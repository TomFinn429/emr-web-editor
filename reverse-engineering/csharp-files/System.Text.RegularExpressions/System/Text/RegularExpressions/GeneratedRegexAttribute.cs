using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public sealed class GeneratedRegexAttribute : Attribute
{
	[CompilerGenerated]
	private readonly string _003CPattern_003Ek__BackingField;

	[CompilerGenerated]
	private readonly RegexOptions _003COptions_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CMatchTimeoutMilliseconds_003Ek__BackingField;

	[CompilerGenerated]
	private readonly string _003CCultureName_003Ek__BackingField;

	public GeneratedRegexAttribute([StringSyntax("Regex", new object[] { "options" })] string P_0, RegexOptions P_1)
		: this(P_0, P_1, -1)
	{
	}

	public GeneratedRegexAttribute([StringSyntax("Regex", new object[] { "options" })] string P_0, RegexOptions P_1, int P_2)
		: this(P_0, P_1, P_2, string.Empty)
	{
	}

	public GeneratedRegexAttribute([StringSyntax("Regex", new object[] { "options" })] string P_0, RegexOptions P_1, int P_2, string P_3)
	{
		_003CPattern_003Ek__BackingField = P_0;
		_003COptions_003Ek__BackingField = P_1;
		_003CMatchTimeoutMilliseconds_003Ek__BackingField = P_2;
		_003CCultureName_003Ek__BackingField = P_3;
	}
}
