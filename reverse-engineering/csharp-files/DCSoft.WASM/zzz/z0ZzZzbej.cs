using System;
using System.Collections.Generic;
using System.IO;
using DCSystem_Drawing;

namespace zzz;

public abstract class z0ZzZzbej : IDisposable
{
	public delegate byte[] z0njj(Stream stream, string strEntryName);

	public delegate z0ZzZzbej z0ypk(Stream stream, bool forSVG);

	public static z0ypk z0rek = null;

	public static z0njj z0tek = null;

	internal static bool z0yek = true;

	public static bool z0uek = false;

	public static bool z0iek = false;

	public abstract void z0bhk(string[] p0);

	public virtual void z0kgk(z0ZzZztfh p0, float p1, float p2, float p3, float p4, float p5, float p6)
	{
	}

	public abstract object z0agk();

	public abstract void z0mhk(string p0, z0ZzZzbdh p1, string p2, float p3, FontStyle p4, bool p5);

	public abstract void z0qgk_jiejie20260327142557(z0ZzZzjdh p0);

	public abstract GraphicsUnit z0ohk();

	public virtual void z0jgk(z0ZzZztfh p0, z0ZzZznfh p1)
	{
	}

	public abstract void z0ihk(string p0, string p1, float p2, FontStyle p3, Color p4, z0ZzZzbdh p5, z0ZzZzlsh p6);

	public abstract void z0dgk(char p0, int p1, string p2, float p3, FontStyle p4, Color p5, float p6, float p7, float p8, object p9);

	public abstract void z0thk();

	public abstract z0ZzZzjdh z0wgk();

	public virtual void z0fgk(z0ZzZzudh p0, float p1, float p2, float p3, float p4, float p5, float p6)
	{
	}

	public abstract void z0uhk(z0ZzZzudh p0, float p1, float p2, float p3, float p4);

	public abstract void z0yhk(z0ZzZzudh p0, float p1, float p2, float p3, float p4);

	public static z0ZzZzbej z0eek(Stream p0, bool p1)
	{
		if (z0rek == null)
		{
			throw new NotSupportedException("CreateInstance");
		}
		return z0rek(p0, p1);
	}

	public abstract void z0phk(float p0, float p1);

	public abstract void z0chk(Color p0, float p1, float p2, float p3, float p4);

	public abstract z0ZzZzndh z0shk(float p0, float p1, float p2, float p3);

	public abstract void z0nhk(z0ZzZzudh p0, float p1, float p2, float p3, float p4, float p5);

	public abstract bool z0rhk();

	public abstract void z0zhk(string p0, byte[] p1);

	public abstract void z0whk();

	public abstract void z0xhk(string p0, string p1, string p2, string p3, DateTime p4, DateTime p5, Dictionary<string, string> p6);

	public virtual void z0hgk(z0ZzZzudh p0, z0ZzZznfh p1)
	{
	}

	public abstract void z0rgk(z0ZzZztfh p0, float p1, float p2, float p3, float p4);

	public abstract void z0qhk(string p0);

	public abstract void z0sgk(z0ZzZzbdh p0);

	public abstract void z0dhk(float p0, float p1);

	public abstract void z0ehk(object p0);

	public abstract void z0lgk(z0ZzZztfh p0, float p1, float p2, float p3, float p4, float p5);

	public abstract void z0vhk(GraphicsUnit p0);

	public abstract void z0ahk(z0ZzZzedh p0, float p1, float p2, float p3, float p4, byte[] p5);

	public abstract void z0egk(z0ZzZzudh p0, z0ZzZzpdh[] p1);

	public abstract void Dispose();

	public abstract void z0ggk(float p0);
}
