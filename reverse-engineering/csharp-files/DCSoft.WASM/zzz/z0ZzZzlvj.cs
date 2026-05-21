using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzlvj
{
	public void z0eek(XTextInputFieldElement p0, bool p1)
	{
		if (p0 == null || p0.z0nek() == null)
		{
			return;
		}
		XTextElementList xTextElementList = null;
		xTextElementList = ((!p1) ? z0eek(p0) : new XTextElementList(p0));
		if (xTextElementList == null || xTextElementList.Count == 0)
		{
			return;
		}
		if (p1)
		{
			GetLinkListItemsEventArgs e = new GetLinkListItemsEventArgs();
			e.EffectElements = xTextElementList;
			e.ParentBinding = p0.z0nek();
			e.ParentElement = p0;
			e.ParentValue = p0.InnerValue;
			e.CurrentElement = p0;
			e.CurrentBinding = p0.z0nek();
			z0eek(p0, p0, e);
			return;
		}
		XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xTextElementList.z0xek(p0);
		if (xTextInputFieldElement != null)
		{
			GetLinkListItemsEventArgs e2 = new GetLinkListItemsEventArgs();
			e2.EffectElements = xTextElementList;
			e2.ParentBinding = p0.z0nek();
			e2.ParentElement = p0;
			e2.ParentValue = p0.InnerValue;
			e2.CurrentElement = xTextInputFieldElement;
			e2.CurrentBinding = xTextInputFieldElement.z0nek();
			z0eek(p0, xTextInputFieldElement, e2);
		}
	}

	private XTextElementList z0eek(XTextInputFieldElement p0)
	{
		if (p0 == null || p0.z0nek() == null || string.IsNullOrEmpty(p0.z0nek().ProviderName))
		{
			return null;
		}
		XTextElementList xTextElementList = new XTextElementList();
		XTextDocumentContentElement xTextDocumentContentElement = p0.z0qek();
		XTextElementList xTextElementList2 = new XTextElementList();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextDocumentContentElement.z0nek<XTextInputFieldElement>().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)z0bpk.Current;
				if (xTextInputFieldElement.z0nek() != null && xTextInputFieldElement.z0nek().ProviderName == p0.z0nek().ProviderName)
				{
					xTextElementList2.Add(xTextInputFieldElement);
				}
			}
		}
		if (!xTextElementList2.Contains(p0))
		{
			return null;
		}
		XTextInputFieldElement xTextInputFieldElement2 = p0;
		while (!xTextInputFieldElement2.z0nek().IsRoot)
		{
			bool flag = false;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextInputFieldElement xTextInputFieldElement3 = (XTextInputFieldElement)z0bpk.Current;
					if (xTextInputFieldElement3.z0nek().NextTarget == (z0ZzZzikh)1 && xTextInputFieldElement3.z0nek().NextTargetID == xTextInputFieldElement2.ID)
					{
						xTextElementList.Insert(0, xTextInputFieldElement3);
						xTextInputFieldElement2 = xTextInputFieldElement3;
						flag = true;
						xTextElementList2.z0cek(xTextInputFieldElement3);
						break;
					}
					if (xTextInputFieldElement3.z0nek().NextTarget == (z0ZzZzikh)0 && xTextElementList2.IndexOf(xTextInputFieldElement3) == xTextElementList2.IndexOf(xTextInputFieldElement2) - 1)
					{
						xTextElementList.Insert(0, xTextInputFieldElement3);
						xTextInputFieldElement2 = xTextInputFieldElement3;
						flag = true;
						xTextElementList2.z0cek(xTextInputFieldElement3);
						break;
					}
				}
			}
			if (!flag)
			{
				break;
			}
		}
		xTextElementList.Add(p0);
		xTextInputFieldElement2 = p0;
		while (xTextInputFieldElement2.z0nek().NextTarget != (z0ZzZzikh)2)
		{
			if (xTextInputFieldElement2.z0nek().NextTarget == (z0ZzZzikh)0)
			{
				XTextInputFieldElement xTextInputFieldElement4 = (XTextInputFieldElement)xTextElementList2.z0xek(xTextInputFieldElement2);
				if (xTextInputFieldElement4 == null)
				{
					break;
				}
				xTextInputFieldElement2 = xTextInputFieldElement4;
				xTextElementList.Add(xTextInputFieldElement2);
			}
			else
			{
				if (xTextInputFieldElement2.z0nek().NextTarget != (z0ZzZzikh)1)
				{
					continue;
				}
				bool flag2 = false;
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextInputFieldElement xTextInputFieldElement5 = (XTextInputFieldElement)z0bpk.Current;
						if (xTextInputFieldElement5.ID == xTextInputFieldElement2.z0nek().NextTargetID)
						{
							xTextInputFieldElement2 = xTextInputFieldElement5;
							xTextElementList.Add(xTextInputFieldElement2);
							flag2 = true;
							xTextElementList2.z0cek(xTextInputFieldElement5);
							break;
						}
					}
				}
				if (!flag2)
				{
					break;
				}
			}
		}
		return xTextElementList;
	}

	public void z0rek(XTextInputFieldElement p0)
	{
		if (p0 != null && p0.z0nek() != null && p0.z0nek().IsRoot)
		{
			z0eek(p0, p1: true);
		}
	}

	private void z0eek(XTextInputFieldElement p0, XTextInputFieldElement p1, GetLinkListItemsEventArgs p2)
	{
		XTextDocument xTextDocument = p0.z0jr();
		if (xTextDocument.z0yyk() != null)
		{
			xTextDocument.z0yyk().z0eek(p2);
			if (p2.Cancel)
			{
				return;
			}
		}
		if (!p2.Handled && p2.Items.Count == 0)
		{
			xTextDocument.z0xmk().z0eek().GetEnabledProvider(p2.ParentBinding.ProviderName)?.GetListItems(p2);
		}
		if (p2.Cancel)
		{
			return;
		}
		if (p1.FieldSettings == null)
		{
			p1.FieldSettings = new InputFieldSettings();
		}
		if (p1.FieldSettings.z0zek() == null)
		{
			p1.FieldSettings.z0eek(new z0ZzZzsvj());
		}
		p1.FieldSettings.z0zek().z0eek(p2.Items);
		if (!p2.CurrentBinding.AutoSetFirstItems)
		{
			return;
		}
		if (p2.Items.Count > 0)
		{
			ListItem listItem = p2.Items[0];
			string text = listItem.Value;
			if (string.IsNullOrEmpty(text))
			{
				text = listItem.Text;
			}
			p1.InnerValue = text;
			p1.z0krk(listItem.Text);
		}
		else
		{
			p1.InnerValue = null;
			p1.z0krk(string.Empty);
		}
	}
}
