using System;
using System.IO;
using DCSoft.Writer;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzovj
{
	public static readonly z0ZzZzovj z0iek;

	private static z0ZzZzrfh z0oek;

	private readonly z0ZzZzrfh[] z0pek = new z0ZzZzrfh[17];

	public static z0ZzZzrfh[] z0mek;

	private static z0ZzZzrfh z0nek;

	private static readonly z0ZzZzrfh[] z0vek;

	private static z0ZzZzrfh z0cek;

	private static z0ZzZzrfh z0xek;

	private Color z0zek = Color.Red;

	public z0ZzZzrfh BmpCheckBoxUnchecked
	{
		get
		{
			z0ZzZzrfh z0ZzZzrfh2 = GetBitmap(DCStdImageKey.CheckBoxUnchecked);
			if (z0ZzZzrfh2 == null)
			{
				z0ZzZzrfh2 = z0rek(z0ZzZzgfh.z0xek_jiejie20260327142557);
			}
			return z0ZzZzrfh2;
		}
		set
		{
			SetBitmape(DCStdImageKey.CheckBoxUnchecked, value);
		}
	}

	public z0ZzZzrfh BmpLinebreak
	{
		get
		{
			z0ZzZzrfh z0ZzZzrfh2 = GetBitmap(DCStdImageKey.Linebreak);
			if (z0ZzZzrfh2 == null)
			{
				z0ZzZzrfh2 = z0rek(z0ZzZzgfh.z0nek);
			}
			return z0ZzZzrfh2;
		}
		set
		{
			SetBitmape(DCStdImageKey.Linebreak, value);
		}
	}

	public z0ZzZzrfh BmpRadioBoxUnchecked
	{
		get
		{
			z0ZzZzrfh z0ZzZzrfh2 = GetBitmap(DCStdImageKey.RadioBoxUnchecked);
			if (z0ZzZzrfh2 == null)
			{
				z0ZzZzrfh2 = z0rek(z0ZzZzgfh.z0vek);
			}
			return z0ZzZzrfh2;
		}
		set
		{
			SetBitmape(DCStdImageKey.RadioBoxUnchecked, value);
		}
	}

	public z0ZzZzrfh BmpCollapse
	{
		get
		{
			z0ZzZzrfh z0ZzZzrfh2 = GetBitmap(DCStdImageKey.Collapse);
			if (z0ZzZzrfh2 == null)
			{
				z0ZzZzrfh2 = z0rek(z0ZzZzgfh.z0tek);
			}
			return z0ZzZzrfh2;
		}
		set
		{
			SetBitmape(DCStdImageKey.Collapse, value);
		}
	}

	public z0ZzZzrfh BmpDragHandle
	{
		get
		{
			z0ZzZzrfh z0ZzZzrfh2 = GetBitmap(DCStdImageKey.DragHandle);
			if (z0ZzZzrfh2 == null)
			{
				z0ZzZzrfh2 = z0rek(z0ZzZzgfh.z0yek);
			}
			return z0ZzZzrfh2;
		}
		set
		{
			SetBitmape(DCStdImageKey.DragHandle, value);
		}
	}

	public z0ZzZzrfh BmpCheckBoxChecked
	{
		get
		{
			z0ZzZzrfh z0ZzZzrfh2 = GetBitmap(DCStdImageKey.CheckBoxChecked);
			if (z0ZzZzrfh2 == null)
			{
				z0ZzZzrfh2 = z0rek(z0ZzZzgfh.z0cek);
			}
			return z0ZzZzrfh2;
		}
		set
		{
			SetBitmape(DCStdImageKey.CheckBoxChecked, value);
		}
	}

	public z0ZzZzrfh BmpParagraphFlagRightToLeft
	{
		get
		{
			z0ZzZzrfh z0ZzZzrfh2 = GetBitmap(DCStdImageKey.ParagraphFlagRightToLeft);
			if (z0ZzZzrfh2 == null)
			{
				z0ZzZzrfh2 = z0rek(z0ZzZzgfh.z0lrk);
			}
			return z0ZzZzrfh2;
		}
		set
		{
			SetBitmape(DCStdImageKey.ParagraphFlagRightToLeft, value);
		}
	}

	public z0ZzZzrfh BmpRadioBoxChecked
	{
		get
		{
			z0ZzZzrfh z0ZzZzrfh2 = GetBitmap(DCStdImageKey.RadioBoxChecked);
			if (z0ZzZzrfh2 == null)
			{
				z0ZzZzrfh2 = z0rek(z0ZzZzgfh.z0zek);
			}
			return z0ZzZzrfh2;
		}
		set
		{
			SetBitmape(DCStdImageKey.RadioBoxChecked, value);
		}
	}

	public z0ZzZzrfh BmpExpand
	{
		get
		{
			z0ZzZzrfh z0ZzZzrfh2 = GetBitmap(DCStdImageKey.Expand);
			if (z0ZzZzrfh2 == null)
			{
				z0ZzZzrfh2 = z0rek(z0ZzZzgfh.z0uek);
			}
			return z0ZzZzrfh2;
		}
		set
		{
			SetBitmape(DCStdImageKey.Expand, value);
		}
	}

	public z0ZzZzrfh BmpParagraphFlagLeftToRight
	{
		get
		{
			z0ZzZzrfh z0ZzZzrfh2 = GetBitmap(DCStdImageKey.ParagraphFlagLeftToRight);
			if (z0ZzZzrfh2 == null)
			{
				z0ZzZzrfh2 = z0rek(z0ZzZzgfh.z0pek);
			}
			return z0ZzZzrfh2;
		}
		set
		{
			SetBitmape(DCStdImageKey.ParagraphFlagLeftToRight, value);
		}
	}

	public Color TransparentColor
	{
		get
		{
			return z0zek;
		}
		set
		{
			z0zek = value;
		}
	}

	static z0ZzZzovj()
	{
		z0iek = new z0ZzZzovj();
		z0mek = null;
		z0vek = null;
		z0oek = null;
		z0nek = null;
		z0cek = null;
		z0xek = null;
		z0vek = new z0ZzZzrfh[17];
		z0vek[1] = z0eek((object)z0ZzZzgfh.z0cek);
		z0vek[2] = z0eek((object)z0ZzZzgfh.z0xek_jiejie20260327142557);
		z0vek[3] = z0eek((object)z0ZzZzgfh.z0zek);
		z0vek[4] = z0eek((object)z0ZzZzgfh.z0vek);
		z0vek[5] = z0eek((object)z0ZzZzgfh.z0pek);
		z0vek[6] = z0eek((object)z0ZzZzgfh.z0lrk);
		z0vek[7] = z0eek((object)z0ZzZzgfh.z0nek);
		z0vek[8] = z0eek((object)z0ZzZzgfh.z0yek);
		z0vek[13] = z0eek((object)z0ZzZzgfh.z0tek);
		z0vek[14] = z0eek((object)z0ZzZzgfh.z0uek);
		z0ZzZzynj.z0yek();
		z0vek[15] = z0ZzZzynj.z0wrk;
		z0vek[16] = z0ZzZzynj.z0lrk;
		for (int i = 0; i < z0vek.Length; i++)
		{
			if (z0vek[i] != null)
			{
				z0vek[i].z0eek(i);
			}
		}
	}

	public static z0ZzZzedh z0eek(z0ZzZzedh p0)
	{
		if (p0 != null && p0.z0uek() >= 0 && z0mek != null && p0.z0uek() < z0mek.Length)
		{
			z0ZzZzrfh z0ZzZzrfh2 = z0mek[p0.z0uek()];
			if (z0ZzZzrfh2 != null)
			{
				return z0ZzZzrfh2;
			}
		}
		return p0;
	}

	public bool SetBitmapByBase64String(DCStdImageKey key, string base64String)
	{
		if (string.IsNullOrEmpty(base64String))
		{
			return SetBitmape(key, null);
		}
		byte[] p = Convert.FromBase64String(base64String);
		return SetBitmape(key, new z0ZzZzrfh(p));
	}

	public z0ZzZzrfh z0eek()
	{
		z0ZzZzrfh z0ZzZzrfh2 = z0oek;
		if (z0ZzZzrfh2 == null)
		{
			z0ZzZzrfh2 = (z0oek = z0vek[1]);
		}
		return z0ZzZzrfh2;
	}

	private static z0ZzZzrfh z0eek(object p0)
	{
		z0ZzZzrfh z0ZzZzrfh2 = z0ZzZzpmk.z0eek(p0);
		if (z0ZzZzrfh2 != null)
		{
			z0ZzZzrfh2 = (z0ZzZzrfh)((z0ZzZzedh)z0ZzZzrfh2).z0eek();
			z0ZzZzrfh2.z0eek(Color.White);
			return z0ZzZzrfh2;
		}
		return null;
	}

	private z0ZzZzovj()
	{
	}

	internal z0ZzZzrfh[] z0rek()
	{
		z0ZzZzrfh[] array = new z0ZzZzrfh[z0vek.Length];
		for (int i = 0; i < array.Length; i++)
		{
			z0ZzZzrfh z0ZzZzrfh2 = z0pek[i];
			if (z0ZzZzrfh2 == null)
			{
				z0ZzZzrfh2 = z0vek[i];
			}
			array[i] = z0ZzZzrfh2;
		}
		return array;
	}

	public z0ZzZzrfh z0tek()
	{
		z0ZzZzrfh z0ZzZzrfh2 = z0nek;
		if (z0ZzZzrfh2 == null)
		{
			z0ZzZzrfh2 = (z0nek = z0vek[2]);
		}
		return z0ZzZzrfh2;
	}

	public bool SetBitmape(DCStdImageKey key, z0ZzZzrfh bmp)
	{
		z0oek = null;
		z0nek = null;
		z0cek = null;
		z0xek = null;
		if (key == DCStdImageKey.SystemCheckBoxChecked || key == DCStdImageKey.SystemCheckBoxUnchecked || key == DCStdImageKey.SystemRadioBoxChecked || key == DCStdImageKey.SystemRadioBoxUnchecked)
		{
			return false;
		}
		bmp?.z0eek(TransparentColor);
		if (key >= DCStdImageKey.None && key < DCStdImageKey.Max)
		{
			if (z0pek[(int)key] != null)
			{
				z0pek[(int)key].z0eek(-2147483648);
			}
			z0pek[(int)key] = bmp;
			bmp.z0eek((int)key);
			z0mek = null;
			return true;
		}
		return false;
	}

	public z0ZzZzrfh z0yek()
	{
		z0ZzZzrfh z0ZzZzrfh2 = z0xek;
		if (z0ZzZzrfh2 == null)
		{
			z0ZzZzrfh2 = (z0xek = z0vek[4]);
		}
		return z0ZzZzrfh2;
	}

	public z0ZzZzrfh GetBitmap(DCStdImageKey key)
	{
		if (key >= DCStdImageKey.None && key < DCStdImageKey.Max)
		{
			z0ZzZzrfh z0ZzZzrfh2 = z0pek[(int)key];
			if (z0ZzZzrfh2 == null)
			{
				z0ZzZzrfh2 = z0vek[(int)key];
			}
			if (z0ZzZzrfh2 != null)
			{
				return z0ZzZzrfh2;
			}
		}
		return key switch
		{
			DCStdImageKey.SystemCheckBoxChecked => z0eek(), 
			DCStdImageKey.SystemCheckBoxUnchecked => z0tek(), 
			DCStdImageKey.SystemRadioBoxChecked => z0uek(), 
			DCStdImageKey.SystemRadioBoxUnchecked => z0yek(), 
			_ => null, 
		};
	}

	internal static z0ZzZzrfh z0rek(object p0)
	{
		if (p0 is z0ZzZzrfh)
		{
			return (z0ZzZzrfh)p0;
		}
		if (p0 is byte[])
		{
			return new z0ZzZzrfh(new MemoryStream((byte[])p0));
		}
		return null;
	}

	public z0ZzZzrfh z0uek()
	{
		z0ZzZzrfh z0ZzZzrfh2 = z0cek;
		if (z0ZzZzrfh2 == null)
		{
			z0ZzZzrfh2 = (z0cek = z0vek[3]);
		}
		return z0ZzZzrfh2;
	}
}
