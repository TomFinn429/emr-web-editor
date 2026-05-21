using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using DCSoft;
using DCSoft.Printing;
using DCSoft.WASM;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing.Printing;

namespace zzz;

internal class z0ZzZzioj : z0ZzZzqbj.z0bnk, IDisposable
{
	private int z0yek = -1;

	private bool z0uek;

	[CompilerGenerated]
	private string z0iek;

	public int z0oek = -1;

	public PrintRange z0pek;

	private bool z0mek = true;

	[CompilerGenerated]
	private int z0nek;

	private int z0bek = -1;

	[CompilerGenerated]
	private JumpPrintInfo z0vek;

	public DCPrintMode z0cek;

	public string z0xek;

	public DCBooleanValueHasDefault z0zek = DCBooleanValueHasDefault.Default;

	public int z0lrk = 1;

	private bool z0krk;

	public DCBooleanValueHasDefault z0jrk = DCBooleanValueHasDefault.Default;

	[CompilerGenerated]
	private int z0hrk;

	private bool z0grk;

	public bool z0frk;

	public int z0drk = -1;

	[CompilerGenerated]
	private string z0srk;

	private bool z0ark = true;

	[CompilerGenerated]
	public void z0gkk(JumpPrintInfo p0)
	{
		z0vek = p0;
	}

	[CompilerGenerated]
	public void z0hkk(string p0)
	{
		z0srk = p0;
	}

	public z0ZzZzioj(JsonElement p0, WriterControlForWASM p1)
	{
		if (p0.ValueKind != JsonValueKind.Object)
		{
			z0mek = true;
			return;
		}
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			string name = item.Name;
			if (name == null)
			{
				continue;
			}
			switch (name.ToLower().Trim())
			{
			case "enablefurtheremptyinputfield":
				z0rek(z0ZzZzboj.z0rek(item.Value, p1: false));
				break;
			case "pageindexs":
				if (item.Value.ValueKind == JsonValueKind.String)
				{
					List<int> list = z0ZzZzcoj.z0tek(item.Value.GetString());
					if (list.Count <= 0)
					{
						break;
					}
					string text = string.Empty;
					for (int i = 0; i < list.Count; i++)
					{
						text += list[i];
						if (i < list.Count - 1)
						{
							text += ",";
						}
					}
					z0xek = text;
					z0pek = PrintRange.SomePages;
					z0mek = false;
				}
				else if (item.Value.ValueKind == JsonValueKind.Number)
				{
					z0xek = item.z0yek(0).ToString();
					z0pek = PrintRange.SomePages;
					z0mek = false;
				}
				break;
			case "pageindexfix":
				z0ulk(item.z0yek(0));
				z0mek = false;
				break;
			case "cleanmode":
			{
				JsonElement value2 = item.Value;
				if (value2.ValueKind == JsonValueKind.True)
				{
					z0zek = DCBooleanValueHasDefault.True;
					z0mek = false;
				}
				else if (value2.ValueKind == JsonValueKind.False)
				{
					z0zek = DCBooleanValueHasDefault.False;
					z0mek = false;
				}
				break;
			}
			case "printHeaderfooteratfirstpage":
			{
				JsonElement value = item.Value;
				if (value.ValueKind == JsonValueKind.True)
				{
					z0jrk = DCBooleanValueHasDefault.True;
					z0mek = false;
				}
				else if (value.ValueKind == JsonValueKind.False)
				{
					z0jrk = DCBooleanValueHasDefault.False;
					z0mek = false;
				}
				break;
			}
			case "printrange":
				z0pek = item.z0rek(PrintRange.AllPages);
				z0mek = false;
				break;
			case "printmode":
				z0cek = item.z0rek(DCPrintMode.Normal);
				z0mek = false;
				break;
			case "printtablecellborder":
				z0tlk(item.z0yek(p1: true));
				break;
			case "collate":
				z0frk = item.z0yek(p1: false);
				z0mek = false;
				break;
			case "copies":
				z0lrk = item.z0yek(1);
				z0mek = false;
				break;
			case "frompage":
				z0oek = item.z0yek(-1);
				z0mek = false;
				break;
			case "topage":
				z0drk = item.z0yek(-1);
				z0mek = false;
				break;
			case "specifypageindexs":
				z0xek = item.Value.GetString();
				z0mek = false;
				break;
			case "bodylayoutoffset":
				z0clk(item.z0yek(-1));
				z0mek = false;
				break;
			case "jumpprintstartelementid":
				z0plk(item.Value.GetString());
				z0mek = false;
				break;
			case "jumpprintendelementid":
				z0hkk(item.Value.GetString());
				z0mek = false;
				break;
			case "jumpprint":
				z0gkk(new JumpPrintInfo());
				z0ilk().Enabled = true;
				z0ilk().Mode = JumpPrintMode.Normal;
				foreach (JsonProperty item2 in item.Value.EnumerateObject())
				{
					switch (item2.Name?.ToLower().Trim())
					{
					case "pageindex":
						z0ilk().PageIndex = item2.z0yek(-1);
						z0mek = false;
						break;
					case "position":
						z0ilk().Position = item2.z0yek(0);
						z0mek = false;
						break;
					case "endpageindex":
						z0ilk().EndPageIndex = item2.z0yek(-1);
						z0mek = false;
						break;
					case "endposition":
						z0ilk().EndPosition = item2.z0yek(-1);
						z0mek = false;
						break;
					case "mode":
						z0ilk().Mode = item2.z0rek(JumpPrintMode.Normal);
						z0mek = false;
						break;
					case "startelement":
						if (item2.Value.ValueKind == JsonValueKind.Number)
						{
							z0ilk().z0rek(p1.z0vek(item2.Value.GetInt32()));
							z0mek = false;
						}
						else if (item.Value.ValueKind == JsonValueKind.String)
						{
							z0ilk().z0rek(p1.z0mrk().z0srk(item.Value.GetString()));
							z0mek = false;
						}
						break;
					case "endelement":
						if (item2.Value.ValueKind == JsonValueKind.Number)
						{
							z0ilk().z0eek(p1.z0vek(item2.Value.GetInt32()));
							z0mek = false;
						}
						else if (item.Value.ValueKind == JsonValueKind.String)
						{
							z0ilk().z0eek(p1.z0mrk().z0srk(item2.Value.GetString()));
							z0mek = false;
						}
						break;
					case "endpositionmode":
						z0ilk().EndPositionMode = item2.z0rek(JumpPrintPositionMode.ElementBottom);
						z0mek = false;
						break;
					case "startpositionmode":
						z0ilk().StartPositionMode = item2.z0rek(JumpPrintPositionMode.ElementTop);
						z0mek = false;
						break;
					case "startlinenumber":
						z0yek = item2.z0yek(-1);
						break;
					case "endlinenumber":
						z0bek = item2.z0yek(-1);
						break;
					}
				}
				break;
			case "forceprintheaderfooter":
				z0grk = item.z0yek(p1: false);
				z0mek = false;
				break;
			case "insertlasttablerowtopagebottom":
				z0krk = item.z0yek(p1: false);
				z0mek = false;
				break;
			}
		}
	}

	public static int z0eek(string p0, List<int> p1, int p2)
	{
		int num = 0;
		if (p0 != null && p0.Length > 0)
		{
			string[] array = p0.Split(',');
			int num2 = 0;
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text.IndexOf('-') > 0)
				{
					string[] array3 = text.Split('-');
					int num3 = 0;
					int num4 = 0;
					if (int.TryParse(array3[0], out num3) && int.TryParse(array3[1], out num4))
					{
						for (int j = Math.Max(1, num3); j <= Math.Min(num4, p2); j++)
						{
							p1.Add(j - 1);
							num++;
						}
					}
				}
				else if (int.TryParse(text, out num2) && num2 >= 1 && num2 <= p2)
				{
					p1.Add(num2 - 1);
					num++;
				}
			}
		}
		return num;
	}

	[CompilerGenerated]
	public string z0jkk()
	{
		return z0iek;
	}

	public void z0kkk(bool p0)
	{
		z0grk = p0;
	}

	[CompilerGenerated]
	public int z0lkk()
	{
		return z0nek;
	}

	public void z0rek(bool p0)
	{
		z0uek = p0;
	}

	public z0ZzZzlrj z0zlk()
	{
		try
		{
			z0ZzZzlrj obj = new z0ZzZzlrj();
			obj.z0rek(z0ilk());
			obj.z0rek(z0pek);
			return obj;
		}
		catch (Exception ex)
		{
			z0ZzZzroj.z0eek("CreateStdOptions", ex.Message, ex.ToString(), 0);
			return null;
		}
	}

	[DevAPI("2023-6-1", "第五代.GetRuntimePageIndexs", "根据打印设置获得实际要打印的页码数组")]
	public int[] z0xlk(int p0, int p1, z0ZzZzclh p2)
	{
		try
		{
			List<int> list = new List<int>();
			if (z0pek == PrintRange.SomePages)
			{
				if (z0xek != null && z0xek.Length > 0)
				{
					z0eek(z0xek, list, p0);
				}
				else if (z0oek >= 0 && z0drk >= 0)
				{
					for (int i = z0oek; i <= Math.Min(p0, z0drk); i++)
					{
						list.Add(i - 1);
					}
				}
			}
			else if (z0pek == PrintRange.Selection)
			{
				List<int> list2 = z0ZzZzafh.z0yek(p2.z0rek());
				if (list2 == null || list2.Count == 0)
				{
					return null;
				}
				list.AddRange(list2);
			}
			else if (z0pek == PrintRange.AllPages)
			{
				for (int j = 0; j < p0; j++)
				{
					list.Add(j);
				}
			}
			else if (z0pek == PrintRange.CurrentPage)
			{
				list.Add(p1);
			}
			if (z0cek == DCPrintMode.EvenPage)
			{
				for (int num = list.Count - 1; num >= 0; num--)
				{
					if (list[num] % 2 == 1)
					{
						list.RemoveAt(num);
					}
				}
			}
			else if (z0cek == DCPrintMode.OddPage)
			{
				for (int num2 = list.Count - 1; num2 >= 0; num2--)
				{
					if (list[num2] % 2 == 0)
					{
						list.RemoveAt(num2);
					}
				}
			}
			if (z0lrk > 1)
			{
				List<int> list3 = new List<int>();
				if (z0frk)
				{
					for (int k = 0; k < z0lrk; k++)
					{
						list3.AddRange(list);
					}
				}
				else
				{
					for (int l = 0; l < list.Count; l++)
					{
						for (int m = 0; m < z0lrk; m++)
						{
							list3.Add(list[l]);
						}
					}
				}
				return list3.ToArray();
			}
			return list.ToArray();
		}
		catch (Exception ex)
		{
			z0ZzZzroj.z0eek("GetRuntimePageIndexs", ex.Message, ex.ToString(), 0);
			return null;
		}
	}

	[CompilerGenerated]
	public void z0clk(int p0)
	{
		z0hrk = p0;
	}

	public bool z0vlk()
	{
		return z0ark;
	}

	public bool z0blk()
	{
		return z0mek;
	}

	[CompilerGenerated]
	public int z0nlk()
	{
		return z0hrk;
	}

	[CompilerGenerated]
	public string z0mlk()
	{
		return z0srk;
	}

	[CompilerGenerated]
	public void z0plk(string p0)
	{
		z0iek = p0;
	}

	public void z0olk(XTextDocument p0)
	{
		if (z0ilk() == null || p0 == null)
		{
			return;
		}
		if (z0yek >= 0 && z0ilk().PageIndex >= 0)
		{
			z0ZzZzzlh z0ZzZzzlh2 = WriterControlForWASM.z0bek(p0, z0ilk().PageIndex, z0yek);
			if (z0ZzZzzlh2 != null)
			{
				z0ilk().z0rek(((XTextElementList)z0ZzZzzlh2).z0grk());
			}
		}
		if (z0bek >= 0 && z0ilk().EndPageIndex >= 0)
		{
			z0ZzZzzlh z0ZzZzzlh3 = WriterControlForWASM.z0bek(p0, z0ilk().EndPageIndex, z0bek);
			if (z0ZzZzzlh3 != null)
			{
				z0ilk().z0eek(((XTextElementList)z0ZzZzzlh3).z0grk());
			}
		}
	}

	[CompilerGenerated]
	public JumpPrintInfo z0ilk()
	{
		return z0vek;
	}

	public void Dispose()
	{
		z0xek = null;
		if (z0ilk() != null)
		{
			z0ilk().z0uek();
			z0gkk(null);
		}
		z0hkk(null);
		z0plk(null);
	}

	[CompilerGenerated]
	public void z0ulk(int p0)
	{
		z0nek = p0;
	}

	public bool z0ylk()
	{
		return z0grk;
	}

	public bool z0rek()
	{
		return z0uek;
	}

	public bool z0tek()
	{
		return z0krk;
	}

	public void z0tek(bool p0)
	{
		z0krk = p0;
	}

	public void z0tlk(bool p0)
	{
		z0ark = p0;
	}
}
