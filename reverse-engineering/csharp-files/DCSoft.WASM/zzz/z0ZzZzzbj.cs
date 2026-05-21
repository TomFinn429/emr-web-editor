using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WASM;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzzbj : z0ZzZzhvj
{
	private static Encoding z0tek = Encoding.Default;

	private static Dictionary<string, XTextElementList> z0yek_jiejie20260327142557 = null;

	private bool z0uek = true;

	private int z0eek(XTextLabelElementBase p0, z0ZzZzrlh p1)
	{
		p0.z0eek(p0: false);
		p0.z0eek(null);
		XTextDocument xTextDocument = p0.z0jr();
		if (p0.ValueBinding != null && p0.ValueBinding.z0eek() && !p0.ValueBinding.IsEmptyBinding)
		{
			if (p0.ValueBinding.ProcessState == DCProcessStates.Never)
			{
				return 0;
			}
			if (!z0eek(p1, p0.ValueBinding, xTextDocument))
			{
				return 0;
			}
			if (!xTextDocument.z0bu().EnableDataBinding)
			{
				return 0;
			}
			z0ZzZzvbj z0ZzZzvbj2 = z0eek(p0, p0.ValueBinding, p1);
			if (z0uek && (z0ZzZzvbj2 == null || z0ZzZzvbj2.z0bek()))
			{
				return 0;
			}
			p0.z0eek(z0ZzZzvbj2);
			object obj = null;
			if (z0ZzZzvbj2 != null && !z0ZzZzvbj2.z0eek())
			{
				obj = z0ZzZzvbj2.z0tek();
				p0.z0eek(p0: true);
			}
			string text = null;
			text = ((obj != null && !DBNull.Value.Equals(obj)) ? Convert.ToString(obj) : null);
			if (p0.ValueBinding.ProcessState == DCProcessStates.Once)
			{
				p0.ValueBinding.ProcessState = DCProcessStates.Never;
			}
			if (p0.Text != text)
			{
				p0.Text = text;
				if (!p1.z0eek())
				{
					p0.z0jo();
				}
				return 1;
			}
		}
		return 0;
	}

	private bool z0eek(z0ZzZzrlh p0, string p1)
	{
		if (p1 == null || p1.Length == 0)
		{
			return true;
		}
		if (p0.z0mek() == null && p0.z0pek() != null && p0.z0pek().Length != 0)
		{
			bool flag = false;
			bool flag2 = false;
			string[] array = p0.z0pek();
			foreach (string text in array)
			{
				if (text != null && text.Length > 0)
				{
					flag2 = true;
					if (string.Compare(text, p1, true) == 0)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag2 && !flag)
			{
				return false;
			}
		}
		return true;
	}

	public override bool z0wv_jiejie20260327142557(XTextDocument p0)
	{
		bool result = false;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0nek<XTextInputFieldElement>().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)z0bpk.Current;
				if (xTextInputFieldElement.z0bek())
				{
					xTextInputFieldElement.Modified = false;
					result = true;
				}
			}
		}
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0nek<XTextCheckBoxElementBase>().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)z0bpk.Current;
			if (xTextCheckBoxElementBase.Checked)
			{
				xTextCheckBoxElementBase.Checked = false;
				xTextCheckBoxElementBase.Modified = false;
				result = true;
			}
			if (((XTextObjectElement)xTextCheckBoxElementBase).z0pek() != ((XTextObjectElement)xTextCheckBoxElementBase).z0pek())
			{
				xTextCheckBoxElementBase.Modified = true;
				result = true;
			}
		}
		return result;
	}

	public override int z0qv(XTextDocument p0, string p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		z0uek = p0.z0vtk().BehaviorOptions.IgnoreDataBindingWhenMissValue;
		p0.z0nik();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0nek<XTextTableElement>().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableElement xTextTableElement = (XTextTableElement)z0bpk.Current;
				xTextTableElement.z0xek(p0: true);
				z0cb(xTextTableElement);
			}
		}
		z0ZzZzrlh z0ZzZzrlh2 = new z0ZzZzrlh();
		z0ZzZzrlh2.z0rek(p0: true);
		if (!string.IsNullOrEmpty(p1))
		{
			z0ZzZzrlh2.z0eek(p1.Split(','));
		}
		p0.z0vek((object)null);
		int num = z0xb(p0, z0ZzZzrlh2);
		if (num > 0)
		{
			p0.z0vik();
			if (p0.z0rik() != null)
			{
				p0.z0rik().z0yw();
			}
			if (p0.z0bu().EnableCopySource)
			{
				XTextElementList xTextElementList = z0ZzZzrlh2.z0rek();
				z0ZzZzyxj z0ZzZzyxj2 = p0.z0apk();
				if (z0ZzZzyxj2 != null && xTextElementList != null && xTextElementList.Count > 0)
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextElement current = z0bpk.Current;
						if (current is XTextContainerElement)
						{
							z0ZzZzyxj2.z0vv(current);
						}
					}
				}
			}
			p0.z0li();
		}
		return num;
	}

	private int z0eek(XTextCheckBoxElementBase p0, z0ZzZzrlh p1)
	{
		z0ZzZzevj z0ZzZzevj2 = null;
		z0ZzZzevj2 = p0.ValueBinding;
		if (z0ZzZzevj2 == null)
		{
			return 0;
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("args");
		}
		if (!p1.z0tek_jiejie20260327142557())
		{
			p0.z0yek(p0: false);
		}
		if (p0.z0jr().z0bek(z0ZzZzevj2))
		{
			if (!z0eek(p1, z0ZzZzevj2, p0.z0jr()))
			{
				return 0;
			}
			if (!p1.z0tek_jiejie20260327142557())
			{
				p0.ValueBinding.z0rek(p0: true);
			}
			z0ZzZzvbj z0ZzZzvbj2 = z0eek(p0, z0ZzZzevj2, p1);
			if (!p1.z0tek_jiejie20260327142557())
			{
				p0.z0eek(z0ZzZzvbj2);
			}
			if (z0uek && (z0ZzZzvbj2 == null || z0ZzZzvbj2.z0bek()))
			{
				return 0;
			}
			bool flag = false;
			if (z0ZzZzvbj2 != null && !z0ZzZzvbj2.z0eek())
			{
				if (!p1.z0tek_jiejie20260327142557())
				{
					p0.z0yek(p0: true);
				}
				object obj = z0ZzZzvbj2.z0tek();
				if (obj == null || DBNull.Value.Equals(obj))
				{
					flag = p0.DefaultCheckedForValueBinding;
				}
				else if (obj is bool)
				{
					flag = (bool)obj;
				}
				else if (!string.IsNullOrEmpty(p0.CheckedValue))
				{
					flag = new z0ZzZzzuk(Convert.ToString(obj), ',').z0tek(p0.CheckedValue);
				}
				else
				{
					bool flag2 = false;
					flag = ((!bool.TryParse(Convert.ToString(obj), out flag2)) ? p0.DefaultCheckedForValueBinding : flag2);
				}
			}
			if (p1.z0tek_jiejie20260327142557())
			{
				if (p0.Checked != flag)
				{
					DetectResultForValueBindingModified p2 = new DetectResultForValueBindingModified(p0.ValueBinding, p0, p0.Checked.ToString(), flag.ToString());
					p1.z0eek(p2);
				}
				return 0;
			}
			if (z0ZzZzevj2.ProcessState == DCProcessStates.Once)
			{
				z0ZzZzevj2.ProcessState = DCProcessStates.Never;
			}
			if (p0.Checked != flag)
			{
				p0.EditorChecked = flag;
				if (!p1.z0eek())
				{
					p0.z0jo();
				}
				p1.z0eek(p0);
				ContentChangedEventArgs p3 = new ContentChangedEventArgs(p0.z0jr(), p0, ContentChangedEventSource.DataBinding);
				p0.z0pi(null, p3);
				p0.Modified = true;
				return 1;
			}
		}
		return 0;
	}

	private int z0eek(XTextChartElement p0, z0ZzZzrlh p1)
	{
		if (!p0.z0bu().EnableDataBinding)
		{
			return 0;
		}
		if (!p0.z0rek())
		{
			return 0;
		}
		object obj = p0.z0jr().z0qrk(p0.z0iek());
		if (obj == null)
		{
			return 0;
		}
		z0ZzZzhok z0ZzZzhok2 = new z0ZzZzhok(obj);
		z0ZzZzhok2.z0uek().z0eek(p0.z0yek());
		z0ZzZzhok2.z0uek().z0eek(p0.z0oek());
		z0ZzZzhok2.z0uek().z0eek(p0.z0cek());
		z0ZzZzhok2.z0uek().z0eek(p0.z0mek());
		z0ZzZzhok2.z0uek().z0eek(p0.z0uek());
		z0ZzZzhok2.z0uek().z0eek(p0.z0pek());
		z0ZzZzhok2.z0rek();
		z0ZzZzhok2.z0yek();
		int num = 0;
		while (z0ZzZzhok2.z0tek())
		{
			DCChartDataItem dCChartDataItem = new DCChartDataItem();
			if (!z0ZzZzhok2.z0uek()[0].z0yek())
			{
				dCChartDataItem.GroupName = Convert.ToString(z0ZzZzhok2.z0eek(0));
			}
			if (!z0ZzZzhok2.z0uek()[1].z0yek())
			{
				dCChartDataItem.Link = Convert.ToString(z0ZzZzhok2.z0eek(1));
			}
			if (!z0ZzZzhok2.z0uek()[2].z0yek())
			{
				dCChartDataItem.SeriesName = Convert.ToString(z0ZzZzhok2.z0eek(2));
			}
			if (!z0ZzZzhok2.z0uek()[3].z0yek())
			{
				dCChartDataItem.Text = Convert.ToString(z0ZzZzhok2.z0eek(3));
			}
			if (!z0ZzZzhok2.z0uek()[4].z0yek())
			{
				dCChartDataItem.TipText = Convert.ToString(z0ZzZzhok2.z0eek(4));
			}
			if (!z0ZzZzhok2.z0uek()[5].z0yek())
			{
				object obj2 = z0ZzZzhok2.z0eek(5);
				if (obj2 is double)
				{
					dCChartDataItem.Value = (double)obj2;
				}
				else
				{
					double value = 0.0;
					if (double.TryParse(Convert.ToString(obj2), out value))
					{
						dCChartDataItem.Value = value;
					}
				}
			}
			if (p0.z0bek() == null)
			{
				p0.z0eek(new DCChartDataItemList());
			}
			p0.z0bek().Add(dCChartDataItem);
			num++;
		}
		return num;
	}

	private int z0eek(XTextPieElement p0, z0ZzZzrlh p1)
	{
		if (!p0.z0bu().EnableDataBinding)
		{
			return 0;
		}
		if (!p0.z0tek())
		{
			return 0;
		}
		object obj = p0.z0jr().z0qrk(p0.DataSourceName);
		if (obj == null)
		{
			return 0;
		}
		z0ZzZzhok z0ZzZzhok2 = new z0ZzZzhok(obj);
		z0ZzZzhok2.z0uek().z0eek(p0.DataFieldNameForLink);
		z0ZzZzhok2.z0uek().z0eek(p0.DataFieldNameForText);
		z0ZzZzhok2.z0uek().z0eek(p0.DataFieldNameForTipText);
		z0ZzZzhok2.z0uek().z0eek(p0.DataFieldNameForValue);
		z0ZzZzhok2.z0uek().z0eek(p0.DataFieldNameForFillColorString);
		z0ZzZzhok2.z0rek();
		z0ZzZzhok2.z0yek();
		int num = 0;
		while (z0ZzZzhok2.z0tek())
		{
			DCPieDataItem dCPieDataItem = new DCPieDataItem();
			if (!z0ZzZzhok2.z0uek()[0].z0yek())
			{
				dCPieDataItem.Link = Convert.ToString(z0ZzZzhok2.z0eek(0));
			}
			if (!z0ZzZzhok2.z0uek()[1].z0yek())
			{
				dCPieDataItem.Text = Convert.ToString(z0ZzZzhok2.z0eek(1));
			}
			if (!z0ZzZzhok2.z0uek()[2].z0yek())
			{
				dCPieDataItem.TipText = Convert.ToString(z0ZzZzhok2.z0eek(2));
			}
			if (!z0ZzZzhok2.z0uek()[3].z0yek())
			{
				object obj2 = z0ZzZzhok2.z0eek(3);
				if (obj2 is double)
				{
					dCPieDataItem.Value = (double)obj2;
				}
				else
				{
					double value = 0.0;
					if (double.TryParse(Convert.ToString(obj2), out value))
					{
						dCPieDataItem.Value = value;
					}
				}
			}
			if (!z0ZzZzhok2.z0uek()[4].z0yek())
			{
				dCPieDataItem.ColorValue = Convert.ToString(z0ZzZzhok2.z0eek(4));
			}
			if (p0.DataItems == null)
			{
				p0.DataItems = new DCPieDataItemList();
			}
			p0.DataItems.Add(dCPieDataItem);
			num++;
		}
		return num;
	}

	public static Encoding z0eek()
	{
		if (z0tek == null)
		{
			z0tek = Encoding.Default;
		}
		return z0tek;
	}

	public override z0ZzZzylh z0av(XTextDocument p0, bool p1)
	{
		DocumentOptions documentOptions = p0.z0vu();
		if (documentOptions.EditOptions.ValueValidateMode == DocumentValueValidateMode.None)
		{
			return null;
		}
		z0ZzZzylh z0ZzZzylh2 = new z0ZzZzylh();
		List<string> list = new List<string>();
		string excludeKeywords = documentOptions.BehaviorOptions.ExcludeKeywords;
		if (excludeKeywords != null && excludeKeywords.Length > 0)
		{
			string[] array = excludeKeywords.Split(',', '|');
			foreach (string text in array)
			{
				if (text.Trim().Length > 0)
				{
					list.Add(text.Trim());
				}
			}
		}
		if (p0.z0tuk() != null && p0.z0tuk().Length > 0)
		{
			string[] array = p0.z0tuk().Split(',');
			foreach (string text2 in array)
			{
				if (text2.Trim().Length > 0)
				{
					list.Add(text2.Trim());
				}
			}
		}
		if (list.Count > 0 && z0ZzZzxcj.z0eek(148))
		{
			z0ZzZzvpj z0ZzZzvpj2 = new z0ZzZzvpj(p0);
			XTextElementList xTextElementList = p0.z0xyk().z0krk();
			z0ZzZzsmj z0ZzZzsmj2 = new z0ZzZzsmj();
			z0ZzZzsmj2.z0yek(p0: true);
			z0ZzZzsmj2.z0rek(p0: false);
			z0ZzZzsmj2.z0iek(p0: false);
			z0ZzZzsmj2.z0uek(p0: false);
			foreach (string item in list)
			{
				z0ZzZzsmj2.z0rek(item);
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextContentElement xTextContentElement = (XTextContentElement)z0bpk.Current;
					int p2 = 0;
					while (true)
					{
						p2 = z0ZzZzvpj2.z0eek(z0ZzZzsmj2, xTextContentElement.z0trk(), p2: false, p2);
						if (p2 < 0)
						{
							break;
						}
						z0ZzZztlh z0ZzZztlh2 = new z0ZzZztlh();
						z0ZzZztlh2.z0eek(xTextContentElement.z0trk()[p2]);
						z0ZzZztlh2.z0eek(ValueValidateResultTypes.ExcludeKeyword);
						z0ZzZztlh2.z0eek(item);
						z0ZzZztlh2.z0eek(ValueValidateLevel.Error);
						z0ZzZztlh2.z0tek(string.Format(z0ZzZziok.z0dtk(), item));
						z0ZzZzylh2.Add(z0ZzZztlh2);
						p2 += item.Length;
					}
				}
			}
		}
		XTextElementList xTextElementList2 = p0.z0rek<XTextCheckBoxElementBase>();
		if (xTextElementList2 != null && xTextElementList2.Count > 0)
		{
			List<string> list2 = new List<string>();
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)z0bpk.Current;
				if (!xTextCheckBoxElementBase.z0drk() || string.IsNullOrEmpty(xTextCheckBoxElementBase.Name) || list2.Contains(xTextCheckBoxElementBase.Name) || !xTextCheckBoxElementBase.Visible)
				{
					continue;
				}
				list2.Add(xTextCheckBoxElementBase.Name);
				XTextElementList xTextElementList3 = xTextCheckBoxElementBase.z0eek();
				bool flag = false;
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextElementList3.z0ltk())
				{
					while (z0bpk2.MoveNext())
					{
						if (((XTextCheckBoxElementBase)z0bpk2.Current).Checked)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					z0ZzZztlh z0ZzZztlh3 = new z0ZzZztlh();
					z0ZzZztlh3.z0eek(xTextCheckBoxElementBase);
					z0ZzZztlh3.z0eek(ValueValidateLevel.Error);
					z0ZzZztlh3.z0tek(string.Format(z0ZzZziok.z0lrk(), xTextCheckBoxElementBase.Name));
					z0ZzZztlh3.z0eek(ValueValidateResultTypes.ValueValidate);
					z0ZzZzylh2.Add(z0ZzZztlh3);
				}
			}
		}
		XTextElementList xTextElementList4 = p0.z0rek<XTextContainerElement>();
		if (xTextElementList4.Count > 0)
		{
			foreach (XTextContainerElement item2 in xTextElementList4.z0xrk())
			{
				if (!item2.EnableValueValidate)
				{
					continue;
				}
				XTextElement xTextElement = item2;
				bool flag2 = false;
				while (xTextElement != null && !(xTextElement is XTextDocumentContentElement))
				{
					if (xTextElement.z0aek().z0jyk >= 0)
					{
						flag2 = true;
						break;
					}
					if (!xTextElement.Visible)
					{
						flag2 = true;
						break;
					}
					xTextElement = xTextElement.z0ji();
				}
				if (!flag2)
				{
					z0ZzZztlh z0ZzZztlh4 = (p1 ? item2.z0frk() : z0gv(item2, p1: false));
					if (z0ZzZztlh4 != null)
					{
						z0ZzZzylh2.Add(z0ZzZztlh4);
					}
				}
			}
		}
		if (z0ZzZzylh2.Count > 1)
		{
			z0ZzZzylh2.z0eek();
		}
		return z0ZzZzylh2;
	}

	private string z0eek(XTextElement p0)
	{
		if (p0 is XTextInputFieldElementBase)
		{
			XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)p0;
			string iD = xTextInputFieldElementBase.ID;
			iD = xTextInputFieldElementBase.z0srk();
			if (string.IsNullOrEmpty(iD))
			{
				iD = xTextInputFieldElementBase.Name;
			}
			if (string.IsNullOrEmpty(iD))
			{
				iD = xTextInputFieldElementBase.z0ho();
			}
			return iD;
		}
		return p0.ID;
	}

	private XTextTableRowElement z0eek(XTextTableRowElement p0)
	{
		XTextTableRowElement xTextTableRowElement = p0.z0lr(p0: false) as XTextTableRowElement;
		xTextTableRowElement.z0oek(((XTextElement)p0).z0pek());
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0rek().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
			XTextTableCellElement xTextTableCellElement2 = xTextTableCellElement.z0lr(p0: false) as XTextTableCellElement;
			xTextTableCellElement2.z0oek(((XTextElement)xTextTableCellElement).z0pek());
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextTableCellElement.z0be().z0ltk())
			{
				while (z0bpk2.MoveNext())
				{
					XTextElement current = z0bpk2.Current;
					if (!(current is XTextImageElement))
					{
						xTextTableCellElement2.z0be().Add(current.z0lr(p0: true));
					}
				}
			}
			xTextTableRowElement.z0rek().Add(xTextTableCellElement2);
		}
		return xTextTableRowElement;
	}

	private bool z0eek(z0ZzZzrlh p0, z0ZzZzevj p1, XTextDocument p2)
	{
		if (p1 == null)
		{
			return true;
		}
		string dataSource = p1.DataSource;
		if (dataSource == null || dataSource.Length == 0)
		{
			return true;
		}
		if (p0.z0mek() == null && p0.z0pek() != null && p0.z0pek().Length != 0)
		{
			bool flag = false;
			bool flag2 = false;
			string[] array = p0.z0pek();
			foreach (string text in array)
			{
				if (text != null && text.Length > 0)
				{
					flag2 = true;
					if (string.Compare(text, dataSource, true) == 0)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag2 && !flag)
			{
				return false;
			}
		}
		return true;
	}

	internal void z0eek(XTextTableElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("table");
		}
		if (WriterControlForWASM.z0hyk)
		{
			if (!XTextTableElement.z0otk)
			{
				return;
			}
			if (z0yek_jiejie20260327142557 == null)
			{
				z0yek_jiejie20260327142557 = new Dictionary<string, XTextElementList>();
			}
			p0.z0pek((p0.ID != null) ? p0.ID : ("table" + DateTime.Now.ToString("yyyyMMddHHmmssfff")));
			XTextElementList xTextElementList = new XTextElementList();
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0stk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk.Current;
					xTextElementList.Add(xTextTableRowElement.z0lr(p0: true));
				}
			}
			z0yek_jiejie20260327142557[p0.z0yrk()] = xTextElementList;
		}
		else
		{
			p0.z0pek((string)null);
			if (XTextTableElement.z0otk)
			{
				byte[] array = p0.z0ee_jiejie20260327142557(p0: true).z0tek((string)null, p2: true);
				p0.z0pek(Convert.ToBase64String(array));
			}
		}
	}

	private int z0eek(XTextTableElement p0, z0ZzZzrlh p1)
	{
		XTextDocument xTextDocument = p0.z0jr();
		bool flag = false;
		if (!xTextDocument.z0bu().EnableDataBinding)
		{
			return 0;
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("args");
		}
		z0ZzZzevj z0ZzZzevj2 = (p0.z0pr() ? p0.ValueBinding : null);
		if (!z0eek(p1, z0ZzZzevj2, xTextDocument))
		{
			return 0;
		}
		int num = 0;
		p0.z0qrk();
		z0ZzZzvbj p2 = z0eek(p0, z0ZzZzevj2, p1);
		if (xTextDocument.z0bek(z0ZzZzevj2))
		{
			p2 = z0eek(p0, z0ZzZzevj2, p1);
		}
		p0.z0cek(p2);
		p0.z0li();
		XTextElementList xTextElementList = p0.z0stk();
		p0.z0qrk();
		XTextElementList xTextElementList2 = new XTextElementList();
		for (int i = 0; i < xTextElementList.Count; i++)
		{
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextElementList[i];
			if (xTextTableRowElement.z0pr() && xTextDocument.z0bek(xTextTableRowElement.ValueBinding))
			{
				List<XTextTableRowElement> list = new List<XTextTableRowElement>();
				for (int j = 0; j < xTextTableRowElement.z0uek() && i + j < xTextElementList.Count; j++)
				{
					list.Add(xTextTableRowElement);
				}
				i += xTextTableRowElement.z0uek() - 1;
				z0ZzZzvbj z0ZzZzvbj2 = z0eek(xTextTableRowElement, xTextTableRowElement.ValueBinding, p1);
				if (z0ZzZzvbj2 == null || z0ZzZzvbj2.z0eek())
				{
					continue;
				}
				z0ZzZzcbj z0ZzZzcbj2 = new z0ZzZzcbj();
				if (z0ZzZzvbj2.z0ov().z0rek())
				{
					if (z0ZzZzvbj2.z0nek() != null && z0ZzZzvbj2.z0nek().Count > 0)
					{
						z0ZzZzcbj2.AddRange(z0ZzZzvbj2.z0nek());
					}
				}
				else if (z0ZzZzvbj2.z0uek())
				{
					if (z0ZzZzvbj2.z0nek() == null || z0ZzZzvbj2.z0nek().Count == 0)
					{
						z0ZzZzvbj2.z0mek();
					}
					if (z0ZzZzvbj2.z0nek() != null)
					{
						z0ZzZzcbj2.AddRange(z0ZzZzvbj2.z0nek());
					}
				}
				else if (z0ZzZzvbj2.z0pv() is z0ZzZzoah)
				{
					if (z0ZzZzvbj2.z0nek() == null || z0ZzZzvbj2.z0nek().Count == 0)
					{
						z0ZzZzvbj2.z0jrk();
					}
					if (z0ZzZzvbj2.z0nek() != null)
					{
						z0ZzZzcbj2.AddRange(z0ZzZzvbj2.z0nek());
					}
				}
				else
				{
					z0ZzZzcbj2.Add(z0ZzZzvbj2);
				}
				if (xTextTableRowElement.ExpendForDataBinding)
				{
					bool flag2 = true;
					int num2 = 0;
					foreach (z0ZzZzvbj item in z0ZzZzcbj2)
					{
						foreach (XTextTableRowElement item2 in list)
						{
							XTextTableRowElement xTextTableRowElement2 = z0eek(item2);
							if (XTextTableElement.z0ttk != null && xTextTableRowElement2.z0qr("$DCADVISE$"))
							{
								xTextTableRowElement2.Attributes.z0rek("$DCADVISE$");
							}
							if (flag2)
							{
								item2.z0rek(p0: false);
							}
							else
							{
								item2.z0rek(p0: true);
							}
							xTextTableRowElement2.z0nu(p0);
							xTextTableRowElement2.z0bt(xTextDocument);
							xTextTableRowElement2.z0li();
							xTextTableRowElement2.z0cek(item);
							z0ZzZzrlh z0ZzZzrlh2 = new z0ZzZzrlh();
							z0ZzZzrlh2.z0rek(item);
							z0ZzZzrlh2.z0rek(p1.z0eek());
							z0eek(xTextTableRowElement2, z0ZzZzrlh2);
							xTextElementList2.Add(xTextTableRowElement2);
							flag = true;
							xTextTableRowElement2.z0li();
							num++;
							num2++;
						}
						flag2 = false;
					}
					if (xTextTableRowElement.z0jrk() <= 1)
					{
						continue;
					}
					int num3 = num2 % xTextTableRowElement.z0jrk();
					if (num3 <= 0)
					{
						continue;
					}
					num3 = xTextTableRowElement.z0jrk() - num3;
					for (int k = 0; k < num3; k++)
					{
						foreach (XTextTableRowElement item3 in list)
						{
							XTextTableRowElement xTextTableRowElement3 = z0eek(item3);
							if (XTextTableElement.z0ttk != null && xTextTableRowElement3.z0qr("$DCADVISE$"))
							{
								xTextTableRowElement3.Attributes.z0rek("$DCADVISE$");
							}
							item3.z0rek(p0: true);
							xTextTableRowElement3.z0nu(p0);
							xTextTableRowElement3.z0bt(xTextDocument);
							xTextTableRowElement3.z0li();
							xTextElementList2.Add(xTextTableRowElement3);
							flag = true;
						}
					}
					continue;
				}
				z0ZzZzrlh z0ZzZzrlh3 = new z0ZzZzrlh();
				z0ZzZzrlh3.z0rek(z0ZzZzcbj2[0]);
				z0ZzZzrlh3.z0rek(p1.z0eek());
				foreach (XTextTableRowElement item4 in list)
				{
					item4.z0rek(p0: false);
					int num4 = z0xb(item4, z0ZzZzrlh3);
					if (num4 > 0)
					{
						item4.z0li();
					}
					num += num4;
					xTextElementList2.Add(item4);
				}
			}
			else
			{
				z0ZzZzrlh z0ZzZzrlh4 = new z0ZzZzrlh();
				z0ZzZzrlh4.z0rek(p1.z0eek());
				z0ZzZzrlh4.z0eek(p1.z0pek());
				int num5 = z0xb(xTextTableRowElement, z0ZzZzrlh4);
				if (num5 > 0)
				{
					xTextTableRowElement.z0li();
				}
				num += num5;
				xTextElementList2.Add(xTextTableRowElement);
			}
		}
		if (flag)
		{
			p0.z0stk().Clear();
			bool flag3 = false;
			int num6 = -1;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableRowElement xTextTableRowElement4 = (XTextTableRowElement)z0bpk.Current;
					int num7 = xTextElementList2.IndexOf(xTextTableRowElement4);
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextTableRowElement4.z0rek().z0ltk();
					while (z0bpk2.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk2.Current;
						if (xTextTableCellElement.ValueExpression == null || xTextTableCellElement.ValueExpression.Length == 0)
						{
							continue;
						}
						if (!flag3)
						{
							num6 = num7;
							flag3 = true;
							break;
						}
						if (num6 != -1)
						{
							XTextTableRowElement obj = xTextElementList2[num6] as XTextTableRowElement;
							int index = xTextTableRowElement4.z0rek().IndexOf(xTextTableCellElement);
							if (obj.z0rek()[index] is XTextTableCellElement { ValueExpression: not null } xTextTableCellElement2 && xTextTableCellElement2.ValueExpression.Length > 0)
							{
								string text = (num6 + 1).ToString();
								string text2 = (num7 + 1).ToString();
								string valueExpression = xTextTableCellElement2.ValueExpression.Replace(text, text2);
								xTextTableCellElement.ValueExpression = valueExpression;
							}
						}
					}
				}
			}
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			int num8 = 1;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableRowElement xTextTableRowElement5 = (XTextTableRowElement)z0bpk.Current;
					int num9 = xTextElementList2.IndexOf(xTextTableRowElement5);
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextTableRowElement5.z0rek().z0ltk())
					{
						while (z0bpk2.MoveNext())
						{
							XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)z0bpk2.Current;
							using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk3 = xTextTableCellElement3.z0rek<XTextCheckBoxElementBase>().z0ltk())
							{
								while (z0bpk3.MoveNext())
								{
									XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)z0bpk3.Current;
									if (xTextCheckBoxElementBase.Name == null || xTextCheckBoxElementBase.Name.Length == 0)
									{
										continue;
									}
									int num10 = -1;
									if (dictionary.TryGetValue(xTextCheckBoxElementBase.Name, out num10))
									{
										if (num9 != num10)
										{
											xTextCheckBoxElementBase.Name += num9;
										}
									}
									else
									{
										dictionary.Add(xTextCheckBoxElementBase.Name, num9);
									}
								}
							}
							if (!p0.z0jr().z0vtk().BehaviorOptions.AutoFixElementIDWhenInsertElements)
							{
								continue;
							}
							p0.z0jr().z0vtk().BehaviorOptions.AutoFixElementIDWhenInsertElements = false;
							using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk3 = xTextTableCellElement3.z0rek<XTextInputFieldElement>().z0ltk())
							{
								while (z0bpk3.MoveNext())
								{
									z0ZzZzcoj.z0tek((XTextInputFieldElement)z0bpk3.Current, p0.z0jr(), num8);
								}
							}
							p0.z0jr().z0vtk().BehaviorOptions.AutoFixElementIDWhenInsertElements = true;
							if (z0ZzZzcoj.z0vek != null)
							{
								z0ZzZzcoj.z0vek.Clear();
								z0ZzZzcoj.z0vek = null;
							}
						}
					}
					num8++;
				}
			}
			((zzz.z0ZzZzkuk<XTextElement>)p0.z0stk()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2);
			p0.z0nek(p0: false);
			p0.z0qrk();
			if (!p1.z0eek())
			{
				p0.z0oe();
			}
			if (num > 0)
			{
				int num11 = ((XTextContainerElement)p0).z0qrk();
				p0.z0zek(num11 + 1);
			}
			p0.Modified = true;
		}
		else
		{
			z0rek(p0);
		}
		return num;
	}

	internal bool z0eek(XTextInputFieldElementBase p0, string p1, bool p2)
	{
		if (string.IsNullOrEmpty(p1))
		{
			return z0eek(p0, null, null, p2);
		}
		string p3 = p0.z0my(p1, p1: false);
		return z0eek(p0, p3, p1, p2);
	}

	public override int z0sv(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		return z0qv(p0, null);
	}

	public override DetectResultForValueBindingModifiedList z0dv(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		p0.z0nik();
		z0ZzZzrlh z0ZzZzrlh2 = new z0ZzZzrlh();
		z0ZzZzrlh2.z0rek(p0: true);
		z0ZzZzrlh2.z0eek(p0: true);
		p0.z0vek((object)null);
		z0xb(p0, z0ZzZzrlh2);
		if (z0ZzZzrlh2.z0oek() != null && z0ZzZzrlh2.z0oek().Count > 0)
		{
			return z0ZzZzrlh2.z0oek();
		}
		return null;
	}

	private int z0eek(XTextImageElement p0, z0ZzZzrlh p1)
	{
		p0.z0yek(p0: false);
		p0.z0eek((object)null);
		XTextDocument xTextDocument = p0.z0jr();
		if (p0.ValueBinding != null && p0.ValueBinding.z0eek() && !p0.ValueBinding.IsEmptyBinding)
		{
			if (p0.ValueBinding.ProcessState == DCProcessStates.Never)
			{
				return 0;
			}
			if (!z0eek(p1, p0.ValueBinding, xTextDocument))
			{
				return 0;
			}
			if (!xTextDocument.z0bu().EnableDataBinding)
			{
				return 0;
			}
			z0ZzZzvbj z0ZzZzvbj2 = z0eek(p0, p0.ValueBinding, p1);
			if (z0uek && (z0ZzZzvbj2 == null || z0ZzZzvbj2.z0bek()))
			{
				return 0;
			}
			p0.z0eek(z0ZzZzvbj2);
			object obj = null;
			if (z0ZzZzvbj2 != null && !z0ZzZzvbj2.z0eek())
			{
				obj = z0ZzZzvbj2.z0tek();
				p0.z0yek(p0: true);
			}
			if (p0.ValueBinding.ProcessState == DCProcessStates.Once)
			{
				p0.ValueBinding.ProcessState = DCProcessStates.Never;
			}
			if (obj == null || DBNull.Value.Equals(obj))
			{
				p0.z0rek((z0ZzZzpmk)null);
			}
			else if (obj is z0ZzZzedh)
			{
				p0.z0rek(new z0ZzZzpmk((z0ZzZzedh)obj));
			}
			else if (obj is byte[])
			{
				byte[] array = (byte[])obj;
				if (array == null || array.Length == 0)
				{
					p0.z0rek((z0ZzZzpmk)null);
				}
				else
				{
					p0.z0rek(new z0ZzZzpmk(array));
				}
			}
			else
			{
				string text = Convert.ToString(obj);
				if (text == null || text.Length == 0)
				{
					p0.z0rek((z0ZzZzpmk)null);
				}
				else if (z0ZzZzmuk.z0rek(text))
				{
					p0.z0rek(new z0ZzZzpmk(text));
				}
				else
				{
					byte[] array2 = z0ZzZzqik.z0uek(text);
					if (array2 == null || array2.Length == 0)
					{
						p0.z0rek((z0ZzZzpmk)null);
					}
					else
					{
						p0.z0rek(new z0ZzZzpmk(array2));
					}
				}
			}
			if (!p1.z0eek())
			{
				p0.z0jo();
			}
			return 1;
		}
		return 0;
	}

	private int z0eek(XTextTableRowElement p0, z0ZzZzrlh p1)
	{
		int num = 0;
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0be().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			int num2 = z0xb(current, p1);
			num += num2;
		}
		return num;
	}

	public z0ZzZzylh z0eek(XTextContainerElement p0)
	{
		DocumentOptions documentOptions = p0.z0jr().z0vu();
		z0ZzZzylh z0ZzZzylh2 = new z0ZzZzylh();
		List<string> list = new List<string>();
		string excludeKeywords = documentOptions.BehaviorOptions.ExcludeKeywords;
		if (excludeKeywords != null && excludeKeywords.Length > 0)
		{
			string[] array = excludeKeywords.Split(',', '|');
			foreach (string text in array)
			{
				if (text.Trim().Length > 0)
				{
					list.Add(text.Trim());
				}
			}
		}
		if (p0.z0jr().z0tuk() != null && p0.z0jr().z0tuk().Length > 0)
		{
			string[] array = p0.z0jr().z0tuk().Split(',');
			foreach (string text2 in array)
			{
				if (text2.Trim().Length > 0)
				{
					list.Add(text2.Trim());
				}
			}
		}
		if (list.Count > 0 && z0ZzZzxcj.z0eek(148))
		{
			z0ZzZzvpj z0ZzZzvpj2 = new z0ZzZzvpj(p0.z0jr());
			XTextElementList xTextElementList = p0.z0ee_jiejie20260327142557(p0: false).z0xyk().z0krk();
			z0ZzZzsmj z0ZzZzsmj2 = new z0ZzZzsmj();
			z0ZzZzsmj2.z0yek(p0: true);
			z0ZzZzsmj2.z0rek(p0: false);
			z0ZzZzsmj2.z0iek(p0: false);
			z0ZzZzsmj2.z0uek(p0: false);
			foreach (string item in list)
			{
				z0ZzZzsmj2.z0rek(item);
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextContentElement xTextContentElement = (XTextContentElement)z0bpk.Current;
					int p1 = 0;
					while (true)
					{
						p1 = z0ZzZzvpj2.z0eek(z0ZzZzsmj2, xTextContentElement.z0trk(), p2: false, p1);
						if (p1 < 0)
						{
							break;
						}
						z0ZzZztlh z0ZzZztlh2 = new z0ZzZztlh();
						z0ZzZztlh2.z0eek(xTextContentElement.z0trk()[p1]);
						z0ZzZztlh2.z0eek(ValueValidateResultTypes.ExcludeKeyword);
						z0ZzZztlh2.z0eek(item);
						z0ZzZztlh2.z0eek(ValueValidateLevel.Error);
						z0ZzZztlh2.z0tek(string.Format(z0ZzZziok.z0dtk(), item));
						z0ZzZzylh2.Add(z0ZzZztlh2);
						p1 += item.Length;
					}
				}
			}
		}
		XTextElementList xTextElementList2 = p0.z0rek<XTextCheckBoxElementBase>();
		if (xTextElementList2 != null && xTextElementList2.Count > 0)
		{
			List<string> list2 = new List<string>();
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)z0bpk.Current;
				if (!xTextCheckBoxElementBase.z0drk() || string.IsNullOrEmpty(xTextCheckBoxElementBase.Name) || list2.Contains(xTextCheckBoxElementBase.Name) || !xTextCheckBoxElementBase.Visible)
				{
					continue;
				}
				list2.Add(xTextCheckBoxElementBase.Name);
				XTextElementList xTextElementList3 = xTextCheckBoxElementBase.z0eek();
				bool flag = false;
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextElementList3.z0ltk())
				{
					while (z0bpk2.MoveNext())
					{
						if (((XTextCheckBoxElementBase)z0bpk2.Current).Checked)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					z0ZzZztlh z0ZzZztlh3 = new z0ZzZztlh();
					z0ZzZztlh3.z0eek(xTextCheckBoxElementBase);
					z0ZzZztlh3.z0eek(ValueValidateLevel.Error);
					z0ZzZztlh3.z0tek(string.Format(z0ZzZziok.z0lrk(), xTextCheckBoxElementBase.Name));
					z0ZzZztlh3.z0eek(ValueValidateResultTypes.ValueValidate);
					z0ZzZzylh2.Add(z0ZzZztlh3);
				}
			}
		}
		XTextElementList xTextElementList4 = p0.z0rek<XTextContainerElement>();
		if (xTextElementList4.Count > 0)
		{
			foreach (XTextContainerElement item2 in xTextElementList4.z0xrk())
			{
				if (!item2.EnableValueValidate)
				{
					continue;
				}
				XTextElement xTextElement = item2;
				bool flag2 = false;
				while (xTextElement != null && !(xTextElement is XTextDocumentContentElement))
				{
					if (xTextElement.z0aek().z0jyk >= 0)
					{
						flag2 = true;
						break;
					}
					if (!xTextElement.Visible)
					{
						flag2 = true;
						break;
					}
					xTextElement = xTextElement.z0ji();
				}
				if (!flag2)
				{
					z0ZzZztlh z0ZzZztlh4 = z0gv(item2, p1: false);
					if (z0ZzZztlh4 != null)
					{
						z0ZzZzylh2.Add(z0ZzZztlh4);
					}
				}
			}
		}
		if (p0 is XTextInputFieldElement)
		{
			if (p0.EnableValueValidate)
			{
				XTextElement xTextElement2 = p0;
				bool flag3 = false;
				while (xTextElement2 != null && !(xTextElement2 is XTextDocumentContentElement))
				{
					if (xTextElement2.z0aek().z0jyk >= 0)
					{
						flag3 = true;
						break;
					}
					if (!xTextElement2.Visible)
					{
						flag3 = true;
						break;
					}
					xTextElement2 = xTextElement2.z0ji();
				}
				if (!flag3)
				{
					z0ZzZztlh z0ZzZztlh5 = z0gv(p0, p1: false);
					if (z0ZzZztlh5 != null)
					{
						z0ZzZzylh2.Add(z0ZzZztlh5);
					}
				}
			}
		}
		if (z0ZzZzylh2.Count > 1)
		{
			z0ZzZzylh2.z0eek();
		}
		return z0ZzZzylh2;
	}

	public override string z0fv(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		DetectResultForValueBindingModifiedList detectResultForValueBindingModifiedList = z0dv(p0);
		if (detectResultForValueBindingModifiedList == null || detectResultForValueBindingModifiedList.Count == 0)
		{
			return null;
		}
		return detectResultForValueBindingModifiedList.ToString();
	}

	private bool z0eek(XTextTableElement p0, string p1, bool p2)
	{
		return false;
	}

	public override z0ZzZztlh z0gv(XTextContainerElement p0, bool p1)
	{
		if (p0 == null)
		{
			return null;
		}
		XTextDocument xTextDocument = p0.z0jr();
		if (xTextDocument == null)
		{
			return null;
		}
		DocumentOptions documentOptions = xTextDocument.z0vu();
		if (documentOptions.EditOptions.ValueValidateMode == DocumentValueValidateMode.None)
		{
			return null;
		}
		if (!p0.EnableValueValidate)
		{
			return null;
		}
		bool flag = p0.z0frk() != null;
		if (documentOptions.BehaviorOptions.EnableElementEvents)
		{
			ElementValidatingEventArgs e = new ElementValidatingEventArgs(p0);
			e.ResultState = ElementValidatingState.Pass;
			xTextDocument.z0bek(e);
			if (e.Handled)
			{
				switch (e.ResultState)
				{
				case ElementValidatingState.Success:
					p0.z0cek((z0ZzZztlh)null);
					if (!e.Cancel)
					{
						p0.z0erk();
					}
					return null;
				case ElementValidatingState.Pass:
					if (!e.Cancel)
					{
						p0.z0erk();
					}
					break;
				case ElementValidatingState.Fail:
				{
					z0ZzZztlh z0ZzZztlh2 = new z0ZzZztlh();
					z0ZzZztlh2.z0eek(p0);
					z0ZzZztlh2.z0eek(ValueValidateResultTypes.ValueValidate);
					z0ZzZztlh2.z0eek(e.ResultLevel);
					z0ZzZztlh2.z0tek(e.Message);
					p0.z0cek(z0ZzZztlh2);
					if (!e.Cancel)
					{
						p0.z0erk();
					}
					p0.z0ri();
					return p0.z0frk();
				}
				}
			}
		}
		ValueValidateStyle valueValidateStyle = p0.z0br();
		if (valueValidateStyle != null && !valueValidateStyle.IsEmpty)
		{
			valueValidateStyle.ContentVersion = p0.z0kek();
			string p2 = "";
			string text = p0.Text;
			if (p0 is XTextInputFieldElement && valueValidateStyle.Required && p0.z0uek<XTextInputFieldElement>() != null)
			{
				z0ZzZzdxj z0ZzZzdxj2 = new z0ZzZzdxj();
				z0ZzZzdxj2.z0tek(p0: false);
				z0ZzZzdxj2.z0eek(p0: false);
				z0ZzZzdxj2.z0yek(p0: false);
				z0ZzZzdxj2.z0rek(p0: false);
				z0ZzZzdxj2.z0uek(p0: false);
				text = p0.z0yek(z0ZzZzdxj2);
			}
			if (p0 is XTextInputFieldElement)
			{
				XTextInputFieldElement xTextInputFieldElement = p0 as XTextInputFieldElement;
				if (xTextInputFieldElement.DisplayFormat != null && xTextInputFieldElement.FieldSettings != null && xTextInputFieldElement.FieldSettings.z0nek() != InputFieldEditStyle.Text && xTextInputFieldElement.FieldSettings.z0nek() != InputFieldEditStyle.DropdownList)
				{
					text = xTextInputFieldElement.InnerValue;
					if (text == null)
					{
						text = string.Empty;
					}
				}
			}
			if (z0eek(valueValidateStyle, p0.z0be(), text, ref p2))
			{
				p0.z0cek((z0ZzZztlh)null);
			}
			else
			{
				z0ZzZztlh z0ZzZztlh3 = new z0ZzZztlh();
				z0ZzZztlh3.z0eek(p0);
				z0ZzZztlh3.z0eek(valueValidateStyle.Level);
				z0ZzZztlh3.z0eek(valueValidateStyle.ExcludeKeywords);
				string text2 = z0eek((XTextElement)p0);
				if (string.IsNullOrEmpty(text2))
				{
					text2 = p0.ID;
				}
				if (valueValidateStyle != null && !string.IsNullOrEmpty(valueValidateStyle.CustomMessage))
				{
					z0ZzZztlh3.z0tek(valueValidateStyle.CustomMessage);
				}
				else if (string.IsNullOrEmpty(text2))
				{
					z0ZzZztlh3.z0tek(valueValidateStyle.Message);
				}
				else
				{
					z0ZzZztlh3.z0tek(text2 + ":" + valueValidateStyle.Message);
				}
				z0ZzZztlh3.z0eek(ValueValidateResultTypes.ValueValidate);
				p0.z0cek(z0ZzZztlh3);
			}
			if (!p1)
			{
				p0.z0jo();
			}
		}
		else
		{
			p0.z0cek((z0ZzZztlh)null);
		}
		if (p0.z0frk() == null)
		{
			string text3 = xTextDocument.z0ark(p0);
			if (!string.IsNullOrEmpty(text3))
			{
				z0ZzZztlh z0ZzZztlh4 = new z0ZzZztlh();
				z0ZzZztlh4.z0tek(text3);
				z0ZzZztlh4.z0eek(ValueValidateLevel.Warring);
				z0ZzZztlh4.z0eek(ValueValidateResultTypes.ValueValidate);
				z0ZzZztlh4.z0eek(valueValidateStyle?.ExcludeKeywords);
				z0ZzZztlh4.z0eek(p0);
				p0.z0cek(z0ZzZztlh4);
				if (!p1)
				{
					p0.z0jo();
				}
			}
		}
		if (xTextDocument.z0bu().DebugMode && p0.z0frk() != null && !string.IsNullOrEmpty(p0.z0frk().z0uek()))
		{
			string p3 = string.Format(z0ZzZziok.z0rek(), p0.z0xr(), p0.Text, p0.z0frk().z0uek());
			z0ZzZzqok.z0rek.z0sh(p3);
		}
		p0.z0erk();
		if (flag != (p0.z0frk() != null))
		{
			p0.z0ri();
		}
		return p0.z0frk();
	}

	private z0ZzZzvbj z0eek(XTextElement p0, string p1, string p2, z0ZzZzrlh p3)
	{
		XTextDocument xTextDocument = p0.z0jr();
		if (xTextDocument == null || !xTextDocument.z0bu().EnableDataBinding)
		{
			return null;
		}
		if (p3 != null && !z0eek(p3, p1))
		{
			return null;
		}
		z0ZzZzvbj z0ZzZzvbj2 = z0eek(p0, p1);
		if (z0ZzZzvbj2 != null && !z0ZzZzvbj2.z0eek())
		{
			string p4 = z0ZzZzvbj2.z0ov().z0eek(p2);
			z0ZzZzvbj z0ZzZzvbj3 = z0ZzZzvbj2.z0rek(p4, p1: true);
			if (z0ZzZzvbj3 == null)
			{
				z0ZzZzvbj3 = z0ZzZzvbj.z0qrk;
			}
			return z0ZzZzvbj3;
		}
		return z0ZzZzvbj.z0qrk;
	}

	public override int z0hv(XTextDocument p0)
	{
		int num = 0;
		DataSourceBindingDescriptionList dataSourceBindingDescriptionList = p0.z0ctk();
		if (dataSourceBindingDescriptionList == null || dataSourceBindingDescriptionList.Count == 0)
		{
			return num;
		}
		XTextElementList xTextElementList = new XTextElementList();
		Dictionary<string, XAttributeList> dictionary = new Dictionary<string, XAttributeList>();
		foreach (DataSourceBindingDescription item3 in dataSourceBindingDescriptionList)
		{
			if (xTextElementList.Contains(item3.Element))
			{
				continue;
			}
			if (item3.Element is XTextTableElement && !xTextElementList.Contains(item3.Element))
			{
				string p1 = null;
				JsonNode jsonNode = z0ZzZzboj.z0tek((XTextTableElement)item3.Element, out p1);
				if (jsonNode == null || p1 == null)
				{
					continue;
				}
				p0.z0bek(item3.DataSource, jsonNode);
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0rek<XTextTableElement>().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextTableElement xTextTableElement = (XTextTableElement)z0bpk.Current;
						if (xTextTableElement.ValueBinding != null && xTextTableElement.ValueBinding.DataSource == item3.DataSource)
						{
							xTextElementList.Add(xTextTableElement);
						}
					}
				}
				num++;
			}
			else if (item3.Element is XTextTableRowElement)
			{
				XTextTableElement xTextTableElement2 = ((XTextTableRowElement)item3.Element).z0gr();
				if (xTextTableElement2 == null || !xTextElementList.Contains(xTextTableElement2))
				{
					string p2 = null;
					JsonNode jsonNode2 = z0ZzZzboj.z0tek(xTextTableElement2, out p2);
					if (jsonNode2 != null && p2 != null)
					{
						p0.z0bek(p2, jsonNode2);
						xTextElementList.Add(xTextTableElement2);
					}
				}
			}
			else if (item3.Element is XTextTableColumnElement)
			{
				XTextTableElement xTextTableElement3 = ((XTextTableColumnElement)item3.Element).z0gr();
				if (xTextTableElement3 == null || !xTextElementList.Contains(xTextTableElement3))
				{
					string p3 = null;
					JsonNode jsonNode3 = z0ZzZzboj.z0tek(xTextTableElement3, out p3);
					if (jsonNode3 != null && p3 != null)
					{
						p0.z0bek(p3, jsonNode3);
						xTextElementList.Add(xTextTableElement3);
					}
				}
			}
			else if (item3.Element is XTextTableCellElement)
			{
				XTextTableElement xTextTableElement4 = ((XTextTableCellElement)item3.Element).z0gr();
				if (xTextTableElement4 == null || !xTextElementList.Contains(xTextTableElement4))
				{
					string p4 = null;
					JsonNode jsonNode4 = z0ZzZzboj.z0tek(xTextTableElement4, out p4);
					if (jsonNode4 != null && p4 != null)
					{
						p0.z0bek(p4, jsonNode4);
						xTextElementList.Add(xTextTableElement4);
					}
				}
			}
			else
			{
				if (item3.Element.z0brk() != null && ((XTextContainerElement)item3.Element.z0brk()).z0hrk())
				{
					continue;
				}
				if (item3.DataSource != null && item3.DataSource.Length > 0 && (item3.BindingPath == null || item3.BindingPath.Length == 0))
				{
					if (item3.Element is XTextImageElement)
					{
						XTextImageElement xTextImageElement = item3.Element as XTextImageElement;
						string empty = string.Empty;
						p0.z0bek(p1: (object)(((xTextImageElement.z0frk() != null && xTextImageElement.z0frk().HasContent) || xTextImageElement.SaveContentInFile) ? ("data:image/png;base64," + xTextImageElement.z0frk().ImageDataBase64String) : xTextImageElement.z0mek()), p0: item3.DataSource);
						xTextElementList.Add(item3.Element);
						num++;
					}
					else if (item3.Element is XTextCheckBoxElementBase)
					{
						XTextElementList xTextElementList2 = ((XTextCheckBoxElementBase)item3.Element).z0eek();
						string text = "";
						using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
						{
							while (z0bpk.MoveNext())
							{
								XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)z0bpk.Current;
								if (xTextCheckBoxElementBase.Checked)
								{
									text = ((text.Length != 0) ? (text + "," + xTextCheckBoxElementBase.CheckedValue) : (text + xTextCheckBoxElementBase.CheckedValue));
									num++;
								}
								xTextElementList.Add(xTextCheckBoxElementBase);
							}
						}
						p0.z0bek(item3.DataSource, (object)text);
					}
					else if (item3.Element is XTextContainerElement && (item3.Element.Text == null || item3.Element.Text.Length == 0))
					{
						XTextContainerElement xTextContainerElement = item3.Element as XTextContainerElement;
						if (xTextContainerElement.z0be().Count <= 2 && xTextContainerElement.z0be().Count > 0 && xTextContainerElement.z0be()[0] is XTextImageElement)
						{
							XTextImageElement xTextImageElement2 = xTextContainerElement.z0be()[0] as XTextImageElement;
							string empty2 = string.Empty;
							p0.z0bek(p1: (object)(((xTextImageElement2.z0frk() != null && xTextImageElement2.z0frk().HasContent) || xTextImageElement2.SaveContentInFile) ? ("data:image/png;base64," + xTextImageElement2.z0frk().ImageDataBase64String) : xTextImageElement2.z0mek()), p0: item3.DataSource);
							xTextElementList.Add(item3.Element);
							num++;
						}
					}
					else
					{
						p0.z0bek(item3.DataSource, (object)item3.Element.Text);
						xTextElementList.Add(item3.Element);
						num++;
					}
				}
				else
				{
					if (item3.DataSource == null || item3.DataSource.Length <= 0 || item3.BindingPath == null || item3.BindingPath.Length <= 0)
					{
						continue;
					}
					string text2 = "";
					if (item3.Element is XTextImageElement)
					{
						XTextImageElement xTextImageElement3 = item3.Element as XTextImageElement;
						text2 = (((xTextImageElement3.z0frk() != null && xTextImageElement3.z0frk().HasContent) || xTextImageElement3.SaveContentInFile) ? ("data:image/png;base64," + xTextImageElement3.z0frk().ImageDataBase64String) : xTextImageElement3.z0mek());
						xTextElementList.Add(item3.Element);
						num++;
					}
					else if (item3.Element is XTextCheckBoxElementBase)
					{
						XTextElementList xTextElementList3 = ((XTextCheckBoxElementBase)item3.Element).z0eek();
						text2 = "";
						using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList3.z0ltk();
						while (z0bpk.MoveNext())
						{
							XTextCheckBoxElementBase xTextCheckBoxElementBase2 = (XTextCheckBoxElementBase)z0bpk.Current;
							if (xTextCheckBoxElementBase2.Checked)
							{
								text2 = ((text2.Length != 0) ? (text2 + "," + xTextCheckBoxElementBase2.CheckedValue) : (text2 + xTextCheckBoxElementBase2.CheckedValue));
								num++;
							}
							xTextElementList.Add(xTextCheckBoxElementBase2);
						}
					}
					else if (item3.Element is XTextContainerElement && (item3.Element.Text == null || item3.Element.Text.Length == 0))
					{
						XTextContainerElement xTextContainerElement2 = item3.Element as XTextContainerElement;
						if (xTextContainerElement2.z0be().Count <= 2 && xTextContainerElement2.z0be().Count > 0 && xTextContainerElement2.z0be()[0] is XTextImageElement)
						{
							XTextImageElement xTextImageElement4 = xTextContainerElement2.z0be()[0] as XTextImageElement;
							text2 = (((xTextImageElement4.z0frk() != null && xTextImageElement4.z0frk().HasContent) || xTextImageElement4.SaveContentInFile) ? ("data:image/png;base64," + xTextImageElement4.z0frk().ImageDataBase64String) : xTextImageElement4.z0mek());
							xTextElementList.Add(item3.Element);
							num++;
						}
						else
						{
							text2 = item3.Element.Text;
							xTextElementList.Add(item3.Element);
							num++;
						}
					}
					else if (item3.Element is XTextInputFieldElement && ((XTextInputFieldElement)item3.Element).z0oek() == InputFieldEditStyle.DropdownList && string.IsNullOrEmpty(((XTextInputFieldElement)item3.Element).ValueBinding.BindingPathForText))
					{
						text2 = ((XTextInputFieldElement)item3.Element).InnerValue;
						xTextElementList.Add(item3.Element);
						num++;
					}
					else
					{
						text2 = item3.Element.Text;
						xTextElementList.Add(item3.Element);
						num++;
					}
					if (dictionary.ContainsKey(item3.DataSource))
					{
						XAttributeList xAttributeList = dictionary[item3.DataSource];
						if (item3.Element is XTextInputFieldElement)
						{
							XTextInputFieldElement xTextInputFieldElement = item3.Element as XTextInputFieldElement;
							if (!string.IsNullOrEmpty(xTextInputFieldElement.ValueBinding.BindingPathForText))
							{
								text2 = xTextInputFieldElement.InnerValue;
								if (xAttributeList.z0yek(xTextInputFieldElement.ValueBinding.BindingPathForText) == null)
								{
									XAttribute item = new XAttribute(xTextInputFieldElement.ValueBinding.BindingPathForText, xTextInputFieldElement.Text);
									xAttributeList.Add(item);
								}
								else
								{
									string p5 = xTextInputFieldElement.Text;
									if (xTextInputFieldElement.z0be().Count <= 2 && xTextInputFieldElement.z0be().Count > 0 && xTextInputFieldElement.z0be()[0] is XTextImageElement)
									{
										XTextImageElement xTextImageElement5 = xTextInputFieldElement.z0be()[0] as XTextImageElement;
										p5 = (((xTextImageElement5.z0frk() != null && xTextImageElement5.z0frk().HasContent) || xTextImageElement5.SaveContentInFile) ? ("data:image/png;base64," + xTextImageElement5.z0frk().ImageDataBase64String) : xTextImageElement5.z0mek());
									}
									z0ZzZzcoj.z0tek(xAttributeList, xTextInputFieldElement.ValueBinding.BindingPathForText, p5);
								}
							}
						}
						if (xAttributeList.z0yek(item3.BindingPath) == null)
						{
							XAttribute item2 = new XAttribute(item3.BindingPath, text2);
							xAttributeList.Add(item2);
						}
						else
						{
							z0ZzZzcoj.z0tek(xAttributeList, item3.BindingPath, text2);
						}
						continue;
					}
					XAttributeList xAttributeList2 = new XAttributeList();
					if (item3.Element is XTextInputFieldElement)
					{
						XTextInputFieldElement xTextInputFieldElement2 = item3.Element as XTextInputFieldElement;
						if (!string.IsNullOrEmpty(xTextInputFieldElement2.ValueBinding.BindingPathForText))
						{
							text2 = xTextInputFieldElement2.InnerValue;
							z0ZzZzcoj.z0tek(xAttributeList2, xTextInputFieldElement2.ValueBinding.BindingPathForText, xTextInputFieldElement2.Text);
						}
					}
					xAttributeList2.z0eek(item3.BindingPath);
					z0ZzZzcoj.z0tek(xAttributeList2, item3.BindingPath, text2);
					dictionary.Add(item3.DataSource, xAttributeList2);
				}
			}
		}
		if (dictionary.Count > 0)
		{
			foreach (KeyValuePair<string, XAttributeList> item4 in dictionary)
			{
				XAttributeList value = item4.Value;
				JsonObject jsonObject = new JsonObject();
				List<string> list = new List<string>();
				using (zzz.z0ZzZzkuk<XAttribute>.z0bpk z0bpk2 = value.z0ltk())
				{
					while (z0bpk2.MoveNext())
					{
						XAttribute current3 = z0bpk2.Current;
						if (!list.Contains(current3.Name))
						{
							jsonObject.Add(current3.Name, current3.Value);
							list.Add(current3.Name);
						}
					}
				}
				p0.z0bek(item4.Key, jsonObject);
			}
		}
		return num;
	}

	public override string z0jv(XTextDocument p0, string p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("name");
		}
		p1 = p1.Trim();
		if (p1.Length == 0)
		{
			throw new ArgumentNullException("name");
		}
		string result = null;
		foreach (XTextElement item in new z0ZzZzkxj(p0))
		{
			if (item is XTextInputFieldElementBase)
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)item;
				if (xTextInputFieldElementBase.ID == p1 || xTextInputFieldElementBase.Name == p1)
				{
					result = xTextInputFieldElementBase.Text;
					break;
				}
			}
			else
			{
				if (item is XTextCheckBoxElement)
				{
					XTextCheckBoxElement xTextCheckBoxElement = (XTextCheckBoxElement)item;
					if (!(xTextCheckBoxElement.Name == p1))
					{
						continue;
					}
					XTextElementList xTextElementList = xTextCheckBoxElement.z0eek();
					StringBuilder stringBuilder = new StringBuilder();
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							XTextCheckBoxElement xTextCheckBoxElement2 = (XTextCheckBoxElement)z0bpk.Current;
							if (xTextCheckBoxElement2.Checked)
							{
								if (stringBuilder.Length > 0)
								{
									stringBuilder.Append(',');
								}
								stringBuilder.Append(xTextCheckBoxElement2.CheckedValue);
								if (xTextCheckBoxElement.z0oi() == CheckBoxControlStyle.RadioBox)
								{
									break;
								}
							}
						}
					}
					result = stringBuilder.ToString();
					break;
				}
				if (!(item is XTextRadioBoxElement))
				{
					continue;
				}
				XTextRadioBoxElement xTextRadioBoxElement = item as XTextRadioBoxElement;
				if (!(xTextRadioBoxElement.Name == p1))
				{
					continue;
				}
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextRadioBoxElement.z0eek().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextRadioBoxElement xTextRadioBoxElement2 = (XTextRadioBoxElement)z0bpk.Current;
					if (xTextRadioBoxElement2.Checked)
					{
						result = xTextRadioBoxElement2.CheckedValue;
						break;
					}
				}
			}
		}
		return result;
	}

	internal bool z0eek(XTextInputFieldElementBase p0, string p1, string p2, bool p3)
	{
		XTextInputFieldElement xTextInputFieldElement = p0 as XTextInputFieldElement;
		if (xTextInputFieldElement != null && xTextInputFieldElement.FieldSettings != null && xTextInputFieldElement.FieldSettings.z0nek() == InputFieldEditStyle.Date && p2 != null && p2.IndexOf(' ') > 0)
		{
			if (p1 == p2)
			{
				p1 = p1.Substring(0, p1.IndexOf(' '));
			}
			p2 = p2.Substring(0, p2.IndexOf(' '));
		}
		if (xTextInputFieldElement != null && xTextInputFieldElement.z0oek() == InputFieldEditStyle.DropdownList && p1 == null && p2 != null)
		{
			z0ZzZzdvj z0ZzZzdvj2 = xTextInputFieldElement.z0eek(null, p1: false, p2);
			if (z0ZzZzdvj2 != null)
			{
				if (!xTextInputFieldElement.FieldSettings.z0yek())
				{
					p1 = z0ZzZzdvj2.z0rek(p2);
				}
				else
				{
					string[] array = p2.Split(xTextInputFieldElement.FieldSettings.z0oek());
					foreach (string p4 in array)
					{
						string text = z0ZzZzdvj2.z0rek(p4);
						if (text != null && text.Length > 0)
						{
							p1 = p1 + text + xTextInputFieldElement.FieldSettings.z0oek();
						}
					}
					if (p1 != null && p1.Length > 0)
					{
						p1 = p1.Substring(0, p1.Length - 1);
					}
				}
			}
		}
		int num = -1;
		XTextElementList xTextElementList = p0.z0rek<XTextParagraphFlagElement>();
		XTextParagraphFlagElement xTextParagraphFlagElement = null;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextParagraphFlagElement xTextParagraphFlagElement2 = (XTextParagraphFlagElement)z0bpk.Current;
				if (!xTextParagraphFlagElement2.z0wtk())
				{
					xTextParagraphFlagElement = xTextParagraphFlagElement2;
					break;
				}
			}
		}
		XTextParagraphFlagElement xTextParagraphFlagElement3 = ((p0.z0be().Count > 0) ? p0.z0be()[0].z0dy() : null);
		num = ((p0.z0be().Count == 0) ? ((XTextElement)p0.z0dy()).z0pek() : (((XTextElement)xTextParagraphFlagElement)?.z0pek() ?? ((xTextParagraphFlagElement3 == null || xTextParagraphFlagElement3.z0wtk()) ? ((XTextElement)p0.z0dy()).z0pek() : ((XTextElement)xTextParagraphFlagElement3).z0pek())));
		bool flag = p0.Text != p1 || p0.InnerValue != p2;
		XTextDocument xTextDocument = p0.z0jr();
		if (string.IsNullOrEmpty(p2))
		{
			p0.InnerValue = string.Empty;
			string text2 = null;
			if (!xTextDocument.z0vtk().SecurityOptions.EnablePermission || xTextDocument.z0muk() == null)
			{
				XTextElementList xTextElementList2 = p0.z0yy(text2, null, p2: false);
				if (xTextElementList2 != null && xTextElementList2.Count > 0)
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextElement current = z0bpk.Current;
						DocumentContentStyle documentContentStyle = current.z0aek().z0yek();
						documentContentStyle.CreatorIndex = -1;
						documentContentStyle.DeleterIndex = -1;
						current.z0oek(xTextDocument.z0gnk().GetStyleIndex(documentContentStyle));
					}
				}
			}
			else
			{
				z0ZzZzcoj.z0tek(xTextDocument, p0, text2);
			}
		}
		else
		{
			int num2 = ((p1 != null && p1.Length > 0) ? p1.IndexOf(',') : (-1));
			if (p1 != null && p1.StartsWith("data:image/") && num2 > 0)
			{
				try
				{
					bool flag2 = false;
					float num3 = 0f;
					float num4 = 0f;
					if (p1.Contains("$imagewidthheight$"))
					{
						string[] array2 = p1.Split("$imagewidthheight$");
						if (array2.Length == 2)
						{
							p1 = array2[0];
							string[] array3 = array2[1].Split('h');
							string text3 = array3[1];
							if (float.TryParse(array3[0].Split('w')[1], out num3) && float.TryParse(text3, out num4) && num3 > 0f && num4 > 0f)
							{
								flag2 = true;
							}
						}
					}
					string p5 = p1.Substring(num2 + 1);
					XTextImageElement xTextImageElement = new XTextImageElement();
					xTextImageElement.z0rek(p5, !flag2);
					if (flag2)
					{
						xTextImageElement.Width = num3;
						xTextImageElement.Height = num4;
						xTextImageElement.KeepWidthHeightRate = false;
					}
					if (xTextImageElement.z0frk().HasContent && !flag2)
					{
						if (p0 is XTextTableCellElement && xTextImageElement.Width > ((XTextElement)p0).z0ork())
						{
							float num5 = xTextImageElement.Width / xTextImageElement.Height;
							xTextImageElement.Width = ((XTextElement)p0).z0ork();
							xTextImageElement.Height = xTextImageElement.Width / num5;
						}
						else if (p0 is XTextInputFieldElement)
						{
							float num6 = ((XTextElement)p0.z0ji()).z0ork();
							if ((p0.z0jy() is XTextDocumentBodyElement || p0.z0jy() is XTextSubDocumentElement) && p0.z0jr() != null && p0.z0jr().PageSettings != null)
							{
								num6 = p0.z0jr().PageSettings.z0prk();
							}
							if (xTextImageElement.Width > num6)
							{
								float num7 = xTextImageElement.Width / xTextImageElement.Height;
								xTextImageElement.Width = num6;
								xTextImageElement.Height = xTextImageElement.Width / num7;
							}
						}
					}
					p0.z0be().Clear();
					p0.z0be().Add(xTextImageElement);
				}
				catch
				{
				}
			}
			else if (!xTextDocument.z0vtk().SecurityOptions.EnablePermission || xTextDocument.z0muk() == null)
			{
				XTextElementList xTextElementList3 = p0.z0zek(p1);
				if (xTextElementList3 != null && xTextElementList3.Count > 0)
				{
					DocumentContentStyle documentContentStyle2 = xTextElementList3[0].z0aek().z0yek();
					documentContentStyle2.CreatorIndex = -1;
					documentContentStyle2.DeleterIndex = -1;
					int styleIndex = xTextDocument.z0gnk().GetStyleIndex(documentContentStyle2);
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList3.z0ltk();
					while (z0bpk.MoveNext())
					{
						z0bpk.Current.z0oek(styleIndex);
					}
				}
			}
			else
			{
				z0ZzZzcoj.z0tek(xTextDocument, p0, p1);
			}
			p0.InnerValue = p2;
		}
		p0.z0eo(p0: true);
		p0.z0zek(p0.z0kek());
		if (xTextDocument != null && !xTextDocument.z0snk() && xTextDocument.z0apk() != null)
		{
			xTextDocument.z0apk().z0vv(p0);
		}
		if (flag)
		{
			p0.InnerValue = p2;
			p0.Modified = true;
		}
		XTextElementList xTextElementList4 = p0.z0nek<XTextParagraphFlagElement>();
		int num8 = -1;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList4.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextParagraphFlagElement xTextParagraphFlagElement4 = (XTextParagraphFlagElement)z0bpk.Current;
				if (xTextParagraphFlagElement4.z0xrk().DeleterIndex == -1)
				{
					if (xTextParagraphFlagElement4.z0xrk().CreatorIndex == -1)
					{
						xTextParagraphFlagElement4.z0oek(num);
					}
					else if (num8 == -1)
					{
						DocumentContentStyle documentContentStyle3 = xTextDocument.z0gnk().GetStyle(num).Clone() as DocumentContentStyle;
						documentContentStyle3.CreatorIndex = xTextParagraphFlagElement4.z0xrk().CreatorIndex;
						xTextDocument.z0gnk().Styles.Add(documentContentStyle3);
						xTextParagraphFlagElement4.z0oek(xTextDocument.z0gnk().Styles.Count - 1);
						num8 = ((XTextElement)xTextParagraphFlagElement4).z0pek();
					}
					else
					{
						xTextParagraphFlagElement4.z0oek(num8);
					}
				}
			}
		}
		return true;
	}

	public static z0ZzZzbbj z0eek(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		if (p0.z0lrk() is z0ZzZzbbj)
		{
			return (z0ZzZzbbj)p0.z0lrk();
		}
		z0ZzZzbbj z0ZzZzbbj2 = p0.z0utk() as z0ZzZzbbj;
		if (z0ZzZzbbj2 == null)
		{
			z0ZzZzbbj2 = new z0ZzZzbbj();
			if (p0.z0gpk() != null)
			{
				foreach (DocumentParameter item in p0.z0gpk())
				{
					z0ZzZzbbj2.z0eek(item.z0eek(), item.z0bek());
				}
			}
			if (p0.z0hmk() != null)
			{
				foreach (DocumentParameter item2 in p0.z0hmk())
				{
					z0ZzZzbbj2.z0eek(item2.z0eek(), item2.z0bek());
				}
			}
			p0.z0vek(z0ZzZzbbj2);
		}
		return z0ZzZzbbj2;
	}

	private int z0eek(XTextInputFieldElementBase p0, z0ZzZzrlh p1)
	{
		if (!p1.z0tek_jiejie20260327142557())
		{
			p0.z0eek((object)null);
			p0.z0hrk(p0: false);
		}
		XTextDocument xTextDocument = p0.z0jr();
		z0ZzZzevj z0ZzZzevj2 = (p0.z0pr() ? p0.ValueBinding : null);
		if (xTextDocument.z0bek(z0ZzZzevj2) && p0.z0pr())
		{
			if (!z0eek(p1, z0ZzZzevj2, xTextDocument))
			{
				return 0;
			}
			if (!p1.z0tek_jiejie20260327142557())
			{
				z0ZzZzevj2.z0rek(p0: true);
				p0.z0rek(null);
			}
			z0ZzZzvbj z0ZzZzvbj2 = z0eek(p0, z0ZzZzevj2, p1);
			if (!p1.z0tek_jiejie20260327142557())
			{
				p0.z0cek(z0ZzZzvbj2);
			}
			if (!string.IsNullOrEmpty(z0ZzZzevj2.BindingPathForText))
			{
				p0.z0rek(z0eek(p0, z0ZzZzevj2.DataSource, z0ZzZzevj2.BindingPathForText, p1));
			}
			if (!xTextDocument.z0bu().EnableDataBinding)
			{
				return 0;
			}
			int result = 0;
			object obj = null;
			object obj2 = null;
			if (z0ZzZzvbj2 != null && !z0ZzZzvbj2.z0eek())
			{
				obj = z0ZzZzvbj2.z0tek();
			}
			else if (z0ZzZzevj2.DataSource != null)
			{
				_ = z0ZzZzevj2.DataSource.Length;
				_ = 0;
			}
			if (z0uek)
			{
				z0ZzZzvbj z0ZzZzvbj3 = p0.z0lrk() as z0ZzZzvbj;
				if ((z0ZzZzvbj2 == null || z0ZzZzvbj2.z0bek()) && (z0ZzZzvbj3 == null || z0ZzZzvbj3.z0bek()))
				{
					return result;
				}
			}
			bool flag = false;
			if (!flag)
			{
				if (obj == null || DBNull.Value.Equals(obj))
				{
					flag = true;
				}
				else if (obj is float)
				{
					if (float.IsNaN((float)obj))
					{
						flag = true;
					}
				}
				else if (obj is double && z0ZzZzbok.z0eek((double)obj))
				{
					flag = true;
				}
			}
			if (p1.z0tek_jiejie20260327142557())
			{
				string text = (flag ? null : Convert.ToString(obj));
				if (string.IsNullOrEmpty(text))
				{
					text = null;
				}
				string text2 = p0.InnerValue;
				if (string.IsNullOrEmpty(text2))
				{
					text2 = null;
				}
				if (!string.Equals(text, text2))
				{
					DetectResultForValueBindingModified p2 = new DetectResultForValueBindingModified(p0.ValueBinding, p0, text2, text);
					p1.z0eek(p2);
				}
				return 0;
			}
			if (!flag)
			{
				if (!string.IsNullOrEmpty(z0ZzZzevj2.BindingPathForText))
				{
					p0.z0rek(z0eek(p0, z0ZzZzevj2.DataSource, z0ZzZzevj2.BindingPathForText, p1));
					obj2 = ((p0.z0lrk() == null) ? p0.z0my(Convert.ToString(obj), p1: false) : Convert.ToString(((z0ZzZzvbj)p0.z0lrk()).z0tek()));
				}
				else
				{
					obj2 = p0.z0my(Convert.ToString(obj), p1: false);
				}
			}
			else
			{
				obj2 = null;
			}
			if (p0.z0lrk() == null && obj == null)
			{
				return result;
			}
			string text3 = Convert.ToString(obj2);
			string text4 = Convert.ToString(obj);
			if (p0 is XTextInputFieldElement && text4 != null && text4.Length > 0 && (text3 == null || text3.Length == 0))
			{
				XTextInputFieldElement xTextInputFieldElement = p0 as XTextInputFieldElement;
				if ((xTextInputFieldElement.FieldSettings == null || xTextInputFieldElement.FieldSettings.z0nek() == InputFieldEditStyle.Text) && string.IsNullOrEmpty(z0ZzZzevj2.BindingPathForText))
				{
					obj2 = text4.ToString();
				}
			}
			p1.z0eek(p0);
			if (flag)
			{
				if (z0eek(p0, null, null, p1.z0eek()))
				{
					p0.z0hrk(p0: true);
					result = 1;
				}
			}
			else if (z0eek(p0, Convert.ToString(obj2), Convert.ToString(obj), p1.z0eek()))
			{
				p0.z0hrk(p0: true);
				result = 1;
			}
			if (!string.IsNullOrEmpty(z0ZzZzevj2.WriteTextBindingPath))
			{
				p0.z0eek(z0eek(p0, z0ZzZzevj2.DataSource, z0ZzZzevj2.WriteTextBindingPath, p1));
			}
			if (z0ZzZzevj2.ProcessState == DCProcessStates.Once)
			{
				z0ZzZzevj2.ProcessState = DCProcessStates.Never;
			}
			return result;
		}
		return z0eek((XTextContainerElement)p0, p1);
	}

	private z0ZzZzvbj z0eek(XTextElement p0, string p1)
	{
		XTextDocument xTextDocument = p0.z0jr();
		if (xTextDocument == null || !xTextDocument.z0bu().EnableDataBinding)
		{
			return null;
		}
		z0ZzZzvbj result = null;
		if (string.IsNullOrEmpty(p1))
		{
			for (XTextContainerElement xTextContainerElement = p0.z0ji(); xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
			{
				if (xTextContainerElement.z0ftk() != null)
				{
					result = (z0ZzZzvbj)xTextContainerElement.z0ftk();
					break;
				}
				if (xTextContainerElement == xTextDocument)
				{
					result = z0eek(xTextDocument);
					break;
				}
			}
		}
		else
		{
			result = ((z0ZzZzvbj)z0eek(xTextDocument)).z0eek(p1, p1: false);
		}
		return result;
	}

	public static void z0eek(Encoding p0)
	{
		z0tek = p0;
	}

	public override Hashtable z0kv(XTextDocument p0)
	{
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0nek<XTextInputFieldElementBase>().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)z0bpk.Current;
				string name = xTextInputFieldElementBase.Name;
				if (!string.IsNullOrEmpty(name))
				{
					if (!dictionary.ContainsKey(name))
					{
						dictionary[name] = new List<string>();
					}
					dictionary[name].Add(xTextInputFieldElementBase.Text);
				}
			}
		}
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0nek<XTextCheckBoxElementBase>().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)z0bpk.Current;
				if (!xTextCheckBoxElementBase.Checked)
				{
					continue;
				}
				string name2 = xTextCheckBoxElementBase.Name;
				if (!string.IsNullOrEmpty(name2))
				{
					if (!dictionary.ContainsKey(name2))
					{
						dictionary[name2] = new List<string>();
					}
					dictionary[name2].Add(xTextCheckBoxElementBase.CheckedValue);
				}
			}
		}
		Hashtable hashtable = new Hashtable();
		foreach (string key in dictionary.Keys)
		{
			List<string> list = dictionary[key];
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < list.Count; i++)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append(list[i]);
			}
			hashtable[key] = stringBuilder.ToString();
		}
		return hashtable;
	}

	public override bool z0lv(XTextDocument p0, string p1, string p2)
	{
		bool flag = false;
		XTextElementList xTextElementList = ((XTextContainerElement)p0).z0jrk(p1);
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextFieldElementBase)
				{
					XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)current;
					if (xTextFieldElementBase.z0jtk() != p2)
					{
						xTextFieldElementBase.z0krk(p2);
						flag = true;
					}
				}
				else if (current is XTextCheckBoxElement)
				{
					z0ZzZzzuk obj = new z0ZzZzzuk(p2, ',');
					XTextCheckBoxElement xTextCheckBoxElement = (XTextCheckBoxElement)current;
					bool flag2 = obj.z0tek(xTextCheckBoxElement.CheckedValue);
					if (xTextCheckBoxElement.EditorChecked != flag2)
					{
						xTextCheckBoxElement.EditorChecked = flag2;
						flag = true;
					}
				}
				else if (current is XTextRadioBoxElement)
				{
					XTextRadioBoxElement xTextRadioBoxElement = (XTextRadioBoxElement)current;
					bool flag3 = xTextRadioBoxElement.CheckedValue == p2;
					if (xTextRadioBoxElement.EditorChecked != flag3)
					{
						xTextRadioBoxElement.EditorChecked = flag3;
						flag = true;
					}
				}
			}
		}
		if (flag)
		{
			p0.z0vik();
		}
		return flag;
	}

	public override bool z0zb(XTextElement p0, string p1, bool p2)
	{
		if (p0 is XTextTableRowElement)
		{
			return z0eek((XTextTableRowElement)p0, p1, p2);
		}
		if (p0 is XTextTableElement)
		{
			return z0eek((XTextTableElement)p0, p1, p2);
		}
		if (p0 is XTextInputFieldElementBase)
		{
			return z0eek((XTextInputFieldElementBase)p0, p1, p2);
		}
		if (p0 is XTextContainerElement)
		{
			return z0eek((XTextContainerElement)p0, p1, p2);
		}
		return false;
	}

	private static bool z0eek(XTextElementList p0, object p1, bool p2)
	{
		if (p1 == null || DBNull.Value.Equals(p1) || p1.ToString().Length == 0)
		{
			bool flag = true;
			if (p0 != null && p0.Count > 0)
			{
				foreach (XTextElement item in p0.z0xrk())
				{
					if (!item.z0wtk())
					{
						flag = false;
					}
					if (item is XTextObjectElement && !item.z0wtk())
					{
						p2 = false;
						break;
					}
					if (item is XTextContainerElement)
					{
						XTextContainerElement obj = item as XTextContainerElement;
						string text = obj.Text;
						z0ZzZzdxj z0ZzZzdxj2 = new z0ZzZzdxj();
						z0ZzZzdxj2.z0tek(p0: false);
						z0ZzZzdxj2.z0eek(p0: false);
						z0ZzZzdxj2.z0yek(p0: false);
						z0ZzZzdxj2.z0rek(p0: false);
						z0ZzZzdxj2.z0uek(p0: false);
						p2 = z0eek(p1: obj.z0yek(z0ZzZzdxj2), p0: obj.z0be(), p2: p2);
						if (!p2)
						{
							break;
						}
					}
				}
			}
			if (p2 || flag)
			{
				return true;
			}
		}
		foreach (XTextElement item2 in p0.z0xrk())
		{
			if (!string.IsNullOrEmpty(Convert.ToString(p1)))
			{
				p2 = false;
				break;
			}
			if (item2 is XTextInputFieldElement)
			{
				XTextInputFieldElement xTextInputFieldElement = item2 as XTextInputFieldElement;
				if (xTextInputFieldElement.z0aek().z0jyk >= 0)
				{
					continue;
				}
				if (xTextInputFieldElement.z0be().Count > 0)
				{
					string text2 = xTextInputFieldElement.Text;
					z0ZzZzdxj z0ZzZzdxj3 = new z0ZzZzdxj();
					z0ZzZzdxj3.z0tek(p0: false);
					z0ZzZzdxj3.z0eek(p0: false);
					z0ZzZzdxj3.z0yek(p0: false);
					z0ZzZzdxj3.z0rek(p0: false);
					z0ZzZzdxj3.z0uek(p0: false);
					text2 = xTextInputFieldElement.z0yek(z0ZzZzdxj3);
					p2 = z0eek(xTextInputFieldElement.z0be(), text2, p2);
					break;
				}
			}
			if (item2 is XTextImageElement && item2.z0aek().z0jyk < 0)
			{
				p2 = false;
				break;
			}
		}
		if (WriterControlForWASM.z0vyk && p1 != null && p1.ToString().Trim().Length == 0)
		{
			p2 = true;
		}
		return p2;
	}

	internal void z0rek(XTextTableElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("table");
		}
		string text = p0.z0yrk();
		if (text == null || text.Length <= 0)
		{
			return;
		}
		if (WriterControlForWASM.z0hyk)
		{
			if (z0yek_jiejie20260327142557 != null)
			{
				XTextElementList p1 = z0yek_jiejie20260327142557[text];
				p0.z0li();
				p0.z0stk().Clear();
				p0.z0jr().z0cek(p1, p1: true);
				((zzz.z0ZzZzkuk<XTextElement>)p0.z0stk()).z0tek((zzz.z0ZzZzkuk<XTextElement>)p1);
				p0.z0oe();
				z0yek_jiejie20260327142557.Remove(text);
				p0.z0pek((string)null);
			}
			return;
		}
		XTextDocument xTextDocument = p0.z0jr();
		byte[] p2 = Convert.FromBase64String(text);
		XTextDocument xTextDocument2 = new XTextDocument();
		using (TextReader p3 = z0ZzZzmuk.z0eek(p2, Encoding.UTF8))
		{
			xTextDocument2.z0bek(p3, "xml");
		}
		if (p0 != null && xTextDocument2.z0xyk().z0be().Count > 0 && xTextDocument2.z0xyk().z0be()[0] is XTextTableElement)
		{
			XTextTableElement xTextTableElement = xTextDocument2.z0xyk().z0be()[0] as XTextTableElement;
			p0.z0li();
			p0.z0stk().Clear();
			xTextDocument.z0cek(xTextTableElement.z0stk(), p1: true);
			((zzz.z0ZzZzkuk<XTextElement>)p0.z0stk()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextTableElement.z0stk());
			p0.z0li();
			p0.z0oe();
		}
	}

	internal bool z0eek(XTextContainerElement p0, string p1, bool p2)
	{
		if ((p1 == null || p1.Length == 0) && p0 is XTextTableCellElement xTextTableCellElement)
		{
			_ = xTextTableCellElement.z0oek() == "A1";
		}
		int num = -1;
		int num2 = -1;
		if (p0 is XTextTableCellElement && p0.z0crk() && p0.z0be()[0] is XTextInputFieldElement)
		{
			num = ((XTextElement)p0.z0be()[0].z0dy()).z0pek();
			DocumentContentStyle documentContentStyle = p0.z0be()[0].z0aek().z0yek();
			documentContentStyle.CreatorIndex = -1;
			documentContentStyle.DeleterIndex = -1;
			documentContentStyle.CommentIndex = -1;
			bool flag = (documentContentStyle.BorderRight = false);
			bool flag3 = (documentContentStyle.BorderLeft = flag);
			bool borderBottom = (documentContentStyle.BorderTop = flag3);
			documentContentStyle.BorderBottom = borderBottom;
			num2 = p0.z0jr().z0gnk().GetStyleIndex(documentContentStyle);
		}
		else if (p0.z0crk() && p0.z0be()[0].z0dy() != null)
		{
			num = ((XTextElement)p0.z0be()[0].z0dy()).z0pek();
			DocumentContentStyle documentContentStyle2 = p0.z0be()[0].z0dy().z0aek().z0yek();
			documentContentStyle2.CreatorIndex = -1;
			documentContentStyle2.DeleterIndex = -1;
			documentContentStyle2.CommentIndex = -1;
			bool flag = (documentContentStyle2.BorderRight = false);
			bool flag3 = (documentContentStyle2.BorderLeft = flag);
			bool borderBottom = (documentContentStyle2.BorderTop = flag3);
			documentContentStyle2.BorderBottom = borderBottom;
			num2 = p0.z0jr().z0gnk().GetStyleIndex(documentContentStyle2);
		}
		else
		{
			num = ((p0.z0dy() != null) ? ((XTextElement)p0.z0dy()).z0pek() : (-1));
			DocumentContentStyle documentContentStyle3 = p0.z0aek().z0yek();
			documentContentStyle3.CreatorIndex = -1;
			documentContentStyle3.DeleterIndex = -1;
			documentContentStyle3.CommentIndex = -1;
			bool flag = (documentContentStyle3.BorderRight = false);
			bool flag3 = (documentContentStyle3.BorderLeft = flag);
			bool borderBottom = (documentContentStyle3.BorderTop = flag3);
			documentContentStyle3.BorderBottom = borderBottom;
			num2 = p0.z0jr().z0gnk().GetStyleIndex(documentContentStyle3);
		}
		int num3 = p1?.IndexOf(',') ?? (-1);
		if (p1 != null && p1.StartsWith("data:image/") && num3 > 0)
		{
			try
			{
				bool flag12 = false;
				float num4 = 0f;
				float num5 = 0f;
				if (p1.Contains("$imagewidthheight$"))
				{
					string[] array = p1.Split("$imagewidthheight$");
					if (array.Length == 2)
					{
						p1 = array[0];
						string[] array2 = array[1].Split('h');
						string text = array2[1];
						if (float.TryParse(array2[0].Split('w')[1], out num4) && float.TryParse(text, out num5) && num4 > 0f && num5 > 0f)
						{
							flag12 = true;
						}
					}
				}
				string p3 = p1.Substring(num3 + 1);
				XTextImageElement xTextImageElement = new XTextImageElement();
				xTextImageElement.z0rek(p3, !flag12);
				if (flag12)
				{
					xTextImageElement.Width = num4;
					xTextImageElement.Height = num5;
					xTextImageElement.KeepWidthHeightRate = false;
				}
				XTextContainerElement xTextContainerElement = p0;
				XTextElementList xTextElementList = p0.z0nek<XTextInputFieldElement>();
				if (xTextElementList != null && xTextElementList.Count == 1)
				{
					xTextContainerElement = xTextElementList[0] as XTextInputFieldElement;
				}
				if (xTextImageElement.z0frk().HasContent && !flag12)
				{
					float num6 = xTextImageElement.Width / xTextImageElement.Height;
					XTextContainerElement xTextContainerElement2 = ((xTextContainerElement is XTextTableCellElement) ? xTextContainerElement : xTextContainerElement.z0ji());
					if (xTextImageElement.Width > ((XTextElement)xTextContainerElement2).z0ork() || xTextImageElement.Height > xTextContainerElement2.Height)
					{
						float num7 = xTextImageElement.Width - ((XTextElement)xTextContainerElement2).z0ork();
						float num8 = xTextImageElement.Height - xTextContainerElement2.Height;
						if (num7 >= num8)
						{
							xTextImageElement.Width = ((XTextElement)xTextContainerElement2).z0ork();
							xTextImageElement.Height = xTextImageElement.Width / num6;
						}
						else
						{
							xTextImageElement.Height = xTextContainerElement2.Height;
							xTextImageElement.Width = xTextImageElement.Height * num6;
						}
					}
				}
				xTextContainerElement.z0be().Clear();
				xTextContainerElement.z0be().Add(xTextImageElement);
				if (xTextContainerElement is XTextTableCellElement)
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
					xTextParagraphFlagElement.z0xrk().Align = DocumentContentAlignment.Center;
					xTextContainerElement.z0be().Add(xTextParagraphFlagElement);
				}
			}
			catch
			{
			}
		}
		else if (p0 is XTextTableCellElement && p0.z0be().Count <= 2 && p0.z0be()[0] is XTextInputFieldElement)
		{
			XTextInputFieldElement xTextInputFieldElement = p0.z0be()[0] as XTextInputFieldElement;
			if (xTextInputFieldElement.FieldSettings != null && xTextInputFieldElement.FieldSettings.z0nek() == InputFieldEditStyle.DropdownList && xTextInputFieldElement.FieldSettings.z0zek() != null && xTextInputFieldElement.FieldSettings.z0zek().Items != null)
			{
				string text2 = null;
				using (zzz.z0ZzZzkuk<ListItem>.z0bpk z0bpk = xTextInputFieldElement.FieldSettings.z0zek().Items.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						ListItem current = z0bpk.Current;
						if (current.Value == p1)
						{
							text2 = current.Text;
							break;
						}
					}
				}
				if (text2 != null)
				{
					xTextInputFieldElement.z0cek(text2, num2, num);
					xTextInputFieldElement.InnerValue = p1;
				}
				else
				{
					xTextInputFieldElement.z0cek(p1, num2, num);
					if (string.IsNullOrEmpty(p1))
					{
						xTextInputFieldElement.InnerValue = null;
					}
				}
			}
			else
			{
				xTextInputFieldElement.z0cek(p1, num2, num);
				if (string.IsNullOrEmpty(p1))
				{
					xTextInputFieldElement.InnerValue = null;
				}
			}
		}
		else if (p0.z0be().Count <= 2 && p0.z0be()[0] is XTextCheckBoxElementBase)
		{
			XTextCheckBoxElementBase xTextCheckBoxElementBase = p0.z0be()[0] as XTextCheckBoxElementBase;
			XTextElementList xTextElementList2 = xTextCheckBoxElementBase.z0eek();
			if (xTextCheckBoxElementBase.Name == null || xTextCheckBoxElementBase.Name.Length == 0 || xTextElementList2.Count == 1)
			{
				if (p1 != null && p1.Contains(","))
				{
					string[] array3 = p1.Split(',');
					if (xTextCheckBoxElementBase.CheckedValue != null && xTextCheckBoxElementBase.CheckedValue.Length > 0 && Array.IndexOf(array3, xTextCheckBoxElementBase.CheckedValue) >= 0)
					{
						xTextCheckBoxElementBase.Checked = true;
					}
					else
					{
						xTextCheckBoxElementBase.Checked = false;
					}
				}
				else if (p1 != null && (p1 == xTextCheckBoxElementBase.CheckedValue || p1.ToLower() == "true"))
				{
					xTextCheckBoxElementBase.Checked = true;
				}
				else if (p1 != null && (p1 != xTextCheckBoxElementBase.CheckedValue || p1.ToLower() == "false"))
				{
					xTextCheckBoxElementBase.Checked = false;
				}
			}
			else if (xTextCheckBoxElementBase.z0jr() != null && xTextElementList2.Count > 1)
			{
				string[] array4 = p1.Split(',');
				if (xTextCheckBoxElementBase.CheckedValue != null && xTextCheckBoxElementBase.CheckedValue.Length > 0 && Array.IndexOf(array4, xTextCheckBoxElementBase.CheckedValue) >= 0)
				{
					xTextCheckBoxElementBase.Checked = true;
				}
				else
				{
					xTextCheckBoxElementBase.Checked = false;
				}
			}
		}
		else if (p0 is XTextTableCellElement && ((XTextTableCellElement)p0).SlantSplitLineStyle != RectangleSlantSplitStyle.None && p1 != null && p1.Contains("$" + ((XTextTableCellElement)p0).SlantSplitLineStyle.ToString() + "$"))
		{
			string text3 = ((XTextTableCellElement)p0).SlantSplitLineStyle.ToString();
			string[] array5 = p1.Split("$" + text3 + "$");
			XTextStringElement xTextStringElement = new XTextStringElement();
			xTextStringElement.z0bt(p0.z0jr());
			XTextElementList xTextElementList3 = xTextStringElement.z0zek(array5[0]);
			XTextStringElement xTextStringElement2 = new XTextStringElement();
			xTextStringElement2.z0bt(p0.z0jr());
			XTextElementList xTextElementList4 = xTextStringElement2.z0zek(array5[1]);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextElementList3.z0ltk())
			{
				while (z0bpk2.MoveNext())
				{
					z0bpk2.Current.z0oek(num2);
				}
			}
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextElementList4.z0ltk())
			{
				while (z0bpk2.MoveNext())
				{
					z0bpk2.Current.z0oek(num2);
				}
			}
			switch (text3)
			{
			case "TopLeftOneLine":
			{
				p0.z0be().Clear();
				((zzz.z0ZzZzkuk<XTextElement>)p0.z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList3);
				XTextParagraphFlagElement xTextParagraphFlagElement3 = new XTextParagraphFlagElement();
				xTextParagraphFlagElement3.z0xrk().Align = DocumentContentAlignment.Right;
				p0.z0be().Add(xTextParagraphFlagElement3);
				((zzz.z0ZzZzkuk<XTextElement>)p0.z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList4);
				p0.z0be().Add(new XTextParagraphFlagElement());
				break;
			}
			case "TopRightOneLine":
			case "BottomLeftOneLine":
			{
				p0.z0be().Clear();
				((zzz.z0ZzZzkuk<XTextElement>)p0.z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList3);
				p0.z0be().Add(new XTextParagraphFlagElement());
				((zzz.z0ZzZzkuk<XTextElement>)p0.z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList4);
				XTextParagraphFlagElement xTextParagraphFlagElement2 = new XTextParagraphFlagElement();
				xTextParagraphFlagElement2.z0xrk().Align = DocumentContentAlignment.Right;
				p0.z0be().Add(xTextParagraphFlagElement2);
				break;
			}
			default:
				p0.z0cek(p1, num2, num);
				break;
			}
		}
		else
		{
			p0.z0cek(p1, num2, num);
		}
		p0.z0zek(p0.z0kek());
		p0.Modified = true;
		return true;
	}

	private bool z0eek(XTextTableRowElement p0, string p1, bool p2)
	{
		return false;
	}

	internal static bool z0eek(ValueValidateStyle p0, XTextElementList p1, object p2, ref string p3)
	{
		p3 = "";
		if (p0 == null)
		{
			return true;
		}
		p0.RequiredInvalidateFlag = false;
		p0.Message = null;
		string text = p0.CustomMessage;
		if (text == null || text.Trim().Length == 0)
		{
			text = null;
		}
		bool flag = false;
		if (p0.Required)
		{
			if (p1.Count > 0)
			{
				flag = z0eek(p1, p2, flag);
			}
			if (p1.Count == 0 || flag)
			{
				p0.Message = ((text != null) ? text : z0ZzZziok.z0pek());
				p0.RequiredInvalidateFlag = true;
				return false;
			}
			if (WriterControlForWASM.z0otk && p1.Count > 0 && p2 is string && p2.ToString().Trim('\n') == "")
			{
				p0.Message = ((text != null) ? text : z0ZzZziok.z0pek());
				p0.RequiredInvalidateFlag = true;
				return false;
			}
		}
		if (!flag && !string.IsNullOrEmpty(p0.IncludeKeywords))
		{
			string[] array = p0.IncludeKeywords.Split(',');
			string text2 = Convert.ToString(p2);
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i] == text2)
				{
					return true;
				}
			}
		}
		switch (p0.ValueType)
		{
		case ValueTypeStyle.Text:
		{
			string text5 = Convert.ToString(p2);
			if (p0.CheckMaxValue && p0.MaxLength > 0 && text5 != null && z0eek(p0, text5) > p0.MaxLength)
			{
				p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0yik(), p0.MaxLength));
				return false;
			}
			if (p0.CheckMinValue && p0.MinLength > 0 && text5 != null && z0eek(p0, text5) < p0.MinLength)
			{
				p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0yrk(), p0.MinLength));
				return false;
			}
			if (p0.Range == null || p0.Range.Length <= 0)
			{
				break;
			}
			bool flag4 = true;
			string[] array2 = p0.Range.Split(new char[1] { ',' });
			foreach (string text6 in array2)
			{
				flag4 = false;
				if (string.Compare(text5, text6.Trim(), true) == 0)
				{
					flag4 = true;
					break;
				}
			}
			if (!flag4)
			{
				p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0iyk(), p0.Range));
				return false;
			}
			break;
		}
		case ValueTypeStyle.Integer:
		case ValueTypeStyle.Numeric:
		{
			double num = z0ZzZzbok.z0rek;
			if (p2.ToString() == "")
			{
				return true;
			}
			if (p2 is int || p2 is float || p2 is double)
			{
				num = (double)p2;
			}
			else
			{
				bool flag2 = false;
				if (p0.ValueType == ValueTypeStyle.Numeric)
				{
					flag2 = double.TryParse(Convert.ToString(p2), out num);
					if (flag2 && p2.ToString().Trim() != p2.ToString())
					{
						flag2 = false;
					}
					if (!flag2)
					{
						p0.Message = ((text != null) ? text : z0ZzZziok.z0cyk());
						return false;
					}
				}
				else
				{
					int num2 = -2147483648;
					flag2 = int.TryParse(Convert.ToString(p2), out num2);
					if (flag2 && p2.ToString().Trim() != p2.ToString())
					{
						flag2 = false;
					}
					if (!flag2)
					{
						p0.Message = ((text != null) ? text : z0ZzZziok.z0xik());
						return false;
					}
					num = num2;
				}
			}
			if (p0.CheckMaxValue && !z0ZzZzbok.z0eek(p0.MaxValue) && num > p0.MaxValue)
			{
				p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0kik(), p0.MaxValue));
				return false;
			}
			if (p0.CheckMinValue && !z0ZzZzbok.z0eek(p0.MinValue) && num < p0.MinValue)
			{
				p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0wrk(), p0.MinValue));
				return false;
			}
			if (p0.CheckDecimalDigits)
			{
				string text3 = Convert.ToString(p2);
				if (text3.Contains(".") && text3.Length - text3.IndexOf('.') - 1 > p0.MaxDecimalDigits)
				{
					p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0ark(), p0.MaxDecimalDigits));
					return false;
				}
			}
			if (p0.Range == null || p0.Range.Length <= 0)
			{
				break;
			}
			bool flag3 = true;
			string[] array2 = p0.Range.Split(new char[1] { ',' });
			foreach (string text4 in array2)
			{
				flag3 = false;
				int num3 = text4.IndexOf('-');
				if (num3 > 0)
				{
					double num4 = 0.0;
					double num5 = 0.0;
					if (double.TryParse(text4.Substring(0, num3), out num4) && double.TryParse(text4.Substring(num3 + 1), out num5) && num >= num4 && num <= num5)
					{
						flag3 = true;
						break;
					}
				}
				else
				{
					double num6 = z0ZzZzbok.z0rek;
					if (double.TryParse(text4, out num6) && num6 == num)
					{
						flag3 = true;
						break;
					}
				}
			}
			if (!flag3)
			{
				p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0iyk(), p0.Range));
				return false;
			}
			break;
		}
		case ValueTypeStyle.Date:
		{
			DateTime result2 = DateTime.MinValue;
			if (Convert.ToString(p2) == "")
			{
				return true;
			}
			if (!DateTime.TryParse(Convert.ToString(p2), out result2))
			{
				p0.Message = ((text != null) ? text : z0ZzZziok.z0qtk());
				return false;
			}
			result2 = result2.Date;
			if (p0.CheckMaxValue)
			{
				DateTime date = p0.DateTimeMaxValue.Date;
				if (result2 > date)
				{
					p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0kik(), z0ZzZznuk.z0eek(date)));
					return false;
				}
			}
			if (p0.CheckMinValue)
			{
				DateTime date2 = p0.DateTimeMinValue.Date;
				if (result2 < date2)
				{
					p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0wrk(), z0ZzZznuk.z0eek(date2)));
					return false;
				}
			}
			break;
		}
		case ValueTypeStyle.Time:
		{
			TimeSpan zero = TimeSpan.Zero;
			if (Convert.ToString(p2) == "")
			{
				return true;
			}
			if (!TimeSpan.TryParse(Convert.ToString(p2), out zero))
			{
				p0.Message = ((text != null) ? text : z0ZzZziok.z0wyk());
				return false;
			}
			if (p0.CheckMaxValue)
			{
				TimeSpan timeOfDay = p0.DateTimeMaxValue.TimeOfDay;
				timeOfDay = new TimeSpan(timeOfDay.Hours, timeOfDay.Minutes, timeOfDay.Seconds);
				if (zero > timeOfDay)
				{
					p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0kik(), timeOfDay));
					return false;
				}
			}
			if (p0.CheckMinValue)
			{
				TimeSpan timeOfDay2 = p0.DateTimeMinValue.TimeOfDay;
				timeOfDay2 = new TimeSpan(timeOfDay2.Hours, timeOfDay2.Minutes, timeOfDay2.Seconds);
				if (zero < timeOfDay2)
				{
					p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0wrk(), timeOfDay2));
					return false;
				}
			}
			break;
		}
		case ValueTypeStyle.DateTime:
		{
			DateTime result = DateTime.MinValue;
			if (Convert.ToString(p2) == "")
			{
				return true;
			}
			if (!DateTime.TryParse(Convert.ToString(p2), out result))
			{
				p0.Message = ((text != null) ? text : z0ZzZziok.z0yok());
				return false;
			}
			if (p0.CheckMaxValue)
			{
				DateTime dateTimeMaxValue = p0.DateTimeMaxValue;
				if (result > dateTimeMaxValue)
				{
					p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0kik(), dateTimeMaxValue.ToString(z0ZzZzkfh.z0qrk)));
					return false;
				}
			}
			if (p0.CheckMinValue)
			{
				DateTime dateTimeMinValue = p0.DateTimeMinValue;
				if (result < dateTimeMinValue)
				{
					p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0wrk(), dateTimeMinValue.ToString(z0ZzZzkfh.z0qrk)));
					return false;
				}
			}
			break;
		}
		case ValueTypeStyle.RegExpress:
			if (!flag && !string.IsNullOrEmpty(p0.RegExpression))
			{
				string p4 = Convert.ToString(p2);
				if (!z0ZzZzroj.z0nek(p0.RegExpression, p4))
				{
					p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0myk(), p0.RegExpression));
					return false;
				}
			}
			break;
		}
		if (!flag && !string.IsNullOrEmpty(p0.ExcludeKeywords))
		{
			string p5 = null;
			if (!z0eek(Convert.ToString(p2), p0.ExcludeKeywords, ref p5))
			{
				p0.Message = ((text != null) ? text : string.Format(z0ZzZziok.z0jrk(), p5));
				p3 = p5;
				return false;
			}
		}
		return true;
	}

	private z0ZzZzvbj z0eek(XTextElement p0, z0ZzZzevj p1, z0ZzZzrlh p2, string p3 = null)
	{
		if (p1 == null)
		{
			return null;
		}
		if (!p0.z0jr().z0bek(p1))
		{
			return null;
		}
		if (string.IsNullOrEmpty(p3))
		{
			return z0eek(p0, p1.DataSource, p1.BindingPath, p2);
		}
		return z0eek(p0, p1.DataSource, p3, p2);
	}

	public override int z0xb(XTextElement p0, z0ZzZzrlh p1)
	{
		if (XTextContainerElement.z0ttk != null && p0 != null && p0.z0qr("CustomerCustomizationCheckDataSourceUIChanged") && p0.z0qr("CustomerCustomizationDataSourceUIChanged"))
		{
			return 0;
		}
		if (p0 is XTextInputFieldElementBase)
		{
			return z0eek((XTextInputFieldElementBase)p0, p1);
		}
		if (p0 is XTextTableElement)
		{
			return z0eek((XTextTableElement)p0, p1);
		}
		if (p0 is XTextLabelElementBase)
		{
			return z0eek((XTextLabelElementBase)p0, p1);
		}
		if (p0 is XTextImageElement)
		{
			return z0eek((XTextImageElement)p0, p1);
		}
		if (p0 is XTextCheckBoxElementBase)
		{
			return z0eek((XTextCheckBoxElementBase)p0, p1);
		}
		if (p0 is XTextChartElement)
		{
			return z0eek((XTextChartElement)p0, p1);
		}
		if (p0 is XTextPieElement)
		{
			return z0eek((XTextPieElement)p0, p1);
		}
		if (p0 is XTextContainerElement)
		{
			return z0eek((XTextContainerElement)p0, p1);
		}
		return 0;
	}

	private static bool z0eek(string p0, string p1, ref string p2)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return true;
		}
		if (p1.Length > 0)
		{
			string[] array = p1.Split(',');
			foreach (string text in array)
			{
				if (p0.Contains(text, StringComparison.Ordinal))
				{
					p2 = text;
					return false;
				}
			}
		}
		return true;
	}

	private static int z0eek(ValueValidateStyle p0, string p1)
	{
		if (string.IsNullOrEmpty(p1))
		{
			return 0;
		}
		if (p0.BinaryLength)
		{
			return z0eek().GetByteCount(p1);
		}
		return p1.Length;
	}

	public override void z0cb(XTextTableElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("table");
		}
		if (p0.z0mrk())
		{
			p0.z0xwk();
			z0eek(p0);
			int num = -1;
			for (int i = 0; i < p0.z0brk(); i++)
			{
				XTextTableRowElement xTextTableRowElement = p0.z0stk()[i] as XTextTableRowElement;
				if (xTextTableRowElement.HeaderStyle || xTextTableRowElement.ValueBinding == null || xTextTableRowElement.ValueBinding.DataSource == null || xTextTableRowElement.ValueBinding.DataSource.Length <= 0)
				{
					continue;
				}
				if (num < 0)
				{
					num = i;
				}
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement.z0rek().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
						if (xTextTableCellElement.ValueBinding == null || xTextTableCellElement.ValueBinding.BindingPath == null)
						{
							continue;
						}
						int p1 = -1;
						XTextElementList xTextElementList = xTextTableCellElement.z0nek<XTextInputFieldElement>();
						XTextElementList xTextElementList2 = xTextTableCellElement.z0nek<XTextObjectElement>();
						if (xTextTableCellElement.z0be().Count <= 2 && xTextTableCellElement.z0be()[0] is XTextInputFieldElement)
						{
							(xTextTableCellElement.z0be()[0] as XTextInputFieldElement).z0be().Clear();
						}
						else
						{
							if (xTextTableCellElement.z0be().Count <= 2 && xTextTableCellElement.z0be()[0] is XTextCheckBoxElementBase)
							{
								continue;
							}
							if (xTextElementList.Count > 1 || xTextElementList2.Count > 1)
							{
								using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextElementList.z0ltk())
								{
									while (z0bpk2.MoveNext())
									{
										XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)z0bpk2.Current;
										if (((XTextContainerElement)xTextInputFieldElement).z0hrk())
										{
											xTextInputFieldElement.z0be().Clear();
										}
									}
								}
								continue;
							}
							if (xTextTableCellElement.z0be().Count > 0)
							{
								xTextTableCellElement.z0be()[0].z0pek();
								p1 = ((XTextElement)xTextTableCellElement.z0be()[0].z0dy()).z0pek();
							}
							xTextTableCellElement.z0be().Clear();
							XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
							xTextParagraphFlagElement.z0oek(p1);
							xTextTableCellElement.z0be().Add(xTextParagraphFlagElement);
						}
					}
				}
				break;
			}
			if (num >= 0)
			{
				for (int num2 = p0.z0brk() - 1; num2 > num; num2--)
				{
					p0.z0stk().RemoveAt(num2);
				}
				p0.z0li();
			}
			else
			{
				if (z0yek_jiejie20260327142557 != null && p0.z0yrk() != null)
				{
					z0yek_jiejie20260327142557.Remove(p0.z0yrk());
				}
				p0.z0pek((string)null);
			}
		}
		else
		{
			if (z0yek_jiejie20260327142557 != null && p0.z0yrk() != null)
			{
				z0yek_jiejie20260327142557.Remove(p0.z0yrk());
			}
			p0.z0pek((string)null);
		}
	}

	internal int z0eek(XTextContainerElement p0, z0ZzZzrlh p1)
	{
		p0.z0hrk(p0: false);
		if (p1 == null)
		{
			throw new ArgumentNullException("args");
		}
		if (!p0.z0bu().EnableDataBinding)
		{
			return 0;
		}
		z0ZzZzevj z0ZzZzevj2 = (p0.z0pr() ? p0.ValueBinding : null);
		z0ZzZzvbj z0ZzZzvbj2 = null;
		if (p0.z0jr().z0bek(z0ZzZzevj2))
		{
			z0ZzZzvbj2 = z0eek(p0, z0ZzZzevj2, p1);
		}
		if (!p1.z0tek_jiejie20260327142557())
		{
			bool flag = true;
			if (p0.z0ftk() is z0ZzZzvbj && p1.z0mek() != null && ((z0ZzZzvbj)p0.z0ftk()).z0pv() == p1.z0mek())
			{
				flag = false;
			}
			if (flag)
			{
				p0.z0cek(z0ZzZzvbj2);
			}
		}
		int num = 0;
		XTextElementList xTextElementList = p0.z0be();
		if (p1.z0iek() != null)
		{
			xTextElementList = p1.z0iek();
		}
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (!(current is XTextCharElement) && !(current is XTextParagraphFlagElement) && !current.z0wtk())
				{
					int num2 = z0xb(current, p1);
					num += num2;
				}
			}
		}
		if (z0uek && (z0ZzZzvbj2 == null || z0ZzZzvbj2.z0bek()))
		{
			return num;
		}
		if (p1.z0tek_jiejie20260327142557())
		{
			if (z0ZzZzvbj2 != null)
			{
				object obj = z0ZzZzvbj2.z0tek();
				if (obj == null || DBNull.Value.Equals(obj))
				{
					obj = null;
				}
				string text = ((obj == null) ? null : Convert.ToString(obj));
				string text2 = p0.Text;
				if (string.IsNullOrEmpty(text2))
				{
					text2 = null;
				}
				if (!string.Equals(text, text2))
				{
					DetectResultForValueBindingModified p2 = new DetectResultForValueBindingModified(p0.ValueBinding, p0, text2, text);
					p1.z0eek(p2);
				}
			}
			return 0;
		}
		if (num == 0 && z0ZzZzvbj2 != null)
		{
			object obj2 = z0ZzZzvbj2.z0tek();
			if (obj2 == null || DBNull.Value.Equals(obj2))
			{
				if (z0zb(p0, null, p1.z0eek()))
				{
					num = 1;
					p0.z0hrk(p0: true);
				}
			}
			else if (z0zb(p0, Convert.ToString(obj2), p1.z0eek()))
			{
				num = 1;
				p0.z0hrk(p0: true);
			}
			p1.z0eek(p0);
		}
		if (z0ZzZzevj2 != null && z0ZzZzevj2.ProcessState == DCProcessStates.Once)
		{
			z0ZzZzevj2.ProcessState = DCProcessStates.Never;
		}
		z0ZzZzevj2?.z0rek(p0: true);
		return num;
	}

	public override string z0vb(XTextDocument p0)
	{
		Hashtable hashtable = p0.z0yuk();
		StringWriter stringWriter = new StringWriter();
		z0ZzZzhqh z0ZzZzhqh2 = new z0ZzZzhqh(stringWriter);
		z0ZzZzhqh2.z0eek((z0ZzZzesh)1);
		z0ZzZzhqh2.z0rek(1);
		z0ZzZzhqh2.z0eek(' ');
		z0ZzZzhqh2.z0ug();
		z0ZzZzhqh2.z0eek("Values");
		foreach (string key in hashtable.Keys)
		{
			string p1 = (string)hashtable[key];
			z0ZzZzhqh2.z0eek("Value");
			z0ZzZzhqh2.z0eek("Name", key);
			z0ZzZzhqh2.z0yg(p1);
			z0ZzZzhqh2.z0bg();
		}
		z0ZzZzhqh2.z0bg();
		z0ZzZzhqh2.z0vg();
		z0ZzZzhqh2.z0kf();
		return z0ZzZzzik.z0eek(stringWriter.ToString());
	}
}
