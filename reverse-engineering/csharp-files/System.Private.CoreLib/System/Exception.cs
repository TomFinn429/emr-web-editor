using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace System;

[Serializable]
[StructLayout((LayoutKind)0)]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class Exception : ISerializable
{
	internal readonly struct DispatchState
	{
		public readonly MonoStackFrame[] StackFrames;

		public DispatchState(MonoStackFrame[] P_0)
		{
			StackFrames = P_0;
		}
	}

	private string _unused1;

	internal string _message;

	private IDictionary _data;

	private Exception _innerException;

	private string _helpURL;

	private object _traceIPs;

	private string _stackTraceString;

	private string _remoteStackTraceString;

	private int _unused4;

	private object[] _dynamicMethods;

	private int _HResult;

	private string _source;

	private object _unused6;

	internal MonoStackFrame[] foreignExceptionsFrames;

	private nint[] native_trace_ips;

	private int caught_in_unmanaged;

	private protected const string InnerExceptionPrefix = " ---> ";

	private bool HasBeenThrown => _traceIPs != null;

	public MethodBase? TargetSite
	{
		[RequiresUnreferencedCode("Metadata for the method might be incomplete or removed")]
		get
		{
			StackTrace stackTrace = new StackTrace(this, true);
			if (stackTrace.FrameCount > 0)
			{
				return stackTrace.GetFrame(0)?.GetMethod();
			}
			return null;
		}
	}

	public virtual string Message => _message ?? SR.Format("Exception_WasThrown", GetClassName());

	public Exception? InnerException => _innerException;

	public virtual string? Source
	{
		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The API will return <unknown> if the metadata for current method cannot be established.")]
		get
		{
			return _source ?? (_source = ((!HasBeenThrown) ? null : (TargetSite?.Module.Assembly.GetName().Name ?? "<unknown>")));
		}
		set
		{
			_source = source;
		}
	}

	public int HResult
	{
		get
		{
			return _HResult;
		}
		set
		{
			_HResult = hResult;
		}
	}

	public virtual string? StackTrace
	{
		get
		{
			string stackTraceString = _stackTraceString;
			string remoteStackTraceString = _remoteStackTraceString;
			if (stackTraceString != null)
			{
				return remoteStackTraceString + stackTraceString;
			}
			if (!HasBeenThrown)
			{
				return remoteStackTraceString;
			}
			return remoteStackTraceString + GetStackTrace();
		}
	}

	private string? SerializationStackTraceString
	{
		get
		{
			string text = _stackTraceString;
			if (text == null && HasBeenThrown)
			{
				text = GetStackTrace();
			}
			return text;
		}
	}

	internal DispatchState CaptureDispatchState()
	{
		MonoStackFrame[] array;
		if (_traceIPs != null)
		{
			array = System.Diagnostics.StackTrace.get_trace(this, 0, true);
			if (array.Length != 0)
			{
				array[array.Length - 1].isLastFrameFromForeignException = true;
			}
			MonoStackFrame[] array2 = foreignExceptionsFrames;
			if (array2 != null)
			{
				MonoStackFrame[] array3 = new MonoStackFrame[array.Length + array2.Length];
				Array.Copy(array2, 0, array3, 0, array2.Length);
				Array.Copy(array, 0, array3, array2.Length, array.Length);
				array = array3;
			}
		}
		else
		{
			array = foreignExceptionsFrames;
		}
		return new DispatchState(array);
	}

	internal void RestoreDispatchState(in DispatchState P_0)
	{
		foreignExceptionsFrames = P_0.StackFrames;
		_stackTraceString = null;
	}

	private bool CanSetRemoteStackTrace()
	{
		if (_traceIPs != null || _stackTraceString != null || _remoteStackTraceString != null)
		{
			ThrowHelper.ThrowInvalidOperationException();
		}
		return true;
	}

	public Exception()
	{
		_HResult = -2146233088;
	}

	public Exception(string? P_0)
		: this()
	{
		_message = P_0;
	}

	public Exception(string? P_0, Exception? P_1)
		: this()
	{
		_message = P_0;
		_innerException = P_1;
	}

	private string GetClassName()
	{
		return GetType().ToString();
	}

	public virtual Exception GetBaseException()
	{
		Exception innerException = InnerException;
		Exception result = this;
		while (innerException != null)
		{
			result = innerException;
			innerException = innerException.InnerException;
		}
		return result;
	}

	public virtual void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "info");
		if (_source == null)
		{
			_source = Source;
		}
		P_0.AddValue("ClassName", GetClassName(), typeof(string));
		P_0.AddValue("Message", _message, typeof(string));
		P_0.AddValue("Data", _data, typeof(IDictionary));
		P_0.AddValue("InnerException", _innerException, typeof(Exception));
		P_0.AddValue("HelpURL", _helpURL, typeof(string));
		P_0.AddValue("StackTraceString", SerializationStackTraceString, typeof(string));
		P_0.AddValue("RemoteStackTraceString", _remoteStackTraceString, typeof(string));
		P_0.AddValue("RemoteStackIndex", 0, typeof(int));
		P_0.AddValue("ExceptionMethod", null, typeof(string));
		P_0.AddValue("HResult", _HResult);
		P_0.AddValue("Source", _source, typeof(string));
		P_0.AddValue("WatsonBuckets", null, typeof(byte[]));
	}

	public override string ToString()
	{
		string className = GetClassName();
		string message = Message;
		string text = _innerException?.ToString() ?? "";
		string text2 = "Exception_EndOfInnerExceptionStack";
		string stackTrace = StackTrace;
		int num = className.Length;
		checked
		{
			if (!string.IsNullOrEmpty(message))
			{
				num += 2 + message.Length;
			}
			if (_innerException != null)
			{
				num += "\n".Length + " ---> ".Length + text.Length + "\n".Length + 3 + text2.Length;
			}
			if (stackTrace != null)
			{
				num += "\n".Length + stackTrace.Length;
			}
			string text3 = string.FastAllocateString(num);
			Span<char> span = new Span<char>(ref text3.GetRawStringData(), text3.Length);
			Write(className, ref span);
			if (!string.IsNullOrEmpty(message))
			{
				Write(": ", ref span);
				Write(message, ref span);
			}
			if (_innerException != null)
			{
				Write("\n", ref span);
				Write(" ---> ", ref span);
				Write(text, ref span);
				Write("\n", ref span);
				Write("   ", ref span);
				Write(text2, ref span);
			}
			if (stackTrace != null)
			{
				Write("\n", ref span);
				Write(stackTrace, ref span);
			}
			return text3;
		}
		static void Write(string P_0, ref Span<char> P_1)
		{
			P_0.CopyTo(P_1);
			P_1 = P_1.Slice(P_0.Length);
		}
	}

	public new Type GetType()
	{
		return base.GetType();
	}

	private string GetStackTrace()
	{
		return new StackTrace(this, true).ToString(System.Diagnostics.StackTrace.TraceFormat.Normal);
	}

	[StackTraceHidden]
	internal void SetCurrentStackTrace()
	{
		if (CanSetRemoteStackTrace())
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			new StackTrace(true).ToString(System.Diagnostics.StackTrace.TraceFormat.TrailingNewLine, stringBuilder);
			stringBuilder.AppendLine("Exception_EndStackTraceFromPreviousThrow");
			_remoteStackTraceString = stringBuilder.ToString();
		}
	}
}
