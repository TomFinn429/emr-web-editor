namespace System.Text.Encodings.Web;

public abstract class JavaScriptEncoder : TextEncoder
{
	public static JavaScriptEncoder Default => DefaultJavaScriptEncoder.BasicLatinSingleton;
}
