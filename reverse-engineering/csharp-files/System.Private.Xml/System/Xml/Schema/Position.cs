namespace System.Xml.Schema;

internal struct Position
{
	public int symbol;

	public object particle;

	public Position(int P_0, object P_1)
	{
		symbol = P_0;
		particle = P_1;
	}
}
