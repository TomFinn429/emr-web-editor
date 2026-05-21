using System.Collections.Generic;
using System.IO;
using System.Text;
using DCSoft.Chart;
using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Extension.Medical;
using DCSoft.Writer.MedicalExpression;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using DCSystem_Drawing.Printing;

namespace zzz;

public static class z0ZzZzghh
{
	private class z0gck : zzz.z0ZzZzkuk<char>
	{
		public new int z0rek = -1;

		private new bool z0tek = true;

		public void z0eek(XTextCharElement p0)
		{
			char c = p0.z0bek;
			if (c != ' ' && c != '\t' && c != '\r' && c != '\n')
			{
				z0tek = false;
			}
			Add(p0.z0bek);
			if (XTextCharElement.z0tek((int)p0.z0bek))
			{
				Add((char)p0.z0iek());
			}
			z0rek = p0.z0buk;
		}

		public void z0eek(z0ZzZzzjh p0)
		{
			if (base.Count > 0)
			{
				bool p1 = p0.z0pek();
				p0.z0rek(z0ZzZzfhh.z0tik);
				p0.z0rek(p0: false);
				if (z0rek >= 0)
				{
					p0.z0rek(z0ZzZzfhh.z0uzk, z0rek);
				}
				if (z0tek)
				{
					p0.z0rek(z0ZzZzfhh.z0mij, base.Count);
				}
				p0.z0rek(z0ZzZzfhh.z0tik, new string(z0atk, 0, base.Count));
				p0.z0mek();
				p0.z0rek(p1);
				z0wtk = 0;
				z0tek = true;
			}
		}

		public void z0eek(char p0)
		{
			if (p0 != ' ' && p0 != '\t' && p0 != '\r' && p0 != '\n')
			{
				z0tek = false;
			}
			Add(p0);
		}
	}

	private static readonly Color z0oek = Color.Red;

	private static readonly Color z0pek = Color.LightGray;

	private static readonly Color z0vek = Color.Transparent;

	private static readonly Color z0cek = Color.Black;

	private static readonly Color z0lrk = z0ZzZzhsh.z0yek;

	private static readonly Color z0hrk = Color.FromArgb(255, 128, 128, 128);

	private static readonly Color z0frk = Color.White;

	private static readonly Color z0srk = Color.Empty;

	internal static void z0tek(z0ZzZzzjh p0, RepeatedImageValue p1)
	{
		p0.z0rek(z0ZzZzfhh.z0rgj, p1.ImageDataBase64String);
		if (p1.ReferenceCount != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0qvk, p1.ReferenceCount);
		}
		if (p1.ValueIndex != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0wvk, p1.ValueIndex);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextTableRowElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		if (p1.SpecifyHeight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0ugj, p1.SpecifyHeight);
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (!p1.CanSplitByPageLine)
		{
			p0.z0rek(z0ZzZzfhh.z0amk, p1.CanSplitByPageLine);
		}
		if (p1.CloneType != TableRowCloneType.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0pqj, z0ZzZzfhh.z0eek(p1.CloneType), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.HeaderStyle)
		{
			p0.z0rek(z0ZzZzfhh.z0mnk, p1.HeaderStyle);
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.AllowInsertRowDownUseHotKey != DCInsertRowDownUseHotKeys.EnableOnlyForLastRow)
		{
			p0.z0rek(z0ZzZzfhh.z0vrk, z0ZzZzfhh.z0eek(p1.AllowInsertRowDownUseHotKey), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0bek())
		{
			p0.z0rek(z0ZzZzfhh.z0vmk, p1.z0bek());
		}
		if (p1.AllowUserToResizeHeight != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0qjj, z0ZzZzfhh.z0eek(p1.AllowUserToResizeHeight), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.z0rek() != null)
		{
			XTextElementList xTextElementList = p1.z0rek();
			int count = xTextElementList.Count;
			if (count > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0obk);
				p0.z0iek();
				for (int i = 0; i < count; i++)
				{
					p0.z0tek();
					z0tek(p0, (XTextTableCellElement)xTextElementList[i]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		if (p1.z0jrk() != 1)
		{
			p0.z0rek(z0ZzZzfhh.z0lrk, p1.z0jrk());
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		if (p1.z0uek() != 1)
		{
			p0.z0rek(z0ZzZzfhh.z0lbk, p1.z0uek());
		}
		p0.z0rek(z0ZzZzfhh.z0vzk, p1.z0nrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		if (!p1.ExpendForDataBinding)
		{
			p0.z0rek(z0ZzZzfhh.z0upk, p1.ExpendForDataBinding);
		}
		if (p1.z0yek())
		{
			p0.z0rek(z0ZzZzfhh.z0qik, p1.z0yek());
		}
		p0.z0rek(z0ZzZzfhh.z0tfj, p1.z0lrk());
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.NewPage)
		{
			p0.z0rek(z0ZzZzfhh.z0wtj, p1.NewPage);
		}
		if (!p1.PrintCellBackground)
		{
			p0.z0rek(z0ZzZzfhh.z0rpj, p1.PrintCellBackground);
		}
		if (!p1.PrintCellBorder)
		{
			p0.z0rek(z0ZzZzfhh.z0hkj, p1.PrintCellBorder);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static PropertyExpressionInfo z0tek(z0ZzZzxjh p0, PropertyExpressionInfo p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0yuj)
				{
					p1.Expression = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0ntj)
				{
					p1.Name = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0caj)
				{
					p1.AllowChainReaction = p0.z0vek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzptk p1)
	{
		if (!p1.z0nek())
		{
			p0.z0rek(z0ZzZzfhh.z0ttk, p1.z0nek());
		}
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0xik);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		if (p1.z0yek_jiejie20260327142557() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0rjj);
			z0tek(p0, p1.z0yek_jiejie20260327142557());
			p0.z0uek();
		}
		if (p1.z0tek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0jvj, p1.z0tek());
		}
		if (p1.z0uek() != 40)
		{
			p0.z0rek(z0ZzZzfhh.z0jik, p1.z0uek());
		}
		if (p1.z0pek() != 40f)
		{
			p0.z0rek(z0ZzZzfhh.z0ouk, p1.z0pek());
		}
		if (p1.z0bek().ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0ojj, p1.z0bek());
		}
		if (p1.z0eek())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0eek());
		}
	}

	internal static z0ZzZzfzj z0tek(z0ZzZzxjh p0, z0ZzZzfzj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0lpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzpmk()));
				}
			}
			else if (text == z0ZzZzfhh.z0jpj)
			{
				p1.z0eek(p0.z0pek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static ValueValidateStyle z0tek(z0ZzZzxjh p0, ValueValidateStyle p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0fej)
				{
					p1.MaxLength = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0hik)
				{
					p1.CheckMaxValue = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0kgj)
				{
					p1.ValueType = (ValueTypeStyle)p0.z0tek(z0ZzZzfhh.z0lgj);
				}
				else if (text == z0ZzZzfhh.z0dej)
				{
					p1.CustomMessage = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0huj)
				{
					p1.Required = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0toj)
				{
					p1.MaxValue = p0.z0oek();
				}
				else if (text == z0ZzZzfhh.z0kej)
				{
					p1.ExcludeKeywords = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0bpj)
				{
					p1.ValueName = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0tpj)
				{
					p1.MinValue = p0.z0oek();
				}
				else if (text == z0ZzZzfhh.z0mpk)
				{
					p1.RegExpression = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0nbk)
				{
					p1.CheckMinValue = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0jgj)
				{
					p1.MinLength = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0edj)
				{
					p1.BinaryLength = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0enk)
				{
					p1.CheckDecimalDigits = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0gaj)
				{
					p1.DateTimeMaxValue = p0.z0cek();
				}
				else if (text == z0ZzZzfhh.z0wij)
				{
					p1.DateTimeMinValue = p0.z0cek();
				}
				else if (text == z0ZzZzfhh.z0elj)
				{
					p1.IncludeKeywords = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0stj)
				{
					p1.Level = (ValueValidateLevel)p0.z0tek(z0ZzZzfhh.z0ryk);
				}
				else if (text == z0ZzZzfhh.z0xzk)
				{
					p1.MaxDecimalDigits = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0ebk)
				{
					p1.Range = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0thj)
				{
					p1.RequiredInvalidateFlag = p0.z0vek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static z0ZzZzfpk z0tek(z0ZzZzxjh p0, z0ZzZzfpk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0laj)
			{
				p1.z0eek(p0.z0tek(z0cek));
			}
			else if (text == z0ZzZzfhh.z0rjj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzimk()));
				}
			}
			else if (text == z0ZzZzfhh.z0onj)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0xek)
			{
				p1.z0tek(p0.z0bek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzykh z0tek(z0ZzZzxjh p0, z0ZzZzykh p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0jqj)
				{
					p1.z0rek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0yuj)
				{
					p1.z0eek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0zmj)
				{
					p1.z0eek((z0ZzZzikh)p0.z0tek(z0ZzZzfhh.z0ztj));
				}
				else if (text == z0ZzZzfhh.z0hej)
				{
					p1.z0yek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0tpk)
				{
					p1.z0tek(p0.z0bek());
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextDocumentFooterForFirstPageElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (XTextElementList.z0pek(p1.z0be()))
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, p1.z0be());
			p0.z0yek();
		}
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0vzk, ((XTextContainerElement)p1).z0nrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.SpecifyFixedLineHeight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0swj, p1.SpecifyFixedLineHeight);
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static XTextCharElement z0tek(z0ZzZzxjh p0, XTextCharElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0ghj)
			{
				p1.CharValue = p0.z0iek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static DCPieDataItem z0tek(z0ZzZzxjh p0, DCPieDataItem p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0laj)
				{
					p1.Color = p0.z0tek(z0vek);
				}
				else if (text == z0ZzZzfhh.z0aoj)
				{
					p1.Link = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0tik)
				{
					p1.Text = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0prj)
				{
					p1.TipText = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0jsj)
				{
					p1.Value = p0.z0oek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static z0ZzZzemk z0tek(z0ZzZzxjh p0, z0ZzZzemk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0laj)
			{
				p1.z0eek(p0.z0tek(z0vek));
			}
			else if (text == z0ZzZzfhh.z0uck)
			{
				p1.z0rek(p0.z0tek(z0cek));
			}
			else if (text == z0ZzZzfhh.z0lpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzpmk()));
				}
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0fyk)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0moj)
			{
				p1.z0eek(zzz.z0ZzZzcyk<XBrushStyleConst>.z0eek(p0.z0uek()));
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzymk z0tek(z0ZzZzxjh p0, z0ZzZzymk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0dfj)
				{
					p1.StringValue = p0.z0bek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, ListItem p1)
	{
		p0.z0rek(z0ZzZzfhh.z0tik, p1.Text);
		p0.z0rek(z0ZzZzfhh.z0jsj, p1.Value);
		p0.z0rek(z0ZzZzfhh.z0wik, p1.Group);
		p0.z0rek(z0ZzZzfhh.z0ftk, p1.TextInList);
		if (p1.CheckedTime.Ticks != 624511296000000000L)
		{
			p0.z0rek(z0ZzZzfhh.z0gzk, p1.CheckedTime);
		}
		p0.z0rek(z0ZzZzfhh.z0pyk, p1.EntryID);
		p0.z0rek(z0ZzZzfhh.z0coj, p1.z0uek());
		if (p1.ListIndex != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0sdj, p1.ListIndex);
		}
		if (p1.LonelyChecked)
		{
			p0.z0rek(z0ZzZzfhh.z0gmk, p1.LonelyChecked);
		}
		p0.z0rek(z0ZzZzfhh.z0uvj, p1.Tag);
	}

	internal static void z0tek(z0ZzZzzjh p0, DocumentInfo p1)
	{
		if (p1.z0irk() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0iek, p1.z0irk());
		}
		p0.z0rek(z0ZzZzfhh.z0ttj_jiejie20260327142557, p1.z0ork());
		p0.z0rek(z0ZzZzfhh.z0fuk, p1.z0nek());
		p0.z0rek(z0ZzZzfhh.z0zoj, p1.z0mek());
		p0.z0rek(z0ZzZzfhh.z0kik, p1.z0trk());
		p0.z0rek(z0ZzZzfhh.z0hyk, p1.z0grk());
		p0.z0rek(z0ZzZzfhh.z0coj, p1.z0srk());
		if (p1.ShowHeaderBottomLine != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0drj, z0ZzZzfhh.z0eek(p1.ShowHeaderBottomLine), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0mxk, p1.z0bek());
		p0.z0rek(z0ZzZzfhh.z0kuj, p1.z0mrk());
		if (p1.z0krk() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0ovk, p1.z0krk());
		}
		p0.z0rek(z0ZzZzfhh.z0qtk, p1.z0xek());
		if (p1.z0eek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0aik, p1.z0eek());
		}
		p0.z0rek(z0ZzZzfhh.z0kvk, p1.z0ark());
		p0.z0rek(z0ZzZzfhh.z0vtk, p1.z0nrk());
		p0.z0rek(z0ZzZzfhh.z0zwj, p1.z0cek());
		p0.z0rek(z0ZzZzfhh.z0cjj, p1.z0jrk());
		if (p1.z0vek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0mek, p1.z0vek());
		}
		p0.z0rek(z0ZzZzfhh.z0xyj, p1.z0erk());
		if (p1.z0qrk() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0nmk, p1.z0qrk());
		}
		if (p1.z0rek() != 1f)
		{
			p0.z0rek(z0ZzZzfhh.z0aij, p1.z0rek());
		}
		if (p1.z0urk() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0wpj, p1.z0urk());
		}
		if (p1.z0drk())
		{
			p0.z0rek(z0ZzZzfhh.z0ggj, p1.z0drk());
		}
		if (p1.z0tek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0eyj, p1.z0tek());
		}
		p0.z0rek(z0ZzZzfhh.z0oej, p1.z0wrk());
		p0.z0rek(z0ZzZzfhh.z0wxk, p1.z0oek());
		if (!p1.z0iek_jiejie20260327142557())
		{
			p0.z0rek(z0ZzZzfhh.z0pek, p1.z0iek_jiejie20260327142557());
		}
		if (p1.z0lrk())
		{
			p0.z0rek(z0ZzZzfhh.z0zck, p1.z0lrk());
		}
		if (p1.z0yrk() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0kzk, p1.z0yrk());
		}
		if (p1.z0frk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ibk);
			z0tek(p0, p1.z0frk());
			p0.z0uek();
		}
		if (p1.z0uek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0auk, p1.z0uek());
		}
		if (p1.z0pek())
		{
			p0.z0rek(z0ZzZzfhh.z0wfj, p1.z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0xnj, p1.z0hrk());
	}

	internal static DocumentInfo z0tek(z0ZzZzxjh p0, DocumentInfo p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0iek)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0ttj_jiejie20260327142557)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0fuk)
			{
				p1.z0nek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0zoj)
			{
				p1.z0vek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0kik)
			{
				p1.z0bek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0hyk)
			{
				p1.z0pek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.z0tek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0drj)
			{
				p1.ShowHeaderBottomLine = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0mxk)
			{
				p1.z0zek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0kuj)
			{
				p1.z0cek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0ovk)
			{
				p1.z0mek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0qtk)
			{
				p1.z0iek_jiejie20260327142557(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0aik)
			{
				p1.z0uek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0kvk)
			{
				p1.z0mek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vtk)
			{
				p1.z0tek(p0.z0cek());
			}
			else if (text == z0ZzZzfhh.z0zwj)
			{
				p1.z0uek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cjj)
			{
				p1.z0rek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0mek)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0xyj)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0nmk)
			{
				p1.z0rek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0aij)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0wpj)
			{
				p1.z0iek_jiejie20260327142557(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0ggj)
			{
				p1.z0iek_jiejie20260327142557(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0eyj)
			{
				p1.z0tek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0oej)
			{
				p1.z0rek(p0.z0cek());
			}
			else if (text == z0ZzZzfhh.z0wxk)
			{
				p1.z0eek(p0.z0cek());
			}
			else if (text == z0ZzZzfhh.z0pek)
			{
				p1.z0uek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zck)
			{
				p1.z0tek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0kzk)
			{
				p1.z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0ibk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new SubDocumentSettings()));
				}
			}
			else if (text == z0ZzZzfhh.z0auk)
			{
				p1.z0pek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0wfj)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0xnj)
			{
				p1.z0yek(p0.z0bek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static SubDocumentSettings z0tek(z0ZzZzxjh p0, SubDocumentSettings p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0kij)
				{
					p1.AllowSave = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0euk)
				{
					p1.BackColor = p0.z0tek(z0vek);
				}
				else if (text == z0ZzZzfhh.z0duk)
				{
					p1.BorderColor = p0.z0tek(z0vek);
				}
				else if (text == z0ZzZzfhh.z0fdj)
				{
					p1.EnablePermission = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0iij)
				{
					p1.Locked = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0wtj)
				{
					p1.NewPage = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0zck)
				{
					p1.Readonly = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0tsj)
				{
					p1.SubDocumentSpacing = p0.z0yek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static XAttribute z0tek(z0ZzZzxjh p0, XAttribute p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0ntj)
				{
					p1.z0eek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0jsj)
				{
					p1.z0rek(p0.z0bek());
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextRadioBoxElement p1)
	{
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.Checked)
		{
			p0.z0rek(z0ZzZzfhh.z0knk, p1.Checked);
		}
		p0.z0rek(z0ZzZzfhh.z0wcj, p1.Caption);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		if (p1.VisualStyle != CheckBoxVisualStyle.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0xaj, z0ZzZzfhh.z0eek(p1.VisualStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0wvj, p1.CheckedValue);
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (p1.AutoHeightForMultiline)
		{
			p0.z0rek(z0ZzZzfhh.z0srk, p1.AutoHeightForMultiline);
		}
		if (p1.BringoutToSave)
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.BringoutToSave);
		}
		if (p1.CanBeReferenced)
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.CanBeReferenced);
		}
		if (p1.CaptionAlign != StringAlignment.Center)
		{
			p0.z0rek(z0ZzZzfhh.z0ztk, z0ZzZzfhh.z0eek(p1.CaptionAlign), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.CaptionFlowLayout)
		{
			p0.z0rek(z0ZzZzfhh.z0emj, p1.CaptionFlowLayout);
		}
		if (!p1.CheckAlignLeft)
		{
			p0.z0rek(z0ZzZzfhh.z0lmk, p1.CheckAlignLeft);
		}
		if (!p1.CheckBoxVisible)
		{
			p0.z0rek(z0ZzZzfhh.z0uuk, p1.CheckBoxVisible);
		}
		if (p1.CheckboxVisibility != RenderVisibility.All)
		{
			p0.z0rek(z0ZzZzfhh.z0rpk, zzz.z0ZzZzcyk<RenderVisibility>.z0rek(p1.CheckboxVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.CheckedUserHistories != null)
		{
			z0ZzZzuhh checkedUserHistories = p1.CheckedUserHistories;
			int count = checkedUserHistories.Count;
			if (count > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0ixk);
				p0.z0iek();
				for (int i = 0; i < count; i++)
				{
					p0.z0tek();
					z0tek(p0, checkedUserHistories[i]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.DataName);
		if (p1.DefaultCheckedForValueBinding)
		{
			p0.z0rek(z0ZzZzfhh.z0kuk, p1.DefaultCheckedForValueBinding);
		}
		if (p1.EnableHighlight != EnableState.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0doj, z0ZzZzfhh.z0eek(p1.EnableHighlight), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		z0ZzZzukh z0ZzZzukh2 = p1.z0uek();
		if (z0ZzZzukh2 != null && z0ZzZzukh2.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0jfj);
			z0tek(p0, z0ZzZzukh2);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		if (((XTextObjectElement)p1).z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, ((XTextObjectElement)p1).z0iek());
			p0.z0uek();
		}
		if (p1.Multiline)
		{
			p0.z0rek(z0ZzZzfhh.z0raj, p1.Multiline);
		}
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		p0.z0rek(z0ZzZzfhh.z0vej, p1.PrintTextForChecked);
		p0.z0rek(z0ZzZzfhh.z0puk, p1.PrintTextForUnChecked);
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.PrintVisibilityWhenUnchecked != PrintVisibilityModeWhenUnchecked.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0pij, z0ZzZzfhh.z0eek(p1.PrintVisibilityWhenUnchecked), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.Readonly)
		{
			p0.z0rek(z0ZzZzfhh.z0zck, p1.Readonly);
		}
		if (p1.Requried)
		{
			p0.z0rek(z0ZzZzfhh.z0ynj, p1.Requried);
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static z0ZzZznmk z0tek(z0ZzZzxjh p0, z0ZzZznmk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0laj)
				{
					p1.Color = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0nnj)
				{
					p1.Width = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0otj)
				{
					p1.Alignment = (z0ZzZzgdh)p0.z0tek(z0ZzZzfhh.z0maj);
				}
				else if (text == z0ZzZzfhh.z0rok)
				{
					p1.DashCap = zzz.z0ZzZzcyk<DashCap>.z0eek(p0.z0uek());
				}
				else if (text == z0ZzZzfhh.z0cij)
				{
					p1.DashStyle = (DashStyle)p0.z0tek(z0ZzZzfhh.z0bnj);
				}
				else if (text == z0ZzZzfhh.z0xbj)
				{
					p1.EndCap = zzz.z0ZzZzcyk<z0ZzZzldh>.z0eek(p0.z0uek());
				}
				else if (text == z0ZzZzfhh.z0sfj)
				{
					p1.LineJoin = (z0ZzZzkdh)p0.z0tek(z0ZzZzfhh.z0mmj_jiejie20260327142557);
				}
				else if (text == z0ZzZzfhh.z0eik)
				{
					p1.MiterLimit = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0igj)
				{
					p1.StartCap = zzz.z0ZzZzcyk<z0ZzZzldh>.z0eek(p0.z0uek());
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static z0ZzZzguj z0tek(z0ZzZzxjh p0, z0ZzZzguj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
		{
			if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
			{
				string text = p0.z0mek();
				if (text == z0ZzZzfhh.z0unk)
				{
					p1.Add(z0tek(p0, new z0ZzZzluj()));
				}
				else if (text == z0ZzZzfhh.z0yek)
				{
					p1.Add(z0tek(p0, new z0ZzZzkuj()));
				}
				else if (text == z0ZzZzfhh.z0adj)
				{
					p1.Add(z0tek(p0, new z0ZzZzjuj()));
				}
				else if (text == z0ZzZzfhh.z0tvk)
				{
					p1.Add(z0tek(p0, new z0ZzZzxyj()));
				}
				else if (text == z0ZzZzfhh.z0ejj)
				{
					p1.Add(z0tek(p0, new z0ZzZzfuj()));
				}
				else if (text == z0ZzZzfhh.z0fbj)
				{
					p1.Add(z0tek(p0, new z0ZzZzuuj()));
				}
				else if (text == z0ZzZzfhh.z0vek)
				{
					p1.Add(z0tek(p0, new z0ZzZzauj()));
				}
				else if (text == z0ZzZzfhh.z0mbj)
				{
					p1.Add(z0tek(p0, new z0ZzZzquj()));
				}
				else if (text == z0ZzZzfhh.z0xyk)
				{
					p1.Add(z0tek(p0, new z0ZzZzwuj()));
				}
				else if (text == z0ZzZzfhh.z0cmk)
				{
					p1.Add(z0tek(p0, new z0ZzZziuj()));
				}
				else if (text == z0ZzZzfhh.z0zvk_jiejie20260327142557)
				{
					p1.Add(z0tek(p0, new z0ZzZzeuj()));
				}
				else if (text == z0ZzZzfhh.z0qrj)
				{
					p1.Add(z0tek(p0, new z0ZzZzhuj()));
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static XTextPieElement z0tek(z0ZzZzxjh p0, XTextPieElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0ypk)
			{
				p1.DataFieldNameForFillColorString = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0sbk)
			{
				p1.DataFieldNameForGroupName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hij)
			{
				p1.DataFieldNameForLink = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tyk)
			{
				p1.DataFieldNameForSeriesName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0iyj)
			{
				p1.DataFieldNameForText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dkj_jiejie20260327142557)
			{
				p1.DataFieldNameForTipText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0duj)
			{
				p1.DataFieldNameForValue = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gmj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				DCPieDataItemList dCPieDataItemList = new DCPieDataItemList();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						dCPieDataItemList.Add(z0tek(p0, new DCPieDataItem()));
					}
				}
				if (dCPieDataItemList.Count > 0)
				{
					p1.DataItems = dCPieDataItemList;
				}
			}
			else if (text == z0ZzZzfhh.z0pzk)
			{
				p1.DataSourceName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0emk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.PieDocumentStyle = z0tek(p0, new z0ZzZzztk());
				}
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzitk p1)
	{
		if (p1.z0eek().ToArgb() != -31)
		{
			p0.z0rek(z0ZzZzfhh.z0euk, p1.z0eek());
		}
		if (p1.z0rek().ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0duk, p1.z0rek());
		}
		if (p1.z0oek().ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0laj, p1.z0oek());
		}
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0rjj);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		if (p1.z0yek())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0yek());
		}
	}

	internal static DocumentParameter z0tek(z0ZzZzxjh p0, DocumentParameter p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0ntj)
				{
					p1.z0iek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0qbk)
				{
					p1.z0yek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0ioj)
				{
					p1.z0eek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0kuj)
				{
					p1.z0rek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0xij)
				{
					p1.z0uek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0jlj)
				{
					p1.z0tek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0kgj)
				{
					p1.z0eek((z0ZzZzjvj)p0.z0tek(z0ZzZzfhh.z0iaj));
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static z0ZzZzukh z0tek(z0ZzZzxjh p0, z0ZzZzukh p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
		{
			if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
			{
				p1.Add(z0tek(p0, new z0ZzZzykh()));
			}
		}
		return p1;
	}

	internal static z0ZzZziuj z0tek(z0ZzZzxjh p0, z0ZzZziuj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0yqj)
			{
				p1.z0tek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0qej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzcok()));
				}
			}
			else if (text == z0ZzZzfhh.z0hnj)
			{
				p1.z0zkk(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0kcj)
			{
				p1.z0eek_jiejie20260327142557(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0gtk)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.z0yek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0cuj)
			{
				p1.z0eek_jiejie20260327142557(p0.z0yek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextTableElement z0tek(z0ZzZzxjh p0, XTextTableElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0gij)
			{
				p1.z0nek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0dvj)
			{
				p1.z0bek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0ehj)
			{
				p1.CompressOwnerLineSpacing = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0xnk)
			{
				p1.AllowUserToResizeColumns = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ycj)
			{
				p1.AllowUserToResizeRows = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0vpj)
			{
				p1.z0mek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0otj)
			{
				p1.z0pek((DCTableAlignment)p0.z0tek(z0ZzZzfhh.z0dpj_jiejie20260327142557));
			}
			else if (text == z0ZzZzfhh.z0dzk)
			{
				p1.z0xek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0dtk)
			{
				p1.AllowUserDeleteRow = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0jrk)
			{
				p1.AllowUserInsertRow = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0fpj)
			{
				p1.z0pek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0uyj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				XTextElementList xTextElementList = new XTextElementList();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						xTextElementList.Add(z0tek(p0, new XTextTableColumnElement()));
					}
				}
				if (xTextElementList.Count > 0)
				{
					p1.z0mek(xTextElementList);
				}
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0rtk)
			{
				p1.z0pek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0goj)
			{
				p1.z0bek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0muk_jiejie20260327142557)
			{
				p1.PrintBothBorderWhenJumpPrint = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0bej)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				XTextElementList xTextElementList2 = new XTextElementList();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						xTextElementList2.Add(z0tek(p0, new XTextTableRowElement()));
					}
				}
				if (xTextElementList2.Count > 0)
				{
					p1.z0pek(xTextElementList2);
				}
			}
			else if (text == z0ZzZzfhh.z0dcj)
			{
				p1.z0pek((DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk));
			}
			else if (text == z0ZzZzfhh.z0wej)
			{
				p1.z0pek((TableSubfieldMode)p0.z0tek(z0ZzZzfhh.z0fpk));
			}
			else if (text == z0ZzZzfhh.z0fnj)
			{
				p1.z0mek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextLabelElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		PageLabelTextList pageTexts = p1.PageTexts;
		if (pageTexts != null && pageTexts.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0xok);
			z0tek(p0, pageTexts);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		if (!p1.Multiline)
		{
			p0.z0rek(z0ZzZzfhh.z0raj, p1.Multiline);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.Alignment != DCContentAlignment.MiddleCenter)
		{
			p0.z0rek(z0ZzZzfhh.z0otj, zzz.z0ZzZzcyk<DCContentAlignment>.z0rek(p1.Alignment), z0ZzZzeok.z0mjj.z0tek);
		}
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (!p1.AutoSize)
		{
			p0.z0rek(z0ZzZzfhh.z0ttk, p1.AutoSize);
		}
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		if (p1.z0rek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0tej, p1.z0rek());
		}
		p0.z0rek(z0ZzZzfhh.z0zbj, p1.AttributeNameForContactAction);
		p0.z0rek(z0ZzZzfhh.z0tnk, p1.LinkTextForContactAction);
		if (p1.ContactAction != LabelTextContactActionMode.Disable)
		{
			p0.z0rek(z0ZzZzfhh.z0omj, z0ZzZzfhh.z0eek(p1.ContactAction), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.AllowUserEditCurrentPageLabelText)
		{
			p0.z0rek(z0ZzZzfhh.z0jjj, p1.AllowUserEditCurrentPageLabelText);
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.StrictMatchPageIndex)
		{
			p0.z0rek(z0ZzZzfhh.z0kok, p1.StrictMatchPageIndex);
		}
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		p0.z0rek(z0ZzZzfhh.z0tik, p1.Text);
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextStringElement p1)
	{
		XTextElementList xTextElementList = p1.z0be();
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, xTextElementList);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		if (p1.z0eek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0apk, p1.z0eek());
		}
	}

	internal static XTextControlHostElement z0tek(z0ZzZzxjh p0, XTextControlHostElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0kvj)
			{
				p1.AllowUserResize = (ResizeableType)p0.z0tek(z0ZzZzfhh.z0sqj);
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0ngj)
			{
				p1.z0ey((z0ZzZzrxj)p0.z0tek(z0ZzZzfhh.z0yhj));
			}
			else if (text == z0ZzZzfhh.z0pkj)
			{
				p1.DelayLoadControl = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0wrj)
			{
				p1.z0eek((z0ZzZzgzj)p0.z0tek(z0ZzZzfhh.z0gpj));
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0nfj)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0hlj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				ObjectParameterList objectParameterList = new ObjectParameterList();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						objectParameterList.Add(z0tek(p0, new ObjectParameter()));
					}
				}
				if (objectParameterList.Count > 0)
				{
					p1.Parameters = objectParameterList;
				}
			}
			else if (text == z0ZzZzfhh.z0sxk)
			{
				p1.z0eek(p0.z0tek());
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0fwj)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.Text = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zdj)
			{
				p1.TypeFullName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0qok)
			{
				p1.VAlign = (VerticalAlignStyle)p0.z0tek(z0ZzZzfhh.z0jnk);
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0onk)
			{
				p1.ValuePropertyName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, PageLabelTextList p1)
	{
		if (p1.Count > 0)
		{
			p0.z0iek();
			int count = p1.Count;
			for (int i = 0; i < count; i++)
			{
				p0.z0tek();
				z0tek(p0, p1[i]);
				p0.z0mek();
			}
			p0.z0nek();
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextPageInfoElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0uqj, p1.FormatString);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		if (p1.AutoHeight)
		{
			p0.z0rek(z0ZzZzfhh.z0mck, p1.AutoHeight);
		}
		if (p1.ValueType != PageInfoValueType.PageIndex)
		{
			p0.z0rek(z0ZzZzfhh.z0kgj, z0ZzZzfhh.z0eek(p1.ValueType), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0tgj, p1.SpecifyPageIndexTextList);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (!p1.ChangePageIndexMidway)
		{
			p0.z0rek(z0ZzZzfhh.z0dnk, p1.ChangePageIndexMidway);
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.DisplayFormat != ParagraphListStyle.ListNumberStyle)
		{
			p0.z0rek(z0ZzZzfhh.z0jyj, zzz.z0ZzZzcyk<ParagraphListStyle>.z0rek(p1.DisplayFormat), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		if (p1.PageIndexFix != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0zhj, p1.PageIndexFix);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.SpecifyPageIndexs != null)
		{
			SpecifyPageIndexInfoList specifyPageIndexs = p1.SpecifyPageIndexs;
			int count = specifyPageIndexs.Count;
			if (count > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0qpj);
				p0.z0iek();
				for (int i = 0; i < count; i++)
				{
					p0.z0tek();
					z0tek(p0, specifyPageIndexs[i]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static z0ZzZzhyk z0tek(z0ZzZzxjh p0, z0ZzZzhyk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0euk)
			{
				p1.z0rek(p0.z0tek(z0lrk));
			}
			else if (text == z0ZzZzfhh.z0duk)
			{
				p1.z0eek(p0.z0tek(z0cek));
			}
			else if (text == z0ZzZzfhh.z0laj)
			{
				p1.z0tek(p0.z0tek(z0cek));
			}
			else if (text == z0ZzZzfhh.z0imj)
			{
				p1.z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0bek)
			{
				p1.z0rek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0ysj)
			{
				p1.z0eek((PieLabelType)p0.z0tek(z0ZzZzfhh.z0tyj));
			}
			else if (text == z0ZzZzfhh.z0rjj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzimk()));
				}
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextElementList z0tek(z0ZzZzxjh p0, XTextElementList p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
		{
			if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
			{
				string text = p0.z0mek();
				if (text == z0ZzZzfhh.z0tik)
				{
					p0.z0tek(p1);
				}
				else if (text == z0ZzZzfhh.z0txk)
				{
					p1.Add(z0tek(p0, new XTextParagraphFlagElement()));
				}
				else if (text == z0ZzZzfhh.z0bvj)
				{
					p1.Add(z0tek(p0, new XTextTableCellElement()));
				}
				else if (text == z0ZzZzfhh.z0ylj)
				{
					p1.Add(z0tek(p0, new XTextInputFieldElement()));
				}
				else if (text == z0ZzZzfhh.z0czk)
				{
					p1.Add(z0tek(p0, new XTextTableRowElement()));
				}
				else if (text == z0ZzZzfhh.z0vaj)
				{
					p1.Add(z0tek(p0, new XTextTableColumnElement()));
				}
				else if (text == z0ZzZzfhh.z0lpj)
				{
					p1.Add(z0tek(p0, new XTextImageElement()));
				}
				else if (text == z0ZzZzfhh.z0wqj)
				{
					p1.Add(z0tek(p0, new XTextCheckBoxElement()));
				}
				else if (text == z0ZzZzfhh.z0ocj)
				{
					p1.Add(z0tek(p0, new XTextRadioBoxElement()));
				}
				else if (text == z0ZzZzfhh.z0fck)
				{
					p1.Add(z0tek(p0, new XTextLabelElement()));
				}
				else if (text == z0ZzZzfhh.z0nnk)
				{
					p1.Add(z0tek(p0, new XTextTableElement()));
				}
				else if (text == z0ZzZzfhh.z0zlj)
				{
					p1.Add(z0tek(p0, new XTextMedicalExpressionFieldElement()));
				}
				else if (text == z0ZzZzfhh.z0daj)
				{
					p1.Add(z0tek(p0, new XTextDocument()));
				}
				else if (text == z0ZzZzfhh.z0prk)
				{
					p1.Add(z0tek(p0, new XTextDocumentBodyElement()));
				}
				else if (text == z0ZzZzfhh.z0uvk)
				{
					p1.Add(z0tek(p0, new XTextDocumentFooterElement()));
				}
				else if (text == z0ZzZzfhh.z0ubj)
				{
					p1.Add(z0tek(p0, new XTextDocumentFooterForFirstPageElement()));
				}
				else if (text == z0ZzZzfhh.z0otk)
				{
					p1.Add(z0tek(p0, new XTextDocumentHeaderElement()));
				}
				else if (text == z0ZzZzfhh.z0lck_jiejie20260327142557)
				{
					p1.Add(z0tek(p0, new XTextDocumentHeaderForFirstPageElement()));
				}
				else if (text == z0ZzZzfhh.z0zzk)
				{
					p1.Add(z0tek(p0, new XTextPageInfoElement()));
				}
				else if (text == z0ZzZzfhh.z0jrj)
				{
					p1.Add(z0tek(p0, new XTextSubDocumentElement()));
				}
				else if (text == z0ZzZzfhh.z0gbk)
				{
					p1.Add(z0tek(p0, new XTextSectionElement()));
				}
				else if (text == z0ZzZzfhh.z0pmk)
				{
					p1.Add(z0tek(p0, new XTextPageBreakElement()));
				}
				else if (text == z0ZzZzfhh.z0snk)
				{
					p1.Add(z0tek(p0, new XTextLineBreakElement()));
				}
				else if (text == z0ZzZzfhh.z0alj)
				{
					p1.Add(z0tek(p0, new XTextHorizontalLineElement()));
				}
				else if (text == z0ZzZzfhh.z0cyj)
				{
					p1.Add(z0tek(p0, new XTextDirectoryFieldElement()));
				}
				else if (text == z0ZzZzfhh.z0kpk)
				{
					p1.Add(z0tek(p0, new XTextBarcodeFieldElement()));
				}
				else if (text == z0ZzZzfhh.z0qgj)
				{
					p1.Add(z0tek(p0, new z0ZzZzilh()));
				}
				else if (text == z0ZzZzfhh.z0eyk)
				{
					p1.Add(z0tek(p0, new XTextBlankLineElement()));
				}
				else if (text == z0ZzZzfhh.z0qwj)
				{
					p1.Add(z0tek(p0, new z0ZzZzolh()));
				}
				else if (text == z0ZzZzfhh.z0myk)
				{
					p1.Add(z0tek(p0, new XTextButtonElement()));
				}
				else if (text == z0ZzZzfhh.z0zbk)
				{
					p1.Add(z0tek(p0, new XTextChartElement()));
				}
				else if (text == z0ZzZzfhh.z0pok)
				{
					p1.Add(z0tek(p0, new XTextCustomShapeElement()));
				}
				else if (text == z0ZzZzfhh.z0bhj)
				{
					p1.Add(z0tek(p0, new XTextMediaElement()));
				}
				else if (text == z0ZzZzfhh.z0xrk)
				{
					p1.Add(z0tek(p0, new XTextControlHostElement()));
				}
				else if (text == z0ZzZzfhh.z0vwj)
				{
					p1.Add(z0tek(p0, new XTextNewBarcodeElement()));
				}
				else if (text == z0ZzZzfhh.z0ktj)
				{
					p1.Add(z0tek(p0, new XTextNewMedicalExpressionElement()));
				}
				else if (text == z0ZzZzfhh.z0udj)
				{
					p1.Add(z0tek(p0, new XTextParagraphElement()));
				}
				else if (text == z0ZzZzfhh.z0vhj)
				{
					p1.Add(z0tek(p0, new XTextPieElement()));
				}
				else if (text == z0ZzZzfhh.z0jck)
				{
					p1.Add(z0tek(p0, new z0ZzZzjkh()));
				}
				else if (text == z0ZzZzfhh.z0cnj)
				{
					p1.Add(z0tek(p0, new XTextRulerElement()));
				}
				else if (text == z0ZzZzfhh.z0pdj)
				{
					p1.Add(z0tek(p0, new XTextSignElement()));
				}
				else if (text == z0ZzZzfhh.z0lij)
				{
					p1.Add(z0tek(p0, new XTextSignImageElement()));
				}
				else if (text == z0ZzZzfhh.z0tij)
				{
					p1.Add(z0tek(p0, new XTextStringElement()));
				}
				else if (text == z0ZzZzfhh.z0kfj)
				{
					p1.Add(z0tek(p0, new XTextTDBarcodeElement()));
				}
				else if (text == z0ZzZzfhh.z0tik)
				{
					p1.Add(z0tek(p0, new XTextTextElement()));
				}
				else if (text == z0ZzZzfhh.z0vuk)
				{
					p1.Add(z0tek(p0, new z0ZzZzdkh()));
				}
				else if (text == z0ZzZzfhh.z0tij)
				{
					p1.Add(z0tek(p0, new XTextCharElement()));
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static DocumentComment z0tek(z0ZzZzxjh p0, DocumentComment p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0kik)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vtk)
			{
				p1.z0eek(p0.z0cek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.z0pek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0qoj)
			{
				p1.z0tek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0eek(z0tek(p0, new XAttributeList()));
				}
			}
			else if (text == z0ZzZzfhh.z0xuk)
			{
				p1.z0rek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0euk)
			{
				p1.z0rek(p0.z0tek(z0srk));
			}
			else if (text == z0ZzZzfhh.z0yik)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0duk)
			{
				p1.z0eek(p0.z0tek(z0oek));
			}
			else if (text == z0ZzZzfhh.z0ltk)
			{
				p1.z0tek(p0.z0tek(z0cek));
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.z0mek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0xxk)
			{
				p1.z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0zoj)
			{
				p1.z0nek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.z0rek(p0.z0vek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzfuj z0tek(z0ZzZzxjh p0, z0ZzZzfuj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0yqj)
			{
				p1.z0tek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0qej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzcok()));
				}
			}
			else if (text == z0ZzZzfhh.z0hnj)
			{
				p1.z0zkk(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0gtk)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.z0yek(p0.z0yek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XPageSettings z0tek(z0ZzZzxjh p0, XPageSettings p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0vqj)
			{
				p1.LeftMargin = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0cdj)
			{
				p1.RightMargin = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0ytj)
			{
				p1.z0rek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0kkj)
			{
				p1.z0yek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0yej)
			{
				p1.TopMargin = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0fhj)
			{
				p1.BottomMargin = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0trk)
			{
				p1.z0mek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0xej)
			{
				p1.z0iek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0ykj)
			{
				p1.z0uek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0xpj_jiejie20260327142557)
			{
				p1.z0nek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0oaj)
			{
				p1.z0rek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0rsj)
			{
				p1.z0eek(zzz.z0ZzZzcyk<PaperKind>.z0eek(p0.z0uek()));
			}
			else if (text == z0ZzZzfhh.z0boj)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0aej)
			{
				p1.z0pek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0mdj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzpmk()));
				}
			}
			else if (text == z0ZzZzfhh.z0naj)
			{
				p1.z0uek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0ohj)
			{
				p1.z0uek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0buj)
			{
				p1.z0yek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0hnk)
			{
				p1.z0bek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0rqj)
			{
				p1.z0tek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0whj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.DocumentGridLine = z0tek(p0, new z0ZzZzzej());
				}
			}
			else if (text == z0ZzZzfhh.z0mcj)
			{
				p1.z0rek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0vpk)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0twj)
			{
				p1.z0tek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0kdj)
			{
				p1.z0eek((DCGutterStyle)p0.z0tek(z0ZzZzfhh.z0bxk));
			}
			else if (text == z0ZzZzfhh.z0oxk)
			{
				p1.z0mek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0cnk)
			{
				p1.z0pek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.z0iek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0muj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.PageBorderBackground = z0tek(p0, new z0ZzZzvpk());
				}
			}
			else if (text == z0ZzZzfhh.z0byj)
			{
				p1.z0tek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0mik)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0wzk)
			{
				p1.z0tek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zaj)
			{
				p1.z0mek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0frk)
			{
				p1.z0nek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0qtj)
			{
				p1.z0eek((DCDuplexType)p0.z0tek(z0ZzZzfhh.z0qvj));
			}
			else if (text == z0ZzZzfhh.z0jnj)
			{
				p1.z0vek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0dok)
			{
				p1.z0iek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0hqj)
			{
				p1.z0oek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0itk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzfpk()));
				}
			}
			else if (text == z0ZzZzfhh.z0kpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzwmk()));
				}
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextDocumentFooterElement z0tek(z0ZzZzxjh p0, XTextDocumentFooterElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0swj)
			{
				p1.SpecifyFixedLineHeight = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzyhh p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.z0zek());
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.z0yek());
		if (p1.z0pek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0xxk, p1.z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0uek, p1.z0mek());
		if (p1.z0rek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0qmj, p1.z0rek());
		}
		if (p1.z0vek())
		{
			p0.z0rek(z0ZzZzfhh.z0wvj, p1.z0vek());
		}
		p0.z0rek(z0ZzZzfhh.z0kuj, p1.z0uek());
		p0.z0rek(z0ZzZzfhh.z0wpk, p1.z0tek());
		p0.z0rek(z0ZzZzfhh.z0foj, p1.z0xek());
		p0.z0rek(z0ZzZzfhh.z0uvj, p1.z0bek());
	}

	internal static XTextSignElement z0tek(z0ZzZzxjh p0, XTextSignElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextInputFieldElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		XTextElementList xTextElementList = p1.z0be();
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, xTextElementList);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0pgj, p1.InnerValue);
		p0.z0rek(z0ZzZzfhh.z0hoj, p1.BackgroundText);
		if (p1.FieldSettings != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dbk);
			z0tek(p0, p1.FieldSettings);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		if (p1.EditorActiveMode != (ValueEditorActiveMode.Program | ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick))
		{
			p0.z0rek(z0ZzZzfhh.z0qfj, zzz.z0ZzZzcyk<ValueEditorActiveMode>.z0rek(p1.EditorActiveMode), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.EnableHighlight != EnableState.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0doj, z0ZzZzfhh.z0eek(p1.EnableHighlight), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.SpecifyWidth != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dij, p1.SpecifyWidth);
		}
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.UserEditable)
		{
			p0.z0rek(z0ZzZzfhh.z0vrj, p1.UserEditable);
		}
		if (p1.MoveFocusHotKey != MoveFocusHotKeys.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0tcj, zzz.z0ZzZzcyk<MoveFocusHotKeys>.z0rek(p1.MoveFocusHotKey), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BorderVisible != DCVisibleState.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0tvj, z0ZzZzfhh.z0eek(p1.BorderVisible), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.z0eek())
		{
			p0.z0rek(z0ZzZzfhh.z0lzk, p1.z0eek());
		}
		if (!p1.TabStop)
		{
			p0.z0rek(z0ZzZzfhh.z0dsj, p1.TabStop);
		}
		if (p1.DisplayFormat != null)
		{
			p0.z0yek(z0ZzZzfhh.z0jyj);
			z0tek(p0, p1.DisplayFormat);
			p0.z0uek();
		}
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gqj, p1.DefaultEventExpression);
		if (p1.BackgroundTextColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0lbj, p1.BackgroundTextColor);
		}
		if (p1.TextColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0ojj, p1.TextColor);
		}
		p0.z0rek(z0ZzZzfhh.z0zvj, p1.LabelText);
		if (!p1.z0yek())
		{
			p0.z0rek(z0ZzZzfhh.z0dxk, p1.z0yek());
		}
		p0.z0rek(z0ZzZzfhh.z0ack, p1.UnitText);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		if (p1.ViewEncryptType != ContentViewEncryptType.None)
		{
			p0.z0rek(z0ZzZzfhh.z0cmj, z0ZzZzfhh.z0eek(p1.ViewEncryptType), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		z0ZzZzukh eventExpressions = p1.EventExpressions;
		if (eventExpressions != null && eventExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0jfj);
			z0tek(p0, eventExpressions);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0phj, p1.EndBorderText);
		p0.z0rek(z0ZzZzfhh.z0njj, p1.StartBorderText);
		if (p1.AcceptTab)
		{
			p0.z0rek(z0ZzZzfhh.z0gdj, p1.AcceptTab);
		}
		if (p1.z0rek() != InputFieldAdornTextType.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0hdj, z0ZzZzfhh.z0eek(p1.z0rek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.Alignment != StringAlignment.Near)
		{
			p0.z0rek(z0ZzZzfhh.z0otj, z0ZzZzfhh.z0eek(p1.Alignment), z0ZzZzeok.z0mjj.z0tek);
		}
		if (((XTextInputFieldElementBase)p1).z0pek())
		{
			p0.z0rek(z0ZzZzfhh.z0ltj, ((XTextInputFieldElementBase)p1).z0pek());
		}
		if (p1.z0pek())
		{
			p0.z0rek(z0ZzZzfhh.z0nxk, p1.z0pek());
		}
		if (((XTextFieldElementBase)p1).z0drk() != DCBooleanValueHasDefault.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0cgj, z0ZzZzfhh.z0eek(((XTextFieldElementBase)p1).z0drk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BorderElementColor.ToArgb() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0lhj, p1.BorderElementColor);
		}
		if (((XTextInputFieldElementBase)p1).z0oek() != (z0ZzZzscj)1)
		{
			p0.z0rek(z0ZzZzfhh.z0tlj, z0ZzZzfhh.z0eek(((XTextInputFieldElementBase)p1).z0oek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		p0.z0rek(z0ZzZzfhh.z0gxk, p1.z0drk());
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0vzk, p1.z0nrk());
		p0.z0rek(z0ZzZzfhh.z0gpk, p1.z0xek());
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.z0vek())
		{
			p0.z0rek(z0ZzZzfhh.z0evj, p1.z0vek());
		}
		if (!p1.EnableValueValidate)
		{
			p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		}
		if (p1.EndingLineBreak)
		{
			p0.z0rek(z0ZzZzfhh.z0gok, p1.EndingLineBreak);
		}
		if (((XTextInputFieldElementBase)p1).z0rek() != DCFastInputMode.NextField)
		{
			p0.z0rek(z0ZzZzfhh.z0syj, z0ZzZzfhh.z0eek(((XTextInputFieldElementBase)p1).z0rek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0iek() != FormButtonStyle.Auto)
		{
			p0.z0rek(z0ZzZzfhh.z0gvk, z0ZzZzfhh.z0eek(p1.z0iek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		if (p1.LableUnitTextBold != DCBooleanValueHasDefault.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0zij, z0ZzZzfhh.z0eek(p1.LableUnitTextBold), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.z0nek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0tek);
			z0tek(p0, p1.z0nek());
			p0.z0uek();
		}
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (((XTextInputFieldElementBase)p1).z0cek() != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0yyj, z0ZzZzfhh.z0eek(((XTextInputFieldElementBase)p1).z0cek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		if (p1.z0krk() != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0ivk, z0ZzZzfhh.z0eek(p1.z0krk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0frk() != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0ekj, z0ZzZzfhh.z0eek(p1.z0frk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.TabIndex != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0blj, p1.TabIndex);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
		if (p1.z0uek())
		{
			p0.z0rek("SensitiveData", p1.z0uek());
		}
	}

	internal static z0ZzZzpdh z0tek(z0ZzZzxjh p0)
	{
		z0ZzZzpdh z0ZzZzpdh2 = default(z0ZzZzpdh);
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0euj)
				{
					z0ZzZzpdh2.z0eek(p0.z0yek());
				}
				else if (text == z0ZzZzfhh.z0pyj)
				{
					z0ZzZzpdh2.z0rek(p0.z0yek());
				}
				else
				{
					p0.z0tek(z0ZzZzpdh2, text);
				}
			}
		}
		return z0ZzZzpdh2;
	}

	internal static z0ZzZzwmk z0tek(z0ZzZzxjh p0, z0ZzZzwmk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0uhj)
			{
				p1.Alpha = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0rrk)
			{
				p1.Angle = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0euk)
			{
				p1.BackColor = p0.z0tek(z0frk);
			}
			else if (text == z0ZzZzfhh.z0laj)
			{
				p1.Color = p0.z0tek(z0cek);
			}
			else if (text == z0ZzZzfhh.z0yok)
			{
				p1.DensityForRepeat = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0rjj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.Font = z0tek(p0, new z0ZzZzimk());
				}
			}
			else if (text == z0ZzZzfhh.z0lpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.Image = z0tek(p0, new z0ZzZzpmk());
				}
			}
			else if (text == z0ZzZzfhh.z0fyk)
			{
				p1.Repeat = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.Text = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0ook)
			{
				p1.Type = (WatermarkType)p0.z0tek(z0ZzZzfhh.z0pxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzitk z0tek(z0ZzZzxjh p0, z0ZzZzitk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0euk)
			{
				p1.z0rek(p0.z0tek(z0lrk));
			}
			else if (text == z0ZzZzfhh.z0duk)
			{
				p1.z0eek(p0.z0tek(z0cek));
			}
			else if (text == z0ZzZzfhh.z0laj)
			{
				p1.z0tek(p0.z0tek(z0cek));
			}
			else if (text == z0ZzZzfhh.z0rjj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzimk()));
				}
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.z0eek(p0.z0vek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZznmk p1)
	{
		if (p1.Color.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0laj, p1.Color);
		}
		if (p1.Width != 1f)
		{
			p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		}
		if (p1.Alignment != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0otj, z0ZzZzfhh.z0eek(p1.Alignment), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.DashCap != DashCap.Flat)
		{
			p0.z0rek(z0ZzZzfhh.z0rok, zzz.z0ZzZzcyk<DashCap>.z0rek(p1.DashCap), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.DashStyle != DashStyle.Solid)
		{
			p0.z0rek(z0ZzZzfhh.z0cij, z0ZzZzfhh.z0eek(p1.DashStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.EndCap != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0xbj, zzz.z0ZzZzcyk<z0ZzZzldh>.z0rek(p1.EndCap), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.LineJoin != (z0ZzZzkdh)1)
		{
			p0.z0rek(z0ZzZzfhh.z0sfj, z0ZzZzfhh.z0eek(p1.LineJoin), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.MiterLimit != 10f)
		{
			p0.z0rek(z0ZzZzfhh.z0eik, p1.MiterLimit);
		}
		if (p1.StartCap != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0igj, zzz.z0ZzZzcyk<z0ZzZzldh>.z0rek(p1.StartCap), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzykh p1)
	{
		p0.z0rek(z0ZzZzfhh.z0jqj, p1.z0tek());
		p0.z0rek(z0ZzZzfhh.z0yuj, p1.z0yek());
		if (p1.z0rek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0zmj, z0ZzZzfhh.z0eek(p1.z0rek()), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0hej, p1.z0iek());
		p0.z0rek(z0ZzZzfhh.z0tpk, p1.z0uek());
	}

	internal static z0ZzZzwuj z0tek(z0ZzZzxjh p0, z0ZzZzwuj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0yqj)
			{
				p1.z0tek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0qej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzcok()));
				}
			}
			else if (text == z0ZzZzfhh.z0uwj)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0hnj)
			{
				p1.z0zkk(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				((z0ZzZzeuj)p1).z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0gtk)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.z0yek(p0.z0yek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzuuj p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, ((z0ZzZzhuj)p1).z0yek());
		if (p1.z0uek())
		{
			p0.z0rek(z0ZzZzfhh.z0wrk, p1.z0uek());
		}
		if (p1.z0yek())
		{
			p0.z0rek(z0ZzZzfhh.z0acj, p1.z0yek());
		}
		if (p1.z0pek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0qej);
			z0tek(p0, p1.z0pek());
			p0.z0uek();
		}
		if (((z0ZzZzhuj)p1).z0eek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((z0ZzZzhuj)p1).z0eek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.z0rek());
		if (!p1.z0rek_jiejie20260327142557())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0rek_jiejie20260327142557());
		}
		if (((z0ZzZzauj)p1).z0eek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0eoj, ((z0ZzZzauj)p1).z0eek());
		}
		if (((z0ZzZzauj)p1).z0yek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0pik, ((z0ZzZzauj)p1).z0yek());
		}
		if (((z0ZzZzauj)p1).z0uek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0mbk, ((z0ZzZzauj)p1).z0uek());
		}
		if (((z0ZzZzauj)p1).z0rek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0eqj, ((z0ZzZzauj)p1).z0rek());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, InputFieldSettings p1)
	{
		if (p1.z0zek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0exk);
			z0tek(p0, p1.z0zek());
			p0.z0uek();
		}
		if (p1.z0nek() != InputFieldEditStyle.Text)
		{
			p0.z0rek(z0ZzZzfhh.z0jhj, z0ZzZzfhh.z0eek(p1.z0nek()), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0sbj, p1.z0tek());
		if (p1.z0yek())
		{
			p0.z0rek(z0ZzZzfhh.z0rkj, p1.z0yek());
		}
		p0.z0rek(z0ZzZzfhh.z0mfj, p1.z0oek());
		if (p1.z0uek())
		{
			p0.z0rek(z0ZzZzfhh.z0vnk, p1.z0uek());
		}
		if (p1.z0iek())
		{
			p0.z0rek(z0ZzZzfhh.z0vij, p1.z0iek());
		}
		if (p1.z0bek())
		{
			p0.z0rek(z0ZzZzfhh.z0jdj, p1.z0bek());
		}
		if (p1.z0xek())
		{
			p0.z0rek(z0ZzZzfhh.z0vdj, p1.z0xek());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzevj p1)
	{
		p0.z0rek(z0ZzZzfhh.z0srj, p1.DataSource);
		p0.z0rek(z0ZzZzfhh.z0soj, p1.BindingPath);
		if (p1.z0yek())
		{
			p0.z0rek(z0ZzZzfhh.z0sij, p1.z0yek());
		}
		p0.z0rek(z0ZzZzfhh.z0rfj, p1.BindingPathForText);
		if (!p1.z0eek())
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.z0eek());
		}
		if (p1.ProcessState != DCProcessStates.Always)
		{
			p0.z0rek(z0ZzZzfhh.z0wwj, z0ZzZzfhh.z0eek(p1.ProcessState), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0rek())
		{
			p0.z0rek(z0ZzZzfhh.z0zck, p1.z0rek());
		}
		p0.z0rek(z0ZzZzfhh.z0wyk, p1.WriteTextBindingPath);
	}

	internal static RepeatedImageValue z0tek(z0ZzZzxjh p0, RepeatedImageValue p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0rgj)
				{
					p1.ImageDataBase64String = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0qvk)
				{
					p1.ReferenceCount = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0wvk)
				{
					p1.ValueIndex = p0.z0pek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static z0ZzZzdkh z0tek(z0ZzZzxjh p0, z0ZzZzdkh p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0pmj)
			{
				p1.z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XAttributeList z0tek(z0ZzZzxjh p0, XAttributeList p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
		{
			if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
			{
				p1.Add(z0tek(p0, new XAttribute()));
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextDocument p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0hmj, p1.z0xuk());
		if (p1.Comments != null)
		{
			z0ZzZzwcj comments = p1.Comments;
			int count = comments.Count;
			if (count > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0ytk);
				p0.z0iek();
				for (int i = 0; i < count; i++)
				{
					p0.z0tek();
					z0tek(p0, comments[i]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		if (p1.z0omk() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0ruk, p1.z0omk());
		}
		XTextElementList xTextElementList = p1.z0be();
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, xTextElementList);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0fgj, p1.z0ftk());
		p0.z0rek(z0ZzZzfhh.z0xtj, p1.z0amk());
		if (p1.z0gpk() != null)
		{
			z0ZzZzkvj z0ZzZzkvj2 = p1.z0gpk();
			int count2 = z0ZzZzkvj2.Count;
			if (count2 > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0hlj);
				p0.z0iek();
				for (int j = 0; j < count2; j++)
				{
					p0.z0tek();
					z0tek(p0, z0ZzZzkvj2[j]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		if (p1.z0syk() != null)
		{
			z0ZzZzuhh z0ZzZzuhh2 = p1.z0syk();
			int count3 = z0ZzZzuhh2.Count;
			if (count3 > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0nwj);
				p0.z0iek();
				for (int k = 0; k < count3; k++)
				{
					p0.z0tek();
					z0tek(p0, z0ZzZzuhh2[k]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.AcceptTab)
		{
			p0.z0rek(z0ZzZzfhh.z0gdj, p1.AcceptTab);
		}
		if (p1.z0umk() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0yoj, p1.z0umk());
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.z0gnk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0quk);
			z0tek(p0, p1.z0gnk());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0vzk, ((XTextContainerElement)p1).z0nrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.z0ptk())
		{
			p0.z0rek(z0ZzZzfhh.z0hyj, p1.z0ptk());
		}
		p0.z0rek(z0ZzZzfhh.z0qcj, p1.z0mmk());
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (p1.z0ipk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0fzk);
			z0tek(p0, p1.z0ipk());
			p0.z0uek();
		}
		if (p1.z0fyk() != null)
		{
			List<byte[]> list = p1.z0fyk();
			int count4 = list.Count;
			if (count4 > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0cck);
				p0.z0iek();
				for (int l = 0; l < count4; l++)
				{
					p0.z0rek(list[l]);
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		p0.z0rek(z0ZzZzfhh.z0awj, p1.z0tuk());
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.z0fnk() != MeasureMode.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0vkj, z0ZzZzfhh.z0eek(p1.z0fnk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.PageSettings != null)
		{
			p0.z0yek(z0ZzZzfhh.z0frj);
			z0tek(p0, p1.PageSettings);
			p0.z0uek();
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.z0nmk() != null)
		{
			RepeatedImageValueList repeatedImageValueList = p1.z0nmk();
			int count5 = repeatedImageValueList.Count;
			if (count5 > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0zyj);
				p0.z0iek();
				for (int m = 0; m < count5; m++)
				{
					p0.z0tek();
					z0tek(p0, repeatedImageValueList[m]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		p0.z0rek(z0ZzZzfhh.z0ksj, p1.z0tnk());
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static z0ZzZzatk z0tek(z0ZzZzxjh p0, z0ZzZzatk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
		{
			if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
			{
				p1.Add(z0tek(p0, new z0ZzZzstk()));
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzfvj p1)
	{
		if (p1.AutoSetFirstItems)
		{
			p0.z0rek(z0ZzZzfhh.z0tmj, p1.AutoSetFirstItems);
		}
		if (!p1.AutoUpdateTargetElement)
		{
			p0.z0rek(z0ZzZzfhh.z0gik, p1.AutoUpdateTargetElement);
		}
		if (p1.IsRoot)
		{
			p0.z0rek(z0ZzZzfhh.z0ncj, p1.IsRoot);
		}
		if (p1.NextTarget != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0rik, z0ZzZzfhh.z0eek(p1.NextTarget), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0eaj, p1.NextTargetID);
		p0.z0rek(z0ZzZzfhh.z0rnj, p1.ProviderName);
		p0.z0rek(z0ZzZzfhh.z0cpk, p1.UserFlag);
	}

	internal static void z0tek(z0ZzZzzjh p0, DCContentLockInfo p1)
	{
		p0.z0rek(z0ZzZzfhh.z0clj, p1.AuthorisedUserIDList);
		p0.z0rek(z0ZzZzfhh.z0vtk, p1.CreationTime);
		p0.z0rek(z0ZzZzfhh.z0xvj, p1.OwnerUserID);
	}

	internal static z0ZzZzfvj z0tek(z0ZzZzxjh p0, z0ZzZzfvj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0tmj)
				{
					p1.AutoSetFirstItems = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0gik)
				{
					p1.AutoUpdateTargetElement = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0ncj)
				{
					p1.IsRoot = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0rik)
				{
					p1.NextTarget = (z0ZzZzikh)p0.z0tek(z0ZzZzfhh.z0ztj);
				}
				else if (text == z0ZzZzfhh.z0eaj)
				{
					p1.NextTargetID = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0rnj)
				{
					p1.ProviderName = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0cpk)
				{
					p1.UserFlag = p0.z0bek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzpdh p1)
	{
		p0.z0rek(z0ZzZzfhh.z0euj, p1.z0rek());
		p0.z0rek(z0ZzZzfhh.z0pyj, p1.z0tek());
	}

	internal static z0ZzZzhuj z0tek(z0ZzZzxjh p0, z0ZzZzhuj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0qej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzcok()));
				}
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.z0eek(p0.z0vek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzbtk z0tek(z0ZzZzxjh p0, z0ZzZzbtk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0gsj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				List<z0ZzZzymk> list = new List<z0ZzZzymk>();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						list.Add(z0tek(p0, new z0ZzZzymk()));
					}
				}
				if (list.Count > 0)
				{
					p1.z0eek(list);
				}
			}
			else if (text == z0ZzZzfhh.z0iyk_jiejie20260327142557)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0rvj)
			{
				p1.z0rek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0avj)
			{
				p1.z0rek((ColorThemeType)p0.z0tek(z0ZzZzfhh.z0kwj));
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextParagraphFlagElement z0tek(z0ZzZzxjh p0, XTextParagraphFlagElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0khj)
			{
				((XTextElement)p1).z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0cvk)
			{
				p1.z0rek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0luk)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0urj)
			{
				p1.z0eek(p0.z0vek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzsvj z0tek(z0ZzZzxjh p0, z0ZzZzsvj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0huk)
			{
				p1.SourceName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gbj)
			{
				p1.DisplayPath = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0ark)
			{
				p1.ValuePath = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cik)
			{
				p1.BufferItems = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0cuk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Items = z0tek(p0, new z0ZzZzdvj());
				}
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzbuk z0tek(z0ZzZzxjh p0, z0ZzZzbuk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0zgj)
				{
					p1.Reference = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0zoj)
				{
					p1.Title = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0zmj)
				{
					p1.Target = p0.z0bek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	public static void z0tek(TextWriter p0, XTextDocument p1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (p0 is StringWriter)
		{
			stringBuilder = ((StringWriter)p0).GetStringBuilder();
		}
		z0ZzZzzjh z0ZzZzzjh2 = new z0ZzZzzjh(stringBuilder, p1.z0vtk().BehaviorOptions.OutputFormatedXMLSource);
		try
		{
			z0ZzZzdhh.z0eek(p1);
			z0ZzZzzjh2.z0rek(z0ZzZzfhh.z0daj);
			z0tek(z0ZzZzzjh2, p1);
			z0ZzZzzjh2.z0mek();
		}
		finally
		{
			XTextImageElement.z0ftk = null;
			if (p1.z0fyk() != null)
			{
				p1.z0fyk().Clear();
				p1.z0pek(null);
			}
		}
		if (!(p0 is StringWriter))
		{
			string text = stringBuilder.ToString();
			p0.Write(text);
		}
	}

	internal static z0ZzZzquj z0tek(z0ZzZzxjh p0, z0ZzZzquj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0qej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzcok()));
				}
			}
			else if (text == z0ZzZzfhh.z0uwj)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.z0eek(p0.z0vek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZziuj p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, ((z0ZzZzhuj)p1).z0yek());
		if (p1.z0eek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0oek, p1.z0eek());
		}
		if (((z0ZzZzeuj)p1).z0rek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0yqj, ((z0ZzZzeuj)p1).z0rek());
		}
		if (((z0ZzZzhuj)p1).z0pek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0qej);
			z0tek(p0, ((z0ZzZzhuj)p1).z0pek());
			p0.z0uek();
		}
		if (!p1.z0xkk())
		{
			p0.z0rek(z0ZzZzfhh.z0hnj, p1.z0xkk());
		}
		if (p1.z0eek_jiejie20260327142557())
		{
			p0.z0rek(z0ZzZzfhh.z0kcj, p1.z0eek_jiejie20260327142557());
		}
		if (((z0ZzZzhuj)p1).z0eek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((z0ZzZzhuj)p1).z0eek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.z0pek());
		if (p1.z0oek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0gtk, p1.z0oek());
		}
		if (!p1.z0rek_jiejie20260327142557())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0rek_jiejie20260327142557());
		}
		if (p1.z0mek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0nnj, p1.z0mek());
		}
		if (p1.z0rek() != 2f)
		{
			p0.z0rek(z0ZzZzfhh.z0cuj, p1.z0rek());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextParagraphElement p1)
	{
		XTextElementList xTextElementList = p1.z0be();
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, xTextElementList);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.AcceptTab)
		{
			p0.z0rek(z0ZzZzfhh.z0gdj, p1.AcceptTab);
		}
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0vzk, p1.z0nrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, p1.z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static DocumentContentStyle z0tek(z0ZzZzxjh p0, DocumentContentStyle p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0asj)
				{
					p1.FontName = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0pck)
				{
					p1.FontSize = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0xxk)
				{
					p1.Index = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0laj)
				{
					p1.Color = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0gnj)
				{
					p1.Align = (DocumentContentAlignment)p0.z0tek(z0ZzZzfhh.z0xfj);
				}
				else if (text == z0ZzZzfhh.z0etj)
				{
					p1.BorderWidth = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0uaj)
				{
					p1.PaddingLeft = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0pvj)
				{
					p1.LineSpacingStyle = (LineSpacingStyle)p0.z0tek(z0ZzZzfhh.z0lcj);
				}
				else if (text == z0ZzZzfhh.z0vyk)
				{
					p1.Bold = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0jvk)
				{
					p1.BorderBottom = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0esj)
				{
					p1.PaddingTop = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0gjj)
				{
					p1.PaddingBottom = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0vgj)
				{
					p1.BorderTop = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0wmj)
				{
					p1.BorderLeft = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0lej)
				{
					p1.BorderRight = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0nmj)
				{
					p1.LineSpacing = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0dik)
				{
					p1.VerticalAlign = (VerticalAlignStyle)p0.z0tek(z0ZzZzfhh.z0jnk);
				}
				else if (text == z0ZzZzfhh.z0cpj)
				{
					p1.PaddingRight = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0hbj)
				{
					p1.FirstLineIndent = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0idj)
				{
					p1.SpacingBeforeParagraph = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0kbj_jiejie20260327142557)
				{
					p1.SpacingAfterParagraph = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0ilj)
				{
					p1.ProtectType = (ContentProtectType)p0.z0tek(z0ZzZzfhh.z0lnk);
				}
				else if (text == z0ZzZzfhh.z0qoj)
				{
					p1.CreatorIndex = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0wok)
				{
					p1.Underline = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0okj)
				{
					p1.BackgroundColor = p0.z0tek(z0vek);
				}
				else if (text == z0ZzZzfhh.z0vpj)
				{
					p1.LeftIndent = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0uik)
				{
					p1.BorderRightColor = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0nyj)
				{
					p1.BorderLeftColor = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0suk)
				{
					p1.DeleterIndex = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0azk)
				{
					p1.BorderBottomColor = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0uyk)
				{
					p1.BorderTopColor = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0dvk)
				{
					p1.GridLineType = (ContentGridLineType)p0.z0tek(z0ZzZzfhh.z0vvj);
				}
				else if (text == z0ZzZzfhh.z0ooj)
				{
					p1.TitleLevel = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0wkj)
				{
					p1.LayoutDirection = (ContentLayoutDirectionStyle)p0.z0tek(z0ZzZzfhh.z0vmj);
				}
				else if (text == z0ZzZzfhh.z0ink)
				{
					p1.BorderSpacing = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0ijj)
				{
					p1.ParagraphListStyle = zzz.z0ZzZzcyk<ParagraphListStyle>.z0eek(p0.z0uek());
				}
				else if (text == z0ZzZzfhh.z0olj)
				{
					p1.ParagraphMultiLevel = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0bqj_jiejie20260327142557)
				{
					p1.ParagraphOutlineLevel = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0rmk)
				{
					p1.Subscript = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0jbk)
				{
					p1.CommentIndex = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0ljj)
				{
					p1.PrintBackColor = p0.z0tek(z0srk);
				}
				else if (text == z0ZzZzfhh.z0mzk)
				{
					p1.PrintColor = p0.z0tek(z0vek);
				}
				else if (text == z0ZzZzfhh.z0svk)
				{
					p1.Superscript = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0wdj)
				{
					p1.CharacterCircle = (CharacterCircleStyles)p0.z0tek(z0ZzZzfhh.z0pvk);
				}
				else if (text == z0ZzZzfhh.z0rbj)
				{
					p1.GridLineStyle = (DashStyle)p0.z0tek(z0ZzZzfhh.z0bnj);
				}
				else if (text == z0ZzZzfhh.z0lrj)
				{
					p1.Visibility = zzz.z0ZzZzcyk<RenderVisibility>.z0eek(p0.z0uek());
				}
				else if (text == z0ZzZzfhh.z0crj)
				{
					p1.BackgroundColor2 = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0nck)
				{
					p1.BorderStyle = (DashStyle)p0.z0tek(z0ZzZzfhh.z0bnj);
				}
				else if (text == z0ZzZzfhh.z0jtk)
				{
					p1.Cursor = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0fqj)
				{
					p1.EmphasisMark = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0lvk)
				{
					p1.FixedSpacing = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0xlj)
				{
					p1.GridLineColor = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0ctj)
				{
					p1.GridLineOffsetY = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0wtk)
				{
					p1.Italic = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0dqj)
				{
					p1.LayoutAlign = (ContentLayoutAlign)p0.z0tek(z0ZzZzfhh.z0stk);
				}
				else if (text == z0ZzZzfhh.z0qpk)
				{
					p1.LetterSpacing = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0lpk)
				{
					p1.MarginBottom = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0oik)
				{
					p1.MarginLeft = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0nej)
				{
					p1.MarginRight = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0sck)
				{
					p1.MarginTop = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0raj)
				{
					p1.Multiline = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0hvk)
				{
					p1.RTFLineSpacing = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0dlj)
				{
					p1.RightToLeft = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0tbj)
				{
					p1.Strikeout = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0jmk)
				{
					p1.UnderlineColor = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0joj)
				{
					p1.UnderlineStyle = (TextUnderlineStyle)p0.z0tek(z0ZzZzfhh.z0lik);
				}
				else if (text == z0ZzZzfhh.z0ptj)
				{
					p1.VisibleInDirectory = p0.z0vek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static z0ZzZzyhh z0tek(z0ZzZzxjh p0, z0ZzZzyhh p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0coj)
				{
					p1.z0tek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0ntj)
				{
					p1.z0uek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0xxk)
				{
					p1.z0rek(p0.z0pek());
				}
				else if (text == z0ZzZzfhh.z0uek)
				{
					p1.z0eek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0qmj)
				{
					p1.z0eek(p0.z0pek());
				}
				else if (text == z0ZzZzfhh.z0wvj)
				{
					p1.z0eek(p0.z0vek());
				}
				else if (text == z0ZzZzfhh.z0kuj)
				{
					p1.z0iek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0wpk)
				{
					p1.z0rek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0foj)
				{
					p1.z0tek(p0.z0cek());
				}
				else if (text == z0ZzZzfhh.z0uvj)
				{
					p1.z0yek(p0.z0bek());
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static z0ZzZzjkh z0tek(z0ZzZzxjh p0, z0ZzZzjkh p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0hnj)
			{
				p1.z0et((ResizeableType)p0.z0tek(z0ZzZzfhh.z0sqj));
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.Text = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzqtk z0tek(z0ZzZzxjh p0, z0ZzZzqtk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0rrk)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0paj)
			{
				p1.z0eek((AxisCompressStyle)p0.z0tek(z0ZzZzfhh.z0brj));
			}
			else if (text == z0ZzZzfhh.z0qzk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0rek(z0tek(p0, new z0ZzZznmk()));
				}
			}
			else if (text == z0ZzZzfhh.z0fik)
			{
				p1.z0tek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0lmj)
			{
				p1.z0eek(p0.z0oek());
			}
			else if (text == z0ZzZzfhh.z0ubk)
			{
				p1.z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0mlj)
			{
				p1.z0mek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0wcj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzstk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ozk)
			{
				p1.z0eek((ColorThemeType)p0.z0tek(z0ZzZzfhh.z0kwj));
			}
			else if (text == z0ZzZzfhh.z0iuk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0rek(z0tek(p0, new z0ZzZzbtk()));
				}
			}
			else if (text == z0ZzZzfhh.z0epj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbtk()));
				}
			}
			else if (text == z0ZzZzfhh.z0rjj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzimk()));
				}
			}
			else if (text == z0ZzZzfhh.z0zjj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzemk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ymk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZznmk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ywj)
			{
				p1.z0uek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0ctj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0rbj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0yek(z0tek(p0, new z0ZzZznmk()));
				}
			}
			else if (text == z0ZzZzfhh.z0roj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0tek(z0tek(p0, new z0ZzZznmk()));
				}
			}
			else if (text == z0ZzZzfhh.z0nuk)
			{
				p1.z0iek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0qqj_jiejie20260327142557)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0btk)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0umk)
			{
				p1.z0rek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0faj)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0smk)
			{
				p1.z0eek((StringAlignment)p0.z0tek(z0ZzZzfhh.z0arj));
			}
			else if (text == z0ZzZzfhh.z0poj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzitk()));
				}
			}
			else if (text == z0ZzZzfhh.z0hmk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzptk()));
				}
			}
			else if (text == z0ZzZzfhh.z0gjj)
			{
				p1.z0pek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0uaj)
			{
				p1.z0nek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0cpj)
			{
				p1.z0bek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0esj)
			{
				p1.z0vek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0fij)
			{
				p1.z0tek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0ojj)
			{
				p1.z0eek(p0.z0tek(z0cek));
			}
			else if (text == z0ZzZzfhh.z0zrk)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0jmj)
			{
				p1.z0rek((StringAlignment)p0.z0tek(z0ZzZzfhh.z0arj));
			}
			else if (text == z0ZzZzfhh.z0xrj)
			{
				p1.z0rek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lvj)
			{
				p1.z0eek((ChartViewStyle)p0.z0tek(z0ZzZzfhh.z0vlj));
			}
			else if (text == z0ZzZzfhh.z0gfj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0rek(z0tek(p0, new z0ZzZzstk()));
				}
			}
			else if (text == z0ZzZzfhh.z0yrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzatk()));
				}
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextBlankLineElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		if (p1.Height != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		}
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, SubDocumentSettings p1)
	{
		if (!p1.AllowSave)
		{
			p0.z0rek(z0ZzZzfhh.z0kij, p1.AllowSave);
		}
		if (p1.BackColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0euk, p1.BackColor);
		}
		if (p1.BorderColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0duk, p1.BorderColor);
		}
		if (p1.EnablePermission)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, p1.EnablePermission);
		}
		if (p1.Locked)
		{
			p0.z0rek(z0ZzZzfhh.z0iij, p1.Locked);
		}
		if (p1.NewPage)
		{
			p0.z0rek(z0ZzZzfhh.z0wtj, p1.NewPage);
		}
		if (p1.Readonly)
		{
			p0.z0rek(z0ZzZzfhh.z0zck, p1.Readonly);
		}
		if (p1.SubDocumentSpacing != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0tsj, p1.SubDocumentSpacing);
		}
	}

	internal static z0ZzZzeuj z0tek(z0ZzZzxjh p0, z0ZzZzeuj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0oek)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0yqj)
			{
				p1.z0tek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0qej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzcok()));
				}
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0gtk)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.z0yek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0hnj)
			{
				p1.z0zkk(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.z0eek(p0.z0vek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextDirectoryFieldElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.BorderVisible != DCVisibleState.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0tvj, z0ZzZzfhh.z0eek(p1.BorderVisible), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.DisplayLevel != 3)
		{
			p0.z0rek(z0ZzZzfhh.z0ukj_jiejie20260327142557, p1.DisplayLevel);
		}
		XTextElementList xTextElementList = p1.z0be();
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, xTextElementList);
			p0.z0yek();
		}
		if (p1.EnableHighlight != EnableState.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0doj, z0ZzZzfhh.z0eek(p1.EnableHighlight), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.AcceptTab)
		{
			p0.z0rek(z0ZzZzfhh.z0gdj, p1.AcceptTab);
		}
		if (p1.Alignment != StringAlignment.Near)
		{
			p0.z0rek(z0ZzZzfhh.z0otj, z0ZzZzfhh.z0eek(p1.Alignment), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0pek())
		{
			p0.z0rek(z0ZzZzfhh.z0ltj, p1.z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0hoj, p1.BackgroundText);
		if (p1.BackgroundTextColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0lbj, p1.BackgroundTextColor);
		}
		if (((XTextFieldElementBase)p1).z0drk() != DCBooleanValueHasDefault.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0cgj, z0ZzZzfhh.z0eek(((XTextFieldElementBase)p1).z0drk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BorderElementColor.ToArgb() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0lhj, p1.BorderElementColor);
		}
		if (p1.z0oek() != (z0ZzZzscj)1)
		{
			p0.z0rek(z0ZzZzfhh.z0tlj, z0ZzZzfhh.z0eek(p1.z0oek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0gqj, p1.DefaultEventExpression);
		p0.z0rek(z0ZzZzfhh.z0vzk, p1.z0nrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.DisplayFormat != null)
		{
			p0.z0yek(z0ZzZzfhh.z0jyj);
			z0tek(p0, p1.DisplayFormat);
			p0.z0uek();
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.EnableValueValidate)
		{
			p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		}
		p0.z0rek(z0ZzZzfhh.z0phj, p1.EndBorderText);
		if (p1.EndingLineBreak)
		{
			p0.z0rek(z0ZzZzfhh.z0gok, p1.EndingLineBreak);
		}
		z0ZzZzukh eventExpressions = p1.EventExpressions;
		if (eventExpressions != null && eventExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0jfj);
			z0tek(p0, eventExpressions);
			p0.z0yek();
		}
		if (((XTextInputFieldElementBase)p1).z0rek() != DCFastInputMode.NextField)
		{
			p0.z0rek(z0ZzZzfhh.z0syj, z0ZzZzfhh.z0eek(((XTextInputFieldElementBase)p1).z0rek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		p0.z0rek(z0ZzZzfhh.z0pgj, p1.InnerValue);
		p0.z0rek(z0ZzZzfhh.z0zvj, p1.LabelText);
		if (p1.LableUnitTextBold != DCBooleanValueHasDefault.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0zij, z0ZzZzfhh.z0eek(p1.LableUnitTextBold), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.MoveFocusHotKey != MoveFocusHotKeys.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0tcj, zzz.z0ZzZzcyk<MoveFocusHotKeys>.z0rek(p1.MoveFocusHotKey), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.z0cek() != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0yyj, z0ZzZzfhh.z0eek(p1.z0cek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (!p1.ShowPageIndex)
		{
			p0.z0rek(z0ZzZzfhh.z0abk, p1.ShowPageIndex);
		}
		if (p1.SpecifyWidth != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dij, p1.SpecifyWidth);
		}
		p0.z0rek(z0ZzZzfhh.z0njj, p1.StartBorderText);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		if (p1.TabIndex != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0blj, p1.TabIndex);
		}
		if (!p1.TabStop)
		{
			p0.z0rek(z0ZzZzfhh.z0dsj, p1.TabStop);
		}
		if (p1.TextColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0ojj, p1.TextColor);
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		p0.z0rek(z0ZzZzfhh.z0ack, p1.UnitText);
		if (!p1.UserEditable)
		{
			p0.z0rek(z0ZzZzfhh.z0vrj, p1.UserEditable);
		}
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (p1.ViewEncryptType != ContentViewEncryptType.None)
		{
			p0.z0rek(z0ZzZzfhh.z0cmj, z0ZzZzfhh.z0eek(p1.ViewEncryptType), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzwuj p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, ((z0ZzZzhuj)p1).z0yek());
		if (((z0ZzZzeuj)p1).z0eek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0oek, ((z0ZzZzeuj)p1).z0eek());
		}
		if (((z0ZzZzeuj)p1).z0rek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0yqj, ((z0ZzZzeuj)p1).z0rek());
		}
		if (((z0ZzZzhuj)p1).z0pek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0qej);
			z0tek(p0, ((z0ZzZzhuj)p1).z0pek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0uwj, p1.z0eek());
		if (!p1.z0xkk())
		{
			p0.z0rek(z0ZzZzfhh.z0hnj, p1.z0xkk());
		}
		if (((z0ZzZzhuj)p1).z0eek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((z0ZzZzhuj)p1).z0eek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.z0pek());
		if (p1.z0oek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0gtk, p1.z0oek());
		}
		if (!p1.z0rek_jiejie20260327142557())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0rek_jiejie20260327142557());
		}
		if (p1.z0mek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0nnj, p1.z0mek());
		}
	}

	internal static z0ZzZzxyj z0tek(z0ZzZzxjh p0, z0ZzZzxyj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0qjk(z0tek(p0, new z0ZzZzguj()));
				}
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0yqj)
			{
				p1.z0tek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0qej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzcok()));
				}
			}
			else if (text == z0ZzZzfhh.z0hnj)
			{
				p1.z0zkk(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0gtk)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.z0yek(p0.z0yek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static SpecifyPageIndexInfo z0tek(z0ZzZzxjh p0, SpecifyPageIndexInfo p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0ymj)
				{
					p1.RawPageIndex = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0lyk)
				{
					p1.SpecifyPageIndex = p0.z0pek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static XTextHorizontalLineElement z0tek(z0ZzZzxjh p0, XTextHorizontalLineElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0pnk)
			{
				p1.LineSize = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0kmk)
			{
				p1.LineLengthInCM = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0nkj)
			{
				p1.LineStyle = (DashStyle)p0.z0tek(z0ZzZzfhh.z0bnj);
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzkuj p1)
	{
		if (!p1.z0rek())
		{
			p0.z0rek(z0ZzZzfhh.z0ttk, p1.z0rek());
		}
		if (((z0ZzZzeuj)p1).z0eek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0oek, ((z0ZzZzeuj)p1).z0eek());
		}
		if (((z0ZzZzeuj)p1).z0rek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0yqj, ((z0ZzZzeuj)p1).z0rek());
		}
		if (((z0ZzZzhuj)p1).z0pek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0qej);
			z0tek(p0, ((z0ZzZzhuj)p1).z0pek());
			p0.z0uek();
		}
		if (((z0ZzZzhuj)p1).z0eek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((z0ZzZzhuj)p1).z0eek());
		}
		if (p1.z0oek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0gtk, p1.z0oek());
		}
		if (p1.z0mek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0nnj, p1.z0mek());
		}
		z0ZzZzguj z0ZzZzguj2 = p1.z0djk();
		if (z0ZzZzguj2 != null && z0ZzZzguj2.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0tek(p0, z0ZzZzguj2);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0coj, ((z0ZzZzhuj)p1).z0yek());
		if (p1.z0eek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0lpj);
			z0tek(p0, p1.z0eek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.z0pek());
		if (!p1.z0rek_jiejie20260327142557())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0rek_jiejie20260327142557());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextDocumentHeaderElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (XTextElementList.z0pek(p1.z0be()))
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, p1.z0be());
			p0.z0yek();
		}
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0vzk, ((XTextContainerElement)p1).z0nrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.SpecifyFixedLineHeight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0swj, p1.SpecifyFixedLineHeight);
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzhyk p1)
	{
		if (p1.z0oek().ToArgb() != -31)
		{
			p0.z0rek(z0ZzZzfhh.z0euk, p1.z0oek());
		}
		if (p1.z0mek().ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0duk, p1.z0mek());
		}
		if (p1.z0rek().ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0laj, p1.z0rek());
		}
		if (p1.z0uek() != 20)
		{
			p0.z0rek(z0ZzZzfhh.z0imj, p1.z0uek());
		}
		if (p1.z0tek() != 2)
		{
			p0.z0rek(z0ZzZzfhh.z0bek, p1.z0tek());
		}
		if (p1.z0pek() != PieLabelType.OutLabel)
		{
			p0.z0rek(z0ZzZzfhh.z0ysj, z0ZzZzfhh.z0eek(p1.z0pek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0eek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0rjj);
			z0tek(p0, p1.z0eek());
			p0.z0uek();
		}
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
	}

	internal static XTextPageInfoElement z0tek(z0ZzZzxjh p0, XTextPageInfoElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0uqj)
			{
				p1.FormatString = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0mck)
			{
				p1.AutoHeight = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0kgj)
			{
				p1.ValueType = (PageInfoValueType)p0.z0tek(z0ZzZzfhh.z0tok);
			}
			else if (text == z0ZzZzfhh.z0tgj)
			{
				p1.SpecifyPageIndexTextList = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0dnk)
			{
				p1.ChangePageIndexMidway = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0jyj)
			{
				p1.DisplayFormat = zzz.z0ZzZzcyk<ParagraphListStyle>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0zhj)
			{
				p1.PageIndexFix = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0qpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				SpecifyPageIndexInfoList specifyPageIndexInfoList = new SpecifyPageIndexInfoList();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						specifyPageIndexInfoList.Add(z0tek(p0, new SpecifyPageIndexInfo()));
					}
				}
				if (specifyPageIndexInfoList.Count > 0)
				{
					p1.SpecifyPageIndexs = specifyPageIndexInfoList;
				}
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzztk z0tek(z0ZzZzxjh p0, z0ZzZzztk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0wcj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzstk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ozk)
			{
				p1.z0eek((ColorThemeType)p0.z0tek(z0ZzZzfhh.z0kwj));
			}
			else if (text == z0ZzZzfhh.z0iuk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbtk()));
				}
			}
			else if (text == z0ZzZzfhh.z0wgj)
			{
				p1.z0eek((DrawingStyle)p0.z0tek(z0ZzZzfhh.z0fmk));
			}
			else if (text == z0ZzZzfhh.z0icj)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0ayj)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0cxk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZznmk()));
				}
			}
			else if (text == z0ZzZzfhh.z0poj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzhyk()));
				}
			}
			else if (text == z0ZzZzfhh.z0hmk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzptk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ufj)
			{
				p1.z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0qyk)
			{
				p1.z0eek(p0.z0oek());
			}
			else if (text == z0ZzZzfhh.z0dmj)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0zrk)
			{
				p1.z0rek(p0.z0pek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, ScaleProperty p1)
	{
		if (p1.ScaleRate != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0htj, p1.ScaleRate);
		}
		if (p1.Value != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0jsj, p1.Value);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, DocumentContentStyleContainer p1)
	{
		if (p1.Default != null)
		{
			p0.z0yek(z0ZzZzfhh.z0sok);
			z0tek(p0, (DocumentContentStyle)p1.Default);
			p0.z0uek();
		}
		if (p1.Styles == null)
		{
			return;
		}
		z0ZzZzzok styles = p1.Styles;
		int count = styles.Count;
		if (count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0djj);
			p0.z0iek();
			for (int i = 0; i < count; i++)
			{
				p0.z0tek();
				z0tek(p0, (DocumentContentStyle)styles[i]);
				p0.z0mek();
			}
			p0.z0nek();
			p0.z0yek();
		}
	}

	internal static z0ZzZzsok z0tek(z0ZzZzxjh p0, z0ZzZzsok p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0rdj)
				{
					p1.Format = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0moj)
				{
					p1.Style = (ValueFormatStyle)p0.z0tek(z0ZzZzfhh.z0nzk);
				}
				else if (text == z0ZzZzfhh.z0pbk)
				{
					p1.NoneText = p0.z0bek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzjkh p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0hnj, z0ZzZzfhh.z0eek(p1.z0wt()), z0ZzZzeok.z0mjj.z0tek);
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.Text);
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzeuj p1)
	{
		if (p1.z0eek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0oek, p1.z0eek());
		}
		if (p1.z0rek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0yqj, p1.z0rek());
		}
		if (((z0ZzZzhuj)p1).z0pek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0qej);
			z0tek(p0, ((z0ZzZzhuj)p1).z0pek());
			p0.z0uek();
		}
		if (((z0ZzZzhuj)p1).z0eek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((z0ZzZzhuj)p1).z0eek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.z0pek());
		if (p1.z0oek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0gtk, p1.z0oek());
		}
		if (p1.z0mek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0nnj, p1.z0mek());
		}
		p0.z0rek(z0ZzZzfhh.z0coj, ((z0ZzZzhuj)p1).z0yek());
		if (!p1.z0xkk())
		{
			p0.z0rek(z0ZzZzfhh.z0hnj, p1.z0xkk());
		}
		if (!p1.z0rek_jiejie20260327142557())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0rek_jiejie20260327142557());
		}
	}

	internal static XTextDocumentFooterForFirstPageElement z0tek(z0ZzZzxjh p0, XTextDocumentFooterForFirstPageElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0swj)
			{
				p1.SpecifyFixedLineHeight = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextLineBreakElement z0tek(z0ZzZzxjh p0, XTextLineBreakElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static ScaleProperty z0tek(z0ZzZzxjh p0, ScaleProperty p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0htj)
				{
					p1.ScaleRate = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0jsj)
				{
					p1.Value = p0.z0yek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static PageLabelTextList z0tek(z0ZzZzxjh p0, PageLabelTextList p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
		{
			if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
			{
				p1.Add(z0tek(p0, new PageLabelText()));
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextTDBarcodeElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.BarcodeType != DCTDBarcodeType.QR)
		{
			p0.z0rek(z0ZzZzfhh.z0hhj, z0ZzZzfhh.z0eek(p1.BarcodeType), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		if (p1.ErroeCorrectionLevel != DCTBErroeCorrectionLevelType.M)
		{
			p0.z0rek(z0ZzZzfhh.z0gcj, z0ZzZzfhh.z0eek(p1.ErroeCorrectionLevel), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		PageLabelTextList pageTexts = p1.PageTexts;
		if (pageTexts != null && pageTexts.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0xok);
			z0tek(p0, pageTexts);
			p0.z0yek();
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.StrictMatchPageIndex)
		{
			p0.z0rek(z0ZzZzfhh.z0kok, p1.StrictMatchPageIndex);
		}
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.Text);
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.VAlign != VerticalAlignStyle.Bottom)
		{
			p0.z0rek(z0ZzZzfhh.z0qok, z0ZzZzfhh.z0eek(p1.VAlign), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, DocumentParameter p1)
	{
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.z0eek());
		p0.z0rek(z0ZzZzfhh.z0qbk, p1.z0uek());
		p0.z0rek(z0ZzZzfhh.z0ioj, p1.z0nek());
		p0.z0rek(z0ZzZzfhh.z0kuj, p1.z0pek());
		p0.z0rek(z0ZzZzfhh.z0xij, p1.z0mek());
		p0.z0rek(z0ZzZzfhh.z0jlj, p1.z0iek());
		if (p1.z0tek() != (z0ZzZzjvj)7)
		{
			p0.z0rek(z0ZzZzfhh.z0kgj, z0ZzZzfhh.z0eek(p1.z0tek()), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static XTextParagraphElement z0tek(z0ZzZzxjh p0, XTextParagraphElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0gdj)
			{
				p1.AcceptTab = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzpmk z0tek(z0ZzZzxjh p0, z0ZzZzpmk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0uij)
				{
					p1.ImageData = p0.z0tek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static PageLabelText z0tek(z0ZzZzxjh p0, PageLabelText p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0tik)
				{
					p1.Text = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0jpj)
				{
					p1.PageIndex = p0.z0pek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzilh p1)
	{
		XTextElementList xTextElementList = p1.z0be();
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, xTextElementList);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.AcceptTab)
		{
			p0.z0rek(z0ZzZzfhh.z0gdj, p1.AcceptTab);
		}
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.BackgroundTextColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0lbj, p1.BackgroundTextColor);
		}
		if (p1.z0drk() != DCBooleanValueHasDefault.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0cgj, z0ZzZzfhh.z0eek(p1.z0drk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BorderElementColor.ToArgb() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0lhj, p1.BorderElementColor);
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0vzk, p1.z0nrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		p0.z0rek(z0ZzZzfhh.z0phj, p1.EndBorderText);
		if (p1.EndingLineBreak)
		{
			p0.z0rek(z0ZzZzfhh.z0gok, p1.EndingLineBreak);
		}
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		if (p1.LableUnitTextBold != DCBooleanValueHasDefault.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0zij, z0ZzZzfhh.z0eek(p1.LableUnitTextBold), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0njj, p1.StartBorderText);
		if (p1.z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, p1.z0pek());
		}
		if (p1.TextColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0ojj, p1.TextColor);
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextChartElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.z0tek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0nik);
			z0tek(p0, p1.z0tek());
			p0.z0uek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0sbk, p1.z0yek());
		p0.z0rek(z0ZzZzfhh.z0hij, p1.z0oek());
		p0.z0rek(z0ZzZzfhh.z0tyk, p1.z0cek());
		p0.z0rek(z0ZzZzfhh.z0iyj, p1.z0mek());
		p0.z0rek(z0ZzZzfhh.z0dkj_jiejie20260327142557, p1.z0uek());
		p0.z0rek(z0ZzZzfhh.z0duj, p1.z0pek());
		if (p1.z0bek() != null)
		{
			DCChartDataItemList dCChartDataItemList = p1.z0bek();
			int count = dCChartDataItemList.Count;
			if (count > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0gmj);
				p0.z0iek();
				for (int i = 0; i < count; i++)
				{
					p0.z0tek();
					z0tek(p0, dCChartDataItemList[i]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		p0.z0rek(z0ZzZzfhh.z0pzk, p1.z0iek());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		if (((XTextObjectElement)p1).z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, ((XTextObjectElement)p1).z0iek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static XTextBlankLineElement z0tek(z0ZzZzxjh p0, XTextBlankLineElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, ObjectParameter p1)
	{
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		p0.z0rek(z0ZzZzfhh.z0jsj, p1.Value);
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzjuk p1)
	{
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		p0.z0rek(z0ZzZzfhh.z0jsj, p1.Value);
	}

	internal static void z0tek(z0ZzZzzjh p0, SpecifyPageIndexInfo p1)
	{
		if (p1.RawPageIndex != 1)
		{
			p0.z0rek(z0ZzZzfhh.z0ymj, p1.RawPageIndex);
		}
		if (p1.SpecifyPageIndex != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0lyk, p1.SpecifyPageIndex);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextRulerElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		if (p1.Font != null)
		{
			p0.z0yek(z0ZzZzfhh.z0rjj);
			z0tek(p0, p1.Font);
			p0.z0uek();
		}
		if (p1.Height != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		}
		if (p1.LineColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0juj, p1.LineColor);
		}
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		if (p1.MaxScale != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0zfj, p1.MaxScale);
		}
		if (p1.MinScale != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0pfj, p1.MinScale);
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		p0.z0rek(z0ZzZzfhh.z0yjj, p1.Precision);
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.RulerValue != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0iuj, p1.RulerValue);
		}
		if (p1.Scales != null)
		{
			ScalePropertyList scales = p1.Scales;
			int count = scales.Count;
			if (count > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0qaj);
				p0.z0iek();
				for (int i = 0; i < count; i++)
				{
					p0.z0tek();
					z0tek(p0, scales[i]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		if (p1.Width != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		}
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzqtk p1)
	{
		if (p1.z0cek() != 45f)
		{
			p0.z0rek(z0ZzZzfhh.z0rrk, p1.z0cek());
		}
		if (p1.z0ark() != AxisCompressStyle.AutoSize)
		{
			p0.z0rek(z0ZzZzfhh.z0paj, z0ZzZzfhh.z0eek(p1.z0ark()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0qrk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0qzk);
			z0tek(p0, p1.z0qrk());
			p0.z0uek();
		}
		if (p1.z0ktk() != 20)
		{
			p0.z0rek(z0ZzZzfhh.z0fik, p1.z0ktk());
		}
		if (p1.z0ork() != 1.0)
		{
			p0.z0rek(z0ZzZzfhh.z0lmj, p1.z0ork());
		}
		if (p1.z0vek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0ubk, p1.z0vek());
		}
		if (p1.z0pek() != 50)
		{
			p0.z0rek(z0ZzZzfhh.z0mlj, p1.z0pek());
		}
		if (p1.z0jrk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0wcj);
			z0tek(p0, p1.z0jrk());
			p0.z0uek();
		}
		if (p1.z0htk() != ColorThemeType.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0ozk, z0ZzZzfhh.z0eek(p1.z0htk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0brk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0iuk);
			z0tek(p0, p1.z0brk());
			p0.z0uek();
		}
		if (p1.z0yek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0epj);
			z0tek(p0, p1.z0yek());
			p0.z0uek();
		}
		if (p1.z0gtk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0rjj);
			z0tek(p0, p1.z0gtk());
			p0.z0uek();
		}
		if (p1.z0wrk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zjj);
			z0tek(p0, p1.z0wrk());
			p0.z0uek();
		}
		if (p1.z0xrk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ymk);
			z0tek(p0, p1.z0xrk());
			p0.z0uek();
		}
		if (p1.z0rek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0ywj, p1.z0rek());
		}
		if (p1.z0frk() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0ctj, p1.z0frk());
		}
		if (p1.z0ltk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0rbj);
			z0tek(p0, p1.z0ltk());
			p0.z0uek();
		}
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0roj);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		if (p1.z0zrk() != 60)
		{
			p0.z0rek(z0ZzZzfhh.z0nuk, p1.z0zrk());
		}
		if (p1.z0irk() != 100)
		{
			p0.z0rek(z0ZzZzfhh.z0qqj_jiejie20260327142557, p1.z0irk());
		}
		p0.z0rek(z0ZzZzfhh.z0btk, p1.z0srk());
		if (p1.z0krk() != 10)
		{
			p0.z0rek(z0ZzZzfhh.z0umk, p1.z0krk());
		}
		if (!p1.z0xek())
		{
			p0.z0rek(z0ZzZzfhh.z0faj, p1.z0xek());
		}
		if (p1.z0nek() != StringAlignment.Center)
		{
			p0.z0rek(z0ZzZzfhh.z0smk, z0ZzZzfhh.z0eek(p1.z0nek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0grk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0poj);
			z0tek(p0, p1.z0grk());
			p0.z0uek();
		}
		if (p1.z0erk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0hmk);
			z0tek(p0, p1.z0erk());
			p0.z0uek();
		}
		if (p1.z0lrk() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0gjj, p1.z0lrk());
		}
		if (p1.z0urk() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0uaj, p1.z0urk());
		}
		if (p1.z0zek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0cpj, p1.z0zek());
		}
		if (p1.z0drk() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0esj, p1.z0drk());
		}
		if (p1.z0vrk() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0fij, p1.z0vrk());
		}
		if (p1.z0mrk().ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0ojj, p1.z0mrk());
		}
		if (p1.z0uek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0zrk, p1.z0uek());
		}
		if (p1.z0nrk() != StringAlignment.Near)
		{
			p0.z0rek(z0ZzZzfhh.z0jmj, z0ZzZzfhh.z0eek(p1.z0nrk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0jtk())
		{
			p0.z0rek(z0ZzZzfhh.z0xrj, p1.z0jtk());
		}
		if (p1.z0dtk() != ChartViewStyle.Bar)
		{
			p0.z0rek(z0ZzZzfhh.z0lvj, z0ZzZzfhh.z0eek(p1.z0dtk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0eek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0gfj);
			z0tek(p0, p1.z0eek());
			p0.z0uek();
		}
		z0ZzZzatk z0ZzZzatk2 = p1.z0mek();
		if (z0ZzZzatk2 != null && z0ZzZzatk2.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0yrj);
			z0tek(p0, z0ZzZzatk2);
			p0.z0yek();
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzbuk p1)
	{
		p0.z0rek(z0ZzZzfhh.z0zgj, p1.Reference);
		p0.z0rek(z0ZzZzfhh.z0zoj, p1.Title);
		p0.z0rek(z0ZzZzfhh.z0zmj, p1.Target);
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextPageBreakElement p1)
	{
		if (p1.z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, p1.z0pek());
		}
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
	}

	internal static XTextTextElement z0tek(z0ZzZzxjh p0, XTextTextElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0mij)
			{
				p1.z0rek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0apk)
			{
				p1.z0eek(p0.z0pek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextTableColumnElement z0tek(z0ZzZzxjh p0, XTextTableColumnElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextSignElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, p1.z0pek());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzpmk p1)
	{
		p0.z0rek(z0ZzZzfhh.z0uij, p1.ImageData);
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzbtk p1)
	{
		if (p1.z0tek() != null)
		{
			List<z0ZzZzymk> list = p1.z0tek();
			int count = list.Count;
			if (count > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0gsj);
				p0.z0iek();
				for (int i = 0; i < count; i++)
				{
					p0.z0tek();
					z0tek(p0, list[i]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		if (p1.z0uek() != 0.5f)
		{
			p0.z0rek(z0ZzZzfhh.z0iyk_jiejie20260327142557, p1.z0uek());
		}
		if (p1.z0iek() != 1)
		{
			p0.z0rek(z0ZzZzfhh.z0rvj, p1.z0iek());
		}
		if (p1.z0rek() != ColorThemeType.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0avj, z0ZzZzfhh.z0eek(p1.z0rek()), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, PageLabelText p1)
	{
		p0.z0rek(z0ZzZzfhh.z0tik, p1.Text);
		if (p1.PageIndex != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0jpj, p1.PageIndex);
		}
	}

	internal static DCContentLockInfo z0tek(z0ZzZzxjh p0, DCContentLockInfo p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0clj)
				{
					p1.AuthorisedUserIDList = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0vtk)
				{
					p1.CreationTime = p0.z0cek();
				}
				else if (text == z0ZzZzfhh.z0xvj)
				{
					p1.OwnerUserID = p0.z0bek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzymk p1)
	{
		p0.z0rek(z0ZzZzfhh.z0dfj, p1.StringValue);
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzvpk p1)
	{
		if (p1.Align != DocumentContentAlignment.Left)
		{
			p0.z0rek(z0ZzZzfhh.z0gnj, z0ZzZzfhh.z0eek(p1.Align), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BackgroundColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0okj, p1.BackgroundColor);
		}
		if (p1.BackgroundColor2.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0crj, p1.BackgroundColor2);
		}
		if (p1.Bold)
		{
			p0.z0rek(z0ZzZzfhh.z0vyk, p1.Bold);
		}
		if (p1.BorderBottom)
		{
			p0.z0rek(z0ZzZzfhh.z0jvk, p1.BorderBottom);
		}
		if (p1.BorderBottomColor.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0azk, p1.BorderBottomColor);
		}
		if (p1.BorderLeft)
		{
			p0.z0rek(z0ZzZzfhh.z0wmj, p1.BorderLeft);
		}
		if (p1.BorderLeftColor.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0nyj, p1.BorderLeftColor);
		}
		if (p1.z0eek() != PageBorderRangeTypes.None)
		{
			p0.z0rek(z0ZzZzfhh.z0xwj, z0ZzZzfhh.z0eek(p1.z0eek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BorderRight)
		{
			p0.z0rek(z0ZzZzfhh.z0lej, p1.BorderRight);
		}
		if (p1.BorderRightColor.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0uik, p1.BorderRightColor);
		}
		if (p1.BorderSpacing != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0ink, p1.BorderSpacing);
		}
		if (p1.BorderStyle != DashStyle.Solid)
		{
			p0.z0rek(z0ZzZzfhh.z0nck, z0ZzZzfhh.z0eek(p1.BorderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BorderTop)
		{
			p0.z0rek(z0ZzZzfhh.z0vgj, p1.BorderTop);
		}
		if (p1.BorderTopColor.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0uyk, p1.BorderTopColor);
		}
		if (p1.BorderWidth != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0etj, p1.BorderWidth);
		}
		if (p1.CharacterCircle != CharacterCircleStyles.None)
		{
			p0.z0rek(z0ZzZzfhh.z0wdj, z0ZzZzfhh.z0eek(p1.CharacterCircle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.Color.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0laj, p1.Color);
		}
		if (p1.EmphasisMark)
		{
			p0.z0rek(z0ZzZzfhh.z0fqj, p1.EmphasisMark);
		}
		if (p1.FirstLineIndent != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hbj, p1.FirstLineIndent);
		}
		if (p1.FixedSpacing)
		{
			p0.z0rek(z0ZzZzfhh.z0lvk, p1.FixedSpacing);
		}
		p0.z0rek(z0ZzZzfhh.z0asj, p1.FontName);
		if (p1.FontSize != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0pck, p1.FontSize);
		}
		if (p1.Index != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0xxk, p1.Index);
		}
		if (p1.Italic)
		{
			p0.z0rek(z0ZzZzfhh.z0wtk, p1.Italic);
		}
		if (p1.LayoutAlign != ContentLayoutAlign.EmbedInText)
		{
			p0.z0rek(z0ZzZzfhh.z0dqj, z0ZzZzfhh.z0eek(p1.LayoutAlign), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.LeftIndent != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0vpj, p1.LeftIndent);
		}
		if (p1.LetterSpacing != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0qpk, p1.LetterSpacing);
		}
		if (p1.LineSpacing != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0nmj, p1.LineSpacing);
		}
		if (p1.LineSpacingStyle != LineSpacingStyle.SpaceSingle)
		{
			p0.z0rek(z0ZzZzfhh.z0pvj, z0ZzZzfhh.z0eek(p1.LineSpacingStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.MarginBottom != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0lpk, p1.MarginBottom);
		}
		if (p1.MarginLeft != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0oik, p1.MarginLeft);
		}
		if (p1.MarginRight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0nej, p1.MarginRight);
		}
		if (p1.MarginTop != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0sck, p1.MarginTop);
		}
		if (p1.Multiline)
		{
			p0.z0rek(z0ZzZzfhh.z0raj, p1.Multiline);
		}
		if (p1.PaddingBottom != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0gjj, p1.PaddingBottom);
		}
		if (p1.PaddingLeft != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0uaj, p1.PaddingLeft);
		}
		if (p1.PaddingRight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0cpj, p1.PaddingRight);
		}
		if (p1.PaddingTop != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0esj, p1.PaddingTop);
		}
		if (p1.ParagraphListStyle != ParagraphListStyle.None)
		{
			p0.z0rek(z0ZzZzfhh.z0ijj, zzz.z0ZzZzcyk<ParagraphListStyle>.z0rek(p1.ParagraphListStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.ParagraphMultiLevel)
		{
			p0.z0rek(z0ZzZzfhh.z0olj, p1.ParagraphMultiLevel);
		}
		if (p1.ParagraphOutlineLevel != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0bqj_jiejie20260327142557, p1.ParagraphOutlineLevel);
		}
		if (p1.RightToLeft)
		{
			p0.z0rek(z0ZzZzfhh.z0dlj, p1.RightToLeft);
		}
		if (p1.RTFLineSpacing != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hvk, p1.RTFLineSpacing);
		}
		if (p1.SpacingAfterParagraph != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0kbj_jiejie20260327142557, p1.SpacingAfterParagraph);
		}
		if (p1.SpacingBeforeParagraph != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0idj, p1.SpacingBeforeParagraph);
		}
		if (p1.Strikeout)
		{
			p0.z0rek(z0ZzZzfhh.z0tbj, p1.Strikeout);
		}
		if (p1.Subscript)
		{
			p0.z0rek(z0ZzZzfhh.z0rmk, p1.Subscript);
		}
		if (p1.Superscript)
		{
			p0.z0rek(z0ZzZzfhh.z0svk, p1.Superscript);
		}
		if (p1.Underline)
		{
			p0.z0rek(z0ZzZzfhh.z0wok, p1.Underline);
		}
		p0.z0rek(z0ZzZzfhh.z0jmk, p1.UnderlineColor);
		if (p1.UnderlineStyle != TextUnderlineStyle.Single)
		{
			p0.z0rek(z0ZzZzfhh.z0joj, z0ZzZzfhh.z0eek(p1.UnderlineStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.VerticalAlign != VerticalAlignStyle.Top)
		{
			p0.z0rek(z0ZzZzfhh.z0dik, z0ZzZzfhh.z0eek(p1.VerticalAlign), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.Visibility != RenderVisibility.All)
		{
			p0.z0rek(z0ZzZzfhh.z0lrj, zzz.z0ZzZzcyk<RenderVisibility>.z0rek(p1.Visibility), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.VisibleInDirectory)
		{
			p0.z0rek(z0ZzZzfhh.z0ptj, p1.VisibleInDirectory);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, PropertyExpressionInfoList p1)
	{
		if (p1.Count > 0)
		{
			p0.z0iek();
			int count = p1.Count;
			for (int i = 0; i < count; i++)
			{
				p0.z0tek();
				z0tek(p0, p1[i]);
				p0.z0mek();
			}
			p0.z0nek();
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextTableCellElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		z0tek(p0, p1.z0be());
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		if (p1.ColSpan != 1)
		{
			p0.z0rek(z0ZzZzfhh.z0xvk, p1.ColSpan);
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0rek())
		{
			p0.z0rek(z0ZzZzfhh.z0kaj, p1.z0rek());
		}
		if (p1.RowSpan != 1)
		{
			p0.z0rek(z0ZzZzfhh.z0ouj, p1.RowSpan);
		}
		if (p1.GridLine != null && !p1.GridLine.z0rek())
		{
			p0.z0yek(z0ZzZzfhh.z0jaj);
			z0tek(p0, p1.GridLine);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		p0.z0rek(z0ZzZzfhh.z0yuj, p1.z0cek());
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (p1.z0wrk())
		{
			p0.z0rek(z0ZzZzfhh.z0ltj, p1.z0wrk());
		}
		if (p1.AutoFixFontSizeMode != ContentAutoFixFontSizeMode.None)
		{
			p0.z0rek(z0ZzZzfhh.z0wbk, z0ZzZzfhh.z0eek(p1.AutoFixFontSizeMode), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.SlantSplitLineStyle != RectangleSlantSplitStyle.None)
		{
			p0.z0rek(z0ZzZzfhh.z0qnk, z0ZzZzfhh.z0eek(p1.SlantSplitLineStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BorderPrintedWhenJumpPrint)
		{
			p0.z0rek(z0ZzZzfhh.z0hwj, p1.BorderPrintedWhenJumpPrint);
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.CloneType != TableRowCloneType.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0pqj, z0ZzZzfhh.z0eek(p1.CloneType), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0vzk, ((XTextContainerElement)p1).z0nrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.EnableValueValidate)
		{
			p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		}
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.MirrorViewForCrossPage)
		{
			p0.z0rek(z0ZzZzfhh.z0avk, p1.MirrorViewForCrossPage);
		}
		if (p1.MoveFocusHotKey != MoveFocusHotKeys.Tab)
		{
			p0.z0rek(z0ZzZzfhh.z0tcj, zzz.z0ZzZzcyk<MoveFocusHotKeys>.z0rek(p1.MoveFocusHotKey), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		if (p1.SpecifyFixedLineHeight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0swj, p1.SpecifyFixedLineHeight);
		}
		if (!p1.z0mek())
		{
			p0.z0rek(z0ZzZzfhh.z0dsj, p1.z0mek());
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static z0ZzZzuuj z0tek(z0ZzZzxjh p0, z0ZzZzuuj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0wrk)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0acj)
			{
				p1.z0rek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0qej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzcok()));
				}
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0eoj)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0pik)
			{
				p1.z0yek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0mbk)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0eqj)
			{
				p1.z0tek(p0.z0yek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static ListItem z0tek(z0ZzZzxjh p0, ListItem p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0tik)
				{
					p1.Text = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0jsj)
				{
					p1.Value = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0wik)
				{
					p1.Group = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0ftk)
				{
					p1.TextInList = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0gzk)
				{
					p1.CheckedTime = p0.z0cek();
				}
				else if (text == z0ZzZzfhh.z0pyk)
				{
					p1.EntryID = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0coj)
				{
					p1.z0eek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0sdj)
				{
					p1.ListIndex = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0gmk)
				{
					p1.LonelyChecked = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0uvj)
				{
					p1.Tag = p0.z0bek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzwmk p1)
	{
		if (p1.Alpha != 80)
		{
			p0.z0rek(z0ZzZzfhh.z0uhj, p1.Alpha);
		}
		if (p1.Angle != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0rrk, p1.Angle);
		}
		if (p1.BackColor.ToArgb() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0euk, p1.BackColor);
		}
		if (p1.Color.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0laj, p1.Color);
		}
		if (p1.DensityForRepeat != 1f)
		{
			p0.z0rek(z0ZzZzfhh.z0yok, p1.DensityForRepeat);
		}
		if (p1.Font != null)
		{
			p0.z0yek(z0ZzZzfhh.z0rjj);
			z0tek(p0, p1.Font);
			p0.z0uek();
		}
		if (p1.Image != null)
		{
			p0.z0yek(z0ZzZzfhh.z0lpj);
			z0tek(p0, p1.Image);
			p0.z0uek();
		}
		if (p1.Repeat)
		{
			p0.z0rek(z0ZzZzfhh.z0fyk, p1.Repeat);
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.Text);
		if (p1.Type != WatermarkType.None)
		{
			p0.z0rek(z0ZzZzfhh.z0ook, z0ZzZzfhh.z0eek(p1.Type), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, DocumentComment p1)
	{
		p0.z0rek(z0ZzZzfhh.z0kik, p1.z0krk());
		if (p1.z0mrk().Ticks != 624511296000000000L)
		{
			p0.z0rek(z0ZzZzfhh.z0vtk, p1.z0mrk());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.z0nek());
		if (p1.z0urk() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0qoj, p1.z0urk());
		}
		XAttributeList xAttributeList = p1.z0lrk();
		if (xAttributeList != null && xAttributeList.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, xAttributeList);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0xuk, p1.z0eek());
		p0.z0rek(z0ZzZzfhh.z0euk, p1.z0frk());
		if (p1.z0jrk())
		{
			p0.z0rek(z0ZzZzfhh.z0yik, p1.z0jrk());
		}
		if (p1.z0brk().ToArgb() != -65536)
		{
			p0.z0rek(z0ZzZzfhh.z0duk, p1.z0brk());
		}
		if (p1.z0vek().ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0ltk, p1.z0vek());
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.z0ark());
		p0.z0rek(z0ZzZzfhh.z0xxk, p1.z0tek());
		p0.z0rek(z0ZzZzfhh.z0zoj, p1.z0grk());
		if (!p1.z0yrk())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0yrk());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzdvj p1)
	{
		if (p1.Count > 0)
		{
			p0.z0iek();
			int count = p1.Count;
			for (int i = 0; i < count; i++)
			{
				p0.z0tek();
				z0tek(p0, p1[i]);
				p0.z0mek();
			}
			p0.z0nek();
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextNewMedicalExpressionElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		if (p1.ExpressionStyle != DCMedicalExpressionStyle.FourValues)
		{
			p0.z0rek(z0ZzZzfhh.z0guk, z0ZzZzfhh.z0eek(p1.ExpressionStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.Text);
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.VAlign != VerticalAlignStyle.Middle)
		{
			p0.z0rek(z0ZzZzfhh.z0qok, z0ZzZzfhh.z0eek(p1.VAlign), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (p1.Values != null)
		{
			MedicalExpressionValueList values = p1.Values;
			int count = values.Count;
			if (count > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0dbj);
				p0.z0iek();
				for (int i = 0; i < count; i++)
				{
					p0.z0tek();
					z0tek(p0, values[i]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextDocumentBodyElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (XTextElementList.z0pek(p1.z0be()))
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, p1.z0be());
			p0.z0yek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0vzk, ((XTextContainerElement)p1).z0nrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.SpecifyFixedLineHeight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0swj, p1.SpecifyFixedLineHeight);
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextButtonElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.AutoSize)
		{
			p0.z0rek(z0ZzZzfhh.z0ttk, p1.AutoSize);
		}
		p0.z0rek(z0ZzZzfhh.z0zek, p1.CommandName);
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		if (p1.Image != null)
		{
			p0.z0yek(z0ZzZzfhh.z0lpj);
			z0tek(p0, p1.Image);
			p0.z0uek();
		}
		if (p1.ImageForDown != null)
		{
			p0.z0yek(z0ZzZzfhh.z0etk);
			z0tek(p0, p1.ImageForDown);
			p0.z0uek();
		}
		if (p1.ImageForMouseOver != null)
		{
			p0.z0yek(z0ZzZzfhh.z0bjj);
			z0tek(p0, p1.ImageForMouseOver);
			p0.z0uek();
		}
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		if (p1.PrintAsText)
		{
			p0.z0rek(z0ZzZzfhh.z0unj, p1.PrintAsText);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0mwj, p1.ScriptTextForClick);
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.Text);
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static XTextStringElement z0tek(z0ZzZzxjh p0, XTextStringElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0apk)
			{
				p1.z0eek(p0.z0pek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzsok p1)
	{
		p0.z0rek(z0ZzZzfhh.z0rdj, p1.Format);
		if (p1.Style != ValueFormatStyle.None)
		{
			p0.z0rek(z0ZzZzfhh.z0moj, z0ZzZzfhh.z0eek(p1.Style), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0pbk, p1.NoneText);
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextTableElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.z0ark() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0gij, p1.z0ark());
		}
		if (p1.z0bek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0dvj, p1.z0bek());
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		if (p1.CompressOwnerLineSpacing)
		{
			p0.z0rek(z0ZzZzfhh.z0ehj, p1.CompressOwnerLineSpacing);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.AllowUserToResizeColumns)
		{
			p0.z0rek(z0ZzZzfhh.z0xnk, p1.AllowUserToResizeColumns);
		}
		if (!p1.AllowUserToResizeRows)
		{
			p0.z0rek(z0ZzZzfhh.z0ycj, p1.AllowUserToResizeRows);
		}
		if (p1.z0qtk() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0vpj, p1.z0qtk());
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0frk() != DCTableAlignment.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0otj, z0ZzZzfhh.z0eek(p1.z0frk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0mrk())
		{
			p0.z0rek(z0ZzZzfhh.z0dzk, p1.z0mrk());
		}
		if (!p1.AllowUserDeleteRow)
		{
			p0.z0rek(z0ZzZzfhh.z0dtk, p1.AllowUserDeleteRow);
		}
		if (!p1.AllowUserInsertRow)
		{
			p0.z0rek(z0ZzZzfhh.z0jrk, p1.AllowUserInsertRow);
		}
		if (p1.z0xrk())
		{
			p0.z0rek(z0ZzZzfhh.z0fpj, p1.z0xrk());
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.z0srk() != null)
		{
			XTextElementList xTextElementList = p1.z0srk();
			int count = xTextElementList.Count;
			if (count > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0uyj);
				p0.z0iek();
				for (int i = 0; i < count; i++)
				{
					p0.z0tek();
					z0tek(p0, (XTextTableColumnElement)xTextElementList[i]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0vzk, ((XTextContainerElement)p1).z0nrk());
		p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		if (!p1.z0mek())
		{
			p0.z0rek(z0ZzZzfhh.z0goj, p1.z0mek());
		}
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.PrintBothBorderWhenJumpPrint)
		{
			p0.z0rek(z0ZzZzfhh.z0muk_jiejie20260327142557, p1.PrintBothBorderWhenJumpPrint);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.z0stk() != null)
		{
			XTextElementList xTextElementList2 = p1.z0stk();
			int count2 = xTextElementList2.Count;
			if (count2 > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0bej);
				p0.z0iek();
				for (int j = 0; j < count2; j++)
				{
					p0.z0tek();
					z0tek(p0, (XTextTableRowElement)xTextElementList2[j]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		if (p1.z0dtk() != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0dcj, z0ZzZzfhh.z0eek(p1.z0dtk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0hrk() != TableSubfieldMode.None)
		{
			p0.z0rek(z0ZzZzfhh.z0wej, z0ZzZzfhh.z0eek(p1.z0hrk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0prk() != 1)
		{
			p0.z0rek(z0ZzZzfhh.z0fnj, p1.z0prk());
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static void z0tek(z0ZzZzzjh p0, PropertyExpressionInfo p1)
	{
		p0.z0rek(z0ZzZzfhh.z0yuj, p1.Expression);
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (!p1.AllowChainReaction)
		{
			p0.z0rek(z0ZzZzfhh.z0caj, p1.AllowChainReaction);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzxyj p1)
	{
		z0ZzZzguj z0ZzZzguj2 = p1.z0djk();
		if (z0ZzZzguj2 != null && z0ZzZzguj2.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0tek(p0, z0ZzZzguj2);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0coj, ((z0ZzZzhuj)p1).z0yek());
		if (((z0ZzZzeuj)p1).z0eek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0oek, ((z0ZzZzeuj)p1).z0eek());
		}
		if (p1.z0rek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0yqj, p1.z0rek());
		}
		if (((z0ZzZzhuj)p1).z0pek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0qej);
			z0tek(p0, ((z0ZzZzhuj)p1).z0pek());
			p0.z0uek();
		}
		if (!p1.z0xkk())
		{
			p0.z0rek(z0ZzZzfhh.z0hnj, p1.z0xkk());
		}
		if (((z0ZzZzhuj)p1).z0eek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((z0ZzZzhuj)p1).z0eek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.z0pek());
		if (p1.z0oek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0gtk, p1.z0oek());
		}
		if (!p1.z0rek_jiejie20260327142557())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0rek_jiejie20260327142557());
		}
		if (p1.z0mek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0nnj, p1.z0mek());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, DCPieDataItem p1)
	{
		if (p1.Color.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0laj, p1.Color);
		}
		p0.z0rek(z0ZzZzfhh.z0aoj, p1.Link);
		p0.z0rek(z0ZzZzfhh.z0tik, p1.Text);
		p0.z0rek(z0ZzZzfhh.z0prj, p1.TipText);
		if (p1.Value != 0.0)
		{
			p0.z0rek(z0ZzZzfhh.z0jsj, p1.Value);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzsvj p1)
	{
		p0.z0rek(z0ZzZzfhh.z0huk, p1.SourceName);
		p0.z0rek(z0ZzZzfhh.z0gbj, p1.DisplayPath);
		p0.z0rek(z0ZzZzfhh.z0ark, p1.ValuePath);
		if (!p1.BufferItems)
		{
			p0.z0rek(z0ZzZzfhh.z0cik, p1.BufferItems);
		}
		z0ZzZzdvj items = p1.Items;
		if (items != null && items.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0cuk);
			z0tek(p0, items);
			p0.z0yek();
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, CopySourceInfo p1)
	{
		p0.z0rek(z0ZzZzfhh.z0rnk, p1.z0iek());
		p0.z0rek(z0ZzZzfhh.z0krj, p1.z0tek());
		p0.z0rek(z0ZzZzfhh.z0luj, p1.z0eek());
		if (!p1.z0yek())
		{
			p0.z0rek(z0ZzZzfhh.z0ulj, p1.z0yek());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextSubDocumentElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.CompressOwnerLineSpacing)
		{
			p0.z0rek(z0ZzZzfhh.z0ehj, p1.CompressOwnerLineSpacing);
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.DocumentInfo != null)
		{
			p0.z0yek(z0ZzZzfhh.z0vuj);
			z0tek(p0, p1.DocumentInfo);
			p0.z0uek();
		}
		if (XTextElementList.z0pek(p1.z0be()))
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, p1.z0be());
			p0.z0yek();
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0xtj, p1.FileName);
		if (p1.ForeColorForCollapsed.ToArgb() != -8355712)
		{
			p0.z0rek(z0ZzZzfhh.z0uuj, p1.ForeColorForCollapsed);
		}
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0fgj, p1.FileFormat);
		if (p1.NewPage)
		{
			p0.z0rek(z0ZzZzfhh.z0wtj, p1.NewPage);
		}
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.AcceptTab)
		{
			p0.z0rek(z0ZzZzfhh.z0gdj, p1.AcceptTab);
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.ContentLoaded)
		{
			p0.z0rek(z0ZzZzfhh.z0nrk, p1.ContentLoaded);
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0vzk, ((XTextContainerElement)p1).z0nrk());
		if (p1.DelayLoadWhenExpand)
		{
			p0.z0rek(z0ZzZzfhh.z0yvk, p1.DelayLoadWhenExpand);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		p0.z0rek(z0ZzZzfhh.z0ujj, p1.DocumentID);
		if (p1.EnableCollapse)
		{
			p0.z0rek(z0ZzZzfhh.z0ovj, p1.EnableCollapse);
		}
		p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		if (!p1.ExpendForDataBinding)
		{
			p0.z0rek(z0ZzZzfhh.z0upk, p1.ExpendForDataBinding);
		}
		if (p1.GridLine != null)
		{
			p0.z0yek(z0ZzZzfhh.z0jaj);
			z0tek(p0, p1.GridLine);
			p0.z0uek();
		}
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (!p1.ImportUserTrack)
		{
			p0.z0rek(z0ZzZzfhh.z0ruj, p1.ImportUserTrack);
		}
		if (p1.InsertEmptyPageForNewPage)
		{
			p0.z0rek(z0ZzZzfhh.z0llj, p1.InsertEmptyPageForNewPage);
		}
		if (p1.IsCollapsed)
		{
			p0.z0rek(z0ZzZzfhh.z0gyj, p1.IsCollapsed);
		}
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.Locked)
		{
			p0.z0rek(z0ZzZzfhh.z0iij, p1.Locked);
		}
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.PrintPositionInPage != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0rij, p1.PrintPositionInPage);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		if (p1.Printed)
		{
			p0.z0rek(z0ZzZzfhh.z0dmk, p1.Printed);
		}
		if (p1.PrintedPageIndex != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0qyj, p1.PrintedPageIndex);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.SpecifyFixedLineHeight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0swj, p1.SpecifyFixedLineHeight);
		}
		if (p1.SpecifyHeight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0ugj, p1.SpecifyHeight);
		}
		p0.z0rek(z0ZzZzfhh.z0zoj, p1.Title);
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzukh p1)
	{
		if (p1.Count > 0)
		{
			p0.z0iek();
			int count = p1.Count;
			for (int i = 0; i < count; i++)
			{
				p0.z0tek();
				z0tek(p0, p1[i]);
				p0.z0mek();
			}
			p0.z0nek();
		}
	}

	internal static z0ZzZzilh z0tek(z0ZzZzxjh p0, z0ZzZzilh p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0gdj)
			{
				p1.AcceptTab = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0lbj)
			{
				p1.BackgroundTextColor = p0.z0tek(z0vek);
			}
			else if (text == z0ZzZzfhh.z0cgj)
			{
				p1.z0eek((DCBooleanValueHasDefault)p0.z0tek(z0ZzZzfhh.z0ndj));
			}
			else if (text == z0ZzZzfhh.z0lhj)
			{
				p1.BorderElementColor = p0.z0tek(z0srk);
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0phj)
			{
				p1.EndBorderText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gok)
			{
				p1.EndingLineBreak = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0zij)
			{
				p1.LableUnitTextBold = (DCBooleanValueHasDefault)p0.z0tek(z0ZzZzfhh.z0ndj);
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0njj)
			{
				p1.StartBorderText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0ojj)
			{
				p1.TextColor = p0.z0tek(z0vek);
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextImageElement z0tek(z0ZzZzxjh p0, XTextImageElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0iqj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				z0ZzZzdzj z0ZzZzdzj2 = new z0ZzZzdzj();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						z0ZzZzdzj2.Add(z0tek(p0, new z0ZzZzfzj()));
					}
				}
				if (z0ZzZzdzj2.Count > 0)
				{
					p1.z0eek(z0ZzZzdzj2);
				}
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0gej_jiejie20260327142557)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzluj()));
				}
			}
			else if (text == z0ZzZzfhh.z0qmk)
			{
				p1.KeepWidthHeightRate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0eij)
			{
				p1.z0eek(p0.z0tek(z0vek));
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else if (text == z0ZzZzfhh.z0ivj)
			{
				p1.z0uek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0qsj)
			{
				p1.z0uek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0vnj)
			{
				p1.z0iek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0mgj)
			{
				p1.EnableEditImageAdditionShape = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wbj)
			{
				p1.z0pek_jiejie20260327142557(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0lpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0rek(z0tek(p0, new z0ZzZzpmk()));
				}
			}
			else if (text == z0ZzZzfhh.z0hvj)
			{
				p1.z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					((XTextObjectElement)p1).z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0taj)
			{
				p1.SaveContentInFile = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0tnj)
			{
				p1.SmoothZoom = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0drk)
			{
				p1.z0tek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zoj)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0qok)
			{
				p1.VAlign = (VerticalAlignStyle)p0.z0tek(z0ZzZzfhh.z0jnk);
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0jok)
			{
				p1.z0rek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzolh z0tek(z0ZzZzxjh p0, z0ZzZzolh p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextDocumentHeaderElement z0tek(z0ZzZzxjh p0, XTextDocumentHeaderElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0swj)
			{
				p1.SpecifyFixedLineHeight = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextCustomShapeElement z0tek(z0ZzZzxjh p0, XTextCustomShapeElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0pcj)
			{
				p1.z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nhj)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextNewBarcodeElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.BarcodeStyle2 != DCBarcodeStyle.Code128C)
		{
			p0.z0rek(z0ZzZzfhh.z0erj, z0ZzZzfhh.z0eek(p1.BarcodeStyle2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		if (p1.Height != 125f)
		{
			p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		}
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		PageLabelTextList pageTexts = p1.PageTexts;
		if (pageTexts != null && pageTexts.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0xok);
			z0tek(p0, pageTexts);
			p0.z0yek();
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (!p1.ShowText)
		{
			p0.z0rek(z0ZzZzfhh.z0yij, p1.ShowText);
		}
		if (p1.StrictMatchPageIndex)
		{
			p0.z0rek(z0ZzZzfhh.z0kok, p1.StrictMatchPageIndex);
		}
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.Text);
		if (p1.TextAlignment != StringAlignment.Center)
		{
			p0.z0rek(z0ZzZzfhh.z0opj, z0ZzZzfhh.z0eek(p1.TextAlignment), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static XTextMedicalExpressionFieldElement z0tek(z0ZzZzxjh p0, XTextMedicalExpressionFieldElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0doj)
			{
				p1.EnableHighlight = (EnableState)p0.z0tek(z0ZzZzfhh.z0pbj);
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0gdj)
			{
				p1.AcceptTab = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0otj)
			{
				p1.Alignment = (StringAlignment)p0.z0tek(z0ZzZzfhh.z0arj);
			}
			else if (text == z0ZzZzfhh.z0zmk)
			{
				p1.AutoExitEditMode = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ltj)
			{
				p1.z0tek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0hoj)
			{
				p1.BackgroundText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0lbj)
			{
				p1.BackgroundTextColor = p0.z0tek(z0vek);
			}
			else if (text == z0ZzZzfhh.z0cgj)
			{
				((XTextFieldElementBase)p1).z0eek((DCBooleanValueHasDefault)p0.z0tek(z0ZzZzfhh.z0ndj));
			}
			else if (text == z0ZzZzfhh.z0lhj)
			{
				p1.BorderElementColor = p0.z0tek(z0srk);
			}
			else if (text == z0ZzZzfhh.z0tlj)
			{
				p1.z0eek((z0ZzZzscj)p0.z0tek(z0ZzZzfhh.z0haj));
			}
			else if (text == z0ZzZzfhh.z0tvj)
			{
				p1.BorderVisible = (DCVisibleState)p0.z0tek(z0ZzZzfhh.z0ppk);
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0gqj)
			{
				p1.DefaultEventExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0jyj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.DisplayFormat = z0tek(p0, new z0ZzZzsok());
				}
			}
			else if (text == z0ZzZzfhh.z0xqj)
			{
				p1.EditValueInDialog = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0phj)
			{
				p1.EndBorderText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gok)
			{
				p1.EndingLineBreak = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0jfj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.EventExpressions = z0tek(p0, new z0ZzZzukh());
				}
			}
			else if (text == z0ZzZzfhh.z0syj)
			{
				p1.z0eek((DCFastInputMode)p0.z0tek(z0ZzZzfhh.z0ynk));
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0pgj)
			{
				p1.InnerValue = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zvj)
			{
				p1.LabelText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zij)
			{
				p1.LableUnitTextBold = (DCBooleanValueHasDefault)p0.z0tek(z0ZzZzfhh.z0ndj);
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0tcj)
			{
				p1.MoveFocusHotKey = zzz.z0ZzZzcyk<MoveFocusHotKeys>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0yyj)
			{
				p1.z0eek((DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk));
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0dij)
			{
				p1.SpecifyWidth = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0njj)
			{
				p1.StartBorderText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0blj)
			{
				p1.TabIndex = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0dsj)
			{
				p1.TabStop = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ojj)
			{
				p1.TextColor = p0.z0tek(z0vek);
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0ack)
			{
				p1.UnitText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0vrj)
			{
				p1.UserEditable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0qok)
			{
				p1.VAlign = (VerticalAlignStyle)p0.z0tek(z0ZzZzfhh.z0jnk);
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cmj)
			{
				p1.ViewEncryptType = (ContentViewEncryptType)p0.z0tek(z0ZzZzfhh.z0hpk);
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzfzj p1)
	{
		if (p1.z0eek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0lpj);
			z0tek(p0, p1.z0eek());
			p0.z0uek();
		}
		if (p1.z0tek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0jpj, p1.z0tek());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextSignImageElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0nlj, p1.DataForSelfCheck);
		if (p1.DefaultSignMode != DCCASignMode.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0zik, z0ZzZzfhh.z0eek(p1.DefaultSignMode), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		p0.z0rek(z0ZzZzfhh.z0uij, p1.ImageData);
		if (p1.LastVerifyResult != null)
		{
			p0.z0rek(z0ZzZzfhh.z0sjj, p1.LastVerifyResult);
		}
		if (((XTextObjectElement)p1).z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, ((XTextObjectElement)p1).z0iek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0hrk, p1.SignClientName);
		p0.z0rek(z0ZzZzfhh.z0wsj, p1.SignErrorMessage);
		p0.z0rek(z0ZzZzfhh.z0dyj, p1.SignMessage);
		p0.z0rek(z0ZzZzfhh.z0grj, p1.SignProviderName);
		if (p1.SignRange != DCSignRange.Parent)
		{
			p0.z0rek(z0ZzZzfhh.z0rvk, z0ZzZzfhh.z0eek(p1.SignRange), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0aaj, p1.SignTime);
		p0.z0rek(z0ZzZzfhh.z0wjj, p1.SignUserID);
		p0.z0rek(z0ZzZzfhh.z0rej, p1.SignUserName);
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0zoj, p1.Title);
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.UseInnerSignProvider)
		{
			p0.z0rek(z0ZzZzfhh.z0fvj, p1.UseInnerSignProvider);
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static DocumentContentStyleContainer z0tek(z0ZzZzxjh p0, DocumentContentStyleContainer p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0sok)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.Default = z0tek(p0, new DocumentContentStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0djj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				z0ZzZzzok z0ZzZzzok2 = new z0ZzZzzok();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						z0ZzZzzok2.Add(z0tek(p0, new DocumentContentStyle()));
					}
				}
				if (z0ZzZzzok2.Count > 0)
				{
					p1.Styles = z0ZzZzzok2;
				}
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextButtonElement z0tek(z0ZzZzxjh p0, XTextButtonElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0ttk)
			{
				p1.AutoSize = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0zek)
			{
				p1.CommandName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0lpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.Image = z0tek(p0, new z0ZzZzpmk());
				}
			}
			else if (text == z0ZzZzfhh.z0etk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ImageForDown = z0tek(p0, new z0ZzZzpmk());
				}
			}
			else if (text == z0ZzZzfhh.z0bjj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ImageForMouseOver = z0tek(p0, new z0ZzZzpmk());
				}
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0unj)
			{
				p1.PrintAsText = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0mwj)
			{
				p1.ScriptTextForClick = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.Text = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextDocumentFooterElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (XTextElementList.z0pek(p1.z0be()))
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, p1.z0be());
			p0.z0yek();
		}
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0vzk, ((XTextContainerElement)p1).z0nrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.SpecifyFixedLineHeight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0swj, p1.SpecifyFixedLineHeight);
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static XTextLabelElement z0tek(z0ZzZzxjh p0, XTextLabelElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0xok)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PageTexts = z0tek(p0, new PageLabelTextList());
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0raj)
			{
				p1.Multiline = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0otj)
			{
				p1.Alignment = zzz.z0ZzZzcyk<DCContentAlignment>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0ttk)
			{
				p1.AutoSize = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					((XTextObjectElement)p1).z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0tej)
			{
				p1.z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0zbj)
			{
				p1.AttributeNameForContactAction = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tnk)
			{
				p1.LinkTextForContactAction = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0omj)
			{
				p1.ContactAction = (LabelTextContactActionMode)p0.z0tek(z0ZzZzfhh.z0sej);
			}
			else if (text == z0ZzZzfhh.z0jjj)
			{
				p1.AllowUserEditCurrentPageLabelText = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0kok)
			{
				p1.StrictMatchPageIndex = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.Text = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzimk z0tek(z0ZzZzxjh p0, z0ZzZzimk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0vyk)
				{
					p1.Bold = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0wtk)
				{
					p1.Italic = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0ntj)
				{
					p1.Name = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0jik)
				{
					p1.Size = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0tbj)
				{
					p1.Strikeout = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0wok)
				{
					p1.Underline = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0rxk)
				{
					p1.Unit = (GraphicsUnit)p0.z0tek(z0ZzZzfhh.z0bsj);
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static XTextChartElement z0tek(z0ZzZzxjh p0, XTextChartElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0nik)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzqtk()));
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0sbk)
			{
				p1.z0uek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0hij)
			{
				p1.z0iek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0tyk)
			{
				p1.z0pek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0iyj)
			{
				p1.z0yek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0dkj_jiejie20260327142557)
			{
				p1.z0tek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0duj)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0gmj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				DCChartDataItemList dCChartDataItemList = new DCChartDataItemList();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						dCChartDataItemList.Add(z0tek(p0, new DCChartDataItem()));
					}
				}
				if (dCChartDataItemList.Count > 0)
				{
					p1.z0eek(dCChartDataItemList);
				}
			}
			else if (text == z0ZzZzfhh.z0pzk)
			{
				p1.z0rek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextSectionElement z0tek(z0ZzZzxjh p0, XTextSectionElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0ehj)
			{
				p1.CompressOwnerLineSpacing = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0gdj)
			{
				p1.AcceptTab = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				((XTextContainerElement)p1).z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ovj)
			{
				p1.EnableCollapse = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0upk)
			{
				p1.ExpendForDataBinding = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0uuj)
			{
				p1.ForeColorForCollapsed = p0.z0tek(z0hrk);
			}
			else if (text == z0ZzZzfhh.z0jaj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.GridLine = z0tek(p0, new z0ZzZzzej());
				}
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0llj)
			{
				p1.InsertEmptyPageForNewPage = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gyj)
			{
				p1.IsCollapsed = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0wtj)
			{
				p1.NewPage = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0swj)
			{
				p1.SpecifyFixedLineHeight = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0ugj)
			{
				p1.SpecifyHeight = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0zoj)
			{
				p1.Title = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextDocumentBodyElement z0tek(z0ZzZzxjh p0, XTextDocumentBodyElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0swj)
			{
				p1.SpecifyFixedLineHeight = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextPageBreakElement z0tek(z0ZzZzxjh p0, XTextPageBreakElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextMedicalExpressionFieldElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		XTextElementList xTextElementList = p1.z0be();
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, xTextElementList);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.EnableHighlight != EnableState.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0doj, z0ZzZzfhh.z0eek(p1.EnableHighlight), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.AcceptTab)
		{
			p0.z0rek(z0ZzZzfhh.z0gdj, p1.AcceptTab);
		}
		if (p1.Alignment != StringAlignment.Near)
		{
			p0.z0rek(z0ZzZzfhh.z0otj, z0ZzZzfhh.z0eek(p1.Alignment), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.AutoExitEditMode)
		{
			p0.z0rek(z0ZzZzfhh.z0zmk, p1.AutoExitEditMode);
		}
		if (p1.z0pek())
		{
			p0.z0rek(z0ZzZzfhh.z0ltj, p1.z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0hoj, p1.BackgroundText);
		if (p1.BackgroundTextColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0lbj, p1.BackgroundTextColor);
		}
		if (((XTextFieldElementBase)p1).z0drk() != DCBooleanValueHasDefault.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0cgj, z0ZzZzfhh.z0eek(((XTextFieldElementBase)p1).z0drk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BorderElementColor.ToArgb() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0lhj, p1.BorderElementColor);
		}
		if (p1.z0oek() != (z0ZzZzscj)1)
		{
			p0.z0rek(z0ZzZzfhh.z0tlj, z0ZzZzfhh.z0eek(p1.z0oek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BorderVisible != DCVisibleState.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0tvj, z0ZzZzfhh.z0eek(p1.BorderVisible), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0gqj, p1.DefaultEventExpression);
		p0.z0rek(z0ZzZzfhh.z0vzk, p1.z0nrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.DisplayFormat != null)
		{
			p0.z0yek(z0ZzZzfhh.z0jyj);
			z0tek(p0, p1.DisplayFormat);
			p0.z0uek();
		}
		if (!p1.EditValueInDialog)
		{
			p0.z0rek(z0ZzZzfhh.z0xqj, p1.EditValueInDialog);
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.EnableValueValidate)
		{
			p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		p0.z0rek(z0ZzZzfhh.z0phj, p1.EndBorderText);
		if (p1.EndingLineBreak)
		{
			p0.z0rek(z0ZzZzfhh.z0gok, p1.EndingLineBreak);
		}
		z0ZzZzukh eventExpressions = p1.EventExpressions;
		if (eventExpressions != null && eventExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0jfj);
			z0tek(p0, eventExpressions);
			p0.z0yek();
		}
		if (((XTextInputFieldElementBase)p1).z0rek() != DCFastInputMode.NextField)
		{
			p0.z0rek(z0ZzZzfhh.z0syj, z0ZzZzfhh.z0eek(((XTextInputFieldElementBase)p1).z0rek()), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		p0.z0rek(z0ZzZzfhh.z0pgj, p1.InnerValue);
		p0.z0rek(z0ZzZzfhh.z0zvj, p1.LabelText);
		if (p1.LableUnitTextBold != DCBooleanValueHasDefault.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0zij, z0ZzZzfhh.z0eek(p1.LableUnitTextBold), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.MoveFocusHotKey != MoveFocusHotKeys.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0tcj, zzz.z0ZzZzcyk<MoveFocusHotKeys>.z0rek(p1.MoveFocusHotKey), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0cek() != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0yyj, z0ZzZzfhh.z0eek(p1.z0cek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.SpecifyWidth != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dij, p1.SpecifyWidth);
		}
		p0.z0rek(z0ZzZzfhh.z0njj, p1.StartBorderText);
		if (p1.TabIndex != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0blj, p1.TabIndex);
		}
		if (!p1.TabStop)
		{
			p0.z0rek(z0ZzZzfhh.z0dsj, p1.TabStop);
		}
		if (p1.TextColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0ojj, p1.TextColor);
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		p0.z0rek(z0ZzZzfhh.z0ack, p1.UnitText);
		if (!p1.UserEditable)
		{
			p0.z0rek(z0ZzZzfhh.z0vrj, p1.UserEditable);
		}
		if (p1.VAlign != VerticalAlignStyle.Middle)
		{
			p0.z0rek(z0ZzZzfhh.z0qok, z0ZzZzfhh.z0eek(p1.VAlign), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (p1.ViewEncryptType != ContentViewEncryptType.None)
		{
			p0.z0rek(z0ZzZzfhh.z0cmj, z0ZzZzfhh.z0eek(p1.ViewEncryptType), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
	}

	internal static z0ZzZzkuj z0tek(z0ZzZzxjh p0, z0ZzZzkuj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0ttk)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0yqj)
			{
				p1.z0tek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0qej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzcok()));
				}
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0gtk)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.z0yek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0qjk(z0tek(p0, new z0ZzZzguj()));
				}
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0lpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzpmk()));
				}
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0vek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzcok z0tek(z0ZzZzxjh p0, z0ZzZzcok p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0jvk)
				{
					p1.BorderBottom = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0wmj)
				{
					p1.BorderLeft = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0lej)
				{
					p1.BorderRight = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0vgj)
				{
					p1.BorderTop = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0etj)
				{
					p1.BorderWidth = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0asj)
				{
					p1.FontName = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0pck)
				{
					p1.FontSize = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0gnj)
				{
					p1.Align = (DocumentContentAlignment)p0.z0tek(z0ZzZzfhh.z0xfj);
				}
				else if (text == z0ZzZzfhh.z0dik)
				{
					p1.VerticalAlign = (VerticalAlignStyle)p0.z0tek(z0ZzZzfhh.z0jnk);
				}
				else if (text == z0ZzZzfhh.z0okj)
				{
					p1.BackgroundColor = p0.z0tek(z0vek);
				}
				else if (text == z0ZzZzfhh.z0crj)
				{
					p1.BackgroundColor2 = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0vyk)
				{
					p1.Bold = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0azk)
				{
					p1.BorderBottomColor = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0nyj)
				{
					p1.BorderLeftColor = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0uik)
				{
					p1.BorderRightColor = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0ink)
				{
					p1.BorderSpacing = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0nck)
				{
					p1.BorderStyle = (DashStyle)p0.z0tek(z0ZzZzfhh.z0bnj);
				}
				else if (text == z0ZzZzfhh.z0uyk)
				{
					p1.BorderTopColor = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0wdj)
				{
					p1.CharacterCircle = (CharacterCircleStyles)p0.z0tek(z0ZzZzfhh.z0pvk);
				}
				else if (text == z0ZzZzfhh.z0laj)
				{
					p1.Color = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0fqj)
				{
					p1.EmphasisMark = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0hbj)
				{
					p1.FirstLineIndent = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0lvk)
				{
					p1.FixedSpacing = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0xxk)
				{
					p1.Index = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0wtk)
				{
					p1.Italic = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0dqj)
				{
					p1.LayoutAlign = (ContentLayoutAlign)p0.z0tek(z0ZzZzfhh.z0stk);
				}
				else if (text == z0ZzZzfhh.z0vpj)
				{
					p1.LeftIndent = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0qpk)
				{
					p1.LetterSpacing = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0nmj)
				{
					p1.LineSpacing = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0pvj)
				{
					p1.LineSpacingStyle = (LineSpacingStyle)p0.z0tek(z0ZzZzfhh.z0lcj);
				}
				else if (text == z0ZzZzfhh.z0lpk)
				{
					p1.MarginBottom = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0oik)
				{
					p1.MarginLeft = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0nej)
				{
					p1.MarginRight = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0sck)
				{
					p1.MarginTop = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0raj)
				{
					p1.Multiline = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0gjj)
				{
					p1.PaddingBottom = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0uaj)
				{
					p1.PaddingLeft = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0cpj)
				{
					p1.PaddingRight = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0esj)
				{
					p1.PaddingTop = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0ijj)
				{
					p1.ParagraphListStyle = zzz.z0ZzZzcyk<ParagraphListStyle>.z0eek(p0.z0uek());
				}
				else if (text == z0ZzZzfhh.z0olj)
				{
					p1.ParagraphMultiLevel = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0bqj_jiejie20260327142557)
				{
					p1.ParagraphOutlineLevel = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0hvk)
				{
					p1.RTFLineSpacing = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0dlj)
				{
					p1.RightToLeft = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0kbj_jiejie20260327142557)
				{
					p1.SpacingAfterParagraph = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0idj)
				{
					p1.SpacingBeforeParagraph = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0tbj)
				{
					p1.Strikeout = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0rmk)
				{
					p1.Subscript = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0svk)
				{
					p1.Superscript = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0wok)
				{
					p1.Underline = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0jmk)
				{
					p1.UnderlineColor = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0joj)
				{
					p1.UnderlineStyle = (TextUnderlineStyle)p0.z0tek(z0ZzZzfhh.z0lik);
				}
				else if (text == z0ZzZzfhh.z0lrj)
				{
					p1.Visibility = zzz.z0ZzZzcyk<RenderVisibility>.z0eek(p0.z0uek());
				}
				else if (text == z0ZzZzfhh.z0ptj)
				{
					p1.VisibleInDirectory = p0.z0vek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static XTextTDBarcodeElement z0tek(z0ZzZzxjh p0, XTextTDBarcodeElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0hhj)
			{
				p1.BarcodeType = (DCTDBarcodeType)p0.z0tek(z0ZzZzfhh.z0amj);
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gcj)
			{
				p1.ErroeCorrectionLevel = (DCTBErroeCorrectionLevelType)p0.z0tek(z0ZzZzfhh.z0cok);
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					((XTextObjectElement)p1).z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0xok)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PageTexts = z0tek(p0, new PageLabelTextList());
				}
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0kok)
			{
				p1.StrictMatchPageIndex = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.Text = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0qok)
			{
				p1.VAlign = (VerticalAlignStyle)p0.z0tek(z0ZzZzfhh.z0jnk);
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzfpk p1)
	{
		if (p1.z0eek().ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0laj, p1.z0eek());
		}
		if (p1.z0uek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0rjj);
			z0tek(p0, p1.z0uek());
			p0.z0uek();
		}
		if (p1.z0bek() != 2f)
		{
			p0.z0rek(z0ZzZzfhh.z0onj, p1.z0bek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.z0mek());
		p0.z0rek(z0ZzZzfhh.z0xek, p1.z0rek());
	}

	internal static void z0tek(z0ZzZzzjh p0, XPageSettings p1)
	{
		if (p1.LeftMargin != 100)
		{
			p0.z0rek(z0ZzZzfhh.z0vqj, p1.LeftMargin);
		}
		if (p1.RightMargin != 100)
		{
			p0.z0rek(z0ZzZzfhh.z0cdj, p1.RightMargin);
		}
		p0.z0rek(z0ZzZzfhh.z0ytj, p1.z0cek());
		p0.z0rek(z0ZzZzfhh.z0kkj, p1.z0vrk());
		if (p1.TopMargin != 100)
		{
			p0.z0rek(z0ZzZzfhh.z0yej, p1.TopMargin);
		}
		if (p1.BottomMargin != 100)
		{
			p0.z0rek(z0ZzZzfhh.z0fhj, p1.BottomMargin);
		}
		if (p1.z0pek() != 50)
		{
			p0.z0rek(z0ZzZzfhh.z0trk, p1.z0pek());
		}
		if (p1.z0utk() != 50)
		{
			p0.z0rek(z0ZzZzfhh.z0xej, p1.z0utk());
		}
		if (p1.z0crk() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0ykj, p1.z0crk());
		}
		if (p1.z0rtk() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0xpj_jiejie20260327142557, p1.z0rtk());
		}
		if (p1.z0jtk() != 1169)
		{
			p0.z0rek(z0ZzZzfhh.z0oaj, p1.z0jtk());
		}
		if (p1.z0yrk() != PaperKind.A4)
		{
			p0.z0rek(z0ZzZzfhh.z0rsj, zzz.z0ZzZzcyk<PaperKind>.z0rek(p1.z0yrk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0ntk() != 827)
		{
			p0.z0rek(z0ZzZzfhh.z0boj, p1.z0ntk());
		}
		if (p1.z0ork())
		{
			p0.z0rek(z0ZzZzfhh.z0aej, p1.z0ork());
		}
		if (p1.z0ark() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0mdj);
			z0tek(p0, p1.z0ark());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0naj, p1.z0urk());
		if (!p1.z0tek())
		{
			p0.z0rek(z0ZzZzfhh.z0ohj, p1.z0tek());
		}
		if (p1.z0yek())
		{
			p0.z0rek(z0ZzZzfhh.z0buj, p1.z0yek());
		}
		if (p1.z0ltk())
		{
			p0.z0rek(z0ZzZzfhh.z0hnk, p1.z0ltk());
		}
		if (p1.z0brk() != 1)
		{
			p0.z0rek(z0ZzZzfhh.z0rqj, p1.z0brk());
		}
		if (p1.DocumentGridLine != null)
		{
			p0.z0yek(z0ZzZzfhh.z0whj);
			z0tek(p0, p1.DocumentGridLine);
			p0.z0uek();
		}
		if (!p1.z0mek())
		{
			p0.z0rek(z0ZzZzfhh.z0mcj, p1.z0mek());
		}
		if (p1.z0vek())
		{
			p0.z0rek(z0ZzZzfhh.z0vpk, p1.z0vek());
		}
		if (p1.z0erk() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0twj, p1.z0erk());
		}
		if (p1.z0xtk() != DCGutterStyle.Left)
		{
			p0.z0rek(z0ZzZzfhh.z0kdj, z0ZzZzfhh.z0eek(p1.z0xtk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0ktk())
		{
			p0.z0rek(z0ZzZzfhh.z0oxk, p1.z0ktk());
		}
		if (p1.z0grk() != 1)
		{
			p0.z0rek(z0ZzZzfhh.z0cnk, p1.z0grk());
		}
		if (p1.z0gtk() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.z0gtk());
		}
		if (p1.z0srk() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.z0srk());
		}
		if (p1.PageBorderBackground != null)
		{
			p0.z0yek(z0ZzZzfhh.z0muj);
			z0tek(p0, p1.PageBorderBackground);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0byj, p1.z0irk());
		p0.z0rek(z0ZzZzfhh.z0mik, p1.z0mtk());
		if (p1.z0uek())
		{
			p0.z0rek(z0ZzZzfhh.z0wzk, p1.z0uek());
		}
		if (p1.z0zek() != 1f)
		{
			p0.z0rek(z0ZzZzfhh.z0zaj, p1.z0zek());
		}
		if (p1.z0otk())
		{
			p0.z0rek(z0ZzZzfhh.z0frk, p1.z0otk());
		}
		if (p1.z0zrk() != DCDuplexType.NoSpecify)
		{
			p0.z0rek(z0ZzZzfhh.z0qtj, z0ZzZzfhh.z0eek(p1.z0zrk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0ftk())
		{
			p0.z0rek(z0ZzZzfhh.z0jnj, p1.z0ftk());
		}
		if (!p1.z0nek())
		{
			p0.z0rek(z0ZzZzfhh.z0dok, p1.z0nek());
		}
		if (p1.z0itk())
		{
			p0.z0rek(z0ZzZzfhh.z0hqj, p1.z0itk());
		}
		if (p1.z0xek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0itk);
			z0tek(p0, p1.z0xek());
			p0.z0uek();
		}
		if (p1.z0jrk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0kpj);
			z0tek(p0, p1.z0jrk());
			p0.z0uek();
		}
	}

	internal static XTextSignImageElement z0tek(z0ZzZzxjh p0, XTextSignImageElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0nlj)
			{
				p1.DataForSelfCheck = p0.z0tek();
			}
			else if (text == z0ZzZzfhh.z0zik)
			{
				p1.DefaultSignMode = (DCCASignMode)p0.z0tek(z0ZzZzfhh.z0ock);
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0uij)
			{
				p1.ImageData = p0.z0tek();
			}
			else if (text == z0ZzZzfhh.z0sjj)
			{
				p1.LastVerifyResult = p0.z0tek();
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0hrk)
			{
				p1.SignClientName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0wsj)
			{
				p1.SignErrorMessage = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dyj)
			{
				p1.SignMessage = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0grj)
			{
				p1.SignProviderName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0rvk)
			{
				p1.SignRange = (DCSignRange)p0.z0tek(z0ZzZzfhh.z0cek);
			}
			else if (text == z0ZzZzfhh.z0aaj)
			{
				p1.SignTime = p0.z0cek();
			}
			else if (text == z0ZzZzfhh.z0wjj)
			{
				p1.SignUserID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0rej)
			{
				p1.SignUserName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0zoj)
			{
				p1.Title = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0fvj)
			{
				p1.UseInnerSignProvider = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextBarcodeFieldElement p1)
	{
		XTextElementList xTextElementList = p1.z0be();
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, xTextElementList);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.AcceptTab)
		{
			p0.z0rek(z0ZzZzfhh.z0gdj, p1.AcceptTab);
		}
		if (p1.Alignment != StringAlignment.Near)
		{
			p0.z0rek(z0ZzZzfhh.z0otj, z0ZzZzfhh.z0eek(p1.Alignment), z0ZzZzeok.z0mjj.z0tek);
		}
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (!p1.AutoExitEditMode)
		{
			p0.z0rek(z0ZzZzfhh.z0zmk, p1.AutoExitEditMode);
		}
		if (p1.z0pek())
		{
			p0.z0rek(z0ZzZzfhh.z0ltj, p1.z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0hoj, p1.BackgroundText);
		if (p1.BackgroundTextColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0lbj, p1.BackgroundTextColor);
		}
		if (((XTextFieldElementBase)p1).z0drk() != DCBooleanValueHasDefault.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0cgj, z0ZzZzfhh.z0eek(((XTextFieldElementBase)p1).z0drk()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BarcodeStyle != (z0ZzZzrrk)30)
		{
			p0.z0rek(z0ZzZzfhh.z0ucj, z0ZzZzfhh.z0eek(p1.BarcodeStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BorderElementColor.ToArgb() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0lhj, p1.BorderElementColor);
		}
		if (p1.z0oek() != (z0ZzZzscj)1)
		{
			p0.z0rek(z0ZzZzfhh.z0tlj, z0ZzZzfhh.z0eek(p1.z0oek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BorderVisible != DCVisibleState.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0tvj, z0ZzZzfhh.z0eek(p1.BorderVisible), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0gqj, p1.DefaultEventExpression);
		p0.z0rek(z0ZzZzfhh.z0vzk, p1.z0nrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.DisplayFormat != null)
		{
			p0.z0yek(z0ZzZzfhh.z0jyj);
			z0tek(p0, p1.DisplayFormat);
			p0.z0uek();
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		if (p1.EnableHighlight != EnableState.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0doj, z0ZzZzfhh.z0eek(p1.EnableHighlight), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.EnableValueValidate)
		{
			p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		}
		p0.z0rek(z0ZzZzfhh.z0phj, p1.EndBorderText);
		if (p1.EndingLineBreak)
		{
			p0.z0rek(z0ZzZzfhh.z0gok, p1.EndingLineBreak);
		}
		z0ZzZzukh eventExpressions = p1.EventExpressions;
		if (eventExpressions != null && eventExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0jfj);
			z0tek(p0, eventExpressions);
			p0.z0yek();
		}
		if (((XTextInputFieldElementBase)p1).z0rek() != DCFastInputMode.NextField)
		{
			p0.z0rek(z0ZzZzfhh.z0syj, z0ZzZzfhh.z0eek(((XTextInputFieldElementBase)p1).z0rek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.Height != 125f)
		{
			p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		}
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		p0.z0rek(z0ZzZzfhh.z0pgj, p1.InnerValue);
		p0.z0rek(z0ZzZzfhh.z0zvj, p1.LabelText);
		if (p1.LableUnitTextBold != DCBooleanValueHasDefault.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0zij, z0ZzZzfhh.z0eek(p1.LableUnitTextBold), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.MinBarWidth != 7f)
		{
			p0.z0rek(z0ZzZzfhh.z0yuk, p1.MinBarWidth);
		}
		if (p1.MoveFocusHotKey != MoveFocusHotKeys.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0tcj, zzz.z0ZzZzcyk<MoveFocusHotKeys>.z0rek(p1.MoveFocusHotKey), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.z0cek() != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0yyj, z0ZzZzfhh.z0eek(p1.z0cek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (!p1.ShowText)
		{
			p0.z0rek(z0ZzZzfhh.z0yij, p1.ShowText);
		}
		if (p1.SpecifyWidth != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dij, p1.SpecifyWidth);
		}
		p0.z0rek(z0ZzZzfhh.z0njj, p1.StartBorderText);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		if (p1.TabIndex != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0blj, p1.TabIndex);
		}
		if (!p1.TabStop)
		{
			p0.z0rek(z0ZzZzfhh.z0dsj, p1.TabStop);
		}
		if (p1.TextAlignment != StringAlignment.Center)
		{
			p0.z0rek(z0ZzZzfhh.z0opj, z0ZzZzfhh.z0eek(p1.TextAlignment), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.TextColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0ojj, p1.TextColor);
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		p0.z0rek(z0ZzZzfhh.z0ack, p1.UnitText);
		if (!p1.UserEditable)
		{
			p0.z0rek(z0ZzZzfhh.z0vrj, p1.UserEditable);
		}
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (p1.ViewEncryptType != ContentViewEncryptType.None)
		{
			p0.z0rek(z0ZzZzfhh.z0cmj, z0ZzZzfhh.z0eek(p1.ViewEncryptType), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static z0ZzZzzyj z0tek(z0ZzZzxjh p0, z0ZzZzzyj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0sok)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.Default = z0tek(p0, new z0ZzZzcok());
				}
			}
			else if (text == z0ZzZzfhh.z0djj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				z0ZzZzzok z0ZzZzzok2 = new z0ZzZzzok();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						z0ZzZzzok2.Add(z0tek(p0, new z0ZzZzcok()));
					}
				}
				if (z0ZzZzzok2.Count > 0)
				{
					p1.Styles = z0ZzZzzok2;
				}
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextCustomShapeElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.z0eek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0pcj, p1.z0eek());
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		p0.z0rek(z0ZzZzfhh.z0nhj, p1.z0tek());
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static z0ZzZzstk z0tek(z0ZzZzxjh p0, z0ZzZzstk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0otj)
			{
				p1.z0eek(zzz.z0ZzZzcyk<ContentAlignment>.z0eek(p0.z0uek()));
			}
			else if (text == z0ZzZzfhh.z0laj)
			{
				p1.z0eek(p0.z0tek(z0cek));
			}
			else if (text == z0ZzZzfhh.z0rjj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzimk()));
				}
			}
			else if (text == z0ZzZzfhh.z0xhj)
			{
				p1.z0tek(p0.z0oek());
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0kbk)
			{
				p1.z0rek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0gyk)
			{
				p1.z0eek((RangeCalculateStyle)p0.z0tek(z0ZzZzfhh.z0mrj_jiejie20260327142557));
			}
			else if (text == z0ZzZzfhh.z0toj)
			{
				p1.z0eek(p0.z0oek());
			}
			else if (text == z0ZzZzfhh.z0tpj)
			{
				p1.z0rek(p0.z0oek());
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.z0tek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0qhj)
			{
				p1.z0rek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.z0eek(p0.z0vek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, DocumentContentStyle p1)
	{
		p0.z0rek(z0ZzZzfhh.z0asj, p1.FontName);
		if (p1.FontSize != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0pck, p1.FontSize);
		}
		if (p1.Index != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0xxk, p1.Index);
		}
		if (p1.Color.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0laj, p1.Color);
		}
		if (p1.Align != DocumentContentAlignment.Left)
		{
			p0.z0rek(z0ZzZzfhh.z0gnj, z0ZzZzfhh.z0eek(p1.Align), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BorderWidth != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0etj, p1.BorderWidth);
		}
		if (p1.PaddingLeft != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0uaj, p1.PaddingLeft);
		}
		if (p1.LineSpacingStyle != LineSpacingStyle.SpaceSingle)
		{
			p0.z0rek(z0ZzZzfhh.z0pvj, z0ZzZzfhh.z0eek(p1.LineSpacingStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.Bold)
		{
			p0.z0rek(z0ZzZzfhh.z0vyk, p1.Bold);
		}
		if (p1.BorderBottom)
		{
			p0.z0rek(z0ZzZzfhh.z0jvk, p1.BorderBottom);
		}
		if (p1.PaddingTop != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0esj, p1.PaddingTop);
		}
		if (p1.PaddingBottom != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0gjj, p1.PaddingBottom);
		}
		if (p1.BorderTop)
		{
			p0.z0rek(z0ZzZzfhh.z0vgj, p1.BorderTop);
		}
		if (p1.BorderLeft)
		{
			p0.z0rek(z0ZzZzfhh.z0wmj, p1.BorderLeft);
		}
		if (p1.BorderRight)
		{
			p0.z0rek(z0ZzZzfhh.z0lej, p1.BorderRight);
		}
		if (p1.LineSpacing != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0nmj, p1.LineSpacing);
		}
		if (p1.VerticalAlign != VerticalAlignStyle.Top)
		{
			p0.z0rek(z0ZzZzfhh.z0dik, z0ZzZzfhh.z0eek(p1.VerticalAlign), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.PaddingRight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0cpj, p1.PaddingRight);
		}
		if (p1.FirstLineIndent != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hbj, p1.FirstLineIndent);
		}
		if (p1.SpacingBeforeParagraph != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0idj, p1.SpacingBeforeParagraph);
		}
		if (p1.SpacingAfterParagraph != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0kbj_jiejie20260327142557, p1.SpacingAfterParagraph);
		}
		if (p1.ProtectType != ContentProtectType.None)
		{
			p0.z0rek(z0ZzZzfhh.z0ilj, z0ZzZzfhh.z0eek(p1.ProtectType), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.CreatorIndex != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0qoj, p1.CreatorIndex);
		}
		if (p1.Underline)
		{
			p0.z0rek(z0ZzZzfhh.z0wok, p1.Underline);
		}
		if (p1.BackgroundColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0okj, p1.BackgroundColor);
		}
		if (p1.LeftIndent != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0vpj, p1.LeftIndent);
		}
		if (p1.BorderRightColor.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0uik, p1.BorderRightColor);
		}
		if (p1.BorderLeftColor.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0nyj, p1.BorderLeftColor);
		}
		if (p1.DeleterIndex != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0suk, p1.DeleterIndex);
		}
		if (p1.BorderBottomColor.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0azk, p1.BorderBottomColor);
		}
		if (p1.BorderTopColor.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0uyk, p1.BorderTopColor);
		}
		if (p1.GridLineType != ContentGridLineType.None)
		{
			p0.z0rek(z0ZzZzfhh.z0dvk, z0ZzZzfhh.z0eek(p1.GridLineType), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.TitleLevel != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0ooj, p1.TitleLevel);
		}
		if (p1.LayoutDirection != ContentLayoutDirectionStyle.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0wkj, z0ZzZzfhh.z0eek(p1.LayoutDirection), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BorderSpacing != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0ink, p1.BorderSpacing);
		}
		if (p1.ParagraphListStyle != ParagraphListStyle.None)
		{
			p0.z0rek(z0ZzZzfhh.z0ijj, zzz.z0ZzZzcyk<ParagraphListStyle>.z0rek(p1.ParagraphListStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.ParagraphMultiLevel)
		{
			p0.z0rek(z0ZzZzfhh.z0olj, p1.ParagraphMultiLevel);
		}
		if (p1.ParagraphOutlineLevel != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0bqj_jiejie20260327142557, p1.ParagraphOutlineLevel);
		}
		if (p1.Subscript)
		{
			p0.z0rek(z0ZzZzfhh.z0rmk, p1.Subscript);
		}
		if (p1.CommentIndex != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0jbk, p1.CommentIndex);
		}
		if (p1.PrintBackColor.ToArgb() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0ljj, p1.PrintBackColor);
		}
		if (p1.PrintColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0mzk, p1.PrintColor);
		}
		if (p1.Superscript)
		{
			p0.z0rek(z0ZzZzfhh.z0svk, p1.Superscript);
		}
		if (p1.CharacterCircle != CharacterCircleStyles.None)
		{
			p0.z0rek(z0ZzZzfhh.z0wdj, z0ZzZzfhh.z0eek(p1.CharacterCircle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.GridLineStyle != DashStyle.Solid)
		{
			p0.z0rek(z0ZzZzfhh.z0rbj, z0ZzZzfhh.z0eek(p1.GridLineStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.Visibility != RenderVisibility.All)
		{
			p0.z0rek(z0ZzZzfhh.z0lrj, zzz.z0ZzZzcyk<RenderVisibility>.z0rek(p1.Visibility), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BackgroundColor2.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0crj, p1.BackgroundColor2);
		}
		if (p1.BorderStyle != DashStyle.Solid)
		{
			p0.z0rek(z0ZzZzfhh.z0nck, z0ZzZzfhh.z0eek(p1.BorderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0jtk, p1.Cursor);
		if (p1.EmphasisMark)
		{
			p0.z0rek(z0ZzZzfhh.z0fqj, p1.EmphasisMark);
		}
		if (p1.FixedSpacing)
		{
			p0.z0rek(z0ZzZzfhh.z0lvk, p1.FixedSpacing);
		}
		if (p1.GridLineColor.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0xlj, p1.GridLineColor);
		}
		if (p1.GridLineOffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0ctj, p1.GridLineOffsetY);
		}
		if (p1.Italic)
		{
			p0.z0rek(z0ZzZzfhh.z0wtk, p1.Italic);
		}
		if (p1.LayoutAlign != ContentLayoutAlign.EmbedInText)
		{
			p0.z0rek(z0ZzZzfhh.z0dqj, z0ZzZzfhh.z0eek(p1.LayoutAlign), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.LetterSpacing != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0qpk, p1.LetterSpacing);
		}
		if (p1.MarginBottom != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0lpk, p1.MarginBottom);
		}
		if (p1.MarginLeft != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0oik, p1.MarginLeft);
		}
		if (p1.MarginRight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0nej, p1.MarginRight);
		}
		if (p1.MarginTop != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0sck, p1.MarginTop);
		}
		if (p1.Multiline)
		{
			p0.z0rek(z0ZzZzfhh.z0raj, p1.Multiline);
		}
		if (p1.RTFLineSpacing != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hvk, p1.RTFLineSpacing);
		}
		if (p1.RightToLeft)
		{
			p0.z0rek(z0ZzZzfhh.z0dlj, p1.RightToLeft);
		}
		if (p1.Strikeout)
		{
			p0.z0rek(z0ZzZzfhh.z0tbj, p1.Strikeout);
		}
		p0.z0rek(z0ZzZzfhh.z0jmk, p1.UnderlineColor);
		if (p1.UnderlineStyle != TextUnderlineStyle.Single)
		{
			p0.z0rek(z0ZzZzfhh.z0joj, z0ZzZzfhh.z0eek(p1.UnderlineStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.VisibleInDirectory)
		{
			p0.z0rek(z0ZzZzfhh.z0ptj, p1.VisibleInDirectory);
		}
	}

	internal static z0ZzZzauj z0tek(z0ZzZzxjh p0, z0ZzZzauj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0qej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzcok()));
				}
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0eoj)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0pik)
			{
				p1.z0yek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0mbk)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0eqj)
			{
				p1.z0tek(p0.z0yek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextLineBreakElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (p1.z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, p1.z0pek());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XAttributeList p1)
	{
		if (p1.Count > 0)
		{
			p0.z0iek();
			int count = p1.Count;
			for (int i = 0; i < count; i++)
			{
				XAttribute xAttribute = p1[i];
				p0.z0tek();
				p0.z0rek(z0ZzZzfhh.z0ntj, xAttribute.Name);
				p0.z0rek(z0ZzZzfhh.z0jsj, xAttribute.Value);
				p0.z0mek();
			}
			p0.z0nek();
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextControlHostElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (p1.AllowUserResize != ResizeableType.WidthAndHeight)
		{
			p0.z0rek(z0ZzZzfhh.z0kvj, z0ZzZzfhh.z0eek(p1.AllowUserResize), z0ZzZzeok.z0mjj.z0tek);
		}
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0ry() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0ngj, z0ZzZzfhh.z0eek(p1.z0ry()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.DelayLoadControl)
		{
			p0.z0rek(z0ZzZzfhh.z0pkj, p1.DelayLoadControl);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		if (p1.z0uek() != (z0ZzZzgzj)2)
		{
			p0.z0rek(z0ZzZzfhh.z0wrj, z0ZzZzfhh.z0eek(p1.z0uek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (((XTextObjectElement)p1).z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, ((XTextObjectElement)p1).z0iek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		p0.z0rek(z0ZzZzfhh.z0nfj, p1.z0iek());
		if (p1.Parameters != null)
		{
			ObjectParameterList parameters = p1.Parameters;
			int count = parameters.Count;
			if (count > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0hlj);
				p0.z0iek();
				for (int i = 0; i < count; i++)
				{
					p0.z0tek();
					z0tek(p0, parameters[i]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		p0.z0rek(z0ZzZzfhh.z0sxk, p1.z0tek());
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.z0yek())
		{
			p0.z0rek(z0ZzZzfhh.z0fwj, p1.z0yek());
		}
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.Text);
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		p0.z0rek(z0ZzZzfhh.z0zdj, p1.TypeFullName);
		if (p1.VAlign != VerticalAlignStyle.Top)
		{
			p0.z0rek(z0ZzZzfhh.z0qok, z0ZzZzfhh.z0eek(p1.VAlign), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		p0.z0rek(z0ZzZzfhh.z0onk, p1.ValuePropertyName);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzauj p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, ((z0ZzZzhuj)p1).z0yek());
		if (p1.z0pek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0qej);
			z0tek(p0, p1.z0pek());
			p0.z0uek();
		}
		if (((z0ZzZzhuj)p1).z0eek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((z0ZzZzhuj)p1).z0eek());
		}
		if (!p1.z0rek_jiejie20260327142557())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0rek_jiejie20260327142557());
		}
		if (p1.z0eek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0eoj, p1.z0eek());
		}
		if (p1.z0yek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0pik, p1.z0yek());
		}
		if (p1.z0uek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0mbk, p1.z0uek());
		}
		if (p1.z0rek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0eqj, p1.z0rek());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzemk p1)
	{
		if (p1.z0eek().ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0laj, p1.z0eek());
		}
		if (p1.z0rek().ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0uck, p1.z0rek());
		}
		if (p1.z0oek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0lpj);
			z0tek(p0, p1.z0oek());
			p0.z0uek();
		}
		if (p1.z0iek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.z0iek());
		}
		if (p1.z0tek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.z0tek());
		}
		if (!p1.z0yek())
		{
			p0.z0rek(z0ZzZzfhh.z0fyk, p1.z0yek());
		}
		if (p1.z0cek() != XBrushStyleConst.Solid)
		{
			p0.z0rek(z0ZzZzfhh.z0moj, zzz.z0ZzZzcyk<XBrushStyleConst>.z0rek(p1.z0cek()), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextMediaElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (p1.AllowUserResize != ResizeableType.WidthAndHeight)
		{
			p0.z0rek(z0ZzZzfhh.z0kvj, z0ZzZzfhh.z0eek(p1.AllowUserResize), z0ZzZzeok.z0mjj.z0tek);
		}
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.z0rek())
		{
			p0.z0rek(z0ZzZzfhh.z0rwj, p1.z0rek());
		}
		if (!p1.DelayLoadControl)
		{
			p0.z0rek(z0ZzZzfhh.z0pkj, p1.DelayLoadControl);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.Image != null && p1.Image.HasContent)
		{
			p0.z0yek(z0ZzZzfhh.z0lpj);
			z0tek(p0, p1.Image);
			p0.z0uek();
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		if (!p1.EnableMediaContextMenu)
		{
			p0.z0rek(z0ZzZzfhh.z0svj, p1.EnableMediaContextMenu);
		}
		p0.z0rek(z0ZzZzfhh.z0bgj, p1.FileContentType);
		p0.z0rek(z0ZzZzfhh.z0xtj, p1.FileName);
		p0.z0rek(z0ZzZzfhh.z0zok, p1.FileSystemName);
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		if (p1.z0uek() != (z0ZzZzgzj)2)
		{
			p0.z0rek(z0ZzZzfhh.z0wrj, z0ZzZzfhh.z0eek(p1.z0uek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (((XTextObjectElement)p1).z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, ((XTextObjectElement)p1).z0iek());
			p0.z0uek();
		}
		if (p1.LoopPlay)
		{
			p0.z0rek(z0ZzZzfhh.z0qnj, p1.LoopPlay);
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		p0.z0rek(z0ZzZzfhh.z0nfj, p1.z0iek());
		if (p1.Parameters != null)
		{
			ObjectParameterList parameters = p1.Parameters;
			int count = parameters.Count;
			if (count > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0hlj);
				p0.z0iek();
				for (int i = 0; i < count; i++)
				{
					p0.z0tek();
					z0tek(p0, parameters[i]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		if (p1.PlayerUIMode != WindowsMediaPlayerUIMode.mini)
		{
			p0.z0rek(z0ZzZzfhh.z0quj, z0ZzZzfhh.z0eek(p1.PlayerUIMode), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0sxk, p1.z0tek());
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.z0yek())
		{
			p0.z0rek(z0ZzZzfhh.z0fwj, p1.z0yek());
		}
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.Text);
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.VAlign != VerticalAlignStyle.Bottom)
		{
			p0.z0rek(z0ZzZzfhh.z0qok, z0ZzZzfhh.z0eek(p1.VAlign), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		p0.z0rek(z0ZzZzfhh.z0onk, p1.ValuePropertyName);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static XTextTableRowElement z0tek(z0ZzZzxjh p0, XTextTableRowElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0ugj)
			{
				p1.SpecifyHeight = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0amk)
			{
				p1.CanSplitByPageLine = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0pqj)
			{
				p1.CloneType = (TableRowCloneType)p0.z0tek(z0ZzZzfhh.z0guj);
			}
			else if (text == z0ZzZzfhh.z0mnk)
			{
				p1.HeaderStyle = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0vrk)
			{
				p1.AllowInsertRowDownUseHotKey = (DCInsertRowDownUseHotKeys)p0.z0tek(z0ZzZzfhh.z0noj);
			}
			else if (text == z0ZzZzfhh.z0vmk)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0qjj)
			{
				p1.AllowUserToResizeHeight = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0obk)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				XTextElementList xTextElementList = new XTextElementList();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						xTextElementList.Add(z0tek(p0, new XTextTableCellElement()));
					}
				}
				if (xTextElementList.Count > 0)
				{
					p1.z0eek(xTextElementList);
				}
			}
			else if (text == z0ZzZzfhh.z0lrk)
			{
				p1.z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0upk)
			{
				p1.ExpendForDataBinding = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0qik)
			{
				p1.z0rek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0tfj)
			{
				p1.z0rek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0wtj)
			{
				p1.NewPage = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0rpj)
			{
				p1.PrintCellBackground = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0hkj)
			{
				p1.PrintCellBorder = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzvpk z0tek(z0ZzZzxjh p0, z0ZzZzvpk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0gnj)
				{
					p1.Align = (DocumentContentAlignment)p0.z0tek(z0ZzZzfhh.z0xfj);
				}
				else if (text == z0ZzZzfhh.z0okj)
				{
					p1.BackgroundColor = p0.z0tek(z0vek);
				}
				else if (text == z0ZzZzfhh.z0crj)
				{
					p1.BackgroundColor2 = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0vyk)
				{
					p1.Bold = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0jvk)
				{
					p1.BorderBottom = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0azk)
				{
					p1.BorderBottomColor = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0wmj)
				{
					p1.BorderLeft = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0nyj)
				{
					p1.BorderLeftColor = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0xwj)
				{
					p1.z0eek((PageBorderRangeTypes)p0.z0tek(z0ZzZzfhh.z0trj));
				}
				else if (text == z0ZzZzfhh.z0lej)
				{
					p1.BorderRight = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0uik)
				{
					p1.BorderRightColor = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0ink)
				{
					p1.BorderSpacing = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0nck)
				{
					p1.BorderStyle = (DashStyle)p0.z0tek(z0ZzZzfhh.z0bnj);
				}
				else if (text == z0ZzZzfhh.z0vgj)
				{
					p1.BorderTop = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0uyk)
				{
					p1.BorderTopColor = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0etj)
				{
					p1.BorderWidth = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0wdj)
				{
					p1.CharacterCircle = (CharacterCircleStyles)p0.z0tek(z0ZzZzfhh.z0pvk);
				}
				else if (text == z0ZzZzfhh.z0laj)
				{
					p1.Color = p0.z0tek(z0cek);
				}
				else if (text == z0ZzZzfhh.z0fqj)
				{
					p1.EmphasisMark = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0hbj)
				{
					p1.FirstLineIndent = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0lvk)
				{
					p1.FixedSpacing = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0asj)
				{
					p1.FontName = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0pck)
				{
					p1.FontSize = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0xxk)
				{
					p1.Index = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0wtk)
				{
					p1.Italic = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0dqj)
				{
					p1.LayoutAlign = (ContentLayoutAlign)p0.z0tek(z0ZzZzfhh.z0stk);
				}
				else if (text == z0ZzZzfhh.z0vpj)
				{
					p1.LeftIndent = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0qpk)
				{
					p1.LetterSpacing = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0nmj)
				{
					p1.LineSpacing = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0pvj)
				{
					p1.LineSpacingStyle = (LineSpacingStyle)p0.z0tek(z0ZzZzfhh.z0lcj);
				}
				else if (text == z0ZzZzfhh.z0lpk)
				{
					p1.MarginBottom = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0oik)
				{
					p1.MarginLeft = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0nej)
				{
					p1.MarginRight = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0sck)
				{
					p1.MarginTop = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0raj)
				{
					p1.Multiline = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0gjj)
				{
					p1.PaddingBottom = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0uaj)
				{
					p1.PaddingLeft = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0cpj)
				{
					p1.PaddingRight = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0esj)
				{
					p1.PaddingTop = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0ijj)
				{
					p1.ParagraphListStyle = zzz.z0ZzZzcyk<ParagraphListStyle>.z0eek(p0.z0uek());
				}
				else if (text == z0ZzZzfhh.z0olj)
				{
					p1.ParagraphMultiLevel = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0bqj_jiejie20260327142557)
				{
					p1.ParagraphOutlineLevel = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0dlj)
				{
					p1.RightToLeft = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0hvk)
				{
					p1.RTFLineSpacing = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0kbj_jiejie20260327142557)
				{
					p1.SpacingAfterParagraph = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0idj)
				{
					p1.SpacingBeforeParagraph = p0.z0yek();
				}
				else if (text == z0ZzZzfhh.z0tbj)
				{
					p1.Strikeout = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0rmk)
				{
					p1.Subscript = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0svk)
				{
					p1.Superscript = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0wok)
				{
					p1.Underline = p0.z0vek();
				}
				else if (text == z0ZzZzfhh.z0jmk)
				{
					p1.UnderlineColor = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0joj)
				{
					p1.UnderlineStyle = (TextUnderlineStyle)p0.z0tek(z0ZzZzfhh.z0lik);
				}
				else if (text == z0ZzZzfhh.z0dik)
				{
					p1.VerticalAlign = (VerticalAlignStyle)p0.z0tek(z0ZzZzfhh.z0jnk);
				}
				else if (text == z0ZzZzfhh.z0lrj)
				{
					p1.Visibility = zzz.z0ZzZzcyk<RenderVisibility>.z0eek(p0.z0uek());
				}
				else if (text == z0ZzZzfhh.z0ptj)
				{
					p1.VisibleInDirectory = p0.z0vek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextSectionElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.CompressOwnerLineSpacing)
		{
			p0.z0rek(z0ZzZzfhh.z0ehj, p1.CompressOwnerLineSpacing);
		}
		if (XTextElementList.z0pek(p1.z0be()))
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, p1.z0be());
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.AcceptTab)
		{
			p0.z0rek(z0ZzZzfhh.z0gdj, p1.AcceptTab);
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0vzk, ((XTextContainerElement)p1).z0nrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.EnableCollapse)
		{
			p0.z0rek(z0ZzZzfhh.z0ovj, p1.EnableCollapse);
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		if (!p1.ExpendForDataBinding)
		{
			p0.z0rek(z0ZzZzfhh.z0upk, p1.ExpendForDataBinding);
		}
		if (p1.ForeColorForCollapsed.ToArgb() != -8355712)
		{
			p0.z0rek(z0ZzZzfhh.z0uuj, p1.ForeColorForCollapsed);
		}
		if (p1.GridLine != null)
		{
			p0.z0yek(z0ZzZzfhh.z0jaj);
			z0tek(p0, p1.GridLine);
			p0.z0uek();
		}
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		if (p1.InsertEmptyPageForNewPage)
		{
			p0.z0rek(z0ZzZzfhh.z0llj, p1.InsertEmptyPageForNewPage);
		}
		if (p1.IsCollapsed)
		{
			p0.z0rek(z0ZzZzfhh.z0gyj, p1.IsCollapsed);
		}
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.NewPage)
		{
			p0.z0rek(z0ZzZzfhh.z0wtj, p1.NewPage);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.SpecifyFixedLineHeight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0swj, p1.SpecifyFixedLineHeight);
		}
		if (p1.SpecifyHeight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0ugj, p1.SpecifyHeight);
		}
		p0.z0rek(z0ZzZzfhh.z0zoj, p1.Title);
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextTableColumnElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (p1.z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, p1.z0pek());
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
	}

	internal static XTextSubDocumentElement z0tek(z0ZzZzxjh p0, XTextSubDocumentElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0ehj)
			{
				p1.CompressOwnerLineSpacing = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0vuj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.DocumentInfo = z0tek(p0, new DocumentInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0xtj)
			{
				p1.FileName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uuj)
			{
				p1.ForeColorForCollapsed = p0.z0tek(z0hrk);
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0fgj)
			{
				p1.FileFormat = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0wtj)
			{
				p1.NewPage = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0gdj)
			{
				p1.AcceptTab = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0nrk)
			{
				p1.ContentLoaded = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				((XTextContainerElement)p1).z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0yvk)
			{
				p1.DelayLoadWhenExpand = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ujj)
			{
				p1.DocumentID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0ovj)
			{
				p1.EnableCollapse = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0upk)
			{
				p1.ExpendForDataBinding = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0jaj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.GridLine = z0tek(p0, new z0ZzZzzej());
				}
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0ruj)
			{
				p1.ImportUserTrack = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0llj)
			{
				p1.InsertEmptyPageForNewPage = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gyj)
			{
				p1.IsCollapsed = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0iij)
			{
				p1.Locked = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0rij)
			{
				p1.PrintPositionInPage = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dmk)
			{
				p1.Printed = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0qyj)
			{
				p1.PrintedPageIndex = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0swj)
			{
				p1.SpecifyFixedLineHeight = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0ugj)
			{
				p1.SpecifyHeight = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0zoj)
			{
				p1.Title = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	public static XTextDocument z0tek(TextReader p0, XTextDocument p1)
	{
		z0ZzZzxjh z0ZzZzxjh2 = new z0ZzZzxjh(p0);
		if (z0ZzZzxjh2.z0uq() && ((z0ZzZzxqh)z0ZzZzxjh2).z0uek() == (z0ZzZzkwh)1 && z0ZzZzxjh2.z0mek() == z0ZzZzfhh.z0daj)
		{
			XTextElementList.z0qrk = true;
			try
			{
				z0tek(z0ZzZzxjh2, p1);
				z0ZzZzdhh.z0rek(p1);
			}
			finally
			{
				XTextElementList.z0qrk = false;
			}
			z0ZzZzxjh2.z0nek();
		}
		return p1;
	}

	internal static z0ZzZzdvj z0tek(z0ZzZzxjh p0, z0ZzZzdvj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
		{
			if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
			{
				p1.Add(z0tek(p0, new ListItem()));
			}
		}
		return p1;
	}

	internal static XTextNewBarcodeElement z0tek(z0ZzZzxjh p0, XTextNewBarcodeElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0erj)
			{
				p1.BarcodeStyle2 = (DCBarcodeStyle)p0.z0tek(z0ZzZzfhh.z0kqj);
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					((XTextObjectElement)p1).z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0xok)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PageTexts = z0tek(p0, new PageLabelTextList());
				}
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0yij)
			{
				p1.ShowText = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0kok)
			{
				p1.StrictMatchPageIndex = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.Text = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0opj)
			{
				p1.TextAlignment = (StringAlignment)p0.z0tek(z0ZzZzfhh.z0arj);
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzdkh p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.z0eek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0pmj, p1.z0eek());
		}
		if (p1.z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, p1.z0pek());
		}
	}

	internal static XTextMediaElement z0tek(z0ZzZzxjh p0, XTextMediaElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0kvj)
			{
				p1.AllowUserResize = (ResizeableType)p0.z0tek(z0ZzZzfhh.z0sqj);
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0lpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.Image = z0tek(p0, new z0ZzZzpmk());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0rwj)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0pkj)
			{
				p1.DelayLoadControl = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0svj)
			{
				p1.EnableMediaContextMenu = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0bgj)
			{
				p1.FileContentType = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0xtj)
			{
				p1.FileName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zok)
			{
				p1.FileSystemName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0wrj)
			{
				p1.z0eek((z0ZzZzgzj)p0.z0tek(z0ZzZzfhh.z0gpj));
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0qnj)
			{
				p1.LoopPlay = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0nfj)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0hlj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				ObjectParameterList objectParameterList = new ObjectParameterList();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						objectParameterList.Add(z0tek(p0, new ObjectParameter()));
					}
				}
				if (objectParameterList.Count > 0)
				{
					p1.Parameters = objectParameterList;
				}
			}
			else if (text == z0ZzZzfhh.z0quj)
			{
				p1.PlayerUIMode = (WindowsMediaPlayerUIMode)p0.z0tek(z0ZzZzfhh.z0ahj);
			}
			else if (text == z0ZzZzfhh.z0sxk)
			{
				p1.z0eek(p0.z0tek());
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0fwj)
			{
				((XTextControlHostElement)p1).z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.Text = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0qok)
			{
				p1.VAlign = (VerticalAlignStyle)p0.z0tek(z0ZzZzfhh.z0jnk);
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0onk)
			{
				p1.ValuePropertyName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	private static void z0tek(z0ZzZzzjh p0, XTextElementList p1)
	{
		if (p1 == null || p1.Count <= 0)
		{
			return;
		}
		if (p1.z0mek())
		{
			int z0buk = p1[0].z0buk;
			if (z0buk >= 0)
			{
				p0.z0rek(z0ZzZzfhh.z0lkj, z0buk);
			}
		}
		else
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, p1);
			p0.z0yek();
		}
	}

	internal static InputFieldSettings z0tek(z0ZzZzxjh p0, InputFieldSettings p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0exk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzsvj()));
				}
			}
			else if (text == z0ZzZzfhh.z0jhj)
			{
				p1.z0eek((InputFieldEditStyle)p0.z0tek(z0ZzZzfhh.z0bzk));
			}
			else if (text == z0ZzZzfhh.z0sbj)
			{
				p1.z0rek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0rkj)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0mfj)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vnk)
			{
				p1.z0uek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0vij)
			{
				p1.z0tek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0jdj)
			{
				p1.z0rek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0vdj)
			{
				p1.z0yek(p0.z0vek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzzej z0tek(z0ZzZzxjh p0, z0ZzZzzej p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0xgj)
				{
					p1.z0tek(p0.z0yek());
				}
				else if (text == z0ZzZzfhh.z0mtk)
				{
					p1.z0eek(p0.z0vek());
				}
				else if (text == z0ZzZzfhh.z0bfj)
				{
					p1.z0tek(p0.z0vek());
				}
				else if (text == z0ZzZzfhh.z0laj)
				{
					p1.z0eek(p0.z0tek(z0cek));
				}
				else if (text == z0ZzZzfhh.z0efj)
				{
					p1.z0eek(p0.z0pek());
				}
				else if (text == z0ZzZzfhh.z0nkj)
				{
					p1.z0eek((DashStyle)p0.z0tek(z0ZzZzfhh.z0bnj));
				}
				else if (text == z0ZzZzfhh.z0zuk)
				{
					p1.z0rek(p0.z0yek());
				}
				else if (text == z0ZzZzfhh.z0pek)
				{
					p1.z0rek(p0.z0vek());
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static XTextRulerElement z0tek(z0ZzZzxjh p0, XTextRulerElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0rjj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.Font = z0tek(p0, new z0ZzZzimk());
				}
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0juj)
			{
				p1.LineColor = p0.z0tek(z0vek);
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0zfj)
			{
				p1.MaxScale = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0pfj)
			{
				p1.MinScale = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0yjj)
			{
				p1.Precision = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0iuj)
			{
				p1.RulerValue = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0qaj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				ScalePropertyList scalePropertyList = new ScalePropertyList();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						scalePropertyList.Add(z0tek(p0, new ScaleProperty()));
					}
				}
				if (scalePropertyList.Count > 0)
				{
					p1.Scales = scalePropertyList;
				}
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzfuj p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, ((z0ZzZzhuj)p1).z0yek());
		if (p1.z0eek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0oek, p1.z0eek());
		}
		if (p1.z0rek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0yqj, p1.z0rek());
		}
		if (((z0ZzZzhuj)p1).z0pek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0qej);
			z0tek(p0, ((z0ZzZzhuj)p1).z0pek());
			p0.z0uek();
		}
		if (!p1.z0xkk())
		{
			p0.z0rek(z0ZzZzfhh.z0hnj, p1.z0xkk());
		}
		if (((z0ZzZzhuj)p1).z0eek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((z0ZzZzhuj)p1).z0eek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.z0pek());
		if (p1.z0oek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0gtk, p1.z0oek());
		}
		if (!p1.z0rek_jiejie20260327142557())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0rek_jiejie20260327142557());
		}
		if (p1.z0mek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0nnj, p1.z0mek());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzluj p1)
	{
		if (p1.z0eek())
		{
			p0.z0rek(z0ZzZzfhh.z0uxk, p1.z0eek());
		}
		if (!p1.z0nek())
		{
			p0.z0rek(z0ZzZzfhh.z0dhj, p1.z0nek());
		}
		if (p1.z0bek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0quk);
			z0tek(p0, p1.z0bek());
			p0.z0uek();
		}
		if (p1.z0rek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0xtk);
			z0tek(p0, p1.z0rek());
			p0.z0uek();
		}
		if (!p1.z0cek())
		{
			p0.z0rek(z0ZzZzfhh.z0rck, p1.z0cek());
		}
		z0ZzZzguj z0ZzZzguj2 = p1.z0djk();
		if (z0ZzZzguj2 != null && z0ZzZzguj2.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0tek(p0, z0ZzZzguj2);
			p0.z0yek();
		}
		if (((z0ZzZzeuj)p1).z0eek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0oek, ((z0ZzZzeuj)p1).z0eek());
		}
		p0.z0rek(z0ZzZzfhh.z0coj, ((z0ZzZzhuj)p1).z0yek());
		if (((z0ZzZzeuj)p1).z0rek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0yqj, ((z0ZzZzeuj)p1).z0rek());
		}
		if (((z0ZzZzhuj)p1).z0pek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0qej);
			z0tek(p0, ((z0ZzZzhuj)p1).z0pek());
			p0.z0uek();
		}
		if (!p1.z0xkk())
		{
			p0.z0rek(z0ZzZzfhh.z0hnj, p1.z0xkk());
		}
		if (((z0ZzZzhuj)p1).z0eek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((z0ZzZzhuj)p1).z0eek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, ((z0ZzZzeuj)p1).z0pek());
		if (p1.z0uek().ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0oyj_jiejie20260327142557, p1.z0uek());
		}
		if (((z0ZzZzeuj)p1).z0oek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0gtk, ((z0ZzZzeuj)p1).z0oek());
		}
		if (!p1.z0rek_jiejie20260327142557())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0rek_jiejie20260327142557());
		}
		if (((z0ZzZzeuj)p1).z0mek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0nnj, ((z0ZzZzeuj)p1).z0mek());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextDocumentHeaderForFirstPageElement p1)
	{
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (XTextElementList.z0pek(p1.z0be()))
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0yek(p0, p1.z0be());
			p0.z0yek();
		}
		if (p1.AcceptChildElementTypes2 != ElementType.All)
		{
			p0.z0rek(z0ZzZzfhh.z0iwj, zzz.z0ZzZzcyk<ElementType>.z0rek(p1.AcceptChildElementTypes2), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0dt())
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.z0dt());
		}
		if (p1.z0gt())
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.z0gt());
		}
		if (p1.ContentLock != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zpj);
			z0tek(p0, p1.ContentLock);
			p0.z0uek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0ypj, p1.ContentReadonlyExpression);
		if (p1.CopySource != null)
		{
			p0.z0yek(z0ZzZzfhh.z0zrj);
			z0tek(p0, p1.CopySource);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.z0ht());
		p0.z0rek(z0ZzZzfhh.z0vzk, ((XTextContainerElement)p1).z0nrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (p1.EnablePermission != DCBooleanValue.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0fdj, z0ZzZzfhh.z0eek(p1.EnablePermission), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0oij, p1.EnableValueValidate);
		if (p1.HiddenPrintWhenEmpty)
		{
			p0.z0rek(z0ZzZzfhh.z0yzk, p1.HiddenPrintWhenEmpty);
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		p0.z0rek(z0ZzZzfhh.z0krk, p1.LimitedInputChars);
		if (p1.MaxInputLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0tkj, p1.MaxInputLength);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0bck, p1.PrintVisibilityExpression);
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.SpecifyFixedLineHeight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0swj, p1.SpecifyFixedLineHeight);
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.ValidateStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0dwj);
			z0tek(p0, p1.ValidateStyle);
			p0.z0uek();
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0gtj, p1.VisibleExpression);
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextPieElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0ypk, p1.DataFieldNameForFillColorString);
		p0.z0rek(z0ZzZzfhh.z0sbk, p1.DataFieldNameForGroupName);
		p0.z0rek(z0ZzZzfhh.z0hij, p1.DataFieldNameForLink);
		p0.z0rek(z0ZzZzfhh.z0tyk, p1.DataFieldNameForSeriesName);
		p0.z0rek(z0ZzZzfhh.z0iyj, p1.DataFieldNameForText);
		p0.z0rek(z0ZzZzfhh.z0dkj_jiejie20260327142557, p1.DataFieldNameForTipText);
		p0.z0rek(z0ZzZzfhh.z0duj, p1.DataFieldNameForValue);
		if (p1.DataItems != null)
		{
			DCPieDataItemList dataItems = p1.DataItems;
			int count = dataItems.Count;
			if (count > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0gmj);
				p0.z0iek();
				for (int i = 0; i < count; i++)
				{
					p0.z0tek();
					z0tek(p0, dataItems[i]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		p0.z0rek(z0ZzZzfhh.z0pzk, p1.DataSourceName);
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		if (p1.PieDocumentStyle != null)
		{
			p0.z0yek(z0ZzZzfhh.z0emk);
			z0tek(p0, p1.PieDocumentStyle);
			p0.z0uek();
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static CopySourceInfo z0tek(z0ZzZzxjh p0, CopySourceInfo p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0rnk)
				{
					p1.z0eek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0krj)
				{
					p1.z0tek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0luj)
				{
					p1.z0rek(p0.z0bek());
				}
				else if (text == z0ZzZzfhh.z0ulj)
				{
					p1.z0eek(p0.z0vek());
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzolh p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, p1.z0pek());
		}
	}

	internal static XTextNewMedicalExpressionElement z0tek(z0ZzZzxjh p0, XTextNewMedicalExpressionElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0guk)
			{
				p1.ExpressionStyle = (DCMedicalExpressionStyle)p0.z0tek(z0ZzZzfhh.z0saj);
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.Text = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0qok)
			{
				p1.VAlign = (VerticalAlignStyle)p0.z0tek(z0ZzZzfhh.z0jnk);
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dbj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				MedicalExpressionValueList medicalExpressionValueList = new MedicalExpressionValueList();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						medicalExpressionValueList.Add(z0tek(p0, new z0ZzZzjuk()));
					}
				}
				if (medicalExpressionValueList.Count > 0)
				{
					p1.Values = medicalExpressionValueList;
				}
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzevj z0tek(z0ZzZzxjh p0, z0ZzZzevj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0srj)
				{
					p1.DataSource = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0soj)
				{
					p1.BindingPath = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0sij)
				{
					p1.z0yek(p0.z0vek());
				}
				else if (text == z0ZzZzfhh.z0rfj)
				{
					p1.BindingPathForText = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0wyj)
				{
					p1.z0tek(p0.z0vek());
				}
				else if (text == z0ZzZzfhh.z0wwj)
				{
					p1.ProcessState = (DCProcessStates)p0.z0tek(z0ZzZzfhh.z0kxk);
				}
				else if (text == z0ZzZzfhh.z0zck)
				{
					p1.z0eek(p0.z0vek());
				}
				else if (text == z0ZzZzfhh.z0wyk)
				{
					p1.WriteTextBindingPath = p0.z0bek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static XTextRadioBoxElement z0tek(z0ZzZzxjh p0, XTextRadioBoxElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0knk)
			{
				p1.Checked = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wcj)
			{
				p1.Caption = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0xaj)
			{
				p1.VisualStyle = (CheckBoxVisualStyle)p0.z0tek(z0ZzZzfhh.z0tdj);
			}
			else if (text == z0ZzZzfhh.z0wvj)
			{
				p1.CheckedValue = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0srk)
			{
				p1.AutoHeightForMultiline = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.BringoutToSave = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.CanBeReferenced = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ztk)
			{
				p1.CaptionAlign = (StringAlignment)p0.z0tek(z0ZzZzfhh.z0arj);
			}
			else if (text == z0ZzZzfhh.z0emj)
			{
				p1.CaptionFlowLayout = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0lmk)
			{
				p1.CheckAlignLeft = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0uuk)
			{
				p1.CheckBoxVisible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0rpk)
			{
				p1.CheckboxVisibility = zzz.z0ZzZzcyk<RenderVisibility>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0ixk)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				z0ZzZzuhh z0ZzZzuhh2 = new z0ZzZzuhh();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						z0ZzZzuhh2.Add(z0tek(p0, new z0ZzZzyhh()));
					}
				}
				if (z0ZzZzuhh2.Count > 0)
				{
					p1.CheckedUserHistories = z0ZzZzuhh2;
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.DataName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0kuk)
			{
				p1.DefaultCheckedForValueBinding = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0doj)
			{
				p1.EnableHighlight = (EnableState)p0.z0tek(z0ZzZzfhh.z0pbj);
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0jfj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzukh()));
				}
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					((XTextObjectElement)p1).z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0raj)
			{
				p1.Multiline = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0vej)
			{
				p1.PrintTextForChecked = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0puk)
			{
				p1.PrintTextForUnChecked = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0pij)
			{
				p1.PrintVisibilityWhenUnchecked = (PrintVisibilityModeWhenUnchecked)p0.z0tek(z0ZzZzfhh.z0skj);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0zck)
			{
				p1.Readonly = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ynj)
			{
				p1.Requried = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextTextElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, p1.z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.z0tek());
		if (p1.z0yek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0mij, p1.z0yek());
		}
		if (p1.z0rek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0apk, p1.z0rek());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzztk p1)
	{
		if (p1.z0pek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0wcj);
			z0tek(p0, p1.z0pek());
			p0.z0uek();
		}
		if (p1.z0iek() != ColorThemeType.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0ozk, z0ZzZzfhh.z0eek(p1.z0iek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0mek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0iuk);
			z0tek(p0, p1.z0mek());
			p0.z0uek();
		}
		if (p1.z0xek() != DrawingStyle.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0wgj, z0ZzZzfhh.z0eek(p1.z0xek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.z0oek())
		{
			p0.z0rek(z0ZzZzfhh.z0icj, p1.z0oek());
		}
		if (p1.z0bek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0ayj, p1.z0bek());
		}
		if (p1.z0zek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0cxk);
			z0tek(p0, p1.z0zek());
			p0.z0uek();
		}
		if (p1.z0uek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0poj);
			z0tek(p0, p1.z0uek());
			p0.z0uek();
		}
		if (p1.z0vek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0hmk);
			z0tek(p0, p1.z0vek());
			p0.z0uek();
		}
		if (p1.z0lrk() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0ufj, p1.z0lrk());
		}
		if (p1.z0yek() != 0.78)
		{
			p0.z0rek(z0ZzZzfhh.z0qyk, p1.z0yek());
		}
		if (p1.z0tek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dmj, p1.z0tek());
		}
		if (p1.z0rek() != 30)
		{
			p0.z0rek(z0ZzZzfhh.z0zrk, p1.z0rek());
		}
	}

	internal static DCChartDataItem z0tek(z0ZzZzxjh p0, DCChartDataItem p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0nik)
				{
					p1.ChartStyle = (ChartStyleConsts)p0.z0tek(z0ZzZzfhh.z0fkj);
				}
				else if (text == z0ZzZzfhh.z0laj)
				{
					p1.Color = p0.z0tek(z0vek);
				}
				else if (text == z0ZzZzfhh.z0tfj)
				{
					p1.GroupName = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0aoj)
				{
					p1.Link = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0cyk)
				{
					p1.SeriesName = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0ouk)
				{
					p1.SymbolSize = p0.z0pek();
				}
				else if (text == z0ZzZzfhh.z0ifj)
				{
					p1.SymbolType = (ShapeTypes)p0.z0tek(z0ZzZzfhh.z0xkj);
				}
				else if (text == z0ZzZzfhh.z0tik)
				{
					p1.Text = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0prj)
				{
					p1.TipText = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0jsj)
				{
					p1.Value = p0.z0oek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextImageElement p1)
	{
		if (p1.z0hrk() != null)
		{
			z0ZzZzdzj z0ZzZzdzj2 = p1.z0hrk();
			int count = z0ZzZzdzj2.Count;
			if (count > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0iqj);
				p0.z0iek();
				for (int i = 0; i < count; i++)
				{
					p0.z0tek();
					z0tek(p0, z0ZzZzdzj2[i]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		if (p1.z0brk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0gej_jiejie20260327142557);
			z0tek(p0, p1.z0brk());
			p0.z0uek();
		}
		if (!p1.KeepWidthHeightRate)
		{
			p0.z0rek(z0ZzZzfhh.z0qmk, p1.KeepWidthHeightRate);
		}
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		if (p1.z0rek().ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0eij, p1.z0rek());
		}
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0jrk())
		{
			p0.z0rek(z0ZzZzfhh.z0ivj, p1.z0jrk());
		}
		p0.z0rek(z0ZzZzfhh.z0qsj, p1.z0tek());
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0vnj, p1.z0yrk());
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.EnableEditImageAdditionShape)
		{
			p0.z0rek(z0ZzZzfhh.z0mgj, p1.EnableEditImageAdditionShape);
		}
		if (p1.z0mrk())
		{
			p0.z0rek(z0ZzZzfhh.z0wbj, p1.z0mrk());
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		if (p1.z0frk() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0lpj);
			z0tek(p0, p1.z0frk());
			p0.z0uek();
		}
		if (p1.z0iek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0hvj, p1.z0iek());
		}
		if (((XTextObjectElement)p1).z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, ((XTextObjectElement)p1).z0iek());
			p0.z0uek();
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (!p1.SaveContentInFile)
		{
			p0.z0rek(z0ZzZzfhh.z0taj, p1.SaveContentInFile);
		}
		if (!p1.SmoothZoom)
		{
			p0.z0rek(z0ZzZzfhh.z0tnj, p1.SmoothZoom);
		}
		p0.z0rek(z0ZzZzfhh.z0drk, p1.z0mek());
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		p0.z0rek(z0ZzZzfhh.z0zoj, p1.z0vrk());
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		if (p1.VAlign != VerticalAlignStyle.Bottom)
		{
			p0.z0rek(z0ZzZzfhh.z0qok, z0ZzZzfhh.z0eek(p1.VAlign), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (p1.z0cek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0jok, p1.z0cek());
		}
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzzyj p1)
	{
		if (p1.Default != null)
		{
			p0.z0yek(z0ZzZzfhh.z0sok);
			z0tek(p0, p1.Default);
			p0.z0uek();
		}
		if (p1.Styles == null)
		{
			return;
		}
		z0ZzZzzok styles = p1.Styles;
		int count = styles.Count;
		if (count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0djj);
			p0.z0iek();
			for (int i = 0; i < count; i++)
			{
				p0.z0tek();
				z0tek(p0, styles[i]);
				p0.z0mek();
			}
			p0.z0nek();
			p0.z0yek();
		}
	}

	internal static XTextTableCellElement z0tek(z0ZzZzxjh p0, XTextTableCellElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0lkj)
			{
				int p2 = p0.z0pek();
				XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
				xTextParagraphFlagElement.z0oek(p2);
				p1.z0be().Add(xTextParagraphFlagElement);
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				((XTextElement)p1).z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0xvk)
			{
				p1.ColSpan = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0kaj)
			{
				p1.z0uek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0ouj)
			{
				p1.RowSpan = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0jaj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.GridLine = z0tek(p0, new z0ZzZzzej());
				}
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0yuj)
			{
				p1.z0tek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0ltj)
			{
				p1.z0yek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0wbk)
			{
				p1.AutoFixFontSizeMode = (ContentAutoFixFontSizeMode)p0.z0tek(z0ZzZzfhh.z0nqj);
			}
			else if (text == z0ZzZzfhh.z0qnk)
			{
				p1.SlantSplitLineStyle = (RectangleSlantSplitStyle)p0.z0tek(z0ZzZzfhh.z0irk);
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0hwj)
			{
				p1.BorderPrintedWhenJumpPrint = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0pqj)
			{
				p1.CloneType = (TableRowCloneType)p0.z0tek(z0ZzZzfhh.z0guj);
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0avk)
			{
				p1.MirrorViewForCrossPage = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0tcj)
			{
				p1.MoveFocusHotKey = zzz.z0ZzZzcyk<MoveFocusHotKeys>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0swj)
			{
				p1.SpecifyFixedLineHeight = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dsj)
			{
				p1.z0tek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0yek(z0ZzZzzjh p0, XTextElementList p1)
	{
		if (p1.Count <= 0)
		{
			return;
		}
		z0gck z0gck = null;
		p0.z0iek();
		int count = p1.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = p1[i];
			if (xTextElement is XTextCharElement)
			{
				XTextCharElement xTextCharElement = (XTextCharElement)xTextElement;
				if (z0gck == null)
				{
					z0gck = new z0gck();
					z0gck.z0eek(xTextCharElement);
				}
				else if (z0gck.z0rek == xTextCharElement.z0buk)
				{
					z0gck.z0eek(xTextCharElement.z0bek);
					if (XTextCharElement.z0tek((int)xTextCharElement.z0bek))
					{
						z0gck.z0eek((char)xTextCharElement.z0iek());
					}
				}
				else
				{
					z0gck.z0eek(p0);
					z0gck.z0eek(xTextCharElement);
				}
				continue;
			}
			z0gck?.z0eek(p0);
			if (xTextElement is XTextParagraphFlagElement)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)xTextElement;
				p0.z0rek(z0ZzZzfhh.z0txk);
				if (xTextParagraphFlagElement.z0buk >= 0)
				{
					p0.z0rek(z0ZzZzfhh.z0uzk, xTextParagraphFlagElement.z0buk);
				}
				if (xTextParagraphFlagElement.z0vek())
				{
					p0.z0rek(z0ZzZzfhh.z0cvk, xTextParagraphFlagElement.z0vek());
				}
				p0.z0mek();
			}
			else if (xTextElement is XTextTableCellElement)
			{
				p0.z0rek(z0ZzZzfhh.z0bvj);
				z0tek(p0, (XTextTableCellElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextInputFieldElement)
			{
				p0.z0rek(z0ZzZzfhh.z0ylj);
				z0tek(p0, (XTextInputFieldElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextTableRowElement)
			{
				p0.z0rek(z0ZzZzfhh.z0czk);
				z0tek(p0, (XTextTableRowElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextTableColumnElement)
			{
				p0.z0rek(z0ZzZzfhh.z0vaj);
				z0tek(p0, (XTextTableColumnElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextImageElement)
			{
				p0.z0rek(z0ZzZzfhh.z0lpj);
				z0tek(p0, (XTextImageElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextCheckBoxElement)
			{
				p0.z0rek(z0ZzZzfhh.z0wqj);
				z0tek(p0, (XTextCheckBoxElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextRadioBoxElement)
			{
				p0.z0rek(z0ZzZzfhh.z0ocj);
				z0tek(p0, (XTextRadioBoxElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextLabelElement)
			{
				p0.z0rek(z0ZzZzfhh.z0fck);
				z0tek(p0, (XTextLabelElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextTableElement)
			{
				p0.z0rek(z0ZzZzfhh.z0nnk);
				z0tek(p0, (XTextTableElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextMedicalExpressionFieldElement)
			{
				p0.z0rek(z0ZzZzfhh.z0zlj);
				z0tek(p0, (XTextMedicalExpressionFieldElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextDocument)
			{
				p0.z0rek(z0ZzZzfhh.z0daj);
				z0tek(p0, (XTextDocument)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextDocumentBodyElement)
			{
				p0.z0rek(z0ZzZzfhh.z0prk);
				z0tek(p0, (XTextDocumentBodyElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextDocumentFooterElement)
			{
				p0.z0rek(z0ZzZzfhh.z0uvk);
				z0tek(p0, (XTextDocumentFooterElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextDocumentFooterForFirstPageElement)
			{
				p0.z0rek(z0ZzZzfhh.z0ubj);
				z0tek(p0, (XTextDocumentFooterForFirstPageElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextDocumentHeaderElement)
			{
				p0.z0rek(z0ZzZzfhh.z0otk);
				z0tek(p0, (XTextDocumentHeaderElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextDocumentHeaderForFirstPageElement)
			{
				p0.z0rek(z0ZzZzfhh.z0lck_jiejie20260327142557);
				z0tek(p0, (XTextDocumentHeaderForFirstPageElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextPageInfoElement)
			{
				p0.z0rek(z0ZzZzfhh.z0zzk);
				z0tek(p0, (XTextPageInfoElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextSubDocumentElement)
			{
				p0.z0rek(z0ZzZzfhh.z0jrj);
				z0tek(p0, (XTextSubDocumentElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextSectionElement)
			{
				p0.z0rek(z0ZzZzfhh.z0gbk);
				z0tek(p0, (XTextSectionElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextPageBreakElement)
			{
				p0.z0rek(z0ZzZzfhh.z0pmk);
				z0tek(p0, (XTextPageBreakElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextLineBreakElement)
			{
				p0.z0rek(z0ZzZzfhh.z0snk);
				z0tek(p0, (XTextLineBreakElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextHorizontalLineElement)
			{
				p0.z0rek(z0ZzZzfhh.z0alj);
				z0tek(p0, (XTextHorizontalLineElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextDirectoryFieldElement)
			{
				p0.z0rek(z0ZzZzfhh.z0cyj);
				z0tek(p0, (XTextDirectoryFieldElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextBarcodeFieldElement)
			{
				p0.z0rek(z0ZzZzfhh.z0kpk);
				z0tek(p0, (XTextBarcodeFieldElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is z0ZzZzilh)
			{
				p0.z0rek(z0ZzZzfhh.z0qgj);
				z0tek(p0, (z0ZzZzilh)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextBlankLineElement)
			{
				p0.z0rek(z0ZzZzfhh.z0eyk);
				z0tek(p0, (XTextBlankLineElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is z0ZzZzolh)
			{
				p0.z0rek(z0ZzZzfhh.z0qwj);
				z0tek(p0, (z0ZzZzolh)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextButtonElement)
			{
				p0.z0rek(z0ZzZzfhh.z0myk);
				z0tek(p0, (XTextButtonElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextChartElement)
			{
				p0.z0rek(z0ZzZzfhh.z0zbk);
				z0tek(p0, (XTextChartElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextControlHostElement)
			{
				p0.z0rek(z0ZzZzfhh.z0xrk);
				z0tek(p0, (XTextControlHostElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextCustomShapeElement)
			{
				p0.z0rek(z0ZzZzfhh.z0pok);
				z0tek(p0, (XTextCustomShapeElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextMediaElement)
			{
				p0.z0rek(z0ZzZzfhh.z0bhj);
				z0tek(p0, (XTextMediaElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextNewBarcodeElement)
			{
				p0.z0rek(z0ZzZzfhh.z0vwj);
				z0tek(p0, (XTextNewBarcodeElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextNewMedicalExpressionElement)
			{
				p0.z0rek(z0ZzZzfhh.z0ktj);
				z0tek(p0, (XTextNewMedicalExpressionElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextParagraphElement)
			{
				p0.z0rek(z0ZzZzfhh.z0udj);
				z0tek(p0, (XTextParagraphElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextPieElement)
			{
				p0.z0rek(z0ZzZzfhh.z0vhj);
				z0tek(p0, (XTextPieElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is z0ZzZzjkh)
			{
				p0.z0rek(z0ZzZzfhh.z0jck);
				z0tek(p0, (z0ZzZzjkh)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextRulerElement)
			{
				p0.z0rek(z0ZzZzfhh.z0cnj);
				z0tek(p0, (XTextRulerElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextSignElement)
			{
				p0.z0rek(z0ZzZzfhh.z0pdj);
				z0tek(p0, (XTextSignElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextSignImageElement)
			{
				p0.z0rek(z0ZzZzfhh.z0lij);
				z0tek(p0, (XTextSignImageElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextStringElement)
			{
				p0.z0rek(z0ZzZzfhh.z0tij);
				z0tek(p0, (XTextStringElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextTDBarcodeElement)
			{
				p0.z0rek(z0ZzZzfhh.z0kfj);
				z0tek(p0, (XTextTDBarcodeElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is XTextTextElement)
			{
				p0.z0rek(z0ZzZzfhh.z0tik);
				z0tek(p0, (XTextTextElement)xTextElement);
				p0.z0mek();
			}
			else if (xTextElement is z0ZzZzdkh)
			{
				p0.z0rek(z0ZzZzfhh.z0vuk);
				z0tek(p0, (z0ZzZzdkh)xTextElement);
				p0.z0mek();
			}
		}
		z0gck?.z0eek(p0);
		p0.z0nek();
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzhuj p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.z0yek());
		if (p1.z0pek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0qej);
			z0tek(p0, p1.z0pek());
			p0.z0uek();
		}
		if (p1.z0eek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, p1.z0eek());
		}
		if (!p1.z0rek_jiejie20260327142557())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0rek_jiejie20260327142557());
		}
	}

	internal static PropertyExpressionInfoList z0tek(z0ZzZzxjh p0, PropertyExpressionInfoList p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
		{
			if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
			{
				p1.Add(z0tek(p0, new PropertyExpressionInfo()));
			}
		}
		return p1;
	}

	internal static XTextBarcodeFieldElement z0tek(z0ZzZzxjh p0, XTextBarcodeFieldElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0gdj)
			{
				p1.AcceptTab = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0otj)
			{
				p1.Alignment = (StringAlignment)p0.z0tek(z0ZzZzfhh.z0arj);
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0zmk)
			{
				p1.AutoExitEditMode = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ltj)
			{
				p1.z0tek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0hoj)
			{
				p1.BackgroundText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0lbj)
			{
				p1.BackgroundTextColor = p0.z0tek(z0vek);
			}
			else if (text == z0ZzZzfhh.z0cgj)
			{
				((XTextFieldElementBase)p1).z0eek((DCBooleanValueHasDefault)p0.z0tek(z0ZzZzfhh.z0ndj));
			}
			else if (text == z0ZzZzfhh.z0ucj)
			{
				p1.BarcodeStyle = (z0ZzZzrrk)p0.z0tek(z0ZzZzfhh.z0cvj);
			}
			else if (text == z0ZzZzfhh.z0lhj)
			{
				p1.BorderElementColor = p0.z0tek(z0srk);
			}
			else if (text == z0ZzZzfhh.z0tlj)
			{
				p1.z0eek((z0ZzZzscj)p0.z0tek(z0ZzZzfhh.z0haj));
			}
			else if (text == z0ZzZzfhh.z0tvj)
			{
				p1.BorderVisible = (DCVisibleState)p0.z0tek(z0ZzZzfhh.z0ppk);
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0gqj)
			{
				p1.DefaultEventExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0jyj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.DisplayFormat = z0tek(p0, new z0ZzZzsok());
				}
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0doj)
			{
				p1.EnableHighlight = (EnableState)p0.z0tek(z0ZzZzfhh.z0pbj);
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0phj)
			{
				p1.EndBorderText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gok)
			{
				p1.EndingLineBreak = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0jfj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.EventExpressions = z0tek(p0, new z0ZzZzukh());
				}
			}
			else if (text == z0ZzZzfhh.z0syj)
			{
				p1.z0eek((DCFastInputMode)p0.z0tek(z0ZzZzfhh.z0ynk));
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0pgj)
			{
				p1.InnerValue = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zvj)
			{
				p1.LabelText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zij)
			{
				p1.LableUnitTextBold = (DCBooleanValueHasDefault)p0.z0tek(z0ZzZzfhh.z0ndj);
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0yuk)
			{
				p1.MinBarWidth = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0tcj)
			{
				p1.MoveFocusHotKey = zzz.z0ZzZzcyk<MoveFocusHotKeys>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0yyj)
			{
				p1.z0eek((DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk));
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0yij)
			{
				p1.ShowText = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0dij)
			{
				p1.SpecifyWidth = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0njj)
			{
				p1.StartBorderText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0blj)
			{
				p1.TabIndex = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0dsj)
			{
				p1.TabStop = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0opj)
			{
				p1.TextAlignment = (StringAlignment)p0.z0tek(z0ZzZzfhh.z0arj);
			}
			else if (text == z0ZzZzfhh.z0ojj)
			{
				p1.TextColor = p0.z0tek(z0vek);
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0ack)
			{
				p1.UnitText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0vrj)
			{
				p1.UserEditable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cmj)
			{
				p1.ViewEncryptType = (ContentViewEncryptType)p0.z0tek(z0ZzZzfhh.z0hpk);
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzquj p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, ((z0ZzZzhuj)p1).z0yek());
		if (p1.z0pek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0qej);
			z0tek(p0, p1.z0pek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0uwj, p1.z0rek());
		if (((z0ZzZzhuj)p1).z0eek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((z0ZzZzhuj)p1).z0eek());
		}
		if (!p1.z0rek_jiejie20260327142557())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0rek_jiejie20260327142557());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, DCChartDataItem p1)
	{
		if (p1.ChartStyle != ChartStyleConsts.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0nik, z0ZzZzfhh.z0eek(p1.ChartStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.Color.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0laj, p1.Color);
		}
		p0.z0rek(z0ZzZzfhh.z0tfj, p1.GroupName);
		p0.z0rek(z0ZzZzfhh.z0aoj, p1.Link);
		p0.z0rek(z0ZzZzfhh.z0cyk, p1.SeriesName);
		if (p1.SymbolSize != 10)
		{
			p0.z0rek(z0ZzZzfhh.z0ouk, p1.SymbolSize);
		}
		if (p1.SymbolType != ShapeTypes.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0ifj, z0ZzZzfhh.z0eek(p1.SymbolType), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.Text);
		p0.z0rek(z0ZzZzfhh.z0prj, p1.TipText);
		if (p1.Value != 0.0)
		{
			p0.z0rek(z0ZzZzfhh.z0jsj, p1.Value);
		}
	}

	internal static XTextInputFieldElement z0tek(z0ZzZzxjh p0, XTextInputFieldElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0pgj)
			{
				p1.InnerValue = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0hoj)
			{
				p1.BackgroundText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.FieldSettings = z0tek(p0, new InputFieldSettings());
				}
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0qfj)
			{
				p1.EditorActiveMode = zzz.z0ZzZzcyk<ValueEditorActiveMode>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0doj)
			{
				p1.EnableHighlight = (EnableState)p0.z0tek(z0ZzZzfhh.z0pbj);
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dij)
			{
				p1.SpecifyWidth = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0vrj)
			{
				p1.UserEditable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0tcj)
			{
				p1.MoveFocusHotKey = zzz.z0ZzZzcyk<MoveFocusHotKeys>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0tvj)
			{
				p1.BorderVisible = (DCVisibleState)p0.z0tek(z0ZzZzfhh.z0ppk);
			}
			else if (text == z0ZzZzfhh.z0lzk)
			{
				p1.z0iek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0dsj)
			{
				p1.TabStop = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0jyj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.DisplayFormat = z0tek(p0, new z0ZzZzsok());
				}
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gqj)
			{
				p1.DefaultEventExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0lbj)
			{
				p1.BackgroundTextColor = p0.z0tek(z0vek);
			}
			else if (text == z0ZzZzfhh.z0ojj)
			{
				p1.TextColor = p0.z0tek(z0vek);
			}
			else if (text == z0ZzZzfhh.z0zvj)
			{
				p1.LabelText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dxk)
			{
				p1.z0uek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0ack)
			{
				p1.UnitText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0cmj)
			{
				p1.ViewEncryptType = (ContentViewEncryptType)p0.z0tek(z0ZzZzfhh.z0hpk);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0jfj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.EventExpressions = z0tek(p0, new z0ZzZzukh());
				}
			}
			else if (text == z0ZzZzfhh.z0phj)
			{
				p1.EndBorderText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0njj)
			{
				p1.StartBorderText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gdj)
			{
				p1.AcceptTab = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0hdj)
			{
				p1.z0eek((InputFieldAdornTextType)p0.z0tek(z0ZzZzfhh.z0iej));
			}
			else if (text == z0ZzZzfhh.z0otj)
			{
				p1.Alignment = (StringAlignment)p0.z0tek(z0ZzZzfhh.z0arj);
			}
			else if (text == z0ZzZzfhh.z0ltj)
			{
				((XTextInputFieldElementBase)p1).z0tek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0nxk)
			{
				p1.z0yek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0cgj)
			{
				((XTextFieldElementBase)p1).z0eek((DCBooleanValueHasDefault)p0.z0tek(z0ZzZzfhh.z0ndj));
			}
			else if (text == z0ZzZzfhh.z0lhj)
			{
				p1.BorderElementColor = p0.z0tek(z0srk);
			}
			else if (text == z0ZzZzfhh.z0tlj)
			{
				p1.z0eek((z0ZzZzscj)p0.z0tek(z0ZzZzfhh.z0haj));
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gxk)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0gpk)
			{
				p1.z0yek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0evj)
			{
				p1.z0oek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gok)
			{
				p1.EndingLineBreak = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0syj)
			{
				p1.z0eek((DCFastInputMode)p0.z0tek(z0ZzZzfhh.z0ynk));
			}
			else if (text == z0ZzZzfhh.z0gvk)
			{
				p1.z0eek((FormButtonStyle)p0.z0tek(z0ZzZzfhh.z0vik));
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0zij)
			{
				p1.LableUnitTextBold = (DCBooleanValueHasDefault)p0.z0tek(z0ZzZzfhh.z0ndj);
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tek)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzfvj()));
				}
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0yyj)
			{
				((XTextInputFieldElementBase)p1).z0eek((DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk));
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0ivk)
			{
				p1.z0eek((DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk));
			}
			else if (text == z0ZzZzfhh.z0ekj)
			{
				p1.z0rek((DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk));
			}
			else if (text == z0ZzZzfhh.z0blj)
			{
				p1.TabIndex = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else if (text == "SensitiveData")
			{
				p1.z0rek(p0.z0vek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextDocumentHeaderForFirstPageElement z0tek(z0ZzZzxjh p0, XTextDocumentHeaderForFirstPageElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0swj)
			{
				p1.SpecifyFixedLineHeight = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextDirectoryFieldElement z0tek(z0ZzZzxjh p0, XTextDirectoryFieldElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0tvj)
			{
				p1.BorderVisible = (DCVisibleState)p0.z0tek(z0ZzZzfhh.z0ppk);
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0ukj_jiejie20260327142557)
			{
				p1.DisplayLevel = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0doj)
			{
				p1.EnableHighlight = (EnableState)p0.z0tek(z0ZzZzfhh.z0pbj);
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0gdj)
			{
				p1.AcceptTab = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0otj)
			{
				p1.Alignment = (StringAlignment)p0.z0tek(z0ZzZzfhh.z0arj);
			}
			else if (text == z0ZzZzfhh.z0ltj)
			{
				p1.z0tek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0hoj)
			{
				p1.BackgroundText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0lbj)
			{
				p1.BackgroundTextColor = p0.z0tek(z0vek);
			}
			else if (text == z0ZzZzfhh.z0cgj)
			{
				((XTextFieldElementBase)p1).z0eek((DCBooleanValueHasDefault)p0.z0tek(z0ZzZzfhh.z0ndj));
			}
			else if (text == z0ZzZzfhh.z0lhj)
			{
				p1.BorderElementColor = p0.z0tek(z0srk);
			}
			else if (text == z0ZzZzfhh.z0tlj)
			{
				p1.z0eek((z0ZzZzscj)p0.z0tek(z0ZzZzfhh.z0haj));
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zrj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.CopySource = z0tek(p0, new CopySourceInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0gqj)
			{
				p1.DefaultEventExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				p1.z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0jyj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.DisplayFormat = z0tek(p0, new z0ZzZzsok());
				}
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0phj)
			{
				p1.EndBorderText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gok)
			{
				p1.EndingLineBreak = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0jfj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.EventExpressions = z0tek(p0, new z0ZzZzukh());
				}
			}
			else if (text == z0ZzZzfhh.z0syj)
			{
				p1.z0eek((DCFastInputMode)p0.z0tek(z0ZzZzfhh.z0ynk));
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0pgj)
			{
				p1.InnerValue = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zvj)
			{
				p1.LabelText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0zij)
			{
				p1.LableUnitTextBold = (DCBooleanValueHasDefault)p0.z0tek(z0ZzZzfhh.z0ndj);
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0tcj)
			{
				p1.MoveFocusHotKey = zzz.z0ZzZzcyk<MoveFocusHotKeys>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0yyj)
			{
				p1.z0eek((DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk));
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0abk)
			{
				p1.ShowPageIndex = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0dij)
			{
				p1.SpecifyWidth = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0njj)
			{
				p1.StartBorderText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0blj)
			{
				p1.TabIndex = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0dsj)
			{
				p1.TabStop = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ojj)
			{
				p1.TextColor = p0.z0tek(z0vek);
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0ack)
			{
				p1.UnitText = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0vrj)
			{
				p1.UserEditable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cmj)
			{
				p1.ViewEncryptType = (ContentViewEncryptType)p0.z0tek(z0ZzZzfhh.z0hpk);
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzcok p1)
	{
		if (p1.BorderBottom)
		{
			p0.z0rek(z0ZzZzfhh.z0jvk, p1.BorderBottom);
		}
		if (p1.BorderLeft)
		{
			p0.z0rek(z0ZzZzfhh.z0wmj, p1.BorderLeft);
		}
		if (p1.BorderRight)
		{
			p0.z0rek(z0ZzZzfhh.z0lej, p1.BorderRight);
		}
		if (p1.BorderTop)
		{
			p0.z0rek(z0ZzZzfhh.z0vgj, p1.BorderTop);
		}
		if (p1.BorderWidth != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0etj, p1.BorderWidth);
		}
		p0.z0rek(z0ZzZzfhh.z0asj, p1.FontName);
		if (p1.FontSize != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0pck, p1.FontSize);
		}
		if (p1.Align != DocumentContentAlignment.Left)
		{
			p0.z0rek(z0ZzZzfhh.z0gnj, z0ZzZzfhh.z0eek(p1.Align), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.VerticalAlign != VerticalAlignStyle.Top)
		{
			p0.z0rek(z0ZzZzfhh.z0dik, z0ZzZzfhh.z0eek(p1.VerticalAlign), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BackgroundColor.ToArgb() != 16777215)
		{
			p0.z0rek(z0ZzZzfhh.z0okj, p1.BackgroundColor);
		}
		if (p1.BackgroundColor2.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0crj, p1.BackgroundColor2);
		}
		if (p1.Bold)
		{
			p0.z0rek(z0ZzZzfhh.z0vyk, p1.Bold);
		}
		if (p1.BorderBottomColor.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0azk, p1.BorderBottomColor);
		}
		if (p1.BorderLeftColor.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0nyj, p1.BorderLeftColor);
		}
		if (p1.BorderRightColor.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0uik, p1.BorderRightColor);
		}
		if (p1.BorderSpacing != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0ink, p1.BorderSpacing);
		}
		if (p1.BorderStyle != DashStyle.Solid)
		{
			p0.z0rek(z0ZzZzfhh.z0nck, z0ZzZzfhh.z0eek(p1.BorderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.BorderTopColor.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0uyk, p1.BorderTopColor);
		}
		if (p1.CharacterCircle != CharacterCircleStyles.None)
		{
			p0.z0rek(z0ZzZzfhh.z0wdj, z0ZzZzfhh.z0eek(p1.CharacterCircle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.Color.ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0laj, p1.Color);
		}
		if (p1.EmphasisMark)
		{
			p0.z0rek(z0ZzZzfhh.z0fqj, p1.EmphasisMark);
		}
		if (p1.FirstLineIndent != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hbj, p1.FirstLineIndent);
		}
		if (p1.FixedSpacing)
		{
			p0.z0rek(z0ZzZzfhh.z0lvk, p1.FixedSpacing);
		}
		if (p1.Index != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0xxk, p1.Index);
		}
		if (p1.Italic)
		{
			p0.z0rek(z0ZzZzfhh.z0wtk, p1.Italic);
		}
		if (p1.LayoutAlign != ContentLayoutAlign.EmbedInText)
		{
			p0.z0rek(z0ZzZzfhh.z0dqj, z0ZzZzfhh.z0eek(p1.LayoutAlign), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.LeftIndent != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0vpj, p1.LeftIndent);
		}
		if (p1.LetterSpacing != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0qpk, p1.LetterSpacing);
		}
		if (p1.LineSpacing != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0nmj, p1.LineSpacing);
		}
		if (p1.LineSpacingStyle != LineSpacingStyle.SpaceSingle)
		{
			p0.z0rek(z0ZzZzfhh.z0pvj, z0ZzZzfhh.z0eek(p1.LineSpacingStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.MarginBottom != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0lpk, p1.MarginBottom);
		}
		if (p1.MarginLeft != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0oik, p1.MarginLeft);
		}
		if (p1.MarginRight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0nej, p1.MarginRight);
		}
		if (p1.MarginTop != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0sck, p1.MarginTop);
		}
		if (p1.Multiline)
		{
			p0.z0rek(z0ZzZzfhh.z0raj, p1.Multiline);
		}
		if (p1.PaddingBottom != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0gjj, p1.PaddingBottom);
		}
		if (p1.PaddingLeft != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0uaj, p1.PaddingLeft);
		}
		if (p1.PaddingRight != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0cpj, p1.PaddingRight);
		}
		if (p1.PaddingTop != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0esj, p1.PaddingTop);
		}
		if (p1.ParagraphListStyle != ParagraphListStyle.None)
		{
			p0.z0rek(z0ZzZzfhh.z0ijj, zzz.z0ZzZzcyk<ParagraphListStyle>.z0rek(p1.ParagraphListStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.ParagraphMultiLevel)
		{
			p0.z0rek(z0ZzZzfhh.z0olj, p1.ParagraphMultiLevel);
		}
		if (p1.ParagraphOutlineLevel != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0bqj_jiejie20260327142557, p1.ParagraphOutlineLevel);
		}
		if (p1.RTFLineSpacing != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hvk, p1.RTFLineSpacing);
		}
		if (p1.RightToLeft)
		{
			p0.z0rek(z0ZzZzfhh.z0dlj, p1.RightToLeft);
		}
		if (p1.SpacingAfterParagraph != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0kbj_jiejie20260327142557, p1.SpacingAfterParagraph);
		}
		if (p1.SpacingBeforeParagraph != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0idj, p1.SpacingBeforeParagraph);
		}
		if (p1.Strikeout)
		{
			p0.z0rek(z0ZzZzfhh.z0tbj, p1.Strikeout);
		}
		if (p1.Subscript)
		{
			p0.z0rek(z0ZzZzfhh.z0rmk, p1.Subscript);
		}
		if (p1.Superscript)
		{
			p0.z0rek(z0ZzZzfhh.z0svk, p1.Superscript);
		}
		if (p1.Underline)
		{
			p0.z0rek(z0ZzZzfhh.z0wok, p1.Underline);
		}
		p0.z0rek(z0ZzZzfhh.z0jmk, p1.UnderlineColor);
		if (p1.UnderlineStyle != TextUnderlineStyle.Single)
		{
			p0.z0rek(z0ZzZzfhh.z0joj, z0ZzZzfhh.z0eek(p1.UnderlineStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.Visibility != RenderVisibility.All)
		{
			p0.z0rek(z0ZzZzfhh.z0lrj, zzz.z0ZzZzcyk<RenderVisibility>.z0rek(p1.Visibility), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.VisibleInDirectory)
		{
			p0.z0rek(z0ZzZzfhh.z0ptj, p1.VisibleInDirectory);
		}
	}

	internal static XTextCheckBoxElement z0tek(z0ZzZzxjh p0, XTextCheckBoxElement p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				p1.z0oek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0wcj)
			{
				p1.Caption = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tfj)
			{
				p1.GroupName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0ntj)
			{
				p1.Name = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0lmk)
			{
				p1.CheckAlignLeft = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0wvj)
			{
				p1.CheckedValue = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0knk)
			{
				p1.Checked = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0xaj)
			{
				p1.VisualStyle = (CheckBoxVisualStyle)p0.z0tek(z0ZzZzfhh.z0tdj);
			}
			else if (text == z0ZzZzfhh.z0jfj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzukh()));
				}
			}
			else if (text == z0ZzZzfhh.z0srk)
			{
				p1.AutoHeightForMultiline = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.BringoutToSave = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.CanBeReferenced = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ztk)
			{
				p1.CaptionAlign = (StringAlignment)p0.z0tek(z0ZzZzfhh.z0arj);
			}
			else if (text == z0ZzZzfhh.z0emj)
			{
				p1.CaptionFlowLayout = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0uuk)
			{
				p1.CheckBoxVisible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0rpk)
			{
				p1.CheckboxVisibility = zzz.z0ZzZzcyk<RenderVisibility>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0ixk)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				z0ZzZzuhh z0ZzZzuhh2 = new z0ZzZzuhh();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						z0ZzZzuhh2.Add(z0tek(p0, new z0ZzZzyhh()));
					}
				}
				if (z0ZzZzuhh2.Count > 0)
				{
					p1.CheckedUserHistories = z0ZzZzuhh2;
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0vbk)
			{
				p1.z0ii((CheckBoxControlStyle)p0.z0tek(z0ZzZzfhh.z0cbk));
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.DataName = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0kuk)
			{
				p1.DefaultCheckedForValueBinding = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0doj)
			{
				p1.EnableHighlight = (EnableState)p0.z0tek(z0ZzZzfhh.z0pbj);
			}
			else if (text == z0ZzZzfhh.z0wyj)
			{
				p1.Enabled = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.Height = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0ydj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					((XTextObjectElement)p1).z0eek(z0tek(p0, new z0ZzZzbuk()));
				}
			}
			else if (text == z0ZzZzfhh.z0raj)
			{
				p1.Multiline = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0hfj)
			{
				p1.OffsetX = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0dck)
			{
				p1.OffsetY = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0vej)
			{
				p1.PrintTextForChecked = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0puk)
			{
				p1.PrintTextForUnChecked = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0pij)
			{
				p1.PrintVisibilityWhenUnchecked = (PrintVisibilityModeWhenUnchecked)p0.z0tek(z0ZzZzfhh.z0skj);
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0zck)
			{
				p1.Readonly = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0ynj)
			{
				p1.Requried = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0kck)
			{
				p1.StringTag = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.Width = p0.z0yek();
			}
			else if (text == z0ZzZzfhh.z0bpk)
			{
				p1.ZOrderStyle = (ElementZOrderStyle)p0.z0tek(z0ZzZzfhh.z0zxk);
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static z0ZzZzluj z0tek(z0ZzZzxjh p0, z0ZzZzluj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0uxk)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0dhj)
			{
				p1.z0rek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0quk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzzyj()));
				}
			}
			else if (text == z0ZzZzfhh.z0xtk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzimk()));
				}
			}
			else if (text == z0ZzZzfhh.z0rck)
			{
				p1.z0yek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0qjk(z0tek(p0, new z0ZzZzguj()));
				}
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				((z0ZzZzeuj)p1).z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0yqj)
			{
				p1.z0tek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0qej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzcok()));
				}
			}
			else if (text == z0ZzZzfhh.z0hnj)
			{
				p1.z0zkk(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				((z0ZzZzeuj)p1).z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0oyj_jiejie20260327142557)
			{
				p1.z0eek(p0.z0tek(z0vek));
			}
			else if (text == z0ZzZzfhh.z0gtk)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.z0yek(p0.z0yek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static XTextDocument z0tek(z0ZzZzxjh p0, XTextDocument p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0tbk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.Attributes = z0tek(p0, new XAttributeList());
				}
			}
			else if (text == z0ZzZzfhh.z0hmj)
			{
				p1.z0hrk(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0ytk)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				z0ZzZzwcj z0ZzZzwcj2 = new z0ZzZzwcj();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						z0ZzZzwcj2.Add(z0tek(p0, new DocumentComment()));
					}
				}
				if (z0ZzZzwcj2.Count > 0)
				{
					p1.Comments = z0ZzZzwcj2;
				}
			}
			else if (text == z0ZzZzfhh.z0ruk)
			{
				p1.z0vek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0te(z0tek(p0, new XTextElementList()));
				}
			}
			else if (text == z0ZzZzfhh.z0fgj)
			{
				p1.z0rrk(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0xtj)
			{
				p1.z0cek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0khj)
			{
				p1.z0yek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0hlj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				z0ZzZzkvj z0ZzZzkvj2 = new z0ZzZzkvj();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						z0ZzZzkvj2.Add(z0tek(p0, new DocumentParameter()));
					}
				}
				if (z0ZzZzkvj2.Count > 0)
				{
					p1.z0bek(z0ZzZzkvj2);
				}
			}
			else if (text == z0ZzZzfhh.z0nwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				z0ZzZzuhh z0ZzZzuhh2 = new z0ZzZzuhh();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						z0ZzZzuhh2.Add(z0tek(p0, new z0ZzZzyhh()));
					}
				}
				if (z0ZzZzuhh2.Count > 0)
				{
					p1.z0bek(z0ZzZzuhh2);
				}
			}
			else if (text == z0ZzZzfhh.z0iwj)
			{
				p1.AcceptChildElementTypes2 = zzz.z0ZzZzcyk<ElementType>.z0eek(p0.z0uek());
			}
			else if (text == z0ZzZzfhh.z0gdj)
			{
				p1.AcceptTab = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0yoj)
			{
				p1.z0hrk(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0ipj)
			{
				p1.z0st(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0lok)
			{
				p1.z0jt(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0zpj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ContentLock = z0tek(p0, new DCContentLockInfo());
				}
			}
			else if (text == z0ZzZzfhh.z0mnj)
			{
				p1.ContentReadonly = (ContentReadonlyState)p0.z0tek(z0ZzZzfhh.z0znj);
			}
			else if (text == z0ZzZzfhh.z0ypj)
			{
				p1.ContentReadonlyExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0quk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0bek(z0tek(p0, new DocumentContentStyleContainer()));
				}
			}
			else if (text == z0ZzZzfhh.z0jij)
			{
				p1.z0ft(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0vzk)
			{
				((XTextContainerElement)p1).z0xek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cej)
			{
				p1.Deleteable = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0hyj)
			{
				p1.z0erk(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0qcj)
			{
				p1.z0irk(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0fdj)
			{
				p1.EnablePermission = (DCBooleanValue)p0.z0tek(z0ZzZzfhh.z0wmk);
			}
			else if (text == z0ZzZzfhh.z0oij)
			{
				p1.EnableValueValidate = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0yzk)
			{
				p1.HiddenPrintWhenEmpty = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				p1.ID = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0fzk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0bek(z0tek(p0, new DocumentInfo()));
				}
			}
			else if (text == z0ZzZzfhh.z0cck)
			{
				p1.z0pek((List<byte[]>)p0.z0eek(new List<byte[]>()));
			}
			else if (text == z0ZzZzfhh.z0krk)
			{
				p1.LimitedInputChars = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0awj)
			{
				p1.z0ark(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0tkj)
			{
				p1.MaxInputLength = p0.z0pek();
			}
			else if (text == z0ZzZzfhh.z0vkj)
			{
				p1.z0bek((MeasureMode)p0.z0tek(z0ZzZzfhh.z0eok));
			}
			else if (text == z0ZzZzfhh.z0frj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.PageSettings = z0tek(p0, new XPageSettings());
				}
			}
			else if (text == z0ZzZzfhh.z0itj)
			{
				p1.PrintVisibility = (ElementVisibility)p0.z0tek(z0ZzZzfhh.z0vck);
			}
			else if (text == z0ZzZzfhh.z0bck)
			{
				p1.PrintVisibilityExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0eej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.PropertyExpressions = z0tek(p0, new PropertyExpressionInfoList());
				}
			}
			else if (text == z0ZzZzfhh.z0zyj)
			{
				if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)2)
				{
					continue;
				}
				RepeatedImageValueList repeatedImageValueList = new RepeatedImageValueList();
				while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)14)
				{
					if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
					{
						repeatedImageValueList.Add(z0tek(p0, new RepeatedImageValue()));
					}
				}
				if (repeatedImageValueList.Count > 0)
				{
					p1.z0bek(repeatedImageValueList);
				}
			}
			else if (text == z0ZzZzfhh.z0ksj)
			{
				p1.z0frk(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0cwj)
			{
				p1.ToolTip = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0dwj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValidateStyle = z0tek(p0, new ValueValidateStyle());
				}
			}
			else if (text == z0ZzZzfhh.z0crk)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.ValueBinding = z0tek(p0, new z0ZzZzevj());
				}
			}
			else if (text == z0ZzZzfhh.z0gvj)
			{
				p1.ValueExpression = p0.z0bek();
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.Visible = p0.z0vek();
			}
			else if (text == z0ZzZzfhh.z0gtj)
			{
				p1.VisibleExpression = p0.z0bek();
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzguj p1)
	{
		if (p1.Count <= 0)
		{
			return;
		}
		p0.z0iek();
		int count = p1.Count;
		for (int i = 0; i < count; i++)
		{
			z0ZzZzhuj z0ZzZzhuj2 = p1[i];
			if (z0ZzZzhuj2 is z0ZzZzluj)
			{
				p0.z0rek(z0ZzZzfhh.z0unk);
				z0tek(p0, (z0ZzZzluj)z0ZzZzhuj2);
				p0.z0mek();
			}
			else if (z0ZzZzhuj2 is z0ZzZzkuj)
			{
				p0.z0rek(z0ZzZzfhh.z0yek);
				z0tek(p0, (z0ZzZzkuj)z0ZzZzhuj2);
				p0.z0mek();
			}
			else if (z0ZzZzhuj2 is z0ZzZzjuj)
			{
				p0.z0rek(z0ZzZzfhh.z0adj);
				z0tek(p0, (z0ZzZzjuj)z0ZzZzhuj2);
				p0.z0mek();
			}
			else if (z0ZzZzhuj2 is z0ZzZzxyj)
			{
				p0.z0rek(z0ZzZzfhh.z0tvk);
				z0tek(p0, (z0ZzZzxyj)z0ZzZzhuj2);
				p0.z0mek();
			}
			else if (z0ZzZzhuj2 is z0ZzZzfuj)
			{
				p0.z0rek(z0ZzZzfhh.z0ejj);
				z0tek(p0, (z0ZzZzfuj)z0ZzZzhuj2);
				p0.z0mek();
			}
			else if (z0ZzZzhuj2 is z0ZzZzwuj)
			{
				p0.z0rek(z0ZzZzfhh.z0xyk);
				z0tek(p0, (z0ZzZzwuj)z0ZzZzhuj2);
				p0.z0mek();
			}
			else if (z0ZzZzhuj2 is z0ZzZzeuj)
			{
				p0.z0rek(z0ZzZzfhh.z0zvk_jiejie20260327142557);
				z0tek(p0, (z0ZzZzeuj)z0ZzZzhuj2);
				p0.z0mek();
			}
			else if (z0ZzZzhuj2 is z0ZzZzquj)
			{
				p0.z0rek(z0ZzZzfhh.z0mbj);
				z0tek(p0, (z0ZzZzquj)z0ZzZzhuj2);
				p0.z0mek();
			}
			else if (z0ZzZzhuj2 is z0ZzZzuuj)
			{
				p0.z0rek(z0ZzZzfhh.z0fbj);
				z0tek(p0, (z0ZzZzuuj)z0ZzZzhuj2);
				p0.z0mek();
			}
			else if (z0ZzZzhuj2 is z0ZzZzauj)
			{
				p0.z0rek(z0ZzZzfhh.z0vek);
				z0tek(p0, (z0ZzZzauj)z0ZzZzhuj2);
				p0.z0mek();
			}
			else if (z0ZzZzhuj2 is z0ZzZziuj)
			{
				p0.z0rek(z0ZzZzfhh.z0cmk);
				z0tek(p0, (z0ZzZziuj)z0ZzZzhuj2);
				p0.z0mek();
			}
			else if (z0ZzZzhuj2 != null)
			{
				p0.z0rek(z0ZzZzfhh.z0qrj);
				z0tek(p0, z0ZzZzhuj2);
				p0.z0mek();
			}
		}
		p0.z0nek();
	}

	internal static ObjectParameter z0tek(z0ZzZzxjh p0, ObjectParameter p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0ntj)
				{
					p1.Name = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0jsj)
				{
					p1.Value = p0.z0bek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, ValueValidateStyle p1)
	{
		if (p1.MaxLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0fej, p1.MaxLength);
		}
		if (p1.CheckMaxValue)
		{
			p0.z0rek(z0ZzZzfhh.z0hik, p1.CheckMaxValue);
		}
		if (p1.ValueType != ValueTypeStyle.Text)
		{
			p0.z0rek(z0ZzZzfhh.z0kgj, z0ZzZzfhh.z0eek(p1.ValueType), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0dej, p1.CustomMessage);
		if (p1.Required)
		{
			p0.z0rek(z0ZzZzfhh.z0huj, p1.Required);
		}
		if (p1.MaxValue != 0.0)
		{
			if (z0ZzZzbok.z0eek(p1.MaxValue))
			{
				p0.z0rek(z0ZzZzfhh.z0toj, 0);
			}
			else
			{
				p0.z0rek(z0ZzZzfhh.z0toj, p1.MaxValue);
			}
		}
		p0.z0rek(z0ZzZzfhh.z0kej, p1.ExcludeKeywords);
		p0.z0rek(z0ZzZzfhh.z0bpj, p1.ValueName);
		if (p1.MinValue != 0.0)
		{
			if (z0ZzZzbok.z0eek(p1.MinValue))
			{
				p0.z0rek(z0ZzZzfhh.z0tpj, 0);
			}
			else
			{
				p0.z0rek(z0ZzZzfhh.z0tpj, p1.MinValue);
			}
		}
		p0.z0rek(z0ZzZzfhh.z0mpk, p1.RegExpression);
		if (p1.CheckMinValue)
		{
			p0.z0rek(z0ZzZzfhh.z0nbk, p1.CheckMinValue);
		}
		if (p1.MinLength != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0jgj, p1.MinLength);
		}
		if (p1.BinaryLength)
		{
			p0.z0rek(z0ZzZzfhh.z0edj, p1.BinaryLength);
		}
		if (p1.CheckDecimalDigits)
		{
			p0.z0rek(z0ZzZzfhh.z0enk, p1.CheckDecimalDigits);
		}
		if (p1.DateTimeMaxValue.Ticks != 624511296000000000L)
		{
			p0.z0rek(z0ZzZzfhh.z0gaj, p1.DateTimeMaxValue);
		}
		if (p1.DateTimeMinValue.Ticks != 624511296000000000L)
		{
			p0.z0rek(z0ZzZzfhh.z0wij, p1.DateTimeMinValue);
		}
		p0.z0rek(z0ZzZzfhh.z0elj, p1.IncludeKeywords);
		if (p1.Level != ValueValidateLevel.Error)
		{
			p0.z0rek(z0ZzZzfhh.z0stj, z0ZzZzfhh.z0eek(p1.Level), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.MaxDecimalDigits != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0xzk, p1.MaxDecimalDigits);
		}
		p0.z0rek(z0ZzZzfhh.z0ebk, p1.Range);
		if (p1.RequiredInvalidateFlag)
		{
			p0.z0rek(z0ZzZzfhh.z0thj, p1.RequiredInvalidateFlag);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzatk p1)
	{
		if (p1.Count > 0)
		{
			p0.z0iek();
			int count = p1.Count;
			for (int i = 0; i < count; i++)
			{
				p0.z0tek();
				z0tek(p0, p1[i]);
				p0.z0mek();
			}
			p0.z0nek();
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzzej p1)
	{
		if (p1.z0xek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0xgj, p1.z0xek());
		}
		if (p1.z0uek())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0uek());
		}
		if (!p1.z0cek())
		{
			p0.z0rek(z0ZzZzfhh.z0bfj, p1.z0cek());
		}
		if (p1.z0iek().ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0laj, p1.z0iek());
		}
		if (p1.z0mek() != 0)
		{
			p0.z0rek(z0ZzZzfhh.z0efj, p1.z0mek());
		}
		if (p1.z0vek() != DashStyle.Solid)
		{
			p0.z0rek(z0ZzZzfhh.z0nkj, z0ZzZzfhh.z0eek(p1.z0vek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0oek() != 1f)
		{
			p0.z0rek(z0ZzZzfhh.z0zuk, p1.z0oek());
		}
		if (!p1.z0yek())
		{
			p0.z0rek(z0ZzZzfhh.z0pek, p1.z0yek());
		}
	}

	internal static z0ZzZzjuj z0tek(z0ZzZzxjh p0, z0ZzZzjuj p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0anj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)2)
				{
					p1.z0qjk(z0tek(p0, new z0ZzZzguj()));
				}
			}
			else if (text == z0ZzZzfhh.z0coj)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0oek)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0yqj)
			{
				p1.z0tek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0qej)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzcok()));
				}
			}
			else if (text == z0ZzZzfhh.z0hnj)
			{
				p1.z0zkk(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0uzk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0tik)
			{
				p1.z0eek(p0.z0bek());
			}
			else if (text == z0ZzZzfhh.z0gtk)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				((z0ZzZzhuj)p1).z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0nnj)
			{
				p1.z0yek(p0.z0yek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzjuj p1)
	{
		z0ZzZzguj z0ZzZzguj2 = p1.z0djk();
		if (z0ZzZzguj2 != null && z0ZzZzguj2.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0anj);
			z0tek(p0, z0ZzZzguj2);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0coj, ((z0ZzZzhuj)p1).z0yek());
		if (((z0ZzZzeuj)p1).z0eek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0oek, ((z0ZzZzeuj)p1).z0eek());
		}
		if (p1.z0rek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0yqj, p1.z0rek());
		}
		if (((z0ZzZzhuj)p1).z0pek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0qej);
			z0tek(p0, ((z0ZzZzhuj)p1).z0pek());
			p0.z0uek();
		}
		if (!p1.z0xkk())
		{
			p0.z0rek(z0ZzZzfhh.z0hnj, p1.z0xkk());
		}
		if (((z0ZzZzhuj)p1).z0eek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((z0ZzZzhuj)p1).z0eek());
		}
		p0.z0rek(z0ZzZzfhh.z0tik, p1.z0pek());
		if (p1.z0oek() != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0gtk, p1.z0oek());
		}
		if (!p1.z0rek_jiejie20260327142557())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0rek_jiejie20260327142557());
		}
		if (p1.z0mek() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0nnj, p1.z0mek());
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextCheckBoxElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0wcj, p1.Caption);
		p0.z0rek(z0ZzZzfhh.z0tfj, p1.GroupName);
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.CheckAlignLeft)
		{
			p0.z0rek(z0ZzZzfhh.z0lmk, p1.CheckAlignLeft);
		}
		p0.z0rek(z0ZzZzfhh.z0wvj, p1.CheckedValue);
		if (p1.Checked)
		{
			p0.z0rek(z0ZzZzfhh.z0knk, p1.Checked);
		}
		if (p1.ValueBinding != null)
		{
			p0.z0yek(z0ZzZzfhh.z0crk);
			z0tek(p0, p1.ValueBinding);
			p0.z0uek();
		}
		if (p1.VisualStyle != CheckBoxVisualStyle.Default)
		{
			p0.z0rek(z0ZzZzfhh.z0xaj, z0ZzZzfhh.z0eek(p1.VisualStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		z0ZzZzukh z0ZzZzukh2 = p1.z0uek();
		if (z0ZzZzukh2 != null && z0ZzZzukh2.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0jfj);
			z0tek(p0, z0ZzZzukh2);
			p0.z0yek();
		}
		if (p1.AutoHeightForMultiline)
		{
			p0.z0rek(z0ZzZzfhh.z0srk, p1.AutoHeightForMultiline);
		}
		if (p1.BringoutToSave)
		{
			p0.z0rek(z0ZzZzfhh.z0ipj, p1.BringoutToSave);
		}
		if (p1.CanBeReferenced)
		{
			p0.z0rek(z0ZzZzfhh.z0lok, p1.CanBeReferenced);
		}
		if (p1.CaptionAlign != StringAlignment.Center)
		{
			p0.z0rek(z0ZzZzfhh.z0ztk, z0ZzZzfhh.z0eek(p1.CaptionAlign), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.CaptionFlowLayout)
		{
			p0.z0rek(z0ZzZzfhh.z0emj, p1.CaptionFlowLayout);
		}
		if (!p1.CheckBoxVisible)
		{
			p0.z0rek(z0ZzZzfhh.z0uuk, p1.CheckBoxVisible);
		}
		if (p1.CheckboxVisibility != RenderVisibility.All)
		{
			p0.z0rek(z0ZzZzfhh.z0rpk, zzz.z0ZzZzcyk<RenderVisibility>.z0rek(p1.CheckboxVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.CheckedUserHistories != null)
		{
			z0ZzZzuhh checkedUserHistories = p1.CheckedUserHistories;
			int count = checkedUserHistories.Count;
			if (count > 0)
			{
				p0.z0uek(z0ZzZzfhh.z0ixk);
				p0.z0iek();
				for (int i = 0; i < count; i++)
				{
					p0.z0tek();
					z0tek(p0, checkedUserHistories[i]);
					p0.z0mek();
				}
				p0.z0nek();
				p0.z0yek();
			}
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0oi() != CheckBoxControlStyle.CheckBox)
		{
			p0.z0rek(z0ZzZzfhh.z0vbk, z0ZzZzfhh.z0eek(p1.z0oi()), z0ZzZzeok.z0mjj.z0tek);
		}
		p0.z0rek(z0ZzZzfhh.z0jij, p1.DataName);
		if (p1.DefaultCheckedForValueBinding)
		{
			p0.z0rek(z0ZzZzfhh.z0kuk, p1.DefaultCheckedForValueBinding);
		}
		if (p1.EnableHighlight != EnableState.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0doj, z0ZzZzfhh.z0eek(p1.EnableHighlight), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		if (((XTextObjectElement)p1).z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, ((XTextObjectElement)p1).z0iek());
			p0.z0uek();
		}
		if (p1.Multiline)
		{
			p0.z0rek(z0ZzZzfhh.z0raj, p1.Multiline);
		}
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		p0.z0rek(z0ZzZzfhh.z0vej, p1.PrintTextForChecked);
		p0.z0rek(z0ZzZzfhh.z0puk, p1.PrintTextForUnChecked);
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.PrintVisibilityWhenUnchecked != PrintVisibilityModeWhenUnchecked.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0pij, z0ZzZzfhh.z0eek(p1.PrintVisibilityWhenUnchecked), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		if (p1.Readonly)
		{
			p0.z0rek(z0ZzZzfhh.z0zck, p1.Readonly);
		}
		if (p1.Requried)
		{
			p0.z0rek(z0ZzZzfhh.z0ynj, p1.Requried);
		}
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		p0.z0rek(z0ZzZzfhh.z0nnj, p1.Width);
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static z0ZzZzptk z0tek(z0ZzZzxjh p0, z0ZzZzptk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (!p0.z0uq())
			{
				continue;
			}
			if (text == z0ZzZzfhh.z0ttk)
			{
				p1.z0eek(p0.z0vek());
			}
			else if (text == z0ZzZzfhh.z0xik)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzemk()));
				}
			}
			else if (text == z0ZzZzfhh.z0rjj)
			{
				if (((z0ZzZzxqh)p0).z0uek() == (z0ZzZzkwh)1)
				{
					p1.z0eek(z0tek(p0, new z0ZzZzimk()));
				}
			}
			else if (text == z0ZzZzfhh.z0jvj)
			{
				p1.z0eek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0jik)
			{
				p1.z0eek(p0.z0pek());
			}
			else if (text == z0ZzZzfhh.z0ouk)
			{
				p1.z0rek(p0.z0yek());
			}
			else if (text == z0ZzZzfhh.z0ojj)
			{
				p1.z0eek(p0.z0tek(z0cek));
			}
			else if (text == z0ZzZzfhh.z0mtk)
			{
				p1.z0rek(p0.z0vek());
			}
			else
			{
				p0.z0tek(p1, text);
			}
		}
		return p1;
	}

	internal static void z0tek(z0ZzZzzjh p0, XTextHorizontalLineElement p1)
	{
		p0.z0rek(z0ZzZzfhh.z0coj, p1.ID);
		if (p1.LineSize != 1f)
		{
			p0.z0rek(z0ZzZzfhh.z0pnk, p1.LineSize);
		}
		XAttributeList attributes = p1.Attributes;
		if (attributes != null && attributes.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0tbk);
			z0tek(p0, attributes);
			p0.z0yek();
		}
		if (p1.ContentReadonly != ContentReadonlyState.Inherit)
		{
			p0.z0rek(z0ZzZzfhh.z0mnj, z0ZzZzfhh.z0eek(p1.ContentReadonly), z0ZzZzeok.z0mjj.z0tek);
		}
		if (!p1.Deleteable)
		{
			p0.z0rek(z0ZzZzfhh.z0cej, p1.Deleteable);
		}
		if (!p1.Enabled)
		{
			p0.z0rek(z0ZzZzfhh.z0wyj, p1.Enabled);
		}
		if (p1.Height != 20f)
		{
			p0.z0rek(z0ZzZzfhh.z0oek, p1.Height);
		}
		if (p1.LineLengthInCM != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0kmk, p1.LineLengthInCM);
		}
		if (p1.LineStyle != DashStyle.Solid)
		{
			p0.z0rek(z0ZzZzfhh.z0nkj, z0ZzZzfhh.z0eek(p1.LineStyle), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0iek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0ydj);
			z0tek(p0, p1.z0iek());
			p0.z0uek();
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.OffsetX != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0hfj, p1.OffsetX);
		}
		if (p1.OffsetY != 0f)
		{
			p0.z0rek(z0ZzZzfhh.z0dck, p1.OffsetY);
		}
		if (p1.PrintVisibility != ElementVisibility.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0itj, z0ZzZzfhh.z0eek(p1.PrintVisibility), z0ZzZzeok.z0mjj.z0tek);
		}
		PropertyExpressionInfoList propertyExpressions = p1.PropertyExpressions;
		if (propertyExpressions != null && propertyExpressions.Count > 0)
		{
			p0.z0uek(z0ZzZzfhh.z0eej);
			z0tek(p0, propertyExpressions);
			p0.z0yek();
		}
		p0.z0rek(z0ZzZzfhh.z0kck, p1.StringTag);
		if (((XTextElement)p1).z0pek() != -1)
		{
			p0.z0rek(z0ZzZzfhh.z0uzk, ((XTextElement)p1).z0pek());
		}
		p0.z0rek(z0ZzZzfhh.z0cwj, p1.ToolTip);
		p0.z0rek(z0ZzZzfhh.z0gvj, p1.ValueExpression);
		if (!p1.Visible)
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.Visible);
		}
		if (p1.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			p0.z0rek(z0ZzZzfhh.z0bpk, z0ZzZzfhh.z0eek(p1.ZOrderStyle), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzimk p1)
	{
		if (p1.Bold)
		{
			p0.z0rek(z0ZzZzfhh.z0vyk, p1.Bold);
		}
		if (p1.Italic)
		{
			p0.z0rek(z0ZzZzfhh.z0wtk, p1.Italic);
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.Name);
		if (p1.Size != 9f)
		{
			p0.z0rek(z0ZzZzfhh.z0jik, p1.Size);
		}
		if (p1.Strikeout)
		{
			p0.z0rek(z0ZzZzfhh.z0tbj, p1.Strikeout);
		}
		if (p1.Underline)
		{
			p0.z0rek(z0ZzZzfhh.z0wok, p1.Underline);
		}
		if (p1.Unit != GraphicsUnit.Point)
		{
			p0.z0rek(z0ZzZzfhh.z0rxk, z0ZzZzfhh.z0eek(p1.Unit), z0ZzZzeok.z0mjj.z0tek);
		}
	}

	internal static void z0tek(z0ZzZzzjh p0, z0ZzZzstk p1)
	{
		if (p1.z0nek() != ContentAlignment.MiddleCenter)
		{
			p0.z0rek(z0ZzZzfhh.z0otj, zzz.z0ZzZzcyk<ContentAlignment>.z0rek(p1.z0nek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0frk().ToArgb() != -16777216)
		{
			p0.z0rek(z0ZzZzfhh.z0laj, p1.z0frk());
		}
		if (p1.z0vek() != null)
		{
			p0.z0yek(z0ZzZzfhh.z0rjj);
			z0tek(p0, p1.z0vek());
			p0.z0uek();
		}
		if (p1.z0pek() != 10.0)
		{
			p0.z0rek(z0ZzZzfhh.z0xhj, p1.z0pek());
		}
		if (p1.z0drk() != 100f)
		{
			p0.z0rek(z0ZzZzfhh.z0oek, p1.z0drk());
		}
		if (!p1.z0xek())
		{
			p0.z0rek(z0ZzZzfhh.z0kbk, p1.z0xek());
		}
		if (p1.z0oek() != RangeCalculateStyle.None)
		{
			p0.z0rek(z0ZzZzfhh.z0gyk, z0ZzZzfhh.z0eek(p1.z0oek()), z0ZzZzeok.z0mjj.z0tek);
		}
		if (p1.z0cek() != 100.0)
		{
			p0.z0rek(z0ZzZzfhh.z0toj, p1.z0cek());
		}
		if (p1.z0hrk() != 0.0)
		{
			p0.z0rek(z0ZzZzfhh.z0tpj, p1.z0hrk());
		}
		p0.z0rek(z0ZzZzfhh.z0ntj, p1.z0mek());
		p0.z0rek(z0ZzZzfhh.z0tik, p1.z0iek());
		p0.z0rek(z0ZzZzfhh.z0qhj, p1.z0srk());
		if (p1.z0jrk())
		{
			p0.z0rek(z0ZzZzfhh.z0mtk, p1.z0jrk());
		}
	}

	internal static z0ZzZzjuk z0tek(z0ZzZzxjh p0, z0ZzZzjuk p1)
	{
		while (p0.z0uq() && ((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)13)
		{
			if (((z0ZzZzxqh)p0).z0uek() != (z0ZzZzkwh)4)
			{
				continue;
			}
			string text = (string)((z0ZzZzxqh)p0).z0iek();
			if (p0.z0uq())
			{
				if (text == z0ZzZzfhh.z0ntj)
				{
					p1.Name = p0.z0bek();
				}
				else if (text == z0ZzZzfhh.z0jsj)
				{
					p1.Value = p0.z0bek();
				}
				else
				{
					p0.z0tek(p1, text);
				}
			}
		}
		return p1;
	}
}
