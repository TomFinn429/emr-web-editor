using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XTextSubDocument")]
[DebuggerDisplay("SubDocument {ID}:{ PreviewString }")]
public sealed class XTextSubDocumentElement : XTextSectionElement
{
	private new bool z0tek;

	private new float z0yek;

	private new string z0uek;

	private new bool z0iek;

	private new DocumentInfo z0oek;

	private new bool z0pek = true;

	private new string z0mek;

	private new bool z0nek;

	private new int z0bek = -1;

	private new bool z0vek;

	private new bool z0cek;

	[NonSerialized]
	internal new XTextDocument z0xek;

	private new string z0zek;

	[DefaultValue(false)]
	public bool DelayLoadWhenExpand
	{
		get
		{
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	[DefaultValue(-1)]
	public int PrintedPageIndex
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	[DefaultValue(false)]
	public bool ContentLoaded
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
		}
	}

	[DefaultValue(false)]
	public bool Printed
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	[DefaultValue(0f)]
	public float PrintPositionInPage
	{
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	[DefaultValue(false)]
	public bool Locked
	{
		get
		{
			return z0cek;
		}
		set
		{
			z0cek = value;
		}
	}

	[DefaultValue(null)]
	public string FileFormat
	{
		get
		{
			return z0zek;
		}
		set
		{
			z0zek = value;
		}
	}

	[DefaultValue(true)]
	public bool ImportUserTrack
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	[DefaultValue(null)]
	public string DocumentID
	{
		get
		{
			return z0mek;
		}
		set
		{
			z0mek = value;
		}
	}

	[DefaultValue(null)]
	public DocumentInfo DocumentInfo
	{
		get
		{
			if (z0oek == null)
			{
				z0oek = new DocumentInfo();
			}
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	[DefaultValue(null)]
	public string FileName
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	public void LoadDocumentFromStream(Stream stream, string format)
	{
		try
		{
			z0eek();
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.z0ovk = this;
			xTextDocument.z0bek(z0jr().z0yyk());
			xTextDocument.z0bek(stream, format);
			xTextDocument.z0bek((z0ZzZzdbj)null);
			z0eek(xTextDocument);
		}
		finally
		{
			z0rek();
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		z0mek = null;
		z0oek = null;
		z0uek = null;
		z0xek = null;
	}

	public void LoadDocumentFromFileName(string fileName, string format)
	{
		try
		{
			z0eek();
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.z0ovk = this;
			xTextDocument.z0bek(z0jr().z0yyk());
			xTextDocument.z0xek(fileName, format);
			xTextDocument.z0bek((z0ZzZzdbj)null);
			z0eek(xTextDocument);
		}
		finally
		{
			z0rek();
		}
	}

	public void LoadDocumentFromString(string txt, string format)
	{
		try
		{
			z0eek();
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.z0ovk = this;
			xTextDocument.z0bek(z0jr().z0yyk());
			xTextDocument.z0lrk(txt, format);
			xTextDocument.z0bek((z0ZzZzdbj)null);
			z0eek(xTextDocument);
		}
		finally
		{
			z0rek();
		}
	}

	public void LoadDocumentFromBinary(byte[] bs, string format)
	{
		if (bs == null || bs.Length == 0)
		{
			throw new ArgumentNullException("bs");
		}
		MemoryStream stream = new MemoryStream(bs);
		LoadDocumentFromStream(stream, format);
	}

	internal void z0eek(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		ContentLoaded = true;
		base.Title = p0.z0zrk();
		z0oek = p0.z0ipk();
		p0.z0uyk();
		p0.z0bek((RepeatedImageValueList)null);
		XTextElementList p1 = p0.z0xyk().z0be().z0pek();
		p0.z0xyk().z0be().Clear();
		try
		{
			z0jr().z0pok();
			z0jr().z0bek(p1, ImportUserTrack, ImportUserTrack);
		}
		finally
		{
			z0jr().z0smk();
		}
		z0be().Clear();
		((zzz.z0ZzZzkuk<XTextElement>)z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)p1);
		z0iek();
		_ = 0;
		DocumentInfo = p0.z0ipk();
		Attributes = p0.Attributes;
		DocumentID = p0.ID;
		FileFormat = p0.z0ftk();
		FileName = p0.z0amk();
		Modified = false;
		z0li();
	}

	public override z0jpk z0kt_jiejie20260327142557()
	{
		if (z0vek)
		{
			z0jpk z0jpk = new z0jpk();
			if (!string.IsNullOrEmpty(base.Title))
			{
				z0jpk.z0eek(string.Format(z0ZzZziok.z0dik(), base.Title));
			}
			else if (!string.IsNullOrEmpty(FileName))
			{
				z0jpk.z0eek(string.Format(z0ZzZziok.z0dik(), FileName));
			}
			else
			{
				z0jpk.z0eek(string.Format(z0ZzZziok.z0dik(), string.Empty));
			}
			z0jpk.z0eek(Color.Black);
			return z0jpk;
		}
		return base.z0kt_jiejie20260327142557();
	}

	public bool EditorSetStateCOM(bool readOnly, string backgroundColor, string borderColor)
	{
		Color backgroundColor2 = z0ZzZzlok.z0eek(backgroundColor, Color.Transparent);
		Color borderColor2 = z0ZzZzlok.z0eek(borderColor, Color.Transparent);
		return EditorSetState(readOnly, backgroundColor2, borderColor2);
	}

	public void SaveDocumentToStream(Stream stream, string format)
	{
		try
		{
			XTextDocument xTextDocument = CreateRecordDocument();
			xTextDocument.z0bek(z0jr().z0yyk());
			xTextDocument.z0vek(stream, format);
		}
		finally
		{
			z0li();
		}
	}

	public byte[] SaveDocumentToBinary(string format)
	{
		using MemoryStream memoryStream = new MemoryStream();
		SaveDocumentToStream(memoryStream, format);
		return memoryStream.ToArray();
	}

	public void LoadDocumentFromBase64String(string base64, string format)
	{
		try
		{
			z0eek();
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.z0ovk = this;
			xTextDocument.z0bek(z0jr().z0yyk());
			xTextDocument.z0grk(base64, format);
			xTextDocument.z0bek((z0ZzZzdbj)null);
			z0eek(xTextDocument);
		}
		finally
		{
			z0rek();
		}
	}

	public string SaveDocumentToString(string format)
	{
		try
		{
			XTextDocument xTextDocument = CreateRecordDocument();
			xTextDocument.z0bek(z0jr().z0yyk());
			return xTextDocument.z0lrk(format);
		}
		finally
		{
			z0li();
		}
	}

	public byte[] SaveDocumentToCompressBinary(string format)
	{
		using MemoryStream memoryStream = new MemoryStream();
		SaveDocumentToStream(memoryStream, format);
		return z0ZzZzmuk.z0eek(memoryStream.ToArray());
	}

	public void LoadDocumentFromXmlReader(z0ZzZzcah reader, string format)
	{
		try
		{
			z0eek();
			XTextDocument xTextDocument = new XTextDocument();
			xTextDocument.z0ovk = this;
			xTextDocument.z0bek(z0jr().z0yyk());
			xTextDocument.z0bek(reader, format);
			xTextDocument.z0bek((z0ZzZzdbj)null);
			z0eek(xTextDocument);
		}
		finally
		{
			z0rek();
		}
	}

	public override void z0lt()
	{
		if (DelayLoadWhenExpand && !string.IsNullOrEmpty(FileName) && !ContentLoaded)
		{
			LoadDocumentFromFileName(FileName, FileFormat);
		}
	}

	public override string z0ge()
	{
		return "SubDocument:" + ID + " " + FileName;
	}

	private new void z0eek()
	{
		z0vek = true;
		if (z0uyk() != null)
		{
			z0jo();
			((z0ZzZzmwh)z0uyk()).z0jrk();
			z0uyk().z0fx(z0ZzZzbwh.z0uek);
		}
	}

	public XTextDocument CreateRecordDocument()
	{
		bool enablePermission = z0jr().z0vtk().SecurityOptions.EnablePermission;
		z0jr().z0vtk().SecurityOptions.EnablePermission = ((XTextContainerElement)this).z0brk();
		XTextDocument xTextDocument = z0ee_jiejie20260327142557(p0: false);
		xTextDocument.ID = DocumentID;
		z0jr().z0vtk().SecurityOptions.EnablePermission = enablePermission;
		xTextDocument.z0vtk().SecurityOptions.EnablePermission = true;
		if (z0oek != null)
		{
			xTextDocument.z0bek(z0oek.z0yek());
		}
		if (Attributes != null)
		{
			xTextDocument.Attributes = Attributes.z0eek();
		}
		xTextDocument.z0cek(z0uek);
		xTextDocument.z0rrk(FileFormat);
		return xTextDocument;
	}

	private new void z0rek()
	{
		z0vek = false;
		if (z0cu() != null)
		{
			z0jo();
		}
	}

	public bool EditorSetState(bool readOnly, Color backgroundColor, Color borderColor)
	{
		if (Locked)
		{
			return false;
		}
		base.ContentReadonly = ((!readOnly) ? ContentReadonlyState.False : ContentReadonlyState.True);
		((XTextElement)this).z0xrk().BackgroundColor = backgroundColor;
		((XTextElement)this).z0xrk().BorderColor = borderColor;
		((XTextElement)this).z0xrk().BorderWidth = 1f;
		((XTextElement)this).z0xrk().BorderStyle = DashStyle.Solid;
		((XTextElement)this).z0xrk().BorderLeft = true;
		((XTextElement)this).z0xrk().BorderTop = true;
		((XTextElement)this).z0xrk().BorderRight = true;
		((XTextElement)this).z0xrk().BorderBottom = true;
		z0jo();
		z0jr().OnSelectionChanged();
		return true;
	}

	public override string z0zr()
	{
		if (DocumentInfo != null && !string.IsNullOrEmpty(DocumentInfo.z0mek()))
		{
			return DocumentInfo.z0mek();
		}
		if (!string.IsNullOrEmpty(base.Title))
		{
			return base.Title;
		}
		if (!string.IsNullOrEmpty(FileName))
		{
			return z0ZzZzmuk.z0eek(FileName);
		}
		return ID;
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextSubDocumentElement xTextSubDocumentElement = (XTextSubDocumentElement)base.z0lr(p0);
		if (z0oek != null)
		{
			xTextSubDocumentElement.z0oek = z0oek.z0yek();
		}
		return xTextSubDocumentElement;
	}

	public void LoadDocumentFromCompressBinary(byte[] bs, string format)
	{
		if (bs == null || bs.Length == 0)
		{
			throw new ArgumentNullException("bs");
		}
		byte[] array = z0ZzZzmuk.z0rek(bs);
		if (array != null && array.Length != 0)
		{
			MemoryStream stream = new MemoryStream(array);
			LoadDocumentFromStream(stream, format);
		}
	}
}
