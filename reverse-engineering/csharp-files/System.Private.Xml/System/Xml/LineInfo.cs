namespace System.Xml;

internal struct LineInfo
{
	internal int lineNo;

	internal int linePos;

	public LineInfo(int P_0, int P_1)
	{
		lineNo = P_0;
		linePos = P_1;
	}

	public void Set(int P_0, int P_1)
	{
		lineNo = P_0;
		linePos = P_1;
	}
}
