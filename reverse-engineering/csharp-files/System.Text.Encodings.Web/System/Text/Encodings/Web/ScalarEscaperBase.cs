namespace System.Text.Encodings.Web;

internal abstract class ScalarEscaperBase
{
	internal abstract int EncodeUtf16(Rune P_0, Span<char> P_1);

	internal abstract int EncodeUtf8(Rune P_0, Span<byte> P_1);
}
