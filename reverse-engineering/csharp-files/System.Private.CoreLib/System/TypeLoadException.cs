using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class TypeLoadException : SystemException, ISerializable
{
	private string _className;

	private string _assemblyName;

	private readonly string _messageArg;

	private readonly int _resourceId;

	public override string Message
	{
		get
		{
			SetMessageField();
			return _message;
		}
	}

	internal TypeLoadException(string P_0, string P_1)
		: this(null)
	{
		_className = P_0;
		_assemblyName = P_1;
	}

	private void SetMessageField()
	{
		if (_message == null)
		{
			if (_className == null)
			{
				_message = "Arg_TypeLoadException";
			}
			else
			{
				_message = SR.Format("Could not load type '{0}' from assembly '{1}'.", _className, _assemblyName ?? "IO_UnknownFileName");
			}
		}
	}

	public TypeLoadException()
		: base("Arg_TypeLoadException")
	{
		base.HResult = -2146233054;
	}

	public TypeLoadException(string? P_0)
		: base(P_0)
	{
		base.HResult = -2146233054;
	}

	public override void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		base.GetObjectData(P_0, P_1);
		P_0.AddValue("TypeLoadClassName", _className, typeof(string));
		P_0.AddValue("TypeLoadAssemblyName", _assemblyName, typeof(string));
		P_0.AddValue("TypeLoadMessageArg", _messageArg, typeof(string));
		P_0.AddValue("TypeLoadResourceID", _resourceId);
	}
}
