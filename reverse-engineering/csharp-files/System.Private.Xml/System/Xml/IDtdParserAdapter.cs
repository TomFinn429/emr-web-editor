using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Xml;

internal interface IDtdParserAdapter
{
	XmlNameTable NameTable { get; }

	IXmlNamespaceResolver NamespaceResolver { get; }

	Uri BaseUri { get; }

	char[] ParsingBuffer { get; }

	int ParsingBufferLength { get; }

	int CurrentPosition { get; set; }

	int LineNo { get; }

	int LineStartPosition { get; }

	bool IsEof { get; }

	int EntityStackLength { get; }

	bool IsEntityEolNormalized { get; }

	int ReadData();

	void OnNewLine(int P_0);

	int ParseNumericCharRef(StringBuilder P_0);

	int ParseNamedCharRef(bool P_0, StringBuilder P_1);

	void ParsePI(StringBuilder P_0);

	void ParseComment(StringBuilder P_0);

	bool PushEntity(IDtdEntityInfo P_0, out int P_1);

	bool PopEntity(out IDtdEntityInfo P_0, out int P_1);

	bool PushExternalSubset(string P_0, string P_1);

	void PushInternalDtd(string P_0, string P_1);

	void OnSystemId(string P_0, LineInfo P_1, LineInfo P_2);

	void OnPublicId(string P_0, LineInfo P_1, LineInfo P_2);

	[DoesNotReturn]
	void Throw(Exception P_0);
}
