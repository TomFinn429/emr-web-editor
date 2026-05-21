namespace System.Xml.Schema;

internal class ContentValidator
{
	private readonly XmlSchemaContentType _contentType;

	private bool _isOpen;

	private readonly bool _isEmptiable;

	public static readonly ContentValidator Empty = new ContentValidator(XmlSchemaContentType.Empty);

	public static readonly ContentValidator TextOnly = new ContentValidator(XmlSchemaContentType.TextOnly, false, false);

	public static readonly ContentValidator Mixed = new ContentValidator(XmlSchemaContentType.Mixed);

	public static readonly ContentValidator Any = new ContentValidator(XmlSchemaContentType.Mixed, true, true);

	public XmlSchemaContentType ContentType => _contentType;

	public bool IsOpen
	{
		get
		{
			if (_contentType == XmlSchemaContentType.TextOnly || _contentType == XmlSchemaContentType.Empty)
			{
				return false;
			}
			return _isOpen;
		}
	}

	public ContentValidator(XmlSchemaContentType P_0)
	{
		_contentType = P_0;
		_isEmptiable = true;
	}

	protected ContentValidator(XmlSchemaContentType P_0, bool P_1, bool P_2)
	{
		_contentType = P_0;
		_isOpen = P_1;
		_isEmptiable = P_2;
	}
}
