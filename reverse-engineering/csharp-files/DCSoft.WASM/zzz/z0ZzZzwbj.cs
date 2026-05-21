using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzwbj : z0ZzZznnj
{
	[CompilerGenerated]
	private sealed class z0muk
	{
		public XTextInputFieldElement z0rek;

		public bool z0tek;

		public z0ZzZzlbj z0yek;

		public DateTime z0uek;

		internal void z0eek(DateTime p0)
		{
			if (p0 != z0uek || (p0 == z0uek && z0uek == DateTime.MinValue))
			{
				z0ZzZzwbj.z0eek(p0, z0rek, z0yek, z0tek);
			}
		}
	}

	[CompilerGenerated]
	private sealed class z0lik
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

	internal static ElementValueEditResult z0eek(z0ZzZzlbj p0, z0ZzZzmnj p1, bool p2)
	{
		XTextInputFieldElement z0rek = (XTextInputFieldElement)p1.z0tek();
		string format = null;
		if (z0rek.DisplayFormat != null)
		{
			format = z0rek.DisplayFormat.Format;
		}
		string text = z0rek.InnerValue;
		if (string.IsNullOrEmpty(text))
		{
			text = z0rek.Text;
		}
		DateTime z0uek;
		DateTime result = (z0uek = z0rek.z0jr().z0jpk());
		if (!DateTime.TryParseExact(text, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out z0uek))
		{
			if (text == string.Empty || !DateTime.TryParse(text, out result))
			{
				z0uek = DateTime.MinValue;
			}
			else
			{
				z0uek = DateTime.Parse(text);
			}
		}
		p0.EditControl.z0lh().z0pz(z0rek, z0uek, z0rek.z0oek(), delegate(DateTime dateTime)
		{
			if (dateTime != z0uek || (dateTime == z0uek && z0uek == DateTime.MinValue))
			{
				z0eek(dateTime, z0rek, p0, p2);
			}
		});
		return ElementValueEditResult.OpeingUI;
	}

	public override ElementValueEditorEditStyle z0lc(z0ZzZzznj p0, z0ZzZzmnj p1)
	{
		return ElementValueEditorEditStyle.DropDown;
	}

	private static ElementValueEditResult z0eek(DateTime p0, XTextInputFieldElement p1, z0ZzZzlbj p2, bool p3)
	{
		string z0rek = null;
		string text = null;
		if (p0 == DateTime.MinValue)
		{
			text = string.Empty;
			z0rek = string.Empty;
		}
		else
		{
			z0ZzZzsok z0ZzZzsok2 = ((XTextInputFieldElementBase)p1).z0frk();
			text = (z0rek = ((z0ZzZzsok2 != null && !z0ZzZzsok2.IsEmpty) ? z0ZzZzsok2.Execute(p0.ToString()) : ((!p3) ? p0.ToString(z0ZzZzkfh.z0mek) : p0.ToString(z0ZzZzkfh.z0qrk))));
			if (p1.z0oek() == InputFieldEditStyle.DateTime)
			{
				z0rek = p0.ToString(z0ZzZzkfh.z0qrk);
			}
			else if (p1.z0oek() == InputFieldEditStyle.DateTimeWithoutSecond)
			{
				z0rek = p0.ToString(z0ZzZzkfh.z0mek);
			}
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
		if (p1.Text != text || p1.InnerValue != z0rek)
		{
			string text4 = p1.Text;
			string innerValue = p1.InnerValue;
			WriterBeforeFieldContentEditEventArgs e = new WriterBeforeFieldContentEditEventArgs(p1, null, null, "XTextInputFieldElementDateTimeValueEditor");
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
			if (p1.z0do(setContainerTextArgs) || p1.InnerValue != z0rek)
			{
				p1.InnerValue = z0rek;
				p2.Document.z0nuk();
				p2.z0eek(p0: true);
				p2.z0rx();
				WriterAfterFieldContentEditEventArgs p4 = new WriterAfterFieldContentEditEventArgs(p1, null, null, "XTextInputFieldElementDateTimeValueEditor", text4, innerValue);
				e.NewText = text;
				e.NewValue = z0rek;
				p2.EditControl.z0eek(p4);
				p2.z0px();
				return ElementValueEditResult.UserAccept;
			}
			p2.Document.z0mrk();
			p2.z0px();
			return ElementValueEditResult.UserCancel;
		}
		return ElementValueEditResult.UserCancel;
	}

	public override ElementValueEditResult z0kc(z0ZzZzznj p0, z0ZzZzmnj p1)
	{
		return z0eek((z0ZzZzlbj)p0, p1, p2: true);
	}
}
