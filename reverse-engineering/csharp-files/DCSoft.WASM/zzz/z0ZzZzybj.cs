using System;
using System.Runtime.CompilerServices;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzybj : z0ZzZznnj
{
	[CompilerGenerated]
	private sealed class z0ruk
	{
		public z0ZzZzlbj z0rek;

		public z0ZzZzybj z0tek;

		public double z0yek;

		public XTextInputFieldElement z0uek;

		internal void z0eek(double p0)
		{
			if (z0yek != p0)
			{
				z0tek.z0eek(p0, z0uek, z0rek);
			}
		}
	}

	[CompilerGenerated]
	private sealed class z0puk
	{
		public string z0rek;

		public z0ZzZzlbj z0tek;

		public XTextInputFieldElement z0yek;

		internal void z0eek(object p0, EventArgs p1)
		{
			if (z0yek.InnerValue != z0rek)
			{
				if (z0tek.Document.z0uik())
				{
					z0tek.Document.z0imk().z0eek("InnerValue", z0yek.InnerValue, z0rek, z0yek);
				}
				z0yek.InnerValue = z0rek;
			}
			z0yek.z0jr().z0apk().z0vv(z0yek);
		}
	}

	private ElementValueEditResult z0eek(double p0, XTextInputFieldElement p1, z0ZzZzlbj p2)
	{
		string z0rek = null;
		string text = null;
		if (z0ZzZzbok.z0eek(p0))
		{
			text = string.Empty;
			z0rek = string.Empty;
		}
		else
		{
			text = ((p1.DisplayFormat == null || p1.DisplayFormat.IsEmpty) ? p0.ToString() : p1.DisplayFormat.Execute(p0.ToString()));
			if (p2.EditControl.z0cuk().BehaviorOptions.DisplayFormatToInnerValue && p1.DisplayFormat != null && !p1.DisplayFormat.IsEmpty)
			{
				z0rek = p1.DisplayFormat.Execute(p0.ToString());
			}
			else
			{
				z0rek = p0.ToString();
			}
		}
		if (p1.Text != text)
		{
			string text2 = p1.Text;
			string innerValue = p1.InnerValue;
			WriterBeforeFieldContentEditEventArgs e = new WriterBeforeFieldContentEditEventArgs(p1, null, null, "XTextInputFieldElementNumericValueEditor");
			e.NewText = text;
			e.NewValue = z0rek;
			p2.EditControl.z0eek(e);
			if (e.Cancel)
			{
				return ElementValueEditResult.UserCancel;
			}
			text = e.NewText;
			z0rek = e.NewValue;
			p1.z0jr().z0ytk();
			XTextInputFieldElementBase.z0yrk = delegate
			{
				if (p1.InnerValue != z0rek)
				{
					if (p2.Document.z0uik())
					{
						p2.Document.z0imk().z0eek("InnerValue", p1.InnerValue, z0rek, p1);
					}
					p1.InnerValue = z0rek;
				}
				p1.z0jr().z0apk().z0vv(p1);
			};
			SetContainerTextArgs setContainerTextArgs = new SetContainerTextArgs();
			setContainerTextArgs.NewText = text;
			setContainerTextArgs.AccessFlags = (z0ZzZzbcj)z0ZzZzmpk.z0eek(255, 2, p2: false);
			setContainerTextArgs.ShowUI = true;
			setContainerTextArgs.LogUndo = true;
			setContainerTextArgs.DisablePermission = false;
			setContainerTextArgs.UpdateContent = true;
			setContainerTextArgs.RaiseDocumentContentChangedEvent = false;
			setContainerTextArgs.FocusContainer = true;
			setContainerTextArgs.IgnoreDisplayFormat = true;
			setContainerTextArgs.EventSource = ContentChangedEventSource.ValueEditor;
			if (p1.z0do(setContainerTextArgs))
			{
				p1.InnerValue = z0rek;
				p2.Document.z0nuk();
				p2.z0eek(p0: true);
				p2.z0rx();
				WriterAfterFieldContentEditEventArgs p3 = new WriterAfterFieldContentEditEventArgs(p1, null, null, "XTextInputFieldElementNumericValueEditor", text2, innerValue);
				e.NewText = text;
				e.NewValue = z0rek;
				p2.EditControl.z0eek(p3);
				return ElementValueEditResult.UserAccept;
			}
			p2.Document.z0mrk();
			return ElementValueEditResult.UserCancel;
		}
		return ElementValueEditResult.UserCancel;
	}

	public override ElementValueEditResult z0kc(z0ZzZzznj p0, z0ZzZzmnj p1)
	{
		z0ZzZzlbj z0rek = (z0ZzZzlbj)p0;
		if (z0rek.EditControl != null && !z0rek.EditControl.z0cuk().BehaviorOptions.EnableCalculateControl)
		{
			return ElementValueEditResult.UserCancel;
		}
		XTextInputFieldElement z0uek = (XTextInputFieldElement)p1.z0tek();
		string text = z0uek.InnerValue;
		if (string.IsNullOrEmpty(text))
		{
			text = z0uek.Text;
		}
		double z0yek = 0.0;
		if (!double.TryParse(text, out z0yek))
		{
			z0yek = 0.0 / 0.0;
		}
		z0rek.EditControl.z0lh().z0bz(z0uek, z0yek, delegate(double num)
		{
			if (z0yek != num)
			{
				z0eek(num, z0uek, z0rek);
			}
		});
		return ElementValueEditResult.OpeingUI;
	}

	public override ElementValueEditorEditStyle z0lc(z0ZzZzznj p0, z0ZzZzmnj p1)
	{
		if (p0.EditControl != null && !p0.EditControl.z0cuk().BehaviorOptions.EnableCalculateControl)
		{
			return ElementValueEditorEditStyle.None;
		}
		return ElementValueEditorEditStyle.DropDown;
	}
}
