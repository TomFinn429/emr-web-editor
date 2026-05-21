using System.ComponentModel;
using zzz;

namespace DCSoft.Writer.Dom;

public class RepeatedImageValue : z0ZzZzpmk
{
	private new int z0eek;

	private new int z0rek;

	[DefaultValue(0)]
	[z0ZzZztqh]
	public int ValueIndex
	{
		get
		{
			return z0eek;
		}
		set
		{
			z0eek = value;
		}
	}

	[z0ZzZztqh]
	[DefaultValue(0)]
	public int ReferenceCount
	{
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	public RepeatedImageValue()
	{
	}

	public RepeatedImageValue(z0ZzZzpmk img)
	{
		img?.z0rek(this);
	}
}
