using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using DCSoft.Common;
using DCSoft.WinForms;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

public abstract class XTextContainerElement : XTextElement, z0ZzZzixj, z0ZzZzbxj
{
	internal class z0apk_jiejie20260327142557
	{
		public z0ZzZztlh z0eek;

		public CopySourceInfo z0rek;

		public ElementType z0tek = ElementType.All;

		public ContentAutoFixFontSizeMode z0yek_jiejie20260327142557;

		public string z0uek;

		public TableRowCloneType z0iek;

		public string z0oek;

		public ElementVisibility z0pek;

		public int z0mek;

		public XTextElement[] z0nek;

		public string z0bek;

		public ValueValidateStyle z0vek;

		public string z0cek;

		public PropertyExpressionInfoList z0xek;

		public DCBooleanValue z0zek = DCBooleanValue.Inherit;

		internal float z0lrk = 1f;

		public List<XTextInputFieldElementBase> z0krk;

		public DCContentLockInfo z0jrk;

		public virtual void z0bwk()
		{
			z0rek = null;
			z0jrk = null;
			z0vek = null;
			z0cek = null;
			z0bek = null;
			z0oek = null;
			if (z0xek != null)
			{
				z0xek.Clear();
				z0xek.Owner = null;
				z0xek = null;
			}
			z0nek = null;
			if (z0krk != null)
			{
				z0krk.Clear();
				z0krk = null;
			}
		}

		public virtual z0apk_jiejie20260327142557 z0vwk()
		{
			z0apk_jiejie20260327142557 z0apk_jiejie20260327142557 = (z0apk_jiejie20260327142557)MemberwiseClone();
			if (z0rek != null)
			{
				z0apk_jiejie20260327142557.z0rek = z0rek.z0rek();
			}
			if (z0jrk != null)
			{
				z0apk_jiejie20260327142557.z0jrk = z0jrk.z0eek();
			}
			if (z0vek != null)
			{
				z0apk_jiejie20260327142557.z0vek = z0vek.Clone();
			}
			if (z0xek != null)
			{
				z0apk_jiejie20260327142557.z0xek = z0xek.Clone();
			}
			z0apk_jiejie20260327142557.z0nek = null;
			z0apk_jiejie20260327142557.z0krk = null;
			return z0apk_jiejie20260327142557;
		}
	}

	public class z0kgj
	{
		public bool z0rek;

		private readonly int z0tek_jiejie20260327142557;

		private readonly bool[] z0yek;

		public readonly bool z0uek;

		internal static z0kgj z0iek;

		public readonly bool z0oek;

		public readonly bool z0pek;

		public bool z0mek;

		public readonly XTextDocument z0nek;

		public bool z0eek(int p0)
		{
			if (p0 >= 0 && p0 < z0tek_jiejie20260327142557)
			{
				return z0yek[p0];
			}
			return false;
		}

		public static z0kgj z0eek(XTextDocument p0, bool p1)
		{
			if (z0iek == null || z0iek.z0nek != p0)
			{
				return new z0kgj(p0, p1);
			}
			z0iek.z0mek = p1;
			return z0iek;
		}

		internal z0kgj(XTextDocument p0, bool p1)
		{
			if (p0 == null)
			{
				throw new ArgumentNullException("document");
			}
			z0nek = p0;
			DocumentContentStyleContainer documentContentStyleContainer = z0nek.z0gnk();
			z0uek = z0nek.z0hi().ShowLogicDeletedContent;
			z0oek = z0nek.z0bu().DesignMode;
			z0mek = p1;
			z0rek = z0nek.z0qtk().Printing;
			z0pek = z0nek.z0qtk().RenderMode == DocumentRenderMode.ReadPaint;
			z0tek_jiejie20260327142557 = 0;
			if (!z0uek)
			{
				z0yek = documentContentStyleContainer.z0eek();
				if (z0yek != null && z0yek.Length != 0)
				{
					z0tek_jiejie20260327142557 = z0yek.Length;
				}
				else
				{
					z0yek = null;
				}
			}
			else
			{
				z0yek = null;
			}
		}
	}

	public class z0eok_jiejie20260327142557 : IDisposable
	{
		internal bool z0rek;

		public readonly bool z0tek;

		public readonly bool z0yek;

		public List<XTextInputFieldElementBase> z0uek;

		public XTextElementList z0iek;

		public readonly bool z0oek;

		[ThreadStatic]
		internal static z0eok_jiejie20260327142557 z0pek;

		public readonly DocumentRenderMode z0mek;

		public readonly bool z0nek;

		public bool z0bek;

		public readonly bool z0vek;

		public bool z0cek;

		public readonly bool z0xek;

		public DCBooleanValue z0zek = DCBooleanValue.False;

		public readonly DCRenderVisibility z0lrk;

		public readonly bool z0krk;

		public readonly bool z0jrk;

		public XTextDocument z0hrk;

		internal z0eok_jiejie20260327142557(z0eok_jiejie20260327142557 p0, bool p1)
		{
			z0tek = p0.z0tek;
			z0iek = p0.z0iek;
			z0vek = p0.z0vek;
			z0hrk = p0.z0hrk;
			z0uek = p0.z0uek;
			z0bek = p0.z0bek;
			z0cek = p0.z0cek;
			z0xek = p0.z0xek;
			z0zek = p0.z0zek;
			z0yek = p0.z0yek;
			z0nek = p0.z0nek;
			z0oek = p0.z0oek;
			z0jrk = p0.z0jrk;
			z0krk = p0.z0krk;
			z0mek = p0.z0mek;
			z0lrk = p0.z0lrk;
			if (p1)
			{
				z0jrk = true;
				z0mek = DocumentRenderMode.ReadPaint;
				if (z0lrk == DCRenderVisibility.Hidden || z0lrk == DCRenderVisibility.Visible)
				{
					z0tek = true;
				}
				else
				{
					z0tek = false;
				}
			}
		}

		public bool z0eek(DCBooleanValue p0)
		{
			return p0 switch
			{
				DCBooleanValue.Inherit => z0oek, 
				DCBooleanValue.True => true, 
				DCBooleanValue.False => false, 
				_ => z0oek, 
			};
		}

		public void Dispose()
		{
			z0hrk = null;
			z0iek = null;
			z0uek = null;
		}

		internal z0eok_jiejie20260327142557(XTextDocument p0, XTextElementList p1, bool p2)
		{
			if (p0 == null)
			{
				throw new ArgumentNullException("document");
			}
			if (p1 == null)
			{
				throw new ArgumentNullException("list");
			}
			z0hrk = p0;
			z0iek = p1;
			z0krk = p2;
			if (z0pek != null && z0pek.z0hrk == p0)
			{
				z0yek = z0pek.z0yek;
				z0jrk = z0pek.z0jrk;
				z0lrk = z0pek.z0lrk;
				z0nek = z0pek.z0nek;
				z0oek = z0pek.z0oek;
				z0tek = z0pek.z0tek;
				z0mek = z0pek.z0mek;
				z0vek = z0pek.z0vek;
				z0xek = z0pek.z0xek;
				return;
			}
			z0jrk = p0.z0tyk();
			z0yek = z0jrk;
			DocumentViewOptions documentViewOptions = p0.z0iu();
			z0lrk = documentViewOptions.z0eek_jiejie20260327142557();
			z0nek = documentViewOptions.PreserveBackgroundTextWhenPrint;
			z0oek = documentViewOptions.PrintBackgroundText;
			z0tek = true;
			if (z0jrk)
			{
				if (z0lrk == DCRenderVisibility.Hidden || z0lrk == DCRenderVisibility.Visible)
				{
					z0tek = true;
				}
				else
				{
					z0tek = false;
				}
			}
			z0mek = p0.z0qtk().RenderMode;
			z0vek = p0.z0bu().DesignMode;
			z0xek = z0ZzZzxcj.z0eek(167);
		}

		internal static void z0eek(XTextDocument p0)
		{
			if (p0 == null)
			{
				z0pek = null;
			}
			else
			{
				z0pek = new z0eok_jiejie20260327142557(p0, new XTextElementList(), p2: false);
			}
		}
	}

	private new static zzz.z0ZzZzkuk<XTextElement> z0stk = new zzz.z0ZzZzkuk<XTextElement>();

	internal new XAttributeList z0atk;

	[NonSerialized]
	internal new int z0qtk;

	private new bool z0wtk = true;

	internal new ContentReadonlyState z0etk = ContentReadonlyState.Inherit;

	[NonSerialized]
	private new int z0rtk = -1;

	public new static Action<ContentChangingEventArgs> z0ttk = null;

	internal new IList<XTextElement> z0ytk;

	internal new z0apk_jiejie20260327142557 z0utk;

	[NonSerialized]
	internal new z0ZzZzqcj z0itk;

	[ThreadStatic]
	private new static zzz.z0ZzZzyik<XTextElement> z0otk;

	private new string z0ptk;

	public new static Action<ContentChangedEventArgs> z0mtk = null;

	protected internal new XTextElementList z0ntk;

	internal new static bool z0btk = true;

	[z0ZzZzbjh(MemberEffectLevel.DOM)]
	[DefaultValue(DCBooleanValue.Inherit)]
	public virtual DCBooleanValue EnablePermission
	{
		get
		{
			if (z0utk == null)
			{
				return DCBooleanValue.Inherit;
			}
			return z0utk.z0zek;
		}
		set
		{
			if (value == DCBooleanValue.Inherit)
			{
				if (z0utk != null)
				{
					z0utk.z0zek = value;
				}
			}
			else
			{
				z0prk().z0zek = value;
			}
		}
	}

	[DefaultValue(null)]
	public virtual string ValueExpression
	{
		get
		{
			return z0utk?.z0xek?.GetValue(z0ZzZzkfh.z0ftk);
		}
		set
		{
			z0cek(z0ZzZzkfh.z0ftk, value);
		}
	}

	[DefaultValue(null)]
	public virtual string ContentReadonlyExpression
	{
		get
		{
			return z0utk?.z0xek?.GetValue(z0ZzZzkfh.z0erk);
		}
		set
		{
			z0cek(z0ZzZzkfh.z0erk, value);
		}
	}

	public DCContentLockInfo ContentLock
	{
		get
		{
			return z0utk?.z0jrk;
		}
		set
		{
			if (value == null)
			{
				if (z0utk != null)
				{
					z0utk.z0jrk = null;
				}
			}
			else
			{
				z0prk().z0jrk = value;
			}
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.DOM)]
	[DefaultValue(ElementVisibility.Visible)]
	public virtual ElementVisibility PrintVisibility
	{
		get
		{
			if (z0utk == null)
			{
				return ElementVisibility.Visible;
			}
			return z0utk.z0pek;
		}
		set
		{
			if (value == ElementVisibility.Visible)
			{
				if (z0utk != null)
				{
					z0utk.z0pek = value;
				}
			}
			else
			{
				z0prk().z0pek = value;
			}
		}
	}

	[DefaultValue(ContentReadonlyState.Inherit)]
	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	public ContentReadonlyState ContentReadonly
	{
		get
		{
			return z0etk;
		}
		set
		{
			z0etk = value;
		}
	}

	public override string ID
	{
		get
		{
			return z0ptk;
		}
		set
		{
			z0ptk = value;
		}
	}

	[z0ZzZzuqh]
	[DefaultValue(null)]
	[z0ZzZzbjh(MemberEffectLevel.DOM)]
	public override string FormulaValue
	{
		get
		{
			return Text;
		}
		set
		{
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
			z0do(setContainerTextArgs);
		}
	}

	[DefaultValue(null)]
	public virtual z0ZzZzevj ValueBinding
	{
		get
		{
			return z0itk?.z0rek;
		}
		set
		{
			if (value == null)
			{
				if (z0itk != null)
				{
					z0itk.z0rek = null;
				}
				return;
			}
			if (z0itk == null)
			{
				z0itk = new z0ZzZzqcj();
			}
			z0itk.z0rek = value;
		}
	}

	[DefaultValue(null)]
	public virtual string PrintVisibilityExpression
	{
		get
		{
			return z0utk?.z0xek?.GetValue(z0ZzZzkfh.z0lrk);
		}
		set
		{
			z0cek(z0ZzZzkfh.z0lrk, value);
		}
	}

	[DefaultValue(true)]
	[z0ZzZzbjh(MemberEffectLevel.DOM)]
	public virtual bool Deleteable
	{
		get
		{
			return z0duk();
		}
		set
		{
			z0zrk(value);
		}
	}

	[DefaultValue(null)]
	[z0ZzZzrqh("Item", typeof(PropertyExpressionInfo))]
	public virtual PropertyExpressionInfoList PropertyExpressions
	{
		get
		{
			return z0utk?.z0xek;
		}
		set
		{
			if (value == null)
			{
				if (z0utk != null)
				{
					z0utk.z0xek = null;
				}
			}
			else
			{
				z0prk().z0xek = value;
			}
		}
	}

	public virtual bool AcceptTab
	{
		get
		{
			return base.z0zek();
		}
		set
		{
			z0trk(value);
		}
	}

	[DefaultValue(null)]
	public override XAttributeList Attributes
	{
		get
		{
			return z0atk;
		}
		set
		{
			z0atk = value;
		}
	}

	public virtual ElementType AcceptChildElementTypes2
	{
		get
		{
			return ElementType.All;
		}
		set
		{
		}
	}

	[DefaultValue(null)]
	public virtual CopySourceInfo CopySource
	{
		get
		{
			return z0utk?.z0rek;
		}
		set
		{
			if (value == null)
			{
				if (z0utk != null)
				{
					z0utk.z0rek = null;
				}
			}
			else
			{
				z0prk().z0rek = value;
			}
			z0oek();
		}
	}

	[z0ZzZzuqh]
	[z0ZzZzbjh(MemberEffectLevel.DOM)]
	public override bool Modified
	{
		get
		{
			return z0vyk();
		}
		set
		{
			z0pek(value);
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[z0ZzZzuqh]
	public override string Text
	{
		get
		{
			if (z0ntk == null || z0ntk.Count == 0)
			{
				return string.Empty;
			}
			z0ygj z0ygj = new z0ygj(z0rik, p1: false, p2: false, z0ntk.Count);
			z0bw_jiejie20260327142557(z0ygj);
			return z0ygj.ToString();
		}
		set
		{
			string text = Text;
			if (((text == null || text.Length == 0) && (value == null || value.Length == 0)) || text == value)
			{
				return;
			}
			if (z0ji() == null)
			{
				z0zek(value);
				return;
			}
			if (z0xu())
			{
				z0zek(value);
			}
			XTextDocument xTextDocument = z0jr();
			if (xTextDocument != null && xTextDocument.z0dtk() != (z0ZzZzzcj)3 && !xTextDocument.z0frk())
			{
				z0zek(value);
				return;
			}
			if (string.IsNullOrEmpty(value))
			{
				z0ZzZzezj z0ZzZzezj = new z0ZzZzezj(this, 0, z0be().Count, null, p4: true, p5: true, p6: true);
				z0ZzZzezj.z0eek((z0ZzZzbcj)0);
				z0ZzZzezj.z0mek(p0: false);
				z0ZzZzezj.z0pek(p0: true);
				xTextDocument.z0bek(z0ZzZzezj);
				return;
			}
			DocumentContentStyle documentContentStyle = null;
			if (z0crk())
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0be().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					if (current is XTextParagraphFlagElement)
					{
						documentContentStyle = current.z0xrk();
						break;
					}
				}
			}
			if (documentContentStyle == null && z0dy() != null)
			{
				documentContentStyle = z0dy().z0xrk();
			}
			if (documentContentStyle.DeleterIndex >= 0)
			{
				documentContentStyle = (DocumentContentStyle)documentContentStyle.Clone();
				documentContentStyle.DeleterIndex = -1;
			}
			XTextElementList xTextElementList = xTextDocument.z0bek(value, documentContentStyle, z0aek().z0rek());
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				z0ZzZzezj z0ZzZzezj2 = new z0ZzZzezj(this, 0, z0be().Count, xTextElementList, p4: true, p5: true, p6: true);
				z0ZzZzezj2.z0eek((z0ZzZzbcj)0);
				z0ZzZzezj2.z0mek(p0: false);
				z0ZzZzezj2.z0pek(p0: true);
				xTextDocument.z0bek(z0ZzZzezj2);
			}
		}
	}

	[z0ZzZzuqh]
	public override string InnerText
	{
		get
		{
			z0ygj z0ygj = new z0ygj(z0rik);
			z0bw_jiejie20260327142557(z0ygj);
			return z0ygj.ToString();
		}
		set
		{
			Text = value;
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(true)]
	public override bool Visible
	{
		get
		{
			return z0wtk;
		}
		set
		{
			z0wtk = value;
			z0ktk();
		}
	}

	[DefaultValue(false)]
	public virtual bool EnableValueValidate
	{
		get
		{
			return base.z0trk();
		}
		set
		{
			z0uek(value);
		}
	}

	[DefaultValue(null)]
	public string LimitedInputChars
	{
		get
		{
			return z0utk?.z0oek;
		}
		set
		{
			if (value == null || value.Length == 0)
			{
				if (z0utk != null)
				{
					z0utk.z0oek = null;
				}
			}
			else
			{
				z0prk().z0oek = value;
			}
		}
	}

	[DefaultValue(null)]
	public virtual string VisibleExpression
	{
		get
		{
			return z0utk?.z0xek?.GetValue(z0ZzZzkfh.z0ork);
		}
		set
		{
			z0cek(z0ZzZzkfh.z0ork, value);
		}
	}

	[DefaultValue(false)]
	public virtual bool HiddenPrintWhenEmpty
	{
		get
		{
			return base.z0jtk();
		}
		set
		{
			z0irk(value);
		}
	}

	[DefaultValue(null)]
	public virtual ValueValidateStyle ValidateStyle
	{
		get
		{
			return z0utk?.z0vek;
		}
		set
		{
			if (value == null)
			{
				if (z0utk != null)
				{
					z0utk.z0vek = null;
				}
			}
			else
			{
				z0prk().z0vek = value;
			}
		}
	}

	[z0ZzZzbjh]
	[DefaultValue(0)]
	public int MaxInputLength
	{
		get
		{
			if (z0utk == null)
			{
				return 0;
			}
			return z0utk.z0mek;
		}
		set
		{
			if (value == 0)
			{
				if (z0utk != null)
				{
					z0utk.z0mek = 0;
				}
			}
			else
			{
				z0prk().z0mek = value;
			}
		}
	}

	[z0ZzZzbjh]
	[DefaultValue(null)]
	public virtual string ToolTip
	{
		get
		{
			return z0utk?.z0bek;
		}
		set
		{
			if (value == null || value.Length == 0)
			{
				if (z0utk != null)
				{
					z0utk.z0bek = null;
				}
			}
			else
			{
				z0prk().z0bek = value;
			}
		}
	}

	internal new void z0cek(bool p0)
	{
		base.z0xek(p0);
	}

	public new bool z0cek()
	{
		XTextElementList xTextElementList = z0nek<XTextSignImageElement>();
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			foreach (XTextSignImageElement item in xTextElementList.z0xrk())
			{
				item.z0ji().z0be().z0krk(item);
				item.Dispose();
			}
			((XTextElement)this).z0rrk();
			z0jo();
			Modified = true;
			z0jr().Modified = true;
			ContentChangedEventArgs e = new ContentChangedEventArgs();
			e.Document = z0jr();
			e.Element = this;
			z0rr(e);
			return true;
		}
		return false;
	}

	public virtual bool z0le(bool p0)
	{
		if (this is XTextDocumentContentElement)
		{
			return false;
		}
		if (z0jr() == null)
		{
			throw new Exception(z0ZzZziok.z0pok());
		}
		if (!z0ar(z0jr(), p1: false))
		{
			return false;
		}
		XTextContainerElement xTextContainerElement = z0ji();
		int p1 = xTextContainerElement.z0be().IndexOf(this);
		XTextDocument xTextDocument = z0jr();
		if (p0)
		{
			xTextDocument.z0ytk();
		}
		z0ZzZzezj p2 = new z0ZzZzezj(xTextContainerElement, p1, 1, null, p0, p5: true, p6: true);
		int num = xTextDocument.z0bek(p2);
		if (p0)
		{
			xTextDocument.z0nuk();
		}
		if (num > 0 && !p0)
		{
			xTextDocument.z0imk().Clear();
		}
		xTextDocument.OnDocumentContentChanged();
		return num != 0;
	}

	public new void z0xek(bool p0)
	{
	}

	public new virtual int z0xek()
	{
		if (z0ntk != null)
		{
			return z0ntk.Count;
		}
		return 0;
	}

	public new virtual XTextElement z0zek()
	{
		if (z0ntk == null)
		{
			return null;
		}
		return z0ntk.LastElement;
	}

	public XTextElement z0cek(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elementType");
		}
		if (!typeof(XTextElement).IsAssignableFrom(p0))
		{
			throw new InvalidCastException(p0.FullName);
		}
		bool flag = !p0.Equals(typeof(XTextCharElement));
		foreach (XTextElement item in z0be().z0xrk())
		{
			if (flag && item is XTextCharElement)
			{
				continue;
			}
			if (p0.IsInstanceOfType(item))
			{
				return item;
			}
			if (item is XTextContainerElement)
			{
				XTextElement xTextElement = ((XTextContainerElement)item).z0cek(p0);
				if (xTextElement != null)
				{
					return xTextElement;
				}
			}
		}
		return null;
	}

	public new XTextElementList z0lrk()
	{
		return z0nek<XTextRadioBoxElement>();
	}

	public override void z0bw_jiejie20260327142557(z0ygj p0)
	{
		if (z0ntk == null || z0ntk.Count == 0)
		{
			return;
		}
		if (p0.z0oek || z0yi())
		{
			int count = z0ntk.Count;
			XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0krk();
			if (!p0.z0oek && !XTextSignImageElement.z0uek())
			{
				for (int i = 0; i < count; i++)
				{
					XTextElement xTextElement = array[i];
					if (!xTextElement.z0yi())
					{
						continue;
					}
					if (xTextElement.z0buk < 0)
					{
						xTextElement.z0bw_jiejie20260327142557(p0);
						continue;
					}
					z0ZzZzrzj z0ZzZzrzj = xTextElement.z0aek();
					if (z0ZzZzrzj == null || z0ZzZzrzj.z0jyk < 0)
					{
						xTextElement.z0bw_jiejie20260327142557(p0);
					}
				}
				return;
			}
			for (int j = 0; j < count; j++)
			{
				XTextElement xTextElement2 = array[j];
				if (xTextElement2 is XTextSignImageElement || (!p0.z0oek && !xTextElement2.z0yi()))
				{
					continue;
				}
				if (xTextElement2.z0buk < 0)
				{
					xTextElement2.z0bw_jiejie20260327142557(p0);
					continue;
				}
				z0ZzZzrzj z0ZzZzrzj2 = xTextElement2.z0aek();
				if (z0ZzZzrzj2 == null || z0ZzZzrzj2.z0jyk < 0)
				{
					xTextElement2.z0bw_jiejie20260327142557(p0);
				}
			}
			return;
		}
		int count2 = z0ntk.Count;
		XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0krk();
		for (int k = 0; k < count2; k++)
		{
			XTextElement xTextElement3 = array2[k];
			if (!(xTextElement3 is XTextSignImageElement) && (xTextElement3.z0aek() == null || xTextElement3.z0aek().z0jyk < 0))
			{
				xTextElement3.z0bw_jiejie20260327142557(p0);
			}
		}
	}

	public new string z0krk()
	{
		return Text;
	}

	internal new bool z0jrk()
	{
		return z0ayk();
	}

	public virtual MoveFocusHotKeys z0wr()
	{
		return MoveFocusHotKeys.None;
	}

	public override void z0xwk()
	{
		base.z0xwk();
		if (z0be() == null)
		{
			return;
		}
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0be().z0ltk();
		while (z0bpk.MoveNext())
		{
			z0bpk.Current.z0xwk();
		}
	}

	public virtual bool z0gt()
	{
		return base.z0grk();
	}

	internal virtual IList<XTextElement> z0xe()
	{
		z0kr();
		return z0ytk;
	}

	public virtual ValueValidateStyle z0br()
	{
		if (z0utk?.z0vek != null && z0ZzZzxcj.z0eek(178))
		{
			return z0utk?.z0vek;
		}
		return null;
	}

	public virtual XTextElementList z0go(string p0, DocumentContentStyle p1)
	{
		return z0yy(p0, p1, p2: true);
	}

	internal void z0cek(string p0, XTextElementList p1, bool p2)
	{
		z0kr();
		IList<XTextElement> list = z0ytk;
		if (list == null)
		{
			return;
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = list[i];
			if (p2 && xTextElement.ID == p0)
			{
				p1.z0hrk(xTextElement);
			}
			if (xTextElement is XTextContainerElement xTextContainerElement)
			{
				if (xTextContainerElement.z0crk())
				{
					xTextContainerElement.z0cek(p0, p1, p2);
				}
				if (xTextElement is XTextInputFieldElementBase && ((XTextInputFieldElementBase)xTextElement).Name == p0)
				{
					p1.z0hrk(xTextElement);
				}
			}
			else if (xTextElement is XTextObjectElement && ((XTextObjectElement)xTextElement).Name == p0)
			{
				p1.z0hrk(xTextElement);
			}
		}
	}

	internal new void z0zek(bool p0)
	{
		z0crk(p0);
	}

	public override bool z0gek()
	{
		if (z0atk != null)
		{
			return z0atk.Count > 0;
		}
		return false;
	}

	public virtual z0ZzZzrzj z0cek(XTextElement p0)
	{
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		if (z0ZzZzrzj != null && z0ZzZzrzj.z0duk)
		{
			return z0ZzZzrzj;
		}
		return null;
	}

	internal virtual bool z0ae()
	{
		return base.z0yrk();
	}

	public virtual void z0ct()
	{
	}

	public virtual int z0ue(z0eok_jiejie20260327142557 p0)
	{
		if (z0rik == null)
		{
			return 0;
		}
		if (!p0.z0krk && z0rtk == z0qtk && z0rik.z0bek(this))
		{
			((zzz.z0ZzZzkuk<XTextElement>)p0.z0iek).z0tek((zzz.z0ZzZzkuk<XTextElement>)z0be());
			p0.z0zek = DCBooleanValue.Inherit;
			return z0be().Count;
		}
		z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = null;
		if (!p0.z0rek)
		{
			z0eok_jiejie20260327142557 = p0;
			p0 = XTextSectionElement.z0eek(this, p0);
			if (z0eok_jiejie20260327142557 == p0)
			{
				z0eok_jiejie20260327142557 = null;
			}
		}
		XTextElementList xTextElementList = p0.z0iek;
		int count = xTextElementList.Count;
		bool flag = p0.z0krk;
		bool flag2 = p0.z0jrk;
		XTextElementList xTextElementList2 = z0be();
		int count2 = xTextElementList2.Count;
		int num = 0;
		if (z0otk == null)
		{
			z0otk = new zzz.z0ZzZzyik<XTextElement>();
		}
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2).z0krk();
		xTextElementList.z0yrk(xTextElementList.Count + count2);
		if (false)
		{
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2);
		}
		else
		{
			bool p1 = false;
			if (p0.z0mek == DocumentRenderMode.ReadPaint || p0.z0yek)
			{
				p1 = true;
			}
			for (int i = 0; i < count2; i++)
			{
				XTextElement xTextElement = array[i];
				if (xTextElement.z0cuk && (xTextElement is XTextCharElement || xTextElement is XTextParagraphFlagElement))
				{
					continue;
				}
				if (xTextElement is XTextObjectElement)
				{
					p0.z0zek = DCBooleanValue.True;
					if (flag2)
					{
						if (xTextElement.z0hek(p1) && (!(xTextElement is XTextCheckBoxElementBase) || !((XTextCheckBoxElementBase)xTextElement).CaptionFlowLayout))
						{
							continue;
						}
					}
					else if (xTextElement.z0cuk && (!(xTextElement is XTextCheckBoxElementBase) || !((XTextCheckBoxElementBase)xTextElement).CaptionFlowLayout))
					{
						continue;
					}
				}
				if (i > num)
				{
					z0otk.z0eek(xTextElementList2, num, i - num);
					xTextElementList.z0tek(z0otk);
				}
				num = i + 1;
				if (flag2)
				{
					if (!xTextElement.z0hek(p1))
					{
						continue;
					}
				}
				else if (!xTextElement.z0cuk)
				{
					continue;
				}
				if (xTextElement is XTextContainerElement)
				{
					if (xTextElement is XTextTableElement)
					{
						if (flag)
						{
							((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(xTextElement);
							continue;
						}
						XTextTableElement xTextTableElement = (XTextTableElement)xTextElement;
						if (!((XTextContainerElement)xTextTableElement).z0crk())
						{
							continue;
						}
						if (XTextSectionElement.z0eek(xTextTableElement))
						{
							xTextTableElement.z0qrk();
						}
						XTextElementList xTextElementList3 = xTextTableElement.z0crk();
						int count3 = xTextElementList3.Count;
						XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList3).z0krk();
						for (int j = 0; j < count3; j++)
						{
							XTextElementList xTextElementList4 = array2[j].z0be();
							int count4 = xTextElementList4.Count;
							XTextElement[] array3 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList4).z0krk();
							for (int k = 0; k < count4; k++)
							{
								XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array3[k];
								if (xTextTableCellElement.z0yi())
								{
									xTextTableCellElement.z0ue(p0);
								}
							}
						}
					}
					else if (xTextElement is XTextSectionElement)
					{
						XTextSectionElement xTextSectionElement = (XTextSectionElement)xTextElement;
						if (xTextSectionElement.z0rek())
						{
							((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(xTextElement);
						}
						else if (flag)
						{
							((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(xTextElement);
						}
						else
						{
							xTextSectionElement.z0ue(p0);
						}
					}
					else
					{
						XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement;
						if (!flag2 || !xTextContainerElement.HiddenPrintWhenEmpty || xTextContainerElement.z0crk())
						{
							xTextContainerElement.z0ue(p0);
						}
					}
				}
				else if (xTextElement is XTextCheckBoxElementBase)
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)xTextElement;
					if (xTextCheckBoxElementBase.CaptionFlowLayout && xTextCheckBoxElementBase.z0eek(p0) > 0)
					{
						continue;
					}
					if (flag2)
					{
						if (xTextCheckBoxElementBase.Checked || xTextCheckBoxElementBase.z0bek() != PrintVisibilityModeWhenUnchecked.HiddenAll)
						{
							((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(xTextElement);
						}
					}
					else
					{
						((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(xTextElement);
					}
				}
				else
				{
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(xTextElement);
				}
			}
			if (count2 > num)
			{
				if (count2 - num == 1)
				{
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(xTextElementList2[num]);
				}
				else if (num == 0)
				{
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2);
				}
				else
				{
					z0otk.z0rek(xTextElementList2, num, count2 - num);
					xTextElementList.z0tek(z0otk);
				}
			}
			z0otk.z0iek();
		}
		count = xTextElementList.Count - count;
		if (!p0.z0krk && count == z0be().Count && z0rik.z0bek(this))
		{
			z0rtk = z0qtk;
			int num2 = xTextElementList.Count - count;
			for (int num3 = count - 1; num3 >= 0; num3--)
			{
				if (xTextElementList.z0yek(num3 + num2) != z0ntk.z0yek(num3))
				{
					z0rtk = -1;
					break;
				}
			}
		}
		z0drk(count > 0);
		if (z0eok_jiejie20260327142557 != null)
		{
			z0eok_jiejie20260327142557.z0cek = p0.z0cek;
			z0eok_jiejie20260327142557.z0uek = p0.z0uek;
			z0eok_jiejie20260327142557.z0zek = p0.z0zek;
		}
		return count;
	}

	public virtual bool z0vr()
	{
		return false;
	}

	internal XTextElement z0cek(string p0, bool p1, bool p2)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		Dictionary<int, int> dictionary = null;
		if (!p2)
		{
			dictionary = z0jr().z0gnk().z0tek();
			if (dictionary.Count == 0)
			{
				dictionary = null;
			}
		}
		XTextElement p3 = null;
		XTextElement xTextElement = z0bek_jiejie20260327142557(this, p0, p1, dictionary, ref p3);
		if (xTextElement != null)
		{
			return xTextElement;
		}
		return p3;
	}

	public virtual bool z0qo()
	{
		return true;
	}

	public virtual XTextElement z0fe(int p0)
	{
		XTextElementList xTextElementList = z0ntk;
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			z0kr();
			if (z0ytk != null)
			{
				IList<XTextElement> list = z0ytk;
				for (int num = list.Count - 1; num >= 0; num--)
				{
					if (list[num].GetHashCode() == p0)
					{
						return list[num];
					}
					if (list[num] is XTextContainerElement xTextContainerElement)
					{
						XTextElement xTextElement = xTextContainerElement.z0fe(p0);
						if (xTextElement != null)
						{
							return xTextElement;
						}
					}
				}
			}
		}
		return null;
	}

	public virtual XTextElementList z0yu(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		XTextElementList xTextElementList = new XTextElementList();
		z0cek(p0, xTextElementList, p2: true);
		return xTextElementList;
	}

	public virtual XTextElement z0ki(string p0)
	{
		return z0cek(p0, p1: false);
	}

	public virtual XTextElementList z0ve()
	{
		XTextElementList xTextElementList = new XTextElementList();
		z0cek(this, xTextElementList, p2: true);
		return xTextElementList;
	}

	public override int z0kek()
	{
		return z0qtk;
	}

	public new bool z0hrk()
	{
		return z0itk?.z0rek != null;
	}

	public new bool z0grk()
	{
		if (z0itk == null)
		{
			return false;
		}
		return z0itk.z0iek;
	}

	public virtual bool z0ne(int p0, XTextElement p1)
	{
		if (p1 != null)
		{
			p1.z0uek(this);
			if (!z0ntk.Contains(p1))
			{
				z0ntk.Insert(p0, p1);
			}
			return true;
		}
		return false;
	}

	protected XTextContainerElement()
	{
		z0ntk = new XTextElementList();
		Deleteable = true;
		EnableValueValidate = false;
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		if (z0atk == null || z0atk.Count == 0)
		{
			p0.z0eek((short)0);
		}
		else
		{
			p0.z0eek((short)z0atk.Count);
			using zzz.z0ZzZzkuk<XAttribute>.z0bpk z0bpk = z0atk.z0ltk();
			while (z0bpk.MoveNext())
			{
				XAttribute current = z0bpk.Current;
				p0.z0eek(current.Name);
				p0.z0eek(current.Value);
			}
		}
		p0.z0eek(z0ht());
		p0.z0eek(ToolTip);
		p0.z0eek((byte)z0etk);
		z0ZzZzevj z0ZzZzevj = z0itk?.z0rek;
		if (z0ZzZzevj == null)
		{
			p0.z0eek(0);
			return;
		}
		p0.z0eek(0);
		p0.z0eek(z0ZzZzevj.DataSource);
		p0.z0eek(z0ZzZzevj.BindingPath);
	}

	public new z0ZzZztlh z0frk()
	{
		return z0utk?.z0eek;
	}

	public virtual void z0jt(bool p0)
	{
		z0bek(p0);
	}

	internal bool z0cek(XTextDocumentContentElement p0, XTextElement p1)
	{
		if (p0 == this)
		{
			return true;
		}
		if (p1 == null)
		{
			return false;
		}
		XTextElement xTextElement = p1;
		if (this is XTextContentElement)
		{
			return xTextElement.z0zu(this);
		}
		XTextElement xTextElement2 = z0hy();
		while (xTextElement != null)
		{
			if (xTextElement2 != xTextElement && xTextElement == this)
			{
				if (this is XTextFieldElementBase)
				{
					XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)this;
					if (p1 == xTextFieldElementBase.z0wrk)
					{
						xTextElement = xTextElement.z0ji();
						continue;
					}
				}
				return true;
			}
			xTextElement = xTextElement.z0ji();
		}
		return false;
	}

	public override void z0bt(XTextDocument p0)
	{
		if (z0rik == p0)
		{
			return;
		}
		z0rik = p0;
		if (z0ntk != null && z0ntk.Count > 0)
		{
			XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0krk();
			for (int num = z0ntk.Count - 1; num >= 0; num--)
			{
				array[num].z0bt(p0);
			}
		}
	}

	internal new void z0lrk(bool p0)
	{
		z0xrk(p0);
	}

	internal new string z0drk()
	{
		return ToolTip;
	}

	public new virtual z0ZzZztlh z0krk(bool p0)
	{
		return XTextDocument.z0mpk()?.z0gv(this, p0);
	}

	public XTextElementList z0cek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("elementTypeName");
		}
		Type controlType = z0ZzZzwnj.GetControlType(p0, typeof(XTextElement));
		if (controlType != null && typeof(XTextElement).IsAssignableFrom(controlType))
		{
			return z0me(controlType);
		}
		throw new ArgumentOutOfRangeException(p0);
	}

	public override bool z0de()
	{
		XTextElement xTextElement = z0ie();
		XTextElement xTextElement2 = z0dek();
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement != null && xTextDocumentContentElement.z0oek() != null && xTextDocumentContentElement.z0oek().z0qrk() > 0 && xTextDocumentContentElement.z0oek().z0bek().z0eek(xTextElement.z0jrk(), xTextElement2.z0jrk()))
		{
			return true;
		}
		return false;
	}

	public override string z0ti()
	{
		z0ygj z0ygj = new z0ygj(z0rik, p1: true);
		z0bw_jiejie20260327142557(z0ygj);
		return z0ygj.ToString();
	}

	protected void z0cek(ContentChangedEventArgs p0)
	{
		bool flag = false;
		DocumentValueValidateMode valueValidateMode = z0pu_jiejie20260327142557().ValueValidateMode;
		if (valueValidateMode == DocumentValueValidateMode.Dynamic)
		{
			flag = true;
		}
		else if (p0.UndoRedoCause && valueValidateMode == DocumentValueValidateMode.LostFocus)
		{
			flag = true;
		}
		ValueValidateStyle valueValidateStyle = z0br();
		if (valueValidateStyle != null && valueValidateStyle.Required && valueValidateStyle.RequiredInvalidateFlag && z0frk() != null)
		{
			flag = true;
		}
		if (flag)
		{
			z0krk(p0.LoadingDocument);
		}
	}

	[CompilerGenerated]
	internal static void z0cek(XTextContainerElement p0, XTextElementList p1, Type p2)
	{
		p0.z0kr();
		if (p0.z0ytk == null)
		{
			return;
		}
		IList<XTextElement> list = p0.z0ytk;
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = list[i];
			if (p2.IsInstanceOfType(p2))
			{
				((zzz.z0ZzZzkuk<XTextElement>)p1).z0pek(xTextElement);
			}
			if (xTextElement is XTextContainerElement xTextContainerElement && xTextContainerElement.z0crk())
			{
				z0cek(xTextContainerElement, p1, p2);
			}
		}
	}

	public virtual XTextElement z0ce(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elementType");
		}
		if (!typeof(XTextElement).IsAssignableFrom(p0))
		{
			throw new InvalidCastException(p0.FullName);
		}
		return z0xek(p0);
	}

	internal new bool z0srk()
	{
		return z0gyk();
	}

	public virtual void z0xek(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			if (z0utk != null)
			{
				z0itk.z0pek = null;
			}
			return;
		}
		if (z0itk == null)
		{
			z0itk = new z0ZzZzqcj();
		}
		z0itk.z0pek = p0;
	}

	public virtual bool z0dt()
	{
		return base.z0urk();
	}

	public override object z0lek()
	{
		if (EnableValueValidate && z0utk?.z0eek != null)
		{
			DocumentViewOptions documentViewOptions = z0iu();
			Color fieldInvalidateValueBackColor = documentViewOptions.FieldInvalidateValueBackColor;
			Color fieldInvalidateValueForeColor = documentViewOptions.FieldInvalidateValueForeColor;
			if ((fieldInvalidateValueBackColor.A != 0 || fieldInvalidateValueForeColor.A != 0) && z0qek() != null && z0ie() != null && z0dek() != null)
			{
				return new z0ZzZzqxj(this, new z0ZzZzkkh(z0qek(), z0ie(), z0dek()), fieldInvalidateValueBackColor, fieldInvalidateValueForeColor, HighlightActiveStyle.Static);
			}
		}
		return null;
	}

	public new void z0jrk(bool p0)
	{
		z0ze(z0kgj.z0eek(z0jr(), p0));
	}

	public void z0cek(string p0, int p1, int p2)
	{
		if (!string.IsNullOrEmpty(p0))
		{
			XTextElementList xTextElementList = z0be();
			if (p1 == -2)
			{
				p1 = ((xTextElementList.Count <= 0) ? z0pek() : xTextElementList.LastElement.z0pek());
			}
			if (p2 == -2)
			{
				p2 = p1;
			}
			XTextElement xTextElement = null;
			if (this is XTextContentElement && xTextElementList.LastElement is XTextParagraphFlagElement)
			{
				xTextElement = xTextElementList.LastElement;
			}
			zzz.z0ZzZzkuk<XTextElement> z0ZzZzkuk = z0stk;
			z0ZzZzkuk.z0rek(zzz.z0ZzZzgik<XTextElement[]>.z0iek.z0yek(), 0);
			z0jr().z0nek(this, p0, p1, p2, z0ZzZzkuk);
			if (xTextElement != null)
			{
				z0ZzZzkuk.z0pek(xTextElement);
			}
			if (xTextElementList.Capacity > z0ZzZzkuk.Count)
			{
				xTextElementList.Clear();
				((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek(z0ZzZzkuk);
			}
			else
			{
				xTextElementList.z0zek(z0ZzZzkuk.ToArray());
			}
			zzz.z0ZzZzgik<XTextElement[]>.z0iek.z0tek(z0ZzZzkuk.z0krk());
			z0ZzZzkuk.z0vrk();
		}
	}

	public virtual void z0ft(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			if (z0utk != null)
			{
				z0utk.z0cek = null;
			}
		}
		else
		{
			z0prk().z0cek = p0;
		}
	}

	public new bool z0ark()
	{
		z0kr();
		if (z0jrk() || z0vrk())
		{
			return z0ytk == null;
		}
		if (!z0jrk())
		{
			return !z0vrk();
		}
		return false;
	}

	public new int z0qrk()
	{
		if (z0itk != null)
		{
			return z0itk.z0oek;
		}
		return 0;
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		if (z0ntk != null && z0rik != null)
		{
			int count = z0ntk.Count;
			XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0krk();
			if (p0.z0oyk)
			{
				for (int i = 0; i < count; i++)
				{
					array[i].z0mr(p0);
				}
				z0xi(p0: false);
				return;
			}
			if (p0.z0prk)
			{
				for (int j = 0; j < count; j++)
				{
					XTextElement xTextElement = array[j];
					if (!xTextElement.z0ao())
					{
						continue;
					}
					if (XTextTableCellElement.z0mrk)
					{
						if (xTextElement is XTextCharElement)
						{
							((XTextCharElement)xTextElement).z0hrk = 1f;
							xTextElement.z0mr(p0);
							continue;
						}
						if (xTextElement is XTextFieldElementBase)
						{
							((XTextFieldElementBase)xTextElement).z0iek();
							xTextElement.z0mr(p0);
							continue;
						}
						if (xTextElement is XTextParagraphFlagElement)
						{
							((XTextParagraphFlagElement)xTextElement).z0eek(1f);
						}
					}
					xTextElement.z0mr(p0);
				}
			}
			else
			{
				for (int k = 0; k < count; k++)
				{
					XTextElement xTextElement2 = array[k];
					if (XTextTableCellElement.z0mrk)
					{
						if (xTextElement2 is XTextCharElement)
						{
							((XTextCharElement)xTextElement2).z0hrk = 1f;
							xTextElement2.z0mr(p0);
							continue;
						}
						if (xTextElement2 is XTextFieldElementBase)
						{
							((XTextFieldElementBase)xTextElement2).z0iek();
							xTextElement2.z0mr(p0);
							continue;
						}
						if (xTextElement2 is XTextParagraphFlagElement)
						{
							((XTextParagraphFlagElement)xTextElement2).z0eek(1f);
						}
					}
					xTextElement2.z0mr(p0);
				}
			}
		}
		z0xi(p0: false);
	}

	public override bool z0ar(XTextDocument p0, bool p1)
	{
		if (p0 == null)
		{
			return false;
		}
		XTextElement xTextElement = this;
		while (true)
		{
			if (xTextElement == p0)
			{
				return true;
			}
			if (p1 && xTextElement.z0aek().z0jyk >= 0)
			{
				return false;
			}
			XTextContainerElement xTextContainerElement = xTextElement.z0uik;
			if (xTextContainerElement == null || !xTextContainerElement.z0qe(xTextElement))
			{
				break;
			}
			xTextElement = xTextContainerElement;
		}
		return false;
	}

	public override XTextDocument z0jr()
	{
		return z0rik;
	}

	public new void z0hrk(bool p0)
	{
		if (z0itk == null)
		{
			z0itk = new z0ZzZzqcj();
		}
		z0itk.z0iek = p0;
	}

	internal static bool z0eek<ElementType>()
	{
		if (!typeof(XTextCharElement).IsAssignableFrom(typeof(ElementType)))
		{
			return typeof(XTextParagraphFlagElement) == typeof(ElementType);
		}
		return true;
	}

	public override void z0li()
	{
		XTextDocument xTextDocument = z0rik;
		if (z0btk)
		{
			z0we();
		}
		if (z0ntk == null || z0ntk.Count <= 0)
		{
			return;
		}
		z0ZzZzafh.z0yek(z0ntk, p1: false, xTextDocument, this, p4: true);
		int count = z0ntk.Count;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0krk();
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = array[i];
			xTextElement.z0muk = i;
			xTextElement.z0yek(xTextDocument, this);
			xTextElement.z0drk(p0: false);
			if (!(xTextElement is XTextCharElement) && !(xTextElement is XTextParagraphFlagElement))
			{
				xTextElement.z0li();
			}
		}
	}

	public bool z0cek(XTextElement p0, XTextElement p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("newElement");
		}
		int num = 0;
		if (p1 == null)
		{
			num = 0;
		}
		else
		{
			num = z0be().IndexOf(p1);
			if (num < 0)
			{
				num = 0;
			}
		}
		return z0ne(num, p0);
	}

	public virtual bool z0ou(XTextElement p0)
	{
		if (p0 is XTextDocument)
		{
			foreach (XTextElement item in ((XTextDocument)p0).z0xyk().z0be().z0xrk())
			{
				item.z0bt(z0jr());
				item.z0nu(this);
				z0ntk.Add(item);
			}
			return true;
		}
		if (p0 != null)
		{
			if (p0.z0ji() != null && p0.z0ji() != this)
			{
				XTextContainerElement xTextContainerElement = p0.z0ji();
				if (xTextContainerElement.z0be().Contains(p0))
				{
					xTextContainerElement.z0be().z0cek(p0);
				}
			}
			if (!z0ntk.Contains(p0))
			{
				z0ntk.Add(p0);
			}
			p0.z0yek(this);
			if (p0 is XTextContainerElement)
			{
				p0.z0bt(z0jr());
			}
			else
			{
				p0.z0yek(z0jr());
			}
			return true;
		}
		return false;
	}

	private new bool z0wrk()
	{
		if (ContentLock != null && z0jr() != null)
		{
			return !ContentLock.CheckCurrentUserAuthorize(z0jr());
		}
		return false;
	}

	public virtual bool z0cek(DocumentContentStyle p0)
	{
		if (z0jr() == null)
		{
			throw new NullReferenceException(z0ZzZziok.z0cik());
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("style");
		}
		if (base.z0uek(p0))
		{
			foreach (XTextElement item in new z0ZzZzkxj(this)
			{
				ExcludeParagraphFlag = false,
				ExcludeCharElement = false
			})
			{
				item.z0oek(z0pek());
			}
			return true;
		}
		return true;
	}

	public override z0ZzZzonj z0qt()
	{
		if (z0utk?.z0eek != null)
		{
			z0ZzZzonj z0ZzZzonj = new z0ZzZzonj(this, z0utk.z0eek.z0uek());
			z0ZzZzonj.z0eek(ToolTipContentType.ValidateResult);
			z0ZzZzonj.z0eek((z0ZzZzkbj)1);
			return z0ZzZzonj;
		}
		string text = z0drk();
		if (text != null && text.Length > 0)
		{
			z0ZzZzonj z0ZzZzonj2 = new z0ZzZzonj(this, text);
			z0ZzZzonj2.z0eek(ToolTipContentType.ElementToolTip);
			return z0ZzZzonj2;
		}
		return base.z0qt();
	}

	public void z0cek(ContentChangingEventArgs p0)
	{
		XTextContainerElement xTextContainerElement = this;
		while (xTextContainerElement != null)
		{
			if (xTextContainerElement == z0jr())
			{
				p0.Element = this;
			}
			else
			{
				p0.Element = xTextContainerElement;
			}
			xTextContainerElement.z0gi(p0);
			if (!p0.CancelBubble)
			{
				xTextContainerElement = xTextContainerElement.z0ji();
				continue;
			}
			break;
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		z0ptk = null;
		z0we();
		if (z0ntk != null)
		{
			z0ntk.z0zrk();
			z0ntk = null;
		}
		if (z0atk != null)
		{
			z0atk.z0vrk();
			z0atk = null;
		}
		if (z0utk != null)
		{
			z0utk.z0bwk();
			z0utk = null;
		}
		if (z0itk != null)
		{
			z0itk.Dispose();
			z0itk = null;
		}
		if (z0utk?.z0eek != null)
		{
			z0utk.z0eek.z0bek();
			z0utk.z0eek = null;
		}
	}

	public new virtual void z0erk()
	{
		z0jr().z0bek(this, (z0utk?.z0eek != null) ? z0utk.z0eek.z0rek() : 0);
	}

	public virtual XTextElementList z0rek<ET>() where ET : XTextElement
	{
		XTextElementList xTextElementList = new XTextElementList();
		z0tek<ET>(xTextElementList);
		return xTextElementList;
	}

	public virtual void z0gi(ContentChangingEventArgs p0)
	{
		if (z0jr().z0puk() && z0bu().EnableElementEvents && z0ttk != null)
		{
			z0ttk(p0);
		}
	}

	public override void z0oy(ElementEventArgs p0)
	{
		if (z0jr() != null)
		{
			z0jr().z0xek()?.z0cp(this);
		}
		if (z0pu_jiejie20260327142557().ValueValidateMode == DocumentValueValidateMode.LostFocus)
		{
			z0krk(p0: false);
		}
		base.z0oy(p0);
	}

	public int z0cek(z0ZzZzrlh p0)
	{
		return XTextDocument.z0mpk().z0xb(this, p0);
	}

	public override XTextElementList z0be()
	{
		return z0ntk;
	}

	public virtual XTextElementList z0cek(int p0)
	{
		XTextElementList xTextElementList = new XTextElementList();
		foreach (XTextElement item in new z0ZzZzkxj(this)
		{
			ExcludeParagraphFlag = false,
			ExcludeCharElement = false
		})
		{
			if (item.z0pek() == p0)
			{
				xTextElementList.z0hrk(item);
			}
		}
		return xTextElementList;
	}

	public virtual bool z0eu()
	{
		bool result = false;
		XTextDocument xTextDocument = z0jr();
		for (int num = z0be().Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = z0be()[num];
			DocumentContentStyle documentContentStyle = xTextElement.z0aek().z0jrk;
			if (documentContentStyle.DeleterIndex >= 0)
			{
				z0be().RemoveAt(num);
				result = true;
			}
			else if (documentContentStyle.CreatorIndex >= 0)
			{
				DocumentContentStyle documentContentStyle2 = (DocumentContentStyle)documentContentStyle.Clone();
				documentContentStyle2.DeleterIndex = -1;
				documentContentStyle2.CreatorIndex = -1;
				xTextElement.z0oek(xTextDocument.z0gnk().GetStyleIndex(documentContentStyle2));
				result = true;
			}
			if (xTextElement is XTextContainerElement)
			{
				if (((XTextContainerElement)xTextElement).z0eu())
				{
					result = true;
				}
			}
			else if (xTextElement is XTextCheckBoxElementBase xTextCheckBoxElementBase)
			{
				xTextCheckBoxElementBase.CheckedUserHistories = null;
			}
		}
		if (xTextDocument.z0imk() != null)
		{
			xTextDocument.z0imk().Clear();
		}
		return result;
	}

	public XTextElementList z0zek(string p0)
	{
		return z0go(p0, null);
	}

	internal new void z0rrk()
	{
		if (z0utk?.z0vek != null)
		{
			z0utk.z0vek.ContentVersion = z0kek() - 1;
		}
	}

	internal new void z0grk(bool p0)
	{
		base.z0srk(p0);
	}

	private void z0cek(string p0, string p1)
	{
		if (p1 == null || p1.Length == 0)
		{
			if (z0utk?.z0xek != null)
			{
				z0utk.z0xek.SetValue(p0, p1);
			}
			return;
		}
		PropertyExpressionInfoList propertyExpressionInfoList = z0prk().z0xek;
		if (propertyExpressionInfoList == null)
		{
			propertyExpressionInfoList = new PropertyExpressionInfoList();
			z0utk.z0xek = propertyExpressionInfoList;
		}
		propertyExpressionInfoList.SetValue(p0, p1);
	}

	public override void z0tu(string p0)
	{
		PropertyExpressionInfoList propertyExpressionInfoList = z0utk?.z0xek;
		if (propertyExpressionInfoList != null && propertyExpressionInfoList.Count == 0)
		{
			z0utk.z0xek = null;
		}
		if (!z0crk())
		{
			return;
		}
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0be()).z0krk();
		int count = z0be().Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = array[i];
			if (!(xTextElement is XTextCharElement) && !(xTextElement is XTextParagraphFlagElement))
			{
				xTextElement.z0tu(p0);
			}
		}
	}

	public bool z0cek(DCSignInputInfo p0)
	{
		return z0ZzZzdfh.z0rek().z0td(this, p0);
	}

	protected internal XTextContainerElement z0cek(z0ZzZzvxj p0)
	{
		if (p0.z0byk == (z0ZzZzcxj)0 && p0.z0btk.CAMode != DCCAMode.Disabled && p0.z0atk is XTextSignImageElement xTextSignImageElement)
		{
			return xTextSignImageElement.z0yek();
		}
		return null;
	}

	public virtual bool z0ur(z0kgj p0)
	{
		XTextContainerElement xTextContainerElement = z0ji();
		if (xTextContainerElement != null && !xTextContainerElement.z0yi())
		{
			return false;
		}
		if (!Visible)
		{
			return false;
		}
		if (p0.z0rek)
		{
			if (PrintVisibility != ElementVisibility.Visible)
			{
				return false;
			}
		}
		else if (p0.z0pek && DocumentViewOptions.z0urk && PrintVisibility != ElementVisibility.Visible)
		{
			return false;
		}
		if (!p0.z0oek && p0.z0eek(z0buk))
		{
			return false;
		}
		return true;
	}

	public override XTextElement z0ie()
	{
		foreach (XTextElement item in z0ntk.z0xrk())
		{
			if (!item.z0yi())
			{
				continue;
			}
			if (item is XTextTableElement)
			{
				XTextTableElement xTextTableElement = (XTextTableElement)item;
				if (xTextTableElement.z0zrk() != null)
				{
					return xTextTableElement.z0zrk().z0ie();
				}
			}
			if (item is XTextContainerElement)
			{
				XTextElement xTextElement = ((XTextContainerElement)item).z0ie();
				if (xTextElement != null)
				{
					return xTextElement;
				}
				continue;
			}
			return item;
		}
		return null;
	}

	public new string z0trk()
	{
		if (z0ntk == null || z0ntk.Count == 0)
		{
			return string.Empty;
		}
		z0ygj z0ygj = new z0ygj(z0rik, p1: false, p2: true);
		z0bw_jiejie20260327142557(z0ygj);
		return z0ygj.ToString();
	}

	public virtual void z0cek(DocumentContentStyle p0, bool p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("newStyle");
		}
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null)
		{
			throw new Exception(z0ZzZziok.z0pok());
		}
		z0li();
		XTextElementList xTextElementList = new XTextElementList();
		xTextElementList.Add(this);
		z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = new z0eok_jiejie20260327142557(xTextDocument, xTextElementList, p2: true);
		z0ue(z0eok_jiejie20260327142557);
		z0eok_jiejie20260327142557.Dispose();
		if (p1)
		{
			xTextDocument.z0ytk();
		}
		bool num = z0ZzZzhkh.z0rek(p0, p0, p0, xTextDocument, xTextElementList, p5: true, null, p1);
		if (p1)
		{
			xTextDocument.z0nuk();
		}
		if (num)
		{
			xTextDocument.z0bek((z0ZzZzdcj)null);
			xTextDocument.OnSelectionChanged();
			xTextDocument.OnDocumentContentChanged();
		}
	}

	public virtual string z0ht()
	{
		return z0utk?.z0cek;
	}

	internal virtual void z0we()
	{
		if (z0srk())
		{
			z0cek(p0: false);
			if (z0ytk is Array)
			{
				Array.Clear((Array)z0ytk);
				z0ytk = null;
			}
		}
	}

	internal XTextElement z0xek(int p0)
	{
		return null;
	}

	public override XTextElement z0dek()
	{
		for (int num = z0ntk.Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = z0ntk[num];
			if (xTextElement.z0yi())
			{
				if (xTextElement is XTextTableElement)
				{
					XTextTableElement xTextTableElement = (XTextTableElement)xTextElement;
					if (xTextTableElement.z0erk() != null)
					{
						return xTextTableElement.z0erk().z0dek();
					}
					return null;
				}
				if (!(xTextElement is XTextContainerElement))
				{
					return xTextElement;
				}
				XTextElement xTextElement2 = ((XTextContainerElement)xTextElement).z0dek();
				if (xTextElement2 != null)
				{
					return xTextElement2;
				}
			}
		}
		return null;
	}

	public void z0cek(z0ZzZztlh p0)
	{
		if (z0jr() != null)
		{
			z0ZzZztlh z0ZzZztlh = z0utk?.z0eek;
			if (z0ZzZztlh != null && z0ZzZztlh.z0oek() != null)
			{
				z0jr().z0bek(this, z0ZzZztlh.z0rek());
			}
			if (z0ZzZztlh != null)
			{
				if (!z0ZzZztlh.z0eek(p0))
				{
					z0jr().z0lok();
				}
			}
			else if (p0 != null && !p0.z0eek(z0ZzZztlh))
			{
				z0jr().z0lok();
			}
		}
		if (p0 == null)
		{
			if (z0utk != null)
			{
				z0utk.z0eek = null;
			}
		}
		else
		{
			z0prk().z0eek = p0;
		}
	}

	public bool z0cek(string p0, string p1, bool p2)
	{
		DCContentLockInfo dCContentLockInfo = new DCContentLockInfo();
		dCContentLockInfo.OwnerUserID = p0;
		dCContentLockInfo.AuthorisedUserIDList = p1;
		dCContentLockInfo.CreationTime = z0jr().z0jpk();
		if (p2)
		{
			if (z0jr().z0uik())
			{
				z0jr().z0imk().z0eek(z0ZzZzkfh.z0jrk, ContentLock, dCContentLockInfo, this);
			}
			else if (z0jr().z0ytk())
			{
				z0jr().z0imk().z0eek(z0ZzZzkfh.z0jrk, ContentLock, dCContentLockInfo, this);
				z0jr().z0nuk();
			}
		}
		ContentLock = dCContentLockInfo;
		return true;
	}

	public override void z0te(XTextElementList p0)
	{
		z0ntk = p0;
	}

	public void z0zek(int p0)
	{
		if (z0itk == null)
		{
			z0itk = new z0ZzZzqcj();
		}
		z0itk.z0oek = p0;
	}

	internal new void z0frk(bool p0)
	{
		z0yrk(p0);
	}

	internal new int z0yrk()
	{
		return MaxInputLength;
	}

	public void z0cek(object p0)
	{
		if (z0itk == null && p0 != null)
		{
			z0itk = new z0ZzZzqcj();
			z0itk.z0yek = p0;
		}
		else if (z0itk != null)
		{
			z0itk.z0yek = p0;
		}
	}

	protected internal XTextContainerElement(int v)
	{
		z0ntk = new XTextElementList();
		Deleteable = true;
		EnableValueValidate = false;
		z0cek(p0: false);
	}

	public new virtual void z0drk(bool p0)
	{
		base.z0zek(p0);
	}

	public override void z0fy(z0ZzZzdxj p0)
	{
		if (!p0.z0yek() && !z0yi())
		{
			return;
		}
		foreach (XTextElement item in z0be().z0xrk())
		{
			if (!(item is XTextSignImageElement) && (p0.z0yek() || item.z0yi()) && p0.z0eek(item.z0pek()))
			{
				item.z0fy(p0);
			}
		}
	}

	protected XTextElementList z0cek(string p0, DocumentContentStyle p1, bool p2)
	{
		if (z0ntk == null)
		{
			z0ntk = new XTextElementList();
		}
		DocumentContentStyle documentContentStyle = null;
		XTextParagraphFlagElement xTextParagraphFlagElement = null;
		if (p0 != null && p0.IndexOf('\r') >= 0)
		{
			xTextParagraphFlagElement = z0xt()?.z0dy();
			if (xTextParagraphFlagElement != null && xTextParagraphFlagElement.z0aek() != null)
			{
				documentContentStyle = xTextParagraphFlagElement.z0aek().z0yek();
			}
		}
		XTextElement xTextElement = null;
		if (this is XTextContentElement && z0ntk.LastElement is XTextParagraphFlagElement)
		{
			xTextElement = z0ntk.LastElement;
		}
		if (z0rik == null)
		{
			XTextElementList xTextElementList = new XTextElementList();
			if (p0 != null && p0.Length > 0)
			{
				int styleIndex = z0pek();
				if (z0ntk.Count > 0)
				{
					foreach (XTextElement item in z0ntk.z0xrk())
					{
						if (item is XTextCharElement || item is XTextStringElement || item is XTextLabelElement)
						{
							styleIndex = item.z0pek();
							break;
						}
					}
				}
				foreach (char c in p0)
				{
					switch (c)
					{
					case '\r':
					{
						XTextParagraphFlagElement xTextParagraphFlagElement2 = new XTextParagraphFlagElement();
						if (xTextParagraphFlagElement != null)
						{
							xTextParagraphFlagElement2.z0oek(((XTextElement)xTextParagraphFlagElement).z0pek());
						}
						xTextElementList.Add(xTextParagraphFlagElement2);
						break;
					}
					default:
					{
						XTextCharElement element = new XTextCharElement(c, this, z0rik, styleIndex);
						xTextElementList.Add(element);
						break;
					}
					case '\n':
						break;
					}
				}
			}
			if (xTextElementList.Count > 0 || z0ntk.Count > 0)
			{
				z0ntk = new XTextElementList();
				((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList);
				if (xTextElement != null)
				{
					z0ntk.Add(xTextElement);
				}
				z0qtk++;
			}
			return xTextElementList;
		}
		XTextDocument xTextDocument = z0rik;
		if (p1 == null)
		{
			if (z0ntk.Count > 0)
			{
				foreach (XTextElement item2 in z0ntk.z0xrk())
				{
					if (item2 is XTextCharElement || item2 is XTextStringElement || item2 is XTextLabelElement)
					{
						p1 = (DocumentContentStyle)xTextDocument.z0gnk().GetStyle(item2.z0pek());
						break;
					}
				}
				if (p1 == null)
				{
					p1 = (DocumentContentStyle)xTextDocument.z0gnk().GetStyle(z0ntk[0].z0pek());
				}
			}
			else
			{
				p1 = z0aek().z0rek();
			}
		}
		if (documentContentStyle != null && documentContentStyle.DeleterIndex >= 0)
		{
			documentContentStyle = (DocumentContentStyle)documentContentStyle.Clone();
			documentContentStyle.DeleterIndex = -1;
		}
		if (p1 != null && p1.DeleterIndex >= 0)
		{
			p1 = (DocumentContentStyle)p1.Clone();
			p1.DeleterIndex = -1;
		}
		XTextElementList xTextElementList2 = xTextDocument.z0bek(p0, documentContentStyle, p1, z0brk());
		bool flag = false;
		XTextContentElement xTextContentElement = z0jy();
		if (xTextElementList2 != null && xTextElementList2.Count > 0)
		{
			flag = true;
			if (xTextDocument.z0rik() != null && xTextDocument.z0rik().z0tw() && z0brk() && z0ntk.Count > 0 && xTextDocument.z0syk().z0yek() >= 0 && !xTextDocument.z0snk())
			{
				int num = xTextDocument.z0syk().z0yek();
				zzz.z0ZzZzkuk<XTextElement> z0ZzZzkuk = new zzz.z0ZzZzkuk<XTextElement>();
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ntk.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextElement current3 = z0bpk.Current;
						if (current3 != xTextElement)
						{
							if (current3.z0aek().z0jyk >= 0)
							{
								z0ZzZzkuk.Add(current3);
							}
							else if (current3.z0aek().z0nrk != num)
							{
								current3.z0xrk().DeleterIndex = num;
								current3.z0ftk();
								z0ZzZzkuk.Add(current3);
							}
						}
					}
				}
				z0ntk.Clear();
				((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0tek(z0ZzZzkuk);
				foreach (XTextElement item3 in xTextElementList2.z0xrk())
				{
					item3.z0yek(this);
					((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0pek(item3);
				}
			}
			else
			{
				z0ntk.Clear();
				foreach (XTextElement item4 in xTextElementList2.z0xrk())
				{
					item4.z0yek(this);
					((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0pek(item4);
				}
			}
			if (xTextElement != null)
			{
				z0ntk.Add(xTextElement);
			}
			if (xTextContentElement != null && p2 && !z0xu())
			{
				XTextContentElement.z0lgj z0lgj = new XTextContentElement.z0lgj();
				z0lgj.z0tek(p0: true);
				z0lgj.z0uek(p0: true);
				z0lgj.z0eek(p0: true);
				xTextContentElement.z0au(z0lgj);
			}
			if (!xTextDocument.z0snk())
			{
				((XTextElement)this).z0rrk();
			}
		}
		else if (z0ntk.Count > 0)
		{
			flag = true;
			if (xTextDocument.z0rik() != null && xTextDocument.z0rik().z0tw() && z0brk() && xTextDocument.z0syk().z0yek() >= 0 && !xTextDocument.z0snk())
			{
				int num2 = xTextDocument.z0syk().z0yek();
				for (int num3 = z0ntk.Count - 1; num3 >= 0; num3--)
				{
					XTextElement xTextElement2 = z0ntk[num3];
					if (xTextElement2.z0aek().z0jyk < 0)
					{
						if (xTextElement2.z0aek().z0nrk != num2)
						{
							xTextElement2.z0xrk().DeleterIndex = num2;
							xTextElement2.z0ftk();
						}
						else
						{
							z0ntk.RemoveAt(num3);
						}
					}
				}
			}
			else
			{
				z0ntk.Clear();
			}
			if (xTextElement != null && z0ntk.LastElement != xTextElement)
			{
				z0ntk.Add(xTextElement);
			}
			if (xTextContentElement != null && p2 && !z0xu())
			{
				XTextContentElement.z0lgj z0lgj2 = new XTextContentElement.z0lgj();
				z0lgj2.z0tek(p0: true);
				z0lgj2.z0uek(p0: true);
				z0lgj2.z0eek(p0: true);
				xTextContentElement.z0au(z0lgj2);
			}
			((XTextElement)this).z0rrk();
		}
		if (flag)
		{
			xTextDocument.z0cxk = true;
		}
		if (flag && xTextDocument != null && !xTextDocument.z0snk() && xTextDocument.z0apk() != null)
		{
			xTextDocument.z0apk().z0vv(this);
		}
		return xTextElementList2;
	}

	protected virtual void z0tek<ET>(XTextElementList p0) where ET : XTextElement
	{
		if (z0ntk == null || z0ntk.Count <= 0)
		{
			return;
		}
		int count = z0ntk.Count;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0krk();
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = array[i];
			if (xTextElement is ET)
			{
				((zzz.z0ZzZzkuk<XTextElement>)p0).z0pek(xTextElement);
			}
			if (xTextElement is XTextContainerElement)
			{
				((XTextContainerElement)xTextElement).z0tek<ET>(p0);
			}
		}
	}

	protected internal new void z0urk()
	{
		for (int num = z0ntk.Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = z0ntk[num];
			xTextElement.z0cuk = false;
			if (xTextElement is XTextContainerElement)
			{
				((XTextContainerElement)xTextElement).z0urk();
			}
		}
	}

	public virtual void z0ze(z0kgj p0)
	{
		bool flag = p0.z0mek;
		if (p0.z0nek == null)
		{
			bool flag2 = z0cuk;
			{
				foreach (XTextElement item in z0ntk.z0xrk())
				{
					item.z0cuk = flag2 && item.Visible;
					if (flag && item is XTextContainerElement)
					{
						((XTextContainerElement)item).z0ze(p0);
					}
				}
				return;
			}
		}
		z0cuk = z0ur(p0);
		if (z0cuk)
		{
			XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0krk();
			int count = z0ntk.Count;
			bool flag3 = false;
			if (this is XTextContentElement)
			{
				flag3 = z0ark();
			}
			if (p0.z0uek)
			{
				if (flag3)
				{
					for (int num = count - 1; num >= 0; num--)
					{
						XTextElement obj = array[num];
						obj.z0cuk = obj.Visible;
					}
					return;
				}
				for (int num2 = count - 1; num2 >= 0; num2--)
				{
					XTextElement xTextElement = array[num2];
					if (xTextElement is XTextContainerElement xTextContainerElement)
					{
						if (flag)
						{
							xTextContainerElement.z0ze(p0);
						}
						else
						{
							xTextContainerElement.z0cuk = xTextContainerElement.z0ur(p0);
						}
					}
					else
					{
						xTextElement.z0cuk = xTextElement.Visible;
					}
				}
				return;
			}
			if (flag3)
			{
				for (int num3 = count - 1; num3 >= 0; num3--)
				{
					XTextElement xTextElement2 = array[num3];
					xTextElement2.z0cuk = xTextElement2.Visible && !p0.z0eek(xTextElement2.z0buk);
				}
			}
			else
			{
				for (int num4 = count - 1; num4 >= 0; num4--)
				{
					XTextElement xTextElement3 = array[num4];
					if (xTextElement3 is XTextContainerElement)
					{
						XTextContainerElement xTextContainerElement2 = (XTextContainerElement)xTextElement3;
						if (flag)
						{
							xTextContainerElement2.z0ze(p0);
						}
						else
						{
							xTextContainerElement2.z0cuk = xTextContainerElement2.z0ur(p0);
						}
					}
					else
					{
						xTextElement3.z0cuk = xTextElement3.Visible && !p0.z0eek(xTextElement3.z0buk);
					}
				}
			}
			if (this is XTextContentElement && z0ntk.LastElement is XTextParagraphFlagElement { z0cuk: false } xTextParagraphFlagElement)
			{
				xTextParagraphFlagElement.z0cuk = true;
			}
		}
		else if (flag)
		{
			z0urk();
		}
	}

	private void z0yek<ElementType>(XTextContainerElement p0, XTextElementList p1)
	{
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0be().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			if (current is ElementType)
			{
				((zzz.z0ZzZzkuk<XTextElement>)p1).z0pek(current);
			}
			else if (current is XTextContainerElement)
			{
				XTextContainerElement xTextContainerElement = (XTextContainerElement)current;
				if (xTextContainerElement.z0crk())
				{
					z0yek<ElementType>(xTextContainerElement, p1);
				}
			}
		}
	}

	public new virtual XTextElementList z0irk()
	{
		XTextElementList xTextElementList = new XTextElementList();
		z0cek(this, xTextElementList, p2: false);
		return xTextElementList;
	}

	public override PropertyExpressionInfoList z0jek()
	{
		return z0utk?.z0xek;
	}

	public new bool z0ork()
	{
		XTextElementList xTextElementList = z0nek<XTextSignImageElement>();
		if (xTextElementList != null)
		{
			return xTextElementList.Count > 0;
		}
		return false;
	}

	public override void z0sr()
	{
		if (!z0ar(z0jr(), p1: false))
		{
			return;
		}
		XTextElement xTextElement = z0ie();
		if (xTextElement == null)
		{
			return;
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement == null)
		{
			return;
		}
		if (z0jr().z0jrk() != xTextDocumentContentElement)
		{
			xTextDocumentContentElement.z0sr();
		}
		if (xTextDocumentContentElement.z0zek() == null || !xTextDocumentContentElement.z0zek().z0zu(this))
		{
			int num = xTextElement.z0jrk();
			xTextDocumentContentElement.z0uek(xTextElement.z0jrk(), 0);
			if (num != xTextElement.z0jrk())
			{
				xTextDocumentContentElement.z0uek(xTextElement.z0jrk(), 0);
			}
		}
		z0ZzZzqbj z0ZzZzqbj = z0uyk();
		if (z0ZzZzqbj != null && ((z0ZzZzxnj)z0ZzZzqbj).z0uek())
		{
			if (this is XTextContentElement && Height < 500f)
			{
				z0ZzZzqbj.z0eek(z0py().z0vek(), ScrollToViewStyle.Normal);
			}
			z0ZzZzqbj.z0huk();
		}
	}

	public virtual bool z0pr()
	{
		return true;
	}

	private XTextElement z0xek(Type p0)
	{
		foreach (XTextElement item in z0be().z0xrk())
		{
			if (p0.IsInstanceOfType(item))
			{
				return item;
			}
			if (item is XTextContainerElement)
			{
				XTextElement xTextElement = ((XTextContainerElement)item).z0xek(p0);
				if (xTextElement != null)
				{
					return xTextElement;
				}
			}
		}
		return null;
	}

	internal new z0apk_jiejie20260327142557 z0prk()
	{
		if (z0utk == null)
		{
			z0utk = z0fo();
		}
		return z0utk;
	}

	public virtual string z0hu()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (XTextElement item in z0be().z0xrk())
		{
			if (!(item is XTextParagraphFlagElement))
			{
				stringBuilder.Append(item.ToString());
				if (stringBuilder.Length > 20)
				{
					break;
				}
			}
		}
		return "Para:" + stringBuilder.ToString();
	}

	public override XTextDocument z0ee_jiejie20260327142557(bool p0)
	{
		XTextElementList xTextElementList = new XTextElementList();
		if (p0)
		{
			xTextElementList.Add(this);
		}
		else
		{
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek((zzz.z0ZzZzkuk<XTextElement>)z0be());
		}
		return z0ZzZzafh.z0yek(z0jr(), xTextElementList, p2: true);
	}

	internal new void z0srk(bool p0)
	{
		base.z0krk(p0);
	}

	public override void z0rt(ElementLoadEventArgs p0)
	{
		z0qtk++;
		PropertyExpressionInfoList propertyExpressionInfoList = z0utk?.z0xek;
		if (propertyExpressionInfoList != null && propertyExpressionInfoList.Count == 0)
		{
			z0utk.z0xek = null;
		}
		if (this is XTextContentElement)
		{
			((XTextContentElement)this).z0gu();
		}
		XTextElementList xTextElementList = z0be();
		int count = xTextElementList.Count;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = array[i];
			xTextElement.z0iek(this);
			if (!(xTextElement is XTextCharElement) && !(xTextElement is XTextParagraphFlagElement))
			{
				p0.Element = this;
				xTextElement.z0rt(p0);
			}
		}
		p0.Element = this;
		base.z0rt(p0);
		if (p0.UpdateExpression)
		{
			XTextDocument xTextDocument = z0jr();
			if (xTextDocument != null && xTextDocument.z0rik() != null)
			{
				xTextDocument.z0rik().z0mw_jiejie20260327142557(this, p0);
			}
		}
	}

	public virtual bool z0eo(bool p0)
	{
		if (z0utk?.z0vek != null)
		{
			z0utk.z0eek = null;
			if (z0utk.z0vek != null)
			{
				z0utk.z0vek.ContentVersion = z0kek();
			}
			if (!p0)
			{
				z0erk();
			}
			return true;
		}
		return false;
	}

	public ElementType z0uek<ElementType>() where ElementType : XTextElement
	{
		XTextElementList xTextElementList = z0be();
		if (xTextElementList == null)
		{
			return null;
		}
		return xTextElementList.z0srk<ElementType>();
	}

	public virtual bool z0do(SetContainerTextArgs p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("args");
		}
		bool flag = false;
		XTextDocument xTextDocument = z0jr();
		if (!z0xu() && z0ar(xTextDocument, p1: false))
		{
			string text = Text;
			if (text == null || text != p0.NewText)
			{
				bool flag2 = xTextDocument.z0uik();
				if (p0.LogUndo && !flag2)
				{
					xTextDocument.z0ytk();
				}
				if (string.IsNullOrEmpty(p0.NewText))
				{
					z0ZzZzezj z0ZzZzezj = new z0ZzZzezj(this, 0, z0be().Count, null, p4: true, p5: true, p6: true);
					z0ZzZzezj.z0eek(p0.EventSource);
					if (this is XTextContentElement && z0ZzZzezj.z0lrk() == z0be().Count && z0be().LastElement is XTextParagraphFlagElement)
					{
						z0ZzZzezj.z0rek(z0be().Count - 1);
					}
					z0ZzZzezj.z0uek(p0: true);
					z0ZzZzezj.z0tek(p0.FocusContainer);
					z0ZzZzezj.z0eek(p0.DisablePermission);
					z0ZzZzezj.z0eek(p0.AccessFlags);
					z0ZzZzezj.z0mek(p0: false);
					z0ZzZzezj.z0bek(p0.UpdateContent);
					z0ZzZzezj.z0pek(p0: true);
					z0ZzZzezj.z0nek(p0.LogUndo);
					z0ZzZzezj.z0oek_jiejie20260327142557(p0.RaiseEvent);
					z0ZzZzezj.z0mek(p0: false);
					if (!p0.DisablePermission && z0brk())
					{
						for (int i = 0; i < z0be().Count; i++)
						{
							if (z0be()[i].z0aek().z0jyk < 0)
							{
								continue;
							}
							bool flag3 = true;
							for (int j = i; j < z0be().Count; j++)
							{
								if (z0be()[j].z0aek().z0jyk < 0)
								{
									flag3 = false;
									break;
								}
							}
							if (flag3)
							{
								z0ZzZzezj.z0rek(i);
							}
							break;
						}
					}
					flag = xTextDocument.z0bek(z0ZzZzezj) != 0;
				}
				else
				{
					DocumentContentStyle documentContentStyle = p0.NewTextStyle;
					if (documentContentStyle == null)
					{
						if (z0be().Count > 0)
						{
							using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0be().z0ltk())
							{
								while (z0bpk.MoveNext())
								{
									XTextElement current = z0bpk.Current;
									if (current.z0yi() && current is XTextCharElement)
									{
										documentContentStyle = current.z0aek().z0rek();
										break;
									}
								}
							}
							if (documentContentStyle == null)
							{
								using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0be().z0ltk();
								while (z0bpk.MoveNext())
								{
									XTextElement current2 = z0bpk.Current;
									if (current2.z0yi())
									{
										documentContentStyle = current2.z0aek().z0rek();
										break;
									}
								}
							}
						}
						if (documentContentStyle == null && z0hy() != null)
						{
							documentContentStyle = z0hy().z0aek().z0rek();
						}
						if (documentContentStyle == null)
						{
							documentContentStyle = z0aek().z0rek();
						}
						documentContentStyle.TitleLevel = -1;
						documentContentStyle.DeleterIndex = -1;
						documentContentStyle.ProtectType = ContentProtectType.None;
					}
					if (!z0brk())
					{
						documentContentStyle.CreatorIndex = -1;
					}
					if (this is XTextInputFieldElement)
					{
						Color defaultInputFieldTextColor = xTextDocument.z0iu().DefaultInputFieldTextColor;
						if (defaultInputFieldTextColor.A != 0)
						{
							documentContentStyle.Color = defaultInputFieldTextColor;
						}
					}
					DocumentContentStyle documentContentStyle2 = p0.NewParagraphStyle;
					if (documentContentStyle2 == null)
					{
						XTextElement xTextElement = z0ie();
						if (xTextElement != null && xTextElement.z0dy() != null)
						{
							documentContentStyle2 = xTextElement.z0dy().z0aek().z0jrk;
						}
						if (documentContentStyle2 == null)
						{
							documentContentStyle2 = xTextDocument.z0onk().z0uek();
						}
					}
					documentContentStyle2 = (DocumentContentStyle)documentContentStyle2.Clone();
					documentContentStyle2.z0rek(p0: false);
					if (!z0brk())
					{
						documentContentStyle2.CreatorIndex = -1;
					}
					XTextElementList xTextElementList = xTextDocument.z0bek(p0.NewText, documentContentStyle2, documentContentStyle, z0brk());
					if (xTextElementList != null && xTextElementList.Count > 0)
					{
						z0ZzZzezj z0ZzZzezj2 = new z0ZzZzezj(this, 0, z0be().Count, xTextElementList, p4: true, p5: true, p6: true);
						z0ZzZzezj2.z0uek(p0: true);
						z0ZzZzezj2.z0tek(p0.FocusContainer);
						z0ZzZzezj2.z0eek(p0.DisablePermission);
						z0ZzZzezj2.z0eek(p0.AccessFlags);
						z0ZzZzezj2.z0mek(p0: false);
						z0ZzZzezj2.z0bek(p0.UpdateContent);
						z0ZzZzezj2.z0pek(p0: true);
						z0ZzZzezj2.z0nek(p0.LogUndo);
						z0ZzZzezj2.z0oek_jiejie20260327142557(p0.RaiseEvent);
						z0ZzZzezj2.z0eek(p0.EventSource);
						z0ZzZzezj2.z0mek(p0: false);
						z0ZzZzezj2.z0iek(p0.z0eek_jiejie20260327142557());
						z0ZzZzezj2.z0eek(p0.NewInnerValue);
						if (!p0.DisablePermission && z0brk())
						{
							for (int k = 0; k < z0be().Count; k++)
							{
								if (z0be()[k].z0aek().z0jyk < 0)
								{
									continue;
								}
								bool flag4 = true;
								for (int l = k; l < z0be().Count; l++)
								{
									if (z0be()[l].z0aek().z0jyk < 0)
									{
										flag4 = false;
										break;
									}
								}
								if (flag4)
								{
									z0ZzZzezj2.z0rek(k);
								}
								break;
							}
						}
						if (this is XTextContentElement && z0ZzZzezj2.z0lrk() == z0be().Count && z0be().LastElement is XTextParagraphFlagElement)
						{
							z0ZzZzezj2.z0rek(z0be().Count - 1);
						}
						XTextDocumentContentElement.z0xrk = true;
						try
						{
							flag = xTextDocument.z0bek(z0ZzZzezj2) != 0;
						}
						finally
						{
							XTextDocumentContentElement.z0xrk = false;
						}
					}
				}
				if (p0.LogUndo && !flag2)
				{
					if (flag)
					{
						xTextDocument.z0nuk();
					}
					else
					{
						xTextDocument.z0mrk();
					}
				}
				if (flag && p0.RaiseEvent)
				{
					if (p0.RaiseDocumentContentChangedEvent)
					{
						xTextDocument.OnDocumentContentChanged();
					}
					xTextDocument.OnSelectionChanged();
				}
			}
		}
		else
		{
			XTextElementList xTextElementList2 = z0zek(p0.NewText);
			flag = xTextElementList2 != null && xTextElementList2.Count > 0;
			if (xTextDocument != null && !xTextDocument.z0snk())
			{
				ContentChangedEventArgs e = new ContentChangedEventArgs();
				e.Document = xTextDocument;
				e.Element = this;
				z0zi(e);
				xTextDocument.z0grk(this);
			}
		}
		if (z0jr() != null && !xTextDocument.z0xu())
		{
			if (p0.ShowUI)
			{
				xTextDocument.z0vek((z0ZzZzgcj)null);
			}
			xTextDocument.z0ntk();
		}
		return flag;
	}

	internal virtual void z0se()
	{
		if (z0ntk == null)
		{
			return;
		}
		for (int num = z0ntk.Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = z0ntk[num];
			xTextElement.z0ruk = null;
			if (xTextElement is XTextContainerElement)
			{
				((XTextContainerElement)xTextElement).z0se();
			}
		}
	}

	public override string z0zwk(string p0)
	{
		if (z0atk != null)
		{
			return z0atk.z0yek(p0);
		}
		return null;
	}

	public override bool z0dr(string p0, string p1)
	{
		if (z0atk == null)
		{
			z0atk = new XAttributeList();
		}
		z0atk.z0eek(p0, p1);
		return true;
	}

	[CompilerGenerated]
	internal static void z0iek<ElementType, ElementType>(XTextContainerElement p0, XTextElementList p1)
	{
		p0.z0kr();
		if (p0.z0ytk == null)
		{
			return;
		}
		IList<XTextElement> list = p0.z0ytk;
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = list[i];
			if (xTextElement is ElementType)
			{
				((zzz.z0ZzZzkuk<XTextElement>)p1).z0pek(xTextElement);
			}
			if (xTextElement is XTextContainerElement xTextContainerElement && xTextContainerElement.z0crk())
			{
				z0iek<ElementType, ElementType>(xTextContainerElement, p1);
			}
		}
	}

	public bool z0cek(string p0, z0ZzZzbcj p1, bool p2, bool p3)
	{
		SetContainerTextArgs setContainerTextArgs = new SetContainerTextArgs();
		setContainerTextArgs.NewText = p0;
		setContainerTextArgs.AccessFlags = p1;
		setContainerTextArgs.DisablePermission = p2;
		setContainerTextArgs.UpdateContent = p3;
		return z0do(setContainerTextArgs);
	}

	internal virtual void z0kr()
	{
		if (z0srk())
		{
			return;
		}
		z0cek(p0: true);
		z0srk(p0: false);
		z0zek(p0: false);
		z0grk(p0: false);
		z0lrk(p0: false);
		z0ytk = null;
		if (z0ntk == null || z0ntk.Count <= 0)
		{
			return;
		}
		if (z0ntk.z0mek())
		{
			z0srk(p0: false);
			z0zek(p0: true);
			z0grk(p0: false);
			z0lrk(p0: false);
			z0ytk = null;
			return;
		}
		bool p = false;
		bool p2 = false;
		bool p3 = false;
		bool p4 = false;
		zzz.z0ZzZzkuk<XTextElement> z0ZzZzkuk = z0stk;
		z0ZzZzkuk.z0rek(zzz.z0ZzZzgik<XTextElement[]>.z0iek.z0yek(), 0);
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0krk();
		int count = z0ntk.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = array[i];
			if (xTextElement is XTextCharElement)
			{
				p = true;
				continue;
			}
			if (xTextElement is XTextParagraphFlagElement)
			{
				p2 = true;
				continue;
			}
			z0ZzZzkuk.Add(xTextElement);
			if (xTextElement is XTextContainerElement)
			{
				p4 = true;
			}
			else if (xTextElement is XTextObjectElement)
			{
				p3 = true;
			}
		}
		z0srk(p);
		z0zek(p2);
		z0grk(p3);
		z0lrk(p4);
		if (z0ZzZzkuk.Count > 0)
		{
			z0ytk = z0ZzZzkuk.ToArray();
		}
		zzz.z0ZzZzgik<XTextElement[]>.z0iek.z0tek(z0ZzZzkuk.z0krk());
		z0ZzZzkuk.z0vrk();
	}

	public override bool z0fek()
	{
		if (z0rik == null)
		{
			return false;
		}
		for (XTextContainerElement xTextContainerElement = this; xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0uik)
		{
			if (xTextContainerElement is XTextDocumentContentElement)
			{
				XTextDocumentContentElement xTextDocumentContentElement = (XTextDocumentContentElement)xTextContainerElement;
				return z0cek(xTextDocumentContentElement, xTextDocumentContentElement.z0zek());
			}
		}
		return false;
	}

	protected new void z0mrk()
	{
		if (z0atk != null)
		{
			z0atk.Clear();
		}
	}

	public virtual void z0yr(MoveFocusHotKeys p0)
	{
	}

	public virtual void z0zi(ContentChangedEventArgs p0)
	{
		XTextContainerElement xTextContainerElement = this;
		while (xTextContainerElement != null)
		{
			if (xTextContainerElement == z0jr())
			{
				p0.Element = this;
			}
			else
			{
				p0.Element = xTextContainerElement;
			}
			xTextContainerElement.z0rr(p0);
			if (!p0.CancelBubble)
			{
				if (p0.EventSource == ContentChangedEventSource.ValueEditor)
				{
					p0.EventSource = ContentChangedEventSource.Default;
				}
				xTextContainerElement = xTextContainerElement.z0ji();
				continue;
			}
			break;
		}
	}

	public new virtual string z0nrk()
	{
		return z0itk?.z0pek;
	}

	public virtual T z0oek<T>() where T : XTextElement
	{
		if (z0ntk == null)
		{
			return null;
		}
		int count = z0ntk.Count;
		XTextElementList xTextElementList = z0ntk;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = xTextElementList[i];
			if (xTextElement is T)
			{
				return (T)xTextElement;
			}
			if (xTextElement is XTextContainerElement)
			{
				T val = ((XTextContainerElement)xTextElement).z0oek<T>();
				if (val != null)
				{
					return val;
				}
			}
		}
		return null;
	}

	public new virtual bool z0brk()
	{
		for (XTextContainerElement xTextContainerElement = this; xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
		{
			if (xTextContainerElement.EnablePermission == DCBooleanValue.True)
			{
				return true;
			}
			if (xTextContainerElement.EnablePermission == DCBooleanValue.False)
			{
				return false;
			}
		}
		if (z0jr() == null)
		{
			return false;
		}
		return z0hi().EnablePermission;
	}

	public XTextElement z0lrk(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("elementTypeName");
		}
		Type controlType = z0ZzZzwnj.GetControlType(p0, typeof(XTextElement));
		if (controlType != null && typeof(XTextElement).IsAssignableFrom(controlType))
		{
			return z0cek(controlType);
		}
		throw new ArgumentOutOfRangeException(p0);
	}

	public void z0krk(string p0)
	{
		z0cek(p0, (z0ZzZzbcj)0, p2: false, p3: true);
	}

	internal new bool z0vrk()
	{
		return z0yek();
	}

	public virtual bool z0sek()
	{
		ContentReadonlyState contentReadonlyState = z0etk;
		if (contentReadonlyState == ContentReadonlyState.True)
		{
			return true;
		}
		if (ContentLock != null && z0wrk())
		{
			return true;
		}
		if (contentReadonlyState == ContentReadonlyState.Inherit)
		{
			for (XTextContainerElement xTextContainerElement = z0ji(); xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
			{
				ContentReadonlyState contentReadonlyState2 = xTextContainerElement.z0etk;
				if (contentReadonlyState2 == ContentReadonlyState.True)
				{
					return true;
				}
				if (xTextContainerElement.ContentLock != null && xTextContainerElement.z0wrk())
				{
					return true;
				}
				if (contentReadonlyState2 == ContentReadonlyState.False)
				{
					return false;
				}
			}
			return false;
		}
		return false;
	}

	public new virtual bool z0crk()
	{
		if (z0ntk != null)
		{
			return z0ntk.Count > 0;
		}
		return false;
	}

	public virtual bool z0ai(XTextElement p0)
	{
		if (p0 != null)
		{
			z0ntk?.z0cek(p0);
			p0.z0yek((XTextContainerElement)null);
			return true;
		}
		return false;
	}

	public virtual XTextElement z0cek(string p0, bool p1)
	{
		return z0cek(p0, p1, p2: true);
	}

	private static void z0cek(XTextContainerElement p0, XTextElementList p1)
	{
		p1.z0hrk(p0);
		XTextElementList xTextElementList = p0.z0ntk;
		if (xTextElementList == null || xTextElementList.Count <= 0)
		{
			return;
		}
		int count = xTextElementList.Count;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
		for (int i = 0; i < count; i++)
		{
			if (array[i] is XTextContainerElement)
			{
				p1.z0hrk(array[i]);
				z0cek((XTextContainerElement)array[i], p1);
			}
		}
	}

	public virtual bool z0qe(XTextElement p0)
	{
		if (z0ntk != null)
		{
			if (z0ntk.z0pek(p0.z0muk, p0))
			{
				return true;
			}
			int num = z0ntk.IndexOf(p0);
			if (num >= 0)
			{
				p0.z0muk = num;
				return true;
			}
		}
		return false;
	}

	public virtual XTextElementList z0me(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elementType");
		}
		if (!typeof(XTextElement).IsAssignableFrom(p0))
		{
			throw new InvalidCastException(p0.FullName);
		}
		XTextElementList xTextElementList = new XTextElementList();
		if (p0.IsInstanceOfType(this))
		{
			xTextElementList.Add(this);
		}
		if (z0crk())
		{
			if (typeof(XTextCharElement).IsAssignableFrom(p0) || typeof(XTextParagraphFlagElement) == p0)
			{
				z0xek(this, xTextElementList, p0);
			}
			else
			{
				z0cek(this, xTextElementList, p0);
			}
		}
		return xTextElementList;
	}

	public override bool z0zy(z0ZzZzzhh p0)
	{
		if (z0ptk() == null)
		{
			bool result = false;
			foreach (XTextElement item in z0be().z0xrk())
			{
				if (item.z0zy(p0))
				{
					result = true;
					break;
				}
			}
			return result;
		}
		return z0ptk().z0oek();
	}

	internal new bool z0xrk()
	{
		return z0kyk_jiejie20260327142557();
	}

	internal new bool z0zrk()
	{
		return z0uek();
	}

	public new virtual bool z0ltk()
	{
		if (base.z0drk(p0: false))
		{
			foreach (XTextElement item in new z0ZzZzkxj(this)
			{
				ExcludeCharElement = false,
				ExcludeParagraphFlag = false
			})
			{
				item.z0oek(z0pek());
			}
			return true;
		}
		return false;
	}

	public XTextElementList z0ktk_jiejie20260327142557()
	{
		return z0nek<XTextCheckBoxElement>();
	}

	public virtual XTextElementList z0yy(string p0, DocumentContentStyle p1, bool p2)
	{
		return z0cek(p0, p1, p2);
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextContainerElement xTextContainerElement = (XTextContainerElement)base.z0lr(p0);
		xTextContainerElement.z0cek(p0: false);
		xTextContainerElement.z0ytk = null;
		xTextContainerElement.z0qtk = 0;
		if (z0utk != null)
		{
			xTextContainerElement.z0utk = z0utk.z0vwk();
		}
		if (z0itk != null)
		{
			xTextContainerElement.z0itk = z0itk.z0eek();
		}
		if (z0atk != null && z0atk.Count > 0)
		{
			xTextContainerElement.z0atk = z0atk.z0eek();
		}
		else
		{
			xTextContainerElement.z0atk = null;
		}
		xTextContainerElement.z0ntk = new XTextElementList();
		if (p0 && z0ntk != null && z0ntk.Count > 0)
		{
			z0ntk.z0oek(xTextContainerElement.z0ntk, xTextContainerElement, z0jr());
		}
		return xTextContainerElement;
	}

	public new string z0jtk()
	{
		return Text;
	}

	public virtual void z0rr(ContentChangedEventArgs p0)
	{
		p0.Element = this;
		XTextDocument xTextDocument = z0jr();
		bool loadingDocument = p0.LoadingDocument;
		if (!loadingDocument)
		{
			Modified = true;
		}
		if (!loadingDocument)
		{
			z0ZzZzpkh z0ZzZzpkh = xTextDocument.z0rik();
			if (z0ZzZzpkh != null)
			{
				z0ZzZzpkh.z0iw(p0: true);
				z0ZzZzpkh.z0rw(this, p1: true);
				z0ZzZzpkh.z0iw(p0: false);
			}
		}
		z0cek(p0);
		if (!loadingDocument && z0mtk != null)
		{
			z0mtk(p0);
		}
	}

	public XTextElementList z0jrk(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		XTextElementList xTextElementList = new XTextElementList();
		z0cek(p0, xTextElementList, p2: false);
		return xTextElementList;
	}

	public virtual bool z0wo(z0ZzZzgcj p0, int p1)
	{
		XTextDocument xTextDocument = z0jr();
		bool flag = false;
		z0ZzZzpxj z0ZzZzpxj = xTextDocument.z0xek();
		XTextElementList xTextElementList = z0be();
		int num = xTextElementList.Count - 1;
		if (this is XTextContentElement)
		{
			num--;
		}
		ElementStateDetectEventArgs e = new ElementStateDetectEventArgs(null, (z0ZzZzbcj)253);
		e.ResetLastContentProtectedInfo = true;
		e.z0eek(p0: true);
		for (int i = 0; i <= num; i++)
		{
			XTextElement xTextElement = (e.Element = xTextElementList[i]);
			e.Message = null;
			z0ZzZzpxj.z0rm(e);
			if (!e.Result)
			{
				z0ZzZzpxj.z0ym(p0);
				flag = true;
				if (p0 == null)
				{
					break;
				}
				if (p1 == 0 || p1 < p0.Count)
				{
					z0ZzZzpxj.z0ym(p0);
				}
			}
			else
			{
				if (!(xTextElement is XTextContainerElement))
				{
					continue;
				}
				if (((XTextContainerElement)xTextElement).z0wo(p0, p1))
				{
					flag = true;
					if (p0 == null && flag)
					{
						break;
					}
				}
				if (p1 > 0 && p0.Count >= p1)
				{
					break;
				}
			}
		}
		return flag;
	}

	[CompilerGenerated]
	internal static void z0pek_jiejie20260327142557<ElementType, ElementType>(XTextContainerElement p0, XTextElementList p1)
	{
		if (!p0.z0crk())
		{
			return;
		}
		XTextElementList xTextElementList = p0.z0be();
		int count = xTextElementList.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = xTextElementList[i];
			if (xTextElement is ElementType)
			{
				((zzz.z0ZzZzkuk<XTextElement>)p1).z0pek(xTextElement);
			}
			if (xTextElement is XTextContainerElement xTextContainerElement && xTextContainerElement.z0crk())
			{
				z0pek_jiejie20260327142557<ElementType, ElementType>(xTextContainerElement, p1);
			}
		}
	}

	protected internal void z0xek(z0ZzZzvxj p0)
	{
		if (z0cek(p0) == this)
		{
			z0ZzZzbdh p1 = z0ZzZzbdh.z0tek(z0qyk(), p0.z0nek());
			if (!p1.z0bek())
			{
				p0.z0gyk.z0rek();
				p0.z0gyk.z0rek(Color.FromArgb(30, Color.Red), p1);
			}
		}
	}

	public virtual void z0st(bool p0)
	{
		z0vek(p0);
	}

	public override void z0wi(string p0)
	{
		Text = p0;
	}

	public new bool z0htk()
	{
		return z0sek();
	}

	public override bool z0hek(bool p0)
	{
		if (z0rik == null)
		{
			return z0cuk;
		}
		if (PrintVisibility == ElementVisibility.None && p0)
		{
			return false;
		}
		return z0yi();
	}

	public override bool z0qr(string p0)
	{
		if (z0atk != null && z0atk.Count > 0 && z0ZzZzxcj.z0eek(181))
		{
			return z0atk.z0tek(p0);
		}
		return false;
	}

	internal void z0mek<ArgType>(bool p0, ArgType p1, Func<XTextElement, ArgType, bool> p2)
	{
		if (p0)
		{
			p2(this, p1);
		}
		if (z0ntk != null && z0ntk.Count > 0)
		{
			z0ntk.z0uek(p1, p2);
		}
	}

	public virtual XTextElementList z0nek<ElementType>()
	{
		XTextElementList xTextElementList = new XTextElementList();
		if (this is ElementType)
		{
			xTextElementList.Add(this);
		}
		if (z0crk())
		{
			if (z0eek<ElementType>())
			{
				z0pek_jiejie20260327142557<ElementType, ElementType>(this, xTextElementList);
			}
			else
			{
				z0iek<ElementType, ElementType>(this, xTextElementList);
			}
		}
		return xTextElementList;
	}

	public new bool z0gtk()
	{
		XTextElementList xTextElementList = z0nek<XTextSignImageElement>();
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			bool flag = false;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextSignImageElement xTextSignImageElement = (XTextSignImageElement)z0bpk.Current;
					if (xTextSignImageElement.z0yek() == this)
					{
						xTextSignImageElement.ClearSign();
						flag = true;
					}
				}
			}
			if (flag)
			{
				((XTextElement)this).z0rrk();
				z0jo();
				Modified = true;
				z0jr().Modified = true;
				ContentChangedEventArgs e = new ContentChangedEventArgs();
				e.Document = z0jr();
				e.Element = this;
				z0rr(e);
				return true;
			}
		}
		return false;
	}

	internal virtual z0apk_jiejie20260327142557 z0fo()
	{
		return new z0apk_jiejie20260327142557();
	}

	public new object z0ftk()
	{
		return z0itk?.z0yek;
	}

	private static XTextElement z0bek_jiejie20260327142557(XTextContainerElement p0, string p1, bool p2, Dictionary<int, int> p3, ref XTextElement p4)
	{
		p0.z0kr();
		if (p0.z0ytk != null)
		{
			IList<XTextElement> list = p0.z0ytk;
			int count = list.Count;
			if (p2)
			{
				for (int i = 0; i < count; i++)
				{
					XTextElement xTextElement = list[i];
					if (xTextElement.ID == p1)
					{
						if (p3 == null || !p3.ContainsKey(xTextElement.z0pek()))
						{
							return xTextElement;
						}
					}
					else if (xTextElement is XTextContainerElement)
					{
						XTextElement xTextElement2 = z0bek_jiejie20260327142557((XTextContainerElement)xTextElement, p1, p2, p3, ref p4);
						if (xTextElement2 != null)
						{
							return xTextElement2;
						}
					}
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					XTextElement xTextElement3 = list[j];
					if (p3 != null && p3.ContainsKey(xTextElement3.z0pek()))
					{
						continue;
					}
					if (xTextElement3.ID == p1)
					{
						return xTextElement3;
					}
					if (xTextElement3 is XTextInputFieldElementBase && p4 == null)
					{
						XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextElement3;
						if (xTextInputFieldElementBase.Name == p1)
						{
							p4 = xTextInputFieldElementBase;
						}
					}
					else if (xTextElement3 is XTextCheckBoxElementBase && p4 == null)
					{
						XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)xTextElement3;
						if (xTextCheckBoxElementBase.Name == p1)
						{
							p4 = xTextCheckBoxElementBase;
						}
					}
					if (xTextElement3 is XTextContainerElement)
					{
						XTextElement xTextElement4 = z0bek_jiejie20260327142557((XTextContainerElement)xTextElement3, p1, p2, p3, ref p4);
						if (xTextElement4 != null)
						{
							return xTextElement4;
						}
					}
				}
			}
		}
		return null;
	}

	private void z0cek(XTextElement p0, XTextElementList p1, bool p2)
	{
		p1.Add(p0);
		if (p0.z0be() == null)
		{
			return;
		}
		foreach (XTextElement item in p0.z0be().z0xrk())
		{
			if (p2 || !(item is XTextCharElement))
			{
				z0cek(item, p1, p2);
			}
		}
	}

	public virtual ElementType z0at()
	{
		return AcceptChildElementTypes2;
	}

	public XTextElement z0zek(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elementType");
		}
		if (!typeof(XTextElement).IsAssignableFrom(p0))
		{
			throw new InvalidCastException(p0.FullName);
		}
		bool flag = p0.Equals(typeof(XTextCharElement));
		for (int num = z0be().Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = z0be()[num];
			if (!flag || !(xTextElement is XTextCharElement))
			{
				if (p0.IsInstanceOfType(xTextElement))
				{
					return xTextElement;
				}
				if (xTextElement is XTextContainerElement)
				{
					XTextElement xTextElement2 = ((XTextContainerElement)xTextElement).z0zek(p0);
					if (xTextElement2 != null)
					{
						return xTextElement2;
					}
				}
			}
		}
		return null;
	}

	[CompilerGenerated]
	internal static void z0xek(XTextContainerElement p0, XTextElementList p1, Type p2)
	{
		if (!p0.z0crk())
		{
			return;
		}
		XTextElementList xTextElementList = p0.z0be();
		int count = xTextElementList.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = xTextElementList[i];
			if (p2.IsInstanceOfType(xTextElement))
			{
				((zzz.z0ZzZzkuk<XTextElement>)p1).z0pek(xTextElement);
			}
			if (xTextElement is XTextContainerElement xTextContainerElement && xTextContainerElement.z0crk())
			{
				z0xek(xTextContainerElement, p1, p2);
			}
		}
	}

	public bool z0vek<ElementType>()
	{
		z0kr();
		if (typeof(XTextCharElement).IsAssignableFrom(typeof(ElementType)))
		{
			return z0jrk();
		}
		if (typeof(ElementType) == typeof(XTextParagraphFlagElement))
		{
			return z0vrk();
		}
		if (typeof(XTextContainerElement).IsAssignableFrom(typeof(ElementType)))
		{
			if (!z0xrk())
			{
				return false;
			}
		}
		else if (typeof(XTextObjectElement).IsAssignableFrom(typeof(ElementType)) && !z0zrk())
		{
			return false;
		}
		if (z0ytk != null)
		{
			if (z0ytk is XTextElement[] array)
			{
				for (int num = array.Length - 1; num >= 0; num--)
				{
					if (array[num] is ElementType)
					{
						return true;
					}
				}
			}
			else
			{
				foreach (XTextElement item in z0ytk)
				{
					if (item is ElementType)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public new virtual void z0ark(bool p0)
	{
		XTextElementList xTextElementList = z0ntk;
		int count = xTextElementList.Count;
		if (p0)
		{
			XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
			for (int i = 0; i < count; i++)
			{
				XTextElement xTextElement = array[i];
				xTextElement.z0muk = i;
				if (xTextElement is XTextContainerElement)
				{
					((XTextContainerElement)xTextElement).z0ark(p0: true);
				}
			}
		}
		else
		{
			XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
			for (int j = 0; j < count; j++)
			{
				array2[j].z0muk = j;
			}
		}
	}

	public virtual bool z0fi()
	{
		return base.z0htk();
	}

	public void z0hrk(string p0)
	{
		z0cek(p0, (z0ZzZzbcj)255, p2: false, p3: true);
	}

	public new virtual XTextElement z0dtk()
	{
		if (z0ntk == null)
		{
			return null;
		}
		return z0ntk.z0krk();
	}

	internal virtual void z0re()
	{
		if (z0ntk == null || z0ntk.Count <= 0)
		{
			return;
		}
		if (z0ntk.Count == 1 && !(z0ntk[0] is XTextContainerElement))
		{
			z0ntk[0].z0yek(z0rik, this);
			return;
		}
		XTextDocument p = z0rik;
		for (int num = z0ntk.Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = z0ntk[num];
			xTextElement.z0muk = num;
			xTextElement.z0yek(p, this);
			if (xTextElement is XTextContainerElement)
			{
				((XTextContainerElement)xTextElement).z0re();
			}
		}
	}
}
