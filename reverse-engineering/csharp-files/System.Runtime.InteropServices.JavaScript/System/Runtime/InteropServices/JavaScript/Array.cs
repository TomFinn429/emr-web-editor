using System.Reflection;

namespace System.Runtime.InteropServices.JavaScript;

[DefaultMember("Item")]
[Obsolete]
public class Array : JSObject
{
	internal Array(nint P_0)
		: base(P_0)
	{
	}
}
