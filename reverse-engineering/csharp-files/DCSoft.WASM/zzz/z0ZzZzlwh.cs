using System;
using System.Globalization;
using System.IO;

namespace zzz;

public class z0ZzZzlwh : z0ZzZzxqh, z0ZzZzmqh
{
	private char[] z0srk_jiejie20260327142557;

	private int z0ark;

	private static readonly bool[] z0qrk = z0rek();

	private bool z0erk;

	private z0ZzZzqwh z0rrk;

	private z0ZzZzwwh z0trk;

	private readonly TextReader z0yrk;

	private int z0urk;

	private int z0irk;

	private int z0ork;

	public int z0tq()
	{
		if (base.z0oek() == z0thj.z0eek && z0rq() == 0)
		{
			return 0;
		}
		return z0ark;
	}

	private new bool z0eek(string p0)
	{
		if (!z0rek(p0))
		{
			return false;
		}
		if (!z0eek(0, p1: false))
		{
			return true;
		}
		if (!z0yek(z0srk_jiejie20260327142557[z0ork]))
		{
			return z0srk_jiejie20260327142557[z0ork] == '\0';
		}
		return true;
	}

	private bool z0eek()
	{
		while (true)
		{
			char c = z0srk_jiejie20260327142557[z0ork];
			switch (c)
			{
			case '\0':
				if (z0irk == z0ork)
				{
					if (z0tek(p0: false) == 0)
					{
						return false;
					}
				}
				else
				{
					z0ork++;
				}
				break;
			case '}':
				z0rek((z0ZzZzkwh)13);
				z0ork++;
				return true;
			case '/':
				z0cek();
				return true;
			case '\r':
				z0rek(p0: false);
				break;
			case '\n':
				z0iek_jiejie20260327142557();
				break;
			case '\t':
			case ' ':
				z0ork++;
				break;
			default:
				if (char.IsWhiteSpace(c))
				{
					z0ork++;
					break;
				}
				return z0hrk();
			}
		}
	}

	private bool z0eek(int p0, bool p1)
	{
		if (z0ork + p0 >= z0irk)
		{
			return z0rek(p0, p1);
		}
		return true;
	}

	private new static bool[] z0rek()
	{
		bool[] array = new bool[127];
		string text = "0123456789abcdefxABCDEFX.-+";
		foreach (char c in text)
		{
			array[(uint)c] = true;
		}
		return array;
	}

	public override bool z0uq()
	{
		base.z0frk = (z0ZzZzjwh)0;
		if (!z0yq())
		{
			z0rek((z0ZzZzkwh)0);
			return false;
		}
		return true;
	}

	private new void z0tek()
	{
		if (z0eek("Infinity"))
		{
			z0eek((z0ZzZzkwh)8, 1.0 / 0.0);
			return;
		}
		throw z0ZzZzzqh.z0eek(this, "Error parsing positive infinity value.");
	}

	private static bool z0eek(char p0)
	{
		if (p0 <= 'x')
		{
			return z0qrk[(uint)p0];
		}
		return false;
	}

	private bool z0rek(int p0, bool p1)
	{
		if (z0erk)
		{
			return false;
		}
		int num = z0ork + p0 - z0irk + 1;
		int num2 = 0;
		do
		{
			int num3 = z0eek(p1, num - num2);
			if (num3 == 0)
			{
				break;
			}
			num2 += num3;
		}
		while (num2 < num);
		if (num2 < num)
		{
			return false;
		}
		return true;
	}

	private new bool z0eek(bool p0)
	{
		bool flag = false;
		bool flag2 = false;
		while (!flag)
		{
			char c = z0srk_jiejie20260327142557[z0ork];
			switch (c)
			{
			case '\0':
				if (z0irk == z0ork)
				{
					if (z0tek(p0: false) == 0)
					{
						flag = true;
					}
				}
				else
				{
					z0ork++;
				}
				break;
			case '\r':
				z0rek(p0: false);
				break;
			case '\n':
				z0iek_jiejie20260327142557();
				break;
			default:
				if (!char.IsWhiteSpace(c))
				{
					flag = true;
					break;
				}
				goto case ' ';
			case ' ':
				flag2 = true;
				z0ork++;
				break;
			}
		}
		return !p0 || flag2;
	}

	private new void z0yek()
	{
		if (z0eek("-Infinity"))
		{
			z0eek((z0ZzZzkwh)8, -1.0 / 0.0);
			return;
		}
		throw z0ZzZzzqh.z0eek(this, "Error parsing negative infinity value.");
	}

	private void z0rek(char p0)
	{
		int num = z0ork;
		int num2 = z0ork;
		int num3 = z0ork;
		z0ZzZzqwh z0ZzZzqwh2 = null;
		while (true)
		{
			switch (z0srk_jiejie20260327142557[num++])
			{
			case '\0':
				if (z0irk == num - 1)
				{
					num--;
					if (z0tek(p0: true) == 0)
					{
						z0ork = num;
						throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Unterminated string. Expected delimiter: {0}.", CultureInfo.InvariantCulture, p0));
					}
				}
				break;
			case '\\':
			{
				z0ork = num;
				if (!z0eek(0, p1: true))
				{
					z0ork = num;
					throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Unterminated string. Expected delimiter: {0}.", CultureInfo.InvariantCulture, p0));
				}
				int p1 = num - 1;
				char c = z0srk_jiejie20260327142557[num];
				char c2;
				switch (c)
				{
				case 'b':
					num++;
					c2 = '\b';
					break;
				case 't':
					num++;
					c2 = '\t';
					break;
				case 'n':
					num++;
					c2 = '\n';
					break;
				case 'f':
					num++;
					c2 = '\f';
					break;
				case 'r':
					num++;
					c2 = '\r';
					break;
				case '\\':
					num++;
					c2 = '\\';
					break;
				case '"':
				case '\'':
				case '/':
					c2 = c;
					num++;
					break;
				case 'u':
					num++;
					z0ork = num;
					c2 = z0mek();
					if (z0ZzZzewh.z0rek(c2))
					{
						c2 = '\ufffd';
					}
					else if (z0ZzZzewh.z0eek(c2))
					{
						bool flag;
						do
						{
							flag = false;
							if (z0eek(2, p1: true) && z0srk_jiejie20260327142557[z0ork] == '\\' && z0srk_jiejie20260327142557[z0ork + 1] == 'u')
							{
								char p2 = c2;
								z0ork += 2;
								c2 = z0mek();
								if (!z0ZzZzewh.z0rek(c2))
								{
									if (z0ZzZzewh.z0eek(c2))
									{
										p2 = '\ufffd';
										flag = true;
									}
									else
									{
										p2 = '\ufffd';
									}
								}
								if (z0ZzZzqwh2 == null)
								{
									z0ZzZzqwh2 = z0zek();
								}
								z0eek(z0ZzZzqwh2, p2, num3, p1);
								num3 = z0ork;
							}
							else
							{
								c2 = '\ufffd';
							}
						}
						while (flag);
					}
					num = z0ork;
					break;
				default:
					num++;
					z0ork = num;
					throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Bad JSON escape sequence: {0}.", CultureInfo.InvariantCulture, "\\" + c));
				}
				if (z0ZzZzqwh2 == null)
				{
					z0ZzZzqwh2 = z0zek();
				}
				z0eek(z0ZzZzqwh2, c2, num3, p1);
				num3 = num;
				break;
			}
			case '\r':
				z0ork = num - 1;
				z0rek(p0: true);
				num = z0ork;
				break;
			case '\n':
				z0ork = num - 1;
				z0iek_jiejie20260327142557();
				num = z0ork;
				break;
			case '"':
			case '\'':
				if (z0srk_jiejie20260327142557[num - 1] != p0)
				{
					break;
				}
				num--;
				if (num2 == num3)
				{
					z0trk = new z0ZzZzwwh(z0srk_jiejie20260327142557, num2, num - num2);
				}
				else
				{
					if (z0ZzZzqwh2 == null)
					{
						z0ZzZzqwh2 = z0zek();
					}
					if (num > num3)
					{
						z0ZzZzqwh2.z0eek(z0srk_jiejie20260327142557, num3, num - num3);
					}
					z0trk = new z0ZzZzwwh(z0ZzZzqwh2.z0rek(), 0, z0ZzZzqwh2.z0tek());
				}
				num++;
				z0ork = num;
				return;
			}
		}
	}

	private int z0eek(bool p0, int p1)
	{
		if (z0erk)
		{
			return 0;
		}
		if (z0irk + p1 >= z0srk_jiejie20260327142557.Length - 1)
		{
			if (p0)
			{
				char[] p2 = new char[Math.Max(z0srk_jiejie20260327142557.Length * 2, z0irk + p1 + 1)];
				z0eek(z0srk_jiejie20260327142557, 0, p2, 0, z0srk_jiejie20260327142557.Length);
				z0srk_jiejie20260327142557 = p2;
			}
			else
			{
				int num = z0irk - z0ork;
				if (num + p1 + 1 >= z0srk_jiejie20260327142557.Length)
				{
					char[] p3 = new char[num + p1 + 1];
					if (num > 0)
					{
						z0eek(z0srk_jiejie20260327142557, z0ork, p3, 0, num);
					}
					z0srk_jiejie20260327142557 = p3;
				}
				else if (num > 0)
				{
					z0eek(z0srk_jiejie20260327142557, z0ork, z0srk_jiejie20260327142557, 0, num);
				}
				z0urk -= z0ork;
				z0ork = 0;
				z0irk = num;
			}
		}
		int num2 = z0srk_jiejie20260327142557.Length - z0irk - 1;
		int num3 = z0yrk.Read(z0srk_jiejie20260327142557, z0irk, num2);
		z0irk += num3;
		if (num3 == 0)
		{
			z0erk = true;
		}
		z0srk_jiejie20260327142557[z0irk] = '\0';
		return num3;
	}

	private bool z0rek(string p0)
	{
		if (!z0eek(p0.Length - 1, p1: true))
		{
			return false;
		}
		for (int i = 0; i < p0.Length; i++)
		{
			if (z0srk_jiejie20260327142557[z0ork + i] != p0[i])
			{
				return false;
			}
		}
		z0ork += p0.Length;
		return true;
	}

	private new void z0uek()
	{
		if (z0eek("undefined"))
		{
			z0rek((z0ZzZzkwh)12);
			return;
		}
		throw z0ZzZzzqh.z0eek(this, "Error parsing undefined value.");
	}

	public bool z0iq()
	{
		return true;
	}

	private void z0iek_jiejie20260327142557()
	{
		z0ork++;
		z0eek(z0ork);
	}

	internal override bool z0yq()
	{
		do
		{
			switch (z0wrk)
			{
			case z0thj.z0eek:
			case z0thj.z0tek:
			case z0thj.z0iek:
			case z0thj.z0oek:
			case z0thj.z0nek:
			case z0thj.z0bek:
				return z0xek();
			case z0thj.z0yek:
			case z0thj.z0uek:
				return z0eek();
			case z0thj.z0mek:
				break;
			case z0thj.z0cek:
				if (z0eek(0, p1: false))
				{
					z0eek(p0: false);
					if (z0erk)
					{
						return false;
					}
					if (z0srk_jiejie20260327142557[z0ork] == '/')
					{
						z0cek();
						return true;
					}
					throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Additional text encountered after finished reading JSON content: {0}.", CultureInfo.InvariantCulture, z0srk_jiejie20260327142557[z0ork]));
				}
				return false;
			default:
				throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Unexpected state: {0}.", CultureInfo.InvariantCulture, base.z0oek()));
			}
		}
		while (!z0bek());
		return true;
	}

	private new void z0oek()
	{
		z0frk();
		char c = z0srk_jiejie20260327142557[z0ork];
		int num = z0ork;
		z0vek();
		base.z0rek(p0: true);
		z0trk = new z0ZzZzwwh(z0srk_jiejie20260327142557, num, z0ork - num);
		bool flag = char.IsDigit(c) && z0trk.z0tek() == 1;
		bool flag2 = c == '0' && z0trk.z0tek() > 1 && z0trk.z0eek()[z0trk.z0rek() + 1] != '.' && z0trk.z0eek()[z0trk.z0rek() + 1] != 'e' && z0trk.z0eek()[z0trk.z0rek() + 1] != 'E';
		object p;
		z0ZzZzkwh p4;
		if (base.z0frk == (z0ZzZzjwh)1)
		{
			if (flag)
			{
				p = c - 48;
			}
			else if (flag2)
			{
				string text = z0trk.z0uek();
				try
				{
					p = (text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? Convert.ToInt32(text, 16) : Convert.ToInt32(text, 8));
				}
				catch (Exception p2)
				{
					throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Input string '{0}' is not a valid integer.", CultureInfo.InvariantCulture, text), p2);
				}
			}
			else
			{
				int p3;
				switch (z0ZzZzhwh.z0eek(z0trk.z0eek(), z0trk.z0rek(), z0trk.z0tek(), out p3))
				{
				case (z0ZzZzswh)1:
					break;
				case (z0ZzZzswh)2:
					throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("JSON integer {0} is too large or small for an Int32.", CultureInfo.InvariantCulture, z0trk.z0uek()));
				default:
					throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Input string '{0}' is not a valid integer.", CultureInfo.InvariantCulture, z0trk.z0uek()));
				}
				p = p3;
			}
			p4 = (z0ZzZzkwh)7;
		}
		else if (base.z0frk == (z0ZzZzjwh)4)
		{
			if (flag)
			{
				p = (decimal)c - 48m;
			}
			else if (flag2)
			{
				string text2 = z0trk.z0uek();
				try
				{
					p = Convert.ToDecimal(text2.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? Convert.ToInt64(text2, 16) : Convert.ToInt64(text2, 8));
				}
				catch (Exception p5)
				{
					throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Input string '{0}' is not a valid decimal.", CultureInfo.InvariantCulture, text2), p5);
				}
			}
			else
			{
				if (!decimal.TryParse(z0trk.z0uek(), NumberStyles.Number | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out var num2))
				{
					throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Input string '{0}' is not a valid decimal.", CultureInfo.InvariantCulture, z0trk.z0uek()));
				}
				p = num2;
			}
			p4 = (z0ZzZzkwh)8;
		}
		else if (flag)
		{
			p = (long)c - 48L;
			p4 = (z0ZzZzkwh)7;
		}
		else if (flag2)
		{
			string text3 = z0trk.z0uek();
			try
			{
				p = (text3.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? Convert.ToInt64(text3, 16) : Convert.ToInt64(text3, 8));
			}
			catch (Exception p6)
			{
				throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Input string '{0}' is not a valid number.", CultureInfo.InvariantCulture, text3), p6);
			}
			p4 = (z0ZzZzkwh)7;
		}
		else
		{
			long p7;
			switch (z0ZzZzhwh.z0eek(z0trk.z0eek(), z0trk.z0rek(), z0trk.z0tek(), out p7))
			{
			case (z0ZzZzswh)1:
				p = p7;
				p4 = (z0ZzZzkwh)7;
				break;
			case (z0ZzZzswh)2:
				throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("JSON integer {0} is too large or small for an Int64.", CultureInfo.InvariantCulture, z0trk.z0uek()));
			default:
			{
				string text4 = z0trk.z0uek();
				if (double.TryParse(text4, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var num3))
				{
					p = num3;
					p4 = (z0ZzZzkwh)8;
					break;
				}
				throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Input string '{0}' is not a valid number.", CultureInfo.InvariantCulture, text4));
			}
			}
		}
		z0drk();
		z0eek(p4, p, p2: false);
	}

	private new void z0rek(bool p0)
	{
		z0ork++;
		if (z0eek(1, p0) && z0srk_jiejie20260327142557[z0ork] == '\n')
		{
			z0ork++;
		}
		z0eek(z0ork);
	}

	private new int z0tek(bool p0)
	{
		return z0eek(p0, 0);
	}

	private void z0pek()
	{
		int num = z0ork;
		char c;
		while (true)
		{
			if (z0srk_jiejie20260327142557[z0ork] == '\0')
			{
				if (z0irk != z0ork)
				{
					z0trk = new z0ZzZzwwh(z0srk_jiejie20260327142557, num, z0ork - num);
					return;
				}
				if (z0tek(p0: true) == 0)
				{
					throw z0ZzZzzqh.z0eek(this, "Unexpected end while parsing unquoted property name.");
				}
			}
			else
			{
				c = z0srk_jiejie20260327142557[z0ork];
				if (!z0uek(c))
				{
					break;
				}
				z0ork++;
			}
		}
		if (char.IsWhiteSpace(c) || c == ':')
		{
			z0trk = new z0ZzZzwwh(z0srk_jiejie20260327142557, num, z0ork - num);
			return;
		}
		throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Invalid JavaScript property identifier character: {0}.", CultureInfo.InvariantCulture, c));
	}

	private void z0tek(char p0)
	{
		z0ork++;
		z0frk();
		z0rek(p0);
		base.z0rek(p0: true);
		if (base.z0frk == (z0ZzZzjwh)2)
		{
			Guid p2;
			byte[] p1 = ((z0trk.z0tek() == 0) ? Array.Empty<byte>() : ((z0trk.z0tek() != 36 || !z0ZzZzhwh.z0eek(z0trk.z0uek(), out p2)) ? Convert.FromBase64CharArray(z0trk.z0eek(), z0trk.z0rek(), z0trk.z0tek()) : p2.ToByteArray()));
			z0eek((z0ZzZzkwh)17, p1, p2: false);
			return;
		}
		if (base.z0frk == (z0ZzZzjwh)3)
		{
			string p3 = z0trk.z0uek();
			z0eek((z0ZzZzkwh)9, p3, p2: false);
			base.z0krk = p0;
			return;
		}
		string text = z0trk.z0uek();
		if (z0ZzZzfwh.z0rek(text, base.z0mek(), base.z0zek(), out object p4))
		{
			z0eek((z0ZzZzkwh)16, p4, p2: false);
			return;
		}
		z0eek((z0ZzZzkwh)9, text, p2: false);
		base.z0krk = p0;
	}

	private new char z0mek()
	{
		if (z0eek(4, p1: true))
		{
			char result = Convert.ToChar(int.Parse(new string(z0srk_jiejie20260327142557, z0ork, 4), NumberStyles.HexNumber, NumberFormatInfo.InvariantInfo));
			z0ork += 4;
			return result;
		}
		throw z0ZzZzzqh.z0eek(this, "Unexpected end while parsing unicode character.");
	}

	private void z0nek()
	{
		if (z0eek("new"))
		{
			z0eek(p0: false);
			int num = z0ork;
			int num2;
			while (true)
			{
				char c = z0srk_jiejie20260327142557[z0ork];
				if (c == '\0')
				{
					if (z0irk == z0ork)
					{
						if (z0tek(p0: true) == 0)
						{
							throw z0ZzZzzqh.z0eek(this, "Unexpected end while parsing constructor.");
						}
						continue;
					}
					num2 = z0ork;
					z0ork++;
					break;
				}
				if (char.IsLetterOrDigit(c))
				{
					z0ork++;
					continue;
				}
				switch (c)
				{
				case '\r':
					num2 = z0ork;
					z0rek(p0: true);
					break;
				case '\n':
					num2 = z0ork;
					z0iek_jiejie20260327142557();
					break;
				default:
					if (char.IsWhiteSpace(c))
					{
						num2 = z0ork;
						z0ork++;
						break;
					}
					if (c == '(')
					{
						num2 = z0ork;
						break;
					}
					throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Unexpected character while parsing constructor: {0}.", CultureInfo.InvariantCulture, c));
				}
				break;
			}
			z0trk = new z0ZzZzwwh(z0srk_jiejie20260327142557, num, num2 - num);
			string p = z0trk.z0uek();
			z0eek(p0: false);
			if (z0srk_jiejie20260327142557[z0ork] != '(')
			{
				throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Unexpected character while parsing constructor: {0}.", CultureInfo.InvariantCulture, z0srk_jiejie20260327142557[z0ork]));
			}
			z0ork++;
			z0drk();
			z0eek((z0ZzZzkwh)3, p);
			return;
		}
		throw z0ZzZzzqh.z0eek(this, "Unexpected content while parsing JSON.");
	}

	private new bool z0bek()
	{
		while (true)
		{
			char c = z0srk_jiejie20260327142557[z0ork];
			switch (c)
			{
			case '\0':
				if (z0irk == z0ork)
				{
					if (z0tek(p0: false) == 0)
					{
						z0wrk = z0thj.z0cek;
						return false;
					}
				}
				else
				{
					z0ork++;
				}
				break;
			case '}':
				z0ork++;
				z0rek((z0ZzZzkwh)13);
				return true;
			case ']':
				z0ork++;
				z0rek((z0ZzZzkwh)14);
				return true;
			case ')':
				z0ork++;
				z0rek((z0ZzZzkwh)15);
				return true;
			case '/':
				z0cek();
				return true;
			case ',':
				z0ork++;
				base.z0tek();
				return false;
			case '\t':
			case ' ':
				z0ork++;
				break;
			case '\r':
				z0rek(p0: false);
				break;
			case '\n':
				z0iek_jiejie20260327142557();
				break;
			default:
				if (char.IsWhiteSpace(c))
				{
					z0ork++;
					break;
				}
				throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("After parsing a value an unexpected character was encountered: {0}.", CultureInfo.InvariantCulture, c));
			}
		}
	}

	private new void z0vek()
	{
		int num = z0ork;
		char c;
		while (true)
		{
			c = z0srk_jiejie20260327142557[num];
			if (z0eek(c))
			{
				num++;
				continue;
			}
			if (c != 0)
			{
				break;
			}
			z0ork = num;
			if (z0irk == num && z0tek(p0: true) != 0)
			{
				continue;
			}
			return;
		}
		z0ork = num;
		char c2 = c;
		if (char.IsWhiteSpace(c2) || c2 == ',' || c2 == '}' || c2 == ']' || c2 == ')' || c2 == '/')
		{
			return;
		}
		throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Unexpected character encountered while parsing number: {0}.", CultureInfo.InvariantCulture, c2));
	}

	private void z0eek(z0ZzZzqwh p0, char p1, int p2, int p3)
	{
		if (p3 > p2)
		{
			p0.z0eek(z0srk_jiejie20260327142557, p2, p3 - p2);
		}
		p0.z0eek(p1);
	}

	private void z0cek()
	{
		z0ork++;
		if (!z0eek(1, p1: false))
		{
			throw z0ZzZzzqh.z0eek(this, "Unexpected end while parsing comment.");
		}
		bool flag;
		if (z0srk_jiejie20260327142557[z0ork] == '*')
		{
			flag = false;
		}
		else
		{
			if (z0srk_jiejie20260327142557[z0ork] != '/')
			{
				throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Error parsing comment. Expected: *, got {0}.", CultureInfo.InvariantCulture, z0srk_jiejie20260327142557[z0ork]));
			}
			flag = true;
		}
		z0ork++;
		int num = z0ork;
		bool flag2 = false;
		while (!flag2)
		{
			switch (z0srk_jiejie20260327142557[z0ork])
			{
			case '\0':
				if (z0irk == z0ork)
				{
					if (z0tek(p0: true) == 0)
					{
						if (!flag)
						{
							throw z0ZzZzzqh.z0eek(this, "Unexpected end while parsing comment.");
						}
						z0trk = new z0ZzZzwwh(z0srk_jiejie20260327142557, num, z0ork - num);
						flag2 = true;
					}
				}
				else
				{
					z0ork++;
				}
				break;
			case '*':
				z0ork++;
				if (!flag && z0eek(0, p1: true) && z0srk_jiejie20260327142557[z0ork] == '/')
				{
					z0trk = new z0ZzZzwwh(z0srk_jiejie20260327142557, num, z0ork - num - 1);
					z0ork++;
					flag2 = true;
				}
				break;
			case '\r':
				if (flag)
				{
					z0trk = new z0ZzZzwwh(z0srk_jiejie20260327142557, num, z0ork - num);
					flag2 = true;
				}
				z0rek(p0: true);
				break;
			case '\n':
				if (flag)
				{
					z0trk = new z0ZzZzwwh(z0srk_jiejie20260327142557, num, z0ork - num);
					flag2 = true;
				}
				z0iek_jiejie20260327142557();
				break;
			default:
				z0ork++;
				break;
			}
		}
		z0eek((z0ZzZzkwh)5, z0trk.z0uek());
		z0drk();
	}

	public z0ZzZzlwh(TextReader p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("reader");
		}
		z0yrk = p0;
		z0ark = 1;
		z0srk_jiejie20260327142557 = new char[1025];
	}

	public int z0rq()
	{
		return z0ork - z0urk;
	}

	private bool z0xek()
	{
		while (true)
		{
			char c = z0srk_jiejie20260327142557[z0ork];
			switch (c)
			{
			case '\0':
				if (z0irk == z0ork)
				{
					if (z0tek(p0: false) == 0)
					{
						return false;
					}
				}
				else
				{
					z0ork++;
				}
				break;
			case '"':
			case '\'':
				z0tek(c);
				return true;
			case 't':
				z0grk();
				return true;
			case 'f':
				z0lrk();
				return true;
			case 'n':
				if (z0eek(1, p1: true))
				{
					switch (z0srk_jiejie20260327142557[z0ork + 1])
					{
					case 'u':
						z0krk();
						break;
					case 'e':
						z0nek();
						break;
					default:
						throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Unexpected character encountered while parsing value: {0}.", CultureInfo.InvariantCulture, z0srk_jiejie20260327142557[z0ork]));
					}
					return true;
				}
				throw z0ZzZzzqh.z0eek(this, "Unexpected end.");
			case 'N':
				z0jrk();
				return true;
			case 'I':
				z0tek();
				return true;
			case '-':
				if (z0eek(1, p1: true) && z0srk_jiejie20260327142557[z0ork + 1] == 'I')
				{
					z0yek();
				}
				else
				{
					z0oek();
				}
				return true;
			case '/':
				z0cek();
				return true;
			case 'u':
				z0uek();
				return true;
			case '{':
				z0ork++;
				z0rek((z0ZzZzkwh)1);
				return true;
			case '[':
				z0ork++;
				z0rek((z0ZzZzkwh)2);
				return true;
			case ']':
				z0ork++;
				z0rek((z0ZzZzkwh)14);
				return true;
			case ',':
				z0rek((z0ZzZzkwh)12);
				return true;
			case ')':
				z0ork++;
				z0rek((z0ZzZzkwh)15);
				return true;
			case '\r':
				z0rek(p0: false);
				break;
			case '\n':
				z0iek_jiejie20260327142557();
				break;
			case '\t':
			case ' ':
				z0ork++;
				break;
			default:
				if (char.IsWhiteSpace(c))
				{
					z0ork++;
					break;
				}
				if (char.IsNumber(c) || c == '-' || c == '.')
				{
					z0oek();
					return true;
				}
				throw z0ZzZzzqh.z0eek(this, z0ZzZzewh.z0eek("Unexpected character encountered while parsing value: {0}.", CultureInfo.InvariantCulture, c));
			}
		}
	}

	private new z0ZzZzqwh z0zek()
	{
		if (z0rrk == null)
		{
			z0rrk = new z0ZzZzqwh(1025);
		}
		else
		{
			z0rrk.z0rek(0);
		}
		return z0rrk;
	}

	private void z0lrk()
	{
		if (z0eek("false"))
		{
			z0eek((z0ZzZzkwh)10, false);
			return;
		}
		throw z0ZzZzzqh.z0eek(this, "Error parsing boolean value.");
	}

	private new void z0krk()
	{
		if (z0eek("null"))
		{
			z0rek((z0ZzZzkwh)11);
			return;
		}
		throw z0ZzZzzqh.z0eek(this, "Error parsing null value.");
	}

	private bool z0yek(char p0)
	{
		switch (p0)
		{
		case ',':
		case ']':
		case '}':
			return true;
		case '/':
		{
			if (!z0eek(1, p1: false))
			{
				return false;
			}
			char c = z0srk_jiejie20260327142557[z0ork + 1];
			if (c != '*')
			{
				return c == '/';
			}
			return true;
		}
		case ')':
			if (base.z0oek() == z0thj.z0bek || base.z0oek() == z0thj.z0nek)
			{
				return true;
			}
			break;
		case '\t':
		case '\n':
		case '\r':
		case ' ':
			return true;
		default:
			if (char.IsWhiteSpace(p0))
			{
				return true;
			}
			break;
		}
		return false;
	}

	public override void z0eq()
	{
		base.z0eq();
		if (base.z0vek() && z0yrk != null)
		{
			z0yrk.Close();
		}
		if (z0rrk != null)
		{
			z0rrk.z0eek();
		}
	}

	private bool z0uek(char p0)
	{
		if (!char.IsLetterOrDigit(p0) && p0 != '_')
		{
			return p0 == '$';
		}
		return true;
	}

	private void z0jrk()
	{
		if (z0eek("NaN"))
		{
			z0eek((z0ZzZzkwh)8, z0ZzZzbok.z0rek);
			return;
		}
		throw z0ZzZzzqh.z0eek(this, "Error parsing NaN value.");
	}

	private bool z0hrk()
	{
		char c = z0srk_jiejie20260327142557[z0ork];
		char p;
		if (c == '"' || c == '\'')
		{
			z0ork++;
			p = c;
			z0frk();
			z0rek(p);
		}
		else
		{
			if (!z0uek(c))
			{
				throw z0ZzZzzqh.z0eek(this, "IVC2:" + z0srk_jiejie20260327142557[z0ork]);
			}
			p = '\0';
			z0frk();
			z0pek();
		}
		string p2 = z0trk.z0uek();
		z0eek(p0: false);
		if (z0srk_jiejie20260327142557[z0ork] != ':')
		{
			throw z0ZzZzzqh.z0eek(this, "IVC:" + z0srk_jiejie20260327142557[z0ork]);
		}
		z0ork++;
		z0eek((z0ZzZzkwh)4, p2);
		base.z0krk = p;
		z0drk();
		return true;
	}

	private void z0grk()
	{
		if (z0eek("true"))
		{
			z0eek((z0ZzZzkwh)10, true);
			return;
		}
		throw z0ZzZzzqh.z0eek(this, "Error parsing boolean value.");
	}

	private new void z0frk()
	{
		int num = z0srk_jiejie20260327142557.Length;
		if ((double)(num - z0ork) <= (double)num * 0.1)
		{
			int num2 = z0irk - z0ork;
			if (num2 > 0)
			{
				z0eek(z0srk_jiejie20260327142557, z0ork, z0srk_jiejie20260327142557, 0, num2);
			}
			z0urk -= z0ork;
			z0ork = 0;
			z0irk = num2;
			z0srk_jiejie20260327142557[z0irk] = '\0';
		}
	}

	private static void z0eek(char[] p0, int p1, char[] p2, int p3, int p4)
	{
		Buffer.BlockCopy(p0, p1 * 2, p2, p3 * 2, p4 * 2);
	}

	private void z0eek(int p0)
	{
		z0ark++;
		z0urk = p0 - 1;
	}

	private void z0drk()
	{
		if (z0rrk != null)
		{
			z0rrk.z0rek(0);
		}
		z0trk.z0yek();
	}
}
