using System;
using DCSoft.Writer;

namespace zzz;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public sealed class z0ZzZzbjh : Attribute
{
	private readonly MemberEffectLevel z0rek;

	public MemberEffectLevel z0eek()
	{
		return z0rek;
	}

	public z0ZzZzbjh()
	{
	}

	public z0ZzZzbjh(MemberEffectLevel p0)
	{
		z0rek = p0;
	}
}
