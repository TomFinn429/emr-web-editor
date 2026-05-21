using System;
using System.Diagnostics;
using System.Text;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

public static class z0ZzZzccj
{
	private static readonly object z0vek;

	private static readonly object z0cek;

	internal static DateTime z0hrk;

	private static readonly z0ZzZzwok z0grk;

	private static readonly z0ZzZzwok z0ark;

	public static int z0qrk;

	private static readonly z0ZzZzwok z0yrk;

	private static bool z0irk;

	internal static bool z0eek(int p0)
	{
		z0ZzZzpck z0ZzZzpck2 = z0uek();
		if (z0ZzZzpck2 != null && z0ZzZzpck2.z0zek)
		{
			return z0ZzZzpck2.z0eek(p0);
		}
		return false;
	}

	internal static object z0eek(bool p0, int p1, int p2, string p3 = null)
	{
		z0ZzZzpck z0ZzZzpck2 = null;
		z0ZzZzick z0ZzZzick2 = z0ZzZzvcj.z0rek;
		if (p1 >= 0 && z0ZzZzick2 != null && z0ZzZzick2.z0rek() != p1)
		{
			z0ZzZzick2.z0rek(p1);
		}
		z0ZzZzpck2 = z0uek();
		if (z0ZzZzpck2 == null)
		{
			z0ZzZzpck2 = z0ZzZzpck.z0eek();
		}
		if (!z0irk && DateTime.Now.Ticks % 100 > 97 && z0ZzZzxvj.z0eek)
		{
			z0irk = true;
		}
		if (z0irk)
		{
			return new z0ZzZzxpk
			{
				z0nek = new z0ZzZzwok(z0grk.z0tek() + typeof(XTextDocument).Assembly.Location),
				z0hrk = 15f,
				z0vek = Color.Red,
				z0krk = true,
				z0yek = false
			};
		}
		if (z0ZzZzpck2.z0htk != null && z0ZzZzpck2.z0eek(p2))
		{
			return z0ZzZzpck2.z0htk;
		}
		z0ZzZzxpk z0ZzZzxpk2 = new z0ZzZzxpk();
		if (z0ZzZzpck2.z0zek)
		{
			z0ZzZzxpk2.z0uek = z0ZzZzpck2.z0gtk;
			if (!z0ZzZzpck2.z0eek(p2))
			{
				z0ZzZzxpk2.z0nek = z0ZzZzxpk2.z0eek() + z0yrk.z0tek();
				z0ZzZzxpk2.z0yek = false;
				z0ZzZzxpk2.z0zek = true;
				z0ZzZzxpk2.z0hrk = 15f;
				z0ZzZzxpk2.z0vek = Color.Red;
				z0ZzZzxpk2.z0krk = true;
				z0ZzZzpck2.z0htk = null;
				return z0ZzZzxpk2;
			}
			z0ZzZzxpk2.z0nek = z0ZzZzpck2.z0ytk;
			z0ZzZzxpk2.z0iek = z0ZzZzpck2.z0otk;
			if (p0 && !string.IsNullOrEmpty(z0ZzZzpck2.z0trk))
			{
				z0ZzZzxpk2.z0nek = z0ZzZzxpk2.z0eek() + " " + z0ZzZzpck2.z0trk;
			}
			z0ZzZzxpk2.z0yek = true;
			int z0jtk = z0ZzZzpck2.z0jtk;
			if (z0jtk < 15)
			{
				z0ZzZzxpk2.z0nek = z0ZzZzxpk2.z0eek() + string.Format(z0ark.z0tek(), z0jtk);
			}
			z0ZzZzxpk2.z0lrk = z0ZzZzpck2.z0qtk;
		}
		else
		{
			z0ZzZzxpk2.z0yek = false;
			string text = z0ZzZzkfh.z0cek.z0tek();
			z0ZzZzick z0ZzZzick3 = z0ZzZzvcj.z0rek;
			if (z0ZzZzick3 != null)
			{
				string text2 = z0ZzZzick3.z0eek();
				if (text2 != null && text2.Length > 0)
				{
					text = string.Format(z0ZzZzkfh.z0vek.z0tek(), text2);
				}
			}
			string text3 = z0ZzZzpck2.z0ork?.z0tek();
			if (text3 != null && text3.Length > 0)
			{
				text = text.Replace(z0ZzZzkfh.z0drk.z0tek(), text3);
			}
			z0ZzZzxpk2.z0nek = text;
			z0ZzZzxpk2.z0hrk = 15f;
			z0ZzZzxpk2.z0vek = Color.Red;
			z0ZzZzxpk2.z0krk = true;
		}
		z0ZzZzpck2.z0htk = z0ZzZzxpk2;
		if (z0ZzZzxpk2.z0nek is string)
		{
			z0ZzZzxpk2.z0nek = new z0ZzZzwok((string)z0ZzZzxpk2.z0nek);
		}
		return z0ZzZzxpk2;
	}

	static z0ZzZzccj()
	{
		z0cek = typeof(z0ZzZzvcj);
		z0vek = typeof(z0ZzZzxcj);
		z0qrk = 0;
		z0irk = false;
		z0grk = new z0ZzZzwok(new int[12]
		{
			1972371501, 779552028, 622100281, 2014773887, 561594146, 889472270, 1311190083, 893526837, 472533821, 1359691092,
			945690370, 1044076802
		}, p1: true);
		z0yrk = new z0ZzZzwok(new int[14]
		{
			-1209270222, 375017220, 1109082724, 1649611632, 343361046, -2129180334, -1078925931, -324486163, -1292911438, -2068452458,
			-225081356, -1225605220, -1633945184, -538785984
		});
		z0ark = new z0ZzZzwok(new int[12]
		{
			-612368340, 1662192999, 879246369, -239341293, 1965435496, 141892609, 925531705, 2049778045, 1031345683, 338380578,
			1261976131, 553003049
		}, p1: true);
		z0hrk = DateTime.MinValue;
		z0ZzZzxcj.z0tek = z0eek;
	}

	private static void z0eek()
	{
		z0iek();
	}

	private static object z0eek(bool p0, int p1)
	{
		return z0eek(p0, p1, 0);
	}

	private static object z0rek()
	{
		return null;
	}

	private static object z0tek()
	{
		return z0ZzZzpck.z0eek();
	}

	[DebuggerHidden]
	private static object z0eek(int p0, object p1)
	{
		switch (p0)
		{
		case 6:
		{
			object[] array2 = (object[])p1;
			return z0eek((bool)array2[0], (int)array2[1]);
		}
		case 5:
		{
			object[] array = (object[])p1;
			return z0eek((bool)array[0], (int)array[1], (string)array[2]);
		}
		case 1:
			return z0eek((bool)p1);
		case 0:
			return z0rek();
		case 4:
			return z0uek();
		case 7:
			return z0yek();
		case 14:
			return z0oek();
		case 15:
			return z0eek((int)p1);
		case 16:
			z0rek((bool)p1);
			break;
		case 17:
			return z0tek();
		case 20:
			z0eek((string)p1);
			break;
		case 22:
			z0eek();
			break;
		default:
			throw new NotSupportedException(p0 + " " + p1);
		case 21:
			break;
		}
		return null;
	}

	private static string z0eek(bool p0 = true)
	{
		return string.Empty;
	}

	private static bool z0yek()
	{
		return true;
	}

	internal static bool z0rek(int p0)
	{
		return true;
	}

	public static void z0eek(z0ZzZzpck p0, z0ZzZzick p1)
	{
		if (p0.z0zek)
		{
			XTextDocument.z0tck = p0.z0lrk;
		}
		XTextDocument.z0rxk = p0.z0mrk;
		if (p0.z0zek)
		{
			z0ZzZzvcj.z0tek = p0.z0tek();
		}
		string text = p0.z0mtk?.z0tek();
		if (p1 != null)
		{
			string text2 = p1.z0eek();
			if (text2 != null && text2.Length > 0)
			{
				text = text2;
			}
		}
		XTextDocument.z0pvk = ((text == null) ? null : Encoding.UTF8.GetBytes(text));
		z0ZzZzdfh.z0rek().z0qd();
	}

	private static z0ZzZzpck z0uek()
	{
		return z0ZzZzick.z0jrk.z0yek();
	}

	private static void z0eek(string p0)
	{
	}

	private static void z0rek(bool p0)
	{
		if (p0)
		{
			if (z0ZzZzvcj.z0rek == null)
			{
				z0uek();
			}
			z0ZzZzick.z0eek(z0ZzZzvcj.z0rek);
		}
		else
		{
			z0ZzZzick.z0eek(null);
		}
	}

	private static object z0eek(bool p0, int p1, string p2 = null)
	{
		return z0eek(p0, -1, p1, p2);
	}

	public static void z0iek()
	{
		z0eek(z0ZzZzick.z0jrk.z0yek(), z0ZzZzick.z0jrk);
	}

	private static bool z0oek()
	{
		z0ZzZzpck z0ZzZzpck2 = z0uek();
		if (z0ZzZzpck2 != null && z0ZzZzpck2.z0zek)
		{
			string text = z0ZzZzpck2.z0drk?.z0tek();
			if (text != null && text.Contains("联众"))
			{
				return true;
			}
		}
		return false;
	}

	private static object z0pek()
	{
		return typeof(XTextDocument);
	}
}
