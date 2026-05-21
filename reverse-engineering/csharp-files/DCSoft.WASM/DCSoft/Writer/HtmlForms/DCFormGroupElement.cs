using System.Collections.Generic;
using System.Text.Json.Nodes;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer.HtmlForms;

public sealed class DCFormGroupElement : DCFormElement
{
	private new z0ZzZzojh z0tek = new z0ZzZzojh();

	private new static readonly string z0yek = "group_";

	internal void z0eek(z0ZzZzojh p0)
	{
		z0tek = p0;
	}

	internal override void z0vq(DCFormDocument p0)
	{
		base.z0vq(p0);
		if (z0tek == null || z0tek.Count <= 0)
		{
			return;
		}
		if (z0tek.Count == 1)
		{
			foreach (DCFormElement item in z0tek[0].z0rek())
			{
				item.z0vq(p0);
			}
			return;
		}
		Dictionary<string, string> dictionary = p0.z0xek;
		Dictionary<string, string> dictionary2 = null;
		foreach (z0ZzZzijh item2 in z0tek)
		{
			p0.z0xek = new Dictionary<string, string>(dictionary);
			foreach (DCFormElement item3 in item2.z0rek())
			{
				item3.z0vq(p0);
			}
			if (dictionary2 == null)
			{
				dictionary2 = p0.z0xek;
			}
		}
		p0.z0xek = dictionary2;
	}

	public override DCFormElement z0bq(bool p0)
	{
		DCFormGroupElement dCFormGroupElement = (DCFormGroupElement)base.z0bq(p0);
		if (z0tek != null)
		{
			dCFormGroupElement.z0tek = new z0ZzZzojh();
			foreach (z0ZzZzijh item in z0tek)
			{
				dCFormGroupElement.z0tek.Add(item.z0eek());
			}
		}
		return dCFormGroupElement;
	}

	public new string z0eek()
	{
		return z0hrk;
	}

	public DCFormGroupElement()
	{
	}

	public DCFormGroupElement(XTextContainerElement element)
		: base(element)
	{
		z0tek(element.ToolTip);
	}

	internal new string z0eek(int p0)
	{
		return z0yek + z0iek() + "_" + p0;
	}

	internal new z0ZzZzojh z0rek()
	{
		if (z0tek == null)
		{
			z0tek = new z0ZzZzojh();
		}
		return z0tek;
	}

	public override void z0pq(JsonObject p0, bool p1 = false)
	{
		base.z0pq(p0, p1);
		if (z0tek == null || z0tek.Count <= 0)
		{
			return;
		}
		JsonArray jsonArray = new JsonArray();
		for (int i = 0; i < z0tek.Count; i++)
		{
			JsonObject jsonObject = new JsonObject();
			jsonObject.Add("Index", i);
			JsonArray jsonArray2 = new JsonArray();
			foreach (DCFormElement item in z0tek[i].z0rek())
			{
				JsonObject jsonObject2 = new JsonObject();
				item.z0pq(jsonObject2, p1);
				jsonArray2.Add(jsonObject2);
			}
			jsonObject.Add("ChildNodes", jsonArray2);
			jsonArray.Add(jsonObject);
		}
		p0.Add("Items", jsonArray);
	}
}
