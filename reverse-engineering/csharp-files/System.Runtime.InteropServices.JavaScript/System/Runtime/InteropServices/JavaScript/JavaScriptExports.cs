using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System.Runtime.InteropServices.JavaScript;

internal static class JavaScriptExports
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe static void CallEntrypoint(JSMarshalerArgument* arguments_buffer)
	{
		ref JSMarshalerArgument reference = ref *arguments_buffer;
		ref JSMarshalerArgument reference2 = ref arguments_buffer[1];
		ref JSMarshalerArgument reference3 = ref arguments_buffer[2];
		ref JSMarshalerArgument reference4 = ref arguments_buffer[3];
		try
		{
			reference3.ToManaged(out nint num);
			if (num == IntPtr.Zero)
			{
				throw new MissingMethodException("Missing entrypoint");
			}
			RuntimeMethodHandle methodHandleFromIntPtr = JSHostImplementation.GetMethodHandleFromIntPtr(num);
			MethodInfo methodInfo = MethodBase.GetMethodFromHandle(methodHandleFromIntPtr) as MethodInfo;
			if (methodInfo == null)
			{
				throw new InvalidProgramException("Can't resolve entrypoint handle");
			}
			reference4.ToManaged(out string[] array);
			object[] array2 = System.Array.Empty<object>();
			Task<int> task = null;
			ParameterInfo[] parameters = methodInfo.GetParameters();
			if (parameters.Length != 0 && parameters[0].ParameterType == typeof(string[]))
			{
				array2 = new object[1] { array ?? System.Array.Empty<string>() };
			}
			if (methodInfo.ReturnType == typeof(void))
			{
				methodInfo.Invoke(null, array2);
			}
			else if (methodInfo.ReturnType == typeof(int))
			{
				int num2 = (int)methodInfo.Invoke(null, array2);
				task = Task.FromResult(num2);
			}
			else if (methodInfo.ReturnType == typeof(Task))
			{
				Task task2 = (Task)methodInfo.Invoke(null, array2);
				TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
				task = tcs.Task;
				task2.ContinueWith(delegate(Task P_0)
				{
					if (P_0.IsFaulted)
					{
						tcs.SetException(P_0.Exception);
					}
					else
					{
						tcs.SetResult(0);
					}
				}, TaskScheduler.Default);
			}
			else
			{
				if (!(methodInfo.ReturnType == typeof(Task<int>)))
				{
					throw new InvalidProgramException("Return type '" + methodInfo.ReturnType.FullName + "' from main method in not supported");
				}
				task = (Task<int>)methodInfo.Invoke(null, array2);
			}
			reference2.ToJS(task, delegate(ref JSMarshalerArgument P_0, int P_1)
			{
				P_0.ToJS(P_1);
			});
		}
		catch (Exception innerException)
		{
			if (innerException is TargetInvocationException { InnerException: not null } ex)
			{
				innerException = ex.InnerException;
			}
			reference.ToJS(innerException);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe static void ReleaseJSOwnedObjectByGCHandle(JSMarshalerArgument* arguments_buffer)
	{
		ref JSMarshalerArgument reference = ref *arguments_buffer;
		ref JSMarshalerArgument reference2 = ref arguments_buffer[2];
		try
		{
			GCHandle gCHandle = (GCHandle)reference2.slot.GCHandle;
			lock (JSHostImplementation.s_gcHandleFromJSOwnedObject)
			{
				JSHostImplementation.s_gcHandleFromJSOwnedObject.Remove(gCHandle.Target);
				gCHandle.Free();
			}
		}
		catch (Exception ex)
		{
			reference.ToJS(ex);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe static void CreateTaskCallback(JSMarshalerArgument* arguments_buffer)
	{
		ref JSMarshalerArgument reference = ref *arguments_buffer;
		ref JSMarshalerArgument reference2 = ref arguments_buffer[1];
		try
		{
			JSHostImplementation.TaskCallback taskCallback = new JSHostImplementation.TaskCallback();
			reference2.slot.Type = MarshalerType.Object;
			reference2.slot.GCHandle = JSHostImplementation.GetJSOwnedObjectGCHandle(taskCallback);
		}
		catch (Exception ex)
		{
			reference.ToJS(ex);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe static void CallDelegate(JSMarshalerArgument* arguments_buffer)
	{
		ref JSMarshalerArgument reference = ref *arguments_buffer;
		ref JSMarshalerArgument reference2 = ref arguments_buffer[2];
		try
		{
			if (((GCHandle)reference2.slot.GCHandle).Target is JSHostImplementation.ToManagedCallback toManagedCallback)
			{
				toManagedCallback(arguments_buffer);
				return;
			}
			throw new InvalidOperationException("ToManagedCallback is null");
		}
		catch (Exception ex)
		{
			reference.ToJS(ex);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe static void CompleteTask(JSMarshalerArgument* arguments_buffer)
	{
		ref JSMarshalerArgument reference = ref *arguments_buffer;
		ref JSMarshalerArgument reference2 = ref arguments_buffer[2];
		try
		{
			if (((GCHandle)reference2.slot.GCHandle).Target is JSHostImplementation.TaskCallback { Callback: not null } taskCallback)
			{
				taskCallback.Callback(arguments_buffer);
				return;
			}
			throw new InvalidOperationException("TaskCallback is null");
		}
		catch (Exception ex)
		{
			reference.ToJS(ex);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe static void GetManagedStackTrace(JSMarshalerArgument* arguments_buffer)
	{
		ref JSMarshalerArgument reference = ref *arguments_buffer;
		ref JSMarshalerArgument reference2 = ref arguments_buffer[1];
		ref JSMarshalerArgument reference3 = ref arguments_buffer[2];
		try
		{
			if (((GCHandle)reference3.slot.GCHandle).Target is Exception ex)
			{
				reference2.ToJS(ex.StackTrace);
				return;
			}
			throw new InvalidOperationException("Exception is null");
		}
		catch (Exception ex2)
		{
			reference.ToJS(ex2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void StopProfile()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public unsafe static void DumpAotProfileData(ref byte buf, int len, string extraArg)
	{
		if (len == 0)
		{
			throw new JSException("Profile data length is 0");
		}
		byte[] array = new byte[len];
		fixed (byte* ptr = &buf)
		{
			void* ptr2 = ptr;
			ReadOnlySpan<byte> readOnlySpan = new ReadOnlySpan<byte>(ptr2, len);
			JSObject propertyAsJSObject = JSHost.DotnetInstance.GetPropertyAsJSObject("INTERNAL");
			if (propertyAsJSObject == null)
			{
				throw new InvalidOperationException();
			}
			propertyAsJSObject.SetProperty("aotProfileData", readOnlySpan.ToArray());
		}
	}
}
