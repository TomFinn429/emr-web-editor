using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WASM;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzejh : IDisposable
{
	internal List<string> z0oek;

	private z0ZzZzgbj z0pek = new z0ZzZzgbj();

	private z0ZzZzrjh z0mek;

	private static readonly string z0nek = "\r\ninput.switch{\r\n    outline: none;\r\n    appearance: none;\r\n    -webkit-appearance: none;\r\n    -moz-appearance: none;\r\n    position: relative;\r\n    width: 40px;\r\n    height: 20px;\r\n    background: #ccc;\r\n    border-radius: 10px;\r\n    transition: border-color .3s, background-color .3s;\r\n}\r\ninput.switch::after {\r\n    content: '';\r\n    display: inline-block;\r\n    width: 1rem;\r\n    height:1rem;\r\n    border-radius: 50%;\r\n    background: #fff;\r\n    box-shadow: 0, 0, 2px, #999;\r\n    transition:.4s;\r\n    top: 2px;\r\n    position: absolute;\r\n    left: 2px;\r\n}\r\ninput.switch:checked {\r\n    background: rgb(19, 206, 102);\r\n}\r\ninput.switch:checked::after {\r\n    content: '';\r\n    position: absolute;\r\n    left: 55%;\r\n    top: 2px;\r\n}\r\n.selectTdClass{background-color:#edf5fa}";

	private static readonly string z0bek = "\r\n        ol,ul {padding-inline-start: inherit !important;list-style-position: inside !important;}\r\n        ul[dcparagraphlistformat='BulletedList'] li,ul[dcparagraphlistformat='BulletedListBlock'] li,ul[dcparagraphlistformat='BulletedListDiamond'] li,ul[dcparagraphlistformat='BulletedListCheck'] li,ul[dcparagraphlistformat='BulletedListRightArrow'] li,ul[dcparagraphlistformat='BulletedListHollowStar'] li{list-style-type: none;}\r\n        ul[dcparagraphlistformat='BulletedList'] li:before,ul[dcparagraphlistformat='BulletedListBlock'] li:before,ul[dcparagraphlistformat='BulletedListDiamond'] li:before,ul[dcparagraphlistformat='BulletedListCheck'] li:before,ul[dcparagraphlistformat='BulletedListRightArrow'] li:before,ul[dcparagraphlistformat='BulletedListHollowStar'] li:before{font-family: Wingdings;font-size: 16px;}\r\n        ul[dcparagraphlistformat='BulletedList'] li:before {content: '\uf06c ';}ul[dcparagraphlistformat='BulletedListBlock'] li:before {content: '\uf06e ';}ul[dcparagraphlistformat='BulletedListDiamond'] li:before {content: '\uf075 ';}ul[dcparagraphlistformat='BulletedListCheck'] li:before {content: '\uf0fc ';}ul[dcparagraphlistformat='BulletedListRightArrow'] li:before {content: '\uf0d8 ';}ul[dcparagraphlistformat='BulletedListHollowStar'] li:before {content: '\uf0b2 ';}";

	private static readonly string z0vek = "\r\n.leftline{white-space:nowrap;word-break:keep-all;text-align:justify;text-justify:distribute-all-lines;layout-grid:char loose 10pt none;justify-content:space-between;}\r\n.centerline{white-space:nowrap;word-break:keep-all;text-align:center}\r\n.rightline{white-space:nowrap;word-break:keep-all;text-align:right}\r\n.justifyline{white-space:nowrap;word-break:keep-all;text-align:justify;text-justify:distribute-all-lines;layout-grid:char loose 10pt none;justify-content:space-between;}\r\n.distributeline{white-space:nowrap;word-break:keep-all;text-align:justify;text-justify:distribute-all-lines;layout-grid:char loose 10pt none;display:flex;justify-content:space-between;}";

	public static readonly string z0cek = "DCNew";

	private List<int> z0xek;

	private static readonly string z0zek = "\r\n        img::selection {background: transparent;};\r\n        img::-moz-selection {background: transparent;}\r\n        img::-webkit-selection { background: transparent;}";

	private Dictionary<XTextDocument, string> z0lrk = new Dictionary<XTextDocument, string>();

	private static readonly string z0krk = "<!--$$contentstyle$@-->";

	private string z0jrk;

	public static readonly string z0hrk = "DCLogicDeleted";

	internal DateTime z0grk = DateTime.MinValue;

	private int z0rek(float p0)
	{
		if (p0 <= 0f)
		{
			return 0;
		}
		if (p0 == 1f)
		{
			return 1;
		}
		int num = (int)z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, GraphicsUnit.Pixel);
		if (num < 1)
		{
			num = 1;
		}
		return num;
	}

	private void z0rek(XTextDocument p0, XTextDocument p1, int p2, z0ZzZzwrj p3)
	{
		z0ZzZzgbj obj = z0tek();
		int num = z0mek.z0uek(p0.z0xyk().Width);
		z0mek.z0rek(p2);
		z0mek.z0cek("div");
		z0mek.z0uek("id", "divDocumentBody_" + p2);
		z0mek.z0rek(typeof(XTextDocumentBodyElement));
		if (!z0uek().ForPrint)
		{
			z0mek.z0uek("dcsave", "1");
		}
		((z0ZzZzfjh)z0mek).z0oek();
		if (!obj.ShowPageBorderLine)
		{
			z0mek.z0yek("outline", "none");
		}
		string fontName = p0.z0gnk().Default.FontName;
		if (fontName != null && fontName.Length > 0)
		{
			z0mek.z0yek("font-family", fontName);
		}
		if (!obj.ShowMainDocumentBodyWhenMultiDocument && p2 == 0)
		{
			z0mek.z0yek("display", "none");
			if (p1.z0ipk() != null && p1.z0ipk().z0frk() != null)
			{
				p1.z0ipk().z0frk().AllowSave = false;
			}
		}
		if (!obj.z0rek())
		{
			z0rek(p1, p3);
		}
		else
		{
			z0mek.z0yek("width", num + "px");
		}
		if (obj.MultiDocument && p1.z0ipk().z0frk() != null)
		{
			if (p1.z0ipk().z0frk().BorderColor.A > 0)
			{
				z0mek.z0yek("border", z0mek.z0rek(p1.z0ipk().z0frk().BorderColor));
			}
			if (p1.z0ipk().z0frk().BackColor.A > 0)
			{
				z0mek.z0yek("background-color", z0mek.z0uek(p1.z0ipk().z0frk().BackColor));
			}
			if (p1.z0ipk().z0frk().SubDocumentSpacing > 0f)
			{
				z0mek.z0yek("padding-bottom", z0mek.z0tek(p1.z0ipk().z0frk().SubDocumentSpacing) + "px");
			}
		}
		z0mek.z0wrk();
		p1.z0bek(p3);
		if (p3 == null)
		{
			z0mek.z0rek(z0ZzZzndh.z0cek);
			z0mek.z0rek(z0ZzZzbdh.z0xek);
		}
		else
		{
			float num2 = 0f;
			if (p3.z0nrk())
			{
				XTextElement obj2 = p3.z0uek()[0];
				z0mek.z0rek(z0ZzZzndh.z0eek(p3.z0krk()));
				XTextTableElement p4 = obj2.z0gr();
				z0mek.z0rek(p4);
				num2 = p3.z0krk().z0iek();
			}
			z0mek.z0rek(new z0ZzZzndh((int)p3.z0bek(), (int)p3.z0irk(), (int)p3.z0oek(), (int)p3.z0xek()));
			z0mek.z0rek(new z0ZzZzbdh(p3.z0bek(), p3.z0irk(), p3.z0oek(), p3.z0urk() - num2));
		}
		if (p1.z0xyk().Attributes != null && p1.z0xyk().Attributes.Count > 0)
		{
			z0mek.z0rek(p1.z0xyk().Attributes);
		}
		z0mek.z0rek(p1.z0xyk());
		((z0ZzZzfjh)z0mek).z0xek();
	}

	public void z0rek(z0ZzZzgbj p0)
	{
		z0pek = p0;
	}

	public string z0rek(z0ZzZzclh p0, bool p1, z0ZzZzuoj p2 = null)
	{
		z0ZzZzgbj z0ZzZzgbj2 = z0tek();
		XTextDocument xTextDocument = null;
		if (p0 != null && p0.Count > 0)
		{
			xTextDocument = p0.z0rek();
		}
		z0ZzZzgbj2.ContentRenderMode = (z0ZzZzfbj)3;
		z0ZzZzgbj2.ForPrint = true;
		z0mek = z0rek(xTextDocument, p2);
		if (p0 == null || p0.Count == 0)
		{
			return "<html><body><b>" + z0ZzZziok.z0gyk() + "</b></body></html>";
		}
		z0mek.z0kw();
		z0mek.Options.BackgroundTextOutputMode = DCBackgroundTextOutputMode.Output;
		z0mek.Options.MultiPage = true;
		z0mek.z0hw();
		z0mek.z0cek("html");
		z0mek.z0uek("flag", "pagehtml");
		z0lrk.Clear();
		z0rek(p0);
		z0iek(xTextDocument);
		_ = 4;
		z0ZzZzclh z0ZzZzclh2 = new z0ZzZzclh();
		if (z0ZzZzgbj2.MultiDocument)
		{
			z0ZzZzclh2.AddRange(p0);
		}
		else
		{
			z0ZzZzclh2.Add(p0[0]);
		}
		z0ZzZzerj z0ZzZzerj2 = new z0ZzZzerj();
		z0ZzZzxcj.z0rek();
		foreach (XTextDocument item in z0ZzZzclh2)
		{
			item.z0qtk().Printing = true;
			item.z0srk(p0: false);
			z0ZzZzwrj z0ZzZzwrj2 = item.z0suk().z0tek();
			foreach (z0ZzZzwrj item2 in item.z0suk())
			{
				if (item2 == z0ZzZzwrj2)
				{
					if (!item.z0cpk())
					{
						z0ZzZzerj2.Add(item2);
					}
				}
				else
				{
					z0ZzZzerj2.Add(item2);
				}
			}
		}
		z0mek.z0cek("center");
		z0mek.z0uek("id", "dcRootCenter");
		z0ZzZzerj z0ZzZzerj3 = null;
		if (z0xek != null && z0xek.Count > 0)
		{
			z0ZzZzerj3 = new z0ZzZzerj();
			foreach (int item3 in z0xek)
			{
				if (item3 >= 0 && item3 < z0ZzZzerj2.Count)
				{
					z0ZzZzerj3.Add(z0ZzZzerj2[item3]);
				}
			}
		}
		else
		{
			z0ZzZzerj3 = z0ZzZzerj2;
		}
		z0ZzZzwrj z0ZzZzwrj3 = ((z0ZzZzerj3 != null && z0ZzZzerj3.Count > 0) ? z0ZzZzerj3[0] : null);
		z0ZzZzwrj z0ZzZzwrj4 = z0ZzZzerj3.z0tek();
		bool flag = ((XTextDocument)z0ZzZzwrj3.z0srk())?.PageSettings.z0ork() ?? false;
		foreach (z0ZzZzwrj item4 in z0ZzZzerj3)
		{
			XTextDocument xTextDocument2 = (XTextDocument)item4.z0srk();
			if (xTextDocument2 == null)
			{
				continue;
			}
			bool num = xTextDocument2.PageSettings.z0ork() != flag;
			z0ZzZzarj z0ZzZzarj2 = new z0ZzZzarj(item4, p1: true);
			xTextDocument2.z0lrk(xTextDocument2.z0suk().IndexOf(item4));
			z0mek.z0tek(z0ZzZzerj3.IndexOf(item4));
			if (z0uek().MultiDocument)
			{
				item4.z0eek(z0ZzZzerj2.IndexOf(item4) + 1);
			}
			z0mek.z0rek(item4);
			z0mek.z0yek(item4 == z0ZzZzwrj4);
			if (item4 != z0ZzZzwrj3)
			{
				z0mek.z0cek("div");
				z0mek.z0uek("name", "dcHiddenElementForPrint");
				z0mek.z0lrk("hiddenforprint");
				z0mek.z0uek("style", "height:" + z0ZzZzgbj2.PixelPageSpacing + "px");
				((z0ZzZzfjh)z0mek).z0xek();
			}
			int num2 = z0mek.z0uek(xTextDocument2.z0xyk().Width);
			float num3 = 0f;
			z0mek.z0cek("div");
			z0mek.z0uek("pageindex", z0ZzZzerj2.IndexOf(item4).ToString());
			z0mek.z0lrk("dcpageforprint");
			((z0ZzZzfjh)z0mek).z0oek();
			z0mek.z0yek("page-break-after", "always");
			z0mek.z0yek("page-break-inside", "avoid");
			if (num)
			{
				z0mek.z0yek("transform", "rotate(90deg)");
			}
			((z0ZzZzfjh)z0mek).z0zek();
			z0tek(xTextDocument2, item4);
			if (z0ZzZzarj2.z0zek())
			{
				z0mek.z0uek("hasgutter", "1");
			}
			z0mek.z0cek("tr");
			z0mek.z0uek("dctype", "dcframe");
			z0mek.z0uek("valign", "top");
			if (!p1)
			{
				z0mek.z0uek("height", z0mek.z0uek(xTextDocument2.PageSettings.z0qrk()) + "px");
			}
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			string text = "none";
			if (item4.z0trk().z0otk())
			{
				text = "1px dashed black";
			}
			if (!p1)
			{
				if (z0ZzZzarj2.z0zek() && !item4.z0ark())
				{
					if (xTextDocument2.PageSettings.z0nek())
					{
						if (z0ZzZzarj2.z0rek() == DCGutterStyle.Left)
						{
							flag2 = !item4.z0cek();
							flag3 = !flag2;
						}
						else if (z0ZzZzarj2.z0rek() == DCGutterStyle.Right)
						{
							flag2 = item4.z0cek();
							flag3 = !flag2;
						}
						else if (z0ZzZzarj2.z0rek() == DCGutterStyle.Top)
						{
							flag4 = !item4.z0cek();
							flag5 = !flag4;
						}
					}
					else if (z0ZzZzarj2.z0rek() == DCGutterStyle.Left)
					{
						flag2 = true;
						flag3 = false;
					}
					else if (z0ZzZzarj2.z0rek() == DCGutterStyle.Right)
					{
						flag2 = false;
						flag3 = true;
					}
					else if (z0ZzZzarj2.z0rek() == DCGutterStyle.Top)
					{
						flag4 = true;
						flag5 = false;
					}
				}
				z0mek.z0cek("td");
				z0mek.z0uek("dctype", "dcframe");
				num3 = z0mek.z0uek(z0ZzZzarj2.z0bek());
				if (flag2)
				{
					num3 = z0mek.z0uek(z0ZzZzarj2.z0uek());
					z0mek.z0uek("part", "leftgutter");
				}
				else
				{
					z0mek.z0uek("part", "leftmargin");
				}
				z0mek.z0uek("name", "dcHiddenElementForPrint");
				z0mek.z0uek("width", num3 + "px");
				z0mek.z0uek("style", "width:" + num3 + "px");
				z0mek.z0cek("div");
				z0mek.z0uek("style", "width:" + Convert.ToString(num3 - 1f) + "px;height:10px");
				((z0ZzZzfjh)z0mek).z0xek();
				((z0ZzZzfjh)z0mek).z0xek();
			}
			z0mek.z0cek("td");
			z0mek.z0uek("dctype", "dcframe");
			z0mek.z0uek("width", z0mek.z0uek(item4.z0oek()) + "px");
			z0mek.z0uek("bodywidth", num2 + "px");
			z0mek.z0uek("id", "dcGlobalRootElement");
			((z0ZzZzfjh)z0mek).z0oek();
			_ = z0ZzZzgbj2.AutoLine;
			z0mek.z0yek("padding-bottom", "3px");
			((z0ZzZzfjh)z0mek).z0zek();
			z0mek.z0uek("valign", "top");
			z0mek.z0rek(z0ZzZzndh.z0cek);
			if (!p1 && flag4)
			{
				z0rek(xTextDocument2, item4, p2: true, z0ZzZzarj2.z0uek());
			}
			else
			{
				z0rek(xTextDocument2, item4, p2: true, z0ZzZzarj2.z0vek());
			}
			z0mek.z0cek("div");
			z0mek.z0uek("dcpart", "pagecontent");
			((z0ZzZzfjh)z0mek).z0oek();
			z0mek.z0yek("overflow", "VISIBLE");
			z0mek.z0yek("width", z0mek.z0uek(item4.z0oek()) + "px");
			float num4 = Math.Max(15f, z0ZzZzarj2.z0vek()) + Math.Max(15f, z0ZzZzarj2.z0tek());
			num4 = z0ZzZzarj2.z0nek() - num4;
			z0mek.z0yek("height", z0mek.z0uek(num4) + "px");
			if (flag2)
			{
				z0mek.z0yek("padding-left", z0mek.z0uek(item4.z0hrk()) + "px");
				z0mek.z0yek("border-left", text);
			}
			else if (flag4)
			{
				z0mek.z0yek("padding-top", z0mek.z0uek(item4.z0trk().z0atk()) + "px");
				z0mek.z0yek("border-top", text);
			}
			else if (flag3)
			{
				z0mek.z0yek("padding-right", z0mek.z0uek(item4.z0ork()) + "px");
				z0mek.z0yek("border-right", text);
			}
			else if (flag5)
			{
				z0mek.z0yek("padding-bottom", z0mek.z0uek(item4.z0trk().z0stk()) + "px");
				z0mek.z0yek("border-bottom", text);
			}
			((z0ZzZzfjh)z0mek).z0zek();
			if (!item4.z0ark())
			{
				if (xTextDocument2.z0suk().z0iek() == item4 && xTextDocument2.PageSettings.z0rrk())
				{
					z0rek(xTextDocument2, xTextDocument2.z0cyk(), p2: true, p1, z0ZzZzerj2.IndexOf(item4), item4, flag4, text);
				}
				else
				{
					z0rek(xTextDocument2, xTextDocument2.z0pyk(), p2: true, p1, z0ZzZzerj2.IndexOf(item4), item4, flag4, text);
				}
			}
			bool flag6 = false;
			if (!item4.z0ark() && z0ZzZzgbj2.ContentRenderMode == (z0ZzZzfbj)3)
			{
				z0ZzZzvpk z0ZzZzvpk2 = xTextDocument.PageSettings.z0krk_jiejie20260327142557();
				if (z0ZzZzvpk2 != null && z0ZzZzvpk2.HasVisibleBorder && z0ZzZzvpk2.z0eek() == PageBorderRangeTypes.Body)
				{
					flag6 = true;
					z0mek.z0cek("div");
					((z0ZzZzfjh)z0mek).z0oek();
					z0mek.z0yek(z0ZzZzvpk2.BorderLeft, z0ZzZzvpk2.BorderTop, z0ZzZzvpk2.BorderRight, z0ZzZzvpk2.BorderBottom, z0ZzZzvpk2.BorderColor, z0rek(z0ZzZzvpk2.BorderWidth), z0ZzZzvpk2.BorderStyle);
					((z0ZzZzfjh)z0mek).z0zek();
				}
			}
			z0mek.z0cek("div");
			z0mek.z0uek("id", "divAllContainer");
			((z0ZzZzfjh)z0mek).z0oek();
			if (xTextDocument2.z0lik().z0fi())
			{
				z0mek.z0yek("height", z0mek.z0uek(item4.z0urk() - 4f) + "px");
			}
			((z0ZzZzfjh)z0mek).z0zek();
			if (!item4.z0ark())
			{
				z0rek(xTextDocument, xTextDocument2, 0, item4);
			}
			XTextDocumentContentElement xTextDocumentContentElement = null;
			xTextDocumentContentElement = ((xTextDocument2.z0suk().z0iek() != item4 || !xTextDocument2.PageSettings.z0rrk()) ? ((XTextDocumentContentElement)xTextDocument2.z0lik()) : ((XTextDocumentContentElement)xTextDocument2.z0guk()));
			((z0ZzZzfjh)z0mek).z0xek();
			if (xTextDocumentContentElement.z0fi() || flag5)
			{
				float num5 = xTextDocument2.PageSettings.z0frk();
				num5 = ((!(num5 > xTextDocument2.z0lik().Height)) ? 0f : (num5 - xTextDocument2.z0lik().Height - 10f));
				num5 = Math.Max(num5, 8f);
				z0mek.z0cek("div");
				z0mek.z0uek("style", "height:" + z0mek.z0uek(num5) + "px;width:" + num2 + "px");
				((z0ZzZzfjh)z0mek).z0xek();
			}
			if (flag6)
			{
				((z0ZzZzfjh)z0mek).z0xek();
			}
			if (!item4.z0ark() && (xTextDocumentContentElement.z0fi() || flag5))
			{
				z0mek.z0rek(z0ZzZzndh.z0cek);
				z0rek(xTextDocument2, xTextDocumentContentElement, p2: true, p1, z0ZzZzerj2.IndexOf(item4), item4, flag5, text);
			}
			((z0ZzZzfjh)z0mek).z0xek();
			((z0ZzZzfjh)z0mek).z0xek();
			z0mek.z0cek("td");
			z0mek.z0uek("dctype", "dcframe");
			z0mek.z0uek("name", "dcHiddenElementForPrint");
			if (flag3)
			{
				z0mek.z0uek("width", z0mek.z0uek(z0ZzZzarj2.z0uek()) + "px");
				z0mek.z0uek("part", "rightgutter");
				z0mek.z0cek("div");
				z0mek.z0uek("style", "width:" + z0mek.z0uek(z0ZzZzarj2.z0uek()) + "px;height:10px");
				((z0ZzZzfjh)z0mek).z0xek();
			}
			else
			{
				z0mek.z0uek("width", z0mek.z0uek(z0ZzZzarj2.z0cek()) + "px");
				z0mek.z0uek("part", "rightmargin");
				z0mek.z0cek("div");
				z0mek.z0uek("style", "width:" + z0mek.z0uek(z0ZzZzarj2.z0cek()) + "px;height:10px");
				((z0ZzZzfjh)z0mek).z0xek();
			}
			((z0ZzZzfjh)z0mek).z0xek();
			((z0ZzZzfjh)z0mek).z0xek();
			((z0ZzZzfjh)z0mek).z0xek();
			((z0ZzZzfjh)z0mek).z0xek();
		}
		((z0ZzZzfjh)z0mek).z0xek();
		if (z0mek.z0yrk != null && z0mek.z0yrk.Count > 0)
		{
			z0mek.z0cek("input");
			z0mek.z0uek("style", "display:none");
			z0mek.z0uek("id", "dchiddeninfoforcorcoordinates");
			z0mek.z0uek("class", "dchiddeninfoforcorcoordinates");
			z0mek.z0uek("value", z0ZzZztwh.z0tek(z0mek.z0yrk.ToJsonString()));
			z0mek.z0yrk();
		}
		((z0ZzZzfjh)z0mek).z0xek();
		((z0ZzZzfjh)z0mek).z0xek();
		((z0ZzZzfjh)z0mek).z0iek();
		if (p2 == null)
		{
			string text2 = z0mek.z0bek();
			if (z0mek.Options.UseClassAttribute)
			{
				string p3 = z0mek.z0srk();
				text2 = z0rek(text2, p3);
			}
			z0mek.z0zq();
			return text2;
		}
		p2.Flush();
		if (z0mek.Options.UseClassAttribute)
		{
			string text3 = z0mek.z0srk();
			p2.Write("<style id='dccustomcontentstyle'>" + text3 + "</style>");
		}
		z0mek.z0zq();
		return null;
	}

	private void z0rek(XTextDocument p0, XTextDocumentContentElement p1, bool p2, bool p3, int p4, z0ZzZzwrj p5, bool p6 = false, string p7 = null)
	{
		z0ZzZzgbj z0ZzZzgbj2 = z0tek();
		int num = z0mek.z0uek(p0.z0xyk().Width);
		z0mek.z0rek(0);
		string p8 = "div" + p1.GetType().Name;
		bool flag = p1 is XTextDocumentHeaderElement || p1 is XTextDocumentHeaderForFirstPageElement;
		bool flag2 = false;
		z0mek.z0cek("div");
		z0mek.z0uek("id", p8);
		z0mek.z0uek("pageindex", p4.ToString());
		z0mek.z0rek(p1.GetType());
		if (p1 is XTextDocumentFooterElement)
		{
			z0mek.z0uek("title", z0ZzZziok.z0kuk());
		}
		else if (p1 is XTextDocumentFooterForFirstPageElement)
		{
			z0mek.z0uek("title", z0ZzZziok.z0vek());
		}
		else if (p1 is XTextDocumentHeaderElement)
		{
			z0mek.z0uek("title", z0ZzZziok.z0eok());
		}
		else if (p1 is XTextDocumentHeaderForFirstPageElement)
		{
			z0mek.z0uek("title", z0ZzZziok.z0nyk());
		}
		((z0ZzZzfjh)z0mek).z0oek();
		if (p0.PageSettings.z0urk() != null && p0.PageSettings.z0urk().Length > 0)
		{
			bool flag3 = Array.IndexOf(p0.PageSettings.z0urk().Split(','), (p4 + 1).ToString()) >= 0;
			if (z0uek().ForPrint && flag3)
			{
				z0mek.z0yek("opacity", "0");
			}
		}
		if (!z0ZzZzgbj2.ForPrint && p0.PageSettings.z0rrk() && (p1 is XTextDocumentFooterElement || p1 is XTextDocumentHeaderElement))
		{
			z0mek.z0yek("display", "none");
		}
		else if (!(p1 is XTextDocumentFooterElement) && !(p1 is XTextDocumentFooterForFirstPageElement) && z0mek.Options.MultiPage)
		{
			float p9 = Math.Max(p1.Height, p0.PageSettings.z0bek() - p0.PageSettings.z0atk());
			float num2 = z0mek.z0uek(p9);
			bool flag4 = p0.z0iu().ShowHeaderBottomLine;
			if (p0.z0ipk() != null && p0.z0ipk().ShowHeaderBottomLine != DCBooleanValue.Inherit)
			{
				flag4 = p0.z0ipk().ShowHeaderBottomLine == DCBooleanValue.True;
			}
			if (flag4 && ((XTextContainerElement)p0.z0pyk()).z0xek() >= 2)
			{
				float headerBottomLineWidth = p0.z0iu().HeaderBottomLineWidth;
				if (headerBottomLineWidth > 1f)
				{
					num2 = headerBottomLineWidth - 1f + num2;
				}
			}
			z0mek.z0yek("height", num2 + "px");
		}
		if (false || z0ZzZzgbj2.z0rek())
		{
			z0mek.z0yek("width", num + "px");
		}
		if (z0ZzZzgbj2.AutoLine)
		{
			string text = z0yek(p0, p5);
			if (text != null && text.Length > 0)
			{
				z0mek.z0uek(text, p1: false);
				z0mek.z0yek("background-repeat", "repeat");
				z0mek.z0yek("background-attachment", "scroll");
			}
		}
		z0mek.z0yek("margin-bottom", "2px");
		((z0ZzZzfjh)z0mek).z0zek();
		z0mek.z0cek("div");
		((z0ZzZzfjh)z0mek).z0oek();
		DocumentViewOptions documentViewOptions = p0.z0iu();
		bool flag5 = documentViewOptions.ShowHeaderBottomLine;
		if (p0.z0ipk() != null && p0.z0ipk().ShowHeaderBottomLine != DCBooleanValue.Inherit)
		{
			flag5 = p0.z0ipk().ShowHeaderBottomLine == DCBooleanValue.True;
		}
		if (flag && p1.z0fi() && flag5)
		{
			z0mek.z0yek("border-bottom", documentViewOptions.HeaderBottomLineWidth + "px solid #888888");
		}
		if (!flag2 && flag && p3)
		{
			z0mek.z0yek("height", z0mek.z0uek(p1.Height) + "px");
		}
		((z0ZzZzfjh)z0mek).z0zek();
		if (flag2)
		{
			z0mek.z0uek(p1);
		}
		else
		{
			bool forPrint = z0mek.Options.ForPrint;
			if (!flag2)
			{
				z0mek.Options.ForPrint = true;
			}
			if (!z0mek.Options.ForPrint || (!(p1 is XTextDocumentFooterElement) && !(p1 is XTextDocumentFooterForFirstPageElement)) || p1.z0fi())
			{
				z0mek.z0uek(p1);
			}
			z0mek.Options.ForPrint = forPrint;
		}
		((z0ZzZzfjh)z0mek).z0xek();
		((z0ZzZzfjh)z0mek).z0xek();
	}

	internal string z0rek(XTextDocument p0)
	{
		z0ZzZzrjh z0ZzZzrjh2 = new z0ZzZzrjh();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine();
		DocumentViewOptions documentViewOptions = p0.z0iu();
		stringBuilder.AppendLine("P{margin:0px}");
		stringBuilder.AppendLine("table p{text-indent:0;}");
		stringBuilder.AppendLine("INPUT{border:1px solid white;border-radius:4px}");
		string text = "border:1px solid red;border-radius:3px;color:" + z0ZzZzrjh2.z0uek(documentViewOptions.FieldInvalidateValueForeColor) + ";";
		if (documentViewOptions.FieldInvalidateValueBackColor.A > 0)
		{
			text = text + ";background-color:" + z0ZzZzrjh2.z0uek(documentViewOptions.FieldInvalidateValueBackColor);
		}
		else if (documentViewOptions.FieldBackColor.A > 0)
		{
			text = text + ";background-color:" + z0ZzZzrjh2.z0uek(documentViewOptions.FieldBackColor);
		}
		stringBuilder.AppendLine(".InputFieldInvalidateValue{" + text + "}");
		text = string.Empty;
		if (documentViewOptions.ReadonlyFieldBackColor.A > 0)
		{
			text = text + ";background-color:" + z0ZzZzrjh2.z0uek(documentViewOptions.ReadonlyFieldBackColor);
		}
		stringBuilder.AppendLine(".InputFieldReadonly{" + text + "}");
		text = string.Empty;
		if (documentViewOptions.FieldBackColor.A > 0)
		{
			text = text + ";background-color:" + z0ZzZzrjh2.z0uek(documentViewOptions.FieldBackColor);
		}
		stringBuilder.AppendLine(".InputFieldModified{" + text + "}");
		text = string.Empty;
		if (documentViewOptions.FieldBackColor.A > 0)
		{
			text = text + ";background-color:" + z0ZzZzrjh2.z0uek(documentViewOptions.FieldBackColor);
		}
		stringBuilder.AppendLine(".InputFieldNormal{" + text + "}");
		stringBuilder.AppendLine(".FieldFocusedBackColor{background-color:" + z0ZzZzrjh2.z0uek(documentViewOptions.FieldFocusedBackColor) + "}");
		stringBuilder.AppendLine(".FieldHoverBackColor{background-color:" + z0ZzZzrjh2.z0uek(documentViewOptions.FieldHoverBackColor) + "}");
		return stringBuilder.ToString();
	}

	public string z0rek()
	{
		return z0jrk;
	}

	private z0ZzZzgbj z0tek()
	{
		z0ZzZzgbj z0ZzZzgbj2 = z0pek;
		if (z0ZzZzgbj2 == null)
		{
			z0ZzZzgbj2 = (z0pek = new z0ZzZzgbj());
		}
		return z0ZzZzgbj2;
	}

	private string z0tek(float p0)
	{
		return z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, (z0ZzZzkpk)0);
	}

	public void z0eek(List<int> p0)
	{
		z0xek = p0;
	}

	internal string z0tek(XTextDocument p0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		XPageSettings pageSettings = p0.PageSettings;
		pageSettings.z0ork();
		bool flag = pageSettings.z0ork();
		z0ZzZzarj z0ZzZzarj2 = new z0ZzZzarj(p0.PageSettings, p1: true, p2: false);
		z0ZzZzarj z0ZzZzarj3 = new z0ZzZzarj(p0.PageSettings, p1: true, p2: true);
		if (z0ZzZzarj2.z0zek())
		{
			string text = z0tek(z0ZzZzarj2.z0uek());
			if (flag)
			{
				if (z0ZzZzarj2.z0rek() == DCGutterStyle.Left)
				{
					stringBuilder.Append("@page:left rotated{size:landscape;margin-left:" + text + ";margin-top:" + z0tek(p0.PageSettings.z0atk()) + ";margin-right:0cm;margin-bottom:0cm;}");
					stringBuilder.Append("@page:right rotated{size:landscape;margin-left:" + z0tek(p0.PageSettings.z0vtk()) + ";margin-top:" + z0tek(p0.PageSettings.z0atk()) + ";margin-right:0cm;margin-bottom:0cm;}");
				}
				else if (z0ZzZzarj2.z0rek() == DCGutterStyle.Right)
				{
					stringBuilder.Append("@page:left rotated{size:landscape;margin-left:" + z0tek(p0.PageSettings.z0vtk()) + ";margin-top:" + z0tek(p0.PageSettings.z0atk()) + ";margin-right:0cm;margin-bottom:0cm;}");
					stringBuilder.Append("@page:right rotated{size:landscape;margin-left:" + text + ";margin-top:" + z0tek(p0.PageSettings.z0atk()) + ";margin-right:0cm;margin-bottom:0cm;}");
				}
				else if (z0ZzZzarj2.z0rek() == DCGutterStyle.Top)
				{
					stringBuilder.Append("@page:left rotated{size:landscape;margin-left:" + z0tek(p0.PageSettings.z0vtk()) + ";margin-top:" + text + ";margin-right:0cm;margin-bottom:0cm;}");
					stringBuilder.Append("@page:right rotated{size:landscape;margin-left:" + z0tek(p0.PageSettings.z0vtk()) + ";margin-top:" + z0tek(p0.PageSettings.z0atk()) + ";margin-right:0cm;margin-bottom:0cm;}");
				}
			}
			else if (z0ZzZzarj2.z0rek() == DCGutterStyle.Left)
			{
				stringBuilder.Append("@page:left{margin-left:" + z0tek(p0.PageSettings.z0vtk()) + ";margin-top:" + z0tek(p0.PageSettings.z0atk()) + ";margin-right:0cm;margin-bottom:0cm;}");
				stringBuilder.Append("@page:right{margin-left:" + text + ";margin-top:" + z0tek(p0.PageSettings.z0atk()) + ";margin-right:0cm;margin-bottom:0cm;}");
			}
			else if (z0ZzZzarj2.z0rek() == DCGutterStyle.Right)
			{
				stringBuilder.Append("@page:left{margin-left:" + text + ";margin-top:" + z0tek(p0.PageSettings.z0atk()) + ";margin-right:0cm;margin-bottom:0cm;}");
				stringBuilder.Append("@page:right{margin-left:" + z0tek(p0.PageSettings.z0vtk()) + ";margin-top:" + z0tek(p0.PageSettings.z0atk()) + ";margin-right:0cm;margin-bottom:0cm;}");
			}
			else if (z0ZzZzarj2.z0rek() == DCGutterStyle.Top)
			{
				stringBuilder.Append("@page:left{margin-left:" + z0tek(p0.PageSettings.z0vtk()) + ";margin-top:" + z0tek(p0.PageSettings.z0atk()) + ";margin-right:0cm;margin-bottom:0cm;}");
				stringBuilder.Append("@page:right{margin-left:" + z0tek(p0.PageSettings.z0vtk()) + ";margin-top:" + text + ";margin-right:0cm;margin-bottom:0cm;}");
			}
			return stringBuilder.ToString();
		}
		if (z0ZzZzarj2.z0oek())
		{
			if (flag)
			{
				stringBuilder.Append("@page:left{margin-left:" + z0tek(z0ZzZzarj2.z0vek()) + ";margin-top:" + z0tek(z0ZzZzarj2.z0bek()) + ";margin-right:" + z0tek(0f) + ";margin-bottom:" + z0tek(0f) + ";}");
				stringBuilder.Append("@page:right{margin-left:" + z0tek(z0ZzZzarj3.z0vek()) + ";margin-top:" + z0tek(z0ZzZzarj3.z0bek()) + ";margin-right:" + z0tek(0f) + ";margin-bottom:" + z0tek(0f) + ";}");
			}
			else
			{
				stringBuilder.Append("@page:left{margin-left:" + z0tek(z0ZzZzarj2.z0bek()) + ";margin-top:" + z0tek(z0ZzZzarj2.z0vek()) + ";margin-right:" + z0tek(0f) + ";margin-bottom:" + z0tek(0f) + ";}");
				stringBuilder.Append("@page:right{margin-left:" + z0tek(z0ZzZzarj3.z0bek()) + ";margin-top:" + z0tek(z0ZzZzarj3.z0vek()) + ";margin-right:" + z0tek(0f) + ";margin-bottom:" + z0tek(0f) + ";}");
			}
		}
		else if (flag)
		{
			stringBuilder.Append("@page{margin-left:" + z0tek(z0ZzZzarj2.z0vek()) + ";margin-top:" + z0tek(z0ZzZzarj2.z0bek()) + ";margin-right:" + z0tek(0f) + ";margin-bottom:" + z0tek(0f) + ";}");
		}
		else
		{
			stringBuilder.Append("@page{margin-left:" + z0tek(z0ZzZzarj2.z0bek()) + ";margin-top:" + z0tek(z0ZzZzarj2.z0vek()) + ";margin-right:" + z0tek(0f) + ";margin-bottom:" + z0tek(0f) + ";}");
		}
		return stringBuilder.ToString();
	}

	public static string z0rek(string p0, string p1)
	{
		int num = p0.IndexOf(z0krk);
		if (num >= 0)
		{
			string text = "<style id='dccustomcontentstyle'>" + p1 + "</style>";
			return p0.Insert(num, text);
		}
		return p0;
	}

	private void z0yek(XTextDocument p0)
	{
		if (!z0mek.Options.ForPrint)
		{
			z0mek.z0cek("style");
			z0mek.z0uek("id", "dccontentstyle");
			z0mek.z0yek(z0rek(p0));
			((z0ZzZzfjh)z0mek).z0xek();
		}
		else
		{
			z0mek.z0cek("style");
			z0mek.z0uek("id", "dccontentstyle");
			z0mek.z0yek(z0vek);
			((z0ZzZzfjh)z0mek).z0xek();
		}
		if (z0mek.z0lw())
		{
			_ = z0mek.z0irk;
			z0mek.z0yek(" ");
			z0mek.z0uek(z0krk);
		}
		z0mek.z0cek("style");
		z0mek.z0yek(z0bek);
		z0mek.z0yek(z0nek);
		z0mek.z0yek(z0zek);
		((z0ZzZzfjh)z0mek).z0xek();
		z0mek.z0cek("style");
		z0mek.z0uek("id", "usertrackstyle");
		z0mek.z0yek(z0uek(p0));
		((z0ZzZzfjh)z0mek).z0xek();
		z0mek.z0cek("style");
		z0mek.z0uek("type", "text/css");
		z0mek.z0uek("media", "print");
		string p1 = "@page{margin-left:0cm;margin-top:0cm;margin-right:0cm;margin-bottom:0cm;size:" + p0.PageSettings.z0yrk().ToString().ToLower() + (p0.PageSettings.z0ork() ? " landscape" : "") + "}";
		z0mek.z0yek(p1);
		((z0ZzZzfjh)z0mek).z0xek();
	}

	internal string z0uek(XTextDocument p0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine();
		DocumentSecurityOptions documentSecurityOptions = p0.z0hi();
		z0ZzZzigh trackVisibleConfig = documentSecurityOptions.GetTrackVisibleConfig(0);
		if (p0.z0syk() != null && p0.z0syk().Count > 0)
		{
			trackVisibleConfig = documentSecurityOptions.GetTrackVisibleConfig(p0.z0syk().z0oek());
		}
		if (trackVisibleConfig != null)
		{
			stringBuilder.Append("." + z0ZzZzhjh.z0krk + "{");
			stringBuilder.Append("text-decoration:line-through;");
			stringBuilder.Append(";text-decoration-color:");
			stringBuilder.Append(z0rek(trackVisibleConfig.DeleteLineColor));
			if (trackVisibleConfig.DeleteLineNum > 1)
			{
				stringBuilder.Append(";text-decoration-style:double");
			}
			if (trackVisibleConfig.BackgroundColor.A != 0)
			{
				stringBuilder.Append(";background-color:");
				stringBuilder.Append(z0rek(trackVisibleConfig.BackgroundColor));
			}
			stringBuilder.Append("}");
			stringBuilder.AppendLine();
		}
		List<z0ZzZzigh> list = new List<z0ZzZzigh>();
		list.Add(documentSecurityOptions.GetTrackVisibleConfig(0));
		list.Add(documentSecurityOptions.GetTrackVisibleConfig(1));
		list.Add(documentSecurityOptions.GetTrackVisibleConfig(2));
		for (int i = 0; i < list.Count; i++)
		{
			z0ZzZzigh z0ZzZzigh2 = list[i];
			stringBuilder.Append("." + z0hrk + i + "{");
			stringBuilder.Append("text-decoration:line-through;");
			stringBuilder.Append(";text-decoration-color:");
			stringBuilder.Append(z0rek(z0ZzZzigh2.DeleteLineColor));
			if (z0ZzZzigh2.DeleteLineNum > 1)
			{
				stringBuilder.Append(";text-decoration-style:double");
			}
			if (z0ZzZzigh2.BackgroundColor.A != 0)
			{
				stringBuilder.Append(";background-color:");
				stringBuilder.Append(z0rek(z0ZzZzigh2.BackgroundColor));
			}
			stringBuilder.Append('}');
			stringBuilder.AppendLine();
			stringBuilder.Append("." + z0cek + i + "{");
			stringBuilder.Append("text-decoration:underline;");
			stringBuilder.Append(";text-decoration-color:");
			stringBuilder.Append(z0rek(z0ZzZzigh2.UnderLineColor));
			if (z0ZzZzigh2.UnderLineColorNum > 1)
			{
				stringBuilder.Append(";text-decoration-style:double");
			}
			if (z0ZzZzigh2.BackgroundColor.A != 0)
			{
				stringBuilder.Append(";background-color:");
				stringBuilder.Append(z0rek(z0ZzZzigh2.BackgroundColor));
			}
			stringBuilder.Append('}');
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	public void z0yek()
	{
		if (z0lrk != null)
		{
			z0lrk.Clear();
			z0lrk = null;
		}
		if (z0mek != null)
		{
			z0mek.z0zq();
			z0mek = null;
		}
	}

	private void z0rek(XTextDocument p0, z0ZzZzwrj p1)
	{
		string text = z0yek(p0, p1);
		if (!string.IsNullOrEmpty(text))
		{
			z0mek.z0uek(text, z0mek.Options.ForPrint);
			z0mek.z0yek("background-attachment", "scroll");
			z0mek.z0yek("background-repeat", "repeat");
		}
	}

	public z0ZzZzgbj z0uek()
	{
		z0ZzZzgbj z0ZzZzgbj2 = z0pek;
		if (z0ZzZzgbj2 == null)
		{
			z0ZzZzgbj2 = (z0pek = new z0ZzZzgbj());
		}
		return z0ZzZzgbj2;
	}

	private void z0tek(XTextDocument p0, z0ZzZzwrj p1)
	{
		z0ZzZzgbj z0ZzZzgbj2 = z0tek();
		z0mek.z0cek("table");
		z0mek.z0uek("id", "dctable_AllContent");
		z0mek.z0uek("contenteditable", "false");
		z0mek.z0uek("dctype", "dcframe");
		z0mek.z0uek("border", "0");
		z0mek.z0uek("cellpadding", "0");
		z0mek.z0uek("cellspacing", "0");
		string text = z0yek(p0, p1);
		if (text != null && text.Length > 0)
		{
			z0mek.z0uek("hasbackgroundimage", "true");
		}
		((z0ZzZzfjh)z0mek).z0oek();
		z0mek.z0yek("position", "relative");
		if (z0ZzZzgbj2.ContentRenderMode == (z0ZzZzfbj)8)
		{
			z0mek.z0yek("height", "100%");
		}
		_ = z0ZzZzgbj2.ContentRenderMode;
		_ = 3;
		bool flag = false;
		z0ZzZzvpk z0ZzZzvpk2 = p0.PageSettings.z0krk_jiejie20260327142557();
		if (z0ZzZzvpk2 != null && z0ZzZzvpk2.HasVisibleBorder && z0ZzZzvpk2.z0eek() == PageBorderRangeTypes.Page)
		{
			z0mek.z0yek(z0ZzZzvpk2.BorderLeft, z0ZzZzvpk2.BorderTop, z0ZzZzvpk2.BorderRight, z0ZzZzvpk2.BorderBottom, z0ZzZzvpk2.BorderColor, z0rek(z0ZzZzvpk2.BorderWidth), z0ZzZzvpk2.BorderStyle);
			flag = true;
		}
		if (!flag)
		{
			z0mek.z0yek("border", "1px solid black");
		}
		z0mek.z0yek("background-color", z0mek.z0uek(z0ZzZzgbj2.PageBackColor));
		_ = z0mek.Options.ForPrint;
		z0rek(p0, p1);
		((z0ZzZzfjh)z0mek).z0zek();
	}

	public void Dispose()
	{
		z0mek = null;
		z0pek = null;
		z0lrk = null;
		z0jrk = null;
	}

	private z0ZzZzrjh z0rek(XTextDocument p0, TextWriter p1)
	{
		z0ZzZzgbj z0ZzZzgbj2 = z0tek();
		z0mek = new z0ZzZzrjh();
		if (p1 != null)
		{
			z0mek.z0yek(new z0ZzZzhqh(p1));
		}
		if (z0rek() != null && z0rek().Length > 0)
		{
			z0mek.z0bek(z0rek());
		}
		z0mek.z0drk = z0oek;
		z0mek.Options = z0ZzZzgbj2.z0eek();
		z0mek.Options.EnableEncryptView = p0.z0iu().EnableEncryptView;
		z0mek.Options.ForPrint = z0ZzZzgbj2.ContentRenderMode == (z0ZzZzfbj)3 || z0ZzZzgbj2.ContentRenderMode == (z0ZzZzfbj)0;
		if (p0 != null)
		{
			z0mek.z0rek(p0);
		}
		z0mek.Options.KeepLineBreak = false;
		z0mek.Options.OutputRowHeight = true;
		z0mek.z0jw(z0uek().UseClassAttribute);
		return z0mek;
	}

	private void z0rek(z0ZzZzclh p0)
	{
		z0ZzZzgbj z0ZzZzgbj2 = z0tek();
		XTextDocument xTextDocument = null;
		if (p0 != null && p0.Count > 0)
		{
			xTextDocument = p0.z0rek();
		}
		z0mek.z0cek("head");
		z0mek.z0cek("meta");
		z0mek.z0uek("http-equiv", "X-UA-Compatible");
		z0mek.z0uek("content", "IE=edge");
		z0mek.z0yrk();
		z0mek.z0cek("meta");
		z0mek.z0uek("http-equiv", "content-type");
		z0mek.z0uek("content", "text/html;charset=" + (string.IsNullOrEmpty(z0ZzZzgbj2.Chartset) ? "utf-8" : z0ZzZzgbj2.Chartset));
		z0mek.z0yrk();
		z0mek.z0cek("title");
		z0mek.z0yek(xTextDocument.z0zrk());
		((z0ZzZzfjh)z0mek).z0xek();
		z0yek(xTextDocument);
		((z0ZzZzfjh)z0mek).z0xek();
	}

	private string z0yek(float p0)
	{
		return Math.Round(z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, GraphicsUnit.Millimeter), 1).ToString();
	}

	private void z0iek(XTextDocument p0)
	{
		z0ZzZzgbj z0ZzZzgbj2 = z0tek();
		z0mek.z0cek("body");
		XPageSettings pageSettings = p0.PageSettings;
		z0ZzZzeok z0ZzZzeok2 = new z0ZzZzeok();
		z0ZzZzeok2.z0mek = true;
		z0ZzZzeok2.z0ewk();
		string p1 = ((p0.Attributes != null && p0.Attributes.Count > 0) ? p0.Attributes.DCWriteString() : null);
		z0ZzZzeok2.z0eek("DocumentAttributes", p1);
		z0ZzZzeok2.z0rwk("PageSettings");
		z0ZzZzeok2.z0ewk();
		z0ZzZzeok2.z0eek("PaperKind", pageSettings.z0yrk().ToString());
		z0ZzZzeok2.z0eek("PaperHeight", z0yek(pageSettings.z0qrk()));
		z0ZzZzeok2.z0eek("PaperWidth", z0yek(pageSettings.z0drk()));
		z0ZzZzeok2.z0eek("LeftMargin", z0yek(pageSettings.z0vtk()));
		z0ZzZzeok2.z0eek("TopMargin", z0yek(pageSettings.z0bek()));
		z0ZzZzeok2.z0eek("BottomMargin", z0yek(pageSettings.z0qtk()));
		z0ZzZzeok2.z0eek("RightMargin", z0yek(pageSettings.z0xrk()));
		z0ZzZzeok2.z0eek("HeaderDistance", z0yek(pageSettings.z0atk()));
		z0ZzZzeok2.z0eek("FooterDistance", z0yek(pageSettings.z0stk()));
		z0ZzZzeok2.z0rek("Landscape", pageSettings.z0ork());
		z0ZzZzeok2.z0eek("GutterPosition", z0yek(pageSettings.z0erk() * 3f));
		z0ZzZzeok2.z0rek("ShowGutterLine", pageSettings.z0otk());
		z0ZzZzeok2.z0rek("SwapGutter", pageSettings.z0nek());
		z0ZzZzeok2.z0eek("GutterStyle", pageSettings.z0xtk().ToString());
		z0ZzZzeok2.z0eek("UNIT", "Millimeter");
		if (pageSettings.z0jrk() != null)
		{
			z0ZzZzeok2.z0rwk("Watermark");
			z0ZzZzeok2.z0ewk();
			z0ZzZzeok2.z0eek("Type", pageSettings.z0jrk().Type.ToString());
			z0ZzZzeok2.z0eek("Text", pageSettings.z0jrk().Text);
			z0ZzZzeok2.z0eek("Repeat", pageSettings.z0jrk().Repeat.ToString());
			string p2 = ((pageSettings.z0jrk().Image != null) ? pageSettings.z0jrk().Image.ImageDataBase64String : null);
			z0ZzZzeok2.z0eek("ImageDataBase64String", p2);
			z0ZzZzeok2.z0eek("Font", pageSettings.z0jrk().Font.ToString());
			z0ZzZzeok2.z0eek("DensityForRepeat", pageSettings.z0jrk().DensityForRepeat.ToString());
			z0ZzZzeok2.z0eek("ColorValue", pageSettings.z0jrk().ColorValue.ToString());
			z0ZzZzeok2.z0eek("BackColorValue", pageSettings.z0jrk().BackColorValue.ToString());
			z0ZzZzeok2.z0eek("Angle", pageSettings.z0jrk().Angle.ToString());
			z0ZzZzeok2.z0eek("Alpha", pageSettings.z0jrk().Alpha.ToString());
			z0ZzZzeok2.z0qwk();
			z0ZzZzeok2.z0wwk();
		}
		else
		{
			z0ZzZzeok2.z0eek("Watermark", (string)null);
		}
		z0ZzZzeok2.z0qwk();
		z0ZzZzeok2.z0wwk();
		if (p0.z0ipk() != null)
		{
			z0ZzZzeok2.z0rwk("DocumentInfos");
			z0ZzZzeok2.z0ewk();
			z0ZzZzeok2.z0eek("ShowHeaderBottomLine", p0.z0ipk().ShowHeaderBottomLine.ToString());
			z0ZzZzeok2.z0qwk();
			z0ZzZzeok2.z0wwk();
		}
		z0ZzZzeok2.z0qwk();
		string text = z0ZzZzeok2.ToString();
		text = z0ZzZztwh.z0eek(z0ZzZzeok2.ToString());
		z0mek.z0uek("dcdocinfo", text);
		if (p0.z0suk().Count > 0)
		{
			z0mek.z0uek("pageclientheight", z0mek.z0uek(p0.z0suk()[0].z0urk()).ToString());
		}
		else
		{
			z0mek.z0uek("pageclientheight", z0mek.z0uek(p0.PageSettings.z0mrk()).ToString());
		}
		z0mek.z0uek("pageunitrate", z0ZzZzrpk.z0eek(GraphicsUnit.Pixel, GraphicsUnit.Document).ToString());
		z0mek.z0uek("contentrendermode", z0ZzZzgbj2.ContentRenderMode.ToString());
		if (z0ZzZzgbj2.ContentRenderMode == (z0ZzZzfbj)3)
		{
			z0mek.z0uek("printhtml", "true");
			z0mek.z0uek("pagesettingstylecontent", z0tek(p0));
			if (p0.PageSettings.z0ork())
			{
				z0mek.z0uek("landscape", "true");
			}
		}
		((z0ZzZzfjh)z0mek).z0oek();
		if (z0ZzZzgbj2.ContentRenderMode == (z0ZzZzfbj)3)
		{
			p0.PageSettings.z0ork();
		}
		z0mek.z0yek("margin", z0ZzZzgbj2.PixelPageSpacing + "px");
		if (z0ZzZzgbj2.AutoLine)
		{
			z0rek(p0, (z0ZzZzwrj)null);
		}
		if (!z0mek.Options.ForPrint)
		{
			z0mek.z0yek("cursor", "default");
		}
		((z0ZzZzfjh)z0mek).z0zek();
	}

	private void z0rek(XTextDocument p0, z0ZzZzwrj p1, bool p2, float p3 = 0f)
	{
		z0mek.z0cek("div");
		((z0ZzZzfjh)z0mek).z0oek();
		if (p3 == 0f)
		{
			p3 = p0.PageSettings.z0atk();
		}
		int num = z0mek.z0uek(p3);
		z0mek.z0yek("height", num + "px");
		((z0ZzZzfjh)z0mek).z0zek();
		byte[] array = Convert.FromBase64String("sL+ym6O2h4Gzl4+TjZuphIKZnICcsp2dgIeZm7GXnJQ=");
		for (int i = 0; i < 32; i++)
		{
			array[i] = (byte)(array[i] ^ (220 + i));
		}
		Encoding.UTF8.GetString(array);
		((z0ZzZzfjh)z0mek).z0xek();
	}

	public List<int> z0iek()
	{
		return z0xek;
	}

	private string z0rek(Color p0)
	{
		return z0ZzZzfjh.z0yek(p0);
	}

	private string z0yek(XTextDocument p0, z0ZzZzwrj p1)
	{
		if (z0lrk == null)
		{
			z0lrk = new Dictionary<XTextDocument, string>();
		}
		string text = null;
		XPageSettings pageSettings = p0.PageSettings;
		if (p1 != null && !pageSettings.z0eek(p1.z0brk(), p1: true))
		{
			return null;
		}
		if (!z0lrk.ContainsKey(p0))
		{
			z0ZzZzrfh z0ZzZzrfh2 = WriterControlForWASM.z0bek(p0);
			if (z0ZzZzrfh2 != null)
			{
				text = z0ZzZzcoj.z0tek(z0ZzZzrfh2);
				z0ZzZzrfh2.Dispose();
			}
			z0lrk[p0] = text;
		}
		else
		{
			text = z0lrk[p0];
		}
		return text;
	}
}
