using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System.Runtime.InteropServices.JavaScript;

internal static class LegacyExports
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetCSOwnedObjectByJSHandleRef(nint jsHandle, int shouldAddInflight, out JSObject result)
	{
		lock (JSHostImplementation.s_csOwnedObjects)
		{
			if (JSHostImplementation.s_csOwnedObjects.TryGetValue((int)jsHandle, out var weakReference))
			{
				weakReference.TryGetTarget(out var jSObject);
				if (shouldAddInflight != 0)
				{
					jSObject?.AddInFlight();
				}
				result = jSObject;
				return;
			}
		}
		result = null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static nint GetCSOwnedObjectJSHandleRef(in JSObject jsObject, int shouldAddInflight)
	{
		jsObject.AssertNotDisposed();
		if (shouldAddInflight != 0)
		{
			jsObject.AddInFlight();
		}
		return jsObject.JSHandle;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static nint TryGetCSOwnedObjectJSHandleRef(in object rawObj, int shouldAddInflight)
	{
		JSObject jSObject = rawObj as JSObject;
		if (jSObject != null && shouldAddInflight != 0)
		{
			jSObject.AddInFlight();
		}
		return jSObject?.JSHandle ?? IntPtr.Zero;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CreateCSOwnedProxyRef(nint jsHandle, JSHostImplementation.MappedType mappedType, int shouldAddInflight, out JSObject jsObject)
	{
		JSObject jSObject = null;
		lock (JSHostImplementation.s_csOwnedObjects)
		{
			if (!JSHostImplementation.s_csOwnedObjects.TryGetValue((int)jsHandle, out var weakReference) || !weakReference.TryGetTarget(out jSObject) || jSObject.IsDisposed)
			{
				jSObject = mappedType switch
				{
					JSHostImplementation.MappedType.JSObject => new JSObject(jsHandle), 
					JSHostImplementation.MappedType.Array => new Array(jsHandle), 
					JSHostImplementation.MappedType.ArrayBuffer => new ArrayBuffer(jsHandle), 
					JSHostImplementation.MappedType.DataView => new DataView(jsHandle), 
					JSHostImplementation.MappedType.Function => new Function(jsHandle), 
					JSHostImplementation.MappedType.Uint8Array => new Uint8Array(jsHandle), 
					_ => throw new ArgumentOutOfRangeException("mappedType"), 
				};
				JSHostImplementation.s_csOwnedObjects[(int)jsHandle] = new WeakReference<JSObject>(jSObject, true);
			}
		}
		if (shouldAddInflight != 0)
		{
			jSObject.AddInFlight();
		}
		jsObject = jSObject;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetJSOwnedObjectByGCHandleRef(int gcHandle, out object result)
	{
		result = ((GCHandle)gcHandle).Target;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static nint GetJSOwnedObjectGCHandleRef(in object obj)
	{
		return JSHostImplementation.GetJSOwnedObjectGCHandle(obj);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static nint CreateTaskSource()
	{
		TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
		object obj = taskCompletionSource;
		return GetJSOwnedObjectGCHandleRef(in obj);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetTaskSourceResultRef(int tcsGCHandle, in object result)
	{
		TaskCompletionSource<object> taskCompletionSource = (TaskCompletionSource<object>)((GCHandle)tcsGCHandle).Target;
		taskCompletionSource.SetResult(result);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetTaskSourceFailure(int tcsGCHandle, string reason)
	{
		TaskCompletionSource<object> taskCompletionSource = (TaskCompletionSource<object>)((GCHandle)tcsGCHandle).Target;
		taskCompletionSource.SetException(new JSException(reason));
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GetTaskSourceTaskRef(int tcsGCHandle, out object result)
	{
		TaskCompletionSource<object> taskCompletionSource = (TaskCompletionSource<object>)((GCHandle)tcsGCHandle).Target;
		result = taskCompletionSource.Task;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetupJSContinuationRef(in Task _task, JSObject continuationObj)
	{
		Task task = _task;
		if (task.IsCompleted)
		{
			Complete();
		}
		else
		{
			task.GetAwaiter().OnCompleted(Complete);
		}
		void Complete()
		{
			try
			{
				if (task.Exception == null)
				{
					Type type = task.GetType();
					object obj = ((!(type == typeof(Task))) ? JSHostImplementation.GetTaskResultMethodInfo(type)?.Invoke(task, null) : System.Array.Empty<object>());
					continuationObj.Invoke("resolve", obj);
				}
				else
				{
					continuationObj.Invoke("reject", task.Exception.ToString());
				}
			}
			catch (Exception ex)
			{
				continuationObj.Invoke("reject", ex.ToString());
			}
			finally
			{
				continuationObj.Dispose();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ObjectToStringRef(ref object o)
	{
		return o.ToString() ?? string.Empty;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static double GetDateValueRef(ref object dtv)
	{
		ArgumentNullException.ThrowIfNull(dtv, "dtv");
		if (!(dtv is DateTime dateTime))
		{
			throw new InvalidCastException(System.SR.Format("UnableCastObjectToType", dtv.GetType(), typeof(DateTime)));
		}
		if (dateTime.Kind == DateTimeKind.Local)
		{
			dateTime = dateTime.ToUniversalTime();
		}
		else if (dateTime.Kind == DateTimeKind.Unspecified)
		{
			dateTime = new DateTime(dateTime.Ticks, DateTimeKind.Utc);
		}
		return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CreateDateTimeRef(double ticks, out object result)
	{
		result = DateTimeOffset.FromUnixTimeMilliseconds((long)ticks).DateTime;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CreateUriRef(string uri, out object result)
	{
		Type type = Type.GetType("System.Uri, System.Private.Uri");
		if (type == null)
		{
			throw new InvalidProgramException();
		}
		result = Activator.CreateInstance(type, uri);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool IsSimpleArrayRef(ref object a)
	{
		if (a is System.Array { Rank: 1 } array)
		{
			return array.GetLowerBound(0) == 0;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string GetCallSignatureRef(nint _methodHandle, in object objForRuntimeType)
	{
		RuntimeMethodHandle methodHandleFromIntPtr = JSHostImplementation.GetMethodHandleFromIntPtr(_methodHandle);
		MethodBase methodBase = ((objForRuntimeType == null) ? MethodBase.GetMethodFromHandle(methodHandleFromIntPtr) : MethodBase.GetMethodFromHandle(methodHandleFromIntPtr, Type.GetTypeHandle(objForRuntimeType)));
		if ((object)methodBase == null)
		{
			return string.Empty;
		}
		ParameterInfo[] parameters = methodBase.GetParameters();
		int num = parameters.Length;
		if (num == 0)
		{
			return string.Empty;
		}
		char[] array = new char[num];
		for (int i = 0; i < num; i++)
		{
			Type parameterType = parameters[i].ParameterType;
			JSHostImplementation.MarshalType marshalTypeFromType = JSHostImplementation.GetMarshalTypeFromType(parameterType);
			array[i] = JSHostImplementation.GetCallSignatureCharacterForMarshalType(marshalTypeFromType, null);
		}
		return new string(array);
	}
}
