using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Microsoft.JSInterop.Infrastructure;

public static class DotNetDispatcher
{
	private readonly struct AssemblyKey : IEquatable<AssemblyKey>
	{
		public Assembly Assembly { get; }

		public string AssemblyName { get; }

		public AssemblyKey(Assembly P_0)
		{
			Assembly = P_0;
			AssemblyName = P_0.GetName().Name;
		}

		public AssemblyKey(string P_0)
		{
			Assembly = null;
			AssemblyName = P_0;
		}

		public bool Equals(AssemblyKey P_0)
		{
			if (Assembly != null && P_0.Assembly != null)
			{
				return Assembly == P_0.Assembly;
			}
			return AssemblyName.Equals(P_0.AssemblyName, StringComparison.Ordinal);
		}

		public override int GetHashCode()
		{
			return StringComparer.Ordinal.GetHashCode(AssemblyName);
		}
	}

	internal static readonly JsonEncodedText DotNetObjectRefKey = JsonEncodedText.Encode("__dotNetObject");

	private static readonly ConcurrentDictionary<AssemblyKey, IReadOnlyDictionary<string, (MethodInfo, Type[])>> _cachedMethodsByAssembly = new ConcurrentDictionary<AssemblyKey, IReadOnlyDictionary<string, (MethodInfo, Type[])>>();

	private static readonly ConcurrentDictionary<Type, IReadOnlyDictionary<string, (MethodInfo, Type[])>> _cachedMethodsByType = new ConcurrentDictionary<Type, IReadOnlyDictionary<string, (MethodInfo, Type[])>>();

	private static readonly ConcurrentDictionary<Type, Func<object, Task>> _cachedConvertToTaskByType = new ConcurrentDictionary<Type, Func<object, Task>>();

	private static readonly MethodInfo _taskConverterMethodInfo = typeof(DotNetDispatcher).GetMethod("CreateValueTaskConverter", BindingFlags.Static | BindingFlags.NonPublic);

	[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "We expect application code is configured to ensure return types of JSInvokable methods are retained.")]
	public static string? Invoke(JSRuntime P_0, in DotNetInvocationInfo P_1, string P_2)
	{
		IDotNetObjectReference dotNetObjectReference = null;
		if (P_1.DotNetObjectId != 0L)
		{
			dotNetObjectReference = P_0.GetObjectReference(P_1.DotNetObjectId);
		}
		object obj = InvokeSynchronously(P_0, in P_1, dotNetObjectReference, P_2);
		if (obj == null)
		{
			return null;
		}
		return JsonSerializer.Serialize(obj, P_0.JsonSerializerOptions);
	}

	[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "We expect application code is configured to ensure return types of JSInvokable methods are retained.")]
	public static void BeginInvokeDotNet(JSRuntime P_0, DotNetInvocationInfo P_1, string P_2)
	{
		string callId = P_1.CallId;
		object obj = null;
		ExceptionDispatchInfo exceptionDispatchInfo = null;
		IDotNetObjectReference dotNetObjectReference = null;
		try
		{
			if (P_1.DotNetObjectId != 0L)
			{
				dotNetObjectReference = P_0.GetObjectReference(P_1.DotNetObjectId);
			}
			obj = InvokeSynchronously(P_0, in P_1, dotNetObjectReference, P_2);
		}
		catch (Exception ex)
		{
			exceptionDispatchInfo = ExceptionDispatchInfo.Capture(ex);
		}
		if (callId == null)
		{
			return;
		}
		if (exceptionDispatchInfo != null)
		{
			P_0.EndInvokeDotNet(P_1, new DotNetInvocationResult(exceptionDispatchInfo.SourceException, "InvocationFailure"));
			return;
		}
		if (obj is Task task)
		{
			task.ContinueWith(delegate(Task task2)
			{
				EndInvokeDotNetAfterTask(task2, P_0, in P_1);
			}, TaskScheduler.Current);
			return;
		}
		if (obj is ValueTask valueTask)
		{
			valueTask.AsTask().ContinueWith(delegate(Task task2)
			{
				EndInvokeDotNetAfterTask(task2, P_0, in P_1);
			}, TaskScheduler.Current);
			return;
		}
		Type type = obj?.GetType();
		if ((object)type != null && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ValueTask<>))
		{
			GetTaskByType(type.GenericTypeArguments[0], obj).ContinueWith(delegate(Task task2)
			{
				EndInvokeDotNetAfterTask(task2, P_0, in P_1);
			}, TaskScheduler.Current);
		}
		else
		{
			string text = JsonSerializer.Serialize(obj, P_0.JsonSerializerOptions);
			DotNetInvocationResult dotNetInvocationResult = new DotNetInvocationResult(text);
			P_0.EndInvokeDotNet(P_1, in dotNetInvocationResult);
		}
	}

	[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "We expect application code is configured to ensure return types of JSInvokable methods are retained.")]
	private static void EndInvokeDotNetAfterTask(Task P_0, JSRuntime P_1, in DotNetInvocationInfo P_2)
	{
		if (P_0.Exception != null)
		{
			ExceptionDispatchInfo exceptionDispatchInfo = ExceptionDispatchInfo.Capture(P_0.Exception.GetBaseException());
			DotNetInvocationResult dotNetInvocationResult = new DotNetInvocationResult(exceptionDispatchInfo.SourceException, "InvocationFailure");
			P_1.EndInvokeDotNet(P_2, in dotNetInvocationResult);
		}
		string text = JsonSerializer.Serialize(TaskGenericsUtil.GetTaskResult(P_0), P_1.JsonSerializerOptions);
		P_1.EndInvokeDotNet(P_2, new DotNetInvocationResult(text));
	}

	private static object InvokeSynchronously(JSRuntime P_0, in DotNetInvocationInfo P_1, IDotNetObjectReference P_2, string P_3)
	{
		string assemblyName = P_1.AssemblyName;
		string methodIdentifier = P_1.MethodIdentifier;
		MethodInfo methodInfo;
		Type[] array;
		if (P_2 == null)
		{
			(methodInfo, array) = GetCachedMethodInfo(new AssemblyKey(assemblyName), methodIdentifier);
		}
		else
		{
			if (assemblyName != null)
			{
				throw new ArgumentException($"For instance method calls, '{"assemblyName"}' should be null. Value received: '{assemblyName}'.");
			}
			if (string.Equals("__Dispose", methodIdentifier, StringComparison.Ordinal))
			{
				P_2.Dispose();
				return null;
			}
			(methodInfo, array) = GetCachedMethodInfo(P_2, methodIdentifier);
		}
		object[] array2 = ParseArguments(P_0, methodIdentifier, P_3, array);
		try
		{
			return methodInfo.Invoke(P_2?.Value, array2);
		}
		catch (TargetInvocationException ex)
		{
			if (ex.InnerException != null)
			{
				ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
				throw ex.InnerException;
			}
			throw;
		}
		finally
		{
			P_0.ByteArraysToBeRevived.Clear();
		}
	}

	[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "We expect application code is configured to ensure return types of JSInvokable methods are retained.")]
	internal static object?[] ParseArguments(JSRuntime P_0, string P_1, string P_2, Type[] P_3)
	{
		if (P_3.Length == 0)
		{
			return Array.Empty<object>();
		}
		int byteCount = Encoding.UTF8.GetByteCount(P_2);
		byte[] array = ArrayPool<byte>.Shared.Rent(byteCount);
		try
		{
			Encoding.UTF8.GetBytes(P_2, array);
			Utf8JsonReader utf8JsonReader = new Utf8JsonReader((ReadOnlySpan<byte>)array.AsSpan(0, byteCount), default(JsonReaderOptions));
			if (!utf8JsonReader.Read() || utf8JsonReader.TokenType != JsonTokenType.StartArray)
			{
				throw new JsonException("Invalid JSON");
			}
			object[] array2 = new object[P_3.Length];
			int i;
			for (i = 0; i < P_3.Length; i++)
			{
				if (!utf8JsonReader.Read())
				{
					break;
				}
				if (utf8JsonReader.TokenType == JsonTokenType.EndArray)
				{
					break;
				}
				Type type = P_3[i];
				if (utf8JsonReader.TokenType == JsonTokenType.StartObject && IsIncorrectDotNetObjectRefUse(type, utf8JsonReader))
				{
					throw new InvalidOperationException($"In call to '{P_1}', parameter of type '{type.Name}' at index {i + 1} must be declared as type 'DotNetObjectRef<{type.Name}>' to receive the incoming value.");
				}
				array2[i] = JsonSerializer.Deserialize(ref utf8JsonReader, type, P_0.JsonSerializerOptions);
			}
			if (i < P_3.Length)
			{
				throw new ArgumentException($"The call to '{P_1}' expects '{P_3.Length}' parameters, but received '{i}'.");
			}
			if (!utf8JsonReader.Read() || utf8JsonReader.TokenType != JsonTokenType.EndArray)
			{
				throw new JsonException($"Unexpected JSON token {utf8JsonReader.TokenType}. Ensure that the call to `{P_1}' is supplied with exactly '{P_3.Length}' parameters.");
			}
			return array2;
		}
		finally
		{
			ArrayPool<byte>.Shared.Return(array);
		}
		static bool IsIncorrectDotNetObjectRefUse(Type type2, Utf8JsonReader utf8JsonReader2)
		{
			if (utf8JsonReader2.Read() && utf8JsonReader2.TokenType == JsonTokenType.PropertyName && utf8JsonReader2.ValueTextEquals(DotNetObjectRefKey.EncodedUtf8Bytes))
			{
				if (type2.IsGenericType)
				{
					return type2.GetGenericTypeDefinition() != typeof(DotNetObjectReference<>);
				}
				return true;
			}
			return false;
		}
	}

	public static void EndInvokeJS(JSRuntime P_0, string P_1)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(P_1);
		Utf8JsonReader utf8JsonReader = new Utf8JsonReader((ReadOnlySpan<byte>)bytes, default(JsonReaderOptions));
		if (!utf8JsonReader.Read() || utf8JsonReader.TokenType != JsonTokenType.StartArray)
		{
			throw new JsonException("Invalid JSON");
		}
		utf8JsonReader.Read();
		long @int = utf8JsonReader.GetInt64();
		utf8JsonReader.Read();
		bool boolean = utf8JsonReader.GetBoolean();
		utf8JsonReader.Read();
		if (!P_0.EndInvokeJS(@int, boolean, ref utf8JsonReader) || (utf8JsonReader.Read() && utf8JsonReader.TokenType == JsonTokenType.EndArray))
		{
			return;
		}
		throw new JsonException("Invalid JSON");
	}

	public static void ReceiveByteArray(JSRuntime P_0, int P_1, byte[] P_2)
	{
		P_0.ReceiveByteArray(P_1, P_2);
	}

	private static (MethodInfo, Type[]) GetCachedMethodInfo(AssemblyKey P_0, string P_1)
	{
		if (string.IsNullOrWhiteSpace(P_0.AssemblyName))
		{
			throw new ArgumentException("Property 'AssemblyName' cannot be null, empty, or whitespace.", "assemblyKey");
		}
		if (string.IsNullOrWhiteSpace(P_1))
		{
			throw new ArgumentException("Cannot be null, empty, or whitespace.", "methodIdentifier");
		}
		if (_cachedMethodsByAssembly.GetOrAdd(P_0, ScanAssemblyForCallableMethods).TryGetValue(P_1, out var result))
		{
			return result;
		}
		throw new ArgumentException($"The assembly '{P_0.AssemblyName}' does not contain a public invokable method with [{"JSInvokableAttribute"}(\"{P_1}\")].");
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2060:MakeGenericMethod", Justification = "https://github.com/mono/linker/issues/1727")]
	private static Task GetTaskByType(Type P_0, object P_1)
	{
		return _cachedConvertToTaskByType.GetOrAdd(P_0, (Type type, MethodInfo methodInfo) => methodInfo.MakeGenericMethod(type).CreateDelegate<Func<object, Task>>(), _taskConverterMethodInfo)(P_1);
	}

	private static Task CreateValueTaskConverter<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)] T>(object result)
	{
		return ((ValueTask<T>)result).AsTask();
	}

	private static (MethodInfo methodInfo, Type[] parameterTypes) GetCachedMethodInfo(IDotNetObjectReference P_0, string P_1)
	{
		Type type = P_0.Value.GetType();
		if (_cachedMethodsByType.GetOrAdd(type, ScanTypeForCallableMethods).TryGetValue(P_1, out var result))
		{
			return result;
		}
		throw new ArgumentException($"The type '{type.Name}' does not contain a public invokable method with [{"JSInvokableAttribute"}(\"{P_1}\")].");
		static Dictionary<string, (MethodInfo, Type[])> ScanTypeForCallableMethods([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] Type type2)
		{
			Dictionary<string, (MethodInfo, Type[])> dictionary = new Dictionary<string, (MethodInfo, Type[])>(StringComparer.Ordinal);
			MethodInfo[] methods = type2.GetMethods(BindingFlags.Instance | BindingFlags.Public);
			foreach (MethodInfo methodInfo in methods)
			{
				if (!methodInfo.ContainsGenericParameters && methodInfo.IsDefined(typeof(JSInvokableAttribute), false))
				{
					string text = methodInfo.GetCustomAttribute<JSInvokableAttribute>(false).Identifier ?? methodInfo.Name;
					Type[] parameterTypes = GetParameterTypes(methodInfo);
					if (dictionary.ContainsKey(text))
					{
						throw new InvalidOperationException("The type " + type2.Name + " contains more than one [JSInvokable] method with identifier '" + text + "'. All [JSInvokable] methods within the same type must have different identifiers. You can pass a custom identifier as a parameter to the [JSInvokable] attribute.");
					}
					dictionary.Add(text, (methodInfo, parameterTypes));
				}
			}
			return dictionary;
		}
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "We expect application code is configured to ensure JSInvokable methods are retained. https://github.com/dotnet/aspnetcore/issues/29946")]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2072", Justification = "We expect application code is configured to ensure JSInvokable methods are retained. https://github.com/dotnet/aspnetcore/issues/29946")]
	[UnconditionalSuppressMessage("Trimming", "IL2075", Justification = "We expect application code is configured to ensure JSInvokable methods are retained. https://github.com/dotnet/aspnetcore/issues/29946")]
	private static Dictionary<string, (MethodInfo, Type[])> ScanAssemblyForCallableMethods(AssemblyKey P_0)
	{
		Dictionary<string, (MethodInfo, Type[])> dictionary = new Dictionary<string, (MethodInfo, Type[])>(StringComparer.Ordinal);
		Type[] exportedTypes = GetRequiredLoadedAssembly(P_0).GetExportedTypes();
		for (int i = 0; i < exportedTypes.Length; i++)
		{
			MethodInfo[] methods = exportedTypes[i].GetMethods(BindingFlags.Static | BindingFlags.Public);
			foreach (MethodInfo methodInfo in methods)
			{
				if (!methodInfo.ContainsGenericParameters && methodInfo.IsDefined(typeof(JSInvokableAttribute), false))
				{
					string text = methodInfo.GetCustomAttribute<JSInvokableAttribute>(false).Identifier ?? methodInfo.Name;
					Type[] parameterTypes = GetParameterTypes(methodInfo);
					if (dictionary.ContainsKey(text))
					{
						throw new InvalidOperationException("The assembly '" + P_0.AssemblyName + "' contains more than one [JSInvokable] method with identifier '" + text + "'. All [JSInvokable] methods within the same assembly must have different identifiers. You can pass a custom identifier as a parameter to the [JSInvokable] attribute.");
					}
					dictionary.Add(text, (methodInfo, parameterTypes));
				}
			}
		}
		return dictionary;
	}

	private static Type[] GetParameterTypes(MethodInfo P_0)
	{
		ParameterInfo[] parameters = P_0.GetParameters();
		if (parameters.Length == 0)
		{
			return Type.EmptyTypes;
		}
		Type[] array = new Type[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			array[i] = parameters[i].ParameterType;
		}
		return array;
	}

	private static Assembly GetRequiredLoadedAssembly(AssemblyKey P_0)
	{
		Assembly assembly = null;
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly2 in assemblies)
		{
			if (new AssemblyKey(assembly2).Equals(P_0))
			{
				assembly = assembly2;
			}
		}
		return assembly ?? throw new ArgumentException("There is no loaded assembly with the name '" + P_0.AssemblyName + "'.");
	}
}
