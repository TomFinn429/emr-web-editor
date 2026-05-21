using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace System.Xml;

public sealed class XmlReaderSettings
{
	internal static readonly XmlReaderSettings s_defaultReaderSettings = new XmlReaderSettings
	{
		ReadOnly = true
	};

	private bool _useAsync;

	private XmlNameTable _nameTable;

	private XmlResolver _xmlResolver;

	private int _lineNumberOffset;

	private int _linePositionOffset;

	private ConformanceLevel _conformanceLevel;

	private bool _checkCharacters;

	private long _maxCharactersInDocument;

	private long _maxCharactersFromEntities;

	private bool _ignoreWhitespace;

	private bool _ignorePIs;

	private bool _ignoreComments;

	private DtdProcessing _dtdProcessing;

	private ValidationType _validationType;

	private XmlSchemaValidationFlags _validationFlags;

	private XmlSchemaSet _schemas;

	private bool _closeInput;

	[CompilerGenerated]
	private bool _003CIsXmlResolverSet_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CReadOnly_003Ek__BackingField;

	public XmlNameTable? NameTable
	{
		set
		{
			CheckReadOnly("NameTable");
			_nameTable = nameTable;
		}
	}

	internal bool IsXmlResolverSet
	{
		[CompilerGenerated]
		set
		{
			_003CIsXmlResolverSet_003Ek__BackingField = flag;
		}
	}

	public XmlResolver? XmlResolver
	{
		set
		{
			CheckReadOnly("XmlResolver");
			_xmlResolver = xmlResolver;
			IsXmlResolverSet = true;
		}
	}

	public int LineNumberOffset
	{
		set
		{
			CheckReadOnly("LineNumberOffset");
			_lineNumberOffset = lineNumberOffset;
		}
	}

	public int LinePositionOffset
	{
		set
		{
			CheckReadOnly("LinePositionOffset");
			_linePositionOffset = linePositionOffset;
		}
	}

	public ConformanceLevel ConformanceLevel
	{
		set
		{
			CheckReadOnly("ConformanceLevel");
			if ((uint)conformanceLevel > 2u)
			{
				ThrowArgumentOutOfRangeException("value");
			}
			_conformanceLevel = conformanceLevel;
		}
	}

	public bool CheckCharacters
	{
		set
		{
			CheckReadOnly("CheckCharacters");
			_checkCharacters = checkCharacters;
		}
	}

	public long MaxCharactersInDocument
	{
		set
		{
			CheckReadOnly("MaxCharactersInDocument");
			if (num < 0)
			{
				ThrowArgumentOutOfRangeException("value");
			}
			_maxCharactersInDocument = num;
		}
	}

	public long MaxCharactersFromEntities
	{
		set
		{
			CheckReadOnly("MaxCharactersFromEntities");
			if (num < 0)
			{
				ThrowArgumentOutOfRangeException("value");
			}
			_maxCharactersFromEntities = num;
		}
	}

	public bool IgnoreWhitespace
	{
		set
		{
			CheckReadOnly("IgnoreWhitespace");
			_ignoreWhitespace = ignoreWhitespace;
		}
	}

	public bool IgnoreProcessingInstructions
	{
		set
		{
			CheckReadOnly("IgnoreProcessingInstructions");
			_ignorePIs = ignorePIs;
		}
	}

	public bool IgnoreComments
	{
		set
		{
			CheckReadOnly("IgnoreComments");
			_ignoreComments = ignoreComments;
		}
	}

	public DtdProcessing DtdProcessing
	{
		set
		{
			CheckReadOnly("DtdProcessing");
			if ((uint)dtdProcessing > 2u)
			{
				ThrowArgumentOutOfRangeException("value");
			}
			_dtdProcessing = dtdProcessing;
		}
	}

	public ValidationType ValidationType => _validationType;

	public XmlSchemaSet Schemas => _schemas ?? (_schemas = new XmlSchemaSet());

	internal bool ReadOnly
	{
		[CompilerGenerated]
		get
		{
			return _003CReadOnly_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CReadOnly_003Ek__BackingField = flag;
		}
	}

	public XmlReaderSettings()
	{
		Initialize();
	}

	internal XmlResolver GetXmlResolver()
	{
		return _xmlResolver;
	}

	private void CheckReadOnly([CallerMemberName] string P_0 = null)
	{
		if (ReadOnly)
		{
			throw new XmlException("Xml_ReadOnlyProperty", GetType().Name + "." + P_0);
		}
	}

	private void Initialize(XmlResolver P_0 = null)
	{
		_nameTable = null;
		_xmlResolver = P_0;
		_maxCharactersFromEntities = 10000000L;
		_lineNumberOffset = 0;
		_linePositionOffset = 0;
		_checkCharacters = true;
		_conformanceLevel = ConformanceLevel.Document;
		_ignoreWhitespace = false;
		_ignorePIs = false;
		_ignoreComments = false;
		_dtdProcessing = DtdProcessing.Prohibit;
		_closeInput = false;
		_maxCharactersInDocument = 0L;
		_schemas = null;
		_validationType = ValidationType.None;
		_validationFlags = XmlSchemaValidationFlags.ProcessIdentityConstraints;
		_validationFlags |= XmlSchemaValidationFlags.AllowXmlAttributes;
		_useAsync = false;
		ReadOnly = false;
		IsXmlResolverSet = false;
	}

	[DoesNotReturn]
	[StackTraceHidden]
	private static void ThrowArgumentOutOfRangeException(string P_0)
	{
		throw new ArgumentOutOfRangeException(P_0);
	}
}
