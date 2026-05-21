using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer;

public class CanInsertObjectEventArgs
{
	private z0ZzZzpxj z0eek;

	private string z0rek;

	private XTextContainerElement z0tek;

	private z0ZzZzbcj z0yek = (z0ZzZzbcj)255;

	private bool z0uek;

	private XTextDocument z0iek;

	private WriterDataFormats z0oek = WriterDataFormats.All;

	private z0ZzZzmvj z0pek;

	private z0ZzZzkeh z0mek;

	private bool z0nek;

	private int z0bek = -1;

	private int z0vek = -1;

	public z0ZzZzbcj AccessFlags
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

	public bool Handled
	{
		[JSInvokable]
		get
		{
			return z0nek;
		}
		[JSInvokable]
		set
		{
			z0nek = value;
		}
	}

	public bool Result
	{
		[JSInvokable]
		get
		{
			return z0uek;
		}
		[JSInvokable]
		set
		{
			z0uek = value;
		}
	}

	public int SpecifyPosition
	{
		[JSInvokable]
		get
		{
			return z0vek;
		}
		set
		{
			z0vek = value;
		}
	}

	public int Position
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

	[JsonIgnore]
	public z0ZzZzkeh DataObject
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

	public WriterDataFormats AllowDataFormats
	{
		[JSInvokable]
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	[JsonIgnore]
	public z0ZzZzpxj DocumentControler
	{
		get
		{
			return z0eek;
		}
		set
		{
			z0eek = value;
		}
	}

	[JsonIgnore]
	public XTextDocument Document
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

	public string SpecifyFormat
	{
		[JSInvokable]
		get
		{
			return z0rek;
		}
		[JSInvokable]
		set
		{
			z0rek = value;
		}
	}

	[JsonIgnore]
	public XTextContainerElement ContainerElement
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

	[JSInvokable]
	public string[] GetFormats()
	{
		if (DataObject == null)
		{
			return null;
		}
		return DataObject.z0kj();
	}

	public CanInsertObjectEventArgs(XTextDocument document)
	{
		z0iek = document;
		if (z0iek != null)
		{
			z0eek = document.z0xek();
			z0pek = document.z0xmk().z0tek();
			z0iek.z0ryk().z0tek(out z0tek, out z0bek);
		}
	}

	public object GetData(string format)
	{
		if (DataObject == null)
		{
			return null;
		}
		return DataObject.z0fj(format);
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
