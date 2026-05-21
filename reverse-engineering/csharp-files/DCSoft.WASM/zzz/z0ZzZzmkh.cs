using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzmkh : z0ZzZzwnk
{
	private Dictionary<string, z0ZzZzxmk> z0iek = new Dictionary<string, z0ZzZzxmk>();

	private z0ZzZznkh z0oek;

	private XTextElement z0pek;

	private StringBuilder z0mek;

	private z0ZzZztkh z0nek;

	private string z0bek;

	private static readonly string z0vek = z0ZzZzbok.z0rek.ToString();

	private XTextDocument z0cek;

	public void z0eek(string p0, object p1)
	{
		if (!z0yek())
		{
			return;
		}
		if (z0mek == null)
		{
			z0mek = new StringBuilder();
		}
		z0mek.Append(">>" + p0 + "=");
		if (p1 == null || DBNull.Value.Equals(p1))
		{
			z0mek.Append("[NULL]");
		}
		else if (p1 is Array)
		{
			IList list = (IList)p1;
			for (int i = 0; i < list.Count; i++)
			{
				object obj = list[i];
				if (i > 0)
				{
					z0mek.Append(',');
				}
				if (obj == null || DBNull.Value.Equals(obj))
				{
					z0mek.Append("[NULL]");
				}
				else
				{
					z0mek.Append(Convert.ToString(obj));
				}
			}
		}
		else
		{
			z0mek.Append(Convert.ToString(p1));
		}
	}

	protected static object z0eek(object p0, bool p1)
	{
		if (p0 != null && p0.GetType().IsArray)
		{
			if (p1)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (object item in (IEnumerable)p0)
				{
					if (item == null || DBNull.Value.Equals(item))
					{
						continue;
					}
					string text = Convert.ToString(item);
					if (!string.IsNullOrEmpty(text))
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(",");
						}
						stringBuilder.Append(text);
					}
				}
				return stringBuilder.ToString();
			}
			double num = 0.0;
			foreach (object item2 in (IEnumerable)p0)
			{
				if (item2 != null && !DBNull.Value.Equals(item2))
				{
					double num2 = z0eek(item2);
					if (!z0ZzZzbok.z0eek(num2))
					{
						num += num2;
					}
				}
			}
			return num;
		}
		return p0;
	}

	private object z0eek(string p0, object[] p1)
	{
		if (z0tek() != null && z0tek().z0cu() != null)
		{
			return z0tek().z0cu().z0pj(p0, p1);
		}
		return null;
	}

	object z0ZzZzwnk.z0eek(string p0, object[] p1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek(p0, p1);
	}

	public object z0eek()
	{
		z0ZzZzxmk z0ZzZzxmk2 = null;
		if (z0iek.ContainsKey(z0bek))
		{
			z0ZzZzxmk2 = z0iek[z0bek];
		}
		else
		{
			z0ZzZzxmk2 = ((z0oek == null || !(z0oek.z0nek() == "[" + z0bek + "]")) ? new z0ZzZzxmk(z0bek) : new z0ZzZzxmk(z0bek, p1: true));
			z0iek[z0bek] = z0ZzZzxmk2;
		}
		return z0ZzZzxmk2.Eval(this);
	}

	internal z0ZzZzmkh(string p0, XTextElement p1, z0ZzZznkh p2, z0ZzZztkh p3)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("expression");
		}
		z0bek = p0;
		if (p1 == null)
		{
			throw new ArgumentNullException("element");
		}
		z0pek = p1;
		z0cek = p1.z0jr();
		z0oek = p2;
		z0nek = p3;
	}

	public XTextElement z0rek()
	{
		return z0pek;
	}

	public static double z0eek(object p0)
	{
		p0 = z0eek(p0, p1: false);
		if (p0 == null)
		{
			return z0ZzZzbok.z0rek;
		}
		if (p0 is double)
		{
			return (double)p0;
		}
		string text = Convert.ToString(p0);
		if (text == null || text.Length == 0)
		{
			return z0ZzZzbok.z0rek;
		}
		text = text.Trim();
		if (text.Length == 0 || text.Length > 30)
		{
			return z0ZzZzbok.z0rek;
		}
		if (string.Compare(text, "NaN", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(text, z0vek, StringComparison.OrdinalIgnoreCase) == 0)
		{
			return z0ZzZzbok.z0rek;
		}
		double result = z0ZzZzbok.z0rek;
		if (double.TryParse(text, out result))
		{
			return result;
		}
		return z0ZzZzbok.z0rek;
	}

	public XTextDocument z0tek()
	{
		return z0cek;
	}

	private object z0eek(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		if (p0[0] == '[' && p0.Length > 1 && p0[p0.Length - 1] == ']')
		{
			p0 = p0.Substring(1, p0.Length - 2);
		}
		if (z0tek() != null)
		{
			if (z0ZzZznkh.z0yek(p0) && z0rek() != null)
			{
				string text = z0rek().Text;
				z0eek("Value", text);
				return text;
			}
			if (p0.StartsWith("this.", StringComparison.CurrentCultureIgnoreCase))
			{
				string p1 = p0.Substring(5).Trim();
				if (z0rek() != null)
				{
					z0ZzZzfuk z0ZzZzfuk2 = z0ZzZzfuk.z0eek(z0rek().GetType(), p1);
					if (z0ZzZzfuk2 != null)
					{
						object obj = z0ZzZzfuk2.z0eek(z0rek());
						z0eek("this." + z0ZzZzfuk2.z0rek(), obj);
						return obj;
					}
				}
			}
			if (z0oek != null)
			{
				bool p2 = false;
				string text2 = z0bek.ToLower();
				bool flag = text2.IndexOf('+') > 0 || text2.IndexOf('-') > 0 || text2.IndexOf('*') > 0 || text2.IndexOf('/') > 0 || text2.StartsWith("sum", StringComparison.Ordinal) || text2.StartsWith("product", StringComparison.Ordinal) || text2.IndexOf('>') > 0 || text2.IndexOf('<') > 0;
				if (flag)
				{
					string[] array = new string[4] { "DAYDIFF", "MINUTEDIFF", "HOURDIFF", "FIND" };
					foreach (string text3 in array)
					{
						if (text2.Contains(text3))
						{
							flag = false;
						}
					}
				}
				object obj2 = z0oek.z0eek(p0, ref p2, flag);
				if (p2)
				{
					z0eek(p0, obj2);
					return obj2;
				}
			}
			object obj3 = null;
			XTextElement xTextElement = null;
			xTextElement = ((z0nek != null) ? z0nek.z0tek(p0, null) : z0tek().z0cek(p0, p1: true));
			if (xTextElement != null && !z0ZzZznkh.z0eek(xTextElement, z0yek()))
			{
				if (xTextElement is XTextCheckBoxElementBase)
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)xTextElement;
					if (xTextCheckBoxElementBase.Checked)
					{
						obj3 = xTextCheckBoxElementBase.CheckedValue;
					}
				}
				else
				{
					obj3 = xTextElement.Text;
				}
				z0eek(p0, obj3);
				return obj3;
			}
			z0eek(p0, obj3);
			return obj3;
		}
		z0eek(p0, (object)null);
		return null;
	}

	object z0ZzZzwnk.z0eek(string p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek(p0);
	}

	private bool z0yek()
	{
		if (z0tek() != null && z0tek().z0vtk().BehaviorOptions.DebugMode)
		{
			return true;
		}
		return false;
	}

	public string z0uek()
	{
		if (z0mek == null)
		{
			return null;
		}
		return z0mek.ToString();
	}
}
