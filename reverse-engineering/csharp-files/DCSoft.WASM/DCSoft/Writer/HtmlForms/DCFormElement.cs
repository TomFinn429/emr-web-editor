using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.HtmlForms;

public abstract class DCFormElement
{
	private int z0krk;

	private static readonly string z0jrk_jiejie20260327142557 = "id";

	protected string z0hrk;

	private string z0grk;

	protected string z0frk;

	private bool z0drk = true;

	private bool z0srk;

	private XAttributeList z0ark;

	[NonSerialized]
	protected XTextElement z0qrk;

	private bool z0wrk = true;

	private string z0erk;

	private string z0rrk;

	private string z0trk;

	private DocumentContentStyle z0yrk;

	private DCFormDocument z0urk;

	protected string z0irk_jiejie20260327142557;

	private string z0ork;

	public string z0eek()
	{
		return z0ork;
	}

	public void z0eek(string p0)
	{
		z0frk = p0;
	}

	public string z0rek()
	{
		return z0irk_jiejie20260327142557;
	}

	public virtual DCFormElement z0bq(bool p0)
	{
		DCFormElement dCFormElement = (DCFormElement)MemberwiseClone();
		if (z0ark != null)
		{
			dCFormElement.z0ark = z0ark.z0eek();
		}
		if (z0yrk != null)
		{
			dCFormElement.z0yrk = (DocumentContentStyle)z0yrk.Clone();
		}
		return dCFormElement;
	}

	public void z0eek(XAttributeList p0)
	{
		z0ark = p0;
	}

	protected void z0eek(JsonObject p0)
	{
		if (z0ark == null || z0ark.Count <= 0)
		{
			return;
		}
		JsonArray jsonArray = new JsonArray();
		using (zzz.z0ZzZzkuk<XAttribute>.z0bpk z0bpk = z0ark.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XAttribute current = z0bpk.Current;
				JsonObject jsonObject = new JsonObject();
				jsonObject.Add("Name", current.Name);
				jsonObject.Add("Value", current.Value);
				jsonArray.Add(jsonObject);
			}
		}
		p0.Add("CustomAttributes", jsonArray);
	}

	public virtual string z0mq()
	{
		return null;
	}

	public string z0tek()
	{
		return z0trk;
	}

	public bool z0yek()
	{
		return z0srk;
	}

	protected void z0rek(JsonObject p0)
	{
		if (z0yrk == null)
		{
			return;
		}
		Dictionary<z0ZzZzcik, object> dictionary = z0yrk.z0nek();
		if (dictionary == null || dictionary.Count <= 0)
		{
			return;
		}
		JsonObject jsonObject = new JsonObject();
		foreach (KeyValuePair<z0ZzZzcik, object> item in dictionary)
		{
			if (item.Value is bool)
			{
				jsonObject.Add(item.Key.z0yek(), (bool)item.Value);
			}
			else if (item.Value is Color)
			{
				jsonObject.Add(item.Key.z0yek(), z0ZzZzifh.z0eek((Color)item.Value));
			}
			else
			{
				jsonObject.Add(item.Key.z0yek(), Convert.ToString(item.Value));
			}
		}
		p0.Add("Style", jsonObject);
	}

	public virtual int z0oq(string p0, XTextDocument p1)
	{
		return 0;
	}

	internal virtual void z0vq(DCFormDocument p0)
	{
		string text = null;
		if (!string.IsNullOrEmpty(z0rrk))
		{
			text = z0rrk.Trim();
		}
		if (string.IsNullOrEmpty(text))
		{
			text = z0jrk_jiejie20260327142557 + z0krk;
		}
		z0trk = p0.z0yek(text, p1: true);
		if (!string.IsNullOrEmpty(z0hrk))
		{
			z0erk = p0.z0yek(z0hrk, p1: false);
		}
		else
		{
			z0erk = z0trk;
		}
	}

	public void z0eek(int p0)
	{
		z0krk = p0;
	}

	public DocumentContentStyle z0uek()
	{
		return z0yrk;
	}

	public void z0eek(bool p0)
	{
		z0srk = p0;
	}

	public string z0iek()
	{
		return z0hrk;
	}

	public virtual DCFormElementList z0xq()
	{
		return null;
	}

	public DCFormDocument z0oek()
	{
		return z0urk;
	}

	public void z0eek(DCFormDocument p0)
	{
		z0urk = p0;
	}

	public void z0rek(bool p0)
	{
		z0wrk = p0;
	}

	public void z0rek(string p0)
	{
		z0irk_jiejie20260327142557 = p0;
	}

	public string z0pek()
	{
		return z0frk;
	}

	public void z0tek(string p0)
	{
		z0grk = p0;
	}

	protected DCFormElement(XTextElement element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		z0qrk = element;
		z0rrk = element.ID;
		z0ark = element.Attributes;
		if (element.z0pek() >= 0)
		{
			z0yrk = (DocumentContentStyle)(element.z0jr()?.z0gnk()?.GetStyle(element.z0pek()));
		}
		z0wrk = element.Visible;
		XTextContainerElement xTextContainerElement = element.z0ji();
		while (!(xTextContainerElement is XTextDocumentBodyElement) && !(xTextContainerElement is XTextDocumentHeaderElement) && !(xTextContainerElement is XTextDocumentHeaderForFirstPageElement) && !(xTextContainerElement is XTextDocumentFooterElement) && !(xTextContainerElement is XTextDocumentFooterForFirstPageElement) && !(xTextContainerElement is XTextSectionElement) && !(xTextContainerElement is XTextSubDocumentElement) && xTextContainerElement != null)
		{
			xTextContainerElement = xTextContainerElement.z0ji();
		}
		string text = ((xTextContainerElement.ID != null) ? xTextContainerElement.ID : string.Empty);
		z0ork = ((XTextElement)xTextContainerElement).z0qrk() + ":" + text;
		z0srk = element.z0wtk();
		z0drk = element.z0yi();
	}

	public int z0mek()
	{
		return z0krk;
	}

	public void z0yek(string p0)
	{
		z0rrk = p0;
	}

	public DCFormElement()
	{
	}

	public void z0eek(DocumentContentStyle p0)
	{
		z0yrk = p0;
	}

	public virtual void z0cq(DCFormElementList p0)
	{
	}

	public XAttributeList z0nek()
	{
		return z0ark;
	}

	public bool z0bek()
	{
		return z0wrk;
	}

	public string z0vek()
	{
		return z0rrk;
	}

	public virtual void z0pq(JsonObject p0, bool p1 = false)
	{
		p0.Add("Type", GetType().Name);
		p0.Add("InnerID", z0mek().ToString());
		p0.Add("ID", z0vek());
		p0.Add("Name", z0iek());
		p0.Add("Title", z0cek());
		p0.Add("DataSource", z0pek());
		p0.Add("DataField", z0rek());
		p0.Add("Visible", z0bek());
		p0.Add("RuntimeID", z0tek());
		p0.Add("RuntimeName", z0lrk());
		p0.Add("OwnerContainer", z0eek());
		p0.Add("IsLogicDeleted", z0yek());
		p0.Add("RuntimeVisible", z0xek());
		if (p1 && z0oek() != null && z0oek().z0uek() != null)
		{
			JsonNode jsonNode = z0oek().z0uek().z0bek(z0qrk, p1: false);
			p0.Add("OuterXML", jsonNode);
		}
		z0eek(p0);
		z0rek(p0);
	}

	public string z0cek()
	{
		return z0grk;
	}

	public bool z0xek()
	{
		return z0drk;
	}

	public virtual void z0nq(string p0)
	{
	}

	public void z0uek(string p0)
	{
		z0hrk = p0;
	}

	public string z0zek()
	{
		if (z0qrk != null)
		{
			return z0qrk.z0ztk();
		}
		return null;
	}

	public string z0lrk()
	{
		return z0erk;
	}
}
