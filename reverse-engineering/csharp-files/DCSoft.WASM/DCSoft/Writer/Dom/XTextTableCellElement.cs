using System;
using System.Collections.Generic;
using System.ComponentModel;
using DCSoft.Common;
using DCSoft.Drawing;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XTextTableCell")]
public sealed class XTextTableCellElement : XTextContentElement
{
	private class z0wxk : IComparable<z0wxk>
	{
		public float z0eek_jiejie20260327142557;

		public XTextTableColumnElement z0rek;

		public XTextTableColumnElement z0tek;

		public float z0yek;

		public bool z0uek;

		public int z0iek;

		public int CompareTo(z0wxk other)
		{
			return (int)(z0eek_jiejie20260327142557 - other.z0eek_jiejie20260327142557);
		}

		public override string ToString()
		{
			string text = z0eek_jiejie20260327142557.ToString("0.0") + " " + z0yek.ToString("0.0");
			if (z0uek)
			{
				text += " NewFlag";
			}
			if (z0rek != null)
			{
				text += " HasOldCol";
			}
			return text;
		}
	}

	public delegate XTextTableCellElement z0rmk(XTextTableCellElement srcElement, TableRowCloneType cloneType);

	private new int z0erk = 1;

	public new static z0rmk z0rrk;

	private new int z0trk = 1;

	internal new static float z0yrk;

	private new static z0ZzZzrfh z0urk;

	[NonSerialized]
	internal new XTextTableCellElement z0irk;

	[NonSerialized]
	internal new int z0ork = -1;

	[NonSerialized]
	private new XTextTableColumnElement z0prk;

	internal new static bool z0mrk;

	[NonSerialized]
	internal new int z0nrk = -1;

	[DefaultValue(MoveFocusHotKeys.Tab)]
	[z0ZzZzbjh]
	public MoveFocusHotKeys MoveFocusHotKey
	{
		get
		{
			if (((XTextContainerElement)this).z0utk != null)
			{
				return ((z0qpk)((XTextContainerElement)this).z0utk).z0tek;
			}
			return MoveFocusHotKeys.Tab;
		}
		set
		{
			if (value == MoveFocusHotKeys.Tab)
			{
				if (((XTextContainerElement)this).z0utk != null)
				{
					((z0qpk)((XTextContainerElement)this).z0utk).z0tek = MoveFocusHotKeys.Tab;
				}
			}
			else
			{
				z0vrk().z0tek = value;
			}
		}
	}

	[DefaultValue(true)]
	[z0ZzZzuqh]
	public override bool Visible
	{
		get
		{
			return true;
		}
		set
		{
			base.Visible = value;
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(ContentAutoFixFontSizeMode.None)]
	public ContentAutoFixFontSizeMode AutoFixFontSizeMode
	{
		get
		{
			if (((XTextContainerElement)this).z0utk != null)
			{
				return ((z0qpk)((XTextContainerElement)this).z0utk).z0yek_jiejie20260327142557;
			}
			return ContentAutoFixFontSizeMode.None;
		}
		set
		{
			if (value == ContentAutoFixFontSizeMode.None)
			{
				if (((XTextContainerElement)this).z0utk != null)
				{
					((z0qpk)((XTextContainerElement)this).z0utk).z0yek_jiejie20260327142557 = ContentAutoFixFontSizeMode.None;
				}
			}
			else
			{
				z0vrk().z0yek_jiejie20260327142557 = value;
			}
		}
	}

	[DefaultValue(RectangleSlantSplitStyle.None)]
	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	public RectangleSlantSplitStyle SlantSplitLineStyle
	{
		get
		{
			if (((XTextContainerElement)this).z0utk != null)
			{
				return ((z0qpk)((XTextContainerElement)this).z0utk).z0eek;
			}
			return RectangleSlantSplitStyle.None;
		}
		set
		{
			if (value == RectangleSlantSplitStyle.None)
			{
				if (((XTextContainerElement)this).z0utk != null)
				{
					((z0qpk)((XTextContainerElement)this).z0utk).z0eek = value;
				}
			}
			else
			{
				z0vrk().z0eek = value;
			}
		}
	}

	[z0ZzZztqh]
	[DefaultValue(RenderVisibility.All)]
	public RenderVisibility BorderRenderVisibility
	{
		get
		{
			if (((XTextContainerElement)this).z0utk != null)
			{
				return ((z0qpk)((XTextContainerElement)this).z0utk).z0bek;
			}
			return RenderVisibility.All;
		}
		set
		{
			if (value == RenderVisibility.All)
			{
				if (((XTextContainerElement)this).z0utk != null)
				{
					((z0qpk)((XTextContainerElement)this).z0utk).z0bek = RenderVisibility.All;
				}
			}
			else
			{
				z0vrk().z0bek = value;
			}
		}
	}

	[DefaultValue(TableRowCloneType.Default)]
	public TableRowCloneType CloneType
	{
		get
		{
			if (((XTextContainerElement)this).z0utk != null)
			{
				return ((XTextContainerElement)this).z0utk.z0iek;
			}
			return TableRowCloneType.Default;
		}
		set
		{
			if (value == TableRowCloneType.Default)
			{
				if (((XTextContainerElement)this).z0utk != null)
				{
					((XTextContainerElement)this).z0utk.z0iek = TableRowCloneType.Default;
				}
			}
			else
			{
				((XTextContainerElement)this).z0prk().z0iek = value;
			}
		}
	}

	[DefaultValue(false)]
	public bool MirrorViewForCrossPage
	{
		get
		{
			return z0dtk();
		}
		set
		{
			z0prk(value);
		}
	}

	[z0ZzZzuqh]
	public override bool AcceptTab
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[DefaultValue(1)]
	[z0ZzZzbjh(MemberEffectLevel.ContentElementLayout)]
	public int RowSpan
	{
		get
		{
			return z0trk;
		}
		set
		{
			if (z0xu())
			{
				z0trk = value;
				return;
			}
			if (z0gr() == null || z0jr() == null || z0jr().z0dtk() != (z0ZzZzzcj)3)
			{
				z0trk = value;
				return;
			}
			int num = z0uek(value);
			if (z0trk != num)
			{
				z0trk = num;
				z0gr().z0ct();
			}
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.DOM)]
	[DefaultValue(false)]
	public bool BorderPrintedWhenJumpPrint
	{
		get
		{
			return z0syk();
		}
		set
		{
			z0cek(value);
		}
	}

	[z0ZzZztqh]
	[DefaultValue(RenderVisibility.All)]
	public RenderVisibility ContentRenderVisibility
	{
		get
		{
			if (((XTextContainerElement)this).z0utk != null)
			{
				return ((z0qpk)((XTextContainerElement)this).z0utk).z0nek;
			}
			return RenderVisibility.All;
		}
		set
		{
			if (value == RenderVisibility.All)
			{
				if (((XTextContainerElement)this).z0utk != null)
				{
					((z0qpk)((XTextContainerElement)this).z0utk).z0nek = RenderVisibility.All;
				}
			}
			else
			{
				z0vrk().z0nek = value;
			}
		}
	}

	[z0ZzZzuqh]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public override string FormulaValue
	{
		get
		{
			XTextInputFieldElement xTextInputFieldElement = z0ntk.z0srk<XTextInputFieldElement>();
			if (xTextInputFieldElement == null)
			{
				return Text;
			}
			return xTextInputFieldElement.FormulaValue;
		}
		set
		{
			XTextInputFieldElement xTextInputFieldElement = z0be().z0srk<XTextInputFieldElement>();
			SetContainerTextArgs setContainerTextArgs = new SetContainerTextArgs();
			setContainerTextArgs.NewText = z0uek(value);
			setContainerTextArgs.LogUndo = false;
			setContainerTextArgs.AccessFlags = (z0ZzZzbcj)0;
			setContainerTextArgs.DisablePermission = true;
			setContainerTextArgs.EventSource = ContentChangedEventSource.Default;
			setContainerTextArgs.FocusContainer = false;
			setContainerTextArgs.IgnoreDisplayFormat = false;
			setContainerTextArgs.ShowUI = false;
			setContainerTextArgs.UpdateContent = true;
			if (xTextInputFieldElement == null)
			{
				z0do(setContainerTextArgs);
			}
			else
			{
				xTextInputFieldElement.z0do(setContainerTextArgs);
			}
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ContentElementLayout)]
	[DefaultValue(1)]
	public int ColSpan
	{
		get
		{
			return z0erk;
		}
		set
		{
			if (z0xu())
			{
				z0erk = value;
				return;
			}
			if (z0jr() == null || z0jr().z0dtk() != (z0ZzZzzcj)3)
			{
				z0erk = value;
				return;
			}
			int num = z0rek(value);
			if (z0erk != num)
			{
				z0erk = num;
				z0gr().z0ct();
			}
		}
	}

	internal override bool z0zt(z0ZzZzazj p0)
	{
		ContentAutoFixFontSizeMode contentAutoFixFontSizeMode = z0nek();
		if (contentAutoFixFontSizeMode == ContentAutoFixFontSizeMode.MultiLine || contentAutoFixFontSizeMode == ContentAutoFixFontSizeMode.SingleLine)
		{
			z0tek();
		}
		else
		{
			z0rek(1f);
		}
		bool result = base.z0zt(p0);
		if (MirrorViewForCrossPage)
		{
			z0jo();
		}
		return result;
	}

	public bool z0rek(DCDirection p0, bool p1, Color p2)
	{
		XTextTableCellElement xTextTableCellElement = this;
		if (xTextTableCellElement.z0hrk() != null)
		{
			xTextTableCellElement = xTextTableCellElement.z0hrk();
		}
		if (xTextTableCellElement.z0gr() == null || xTextTableCellElement.z0jr() == null)
		{
			return false;
		}
		switch (p0)
		{
		case DCDirection.Left:
		{
			((XTextElement)xTextTableCellElement).z0xrk().BorderLeft = p1;
			((XTextElement)xTextTableCellElement).z0xrk().BorderLeftColor = p2;
			XTextTableCellElement xTextTableCellElement4 = z0gr().z0nek(xTextTableCellElement.z0pek(), xTextTableCellElement.z0xek() - 1, p2: false);
			if (xTextTableCellElement4 != null)
			{
				if (xTextTableCellElement4.z0hrk() != null)
				{
					xTextTableCellElement4 = xTextTableCellElement4.z0hrk();
				}
				((XTextElement)xTextTableCellElement4).z0xrk().BorderRight = p1;
				((XTextElement)xTextTableCellElement4).z0xrk().BorderRightColor = p2;
			}
			break;
		}
		case DCDirection.Top:
		{
			((XTextElement)xTextTableCellElement).z0xrk().BorderTop = p1;
			((XTextElement)xTextTableCellElement).z0xrk().BorderTopColor = p2;
			XTextTableCellElement xTextTableCellElement5 = z0gr().z0nek(xTextTableCellElement.z0pek() - 1, xTextTableCellElement.z0xek(), p2: false);
			if (xTextTableCellElement5 != null)
			{
				if (xTextTableCellElement5.z0hrk() != null)
				{
					xTextTableCellElement5 = xTextTableCellElement5.z0hrk();
				}
				((XTextElement)xTextTableCellElement5).z0xrk().BorderBottom = p1;
				((XTextElement)xTextTableCellElement5).z0xrk().BorderBottomColor = p2;
			}
			break;
		}
		case DCDirection.Right:
		{
			((XTextElement)xTextTableCellElement).z0xrk().BorderRight = p1;
			((XTextElement)xTextTableCellElement).z0xrk().BorderRightColor = p2;
			XTextTableCellElement xTextTableCellElement3 = z0gr().z0nek(xTextTableCellElement.z0pek(), xTextTableCellElement.z0xek() + 1, p2: false);
			if (xTextTableCellElement3 != null)
			{
				if (xTextTableCellElement3.z0hrk() != null)
				{
					xTextTableCellElement3 = xTextTableCellElement3.z0hrk();
				}
				((XTextElement)xTextTableCellElement3).z0xrk().BorderLeft = p1;
				((XTextElement)xTextTableCellElement3).z0xrk().BorderLeftColor = p2;
			}
			break;
		}
		case DCDirection.Bottom:
		{
			((XTextElement)xTextTableCellElement).z0xrk().BorderBottom = p1;
			((XTextElement)xTextTableCellElement).z0xrk().BorderBottomColor = p2;
			XTextTableCellElement xTextTableCellElement2 = z0gr().z0nek(xTextTableCellElement.z0pek() + 1, xTextTableCellElement.z0xek(), p2: false);
			if (xTextTableCellElement2 != null)
			{
				if (xTextTableCellElement2.z0hrk() != null)
				{
					xTextTableCellElement2 = xTextTableCellElement2.z0hrk();
				}
				((XTextElement)xTextTableCellElement2).z0xrk().BorderTop = p1;
				((XTextElement)xTextTableCellElement2).z0xrk().BorderTopColor = p2;
			}
			break;
		}
		}
		xTextTableCellElement.z0jo();
		return true;
	}

	public bool z0rek()
	{
		return z0iyk();
	}

	public new void z0rek(bool p0)
	{
		z0wrk(p0);
	}

	public new void z0tek(bool p0)
	{
		z0lrk(p0);
	}

	internal bool z0rek(z0ZzZzwrj p0, z0ZzZzbik p1, z0ZzZzvxj p2)
	{
		if (p0 != null && z0rek(p0))
		{
			float num = 0f;
			if (z0cr() == VerticalAlignStyle.Top)
			{
				num = p0.z0irk() - ((XTextElement)this).z0ltk();
			}
			else if (z0cr() == VerticalAlignStyle.Bottom)
			{
				num = p0.z0qrk() - z0qyk().z0nek();
			}
			z0ZzZzlkh z0ZzZzlkh = new z0ZzZzlkh();
			z0ZzZzzlh[] array = base.z0zek();
			foreach (z0ZzZzzlh z0ZzZzzlh in array)
			{
				z0ZzZzzlh.z0nek(z0ZzZzzlh.z0zrk() + num);
				z0ZzZzzlh.z0erk();
				z0ZzZzlkh.Add(z0ZzZzzlh);
			}
			try
			{
				if (p1 == null)
				{
					if (p2 != null)
					{
						bool p3 = p2.z0rek();
						p2.z0tek(p0: false);
						try
						{
							base.z0vw(p2);
						}
						finally
						{
							p2.z0tek(p3);
						}
					}
				}
				else
				{
					p1();
				}
			}
			finally
			{
				using zzz.z0ZzZzkuk<z0ZzZzzlh>.z0bpk z0bpk = z0ZzZzlkh.z0ltk();
				while (z0bpk.MoveNext())
				{
					z0ZzZzzlh current = z0bpk.Current;
					current.z0nek(current.z0zrk() - num);
					current.z0erk();
				}
			}
			return true;
		}
		return false;
	}

	public override string z0xr()
	{
		string text = null;
		text = ((z0gr() != null || !string.IsNullOrEmpty(z0gr().ID)) ? ("Cell:" + z0gr().ID + "!" + z0oek()) : ("Cell:" + z0oek()));
		if (ID != null && ID.Length > 0)
		{
			text = text + "(" + ID + ")";
		}
		return text;
	}

	internal new void z0tek()
	{
		if (z0utk == null || z0utk.Count == 0)
		{
			return;
		}
		ContentAutoFixFontSizeMode contentAutoFixFontSizeMode = z0nek();
		if (contentAutoFixFontSizeMode == ContentAutoFixFontSizeMode.None)
		{
			z0rek(1f);
		}
		else
		{
			if (Height == 0f)
			{
				return;
			}
			using z0ZzZzjpk p = z0ru();
			z0ZzZzvxj z0ZzZzvxj = z0jr().z0bek(p, (z0ZzZzcxj)0);
			foreach (XTextElement item in z0trk().z0xrk())
			{
				if (item is XTextCharElement)
				{
					XTextCharElement xTextCharElement = (XTextCharElement)item;
					if (xTextCharElement.z0nek() != 1f)
					{
						xTextCharElement.z0rek(1f);
						z0ZzZzvxj.z0hyk = xTextCharElement;
						xTextCharElement.z0mr(z0ZzZzvxj);
					}
				}
				else if (item is XTextParagraphFlagElement)
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)item;
					xTextParagraphFlagElement.z0eek(1f);
					z0ZzZzvxj.z0hyk = xTextParagraphFlagElement;
					xTextParagraphFlagElement.z0mr(z0ZzZzvxj);
				}
			}
			switch (contentAutoFixFontSizeMode)
			{
			case ContentAutoFixFontSizeMode.MultiLine:
			{
				z0mrk = true;
				z0rek(1f);
				float num5 = Height;
				float num6 = z0si();
				if (num6 < 0f && z0ji() is XTextTableRowElement xTextTableRowElement && xTextTableRowElement.z0cek() != 0f)
				{
					num5 = Math.Abs(xTextTableRowElement.z0cek());
					num6 = num5 - z0aek().z0quk - z0aek().z0xrk;
				}
				if (num6 <= 10f)
				{
					break;
				}
				bool flag = false;
				z0ZzZzzlh[] array = base.z0zek();
				if (array == null)
				{
					break;
				}
				if (array.Length == 1 && z0si() < array[0].z0ytk() * 2f)
				{
					float num7 = 0f;
					foreach (XTextElement item2 in z0trk().z0xrk())
					{
						num7 += item2.Width;
					}
					float num8 = z0si() / array[0].z0ytk();
					float num9 = ((XTextElement)this).z0ork() / num7;
					z0rek(Math.Min(num8, num9), z0ZzZzvxj, p2: true);
				}
				else
				{
					flag = true;
				}
				if (flag || array.Length > 1)
				{
					z0ZzZzazj z0ZzZzazj = new z0ZzZzazj(null, null, z0cr());
					z0ZzZzazj.z0eek(p0: true);
					double num10 = 1.0;
					z0ZzZzzlh[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						array2[i].z0tek(p0: true);
					}
					base.z0zt(z0ZzZzazj);
					z0ZzZzazj.z0tek();
					for (int j = 0; j < 4; j++)
					{
						float num11 = base.z0cek() - z0aek().z0quk - z0aek().z0xrk;
						if (!(num11 > num6 + 10f))
						{
							break;
						}
						double num12 = 1.0 / Math.Sqrt(num11 / num6);
						num12 *= 1.0 - (double)j / 8.0;
						num10 *= num12;
						if (num12 > 0.9)
						{
							num10 *= 0.95;
						}
						z0rek((float)num10, z0ZzZzvxj, p2: true);
					}
				}
				Height = num5;
				z0jo();
				break;
			}
			case ContentAutoFixFontSizeMode.SingleLine:
			{
				z0mrk = true;
				z0rek(1f);
				float num = 1f;
				float num2 = 0f;
				float num3 = 0f;
				foreach (XTextElement item3 in z0trk().z0xrk())
				{
					if (item3 is XTextFieldBorderElement && item3.z0ji() is XTextInputFieldElementBase xTextInputFieldElementBase && xTextInputFieldElementBase.z0tek() != 0f)
					{
						num2 += ((XTextFieldBorderElement)item3).z0tek();
						continue;
					}
					num2 += item3.Width;
					if (item3 is XTextCharElement)
					{
						num3 += item3.Width;
					}
				}
				float num4 = num2 - ((XTextElement)this).z0ork();
				if (num4 > 0f && num3 > 0f)
				{
					num = (num3 - num4) / num3;
					if (num < 0.3f)
					{
						num = 0.3f;
					}
				}
				if ((double)num < 1.0)
				{
					z0rek(num, z0ZzZzvxj, p2: true);
				}
				z0rek(num);
				break;
			}
			}
		}
	}

	public new int z0rek(int p0)
	{
		if (z0xek() + p0 - 1 >= z0gr().z0srk().Count)
		{
			p0 = z0gr().z0srk().Count - z0xek();
		}
		if (p0 < 1)
		{
			p0 = 1;
		}
		return p0;
	}

	public new XTextTableCellElement z0yek()
	{
		XTextTableCellElement xTextTableCellElement = this;
		if (xTextTableCellElement.z0hrk() != null)
		{
			xTextTableCellElement = xTextTableCellElement.z0hrk();
		}
		if (z0gr() != null)
		{
			XTextTableCellElement xTextTableCellElement2 = z0gr().z0nek(xTextTableCellElement.z0pek() - 1, xTextTableCellElement.z0xek(), p2: false);
			if (xTextTableCellElement2 != null && xTextTableCellElement2.z0hrk() != null)
			{
				xTextTableCellElement2 = xTextTableCellElement2.z0hrk();
			}
			return xTextTableCellElement2;
		}
		return null;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0irk = null;
		z0prk = null;
	}

	internal void z0rek(z0ZzZzvxj p0, bool p1)
	{
		if (z0rik == null || z0etk == null || z0etk.Length == 0)
		{
			return;
		}
		DocumentViewOptions documentViewOptions = p0.z0rtk;
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		if (!p1)
		{
			RectangleSlantSplitStyle slantSplitLineStyle = SlantSplitLineStyle;
			if (slantSplitLineStyle != RectangleSlantSplitStyle.None && z0ZzZzrzj.z0wrk)
			{
				using z0ZzZzudh z0ZzZzudh = z0ZzZzrzj.z0eek();
				if (p0.z0zrk)
				{
					z0ZzZzudh.z0eek(Color.Black);
				}
				z0ZzZzbdh p2 = z0qyk();
				if (z0yrk > 0f && z0yrk < p2.z0iek())
				{
					p2.z0yek(z0yrk);
				}
				z0ZzZzgmk.z0eek(p0.z0gyk, p2, z0ZzZzudh, slantSplitLineStyle);
			}
		}
		if (p0.z0byk == (z0ZzZzcxj)0 && documentViewOptions.ShowExpressionFlag && !string.IsNullOrEmpty(ValueExpression))
		{
			z0ZzZzbdh z0ZzZzbdh = z0qyk();
			float num = z0jr().z0xek((float)z0vek().z0iek());
			p0.z0gyk.z0eek(z0vek(), z0ZzZzbdh.z0mek() - num, z0ZzZzbdh.z0nek() - num);
		}
		base.z0vw(p0);
		if (MirrorViewForCrossPage)
		{
			z0rek(p0.z0lrk(), null, p0);
		}
		if (p0.z0byk != 0 || !documentViewOptions.ShowBackgroundCellID)
		{
			return;
		}
		z0ZzZzbdh z0ZzZzbdh2 = z0qyk();
		if (!p0.z0hrk().z0bek())
		{
			z0ZzZzbdh2 = z0ZzZzbdh.z0tek(z0ZzZzbdh2, p0.z0hrk());
		}
		float num2 = p0.z0eek(z0ZzZzimk.z0oek);
		z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh();
		VerticalAlignStyle verticalAlignStyle = z0ZzZzrzj.z0srk;
		z0ZzZzlsh.z0rek(StringAlignment.Center);
		z0ZzZzlsh.z0eek(StringAlignment.Center);
		if (z0be().Count > 1)
		{
			z0ZzZzzlh z0ZzZzzlh = base.z0zek()[0];
			if (z0ZzZzzlh != null)
			{
				if (z0ZzZzzlh.z0zrk() > num2)
				{
					z0ZzZzbdh2.z0yek(z0ZzZzzlh.z0zrk());
				}
				else
				{
					switch (verticalAlignStyle)
					{
					case VerticalAlignStyle.Top:
						z0ZzZzlsh.z0eek(StringAlignment.Center);
						break;
					case VerticalAlignStyle.Middle:
						z0ZzZzlsh.z0eek(StringAlignment.Near);
						break;
					case VerticalAlignStyle.Bottom:
						z0ZzZzlsh.z0eek(StringAlignment.Near);
						break;
					}
				}
			}
		}
		z0ZzZzlsh.z0eek((z0ZzZzksh)4096);
		string text = z0oek();
		if (!string.IsNullOrEmpty(ValueExpression))
		{
			text = text + "=" + ValueExpression;
		}
		p0.z0gyk.DrawString(text, z0ZzZzimk.z0oek, z0ZzZzyfh.z0bek, z0ZzZzbdh2, z0ZzZzlsh);
	}

	public override XTextDocument z0ee_jiejie20260327142557(bool p0)
	{
		if (z0gr() == null)
		{
			return null;
		}
		if (p0)
		{
			XTextTableElement xTextTableElement = (XTextTableElement)z0gr().z0lr(p0: false);
			xTextTableElement.z0bt(z0jr());
			xTextTableElement.z0mek(new XTextElementList());
			XTextTableColumnElement xTextTableColumnElement = new XTextTableColumnElement();
			xTextTableColumnElement.Width = Width;
			xTextTableElement.z0srk().Add(xTextTableColumnElement);
			xTextTableElement.z0te(new XTextElementList());
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0krk().z0lr(p0: false);
			xTextTableElement.z0stk().Add(xTextTableRowElement);
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0lr(p0: true);
			xTextTableCellElement.z0trk = 1;
			xTextTableCellElement.z0erk = 1;
			xTextTableRowElement.z0rek().Add(xTextTableCellElement);
			xTextTableElement.z0li();
			XTextDocument result = z0ZzZzafh.z0yek(z0jr(), new XTextElementList(xTextTableElement), p2: false);
			xTextTableElement.Dispose();
			return result;
		}
		return base.z0ee_jiejie20260327142557(p0: false);
	}

	public override XTextTableElement z0gr()
	{
		if (z0uik == null)
		{
			return null;
		}
		return (XTextTableElement)z0uik.z0ji();
	}

	public override VerticalAlignStyle z0cr()
	{
		return z0aek().z0srk;
	}

	public bool z0rek(z0ZzZzwrj p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (MirrorViewForCrossPage)
		{
			if (base.z0zek() == null || base.z0zek().Length == 0)
			{
				return false;
			}
			if (z0atk() == PageContentPartyStyle.Body)
			{
				if (z0cr() == VerticalAlignStyle.Top)
				{
					z0ZzZzzlh z0ZzZzzlh = base.z0zek().z0uek();
					float num = 0f;
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzzlh).z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							XTextElement current = z0bpk.Current;
							num = Math.Max(num, current.z0yt() + current.Height);
						}
					}
					if (z0ZzZzzlh.z0xrk() + num < p0.z0irk() + 4f)
					{
						return true;
					}
				}
				else if (z0cr() == VerticalAlignStyle.Bottom && (double)base.z0zek()[0].z0xrk() > (double)p0.z0qrk() - 0.1)
				{
					return true;
				}
			}
		}
		return false;
	}

	public void z0rek(string p0)
	{
		ToolTip = p0;
	}

	public new XTextTableColumnElement z0uek()
	{
		XTextTableElement xTextTableElement = z0gr();
		if (xTextTableElement == null)
		{
			return null;
		}
		return (XTextTableColumnElement)xTextTableElement.z0srk().SafeGet(z0tr() + z0erk - 1);
	}

	public override float z0he()
	{
		if (z0krk() == null)
		{
			return z0it();
		}
		return ((XTextElement)z0krk()).z0zrk() + z0it();
	}

	public override bool z0vr()
	{
		return z0mek();
	}

	public new void z0yek(bool p0)
	{
		if (p0 != (AutoFixFontSizeMode != ContentAutoFixFontSizeMode.None))
		{
			if (p0)
			{
				AutoFixFontSizeMode = ContentAutoFixFontSizeMode.SingleLine;
			}
			else
			{
				AutoFixFontSizeMode = ContentAutoFixFontSizeMode.None;
			}
		}
	}

	public override ValueValidateStyle z0br()
	{
		return base.ValidateStyle;
	}

	public bool z0rek(int p0, int p1, bool p2)
	{
		if (p0 < 1 || p1 < 1)
		{
			return false;
		}
		if (p0 == 1 && p1 == 1)
		{
			return false;
		}
		bool flag = false;
		if (RowSpan > 1)
		{
			int[] array = z0ZzZzmpk.z0rek(RowSpan);
			for (int i = 0; i < array.Length; i++)
			{
				if (p0 == array[i])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		XTextTableElement xTextTableElement = z0gr();
		xTextTableElement.z0li();
		z0ZzZzelh z0ZzZzelh = null;
		if (p2)
		{
			z0ZzZzelh = new z0ZzZzelh();
			z0ZzZzelh.z0eek(new z0ZzZzmzj(xTextTableElement, p1: true));
		}
		XTextDocument xTextDocument = z0jr();
		bool flag2 = false;
		int num = z0pek();
		int num2 = z0xek();
		int colSpan = ColSpan;
		int num3 = RowSpan / p0;
		int num4 = RowSpan;
		if (num4 == 1)
		{
			num3 = 1;
		}
		float width = Width;
		if (p0 == RowSpan && p1 == ColSpan)
		{
			XTextTableCellElement[] array2 = xTextTableElement.z0pek(z0pek(), z0xek(), RowSpan, ColSpan, p4: true);
			foreach (XTextTableCellElement obj in array2)
			{
				obj.z0tek(1);
				obj.z0yek(1);
				obj.z0rek((XTextTableCellElement)null);
				obj.Width = 0f;
				obj.Height = 0f;
				obj.z0xi(p0: true);
			}
			flag2 = true;
		}
		else
		{
			if (p0 > 1)
			{
				if (num4 == 1)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextTableElement.z0stk()[num];
					float num5 = xTextTableRowElement.z0cek();
					if (num5 > 0f)
					{
						num5 = (xTextTableRowElement.SpecifyHeight = num5 / (float)p0);
					}
					for (int k = 1; k < p0; k++)
					{
						XTextTableRowElement xTextTableRowElement2 = xTextTableElement.z0nrk();
						xTextTableRowElement2.SpecifyHeight = num5;
						xTextTableRowElement2.z0oek(((XTextElement)xTextTableRowElement).z0pek());
						xTextTableRowElement2.HeaderStyle = xTextTableRowElement.HeaderStyle;
						xTextTableRowElement2.z0yek(xTextDocument, xTextTableElement);
						using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement.z0rek().z0ltk())
						{
							while (z0bpk.MoveNext())
							{
								XTextTableCellElement p3 = (XTextTableCellElement)z0bpk.Current;
								XTextTableCellElement xTextTableCellElement = xTextTableElement.z0pek(p3);
								xTextTableCellElement.z0yek(xTextDocument, xTextTableRowElement2);
								xTextTableCellElement.Width = 0f;
								xTextTableCellElement.Height = 0f;
								xTextTableCellElement.z0xi(p0: true);
								xTextTableCellElement.z0yek(1);
								xTextTableCellElement.z0tek(1);
								xTextTableCellElement.z0gu();
								xTextTableRowElement2.z0rek().Add(xTextTableCellElement);
							}
						}
						xTextTableElement.z0stk().z0oek(num + 1, xTextTableRowElement2);
					}
					List<XTextTableCellElement> list = new List<XTextTableCellElement>();
					for (int l = 0; l < xTextTableElement.z0srk().Count; l++)
					{
						XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextTableRowElement.z0rek()[l];
						if (xTextTableCellElement2.z0hrk() != null)
						{
							xTextTableCellElement2 = xTextTableCellElement2.z0hrk();
						}
						if (!list.Contains(xTextTableCellElement2))
						{
							list.Add(xTextTableCellElement2);
							if (l < num2 || l >= num2 + colSpan)
							{
								xTextTableCellElement2.z0yek(xTextTableCellElement2.RowSpan + p0 - 1);
								xTextTableCellElement2.Width = 0f;
							}
						}
					}
					num4 = num3;
				}
				else
				{
					for (int m = 0; m < num4; m++)
					{
						XTextTableRowElement xTextTableRowElement3 = (XTextTableRowElement)xTextTableElement.z0stk()[num + m];
						for (int n = 0; n < ColSpan; n++)
						{
							XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)xTextTableRowElement3.z0rek()[num2 + n];
							if (m % p0 == 0)
							{
								xTextTableCellElement3.z0yek(num3);
							}
							else
							{
								xTextTableCellElement3.z0yek(1);
							}
							xTextTableCellElement3.Width = 0f;
							xTextTableCellElement3.Height = 0f;
						}
					}
				}
				flag2 = true;
			}
			if (p1 == ColSpan)
			{
				if (ColSpan > 1)
				{
					XTextTableCellElement[] array2 = xTextTableElement.z0pek(z0pek(), z0xek(), num4, ColSpan, p4: true);
					foreach (XTextTableCellElement xTextTableCellElement4 in array2)
					{
						xTextTableCellElement4.z0tek(1);
						xTextTableCellElement4.Width = 0f;
						xTextTableCellElement4.Height = 0f;
						if (xTextTableCellElement4.z0pek() == z0pek())
						{
							xTextTableCellElement4.z0yek(num3);
						}
						xTextTableCellElement4.z0xi(p0: true);
					}
					flag2 = true;
				}
			}
			else
			{
				flag2 = true;
				List<z0wxk> list2 = new List<z0wxk>();
				float num7 = 0f;
				for (int num8 = 0; num8 < ColSpan; num8++)
				{
					XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)xTextTableElement.z0srk()[num8 + num2];
					z0wxk z0wxk = new z0wxk();
					z0wxk.z0eek_jiejie20260327142557 = num7;
					z0wxk.z0yek = xTextTableColumnElement.Width;
					z0wxk.z0rek = xTextTableColumnElement;
					list2.Add(z0wxk);
					num7 += xTextTableColumnElement.Width;
				}
				float num9 = width / (float)p1;
				for (int num10 = 0; num10 < p1; num10++)
				{
					float num11 = num9 * (float)num10;
					bool flag3 = false;
					for (int num12 = 0; num12 < list2.Count; num12++)
					{
						if ((double)Math.Abs(num11 - list2[num12].z0eek_jiejie20260327142557) < (double)num9 * 0.2)
						{
							list2[num12].z0uek = true;
							num11 = list2[num12].z0eek_jiejie20260327142557;
							flag3 = true;
							break;
						}
					}
					if (!flag3)
					{
						z0wxk z0wxk2 = new z0wxk();
						z0wxk2.z0eek_jiejie20260327142557 = num11;
						z0wxk2.z0uek = true;
						list2.Add(z0wxk2);
					}
				}
				list2.Sort();
				for (int num13 = 0; num13 < list2.Count; num13++)
				{
					list2[num13].z0iek = num13;
					if (num13 > 0)
					{
						list2[num13 - 1].z0yek = list2[num13].z0eek_jiejie20260327142557 - list2[num13 - 1].z0eek_jiejie20260327142557;
					}
				}
				list2[list2.Count - 1].z0yek = width - list2[list2.Count - 1].z0eek_jiejie20260327142557;
				z0wxk z0wxk3 = null;
				for (int num14 = 0; num14 < list2.Count; num14++)
				{
					z0wxk z0wxk4 = list2[num14];
					XTextTableColumnElement xTextTableColumnElement2 = xTextTableElement.z0vek();
					xTextTableColumnElement2.z0yek(xTextDocument, xTextTableElement);
					xTextTableColumnElement2.Width = z0wxk4.z0yek;
					xTextTableColumnElement2.z0mek = new XTextElementList();
					z0wxk4.z0tek = xTextTableColumnElement2;
					if (z0wxk4.z0rek != null)
					{
						using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0wxk4.z0rek.z0eek().z0ltk())
						{
							while (z0bpk.MoveNext())
							{
								XTextTableCellElement element = (XTextTableCellElement)z0bpk.Current;
								xTextTableColumnElement2.z0mek.Add(element);
							}
						}
						z0wxk3 = z0wxk4;
					}
					else
					{
						XTextElementList xTextElementList = z0wxk3.z0rek.z0eek();
						using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
						while (z0bpk.MoveNext())
						{
							XTextTableCellElement xTextTableCellElement5 = (XTextTableCellElement)z0bpk.Current;
							XTextTableCellElement xTextTableCellElement6 = xTextTableElement.z0pek(xTextTableCellElement5);
							xTextTableCellElement6.z0yek(xTextDocument, xTextTableCellElement5.z0ji());
							((zzz.z0ZzZzkuk<XTextElement>)xTextTableColumnElement2.z0mek).z0pek((XTextElement)xTextTableCellElement6);
							int num15 = xTextElementList.IndexOf(xTextTableCellElement5);
							if (num15 >= num && num15 < num + p0)
							{
								continue;
							}
							if (xTextTableCellElement5.z0hrk() != null)
							{
								XTextTableCellElement xTextTableCellElement7 = xTextTableCellElement5.z0hrk();
								if (xTextTableCellElement7.z0krk() == xTextTableCellElement5.z0krk())
								{
									xTextTableCellElement7.z0tek(xTextTableCellElement7.ColSpan + 1);
								}
							}
							else
							{
								xTextTableCellElement5.z0tek(xTextTableCellElement5.ColSpan + 1);
							}
						}
					}
					if (!z0wxk4.z0uek)
					{
						continue;
					}
					if (num14 == list2.Count - 1)
					{
						for (int num16 = num; num16 < num + p0; num16++)
						{
							XTextTableCellElement obj2 = (XTextTableCellElement)z0wxk4.z0tek.z0mek[num16];
							obj2.z0tek(1);
							obj2.Width = 0f;
						}
					}
					else
					{
						for (int num17 = num14 + 1; num17 < list2.Count; num17++)
						{
							int num18 = -1;
							if (num17 == list2.Count - 1)
							{
								num18 = num17 - num14;
								if (p1 < colSpan && !list2[num17].z0uek)
								{
									num18++;
								}
							}
							else if (list2[num17].z0uek)
							{
								num18 = num17 - num14;
							}
							if (num18 > 0)
							{
								for (int num19 = num; num19 < num + p0; num19++)
								{
									XTextTableCellElement obj3 = (XTextTableCellElement)z0wxk4.z0tek.z0mek[num19];
									obj3.z0tek(num18);
									obj3.Width = 0f;
								}
							}
							if (num18 > 0)
							{
								break;
							}
						}
					}
					for (int num20 = num; num20 < num + num4; num20 += num3)
					{
						XTextTableCellElement obj4 = (XTextTableCellElement)z0wxk4.z0tek.z0mek[num20];
						obj4.z0yek(num3);
						obj4.Width = 0f;
					}
				}
				using (z0ZzZzjpk p4 = xTextDocument.z0ru())
				{
					z0ZzZzvxj z0ZzZzvxj = xTextDocument.z0bek(p4, (z0ZzZzcxj)0);
					for (int num21 = 0; num21 < list2.Count; num21++)
					{
						z0wxk z0wxk5 = list2[num21];
						if (!z0wxk5.z0uek)
						{
							continue;
						}
						using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0wxk5.z0tek.z0mek.z0ltk();
						while (z0bpk.MoveNext())
						{
							XTextTableCellElement xTextTableCellElement8 = (XTextTableCellElement)z0bpk.Current;
							if (xTextTableCellElement8.z0bek())
							{
								z0ZzZzvxj.z0hyk = xTextTableCellElement8;
								xTextTableCellElement8.z0gu();
								xTextTableCellElement8.z0mr(z0ZzZzvxj);
							}
						}
					}
				}
				for (int num22 = num2 + colSpan - 1; num22 >= num2; num22--)
				{
					xTextTableElement.z0srk().z0bek(num22);
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0stk().z0ltk();
					while (z0bpk.MoveNext())
					{
						((XTextTableRowElement)z0bpk.Current).z0rek().z0bek(num22);
					}
				}
				for (int num23 = 0; num23 < list2.Count; num23++)
				{
					XTextTableColumnElement xTextTableColumnElement3 = list2[num23].z0tek;
					xTextTableElement.z0srk().Insert(num2 + num23, xTextTableColumnElement3);
					for (int num24 = 0; num24 < xTextTableElement.z0stk().Count; num24++)
					{
						XTextTableRowElement obj5 = (XTextTableRowElement)xTextTableElement.z0stk()[num24];
						XTextTableCellElement element2 = (XTextTableCellElement)xTextTableColumnElement3.z0mek[num24];
						obj5.z0rek().Insert(num2 + num23, element2);
					}
					xTextTableColumnElement3.z0mek = null;
				}
			}
		}
		if (flag2)
		{
			xTextTableElement.z0li();
			((XTextElement)this).z0rrk();
			xTextTableElement.z0krk();
			if (xTextTableElement.z0grk())
			{
				xTextTableElement.z0krk();
			}
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0zek().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					((XTextTableCellElement)z0bpk.Current).z0gu();
				}
			}
			if (!z0ar(xTextDocument, p1: false))
			{
				return flag2;
			}
			XTextDocumentContentElement xTextDocumentContentElement = z0qek();
			xTextDocumentContentElement?.z0ark();
			z0bek(p0: true);
			xTextTableElement.z0jo();
			using (z0ZzZzjpk p5 = xTextDocument.z0ru())
			{
				xTextTableElement.z0pek(p5);
			}
			xTextTableElement.z0vek(p0: false);
			xTextTableElement.z0jo();
			xTextTableElement.z0mek(p0: false);
			xTextDocumentContentElement?.z0uek(z0ie().z0jrk(), z0dek().z0jrk() - z0ie().z0jrk());
			if (z0ZzZzelh != null)
			{
				z0ZzZzelh.z0rek(new z0ZzZzmzj(xTextTableElement, p1: true));
				z0ZzZzelh.z0eek();
				if (xTextDocument.z0ytk())
				{
					xTextDocument.z0bek(z0ZzZzelh);
					xTextDocument.z0nuk();
					xTextDocument.OnSelectionChanged();
					xTextDocument.OnDocumentContentChanged();
				}
			}
		}
		return flag2;
	}

	public bool z0eek(int p0, int p1, bool p2, Dictionary<XTextTableCellElement, XTextElementList> p3)
	{
		p0 = z0uek(p0);
		p1 = z0rek(p1);
		if (p0 == RowSpan && p1 == ColSpan)
		{
			return false;
		}
		z0ZzZzelh z0ZzZzelh = null;
		if (p2)
		{
			z0ZzZzelh = new z0ZzZzelh();
			z0ZzZzelh.z0eek(new z0ZzZzmzj(z0gr(), p1: true));
		}
		XTextTableElement xTextTableElement = z0gr();
		XTextDocument xTextDocument = z0jr();
		DocumentContentStyle documentContentStyle = z0aek().z0yek();
		documentContentStyle.z0eek(p0: true);
		bool flag = false;
		if (ColSpan < p1)
		{
			XTextTableCellElement xTextTableCellElement = xTextTableElement.z0nek(z0pek(), z0xek() + p1 - 1, p2: false);
			if (xTextTableCellElement != null && !xTextTableCellElement.z0bek())
			{
				documentContentStyle.BorderRight = xTextTableCellElement.z0aek().z0etk;
				documentContentStyle.BorderRightColor = xTextTableCellElement.z0aek().z0grk;
				flag = true;
			}
		}
		if (RowSpan < p0)
		{
			XTextTableCellElement xTextTableCellElement2 = xTextTableElement.z0nek(z0pek() + p0 - 1, z0xek(), p2: false);
			if (xTextTableCellElement2 != null && !xTextTableCellElement2.z0bek())
			{
				documentContentStyle.BorderBottom = xTextTableCellElement2.z0aek().z0mrk;
				documentContentStyle.BorderBottomColor = xTextTableCellElement2.z0aek().z0trk;
				flag = true;
			}
		}
		int num = ((XTextElement)this).z0pek();
		int num2 = num;
		if (flag)
		{
			num2 = xTextDocument.z0gnk().GetStyleIndex(documentContentStyle);
		}
		if (p3 != null)
		{
			foreach (XTextTableCellElement key in p3.Keys)
			{
				XTextElementList p4 = p3[key];
				key.z0be().Clear();
				((zzz.z0ZzZzkuk<XTextElement>)key.z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)p4);
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = key.z0be().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						z0bpk.Current.z0yek(xTextDocument, key);
					}
				}
				key.z0bek(p0: false);
				key.Width = 0f;
			}
		}
		else
		{
			XTextTableCellElement[] array = xTextTableElement.z0pek(z0pek(), z0xek(), z0trk, z0erk, p4: true);
			XTextTableCellElement[] array2 = xTextTableElement.z0pek(z0pek(), z0xek(), p0, p1, p4: true);
			XTextTableCellElement[] array3 = array;
			foreach (XTextTableCellElement xTextTableCellElement3 in array3)
			{
				if (Array.IndexOf(array2, xTextTableCellElement3) < 0)
				{
					xTextTableCellElement3.z0bek(p0: false);
					xTextTableCellElement3.Width = 0f;
				}
			}
			XTextElementList xTextElementList = new XTextElementList();
			array3 = array2;
			foreach (XTextTableCellElement xTextTableCellElement4 in array3)
			{
				if (xTextTableCellElement4 != this && xTextTableCellElement4.z0hrk() == null && xTextTableCellElement4.z0be().Count > 1)
				{
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextTableCellElement4.z0be());
					xTextTableCellElement4.z0be().Clear();
					xTextTableCellElement4.Width = 0f;
					xTextTableCellElement4.z0bek(p0: false);
				}
			}
			for (int num3 = xTextElementList.Count - 2; num3 >= 0; num3--)
			{
				if (xTextElementList[num3] is XTextParagraphFlagElement && ((XTextParagraphFlagElement)xTextElementList[num3]).z0vek())
				{
					xTextElementList.z0bek(num3);
				}
			}
			((zzz.z0ZzZzkuk<XTextElement>)z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList);
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			while (z0bpk.MoveNext())
			{
				z0bpk.Current.z0nu(this);
			}
		}
		z0trk = p0;
		z0erk = p1;
		z0oek(num2);
		Width = 0f;
		((XTextElement)this).z0rrk();
		xTextTableElement.z0krk();
		if (xTextTableElement.z0grk())
		{
			xTextTableElement.z0krk();
		}
		z0bek(p0: true);
		z0qek().z0uek(z0ie().z0jrk(), z0dek().z0jrk() - z0ie().z0jrk());
		xTextTableElement.z0jo();
		xTextTableElement.z0ct();
		xTextTableElement.z0mek(p0: true);
		xTextTableElement.z0jo();
		xTextTableElement.z0mek(p0: false);
		if (z0ZzZzelh != null)
		{
			z0ZzZzelh.z0rek(new z0ZzZzmzj(xTextTableElement, p1: true));
			z0ZzZzelh.z0eek();
			if (xTextDocument.z0ytk())
			{
				if (num != num2)
				{
					xTextDocument.z0imk().z0eek(this, num, num2);
				}
				xTextDocument.z0bek(z0ZzZzelh);
				xTextDocument.z0nuk();
				xTextDocument.OnSelectionChanged();
				xTextDocument.OnDocumentContentChanged();
			}
		}
		return true;
	}

	public override string z0nr()
	{
		return z0oek();
	}

	public override string z0ge()
	{
		if (string.IsNullOrEmpty(ID))
		{
			return z0oek();
		}
		return z0oek() + "-" + ID;
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		z0nek(p0: true);
		base.z0mr(p0);
	}

	public new int z0iek()
	{
		return z0trk;
	}

	public new string z0oek()
	{
		if (z0uik?.z0ji() is XTextTableElement)
		{
			return z0ZzZzryk.z0rek(z0nrk + 1, z0muk + 1);
		}
		return string.Empty;
	}

	public override void z0qi(bool p0)
	{
		z0cuk = p0;
	}

	private void z0rek(float p0, z0ZzZzvxj p1, bool p2)
	{
		if (p0 >= 1f)
		{
			p0 = 1f;
		}
		p0 = (float)Math.Round(p0, 3);
		bool flag = false;
		foreach (XTextElement item in z0trk().z0xrk())
		{
			if (item is XTextCharElement)
			{
				XTextCharElement xTextCharElement = (XTextCharElement)item;
				if (xTextCharElement.z0nek() != p0)
				{
					xTextCharElement.z0rek(p0);
					p1.z0hyk = xTextCharElement;
					xTextCharElement.z0mr(p1);
					flag = true;
				}
			}
			else if (item is XTextParagraphFlagElement)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)item;
				if (xTextParagraphFlagElement.z0pek() != p0)
				{
					xTextParagraphFlagElement.z0eek(p0);
					p1.z0hyk = xTextParagraphFlagElement;
					xTextParagraphFlagElement.z0mr(p1);
					flag = true;
				}
			}
		}
		z0rek(p0);
		if (!(p2 && flag))
		{
			return;
		}
		z0ZzZzazj z0ZzZzazj = new z0ZzZzazj(null, null, z0cr());
		z0ZzZzazj.z0eek(p0: true);
		if (z0etk != null && z0etk.Length != 0)
		{
			z0ZzZzzlh[] array = z0etk;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].z0tek(p0: true);
			}
		}
		base.z0zt(z0ZzZzazj);
		z0ZzZzazj.z0tek();
	}

	public new int z0pek()
	{
		return z0nrk;
	}

	public new bool z0mek()
	{
		return z0otk();
	}

	public override int z0je()
	{
		if (z0krk() == null)
		{
			return -1;
		}
		return z0krk().z0je();
	}

	public override bool z0pr()
	{
		return true;
	}

	public override bool z0or(bool p0, bool p1, bool p2)
	{
		return false;
	}

	public void z0rek(XTextTableColumnElement p0)
	{
		z0prk = p0;
	}

	public override float z0cw()
	{
		if (z0ji() is XTextTableRowElement xTextTableRowElement && xTextTableRowElement.z0ji() is XTextTableElement xTextTableElement)
		{
			return ((XTextElement)xTextTableElement).z0ltk() + xTextTableRowElement.z0yt();
		}
		return 0f;
	}

	public override void z0ir(int p0)
	{
		base.z0ir(p0);
	}

	private new ContentAutoFixFontSizeMode z0nek()
	{
		if (AutoFixFontSizeMode == ContentAutoFixFontSizeMode.None)
		{
			return ContentAutoFixFontSizeMode.None;
		}
		return AutoFixFontSizeMode;
	}

	public new void z0uek(bool p0)
	{
		z0qrk(p0);
	}

	internal void z0rek(bool p0, z0ZzZzazj p1)
	{
		base.z0grk();
		XTextElementList xTextElementList = z0utk;
		if (z0etk != null || xTextElementList != null || !z0rik.z0snk())
		{
			if (xTextElementList != null && ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk() == ((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0krk())
			{
				xTextElementList.z0frk();
				xTextElementList.z0dtk();
			}
			if (z0trk().Count == 1)
			{
				z0utk[0].z0kik = null;
			}
			else
			{
				z0utk.z0drk();
			}
		}
		z0qek().z0ark();
		if (p1 == null)
		{
			p1 = new z0ZzZzazj(null, null, z0aek().z0srk);
			p1.z0eek(p0);
		}
		if (z0zt(p1) && Height > 0f)
		{
			z0eek(z0cr(), p1: true, p2: true);
		}
		z0xi(p0: false);
	}

	internal void z0rek(XTextTableCellElement p0)
	{
		z0irk = p0;
	}

	public override void z0ly()
	{
	}

	public new bool z0bek()
	{
		return z0irk != null;
	}

	private new static z0ZzZzrfh z0vek()
	{
		if (z0urk == null)
		{
			z0urk = z0ZzZzpmk.z0eek((object)z0ZzZzgfh.z0iek);
			z0urk.z0eek(Color.Red);
		}
		return z0urk;
	}

	public new string z0cek()
	{
		return ValueExpression;
	}

	public override bool z0ur(z0kgj p0)
	{
		if (z0bek())
		{
			return false;
		}
		XTextTableColumnElement xTextTableColumnElement = z0drk();
		if (xTextTableColumnElement != null && !xTextTableColumnElement.Visible)
		{
			return false;
		}
		return base.z0ur(p0);
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextTableCellElement obj = (XTextTableCellElement)base.z0lr(p0);
		obj.z0prk = null;
		obj.z0irk = null;
		return obj;
	}

	public new int z0xek()
	{
		return z0muk;
	}

	public void z0tek(int p0)
	{
		z0erk = Math.Max(p0, 1);
	}

	public override z0ZzZzzej z0ju()
	{
		z0ZzZzzej z0ZzZzzej = base.z0ju();
		if (z0ZzZzzej != null)
		{
			return z0ZzZzzej;
		}
		return null;
	}

	public new string z0zek()
	{
		return ToolTip;
	}

	public new bool z0lrk()
	{
		return z0qek()?.z0oek().z0tek(this) ?? false;
	}

	public new XTextTableRowElement z0krk()
	{
		return (XTextTableRowElement)z0uik;
	}

	public new void z0yek(int p0)
	{
		z0trk = Math.Max(p0, 1);
	}

	public void z0tek(string p0)
	{
		ValueExpression = p0;
	}

	public bool z0rek(float p0, bool p1)
	{
		float minTableColumnWidth = z0iu().MinTableColumnWidth;
		if (Math.Abs(p0 - Width) < minTableColumnWidth / 5f)
		{
			return false;
		}
		XTextTableElement xTextTableElement = z0gr();
		if (z0xek() + ColSpan >= xTextTableElement.z0srk().Count)
		{
			return false;
		}
		XTextTableRowElement xTextTableRowElement = z0krk();
		if (p0 > Width)
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.z0rek()[z0xek() + ColSpan];
			if (xTextTableCellElement.z0hrk() != null)
			{
				xTextTableCellElement = xTextTableCellElement.z0hrk();
			}
			p0 = Math.Min(p0, xTextTableCellElement.Width + Width - minTableColumnWidth);
		}
		if (p0 < minTableColumnWidth)
		{
			p0 = minTableColumnWidth;
		}
		int num = -1;
		for (int i = 0; i < RowSpan; i++)
		{
			XTextTableCellElement xTextTableCellElement2 = xTextTableElement.z0nek(i + z0pek(), z0xek() + ColSpan, p2: true);
			if (xTextTableCellElement2.z0bek())
			{
				xTextTableCellElement2 = xTextTableCellElement2.z0hrk();
			}
			if (xTextTableCellElement2.z0pek() < z0pek())
			{
				return false;
			}
			if (xTextTableCellElement2.z0pek() + xTextTableCellElement2.RowSpan > z0pek() + RowSpan)
			{
				return false;
			}
			num = ((!(p0 < Width)) ? ((num != -1) ? Math.Min(num, xTextTableCellElement2.z0xek() + xTextTableCellElement2.ColSpan) : (xTextTableCellElement2.z0xek() + xTextTableCellElement2.ColSpan)) : ((num != -1) ? Math.Min(num, xTextTableCellElement2.z0xek() + xTextTableCellElement2.ColSpan) : (xTextTableCellElement2.z0xek() + xTextTableCellElement2.ColSpan)));
		}
		if (num >= xTextTableElement.z0srk().Count)
		{
			num = xTextTableElement.z0srk().Count - 1;
		}
		z0ZzZzelh z0ZzZzelh = null;
		if (p1)
		{
			z0ZzZzelh = new z0ZzZzelh();
			z0ZzZzelh.z0eek(new z0ZzZzmzj(xTextTableElement, p1: false));
		}
		float num2 = 0f;
		bool flag = false;
		for (int j = z0xek(); j <= num; j++)
		{
			num2 += xTextTableElement.z0srk()[j].Width;
			if (Math.Abs(num2 - p0) < minTableColumnWidth * 0.4f)
			{
				if (j + 1 < xTextTableElement.z0srk().Count)
				{
					for (int k = 0; k < RowSpan; k++)
					{
						XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)xTextTableElement.z0stk()[k + z0pek()];
						XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)xTextTableRowElement2.z0rek()[z0xek() + ColSpan];
						int num3 = xTextTableCellElement3.z0xek() + xTextTableCellElement3.ColSpan;
						xTextTableRowElement2.z0rek().z0nek(xTextTableRowElement2.z0rek().IndexOf(xTextTableCellElement3), j + 1);
						xTextTableCellElement3.z0tek(num3 - j - 1);
					}
					z0tek(j - z0xek() + 1);
					flag = true;
				}
				break;
			}
			if (!(num2 > p0))
			{
				continue;
			}
			XTextTableColumnElement xTextTableColumnElement = xTextTableElement.z0vek();
			xTextTableColumnElement.Width = num2 - p0;
			((XTextTableColumnElement)xTextTableElement.z0srk()[j]).Width -= xTextTableColumnElement.Width;
			using (z0ZzZzjpk p2 = xTextTableElement.z0ru())
			{
				for (int l = 0; l < xTextTableElement.z0stk().Count; l++)
				{
					XTextTableRowElement xTextTableRowElement3 = (XTextTableRowElement)xTextTableElement.z0stk()[l];
					XTextTableCellElement xTextTableCellElement4 = xTextTableElement.z0urk();
					xTextTableCellElement4.z0bt(z0jr());
					xTextTableCellElement4.z0oek(((XTextElement)this).z0pek());
					xTextTableCellElement4.z0gu();
					z0ZzZzvxj z0ZzZzvxj = xTextTableElement.z0jr().z0bek(p2, (z0ZzZzcxj)0);
					z0ZzZzvxj.z0hyk = xTextTableCellElement4;
					xTextTableCellElement4.z0mr(z0ZzZzvxj);
					xTextTableCellElement4.Width = 0f;
					xTextTableCellElement4.Height = 0f;
					xTextTableCellElement4.z0nu(xTextTableRowElement3);
					xTextTableCellElement4.z0bt(z0jr());
					xTextTableRowElement3.z0rek().Insert(j + 1, xTextTableCellElement4);
					xTextTableRowElement3.z0li();
				}
			}
			xTextTableElement.z0srk().Insert(j + 1, xTextTableColumnElement);
			for (int m = 0; m < xTextTableElement.z0stk().Count; m++)
			{
				XTextTableRowElement xTextTableRowElement4 = (XTextTableRowElement)xTextTableElement.z0stk()[m];
				if (m < z0pek() || m >= z0pek() + RowSpan)
				{
					XTextTableCellElement xTextTableCellElement5 = (XTextTableCellElement)xTextTableRowElement4.z0rek()[j];
					if (xTextTableCellElement5.z0bek())
					{
						xTextTableCellElement5 = ((xTextTableCellElement5.z0pek() != xTextTableCellElement5.z0hrk().z0pek()) ? null : xTextTableCellElement5.z0hrk());
					}
					xTextTableCellElement5?.z0tek(xTextTableCellElement5.ColSpan + 1);
				}
				else if (p0 > Width)
				{
					XTextTableCellElement xTextTableCellElement6 = (XTextTableCellElement)xTextTableRowElement4.z0rek()[z0xek() + ColSpan];
					int num4 = xTextTableCellElement6.z0xek() + xTextTableCellElement6.ColSpan;
					xTextTableRowElement4.z0rek().z0nek(xTextTableRowElement4.z0rek().IndexOf(xTextTableCellElement6), j + 1);
					xTextTableCellElement6.z0tek(num4 - xTextTableRowElement4.z0rek().IndexOf(xTextTableCellElement6) + 1);
				}
				else
				{
					XTextTableCellElement xTextTableCellElement7 = (XTextTableCellElement)xTextTableRowElement4.z0rek()[z0xek() + ColSpan + 1];
					int num5 = xTextTableCellElement7.z0xek() + xTextTableCellElement7.ColSpan;
					xTextTableRowElement4.z0rek().z0nek(xTextTableRowElement4.z0rek().IndexOf(xTextTableCellElement7), j + 1);
					xTextTableCellElement7.z0tek(num5 - j - 1);
				}
			}
			if (p0 > Width)
			{
				z0tek(j - z0xek() + 1);
			}
			else
			{
				z0tek(j - z0xek() + 1);
			}
			flag = true;
			break;
		}
		if (flag)
		{
			xTextTableElement.z0li();
			((XTextElement)this).z0rrk();
			xTextTableElement.z0krk();
			if (xTextTableElement.z0grk())
			{
				xTextTableElement.z0krk();
			}
			z0bek(p0: true);
			xTextTableElement.z0jo();
			using (z0ZzZzjpk p3 = z0ru())
			{
				xTextTableElement.z0pek(p3);
			}
			xTextTableElement.z0ct();
			xTextTableElement.z0jo();
			xTextTableElement.z0mek(p0: false);
			z0qek().z0uek(z0ie().z0jrk(), z0dek().z0jrk() - z0ie().z0jrk() + 1);
			if (z0ZzZzelh != null)
			{
				z0ZzZzelh.z0rek(new z0ZzZzmzj(xTextTableElement, p1: false));
				z0ZzZzelh.z0eek();
				if (z0jr().z0ytk())
				{
					z0jr().z0bek(z0ZzZzelh);
					z0jr().z0nuk();
				}
			}
			z0jr().OnSelectionChanged();
			z0jr().OnDocumentContentChanged();
		}
		return flag;
	}

	public override string z0pe()
	{
		return "cell";
	}

	public new bool z0jrk()
	{
		return z0zyk();
	}

	public new XTextTableCellElement z0hrk()
	{
		return z0irk;
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		p0.z0eek((byte)z0trk);
		p0.z0eek((byte)z0erk);
		p0.z0eek((byte)SlantSplitLineStyle);
	}

	public override void z0yr(MoveFocusHotKeys p0)
	{
	}

	public new int z0uek(int p0)
	{
		if (p0 < 1)
		{
			p0 = 1;
		}
		if (z0pek() + p0 - 1 >= z0gr().z0stk().Count)
		{
			p0 = z0gr().z0stk().Count - z0pek();
		}
		return p0;
	}

	public XTextTableCellElement()
	{
		z0tek(p0: true);
	}

	public new XTextTableCellElement z0grk()
	{
		XTextTableRowElement xTextTableRowElement = z0krk();
		if (xTextTableRowElement != null)
		{
			xTextTableRowElement = (XTextTableRowElement)((XTextTableElement)xTextTableRowElement.z0ji()).z0stk().SafeGet(z0nrk + z0trk);
			if (xTextTableRowElement != null && xTextTableRowElement.z0rek() != null)
			{
				XTextTableCellElement xTextTableCellElement = xTextTableRowElement.z0rek().SafeGet(z0xek()) as XTextTableCellElement;
				if (xTextTableCellElement != null && xTextTableCellElement.z0irk != null)
				{
					xTextTableCellElement = xTextTableCellElement.z0irk;
				}
				return xTextTableCellElement;
			}
		}
		return null;
	}

	public new XTextTableRowElement z0frk()
	{
		XTextTableElement xTextTableElement = z0gr();
		if (xTextTableElement == null)
		{
			return null;
		}
		return (XTextTableRowElement)xTextTableElement.z0crk().SafeGet(z0ji().z0tr() + RowSpan - 1);
	}

	public override void z0ct()
	{
		z0rek(p0: false, null);
	}

	public XTextTableCellElement z0rek(TableRowCloneType p0)
	{
		if (z0rrk == null)
		{
			throw new NotSupportedException("EditorCloneSpecifyCloneType");
		}
		return z0rrk(this, p0);
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		z0rek(p0, p1: false);
	}

	public override bool z0hr()
	{
		if (z0gr() == null)
		{
			return false;
		}
		XTextTableCellElement xTextTableCellElement = this;
		if (xTextTableCellElement.z0bek())
		{
			xTextTableCellElement = xTextTableCellElement.z0hrk();
		}
		int p = xTextTableCellElement.z0ie().z0jrk();
		int p2 = xTextTableCellElement.z0dek().z0jrk();
		xTextTableCellElement.z0qek().z0sr();
		z0jr().z0btk();
		return xTextTableCellElement.z0qek().z0tek(p, p2);
	}

	public override int z0tr()
	{
		if (z0uik == null)
		{
			return -1;
		}
		XTextElementList xTextElementList = z0uik.z0be();
		if (z0muk >= 0 && z0muk < xTextElementList.Count && xTextElementList[z0muk] == this)
		{
			return z0muk;
		}
		return xTextElementList.IndexOf(this);
	}

	public override void z0rr(ContentChangedEventArgs p0)
	{
		if (z0drk() != null && !p0.LoadingDocument && z0jr().z0puk())
		{
			z0drk().Modified = true;
		}
		base.z0rr(p0);
	}

	public new XTextTableColumnElement z0drk()
	{
		if (z0prk == null)
		{
			XTextTableElement xTextTableElement = z0gr();
			if (xTextTableElement != null)
			{
				z0prk = (XTextTableColumnElement)xTextTableElement.z0srk().SafeGet(z0tr());
			}
		}
		return z0prk;
	}

	public new XTextTableCellElement z0srk()
	{
		TableRowCloneType cloneType = CloneType;
		if (cloneType == TableRowCloneType.Default && z0krk() != null)
		{
			cloneType = z0krk().CloneType;
		}
		return z0rek(cloneType);
	}

	public new XTextTableCellElement z0ark()
	{
		XTextTableCellElement xTextTableCellElement = this;
		if (xTextTableCellElement.z0hrk() != null)
		{
			xTextTableCellElement = xTextTableCellElement.z0hrk();
		}
		XTextTableRowElement xTextTableRowElement = xTextTableCellElement.z0krk();
		if (xTextTableRowElement != null && xTextTableCellElement.z0xek() > 0)
		{
			XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextTableRowElement.z0rek().SafeGet(xTextTableCellElement.z0xek() - 1);
			if (xTextTableCellElement2 != null && xTextTableCellElement2.z0hrk() != null)
			{
				xTextTableCellElement2 = xTextTableCellElement2.z0hrk();
			}
			return xTextTableCellElement2;
		}
		return null;
	}

	public override string ToString()
	{
		return z0xr();
	}

	public override z0ZzZzpdh z0zw()
	{
		if (!(z0uik is XTextTableRowElement xTextTableRowElement))
		{
			return new z0ZzZzpdh(z0it(), z0yt());
		}
		z0ZzZzpdh z0ZzZzpdh = xTextTableRowElement.z0zw();
		return new z0ZzZzpdh(z0ZzZzpdh.z0rek() + z0it(), z0ZzZzpdh.z0tek() + z0yt());
	}

	protected internal override void z0er(z0ZzZzvxj p0)
	{
		if (p0.z0byk != (z0ZzZzcxj)3 || z0krk().PrintCellBorder)
		{
			base.z0er(p0);
		}
	}

	public new XTextTableCellElement z0qrk()
	{
		XTextTableCellElement xTextTableCellElement = this;
		if (xTextTableCellElement.z0irk != null)
		{
			xTextTableCellElement = xTextTableCellElement.z0irk;
		}
		XTextElementList xTextElementList = z0uik?.z0be();
		int num = z0xek() + z0erk;
		if (xTextElementList != null && num >= 0 && num < xTextElementList.Count)
		{
			XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextElementList[num];
			if (xTextTableCellElement2 != null && xTextTableCellElement2.z0irk != null)
			{
				xTextTableCellElement2 = xTextTableCellElement2.z0irk;
			}
			return xTextTableCellElement2;
		}
		return null;
	}

	public new bool z0wrk()
	{
		return AutoFixFontSizeMode != ContentAutoFixFontSizeMode.None;
	}

	public override bool z0yi()
	{
		if (z0irk == null)
		{
			return z0cuk;
		}
		return false;
	}

	public override MoveFocusHotKeys z0wr()
	{
		MoveFocusHotKeys moveFocusHotKeys = MoveFocusHotKey;
		if (moveFocusHotKeys == MoveFocusHotKeys.Default && z0jr() != null && z0jr().z0yyk() != null)
		{
			moveFocusHotKeys = z0jr().z0yyk().z0jik();
		}
		if (moveFocusHotKeys == MoveFocusHotKeys.Default)
		{
			moveFocusHotKeys = MoveFocusHotKeys.None;
		}
		return moveFocusHotKeys;
	}
}
