using System;
using System.Reflection;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzjlh : z0ZzZzxzj
{
	private new object z0rek;

	private object z0tek;

	private new PropertyInfo z0yek;

	private object z0uek;

	public override void Dispose()
	{
		base.Dispose();
		z0yek = null;
		z0rek = null;
		z0uek = null;
		z0tek = null;
	}

	private new string z0eek()
	{
		if (z0yek != null)
		{
			return z0yek.Name;
		}
		return null;
	}

	public override void z0to(z0ZzZzpgh p0)
	{
		if (z0yek != null)
		{
			z0yek.SetValue(z0rek, z0uek, null);
		}
		if (z0rek is XTextElement)
		{
			XTextElement xTextElement = (XTextElement)z0rek;
			xTextElement.z0rrk();
			xTextElement.z0xi(p0: true);
			base.z0eek().z0rek().Add(xTextElement);
			if (xTextElement is XTextFieldElementBase)
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xTextElement;
				if (xTextFieldElementBase.z0jrk() != null)
				{
					base.z0eek().z0rek().Add(xTextFieldElementBase.z0jrk());
				}
				if (xTextFieldElementBase.z0tek() != null)
				{
					base.z0eek().z0rek().Add(xTextFieldElementBase.z0tek());
				}
			}
		}
		if (z0rek is XTextTableRowElement && (z0eek() == "SpecifyHeight" || z0eek() == "HeaderStyle"))
		{
			base.z0eek().z0rek(base.z0eek().z0tek() | (z0ZzZzbzj)3);
		}
		if (z0rek is XTextDocument)
		{
			if (z0eek() == "PageSettings" || z0eek() == "DefaultStyle")
			{
				base.z0eek().z0rek(base.z0eek().z0tek() | (z0ZzZzbzj)3);
			}
			if (z0eek() == "Comments")
			{
				XTextDocument xTextDocument = (XTextDocument)z0rek;
				if (xTextDocument.z0ank() != null)
				{
					xTextDocument.z0ank().z0eb((z0ZzZzwcj)z0uek, (z0ZzZzwcj)z0tek);
				}
			}
		}
		if (z0rek is XTextInputFieldElementBase && z0eek() == "DefaultEventExpression")
		{
			((XTextInputFieldElementBase)z0rek).z0eek(p0: false);
		}
	}

	public override void z0yo(z0ZzZzpgh p0)
	{
		z0yek.SetValue(z0rek, z0tek, null);
		if (z0rek is XTextElement)
		{
			XTextElement xTextElement = (XTextElement)z0rek;
			xTextElement.z0xi(p0: true);
			base.z0eek().z0rek().Add(xTextElement);
			if (xTextElement is XTextFieldElementBase)
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xTextElement;
				if (xTextFieldElementBase.z0jrk() != null)
				{
					base.z0eek().z0rek().Add(xTextFieldElementBase.z0jrk());
				}
				if (xTextFieldElementBase.z0tek() != null)
				{
					base.z0eek().z0rek().Add(xTextFieldElementBase.z0tek());
				}
			}
		}
		if (z0rek is XTextTableRowElement && (z0eek() == "SpecifyHeight" || z0eek() == "HeaderStyle"))
		{
			base.z0eek().z0rek(base.z0eek().z0tek() | (z0ZzZzbzj)3);
		}
		if (z0rek is XTextDocument && (z0eek() == "PageSettings" || z0eek() == "DefaultStyle"))
		{
			base.z0eek().z0rek(base.z0eek().z0tek() | (z0ZzZzbzj)3);
		}
		if (z0eek() == "Comments")
		{
			XTextDocument xTextDocument = (XTextDocument)z0rek;
			if (xTextDocument.z0ank() != null)
			{
				xTextDocument.z0ank().z0eb((z0ZzZzwcj)z0uek, (z0ZzZzwcj)z0tek);
			}
		}
		if (z0rek is XTextInputFieldElementBase && z0eek() == "DefaultEventExpression")
		{
			((XTextInputFieldElementBase)z0rek).z0eek(p0: false);
		}
	}

	public z0ZzZzjlh(object p0, PropertyInfo p1, object p2, object p3)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("property");
		}
		z0rek = p0;
		z0yek = p1;
		z0uek = p2;
		z0tek = p3;
	}
}
