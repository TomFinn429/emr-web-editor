using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace System.Runtime.InteropServices.JavaScript;

[SupportedOSPlatform("browser")]
[CLSCompliant(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public struct JSMarshalerArgument
{
	[StructLayout((LayoutKind)2, Pack = 16, Size = 16)]
	internal struct JSMarshalerArgumentImpl
	{
		[FieldOffset(0)]
		internal bool BooleanValue;

		[FieldOffset(0)]
		internal byte ByteValue;

		[FieldOffset(0)]
		internal char CharValue;

		[FieldOffset(0)]
		internal short Int16Value;

		[FieldOffset(0)]
		internal int Int32Value;

		[FieldOffset(0)]
		internal long Int64Value;

		[FieldOffset(0)]
		internal float SingleValue;

		[FieldOffset(0)]
		internal double DoubleValue;

		[FieldOffset(0)]
		internal nint IntPtrValue;

		[FieldOffset(4)]
		internal nint JSHandle;

		[FieldOffset(4)]
		internal nint GCHandle;

		[FieldOffset(4)]
		internal MarshalerType ElementType;

		[FieldOffset(8)]
		internal int Length;

		[FieldOffset(12)]
		internal MarshalerType Type;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public delegate void ArgumentToManagedCallback<T>(ref JSMarshalerArgument P_0, out T P_1);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public delegate void ArgumentToJSCallback<T>(ref JSMarshalerArgument P_0, T P_1);

	internal JSMarshalerArgumentImpl slot;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Initialize()
	{
		slot.Type = MarshalerType.None;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(char P_0)
	{
		slot.Type = MarshalerType.Char;
		slot.CharValue = P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(char? P_0)
	{
		if (P_0.HasValue)
		{
			slot.Type = MarshalerType.Char;
			slot.CharValue = P_0.Value;
		}
		else
		{
			slot.Type = MarshalerType.None;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(double P_0)
	{
		slot.Type = MarshalerType.Double;
		slot.DoubleValue = P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(double? P_0)
	{
		if (P_0.HasValue)
		{
			slot.Type = MarshalerType.Double;
			slot.DoubleValue = P_0.Value;
		}
		else
		{
			slot.Type = MarshalerType.None;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(double[] P_0)
	{
		if (P_0 == null)
		{
			slot.Type = MarshalerType.None;
			return;
		}
		slot.Type = MarshalerType.Array;
		slot.IntPtrValue = Marshal.AllocHGlobal(P_0.Length * 8);
		slot.Length = P_0.Length;
		slot.ElementType = MarshalerType.Double;
		Marshal.Copy(P_0, 0, slot.IntPtrValue, slot.Length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(float P_0)
	{
		slot.Type = MarshalerType.Single;
		slot.SingleValue = P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(float? P_0)
	{
		if (P_0.HasValue)
		{
			slot.Type = MarshalerType.Single;
			slot.SingleValue = P_0.Value;
		}
		else
		{
			slot.Type = MarshalerType.None;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(short P_0)
	{
		slot.Type = MarshalerType.Int16;
		slot.Int16Value = P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(short? P_0)
	{
		if (P_0.HasValue)
		{
			slot.Type = MarshalerType.Int16;
			slot.Int16Value = P_0.Value;
		}
		else
		{
			slot.Type = MarshalerType.None;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(byte P_0)
	{
		slot.Type = MarshalerType.Byte;
		slot.ByteValue = P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(byte? P_0)
	{
		if (P_0.HasValue)
		{
			slot.Type = MarshalerType.Byte;
			slot.ByteValue = P_0.Value;
		}
		else
		{
			slot.Type = MarshalerType.None;
		}
	}

	public void ToManaged(out byte[]? P_0)
	{
		if (slot.Type == MarshalerType.None)
		{
			P_0 = null;
			return;
		}
		P_0 = new byte[slot.Length];
		Marshal.Copy(slot.IntPtrValue, P_0, 0, slot.Length);
		Marshal.FreeHGlobal(slot.IntPtrValue);
	}

	public void ToJS(byte[]? P_0)
	{
		if (P_0 == null)
		{
			slot.Type = MarshalerType.None;
			return;
		}
		slot.Length = P_0.Length;
		slot.Type = MarshalerType.Array;
		slot.IntPtrValue = Marshal.AllocHGlobal(P_0.Length);
		slot.ElementType = MarshalerType.Byte;
		Marshal.Copy(P_0, 0, slot.IntPtrValue, slot.Length);
	}

	public unsafe void ToJS(Span<byte> P_0)
	{
		slot.Length = P_0.Length;
		slot.IntPtrValue = (nint)Unsafe.AsPointer(ref P_0.GetPinnableReference());
		slot.Type = MarshalerType.Span;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToManaged(out bool P_0)
	{
		if (slot.Type == MarshalerType.None)
		{
			P_0 = false;
		}
		else
		{
			P_0 = slot.BooleanValue;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(bool P_0)
	{
		slot.Type = MarshalerType.Boolean;
		slot.BooleanValue = P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(bool? P_0)
	{
		if (P_0.HasValue)
		{
			slot.Type = MarshalerType.Boolean;
			slot.BooleanValue = P_0.Value;
		}
		else
		{
			slot.Type = MarshalerType.None;
		}
	}

	public unsafe void ToManaged<T>(out Task<T>? P_0, ArgumentToManagedCallback<T> P_1)
	{
		if (slot.Type == MarshalerType.None)
		{
			P_0 = null;
			return;
		}
		GCHandle gCHandle = (GCHandle)slot.GCHandle;
		JSHostImplementation.TaskCallback taskCallback = (JSHostImplementation.TaskCallback)gCHandle.Target;
		if (taskCallback == null)
		{
			throw new NullReferenceException("JSHostImplementation.TaskCallback");
		}
		TaskCompletionSource<T> tcs = new TaskCompletionSource<T>(gCHandle);
		JSHostImplementation.ToManagedCallback callback = delegate(JSMarshalerArgument* ptr)
		{
			ref JSMarshalerArgument reference = ref ptr[3];
			ref JSMarshalerArgument reference2 = ref ptr[4];
			if (reference.slot.Type != MarshalerType.None)
			{
				reference.ToManaged(out Exception ex);
				if (ex == null)
				{
					throw new NullReferenceException("Exception");
				}
				tcs.SetException(ex);
			}
			else
			{
				P_1(ref reference2, out var result);
				tcs.SetResult(result);
			}
		};
		taskCallback.Callback = callback;
		P_0 = tcs.Task;
	}

	internal void ToJSDynamic(Task P_0)
	{
		if (P_0 == null)
		{
			slot.Type = MarshalerType.None;
			return;
		}
		slot.Type = MarshalerType.Task;
		JSObject promise;
		if (P_0.IsCompleted)
		{
			if (P_0.Exception != null)
			{
				Exception exception = P_0.Exception;
				slot.JSHandle = CreateFailedPromise(exception);
			}
			else
			{
				object taskResult = JSHostImplementation.GetTaskResult(P_0);
				slot.JSHandle = CreateResolvedPromise(taskResult, MarshalResult);
			}
		}
		else
		{
			nint num = CreatePendingPromise();
			slot.JSHandle = num;
			promise = JSHostImplementation.CreateCSOwnedProxy(num);
			P_0.GetAwaiter().OnCompleted(Complete);
		}
		void Complete()
		{
			try
			{
				if (P_0.Exception != null)
				{
					FailPromise(promise, P_0.Exception);
				}
				else
				{
					object taskResult2 = JSHostImplementation.GetTaskResult(P_0);
					ResolvePromise(promise, taskResult2, MarshalResult);
				}
			}
			catch (Exception ex)
			{
				throw new InvalidProgramException(ex.Message, ex);
			}
			finally
			{
				promise.Dispose();
			}
		}
		static void MarshalResult(ref JSMarshalerArgument reference, object obj)
		{
			reference.ToJS(obj);
		}
	}

	public void ToJS<T>(Task<T>? P_0, ArgumentToJSCallback<T> P_1)
	{
		if (P_0 == null)
		{
			slot.Type = MarshalerType.None;
			return;
		}
		slot.Type = MarshalerType.Task;
		JSObject promise;
		if (P_0.IsCompleted)
		{
			if (P_0.Exception != null)
			{
				Exception exception = P_0.Exception;
				slot.JSHandle = CreateFailedPromise(exception);
			}
			else
			{
				T result = P_0.Result;
				slot.JSHandle = CreateResolvedPromise(result, P_1);
			}
		}
		else
		{
			nint num = CreatePendingPromise();
			slot.JSHandle = num;
			promise = JSHostImplementation.CreateCSOwnedProxy(num);
			P_0.GetAwaiter().OnCompleted(Complete);
		}
		void Complete()
		{
			try
			{
				if (P_0.Exception != null)
				{
					FailPromise(promise, P_0.Exception);
				}
				else
				{
					T result2 = P_0.Result;
					ResolvePromise(promise, result2, P_1);
				}
			}
			catch (Exception ex)
			{
				throw new InvalidProgramException(ex.Message, ex);
			}
			finally
			{
				promise.Dispose();
			}
		}
	}

	private static nint CreatePendingPromise()
	{
		Span<JSMarshalerArgument> span = stackalloc JSMarshalerArgument[4];
		ref JSMarshalerArgument reference = ref span[0];
		ref JSMarshalerArgument reference2 = ref span[1];
		ref JSMarshalerArgument reference3 = ref span[2];
		ref JSMarshalerArgument reference4 = ref span[3];
		reference.Initialize();
		reference2.Initialize();
		reference4.Initialize();
		reference3.slot.Type = MarshalerType.Task;
		reference3.slot.JSHandle = IntPtr.Zero;
		reference4.slot.Type = MarshalerType.Task;
		JavaScriptImports.MarshalPromise(span);
		return reference2.slot.JSHandle;
	}

	private static nint CreateFailedPromise(Exception P_0)
	{
		Span<JSMarshalerArgument> span = stackalloc JSMarshalerArgument[4];
		ref JSMarshalerArgument reference = ref span[0];
		ref JSMarshalerArgument reference2 = ref span[1];
		ref JSMarshalerArgument reference3 = ref span[2];
		ref JSMarshalerArgument reference4 = ref span[3];
		reference2.Initialize();
		reference4.Initialize();
		reference3.slot.Type = MarshalerType.Task;
		reference3.slot.JSHandle = IntPtr.Zero;
		reference.ToJS(P_0);
		JavaScriptImports.MarshalPromise(span);
		return reference2.slot.JSHandle;
	}

	private static void FailPromise(JSObject P_0, Exception P_1)
	{
		if (P_0.IsDisposed)
		{
			throw new ObjectDisposedException("promise");
		}
		Span<JSMarshalerArgument> span = stackalloc JSMarshalerArgument[4];
		ref JSMarshalerArgument reference = ref span[0];
		ref JSMarshalerArgument reference2 = ref span[1];
		ref JSMarshalerArgument reference3 = ref span[2];
		ref JSMarshalerArgument reference4 = ref span[3];
		reference.Initialize();
		reference2.Initialize();
		reference4.Initialize();
		reference3.slot.Type = MarshalerType.None;
		reference3.slot.JSHandle = P_0.JSHandle;
		reference.ToJS(P_1);
		JavaScriptImports.MarshalPromise(span);
	}

	private static nint CreateResolvedPromise<T>(T P_0, ArgumentToJSCallback<T> P_1)
	{
		Span<JSMarshalerArgument> span = stackalloc JSMarshalerArgument[4];
		ref JSMarshalerArgument reference = ref span[0];
		ref JSMarshalerArgument reference2 = ref span[1];
		ref JSMarshalerArgument reference3 = ref span[2];
		ref JSMarshalerArgument reference4 = ref span[3];
		reference.Initialize();
		reference2.Initialize();
		reference3.slot.Type = MarshalerType.Task;
		reference3.slot.JSHandle = IntPtr.Zero;
		P_1(ref reference4, P_0);
		JavaScriptImports.MarshalPromise(span);
		return reference2.slot.JSHandle;
	}

	private static void ResolvePromise<T>(JSObject P_0, T P_1, ArgumentToJSCallback<T> P_2)
	{
		if (P_0.IsDisposed)
		{
			throw new ObjectDisposedException("promise");
		}
		Span<JSMarshalerArgument> span = stackalloc JSMarshalerArgument[4];
		ref JSMarshalerArgument reference = ref span[0];
		ref JSMarshalerArgument reference2 = ref span[1];
		ref JSMarshalerArgument reference3 = ref span[2];
		ref JSMarshalerArgument reference4 = ref span[3];
		reference.Initialize();
		reference2.Initialize();
		reference3.slot.Type = MarshalerType.None;
		reference3.slot.JSHandle = P_0.JSHandle;
		P_2(ref reference4, P_1);
		JavaScriptImports.MarshalPromise(span);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(DateTimeOffset P_0)
	{
		slot.Type = MarshalerType.DateTimeOffset;
		slot.DoubleValue = P_0.ToUnixTimeMilliseconds();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(DateTimeOffset? P_0)
	{
		if (P_0.HasValue)
		{
			slot.Type = MarshalerType.DateTimeOffset;
			slot.DoubleValue = P_0.Value.ToUnixTimeMilliseconds();
		}
		else
		{
			slot.Type = MarshalerType.None;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(DateTime P_0)
	{
		slot.Type = MarshalerType.DateTime;
		slot.DoubleValue = new DateTimeOffset(P_0).ToUnixTimeMilliseconds();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(DateTime? P_0)
	{
		if (P_0.HasValue)
		{
			slot.Type = MarshalerType.DateTime;
			slot.DoubleValue = new DateTimeOffset(P_0.Value).ToUnixTimeMilliseconds();
		}
		else
		{
			slot.Type = MarshalerType.None;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToManaged(out nint P_0)
	{
		if (slot.Type == MarshalerType.None)
		{
			P_0 = 0;
		}
		else
		{
			P_0 = slot.IntPtrValue;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(nint P_0)
	{
		slot.Type = MarshalerType.IntPtr;
		slot.IntPtrValue = P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(nint? P_0)
	{
		if (P_0.HasValue)
		{
			slot.Type = MarshalerType.IntPtr;
			slot.IntPtrValue = P_0.Value;
		}
		else
		{
			slot.Type = MarshalerType.None;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(object? P_0)
	{
		if (P_0 == null)
		{
			slot.Type = MarshalerType.None;
			return;
		}
		Type type = P_0.GetType();
		if (type.IsPrimitive)
		{
			if (typeof(long) == type)
			{
				throw new NotImplementedException("ToJS: " + type.FullName);
			}
			if (typeof(int) == type)
			{
				int num = (int)P_0;
				ToJS(num);
				return;
			}
			if (typeof(short) == type)
			{
				short num2 = (short)P_0;
				ToJS(num2);
				return;
			}
			if (typeof(byte) == type)
			{
				byte b = (byte)P_0;
				ToJS(b);
				return;
			}
			if (typeof(char) == type)
			{
				char c = (char)P_0;
				ToJS(c);
				return;
			}
			if (typeof(bool) == type)
			{
				bool flag = (bool)P_0;
				ToJS(flag);
				return;
			}
			if (typeof(double) == type)
			{
				double num3 = (double)P_0;
				ToJS(num3);
				return;
			}
			if (typeof(float) == type)
			{
				float num4 = (float)P_0;
				ToJS(num4);
				return;
			}
			if (typeof(nint) == type)
			{
				nint num5 = (nint)P_0;
				ToJS(num5);
				return;
			}
			throw new NotImplementedException("ToJS: " + type.FullName);
		}
		if (typeof(string) == type)
		{
			string text = P_0 as string;
			ToJS(text);
			return;
		}
		if (typeof(DateTimeOffset) == type)
		{
			DateTimeOffset dateTimeOffset = (DateTimeOffset)P_0;
			ToJS(dateTimeOffset);
			return;
		}
		if (typeof(DateTime) == type)
		{
			DateTime dateTime = (DateTime)P_0;
			ToJS(dateTime);
			return;
		}
		Type underlyingType = Nullable.GetUnderlyingType(type);
		if ((object)underlyingType != null && underlyingType != null)
		{
			if (typeof(long) == underlyingType)
			{
				throw new NotImplementedException("ToJS: " + type.FullName);
			}
			if (typeof(int) == underlyingType)
			{
				int? num6 = P_0 as int?;
				ToJS(num6);
				return;
			}
			if (typeof(short) == underlyingType)
			{
				short? num7 = P_0 as short?;
				ToJS(num7);
				return;
			}
			if (typeof(byte) == underlyingType)
			{
				byte? b2 = P_0 as byte?;
				ToJS(b2);
				return;
			}
			if (typeof(char) == underlyingType)
			{
				char? c2 = P_0 as char?;
				ToJS(c2);
				return;
			}
			if (typeof(bool) == underlyingType)
			{
				bool? flag2 = P_0 as bool?;
				ToJS(flag2);
				return;
			}
			if (typeof(double) == underlyingType)
			{
				double? num8 = P_0 as double?;
				ToJS(num8);
				return;
			}
			if (typeof(float) == underlyingType)
			{
				float? num9 = P_0 as float?;
				ToJS(num9);
				return;
			}
			if (typeof(nint) == underlyingType)
			{
				nint? num10 = P_0 as nint?;
				ToJS(num10);
				return;
			}
			if (typeof(DateTimeOffset) == underlyingType)
			{
				DateTimeOffset? dateTimeOffset2 = P_0 as DateTimeOffset?;
				ToJS(dateTimeOffset2);
				return;
			}
			if (!(typeof(DateTime) == underlyingType))
			{
				throw new NotImplementedException("ToJS: " + type.FullName);
			}
			DateTime? dateTime2 = P_0 as DateTime?;
			ToJS(dateTime2);
		}
		else if (typeof(JSObject).IsAssignableFrom(type))
		{
			JSObject jSObject = P_0 as JSObject;
			ToJS(jSObject);
		}
		else if (typeof(Exception).IsAssignableFrom(type))
		{
			Exception ex = P_0 as Exception;
			ToJS(ex);
		}
		else if (typeof(Task<object>) == type)
		{
			Task<object> task = P_0 as Task<object>;
			ToJS(task, delegate(ref JSMarshalerArgument reference, object obj)
			{
				reference.ToJS(obj);
			});
		}
		else if (typeof(Task).IsAssignableFrom(type))
		{
			Task task2 = P_0 as Task;
			ToJSDynamic(task2);
		}
		else if (typeof(byte[]) == type)
		{
			byte[] array = (byte[])P_0;
			ToJS(array);
			slot.ElementType = MarshalerType.Byte;
		}
		else if (typeof(int[]) == type)
		{
			int[] array2 = (int[])P_0;
			ToJS(array2);
		}
		else if (typeof(double[]) == type)
		{
			double[] array3 = (double[])P_0;
			ToJS(array3);
		}
		else if (typeof(string[]) == type)
		{
			string[] array4 = (string[])P_0;
			ToJS(array4);
		}
		else if (typeof(object[]) == type)
		{
			object[] array5 = (object[])P_0;
			ToJS(array5);
		}
		else
		{
			if (type.IsArray)
			{
				throw new NotImplementedException("ToJS: " + type.FullName);
			}
			if (typeof(MulticastDelegate).IsAssignableFrom(type.BaseType))
			{
				throw new NotImplementedException("ToJS: " + type.FullName);
			}
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ArraySegment<>))
			{
				throw new NotImplementedException("ToJS: " + type.FullName);
			}
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Span<>))
			{
				throw new NotImplementedException("ToJS: " + type.FullName);
			}
			slot.Type = MarshalerType.Object;
			slot.GCHandle = JSHostImplementation.GetJSOwnedObjectGCHandle(P_0);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void ToJS(object?[] P_0)
	{
		if (P_0 == null)
		{
			slot.Type = MarshalerType.None;
			return;
		}
		slot.Length = P_0.Length;
		int num = P_0.Length * Marshal.SizeOf(typeof(JSMarshalerArgument));
		slot.Type = MarshalerType.Array;
		JSMarshalerArgument* ptr = (JSMarshalerArgument*)Marshal.AllocHGlobal(num);
		Unsafe.InitBlock(ptr, 0, (uint)num);
		global::Interop.Runtime.RegisterGCRoot((nint)ptr, num, IntPtr.Zero);
		for (int i = 0; i < slot.Length; i++)
		{
			ref JSMarshalerArgument reference = ref ptr[i];
			object obj = P_0[i];
			reference.ToJS(obj);
			P_0[i] = obj;
		}
		slot.ElementType = MarshalerType.Object;
		slot.IntPtrValue = (nint)ptr;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToManaged(out int P_0)
	{
		if (slot.Type == MarshalerType.None)
		{
			P_0 = 0;
		}
		else
		{
			P_0 = slot.Int32Value;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(int P_0)
	{
		slot.Type = MarshalerType.Int32;
		slot.Int32Value = P_0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(int? P_0)
	{
		if (P_0.HasValue)
		{
			slot.Type = MarshalerType.Int32;
			slot.Int32Value = P_0.Value;
		}
		else
		{
			slot.Type = MarshalerType.None;
		}
	}

	public void ToJS(int[]? P_0)
	{
		if (P_0 == null)
		{
			slot.Type = MarshalerType.None;
			return;
		}
		slot.Type = MarshalerType.Array;
		slot.IntPtrValue = Marshal.AllocHGlobal(P_0.Length * 4);
		slot.Length = P_0.Length;
		slot.ElementType = MarshalerType.Int32;
		Marshal.Copy(P_0, 0, slot.IntPtrValue, slot.Length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToManaged(out JSObject? P_0)
	{
		if (slot.Type == MarshalerType.None)
		{
			P_0 = null;
		}
		else
		{
			P_0 = JSHostImplementation.CreateCSOwnedProxy(slot.JSHandle);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(JSObject? P_0)
	{
		if (P_0 == null)
		{
			slot.Type = MarshalerType.None;
			return;
		}
		if (P_0.IsDisposed)
		{
			throw new ObjectDisposedException("value");
		}
		slot.Type = MarshalerType.JSObject;
		slot.JSHandle = P_0.JSHandle;
		if (slot.JSHandle != IntPtr.Zero)
		{
			return;
		}
		throw new ObjectDisposedException("value");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void ToManaged(out string? P_0)
	{
		if (slot.Type == MarshalerType.None)
		{
			P_0 = null;
			return;
		}
		fixed (nint* intPtrValue = &slot.IntPtrValue)
		{
			void* ptr = intPtrValue;
			P_0 = Unsafe.AsRef<string>(ptr);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void ToJS(string? P_0)
	{
		if (P_0 == null)
		{
			slot.Type = MarshalerType.None;
			return;
		}
		slot.Type = MarshalerType.String;
		fixed (nint* intPtrValue = &slot.IntPtrValue)
		{
			string text = P_0;
			nint* ptr = (nint*)Unsafe.AsPointer(ref text);
			*intPtrValue = *ptr;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void ToManaged(out string?[]? P_0)
	{
		if (slot.Type == MarshalerType.None)
		{
			P_0 = null;
			return;
		}
		P_0 = new string[slot.Length];
		JSMarshalerArgument* intPtrValue = (JSMarshalerArgument*)slot.IntPtrValue;
		for (int i = 0; i < slot.Length; i++)
		{
			intPtrValue[i].ToManaged(out string text);
			P_0[i] = text;
		}
		global::Interop.Runtime.DeregisterGCRoot(slot.IntPtrValue);
		Marshal.FreeHGlobal(slot.IntPtrValue);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void ToJS(string?[] P_0)
	{
		if (P_0 == null)
		{
			slot.Type = MarshalerType.None;
			return;
		}
		slot.Length = P_0.Length;
		int num = P_0.Length * Marshal.SizeOf(typeof(JSMarshalerArgument));
		slot.Type = MarshalerType.Array;
		JSMarshalerArgument* ptr = (JSMarshalerArgument*)Marshal.AllocHGlobal(num);
		Unsafe.InitBlock(ptr, 0, (uint)num);
		global::Interop.Runtime.RegisterGCRoot((nint)ptr, num, IntPtr.Zero);
		for (int i = 0; i < slot.Length; i++)
		{
			ref JSMarshalerArgument reference = ref ptr[i];
			string text = P_0[i];
			reference.ToJS(text);
			P_0[i] = text;
		}
		slot.IntPtrValue = (nint)ptr;
		slot.ElementType = MarshalerType.String;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToManaged(out Exception? P_0)
	{
		if (slot.Type == MarshalerType.None)
		{
			P_0 = null;
			return;
		}
		if (slot.Type == MarshalerType.Exception)
		{
			P_0 = (Exception)((GCHandle)slot.GCHandle).Target;
			return;
		}
		JSObject jSObject = null;
		if (slot.JSHandle != IntPtr.Zero)
		{
			jSObject = JSHostImplementation.CreateCSOwnedProxy(slot.JSHandle);
		}
		ToManaged(out string text);
		P_0 = new JSException(text, jSObject);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToJS(Exception? P_0)
	{
		if (P_0 == null)
		{
			slot.Type = MarshalerType.None;
			return;
		}
		Exception ex = P_0;
		if (ex is AggregateException ex2 && ex2.InnerExceptions.Count == 1)
		{
			ex = ex2.InnerExceptions[0];
		}
		if (ex is JSException { jsException: not null } ex3)
		{
			if (ex3.jsException.IsDisposed)
			{
				throw new ObjectDisposedException("value");
			}
			slot.Type = MarshalerType.JSException;
			slot.JSHandle = ex3.jsException.JSHandle;
		}
		else
		{
			ToJS(ex.Message);
			slot.Type = MarshalerType.Exception;
			slot.GCHandle = JSHostImplementation.GetJSOwnedObjectGCHandle(ex);
		}
	}
}
