using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzvoj : IDisposable
{
	private HashSet<XTextElement> z0rek = new HashSet<XTextElement>();

	private Dictionary<XTextElement, JsonNode> z0tek_jiejie20260327142557 = new Dictionary<XTextElement, JsonNode>();

	public int z0eek(XTextContainerElement p0, JsonObject p1)
	{
		p0.z0jr();
		int num = 0;
		z0ZzZzevj valueBinding = p0.ValueBinding;
		if (valueBinding != null && valueBinding.z0eek() && !valueBinding.IsEmptyBinding)
		{
			JsonNode p2 = z0eek(p1, valueBinding.DataSource);
			if (p0 is XTextTableRowElement xTextTableRowElement)
			{
				XTextTableElement xTextTableElement = xTextTableRowElement.z0gr();
				p2 = z0eek(p2, valueBinding.BindingPath);
				IList<XTextElement> list = null;
				list = new XTextElement[1] { xTextTableRowElement };
				if (p2 is JsonArray jsonArray)
				{
					List<XTextTableRowElement> list2 = new List<XTextTableRowElement>();
					foreach (JsonNode item in jsonArray)
					{
						if (!(item is JsonObject jsonObject))
						{
							continue;
						}
						foreach (XTextTableRowElement item2 in list)
						{
							XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)item2.z0lr(p0: true);
							using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement2.z0rek().z0ltk())
							{
								while (z0bpk.MoveNext())
								{
									XTextTableCellElement p3 = (XTextTableCellElement)z0bpk.Current;
									num += z0eek(p3, jsonObject);
								}
							}
							list2.Add(xTextTableRowElement2);
							z0tek_jiejie20260327142557[xTextTableRowElement2] = jsonObject;
						}
					}
					int p4 = xTextTableElement.z0stk().IndexOf(xTextTableRowElement);
					xTextTableElement.z0stk().z0irk(p4, list.Count);
					if (list2.Count > 0)
					{
						xTextTableElement.z0stk().z0yek(p4, list2);
					}
					foreach (XTextElement item3 in list)
					{
						item3.Dispose();
					}
					list2.Clear();
				}
				else if (p2 is JsonObject p5)
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement.z0rek().z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement p6 = (XTextTableCellElement)z0bpk.Current;
						num += z0eek(p6, p5);
					}
				}
			}
			else if (p0 is XTextTableElement xTextTableElement2)
			{
				p2 = z0eek(p2, valueBinding.BindingPath);
				if (p2 is JsonObject p7)
				{
					foreach (XTextTableRowElement item4 in xTextTableElement2.z0stk().z0xrk())
					{
						num += z0eek(item4, p7);
					}
				}
			}
			else
			{
				p2 = z0eek(p2, valueBinding.BindingPath);
				z0tek_jiejie20260327142557[p0] = p2;
				if (p2 is JsonObject p9)
				{
					num += z0eek(p0.z0be(), p9);
				}
				else if (p0 is XTextInputFieldElement xTextInputFieldElement)
				{
					p2 = z0eek(p1, valueBinding.DataSource);
					string text = null;
					string text2 = null;
					if (!string.IsNullOrEmpty(valueBinding.BindingPath))
					{
						text2 = z0eek(p2, valueBinding.BindingPath)?.ToString();
					}
					text = (string.IsNullOrEmpty(valueBinding.BindingPathForText) ? text2 : z0eek(p2, valueBinding.BindingPathForText)?.ToString());
					xTextInputFieldElement.z0zek(text);
					xTextInputFieldElement.InnerValue = text2;
				}
				else
				{
					string p10 = z0eek(p2, valueBinding.BindingPath)?.ToString();
					p0.z0zek(p10);
				}
			}
		}
		else
		{
			z0eek(p0.z0be(), p1);
		}
		return num;
	}

	public void Dispose()
	{
		z0tek_jiejie20260327142557.Clear();
		z0rek.Clear();
		z0tek_jiejie20260327142557 = null;
		z0rek = null;
	}

	private int z0eek(XTextElementList p0, JsonElement p1)
	{
		if (p0 == null || p0.Count == 0 || p1.ValueKind != JsonValueKind.Object)
		{
			return 0;
		}
		int num = 0;
		foreach (XTextElement item in p0.z0xrk())
		{
			if (z0rek.Contains(item))
			{
				continue;
			}
			z0rek.Add(item);
			if (item is XTextCheckBoxElementBase { ValueBinding: var valueBinding } xTextCheckBoxElementBase)
			{
				if (valueBinding == null || valueBinding.IsEmptyBinding)
				{
					continue;
				}
				XTextElementList xTextElementList = xTextCheckBoxElementBase.z0eek();
				JsonElement p2 = z0eek(p1, valueBinding.DataSource);
				p2 = z0eek(p2, valueBinding.BindingPath);
				bool flag = false;
				bool flag2 = xTextCheckBoxElementBase.Checked;
				if (p2.ValueKind == JsonValueKind.True)
				{
					flag = true;
					flag2 = true;
				}
				else if (p2.ValueKind == JsonValueKind.False)
				{
					flag = true;
					flag2 = false;
				}
				else if (p2.ValueKind == JsonValueKind.String)
				{
					string text = p2.GetString()?.Trim();
					if ("true".Equals(text, StringComparison.OrdinalIgnoreCase))
					{
						flag2 = true;
						flag = true;
					}
					else if ("false".Equals(text, StringComparison.OrdinalIgnoreCase))
					{
						flag2 = false;
						flag = true;
					}
				}
				if (flag && xTextElementList.Count == 1 && xTextCheckBoxElementBase.Checked != flag2)
				{
					xTextCheckBoxElementBase.Checked = flag2;
					num++;
					z0rek.Add(xTextCheckBoxElementBase);
					continue;
				}
				string text2 = p2.ToString();
				if (string.IsNullOrEmpty(text2))
				{
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							XTextCheckBoxElementBase xTextCheckBoxElementBase2 = (XTextCheckBoxElementBase)z0bpk.Current;
							if (xTextCheckBoxElementBase2.Checked)
							{
								xTextCheckBoxElementBase2.Checked = false;
								num++;
							}
						}
					}
					continue;
				}
				string[] array = text2.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase3 = (XTextCheckBoxElementBase)z0bpk.Current;
					z0rek.Add(xTextCheckBoxElementBase3);
					bool flag3 = Array.IndexOf(array, xTextCheckBoxElementBase3.CheckedValue) >= 0;
					if (xTextCheckBoxElementBase.Checked != flag3)
					{
						xTextCheckBoxElementBase.Checked = flag3;
						num++;
					}
					if (!(xTextCheckBoxElementBase is XTextRadioBoxElement))
					{
						continue;
					}
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextElementList.z0ltk())
					{
						while (z0bpk2.MoveNext())
						{
							XTextCheckBoxElementBase xTextCheckBoxElementBase4 = (XTextCheckBoxElementBase)z0bpk2.Current;
							if (xTextCheckBoxElementBase4.Checked && xTextCheckBoxElementBase4 != xTextCheckBoxElementBase3)
							{
								xTextCheckBoxElementBase4.Checked = false;
								num++;
							}
						}
					}
					break;
				}
			}
			else if (item is XTextImageElement { ValueBinding: var valueBinding2 } xTextImageElement)
			{
				if (valueBinding2 == null || valueBinding2.IsEmptyBinding)
				{
					continue;
				}
				JsonElement p3 = z0eek(p1, valueBinding2.DataSource);
				p3 = z0eek(p3, valueBinding2.BindingPath);
				if (p3.ValueKind == JsonValueKind.String)
				{
					string text3 = p3.GetString()?.Trim();
					text3 = text3.Trim();
					if (text3.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || text3.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
					{
						xTextImageElement.z0tek(text3);
						xTextImageElement.z0rek((byte[])null);
						xTextImageElement.z0xek();
						num++;
						continue;
					}
					if (text3.StartsWith("data:image/", StringComparison.OrdinalIgnoreCase))
					{
						xTextImageElement.z0rek(z0ZzZzpmk.ParseEmitImageSource(text3));
						num++;
						continue;
					}
					try
					{
						byte[] p4 = Convert.FromBase64String(text3);
						xTextImageElement.z0rek(p4);
						num++;
					}
					catch
					{
					}
				}
				else
				{
					xTextImageElement.z0rek((byte[])null);
					num++;
				}
			}
			else if (item is XTextLabelElementBase { ValueBinding: { IsEmptyBinding: false } valueBinding3 } xTextLabelElementBase)
			{
				string text4 = z0eek(z0eek(p1, valueBinding3.DataSource), valueBinding3.BindingPath).z0yek();
				if (xTextLabelElementBase.Text != text4)
				{
					xTextLabelElementBase.Text = text4;
					num++;
				}
			}
		}
		return num;
	}

	private static JsonNode z0eek(JsonNode p0, string p1)
	{
		if (p1 == null || p1.Length == 0)
		{
			return p0;
		}
		if (p0 == null)
		{
			return null;
		}
		if (!(p0 is JsonObject jsonObject))
		{
			return null;
		}
		while (true)
		{
			int num = p1.IndexOf('.');
			string text = p1.Trim();
			if (num > 0)
			{
				text = p1.Substring(0, num).Trim();
				p1 = p1.Substring(num + 1).Trim();
			}
			else
			{
				p1 = null;
			}
			if (!jsonObject.TryGetPropertyValue(text, out JsonNode jsonNode) || jsonNode == null)
			{
				break;
			}
			if (p1 == null)
			{
				return jsonNode;
			}
			p0 = jsonNode;
		}
		return null;
	}

	public int z0eek(XTextContainerElement p0, JsonElement p1)
	{
		p0.z0jr();
		int num = 0;
		z0ZzZzevj valueBinding = p0.ValueBinding;
		if (valueBinding != null && valueBinding.z0eek() && !valueBinding.IsEmptyBinding)
		{
			JsonElement p2 = z0eek(p1, valueBinding.DataSource);
			if (p0 is XTextTableRowElement xTextTableRowElement)
			{
				XTextTableElement xTextTableElement = xTextTableRowElement.z0gr();
				p2 = z0eek(p2, valueBinding.BindingPath);
				IList<XTextElement> list = null;
				list = new XTextElement[1] { xTextTableRowElement };
				if (p2.ValueKind == JsonValueKind.Array)
				{
					List<XTextTableRowElement> list2 = new List<XTextTableRowElement>();
					JsonElement.ArrayEnumerator arrayEnumerator = p2.EnumerateArray();
					while (arrayEnumerator.MoveNext())
					{
						JsonElement current = arrayEnumerator.Current;
						if (current.ValueKind != JsonValueKind.Object)
						{
							continue;
						}
						foreach (XTextTableRowElement item in list)
						{
							XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)item.z0lr(p0: true);
							using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement2.z0rek().z0ltk())
							{
								while (z0bpk.MoveNext())
								{
									XTextTableCellElement p3 = (XTextTableCellElement)z0bpk.Current;
									num += z0eek(p3, current);
								}
							}
							list2.Add(xTextTableRowElement2);
						}
					}
					int p4 = xTextTableElement.z0stk().IndexOf(xTextTableRowElement);
					xTextTableElement.z0stk().z0irk(p4, list.Count);
					if (list2.Count > 0)
					{
						xTextTableElement.z0stk().z0yek(p4, list2);
					}
					foreach (XTextElement item2 in list)
					{
						item2.Dispose();
					}
					list2.Clear();
				}
				else if (p2.ValueKind == JsonValueKind.Object)
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement.z0rek().z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement p5 = (XTextTableCellElement)z0bpk.Current;
						num += z0eek(p5, p2);
					}
				}
			}
			else if (p0 is XTextTableElement xTextTableElement2)
			{
				p2 = z0eek(p2, valueBinding.BindingPath);
				if (p2.ValueKind == JsonValueKind.Object)
				{
					foreach (XTextTableRowElement item3 in xTextTableElement2.z0stk().z0xrk())
					{
						num += z0eek(item3, p2);
					}
				}
			}
			else
			{
				p2 = z0eek(p2, valueBinding.BindingPath);
				if (p2.ValueKind == JsonValueKind.Object)
				{
					num += z0eek(p0.z0be(), p2);
				}
				else if (p0 is XTextInputFieldElement xTextInputFieldElement)
				{
					p2 = z0eek(p1, valueBinding.DataSource);
					string text = null;
					string text2 = null;
					if (!string.IsNullOrEmpty(valueBinding.BindingPath))
					{
						text2 = z0eek(p2, valueBinding.BindingPath).z0yek();
					}
					text = (string.IsNullOrEmpty(valueBinding.BindingPathForText) ? text2 : z0eek(p2, valueBinding.BindingPathForText).z0yek());
					xTextInputFieldElement.z0zek(text);
					xTextInputFieldElement.InnerValue = text2;
				}
				else
				{
					string p7 = z0eek(p2, valueBinding.BindingPath).z0yek();
					p0.z0zek(p7);
				}
			}
		}
		else
		{
			z0eek(p0.z0be(), p1);
		}
		return num;
	}

	private int z0eek(XTextElementList p0, JsonObject p1)
	{
		if (p0 == null || p0.Count == 0 || p1 == null)
		{
			return 0;
		}
		int num = 0;
		foreach (XTextElement item in p0.z0xrk())
		{
			if (z0rek.Contains(item))
			{
				continue;
			}
			z0rek.Add(item);
			if (item is XTextCheckBoxElementBase { ValueBinding: var valueBinding } xTextCheckBoxElementBase)
			{
				if (valueBinding == null || valueBinding.IsEmptyBinding)
				{
					continue;
				}
				XTextElementList xTextElementList = xTextCheckBoxElementBase.z0eek();
				JsonNode p2 = z0eek(p1, valueBinding.DataSource);
				p2 = z0eek(p2, valueBinding.BindingPath);
				bool flag = false;
				bool flag2 = xTextCheckBoxElementBase.Checked;
				if (!(p2 is JsonValue jsonValue))
				{
					continue;
				}
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextCheckBoxElementBase xTextCheckBoxElementBase2 = (XTextCheckBoxElementBase)z0bpk.Current;
						z0tek_jiejie20260327142557[xTextCheckBoxElementBase2] = jsonValue;
					}
				}
				string text;
				if (jsonValue.TryGetValue<bool>(out flag2))
				{
					flag = true;
				}
				else if (jsonValue.TryGetValue<string>(out text) && text != null)
				{
					if ("true".Equals(text, StringComparison.OrdinalIgnoreCase))
					{
						flag2 = true;
						flag = true;
					}
					else if ("false".Equals(text, StringComparison.OrdinalIgnoreCase))
					{
						flag2 = false;
						flag = true;
					}
				}
				if (flag && xTextElementList.Count == 1 && xTextCheckBoxElementBase.Checked != flag2)
				{
					xTextCheckBoxElementBase.Checked = flag2;
					num++;
					z0rek.Add(xTextCheckBoxElementBase);
					continue;
				}
				string text2 = p2.ToString();
				if (string.IsNullOrEmpty(text2))
				{
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							XTextCheckBoxElementBase xTextCheckBoxElementBase3 = (XTextCheckBoxElementBase)z0bpk.Current;
							if (xTextCheckBoxElementBase3.Checked)
							{
								xTextCheckBoxElementBase3.Checked = false;
								num++;
							}
						}
					}
					continue;
				}
				string[] array = text2.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase4 = (XTextCheckBoxElementBase)z0bpk.Current;
					z0rek.Add(xTextCheckBoxElementBase4);
					bool flag3 = Array.IndexOf(array, xTextCheckBoxElementBase4.CheckedValue) >= 0;
					if (xTextCheckBoxElementBase.Checked != flag3)
					{
						xTextCheckBoxElementBase.Checked = flag3;
						num++;
					}
					if (!(xTextCheckBoxElementBase is XTextRadioBoxElement))
					{
						continue;
					}
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextElementList.z0ltk())
					{
						while (z0bpk2.MoveNext())
						{
							XTextCheckBoxElementBase xTextCheckBoxElementBase5 = (XTextCheckBoxElementBase)z0bpk2.Current;
							if (xTextCheckBoxElementBase5.Checked && xTextCheckBoxElementBase5 != xTextCheckBoxElementBase4)
							{
								xTextCheckBoxElementBase5.Checked = false;
								num++;
							}
						}
					}
					break;
				}
			}
			else if (item is XTextImageElement { ValueBinding: var valueBinding2 } xTextImageElement)
			{
				if (valueBinding2 == null || valueBinding2.IsEmptyBinding || !(z0eek(z0eek(p1, valueBinding2.DataSource), valueBinding2.BindingPath) is JsonValue jsonValue2))
				{
					continue;
				}
				z0tek_jiejie20260327142557[xTextImageElement] = jsonValue2;
				if (jsonValue2.TryGetValue<string>(out string text3) && text3 != null)
				{
					text3 = text3.Trim();
					if (text3.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || text3.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
					{
						xTextImageElement.z0tek(text3);
						xTextImageElement.z0rek((byte[])null);
						xTextImageElement.z0xek();
						num++;
						continue;
					}
					if (text3.StartsWith("data:image/", StringComparison.OrdinalIgnoreCase))
					{
						xTextImageElement.z0rek(z0ZzZzpmk.ParseEmitImageSource(text3));
						num++;
						continue;
					}
					try
					{
						byte[] p3 = Convert.FromBase64String(text3);
						xTextImageElement.z0rek(p3);
						num++;
					}
					catch
					{
					}
				}
				else
				{
					xTextImageElement.z0rek((byte[])null);
					num++;
				}
			}
			else if (item is XTextLabelElementBase { ValueBinding: { IsEmptyBinding: false } valueBinding3 } xTextLabelElementBase)
			{
				JsonNode p4 = z0eek(p1, valueBinding3.DataSource);
				p4 = z0eek(p4, valueBinding3.BindingPath);
				string text4 = p4?.ToString();
				z0tek_jiejie20260327142557[xTextLabelElementBase] = p4;
				if (xTextLabelElementBase.Text != text4)
				{
					xTextLabelElementBase.Text = text4;
					num++;
				}
			}
		}
		return num;
	}

	private static JsonElement z0eek(JsonElement p0, string p1)
	{
		if (p1 == null || p1.Length == 0)
		{
			return p0;
		}
		if (p0.ValueKind != JsonValueKind.Object)
		{
			return default(JsonElement);
		}
		do
		{
			int num = p1.IndexOf('.');
			string text = p1.Trim();
			if (num > 0)
			{
				text = p1.Substring(0, num).Trim();
				p1 = p1.Substring(num + 1).Trim();
			}
			else
			{
				p1 = null;
			}
			JsonElement.ObjectEnumerator objectEnumerator = p0.EnumerateObject();
			while (objectEnumerator.MoveNext())
			{
				JsonProperty current = objectEnumerator.Current;
				if (current.Name == text)
				{
					if (p1 == null)
					{
						return current.Value;
					}
					p0 = current.Value;
					break;
				}
			}
		}
		while (p1 != null);
		return default(JsonElement);
	}
}
