namespace DCSoft.WASM;

public class InsertDocumentArgs
{
	private bool _checkImportDocument;

	private bool _showUI = true;

	private string _fileContent;

	private string _fileFormat;

	private int _clearFormatType;

	public bool ShowUI
	{
		get
		{
			return _showUI;
		}
		set
		{
			_showUI = value;
		}
	}

	public bool CheckImportDocument
	{
		get
		{
			return _checkImportDocument;
		}
		set
		{
			_checkImportDocument = value;
		}
	}

	public string FileContent
	{
		get
		{
			return _fileContent;
		}
		set
		{
			_fileContent = value;
		}
	}

	public int ClearFormatType
	{
		get
		{
			return _clearFormatType;
		}
		set
		{
			_clearFormatType = value;
		}
	}

	public string FileFormat
	{
		get
		{
			return _fileFormat;
		}
		set
		{
			_fileFormat = value;
		}
	}
}
