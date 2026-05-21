using System;
using System.ComponentModel;
using zzz;

namespace DCSoft.Writer;

public class DocumentEditOptions : ICloneable
{
	private bool z0tek;

	private bool z0yek;

	private bool z0uek = true;

	private DocumentValueValidateMode z0iek = DocumentValueValidateMode.LostFocus;

	private bool z0oek = true;

	private bool z0pek = true;

	private bool z0mek = true;

	private bool z0nek = true;

	private bool z0bek;

	private bool z0vek = true;

	private bool z0cek = true;

	private bool z0xek;

	private static readonly string z0zek = z0ZzZziok.z0xyk();

	private string z0lrk = z0zek;

	private bool z0krk = true;

	[DefaultValue(true)]
	public bool FixSizeWhenInsertImage
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

	[DefaultValue(true)]
	public bool FixWidthWhenInsertTable
	{
		get
		{
			return z0krk;
		}
		set
		{
			z0krk = value;
		}
	}

	[DefaultValue(true)]
	public bool TabKeyToInsertTableRow
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

	[DefaultValue(true)]
	public bool CloneWithoutElementBorderStyle
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

	[DefaultValue(true)]
	public bool AutoInsertTableRowWhenMoveToNextCell
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

	[DefaultValue(false)]
	public bool CopyInTextFormatOnly
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

	[DefaultValue(true)]
	public bool KeepTableWidthWhenInsertDeleteColumn
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

	[DefaultValue(true)]
	[z0ZzZzuqh]
	public bool FixWidthWhenInsertImage
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

	[DefaultValue(true)]
	public bool TabKeyToFirstLineIndent
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

	[DefaultValue(false)]
	public bool ClearFieldValueWhenCopy
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

	public string GridLinePreviewText
	{
		get
		{
			return z0lrk;
		}
		set
		{
			z0lrk = value;
		}
	}

	[DefaultValue(DocumentValueValidateMode.LostFocus)]
	public DocumentValueValidateMode ValueValidateMode
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

	[DefaultValue(false)]
	public bool CopyWithoutInputFieldStructure
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
	public bool CloneWithoutLogicDeletedContent
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

	public DocumentEditOptions Clone()
	{
		return (DocumentEditOptions)((ICloneable)this).Clone();
	}

	public static void z0eek()
	{
	}

	private object z0rek()
	{
		return (DocumentEditOptions)MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0rek
		return this.z0rek();
	}
}
