using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization;
using System.Text;

namespace System;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class AggregateException : Exception
{
	private readonly Exception[] _innerExceptions;

	private ReadOnlyCollection<Exception> _rocView;

	public ReadOnlyCollection<Exception> InnerExceptions => _rocView ?? (_rocView = new ReadOnlyCollection<Exception>(_innerExceptions));

	public override string Message
	{
		get
		{
			if (_innerExceptions.Length == 0)
			{
				return base.Message;
			}
			Span<char> span = stackalloc char[256];
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(span);
			valueStringBuilder.Append(base.Message);
			valueStringBuilder.Append(' ');
			for (int i = 0; i < _innerExceptions.Length; i++)
			{
				valueStringBuilder.Append('(');
				valueStringBuilder.Append(_innerExceptions[i].Message);
				valueStringBuilder.Append(") ");
			}
			valueStringBuilder.Length--;
			return valueStringBuilder.ToString();
		}
	}

	public AggregateException(IEnumerable<Exception> P_0)
		: this("AggregateException_ctor_DefaultMessage", P_0 ?? throw new ArgumentNullException("innerExceptions"))
	{
	}

	public AggregateException(params Exception[] P_0)
		: this("AggregateException_ctor_DefaultMessage", P_0 ?? throw new ArgumentNullException("innerExceptions"))
	{
	}

	public AggregateException(string? P_0, IEnumerable<Exception> P_1)
		: this(P_0, new List<Exception>(P_1 ?? throw new ArgumentNullException("innerExceptions")).ToArray(), false)
	{
	}

	public AggregateException(string? P_0, params Exception[] P_1)
		: this(P_0, P_1 ?? throw new ArgumentNullException("innerExceptions"), true)
	{
	}

	private AggregateException(string P_0, Exception[] P_1, bool P_2)
		: base(P_0, (P_1.Length != 0) ? P_1[0] : null)
	{
		_innerExceptions = (P_2 ? new Exception[P_1.Length] : P_1);
		for (int i = 0; i < _innerExceptions.Length; i++)
		{
			_innerExceptions[i] = P_1[i];
			if (P_1[i] == null)
			{
				throw new ArgumentException("AggregateException_ctor_InnerExceptionNull");
			}
		}
	}

	internal AggregateException(List<ExceptionDispatchInfo> P_0)
		: this("AggregateException_ctor_DefaultMessage", P_0)
	{
	}

	internal AggregateException(string P_0, List<ExceptionDispatchInfo> P_1)
		: base(P_0, (P_1.Count != 0) ? P_1[0].SourceException : null)
	{
		_innerExceptions = new Exception[P_1.Count];
		for (int i = 0; i < _innerExceptions.Length; i++)
		{
			_innerExceptions[i] = P_1[i].SourceException;
		}
	}

	public override void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		base.GetObjectData(P_0, P_1);
		P_0.AddValue("InnerExceptions", _innerExceptions, typeof(Exception[]));
	}

	public override Exception GetBaseException()
	{
		Exception ex = this;
		AggregateException ex2 = this;
		while (ex2 != null && ex2.InnerExceptions.Count == 1)
		{
			ex = ex.InnerException;
			ex2 = ex as AggregateException;
		}
		return ex;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(base.ToString());
		for (int i = 0; i < _innerExceptions.Length; i++)
		{
			if (_innerExceptions[i] != base.InnerException)
			{
				stringBuilder.Append("\n ---> ");
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "AggregateException_InnerException", i);
				stringBuilder.Append(_innerExceptions[i].ToString());
				stringBuilder.Append("<---");
				stringBuilder.AppendLine();
			}
		}
		return stringBuilder.ToString();
	}
}
