using System;
using System.Collections;

namespace zzz;

public class z0ZzZzgnk : z0ZzZzzmk
{
	private string z0iek;

	private bool z0oek;

	private z0ZzZzzmk z0pek;

	private z0ZzZzfnk z0mek;

	private z0ZzZzzmk z0nek;

	public void z0eek(z0ZzZzfnk p0)
	{
		z0mek = p0;
	}

	private int z0eek(z0ZzZzwnk p0)
	{
		object obj = ((z0uek() == null) ? null : z0uek().z0pqk(p0));
		object obj2 = ((z0eek() == null) ? null : z0eek().z0pqk(p0));
		if (obj == obj2)
		{
			return 0;
		}
		if ((obj is int || obj is double) && (obj2 is int || obj2 is double))
		{
			double p1 = Convert.ToDouble(obj);
			double p2 = Convert.ToDouble(obj2);
			return z0eek(p1, p2);
		}
		bool flag = false;
		if (obj == null || obj2 == null)
		{
			if (obj is string || obj2 is string)
			{
				flag = true;
			}
		}
		else if (obj is string && obj2 is string)
		{
			flag = true;
		}
		if (flag)
		{
			if (obj == null && obj2 == null)
			{
				return 0;
			}
			string text = (string)obj;
			string text2 = (string)obj2;
			int num = text?.Length ?? 0;
			int num2 = text2?.Length ?? 0;
			if (num == 0 && num2 == 0)
			{
				return 0;
			}
			return string.Compare(text, text2);
		}
		if (obj is float && obj2 is float)
		{
			return ((float)obj).CompareTo((float)obj2);
		}
		if (obj is double && obj2 is double)
		{
			return z0eek((double)obj, (double)obj2);
		}
		bool flag2 = obj != null && !DBNull.Value.Equals(obj);
		if (flag2 && obj is string)
		{
			flag2 = !string.IsNullOrEmpty((string)obj);
		}
		bool flag3 = obj2 != null && !DBNull.Value.Equals(obj2);
		if (flag2 && obj2 is string)
		{
			flag3 = !string.IsNullOrEmpty((string)obj2);
		}
		if (flag2 && flag3)
		{
			try
			{
				Type type = obj.GetType();
				Type type2 = obj2.GetType();
				if (type == type2)
				{
					return Comparer.Default.Compare(obj, obj2);
				}
				switch ((z0ZzZzank)Math.Min((int)z0eek(type), (int)z0eek(type2)))
				{
				case (z0ZzZzank)2:
				{
					bool flag4 = Convert.ToBoolean(obj);
					bool flag5 = Convert.ToBoolean(obj2);
					return flag4.CompareTo(flag5);
				}
				case (z0ZzZzank)0:
				{
					string? text5 = Convert.ToString(obj);
					string text6 = Convert.ToString(obj2);
					double num3 = 0.0 / 0.0;
					double num4 = 0.0 / 0.0;
					if (!double.TryParse(text5, out num3))
					{
						return -1;
					}
					if (!double.TryParse(text6, out num4))
					{
						return 1;
					}
					return num3.CompareTo(num4);
				}
				default:
				{
					string? text3 = Convert.ToString(obj);
					string text4 = Convert.ToString(obj2);
					return text3.CompareTo(text4);
				}
				}
			}
			catch (Exception ex)
			{
				z0ZzZzqok.z0rek.z0dh(ex.ToString());
			}
		}
		return flag2.CompareTo(flag3);
	}

	public override void Dispose()
	{
		if (z0nek != null)
		{
			z0nek.Dispose();
			z0nek = null;
		}
		if (z0pek != null)
		{
			z0pek.Dispose();
			z0pek = null;
		}
		z0iek = null;
	}

	public new void z0eek(bool p0)
	{
		z0oek = p0;
	}

	public override z0ZzZzzmk z0mqk()
	{
		z0ZzZzgnk z0ZzZzgnk2 = (z0ZzZzgnk)MemberwiseClone();
		if (z0nek != null)
		{
			z0ZzZzgnk2.z0nek = z0nek.z0mqk();
		}
		if (z0pek != null)
		{
			z0ZzZzgnk2.z0pek = z0pek.z0mqk();
		}
		return z0ZzZzgnk2;
	}

	private z0ZzZzank z0eek(Type p0)
	{
		if (p0 == typeof(string))
		{
			return (z0ZzZzank)1;
		}
		if (p0 == typeof(bool))
		{
			return (z0ZzZzank)2;
		}
		_ = p0.IsValueType;
		return (z0ZzZzank)0;
	}

	public override object z0pqk(z0ZzZzwnk p0)
	{
		switch (z0tek())
		{
		case (z0ZzZzfnk)6:
			if (!z0eek(z0uek(), p0, p2: false))
			{
				return false;
			}
			return z0eek(z0eek(), p0, p2: false);
		case (z0ZzZzfnk)7:
			if (z0eek(z0uek(), p0, p2: false))
			{
				return true;
			}
			return z0eek(z0eek(), p0, p2: false);
		case (z0ZzZzfnk)8:
			return z0eek(p0) > 0;
		case (z0ZzZzfnk)9:
			return z0eek(p0) >= 0;
		case (z0ZzZzfnk)12:
			return z0eek(p0) == 0;
		case (z0ZzZzfnk)10:
			return z0eek(p0) < 0;
		case (z0ZzZzfnk)11:
			return z0eek(p0) <= 0;
		case (z0ZzZzfnk)13:
			return z0eek(p0) != 0;
		case (z0ZzZzfnk)1:
		{
			double num7 = z0eek(z0uek(), p0, z0ZzZzbok.z0rek);
			double num8 = z0eek(z0eek(), p0, z0ZzZzbok.z0rek);
			if (z0ZzZzbok.z0eek(num7))
			{
				if (z0ZzZzbok.z0eek(num8))
				{
					return z0ZzZzbok.z0rek;
				}
				return num8;
			}
			if (z0ZzZzbok.z0eek(num8))
			{
				return num7;
			}
			return num7 + num8;
		}
		case (z0ZzZzfnk)2:
		{
			double num9 = z0eek(z0uek(), p0, z0ZzZzbok.z0rek);
			double num10 = z0eek(z0eek(), p0, z0ZzZzbok.z0rek);
			if (z0ZzZzbok.z0eek(num9))
			{
				if (z0ZzZzbok.z0eek(num10))
				{
					return z0ZzZzbok.z0rek;
				}
				return num10;
			}
			if (z0ZzZzbok.z0eek(num10))
			{
				return num9;
			}
			return num9 - num10;
		}
		case (z0ZzZzfnk)3:
		{
			double num3 = z0eek(z0uek(), p0, z0ZzZzbok.z0rek);
			double num4 = z0eek(z0eek(), p0, z0ZzZzbok.z0rek);
			if (z0ZzZzbok.z0eek(num3) || z0ZzZzbok.z0eek(num4))
			{
				return z0ZzZzbok.z0rek;
			}
			return num3 * num4;
		}
		case (z0ZzZzfnk)14:
		{
			double num11 = 0.0;
			if (z0eek() != null)
			{
				num11 = z0eek(z0eek(), p0, z0ZzZzbok.z0rek);
			}
			else if (z0uek() != null)
			{
				num11 = z0eek(z0uek(), p0, z0ZzZzbok.z0rek);
			}
			if (z0ZzZzbok.z0eek(num11))
			{
				return z0ZzZzbok.z0rek;
			}
			return 0.0 - num11;
		}
		case (z0ZzZzfnk)4:
		{
			double num5 = z0eek(z0uek(), p0, z0ZzZzbok.z0rek);
			double num6 = z0eek(z0eek(), p0, z0ZzZzbok.z0rek);
			if (z0ZzZzbok.z0eek(num5) || z0ZzZzbok.z0eek(num6) || num6 == 0.0)
			{
				return z0ZzZzbok.z0rek;
			}
			return num5 / num6;
		}
		case (z0ZzZzfnk)5:
		{
			double num = z0eek(z0uek(), p0, z0ZzZzbok.z0rek);
			double num2 = z0eek(z0eek(), p0, z0ZzZzbok.z0rek);
			if (z0ZzZzbok.z0eek(num) || z0ZzZzbok.z0eek(num2) || num2 == 0.0)
			{
				return z0ZzZzbok.z0rek;
			}
			return num % num2;
		}
		default:
			throw new NotSupportedException(z0tek().ToString());
		}
	}

	public new z0ZzZzzmk z0eek()
	{
		return z0pek;
	}

	public void z0eek(string p0)
	{
		z0iek = p0;
	}

	internal override void z0nqk(z0ZzZzzmk p0)
	{
		if (z0nek == null)
		{
			z0nek = p0;
			return;
		}
		if (z0pek == null)
		{
			z0pek = p0;
			return;
		}
		throw new NotSupportedException("无法添加超过2个子项目。");
	}

	private double z0eek(z0ZzZzzmk p0, z0ZzZzwnk p1, double p2 = 0.0)
	{
		if (p0 == null)
		{
			return p2;
		}
		return z0ZzZzxmk.z0rek(p0.z0pqk(p1), p2);
	}

	private int z0eek(double p0, double p1)
	{
		if (p0 == p1)
		{
			return 0;
		}
		bool flag = z0ZzZzbok.z0eek(p0) || p0 == 2147439148.0;
		bool flag2 = z0ZzZzbok.z0eek(p1) || p1 == 2147439148.0;
		if (flag && flag2)
		{
			return 0;
		}
		if ((flag && p1 == 0.0) || (flag2 && p0 == 0.0))
		{
			return 0;
		}
		return p0.CompareTo(p1);
	}

	public void z0eek(z0ZzZzzmk p0)
	{
		z0nek = p0;
	}

	public void z0rek(z0ZzZzzmk p0)
	{
		z0pek = p0;
	}

	public new string z0rek()
	{
		return z0iek;
	}

	public z0ZzZzfnk z0tek()
	{
		return z0mek;
	}

	public bool z0yek_jiejie20260327142557()
	{
		return z0oek;
	}

	public z0ZzZzzmk z0uek()
	{
		return z0nek;
	}

	private bool z0eek(z0ZzZzzmk p0, z0ZzZzwnk p1, bool p2 = false)
	{
		if (p0 == null)
		{
			return p2;
		}
		return z0ZzZzxmk.z0rek(p0.z0pqk(p1), p1: false);
	}
}
