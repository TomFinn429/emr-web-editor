using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer.HtmlForms;

public sealed class DCFormTableElement : DCFormElement
{
	private new bool z0yek;

	private new int z0uek;

	private new bool z0iek;

	public new bool z0eek()
	{
		return z0iek;
	}

	public DCFormTableElement(XTextTableElement element)
		: base(element)
	{
		if (element.z0zwk("DCFormOutput") == "true")
		{
			z0eek(p0: true);
		}
		if (element.z0zwk("HorizontalExpand") == "true")
		{
			z0rek(p0: true);
		}
		int num = 0;
		XTextTableElement xTextTableElement = z0qrk as XTextTableElement;
		if (element.z0qr("OutputBeginColIndex") && int.TryParse(element.z0zwk("OutputBeginColIndex"), out num) && xTextTableElement != null && num >= 0 && num < xTextTableElement.z0drk())
		{
			z0eek(num);
		}
	}

	public override void z0pq(JsonObject p0, bool p1 = false)
	{
		base.z0pq(p0, p1);
		p0.Add("HorizontalExpand", z0rek());
		p0.Add("OutputBeginColIndex", z0tek().ToString());
		XTextTableElement xTextTableElement = z0qrk as XTextTableElement;
		if (xTextTableElement.ID == null || xTextTableElement.ID.Length == 0 || !z0eek() || xTextTableElement.z0brk() == 0)
		{
			return;
		}
		if (!z0rek())
		{
			JsonArray jsonArray = new JsonArray();
			for (int i = 0; i <= xTextTableElement.z0stk().Count - 1; i++)
			{
				XTextTableRowElement xTextTableRowElement = xTextTableElement.z0stk()[i] as XTextTableRowElement;
				if (xTextTableRowElement.HeaderStyle)
				{
					continue;
				}
				XTextTableCellElement xTextTableCellElement = xTextTableRowElement.z0rek()[0] as XTextTableCellElement;
				if (xTextTableCellElement.ValueBinding == null || xTextTableCellElement.ValueBinding.BindingPath == null || xTextTableCellElement.ValueBinding.BindingPath.Length == 0)
				{
					JsonArray jsonArray2 = new JsonArray();
					for (int j = 0; j <= xTextTableRowElement.z0rek().Count - 1; j++)
					{
						XTextTableCellElement xTextTableCellElement2 = xTextTableRowElement.z0rek()[j] as XTextTableCellElement;
						jsonArray2.Add(xTextTableCellElement2.Text);
					}
					jsonArray.Add(jsonArray2);
					continue;
				}
				JsonObject jsonObject = new JsonObject();
				List<string> list = new List<string>();
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement.z0rek().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)z0bpk.Current;
						string text = ((xTextTableCellElement3.ValueBinding == null || xTextTableCellElement3.ValueBinding.BindingPath == null || xTextTableCellElement3.ValueBinding.BindingPath.Length == 0) ? xTextTableCellElement3.ID : xTextTableCellElement3.ValueBinding.BindingPath);
						string text2 = ((xTextTableCellElement3.Text != null) ? xTextTableCellElement3.Text : "");
						if (string.IsNullOrEmpty(text))
						{
							text = xTextTableCellElement3.z0oek();
						}
						if (!list.Contains(text))
						{
							jsonObject.Add(text, text2);
							list.Add(text);
						}
					}
				}
				jsonArray.Add(jsonObject);
			}
			p0.Add("Datas", jsonArray);
			return;
		}
		XTextElementList xTextElementList = xTextTableElement.z0jr().z0yu(xTextTableElement.ID);
		int num = z0tek();
		JsonArray jsonArray3 = new JsonArray();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableElement xTextTableElement2 = (XTextTableElement)z0bpk.Current;
				for (int k = num; k < xTextTableElement2.z0drk(); k++)
				{
					XTextElementList xTextElementList2 = (xTextTableElement2.z0srk()[k] as XTextTableColumnElement).z0eek();
					JsonArray jsonArray4 = new JsonArray();
					for (int l = 0; l <= xTextElementList2.Count - 1; l++)
					{
						XTextTableCellElement xTextTableCellElement4 = xTextElementList2[l] as XTextTableCellElement;
						jsonArray4.Add(xTextTableCellElement4.Text);
					}
					jsonArray3.Add(jsonArray4);
				}
			}
		}
		p0.Add("Datas", jsonArray3);
	}

	public new void z0eek(int p0)
	{
		z0uek = p0;
	}

	public new bool z0rek()
	{
		return z0yek;
	}

	public DCFormTableElement()
	{
	}

	public new void z0eek(bool p0)
	{
		z0iek = p0;
	}

	public new void z0rek(bool p0)
	{
		z0yek = p0;
	}

	public new int z0tek()
	{
		return z0uek;
	}

	public override int z0oq(string p0, XTextDocument p1)
	{
		int num = 0;
		if (!(JsonNode.Parse(p0) is JsonArray { Count: not 0 } jsonArray))
		{
			return 0;
		}
		XTextTableElement xTextTableElement = z0qrk as XTextTableElement;
		string iD = xTextTableElement.ID;
		if (!z0rek())
		{
			XTextTableRowElement xTextTableRowElement = null;
			int p2 = -1;
			int p3 = -1;
			for (int num2 = xTextTableElement.z0brk() - 1; num2 >= 0; num2--)
			{
				XTextTableRowElement xTextTableRowElement2 = xTextTableElement.z0stk()[num2] as XTextTableRowElement;
				if (xTextTableRowElement2.HeaderStyle)
				{
					break;
				}
				if (xTextTableRowElement == null)
				{
					p2 = xTextTableRowElement2.z0rek()[0].z0be()[0].z0pek();
					p3 = ((XTextElement)xTextTableRowElement2.z0rek()[0].z0be()[0].z0dy()).z0pek();
					xTextTableRowElement = xTextTableRowElement2.z0eek(TableRowCloneType.Default);
				}
				xTextTableElement.z0stk().z0cek(xTextTableRowElement2);
			}
			if (xTextTableRowElement == null)
			{
				return 0;
			}
			for (int i = 0; i < jsonArray.Count; i++)
			{
				XTextTableRowElement xTextTableRowElement3 = xTextTableRowElement.z0zek();
				if (jsonArray[i] is JsonArray)
				{
					JsonArray jsonArray2 = jsonArray[i] as JsonArray;
					int num3 = Math.Min(jsonArray2.Count, xTextTableRowElement.z0vek());
					for (int j = 0; j <= num3 - 1; j++)
					{
						XTextTableCellElement obj = xTextTableRowElement3.z0rek()[j] as XTextTableCellElement;
						string p4 = jsonArray2[j].ToString();
						obj.z0cek(p4, p2, p3);
					}
					xTextTableElement.z0stk().Add(xTextTableRowElement3);
					num++;
				}
				else
				{
					if (!(jsonArray[i] is JsonObject))
					{
						continue;
					}
					JsonObject jsonObject = jsonArray[i] as JsonObject;
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement3.z0rek().z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
							if (xTextTableCellElement.ValueBinding != null && xTextTableCellElement.ValueBinding.BindingPath != null)
							{
								JsonNode jsonNode = null;
								if (jsonObject.TryGetPropertyValue(xTextTableCellElement.ValueBinding.BindingPath, out jsonNode))
								{
									string value = jsonNode.GetValue<string>();
									xTextTableCellElement.z0cek(value, p2, p3);
								}
							}
						}
					}
					xTextTableElement.z0stk().Add(xTextTableRowElement3);
					num++;
				}
			}
			return num;
		}
		p1.z0vtk().BehaviorOptions.AutoFixElementIDWhenInsertElements = false;
		XTextElementList xTextElementList = p1.z0yu(iD);
		if (xTextElementList.Count == 0)
		{
			return 0;
		}
		XTextTableElement xTextTableElement2 = xTextElementList[0] as XTextTableElement;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current != xTextTableElement2 && current is XTextTableElement)
				{
					current.z0ji().z0ai(current);
				}
			}
		}
		int num4 = z0tek();
		int num5 = xTextTableElement2.z0drk();
		int num6 = num5 - num4;
		if (num6 <= 0)
		{
			return 0;
		}
		int num7 = ((jsonArray.Count % num6 != 0) ? 1 : 0);
		int num8 = ((jsonArray.Count <= num6) ? 1 : (jsonArray.Count / num6 + num7));
		XTextTableCellElement xTextTableCellElement2 = xTextTableElement2.z0nek(0, num4, p2: false);
		int p5 = xTextTableCellElement2.z0be()[0].z0pek();
		int p6 = ((XTextElement)xTextTableCellElement2.z0be()[0].z0dy()).z0pek();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement2.z0zek().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)z0bpk.Current;
				if (xTextTableCellElement3.z0xek() >= num4)
				{
					xTextTableCellElement3.z0cek("", p5, p6);
				}
			}
		}
		XTextElementList xTextElementList2 = new XTextElementList();
		while (num8 > 0)
		{
			XTextTableElement xTextTableElement3 = xTextTableElement2.z0lr(p0: true) as XTextTableElement;
			xTextTableElement3.z0oe();
			xTextTableElement3.z0bt(p1);
			for (int k = num4; k < num5; k++)
			{
				XTextElementList xTextElementList3 = (xTextTableElement3.z0srk()[k] as XTextTableColumnElement).z0eek();
				if (!(jsonArray[num] is JsonArray jsonArray3))
				{
					return num;
				}
				int num9 = Math.Min(jsonArray3.Count, xTextElementList3.Count);
				for (int l = 0; l < num9; l++)
				{
					XTextTableCellElement obj2 = xTextElementList3[l] as XTextTableCellElement;
					string p7 = jsonArray3[l].ToString();
					obj2.z0cek(p7, p5, p6);
				}
				num++;
				if (num >= jsonArray.Count)
				{
					xTextElementList2.Add(xTextTableElement3);
					xTextTableElement2.z0ji().z0be().z0yek(xTextTableElement2.z0ji().z0be().IndexOf(xTextTableElement2), xTextElementList2);
					xTextTableElement2.z0ji().z0be().z0cek(xTextTableElement2);
					return num;
				}
			}
			xTextElementList2.Add(xTextTableElement3);
			num8--;
		}
		xTextTableElement2.z0ji().z0be().z0yek(xTextTableElement2.z0ji().z0be().IndexOf(xTextTableElement2), xTextElementList2);
		xTextTableElement2.z0ji().z0be().z0cek(xTextTableElement2);
		return num;
	}
}
