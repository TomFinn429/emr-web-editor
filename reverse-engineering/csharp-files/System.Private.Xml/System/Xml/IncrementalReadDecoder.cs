namespace System.Xml;

internal abstract class IncrementalReadDecoder
{
	internal abstract bool IsFull { get; }

	internal abstract int Decode(char[] P_0, int P_1, int P_2);
}
