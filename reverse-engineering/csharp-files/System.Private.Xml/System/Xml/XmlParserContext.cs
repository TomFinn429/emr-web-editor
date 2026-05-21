using System.Text;

namespace System.Xml;

public class XmlParserContext
{
	private XmlNameTable _nt;

	private XmlNamespaceManager _nsMgr;

	private string _docTypeName = string.Empty;

	private string _pubId = string.Empty;

	private string _sysId = string.Empty;

	private string _internalSubset = string.Empty;

	private string _xmlLang = string.Empty;

	private XmlSpace _xmlSpace;

	private string _baseURI = string.Empty;

	private Encoding _encoding;

	public XmlNameTable? NameTable => _nt;

	public XmlNamespaceManager? NamespaceManager => _nsMgr;

	public string DocTypeName => _docTypeName;

	public string PublicId => _pubId;

	public string SystemId => _sysId;

	public string BaseURI => _baseURI;

	public string InternalSubset => _internalSubset;

	public string XmlLang => _xmlLang;

	public XmlSpace XmlSpace => _xmlSpace;

	public Encoding? Encoding => _encoding;

	internal bool HasDtdInfo
	{
		get
		{
			if (!(_internalSubset != string.Empty) && !(_pubId != string.Empty))
			{
				return _sysId != string.Empty;
			}
			return true;
		}
	}

	public XmlParserContext(XmlNameTable? P_0, XmlNamespaceManager? P_1, string? P_2, string? P_3, string? P_4, string? P_5, string? P_6, string? P_7, XmlSpace P_8)
		: this(P_0, P_1, P_2, P_3, P_4, P_5, P_6, P_7, P_8, null)
	{
	}

	public XmlParserContext(XmlNameTable? P_0, XmlNamespaceManager? P_1, string? P_2, string? P_3, string? P_4, string? P_5, string? P_6, string? P_7, XmlSpace P_8, Encoding? P_9)
	{
		if (P_1 != null)
		{
			if (P_0 == null)
			{
				_nt = P_1.NameTable;
			}
			else
			{
				if (P_0 != P_1.NameTable)
				{
					throw new XmlException("Xml_NotSameNametable", string.Empty);
				}
				_nt = P_0;
			}
		}
		else
		{
			_nt = P_0;
		}
		_nsMgr = P_1;
		_docTypeName = P_2 ?? string.Empty;
		_pubId = P_3 ?? string.Empty;
		_sysId = P_4 ?? string.Empty;
		_internalSubset = P_5 ?? string.Empty;
		_baseURI = P_6 ?? string.Empty;
		_xmlLang = P_7 ?? string.Empty;
		_xmlSpace = P_8;
		_encoding = P_9;
	}
}
