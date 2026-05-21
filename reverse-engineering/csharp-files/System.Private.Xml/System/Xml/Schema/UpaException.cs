namespace System.Xml.Schema;

internal sealed class UpaException : Exception
{
	private readonly object _particle1;

	private readonly object _particle2;

	public UpaException(object P_0, object P_1)
	{
		_particle1 = P_0;
		_particle2 = P_1;
	}
}
