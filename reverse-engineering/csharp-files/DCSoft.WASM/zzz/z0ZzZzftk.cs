using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using DCSystem_Drawing;

namespace zzz;

internal static class z0ZzZzftk
{
	private static XTextSignImageElement z0eek(XTextContainerElement p0)
	{
		if (p0 == null)
		{
			return null;
		}
		XTextElementList xTextElementList = p0.z0nek<XTextSignImageElement>();
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			if (z0bpk.MoveNext())
			{
				return (XTextSignImageElement)z0bpk.Current;
			}
		}
		return null;
	}

	internal static byte[] z0eek(XTextElement p0, int p1 = 2)
	{
		MemoryStream memoryStream = new MemoryStream();
		z0ZzZzdtk obj = new z0ZzZzdtk(p0.z0jr(), memoryStream, p1);
		obj.WriteStartDocument();
		obj.WriteStartInstance(p0.GetType().Name, p0);
		obj.WritePropertyValues(p0);
		obj.WriteEndInstance();
		obj.WriteEndDocument();
		obj.Close();
		byte[] array = memoryStream.ToArray();
		z0ZzZzeyk.z0eek(array, 3);
		z0ZzZzeyk.z0eek(array, (byte)132);
		return array;
	}

	public static void z0eek(XTextElement p0)
	{
		if (p0 == null || p0.z0hi().CAMode == DCCAMode.Disabled)
		{
			return;
		}
		XTextContainerElement xTextContainerElement = null;
		XTextSignImageElement xTextSignImageElement = null;
		if (p0 is XTextContainerElement)
		{
			xTextContainerElement = (XTextContainerElement)p0;
			xTextSignImageElement = z0eek(xTextContainerElement);
		}
		else
		{
			xTextSignImageElement = (XTextSignImageElement)p0;
			xTextContainerElement = xTextSignImageElement.z0yek();
		}
		if (xTextContainerElement == null || xTextSignImageElement == null)
		{
			return;
		}
		if (xTextContainerElement == null)
		{
			xTextSignImageElement.SignState = DCSignValidateState.NotDetect;
			return;
		}
		xTextSignImageElement.z0eek(xTextContainerElement.z0kek());
		if (xTextSignImageElement.DataForSelfCheck == null || xTextSignImageElement.DataForSelfCheck.Length == 0)
		{
			xTextSignImageElement.SignState = DCSignValidateState.NotDetect;
		}
		else if (!z0ZzZzeyk.z0rek(z0eek(xTextSignImageElement), xTextSignImageElement.DataForSelfCheck))
		{
			xTextSignImageElement.SignState = DCSignValidateState.Invalidate;
		}
		else
		{
			if (xTextSignImageElement.LastVerifyResult == null || xTextSignImageElement.LastVerifyResult.Length <= 10)
			{
				return;
			}
			z0ZzZzsik z0ZzZzsik2 = new z0ZzZzsik();
			z0ZzZzsik2.z0cek = 529148323;
			z0ZzZzsik2.z0tek = true;
			z0ZzZzsik2.z0rek = 2;
			z0ZzZzsik2.z0uek = 104;
			z0ZzZzsik2.z0eek(xTextSignImageElement.LastVerifyResult);
			if (z0ZzZzsik2.Count == 0)
			{
				return;
			}
			int num = (int)z0ZzZzsik2[0];
			z0ZzZzhuk z0ZzZzhuk2 = null;
			byte[] array = null;
			byte[] array2 = null;
			if (num == 1 || num == 2)
			{
				z0ZzZzhuk2 = z0eek((byte[])z0ZzZzsik2[1]);
				array = (byte[])z0ZzZzsik2[2];
				array2 = (byte[])z0ZzZzsik2[3];
				byte[] p1 = z0eek(xTextContainerElement, num);
				byte[] p2 = z0ZzZzeyk.z0eek(p1);
				if (z0ZzZzeyk.z0rek(array2, p2))
				{
					xTextSignImageElement.SignState = DCSignValidateState.ValidateBySoftOnly;
					z0ZzZzoyk z0ZzZzoyk2 = new z0ZzZzoyk(p1, null, z0ZzZzhuk2);
					z0ZzZzoyk2.z0eek(array);
					z0ZzZzoyk2.z0eek(p0: false);
					z0ZzZzoyk2.ServerIP = p0.z0hi().CAServerIP;
					z0ZzZzoyk2.ServerPort = p0.z0hi().CAServerPort;
					xTextSignImageElement.SignMessage = z0ZzZzoyk2.GetAttribute("Message");
					if (string.IsNullOrEmpty(xTextSignImageElement.SignProviderName))
					{
						if (z0rek(z0ZzZzoyk2))
						{
							xTextSignImageElement.SignState = DCSignValidateState.ValidateBySoftOnly;
						}
						else
						{
							xTextSignImageElement.SignState = DCSignValidateState.Invalidate;
						}
					}
					else
					{
						z0ZzZzpyk z0ZzZzpyk2 = z0rek(xTextSignImageElement.SignProviderName);
						if (z0ZzZzpyk2 != null)
						{
							int tickCount = Environment.TickCount;
							if (z0ZzZzpyk2.z0rek(z0ZzZzoyk2))
							{
								xTextSignImageElement.SignState = DCSignValidateState.Validate;
							}
							else
							{
								xTextSignImageElement.SignState = DCSignValidateState.Invalidate;
							}
							tickCount = Environment.TickCount - tickCount;
						}
						else
						{
							xTextSignImageElement.SignState = DCSignValidateState.ValidateBySoftOnly;
						}
					}
					if (!string.IsNullOrEmpty(z0ZzZzoyk2.z0pek()))
					{
						xTextSignImageElement.SignErrorMessage = z0ZzZzoyk2.z0pek();
					}
				}
				else
				{
					xTextSignImageElement.SignState = DCSignValidateState.Invalidate;
				}
			}
			else
			{
				xTextSignImageElement.SignState = DCSignValidateState.NotSupportFormat;
			}
		}
	}

	static z0ZzZzftk()
	{
	}

	private static bool z0eek(z0ZzZzoyk p0)
	{
		p0.z0eek((string)null);
		byte[] p1 = z0ZzZzeyk.z0eek(p0.InputContent);
		z0ZzZzeyk.z0eek(p1, -4);
		p0.z0eek(p1);
		return true;
	}

	public static bool z0eek(XTextElement p0, DCSignInputInfo p1)
	{
		if (p0 == null)
		{
			return false;
		}
		XTextSignImageElement xTextSignImageElement = null;
		XTextContainerElement xTextContainerElement = null;
		bool flag = false;
		if (p0 is XTextContainerElement)
		{
			xTextContainerElement = (XTextContainerElement)p0;
			if (p1 != null && p1.InsertSignImageAtCaret)
			{
				if (p1.ElementID != null && p1.ElementID.Length > 0)
				{
					xTextSignImageElement = xTextContainerElement.z0ki(p1.ElementID) as XTextSignImageElement;
				}
				bool flag2 = xTextSignImageElement != null;
				if (xTextSignImageElement == null)
				{
					flag = true;
					xTextSignImageElement = new XTextSignImageElement();
					xTextSignImageElement.z0bt(xTextContainerElement.z0jr());
				}
				z0eek(xTextSignImageElement, p1);
				z0eek(xTextContainerElement, xTextSignImageElement);
				if (xTextSignImageElement.Width == 0f || xTextSignImageElement.Height == 0f)
				{
					xTextSignImageElement.z0rek();
				}
				if (p1.ImageInFrontOfText && flag)
				{
					xTextSignImageElement.ZOrderStyle = ElementZOrderStyle.InFrontOfText;
				}
				if (p1.SpecifyInsertElementIndex >= 0)
				{
					int p2 = Math.Min(p1.SpecifyInsertElementIndex, xTextContainerElement.z0be().Count);
					xTextContainerElement.z0ne(p2, xTextSignImageElement);
				}
				else if (!flag2)
				{
					XTextElement xTextElement = xTextContainerElement.z0jr().z0itk();
					if (xTextElement is XTextContainerElement)
					{
						xTextElement = ((XTextContainerElement)xTextElement).z0zek();
					}
					xTextElement.z0ji().z0cek(xTextSignImageElement, xTextElement);
				}
			}
			else
			{
				xTextSignImageElement = z0eek(xTextContainerElement);
				if (xTextSignImageElement != null && (xTextSignImageElement.Width == 0f || xTextSignImageElement.Height == 0f))
				{
					xTextSignImageElement.z0rek();
				}
			}
		}
		else if (p0 is XTextSignImageElement)
		{
			xTextSignImageElement = (XTextSignImageElement)p0;
		}
		if (xTextSignImageElement == null)
		{
			return false;
		}
		z0eek(xTextSignImageElement, p1);
		if (xTextSignImageElement.Width == 0f || xTextSignImageElement.Height == 0f)
		{
			xTextSignImageElement.z0rek();
		}
		z0eek(xTextContainerElement, xTextSignImageElement);
		string text = z0rek(xTextSignImageElement.z0yek(), 2);
		if (z0eek(xTextContainerElement, xTextSignImageElement, p1.z0eek()))
		{
			z0eek(xTextSignImageElement, p1);
			xTextContainerElement.Modified = true;
			xTextContainerElement.z0jr().Modified = true;
			xTextContainerElement.z0oe();
			if (z0rek(xTextSignImageElement.z0yek(), 2) != text)
			{
				z0eek(xTextContainerElement, xTextSignImageElement, p1.z0eek());
			}
			ContentChangedEventArgs e = new ContentChangedEventArgs();
			e.Document = xTextContainerElement.z0jr();
			e.Element = xTextContainerElement;
			xTextContainerElement.z0rr(e);
			return true;
		}
		if (xTextSignImageElement != null && flag)
		{
			xTextSignImageElement.z0ji().z0ai(xTextSignImageElement);
		}
		return false;
	}

	private static bool z0eek(XTextContainerElement p0, XTextSignImageElement p1, z0ZzZzhuk p2)
	{
		return z0eek(p0, p1, p1.DefaultSignMode, p2);
	}

	private static string z0rek(XTextElement p0, int p1)
	{
		return Convert.ToBase64String(z0ZzZzeyk.z0eek(z0eek(p0, p1)));
	}

	private static z0ZzZzhuk z0eek(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		byte[] array = new byte[8];
		array[0] = 212;
		array[7] = 114;
		array[4] = 208;
		array[5] = 107;
		array[1] = 227;
		array[2] = 72;
		array[6] = 24;
		array[3] = 9;
		byte[] array2 = new byte[8];
		array2[7] = 65;
		array2[2] = 72;
		array2[3] = 10;
		array2[1] = 60;
		array2[4] = 178;
		array2[0] = 187;
		array2[5] = 232;
		array2[6] = 203;
		p0 = z0ZzZzeck.z0tek(p0, array, array2);
		if (p0 == null)
		{
			return new z0ZzZzhuk();
		}
		Encoding uTF = Encoding.UTF8;
		int num = BitConverter.ToInt32(p0, 0);
		List<string> list = new List<string>();
		int num2 = 4;
		int num3 = p0.Length;
		for (int i = 0; i < num; i++)
		{
			if (num2 >= num3)
			{
				break;
			}
			int num4 = BitConverter.ToInt32(p0, num2);
			num2 += 4;
			if (num4 > 0 && num2 + num4 <= num3)
			{
				string text = uTF.GetString(p0, num2, num4);
				list.Add(text);
				num2 += num4;
			}
			else
			{
				list.Add(null);
			}
		}
		z0ZzZzhuk z0ZzZzhuk2 = new z0ZzZzhuk();
		for (int j = 0; j < list.Count; j += 2)
		{
			z0ZzZzhuk2.z0rek(list[j], list[j + 1]);
		}
		return z0ZzZzhuk2;
	}

	private static void z0eek(XTextSignImageElement p0, DCSignInputInfo p1)
	{
		if (p0 != null && p1 != null)
		{
			p0.SignProviderName = p1.ProviderName;
			p0.SignUserID = p1.UserID;
			p0.SignUserName = p1.UserName;
			p0.SignClientName = p1.ClientName;
			if (p1.Width > 0f)
			{
				p0.Width = p1.Width;
			}
			if (p1.Height > 0f)
			{
				p0.Height = p1.Height;
			}
			Color transparentColor = z0ZzZzlok.z0eek(p1.ImageTransparentColor, Color.Empty);
			p0.LoadImageDataUseTransparentColor(p1.ImageData, transparentColor);
			if (p1.ImageInFrontOfText)
			{
				p0.ZOrderStyle = ElementZOrderStyle.InFrontOfText;
			}
			p0.SignTime = p1.Time;
		}
	}

	private static bool z0rek(z0ZzZzoyk p0)
	{
		if (p0.InputContent != null)
		{
			byte[] array = z0ZzZzeyk.z0eek(p0.InputContent);
			z0ZzZzeyk.z0eek(array, -4);
			if (z0ZzZzeyk.z0rek(p0.z0nek(), array))
			{
				return true;
			}
		}
		return false;
	}

	private static bool z0eek(XTextContainerElement p0, XTextSignImageElement p1, DCCASignMode p2, z0ZzZzhuk p3)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("imgElement");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("containerElement");
		}
		DocumentSecurityOptions documentSecurityOptions = p0.z0hi();
		if (documentSecurityOptions.CAMode == DCCAMode.Disabled)
		{
			return false;
		}
		if (p2 == DCCASignMode.Default)
		{
			p2 = p1.DefaultSignMode;
		}
		z0ZzZzpyk z0ZzZzpyk2 = z0rek(p1.SignProviderName);
		if (z0ZzZzpyk2 != null)
		{
			p1.SignProviderName = z0ZzZzpyk2.z0eek();
		}
		byte[] p4 = z0eek(p1.z0yek(), 2);
		byte[] array = z0ZzZzeyk.z0eek(p4);
		if (p3 == null)
		{
			p3 = new z0ZzZzhuk();
		}
		z0ZzZzoyk z0ZzZzoyk2 = new z0ZzZzoyk(p4, null, p3);
		z0ZzZzoyk2.z0eek(p0: false);
		z0ZzZzoyk2.z0iek(p1.SignClientName);
		z0ZzZzoyk2.z0uek(p1.SignUserName);
		z0ZzZzoyk2.ResultImageData = p1.ImageData;
		z0ZzZzoyk2.z0eek(p0);
		z0ZzZzoyk2.ServerIP = documentSecurityOptions.CAServerIP;
		z0ZzZzoyk2.ServerPort = documentSecurityOptions.CAServerPort;
		z0ZzZzoyk2.ResultImageData = p1.ImageData;
		z0ZzZzoyk2.z0eek(p2);
		bool flag = false;
		if (z0ZzZzpyk2 == null)
		{
			p1.UseInnerSignProvider = true;
		}
		else
		{
			p1.UseInnerSignProvider = false;
		}
		using (null)
		{
			if (z0ZzZzpyk2 == null)
			{
				flag = z0eek(z0ZzZzoyk2);
			}
			else
			{
				flag = z0ZzZzpyk2.z0eek(z0ZzZzoyk2);
				p1.SignProviderName = z0ZzZzpyk2.z0eek();
			}
		}
		if (flag)
		{
			p1.ImageData = z0ZzZzoyk2.ResultImageData;
			p1.DataForSelfCheck = z0eek(p1);
			z0ZzZzsik z0ZzZzsik2 = new z0ZzZzsik();
			z0ZzZzsik2.z0cek = 529148323;
			z0ZzZzsik2.z0tek = true;
			z0ZzZzsik2.z0rek = 2;
			z0ZzZzsik2.z0uek = 104;
			z0ZzZzsik2.Add(2);
			z0ZzZzsik2.Add(z0eek(p3));
			z0ZzZzsik2.Add(z0ZzZzoyk2.z0nek());
			z0ZzZzsik2.Add(array);
			z0ZzZzsik2.Add("袁永福到此一游");
			p1.LastVerifyResult = z0ZzZzsik2.z0eek();
			if (p1.UseInnerSignProvider)
			{
				p1.SignState = DCSignValidateState.ValidateBySoftOnly;
			}
			else
			{
				p1.SignState = DCSignValidateState.Validate;
			}
			return true;
		}
		return false;
	}

	public static bool z0eek(string p0)
	{
		return false;
	}

	private static byte[] z0eek(z0ZzZzhuk p0)
	{
		MemoryStream memoryStream = new MemoryStream();
		Encoding uTF = Encoding.UTF8;
		List<string> list = new List<string>();
		foreach (z0ZzZzjuk item in p0)
		{
			list.Add(item.Name);
			list.Add(item.Value);
		}
		byte[] bytes = BitConverter.GetBytes(list.Count);
		memoryStream.Write(bytes, 0, bytes.Length);
		foreach (string item2 in list)
		{
			if (string.IsNullOrEmpty(item2))
			{
				bytes = BitConverter.GetBytes(0);
				memoryStream.Write(bytes, 0, bytes.Length);
				continue;
			}
			bytes = uTF.GetBytes(item2);
			byte[] bytes2 = BitConverter.GetBytes(bytes.Length);
			memoryStream.Write(bytes2, 0, bytes2.Length);
			memoryStream.Write(bytes, 0, bytes.Length);
		}
		bytes = memoryStream.ToArray();
		byte[] array = new byte[8];
		array[0] = 212;
		array[7] = 114;
		array[4] = 208;
		array[5] = 107;
		array[1] = 227;
		array[2] = 72;
		array[6] = 24;
		array[3] = 9;
		byte[] array2 = new byte[8];
		array2[7] = 65;
		array2[2] = 72;
		array2[3] = 10;
		array2[1] = 60;
		array2[4] = 178;
		array2[0] = 187;
		array2[5] = 232;
		array2[6] = 203;
		return z0ZzZzeck.z0rek(bytes, array, array2);
	}

	private static z0ZzZzpyk z0rek(string p0)
	{
		return z0ZzZzpyk.z0eek(p0);
	}

	private static byte[] z0eek(XTextSignImageElement p0)
	{
		if (p0 == null)
		{
			return null;
		}
		z0ZzZzsik z0ZzZzsik2 = new z0ZzZzsik();
		z0ZzZzsik2.z0tek = true;
		z0ZzZzsik2.z0rek = 4;
		z0ZzZzsik2.z0uek = 94;
		z0ZzZzsik2.z0nek = false;
		z0ZzZzsik2.z0vek = true;
		z0ZzZzsik2.Add(p0.ID);
		z0ZzZzsik2.Add(p0.ZOrderStyle);
		z0ZzZzsik2.Add(p0.OffsetX);
		z0ZzZzsik2.Add(p0.OffsetY);
		z0ZzZzsik2.Add(p0.Width);
		z0ZzZzsik2.Add(p0.Height);
		z0ZzZzsik2.Add(p0.ImageData);
		z0ZzZzsik2.Add(p0.SignUserID);
		z0ZzZzsik2.Add(p0.SignUserName);
		z0ZzZzsik2.Add(p0.SignRange);
		z0ZzZzsik2.Add(p0.SignTime);
		z0ZzZzsik2.Add(p0.UseInnerSignProvider);
		z0ZzZzsik2.Add(p0.SignProviderName);
		z0ZzZzsik2.Add(p0.SignClientName);
		if (p0.z0gek())
		{
			using zzz.z0ZzZzkuk<XAttribute>.z0bpk z0bpk = p0.Attributes.z0ltk();
			while (z0bpk.MoveNext())
			{
				XAttribute current = z0bpk.Current;
				z0ZzZzsik2.Add(current.Name);
				z0ZzZzsik2.Add(current.Value);
			}
		}
		return z0ZzZzeyk.z0eek(z0ZzZzsik2.z0eek());
	}

	public static bool z0eek(XTextElement p0, DCCASignMode p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("srcElement");
		}
		XTextContainerElement xTextContainerElement = null;
		XTextSignImageElement xTextSignImageElement = null;
		if (p0 is XTextSignImageElement)
		{
			xTextSignImageElement = (XTextSignImageElement)p0;
			xTextContainerElement = xTextSignImageElement.z0yek();
		}
		else if (p0 is XTextContainerElement)
		{
			xTextContainerElement = (XTextContainerElement)p0;
			xTextSignImageElement = z0eek(xTextContainerElement);
		}
		else
		{
			xTextContainerElement = p0.z0ji();
			xTextSignImageElement = z0eek(xTextContainerElement);
		}
		if (xTextContainerElement == null || xTextSignImageElement == null)
		{
			return false;
		}
		if (z0eek(xTextContainerElement, xTextSignImageElement, p1, null))
		{
			xTextContainerElement.z0jo();
			xTextContainerElement.Modified = true;
			xTextContainerElement.z0jr().Modified = true;
			ContentChangedEventArgs e = new ContentChangedEventArgs();
			e.Document = xTextContainerElement.z0jr();
			e.Element = xTextContainerElement;
			xTextContainerElement.z0rr(e);
			return true;
		}
		return false;
	}

	private static void z0eek(XTextContainerElement p0, XTextSignImageElement p1)
	{
		if (p0 is XTextInputFieldElement)
		{
			p1.SignRange = DCSignRange.InputField;
		}
		else if (p0 is XTextSectionElement)
		{
			p1.SignRange = DCSignRange.Section;
		}
		else if (p0 is XTextTableCellElement)
		{
			p1.SignRange = DCSignRange.TableCell;
		}
		else if (p0 is XTextTableRowElement)
		{
			p1.SignRange = DCSignRange.TableRow;
		}
		else if (p0 is XTextTableElement)
		{
			p1.SignRange = DCSignRange.Table;
		}
		else if (p0 is XTextSectionElement)
		{
			p1.SignRange = DCSignRange.Section;
		}
		else if (p0 is XTextDocument || p0 is XTextDocumentContentElement)
		{
			p1.SignRange = DCSignRange.Document;
		}
	}
}
