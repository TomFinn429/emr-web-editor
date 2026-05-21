namespace System.Xml;

internal sealed class IncrementalReadDummyDecoder : IncrementalReadDecoder
{
	internal override bool IsFull => false;

	internal override int Decode(char[] P_0, int P_1, int P_2)
	{
		return P_2;
	}
}
