using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;
using DCSoft.WASM;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer.HtmlForms;

public sealed class DCFormDocument : DCFormElement
{
	[NonSerialized]
	private new XTextDocument z0mek;

	[NonSerialized]
	private new Dictionary<string, DCFormCheckBoxElementBase> z0nek;

	private new bool z0bek;

	private new WriterControlForWASM z0vek;

	[NonSerialized]
	private new List<string> z0cek;

	[NonSerialized]
	internal new Dictionary<string, string> z0xek;

	private new DCFormElementList z0zek = new DCFormElementList();

	private new string z0lrk;

	private DCFormLabelElement z0yek(XTextLabelElement p0)
	{
		return new DCFormLabelElement(p0);
	}

	public JsonNode z0yek(bool p0 = false)
	{
		JsonObject jsonObject = new JsonObject();
		z0pq(jsonObject, p0);
		return jsonObject;
	}

	public new DCFormElementList z0yek()
	{
		DCFormElementList dCFormElementList = new DCFormElementList();
		z0yek(this, dCFormElementList);
		return dCFormElementList;
	}

	public void z0yek(WriterControlForWASM p0)
	{
		z0vek = p0;
	}

	public int z0eek(Dictionary<string, string> p0, XTextDocument p1 = null)
	{
		if (p1 == null)
		{
			p1 = z0mek;
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("srcDocument");
		}
		return z0tek(z0xq(), p0, p1, null);
	}

	private void z0yek(XTextDocument p0, DCFormElementList p1)
	{
		z0cek = new List<string>();
		p1.AddRange(z0yek(p0.z0be()));
	}

	private DCFormTableElement z0yek(XTextTableElement p0)
	{
		DCFormTableElement dCFormTableElement = new DCFormTableElement(p0);
		if (!dCFormTableElement.z0eek() || (dCFormTableElement.z0rek() && z0cek.Contains(dCFormTableElement.z0vek())))
		{
			return null;
		}
		return dCFormTableElement;
	}

	private DCFormElementList z0yek(XTextElement p0)
	{
		DCFormElementList dCFormElementList = new DCFormElementList();
		if (p0 is XTextButtonElement)
		{
			dCFormElementList.Add(z0yek((XTextButtonElement)p0));
		}
		else if (p0 is XTextLabelElement)
		{
			dCFormElementList.Add(z0yek((XTextLabelElement)p0));
		}
		else if (p0 is XTextCheckBoxElementBase)
		{
			DCFormCheckBoxElementBase dCFormCheckBoxElementBase = z0yek((XTextCheckBoxElementBase)p0);
			if (dCFormCheckBoxElementBase != null)
			{
				dCFormElementList.Add(dCFormCheckBoxElementBase);
			}
		}
		else if (p0 is XTextImageElement)
		{
			dCFormElementList.Add(z0yek((XTextImageElement)p0));
		}
		else if (p0 is XTextTableElement)
		{
			XTextTableElement xTextTableElement = (XTextTableElement)p0;
			DCFormTableElement dCFormTableElement = z0yek(xTextTableElement);
			if (dCFormTableElement != null)
			{
				dCFormElementList.Add(dCFormTableElement);
				z0cek.Add(dCFormTableElement.z0vek());
			}
			else
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0stk().z0ltk();
				while (z0bpk.MoveNext())
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = ((XTextTableRowElement)z0bpk.Current).z0rek().z0ltk();
					while (z0bpk2.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk2.Current;
						DCFormElementList dCFormElementList2 = z0yek(xTextTableCellElement.z0be());
						dCFormElementList.AddRange(dCFormElementList2);
					}
				}
			}
		}
		else if (p0 is XTextInputFieldElement)
		{
			XTextInputFieldElement xTextInputFieldElement = p0 as XTextInputFieldElement;
			DCFormInputElement dCFormInputElement = z0yek((XTextInputFieldElement)p0);
			dCFormInputElement?.z0cq(z0yek(xTextInputFieldElement.z0be()));
			dCFormElementList.Add(dCFormInputElement);
		}
		else if (p0 is XTextContainerElement)
		{
			XTextContainerElement xTextContainerElement = p0 as XTextContainerElement;
			DCFormElementList dCFormElementList3 = z0yek(xTextContainerElement.z0be());
			dCFormElementList.AddRange(dCFormElementList3);
		}
		else if (p0 is XTextNewBarcodeElement)
		{
			dCFormElementList.Add(z0yek((XTextNewBarcodeElement)p0));
		}
		else if (p0 is XTextTDBarcodeElement)
		{
			dCFormElementList.Add(z0yek((XTextTDBarcodeElement)p0));
		}
		return dCFormElementList;
	}

	public new WriterControlForWASM z0uek()
	{
		return z0vek;
	}

	public new Dictionary<string, string> z0iek()
	{
		Dictionary<string, StringBuilder> dictionary = new Dictionary<string, StringBuilder>();
		z0rek(this, dictionary);
		Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
		foreach (KeyValuePair<string, StringBuilder> item in dictionary)
		{
			dictionary2[item.Key] = item.Value.ToString();
		}
		return dictionary2;
	}

	private void z0rek(DCFormElement p0, Dictionary<string, StringBuilder> p1)
	{
		foreach (DCFormElement item in p0.z0xq())
		{
			string text = null;
			string text2 = null;
			if (item is DCFormInputElement)
			{
				text = item.z0iek();
				text2 = item.z0mq();
			}
			else if (item is DCFormGroupElement)
			{
				z0rek(item, p1);
				continue;
			}
			if (text != null && text.Length > 0 && text2 != null && text2.Length > 0)
			{
				StringBuilder stringBuilder = null;
				if (!p1.TryGetValue(text, out stringBuilder))
				{
					stringBuilder = (p1[text] = new StringBuilder());
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append(text2);
			}
		}
	}

	public override void z0pq(JsonObject p0, bool p1 = false)
	{
		p0.Add("Type", GetType().Name);
		p0.Add("ID", z0vek());
		p0.Add("Name", base.z0iek());
		p0.Add("Title", z0cek());
		p0.Add("FileName", z0oek());
		z0eek(p0);
		if (z0zek == null || z0zek.Count <= 0)
		{
			return;
		}
		JsonArray jsonArray = new JsonArray();
		foreach (DCFormElement item in z0zek)
		{
			JsonObject jsonObject = new JsonObject();
			item.z0pq(jsonObject, p1);
			jsonArray.Add(jsonObject);
		}
		p0.Add("ChildNodes", jsonArray);
	}

	private DCFormButtonElement z0yek(XTextButtonElement p0)
	{
		return new DCFormButtonElement(p0);
	}

	private DCFormCheckBoxElementBase z0yek(XTextCheckBoxElementBase p0)
	{
		DCFormCheckBoxElementBase dCFormCheckBoxElementBase = null;
		bool flag = false;
		if (p0.Name != null && p0.Name.Length > 0)
		{
			if (z0nek == null)
			{
				z0nek = new Dictionary<string, DCFormCheckBoxElementBase>();
			}
			z0nek.TryGetValue(p0.Name, out dCFormCheckBoxElementBase);
		}
		if (dCFormCheckBoxElementBase == null)
		{
			dCFormCheckBoxElementBase = ((!(p0 is XTextCheckBoxElement)) ? ((DCFormCheckBoxElementBase)new DCFormRadioElement((XTextRadioBoxElement)p0)) : ((DCFormCheckBoxElementBase)new DCFormCheckBoxElement((XTextCheckBoxElement)p0)));
			flag = true;
			dCFormCheckBoxElementBase.z0tek(p0.ToolTip);
		}
		if (z0uek(dCFormCheckBoxElementBase.z0cek()) < z0uek(p0.ToolTip))
		{
			dCFormCheckBoxElementBase.z0tek(p0.ToolTip);
		}
		if (p0.Name != null && p0.Name.Length > 0)
		{
			z0nek[p0.Name] = dCFormCheckBoxElementBase;
		}
		dCFormCheckBoxElementBase.z0eek().Add(new z0ZzZzujh(p0, this));
		if (flag)
		{
			return dCFormCheckBoxElementBase;
		}
		return null;
	}

	public new string z0oek()
	{
		return z0lrk;
	}

	private DCFormBarcodeElement z0yek(XTextNewBarcodeElement p0)
	{
		return new DCFormBarcodeElement(p0);
	}

	private DCFormInputElement z0yek(XTextInputFieldElement p0)
	{
		return new DCFormInputElement(p0);
	}

	internal override void z0vq(DCFormDocument p0)
	{
		z0xek = new Dictionary<string, string>();
		base.z0vq(this);
		foreach (DCFormElement item in z0xq())
		{
			item.z0vq(this);
		}
		z0xek = null;
	}

	private DCFormElementList z0yek(XTextElementList p0)
	{
		DCFormElementList dCFormElementList = new DCFormElementList();
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			DCFormElementList dCFormElementList2 = z0yek(current);
			if (dCFormElementList2 == null)
			{
				continue;
			}
			foreach (DCFormElement item in dCFormElementList2)
			{
				item.z0eek(this);
			}
			dCFormElementList.AddRange(dCFormElementList2);
		}
		return dCFormElementList;
	}

	public new bool z0pek()
	{
		return z0bek;
	}

	public void z0yek(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		p0.z0vek(p0: false);
		z0mek = p0;
		base.z0yek(p0.ID);
		z0yek(p0.z0amk());
		z0tek(p0.z0ipk().z0mek());
		z0eek(p0.Attributes);
		z0nek = null;
		z0xek = new Dictionary<string, string>();
		if (z0pek())
		{
			z0yek(p0, z0xq());
		}
		else
		{
			z0yek((XTextContainerElement)p0, z0xq());
		}
		z0vq(this);
		z0nek = null;
	}

	public new void z0yek(string p0)
	{
		z0lrk = p0;
	}

	private DCFormTDBarcodeElement z0yek(XTextTDBarcodeElement p0)
	{
		return new DCFormTDBarcodeElement(p0);
	}

	private new int z0uek(string p0)
	{
		return p0?.Length ?? 0;
	}

	private void z0yek(XTextContainerElement p0, DCFormElementList p1)
	{
		XTextElementList xTextElementList = p0.z0rek<XTextObjectElement>();
		XTextElementList xTextElementList2 = p0.z0rek<XTextContainerElement>();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextButtonElement)
				{
					DCFormButtonElement dCFormButtonElement = z0yek((XTextButtonElement)current);
					dCFormButtonElement.z0eek(this);
					p1.Add(dCFormButtonElement);
				}
				else if (current is XTextLabelElement)
				{
					DCFormLabelElement dCFormLabelElement = z0yek((XTextLabelElement)current);
					dCFormLabelElement.z0eek(this);
					p1.Add(dCFormLabelElement);
				}
				else if (current is XTextCheckBoxElementBase)
				{
					XTextCheckBoxElementBase p2 = (XTextCheckBoxElementBase)current;
					DCFormCheckBoxElementBase dCFormCheckBoxElementBase = z0yek(p2);
					if (dCFormCheckBoxElementBase != null)
					{
						dCFormCheckBoxElementBase.z0eek(this);
						p1.Add(dCFormCheckBoxElementBase);
					}
				}
				else if (current is XTextImageElement)
				{
					DCFormImageElement dCFormImageElement = z0yek((XTextImageElement)current);
					dCFormImageElement.z0eek(this);
					p1.Add(dCFormImageElement);
				}
				else if (current is XTextNewBarcodeElement)
				{
					DCFormBarcodeElement dCFormBarcodeElement = z0yek((XTextNewBarcodeElement)current);
					dCFormBarcodeElement.z0eek(this);
					p1.Add(dCFormBarcodeElement);
				}
				else if (current is XTextTDBarcodeElement)
				{
					DCFormTDBarcodeElement dCFormTDBarcodeElement = z0yek((XTextTDBarcodeElement)current);
					dCFormTDBarcodeElement.z0eek(this);
					p1.Add(dCFormTDBarcodeElement);
				}
			}
		}
		z0cek = new List<string>();
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current2 = z0bpk.Current;
			if (current2 is XTextTableElement)
			{
				DCFormTableElement dCFormTableElement = z0yek((XTextTableElement)current2);
				if (dCFormTableElement != null && !z0cek.Contains(dCFormTableElement.z0vek()))
				{
					dCFormTableElement.z0eek(this);
					p1.Add(dCFormTableElement);
					z0cek.Add(dCFormTableElement.z0vek());
				}
			}
			else if (current2 is XTextInputFieldElement)
			{
				DCFormInputElement dCFormInputElement = z0yek((XTextInputFieldElement)current2);
				dCFormInputElement.z0eek(this);
				p1.Add(dCFormInputElement);
			}
		}
	}

	public DCFormDocument()
	{
	}

	private int z0tek(DCFormElementList p0, Dictionary<string, string> p1, XTextDocument p2, string p3)
	{
		int num = 0;
		foreach (DCFormElement item in p0)
		{
			if (item is DCFormInputElement)
			{
				string text = item.z0vek();
				if (text != null && text.Length > 0)
				{
					string text2 = text;
					if (p3 != null && p3.Length > 0)
					{
						text2 = p3 + ":" + text;
					}
					string p4 = null;
					if (p1.TryGetValue(text2, out p4))
					{
						num += item.z0oq(p4, p2);
					}
				}
			}
			else if (item is DCFormCheckBoxElementBase)
			{
				string text3 = item.z0lrk();
				if (text3 != null && text3.Length > 0)
				{
					string text4 = text3;
					if (p3 != null && p3.Length > 0)
					{
						text4 = p3 + ":" + text3;
					}
					string p5 = null;
					num = ((!p1.TryGetValue(text4, out p5)) ? (num + item.z0oq(null, p2)) : (num + item.z0oq(p5, p2)));
				}
			}
			else if (item is DCFormGroupElement)
			{
				DCFormGroupElement dCFormGroupElement = (DCFormGroupElement)item;
				z0ZzZzojh z0ZzZzojh = dCFormGroupElement.z0rek();
				if (z0ZzZzojh != null && z0ZzZzojh.Count > 0)
				{
					for (int i = 0; i < z0ZzZzojh.Count; i++)
					{
						string p6 = dCFormGroupElement.z0eek(i);
						num += z0tek(z0ZzZzojh[i].z0rek(), p1, p2, p6);
					}
				}
			}
			else if (item is DCFormTableElement)
			{
				DCFormTableElement dCFormTableElement = item as DCFormTableElement;
				string p7 = null;
				if (p1.TryGetValue(dCFormTableElement.z0vek(), out p7))
				{
					num += item.z0oq(p7, p2);
				}
			}
			else if (item is DCFormImageElement)
			{
				DCFormImageElement dCFormImageElement = item as DCFormImageElement;
				string p8 = null;
				if (dCFormImageElement.z0vek() != null && dCFormImageElement.z0vek().Length > 0 && p1.TryGetValue(dCFormImageElement.z0vek(), out p8))
				{
					num += item.z0oq(p8, p2);
				}
			}
			else if (item is DCFormBarcodeElement)
			{
				DCFormBarcodeElement dCFormBarcodeElement = item as DCFormBarcodeElement;
				string p9 = null;
				if (dCFormBarcodeElement.z0vek() != null && dCFormBarcodeElement.z0vek().Length > 0 && p1.TryGetValue(dCFormBarcodeElement.z0vek(), out p9))
				{
					num += item.z0oq(p9, p2);
				}
			}
			else if (item is DCFormTDBarcodeElement)
			{
				DCFormTDBarcodeElement dCFormTDBarcodeElement = item as DCFormTDBarcodeElement;
				string p10 = null;
				if (dCFormTDBarcodeElement.z0vek() != null && dCFormTDBarcodeElement.z0vek().Length > 0 && p1.TryGetValue(dCFormTDBarcodeElement.z0vek(), out p10))
				{
					num += item.z0oq(p10, p2);
				}
			}
		}
		return num;
	}

	public DCFormDocument(XTextDocument srcDocument)
	{
		srcDocument.z0vek(p0: false);
		z0yek(srcDocument);
	}

	private DCFormImageElement z0yek(XTextImageElement p0)
	{
		return new DCFormImageElement(p0);
	}

	private void z0yek(DCFormElement p0, DCFormElementList p1)
	{
		foreach (DCFormElement item in p0.z0xq())
		{
			p1.Add(item);
			if (item is DCFormGroupElement)
			{
				z0yek(item, p1);
			}
		}
	}

	public void z0uek(bool p0)
	{
		z0bek = p0;
	}

	internal string z0yek(string p0, bool p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			p0 = ((!p1) ? "name" : "id");
		}
		if (z0xek.ContainsKey(p0))
		{
			for (int i = 0; i < 100; i++)
			{
				string text = p0 + "_" + i;
				if (!z0xek.ContainsKey(text))
				{
					z0xek[text] = text;
					return text;
				}
			}
			return p0 + z0xek.Count;
		}
		z0xek[p0] = p0;
		return p0;
	}

	public override DCFormElementList z0xq()
	{
		if (z0zek == null)
		{
			z0zek = new DCFormElementList();
		}
		return z0zek;
	}

	public override void z0cq(DCFormElementList p0)
	{
		z0zek = p0;
	}
}
