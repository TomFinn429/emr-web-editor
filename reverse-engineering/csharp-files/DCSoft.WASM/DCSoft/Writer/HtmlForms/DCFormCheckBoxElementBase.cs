using System;
using System.Text;
using System.Text.Json.Nodes;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer.HtmlForms;

public abstract class DCFormCheckBoxElementBase : DCFormElement
{
	private new DCFormCheckBoxItemList z0uek = new DCFormCheckBoxItemList();

	private new string z0iek;

	private new bool z0oek;

	private char z0eek(bool p0, bool p1)
	{
		if (p0)
		{
			if (p1)
			{
				return '■';
			}
			return '□';
		}
		if (p1)
		{
			return '●';
		}
		return '○';
	}

	public DCFormCheckBoxElementBase()
	{
	}

	public new DCFormCheckBoxItemList z0eek()
	{
		if (z0uek == null)
		{
			z0uek = new DCFormCheckBoxItemList();
		}
		return z0uek;
	}

	internal override void z0vq(DCFormDocument p0)
	{
		base.z0vq(p0);
		if (z0uek != null && z0uek.Count > 0)
		{
			z0uek[0].z0grk = base.z0tek();
			for (int i = 1; i < z0uek.Count; i++)
			{
				z0uek[i].z0eek(p0);
			}
		}
	}

	public override int z0oq(string p0, XTextDocument p1)
	{
		int num = 0;
		if (z0uek != null)
		{
			if (p0 == "on" && z0uek.Count == 1 && string.IsNullOrEmpty(z0uek[0].z0yek()))
			{
				if (z0uek[0].z0eek(p0: true, p1))
				{
					num++;
				}
				return num;
			}
			string[] array = null;
			if (p0 != null && p0.Length > 0)
			{
				array = p0.Split(',');
			}
			foreach (z0ZzZzujh item in z0uek)
			{
				bool flag = false;
				if (array != null)
				{
					flag = Array.IndexOf(array, item.z0yek()) >= 0;
				}
				if (item.z0pek() != flag && item.z0eek(flag, p1))
				{
					num++;
				}
			}
		}
		return num;
	}

	public new void z0eek(string p0)
	{
		z0iek = p0;
	}

	public new string z0rek()
	{
		return z0iek;
	}

	public void z0eek(DCFormCheckBoxItemList p0)
	{
		z0uek = p0;
	}

	public override void z0nq(string p0)
	{
		if (z0uek == null)
		{
			return;
		}
		if (p0 == null || p0.Length == 0)
		{
			foreach (z0ZzZzujh item in z0eek())
			{
				item.z0rek(p0: false);
			}
			return;
		}
		string[] array = p0.Split(',');
		foreach (z0ZzZzujh item2 in z0eek())
		{
			item2.z0rek(Array.IndexOf(array, item2.z0yek()) > 0);
		}
	}

	protected DCFormCheckBoxElementBase(XTextCheckBoxElementBase chk)
		: base(chk)
	{
		if (chk == null)
		{
			throw new ArgumentNullException("chk");
		}
		z0uek(chk.Name);
		if (chk.ValueBinding != null)
		{
			base.z0eek(chk.ValueBinding.DataSource);
			z0rek(chk.ValueBinding.BindingPath);
		}
		z0eek(chk.Requried);
	}

	public override string z0mq()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (z0uek != null)
		{
			foreach (z0ZzZzujh item in z0uek)
			{
				if (item.z0rek())
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append(item.z0yek());
				}
			}
		}
		return stringBuilder.ToString();
	}

	public new bool z0tek()
	{
		if (z0uek != null)
		{
			return z0uek.Count == 1;
		}
		return false;
	}

	public override void z0pq(JsonObject p0, bool p1 = false)
	{
		p0.Add("Type", GetType().Name);
		p0.Add("Name", z0iek());
		p0.Add("RuntimeName", z0lrk());
		p0.Add("Title", z0cek());
		p0.Add("Required", z0yek());
		p0.Add("OwnerContainer", base.z0eek());
		z0rek(p0);
		if (z0uek == null || z0uek.Count <= 0)
		{
			return;
		}
		JsonArray jsonArray = new JsonArray();
		foreach (z0ZzZzujh item in z0uek)
		{
			JsonObject jsonObject = new JsonObject();
			jsonObject.Add("ID", item.z0uek());
			jsonObject.Add("InnerID", item.z0iek().ToString());
			if (item.z0jrk != null && item.z0jrk.Attributes != null && item.z0jrk.Attributes.Count > 0)
			{
				JsonArray jsonArray2 = new JsonArray();
				using (zzz.z0ZzZzkuk<XAttribute>.z0bpk z0bpk = item.z0jrk.Attributes.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XAttribute current2 = z0bpk.Current;
						JsonObject jsonObject2 = new JsonObject();
						jsonObject2.Add("Name", current2.Name);
						jsonObject2.Add("Value", current2.Value);
						jsonArray2.Add(jsonObject2);
					}
				}
				jsonObject.Add("CustomAttributes", jsonArray2);
			}
			jsonObject.Add("RuntimeID", item.z0tek());
			if (p1 && z0oek() != null && z0oek().z0uek() != null)
			{
				JsonNode jsonNode = z0oek().z0uek().z0bek(z0qrk, p1: false);
				jsonObject.Add("OuterXML", jsonNode);
			}
			jsonObject.Add("ValueExpression", item.z0eek());
			jsonObject.Add("Text", item.z0bek());
			jsonObject.Add("Value", item.z0yek());
			jsonObject.Add("Checked", item.z0pek());
			jsonObject.Add("Title", item.z0nek());
			jsonObject.Add("IsLogicDeleted", item.z0oek());
			jsonArray.Add(jsonObject);
		}
		p0.Add("Items", jsonArray);
	}

	public new bool z0yek()
	{
		return z0oek;
	}

	public new void z0eek(bool p0)
	{
		z0oek = p0;
	}
}
