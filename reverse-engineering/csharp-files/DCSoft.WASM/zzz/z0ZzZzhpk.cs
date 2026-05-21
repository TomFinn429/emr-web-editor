using System;
using System.ComponentModel;
using System.Reflection;

namespace zzz;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
[Obfuscation(Exclude = true, ApplyToMembers = true)]
public sealed class z0ZzZzhpk : DefaultValueAttribute
{
	public static string z0eek;

	public z0ZzZzhpk()
		: base(z0eek)
	{
	}

	static z0ZzZzhpk()
	{
		z0eek = z0ZzZzimk.DefaultFontName;
	}
}
