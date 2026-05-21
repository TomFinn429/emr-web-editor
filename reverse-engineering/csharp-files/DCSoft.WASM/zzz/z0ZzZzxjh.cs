using System;
using System.Collections.Generic;
using System.IO;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzxjh : z0ZzZzlwh
{
	private Dictionary<string, string> z0xek = new Dictionary<string, string>();

	public Color z0tek(Color p0)
	{
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)9)
		{
			string text = (string)((z0ZzZzxqh)this).z0iek();
			if (text != null && text.Length > 0)
			{
				return z0ZzZzlok.z0eek(text, p0);
			}
		}
		return p0;
	}

	public new byte[] z0tek()
	{
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)9)
		{
			string text = (string)((z0ZzZzxqh)this).z0iek();
			if (text != null && text.Length > 0)
			{
				return Convert.FromBase64String(text);
			}
		}
		return null;
	}

	public void z0tek(object p0, string p1)
	{
		if (((z0ZzZzxqh)this).z0uek() != (z0ZzZzkwh)4 || !z0uq() || (((z0ZzZzxqh)this).z0uek() != (z0ZzZzkwh)2 && ((z0ZzZzxqh)this).z0uek() != (z0ZzZzkwh)3 && ((z0ZzZzxqh)this).z0uek() != (z0ZzZzkwh)1))
		{
			return;
		}
		int num = 1;
		while (z0uq())
		{
			switch (((z0ZzZzxqh)this).z0uek())
			{
			case (z0ZzZzkwh)1:
			case (z0ZzZzkwh)2:
			case (z0ZzZzkwh)3:
				num++;
				break;
			case (z0ZzZzkwh)13:
			case (z0ZzZzkwh)14:
			case (z0ZzZzkwh)15:
				num--;
				break;
			}
			if (num == 0)
			{
				break;
			}
		}
	}

	public new float z0yek()
	{
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)7)
		{
			return (long)((z0ZzZzxqh)this).z0iek();
		}
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)8)
		{
			return (float)(double)((z0ZzZzxqh)this).z0iek();
		}
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)9)
		{
			string text = (string)((z0ZzZzxqh)this).z0iek();
			if (text != null && text.Length > 0)
			{
				return float.Parse(text);
			}
		}
		return 0f;
	}

	public z0ZzZzxjh(TextReader p0)
		: base(p0)
	{
	}

	public void z0tek(XTextElementList p0)
	{
		int styleIndex = -1;
		string text = null;
		int num = 0;
		while (z0uq())
		{
			switch (((z0ZzZzxqh)this).z0uek())
			{
			case (z0ZzZzkwh)4:
			{
				string text2 = (string)((z0ZzZzxqh)this).z0iek();
				if (text2 == z0ZzZzfhh.z0uzk)
				{
					if (z0uq())
					{
						styleIndex = z0pek();
					}
				}
				else if (text2 == z0ZzZzfhh.z0mij)
				{
					if (z0uq())
					{
						num = z0pek();
					}
				}
				else if (text2 == z0ZzZzfhh.z0tik)
				{
					if (z0uq())
					{
						text = z0bek();
					}
				}
				else
				{
					z0tek(null, text2);
				}
				continue;
			}
			default:
				continue;
			case (z0ZzZzkwh)13:
				break;
			}
			break;
		}
		if (num > 0)
		{
			for (int num2 = num; num2 > 0; num2--)
			{
				p0.Add(new XTextCharElement(' ', styleIndex));
			}
		}
		else
		{
			if (text == null || text.Length <= 0)
			{
				return;
			}
			int length = text.Length;
			for (int i = 0; i < length; i++)
			{
				char c = text[i];
				if (XTextCharElement.z0tek((int)c) && i < length - 1)
				{
					XTextCharElement xTextCharElement = new XTextCharElement(c, styleIndex);
					xTextCharElement.z0rek((ushort)text[i + 1]);
					p0.z0hrk(xTextCharElement);
					i++;
				}
				else
				{
					p0.z0hrk(new XTextCharElement(c, styleIndex));
				}
			}
		}
	}

	public new string z0uek()
	{
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)9)
		{
			return (string)((z0ZzZzxqh)this).z0iek();
		}
		return null;
	}

	public new char z0iek()
	{
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)9)
		{
			string text = (string)((z0ZzZzxqh)this).z0iek();
			if (text != null && text.Length > 1)
			{
				return text[0];
			}
		}
		else if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)7)
		{
			return (char)((z0ZzZzxqh)this).z0iek();
		}
		return '\0';
	}

	public new double z0oek()
	{
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)7)
		{
			return (long)((z0ZzZzxqh)this).z0iek();
		}
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)8)
		{
			return (double)((z0ZzZzxqh)this).z0iek();
		}
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)9)
		{
			string text = (string)((z0ZzZzxqh)this).z0iek();
			if (text != null && text.Length > 0)
			{
				return double.Parse(text);
			}
		}
		return 0.0;
	}

	public int z0pek()
	{
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)7)
		{
			return (int)(long)((z0ZzZzxqh)this).z0iek();
		}
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)9)
		{
			string text = (string)((z0ZzZzxqh)this).z0iek();
			if (text != null && text.Length > 0)
			{
				return int.Parse(text);
			}
		}
		return 0;
	}

	public int z0tek(string[] p0)
	{
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)9)
		{
			string text = (string)((z0ZzZzxqh)this).z0iek();
			if (text != null && text.Length > 0)
			{
				for (int num = p0.Length - 1; num >= 0; num--)
				{
					if (p0[num] == text)
					{
						return num;
					}
				}
				if (text[0] >= '0' && text[0] <= '9')
				{
					int result = 0;
					if (int.TryParse(text, out result))
					{
						return result;
					}
				}
			}
		}
		else if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)7)
		{
			return (int)(long)((z0ZzZzxqh)this).z0iek();
		}
		return 0;
	}

	public IList<byte[]> z0eek(IList<byte[]> p0)
	{
		while (z0yq())
		{
			switch (((z0ZzZzxqh)this).z0uek())
			{
			case (z0ZzZzkwh)9:
			{
				string text = (string)((z0ZzZzxqh)this).z0iek();
				if (text != null)
				{
					if (text.Length == 0)
					{
						p0.Add(null);
						continue;
					}
					byte[] array = Convert.FromBase64String(text);
					p0.Add(array);
				}
				continue;
			}
			case (z0ZzZzkwh)11:
				p0.Add(null);
				continue;
			default:
				continue;
			case (z0ZzZzkwh)14:
				break;
			}
			break;
		}
		return p0;
	}

	public new string z0mek()
	{
		int num = 5;
		while (z0uq() && num-- >= 0)
		{
			if (base.z0uek() == (z0ZzZzkwh)4)
			{
				if ((string)base.z0iek() == "Type")
				{
					if (!z0uq() || ((z0ZzZzxqh)this).z0uek() != (z0ZzZzkwh)9)
					{
						break;
					}
					return (string)((z0ZzZzxqh)this).z0iek();
				}
			}
			else if (base.z0uek() == (z0ZzZzkwh)13)
			{
				break;
			}
		}
		return null;
	}

	public void z0nek()
	{
		if (z0xek != null)
		{
			z0xek.Clear();
			z0xek = null;
		}
	}

	public new string z0bek()
	{
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)9)
		{
			string text = (string)((z0ZzZzxqh)this).z0iek();
			if (text != null)
			{
				if (text.Length == 0)
				{
					return string.Empty;
				}
				string result = null;
				if (!z0xek.TryGetValue(text, out result))
				{
					z0xek[text] = text;
					return text;
				}
				return result;
			}
			return null;
		}
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)11)
		{
			return null;
		}
		return Convert.ToString(((z0ZzZzxqh)this).z0iek());
	}

	public new bool z0vek()
	{
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)10)
		{
			return (bool)((z0ZzZzxqh)this).z0iek();
		}
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)9)
		{
			return z0ZzZzhah.z0rek((string)((z0ZzZzxqh)this).z0iek());
		}
		return false;
	}

	public IList<string> z0rek(IList<string> p0)
	{
		while (z0yq())
		{
			switch (((z0ZzZzxqh)this).z0uek())
			{
			case (z0ZzZzkwh)9:
			{
				string text = (string)((z0ZzZzxqh)this).z0iek();
				if (text == null)
				{
					continue;
				}
				if (text.Length == 0)
				{
					p0.Add(string.Empty);
					continue;
				}
				string text2 = null;
				if (z0xek.TryGetValue(text, out text2))
				{
					p0.Add(text2);
					continue;
				}
				z0xek[text] = text;
				p0.Add(text);
				continue;
			}
			case (z0ZzZzkwh)11:
				p0.Add(null);
				continue;
			default:
				continue;
			case (z0ZzZzkwh)14:
				break;
			}
			break;
		}
		return p0;
	}

	public DateTime z0cek()
	{
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)9)
		{
			string text = (string)((z0ZzZzxqh)this).z0iek();
			if (text == null)
			{
				return DateTime.MinValue;
			}
			if (text.Length != 19)
			{
				return DateTime.Parse(text);
			}
			if (text == null || text.Length < 19)
			{
				return DateTime.MinValue;
			}
			try
			{
				int year = 1000 * (text[0] - 48) + 100 * (text[1] - 48) + 10 * (text[2] - 48) + (text[3] - 48);
				int month = 10 * (text[5] - 48) + (text[6] - 48);
				int day = 10 * (text[8] - 48) + (text[9] - 48);
				int hour = 10 * (text[11] - 48) + (text[12] - 48);
				int minute = 10 * (text[14] - 48) + (text[15] - 48);
				int second = 10 * (text[17] - 48) + (text[18] - 48);
				return new DateTime(year, month, day, hour, minute, second);
			}
			catch (Exception)
			{
				return DateTime.MinValue;
			}
		}
		if (((z0ZzZzxqh)this).z0uek() == (z0ZzZzkwh)16)
		{
			return (DateTime)((z0ZzZzxqh)this).z0iek();
		}
		return DateTime.MinValue;
	}
}
