using System;
using System.Collections;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZzxmk : IDisposable
{
	private bool z0yek;

	private z0ZzZzzmk z0uek;

	private string z0iek;

	public z0ZzZzxmk(string p0)
	{
		z0rek(p0);
	}

	public z0ZzZzxmk(string p0, bool p1)
	{
		z0yek = p1;
		z0rek(p0);
	}

	public string z0rek()
	{
		return z0iek;
	}

	internal static bool z0rek(object p0, bool p1 = false)
	{
		if (p0 == null || DBNull.Value.Equals(p0))
		{
			return p1;
		}
		if (p0 is bool)
		{
			return (bool)p0;
		}
		if (p0 is string)
		{
			if (string.Compare((string)p0, "true", true) == 0)
			{
				return true;
			}
			return false;
		}
		if (p0 is float num)
		{
			if (float.IsNaN(num) || num == 0f)
			{
				return false;
			}
			return true;
		}
		if (p0 is double num2)
		{
			if (z0ZzZzbok.z0eek(num2) || num2 == 0.0)
			{
				return false;
			}
			return true;
		}
		if (p0 is int num3)
		{
			if (num3 == 2147439148 || num3 == 0)
			{
				return false;
			}
			return true;
		}
		if (p0.GetType().IsValueType)
		{
			try
			{
				int num4 = Convert.ToInt32(p0);
				if (num4 == 2147439148 || num4 == 0)
				{
					return false;
				}
				return true;
			}
			catch (Exception)
			{
				return p1;
			}
		}
		if (p0 is Array)
		{
			Array array = (Array)p0;
			if (array.Length > 0)
			{
				return z0rek(array.GetValue(0), p1);
			}
		}
		return p1;
	}

	public static double z0rek(object p0, double p1 = 0.0)
	{
		if (p0 == null || DBNull.Value.Equals(p0))
		{
			return p1;
		}
		if (p0 is float)
		{
			if (float.IsNaN((float)p0))
			{
				return p1;
			}
			return (double)p0;
		}
		if (p0 is double)
		{
			if (z0ZzZzbok.z0eek((double)p0))
			{
				return p1;
			}
			return (double)p0;
		}
		if (p0 is string)
		{
			string text = (string)p0;
			if (string.IsNullOrEmpty(text))
			{
				return p1;
			}
			if (string.Compare(text, "NaN", true) == 0)
			{
				return z0ZzZzbok.z0rek;
			}
			double result = p1;
			if (double.TryParse(text, out result))
			{
				return result;
			}
			return p1;
		}
		if (p0 != null && p0.GetType().IsArray)
		{
			foreach (object item in (IEnumerable)p0)
			{
				if (item != null)
				{
					double num = z0rek(item, z0ZzZzbok.z0rek);
					if (!z0ZzZzbok.z0eek(num))
					{
						return num;
					}
				}
			}
			return p1;
		}
		double num2 = Convert.ToDouble(p0);
		if (z0ZzZzbok.z0eek(num2))
		{
			return p1;
		}
		return num2;
	}

	public object Eval(z0ZzZzwnk context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (z0uek == null)
		{
			throw new NullReferenceException("this.RootItem");
		}
		object obj = z0uek.z0pqk(context);
		if (obj is Array)
		{
			Array array = (Array)obj;
			if (array.Length > 0)
			{
				string text = string.Empty;
				for (int i = 0; i < array.Length; i++)
				{
					text = ((i != array.Length - 1) ? (text + array.GetValue(i).ToString() + ",") : (text + array.GetValue(i).ToString()));
				}
				return text;
			}
			return null;
		}
		return obj;
	}

	private void z0rek(z0ZzZzzmk p0, z0ZzZzsnk p1)
	{
		List<z0ZzZzzmk> list = new List<z0ZzZzzmk>();
		while (p1.z0rek())
		{
			z0ZzZzzmk z0ZzZzzmk2 = null;
			z0ZzZzdnk z0ZzZzdnk2 = p1.z0tek();
			if (z0ZzZzdnk2.z0tek == (z0ZzZzvmk)1)
			{
				if (string.Equals(z0ZzZzdnk2.z0rek, "And", StringComparison.CurrentCultureIgnoreCase))
				{
					z0ZzZzdnk2.z0tek = (z0ZzZzvmk)2;
					z0ZzZzdnk2.z0rek = "&&";
				}
				else if (string.Equals(z0ZzZzdnk2.z0rek, "or", StringComparison.CurrentCultureIgnoreCase))
				{
					z0ZzZzdnk2.z0tek = (z0ZzZzvmk)2;
					z0ZzZzdnk2.z0rek = "||";
				}
			}
			z0ZzZzgnk z0ZzZzgnk2;
			string text2;
			if (z0ZzZzdnk2.z0tek == (z0ZzZzvmk)1)
			{
				z0ZzZzdnk z0ZzZzdnk3 = p1.z0eek();
				if (z0ZzZzdnk3 != null && z0ZzZzdnk3.z0tek == (z0ZzZzvmk)4)
				{
					p1.z0rek();
					z0ZzZzknk z0ZzZzknk2 = new z0ZzZzknk();
					z0ZzZzknk2.z0eek(z0ZzZzdnk2.z0rek);
					z0rek(z0ZzZzknk2, p1);
					z0ZzZzzmk2 = z0ZzZzknk2;
					z0ZzZzzmk2.z0eek(0);
				}
				else
				{
					if (string.Compare(z0ZzZzdnk2.z0rek, "true", true) == 0)
					{
						z0ZzZzzmk2 = new z0ZzZzcmk(true, (z0ZzZzank)2);
					}
					else if (string.Compare(z0ZzZzdnk2.z0rek, "false", true) == 0)
					{
						z0ZzZzzmk2 = new z0ZzZzcmk(false, (z0ZzZzank)2);
					}
					else if (string.Compare(z0ZzZzdnk2.z0rek, "null", true) == 0)
					{
						z0ZzZzzmk2 = new z0ZzZzcmk(null, (z0ZzZzank)3);
					}
					else
					{
						double num = 0.0;
						if (double.TryParse(z0ZzZzdnk2.z0rek, out num) && !z0yek)
						{
							z0ZzZzzmk2 = new z0ZzZzcmk(num, (z0ZzZzank)0);
						}
						else
						{
							z0ZzZzqnk obj = new z0ZzZzqnk();
							obj.z0eek(z0ZzZzdnk2.z0rek);
							z0ZzZzzmk2 = obj;
						}
					}
					z0ZzZzzmk2.z0eek(0);
				}
			}
			else if (z0ZzZzdnk2.z0tek == (z0ZzZzvmk)10)
			{
				string text = z0ZzZzdnk2.z0rek;
				if (text != null && text.Length >= 2 && (text[0] == '\'' || text[0] == '"'))
				{
					text = text.Substring(1, text.Length - 2);
				}
				z0ZzZzzmk2 = new z0ZzZzcmk(text, (z0ZzZzank)1);
			}
			else
			{
				if (z0ZzZzdnk2.z0tek != (z0ZzZzvmk)4)
				{
					if (z0ZzZzdnk2.z0tek == (z0ZzZzvmk)9 || z0ZzZzdnk2.z0tek == (z0ZzZzvmk)5)
					{
						_ = list?.Count;
						if (list != null && list.Count > 0)
						{
							z0ZzZzzmk p2 = z0eek(list);
							p0.z0nqk(p2);
						}
						list = new List<z0ZzZzzmk>();
						if (z0ZzZzdnk2.z0tek == (z0ZzZzvmk)5)
						{
							break;
						}
						continue;
					}
					if (z0ZzZzdnk2.z0tek == (z0ZzZzvmk)2 || z0ZzZzdnk2.z0tek == (z0ZzZzvmk)3)
					{
						z0ZzZzgnk2 = new z0ZzZzgnk();
						z0ZzZzgnk2.z0eek(z0ZzZzdnk2.z0rek);
						text2 = z0ZzZzdnk2.z0rek;
						if (text2 != null)
						{
							int length = text2.Length;
							if (length == 1)
							{
								switch (text2[0])
								{
								case '+':
									break;
								case '-':
									goto IL_03d6;
								case '*':
									goto IL_03eb;
								case '/':
									goto IL_0400;
								case '>':
									goto IL_0415;
								case '=':
									goto IL_0450;
								case '<':
									goto IL_048c;
								case '%':
									goto IL_04c8;
								default:
									goto IL_0547;
								}
								z0ZzZzgnk2.z0eek((z0ZzZzfnk)1);
								z0ZzZzgnk2.z0eek(1);
								goto IL_055d;
							}
							if (length == 2)
							{
								switch (text2[0])
								{
								case '>':
									break;
								case '=':
									goto IL_0342;
								case '<':
									goto IL_0358;
								case '|':
									goto IL_037f;
								case '&':
									goto IL_0395;
								case '!':
									goto IL_03ab;
								default:
									goto IL_0547;
								}
								if (text2 == ">=")
								{
									z0ZzZzgnk2.z0eek((z0ZzZzfnk)9);
									((z0ZzZzzmk)z0ZzZzgnk2).z0eek(0);
									z0ZzZzgnk2.z0eek(p0: true);
									goto IL_055d;
								}
							}
						}
						goto IL_0547;
					}
					throw new NotSupportedException(z0ZzZzdnk2.z0tek.ToString() + ":" + z0ZzZzdnk2.z0rek);
				}
				z0ZzZzhnk z0ZzZzhnk2 = new z0ZzZzhnk();
				z0ZzZzzmk2 = z0ZzZzhnk2;
				z0ZzZzzmk2.z0eek(0);
				z0rek(z0ZzZzhnk2, p1);
			}
			goto IL_0589;
			IL_0547:
			throw new NotSupportedException("无效操作符:" + z0ZzZzdnk2.z0rek);
			IL_0415:
			z0ZzZzgnk2.z0eek((z0ZzZzfnk)8);
			((z0ZzZzzmk)z0ZzZzgnk2).z0eek(0);
			z0ZzZzgnk2.z0eek(p0: true);
			goto IL_055d;
			IL_0450:
			z0ZzZzgnk2.z0eek((z0ZzZzfnk)12);
			((z0ZzZzzmk)z0ZzZzgnk2).z0eek(0);
			z0ZzZzgnk2.z0eek(p0: true);
			goto IL_055d;
			IL_03ab:
			if (!(text2 == "!="))
			{
				goto IL_0547;
			}
			z0ZzZzgnk2.z0eek((z0ZzZzfnk)13);
			((z0ZzZzzmk)z0ZzZzgnk2).z0eek(0);
			z0ZzZzgnk2.z0eek(p0: true);
			goto IL_055d;
			IL_0400:
			z0ZzZzgnk2.z0eek((z0ZzZzfnk)4);
			z0ZzZzgnk2.z0eek(2);
			goto IL_055d;
			IL_0342:
			if (!(text2 == "=="))
			{
				goto IL_0547;
			}
			z0ZzZzgnk2.z0eek((z0ZzZzfnk)12);
			((z0ZzZzzmk)z0ZzZzgnk2).z0eek(0);
			z0ZzZzgnk2.z0eek(p0: true);
			goto IL_055d;
			IL_04c8:
			z0ZzZzgnk2.z0eek((z0ZzZzfnk)5);
			z0ZzZzgnk2.z0eek(2);
			goto IL_055d;
			IL_037f:
			if (!(text2 == "||"))
			{
				goto IL_0547;
			}
			z0ZzZzgnk2.z0eek((z0ZzZzfnk)7);
			z0ZzZzgnk2.z0eek(-1);
			z0ZzZzgnk2.z0eek(p0: true);
			goto IL_055d;
			IL_03eb:
			z0ZzZzgnk2.z0eek((z0ZzZzfnk)3);
			z0ZzZzgnk2.z0eek(2);
			goto IL_055d;
			IL_0395:
			if (!(text2 == "&&"))
			{
				goto IL_0547;
			}
			z0ZzZzgnk2.z0eek((z0ZzZzfnk)6);
			z0ZzZzgnk2.z0eek(-1);
			z0ZzZzgnk2.z0eek(p0: true);
			goto IL_055d;
			IL_048c:
			z0ZzZzgnk2.z0eek((z0ZzZzfnk)10);
			((z0ZzZzzmk)z0ZzZzgnk2).z0eek(0);
			z0ZzZzgnk2.z0eek(p0: true);
			goto IL_055d;
			IL_03d6:
			z0ZzZzgnk2.z0eek((z0ZzZzfnk)2);
			z0ZzZzgnk2.z0eek(1);
			goto IL_055d;
			IL_0358:
			if (!(text2 == "<="))
			{
				if (!(text2 == "<>"))
				{
					goto IL_0547;
				}
				z0ZzZzgnk2.z0eek((z0ZzZzfnk)13);
				((z0ZzZzzmk)z0ZzZzgnk2).z0eek(0);
				z0ZzZzgnk2.z0eek(p0: true);
			}
			else
			{
				z0ZzZzgnk2.z0eek((z0ZzZzfnk)11);
				((z0ZzZzzmk)z0ZzZzgnk2).z0eek(0);
				z0ZzZzgnk2.z0eek(p0: true);
			}
			goto IL_055d;
			IL_0589:
			list.Add(z0ZzZzzmk2);
			continue;
			IL_055d:
			z0ZzZzzmk2 = z0ZzZzgnk2;
			goto IL_0589;
		}
		z0ZzZzzmk z0ZzZzzmk3 = z0eek(list);
		if (z0ZzZzzmk3 != null)
		{
			p0.z0nqk(z0ZzZzzmk3);
		}
	}

	public void z0rek(string p0)
	{
		z0iek = p0;
		z0ZzZzsnk p1 = new z0ZzZzsnk(p0);
		z0uek = new z0ZzZzhnk();
		z0rek(z0uek, p1);
	}

	public void Dispose()
	{
		if (z0uek != null)
		{
			z0uek.Dispose();
			z0uek = null;
		}
		z0iek = null;
	}

	private z0ZzZzzmk z0eek(List<z0ZzZzzmk> p0)
	{
		if (p0.Count == 1)
		{
			return p0[0];
		}
		if (p0.Count == 0)
		{
			return null;
		}
		for (int i = 0; i < p0.Count; i++)
		{
			if (!(p0[i] is z0ZzZzgnk) || i >= p0.Count - 1)
			{
				continue;
			}
			z0ZzZzgnk z0ZzZzgnk2 = (z0ZzZzgnk)p0[i];
			if (z0ZzZzgnk2.z0tek() != (z0ZzZzfnk)2)
			{
				continue;
			}
			bool flag = false;
			if (i == 0)
			{
				flag = true;
			}
			else
			{
				z0ZzZzzmk z0ZzZzzmk2 = p0[i - 1];
				if (z0ZzZzzmk2 is z0ZzZzgnk)
				{
					if (((z0ZzZzgnk)z0ZzZzzmk2).z0yek_jiejie20260327142557())
					{
						flag = true;
					}
				}
				else if (z0ZzZzzmk2 is z0ZzZzhnk)
				{
					flag = true;
				}
			}
			if (flag)
			{
				z0ZzZzgnk2.z0eek((z0ZzZzfnk)14);
				z0ZzZzgnk2.z0rek(p0[i + 1]);
				p0.RemoveAt(i + 1);
				((z0ZzZzzmk)z0ZzZzgnk2).z0eek(0);
				((z0ZzZzzmk)z0ZzZzgnk2).z0eek(p0: true);
			}
		}
		while (p0.Count > 1)
		{
			z0ZzZzgnk z0ZzZzgnk3 = null;
			int num = -1;
			int count = p0.Count;
			for (int j = 0; j < count; j++)
			{
				z0ZzZzzmk z0ZzZzzmk3 = p0[j];
				if (!z0ZzZzzmk3.z0eek() && z0ZzZzzmk3 is z0ZzZzgnk && (z0ZzZzgnk3 == null || ((z0ZzZzzmk)z0ZzZzgnk3).z0rek() < z0ZzZzzmk3.z0rek()))
				{
					z0ZzZzgnk3 = (z0ZzZzgnk)z0ZzZzzmk3;
					num = j;
				}
			}
			if (z0ZzZzgnk3 == null)
			{
				break;
			}
			if (num < p0.Count - 1)
			{
				z0ZzZzgnk3.z0rek(p0[num + 1]);
				p0.RemoveAt(num + 1);
			}
			if (num > 0)
			{
				z0ZzZzgnk3.z0eek(p0[num - 1]);
				p0.RemoveAt(num - 1);
			}
			((z0ZzZzzmk)z0ZzZzgnk3).z0eek(p0: true);
		}
		if (p0.Count > 0)
		{
			return p0[0];
		}
		return null;
	}
}
