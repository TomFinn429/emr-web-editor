using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace System.Runtime.InteropServices.JavaScript;

[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
[SupportedOSPlatform("browser")]
public sealed class JSImportAttribute : Attribute
{
	[CompilerGenerated]
	private readonly string _003CFunctionName_003Ek__BackingField;

	[CompilerGenerated]
	private readonly string _003CModuleName_003Ek__BackingField;

	public JSImportAttribute(string P_0)
	{
		_003CFunctionName_003Ek__BackingField = P_0;
	}

	public JSImportAttribute(string P_0, string P_1)
	{
		_003CFunctionName_003Ek__BackingField = P_0;
		_003CModuleName_003Ek__BackingField = P_1;
	}
}
