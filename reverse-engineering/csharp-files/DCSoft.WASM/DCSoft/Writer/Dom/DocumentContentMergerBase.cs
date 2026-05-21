using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using zzz;

namespace DCSoft.Writer.Dom;

public abstract class DocumentContentMergerBase : IDisposable
{
	protected class z0eck : XTextElement
	{
		internal string z0rek;

		internal new string z0tek;

		internal new int z0yek;

		private new bool z0uek;

		internal new string z0iek;

		public new List<XTextElement> z0oek = new List<XTextElement>();

		internal new string z0pek;

		public static void z0eek(XTextElementList p0, bool p1)
		{
			for (int num = p0.Count - 1; num >= 0; num--)
			{
				if (p0[num] is z0eck)
				{
					z0eck z0eck = (z0eck)p0[num];
					p0.RemoveAt(num);
					if (z0eck.z0oek != null)
					{
						p0.z0yek(num, z0eck.z0oek);
						z0eck.z0eek();
					}
				}
				else if (p1 && p0[num] is XTextContainerElement)
				{
					z0eek(p0[num].z0be(), p1);
				}
			}
		}

		public override string ToString()
		{
			return "[Deleteds:" + z0oek.Count + "]";
		}

		private void z0eek()
		{
			_ = z0uek;
			z0uek = true;
			z0oek.Clear();
			z0oek = null;
		}
	}

	private class z0pgj : zzz.z0ZzZzyuk<XTextContainerElement, XTextContainerElement, z0mgj>
	{
		protected override bool z0iwk(XTextContainerElement p0, XTextContainerElement p1, XTextContainerElement p2, XTextContainerElement p3)
		{
			if (p0 == p2)
			{
				return p1 == p3;
			}
			return false;
		}
	}

	internal class z0mgj : zzz.z0ZzZzbyk<XTextElement>
	{
		public XTextContainerElement z0iek;

		private new const uint z0oek = 65536u;

		public new XTextContainerElement z0pek;

		private new float z0mek;

		private new uint[] z0nek;

		public new XTextContainerElement z0bek;

		private new DocumentContentMergerBase z0vek;

		private new const float z0cek = 0.5f;

		private new uint[] z0xek;

		private new bool z0zek;

		internal static bool z0lrk = true;

		private static int z0uek_jiejie20260327142557(XTextTableElement p0)
		{
			int num = 0;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0crk().z0ltk())
			{
				while (z0bpk.MoveNext() && ((XTextTableRowElement)z0bpk.Current).HeaderStyle)
				{
					num++;
				}
			}
			return num;
		}

		protected override int[] z0ik(IList<XTextElement> p0, IList<XTextElement> p1)
		{
			_ = z0iek is XTextTableElement;
			return null;
		}

		private long[] z0eek(IList<XTextElement> p0)
		{
			z0ZzZzuzj z0ZzZzuzj = new z0ZzZzuzj(z0ZzZzuzj.z0yhj.z0eek);
			long[] array = new long[p0.Count];
			for (int num = p0.Count - 1; num >= 0; num--)
			{
				z0ZzZzuzj.z0eek();
				p0[num].z0nw(z0ZzZzuzj);
				array[num] = z0ZzZzuzj.z0tek();
			}
			z0ZzZzuzj.z0rek();
			return array;
		}

		public override void Compare(IList<XTextElement> cs1, IList<XTextElement> cs2)
		{
			z0zek = false;
			z0mek = 0f;
			if (z0iek is XTextTableElement)
			{
				XTextTableElement p = (XTextTableElement)z0iek;
				XTextTableElement p2 = (XTextTableElement)z0bek;
				if (z0vek.z0eek(p, p2))
				{
					z0zek = true;
					z0wrk = new List<XTextElement>();
					z0ZzZznyk z0ZzZznyk = z0eek(cs1, 0, cs2, 0, cs1.Count);
					z0ZzZznyk.z0yek = 0;
					z0ZzZznyk.z0pek = 0;
				}
				else
				{
					z0tek(cs1, cs2);
				}
				return;
			}
			if (z0iek is XTextTableRowElement)
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0iek;
				XTextTableRowElement obj = (XTextTableRowElement)z0bek;
				XTextTableElement xTextTableElement = xTextTableRowElement.z0gr();
				XTextTableElement xTextTableElement2 = obj.z0gr();
				if (z0vek.z0eek(xTextTableElement, xTextTableElement2))
				{
					if (xTextTableElement == xTextTableElement2)
					{
						z0tek(cs1, cs2);
						return;
					}
					z0ZzZznyk z0ZzZznyk2 = z0eek(cs1, 0, cs2, 0, cs1.Count);
					z0ZzZznyk2.z0yek = 0;
					z0ZzZznyk2.z0pek = 0;
				}
				else
				{
					z0tek(cs1, cs2);
				}
				return;
			}
			if (z0iek is XTextInputFieldElement)
			{
				InputFieldEditStyle inputFieldEditStyle = ((XTextInputFieldElement)z0iek).z0oek();
				if (inputFieldEditStyle == InputFieldEditStyle.Date || inputFieldEditStyle == InputFieldEditStyle.DateTime || inputFieldEditStyle == InputFieldEditStyle.DateTimeWithoutSecond || inputFieldEditStyle == InputFieldEditStyle.DropdownList || inputFieldEditStyle == InputFieldEditStyle.Numeric || inputFieldEditStyle == InputFieldEditStyle.Time)
				{
					z0mek(p0: true);
					if (cs1.Count == cs2.Count + 1)
					{
						int num = -1;
						if (cs1[0] is z0eck)
						{
							num = 1;
						}
						else if (cs1[cs1.Count - 1] is z0eck)
						{
							num = 0;
						}
						if (num >= 0)
						{
							z0mek(p0: false);
							for (int i = 0; i < cs2.Count; i++)
							{
								if (!EqualValues(cs1[i + num], i + num, cs2[i], i))
								{
									z0mek(p0: true);
									break;
								}
							}
						}
					}
				}
			}
			if (z0iek != null && z0bek != null && z0iek.GetType() == z0bek.GetType() && z0iek.z0xek() > 0 && z0bek.z0xek() > 0)
			{
				int j = 0;
				XTextElementList xTextElementList = z0bek.z0be();
				int count = xTextElementList.Count;
				int num2 = 0;
				int num3 = 0;
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0iek.z0be().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextElement current = z0bpk.Current;
						if ((!(current is XTextContainerElement) && !(current is XTextObjectElement)) || current is XTextStringElement)
						{
							continue;
						}
						num2++;
						string text = current.ID;
						if (text == null || text.Length == 0)
						{
							text = null;
						}
						string text2 = z0uek_jiejie20260327142557(current);
						if (text2 == null || text2.Length == 0)
						{
							text2 = null;
						}
						if (text == null && text2 == null)
						{
							continue;
						}
						Type type = current.GetType();
						for (; j < count; j++)
						{
							XTextElement xTextElement = xTextElementList[j];
							if (!(xTextElement.GetType() == type))
							{
								continue;
							}
							if (text != null)
							{
								if (z0ZzZzafh.z0yek(text, xTextElement.ID))
								{
									num3++;
								}
								break;
							}
							if (text2 != null)
							{
								if (z0ZzZzafh.z0yek(text2, z0uek_jiejie20260327142557(xTextElement)))
								{
									num3++;
								}
								break;
							}
						}
						if (j >= count)
						{
							break;
						}
					}
				}
				if (num2 > 0)
				{
					z0mek = (float)num3 / (float)num2;
				}
			}
			z0tek(cs1, cs2);
		}

		private void z0rek(IList<XTextElement> p0, uint[] p1, Dictionary<Type, uint> p2)
		{
			for (int num = p0.Count - 1; num >= 0; num--)
			{
				XTextElement xTextElement = p0[num];
				if (xTextElement is XTextCharElement)
				{
					char charValue = ((XTextCharElement)xTextElement).CharValue;
					if (XTextCharElement.z0tek(charValue))
					{
						p1[num] = 65537u;
					}
					else
					{
						p1[num] = charValue;
					}
				}
				else if (xTextElement is XTextParagraphFlagElement)
				{
					p1[num] = 65539u;
				}
				else if (xTextElement is XTextLineBreakElement)
				{
					p1[num] = 65540u;
				}
				else if (xTextElement is XTextPageBreakElement)
				{
					p1[num] = 65541u;
				}
				else
				{
					uint num2 = 0u;
					if (!p2.TryGetValue(xTextElement.GetType(), out num2))
					{
						num2 = (uint)(p2.Count + 10);
						num2 <<= 24;
						p2[xTextElement.GetType()] = num2;
					}
					if (xTextElement is XTextContainerElement || xTextElement is XTextObjectElement)
					{
						if (xTextElement.ID != null && xTextElement.ID.Length > 0)
						{
							num2 += (uint)(Math.Abs(xTextElement.ID.GetHashCode()) & 0xFFFFFF);
						}
						string text = null;
						if (xTextElement is XTextInputFieldElement)
						{
							text = ((XTextInputFieldElement)xTextElement).Name;
						}
						else if (xTextElement is XTextCheckBoxElementBase)
						{
							text = ((XTextCheckBoxElementBase)xTextElement).Name;
						}
						if (text != null && text.Length > 0)
						{
							num2 += (uint)(Math.Abs(text.GetHashCode() + 1) & 0xFFFFFF);
						}
					}
					p1[num] = num2;
				}
			}
		}

		public override float z0uk()
		{
			if ((double)z0mek >= 0.5)
			{
				return 1f;
			}
			float result = 0f;
			if (z0wrk != null && z0wrk.Count > 0)
			{
				int num = 0;
				List<XTextElement> list = z0wrk;
				int num2 = list.Count;
				using (List<z0ZzZznyk>.Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						z0ZzZznyk current = enumerator.Current;
						if (current.z0rek())
						{
							num += current.z0iek;
							continue;
						}
						for (int num3 = current.z0iek - 1; num3 >= 0; num3--)
						{
							if (list[current.z0oek + num3] is z0eck)
							{
								num2--;
							}
						}
					}
				}
				num += z0oek();
				if (num2 > 0)
				{
					result = (float)num / (float)num2;
				}
			}
			return result;
		}

		public override bool EqualValues(XTextElement oldElement, int oldIndex, XTextElement newElement, int newIndex)
		{
			if (z0xek != null)
			{
				uint num = z0xek[oldIndex];
				uint num2 = z0nek[newIndex];
				if (num != num2)
				{
					return false;
				}
				if (num < 65636)
				{
					return true;
				}
			}
			return z0uek_jiejie20260327142557(oldElement, newElement, p2: true);
		}

		protected override bool z0yk(IList<XTextElement> p0, IList<XTextElement> p1)
		{
			if (!base.z0yk(p0, p1))
			{
				return false;
			}
			if (base.Count == 0)
			{
				return false;
			}
			bool flag = false;
			z0ZzZznyk z0ZzZznyk = base[base.Count - 1];
			if (z0ZzZznyk.z0rek() && z0ZzZznyk.z0iek == 1 && p0[z0ZzZznyk.z0pek] is XTextParagraphFlagElement)
			{
				flag = true;
			}
			int num = 0;
			int num2 = 0;
			using (List<z0ZzZznyk>.Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					z0ZzZznyk current = enumerator.Current;
					if (flag && current == z0ZzZznyk)
					{
						break;
					}
					if (current.z0rek())
					{
						num2 += current.z0iek;
						for (int i = 0; i < current.z0iek; i++)
						{
							XTextElement xTextElement = p0[current.z0pek + i];
							if (xTextElement is XTextContainerElement)
							{
								num2 += 3;
							}
							else if (xTextElement is XTextObjectElement)
							{
								num2++;
							}
							else if (xTextElement is XTextParagraphFlagElement)
							{
								num2++;
							}
						}
					}
					if (current.z0iek == 1 && (current.z0eek() || current.z0tek()) && z0zek()[current.z0oek] is XTextCheckBoxElementBase)
					{
						num++;
						num2++;
					}
				}
			}
			int num3 = base.Count;
			int num4 = (p0.Count + p1.Count) / 2;
			if (flag)
			{
				num4--;
				num3--;
			}
			if (num2 > num4)
			{
				return false;
			}
			if (num3 < 3)
			{
				return false;
			}
			int num5 = (num3 - 1 - num) * 4;
			if (num5 > num4 * 2)
			{
				return false;
			}
			if (num5 > num4 && num4 < 30)
			{
				return true;
			}
			return false;
		}

		protected override bool z0tk()
		{
			return true;
		}

		public override void z0rk(string p0)
		{
			z0vek.z0eek(p0);
		}

		protected override bool z0ek(XTextElement p0)
		{
			return p0 is z0eck;
		}

		public override void z0wk()
		{
			base.z0wk();
			z0bek = null;
			z0iek = null;
			z0vek = null;
			z0pek = null;
		}

		public void z0uek_jiejie20260327142557()
		{
			if (z0pek == null)
			{
				throw new ArgumentNullException("_TargetContainer");
			}
			z0zek = false;
			XTextDocument xTextDocument = z0pek.z0jr();
			z0pek.z0be().Clear();
			XTextElementList xTextElementList = z0iek.z0be();
			XTextElementList xTextElementList2 = z0bek.z0be();
			if (!z0xek())
			{
				Compare(xTextElementList, xTextElementList2);
			}
			if (z0zek)
			{
				XTextTableElement xTextTableElement = (XTextTableElement)z0iek;
				XTextTableElement xTextTableElement2 = (XTextTableElement)z0bek;
				XTextTableElement xTextTableElement3 = (XTextTableElement)z0pek;
				xTextTableElement3.z0stk().Clear();
				xTextTableElement3.z0srk().Clear();
				((zzz.z0ZzZzkuk<XTextElement>)xTextTableElement3.z0srk()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextTableElement2.z0srk());
				for (int i = 0; i < xTextTableElement.z0stk().Count; i++)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextTableElement.z0stk()[i];
					XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)xTextTableElement2.z0stk()[i];
					XTextTableRowElement xTextTableRowElement3 = (XTextTableRowElement)xTextTableRowElement2.z0lr(p0: false);
					xTextTableRowElement3.z0yek(xTextDocument, xTextTableElement3);
					xTextTableElement3.z0stk().z0hrk(xTextTableRowElement3);
					for (int j = 0; j < xTextTableRowElement.z0rek().Count; j++)
					{
						XTextTableCellElement p = (XTextTableCellElement)xTextTableRowElement.z0rek()[j];
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement2.z0rek()[j];
						XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextTableCellElement.z0lr(p0: false);
						xTextTableCellElement2.z0yek(xTextDocument, xTextTableRowElement3);
						z0mgj z0mgj = z0vek.z0eek(p, xTextTableCellElement);
						z0mgj.z0pek = xTextTableCellElement2;
						z0mgj.z0uek_jiejie20260327142557();
						xTextTableRowElement3.z0rek().z0hrk(xTextTableCellElement2);
					}
				}
				return;
			}
			bool flag = false;
			if (base.Count == 0)
			{
				flag = true;
			}
			else if (base.Count == 1)
			{
				z0ZzZznyk z0ZzZznyk = base[0];
				if (xTextElementList.Count == xTextElementList2.Count && z0ZzZznyk.z0rek() && z0ZzZznyk.z0oek == 0 && z0ZzZznyk.z0iek == xTextElementList.Count)
				{
					flag = true;
				}
			}
			if (z0zek)
			{
				flag = true;
			}
			if (flag)
			{
				if (xTextElementList2 == null || xTextElementList2.Count <= 0)
				{
					return;
				}
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextElement current = z0bpk.Current;
						z0vek.z0eek(current, xTextDocument, z0pek);
					}
				}
				((zzz.z0ZzZzkuk<XTextElement>)z0pek.z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2);
				for (int num = xTextElementList.Count - 1; num >= 0; num--)
				{
					XTextElement xTextElement = xTextElementList[num];
					if (!(xTextElement is z0eck))
					{
						int creatorIndex = xTextElement.z0xrk().CreatorIndex;
						int deleterIndex = xTextElement.z0xrk().DeleterIndex;
						if (creatorIndex >= 0)
						{
							xTextElementList2[num].z0xrk().CreatorIndex = creatorIndex;
						}
						if (deleterIndex >= 0)
						{
							xTextElementList2[num].z0xrk().DeleterIndex = deleterIndex;
						}
					}
				}
				int count = xTextElementList.Count;
				for (int k = 0; k < count; k++)
				{
					if (!(xTextElementList[k] is XTextContainerElement))
					{
						continue;
					}
					XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElementList[k];
					XTextContainerElement xTextContainerElement2 = (XTextContainerElement)xTextElementList2[k];
					if (xTextContainerElement == xTextContainerElement2 || xTextContainerElement.z0tyk())
					{
						continue;
					}
					XTextContainerElement xTextContainerElement3 = (XTextContainerElement)xTextContainerElement2.z0lr(p0: false);
					if (xTextContainerElement is XTextTableCellElement && xTextContainerElement2 is XTextTableCellElement)
					{
						XTextTableCellElement obj = (XTextTableCellElement)xTextContainerElement;
						XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)xTextContainerElement2;
						if (obj.z0bek() && xTextTableCellElement3.z0bek())
						{
							z0vek.z0eek(xTextContainerElement3, xTextDocument, z0pek);
							z0pek.z0be()[k] = xTextContainerElement3;
							continue;
						}
					}
					z0mgj z0mgj2 = z0vek.z0eek(xTextContainerElement, xTextContainerElement2);
					z0mgj2.z0pek = xTextContainerElement3;
					if (xTextContainerElement3.z0jr() != xTextDocument)
					{
						z0vek.z0eek(xTextContainerElement3, xTextDocument, z0pek);
					}
					z0mgj2.z0uek_jiejie20260327142557();
					z0pek.z0be()[k] = xTextContainerElement3;
				}
				return;
			}
			if (z0pek is XTextTableRowElement)
			{
				XTextTableRowElement xTextTableRowElement4 = (XTextTableRowElement)z0pek;
				for (int l = 0; l < z0iek.z0be().Count; l++)
				{
					XTextTableCellElement xTextTableCellElement4 = (XTextTableCellElement)z0iek.z0be()[l];
					XTextTableCellElement xTextTableCellElement5 = (XTextTableCellElement)z0bek.z0be()[l];
					XTextTableCellElement xTextTableCellElement6 = (XTextTableCellElement)xTextTableCellElement5.z0lr(p0: false);
					z0vek.z0eek(xTextTableCellElement6, xTextDocument, xTextTableRowElement4);
					xTextTableRowElement4.z0rek().Add(xTextTableCellElement6);
					if (!xTextTableCellElement4.z0bek())
					{
						z0mgj z0mgj3 = z0vek.z0eek(xTextTableCellElement4, xTextTableCellElement5);
						z0mgj3.z0pek = xTextTableCellElement6;
						z0mgj3.z0uek_jiejie20260327142557();
					}
				}
				return;
			}
			List<XTextElement> list = z0zek();
			foreach (XTextElement item in list)
			{
				z0vek.z0eek(item, xTextDocument, z0pek);
			}
			if (z0vek.z0rek())
			{
				for (int num2 = base.Count - 2; num2 > 0; num2--)
				{
					z0ZzZznyk z0ZzZznyk2 = base[num2];
					if (z0ZzZznyk2.z0eek() && z0ZzZznyk2.z0iek == 1 && z0ZzZznyk2.z0oek > 0 && z0ZzZznyk2.z0oek < list.Count - 1 && list[z0ZzZznyk2.z0oek] is XTextParagraphFlagElement)
					{
						XTextElement xTextElement2 = list[z0ZzZznyk2.z0oek - 1];
						XTextElement xTextElement3 = list[z0ZzZznyk2.z0oek + 1];
						if (!(xTextElement2 is XTextParagraphFlagElement) && xTextElement3 is XTextTableElement && base[num2 - 1].z0rek() && base[num2 + 1].z0rek())
						{
							list.RemoveAt(z0ZzZznyk2.z0oek);
							RemoveAt(num2);
							for (int m = num2; m < base.Count; m++)
							{
								z0ZzZznyk z0ZzZznyk3 = base[m];
								if (z0ZzZznyk3.z0oek > z0ZzZznyk2.z0oek)
								{
									z0ZzZznyk3.z0oek--;
								}
							}
						}
					}
				}
			}
			using (List<z0ZzZznyk>.Enumerator enumerator2 = GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					z0ZzZznyk current3 = enumerator2.Current;
					for (int n = 0; n < current3.z0iek; n++)
					{
						XTextElement xTextElement4 = list[n + current3.z0oek];
						xTextElement4.z0ntk();
						_ = 1;
						if (current3.z0tek())
						{
							if (!xTextElement4.z0tyk())
							{
								if (xTextElement4.z0xrk().CreatorIndex < 0)
								{
									xTextElement4.z0xrk().CreatorIndex = z0vek.z0eek();
								}
								xTextElement4.z0xrk().DeleterIndex = z0vek.z0yek();
							}
						}
						else if (current3.z0eek())
						{
							xTextElement4.z0xrk().CreatorIndex = z0vek.z0yek();
							if (!(xTextElement4 is XTextContainerElement))
							{
								continue;
							}
							z0ZzZzkxj obj2 = new z0ZzZzkxj(xTextElement4)
							{
								ExcludeCharElement = false,
								ExcludeParagraphFlag = false
							};
							int creatorIndex2 = z0vek.z0yek();
							foreach (XTextElement item2 in obj2)
							{
								item2.z0xrk().CreatorIndex = creatorIndex2;
							}
						}
						else if (current3.z0rek() && xTextElement4 is XTextContainerElement)
						{
							XTextContainerElement p2 = (XTextContainerElement)xTextElementList[current3.z0pek + n];
							XTextContainerElement xTextContainerElement4 = (XTextContainerElement)xTextElementList2[current3.z0yek + n];
							z0mgj z0mgj4 = z0vek.z0eek(p2, xTextContainerElement4);
							XTextContainerElement xTextContainerElement5 = (z0mgj4.z0pek = (XTextContainerElement)xTextContainerElement4.z0lr(p0: false));
							list[n + current3.z0oek] = xTextContainerElement5;
							z0vek.z0eek(xTextContainerElement5, xTextDocument, z0pek);
							z0mgj4.z0uek_jiejie20260327142557();
						}
					}
				}
			}
			for (int num3 = base.Count - 1; num3 >= 0; num3--)
			{
				z0ZzZznyk z0ZzZznyk4 = base[num3];
				if (!z0ZzZznyk4.z0tek())
				{
					z0ZzZznyk4.z0rek();
				}
			}
			z0pek.z0be().AddRange(list);
		}

		public override int z0qk(XTextElement p0)
		{
			if (p0 is XTextCharElement || p0 is XTextParagraphFlagElement)
			{
				return 1;
			}
			if (p0 is XTextContainerElement)
			{
				return ((XTextContainerElement)p0).z0xek();
			}
			if (p0 is XTextObjectElement)
			{
				return 1000;
			}
			return 1;
		}

		private void z0tek(IList<XTextElement> p0, IList<XTextElement> p1)
		{
			z0xek = new uint[p0.Count];
			z0nek = new uint[p1.Count];
			Dictionary<Type, uint> dictionary = new Dictionary<Type, uint>();
			z0rek(p0, z0xek, dictionary);
			z0rek(p1, z0nek, dictionary);
			dictionary.Clear();
			dictionary = null;
			base.Compare(p0, p1);
			z0xek = null;
			z0nek = null;
		}

		private byte[] z0yek(XTextElement p0, int p1, IList<XTextElement> p2)
		{
			byte[] array = new byte[p2.Count];
			for (int num = p2.Count - 1; num >= 0; num--)
			{
				array[num] = (EqualValues(p0, p1, p2[num], num) ? ((byte)1) : ((byte)0));
			}
			return array;
		}

		private bool z0uek_jiejie20260327142557(XTextTableElement p0, XTextTableElement p1, bool p2)
		{
			if (p2)
			{
				if (p0.z0drk() != p1.z0drk())
				{
					return false;
				}
				int num = z0uek_jiejie20260327142557(p0);
				int num2 = z0uek_jiejie20260327142557(p1);
				if (num > 0 && num == num2)
				{
					bool flag = true;
					for (int num3 = num - 1; num3 >= 0; num3--)
					{
						XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)p0.z0crk()[num3];
						XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)p1.z0crk()[num3];
						if (xTextTableRowElement.z0rek().Count != xTextTableRowElement2.z0rek().Count)
						{
							flag = false;
							break;
						}
						for (int i = 0; i < xTextTableRowElement.z0rek().Count; i++)
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.z0rek()[i];
							XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextTableRowElement2.z0rek()[i];
							if (!xTextTableCellElement.z0bek() && !xTextTableCellElement2.z0bek() && (double)z0vek.z0eek(xTextTableCellElement, xTextTableCellElement2).z0uk() < 0.7)
							{
								flag = false;
								break;
							}
						}
						if (!flag)
						{
							break;
						}
					}
					if (flag)
					{
						return true;
					}
				}
				if (p0.z0brk() == p1.z0brk() && p0.z0srk().Count * p0.z0stk().Count > 4 && z0vek.z0eek(p0, p1))
				{
					return true;
				}
			}
			return false;
		}

		protected override XTextElement z0ak(XTextElement p0, XTextElement p1)
		{
			return z0vek.z0zn(p0, p1);
		}

		public override string ToString()
		{
			if (z0pek == null)
			{
				return base.ToString();
			}
			return z0pek.ToString() + " " + base.ToString();
		}

		protected override bool z0sk(IList<XTextElement> p0, IList<XTextElement> p1, z0lhj p2)
		{
			if (p2.z0mek == 1 && p0[p2.z0zek_jiejie20260327142557 + p2.z0mek - 1] is XTextParagraphFlagElement)
			{
				return false;
			}
			return true;
		}

		protected override byte[][] z0dk(IList<XTextElement> p0, IList<XTextElement> p1, byte[] p2, ref int p3)
		{
			p3 = 0;
			int count = p0.Count;
			int count2 = p1.Count;
			if (count < 50)
			{
				return null;
			}
			Dictionary<char, char> dictionary = new Dictionary<char, char>();
			foreach (XTextElement item in p0)
			{
				if (item is XTextCharElement)
				{
					char charValue = ((XTextCharElement)item).CharValue;
					if (!dictionary.ContainsKey(charValue))
					{
						dictionary[charValue] = charValue;
					}
				}
			}
			if (dictionary.Count == 0)
			{
				return null;
			}
			if (count / dictionary.Count < 5)
			{
				return null;
			}
			byte[][] array = new byte[p0.Count][];
			for (int i = 0; i < count; i++)
			{
				array[i] = p2;
			}
			Dictionary<char, byte[]> dictionary2 = new Dictionary<char, byte[]>();
			byte[] array2 = null;
			byte[] array3 = null;
			Dictionary<Type, byte[]> dictionary3 = new Dictionary<Type, byte[]>();
			for (int j = 0; j < count; j++)
			{
				XTextElement xTextElement = p0[j];
				if (xTextElement is XTextCharElement)
				{
					char charValue2 = ((XTextCharElement)xTextElement).CharValue;
					byte[] array4 = null;
					if (!dictionary2.TryGetValue(charValue2, out array4))
					{
						p3++;
						array4 = (dictionary2[charValue2] = z0yek(xTextElement, j, p1));
					}
					array[j] = array4;
				}
				else if (xTextElement is XTextParagraphFlagElement)
				{
					if (((XTextParagraphFlagElement)xTextElement).z0vek())
					{
						if (array2 == null)
						{
							array2 = z0yek(xTextElement, j, p1);
							p3++;
						}
						array[j] = array2;
					}
					else
					{
						if (array3 == null)
						{
							array3 = z0yek(xTextElement, j, p1);
							p3++;
						}
						array[j] = array3;
					}
				}
				else if (xTextElement is XTextLineBreakElement || xTextElement is XTextPageBreakElement)
				{
					byte[] array6 = null;
					if (!dictionary3.TryGetValue(xTextElement.GetType(), out array6))
					{
						array6 = z0yek(xTextElement, j, p1);
						p3++;
					}
					array[j] = array6;
				}
			}
			p3 *= count2;
			dictionary3.Clear();
			dictionary2.Clear();
			return array;
		}

		public z0mgj(DocumentContentMergerBase p0)
		{
			z0oek(z0lrk);
			z0vek = p0;
		}

		private string z0uek_jiejie20260327142557(XTextElement p0)
		{
			string text = null;
			if (p0 is XTextInputFieldElementBase)
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)p0;
				text = xTextInputFieldElementBase.Name;
				if (text == null || text.Length == 0)
				{
					text = xTextInputFieldElementBase.z0ht();
				}
			}
			else if (p0 is XTextCheckBoxElementBase)
			{
				text = ((XTextCheckBoxElementBase)p0).z0tek();
			}
			return text;
		}

		private bool z0uek_jiejie20260327142557(XTextElement p0, XTextElement p1, bool p2)
		{
			if (p0 is XTextCharElement && p1 is XTextCharElement)
			{
				char c = ((XTextCharElement)p0).z0bek;
				char c2 = ((XTextCharElement)p1).z0bek;
				if (c == c2)
				{
					return true;
				}
				if (XTextCharElement.z0tek(c) && XTextCharElement.z0tek(c2))
				{
					return true;
				}
				return false;
			}
			if (p0 is z0eck || p1 is z0eck)
			{
				if (p0 is z0eck && p1 is z0eck)
				{
					z0eck z0eck = (z0eck)p0;
					z0eck z0eck2 = (z0eck)p1;
					if (z0eck.z0pek == z0eck2.z0pek && z0eck.z0tek == z0eck2.z0tek && z0eck.z0oek.Count == z0eck2.z0oek.Count)
					{
						int count = z0eck.z0oek.Count;
						bool flag = true;
						for (int i = 0; i < count; i++)
						{
							XTextElement xTextElement = z0eck.z0oek[i];
							XTextElement xTextElement2 = z0eck2.z0oek[i];
							if (xTextElement.GetType() != xTextElement2.GetType())
							{
								flag = false;
								break;
							}
							if (xTextElement is XTextCharElement)
							{
								if (((XTextCharElement)xTextElement).z0mek() != ((XTextCharElement)xTextElement2).z0mek())
								{
									flag = false;
									break;
								}
							}
							else
							{
								if (xTextElement is XTextParagraphFlagElement)
								{
									continue;
								}
								if (!z0uek_jiejie20260327142557(xTextElement, xTextElement2, p2: false))
								{
									flag = false;
									break;
								}
								if (xTextElement is XTextContainerElement)
								{
									byte[] p3 = z0vek.z0xn(xTextElement);
									byte[] p4 = z0vek.z0xn(xTextElement2);
									if (!z0ZzZzeyk.z0rek(p3, p4))
									{
										flag = false;
										break;
									}
								}
							}
						}
						if (flag)
						{
							return true;
						}
					}
				}
				return false;
			}
			if (p0.GetType() == p1.GetType())
			{
				if (p0 is XTextParagraphFlagElement)
				{
					XTextParagraphFlagElement obj = (XTextParagraphFlagElement)p0;
					XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)p1;
					if (obj.z0vek() != xTextParagraphFlagElement.z0vek())
					{
						return false;
					}
				}
				if (p0 is XTextParagraphFlagElement || p0 is XTextLineBreakElement || p0 is XTextPageBreakElement)
				{
					return true;
				}
				if (p0 is XTextObjectElement)
				{
					if (!z0ZzZzafh.z0yek(p0.ID, p1.ID))
					{
						return false;
					}
					if (p0 is XTextImageElement)
					{
						XTextImageElement xTextImageElement = (XTextImageElement)p0;
						XTextImageElement xTextImageElement2 = (XTextImageElement)p1;
						if (xTextImageElement.z0frk() != null && !xTextImageElement.z0frk().z0eek(xTextImageElement2.z0frk()))
						{
							return false;
						}
						return true;
					}
					if (p0 is XTextCheckBoxElementBase)
					{
						XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)p0;
						XTextCheckBoxElementBase xTextCheckBoxElementBase2 = (XTextCheckBoxElementBase)p1;
						if (!z0ZzZzafh.z0yek(xTextCheckBoxElementBase.Caption, xTextCheckBoxElementBase2.Caption))
						{
							return false;
						}
						if (!z0ZzZzafh.z0yek(xTextCheckBoxElementBase.Name, xTextCheckBoxElementBase2.Name))
						{
							return false;
						}
						return true;
					}
					if (p0 is XTextButtonElement)
					{
						XTextButtonElement xTextButtonElement = (XTextButtonElement)p0;
						XTextButtonElement xTextButtonElement2 = (XTextButtonElement)p1;
						if (!z0ZzZzafh.z0yek(xTextButtonElement.Text, xTextButtonElement2.Text))
						{
							return false;
						}
						if ((!xTextButtonElement.AutoSize || !xTextButtonElement2.AutoSize) && Math.Abs(p0.Width - p1.Width) + Math.Abs(p0.Height - p1.Height) > 6f)
						{
							return false;
						}
						return true;
					}
					if (p0 is XTextLabelElement)
					{
						XTextLabelElement xTextLabelElement = (XTextLabelElement)p0;
						XTextLabelElement xTextLabelElement2 = (XTextLabelElement)p1;
						if (!z0ZzZzafh.z0yek(xTextLabelElement.Text, xTextLabelElement2.Text))
						{
							return false;
						}
						if ((!xTextLabelElement.AutoSize || !xTextLabelElement2.AutoSize) && Math.Abs(p0.Width - p1.Width) + Math.Abs(p0.Height - p1.Height) > 6f)
						{
							return false;
						}
						return true;
					}
					return z0vek.z0lb((XTextObjectElement)p0, (XTextObjectElement)p1, this);
				}
				if (p0 is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)p0;
					XTextContainerElement xTextContainerElement2 = (XTextContainerElement)p1;
					if (!z0ZzZzafh.z0yek(xTextContainerElement.ID, xTextContainerElement2.ID))
					{
						return false;
					}
					if (xTextContainerElement.ID != null && xTextContainerElement.ID.Length > 0)
					{
						return true;
					}
					if (!z0ZzZzafh.z0yek(xTextContainerElement.z0ht(), xTextContainerElement2.z0ht()))
					{
						return false;
					}
					if (p2 && !xTextContainerElement.z0crk() && !xTextContainerElement2.z0crk())
					{
						return true;
					}
					if (p0 is XTextTableElement)
					{
						XTextTableElement xTextTableElement = (XTextTableElement)p0;
						XTextTableElement xTextTableElement2 = (XTextTableElement)p1;
						if (p2)
						{
							if (xTextTableElement.z0drk() != xTextTableElement2.z0drk())
							{
								return false;
							}
							if (z0uek_jiejie20260327142557(xTextTableElement, xTextTableElement2, p2))
							{
								return true;
							}
							if (xTextTableElement.z0brk() == xTextTableElement2.z0brk() && xTextTableElement.z0srk().Count * xTextTableElement.z0stk().Count > 4 && z0vek.z0eek(xTextTableElement, xTextTableElement2))
							{
								return true;
							}
						}
					}
					if (xTextContainerElement is XTextInputFieldElement)
					{
						XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xTextContainerElement;
						XTextInputFieldElement xTextInputFieldElement2 = (XTextInputFieldElement)xTextContainerElement2;
						if (!z0ZzZzafh.z0yek(xTextInputFieldElement.BackgroundText, xTextInputFieldElement2.BackgroundText))
						{
							return false;
						}
						if (!z0ZzZzafh.z0yek(xTextInputFieldElement.ToolTip, xTextInputFieldElement2.ToolTip))
						{
							return false;
						}
						if (xTextInputFieldElement.BackgroundText != null && xTextInputFieldElement.BackgroundText.Length > 0)
						{
							return true;
						}
						if (!p2)
						{
							return true;
						}
						if (!xTextInputFieldElement.z0crk() && !xTextInputFieldElement2.z0crk())
						{
							return true;
						}
					}
					else
					{
						if (xTextContainerElement is XTextTableRowElement)
						{
							if (!p2)
							{
								return true;
							}
							XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextContainerElement;
							XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)xTextContainerElement2;
							int num = xTextTableRowElement.z0vek();
							if (num != xTextTableRowElement2.z0vek())
							{
								return false;
							}
							float num2 = 0f;
							for (int j = 0; j < num; j++)
							{
								XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.z0rek()[j];
								XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextTableRowElement2.z0rek()[j];
								if (xTextTableCellElement.z0bek() != xTextTableCellElement2.z0bek())
								{
									return false;
								}
								if (xTextTableCellElement.z0bek())
								{
									num2 += 1f;
									continue;
								}
								if (xTextTableCellElement.RowSpan != xTextTableCellElement2.RowSpan || xTextTableCellElement.ColSpan != xTextTableCellElement2.ColSpan)
								{
									return false;
								}
								z0mgj z0mgj = z0vek.z0eek(xTextTableCellElement, xTextTableCellElement2);
								if (!z0mgj.z0xek())
								{
									z0mgj.Compare(xTextTableCellElement.z0be(), xTextTableCellElement2.z0be());
								}
								num2 += z0mgj.z0mek();
							}
							if (num2 > 0.5f * (float)num)
							{
								return true;
							}
							return false;
						}
						if (xTextContainerElement is XTextTableCellElement)
						{
							XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)xTextContainerElement;
							XTextTableCellElement xTextTableCellElement4 = (XTextTableCellElement)xTextContainerElement2;
							if (xTextTableCellElement3.z0bek() != xTextTableCellElement4.z0bek())
							{
								return false;
							}
							if (xTextTableCellElement3.z0bek())
							{
								if (xTextTableCellElement3.z0xek() == xTextTableCellElement4.z0xek())
								{
									return true;
								}
								return false;
							}
							if (xTextTableCellElement3.z0xek() != xTextTableCellElement4.z0xek())
							{
								return false;
							}
						}
					}
					if (!p2)
					{
						return true;
					}
					z0mgj z0mgj2 = z0vek.z0eek(xTextContainerElement, xTextContainerElement2);
					if (!z0mgj2.z0xek())
					{
						z0mgj2.Compare(xTextContainerElement.z0be(), xTextContainerElement2.z0be());
					}
					if (z0mgj2.z0mek() > 0.5f)
					{
						return true;
					}
					return false;
				}
			}
			return false;
		}
	}

	private ArrayList z0uek = new ArrayList();

	private string z0iek;

	private XTextDocument z0oek;

	protected z0ZzZzyhh z0pek;

	private bool z0mek;

	private StringBuilder z0nek;

	private int z0bek = -2147483648;

	private XTextDocument z0vek;

	private z0pgj z0cek = new z0pgj();

	private XTextDocument z0xek;

	private int z0zek = -2147483648;

	private bool z0lrk;

	public string LastCompareResultMessage => z0iek;

	public XTextDocument ResultDocument
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	public void Dispose()
	{
		z0tek();
	}

	protected virtual XTextElement z0zn(XTextElement p0, XTextElement p1)
	{
		if (p0 is z0eck)
		{
			return p0;
		}
		if (p0 is XTextCheckBoxElementBase)
		{
			XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)p0;
			XTextCheckBoxElementBase xTextCheckBoxElementBase2 = (XTextCheckBoxElementBase)p1;
			if (z0pek != null && xTextCheckBoxElementBase.Checked != xTextCheckBoxElementBase2.Checked)
			{
				xTextCheckBoxElementBase2.CheckedUserHistories = xTextCheckBoxElementBase.CheckedUserHistories;
				xTextCheckBoxElementBase2.z0eek(z0pek.z0zek(), z0pek.z0yek());
				return xTextCheckBoxElementBase2;
			}
			if (xTextCheckBoxElementBase.z0hrk())
			{
				xTextCheckBoxElementBase2.CheckedUserHistories = xTextCheckBoxElementBase.CheckedUserHistories;
				return xTextCheckBoxElementBase2;
			}
		}
		z0ZzZzrzj z0ZzZzrzj = p0.z0aek();
		z0ZzZzrzj z0ZzZzrzj2 = p1.z0aek();
		if (z0ZzZzrzj.z0nrk >= 0 || z0ZzZzrzj.z0jyk >= 0)
		{
			if (z0ZzZzrzj.z0tyk != z0ZzZzrzj2.z0tyk || z0ZzZzrzj.z0wtk != z0ZzZzrzj2.z0wtk)
			{
				return p1;
			}
			return p0;
		}
		return p1;
	}

	internal abstract bool z0lb(XTextObjectElement p0, XTextObjectElement p1, z0mgj p2);

	private int z0eek()
	{
		if (z0zek == -2147483648)
		{
			z0zek = z0oek.z0syk().Count - 1;
		}
		return z0zek;
	}

	private void z0eek(XTextContainerElement p0)
	{
		XTextElementList xTextElementList = p0.z0be();
		z0eck z0eck = null;
		XTextDocument xTextDocument = p0.z0jr();
		bool[] z0wxk = xTextDocument.z0wxk;
		if (z0wxk == null)
		{
			return;
		}
		int num = z0wxk.Length;
		for (int num2 = xTextElementList.Count - 1; num2 >= 0; num2--)
		{
			XTextElement xTextElement = xTextElementList[num2];
			int num3 = xTextElement.z0pek();
			if (num3 >= 0 && num3 < num && z0wxk[num3])
			{
				if (z0eck != null)
				{
					z0eck.z0oek.Insert(0, xTextElement);
					xTextElementList.RemoveAt(num2);
				}
				else
				{
					z0mek = true;
					z0eck = new z0eck();
					StringBuilder stringBuilder = new StringBuilder();
					z0ZzZzrzj z0ZzZzrzj = xTextDocument.z0gnk().z0eek(num3);
					if (z0ZzZzrzj.z0jyk >= 0 && z0ZzZzrzj.z0jyk < xTextDocument.z0syk().Count)
					{
						z0ZzZzyhh z0ZzZzyhh = xTextDocument.z0syk()[z0ZzZzrzj.z0jyk];
						stringBuilder.Append("Deleter:" + z0ZzZzyhh.z0zek() + " " + z0ZzZzyhh.z0yek() + " " + z0ZzZzyhh.z0cek());
						z0eck.z0pek = z0ZzZzyhh.z0zek();
						z0eck.z0tek = z0ZzZzyhh.z0yek();
						z0eck.z0iek = z0ZzZzyhh.z0cek();
					}
					z0eck.z0rek = stringBuilder.ToString();
					z0eck.z0yek = stringBuilder.ToString().GetHashCode();
					z0eck.z0oek.Add(xTextElement);
					xTextElementList[num2] = z0eck;
				}
			}
			else
			{
				z0eck = null;
				if (xTextElement is XTextContainerElement)
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement;
					if (xTextContainerElement.z0crk())
					{
						z0eek(xTextContainerElement);
					}
				}
			}
		}
	}

	public void Append(XTextDocument doc, string userID, string userName, DateTime savedTime, int userLevel, string clientName)
	{
		z0nek = null;
		z0mek = false;
		z0zek = -2147483648;
		z0bek = -2147483648;
		z0pek = null;
		if (doc == null)
		{
			throw new ArgumentNullException("doc");
		}
		doc.z0aok();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = doc.z0ltk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				((XTextTableElement)z0bpk.Current).z0pek();
			}
		}
		if (userID != null && userID.Length > 0)
		{
			z0pek = new z0ZzZzyhh();
			z0pek.z0tek(userID);
			z0pek.z0uek(userName);
			z0pek.z0tek(savedTime);
			z0pek.z0eek(userLevel);
			z0pek.z0eek(clientName);
		}
		else
		{
			z0pek = new z0ZzZzyhh();
			z0pek.z0tek(userID);
			z0pek.z0uek(userName);
			z0pek.z0tek(savedTime);
			z0pek.z0eek(userLevel);
			z0pek.z0eek(clientName);
		}
		if (z0oek == null)
		{
			XTextElementList p = doc.z0be();
			doc.z0te(new XTextElementList());
			z0oek = (XTextDocument)doc.z0lr(p0: true);
			z0oek.z0te(p);
			z0oek.z0li();
			if (userID == null || userID.Length <= 0)
			{
				return;
			}
			if (z0pek != null)
			{
				z0oek.z0syk().Add(z0pek);
			}
			int creatorIndex = z0oek.z0syk().Count - 1;
			using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk2 = z0oek.z0gnk().Styles.z0ltk())
			{
				while (z0bpk2.MoveNext())
				{
					((DocumentContentStyle)z0bpk2.Current).CreatorIndex = creatorIndex;
				}
			}
			z0oek.z0xwk();
			return;
		}
		z0zek = z0oek.z0syk().Count - 1;
		z0iek = null;
		z0cek = new z0pgj();
		z0oek.z0li();
		z0oek.z0aok();
		doc.z0li();
		int tickCount = Environment.TickCount;
		z0xek = z0oek.z0kik();
		z0xek.z0xyk().z0te(z0oek.z0xyk().z0be());
		z0xek.z0bek(z0oek.z0gnk());
		z0xek.z0bek(z0oek.z0syk());
		z0xek.Comments = z0oek.Comments;
		z0oek.z0xyk().z0te(new XTextElementList());
		z0xek.z0xwk();
		z0ZzZzzok styles = z0xek.z0gnk().Styles;
		int[] array = new int[styles.Count];
		bool[] array2 = new bool[styles.Count];
		for (int i = 0; i < styles.Count; i++)
		{
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)styles[i];
			_ = documentContentStyle.CommentIndex;
			_ = 0;
			array[i] = z0oek.z0gnk().GetStyleIndex(documentContentStyle);
			array2[i] = documentContentStyle.DeleterIndex >= 0;
		}
		z0vek = doc;
		z0vek.z0xwk();
		z0ZzZzzok styles2 = z0vek.z0gnk().Styles;
		int[] array3 = new int[styles2.Count];
		int num = 0;
		if (z0vek.Comments != null && z0vek.Comments.Count > 0)
		{
			num = z0oek.Comments.Count;
			foreach (DocumentComment comment in z0vek.Comments)
			{
				comment.z0eek(comment.z0tek() + num);
				z0oek.Comments.Add(comment);
			}
		}
		for (int j = 0; j < styles2.Count; j++)
		{
			DocumentContentStyle documentContentStyle2 = (DocumentContentStyle)styles2[j];
			documentContentStyle2.CreatorIndex = -1;
			if (documentContentStyle2.CommentIndex >= 0)
			{
				documentContentStyle2.CommentIndex += num;
			}
			array3[j] = z0oek.z0gnk().GetStyleIndex(documentContentStyle2);
		}
		foreach (XTextElement item in new z0ZzZzkxj(z0vek)
		{
			ExcludeCharElement = false,
			ExcludeParagraphFlag = false
		})
		{
			if (item.z0pek() >= 0 && item.z0pek() < array3.Length)
			{
				item.z0oek(array3[item.z0pek()]);
			}
		}
		z0vek.z0bek(z0oek.z0gnk());
		z0xek.z0jnk();
		z0eek(z0xek.z0xyk());
		z0vek.z0jnk();
		z0eek(z0vek.z0xyk());
		XTextElement.z0euk = true;
		z0mgj z0mgj = z0eek(z0xek.z0xyk(), z0vek.z0xyk());
		z0mgj.z0pek = z0oek.z0xyk();
		z0mgj.z0uek_jiejie20260327142557();
		if (z0mek)
		{
			z0eck.z0eek(z0oek.z0xyk().z0be(), p1: true);
		}
		if (z0nek != null && z0nek.Length > 0)
		{
			z0ZzZzqok.z0rek.z0sh("[系统警告：" + z0nek.ToString() + "]");
			z0nek = null;
		}
		z0oek.z0li();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0vek.z0be().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current2 = z0bpk.Current;
				if (current2 != z0vek.z0xyk())
				{
					z0oek.z0be().z0jrk(current2);
				}
			}
		}
		z0oek.PageSettings = z0vek.PageSettings;
		z0oek.z0bek(z0vek.z0ipk());
		z0oek.Attributes = z0vek.Attributes;
		z0xek.z0be().Clear();
		z0xek.z0bek((DocumentContentStyleContainer)null);
		z0xek.z0bek((z0ZzZzuhh)null);
		z0xek.Comments = null;
		z0xek.Dispose();
		z0xek = null;
		z0vek = null;
		z0oek.z0xyk().z0xwk();
		z0oek.z0prk();
		int num2 = 0;
		foreach (z0mgj item2 in z0cek.z0yek())
		{
			if (item2.z0pek != null)
			{
				num2 += item2.z0vek();
			}
		}
		tickCount = Environment.TickCount - tickCount;
		z0iek = string.Format(z0ZzZziok.z0auk(), tickCount, num2);
		_ = 0;
		z0tek();
		XTextElement.z0euk = false;
	}

	public bool z0rek()
	{
		return z0lrk;
	}

	private void z0eek(XTextElementList p0)
	{
		if (p0.Count == 1 && p0[0] is XTextParagraphFlagElement)
		{
			XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)p0[0];
			if (xTextParagraphFlagElement.z0vek() || ((XTextElement)xTextParagraphFlagElement).z0pek() == -1)
			{
				p0.RemoveAt(0);
			}
		}
	}

	private void z0tek()
	{
		if (z0uek != null)
		{
			z0uek.Clear();
		}
		if (z0cek == null || z0cek.z0uek() <= 0)
		{
			return;
		}
		foreach (z0mgj item in z0cek.z0yek())
		{
			item.z0wk();
		}
		z0cek.z0iek();
	}

	private z0mgj z0eek(XTextContainerElement p0, XTextContainerElement p1)
	{
		_ = p0 is XTextTableRowElement;
		z0mgj p2 = null;
		if (!z0cek.z0eek(p0, p1, out p2))
		{
			p2 = new z0mgj(this);
			p2.z0iek = p0;
			p2.z0bek = p1;
			z0cek.z0rek(p0, p1, p2);
			z0eek(p0.z0be());
			z0eek(p1.z0be());
			p2.Compare(p0.z0be(), p1.z0be());
		}
		return p2;
	}

	private void z0eek(XTextElement p0, XTextDocument p1, XTextContainerElement p2)
	{
		p0.z0yek(p1, p2);
	}

	protected abstract byte[] z0xn(XTextElement p0);

	public void z0eek(bool p0)
	{
		z0lrk = p0;
	}

	internal void z0eek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			if (z0nek == null)
			{
				z0nek = new StringBuilder();
			}
			z0nek.AppendLine(p0);
		}
	}

	private int z0yek()
	{
		if (z0bek == -2147483648)
		{
			if (z0pek == null)
			{
				throw new NullReferenceException("this._CurrentInfo");
			}
			z0oek.z0syk().Add(z0pek);
			z0bek = z0oek.z0syk().Count - 1;
			z0oek.z0syk().z0rek();
		}
		return z0bek;
	}

	private bool z0eek(XTextTableElement p0, XTextTableElement p1)
	{
		int count = z0uek.Count;
		for (int i = 0; i < count; i += 3)
		{
			if (z0uek[i] == p0 && z0uek[i + 1] == p1)
			{
				return (bool)z0uek[i + 2];
			}
		}
		bool flag = false;
		if (p0.z0brk() == p1.z0brk() && p0.z0drk() == p1.z0drk())
		{
			flag = true;
			for (int j = 0; j < p0.z0srk().Count; j++)
			{
				XTextTableColumnElement obj = (XTextTableColumnElement)p0.z0srk()[j];
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)p1.z0srk()[j];
				if (Math.Abs(obj.Width - xTextTableColumnElement.Width) > 1f)
				{
					flag = false;
					break;
				}
			}
			for (int k = 0; k < p0.z0stk().Count && flag; k++)
			{
				if (p0.z0stk()[k] is z0eck || p1.z0stk()[k] is z0eck)
				{
					flag = false;
					break;
				}
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)p0.z0stk()[k];
				XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)p1.z0stk()[k];
				if (xTextTableRowElement.z0rek().Count != xTextTableRowElement2.z0rek().Count)
				{
					flag = false;
					break;
				}
				if (Math.Abs(xTextTableRowElement.SpecifyHeight - xTextTableRowElement2.SpecifyHeight) > 1f)
				{
					flag = false;
					break;
				}
				for (int l = 0; l < xTextTableRowElement.z0rek().Count; l++)
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextTableRowElement.z0rek()[l];
					XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextTableRowElement2.z0rek()[l];
					if (xTextTableCellElement.RowSpan != xTextTableCellElement2.RowSpan || xTextTableCellElement.ColSpan != xTextTableCellElement2.ColSpan || xTextTableCellElement.z0bek() != xTextTableCellElement2.z0bek())
					{
						flag = false;
						break;
					}
				}
			}
		}
		z0uek.Add(p0);
		z0uek.Add(p1);
		z0uek.Add(flag);
		return flag;
	}
}
