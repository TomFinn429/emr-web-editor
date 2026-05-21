using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzgtj : z0ZzZzftj
{
	private readonly bool z0trk;

	private int z0yrk;

	private CultureInfo z0urk;

	private int z0irk = 720;

	private string z0ork;

	private Encoding z0prk = z0ZzZzltj.z0rik;

	private string z0mrk;

	private int z0nrk = 1800;

	private int z0brk = 1440;

	private Encoding z0vrk;

	private int z0crk = 1800;

	private int z0xrk = 1440;

	private z0ZzZzktj z0zrk = new z0ZzZzktj();

	private z0ZzZzzrj z0ltk = new z0ZzZzzrj();

	private string z0ktk;

	private z0ZzZzdyj z0jtk = new z0ZzZzdyj();

	private bool z0htk;

	private int z0gtk;

	private CultureInfo z0ftk;

	private readonly z0ZzZzztj z0dtk = new z0ZzZzztj();

	private z0ZzZzmrj z0stk;

	private Encoding z0atk;

	private readonly Stack<z0ZzZzmrj> z0qtk = new Stack<z0ZzZzmrj>();

	private int z0wtk = 12240;

	private int z0etk = 720;

	private bool z0rtk;

	private static readonly string z0ttk = z0ZzZzimk.DefaultFontName;

	private Dictionary<int, Dictionary<string, string>> z0ytk;

	private bool z0utk;

	private z0ZzZzfyj z0itk = new z0ZzZzfyj();

	private string z0otk;

	private bool z0ptk;

	private int z0mtk = 15840;

	private int z0ntk = 400;

	public void z0rek(int p0)
	{
		z0brk = p0;
	}

	public void z0tek(int p0)
	{
		z0crk = p0;
	}

	private z0ZzZzytj z0rek(z0ZzZzuyj p0, z0ZzZzmrj p1)
	{
		z0ZzZzytj z0ZzZzytj2 = new z0ZzZzytj();
		((z0ZzZzftj)z0ZzZzytj2).z0mek = p0.z0lrk();
		z0yek(z0ZzZzytj2);
		int num = p0.z0lrk();
		while (p0.z0rek() != null && p0.z0lrk() >= num)
		{
			if (p0.z0iek() != (z0ZzZzpyj)6 && p0.z0iek() != (z0ZzZzpyj)7)
			{
				if (p0.z0lrk() == ((z0ZzZzftj)z0ZzZzytj2).z0mek + 1 && p0.z0vek().StartsWith("attribute_"))
				{
					z0ZzZzytj2.z0rek()[p0.z0vek()] = z0rek(p0, p1: true);
				}
				switch (p0.z0vek())
				{
				case "objautlink":
					z0ZzZzytj2.z0rek((z0ZzZzeyj)2);
					break;
				case "objclass":
					z0ZzZzytj2.z0rek(z0rek(p0, p1: true));
					break;
				case "objdata":
				{
					string p2 = z0rek(p0, p1: true);
					z0ZzZzytj2.z0rek(z0tek(p2));
					break;
				}
				case "objemb":
					z0ZzZzytj2.z0rek((z0ZzZzeyj)0);
					break;
				case "objh":
					z0ZzZzytj2.z0rek(p0.z0xek());
					break;
				case "objhtml":
					z0ZzZzytj2.z0rek((z0ZzZzeyj)6);
					break;
				case "objicemb":
					z0ZzZzytj2.z0rek((z0ZzZzeyj)5);
					break;
				case "objlink":
					z0ZzZzytj2.z0rek((z0ZzZzeyj)1);
					break;
				case "objname":
					z0ZzZzytj2.z0tek(z0rek(p0, p1: true));
					break;
				case "objocx":
					z0ZzZzytj2.z0rek((z0ZzZzeyj)7);
					break;
				case "objpub":
					z0ZzZzytj2.z0rek((z0ZzZzeyj)4);
					break;
				case "objsub":
					z0ZzZzytj2.z0rek((z0ZzZzeyj)3);
					break;
				case "objw":
					z0ZzZzytj2.z0yek(p0.z0xek());
					break;
				case "objscalex":
					z0ZzZzytj2.z0tek(p0.z0xek());
					break;
				case "objscaley":
					z0ZzZzytj2.z0uek(p0.z0xek());
					break;
				case "result":
				{
					z0ZzZzdtj z0ZzZzdtj2 = new z0ZzZzdtj();
					z0ZzZzdtj2.z0eek("result");
					z0ZzZzytj2.z0eek(z0ZzZzdtj2);
					z0yek(p0, p1);
					z0ZzZzdtj2.z0eek(p0: true);
					break;
				}
				}
			}
		}
		z0ZzZzytj2.z0eek(p0: true);
		return z0ZzZzytj2;
	}

	private new void z0rek()
	{
	}

	public void z0yek(int p0)
	{
		z0nrk = p0;
	}

	private bool z0rek(z0ZzZziyj p0, z0ZzZzuyj p1, z0ZzZzmrj p2)
	{
		if (p0.z0tek())
		{
			string p3 = p0.z0uek();
			p0.z0eek();
			z0ZzZzrtj z0ZzZzrtj2 = (z0ZzZzrtj)z0rek(typeof(z0ZzZzrtj));
			if (z0ZzZzrtj2 != null && !((z0ZzZzftj)z0ZzZzrtj2).z0oek())
			{
				z0ZzZzrtj2.z0eek(z0tek(p3));
				z0ZzZzrtj2.z0eek(p2.z0yrk());
				z0ZzZzrtj2.z0yek(z0ZzZzrtj2.z0yek() * z0ZzZzrtj2.z0eek() / 100);
				z0ZzZzrtj2.z0rek(z0ZzZzrtj2.z0pek() * z0ZzZzrtj2.z0tek() / 100);
				z0ZzZzrtj2.z0eek(p0: true);
				if (p1.z0iek() != (z0ZzZzpyj)7)
				{
					z0nek_jiejie20260327142557(p1);
				}
				return true;
			}
			if (p2.z0atk && z0rtk)
			{
				z0ZzZzctj z0ZzZzctj2 = new z0ZzZzctj();
				z0ZzZzctj2.z0mek = p0.z0rek();
				z0ZzZzctj2.z0eek(p2.z0yrk());
				if (z0ZzZzctj2.z0eek().z0nrk_jiejie20260327142557() == (z0ZzZzvrj)3)
				{
					z0ZzZzctj2.z0eek().z0eek((z0ZzZzvrj)0);
				}
				z0ZzZzctj2.z0eek(p3);
				z0yek(z0ZzZzctj2);
			}
		}
		return false;
	}

	public new string z0tek()
	{
		return z0ktk;
	}

	private string z0rek(z0ZzZzuyj p0, z0ZzZzoyj p1, bool p2, bool p3, bool p4)
	{
		int num = 0;
		z0ZzZziyj z0ZzZziyj2 = new z0ZzZziyj(this);
		z0ZzZziyj2.z0eek(p1, p0);
		while (true)
		{
			z0ZzZzpyj z0ZzZzpyj2 = p0.z0pek();
			if (z0ZzZzpyj2 == (z0ZzZzpyj)5)
			{
				break;
			}
			if (z0ZzZzpyj2 == (z0ZzZzpyj)6)
			{
				num++;
			}
			else if (z0ZzZzpyj2 == (z0ZzZzpyj)7)
			{
				num--;
				if (num < 0)
				{
					break;
				}
			}
			p0.z0rek();
			if (p2 || num == 0)
			{
				if (p4 && p0.z0vek() == "par")
				{
					z0ZzZziyj2.z0eek(Environment.NewLine);
				}
				else if (!z0ZzZziyj2.z0eek(p0.z0cek(), p0) && p3)
				{
					break;
				}
			}
		}
		return z0ZzZziyj2.z0uek();
	}

	public int z0yek()
	{
		return z0ntk;
	}

	private void z0rek(z0ZzZzuyj p0)
	{
		z0jtk = new z0ZzZzdyj();
		while (p0.z0rek() != null && p0.z0iek() != (z0ZzZzpyj)7)
		{
			if (p0.z0iek() != (z0ZzZzpyj)6)
			{
				continue;
			}
			bool flag = true;
			z0ZzZzjyj z0ZzZzjyj2 = null;
			z0ZzZzhyj z0ZzZzhyj2 = null;
			int num = p0.z0lrk();
			while (p0.z0rek() != null)
			{
				if (p0.z0iek() == (z0ZzZzpyj)7)
				{
					if (p0.z0lrk() < num)
					{
						break;
					}
				}
				else
				{
					p0.z0iek();
					_ = 6;
				}
				if (flag)
				{
					if (p0.z0cek().z0rek() != "list")
					{
						z0nek_jiejie20260327142557(p0);
						p0.z0rek();
						break;
					}
					z0ZzZzjyj2 = new z0ZzZzjyj();
					z0jtk.Add(z0ZzZzjyj2);
					flag = false;
				}
				switch (p0.z0cek().z0rek())
				{
				case "listlevel":
					z0ZzZzhyj2 = new z0ZzZzhyj();
					z0ZzZzjyj2.z0tek().Add(z0ZzZzhyj2);
					break;
				case "listtemplateid":
					z0ZzZzjyj2.z0rek(p0.z0cek().z0eek());
					break;
				case "listid":
					z0ZzZzjyj2.z0tek(p0.z0cek().z0eek());
					break;
				case "listhybrid":
					z0ZzZzjyj2.z0rek(p0: true);
					break;
				case "levelfollow":
					z0ZzZzhyj2.z0tek(p0.z0cek().z0eek());
					break;
				case "levelstartat":
					z0ZzZzhyj2.z0rek(p0.z0cek().z0eek());
					break;
				case "levelnfc":
					if (z0ZzZzhyj2.z0eek() == (z0ZzZzbrj)(-10))
					{
						z0ZzZzhyj2.z0eek((z0ZzZzbrj)p0.z0cek().z0eek());
					}
					break;
				case "levelnfcn":
					if (z0ZzZzhyj2.z0eek() == (z0ZzZzbrj)(-10))
					{
						z0ZzZzhyj2.z0eek((z0ZzZzbrj)p0.z0cek().z0eek());
					}
					break;
				case "leveljc":
					z0ZzZzhyj2.z0eek(p0.z0cek().z0eek());
					break;
				case "leveltext":
					if (string.IsNullOrEmpty(z0ZzZzhyj2.z0iek()))
					{
						string text = z0rek(p0, p1: true);
						if (text != null && text.Length > 2)
						{
							int num2 = text[0];
							num2 = Math.Min(num2, text.Length - 1);
							text = text.Substring(1, num2);
						}
						z0ZzZzhyj2.z0rek(text);
					}
					break;
				case "levelnumbers":
					if (string.IsNullOrEmpty(z0ZzZzhyj2.z0oek()))
					{
						string p1 = z0rek(p0, p1: true);
						z0ZzZzhyj2.z0tek(p1);
					}
					break;
				case "f":
					z0ZzZzhyj2.z0eek(z0bek().z0eek(p0.z0cek().z0eek()));
					break;
				}
			}
		}
	}

	public new int z0uek()
	{
		return z0mtk;
	}

	public void z0uek(int p0)
	{
		z0mtk = p0;
	}

	public void z0rek(z0ZzZzdyj p0)
	{
		z0jtk = p0;
	}

	public void z0rek(z0ZzZzftj p0)
	{
		z0ZzZzitj z0ZzZzitj2 = null;
		z0ZzZzstj z0ZzZzstj2 = new z0ZzZzstj();
		foreach (z0ZzZzftj item in p0.z0uek())
		{
			if (item is z0ZzZzetj || item is z0ZzZzwtj)
			{
				z0rek(item);
				z0ZzZzitj2 = null;
				z0ZzZzstj2.Add(item);
				continue;
			}
			if (item is z0ZzZzitj || item is z0ZzZzvtj || item is z0ZzZzmtj || item is z0ZzZzntj)
			{
				z0ZzZzitj2 = null;
				z0ZzZzstj2.Add(item);
				continue;
			}
			if (z0ZzZzitj2 == null)
			{
				z0ZzZzitj2 = new z0ZzZzitj();
				z0ZzZzstj2.Add(z0ZzZzitj2);
				if (item is z0ZzZzctj)
				{
					z0ZzZzitj2.z0eek(((z0ZzZzctj)item).z0eek().z0yrk());
				}
			}
			z0ZzZzitj2.z0uek().Add(item);
		}
		p0.z0uek().Clear();
		foreach (z0ZzZzftj item2 in z0ZzZzstj2)
		{
			p0.z0uek().Add(item2);
		}
	}

	public void z0rek(z0ZzZzfyj p0)
	{
		z0itk = p0;
	}

	public void z0rek(TextReader p0)
	{
		z0ktk = null;
		base.z0uek().Clear();
		z0rtk = false;
		z0ZzZzuyj p1 = new z0ZzZzuyj(p0);
		z0ZzZzmrj p2 = new z0ZzZzmrj();
		z0stk = null;
		z0yek(p1, p2);
		z0uek(this);
		z0tek(this);
		z0rek();
		base.z0tek();
	}

	public new z0ZzZzktj z0iek()
	{
		return z0zrk;
	}

	private z0ZzZzftj[] z0rek(bool p0)
	{
		List<z0ZzZzftj> list = new List<z0ZzZzftj>();
		z0ZzZzftj z0ZzZzftj2 = this;
		while (z0ZzZzftj2 != null && (!p0 || !z0ZzZzftj2.z0oek()))
		{
			list.Add(z0ZzZzftj2);
			z0ZzZzftj2 = z0ZzZzftj2.z0uek().z0eek();
		}
		if (p0)
		{
			for (int num = list.Count - 1; num >= 0; num--)
			{
				if (list[num].z0oek())
				{
					list.RemoveAt(num);
				}
			}
		}
		if (list.Count == 0)
		{
			z0eek(p0: false);
			list.Add(this);
		}
		return list.ToArray();
	}

	public new string z0oek()
	{
		return z0mrk;
	}

	public string z0pek()
	{
		return z0otk;
	}

	public void z0iek(int p0)
	{
		z0irk = p0;
	}

	public new bool z0mek()
	{
		return z0ptk;
	}

	public string z0nek_jiejie20260327142557()
	{
		return z0ork;
	}

	private void z0rek(z0ZzZzmtj p0, bool p1)
	{
		int num = 0;
		bool flag = false;
		ArrayList arrayList = new ArrayList();
		int num2 = 0;
		for (int num3 = p0.z0uek().Count - 1; num3 >= 0; num3--)
		{
			if (((z0ZzZzftj)(z0ZzZzvtj)p0.z0uek()[num3]).z0uek().Count == 0)
			{
				p0.z0uek().RemoveAt(num3);
			}
		}
		foreach (z0ZzZzvtj item in p0.z0uek())
		{
			int num4 = 0;
			num = Math.Max(num, ((z0ZzZzftj)item).z0uek().Count);
			if (item.z0eek("irow"))
			{
				item.z0eek(((z0ZzZzftj)item).z0rek().z0rek("irow"));
			}
			item.z0rek(item.z0eek("lastrow"));
			item.z0eek(item.z0eek("trhdr"));
			if (item.z0eek("trrh"))
			{
				item.z0tek(((z0ZzZzftj)item).z0rek().z0rek("trrh"));
				if (item.z0oek() == 0)
				{
					item.z0tek(z0yek());
				}
				else if (item.z0oek() < 0)
				{
					item.z0tek(-item.z0oek());
				}
			}
			else
			{
				item.z0tek(z0yek());
			}
			if (item.z0eek("trpaddl"))
			{
				item.z0iek(((z0ZzZzftj)item).z0rek().z0rek("trpaddl"));
			}
			else
			{
				item.z0iek(-2147483648);
			}
			if (item.z0eek("trpaddt"))
			{
				item.z0rek(((z0ZzZzftj)item).z0rek().z0rek("trpaddt"));
			}
			else
			{
				item.z0rek(-2147483648);
			}
			if (item.z0eek("trpaddr"))
			{
				item.z0pek(((z0ZzZzftj)item).z0rek().z0rek("trpaddr"));
			}
			else
			{
				item.z0pek(-2147483648);
			}
			if (item.z0eek("trpaddb"))
			{
				item.z0uek(((z0ZzZzftj)item).z0rek().z0rek("trpaddb"));
			}
			else
			{
				item.z0uek(-2147483648);
			}
			if (item.z0eek("trleft"))
			{
				num2 = ((z0ZzZzftj)item).z0rek().z0rek("trleft");
			}
			if (item.z0eek("trcbpat"))
			{
				item.z0yek().z0eek(z0wrk().z0eek(((z0ZzZzftj)item).z0rek().z0rek("trcbpat"), Color.Transparent));
			}
			int num5 = 0;
			foreach (z0ZzZzntj item2 in ((z0ZzZzftj)item).z0uek())
			{
				if (item2.z0eek("clvmgf"))
				{
					flag = true;
				}
				if (item2.z0eek("clvmrg"))
				{
					flag = true;
				}
				if (item2.z0eek("clpadl"))
				{
					item2.z0uek(((z0ZzZzftj)item2).z0rek().z0rek("clpadl"));
				}
				else
				{
					item2.z0uek(-2147483648);
				}
				if (item2.z0eek("clpadr"))
				{
					item2.z0pek(((z0ZzZzftj)item2).z0rek().z0rek("clpadr"));
				}
				else
				{
					item2.z0pek(-2147483648);
				}
				if (item2.z0eek("clpadt"))
				{
					item2.z0iek(((z0ZzZzftj)item2).z0rek().z0rek("clpadt"));
				}
				else
				{
					item2.z0iek(-2147483648);
				}
				if (item2.z0eek("clpadb"))
				{
					item2.z0eek(((z0ZzZzftj)item2).z0rek().z0rek("clpadb"));
				}
				else
				{
					item2.z0eek(-2147483648);
				}
				item2.z0tek().z0xek(item2.z0eek("clbrdrl"));
				item2.z0tek().z0yek(item2.z0eek("clbrdrt"));
				item2.z0tek().z0nek(item2.z0eek("clbrdrr"));
				item2.z0tek().z0lrk(item2.z0eek("clbrdrb"));
				if (item2.z0eek("brdrcf"))
				{
					item2.z0tek().z0rek(z0wrk().z0eek(item2.z0eek("brdrcf", 1), Color.Black));
				}
				for (int num6 = ((z0ZzZzftj)item2).z0rek().Count - 1; num6 >= 0; num6--)
				{
					switch (((z0ZzZzftj)item2).z0rek().z0eek(num6).z0eek())
					{
					case "brdrtbl":
					case "brdrnone":
					case "brdrnil":
					{
						for (int num7 = num6 - 1; num7 >= 0; num7--)
						{
							switch (((z0ZzZzftj)item2).z0rek().z0eek(num7).z0eek())
							{
							case "clbrdrl":
								item2.z0tek().z0xek(p0: false);
								break;
							case "clbrdrt":
								item2.z0tek().z0yek(p0: false);
								break;
							case "clbrdrr":
								item2.z0tek().z0nek(p0: false);
								break;
							case "clbrdrb":
								item2.z0tek().z0lrk(p0: false);
								break;
							default:
								continue;
							}
							break;
						}
						break;
					}
					}
				}
				if (item2.z0eek("clvertalt"))
				{
					item2.z0eek((z0ZzZznyj)0);
				}
				else if (item2.z0eek("clvertalc"))
				{
					item2.z0eek((z0ZzZznyj)1);
				}
				else if (item2.z0eek("clvertalb"))
				{
					item2.z0eek((z0ZzZznyj)2);
				}
				if (item2.z0eek("clcbpat"))
				{
					item2.z0tek().z0eek(z0wrk().z0eek(((z0ZzZzftj)item2).z0rek().z0rek("clcbpat"), Color.Transparent));
				}
				else
				{
					item2.z0tek().z0eek(Color.Transparent);
				}
				if (item2.z0eek("clcfpat"))
				{
					item2.z0tek().z0rek(z0wrk().z0eek(((z0ZzZzftj)item2).z0rek().z0rek("clcfpat"), Color.Black));
				}
				int num8 = 2763;
				if (item2.z0eek("cellx"))
				{
					num8 = ((z0ZzZzftj)item2).z0rek().z0rek("cellx") - num4;
					if (num8 < 100)
					{
						num8 = 100;
					}
				}
				int num9 = num4 + num8;
				for (int i = 0; i < arrayList.Count; i++)
				{
					if (Math.Abs(num9 - (int)arrayList[i]) < 45)
					{
						num9 = (int)arrayList[i];
						num8 = num9 - num4;
						break;
					}
				}
				item2.z0tek(num4);
				item2.z0yek(num8);
				item2.z0eek("cellx");
				num5 += num8;
				if (!arrayList.Contains(num9))
				{
					arrayList.Add(num9);
				}
				num4 += num8;
			}
			item.z0yek(num5);
		}
		if (arrayList.Count == 0)
		{
			int num10 = 1;
			foreach (z0ZzZzvtj item3 in p0.z0uek())
			{
				num10 = Math.Max(num10, ((z0ZzZzftj)item3).z0uek().Count);
			}
			int num11 = z0zek() / num10;
			for (int j = 0; j < num10; j++)
			{
				arrayList.Add(j * num11 + num11);
			}
		}
		arrayList.Add(0);
		arrayList.Sort();
		for (int k = 1; k < arrayList.Count; k++)
		{
			z0ZzZzbtj z0ZzZzbtj2 = new z0ZzZzbtj();
			z0ZzZzbtj2.z0eek((int)arrayList[k] - (int)arrayList[k - 1]);
			p0.z0eek().Add(z0ZzZzbtj2);
		}
		for (int l = 1; l < p0.z0uek().Count; l++)
		{
			z0ZzZzvtj z0ZzZzvtj4 = (z0ZzZzvtj)p0.z0uek()[l];
			for (int m = 0; m < ((z0ZzZzftj)z0ZzZzvtj4).z0uek().Count; m++)
			{
				z0ZzZzntj z0ZzZzntj3 = (z0ZzZzntj)((z0ZzZzftj)z0ZzZzvtj4).z0uek()[m];
				if (z0ZzZzntj3.z0cek() == 0)
				{
					z0ZzZzvtj z0ZzZzvtj5 = (z0ZzZzvtj)p0.z0uek()[l - 1];
					if (((z0ZzZzftj)z0ZzZzvtj5).z0uek().Count > m)
					{
						z0ZzZzntj z0ZzZzntj4 = (z0ZzZzntj)((z0ZzZzftj)z0ZzZzvtj5).z0uek()[m];
						z0ZzZzntj3.z0tek(z0ZzZzntj4.z0nek());
						z0ZzZzntj3.z0yek(z0ZzZzntj4.z0cek());
						z0rek(z0ZzZzntj3, ((z0ZzZzftj)z0ZzZzntj4).z0rek());
					}
				}
			}
		}
		if (!flag)
		{
			foreach (z0ZzZzvtj item4 in p0.z0uek())
			{
				if (((z0ZzZzftj)item4).z0uek().Count < p0.z0eek().Count)
				{
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			foreach (z0ZzZzvtj item5 in p0.z0uek())
			{
				if (((z0ZzZzftj)item5).z0uek().Count == p0.z0eek().Count)
				{
					continue;
				}
				z0ZzZzftj[] array = ((z0ZzZzftj)item5).z0uek().ToArray();
				for (int n = 0; n < array.Length; n++)
				{
					z0ZzZzntj z0ZzZzntj5 = (z0ZzZzntj)array[n];
					int num12 = arrayList.IndexOf(z0ZzZzntj5.z0nek());
					int num13 = arrayList.IndexOf(z0ZzZzntj5.z0nek() + z0ZzZzntj5.z0cek()) - num12;
					bool flag2 = z0ZzZzntj5.z0eek("clvmrg");
					if (!flag2)
					{
						z0ZzZzntj5.z0oek(num13);
					}
					if (((z0ZzZzftj)item5).z0uek().z0eek() == z0ZzZzntj5)
					{
						z0ZzZzntj5.z0oek(p0.z0eek().Count - ((z0ZzZzftj)item5).z0uek().Count + 1);
						num13 = z0ZzZzntj5.z0iek();
					}
					for (int num14 = 0; num14 < num13 - 1; num14++)
					{
						z0ZzZzntj z0ZzZzntj6 = new z0ZzZzntj();
						z0ZzZzntj6.z0eek(((z0ZzZzftj)z0ZzZzntj5).z0rek().z0eek());
						((z0ZzZzftj)item5).z0uek().Insert(((z0ZzZzftj)item5).z0uek().IndexOf(z0ZzZzntj5) + 1, z0ZzZzntj6);
						if (flag2)
						{
							((z0ZzZzftj)z0ZzZzntj6).z0rek().z0rek("clvmrg", 1);
							z0ZzZzntj6.z0eek(z0ZzZzntj5);
						}
					}
				}
				if (((z0ZzZzftj)item5).z0uek().Count != p0.z0eek().Count)
				{
					z0ZzZzntj z0ZzZzntj7 = (z0ZzZzntj)((z0ZzZzftj)item5).z0uek().z0eek();
					for (int num15 = ((z0ZzZzftj)item5).z0uek().Count; num15 < arrayList.Count; num15++)
					{
						z0ZzZzntj z0ZzZzntj8 = new z0ZzZzntj();
						z0rek(z0ZzZzntj8, ((z0ZzZzftj)z0ZzZzntj7).z0rek());
						((z0ZzZzftj)item5).z0uek().Add(z0ZzZzntj8);
					}
				}
			}
			foreach (z0ZzZzvtj item6 in p0.z0uek())
			{
				foreach (z0ZzZzntj item7 in ((z0ZzZzftj)item6).z0uek())
				{
					if (!item7.z0eek("clvmgf"))
					{
						continue;
					}
					int num16 = ((z0ZzZzftj)item6).z0uek().IndexOf(item7);
					for (int num17 = p0.z0uek().IndexOf(item6) + 1; num17 < p0.z0uek().Count; num17++)
					{
						z0ZzZzntj z0ZzZzntj10 = (z0ZzZzntj)((z0ZzZzftj)(z0ZzZzvtj)p0.z0uek()[num17]).z0uek()[num16];
						if (!z0ZzZzntj10.z0eek("clvmrg") || z0ZzZzntj10.z0bek() != null)
						{
							break;
						}
						int n = item7.z0mek();
						item7.z0rek(n + 1);
						z0ZzZzntj10.z0eek(item7);
					}
				}
			}
			foreach (z0ZzZzvtj item8 in p0.z0uek())
			{
				foreach (z0ZzZzntj item9 in ((z0ZzZzftj)item8).z0uek())
				{
					if (item9.z0mek() <= 1 && item9.z0iek() <= 1)
					{
						continue;
					}
					for (int num18 = 1; num18 <= item9.z0mek(); num18++)
					{
						for (int num19 = 1; num19 <= item9.z0iek(); num19++)
						{
							int num20 = p0.z0uek().IndexOf(item8) + num18 - 1;
							int num21 = ((z0ZzZzftj)item8).z0uek().IndexOf(item9) + num19 - 1;
							z0ZzZzntj z0ZzZzntj12 = (z0ZzZzntj)p0.z0uek()[num20].z0uek()[num21];
							if (item9 != z0ZzZzntj12)
							{
								z0ZzZzntj12.z0eek(item9);
							}
						}
					}
				}
			}
		}
		if (p1 && p0.z0eek().Count > 0)
		{
			z0ZzZzbtj obj = (z0ZzZzbtj)p0.z0eek()[0];
			obj.z0eek(obj.z0eek() - num2);
		}
	}

	private CultureInfo z0oek(int p0)
	{
		if (p0 == 1024 || p0 == 1033)
		{
			return CultureInfo.CurrentCulture;
		}
		try
		{
			return new CultureInfo(p0);
		}
		catch (Exception ex)
		{
			z0ZzZzqok.z0rek.z0dh(ex.Message);
			return CultureInfo.CurrentCulture;
		}
	}

	public z0ZzZzztj z0bek()
	{
		return z0dtk;
	}

	private void z0tek(z0ZzZzftj p0)
	{
		ArrayList arrayList = new ArrayList();
		foreach (z0ZzZzftj item in p0.z0uek())
		{
			if (item is z0ZzZzitj)
			{
				z0ZzZzitj z0ZzZzitj2 = (z0ZzZzitj)item;
				if (z0ZzZzitj2.z0tek().z0xrk())
				{
					z0ZzZzitj2.z0tek().z0vek(p0: false);
					arrayList.Add(new z0ZzZzutj());
				}
			}
			if (item is z0ZzZzctj)
			{
				if (arrayList.Count > 0 && arrayList[arrayList.Count - 1] is z0ZzZzctj)
				{
					z0ZzZzctj z0ZzZzctj2 = (z0ZzZzctj)arrayList[arrayList.Count - 1];
					z0ZzZzctj z0ZzZzctj3 = (z0ZzZzctj)item;
					if (z0ZzZzctj2.z0rek().Length == 0 || z0ZzZzctj3.z0rek().Length == 0)
					{
						if (z0ZzZzctj2.z0rek().Length == 0)
						{
							z0ZzZzctj2.z0eek(z0ZzZzctj3.z0eek().z0yrk());
						}
						z0ZzZzctj2.z0eek(z0ZzZzctj2.z0rek() + z0ZzZzctj3.z0rek());
					}
					else if (z0ZzZzctj2.z0eek().z0eek(z0ZzZzctj3.z0eek()))
					{
						z0ZzZzctj2.z0eek(z0ZzZzctj2.z0rek() + z0ZzZzctj3.z0rek());
					}
					else
					{
						arrayList.Add(z0ZzZzctj3);
					}
				}
				else
				{
					arrayList.Add(item);
				}
			}
			else
			{
				arrayList.Add(item);
			}
		}
		p0.z0uek().Clear();
		p0.z0eek(p0: false);
		foreach (z0ZzZzftj item2 in arrayList)
		{
			p0.z0eek(item2);
		}
		z0ZzZzftj[] array = p0.z0uek().ToArray();
		foreach (z0ZzZzftj z0ZzZzftj2 in array)
		{
			if (z0ZzZzftj2 is z0ZzZzmtj)
			{
				z0rek((z0ZzZzmtj)z0ZzZzftj2, p1: true);
			}
		}
		if (base.z0uek().Count > 1 && base.z0uek()[0] is z0ZzZzitj)
		{
			z0ZzZzitj z0ZzZzitj3 = (z0ZzZzitj)base.z0uek()[0];
			if (z0ZzZzitj3.z0eek())
			{
				z0ZzZzitj3.z0rek(p0: false);
				if (base.z0uek().z0eek() is z0ZzZzitj)
				{
					((z0ZzZzitj)base.z0uek().z0eek()).z0rek(p0: true);
				}
			}
		}
		foreach (z0ZzZzftj item3 in p0.z0uek())
		{
			z0tek(item3);
		}
	}

	public void z0tek(bool p0)
	{
		z0utk = p0;
	}

	internal Encoding z0vek()
	{
		if (z0ftk != null)
		{
			return z0ZzZzqik.z0eek(z0ftk.TextInfo.ANSICodePage);
		}
		if (z0urk != null)
		{
			return z0ZzZzqik.z0eek(z0urk.TextInfo.ANSICodePage);
		}
		if (z0vrk != null)
		{
			return z0vrk;
		}
		if (z0atk != null)
		{
			return z0atk;
		}
		return z0prk;
	}

	public void z0rek(z0ZzZzktj p0)
	{
		z0zrk = p0;
	}

	public int z0cek()
	{
		return z0irk;
	}

	public int z0xek()
	{
		return z0xrk;
	}

	public z0ZzZzftj z0rek(Type p0)
	{
		z0ZzZzftj[] array = z0rek(p0: true);
		for (int num = array.Length - 1; num >= 0; num--)
		{
			if (p0.IsInstanceOfType(array[num]))
			{
				return array[num];
			}
		}
		return null;
	}

	private void z0yek(z0ZzZzftj p0)
	{
		z0ZzZzftj[] array = z0rek(p0: true);
		_ = array.LongLength;
		z0ZzZzftj z0ZzZzftj2 = null;
		if (array.Length != 0)
		{
			z0ZzZzftj2 = array[array.Length - 1];
		}
		if ((z0ZzZzftj2 is z0ZzZzgtj || z0ZzZzftj2 is z0ZzZzetj || z0ZzZzftj2 is z0ZzZzwtj) && (p0 is z0ZzZzctj || p0 is z0ZzZzrtj || p0 is z0ZzZzytj || p0 is z0ZzZzotj || p0 is z0ZzZzptj))
		{
			if (z0trk)
			{
				z0ZzZzftj2.z0eek(p0);
				return;
			}
			z0ZzZzitj z0ZzZzitj2 = new z0ZzZzitj();
			if (z0ZzZzftj2.z0uek().Count > 0)
			{
				z0ZzZzitj2.z0rek(p0: true);
			}
			else if (z0ZzZzftj2 is z0ZzZzgtj && z0ZzZzftj2.z0uek().Count == 0)
			{
				z0ZzZzitj2.z0rek(p0: true);
			}
			if (z0stk != null)
			{
				z0ZzZzitj2.z0eek(z0stk);
			}
			z0ZzZzftj2.z0eek(z0ZzZzitj2);
			z0ZzZzitj2.z0uek().Add(p0);
			return;
		}
		_ = array.LongLength;
		z0ZzZzftj z0ZzZzftj3 = array[array.Length - 1];
		if (p0 != null && p0.z0mek > 0)
		{
			for (int num = array.Length - 1; num >= 0; num--)
			{
				if (array[num].z0mek == p0.z0mek)
				{
					for (int i = num; i < array.Length; i++)
					{
						z0ZzZzftj z0ZzZzftj4 = array[i];
						if ((!(p0 is z0ZzZzctj) && !(p0 is z0ZzZzrtj) && !(p0 is z0ZzZzytj) && !(p0 is z0ZzZzotj) && !(p0 is z0ZzZzptj) && !(p0 is z0ZzZzatj) && !(p0 is z0ZzZzhtj) && !(p0 is z0ZzZzttj)) || p0.z0mek != z0ZzZzftj4.z0mek || (!(z0ZzZzftj4 is z0ZzZzvtj) && !(z0ZzZzftj4 is z0ZzZzntj) && !(z0ZzZzftj4 is z0ZzZzatj) && !(z0ZzZzftj4 is z0ZzZzitj)))
						{
							array[i].z0eek(p0: true);
						}
					}
					break;
				}
			}
		}
		for (int num2 = array.Length - 1; num2 >= 0; num2--)
		{
			if (!array[num2].z0oek())
			{
				z0ZzZzftj3 = array[num2];
				if (!(z0ZzZzftj3 is z0ZzZzrtj))
				{
					break;
				}
				z0ZzZzftj3.z0eek(p0: true);
			}
		}
		if (z0ZzZzftj3 is z0ZzZzvtj)
		{
			z0ZzZzntj z0ZzZzntj2 = new z0ZzZzntj();
			((z0ZzZzftj)z0ZzZzntj2).z0mek = z0ZzZzftj3.z0mek;
			z0ZzZzftj3.z0eek(z0ZzZzntj2);
			if (p0 is z0ZzZzvtj)
			{
				((z0ZzZzftj)z0ZzZzntj2).z0uek().Add(p0);
				return;
			}
			z0ZzZzitj z0ZzZzitj3 = new z0ZzZzitj();
			z0ZzZzitj3.z0eek(z0stk.z0yrk());
			z0ZzZzitj3.z0mek = ((z0ZzZzftj)z0ZzZzntj2).z0mek;
			z0ZzZzntj2.z0eek(z0ZzZzitj3);
			if (p0 != null)
			{
				z0ZzZzitj3.z0eek(p0);
			}
		}
		else if (p0 != null)
		{
			if (z0ZzZzftj3 is z0ZzZzitj && (p0 is z0ZzZzitj || p0 is z0ZzZzvtj))
			{
				z0ZzZzftj3.z0eek(p0: true);
				z0ZzZzftj3.z0eek().z0eek(p0);
			}
			else
			{
				z0ZzZzftj3.z0eek(p0);
			}
		}
	}

	private void z0tek(z0ZzZzuyj p0)
	{
		z0dtk.z0rek();
		while (p0.z0rek() != null)
		{
			if (p0.z0iek() == (z0ZzZzpyj)1 && p0.z0vek() == "f" && p0.z0uek())
			{
				int num = -1;
				string text = null;
				int p1 = 1;
				bool p2 = false;
				p0.z0ark = true;
				while (p0.z0rek() != null && p0.z0iek() != (z0ZzZzpyj)7 && p0.z0iek() != (z0ZzZzpyj)7)
				{
					if (p0.z0iek() == (z0ZzZzpyj)6)
					{
						p0.z0rek();
						z0nek_jiejie20260327142557(p0);
						p0.z0rek();
					}
					else if (p0.z0vek() == "f" && p0.z0uek())
					{
						if (num >= 0)
						{
							z0rek(num, text, p1, p2);
						}
						num = p0.z0xek();
					}
					else if (p0.z0vek() == "fnil")
					{
						text = z0ZzZzimk.DefaultFontName;
						p2 = true;
					}
					else if (p0.z0vek() == "fcharset")
					{
						p1 = p0.z0xek();
					}
					else
					{
						if (!p0.z0cek().z0yek())
						{
							continue;
						}
						text = z0rek(p0, p0.z0cek(), p2: false, p3: true, p4: false);
						if (text != null)
						{
							text = text.Trim();
							if (text.EndsWith(";"))
							{
								text = text.Substring(0, text.Length - 1);
							}
						}
						if (p0.z0iek() == (z0ZzZzpyj)1)
						{
							p0.z0ark = true;
						}
					}
				}
				z0rek(num, text, p1, p2);
				break;
			}
			if (p0.z0iek() == (z0ZzZzpyj)7)
			{
				break;
			}
			if (p0.z0iek() != (z0ZzZzpyj)6)
			{
				continue;
			}
			int p3 = -1;
			string text2 = null;
			int p4 = 1;
			bool p5 = false;
			while (p0.z0rek() != null && p0.z0iek() != (z0ZzZzpyj)7)
			{
				if (p0.z0iek() == (z0ZzZzpyj)6)
				{
					p0.z0rek();
					z0nek_jiejie20260327142557(p0);
					p0.z0rek();
				}
				else if (p0.z0vek() == "f" && p0.z0uek())
				{
					p3 = p0.z0xek();
				}
				else if (p0.z0vek() == "fnil")
				{
					text2 = z0ZzZzimk.DefaultFontName;
					p5 = true;
				}
				else if (p0.z0vek() == "fcharset")
				{
					p4 = p0.z0xek();
				}
				else
				{
					if (!p0.z0cek().z0yek())
					{
						continue;
					}
					text2 = z0rek(p0, p0.z0cek(), p2: false, p3: false, p4: false);
					if (text2 != null)
					{
						text2 = text2.Trim();
						if (text2.EndsWith(";"))
						{
							text2 = text2.Substring(0, text2.Length - 1);
						}
					}
				}
			}
			if (text2 != null && text2.Length >= 4)
			{
				bool flag = true;
				for (int i = 0; i < text2.Length - 1; i++)
				{
					if (!char.IsWhiteSpace(text2[i]))
					{
						if (text2[i] != text2[i + 1])
						{
							flag = false;
							break;
						}
						i++;
					}
				}
				if (flag)
				{
					StringBuilder stringBuilder = new StringBuilder();
					for (int j = 0; j < text2.Length; j++)
					{
						stringBuilder.Append(text2[j]);
						if (!char.IsWhiteSpace(text2[j]))
						{
							j++;
						}
					}
					text2 = stringBuilder.ToString();
				}
			}
			z0rek(p3, text2, p4, p5);
		}
	}

	private void z0yek(z0ZzZzuyj p0)
	{
		z0zrk.z0eek();
		int num = 0;
		while (p0.z0rek() != null)
		{
			if (p0.z0iek() == (z0ZzZzpyj)6)
			{
				num++;
				continue;
			}
			if (p0.z0iek() == (z0ZzZzpyj)7)
			{
				num--;
				if (num >= 0)
				{
					continue;
				}
				break;
			}
			switch (p0.z0vek())
			{
			case "creatim":
				z0zrk.z0tek(z0mek(p0));
				num--;
				continue;
			case "revtim":
				z0zrk.z0yek(z0mek(p0));
				num--;
				continue;
			case "printim":
				z0zrk.z0rek(z0mek(p0));
				num--;
				continue;
			case "buptim":
				z0zrk.z0eek(z0mek(p0));
				num--;
				continue;
			}
			if (p0.z0vek() != null)
			{
				if (p0.z0uek())
				{
					z0zrk.z0eek(p0.z0vek(), p0.z0xek().ToString());
				}
				else
				{
					z0zrk.z0eek(p0.z0vek(), z0rek(p0, p1: true));
				}
			}
		}
	}

	private void z0uek(z0ZzZzuyj p0)
	{
		z0itk = new z0ZzZzfyj();
		while (p0.z0rek() != null && p0.z0iek() != (z0ZzZzpyj)7)
		{
			if (p0.z0iek() != (z0ZzZzpyj)6)
			{
				continue;
			}
			int num = p0.z0lrk();
			z0ZzZzgyj z0ZzZzgyj2 = null;
			while (p0.z0rek() != null && (p0.z0iek() != (z0ZzZzpyj)7 || p0.z0lrk() >= num))
			{
				if (p0.z0cek().z0rek() == "listoverride")
				{
					z0ZzZzgyj2 = new z0ZzZzgyj();
					z0itk.Add(z0ZzZzgyj2);
				}
				else if (z0ZzZzgyj2 != null)
				{
					switch (p0.z0cek().z0rek())
					{
					case "listid":
						z0ZzZzgyj2.z0tek(p0.z0cek().z0eek());
						break;
					case "listoverridecount":
						z0ZzZzgyj2.z0eek(p0.z0cek().z0eek());
						break;
					case "ls":
						z0ZzZzgyj2.z0rek_jiejie20260327142557(p0.z0cek().z0eek());
						break;
					case "lfolevel":
						p0.z0krk();
						break;
					}
				}
			}
		}
	}

	public void z0rek(string p0)
	{
		z0mrk = p0;
	}

	private z0ZzZzmtj z0rek(ArrayList p0)
	{
		if (p0.Count > 0)
		{
			z0ZzZzmtj z0ZzZzmtj2 = new z0ZzZzmtj();
			int num = 0;
			foreach (z0ZzZzvtj item in p0)
			{
				item.z0eek(num);
				num++;
				z0ZzZzmtj2.z0eek(item);
			}
			p0.Clear();
			{
				foreach (z0ZzZzvtj item2 in z0ZzZzmtj2.z0uek())
				{
					foreach (z0ZzZzntj item3 in ((z0ZzZzftj)item2).z0uek())
					{
						z0uek(item3);
					}
				}
				return z0ZzZzmtj2;
			}
		}
		throw new ArgumentException("rows");
	}

	public int z0zek()
	{
		if (z0ptk)
		{
			return z0mtk - z0nrk - z0crk;
		}
		return z0wtk - z0nrk - z0crk;
	}

	public int z0lrk()
	{
		return z0nrk;
	}

	public void z0pek(int p0)
	{
		z0wtk = p0;
	}

	public bool z0krk()
	{
		return z0utk;
	}

	private void z0iek(z0ZzZzuyj p0)
	{
		z0ytk = new Dictionary<int, Dictionary<string, string>>();
		while (p0.z0rek() != null && p0.z0iek() != (z0ZzZzpyj)7)
		{
			if (p0.z0iek() != (z0ZzZzpyj)6)
			{
				continue;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			int num = 0;
			while (p0.z0rek() != null && p0.z0iek() != (z0ZzZzpyj)7)
			{
				if (p0.z0iek() == (z0ZzZzpyj)6)
				{
					p0.z0rek();
					z0nek_jiejie20260327142557(p0);
					p0.z0rek();
				}
				else if (p0.z0iek() == (z0ZzZzpyj)1 || p0.z0iek() == (z0ZzZzpyj)2)
				{
					if (p0.z0vek() == "s")
					{
						num = p0.z0xek();
					}
					else if (p0.z0uek())
					{
						dictionary[p0.z0vek()] = p0.z0xek().ToString();
					}
					else
					{
						dictionary[p0.z0vek()] = null;
					}
				}
				else
				{
					if (!p0.z0cek().z0yek())
					{
						continue;
					}
					string text = z0rek(p0, p0.z0cek(), p2: false, p3: false, p4: false);
					if (text != null)
					{
						text = text.Trim();
						if (text.EndsWith(";"))
						{
							text = text.Substring(0, text.Length - 1);
						}
					}
					dictionary["name"] = text;
				}
			}
			if (dictionary.Count > 0)
			{
				z0ytk[num] = dictionary;
			}
		}
	}

	private byte[] z0tek(string p0)
	{
		return z0ZzZzqik.z0eek(p0);
	}

	public bool z0jrk()
	{
		return z0htk;
	}

	private void z0oek(z0ZzZzuyj p0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		while (p0.z0rek() != null)
		{
			if (p0.z0vek() == "htmlrtf")
			{
				flag = ((!p0.z0uek() || p0.z0xek() != 0) ? true : false);
			}
			else if (p0.z0vek() == "htmltag")
			{
				if (p0.z0oek().Peek() == 32)
				{
					p0.z0oek().Read();
				}
				string text = z0rek(p0, null, p2: true, p3: false, p4: true);
				if (!string.IsNullOrEmpty(text))
				{
					stringBuilder.Append(text);
				}
			}
			else if (p0.z0iek() == (z0ZzZzpyj)1 || p0.z0iek() == (z0ZzZzpyj)2)
			{
				if (!flag)
				{
					switch (p0.z0vek())
					{
					case "par":
						stringBuilder.Append(Environment.NewLine);
						break;
					case "line":
						stringBuilder.Append(Environment.NewLine);
						break;
					case "tab":
						stringBuilder.Append("\t");
						break;
					case "lquote":
						stringBuilder.Append("&lsquo;");
						break;
					case "rquote":
						stringBuilder.Append("&rsquo;");
						break;
					case "ldblquote":
						stringBuilder.Append("&ldquo;");
						break;
					case "rdblquote":
						stringBuilder.Append("&rdquo;");
						break;
					case "bullet":
						stringBuilder.Append("&bull;");
						break;
					case "endash":
						stringBuilder.Append("&ndash;");
						break;
					case "emdash":
						stringBuilder.Append("&mdash;");
						break;
					case "~":
						stringBuilder.Append("&nbsp;");
						break;
					case "_":
						stringBuilder.Append("&shy;");
						break;
					}
				}
			}
			else if (p0.z0iek() == (z0ZzZzpyj)4 && !flag)
			{
				stringBuilder.Append(p0.z0vek());
			}
		}
		z0iek(stringBuilder.ToString());
	}

	private void z0hrk()
	{
		for (z0ZzZzftj z0ZzZzftj2 = z0frk(); z0ZzZzftj2 != null; z0ZzZzftj2 = z0ZzZzftj2.z0eek())
		{
			if (z0ZzZzftj2 is z0ZzZzitj)
			{
				z0ZzZzitj z0ZzZzitj2 = (z0ZzZzitj)z0ZzZzftj2;
				((z0ZzZzftj)z0ZzZzitj2).z0eek(p0: true);
				if (z0stk != null)
				{
					z0ZzZzitj2.z0eek(z0stk);
					z0stk = z0stk.z0yrk();
				}
				else
				{
					z0stk = new z0ZzZzmrj();
				}
				break;
			}
		}
	}

	public int z0grk()
	{
		return z0etk;
	}

	public void z0eek(Dictionary<int, Dictionary<string, string>> p0)
	{
		z0ytk = p0;
	}

	public z0ZzZzftj z0frk()
	{
		z0ZzZzftj[] array = z0rek(p0: true);
		return array[array.Length - 1];
	}

	public void z0yek(bool p0)
	{
		z0htk = p0;
	}

	public Dictionary<int, Dictionary<string, string>> z0drk()
	{
		return z0ytk;
	}

	private z0ZzZzatj z0tek(z0ZzZzuyj p0, z0ZzZzmrj p1)
	{
		z0ZzZzatj z0ZzZzatj2 = new z0ZzZzatj();
		z0ZzZzatj2.z0mek = p0.z0lrk();
		z0yek(z0ZzZzatj2);
		int num = p0.z0lrk();
		while (p0.z0rek() != null && p0.z0lrk() >= num)
		{
			if (p0.z0iek() == (z0ZzZzpyj)6 || p0.z0iek() == (z0ZzZzpyj)7)
			{
				continue;
			}
			switch (p0.z0vek())
			{
			case "flddirty":
				z0ZzZzatj2.z0eek((z0ZzZzqtj)1);
				break;
			case "fldedit":
				z0ZzZzatj2.z0eek((z0ZzZzqtj)2);
				break;
			case "fldlock":
				z0ZzZzatj2.z0eek((z0ZzZzqtj)3);
				break;
			case "fldpriv":
				z0ZzZzatj2.z0eek((z0ZzZzqtj)4);
				break;
			case "fldrslt":
			{
				z0ZzZzdtj z0ZzZzdtj3 = new z0ZzZzdtj();
				z0ZzZzdtj3.z0eek("fldrslt");
				z0ZzZzatj2.z0eek(z0ZzZzdtj3);
				z0yek(p0, p1);
				z0ZzZzdtj3.z0eek(p0: true);
				break;
			}
			case "fldinst":
			{
				z0ZzZzdtj z0ZzZzdtj2 = new z0ZzZzdtj();
				z0ZzZzdtj2.z0eek("fldinst");
				z0ZzZzatj2.z0eek(z0ZzZzdtj2);
				z0yek(p0, p1);
				z0ZzZzdtj2.z0eek(p0: true);
				string text = z0ZzZzdtj2.z0bjk();
				if (text == null)
				{
					break;
				}
				int num2 = text.IndexOf("HYPERLINK");
				if (num2 < 0)
				{
					break;
				}
				int num3 = text.IndexOf('"', num2);
				if (num3 <= 0 || text.Length <= num3 + 2)
				{
					break;
				}
				int num4 = text.IndexOf('"', num3 + 2);
				if (num4 <= num3)
				{
					break;
				}
				string text2 = text.Substring(num3 + 1, num4 - num3 - 1);
				if (p1.z0zrk() != null)
				{
					if (text2.StartsWith("_Toc"))
					{
						text2 = "#" + text2;
					}
					p1.z0zrk().z0eek(text2);
				}
				break;
			}
			}
		}
		z0ZzZzatj2.z0eek(p0: true);
		return z0ZzZzatj2;
	}

	private void z0pek(z0ZzZzuyj p0)
	{
		z0ltk.z0eek();
		z0ltk.z0eek(p0: false);
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		while (p0.z0rek() != null && p0.z0iek() != (z0ZzZzpyj)7)
		{
			switch (p0.z0vek())
			{
			case "red":
				num = p0.z0xek();
				break;
			case "green":
				num2 = p0.z0xek();
				break;
			case "blue":
				num3 = p0.z0xek();
				break;
			case ";":
				if (num >= 0 && num2 >= 0 && num3 >= 0)
				{
					Color p1 = Color.FromArgb(255, num, num2, num3);
					z0ltk.z0eek(p1);
					num = -1;
					num2 = -1;
					num3 = -1;
				}
				break;
			}
		}
		if (num >= 0 && num2 >= 0 && num3 >= 0)
		{
			Color p2 = Color.FromArgb(255, num, num2, num3);
			z0ltk.z0eek(p2);
		}
	}

	public void z0yek(string p0)
	{
		z0ork = p0;
	}

	public void z0uek(bool p0)
	{
		z0ptk = p0;
	}

	public z0ZzZzfyj z0srk()
	{
		return z0itk;
	}

	public z0ZzZzdyj z0ark()
	{
		return z0jtk;
	}

	public int z0qrk()
	{
		return z0brk;
	}

	public z0ZzZzgtj()
	{
		z0eek(this);
		EncodingInfo[] encodings = Encoding.GetEncodings();
		foreach (EncodingInfo encodingInfo in encodings)
		{
			z0ZzZzqok.z0rek.z0sh(encodingInfo.Name + " " + encodingInfo.DisplayName + " " + encodingInfo.CodePage);
		}
	}

	public void z0uek(string p0)
	{
		z0otk = p0;
	}

	private void z0rek(int p0, string p1, int p2, bool p3)
	{
		if (p0 >= 0 && p1 != null)
		{
			if (p1.EndsWith(";"))
			{
				p1 = p1.Substring(0, p1.Length - 1);
			}
			p1 = p1.Trim();
			if (string.IsNullOrEmpty(p1))
			{
				p1 = z0ZzZzimk.DefaultFontName;
			}
			p1 = z0ZzZzpij.z0rek(p1);
			z0ZzZzxtj z0ZzZzxtj2 = new z0ZzZzxtj(p0, p1);
			z0ZzZzxtj2.z0tek(p2);
			z0ZzZzxtj2.z0eek(p3);
			z0dtk.z0eek(z0ZzZzxtj2);
		}
	}

	public z0ZzZzzrj z0wrk()
	{
		return z0ltk;
	}

	private string z0rek(z0ZzZzuyj p0, bool p1)
	{
		return z0rek(p0, null, p1, p3: false, p4: false);
	}

	public z0ZzZzftj z0rek(Type p0, bool p1)
	{
		z0ZzZzftj[] array = z0rek(p0: true);
		for (int num = array.Length - 1; num >= 0; num--)
		{
			if (p0.IsInstanceOfType(array[num]) && array[num].z0oek() == p1)
			{
				return array[num];
			}
		}
		return null;
	}

	public new void z0mek(int p0)
	{
		z0etk = p0;
	}

	public int z0erk()
	{
		return z0crk;
	}

	private new DateTime z0mek(z0ZzZzuyj p0)
	{
		int year = 1900;
		int month = 1;
		int day = 1;
		int hour = 0;
		int minute = 0;
		int second = 0;
		while (p0.z0rek() != null && p0.z0iek() != (z0ZzZzpyj)7)
		{
			switch (p0.z0vek())
			{
			case "yr":
				year = p0.z0xek();
				break;
			case "mo":
				month = p0.z0xek();
				break;
			case "dy":
				day = p0.z0xek();
				break;
			case "hr":
				hour = p0.z0xek();
				break;
			case "min":
				minute = p0.z0xek();
				break;
			case "sec":
				second = p0.z0xek();
				break;
			}
		}
		return new DateTime(year, month, day, hour, minute, second);
	}

	private void z0uek(z0ZzZzftj p0)
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		int num = -1;
		z0ZzZzvtj z0ZzZzvtj2 = null;
		foreach (z0ZzZzftj item in p0.z0uek())
		{
			if (item is z0ZzZzvtj)
			{
				z0ZzZzvtj z0ZzZzvtj3 = (z0ZzZzvtj)item;
				((z0ZzZzftj)z0ZzZzvtj3).z0eek(p0: false);
				ArrayList arrayList3 = z0ZzZzvtj3.z0nek();
				if (arrayList3.Count == 0 && z0ZzZzvtj2 != null && z0ZzZzvtj2.z0nek().Count == ((z0ZzZzftj)z0ZzZzvtj3).z0uek().Count)
				{
					arrayList3 = z0ZzZzvtj2.z0nek();
				}
				if (arrayList3.Count == ((z0ZzZzftj)z0ZzZzvtj3).z0uek().Count)
				{
					for (int i = 0; i < ((z0ZzZzftj)z0ZzZzvtj3).z0uek().Count; i++)
					{
						((z0ZzZzftj)z0ZzZzvtj3).z0uek()[i].z0eek((z0ZzZzxrj)arrayList3[i]);
					}
				}
				bool flag = z0ZzZzvtj3.z0eek("lastrow");
				if (!flag)
				{
					int num2 = p0.z0uek().IndexOf(item);
					if (num2 == p0.z0uek().Count - 1)
					{
						flag = true;
					}
					else if (!(p0.z0uek()[num2 + 1] is z0ZzZzvtj))
					{
						flag = true;
					}
				}
				if (flag)
				{
					arrayList2.Add(z0ZzZzvtj3);
					arrayList.Add(z0rek(arrayList2));
					num = -1;
				}
				else
				{
					int num3 = 0;
					if (z0ZzZzvtj3.z0eek("trwWidth"))
					{
						num3 = ((z0ZzZzftj)z0ZzZzvtj3).z0rek().z0rek("trwWidth");
						if (z0ZzZzvtj3.z0eek("trwWidthA"))
						{
							num3 -= ((z0ZzZzftj)z0ZzZzvtj3).z0rek().z0rek("trwWidthA");
						}
					}
					else
					{
						foreach (z0ZzZzntj item2 in ((z0ZzZzftj)z0ZzZzvtj3).z0uek())
						{
							if (item2.z0eek("cellx"))
							{
								num3 = Math.Max(num3, ((z0ZzZzftj)item2).z0rek().z0rek("cellx"));
							}
						}
					}
					if (num > 0 && num != num3 && arrayList2.Count > 0)
					{
						arrayList.Add(z0rek(arrayList2));
					}
					num = num3;
					arrayList2.Add(z0ZzZzvtj3);
				}
				z0ZzZzvtj2 = z0ZzZzvtj3;
			}
			else if (item is z0ZzZzntj)
			{
				z0ZzZzvtj2 = null;
				z0uek(item);
				if (arrayList2.Count > 0)
				{
					arrayList.Add(z0rek(arrayList2));
				}
				arrayList.Add(item);
				num = -1;
			}
			else
			{
				z0ZzZzvtj2 = null;
				z0uek(item);
				if (arrayList2.Count > 0)
				{
					arrayList.Add(z0rek(arrayList2));
				}
				arrayList.Add(item);
				num = -1;
			}
		}
		if (arrayList2.Count > 0)
		{
			arrayList.Add(z0rek(arrayList2));
		}
		p0.z0eek(p0: false);
		p0.z0uek().Clear();
		foreach (z0ZzZzftj item3 in arrayList)
		{
			p0.z0eek(item3);
		}
	}

	public void z0nek_jiejie20260327142557(int p0)
	{
		z0ntk = p0;
	}

	public int z0rrk()
	{
		return z0wtk;
	}

	private void z0rek(z0ZzZzntj p0, z0ZzZzxrj p1)
	{
		z0ZzZzxrj z0ZzZzxrj2 = p1.z0eek();
		z0ZzZzxrj2.z0tek("clvmgf");
		z0ZzZzxrj2.z0tek("clvmrg");
		p0.z0eek(z0ZzZzxrj2);
	}

	public void z0rek(z0ZzZzzrj p0)
	{
		z0ltk = p0;
	}

	private void z0nek_jiejie20260327142557(z0ZzZzuyj p0)
	{
		p0.z0krk();
	}

	public void z0bek(int p0)
	{
		z0xrk = p0;
	}

	private void z0yek(z0ZzZzuyj p0, z0ZzZzmrj p1)
	{
		bool flag = false;
		z0ZzZzmrj z0ZzZzmrj2 = null;
		if (z0stk == null)
		{
			z0stk = new z0ZzZzmrj();
		}
		if (p1 == null)
		{
			z0ZzZzmrj2 = new z0ZzZzmrj();
		}
		else
		{
			z0ZzZzmrj2 = p1.z0yrk();
			z0ZzZzmrj2.z0rtk = p1.z0rtk + 1;
		}
		z0qtk.Push(z0ZzZzmrj2);
		z0ZzZziyj z0ZzZziyj2 = new z0ZzZziyj(this);
		int num = p0.z0lrk();
		while (p0.z0rek() != null)
		{
			if (p0.z0zek() - z0yrk > 100)
			{
				z0yrk = p0.z0zek();
			}
			if (z0rtk)
			{
				if (z0ZzZziyj2.z0eek(p0.z0cek(), p0))
				{
					z0ZzZziyj2.z0eek(p0.z0lrk());
					continue;
				}
				if (z0ZzZziyj2.z0tek() && z0rek(z0ZzZziyj2, p0, z0ZzZzmrj2))
				{
					break;
				}
			}
			if (p0.z0iek() == (z0ZzZzpyj)7)
			{
				z0qtk.Pop();
				z0ZzZzftj[] array = z0rek(p0: true);
				for (int i = 0; i < array.Length; i++)
				{
					z0ZzZzftj z0ZzZzftj2 = array[i];
					if (z0ZzZzftj2.z0mek >= 0 && z0ZzZzftj2.z0mek > p0.z0lrk())
					{
						for (int j = i; j < array.Length; j++)
						{
							array[j].z0eek(p0: true);
						}
						break;
					}
				}
				if (array.Length > 1 && !(array[array.Length - 1] is z0ZzZzitj))
				{
				}
				break;
			}
			if (p0.z0lrk() < num)
			{
				break;
			}
			if (p0.z0iek() == (z0ZzZzpyj)6)
			{
				z0yek(p0, z0ZzZzmrj2);
				if (p0.z0lrk() < num)
				{
					break;
				}
			}
			if (p0.z0iek() != (z0ZzZzpyj)3 && p0.z0iek() != (z0ZzZzpyj)1 && p0.z0iek() != (z0ZzZzpyj)2)
			{
				continue;
			}
			string text = p0.z0vek();
			uint num2 = z0ZzZzcek.z0eek(text);
			if (num2 <= 1796401776)
			{
				if (num2 <= 1129452970)
				{
					if (num2 <= 695292791)
					{
						if (num2 <= 296252135)
						{
							if (num2 <= 155321749)
							{
								if (num2 <= 29204113)
								{
									switch (num2)
									{
									case 29204113u:
										if (!(text == "footery"))
										{
											break;
										}
										if (p0.z0uek())
										{
											z0mek(p0.z0xek());
										}
										continue;
									case 13276056u:
									{
										if (!(text == "shpright"))
										{
											break;
										}
										z0ZzZzotj z0ZzZzotj2 = (z0ZzZzotj)z0rek(typeof(z0ZzZzotj));
										z0ZzZzotj2?.z0yek(p0.z0xek() - z0ZzZzotj2.z0yek());
										continue;
									}
									}
								}
								else if (num2 != 44373190)
								{
									if (num2 != 77928428)
									{
										if (num2 == 155321749 && text == "pict")
										{
											z0rtk = true;
											z0ZzZzrtj z0ZzZzrtj2 = new z0ZzZzrtj();
											((z0ZzZzftj)z0ZzZzrtj2).z0mek = p0.z0lrk();
											z0yek(z0ZzZzrtj2);
											continue;
										}
									}
									else if (text == "trpaddt")
									{
										goto IL_31fb;
									}
								}
								else if (text == "trpaddr")
								{
									goto IL_31fb;
								}
							}
							else
							{
								switch (num2)
								{
								case 201306683u:
									if (!(text == "filetbl"))
									{
										break;
									}
									z0nek_jiejie20260327142557(p0);
									continue;
								case 263456517u:
									if (!(text == "info"))
									{
										break;
									}
									z0yek(p0);
									return;
								case 290031026u:
								{
									if (!(text == "footer"))
									{
										break;
									}
									z0ZzZzwtj z0ZzZzwtj2 = new z0ZzZzwtj();
									z0ZzZzwtj2.z0eek((z0ZzZznrj)3);
									z0eek(z0ZzZzwtj2);
									z0yek(p0, p1);
									z0ZzZzwtj2.z0tek();
									z0ZzZzwtj2.z0eek(p0: true);
									z0stk = new z0ZzZzmrj();
									continue;
								}
								case 180202684u:
								{
									if (!(text == "footerf"))
									{
										break;
									}
									z0ZzZzwtj z0ZzZzwtj3 = new z0ZzZzwtj();
									z0ZzZzwtj3.z0eek((z0ZzZznrj)3);
									z0eek(z0ZzZzwtj3);
									z0yek(p0, p1);
									z0ZzZzwtj3.z0tek();
									z0ZzZzwtj3.z0eek(p0: true);
									z0stk = new z0ZzZzmrj();
									continue;
								}
								case 296252135u:
									if (!(text == "brdrth"))
									{
										break;
									}
									z0rtk = true;
									z0stk.z0eek(p0: true);
									z0ZzZzmrj2.z0eek(p0: true);
									continue;
								case 171713509u:
									if (!(text == "wmetafile"))
									{
										break;
									}
									((z0ZzZzrtj)z0rek(typeof(z0ZzZzrtj)))?.z0eek((z0ZzZzryj)5);
									continue;
								}
							}
						}
						else if (num2 <= 480244007)
						{
							if (num2 <= 329621823)
							{
								if (num2 != 312815094)
								{
									if (num2 == 329621823 && text == "brdrdashdd")
									{
										z0rtk = true;
										z0stk.z0eek(DashStyle.DashDotDot);
										z0ZzZzmrj2.z0eek(DashStyle.DashDotDot);
										continue;
									}
								}
								else if (text == "trpaddb")
								{
									goto IL_31fb;
								}
							}
							else
							{
								switch (num2)
								{
								case 347978874u:
								{
									if (!(text == "footerl"))
									{
										break;
									}
									z0ZzZzwtj z0ZzZzwtj4 = new z0ZzZzwtj();
									z0ZzZzwtj4.z0eek((z0ZzZznrj)1);
									z0eek(z0ZzZzwtj4);
									z0yek(p0, p1);
									z0ZzZzwtj4.z0tek();
									z0ZzZzwtj4.z0eek(p0: true);
									z0stk = new z0ZzZzmrj();
									continue;
								}
								case 400234023u:
									if (!(text == "line"))
									{
										break;
									}
									z0rtk = true;
									if (z0ZzZzmrj2.z0atk)
									{
										z0ZzZzttj z0ZzZzttj2 = new z0ZzZzttj();
										z0ZzZzttj2.z0mek = p0.z0lrk();
										z0yek(z0ZzZzttj2);
									}
									continue;
								case 480244007u:
									if (!(text == "highlight"))
									{
										break;
									}
									z0rtk = true;
									if (z0ZzZzmrj2.z0atk && p0.z0uek())
									{
										z0ZzZzmrj2.z0eek(z0wrk().z0eek(p0.z0xek(), Color.Empty));
									}
									continue;
								}
							}
						}
						else if (num2 <= 580323335)
						{
							if (num2 != 480591284)
							{
								switch (num2)
								{
								case 549041394u:
									if (!(text == "landscape"))
									{
										break;
									}
									z0ptk = true;
									continue;
								case 580323335u:
								{
									if (!(text == "nestcell"))
									{
										break;
									}
									z0rtk = true;
									z0yek((z0ZzZzftj)null);
									z0hrk();
									z0ZzZzftj[] array2 = z0rek(p0: false);
									for (int num3 = array2.Length - 1; num3 >= 0; num3--)
									{
										array2[num3].z0eek(p0: true);
										if (array2[num3] is z0ZzZzntj)
										{
											((z0ZzZzntj)array2[num3]).z0eek(z0ZzZzmrj2);
											break;
										}
									}
									continue;
								}
								}
							}
							else if (text == "trpaddl")
							{
								goto IL_31fb;
							}
						}
						else if (num2 != 592110028)
						{
							switch (num2)
							{
							case 632598351u:
								if (!(text == "strike"))
								{
									break;
								}
								z0rtk = true;
								if (z0ZzZzmrj2.z0atk)
								{
									z0ZzZzmrj2.z0mek(!p0.z0uek() || p0.z0xek() != 0);
								}
								continue;
							case 695292791u:
								if (!(text == "bkmkend"))
								{
									break;
								}
								flag = true;
								z0ZzZzmrj2.z0atk = false;
								continue;
							}
						}
						else if (text == "clcbpat")
						{
							goto IL_323f;
						}
					}
					else if (num2 <= 956151988)
					{
						if (num2 <= 850369312)
						{
							if (num2 <= 802434779)
							{
								if (num2 != 786484486)
								{
									if (num2 == 802434779 && text == "trshdng")
									{
										goto IL_31fb;
									}
								}
								else if (text == "clvmgf")
								{
									goto IL_323f;
								}
							}
							else if (num2 != 826723091)
							{
								if (num2 != 830561601)
								{
									if (num2 == 850369312 && text == "irow")
									{
										goto IL_31fb;
									}
								}
								else if (text == "brdrdashd")
								{
									z0rtk = true;
									z0stk.z0eek(DashStyle.DashDot);
									z0ZzZzmrj2.z0eek(DashStyle.DashDot);
									continue;
								}
							}
							else if (text == "brdrb")
							{
								z0rtk = true;
								z0stk.z0lrk(p0: true);
								continue;
							}
						}
						else
						{
							switch (num2)
							{
							case 914244106u:
								if (!(text == "ansicpg"))
								{
									break;
								}
								z0prk = z0ZzZzqik.z0eek(p0.z0xek());
								continue;
							case 956151988u:
								if (text == "revtbl")
								{
									continue;
								}
								break;
							case 894566304u:
								if (!(text == "sb"))
								{
									break;
								}
								z0rtk = true;
								z0stk.z0uek(p0.z0xek());
								continue;
							case 944899161u:
								if (!(text == "sa"))
								{
									break;
								}
								z0rtk = true;
								z0stk.z0iek(p0.z0xek());
								continue;
							case 867750633u:
								if (text == "insrsid")
								{
									continue;
								}
								break;
							case 854220258u:
								if (!(text == "brdrnil"))
								{
									break;
								}
								z0rtk = true;
								z0stk.z0xek(p0: false);
								z0stk.z0yek(p0: false);
								z0stk.z0nek(p0: false);
								z0stk.z0lrk(p0: false);
								z0ZzZzmrj2.z0xek(p0: false);
								z0ZzZzmrj2.z0yek(p0: false);
								z0ZzZzmrj2.z0nek(p0: false);
								z0ZzZzmrj2.z0lrk(p0: false);
								continue;
							}
						}
					}
					else if (num2 <= 1077001542)
					{
						if (num2 <= 1052843449)
						{
							if (num2 != 1036065830)
							{
								if (num2 != 1043498608)
								{
									if (num2 == 1052843449 && text == "clvertalc")
									{
										goto IL_323f;
									}
								}
								else if (text == "lchars")
								{
									z0yek(z0rek(p0, p1: true));
									continue;
								}
							}
							else if (text == "clvertalb")
							{
								goto IL_323f;
							}
						}
						else if (num2 != 1061609757)
						{
							if (num2 != 1072678677)
							{
								if (num2 == 1077001542 && text == "li")
								{
									z0rtk = true;
									if (p0.z0uek())
									{
										z0stk.z0nek(p0.z0xek());
									}
									continue;
								}
							}
							else if (text == "brdrnone")
							{
								goto IL_323f;
							}
						}
						else if (text == "brdrl")
						{
							z0rtk = true;
							z0stk.z0xek(p0: true);
							continue;
						}
					}
					else
					{
						switch (num2)
						{
						case 1129452970u:
							if (!(text == "sl"))
							{
								break;
							}
							z0rtk = true;
							if (p0.z0xek() >= 0)
							{
								z0stk.z0mek(p0.z0xek());
							}
							continue;
						case 1129202707u:
							if (!(text == "pn"))
							{
								break;
							}
							z0rtk = true;
							z0stk.z0vek(-1);
							continue;
						case 1104843343u:
							if (!(text == "pnlvlbody"))
							{
								break;
							}
							z0rtk = true;
							continue;
						case 1095164995u:
							if (!(text == "brdrr"))
							{
								break;
							}
							z0rtk = true;
							z0stk.z0nek(p0: true);
							continue;
						case 1078387376u:
							if (!(text == "brdrs"))
							{
								break;
							}
							z0rtk = true;
							z0stk.z0eek(p0: false);
							z0ZzZzmrj2.z0eek(p0: false);
							continue;
						case 1098216500u:
							if (!(text == "jpegblip"))
							{
								break;
							}
							((z0ZzZzrtj)z0rek(typeof(z0ZzZzrtj)))?.z0eek((z0ZzZzryj)2);
							continue;
						}
					}
				}
				else if (num2 <= 1472767843)
				{
					if (num2 <= 1221306618)
					{
						if (num2 <= 1195830709)
						{
							switch (num2)
							{
							case 1150566289u:
								if (!(text == "nonesttables"))
								{
									break;
								}
								z0nek_jiejie20260327142557(p0);
								continue;
							case 1143551638u:
								if (!(text == "fchars"))
								{
									break;
								}
								z0uek(z0rek(p0, p1: true));
								continue;
							case 1145497852u:
								if (!(text == "brdrw"))
								{
									break;
								}
								z0rtk = true;
								if (p0.z0uek())
								{
									z0stk.z0tek(p0.z0xek());
								}
								continue;
							case 1195830709u:
								if (!(text == "brdrt"))
								{
									break;
								}
								z0rtk = true;
								z0stk.z0lrk(p0: true);
								continue;
							case 1141775739u:
							{
								if (!(text == "row"))
								{
									break;
								}
								z0rtk = true;
								z0ZzZzftj[] array3 = z0rek(p0: true);
								for (int num4 = array3.Length - 1; num4 >= 0; num4--)
								{
									array3[num4].z0eek(p0: true);
									if (array3[num4] is z0ZzZzvtj)
									{
										break;
									}
								}
								continue;
							}
							}
						}
						else if (num2 <= 1204921911)
						{
							if (num2 != 1196563446)
							{
								if (num2 != 1204293575)
								{
									if (num2 == 1204921911 && text == "lastrow")
									{
										goto IL_31fb;
									}
								}
								else if (text == "trhdr")
								{
									goto IL_31fb;
								}
							}
							else if (text == "sp")
							{
								int num5 = 0;
								string p2 = null;
								string p3 = null;
								while (p0.z0rek() != null)
								{
									if (p0.z0iek() == (z0ZzZzpyj)6)
									{
										num5++;
									}
									else if (p0.z0iek() == (z0ZzZzpyj)7)
									{
										num5--;
										if (num5 < 0)
										{
											break;
										}
									}
									else if (p0.z0vek() == "sn")
									{
										p2 = z0rek(p0, p1: true);
									}
									else if (p0.z0vek() == "sv")
									{
										p3 = z0rek(p0, p1: true);
									}
								}
								z0ZzZzotj z0ZzZzotj3 = (z0ZzZzotj)z0rek(typeof(z0ZzZzotj));
								if (z0ZzZzotj3 != null)
								{
									z0ZzZzotj3.z0eek().z0eek(p2, p3);
								}
								else
								{
									((z0ZzZzptj)z0rek(typeof(z0ZzZzptj)))?.z0eek().z0eek(p2, p3);
								}
								continue;
							}
						}
						else if (num2 != 1218042098)
						{
							if (num2 != 1218993707)
							{
								if (num2 == 1221306618 && text == "trleft")
								{
									goto IL_31fb;
								}
							}
							else if (text == "listoverridetable")
							{
								z0uek(p0);
								continue;
							}
						}
						else if (text == "bkmkstart")
						{
							z0rtk = true;
							if (z0ZzZzmrj2.z0atk && z0rtk)
							{
								z0ZzZzhtj z0ZzZzhtj2 = new z0ZzZzhtj();
								z0ZzZzhtj2.z0eek(z0rek(p0, p1: true));
								z0ZzZzhtj2.z0eek(p0: true);
								z0yek(z0ZzZzhtj2);
							}
							continue;
						}
					}
					else if (num2 <= 1386565073)
					{
						if (num2 <= 1264897480)
						{
							if (num2 != 1226985087)
							{
								if (num2 != 1227161470)
								{
									if (num2 == 1264897480 && text == "intbl")
									{
										goto IL_2f71;
									}
								}
								else if (text == "af")
								{
									z0ZzZzxtj z0ZzZzxtj2 = z0bek().z0rek(p0.z0xek());
									if (z0ZzZzxtj2 != null)
									{
										z0atk = z0ZzZzxtj2.z0rek();
									}
									continue;
								}
							}
							else if (text == "shplid")
							{
								((z0ZzZzotj)z0rek(typeof(z0ZzZzotj)))?.z0rek(p0.z0xek());
								continue;
							}
						}
						else if (num2 != 1338062972)
						{
							if (num2 != 1380330086)
							{
								if (num2 == 1386565073 && text == "trrh")
								{
									goto IL_31fb;
								}
							}
							else if (text == "brsp")
							{
								z0rtk = true;
								if (p0.z0uek())
								{
									z0stk.z0eek(p0.z0xek());
								}
								continue;
							}
						}
						else if (text == "clvertalt")
						{
							goto IL_323f;
						}
					}
					else if (num2 <= 1435908495)
					{
						if (num2 != 1392331604)
						{
							if (num2 != 1428787088)
							{
								if (num2 == 1435908495 && text == "irowband")
								{
									goto IL_31fb;
								}
							}
							else if (text == "cb")
							{
								goto IL_25c1;
							}
						}
						else if (text == "pntext")
						{
							continue;
						}
					}
					else if (num2 != 1445123422)
					{
						if (num2 != 1446109160)
						{
							if (num2 == 1472767843 && text == "trcfpat")
							{
								goto IL_31fb;
							}
						}
						else if (text == "ls")
						{
							z0rtk = true;
							z0stk.z0vek(p0.z0xek());
							z0gtk = 0;
							continue;
						}
					}
					else if (text == "fs")
					{
						z0rtk = true;
						if (z0ZzZzmrj2.z0atk && p0.z0uek())
						{
							z0ZzZzmrj2.z0eek((float)p0.z0xek() / 2f);
						}
						continue;
					}
				}
				else if (num2 <= 1628625586)
				{
					if (num2 <= 1565273706)
					{
						switch (num2)
						{
						case 1565273706u:
							if (!(text == "qr"))
							{
								break;
							}
							z0rtk = true;
							z0stk.z0eek((z0ZzZzvrj)2);
							continue;
						case 1545789136u:
							if (!(text == "fi"))
							{
								break;
							}
							z0rtk = true;
							z0stk.z0bek(p0.z0xek());
							continue;
						case 1495897564u:
							if (!(text == "cf"))
							{
								break;
							}
							z0rtk = true;
							if (z0ZzZzmrj2.z0atk && p0.z0uek())
							{
								z0ZzZzmrj2.z0tek(z0wrk().z0eek(p0.z0xek(), Color.Black));
							}
							continue;
						case 1475767949u:
							if (!(text == "nonshppict"))
							{
								break;
							}
							z0nek_jiejie20260327142557(p0);
							continue;
						case 1489552147u:
							if (!(text == "pngblip"))
							{
								break;
							}
							((z0ZzZzrtj)z0rek(typeof(z0ZzZzrtj)))?.z0eek((z0ZzZzryj)1);
							continue;
						}
					}
					else if (num2 <= 1598828944)
					{
						if (num2 != 1588043596)
						{
							switch (num2)
							{
							case 1598828944u:
								if (!(text == "ql"))
								{
									break;
								}
								z0rtk = true;
								z0stk.z0eek((z0ZzZzvrj)0);
								continue;
							case 1598240564u:
								if (!(text == "ul"))
								{
									break;
								}
								z0rtk = true;
								if (z0ZzZzmrj2.z0atk)
								{
									z0ZzZzmrj2.z0bek(!p0.z0uek() || p0.z0xek() != 0);
								}
								continue;
							}
						}
						else if (text == "trqr")
						{
							goto IL_31fb;
						}
					}
					else if (num2 != 1604535569)
					{
						if (num2 != 1610706388)
						{
							if (num2 == 1628625586 && text == "clbrdrb")
							{
								goto IL_323f;
							}
						}
						else if (text == "clvmrg")
						{
							goto IL_323f;
						}
					}
					else if (text == "listoverride")
					{
						z0nek_jiejie20260327142557(p0);
						continue;
					}
				}
				else if (num2 <= 1688328418)
				{
					if (num2 <= 1662180824)
					{
						if (num2 != 1641669536)
						{
							if (num2 != 1649401158)
							{
								if (num2 == 1662180824 && text == "clbrdrl")
								{
									goto IL_323f;
								}
							}
							else if (text == "picscaley")
							{
								((z0ZzZzrtj)z0rek(typeof(z0ZzZzrtj)))?.z0eek(p0.z0xek());
								continue;
							}
						}
						else if (text == "chbrdr")
						{
							z0rtk = true;
							z0ZzZzmrj2.z0xek(p0: true);
							z0ZzZzmrj2.z0yek(p0: true);
							z0ZzZzmrj2.z0nek(p0: true);
							z0ZzZzmrj2.z0lrk(p0: true);
							continue;
						}
					}
					else if (num2 != 1666178777)
					{
						if (num2 != 1666584168)
						{
							if (num2 == 1688328418 && text == "trkeep")
							{
								goto IL_31fb;
							}
						}
						else if (text == "par")
						{
							z0rtk = true;
							if (z0rek(typeof(z0ZzZzitj)) == null)
							{
								z0ZzZzitj z0ZzZzitj2 = new z0ZzZzitj();
								z0ZzZzitj2.z0eek(p0: true);
								z0ZzZzitj2.z0eek(z0stk);
								z0stk = z0stk.z0yrk();
								z0yek(z0ZzZzitj2);
								((z0ZzZzftj)z0ZzZzitj2).z0eek(p0: true);
							}
							else
							{
								z0hrk();
								z0ZzZzitj z0ZzZzitj3 = new z0ZzZzitj();
								z0ZzZzitj3.z0eek(p0: true);
								z0ZzZzitj3.z0eek(z0stk);
								z0yek(z0ZzZzitj3);
							}
							z0rtk = true;
							continue;
						}
					}
					else if (text == "picscalex")
					{
						((z0ZzZzrtj)z0rek(typeof(z0ZzZzrtj)))?.z0iek(p0.z0xek());
						continue;
					}
				}
				else if (num2 <= 1736598119)
				{
					switch (num2)
					{
					case 1725990458u:
						if (!(text == "pagebb"))
						{
							break;
						}
						z0rtk = true;
						z0stk.z0vek(p0: true);
						continue;
					case 1699494658u:
						if (!(text == "qj"))
						{
							break;
						}
						z0rtk = true;
						z0stk.z0eek((z0ZzZzvrj)3);
						continue;
					case 1736598119u:
						if (!(text == "field"))
						{
							break;
						}
						z0rtk = true;
						z0tek(p0, z0ZzZzmrj2);
						return;
					}
				}
				else if (num2 != 1750753032)
				{
					if (num2 != 1759288501)
					{
						if (num2 == 1796401776 && text == "clbrdrt")
						{
							goto IL_323f;
						}
					}
					else if (text == "cell")
					{
						z0rtk = true;
						z0yek((z0ZzZzftj)null);
						z0hrk();
						z0stk.z0mrk();
						z0ZzZzmrj2.z0mrk();
						z0ZzZzftj[] array4 = z0rek(p0: true);
						for (int num6 = array4.Length - 1; num6 >= 0; num6--)
						{
							if (!array4[num6].z0oek())
							{
								if (array4[num6] is z0ZzZzgtj)
								{
									break;
								}
								array4[num6].z0eek(p0: true);
								if (array4[num6] is z0ZzZzntj)
								{
									break;
								}
							}
						}
						continue;
					}
				}
				else if (text == "trwWidth")
				{
					goto IL_31fb;
				}
			}
			else if (num2 <= 2988820187u)
			{
				if (num2 <= 2438597557u)
				{
					if (num2 <= 1957151214)
					{
						if (num2 <= 1860974018)
						{
							switch (num2)
							{
							case 1860974018u:
								if (!(text == "generator"))
								{
									break;
								}
								z0rek(z0rek(p0, p1: true));
								continue;
							case 1819811044u:
								if (!(text == "pard"))
								{
									break;
								}
								z0rtk = true;
								if (!flag)
								{
									z0stk.z0yek();
								}
								continue;
							case 1850493229u:
								if (!(text == "qc"))
								{
									break;
								}
								z0rtk = true;
								z0stk.z0eek((z0ZzZzvrj)1);
								continue;
							case 1799583997u:
								if (!(text == "wbitmap"))
								{
									break;
								}
								((z0ZzZzrtj)z0rek(typeof(z0ZzZzrtj)))?.z0eek((z0ZzZzryj)7);
								continue;
							case 1798136701u:
							{
								if (!(text == "shpgrp"))
								{
									break;
								}
								z0ZzZzptj z0ZzZzptj2 = new z0ZzZzptj();
								z0ZzZzptj2.z0mek = p0.z0lrk();
								z0yek(z0ZzZzptj2);
								continue;
							}
							}
						}
						else if (num2 <= 1897067490)
						{
							if (num2 != 1873263119)
							{
								if (num2 != 1894398805)
								{
									if (num2 == 1897067490 && text == "clbrdrr")
									{
										goto IL_323f;
									}
								}
								else if (text == "lang")
								{
									z0ftk = z0oek(p0.z0xek());
									continue;
								}
							}
							else if (text == "trqc")
							{
								goto IL_31fb;
							}
						}
						else if (num2 != 1931309659)
						{
							if (num2 != 1941544423)
							{
								if (num2 == 1957151214 && text == "trql")
								{
									goto IL_31fb;
								}
							}
							else if (text == "shpleft")
							{
								((z0ZzZzotj)z0rek(typeof(z0ZzZzotj)))?.z0uek(p0.z0xek());
								continue;
							}
						}
						else if (text == "brdrtbl")
						{
							goto IL_323f;
						}
					}
					else if (num2 <= 2250403136u)
					{
						if (num2 <= 2016218663)
						{
							if (num2 != 1966078305)
							{
								if (num2 == 2016218663 && text == "trautofit")
								{
									goto IL_31fb;
								}
							}
							else if (text == "stylesheet")
							{
								z0iek(p0);
								continue;
							}
						}
						else
						{
							switch (num2)
							{
							case 2033953750u:
								if (text == "xmlopen")
								{
									continue;
								}
								break;
							case 2170419830u:
								if (!(text == "page"))
								{
									break;
								}
								z0rtk = true;
								z0hrk();
								z0yek(new z0ZzZzutj());
								continue;
							case 2250403136u:
								if (!(text == "slmult"))
								{
									break;
								}
								z0rtk = true;
								z0stk.z0iek(p0.z0xek() == 1);
								continue;
							}
						}
					}
					else if (num2 <= 2403598315u)
					{
						if (num2 != 2338465226u)
						{
							if (num2 != 2376145825u)
							{
								if (num2 == 2403598315u && text == "trwWidthA")
								{
									goto IL_31fb;
								}
							}
							else if (text == "xmlns")
							{
								z0nek_jiejie20260327142557(p0);
								continue;
							}
						}
						else if (text == "pichgoal")
						{
							((z0ZzZzrtj)z0rek(typeof(z0ZzZzrtj)))?.z0uek(p0.z0xek());
							continue;
						}
					}
					else
					{
						switch (num2)
						{
						case 2404747860u:
							if (!(text == "emfblip"))
							{
								break;
							}
							((z0ZzZzrtj)z0rek(typeof(z0ZzZzrtj)))?.z0eek((z0ZzZzryj)0);
							continue;
						case 2438597557u:
							if (!(text == "dibitmap"))
							{
								break;
							}
							((z0ZzZzrtj)z0rek(typeof(z0ZzZzrtj)))?.z0eek((z0ZzZzryj)6);
							continue;
						case 2424899737u:
							if (text == "nesttableprops")
							{
								continue;
							}
							break;
						}
					}
				}
				else if (num2 <= 2720378283u)
				{
					if (num2 <= 2556583377u)
					{
						switch (num2)
						{
						case 2556583377u:
							if (text == "pntxtb")
							{
								continue;
							}
							break;
						case 2506250520u:
							if (text == "pntxta")
							{
								continue;
							}
							break;
						case 2472444663u:
							if (!(text == "pnlvlblt"))
							{
								break;
							}
							z0rtk = true;
							continue;
						case 2444060886u:
							if (text == "shptxt")
							{
								continue;
							}
							break;
						case 2516824777u:
						{
							if (!(text == "shpbottom"))
							{
								break;
							}
							z0ZzZzotj z0ZzZzotj4 = (z0ZzZzotj)z0rek(typeof(z0ZzZzotj));
							z0ZzZzotj4?.z0tek(p0.z0xek() - z0ZzZzotj4.z0tek());
							continue;
						}
						}
					}
					else if (num2 <= 2686823045u)
					{
						if (num2 != 2662644287u)
						{
							if (num2 != 2673378846u)
							{
								if (num2 == 2686823045u && text == "clpadl")
								{
									goto IL_323f;
								}
							}
							else if (text == "brdrdot")
							{
								z0rtk = true;
								z0stk.z0eek(DashStyle.Dot);
								z0ZzZzmrj2.z0eek(DashStyle.Dot);
								continue;
							}
						}
						else if (text == "brdrdash")
						{
							z0rtk = true;
							z0stk.z0eek(DashStyle.Dash);
							z0ZzZzmrj2.z0eek(DashStyle.Dash);
							continue;
						}
					}
					else if (num2 != 2695218327u)
					{
						if (num2 != 2714769610u)
						{
							if (num2 == 2720378283u && text == "clpadb")
							{
								goto IL_323f;
							}
						}
						else if (text == "paperw")
						{
							z0wtk = p0.z0xek();
							continue;
						}
					}
					else if (text == "trowd")
					{
						goto IL_2f71;
					}
				}
				else if (num2 <= 2849001335u)
				{
					if (num2 <= 2775673141u)
					{
						if (num2 != 2754457193u)
						{
							switch (num2)
							{
							case 2765102467u:
								if (!(text == "paperh"))
								{
									break;
								}
								z0mtk = p0.z0xek();
								continue;
							case 2775673141u:
								if (!(text == "pmmetafile"))
								{
									break;
								}
								((z0ZzZzrtj)z0rek(typeof(z0ZzZzrtj)))?.z0eek((z0ZzZzryj)4);
								continue;
							}
						}
						else if (text == "itap")
						{
							goto IL_2f71;
						}
					}
					else if (num2 != 2816272813u)
					{
						if (num2 != 2831976228u)
						{
							if (num2 == 2849001335u && text == "trcbpat")
							{
								goto IL_31fb;
							}
						}
						else if (text == "trpat")
						{
							goto IL_31fb;
						}
					}
					else if (text == "shptop")
					{
						((z0ZzZzotj)z0rek(typeof(z0ZzZzotj)))?.z0iek(p0.z0xek());
						continue;
					}
				}
				else if (num2 <= 2889848880u)
				{
					switch (num2)
					{
					case 2861155257u:
						if (!(text == "nosupersub"))
						{
							break;
						}
						z0rtk = true;
						z0ZzZzmrj2.z0tek(p0: false);
						z0ZzZzmrj2.z0rek(p0: false);
						continue;
					case 2886017721u:
						if (!(text == "shprslt"))
						{
							break;
						}
						z0nek_jiejie20260327142557(p0);
						continue;
					case 2889848880u:
						if (!(text == "shpz"))
						{
							break;
						}
						((z0ZzZzotj)z0rek(typeof(z0ZzZzotj)))?.z0eek(p0.z0xek());
						continue;
					}
				}
				else if (num2 != 2917992978u)
				{
					if (num2 != 2933995378u)
					{
						if (num2 == 2988820187u && text == "clpadr")
						{
							goto IL_323f;
						}
					}
					else if (text == "shpinst")
					{
						continue;
					}
				}
				else if (text == "ansi")
				{
					continue;
				}
			}
			else if (num2 <= 3607388050u)
			{
				if (num2 <= 3327400911u)
				{
					if (num2 <= 3099987130u)
					{
						if (num2 <= 3050212817u)
						{
							switch (num2)
							{
							case 3003421458u:
								if (!(text == "fonttbl"))
								{
									break;
								}
								z0tek(p0);
								continue;
							case 3050212817u:
							{
								if (!(text == "nestrow"))
								{
									break;
								}
								z0rtk = true;
								z0ZzZzftj[] array5 = z0rek(p0: true);
								for (int num7 = array5.Length - 1; num7 >= 0; num7--)
								{
									array5[num7].z0eek(p0: true);
									if (array5[num7] is z0ZzZzvtj)
									{
										break;
									}
								}
								continue;
							}
							}
						}
						else if (num2 != 3051949850u)
						{
							if (num2 != 3089485901u)
							{
								if (num2 == 3099987130u && text == "object")
								{
									z0rtk = true;
									z0rek(p0, z0ZzZzmrj2);
									return;
								}
							}
							else if (text == "clpadt")
							{
								goto IL_323f;
							}
						}
						else if (text == "colortbl")
						{
							z0pek(p0);
							return;
						}
					}
					else if (num2 <= 3222463264u)
					{
						switch (num2)
						{
						case 3222463264u:
							if (!(text == "fromhtml"))
							{
								break;
							}
							z0oek(p0);
							return;
						case 3182631899u:
							if (!(text == "listtable"))
							{
								break;
							}
							z0rek(p0);
							return;
						case 3201225730u:
							if (!(text == "pnseclvl"))
							{
								break;
							}
							z0nek_jiejie20260327142557(p0);
							continue;
						}
					}
					else if (num2 != 3315825969u)
					{
						if (num2 != 3323006560u)
						{
							if (num2 == 3327400911u && text == "trkeepfollow")
							{
								goto IL_31fb;
							}
						}
						else if (text == "trpaddfb")
						{
							goto IL_31fb;
						}
					}
					else if (text == "clNoWrap")
					{
						goto IL_323f;
					}
				}
				else if (num2 <= 3532931640u)
				{
					switch (num2)
					{
					case 3442218869u:
						if (!(text == "deflangfe"))
						{
							break;
						}
						z0urk = z0oek(p0.z0xek());
						continue;
					case 3479555812u:
					{
						if (!(text == "headerl"))
						{
							break;
						}
						z0ZzZzetj z0ZzZzetj2 = new z0ZzZzetj();
						z0ZzZzetj2.z0eek((z0ZzZznrj)1);
						z0eek(z0ZzZzetj2);
						z0yek(p0, p1);
						z0ZzZzetj2.z0tek();
						z0ZzZzetj2.z0eek(p0: true);
						z0stk = new z0ZzZzmrj();
						continue;
					}
					case 3378890098u:
					{
						if (!(text == "headerf"))
						{
							break;
						}
						z0ZzZzetj z0ZzZzetj3 = new z0ZzZzetj();
						z0ZzZzetj3.z0eek((z0ZzZznrj)3);
						z0eek(z0ZzZzetj3);
						z0yek(p0, p1);
						z0ZzZzetj3.z0tek();
						z0ZzZzetj3.z0eek(p0: true);
						z0stk = new z0ZzZzmrj();
						continue;
					}
					case 3532931640u:
						if (!(text == "margl"))
						{
							break;
						}
						z0nrk = p0.z0xek();
						continue;
					case 3499376402u:
						if (!(text == "margb"))
						{
							break;
						}
						z0brk = p0.z0xek();
						continue;
					case 3472409925u:
						if (!(text == "outlinelevel"))
						{
							break;
						}
						z0rtk = true;
						if (p0.z0uek())
						{
							z0stk.z0yek(p0.z0xek());
						}
						continue;
					}
				}
				else if (num2 <= 3565189836u)
				{
					if (num2 != 3552460647u)
					{
						if (num2 != 3557893226u)
						{
							if (num2 == 3565189836u && text == "macpict")
							{
								((z0ZzZzrtj)z0rek(typeof(z0ZzZzrtj)))?.z0eek((z0ZzZzryj)3);
								continue;
							}
						}
						else if (text == "trpaddfl")
						{
							goto IL_31fb;
						}
					}
					else if (text == "plain")
					{
						z0rtk = true;
						z0ftk = null;
						z0ZzZzmrj2.z0zek();
						continue;
					}
				}
				else if (num2 != 3580221526u)
				{
					if (num2 != 3591448464u)
					{
						if (num2 == 3607388050u && text == "shppict")
						{
							continue;
						}
					}
					else if (text == "trpaddfr")
					{
						goto IL_31fb;
					}
				}
				else if (text == "headerr")
				{
					z0ZzZzetj z0ZzZzetj4 = new z0ZzZzetj();
					z0ZzZzetj4.z0eek((z0ZzZznrj)2);
					z0eek(z0ZzZzetj4);
					z0yek(p0, p1);
					z0ZzZzetj4.z0tek();
					z0ZzZzetj4.z0eek(p0: true);
					z0stk = new z0ZzZzmrj();
					continue;
				}
			}
			else if (num2 <= 3834172512u)
			{
				if (num2 <= 3696113941u)
				{
					if (num2 <= 3685640260u)
					{
						switch (num2)
						{
						case 3685640260u:
							if (!(text == "langfe"))
							{
								break;
							}
							z0ftk = z0oek(p0.z0xek());
							continue;
						case 3667152592u:
							if (!(text == "margt"))
							{
								break;
							}
							z0xrk = p0.z0xek();
							continue;
						}
					}
					else if (num2 != 3692114178u)
					{
						switch (num2)
						{
						case 3696113941u:
							if (!(text == "sub"))
							{
								break;
							}
							z0rtk = true;
							if (z0ZzZzmrj2.z0atk)
							{
								z0ZzZzmrj2.z0tek(!p0.z0uek() || p0.z0xek() != 0);
							}
							continue;
						case 3693995370u:
						{
							if (!(text == "shp"))
							{
								break;
							}
							z0rtk = true;
							z0ZzZzotj z0ZzZzotj5 = new z0ZzZzotj();
							z0ZzZzotj5.z0mek = p0.z0lrk();
							z0yek(z0ZzZzotj5);
							continue;
						}
						}
					}
					else if (text == "trpaddft")
					{
						goto IL_31fb;
					}
				}
				else if (num2 <= 3767818306u)
				{
					if (num2 != 3697664859u)
					{
						if (num2 != 3763001015u)
						{
							if (num2 == 3767818306u && text == "margr")
							{
								z0crk = p0.z0xek();
								continue;
							}
						}
						else if (text == "cellx")
						{
							goto IL_323f;
						}
					}
					else if (text == "headery")
					{
						if (p0.z0uek())
						{
							z0iek(p0.z0xek());
						}
						continue;
					}
				}
				else if (num2 != 3809224601u)
				{
					if (num2 != 3823790992u)
					{
						if (num2 == 3834172512u && text == "header")
						{
							z0ZzZzetj z0ZzZzetj5 = new z0ZzZzetj();
							z0ZzZzetj5.z0eek((z0ZzZznrj)0);
							z0eek(z0ZzZzetj5);
							z0yek(p0, p1);
							z0ZzZzetj5.z0tek();
							z0ZzZzetj5.z0eek(p0: true);
							z0stk = new z0ZzZzmrj();
							continue;
						}
					}
					else if (text == "chcbpat")
					{
						goto IL_25c1;
					}
				}
				else if (text == "f")
				{
					z0rtk = true;
					if (z0ZzZzmrj2.z0atk)
					{
						string text2 = z0bek().z0eek(p0.z0xek());
						if (text2 != null)
						{
							text2 = text2.Trim();
						}
						if (text2 == null || text2.Length == 0)
						{
							text2 = z0ttk;
						}
						if (z0krk() && text2 == "Times New Roman")
						{
							text2 = z0ttk;
						}
						z0ZzZzmrj2.z0rek(text2);
					}
					z0ZzZzxtj z0ZzZzxtj3 = z0bek().z0rek(p0.z0xek());
					if (z0ZzZzxtj3 != null)
					{
						z0vrk = z0ZzZzxtj3.z0rek();
					}
					continue;
				}
			}
			else if (num2 <= 4047624472u)
			{
				if (num2 <= 3876335077u)
				{
					switch (num2)
					{
					case 3876335077u:
						if (!(text == "b"))
						{
							break;
						}
						z0rtk = true;
						if (z0ZzZzmrj2.z0atk)
						{
							z0ZzZzmrj2.z0uek(!p0.z0uek() || p0.z0xek() != 0);
						}
						continue;
					case 3849311506u:
					{
						if (!(text == "brdrcf"))
						{
							break;
						}
						z0rtk = true;
						z0ZzZzftj z0ZzZzftj3 = z0rek(typeof(z0ZzZzvtj), p1: false);
						if (z0ZzZzftj3 is z0ZzZzvtj)
						{
							z0ZzZzvtj z0ZzZzvtj2 = (z0ZzZzvtj)z0ZzZzftj3;
							if (z0ZzZzvtj2.z0nek().Count > 0)
							{
								((z0ZzZzxrj)z0ZzZzvtj2.z0nek()[z0ZzZzvtj2.z0nek().Count - 1]).z0eek(p0.z0vek(), p0.z0xek());
							}
						}
						else
						{
							z0stk.z0rek(z0wrk().z0eek(p0.z0xek(), Color.Black));
							z0ZzZzmrj2.z0rek(z0ZzZzmrj2.z0crk());
						}
						continue;
					}
					case 3872902567u:
						if (!(text == "picwgoal"))
						{
							break;
						}
						((z0ZzZzrtj)z0rek(typeof(z0ZzZzrtj)))?.z0tek(p0.z0xek());
						continue;
					}
				}
				else if (num2 != 3948894032u)
				{
					if (num2 != 3960223172u)
					{
						if (num2 == 4047624472u && text == "clcfpat")
						{
							goto IL_323f;
						}
					}
					else if (text == "i")
					{
						z0rtk = true;
						if (z0ZzZzmrj2.z0atk)
						{
							z0ZzZzmrj2.z0cek(!p0.z0uek() || p0.z0xek() != 0);
						}
						continue;
					}
				}
				else if (text == "blipuid")
				{
					((z0ZzZzrtj)z0rek(typeof(z0ZzZzrtj)))?.z0eek(z0rek(p0, p1: true));
					continue;
				}
			}
			else
			{
				switch (num2)
				{
				case 4230251284u:
					if (!(text == "titlepg"))
					{
						break;
					}
					z0yek(p0: true);
					continue;
				case 4139617600u:
				{
					if (!(text == "footerr"))
					{
						break;
					}
					z0ZzZzwtj z0ZzZzwtj5 = new z0ZzZzwtj();
					z0ZzZzwtj5.z0eek((z0ZzZznrj)2);
					z0eek(z0ZzZzwtj5);
					z0yek(p0, p1);
					z0ZzZzwtj5.z0tek();
					z0ZzZzwtj5.z0eek(p0: true);
					z0stk = new z0ZzZzmrj();
					continue;
				}
				case 4127999362u:
					if (!(text == "s"))
					{
						break;
					}
					z0rtk = true;
					z0stk.z0oek(p0.z0xek());
					continue;
				case 4141617394u:
				{
					if (!(text == "listtext"))
					{
						break;
					}
					z0rtk = true;
					string text3 = z0rek(p0, p1: true);
					if (text3 != null)
					{
						text3 = text3.Trim();
						if (text3.StartsWith("l"))
						{
							z0gtk = 1;
						}
						else
						{
							z0gtk = 2;
						}
					}
					continue;
				}
				case 4077666505u:
					if (!(text == "v"))
					{
						break;
					}
					z0rtk = true;
					if (z0ZzZzmrj2.z0atk)
					{
						if (p0.z0uek() && p0.z0xek() == 0)
						{
							z0ZzZzmrj2.z0pek(p0: false);
						}
						else
						{
							z0ZzZzmrj2.z0pek(p0: true);
						}
					}
					continue;
				case 4152230356u:
					if (!(text == "super"))
					{
						break;
					}
					z0rtk = true;
					if (z0ZzZzmrj2.z0atk)
					{
						z0ZzZzmrj2.z0rek(!p0.z0uek() || p0.z0xek() != 0);
					}
					continue;
				}
			}
			if (p0.z0iek() == (z0ZzZzpyj)2 && p0.z0yek_jiejie20260327142557())
			{
				z0nek_jiejie20260327142557(p0);
			}
			continue;
			IL_25c1:
			z0rtk = true;
			if (z0ZzZzmrj2.z0atk && p0.z0uek())
			{
				z0ZzZzmrj2.z0eek(z0wrk().z0eek(p0.z0xek(), Color.Empty));
			}
			continue;
			IL_31fb:
			z0rtk = true;
			((z0ZzZzftj)(z0ZzZzvtj)z0rek(typeof(z0ZzZzvtj), p1: false))?.z0rek().z0eek(p0.z0vek(), p0.z0xek());
			continue;
			IL_2f71:
			z0rtk = true;
			z0ZzZzftj[] array6 = z0rek(p0: true);
			z0ZzZzftj z0ZzZzftj4 = null;
			z0ZzZzftj z0ZzZzftj5 = null;
			for (int num8 = array6.Length - 1; num8 >= 0; num8--)
			{
				z0ZzZzftj z0ZzZzftj6 = array6[num8];
				if (!z0ZzZzftj6.z0oek())
				{
					if (z0ZzZzftj4 == null && !(z0ZzZzftj6 is z0ZzZzitj))
					{
						z0ZzZzftj4 = z0ZzZzftj6;
					}
					if (z0ZzZzftj6 is z0ZzZzvtj || z0ZzZzftj6 is z0ZzZzntj)
					{
						z0ZzZzftj5 = z0ZzZzftj6;
						break;
					}
				}
			}
			if (p0.z0vek() == "intbl")
			{
				if (z0ZzZzftj5 == null)
				{
					z0ZzZzvtj z0ZzZzvtj3 = new z0ZzZzvtj();
					((z0ZzZzftj)z0ZzZzvtj3).z0mek = p0.z0lrk();
					z0ZzZzftj4.z0eek(z0ZzZzvtj3);
				}
			}
			else if (p0.z0vek() == "trowd")
			{
				z0ZzZzvtj z0ZzZzvtj4 = null;
				if (z0ZzZzftj5 == null)
				{
					z0ZzZzvtj4 = new z0ZzZzvtj();
					((z0ZzZzftj)z0ZzZzvtj4).z0mek = p0.z0lrk();
					z0ZzZzftj4.z0eek(z0ZzZzvtj4);
				}
				else
				{
					z0ZzZzvtj4 = z0ZzZzftj5 as z0ZzZzvtj;
					if (z0ZzZzvtj4 == null)
					{
						z0ZzZzvtj4 = (z0ZzZzvtj)z0ZzZzftj5.z0eek();
					}
				}
				((z0ZzZzftj)z0ZzZzvtj4).z0rek().Clear();
				z0ZzZzvtj4.z0nek().Clear();
				z0stk.z0yek();
			}
			else
			{
				if (!(p0.z0vek() == "itap"))
				{
					continue;
				}
				z0ZzZzvtj z0ZzZzvtj5 = null;
				if (p0.z0xek() == 0)
				{
					continue;
				}
				if (z0ZzZzftj5 == null)
				{
					z0ZzZzvtj5 = new z0ZzZzvtj();
					((z0ZzZzftj)z0ZzZzvtj5).z0mek = p0.z0lrk();
					z0ZzZzftj4.z0eek(z0ZzZzvtj5);
				}
				else
				{
					z0ZzZzvtj5 = z0ZzZzftj5 as z0ZzZzvtj;
					if (z0ZzZzvtj5 == null)
					{
						z0ZzZzvtj5 = (z0ZzZzvtj)z0ZzZzftj5.z0eek();
					}
				}
				if (p0.z0xek() == z0ZzZzvtj5.z0rek())
				{
					continue;
				}
				if (p0.z0xek() > z0ZzZzvtj5.z0rek())
				{
					z0ZzZzvtj z0ZzZzvtj6 = new z0ZzZzvtj();
					z0ZzZzvtj6.z0oek(p0.z0xek());
					z0ZzZzntj z0ZzZzntj2 = (z0ZzZzntj)z0rek(typeof(z0ZzZzntj), p1: false);
					if (z0ZzZzntj2 == null)
					{
						z0yek(z0ZzZzvtj6);
					}
					else
					{
						z0ZzZzntj2.z0eek(z0ZzZzvtj6);
					}
				}
				else if (p0.z0xek() >= z0ZzZzvtj5.z0rek())
				{
				}
			}
			continue;
			IL_323f:
			z0rtk = true;
			z0ZzZzvtj z0ZzZzvtj7 = (z0ZzZzvtj)z0rek(typeof(z0ZzZzvtj), p1: false);
			if (z0ZzZzvtj7 != null)
			{
				z0ZzZzxrj z0ZzZzxrj2 = null;
				if (z0ZzZzvtj7.z0nek().Count > 0)
				{
					z0ZzZzxrj2 = (z0ZzZzxrj)z0ZzZzvtj7.z0nek()[z0ZzZzvtj7.z0nek().Count - 1];
				}
				if (z0ZzZzxrj2 == null || z0ZzZzxrj2.z0eek("cellx"))
				{
					z0ZzZzxrj2 = new z0ZzZzxrj();
					z0ZzZzvtj7.z0nek().Add(z0ZzZzxrj2);
				}
				z0ZzZzxrj2.z0eek(p0.z0vek(), p0.z0xek());
			}
		}
		if (z0ZzZziyj2.z0tek())
		{
			z0rek(z0ZzZziyj2, p0, z0ZzZzmrj2);
		}
	}

	public void z0iek(string p0)
	{
		z0ktk = p0;
	}
}
