using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzubj : z0ZzZznnj
{
	[CompilerGenerated]
	private sealed class z0tuk
	{
		public z0ZzZzlbj z0rek;

		public DateTime z0tek;

		public bool z0yek;

		public z0ZzZzubj z0uek;

		public XTextInputFieldElement z0iek;

		internal void z0eek(DateTime p0)
		{
			if (!z0yek)
			{
				z0uek.z0eek(p0, z0iek, z0rek);
			}
			else if (p0 != z0tek)
			{
				z0uek.z0eek(p0, z0iek, z0rek);
			}
		}
	}

	[CompilerGenerated]
	private sealed class z0ouk
	{
		public XTextInputFieldElement z0rek;

		public z0ZzZzlbj z0tek;

		public string z0yek;

		internal void z0eek(object p0, EventArgs p1)
		{
			if (z0rek.InnerValue != z0yek)
			{
				if (z0tek.Document.z0uik())
				{
					z0tek.Document.z0imk().z0eek("InnerValue", z0rek.InnerValue, z0yek, z0rek);
				}
				z0rek.InnerValue = z0yek;
			}
		}
	}

	private ElementValueEditResult z0eek(DateTime p0, XTextInputFieldElement p1, z0ZzZzlbj p2)
	{
		string z0yek = null;
		string text = null;
		if (p0 == DateTime.MinValue)
		{
			text = string.Empty;
			z0yek = string.Empty;
		}
		else
		{
			z0ZzZzsok z0ZzZzsok2 = ((XTextInputFieldElementBase)p1).z0frk();
			text = ((z0ZzZzsok2 == null || z0ZzZzsok2.IsEmpty) ? p0.ToString(z0ZzZzkfh.z0iek) : z0ZzZzsok2.Execute(p0.ToString()));
			z0yek = p0.ToString(z0ZzZzkfh.z0iek);
		}
		if (p1.z0zwk("numberdisplayedintibetan") == "true")
		{
			string[] array = new string[16]
			{
				"༠", "༡", "༢", "༣", "༤", "༥", "༦", "༧", "༨", "༩",
				"ལ\u0f7c་", "ཟ\u0fb3་བ།", "ཉ\u0f72་མ།", "ད\u0f74ས", "ས\u0f90ར་མ་", "ས\u0f90ར་ཆ་"
			};
			string text2 = "";
			for (int i = 0; i < text.Length; i++)
			{
				string text3 = text[i].ToString();
				switch (text3)
				{
				case " ":
					text2 += text3;
					break;
				case "年":
					text2 += array[10];
					break;
				case "月":
					text2 += array[11];
					break;
				case "日":
					text2 += array[12];
					break;
				case "时":
					text2 += array[13];
					break;
				case "分":
					text2 += array[14];
					break;
				case "秒":
					text2 += array[15];
					break;
				default:
				{
					int num = -2147483648;
					text2 = ((!int.TryParse(text3, out num)) ? (text2 + text3) : (text2 + array[num]));
					break;
				}
				}
			}
			text = text2;
		}
		if (p1.Text != text)
		{
			string text4 = p1.Text;
			string innerValue = p1.InnerValue;
			WriterBeforeFieldContentEditEventArgs e = new WriterBeforeFieldContentEditEventArgs(p1, null, null, "XTextInputFieldElementTimeValueEditor");
			e.NewText = text;
			e.NewValue = z0yek;
			p2.EditControl.z0eek(e);
			if (e.Cancel)
			{
				return ElementValueEditResult.UserCancel;
			}
			text = e.NewText;
			z0yek = e.NewValue;
			p1.z0jr().z0ytk();
			XTextInputFieldElementBase.z0yrk = delegate
			{
				if (p1.InnerValue != z0yek)
				{
					if (p2.Document.z0uik())
					{
						p2.Document.z0imk().z0eek("InnerValue", p1.InnerValue, z0yek, p1);
					}
					p1.InnerValue = z0yek;
				}
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
				p1.InnerValue = z0yek;
				p2.Document.z0nuk();
				p2.z0eek(p0: true);
				p2.z0rx();
				WriterAfterFieldContentEditEventArgs p3 = new WriterAfterFieldContentEditEventArgs(p1, null, null, "XTextInputFieldElementTimeValueEditor", text4, innerValue);
				e.NewText = text;
				e.NewValue = z0yek;
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
		XTextInputFieldElement z0iek = (XTextInputFieldElement)p1.z0tek();
		string text = z0iek.InnerValue;
		if (string.IsNullOrEmpty(text))
		{
			text = z0iek.Text;
		}
		DateTime z0tek;
		DateTime result = (z0tek = z0iek.z0jr().z0jpk());
		string format = null;
		if (z0iek.DisplayFormat != null && z0iek.DisplayFormat.Format != null)
		{
			format = z0iek.DisplayFormat.Format;
		}
		bool z0yek = false;
		if (!DateTime.TryParseExact(text, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out z0tek))
		{
			if (text == string.Empty || !DateTime.TryParse(text, out result))
			{
				z0yek = false;
				z0tek = result;
			}
			else
			{
				z0yek = true;
				z0tek = DateTime.Parse(text);
			}
		}
		z0rek.EditControl.z0lh().z0pz(z0iek, z0tek, z0iek.FieldSettings.z0nek(), delegate(DateTime dateTime)
		{
			if (!z0yek)
			{
				z0eek(dateTime, z0iek, z0rek);
			}
			else if (dateTime != z0tek)
			{
				z0eek(dateTime, z0iek, z0rek);
			}
		});
		return ElementValueEditResult.OpeingUI;
	}

	public override ElementValueEditorEditStyle z0lc(z0ZzZzznj p0, z0ZzZzmnj p1)
	{
		return ElementValueEditorEditStyle.DropDown;
	}
}
