using System;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzhoj
{
	public readonly int z0eek;

	public readonly int z0rek;

	public readonly int z0tek;

	public readonly int z0yek;

	public z0ZzZzhoj(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		p0 = z0ZzZzlbj.z0eek(p0);
		if (p0 == null)
		{
			return;
		}
		z0ZzZzqbj.z0dgj z0dgj = p0.z0uyk().z0iek(p0);
		if (z0dgj != null)
		{
			z0tek = z0dgj.z0iek;
			z0yek = z0dgj.z0eek;
			if (p0 is XTextFieldBorderElement)
			{
				z0yek += (int)(p0.z0xyk() * p0.z0uyk().z0kyk());
			}
			z0rek = z0dgj.z0yek;
			z0eek = (int)(p0.z0utk() * p0.z0uyk().z0kyk());
		}
	}
}
