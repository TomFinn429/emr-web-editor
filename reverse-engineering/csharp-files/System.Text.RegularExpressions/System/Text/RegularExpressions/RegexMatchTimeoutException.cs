using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Text.RegularExpressions;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class RegexMatchTimeoutException : TimeoutException, ISerializable
{
	public string Input { get; } = string.Empty;

	public string Pattern { get; } = string.Empty;

	public TimeSpan MatchTimeout { get; } = TimeSpan.FromTicks(-1L);

	public RegexMatchTimeoutException(string P_0, string P_1, TimeSpan P_2)
		: base("RegexMatchTimeoutException_Occurred")
	{
		Input = P_0;
		Pattern = P_1;
		MatchTimeout = P_2;
	}

	void ISerializable.GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		base.GetObjectData(P_0, P_1);
		P_0.AddValue("regexInput", Input);
		P_0.AddValue("regexPattern", Pattern);
		P_0.AddValue("timeoutTicks", MatchTimeout.Ticks);
	}
}
