using System.IO;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzqrk : z0ZzZzphh
{
	public override z0ZzZzmhh z0bd()
	{
		return (z0ZzZzmhh)1;
	}

	public override bool z0zd(Stream p0, XTextDocument p1, z0ZzZzohh p2)
	{
		bool result = new z0ZzZzark
		{
			ThrowODTEncryptionedException = false,
			Password = "123"
		}.Load(p0, p1, p2);
		p1.z0rrk();
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.z0rek<XTextImageElement>().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextImageElement xTextImageElement = (XTextImageElement)z0bpk.Current;
			if (xTextImageElement.z0uek() != null && xTextImageElement.z0uek() is string)
			{
				string[] array = ((string)xTextImageElement.z0uek()).Split('|');
				if (array.Length == 2)
				{
					float num = z0ZzZzark.z0rek(array[0]);
					float num2 = z0ZzZzark.z0rek(array[1]);
					xTextImageElement.ZOrderStyle = ElementZOrderStyle.InFrontOfText;
					xTextImageElement.OffsetX = ((XTextElement)p1.z0pyk()).z0mrk() - ((XTextElement)xTextImageElement).z0mrk() + num;
					xTextImageElement.OffsetY = xTextImageElement.z0fuk() - p1.z0pyk().z0fuk() + num2;
					xTextImageElement.z0oe();
				}
			}
		}
		return result;
	}

	public override string z0ks()
	{
		return "ODT文件(*.odt)|*.odt";
	}

	public override string z0js()
	{
		return "odt";
	}

	public override string z0ls()
	{
		return ".odt";
	}
}
