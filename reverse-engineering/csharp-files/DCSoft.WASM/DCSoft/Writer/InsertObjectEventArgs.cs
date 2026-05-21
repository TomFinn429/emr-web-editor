using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer;

public class InsertObjectEventArgs
{
	private WriterDataFormats z0rek = WriterDataFormats.All;

	private z0ZzZzdbj z0tek;

	internal XTextDocument z0yek;

	private XTextElementList z0uek;

	private z0ZzZzpxj z0iek;

	private bool z0oek;

	private z0ZzZzmvj z0pek;

	private bool z0mek = true;

	private z0ZzZzzwh z0nek;

	private bool z0bek = true;

	private z0ZzZzkeh z0vek;

	private XTextDocument z0cek;

	private List<string> z0xek = new List<string>();

	private XTextElement z0zek;

	private bool z0lrk;

	private InputValueSource z0krk;

	internal XTextElementList z0jrk;

	private bool z0hrk;

	private z0ZzZzzwh z0grk;

	private bool z0frk;

	private int z0drk = -1;

	private XTextContainerElement z0srk;

	private string z0ark;

	public z0ZzZzzwh AllowedEffect
	{
		[JSInvokable]
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
		}
	}

	public z0ZzZzzwh DragEffect
	{
		[JSInvokable]
		get
		{
			return z0grk;
		}
		set
		{
			z0grk = value;
		}
	}

	public string ContainerElementName
	{
		[JSInvokable]
		get
		{
			return z0ZzZzafh.z0uek(z0srk);
		}
	}

	public string SpecifyFormat
	{
		get
		{
			return z0ark;
		}
		set
		{
			z0ark = value;
		}
	}

	[JsonIgnore]
	public z0ZzZzkeh DataObject
	{
		get
		{
			return z0vek;
		}
		set
		{
			z0vek = value;
		}
	}

	public bool AutoSelectContent
	{
		[JSInvokable]
		get
		{
			return z0lrk;
		}
		set
		{
			z0lrk = value;
		}
	}

	public InputValueSource InputSource
	{
		[JSInvokable]
		get
		{
			return z0krk;
		}
		set
		{
			z0krk = value;
		}
	}

	[JsonIgnore]
	public XTextContainerElement ContainerElement
	{
		get
		{
			return z0srk;
		}
		set
		{
			z0srk = value;
		}
	}

	[JsonIgnore]
	public z0ZzZzmvj Services
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

	[JsonIgnore]
	public z0ZzZzdbj WriterControl
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

	public bool Result
	{
		[JSInvokable]
		get
		{
			return z0mek;
		}
		[JSInvokable]
		set
		{
			z0mek = value;
		}
	}

	public bool Handled
	{
		[JSInvokable]
		get
		{
			return z0oek;
		}
		[JSInvokable]
		set
		{
			z0oek = value;
		}
	}

	[JsonIgnore]
	public XTextDocument Document
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

	public int Position
	{
		[JSInvokable]
		get
		{
			return z0drk;
		}
		set
		{
			z0drk = value;
		}
	}

	[JsonIgnore]
	public XTextElement CurrentElement
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

	[JsonIgnore]
	public XTextElementList NewElements
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

	public string ContainerElementID
	{
		[JSInvokable]
		get
		{
			return z0srk?.ID;
		}
	}

	public bool CheckMaxTextLengthForCopyPaste
	{
		[JSInvokable]
		get
		{
			return z0frk;
		}
		set
		{
			z0frk = value;
		}
	}

	public WriterDataFormats AllowDataFormats
	{
		[JSInvokable]
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	[JsonIgnore]
	public z0ZzZzpxj DocumentControler
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

	public List<string> RejectFormats
	{
		get
		{
			return z0xek;
		}
		set
		{
			z0xek = value;
		}
	}

	public bool ShowUI
	{
		[JSInvokable]
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	[JSInvokable]
	public object GetData(string format)
	{
		if (DataObject == null)
		{
			return null;
		}
		return DataObject.z0fj(format);
	}

	[SpecialName]
	[JSInvokable]
	public bool get_DetectForDragContent()
	{
		return z0hrk;
	}

	[JSInvokable]
	public string[] GetFormats()
	{
		if (DataObject == null)
		{
			return null;
		}
		return DataObject.z0kj();
	}

	public void z0eek(bool p0)
	{
		z0hrk = p0;
	}

	public InsertObjectEventArgs(XTextDocument document)
	{
		z0cek = document;
		if (z0cek != null)
		{
			z0tek = document.z0yyk();
			z0iek = document.z0xek();
			z0pek = document.z0xmk().z0tek();
			z0cek.z0ryk().z0tek(out z0srk, out z0drk);
			if (z0cek.z0yyk() != null)
			{
				z0rek = z0cek.z0yyk().AcceptDataFormats;
			}
		}
	}

	[JSInvokable]
	public bool GetDataPresent(string format)
	{
		if (DataObject == null)
		{
			return false;
		}
		return DataObject.z0jj(format);
	}
}
