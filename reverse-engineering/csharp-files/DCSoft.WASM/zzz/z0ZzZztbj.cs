using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZztbj : z0ZzZznnj
{
	[CompilerGenerated]
	private sealed class z0zuk
	{
		public XTextInputFieldElement z0rek;

		public z0ZzZztbj z0tek;

		internal void z0eek(string p0, string p1)
		{
			z0tek.z0eek(z0rek, p0, p1);
		}
	}

	[CompilerGenerated]
	private sealed class z0rik_jiejie20260327142557
	{
		public string z0rek;

		public XTextDocument z0tek;

		public XTextInputFieldElement z0yek;

		internal void z0eek(object p0, EventArgs p1)
		{
			if (z0yek.InnerValue != z0rek)
			{
				if (z0tek.z0uik())
				{
					z0tek.z0imk().z0eek("InnerValue", z0yek.InnerValue, z0rek, z0yek);
				}
				z0yek.InnerValue = z0rek;
			}
			z0yek.z0jr().z0apk().z0vv(z0yek);
		}
	}

	public override ElementValueEditResult z0kc(z0ZzZzznj p0, z0ZzZzmnj p1)
	{
		p0.EditControl.z0mik();
		p1.z0rek_jiejie20260327142557();
		if (p1.z0tek() is XTextInputFieldElement xTextInputFieldElement)
		{
			z0ZzZzdvj p2 = z0eek(xTextInputFieldElement);
			return z0eek((z0ZzZzlbj)p0, p1, xTextInputFieldElement, p2);
		}
		return ElementValueEditResult.UserCancel;
	}

	internal static string z0eek(z0ZzZzdbj p0, XTextInputFieldElement p1, int[] p2, bool p3)
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		StringBuilder stringBuilder = new StringBuilder();
		z0ZzZzdvj z0ZzZzdvj2 = p1.z0eek(null, p1: true, null);
		if (z0ZzZzdvj2 == null || z0ZzZzdvj2.Count == 0)
		{
			return null;
		}
		for (int i = 0; i < z0ZzZzdvj2.Count; i++)
		{
			ListItem listItem = z0ZzZzdvj2[i];
			bool flag = Array.IndexOf(p2, i) >= 0;
			string text = (p3 ? listItem.Text : listItem.Value);
			if (string.IsNullOrEmpty(text))
			{
				text = listItem.Text;
			}
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			if (flag)
			{
				list.Add(text);
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(p1.FieldSettings.z0oek());
				}
				stringBuilder.Append(text);
			}
			else
			{
				list2.Add(text);
			}
		}
		string text2 = p1.FieldSettings.z0cek();
		FormatListItemsEventArgs e = new FormatListItemsEventArgs(p0, p1.FieldSettings.z0tek(), p0.z0ruk(), p1, list.ToArray(), list2.ToArray(), text2);
		e.Result = stringBuilder.ToString();
		if (!string.IsNullOrEmpty(p1.FieldSettings.z0tek()))
		{
			StringBuilder stringBuilder2 = new StringBuilder();
			string[] array = z0ZzZznik.AnalyseVariableString(p1.FieldSettings.z0tek(), "[", "]");
			for (int j = 0; j < array.Length; j++)
			{
				if (j % 2 == 0)
				{
					stringBuilder2.Append(array[j]);
					continue;
				}
				int num = 0;
				if (string.Compare(array[j], z0ZzZzkfh.z0ktk, true) == 0)
				{
					num = 1;
				}
				else if (string.Compare(array[j], z0ZzZzkfh.z0oek, true) == 0)
				{
					num = -1;
				}
				if (num == 0)
				{
					stringBuilder2.Append("[" + array[j] + "]");
					continue;
				}
				bool flag2 = true;
				for (int k = 0; k < z0ZzZzdvj2.Count; k++)
				{
					bool flag3 = p2 != null && Array.IndexOf(p2, k) >= 0;
					switch (num)
					{
					case 1:
						if (!flag3)
						{
							continue;
						}
						break;
					case -1:
						if (flag3)
						{
							continue;
						}
						break;
					}
					if (!flag2 && !string.IsNullOrEmpty(text2))
					{
						stringBuilder2.Append(text2);
					}
					flag2 = false;
					if (p3)
					{
						stringBuilder2.Append(z0ZzZzdvj2[k].Text);
						continue;
					}
					string text3 = z0ZzZzdvj2[k].Value;
					if (string.IsNullOrEmpty(text3))
					{
						text3 = z0ZzZzdvj2[k].Text;
					}
					stringBuilder2.Append(text3);
				}
			}
			e.Result = stringBuilder2.ToString();
		}
		p0.z0eek(e);
		return e.Result;
	}

	private ElementValueEditResult z0eek(XTextInputFieldElement p0, string p1, string p2)
	{
		string text = p0.Text;
		string innerValue = p0.InnerValue;
		if (p0.z0bu().ForceRaiseEventAfterFieldContentEdit || p0.Text != p1)
		{
			StringBuilder stringBuilder = new StringBuilder();
			z0ZzZzdvj selectedItems = new z0ZzZzdvj();
			WriterBeforeFieldContentEditEventArgs e = new WriterBeforeFieldContentEditEventArgs(p0, string.Empty, selectedItems, "XTextInputFieldElementListValueEditor");
			e.NewText = p1;
			e.NewValue = p2;
			p0.z0cu().z0eek(e);
			if (e.Cancel)
			{
				return ElementValueEditResult.None;
			}
			p1 = e.NewText;
			p2 = e.NewValue;
			XTextDocument z0tek = p0.z0jr();
			z0tek.z0ytk();
			XTextInputFieldElementBase.z0yrk = delegate
			{
				if (p0.InnerValue != p2)
				{
					if (z0tek.z0uik())
					{
						z0tek.z0imk().z0eek("InnerValue", p0.InnerValue, p2, p0);
					}
					p0.InnerValue = p2;
				}
				p0.z0jr().z0apk().z0vv(p0);
			};
			SetContainerTextArgs setContainerTextArgs = new SetContainerTextArgs();
			setContainerTextArgs.NewText = p1;
			setContainerTextArgs.AccessFlags = (z0ZzZzbcj)z0ZzZzmpk.z0eek(255, 2, p2: false);
			setContainerTextArgs.ShowUI = true;
			setContainerTextArgs.LogUndo = true;
			setContainerTextArgs.DisablePermission = false;
			setContainerTextArgs.UpdateContent = true;
			setContainerTextArgs.RaiseDocumentContentChangedEvent = true;
			setContainerTextArgs.FocusContainer = true;
			setContainerTextArgs.EventSource = ContentChangedEventSource.ValueEditor;
			if (p0.z0do(setContainerTextArgs) || p0.z0bu().ForceRaiseEventAfterFieldContentEdit)
			{
				p0.z0eek(p1, p2);
				z0tek.z0nuk();
				WriterAfterFieldContentEditEventArgs p3 = new WriterAfterFieldContentEditEventArgs(p0, stringBuilder.ToString(), selectedItems, "XTextInputFieldElementListValueEditor", text, innerValue);
				e.NewText = p1;
				e.NewValue = p2;
				p0.z0cu().z0eek(p3);
				p0.z0cu().z0cok();
				p0.z0cu().z0yek(p0);
				return ElementValueEditResult.UserAccept;
			}
			z0tek.z0mrk();
			return ElementValueEditResult.UserAccept;
		}
		return ElementValueEditResult.UserCancel;
	}

	private ElementValueEditResult z0eek(z0ZzZzlbj p0, z0ZzZzmnj p1, XTextInputFieldElement p2, z0ZzZzdvj p3)
	{
		if (p0.EditControl == null || !p0.EditControl.z0aik())
		{
			return ElementValueEditResult.None;
		}
		if (p0 == null || p0.EditControl == null || ((z0ZzZzmwh)p0.EditControl).z0rek() || !((z0ZzZzmwh)p0.EditControl).z0eek())
		{
			return ElementValueEditResult.None;
		}
		p2.z0jr().z0bik();
		p0.EditControl.z0cok();
		if (p3 == null)
		{
			p3 = new z0ZzZzdvj();
		}
		if ((p3 == null || p3.Count == 0) && p2.FieldSettings != null)
		{
			p2.FieldSettings.z0uek();
		}
		if (string.IsNullOrEmpty(p2.InnerValue))
		{
			_ = p2.Text;
		}
		p0.EditControl.z0nj(p2, p3, delegate(string p4, string p5)
		{
			z0eek(p2, p4, p5);
		});
		return ElementValueEditResult.OpeingUI;
	}

	public override ElementValueEditorEditStyle z0lc(z0ZzZzznj p0, z0ZzZzmnj p1)
	{
		return ElementValueEditorEditStyle.DropDown;
	}

	private z0ZzZzdvj z0eek(XTextInputFieldElement p0)
	{
		InputFieldSettings fieldSettings = p0.FieldSettings;
		z0ZzZzsvj z0ZzZzsvj2 = p0.FieldSettings.z0zek();
		if (!fieldSettings.z0uek())
		{
			if (z0ZzZzsvj2 == null)
			{
				return null;
			}
			if (z0ZzZzsvj2.IsEmpty && (z0ZzZzsvj2.z0eek() == null || z0ZzZzsvj2.z0eek().Count == 0))
			{
				return null;
			}
		}
		return p0.z0eek(null, p1: true, null);
	}
}
