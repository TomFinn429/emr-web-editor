using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime.InteropServices.JavaScript;

internal static class JSHostImplementation
{
	internal unsafe delegate void ToManagedCallback(JSMarshalerArgument* P_0);

	public sealed class TaskCallback
	{
		public ToManagedCallback Callback;
	}

	[StructLayout((LayoutKind)2)]
	public struct IntPtrAndHandle
	{
		[FieldOffset(0)]
		internal nint ptr;

		[FieldOffset(0)]
		internal RuntimeMethodHandle methodHandle;

		[FieldOffset(0)]
		internal RuntimeTypeHandle typeHandle;
	}

	public enum MarshalType
	{
		NULL = 0,
		INT = 1,
		FP64 = 2,
		STRING = 3,
		VT = 4,
		DELEGATE = 5,
		TASK = 6,
		OBJECT = 7,
		BOOL = 8,
		ENUM = 9,
		URI = 22,
		SAFEHANDLE = 23,
		ARRAY_BYTE = 10,
		ARRAY_UBYTE = 11,
		ARRAY_UBYTE_C = 12,
		ARRAY_SHORT = 13,
		ARRAY_USHORT = 14,
		ARRAY_INT = 15,
		ARRAY_UINT = 16,
		ARRAY_FLOAT = 17,
		ARRAY_DOUBLE = 18,
		FP32 = 24,
		UINT32 = 25,
		INT64 = 26,
		UINT64 = 27,
		CHAR = 28,
		STRING_INTERNED = 29,
		VOID = 30,
		ENUM64 = 31,
		POINTER = 32
	}

	public enum MappedType
	{
		JSObject = 0,
		Array = 1,
		ArrayBuffer = 2,
		DataView = 3,
		Function = 4,
		Uint8Array = 11
	}

	private static readonly MethodInfo s_taskGetResultMethodInfo = typeof(Task<>).GetMethod("get_Result");

	public static readonly Dictionary<int, WeakReference<JSObject>> s_csOwnedObjects = new Dictionary<int, WeakReference<JSObject>>();

	public static Dictionary<object, nint> s_gcHandleFromJSOwnedObject = new Dictionary<object, nint>(ReferenceEqualityComparer.Instance);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ReleaseCSOwnedObject(nint P_0)
	{
		if (P_0 != IntPtr.Zero)
		{
			lock (s_csOwnedObjects)
			{
				s_csOwnedObjects.Remove((int)P_0);
			}
			global::Interop.Runtime.ReleaseCSOwnedObject(P_0);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static object GetTaskResult(Task P_0)
	{
		MethodInfo taskResultMethodInfo = GetTaskResultMethodInfo(P_0.GetType());
		if (taskResultMethodInfo != null)
		{
			return taskResultMethodInfo.Invoke(P_0, null);
		}
		throw new InvalidOperationException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ReleaseInFlight(object P_0)
	{
		if (P_0 is JSObject jSObject)
		{
			jSObject.ReleaseInFlight();
		}
	}

	public static nint GetJSOwnedObjectGCHandle(object P_0, GCHandleType P_1 = GCHandleType.Normal)
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		lock (s_gcHandleFromJSOwnedObject)
		{
			if (s_gcHandleFromJSOwnedObject.TryGetValue(P_0, out var result))
			{
				return result;
			}
			nint num = (nint)GCHandle.Alloc(P_0, P_1);
			s_gcHandleFromJSOwnedObject[P_0] = num;
			return num;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static RuntimeMethodHandle GetMethodHandleFromIntPtr(nint P_0)
	{
		IntPtrAndHandle intPtrAndHandle = new IntPtrAndHandle
		{
			ptr = P_0
		};
		return intPtrAndHandle.methodHandle;
	}

	public static MarshalType GetMarshalTypeFromType(Type P_0)
	{
		if ((object)P_0 == null)
		{
			return MarshalType.VOID;
		}
		TypeCode typeCode = Type.GetTypeCode(P_0);
		if (P_0.IsEnum)
		{
			switch (typeCode)
			{
			case TypeCode.Int32:
			case TypeCode.UInt32:
				return MarshalType.ENUM;
			case TypeCode.Int64:
			case TypeCode.UInt64:
				return MarshalType.ENUM64;
			default:
				throw new JSException($"Unsupported enum underlying type {typeCode}");
			}
		}
		switch (typeCode)
		{
		case TypeCode.SByte:
		case TypeCode.Int16:
		case TypeCode.Int32:
			return MarshalType.INT;
		case TypeCode.Byte:
		case TypeCode.UInt16:
		case TypeCode.UInt32:
			return MarshalType.UINT32;
		case TypeCode.Boolean:
			return MarshalType.BOOL;
		case TypeCode.Int64:
			return MarshalType.INT64;
		case TypeCode.UInt64:
			return MarshalType.UINT64;
		case TypeCode.Single:
			return MarshalType.FP32;
		case TypeCode.Double:
			return MarshalType.FP64;
		case TypeCode.String:
			return MarshalType.STRING;
		case TypeCode.Char:
			return MarshalType.CHAR;
		default:
			if (P_0.IsArray)
			{
				if (!P_0.IsSZArray)
				{
					throw new JSException("Only single-dimensional arrays with a zero lower bound can be marshaled to JS");
				}
				Type elementType = P_0.GetElementType();
				return Type.GetTypeCode(elementType) switch
				{
					TypeCode.Byte => MarshalType.ARRAY_UBYTE, 
					TypeCode.SByte => MarshalType.ARRAY_BYTE, 
					TypeCode.Int16 => MarshalType.ARRAY_SHORT, 
					TypeCode.UInt16 => MarshalType.ARRAY_USHORT, 
					TypeCode.Int32 => MarshalType.ARRAY_INT, 
					TypeCode.UInt32 => MarshalType.ARRAY_UINT, 
					TypeCode.Single => MarshalType.ARRAY_FLOAT, 
					TypeCode.Double => MarshalType.ARRAY_DOUBLE, 
					_ => throw new JSException($"Unsupported array element type {elementType}"), 
				};
			}
			if (P_0 == typeof(nint))
			{
				return MarshalType.POINTER;
			}
			if (P_0 == typeof(nuint))
			{
				return MarshalType.POINTER;
			}
			if (P_0 == typeof(SafeHandle))
			{
				return MarshalType.SAFEHANDLE;
			}
			if (typeof(Delegate).IsAssignableFrom(P_0))
			{
				return MarshalType.DELEGATE;
			}
			if (P_0 == typeof(Task) || typeof(Task).IsAssignableFrom(P_0))
			{
				return MarshalType.TASK;
			}
			if (P_0.FullName == "System.Uri")
			{
				return MarshalType.URI;
			}
			if (P_0.IsPointer)
			{
				return MarshalType.POINTER;
			}
			if (P_0.IsValueType)
			{
				return MarshalType.VT;
			}
			return MarshalType.OBJECT;
		}
	}

	public static char GetCallSignatureCharacterForMarshalType(MarshalType P_0, char? P_1)
	{
		switch (P_0)
		{
		case MarshalType.BOOL:
			return 'b';
		case MarshalType.UINT32:
		case MarshalType.POINTER:
			return 'I';
		case MarshalType.INT:
			return 'i';
		case MarshalType.UINT64:
			return 'L';
		case MarshalType.INT64:
			return 'l';
		case MarshalType.FP32:
			return 'f';
		case MarshalType.FP64:
			return 'd';
		case MarshalType.STRING:
			return 's';
		case MarshalType.URI:
			return 'u';
		case MarshalType.SAFEHANDLE:
			return 'h';
		case MarshalType.ENUM:
			return 'j';
		case MarshalType.ENUM64:
			return 'k';
		case MarshalType.DELEGATE:
		case MarshalType.TASK:
		case MarshalType.OBJECT:
			return 'o';
		case MarshalType.VT:
			return 'a';
		default:
			if (P_1.HasValue)
			{
				return P_1.Value;
			}
			throw new JSException($"Unsupported marshal type {P_0}");
		}
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2070:UnrecognizedReflectionPattern", Justification = "Task<T>.Result is preserved by the ILLinker because _taskGetResultMethodInfo was initialized with it.")]
	public static MethodInfo GetTaskResultMethodInfo(Type P_0)
	{
		if (P_0 != null)
		{
			MethodInfo method = P_0.GetMethod("get_Result");
			if (method != null && method.HasSameMetadataDefinitionAs(s_taskGetResultMethodInfo))
			{
				return method;
			}
		}
		throw new InvalidOperationException();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ThrowException(ref JSMarshalerArgument P_0)
	{
		P_0.ToManaged(out Exception ex);
		if (ex != null)
		{
			throw ex;
		}
		throw new InvalidProgramException();
	}

	public static async Task<JSObject> ImportAsync(string P_0, string P_1, CancellationToken P_2)
	{
		Task<JSObject> task = JavaScriptImports.DynamicImport(P_0, P_1);
		Task<JSObject> wrappedTask = CancelationHelper(task, P_2);
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		return await wrappedTask.ConfigureAwait(true);
	}

	public static async Task<JSObject> CancelationHelper(Task<JSObject> P_0, CancellationToken P_1)
	{
		if (P_0.IsCompletedSuccessfully)
		{
			return P_0.Result;
		}
		using (P_1.Register(delegate
		{
			CancelablePromise.CancelPromise(P_0);
		}))
		{
			return await P_0.ConfigureAwait(true);
		}
	}

	public unsafe static JSFunctionBinding GetMethodSignature(ReadOnlySpan<JSMarshalerType> P_0)
	{
		int num = P_0.Length - 1;
		int num2 = 8 + (num + 2) * sizeof(JSFunctionBinding.JSBindingType);
		nint num3 = Marshal.AllocHGlobal(num2);
		JSFunctionBinding jSFunctionBinding = new JSFunctionBinding();
		jSFunctionBinding.Header = (JSFunctionBinding.JSBindingHeader*)num3;
		jSFunctionBinding.Sigs = (JSFunctionBinding.JSBindingType*)(num3 + 8 + 2 * sizeof(JSFunctionBinding.JSBindingType));
		JSFunctionBinding jSFunctionBinding2 = jSFunctionBinding;
		jSFunctionBinding2.Version = 1;
		jSFunctionBinding2.ArgumentCount = num;
		jSFunctionBinding2.Exception = JSMarshalerType.Exception._signatureType;
		jSFunctionBinding2.Result = P_0[0]._signatureType;
		for (int i = 0; i < num; i++)
		{
			jSFunctionBinding2.Sigs[i] = P_0[i + 1]._signatureType;
		}
		return jSFunctionBinding2;
	}

	public static JSObject CreateCSOwnedProxy(nint P_0)
	{
		JSObject jSObject = null;
		lock (s_csOwnedObjects)
		{
			if (!s_csOwnedObjects.TryGetValue((int)P_0, out var weakReference) || !weakReference.TryGetTarget(out jSObject) || jSObject.IsDisposed)
			{
				jSObject = new JSObject(P_0);
				s_csOwnedObjects[(int)P_0] = new WeakReference<JSObject>(jSObject, true);
			}
		}
		return jSObject;
	}
}
