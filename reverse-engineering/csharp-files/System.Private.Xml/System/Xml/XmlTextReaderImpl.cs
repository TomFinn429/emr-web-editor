using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace System.Xml;

internal sealed class XmlTextReaderImpl : XmlReader, IXmlNamespaceResolver
{
	private enum ParsingFunction
	{
		ElementContent,
		NoData,
		OpenUrl,
		SwitchToInteractive,
		SwitchToInteractiveXmlDecl,
		DocumentContent,
		MoveToElementContent,
		PopElementContext,
		PopEmptyElementContext,
		ResetAttributesRootLevel,
		Error,
		Eof,
		ReaderClosed,
		EntityReference,
		InIncrementalRead,
		FragmentAttribute,
		ReportEndEntity,
		AfterResolveEntityInContent,
		AfterResolveEmptyEntityInContent,
		XmlDeclarationFragment,
		GoToEof,
		PartialTextValue,
		InReadAttributeValue,
		InReadValueChunk,
		InReadContentAsBinary,
		InReadElementContentAsBinary
	}

	private enum ParsingMode
	{
		Full,
		SkipNode,
		SkipContent
	}

	private enum EntityType
	{
		CharacterDec,
		CharacterHex,
		CharacterNamed,
		Expanded,
		Skipped,
		FakeExpanded,
		Unexpanded,
		ExpandedInAttribute
	}

	private enum EntityExpandType
	{
		All,
		OnlyGeneral,
		OnlyCharacter
	}

	private enum IncrementalReadState
	{
		Text,
		StartTag,
		PI,
		CDATA,
		Comment,
		Attributes,
		AttributeValue,
		ReadData,
		EndElement,
		End,
		ReadValueChunk_OnCachedValue,
		ReadValueChunk_OnPartialValue,
		ReadContentAsBinary_OnCachedValue,
		ReadContentAsBinary_OnPartialValue,
		ReadContentAsBinary_End
	}

	private sealed class LaterInitParam
	{
		public bool useAsync;

		public Stream inputStream;

		public byte[] inputBytes;

		public int inputByteCount;

		public Uri inputbaseUri;

		public string inputUriStr;

		public XmlResolver inputUriResolver;

		public XmlParserContext inputContext;

		public TextReader inputTextReader;

		public InitInputType initType;
	}

	private enum InitInputType
	{
		UriString,
		Stream,
		TextReader,
		Invalid
	}

	private struct ParsingState
	{
		internal char[] chars;

		internal int charPos;

		internal int charsUsed;

		internal Encoding encoding;

		internal bool appendMode;

		internal Stream stream;

		internal Decoder decoder;

		internal byte[] bytes;

		internal int bytePos;

		internal int bytesUsed;

		internal TextReader textReader;

		internal int lineNo;

		internal int lineStartPos;

		internal string baseUriStr;

		internal Uri baseUri;

		internal bool isEof;

		internal bool isStreamEof;

		internal IDtdEntityInfo entity;

		internal int entityId;

		internal bool eolNormalized;

		internal bool entityResolvedManually;

		internal int LineNo => lineNo;

		internal int LinePos => charPos - lineStartPos;

		internal void Clear()
		{
			chars = null;
			charPos = 0;
			charsUsed = 0;
			encoding = null;
			stream = null;
			decoder = null;
			bytes = null;
			bytePos = 0;
			bytesUsed = 0;
			textReader = null;
			lineNo = 1;
			lineStartPos = -1;
			baseUriStr = string.Empty;
			baseUri = null;
			isEof = false;
			isStreamEof = false;
			eolNormalized = true;
			entityResolvedManually = false;
		}

		internal void Close(bool P_0)
		{
			if (P_0)
			{
				if (stream != null)
				{
					stream.Dispose();
				}
				else
				{
					textReader?.Dispose();
				}
			}
		}
	}

	private sealed class XmlContext
	{
		internal XmlSpace xmlSpace;

		internal string xmlLang;

		internal string defaultNamespace;

		internal XmlContext previousContext;

		internal XmlContext()
		{
			xmlSpace = XmlSpace.None;
			xmlLang = string.Empty;
			defaultNamespace = string.Empty;
			previousContext = null;
		}

		internal XmlContext(XmlContext P_0)
		{
			xmlSpace = P_0.xmlSpace;
			xmlLang = P_0.xmlLang;
			defaultNamespace = P_0.defaultNamespace;
			previousContext = P_0;
		}
	}

	private sealed class NoNamespaceManager : XmlNamespaceManager
	{
		public override string DefaultNamespace => string.Empty;

		public override void PushScope()
		{
		}

		public override bool PopScope()
		{
			return false;
		}

		public override void AddNamespace(string P_0, string P_1)
		{
		}

		public override IEnumerator GetEnumerator()
		{
			return null;
		}

		public override string LookupNamespace(string P_0)
		{
			return string.Empty;
		}

		public override string LookupPrefix(string P_0)
		{
			return null;
		}
	}

	internal sealed class DtdParserProxy : IDtdParserAdapterV1, IDtdParserAdapterWithValidation, IDtdParserAdapter
	{
		private readonly XmlTextReaderImpl _reader;

		XmlNameTable IDtdParserAdapter.NameTable => _reader.DtdParserProxy_NameTable;

		IXmlNamespaceResolver IDtdParserAdapter.NamespaceResolver => _reader.DtdParserProxy_NamespaceResolver;

		Uri IDtdParserAdapter.BaseUri => _reader.DtdParserProxy_BaseUri;

		bool IDtdParserAdapter.IsEof => _reader.DtdParserProxy_IsEof;

		char[] IDtdParserAdapter.ParsingBuffer => _reader.DtdParserProxy_ParsingBuffer;

		int IDtdParserAdapter.ParsingBufferLength => _reader.DtdParserProxy_ParsingBufferLength;

		int IDtdParserAdapter.CurrentPosition
		{
			get
			{
				return _reader.DtdParserProxy_CurrentPosition;
			}
			set
			{
				_reader.DtdParserProxy_CurrentPosition = dtdParserProxy_CurrentPosition;
			}
		}

		int IDtdParserAdapter.EntityStackLength => _reader.DtdParserProxy_EntityStackLength;

		bool IDtdParserAdapter.IsEntityEolNormalized => _reader.DtdParserProxy_IsEntityEolNormalized;

		int IDtdParserAdapter.LineNo => _reader.DtdParserProxy_LineNo;

		int IDtdParserAdapter.LineStartPosition => _reader.DtdParserProxy_LineStartPosition;

		bool IDtdParserAdapterWithValidation.DtdValidation => _reader.DtdParserProxy_DtdValidation;

		IValidationEventHandling IDtdParserAdapterWithValidation.ValidationEventHandling => _reader.DtdParserProxy_ValidationEventHandling;

		bool IDtdParserAdapterV1.Normalization => _reader.DtdParserProxy_Normalization;

		bool IDtdParserAdapterV1.Namespaces => _reader.DtdParserProxy_Namespaces;

		bool IDtdParserAdapterV1.V1CompatibilityMode => _reader.DtdParserProxy_V1CompatibilityMode;

		internal DtdParserProxy(XmlTextReaderImpl P_0)
		{
			_reader = P_0;
		}

		void IDtdParserAdapter.OnNewLine(int P_0)
		{
			_reader.DtdParserProxy_OnNewLine(P_0);
		}

		int IDtdParserAdapter.ReadData()
		{
			return _reader.DtdParserProxy_ReadData();
		}

		int IDtdParserAdapter.ParseNumericCharRef(StringBuilder P_0)
		{
			return _reader.DtdParserProxy_ParseNumericCharRef(P_0);
		}

		int IDtdParserAdapter.ParseNamedCharRef(bool P_0, StringBuilder P_1)
		{
			return _reader.DtdParserProxy_ParseNamedCharRef(P_0, P_1);
		}

		void IDtdParserAdapter.ParsePI(StringBuilder P_0)
		{
			_reader.DtdParserProxy_ParsePI(P_0);
		}

		void IDtdParserAdapter.ParseComment(StringBuilder P_0)
		{
			_reader.DtdParserProxy_ParseComment(P_0);
		}

		bool IDtdParserAdapter.PushEntity(IDtdEntityInfo P_0, out int P_1)
		{
			return _reader.DtdParserProxy_PushEntity(P_0, out P_1);
		}

		bool IDtdParserAdapter.PopEntity(out IDtdEntityInfo P_0, out int P_1)
		{
			return _reader.DtdParserProxy_PopEntity(out P_0, out P_1);
		}

		bool IDtdParserAdapter.PushExternalSubset(string P_0, string P_1)
		{
			return _reader.DtdParserProxy_PushExternalSubset(P_0, P_1);
		}

		void IDtdParserAdapter.PushInternalDtd(string P_0, string P_1)
		{
			_reader.DtdParserProxy_PushInternalDtd(P_0, P_1);
		}

		[DoesNotReturn]
		void IDtdParserAdapter.Throw(Exception P_0)
		{
			_reader.DtdParserProxy_Throw(P_0);
		}

		void IDtdParserAdapter.OnSystemId(string P_0, LineInfo P_1, LineInfo P_2)
		{
			_reader.DtdParserProxy_OnSystemId(P_0, P_1, P_2);
		}

		void IDtdParserAdapter.OnPublicId(string P_0, LineInfo P_1, LineInfo P_2)
		{
			_reader.DtdParserProxy_OnPublicId(P_0, P_1, P_2);
		}
	}

	private sealed class NodeData : IComparable
	{
		private static volatile NodeData s_None;

		internal XmlNodeType type;

		internal string localName;

		internal string prefix;

		internal string ns;

		internal string nameWPrefix;

		private string _value;

		private char[] _chars;

		private int _valueStartPos;

		private int _valueLength;

		internal LineInfo lineInfo;

		internal LineInfo lineInfo2;

		internal char quoteChar;

		internal int depth;

		private bool _isEmptyOrDefault;

		internal int entityId;

		internal bool xmlContextPushed;

		internal NodeData nextAttrValueChunk;

		internal object schemaType;

		internal object typedValue;

		internal static NodeData None => s_None ?? (s_None = new NodeData());

		internal int LineNo => lineInfo.lineNo;

		internal int LinePos => lineInfo.linePos;

		internal bool IsEmptyElement
		{
			get
			{
				if (type == XmlNodeType.Element)
				{
					return _isEmptyOrDefault;
				}
				return false;
			}
			set
			{
				_isEmptyOrDefault = isEmptyOrDefault;
			}
		}

		internal bool IsDefaultAttribute
		{
			get
			{
				if (type == XmlNodeType.Attribute)
				{
					return _isEmptyOrDefault;
				}
				return false;
			}
			set
			{
				_isEmptyOrDefault = isEmptyOrDefault;
			}
		}

		internal bool ValueBuffered => _value == null;

		internal string StringValue
		{
			get
			{
				if (_value == null)
				{
					_value = new string(_chars, _valueStartPos, _valueLength);
				}
				return _value;
			}
		}

		internal NodeData()
		{
			Clear(XmlNodeType.None);
			xmlContextPushed = false;
		}

		internal void TrimSpacesInValue()
		{
			if (ValueBuffered)
			{
				StripSpaces(_chars, _valueStartPos, ref _valueLength);
			}
			else
			{
				_value = StripSpaces(_value);
			}
		}

		[MemberNotNull("_value")]
		[MemberNotNull("nameWPrefix")]
		[MemberNotNull("localName")]
		[MemberNotNull("prefix")]
		[MemberNotNull("ns")]
		internal void Clear(XmlNodeType P_0)
		{
			type = P_0;
			ClearName();
			_value = string.Empty;
			_valueStartPos = -1;
			schemaType = null;
			typedValue = null;
		}

		[MemberNotNull("localName")]
		[MemberNotNull("prefix")]
		[MemberNotNull("ns")]
		[MemberNotNull("nameWPrefix")]
		internal void ClearName()
		{
			localName = string.Empty;
			prefix = string.Empty;
			ns = string.Empty;
			nameWPrefix = string.Empty;
		}

		internal void SetLineInfo(int P_0, int P_1)
		{
			lineInfo.Set(P_0, P_1);
		}

		internal void SetLineInfo2(int P_0, int P_1)
		{
			lineInfo2.Set(P_0, P_1);
		}

		internal void SetValueNode(XmlNodeType P_0, string P_1)
		{
			type = P_0;
			ClearName();
			_value = P_1;
			_valueStartPos = -1;
		}

		internal void SetValueNode(XmlNodeType P_0, char[] P_1, int P_2, int P_3)
		{
			type = P_0;
			ClearName();
			_value = null;
			_chars = P_1;
			_valueStartPos = P_2;
			_valueLength = P_3;
		}

		internal void SetNamedNode(XmlNodeType P_0, string P_1)
		{
			SetNamedNode(P_0, P_1, string.Empty, P_1);
		}

		internal void SetNamedNode(XmlNodeType P_0, string P_1, string P_2, string P_3)
		{
			type = P_0;
			localName = P_1;
			prefix = P_2;
			nameWPrefix = P_3;
			ns = string.Empty;
			_value = string.Empty;
			_valueStartPos = -1;
		}

		internal void SetValue(string P_0)
		{
			_valueStartPos = -1;
			_value = P_0;
		}

		internal void SetValue(char[] P_0, int P_1, int P_2)
		{
			_value = null;
			_chars = P_0;
			_valueStartPos = P_1;
			_valueLength = P_2;
		}

		internal void OnBufferInvalidated()
		{
			if (_value == null)
			{
				_value = new string(_chars, _valueStartPos, _valueLength);
			}
			_valueStartPos = -1;
		}

		internal void CopyTo(int P_0, StringBuilder P_1)
		{
			if (_value == null)
			{
				P_1.Append(_chars, _valueStartPos + P_0, _valueLength - P_0);
			}
			else if (P_0 <= 0)
			{
				P_1.Append(_value);
			}
			else
			{
				P_1.Append(_value, P_0, _value.Length - P_0);
			}
		}

		internal string GetNameWPrefix(XmlNameTable P_0)
		{
			if (nameWPrefix != null)
			{
				return nameWPrefix;
			}
			return CreateNameWPrefix(P_0);
		}

		internal string CreateNameWPrefix(XmlNameTable P_0)
		{
			if (prefix.Length == 0)
			{
				nameWPrefix = localName;
			}
			else
			{
				nameWPrefix = P_0.Add(prefix + ":" + localName);
			}
			return nameWPrefix;
		}

		int IComparable.CompareTo(object P_0)
		{
			if (P_0 is NodeData nodeData)
			{
				if (Ref.Equal(localName, nodeData.localName))
				{
					if (Ref.Equal(ns, nodeData.ns))
					{
						return 0;
					}
					return string.CompareOrdinal(ns, nodeData.ns);
				}
				return string.CompareOrdinal(localName, nodeData.localName);
			}
			return 1;
		}
	}

	private sealed class DtdDefaultAttributeInfoToNodeDataComparer : IComparer<object>
	{
		private static readonly IComparer<object> s_instance = new DtdDefaultAttributeInfoToNodeDataComparer();

		internal static IComparer<object> Instance => s_instance;

		public int Compare(object P_0, object P_1)
		{
			if (P_0 == null)
			{
				if (P_1 != null)
				{
					return -1;
				}
				return 0;
			}
			if (P_1 == null)
			{
				return 1;
			}
			string localName;
			string prefix;
			if (P_0 is NodeData nodeData)
			{
				localName = nodeData.localName;
				prefix = nodeData.prefix;
			}
			else
			{
				if (!(P_0 is IDtdDefaultAttributeInfo dtdDefaultAttributeInfo))
				{
					throw new XmlException("Xml_DefaultException", string.Empty);
				}
				localName = dtdDefaultAttributeInfo.LocalName;
				prefix = dtdDefaultAttributeInfo.Prefix;
			}
			string localName2;
			string prefix2;
			if (P_1 is NodeData nodeData2)
			{
				localName2 = nodeData2.localName;
				prefix2 = nodeData2.prefix;
			}
			else
			{
				if (!(P_1 is IDtdDefaultAttributeInfo dtdDefaultAttributeInfo2))
				{
					throw new XmlException("Xml_DefaultException", string.Empty);
				}
				localName2 = dtdDefaultAttributeInfo2.LocalName;
				prefix2 = dtdDefaultAttributeInfo2.Prefix;
			}
			int num = string.Compare(localName, localName2, StringComparison.Ordinal);
			if (num != 0)
			{
				return num;
			}
			return string.Compare(prefix, prefix2, StringComparison.Ordinal);
		}
	}

	internal delegate void OnDefaultAttributeUseDelegate(IDtdDefaultAttributeInfo P_0, XmlTextReaderImpl P_1);

	private static UTF8Encoding s_utf8BomThrowing;

	private LaterInitParam _laterInitParam;

	private ParsingState _ps;

	private ParsingFunction _parsingFunction;

	private ParsingFunction _nextParsingFunction;

	private ParsingFunction _nextNextParsingFunction;

	private NodeData[] _nodes;

	private NodeData _curNode;

	private int _index;

	private int _curAttrIndex = -1;

	private int _attrCount;

	private int _attrHashtable;

	private int _attrDuplWalkCount;

	private bool _attrNeedNamespaceLookup;

	private bool _fullAttrCleanup;

	private NodeData[] _attrDuplSortingArray;

	private XmlNameTable _nameTable;

	private bool _nameTableFromSettings;

	private XmlResolver _xmlResolver;

	private readonly string _url = string.Empty;

	private bool _normalize;

	private bool _supportNamespaces = true;

	private WhitespaceHandling _whitespaceHandling;

	private DtdProcessing _dtdProcessing = DtdProcessing.Parse;

	private EntityHandling _entityHandling;

	private readonly bool _ignorePIs;

	private readonly bool _ignoreComments;

	private readonly bool _checkCharacters;

	private readonly int _lineNumberOffset;

	private readonly int _linePositionOffset;

	private readonly bool _closeInput;

	private readonly long _maxCharactersInDocument;

	private readonly long _maxCharactersFromEntities;

	private readonly bool _v1Compat;

	private XmlNamespaceManager _namespaceManager;

	private string _lastPrefix = string.Empty;

	private XmlContext _xmlContext;

	private ParsingState[] _parsingStatesStack;

	private int _parsingStatesStackTop = -1;

	private string _reportedBaseUri = string.Empty;

	private Encoding _reportedEncoding;

	private IDtdInfo _dtdInfo;

	private XmlNodeType _fragmentType = XmlNodeType.Document;

	private XmlParserContext _fragmentParserContext;

	private bool _fragment;

	private IncrementalReadDecoder _incReadDecoder;

	private IncrementalReadState _incReadState;

	private LineInfo _incReadLineInfo;

	private int _incReadDepth;

	private int _incReadLeftStartPos;

	private int _incReadLeftEndPos;

	private int _attributeValueBaseEntityId;

	private bool _emptyEntityInAttributeResolved;

	private IValidationEventHandling _validationEventHandling;

	private OnDefaultAttributeUseDelegate _onDefaultAttributeUse;

	private bool _validatingReaderCompatFlag;

	private bool _addDefaultAttributesAndNormalize;

	private readonly StringBuilder _stringBuilder;

	private bool _rootElementParsed;

	private bool _standalone;

	private int _nextEntityId = 1;

	private ParsingMode _parsingMode;

	private ReadState _readState;

	private IDtdEntityInfo _lastEntity;

	private bool _afterResetState;

	private int _documentStartBytePos;

	private int _readValueOffset;

	private long _charactersInDocument;

	private long _charactersFromEntities;

	private Dictionary<IDtdEntityInfo, IDtdEntityInfo> _currentEntities;

	private bool _disableUndeclaredEntityCheck;

	private XmlReader _outerReader;

	private bool _xmlResolverIsSet;

	private readonly string _xml;

	private readonly string _xmlNs;

	private readonly Task<(int, int, int, bool)> _parseText_dummyTask = Task.FromResult((0, 0, 0, false));

	private static UTF8Encoding UTF8BomThrowing => s_utf8BomThrowing ?? (s_utf8BomThrowing = new UTF8Encoding(true, true));

	public override XmlReaderSettings Settings
	{
		get
		{
			XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
			if (_nameTableFromSettings)
			{
				xmlReaderSettings.NameTable = _nameTable;
			}
			switch (_fragmentType)
			{
			default:
				xmlReaderSettings.ConformanceLevel = ConformanceLevel.Auto;
				break;
			case XmlNodeType.Element:
				xmlReaderSettings.ConformanceLevel = ConformanceLevel.Fragment;
				break;
			case XmlNodeType.Document:
				xmlReaderSettings.ConformanceLevel = ConformanceLevel.Document;
				break;
			}
			xmlReaderSettings.CheckCharacters = _checkCharacters;
			xmlReaderSettings.LineNumberOffset = _lineNumberOffset;
			xmlReaderSettings.LinePositionOffset = _linePositionOffset;
			xmlReaderSettings.IgnoreWhitespace = _whitespaceHandling == WhitespaceHandling.Significant;
			xmlReaderSettings.IgnoreProcessingInstructions = _ignorePIs;
			xmlReaderSettings.IgnoreComments = _ignoreComments;
			xmlReaderSettings.DtdProcessing = _dtdProcessing;
			xmlReaderSettings.MaxCharactersInDocument = _maxCharactersInDocument;
			xmlReaderSettings.MaxCharactersFromEntities = _maxCharactersFromEntities;
			xmlReaderSettings.XmlResolver = _xmlResolver;
			xmlReaderSettings.ReadOnly = true;
			return xmlReaderSettings;
		}
	}

	public override XmlNodeType NodeType => _curNode.type;

	public override string Name => _curNode.GetNameWPrefix(_nameTable);

	public override string LocalName => _curNode.localName;

	public override string NamespaceURI => _curNode.ns ?? string.Empty;

	public override string Prefix => _curNode.prefix;

	public override string Value
	{
		get
		{
			if (_parsingFunction >= ParsingFunction.PartialTextValue)
			{
				if (_parsingFunction == ParsingFunction.PartialTextValue)
				{
					FinishPartialValue();
					_parsingFunction = _nextParsingFunction;
				}
				else
				{
					FinishOtherValueIterator();
				}
			}
			return _curNode.StringValue;
		}
	}

	public override string BaseURI => _reportedBaseUri;

	public override bool IsEmptyElement => _curNode.IsEmptyElement;

	public override bool IsDefault => _curNode.IsDefaultAttribute;

	public override ReadState ReadState => _readState;

	public override XmlNameTable NameTable => _nameTable;

	public override bool CanResolveEntity => true;

	internal XmlReader OuterReader
	{
		set
		{
			_outerReader = outerReader;
		}
	}

	internal bool Namespaces
	{
		set
		{
			if (_readState != ReadState.Initial)
			{
				throw new InvalidOperationException("Xml_InvalidOperation");
			}
			_supportNamespaces = flag;
			if (flag)
			{
				if (_namespaceManager is NoNamespaceManager)
				{
					if (_fragment && _fragmentParserContext != null && _fragmentParserContext.NamespaceManager != null)
					{
						_namespaceManager = _fragmentParserContext.NamespaceManager;
					}
					else
					{
						_namespaceManager = new XmlNamespaceManager(_nameTable);
					}
				}
				_xmlContext.defaultNamespace = _namespaceManager.LookupNamespace(string.Empty);
			}
			else
			{
				if (!(_namespaceManager is NoNamespaceManager))
				{
					_namespaceManager = new NoNamespaceManager();
				}
				_xmlContext.defaultNamespace = string.Empty;
			}
		}
	}

	internal EntityHandling EntityHandling
	{
		set
		{
			if (entityHandling != EntityHandling.ExpandEntities && entityHandling != EntityHandling.ExpandCharEntities)
			{
				throw new XmlException("Xml_EntityHandling", string.Empty);
			}
			_entityHandling = entityHandling;
		}
	}

	internal XmlResolver XmlResolver
	{
		set
		{
			_xmlResolver = xmlResolver;
			_xmlResolverIsSet = true;
			_ps.baseUri = null;
			for (int i = 0; i <= _parsingStatesStackTop; i++)
			{
				_parsingStatesStack[i].baseUri = null;
			}
		}
	}

	internal XmlNameTable DtdParserProxy_NameTable => _nameTable;

	internal IXmlNamespaceResolver DtdParserProxy_NamespaceResolver => _namespaceManager;

	internal bool DtdParserProxy_DtdValidation => DtdValidation;

	internal bool DtdParserProxy_Normalization => _normalize;

	internal bool DtdParserProxy_Namespaces => _supportNamespaces;

	internal bool DtdParserProxy_V1CompatibilityMode => _v1Compat;

	internal Uri DtdParserProxy_BaseUri
	{
		get
		{
			if (_ps.baseUriStr.Length > 0 && _ps.baseUri == null && _xmlResolver != null)
			{
				_ps.baseUri = _xmlResolver.ResolveUri(null, _ps.baseUriStr);
			}
			return _ps.baseUri;
		}
	}

	internal bool DtdParserProxy_IsEof => _ps.isEof;

	internal char[] DtdParserProxy_ParsingBuffer => _ps.chars;

	internal int DtdParserProxy_ParsingBufferLength => _ps.charsUsed;

	internal int DtdParserProxy_CurrentPosition
	{
		get
		{
			return _ps.charPos;
		}
		set
		{
			_ps.charPos = charPos;
		}
	}

	internal int DtdParserProxy_EntityStackLength => _parsingStatesStackTop + 1;

	internal bool DtdParserProxy_IsEntityEolNormalized => _ps.eolNormalized;

	internal IValidationEventHandling DtdParserProxy_ValidationEventHandling => _validationEventHandling;

	internal int DtdParserProxy_LineNo => _ps.LineNo;

	internal int DtdParserProxy_LineStartPosition => _ps.lineStartPos;

	private bool IsResolverNull
	{
		get
		{
			if (_xmlResolver != null)
			{
				return !_xmlResolverIsSet;
			}
			return true;
		}
	}

	private bool InAttributeValueIterator
	{
		get
		{
			if (_attrCount > 0)
			{
				return _parsingFunction >= ParsingFunction.InReadAttributeValue;
			}
			return false;
		}
	}

	private bool DtdValidation => _validationEventHandling != null;

	private bool InEntity => _parsingStatesStackTop >= 0;

	internal override IDtdInfo DtdInfo => _dtdInfo;

	internal bool XmlValidatingReaderCompatibilityMode
	{
		set
		{
			_validatingReaderCompatFlag = flag;
			if (flag)
			{
				_nameTable.Add("http://www.w3.org/2001/XMLSchema");
				_nameTable.Add("http://www.w3.org/2001/XMLSchema-instance");
				_nameTable.Add("urn:schemas-microsoft-com:datatypes");
			}
		}
	}

	internal bool DisableUndeclaredEntityCheck
	{
		set
		{
			_disableUndeclaredEntityCheck = disableUndeclaredEntityCheck;
		}
	}

	internal XmlTextReaderImpl(XmlNameTable P_0)
	{
		_v1Compat = true;
		_outerReader = this;
		_nameTable = P_0;
		P_0.Add(string.Empty);
		_xmlResolver = null;
		_xml = P_0.Add("xml");
		_xmlNs = P_0.Add("xmlns");
		_nodes = new NodeData[8];
		_nodes[0] = new NodeData();
		_curNode = _nodes[0];
		_stringBuilder = new StringBuilder();
		_xmlContext = new XmlContext();
		_parsingFunction = ParsingFunction.SwitchToInteractiveXmlDecl;
		_nextParsingFunction = ParsingFunction.DocumentContent;
		_entityHandling = EntityHandling.ExpandCharEntities;
		_whitespaceHandling = WhitespaceHandling.All;
		_closeInput = true;
		_maxCharactersInDocument = 0L;
		_maxCharactersFromEntities = 10000000L;
		_charactersInDocument = 0L;
		_charactersFromEntities = 0L;
		_ps.lineNo = 1;
		_ps.lineStartPos = -1;
	}

	internal XmlTextReaderImpl(TextReader P_0, XmlNameTable P_1)
		: this(string.Empty, P_0, P_1)
	{
	}

	internal XmlTextReaderImpl(string P_0, TextReader P_1, XmlNameTable P_2)
		: this(P_2)
	{
		ConvertAbsoluteUnixPathToAbsoluteUri(ref P_0, null);
		_namespaceManager = new XmlNamespaceManager(P_2);
		_reportedBaseUri = P_0 ?? string.Empty;
		InitTextReaderInput(_reportedBaseUri, P_1);
		_reportedEncoding = _ps.encoding;
	}

	internal XmlTextReaderImpl(string P_0, XmlNodeType P_1, XmlParserContext P_2)
		: this((P_2 == null || P_2.NameTable == null) ? new NameTable() : P_2.NameTable)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		if (P_2 == null)
		{
			InitStringInput(string.Empty, Encoding.Unicode, P_0);
		}
		else
		{
			_reportedBaseUri = P_2.BaseURI;
			InitStringInput(P_2.BaseURI, Encoding.Unicode, P_0);
		}
		InitFragmentReader(P_1, P_2, false);
		_reportedEncoding = _ps.encoding;
	}

	internal XmlTextReaderImpl(string P_0, XmlParserContext P_1)
		: this((P_1 == null || P_1.NameTable == null) ? new NameTable() : P_1.NameTable)
	{
		InitStringInput((P_1 == null) ? string.Empty : P_1.BaseURI, Encoding.Unicode, "<?xml " + P_0 + "?>");
		InitFragmentReader(XmlNodeType.XmlDeclaration, P_1, true);
	}

	private void FinishInitUriString()
	{
		Stream stream;
		if (_laterInitParam.useAsync)
		{
			Task<object> entityAsync = _laterInitParam.inputUriResolver.GetEntityAsync(_laterInitParam.inputbaseUri, string.Empty, typeof(Stream));
			stream = (Stream)entityAsync.GetAwaiter().GetResult();
		}
		else
		{
			stream = (Stream)_laterInitParam.inputUriResolver.GetEntity(_laterInitParam.inputbaseUri, string.Empty, typeof(Stream));
		}
		if (stream == null)
		{
			throw new XmlException("Xml_CannotResolveUrl", _laterInitParam.inputUriStr);
		}
		Encoding encoding = null;
		if (_laterInitParam.inputContext != null)
		{
			encoding = _laterInitParam.inputContext.Encoding;
		}
		try
		{
			InitStreamInput(_laterInitParam.inputbaseUri, _reportedBaseUri, stream, null, 0, encoding);
			_reportedEncoding = _ps.encoding;
			if (_laterInitParam.inputContext != null && _laterInitParam.inputContext.HasDtdInfo)
			{
				ProcessDtdFromParserContext(_laterInitParam.inputContext);
			}
		}
		catch
		{
			stream.Dispose();
			throw;
		}
		_laterInitParam = null;
	}

	private void FinishInitStream()
	{
		Encoding encoding = null;
		if (_laterInitParam.inputContext != null)
		{
			encoding = _laterInitParam.inputContext.Encoding;
		}
		InitStreamInput(_laterInitParam.inputbaseUri, _reportedBaseUri, _laterInitParam.inputStream, _laterInitParam.inputBytes, _laterInitParam.inputByteCount, encoding);
		_reportedEncoding = _ps.encoding;
		if (_laterInitParam.inputContext != null && _laterInitParam.inputContext.HasDtdInfo)
		{
			ProcessDtdFromParserContext(_laterInitParam.inputContext);
		}
		_laterInitParam = null;
	}

	private void FinishInitTextReader()
	{
		InitTextReaderInput(_reportedBaseUri, _laterInitParam.inputTextReader);
		_reportedEncoding = _ps.encoding;
		if (_laterInitParam.inputContext != null && _laterInitParam.inputContext.HasDtdInfo)
		{
			ProcessDtdFromParserContext(_laterInitParam.inputContext);
		}
		_laterInitParam = null;
	}

	public override bool MoveToAttribute(string P_0)
	{
		int num = (P_0.Contains(':') ? GetIndexOfAttributeWithPrefix(P_0) : GetIndexOfAttributeWithoutPrefix(P_0));
		if (num >= 0)
		{
			if (InAttributeValueIterator)
			{
				FinishAttributeValueIterator();
			}
			_curAttrIndex = num - _index - 1;
			_curNode = _nodes[num];
			return true;
		}
		return false;
	}

	public override bool MoveToFirstAttribute()
	{
		if (_attrCount == 0)
		{
			return false;
		}
		if (InAttributeValueIterator)
		{
			FinishAttributeValueIterator();
		}
		_curAttrIndex = 0;
		_curNode = _nodes[_index + 1];
		return true;
	}

	public override bool MoveToNextAttribute()
	{
		if (_curAttrIndex + 1 < _attrCount)
		{
			if (InAttributeValueIterator)
			{
				FinishAttributeValueIterator();
			}
			_curNode = _nodes[_index + 1 + ++_curAttrIndex];
			return true;
		}
		return false;
	}

	public override bool MoveToElement()
	{
		if (InAttributeValueIterator)
		{
			FinishAttributeValueIterator();
		}
		else if (_curNode.type != XmlNodeType.Attribute)
		{
			return false;
		}
		_curAttrIndex = -1;
		_curNode = _nodes[_index];
		return true;
	}

	private void FinishInit()
	{
		switch (_laterInitParam.initType)
		{
		case InitInputType.UriString:
			FinishInitUriString();
			break;
		case InitInputType.Stream:
			FinishInitStream();
			break;
		case InitInputType.TextReader:
			FinishInitTextReader();
			break;
		}
	}

	public override bool Read()
	{
		if (_laterInitParam != null)
		{
			FinishInit();
		}
		while (true)
		{
			switch (_parsingFunction)
			{
			case ParsingFunction.ElementContent:
				return ParseElementContent();
			case ParsingFunction.DocumentContent:
				return ParseDocumentContent();
			case ParsingFunction.OpenUrl:
				OpenUrl();
				goto case ParsingFunction.SwitchToInteractiveXmlDecl;
			case ParsingFunction.SwitchToInteractive:
				_readState = ReadState.Interactive;
				_parsingFunction = _nextParsingFunction;
				break;
			case ParsingFunction.SwitchToInteractiveXmlDecl:
				_readState = ReadState.Interactive;
				_parsingFunction = _nextParsingFunction;
				if (ParseXmlDeclaration(false))
				{
					_reportedEncoding = _ps.encoding;
					return true;
				}
				_reportedEncoding = _ps.encoding;
				break;
			case ParsingFunction.ResetAttributesRootLevel:
				ResetAttributes();
				_curNode = _nodes[_index];
				_parsingFunction = ((_index == 0) ? ParsingFunction.DocumentContent : ParsingFunction.ElementContent);
				break;
			case ParsingFunction.MoveToElementContent:
				ResetAttributes();
				_index++;
				_curNode = AddNode(_index, _index);
				_parsingFunction = ParsingFunction.ElementContent;
				break;
			case ParsingFunction.PopElementContext:
				PopElementContext();
				_parsingFunction = _nextParsingFunction;
				break;
			case ParsingFunction.PopEmptyElementContext:
				_curNode = _nodes[_index];
				_curNode.IsEmptyElement = false;
				ResetAttributes();
				PopElementContext();
				_parsingFunction = _nextParsingFunction;
				break;
			case ParsingFunction.EntityReference:
				_parsingFunction = _nextParsingFunction;
				ParseEntityReference();
				return true;
			case ParsingFunction.ReportEndEntity:
				SetupEndEntityNodeInContent();
				_parsingFunction = _nextParsingFunction;
				return true;
			case ParsingFunction.AfterResolveEntityInContent:
				_curNode = AddNode(_index, _index);
				_reportedEncoding = _ps.encoding;
				_reportedBaseUri = _ps.baseUriStr;
				_parsingFunction = _nextParsingFunction;
				break;
			case ParsingFunction.AfterResolveEmptyEntityInContent:
				_curNode = AddNode(_index, _index);
				_curNode.SetValueNode(XmlNodeType.Text, string.Empty);
				_curNode.SetLineInfo(_ps.lineNo, _ps.LinePos);
				_reportedEncoding = _ps.encoding;
				_reportedBaseUri = _ps.baseUriStr;
				_parsingFunction = _nextParsingFunction;
				return true;
			case ParsingFunction.InReadAttributeValue:
				FinishAttributeValueIterator();
				_curNode = _nodes[_index];
				break;
			case ParsingFunction.InIncrementalRead:
				FinishIncrementalRead();
				return true;
			case ParsingFunction.FragmentAttribute:
				return ParseFragmentAttribute();
			case ParsingFunction.XmlDeclarationFragment:
				ParseXmlDeclarationFragment();
				_parsingFunction = ParsingFunction.GoToEof;
				return true;
			case ParsingFunction.GoToEof:
				OnEof();
				return false;
			case ParsingFunction.Error:
			case ParsingFunction.Eof:
			case ParsingFunction.ReaderClosed:
				return false;
			case ParsingFunction.NoData:
				ThrowWithoutLineInfo("Xml_MissingRoot");
				return false;
			case ParsingFunction.PartialTextValue:
				SkipPartialTextValue();
				break;
			case ParsingFunction.InReadValueChunk:
				FinishReadValueChunk();
				break;
			case ParsingFunction.InReadContentAsBinary:
				FinishReadContentAsBinary();
				break;
			case ParsingFunction.InReadElementContentAsBinary:
				FinishReadElementContentAsBinary();
				break;
			}
		}
	}

	public override void Close()
	{
		Close(_closeInput);
	}

	public override string LookupNamespace(string P_0)
	{
		if (!_supportNamespaces)
		{
			return null;
		}
		return _namespaceManager.LookupNamespace(P_0);
	}

	public override bool ReadAttributeValue()
	{
		if (_parsingFunction != ParsingFunction.InReadAttributeValue)
		{
			if (_curNode.type != XmlNodeType.Attribute)
			{
				return false;
			}
			if (_readState != ReadState.Interactive || _curAttrIndex < 0)
			{
				return false;
			}
			if (_parsingFunction == ParsingFunction.InReadValueChunk)
			{
				FinishReadValueChunk();
			}
			if (_parsingFunction == ParsingFunction.InReadContentAsBinary)
			{
				FinishReadContentAsBinary();
			}
			if (_curNode.nextAttrValueChunk == null || _entityHandling == EntityHandling.ExpandEntities)
			{
				NodeData nodeData = AddNode(_index + _attrCount + 1, _curNode.depth + 1);
				nodeData.SetValueNode(XmlNodeType.Text, _curNode.StringValue);
				nodeData.lineInfo = _curNode.lineInfo2;
				nodeData.depth = _curNode.depth + 1;
				_curNode = nodeData;
				nodeData.nextAttrValueChunk = null;
			}
			else
			{
				_curNode = _curNode.nextAttrValueChunk;
				AddNode(_index + _attrCount + 1, _index + 2);
				_nodes[_index + _attrCount + 1] = _curNode;
				_fullAttrCleanup = true;
			}
			_nextParsingFunction = _parsingFunction;
			_parsingFunction = ParsingFunction.InReadAttributeValue;
			_attributeValueBaseEntityId = _ps.entityId;
			return true;
		}
		if (_ps.entityId == _attributeValueBaseEntityId)
		{
			if (_curNode.nextAttrValueChunk != null)
			{
				_curNode = _curNode.nextAttrValueChunk;
				_nodes[_index + _attrCount + 1] = _curNode;
				return true;
			}
			return false;
		}
		return ParseAttributeValueChunk();
	}

	public override void ResolveEntity()
	{
		if (_curNode.type != XmlNodeType.EntityReference)
		{
			throw new InvalidOperationException("Xml_InvalidOperation");
		}
		if (_parsingFunction == ParsingFunction.InReadAttributeValue || _parsingFunction == ParsingFunction.FragmentAttribute)
		{
			switch (HandleGeneralEntityReference(_curNode.localName, true, true, _curNode.LinePos))
			{
			case EntityType.Expanded:
			case EntityType.ExpandedInAttribute:
				if (_ps.charsUsed - _ps.charPos == 0)
				{
					_emptyEntityInAttributeResolved = true;
				}
				break;
			case EntityType.FakeExpanded:
				_emptyEntityInAttributeResolved = true;
				break;
			default:
				throw new XmlException("Xml_InternalError", string.Empty);
			}
		}
		else
		{
			switch (HandleGeneralEntityReference(_curNode.localName, false, true, _curNode.LinePos))
			{
			case EntityType.Expanded:
			case EntityType.ExpandedInAttribute:
				_nextParsingFunction = _parsingFunction;
				if (_ps.charsUsed - _ps.charPos == 0 && !_ps.entity.IsExternal)
				{
					_parsingFunction = ParsingFunction.AfterResolveEmptyEntityInContent;
				}
				else
				{
					_parsingFunction = ParsingFunction.AfterResolveEntityInContent;
				}
				break;
			case EntityType.FakeExpanded:
				_nextParsingFunction = _parsingFunction;
				_parsingFunction = ParsingFunction.AfterResolveEmptyEntityInContent;
				break;
			default:
				throw new XmlException("Xml_InternalError", string.Empty);
			}
		}
		_ps.entityResolvedManually = true;
		_index++;
	}

	string IXmlNamespaceResolver.LookupNamespace(string P_0)
	{
		return LookupNamespace(P_0);
	}

	string IXmlNamespaceResolver.LookupPrefix(string P_0)
	{
		return LookupPrefix(P_0);
	}

	internal string LookupPrefix(string P_0)
	{
		return _namespaceManager.LookupPrefix(P_0);
	}

	internal void DtdParserProxy_OnNewLine(int P_0)
	{
		OnNewLine(P_0);
	}

	internal int DtdParserProxy_ReadData()
	{
		return ReadData();
	}

	internal int DtdParserProxy_ParseNumericCharRef(StringBuilder P_0)
	{
		EntityType entityType;
		return ParseNumericCharRef(true, P_0, out entityType);
	}

	internal int DtdParserProxy_ParseNamedCharRef(bool P_0, StringBuilder P_1)
	{
		return ParseNamedCharRef(P_0, P_1);
	}

	internal void DtdParserProxy_ParsePI(StringBuilder P_0)
	{
		if (P_0 == null)
		{
			ParsingMode parsingMode = _parsingMode;
			_parsingMode = ParsingMode.SkipNode;
			ParsePI(null);
			_parsingMode = parsingMode;
		}
		else
		{
			ParsePI(P_0);
		}
	}

	internal void DtdParserProxy_ParseComment(StringBuilder P_0)
	{
		try
		{
			if (P_0 == null)
			{
				ParsingMode parsingMode = _parsingMode;
				_parsingMode = ParsingMode.SkipNode;
				ParseCDataOrComment(XmlNodeType.Comment);
				_parsingMode = parsingMode;
			}
			else
			{
				NodeData curNode = _curNode;
				_curNode = AddNode(_index + _attrCount + 1, _index);
				ParseCDataOrComment(XmlNodeType.Comment);
				_curNode.CopyTo(0, P_0);
				_curNode = curNode;
			}
		}
		catch (XmlException ex)
		{
			if (ex.ResString == "Xml_UnexpectedEOF" && _ps.entity != null)
			{
				SendValidationEvent(XmlSeverityType.Error, "Sch_ParEntityRefNesting", null, _ps.LineNo, _ps.LinePos);
				return;
			}
			throw;
		}
	}

	private XmlResolver GetTempResolver()
	{
		return _xmlResolver ?? new XmlUrlResolver();
	}

	internal bool DtdParserProxy_PushEntity(IDtdEntityInfo P_0, out int P_1)
	{
		bool result;
		if (P_0.IsExternal)
		{
			if (IsResolverNull)
			{
				P_1 = -1;
				return false;
			}
			result = PushExternalEntity(P_0);
		}
		else
		{
			PushInternalEntity(P_0);
			result = true;
		}
		P_1 = _ps.entityId;
		return result;
	}

	internal bool DtdParserProxy_PopEntity(out IDtdEntityInfo P_0, out int P_1)
	{
		if (_parsingStatesStackTop == -1)
		{
			P_0 = null;
			P_1 = -1;
			return false;
		}
		P_0 = _ps.entity;
		PopEntity();
		P_1 = _ps.entityId;
		return true;
	}

	internal bool DtdParserProxy_PushExternalSubset(string P_0, string P_1)
	{
		if (IsResolverNull)
		{
			return false;
		}
		if (_ps.baseUri == null && !string.IsNullOrEmpty(_ps.baseUriStr))
		{
			_ps.baseUri = _xmlResolver.ResolveUri(null, _ps.baseUriStr);
		}
		PushExternalEntityOrSubset(P_1, P_0, _ps.baseUri, null);
		_ps.entity = null;
		_ps.entityId = 0;
		int charPos = _ps.charPos;
		if (_v1Compat)
		{
			EatWhitespaces(null);
		}
		if (!ParseXmlDeclaration(true))
		{
			_ps.charPos = charPos;
		}
		return true;
	}

	internal void DtdParserProxy_PushInternalDtd(string P_0, string P_1)
	{
		PushParsingState();
		RegisterConsumedCharacters(P_1.Length, false);
		InitStringInput(P_0, Encoding.Unicode, P_1);
		_ps.entity = null;
		_ps.entityId = 0;
		_ps.eolNormalized = false;
	}

	[DoesNotReturn]
	internal void DtdParserProxy_Throw(Exception P_0)
	{
		Throw(P_0);
	}

	internal void DtdParserProxy_OnSystemId(string P_0, LineInfo P_1, LineInfo P_2)
	{
		NodeData nodeData = AddAttributeNoChecks("SYSTEM", _index + 1);
		nodeData.SetValue(P_0);
		nodeData.lineInfo = P_1;
		nodeData.lineInfo2 = P_2;
	}

	internal void DtdParserProxy_OnPublicId(string P_0, LineInfo P_1, LineInfo P_2)
	{
		NodeData nodeData = AddAttributeNoChecks("PUBLIC", _index + 1);
		nodeData.SetValue(P_0);
		nodeData.lineInfo = P_1;
		nodeData.lineInfo2 = P_2;
	}

	[DoesNotReturn]
	private void Throw(int P_0, string P_1, string P_2)
	{
		_ps.charPos = P_0;
		Throw(P_1, P_2);
	}

	[DoesNotReturn]
	private void Throw(int P_0, string P_1, string[] P_2)
	{
		_ps.charPos = P_0;
		Throw(P_1, P_2);
	}

	[DoesNotReturn]
	private void Throw(int P_0, string P_1)
	{
		_ps.charPos = P_0;
		Throw(P_1, string.Empty);
	}

	[DoesNotReturn]
	private void Throw(string P_0)
	{
		Throw(P_0, string.Empty);
	}

	[DoesNotReturn]
	private void Throw(string P_0, int P_1, int P_2)
	{
		Throw(new XmlException(P_0, string.Empty, P_1, P_2, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void Throw(string P_0, string P_1)
	{
		Throw(new XmlException(P_0, P_1, _ps.LineNo, _ps.LinePos, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void Throw(string P_0, string P_1, int P_2, int P_3)
	{
		Throw(new XmlException(P_0, P_1, P_2, P_3, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void Throw(string P_0, string[] P_1)
	{
		Throw(new XmlException(P_0, P_1, _ps.LineNo, _ps.LinePos, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void Throw(string P_0, string P_1, Exception P_2)
	{
		Throw(P_0, new string[1] { P_1 }, P_2);
	}

	[DoesNotReturn]
	private void Throw(string P_0, string[] P_1, Exception P_2)
	{
		Throw(new XmlException(P_0, P_1, P_2, _ps.LineNo, _ps.LinePos, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void Throw(Exception P_0)
	{
		SetErrorState();
		if (P_0 is XmlException ex)
		{
			_curNode.SetLineInfo(ex.LineNumber, ex.LinePosition);
		}
		throw P_0;
	}

	[DoesNotReturn]
	private void ReThrow(Exception P_0, int P_1, int P_2)
	{
		Throw(new XmlException(P_0.Message, (Exception)null, P_1, P_2, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void ThrowWithoutLineInfo(string P_0)
	{
		Throw(new XmlException(P_0, string.Empty, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void ThrowWithoutLineInfo(string P_0, string P_1)
	{
		Throw(new XmlException(P_0, P_1, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void ThrowWithoutLineInfo(string P_0, string[] P_1, Exception P_2)
	{
		Throw(new XmlException(P_0, P_1, P_2, 0, 0, _ps.baseUriStr));
	}

	[DoesNotReturn]
	private void ThrowInvalidChar(char[] P_0, int P_1, int P_2)
	{
		Throw(P_2, "Xml_InvalidCharacter", XmlException.BuildCharExceptionArgs(P_0, P_1, P_2));
	}

	private void SetErrorState()
	{
		_parsingFunction = ParsingFunction.Error;
		_readState = ReadState.Error;
	}

	private void SendValidationEvent(XmlSeverityType P_0, string P_1, string P_2, int P_3, int P_4)
	{
		SendValidationEvent(P_0, new XmlSchemaException(P_1, P_2, _ps.baseUriStr, P_3, P_4));
	}

	private void SendValidationEvent(XmlSeverityType P_0, XmlSchemaException P_1)
	{
		_validationEventHandling?.SendEvent(P_1, P_0);
	}

	private void FinishAttributeValueIterator()
	{
		if (_parsingFunction == ParsingFunction.InReadValueChunk)
		{
			FinishReadValueChunk();
		}
		else if (_parsingFunction == ParsingFunction.InReadContentAsBinary)
		{
			FinishReadContentAsBinary();
		}
		if (_parsingFunction == ParsingFunction.InReadAttributeValue)
		{
			while (_ps.entityId != _attributeValueBaseEntityId)
			{
				HandleEntityEnd(false);
			}
			_emptyEntityInAttributeResolved = false;
			_parsingFunction = _nextParsingFunction;
			_nextParsingFunction = ((_index <= 0) ? ParsingFunction.DocumentContent : ParsingFunction.ElementContent);
		}
	}

	private void InitStreamInput(Uri P_0, Stream P_1, Encoding P_2)
	{
		InitStreamInput(P_0, P_0.ToString(), P_1, null, 0, P_2);
	}

	private void InitStreamInput(Uri P_0, string P_1, Stream P_2, Encoding P_3)
	{
		InitStreamInput(P_0, P_1, P_2, null, 0, P_3);
	}

	private void InitStreamInput(Uri P_0, string P_1, Stream P_2, byte[] P_3, int P_4, Encoding P_5)
	{
		_ps.stream = P_2;
		_ps.baseUri = P_0;
		_ps.baseUriStr = P_1;
		int num;
		if (P_3 != null)
		{
			_ps.bytes = P_3;
			_ps.bytesUsed = P_4;
			num = _ps.bytes.Length;
		}
		else
		{
			num = ((_laterInitParam == null || !_laterInitParam.useAsync) ? XmlReader.CalcBufferSize(P_2) : 32768);
			if (_ps.bytes == null || _ps.bytes.Length < num)
			{
				_ps.bytes = new byte[num];
			}
		}
		if (_ps.chars == null || _ps.chars.Length < num + 1)
		{
			_ps.chars = new char[num + 1];
		}
		_ps.bytePos = 0;
		if (_ps.bytesUsed < 4 && _ps.bytes.Length - _ps.bytesUsed > 0)
		{
			int num2 = Math.Min(4, _ps.bytes.Length - _ps.bytesUsed);
			int num3 = P_2.ReadAtLeast(_ps.bytes.AsSpan(_ps.bytesUsed), num2, false);
			if (num3 < num2)
			{
				_ps.isStreamEof = true;
			}
			_ps.bytesUsed += num3;
		}
		if (P_5 == null)
		{
			P_5 = DetectEncoding();
		}
		SetupEncoding(P_5);
		EatPreamble();
		_documentStartBytePos = _ps.bytePos;
		_ps.eolNormalized = !_normalize;
		_ps.appendMode = true;
		ReadData();
	}

	private void InitTextReaderInput(string P_0, TextReader P_1)
	{
		InitTextReaderInput(P_0, null, P_1);
	}

	private void InitTextReaderInput(string P_0, Uri P_1, TextReader P_2)
	{
		_ps.textReader = P_2;
		_ps.baseUriStr = P_0;
		_ps.baseUri = P_1;
		if (_ps.chars == null)
		{
			if (_laterInitParam != null && _laterInitParam.useAsync)
			{
				_ps.chars = new char[32769];
			}
			else
			{
				_ps.chars = new char[4097];
			}
		}
		_ps.encoding = Encoding.Unicode;
		_ps.eolNormalized = !_normalize;
		_ps.appendMode = true;
		ReadData();
	}

	private void InitStringInput(string P_0, Encoding P_1, string P_2)
	{
		_ps.baseUriStr = P_0;
		_ps.baseUri = null;
		int length = P_2.Length;
		_ps.chars = new char[length + 1];
		P_2.CopyTo(0, _ps.chars, 0, P_2.Length);
		_ps.charsUsed = length;
		_ps.chars[length] = '\0';
		_ps.encoding = P_1;
		_ps.eolNormalized = !_normalize;
		_ps.isEof = true;
	}

	private void InitFragmentReader(XmlNodeType P_0, XmlParserContext P_1, bool P_2)
	{
		_fragmentParserContext = P_1;
		if (P_1 != null)
		{
			if (P_1.NamespaceManager != null)
			{
				_namespaceManager = P_1.NamespaceManager;
				_xmlContext.defaultNamespace = _namespaceManager.LookupNamespace(string.Empty);
			}
			else
			{
				_namespaceManager = new XmlNamespaceManager(_nameTable);
			}
			_ps.baseUriStr = P_1.BaseURI;
			_ps.baseUri = null;
			_xmlContext.xmlLang = P_1.XmlLang;
			_xmlContext.xmlSpace = P_1.XmlSpace;
		}
		else
		{
			_namespaceManager = new XmlNamespaceManager(_nameTable);
			_ps.baseUriStr = string.Empty;
			_ps.baseUri = null;
		}
		_reportedBaseUri = _ps.baseUriStr;
		if (P_0 <= XmlNodeType.Attribute)
		{
			if (P_0 != XmlNodeType.Element)
			{
				if (P_0 != XmlNodeType.Attribute)
				{
					goto IL_012e;
				}
				_ps.appendMode = false;
				_parsingFunction = ParsingFunction.SwitchToInteractive;
				_nextParsingFunction = ParsingFunction.FragmentAttribute;
			}
			else
			{
				_nextParsingFunction = ParsingFunction.DocumentContent;
			}
		}
		else if (P_0 != XmlNodeType.Document)
		{
			if (P_0 != XmlNodeType.XmlDeclaration || !P_2)
			{
				goto IL_012e;
			}
			_ps.appendMode = false;
			_parsingFunction = ParsingFunction.SwitchToInteractive;
			_nextParsingFunction = ParsingFunction.XmlDeclarationFragment;
		}
		_fragmentType = P_0;
		_fragment = true;
		return;
		IL_012e:
		Throw("Xml_PartialContentNodeTypeNotSupportedEx", P_0.ToString());
	}

	private void ProcessDtdFromParserContext(XmlParserContext P_0)
	{
		switch (_dtdProcessing)
		{
		case DtdProcessing.Prohibit:
			ThrowWithoutLineInfo("Xml_DtdIsProhibitedEx");
			break;
		case DtdProcessing.Parse:
			ParseDtdFromParserContext();
			break;
		case DtdProcessing.Ignore:
			break;
		}
	}

	private void OpenUrl()
	{
		XmlResolver tempResolver = GetTempResolver();
		if (_ps.baseUri == null)
		{
			_ps.baseUri = tempResolver.ResolveUri(null, _url);
			_ps.baseUriStr = _ps.baseUri.ToString();
		}
		try
		{
			_ps.stream = (Stream)tempResolver.GetEntity(_ps.baseUri, null, typeof(Stream));
		}
		catch
		{
			SetErrorState();
			throw;
		}
		if (_ps.stream == null)
		{
			ThrowWithoutLineInfo("Xml_CannotResolveUrl", _ps.baseUriStr);
		}
		InitStreamInput(_ps.baseUri, _ps.baseUriStr, _ps.stream, null);
		_reportedEncoding = _ps.encoding;
	}

	private Encoding DetectEncoding()
	{
		if (_ps.bytesUsed < 2)
		{
			return null;
		}
		int num = (_ps.bytes[0] << 8) | _ps.bytes[1];
		int num2 = ((_ps.bytesUsed >= 4) ? ((_ps.bytes[2] << 8) | _ps.bytes[3]) : 0);
		switch (num)
		{
		case 0:
			switch (num2)
			{
			case 65279:
				return Ucs4Encoding.UCS4_Bigendian;
			case 60:
				return Ucs4Encoding.UCS4_Bigendian;
			case 65534:
				return Ucs4Encoding.UCS4_2143;
			case 15360:
				return Ucs4Encoding.UCS4_2143;
			}
			break;
		case 65279:
			if (num2 == 0)
			{
				return Ucs4Encoding.UCS4_3412;
			}
			return Encoding.BigEndianUnicode;
		case 65534:
			if (num2 == 0)
			{
				return Ucs4Encoding.UCS4_Littleendian;
			}
			return Encoding.Unicode;
		case 15360:
			if (num2 == 0)
			{
				return Ucs4Encoding.UCS4_Littleendian;
			}
			return Encoding.Unicode;
		case 60:
			if (num2 == 0)
			{
				return Ucs4Encoding.UCS4_3412;
			}
			return Encoding.BigEndianUnicode;
		case 19567:
			if (num2 == 42900)
			{
				Throw("Xml_UnknownEncoding", "ebcdic");
			}
			break;
		case 61371:
			if ((num2 & 0xFF00) == 48896)
			{
				return new UTF8Encoding(true, true);
			}
			break;
		}
		return null;
	}

	private void SetupEncoding(Encoding P_0)
	{
		if (P_0 == null)
		{
			_ps.encoding = Encoding.UTF8;
			_ps.decoder = new SafeAsciiDecoder();
			return;
		}
		_ps.encoding = P_0;
		_ = _ps;
		string webName = _ps.encoding.WebName;
		Decoder decoder = ((webName == "utf-16") ? new UTF16Decoder(false) : ((!(webName == "utf-16BE")) ? P_0.GetDecoder() : new UTF16Decoder(true)));
		_ps.decoder = decoder;
	}

	private void EatPreamble()
	{
		ReadOnlySpan<byte> preamble = _ps.encoding.Preamble;
		if (_ps.bytes.AsSpan(0, _ps.bytesUsed).StartsWith(preamble))
		{
			_ps.bytePos = preamble.Length;
		}
	}

	private void SwitchEncoding(Encoding P_0)
	{
		if ((P_0.WebName != _ps.encoding.WebName || _ps.decoder is SafeAsciiDecoder) && !_afterResetState)
		{
			UnDecodeChars();
			_ps.appendMode = false;
			SetupEncoding(P_0);
			ReadData();
		}
	}

	private Encoding CheckEncoding(string P_0)
	{
		if (_ps.stream == null)
		{
			return _ps.encoding;
		}
		if (string.Equals(P_0, "ucs-2", StringComparison.OrdinalIgnoreCase) || string.Equals(P_0, "utf-16", StringComparison.OrdinalIgnoreCase) || string.Equals(P_0, "iso-10646-ucs-2", StringComparison.OrdinalIgnoreCase) || string.Equals(P_0, "ucs-4", StringComparison.OrdinalIgnoreCase))
		{
			if (_ps.encoding.WebName != "utf-16BE" && _ps.encoding.WebName != "utf-16" && !string.Equals(P_0, "ucs-4", StringComparison.OrdinalIgnoreCase))
			{
				if (_afterResetState)
				{
					Throw("Xml_EncodingSwitchAfterResetState", P_0);
				}
				else
				{
					ThrowWithoutLineInfo("Xml_MissingByteOrderMark");
				}
			}
			return _ps.encoding;
		}
		Encoding encoding = null;
		if (string.Equals(P_0, "utf-8", StringComparison.OrdinalIgnoreCase))
		{
			encoding = UTF8BomThrowing;
		}
		else
		{
			try
			{
				encoding = Encoding.GetEncoding(P_0);
			}
			catch (NotSupportedException ex)
			{
				Throw("Xml_UnknownEncoding", P_0, ex);
			}
			catch (ArgumentException ex2)
			{
				Throw("Xml_UnknownEncoding", P_0, ex2);
			}
		}
		if (_afterResetState && _ps.encoding.WebName != encoding.WebName)
		{
			Throw("Xml_EncodingSwitchAfterResetState", P_0);
		}
		return encoding;
	}

	private void UnDecodeChars()
	{
		if (_maxCharactersInDocument > 0)
		{
			_charactersInDocument -= _ps.charsUsed - _ps.charPos;
		}
		if (_maxCharactersFromEntities > 0 && InEntity)
		{
			_charactersFromEntities -= _ps.charsUsed - _ps.charPos;
		}
		_ps.bytePos = _documentStartBytePos;
		if (_ps.charPos > 0)
		{
			_ps.bytePos += _ps.encoding.GetByteCount(_ps.chars, 0, _ps.charPos);
		}
		_ps.charsUsed = _ps.charPos;
		_ps.isEof = false;
	}

	private void SwitchEncodingToUTF8()
	{
		SwitchEncoding(UTF8BomThrowing);
	}

	private int ReadData()
	{
		if (_ps.isEof)
		{
			return 0;
		}
		int num;
		if (_ps.appendMode)
		{
			if (_ps.charsUsed == _ps.chars.Length - 1)
			{
				for (int i = 0; i < _attrCount; i++)
				{
					_nodes[_index + i + 1].OnBufferInvalidated();
				}
				char[] array = new char[_ps.chars.Length * 2];
				BlockCopyChars(_ps.chars, 0, array, 0, _ps.chars.Length);
				_ps.chars = array;
			}
			if (_ps.stream != null && _ps.bytesUsed - _ps.bytePos < 6 && _ps.bytes.Length - _ps.bytesUsed < 6)
			{
				byte[] array2 = new byte[_ps.bytes.Length * 2];
				BlockCopy(_ps.bytes, 0, array2, 0, _ps.bytesUsed);
				_ps.bytes = array2;
			}
			num = _ps.chars.Length - _ps.charsUsed - 1;
			if (num > 80)
			{
				num = 80;
			}
		}
		else
		{
			int num2 = _ps.chars.Length;
			if (num2 - _ps.charsUsed <= num2 / 2)
			{
				for (int j = 0; j < _attrCount; j++)
				{
					_nodes[_index + j + 1].OnBufferInvalidated();
				}
				int num3 = _ps.charsUsed - _ps.charPos;
				if (num3 < num2 - 1)
				{
					_ps.lineStartPos -= _ps.charPos;
					if (num3 > 0)
					{
						BlockCopyChars(_ps.chars, _ps.charPos, _ps.chars, 0, num3);
					}
					_ps.charPos = 0;
					_ps.charsUsed = num3;
				}
				else
				{
					char[] array3 = new char[_ps.chars.Length * 2];
					BlockCopyChars(_ps.chars, 0, array3, 0, _ps.chars.Length);
					_ps.chars = array3;
				}
			}
			if (_ps.stream != null)
			{
				int num4 = _ps.bytesUsed - _ps.bytePos;
				if (num4 <= 128)
				{
					if (num4 == 0)
					{
						_ps.bytesUsed = 0;
					}
					else
					{
						BlockCopy(_ps.bytes, _ps.bytePos, _ps.bytes, 0, num4);
						_ps.bytesUsed = num4;
					}
					_ps.bytePos = 0;
				}
			}
			num = _ps.chars.Length - _ps.charsUsed - 1;
		}
		if (_ps.stream != null)
		{
			if (!_ps.isStreamEof && _ps.bytePos == _ps.bytesUsed && _ps.bytes.Length - _ps.bytesUsed > 0)
			{
				int num5 = _ps.stream.Read(_ps.bytes, _ps.bytesUsed, _ps.bytes.Length - _ps.bytesUsed);
				if (num5 == 0)
				{
					_ps.isStreamEof = true;
				}
				_ps.bytesUsed += num5;
			}
			int bytePos = _ps.bytePos;
			num = GetChars(num);
			if (num == 0 && _ps.bytePos != bytePos)
			{
				return ReadData();
			}
		}
		else if (_ps.textReader != null)
		{
			num = _ps.textReader.Read(_ps.chars, _ps.charsUsed, _ps.chars.Length - _ps.charsUsed - 1);
			_ps.charsUsed += num;
		}
		else
		{
			num = 0;
		}
		RegisterConsumedCharacters(num, InEntity);
		if (num == 0)
		{
			_ps.isEof = true;
		}
		_ps.chars[_ps.charsUsed] = '\0';
		return num;
	}

	private int GetChars(int P_0)
	{
		int num = _ps.bytesUsed - _ps.bytePos;
		if (num == 0)
		{
			return 0;
		}
		int num2;
		try
		{
			_ps.decoder.Convert(_ps.bytes, _ps.bytePos, num, _ps.chars, _ps.charsUsed, P_0, false, out num, out num2, out var _);
		}
		catch (ArgumentException)
		{
			InvalidCharRecovery(ref num, out num2);
		}
		_ps.bytePos += num;
		_ps.charsUsed += num2;
		return num2;
	}

	private void InvalidCharRecovery(ref int P_0, out int P_1)
	{
		int num = 0;
		int i = 0;
		try
		{
			int num2;
			for (; i < P_0; i += num2)
			{
				_ps.decoder.Convert(_ps.bytes, _ps.bytePos + i, 1, _ps.chars, _ps.charsUsed + num, 2, false, out num2, out var num3, out var _);
				num += num3;
			}
		}
		catch (ArgumentException)
		{
		}
		if (num == 0)
		{
			Throw(_ps.charsUsed, "Xml_InvalidCharInThisEncoding");
		}
		P_1 = num;
		P_0 = i;
	}

	internal void Close(bool P_0)
	{
		if (_parsingFunction != ParsingFunction.ReaderClosed)
		{
			while (InEntity)
			{
				PopParsingState();
			}
			_ps.Close(P_0);
			_curNode = NodeData.None;
			_parsingFunction = ParsingFunction.ReaderClosed;
			_reportedEncoding = null;
			_reportedBaseUri = string.Empty;
			_readState = ReadState.Closed;
			_fullAttrCleanup = false;
			ResetAttributes();
			_laterInitParam = null;
		}
	}

	private void ShiftBuffer(int P_0, int P_1, int P_2)
	{
		BlockCopyChars(_ps.chars, P_0, _ps.chars, P_1, P_2);
	}

	private bool ParseXmlDeclaration(bool P_0)
	{
		do
		{
			if (_ps.charsUsed - _ps.charPos < 6)
			{
				continue;
			}
			if (!XmlConvert.StrEqual(_ps.chars, _ps.charPos, 5, "<?xml") || XmlCharType.IsNameSingleChar(_ps.chars[_ps.charPos + 5]))
			{
				break;
			}
			if (!P_0)
			{
				_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos + 2);
				_curNode.SetNamedNode(XmlNodeType.XmlDeclaration, _xml);
			}
			_ps.charPos += 5;
			StringBuilder stringBuilder = (P_0 ? new StringBuilder() : _stringBuilder);
			int num = 0;
			Encoding encoding = null;
			while (true)
			{
				int length = stringBuilder.Length;
				int num2 = EatWhitespaces((num == 0) ? null : stringBuilder);
				if (_ps.chars[_ps.charPos] == '?')
				{
					stringBuilder.Length = length;
					if (_ps.chars[_ps.charPos + 1] == '>')
					{
						break;
					}
					if (_ps.charPos + 1 == _ps.charsUsed)
					{
						goto IL_07a2;
					}
					ThrowUnexpectedToken("'>'");
				}
				if (num2 == 0 && num != 0)
				{
					ThrowUnexpectedToken("?>");
				}
				int num3 = ParseName();
				NodeData nodeData = null;
				char c = _ps.chars[_ps.charPos];
				if (c != 'e')
				{
					if (c != 's')
					{
						if (c != 'v' || !XmlConvert.StrEqual(_ps.chars, _ps.charPos, num3 - _ps.charPos, "version") || num != 0)
						{
							goto IL_03ac;
						}
						if (!P_0)
						{
							nodeData = AddAttributeNoChecks("version", 1);
						}
					}
					else
					{
						if (!XmlConvert.StrEqual(_ps.chars, _ps.charPos, num3 - _ps.charPos, "standalone") || (num != 1 && num != 2) || P_0)
						{
							goto IL_03ac;
						}
						nodeData = AddAttributeNoChecks("standalone", 1);
						num = 2;
					}
				}
				else
				{
					if (!XmlConvert.StrEqual(_ps.chars, _ps.charPos, num3 - _ps.charPos, "encoding") || (num != 1 && (!P_0 || num != 0)))
					{
						goto IL_03ac;
					}
					if (!P_0)
					{
						nodeData = AddAttributeNoChecks("encoding", 1);
					}
					num = 1;
				}
				goto IL_03c1;
				IL_03ac:
				Throw(P_0 ? "Xml_InvalidTextDecl" : "Xml_InvalidXmlDecl");
				goto IL_03c1;
				IL_03c1:
				if (!P_0)
				{
					nodeData.SetLineInfo(_ps.LineNo, _ps.LinePos);
				}
				stringBuilder.Append(_ps.chars, _ps.charPos, num3 - _ps.charPos);
				_ps.charPos = num3;
				if (_ps.chars[_ps.charPos] != '=')
				{
					EatWhitespaces(stringBuilder);
					if (_ps.chars[_ps.charPos] != '=')
					{
						ThrowUnexpectedToken("=");
					}
				}
				stringBuilder.Append('=');
				_ps.charPos++;
				char c2 = _ps.chars[_ps.charPos];
				if (c2 != '"' && c2 != '\'')
				{
					EatWhitespaces(stringBuilder);
					c2 = _ps.chars[_ps.charPos];
					if (c2 != '"' && c2 != '\'')
					{
						ThrowUnexpectedToken("\"", "'");
					}
				}
				stringBuilder.Append(c2);
				_ps.charPos++;
				if (!P_0)
				{
					nodeData.quoteChar = c2;
					nodeData.SetLineInfo2(_ps.LineNo, _ps.LinePos);
				}
				int i = _ps.charPos;
				char[] chars;
				while (true)
				{
					for (chars = _ps.chars; XmlCharType.IsAttributeValueChar(chars[i]); i++)
					{
					}
					if (_ps.chars[i] == c2)
					{
						break;
					}
					if (i == _ps.charsUsed)
					{
						if (ReadData() != 0)
						{
							continue;
						}
						goto IL_0780;
					}
					goto IL_078d;
				}
				switch (num)
				{
				case 0:
					if (XmlConvert.StrEqual(_ps.chars, _ps.charPos, i - _ps.charPos, "1.0"))
					{
						if (!P_0)
						{
							nodeData.SetValue(_ps.chars, _ps.charPos, i - _ps.charPos);
						}
						num = 1;
					}
					else
					{
						string text2 = new string(_ps.chars, _ps.charPos, i - _ps.charPos);
						Throw("Xml_InvalidVersionNumber", text2);
					}
					break;
				case 1:
				{
					string text = new string(_ps.chars, _ps.charPos, i - _ps.charPos);
					encoding = CheckEncoding(text);
					if (!P_0)
					{
						nodeData.SetValue(text);
					}
					num = 2;
					break;
				}
				case 2:
					if (XmlConvert.StrEqual(_ps.chars, _ps.charPos, i - _ps.charPos, "yes"))
					{
						_standalone = true;
					}
					else if (XmlConvert.StrEqual(_ps.chars, _ps.charPos, i - _ps.charPos, "no"))
					{
						_standalone = false;
					}
					else
					{
						Throw("Xml_InvalidXmlDecl", _ps.LineNo, _ps.LinePos - 1);
					}
					if (!P_0)
					{
						nodeData.SetValue(_ps.chars, _ps.charPos, i - _ps.charPos);
					}
					num = 3;
					break;
				}
				stringBuilder.Append(chars, _ps.charPos, i - _ps.charPos);
				stringBuilder.Append(c2);
				_ps.charPos = i + 1;
				continue;
				IL_078d:
				Throw(P_0 ? "Xml_InvalidTextDecl" : "Xml_InvalidXmlDecl");
				goto IL_07a2;
				IL_07a2:
				if (_ps.isEof || ReadData() == 0)
				{
					Throw("Xml_UnexpectedEOF1");
				}
				continue;
				IL_0780:
				Throw("Xml_UnclosedQuote");
				goto IL_07a2;
			}
			if (num == 0)
			{
				Throw(P_0 ? "Xml_InvalidTextDecl" : "Xml_InvalidXmlDecl");
			}
			_ps.charPos += 2;
			if (!P_0)
			{
				_curNode.SetValue(stringBuilder.ToString());
				stringBuilder.Length = 0;
				_nextParsingFunction = _parsingFunction;
				_parsingFunction = ParsingFunction.ResetAttributesRootLevel;
			}
			if (encoding == null)
			{
				if (P_0)
				{
					Throw("Xml_InvalidTextDecl");
				}
				if (_afterResetState)
				{
					string webName = _ps.encoding.WebName;
					if (webName != "utf-8" && webName != "utf-16" && webName != "utf-16BE" && !(_ps.encoding is Ucs4Encoding))
					{
						Throw("Xml_EncodingSwitchAfterResetState", (_ps.encoding.GetByteCount("A") == 1) ? "UTF-8" : "UTF-16");
					}
				}
				if (_ps.decoder is SafeAsciiDecoder)
				{
					SwitchEncodingToUTF8();
				}
			}
			else
			{
				SwitchEncoding(encoding);
			}
			_ps.appendMode = false;
			return true;
		}
		while (ReadData() != 0);
		if (!P_0)
		{
			_parsingFunction = _nextParsingFunction;
		}
		if (_afterResetState)
		{
			string webName2 = _ps.encoding.WebName;
			if (webName2 != "utf-8" && webName2 != "utf-16" && webName2 != "utf-16BE" && !(_ps.encoding is Ucs4Encoding))
			{
				Throw("Xml_EncodingSwitchAfterResetState", (_ps.encoding.GetByteCount("A") == 1) ? "UTF-8" : "UTF-16");
			}
		}
		if (_ps.decoder is SafeAsciiDecoder)
		{
			SwitchEncodingToUTF8();
		}
		_ps.appendMode = false;
		return false;
	}

	private bool ParseDocumentContent()
	{
		bool flag = false;
		while (true)
		{
			bool flag2 = false;
			int charPos = _ps.charPos;
			char[] chars = _ps.chars;
			if (chars[charPos] == '<')
			{
				flag2 = true;
				if (_ps.charsUsed - charPos >= 4)
				{
					charPos++;
					switch (chars[charPos])
					{
					case '?':
						_ps.charPos = charPos + 1;
						if (!ParsePI())
						{
							continue;
						}
						return true;
					case '!':
						charPos++;
						if (_ps.charsUsed - charPos < 2)
						{
							break;
						}
						if (chars[charPos] == '-')
						{
							if (chars[charPos + 1] == '-')
							{
								_ps.charPos = charPos + 2;
								if (!ParseComment())
								{
									continue;
								}
								return true;
							}
							ThrowUnexpectedToken(charPos + 1, "-");
							break;
						}
						if (chars[charPos] == '[')
						{
							if (_fragmentType != XmlNodeType.Document)
							{
								charPos++;
								if (_ps.charsUsed - charPos < 6)
								{
									break;
								}
								if (XmlConvert.StrEqual(chars, charPos, 6, "CDATA["))
								{
									_ps.charPos = charPos + 6;
									ParseCData();
									if (_fragmentType == XmlNodeType.None)
									{
										_fragmentType = XmlNodeType.Element;
									}
									return true;
								}
								ThrowUnexpectedToken(charPos, "CDATA[");
							}
							else
							{
								Throw(_ps.charPos, "Xml_InvalidRootData");
							}
							break;
						}
						if (_fragmentType == XmlNodeType.Document || _fragmentType == XmlNodeType.None)
						{
							_fragmentType = XmlNodeType.Document;
							_ps.charPos = charPos;
							if (!ParseDoctypeDecl())
							{
								continue;
							}
							return true;
						}
						if (ParseUnexpectedToken(charPos) == "DOCTYPE")
						{
							Throw("Xml_BadDTDLocation");
						}
						else
						{
							ThrowUnexpectedToken(charPos, "<!--", "<[CDATA[");
						}
						break;
					case '/':
						Throw(charPos + 1, "Xml_UnexpectedEndTag");
						break;
					default:
						if (_rootElementParsed)
						{
							if (_fragmentType == XmlNodeType.Document)
							{
								Throw(charPos, "Xml_MultipleRoots");
							}
							if (_fragmentType == XmlNodeType.None)
							{
								_fragmentType = XmlNodeType.Element;
							}
						}
						_ps.charPos = charPos;
						_rootElementParsed = true;
						ParseElement();
						return true;
					}
				}
			}
			else if (chars[charPos] == '&')
			{
				if (_fragmentType != XmlNodeType.Document)
				{
					if (_fragmentType == XmlNodeType.None)
					{
						_fragmentType = XmlNodeType.Element;
					}
					int num;
					switch (HandleEntityReference(false, EntityExpandType.OnlyGeneral, out num))
					{
					case EntityType.Unexpanded:
						if (_parsingFunction == ParsingFunction.EntityReference)
						{
							_parsingFunction = _nextParsingFunction;
						}
						ParseEntityReference();
						return true;
					case EntityType.CharacterDec:
					case EntityType.CharacterHex:
					case EntityType.CharacterNamed:
						if (ParseText())
						{
							return true;
						}
						break;
					}
					continue;
				}
				Throw(charPos, "Xml_InvalidRootData");
			}
			else if (charPos != _ps.charsUsed && (!(_v1Compat || flag) || chars[charPos] != 0))
			{
				if (_fragmentType == XmlNodeType.Document)
				{
					if (ParseRootLevelWhitespace())
					{
						return true;
					}
				}
				else if (ParseText())
				{
					if (_fragmentType == XmlNodeType.None && _curNode.type == XmlNodeType.Text)
					{
						_fragmentType = XmlNodeType.Element;
					}
					return true;
				}
				continue;
			}
			if (ReadData() == 0)
			{
				if (flag2)
				{
					Throw("Xml_InvalidRootData");
				}
				if (!InEntity)
				{
					break;
				}
				if (HandleEntityEnd(true))
				{
					SetupEndEntityNodeInContent();
					return true;
				}
			}
		}
		if (!_rootElementParsed && _fragmentType == XmlNodeType.Document)
		{
			ThrowWithoutLineInfo("Xml_MissingRoot");
		}
		if (_fragmentType == XmlNodeType.None)
		{
			_fragmentType = ((!_rootElementParsed) ? XmlNodeType.Element : XmlNodeType.Document);
		}
		OnEof();
		return false;
	}

	private bool ParseElementContent()
	{
		while (true)
		{
			int charPos = _ps.charPos;
			char[] chars = _ps.chars;
			switch (chars[charPos])
			{
			case '<':
				switch (chars[charPos + 1])
				{
				case '?':
					_ps.charPos = charPos + 2;
					if (!ParsePI())
					{
						continue;
					}
					return true;
				case '!':
					charPos += 2;
					if (_ps.charsUsed - charPos < 2)
					{
						break;
					}
					if (chars[charPos] == '-')
					{
						if (chars[charPos + 1] == '-')
						{
							_ps.charPos = charPos + 2;
							if (!ParseComment())
							{
								continue;
							}
							return true;
						}
						ThrowUnexpectedToken(charPos + 1, "-");
					}
					else if (chars[charPos] == '[')
					{
						charPos++;
						if (_ps.charsUsed - charPos >= 6)
						{
							if (XmlConvert.StrEqual(chars, charPos, 6, "CDATA["))
							{
								_ps.charPos = charPos + 6;
								ParseCData();
								return true;
							}
							ThrowUnexpectedToken(charPos, "CDATA[");
						}
					}
					else if (ParseUnexpectedToken(charPos) == "DOCTYPE")
					{
						Throw("Xml_BadDTDLocation");
					}
					else
					{
						ThrowUnexpectedToken(charPos, "<!--", "<[CDATA[");
					}
					break;
				case '/':
					_ps.charPos = charPos + 2;
					ParseEndElement();
					return true;
				default:
					if (charPos + 1 != _ps.charsUsed)
					{
						_ps.charPos = charPos + 1;
						ParseElement();
						return true;
					}
					break;
				}
				break;
			case '&':
				if (!ParseText())
				{
					continue;
				}
				return true;
			default:
				if (charPos != _ps.charsUsed)
				{
					if (!ParseText())
					{
						continue;
					}
					return true;
				}
				break;
			}
			if (ReadData() != 0)
			{
				continue;
			}
			if (_ps.charsUsed - _ps.charPos != 0)
			{
				ThrowUnclosedElements();
			}
			if (!InEntity)
			{
				if (_index == 0 && _fragmentType != XmlNodeType.Document)
				{
					OnEof();
					return false;
				}
				ThrowUnclosedElements();
			}
			if (HandleEntityEnd(true))
			{
				break;
			}
		}
		SetupEndEntityNodeInContent();
		return true;
	}

	private void ThrowUnclosedElements()
	{
		if (_index == 0 && _curNode.type != XmlNodeType.Element)
		{
			Throw(_ps.charsUsed, "Xml_UnexpectedEOF1");
			return;
		}
		int num = ((_parsingFunction == ParsingFunction.InIncrementalRead) ? _index : (_index - 1));
		_stringBuilder.Length = 0;
		while (num >= 0)
		{
			NodeData nodeData = _nodes[num];
			if (nodeData.type == XmlNodeType.Element)
			{
				_stringBuilder.Append(nodeData.GetNameWPrefix(_nameTable));
				if (num > 0)
				{
					_stringBuilder.Append(", ");
				}
				else
				{
					_stringBuilder.Append('.');
				}
			}
			num--;
		}
		Throw(_ps.charsUsed, "Xml_UnexpectedEOFInElementContent", _stringBuilder.ToString());
	}

	private void ParseElement()
	{
		int num = _ps.charPos;
		char[] chars = _ps.chars;
		int num2 = -1;
		_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
		while (true)
		{
			if (XmlCharType.IsStartNCNameSingleChar(chars[num]))
			{
				num++;
				while (true)
				{
					if (XmlCharType.IsNCNameSingleChar(chars[num]))
					{
						num++;
						continue;
					}
					if (chars[num] != ':')
					{
						break;
					}
					if (num2 == -1)
					{
						goto IL_0088;
					}
					if (!_supportNamespaces)
					{
						num++;
						continue;
					}
					goto IL_006c;
				}
				if (num + 1 < _ps.charsUsed)
				{
					break;
				}
			}
			goto IL_00a0;
			IL_0088:
			num2 = num;
			num++;
			continue;
			IL_00a0:
			num = ParseQName(out num2);
			chars = _ps.chars;
			break;
			IL_006c:
			Throw(num, "Xml_BadNameChar", XmlException.BuildCharExceptionArgs(':', '\0'));
			goto IL_00a0;
		}
		_namespaceManager.PushScope();
		if (num2 == -1 || !_supportNamespaces)
		{
			_curNode.SetNamedNode(XmlNodeType.Element, _nameTable.Add(chars, _ps.charPos, num - _ps.charPos));
		}
		else
		{
			int charPos = _ps.charPos;
			int num3 = num2 - charPos;
			if (num3 == _lastPrefix.Length && XmlConvert.StrEqual(chars, charPos, num3, _lastPrefix))
			{
				_curNode.SetNamedNode(XmlNodeType.Element, _nameTable.Add(chars, num2 + 1, num - num2 - 1), _lastPrefix, null);
			}
			else
			{
				_curNode.SetNamedNode(XmlNodeType.Element, _nameTable.Add(chars, num2 + 1, num - num2 - 1), _nameTable.Add(chars, _ps.charPos, num3), null);
				_lastPrefix = _curNode.prefix;
			}
		}
		char c = chars[num];
		if (XmlCharType.IsWhiteSpace(c))
		{
			_ps.charPos = num;
			ParseAttributes();
			return;
		}
		switch (c)
		{
		case '>':
			_ps.charPos = num + 1;
			_parsingFunction = ParsingFunction.MoveToElementContent;
			break;
		case '/':
			if (num + 1 == _ps.charsUsed)
			{
				_ps.charPos = num;
				if (ReadData() == 0)
				{
					Throw(num, "Xml_UnexpectedEOF", ">");
				}
				num = _ps.charPos;
				chars = _ps.chars;
			}
			if (chars[num + 1] == '>')
			{
				_curNode.IsEmptyElement = true;
				_nextParsingFunction = _parsingFunction;
				_parsingFunction = ParsingFunction.PopEmptyElementContext;
				_ps.charPos = num + 2;
			}
			else
			{
				ThrowUnexpectedToken(num, ">");
			}
			break;
		default:
			Throw(num, "Xml_BadNameChar", XmlException.BuildCharExceptionArgs(chars, _ps.charsUsed, num));
			break;
		}
		if (_addDefaultAttributesAndNormalize)
		{
			AddDefaultAttributesAndNormalize();
		}
		ElementNamespaceLookup();
	}

	private void AddDefaultAttributesAndNormalize()
	{
		IDtdAttributeListInfo dtdAttributeListInfo = _dtdInfo.LookupAttributeList(_curNode.localName, _curNode.prefix);
		if (dtdAttributeListInfo == null)
		{
			return;
		}
		if (_normalize && dtdAttributeListInfo.HasNonCDataAttributes)
		{
			for (int i = _index + 1; i < _index + 1 + _attrCount; i++)
			{
				NodeData nodeData = _nodes[i];
				IDtdAttributeInfo dtdAttributeInfo = dtdAttributeListInfo.LookupAttribute(nodeData.prefix, nodeData.localName);
				if (dtdAttributeInfo == null || !dtdAttributeInfo.IsNonCDataType)
				{
					continue;
				}
				if (DtdValidation && _standalone && dtdAttributeInfo.IsDeclaredInExternal)
				{
					string stringValue = nodeData.StringValue;
					nodeData.TrimSpacesInValue();
					if (stringValue != nodeData.StringValue)
					{
						SendValidationEvent(XmlSeverityType.Error, "Sch_StandAloneNormalization", nodeData.GetNameWPrefix(_nameTable), nodeData.LineNo, nodeData.LinePos);
					}
				}
				else
				{
					nodeData.TrimSpacesInValue();
				}
			}
		}
		IEnumerable<IDtdDefaultAttributeInfo> enumerable = dtdAttributeListInfo.LookupDefaultAttributes();
		if (enumerable == null)
		{
			return;
		}
		int attrCount = _attrCount;
		NodeData[] array = null;
		if (_attrCount >= 250)
		{
			array = new NodeData[_attrCount];
			Array.Copy(_nodes, _index + 1, array, 0, _attrCount);
			object[] array2 = array;
			Array.Sort(array2, DtdDefaultAttributeInfoToNodeDataComparer.Instance);
		}
		foreach (IDtdDefaultAttributeInfo item in enumerable)
		{
			if (AddDefaultAttributeDtd(item, true, array) && DtdValidation && _standalone && item.IsDeclaredInExternal)
			{
				string prefix = item.Prefix;
				string text = ((prefix.Length == 0) ? item.LocalName : (prefix + ":" + item.LocalName));
				SendValidationEvent(XmlSeverityType.Error, "Sch_UnSpecifiedDefaultAttributeInExternalStandalone", text, _curNode.LineNo, _curNode.LinePos);
			}
		}
		if (attrCount == 0 && _attrNeedNamespaceLookup)
		{
			AttributeNamespaceLookup();
			_attrNeedNamespaceLookup = false;
		}
	}

	private void ParseEndElement()
	{
		NodeData nodeData = _nodes[_index - 1];
		int length = nodeData.prefix.Length;
		int length2 = nodeData.localName.Length;
		while (_ps.charsUsed - _ps.charPos < length + length2 + 1 && ReadData() != 0)
		{
		}
		char[] chars = _ps.chars;
		int num;
		if (nodeData.prefix.Length == 0)
		{
			if (!XmlConvert.StrEqual(chars, _ps.charPos, length2, nodeData.localName))
			{
				ThrowTagMismatch(nodeData);
			}
			num = length2;
		}
		else
		{
			int num2 = _ps.charPos + length;
			if (!XmlConvert.StrEqual(chars, _ps.charPos, length, nodeData.prefix) || chars[num2] != ':' || !XmlConvert.StrEqual(chars, num2 + 1, length2, nodeData.localName))
			{
				ThrowTagMismatch(nodeData);
			}
			num = length2 + length + 1;
		}
		LineInfo lineInfo = new LineInfo(_ps.lineNo, _ps.LinePos);
		int num3;
		while (true)
		{
			num3 = _ps.charPos + num;
			chars = _ps.chars;
			if (num3 != _ps.charsUsed)
			{
				if (XmlCharType.IsNCNameSingleChar(chars[num3]) || chars[num3] == ':')
				{
					ThrowTagMismatch(nodeData);
				}
				if (chars[num3] != '>')
				{
					char c;
					while (XmlCharType.IsWhiteSpace(c = chars[num3]))
					{
						num3++;
						switch (c)
						{
						case '\n':
							OnNewLine(num3);
							break;
						case '\r':
							if (chars[num3] == '\n')
							{
								num3++;
							}
							else if (num3 == _ps.charsUsed && !_ps.isEof)
							{
								break;
							}
							OnNewLine(num3);
							break;
						}
					}
				}
				if (chars[num3] == '>')
				{
					break;
				}
				if (num3 != _ps.charsUsed)
				{
					ThrowUnexpectedToken(num3, ">");
				}
			}
			if (ReadData() == 0)
			{
				ThrowUnclosedElements();
			}
		}
		_index--;
		_curNode = _nodes[_index];
		nodeData.lineInfo = lineInfo;
		nodeData.type = XmlNodeType.EndElement;
		_ps.charPos = num3 + 1;
		_nextParsingFunction = ((_index > 0) ? _parsingFunction : ParsingFunction.DocumentContent);
		_parsingFunction = ParsingFunction.PopElementContext;
	}

	private void ThrowTagMismatch(NodeData P_0)
	{
		if (P_0.type == XmlNodeType.Element)
		{
			int num2;
			int num = ParseQName(out num2);
			Throw("Xml_TagMismatchEx", new string[4]
			{
				P_0.GetNameWPrefix(_nameTable),
				P_0.lineInfo.lineNo.ToString(CultureInfo.InvariantCulture),
				P_0.lineInfo.linePos.ToString(CultureInfo.InvariantCulture),
				new string(_ps.chars, _ps.charPos, num - _ps.charPos)
			});
		}
		else
		{
			Throw("Xml_UnexpectedEndTag");
		}
	}

	private void ParseAttributes()
	{
		int num = _ps.charPos;
		char[] chars = _ps.chars;
		NodeData nodeData = null;
		while (true)
		{
			int num2 = 0;
			while (true)
			{
				char c;
				int num3;
				if (XmlCharType.IsWhiteSpace(c = chars[num]))
				{
					switch (c)
					{
					case '\n':
						OnNewLine(num + 1);
						num2++;
						goto IL_0085;
					case '\r':
						if (chars[num + 1] == '\n')
						{
							OnNewLine(num + 2);
							num2++;
							num++;
							goto IL_0085;
						}
						if (num + 1 != _ps.charsUsed)
						{
							OnNewLine(num + 1);
							num2++;
							goto IL_0085;
						}
						break;
					default:
						goto IL_0085;
					}
					_ps.charPos = num;
				}
				else
				{
					num3 = 0;
					char c2;
					if (XmlCharType.IsStartNCNameSingleChar(c2 = chars[num]))
					{
						num3 = 1;
					}
					if (num3 != 0)
					{
						goto IL_0171;
					}
					if (c2 == '>')
					{
						_ps.charPos = num + 1;
						_parsingFunction = ParsingFunction.MoveToElementContent;
						goto IL_0438;
					}
					if (c2 == '/')
					{
						if (num + 1 != _ps.charsUsed)
						{
							if (chars[num + 1] == '>')
							{
								_ps.charPos = num + 2;
								_curNode.IsEmptyElement = true;
								_nextParsingFunction = _parsingFunction;
								_parsingFunction = ParsingFunction.PopEmptyElementContext;
								goto IL_0438;
							}
							ThrowUnexpectedToken(num + 1, ">");
							goto IL_0171;
						}
					}
					else if (num != _ps.charsUsed)
					{
						if (c2 != ':' || _supportNamespaces)
						{
							Throw(num, "Xml_BadStartNameChar", XmlException.BuildCharExceptionArgs(chars, _ps.charsUsed, num));
						}
						goto IL_0171;
					}
				}
				_ps.lineNo -= num2;
				if (ReadData() != 0)
				{
					num = _ps.charPos;
					chars = _ps.chars;
				}
				else
				{
					ThrowUnclosedElements();
				}
				break;
				IL_0438:
				if (_addDefaultAttributesAndNormalize)
				{
					AddDefaultAttributesAndNormalize();
				}
				ElementNamespaceLookup();
				if (_attrNeedNamespaceLookup)
				{
					AttributeNamespaceLookup();
					_attrNeedNamespaceLookup = false;
				}
				if (_attrDuplWalkCount >= 250)
				{
					AttributeDuplCheck();
				}
				return;
				IL_0085:
				num++;
				continue;
				IL_0171:
				if (num == _ps.charPos)
				{
					ThrowExpectingWhitespace(num);
				}
				_ps.charPos = num;
				int linePos = _ps.LinePos;
				int num4 = -1;
				num += num3;
				while (true)
				{
					char c3;
					if (XmlCharType.IsNCNameSingleChar(c3 = chars[num]))
					{
						num++;
						continue;
					}
					if (c3 == ':')
					{
						if (num4 != -1)
						{
							if (_supportNamespaces)
							{
								Throw(num, "Xml_BadNameChar", XmlException.BuildCharExceptionArgs(':', '\0'));
								break;
							}
							num++;
							continue;
						}
						num4 = num;
						num++;
						if (XmlCharType.IsStartNCNameSingleChar(chars[num]))
						{
							num++;
							continue;
						}
						num = ParseQName(out num4);
						chars = _ps.chars;
						break;
					}
					if (num + 1 >= _ps.charsUsed)
					{
						num = ParseQName(out num4);
						chars = _ps.chars;
					}
					break;
				}
				nodeData = AddAttribute(num, num4);
				nodeData.SetLineInfo(_ps.LineNo, linePos);
				if (chars[num] != '=')
				{
					_ps.charPos = num;
					EatWhitespaces(null);
					num = _ps.charPos;
					if (chars[num] != '=')
					{
						ThrowUnexpectedToken("=");
					}
				}
				num++;
				char c4 = chars[num];
				if (c4 != '"' && c4 != '\'')
				{
					_ps.charPos = num;
					EatWhitespaces(null);
					num = _ps.charPos;
					c4 = chars[num];
					if (c4 != '"' && c4 != '\'')
					{
						ThrowUnexpectedToken("\"", "'");
					}
				}
				num++;
				_ps.charPos = num;
				nodeData.quoteChar = c4;
				nodeData.SetLineInfo2(_ps.LineNo, _ps.LinePos);
				char c5;
				while (XmlCharType.IsAttributeValueChar(c5 = chars[num]))
				{
					num++;
				}
				if (c5 == c4)
				{
					nodeData.SetValue(chars, _ps.charPos, num - _ps.charPos);
					num++;
					_ps.charPos = num;
				}
				else
				{
					ParseAttributeValueSlow(num, c4, nodeData);
					num = _ps.charPos;
					chars = _ps.chars;
				}
				if (nodeData.prefix.Length == 0)
				{
					if (Ref.Equal(nodeData.localName, _xmlNs))
					{
						OnDefaultNamespaceDecl(nodeData);
					}
				}
				else if (Ref.Equal(nodeData.prefix, _xmlNs))
				{
					OnNamespaceDecl(nodeData);
				}
				else if (Ref.Equal(nodeData.prefix, _xml))
				{
					OnXmlReservedAttribute(nodeData);
				}
				break;
			}
		}
	}

	private void ElementNamespaceLookup()
	{
		if (_curNode.prefix.Length == 0)
		{
			_curNode.ns = _xmlContext.defaultNamespace;
		}
		else
		{
			_curNode.ns = LookupNamespace(_curNode);
		}
	}

	private void AttributeNamespaceLookup()
	{
		for (int i = _index + 1; i < _index + _attrCount + 1; i++)
		{
			NodeData nodeData = _nodes[i];
			if (nodeData.type == XmlNodeType.Attribute && nodeData.prefix.Length > 0)
			{
				nodeData.ns = LookupNamespace(nodeData);
			}
		}
	}

	private void AttributeDuplCheck()
	{
		if (_attrCount < 250)
		{
			for (int i = _index + 1; i < _index + 1 + _attrCount; i++)
			{
				NodeData nodeData = _nodes[i];
				for (int j = i + 1; j < _index + 1 + _attrCount; j++)
				{
					if (Ref.Equal(nodeData.localName, _nodes[j].localName) && Ref.Equal(nodeData.ns, _nodes[j].ns))
					{
						Throw("Xml_DupAttributeName", _nodes[j].GetNameWPrefix(_nameTable), _nodes[j].LineNo, _nodes[j].LinePos);
					}
				}
			}
			return;
		}
		if (_attrDuplSortingArray == null || _attrDuplSortingArray.Length < _attrCount)
		{
			_attrDuplSortingArray = new NodeData[_attrCount];
		}
		Array.Copy(_nodes, _index + 1, _attrDuplSortingArray, 0, _attrCount);
		Array.Sort(_attrDuplSortingArray, 0, _attrCount);
		NodeData nodeData2 = _attrDuplSortingArray[0];
		for (int k = 1; k < _attrCount; k++)
		{
			NodeData nodeData3 = _attrDuplSortingArray[k];
			if (Ref.Equal(nodeData2.localName, nodeData3.localName) && Ref.Equal(nodeData2.ns, nodeData3.ns))
			{
				Throw("Xml_DupAttributeName", nodeData3.GetNameWPrefix(_nameTable), nodeData3.LineNo, nodeData3.LinePos);
			}
			nodeData2 = nodeData3;
		}
	}

	private void OnDefaultNamespaceDecl(NodeData P_0)
	{
		if (_supportNamespaces)
		{
			string text = _nameTable.Add(P_0.StringValue);
			P_0.ns = _nameTable.Add("http://www.w3.org/2000/xmlns/");
			if (!_curNode.xmlContextPushed)
			{
				PushXmlContext();
			}
			_xmlContext.defaultNamespace = text;
			AddNamespace(string.Empty, text, P_0);
		}
	}

	private void OnNamespaceDecl(NodeData P_0)
	{
		if (_supportNamespaces)
		{
			string text = _nameTable.Add(P_0.StringValue);
			if (text.Length == 0)
			{
				Throw("Xml_BadNamespaceDecl", P_0.lineInfo2.lineNo, P_0.lineInfo2.linePos - 1);
			}
			AddNamespace(P_0.localName, text, P_0);
		}
	}

	private void OnXmlReservedAttribute(NodeData P_0)
	{
		string localName = P_0.localName;
		if (!(localName == "space"))
		{
			if (localName == "lang")
			{
				if (!_curNode.xmlContextPushed)
				{
					PushXmlContext();
				}
				_xmlContext.xmlLang = P_0.StringValue;
			}
			return;
		}
		if (!_curNode.xmlContextPushed)
		{
			PushXmlContext();
		}
		string text = XmlConvert.TrimString(P_0.StringValue);
		if (!(text == "preserve"))
		{
			if (text == "default")
			{
				_xmlContext.xmlSpace = XmlSpace.Default;
			}
			else
			{
				Throw("Xml_InvalidXmlSpace", P_0.StringValue, P_0.lineInfo.lineNo, P_0.lineInfo.linePos);
			}
		}
		else
		{
			_xmlContext.xmlSpace = XmlSpace.Preserve;
		}
	}

	private void ParseAttributeValueSlow(int P_0, char P_1, NodeData P_2)
	{
		int num = P_0;
		char[] chars = _ps.chars;
		int entityId = _ps.entityId;
		int num2 = 0;
		LineInfo lineInfo = new LineInfo(_ps.lineNo, _ps.LinePos);
		NodeData nodeData = null;
		while (true)
		{
			if (XmlCharType.IsAttributeValueChar(chars[num]))
			{
				num++;
				continue;
			}
			if (num - _ps.charPos > 0)
			{
				_stringBuilder.Append(chars, _ps.charPos, num - _ps.charPos);
				_ps.charPos = num;
			}
			if (chars[num] == P_1 && entityId == _ps.entityId)
			{
				break;
			}
			switch (chars[num])
			{
			case '\n':
				num++;
				OnNewLine(num);
				if (_normalize)
				{
					_stringBuilder.Append(' ');
					_ps.charPos++;
				}
				continue;
			case '\r':
				if (chars[num + 1] == '\n')
				{
					num += 2;
					if (_normalize)
					{
						_stringBuilder.Append(_ps.eolNormalized ? "  " : " ");
						_ps.charPos = num;
					}
				}
				else
				{
					if (num + 1 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					num++;
					if (_normalize)
					{
						_stringBuilder.Append(' ');
						_ps.charPos = num;
					}
				}
				OnNewLine(num);
				continue;
			case '\t':
				num++;
				if (_normalize)
				{
					_stringBuilder.Append(' ');
					_ps.charPos++;
				}
				continue;
			case '"':
			case '\'':
			case '>':
				num++;
				continue;
			case '<':
				Throw(num, "Xml_BadAttributeChar", XmlException.BuildCharExceptionArgs('<', '\0'));
				break;
			case '&':
			{
				if (num - _ps.charPos > 0)
				{
					_stringBuilder.Append(chars, _ps.charPos, num - _ps.charPos);
				}
				_ps.charPos = num;
				int entityId2 = _ps.entityId;
				LineInfo lineInfo2 = new LineInfo(_ps.lineNo, _ps.LinePos + 1);
				switch (HandleEntityReference(true, EntityExpandType.All, out num))
				{
				case EntityType.Unexpanded:
					if (_parsingMode == ParsingMode.Full && _ps.entityId == entityId)
					{
						int num4 = _stringBuilder.Length - num2;
						if (num4 > 0)
						{
							NodeData nodeData4 = new NodeData();
							nodeData4.lineInfo = lineInfo;
							nodeData4.depth = P_2.depth + 1;
							nodeData4.SetValueNode(XmlNodeType.Text, _stringBuilder.ToString(num2, num4));
							AddAttributeChunkToList(P_2, nodeData4, ref nodeData);
						}
						_ps.charPos++;
						string text = ParseEntityName();
						NodeData nodeData5 = new NodeData();
						nodeData5.lineInfo = lineInfo2;
						nodeData5.depth = P_2.depth + 1;
						nodeData5.SetNamedNode(XmlNodeType.EntityReference, text);
						AddAttributeChunkToList(P_2, nodeData5, ref nodeData);
						_stringBuilder.Append('&');
						_stringBuilder.Append(text);
						_stringBuilder.Append(';');
						num2 = _stringBuilder.Length;
						lineInfo.Set(_ps.LineNo, _ps.LinePos);
						_fullAttrCleanup = true;
					}
					else
					{
						_ps.charPos++;
						ParseEntityName();
					}
					num = _ps.charPos;
					break;
				case EntityType.ExpandedInAttribute:
					if (_parsingMode == ParsingMode.Full && entityId2 == entityId)
					{
						int num3 = _stringBuilder.Length - num2;
						if (num3 > 0)
						{
							NodeData nodeData2 = new NodeData();
							nodeData2.lineInfo = lineInfo;
							nodeData2.depth = P_2.depth + 1;
							nodeData2.SetValueNode(XmlNodeType.Text, _stringBuilder.ToString(num2, num3));
							AddAttributeChunkToList(P_2, nodeData2, ref nodeData);
						}
						NodeData nodeData3 = new NodeData();
						nodeData3.lineInfo = lineInfo2;
						nodeData3.depth = P_2.depth + 1;
						nodeData3.SetNamedNode(XmlNodeType.EntityReference, _ps.entity.Name);
						AddAttributeChunkToList(P_2, nodeData3, ref nodeData);
						_fullAttrCleanup = true;
					}
					num = _ps.charPos;
					break;
				default:
					num = _ps.charPos;
					break;
				case EntityType.CharacterDec:
				case EntityType.CharacterHex:
				case EntityType.CharacterNamed:
					break;
				}
				chars = _ps.chars;
				continue;
			}
			default:
			{
				if (num == _ps.charsUsed)
				{
					break;
				}
				char c = chars[num];
				if (XmlCharType.IsHighSurrogate(c))
				{
					if (num + 1 == _ps.charsUsed)
					{
						break;
					}
					num++;
					if (XmlCharType.IsLowSurrogate(chars[num]))
					{
						num++;
						continue;
					}
				}
				ThrowInvalidChar(chars, _ps.charsUsed, num);
				break;
			}
			}
			if (ReadData() == 0)
			{
				if (_ps.charsUsed - _ps.charPos > 0)
				{
					if (_ps.chars[_ps.charPos] != '\r')
					{
						Throw("Xml_UnexpectedEOF1");
					}
				}
				else
				{
					if (!InEntity)
					{
						if (_fragmentType == XmlNodeType.Attribute)
						{
							if (entityId != _ps.entityId)
							{
								Throw("Xml_EntityRefNesting");
							}
							break;
						}
						Throw("Xml_UnclosedQuote");
					}
					if (HandleEntityEnd(true))
					{
						Throw("Xml_InternalError");
					}
					if (entityId == _ps.entityId)
					{
						num2 = _stringBuilder.Length;
						lineInfo.Set(_ps.LineNo, _ps.LinePos);
					}
				}
			}
			num = _ps.charPos;
			chars = _ps.chars;
		}
		if (P_2.nextAttrValueChunk != null)
		{
			int num5 = _stringBuilder.Length - num2;
			if (num5 > 0)
			{
				NodeData nodeData6 = new NodeData();
				nodeData6.lineInfo = lineInfo;
				nodeData6.depth = P_2.depth + 1;
				nodeData6.SetValueNode(XmlNodeType.Text, _stringBuilder.ToString(num2, num5));
				AddAttributeChunkToList(P_2, nodeData6, ref nodeData);
			}
		}
		_ps.charPos = num + 1;
		P_2.SetValue(_stringBuilder.ToString());
		_stringBuilder.Length = 0;
	}

	private static void AddAttributeChunkToList(NodeData P_0, NodeData P_1, ref NodeData P_2)
	{
		if (P_2 == null)
		{
			P_2 = P_1;
			P_0.nextAttrValueChunk = P_1;
		}
		else
		{
			P_2.nextAttrValueChunk = P_1;
			P_2 = P_1;
		}
	}

	private bool ParseText()
	{
		int num = 0;
		int num2;
		int num3;
		if (_parsingMode != ParsingMode.Full)
		{
			while (!ParseText(out num2, out num3, ref num))
			{
			}
		}
		else
		{
			_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
			if (ParseText(out var num4, out var num5, ref num))
			{
				if (num5 - num4 != 0)
				{
					XmlNodeType textNodeType = GetTextNodeType(num);
					if (textNodeType != XmlNodeType.None)
					{
						_curNode.SetValueNode(textNodeType, _ps.chars, num4, num5 - num4);
						return true;
					}
				}
			}
			else if (_v1Compat)
			{
				do
				{
					if (num5 - num4 > 0)
					{
						_stringBuilder.Append(_ps.chars, num4, num5 - num4);
					}
				}
				while (!ParseText(out num4, out num5, ref num));
				if (num5 - num4 > 0)
				{
					_stringBuilder.Append(_ps.chars, num4, num5 - num4);
				}
				XmlNodeType textNodeType2 = GetTextNodeType(num);
				if (textNodeType2 != XmlNodeType.None)
				{
					_curNode.SetValueNode(textNodeType2, _stringBuilder.ToString());
					_stringBuilder.Length = 0;
					return true;
				}
				_stringBuilder.Length = 0;
			}
			else
			{
				if (num > 32)
				{
					_curNode.SetValueNode(XmlNodeType.Text, _ps.chars, num4, num5 - num4);
					_nextParsingFunction = _parsingFunction;
					_parsingFunction = ParsingFunction.PartialTextValue;
					return true;
				}
				if (num5 - num4 > 0)
				{
					_stringBuilder.Append(_ps.chars, num4, num5 - num4);
				}
				bool flag;
				do
				{
					flag = ParseText(out num4, out num5, ref num);
					if (num5 - num4 > 0)
					{
						_stringBuilder.Append(_ps.chars, num4, num5 - num4);
					}
				}
				while (!flag && num <= 32 && _stringBuilder.Length < 4096);
				XmlNodeType xmlNodeType = ((_stringBuilder.Length < 4096) ? GetTextNodeType(num) : XmlNodeType.Text);
				if (xmlNodeType != XmlNodeType.None)
				{
					_curNode.SetValueNode(xmlNodeType, _stringBuilder.ToString());
					_stringBuilder.Length = 0;
					if (!flag)
					{
						_nextParsingFunction = _parsingFunction;
						_parsingFunction = ParsingFunction.PartialTextValue;
					}
					return true;
				}
				_stringBuilder.Length = 0;
				if (!flag)
				{
					while (!ParseText(out num3, out num2, ref num))
					{
					}
				}
			}
		}
		if (_parsingFunction == ParsingFunction.ReportEndEntity)
		{
			SetupEndEntityNodeInContent();
			_parsingFunction = _nextParsingFunction;
			return true;
		}
		if (_parsingFunction == ParsingFunction.EntityReference)
		{
			_parsingFunction = _nextNextParsingFunction;
			ParseEntityReference();
			return true;
		}
		return false;
	}

	private bool ParseText(out int P_0, out int P_1, ref int P_2)
	{
		char[] chars = _ps.chars;
		int num = _ps.charPos;
		int num2 = 0;
		int num3 = -1;
		int num4 = P_2;
		char c;
		while (true)
		{
			if (XmlCharType.IsTextChar(c = chars[num]))
			{
				num4 |= c;
				num++;
				continue;
			}
			switch (c)
			{
			case '\t':
				num++;
				continue;
			case '\n':
				num++;
				OnNewLine(num);
				continue;
			case '\r':
				if (chars[num + 1] == '\n')
				{
					if (!_ps.eolNormalized && _parsingMode == ParsingMode.Full)
					{
						if (num - _ps.charPos > 0)
						{
							if (num2 == 0)
							{
								num2 = 1;
								num3 = num;
							}
							else
							{
								ShiftBuffer(num3 + num2, num3, num - num3 - num2);
								num3 = num - num2;
								num2++;
							}
						}
						else
						{
							_ps.charPos++;
						}
					}
					num += 2;
				}
				else
				{
					if (num + 1 >= _ps.charsUsed && !_ps.isEof)
					{
						goto IL_0341;
					}
					if (!_ps.eolNormalized)
					{
						chars[num] = '\n';
					}
					num++;
				}
				OnNewLine(num);
				continue;
			case '&':
			{
				int num6;
				if ((num6 = ParseCharRefInline(num, out var num7, out var entityType)) > 0)
				{
					if (num2 > 0)
					{
						ShiftBuffer(num3 + num2, num3, num - num3 - num2);
					}
					num3 = num - num2;
					num2 += num6 - num - num7;
					num = num6;
					if (!XmlCharType.IsWhiteSpace(chars[num6 - num7]) || (_v1Compat && entityType == EntityType.CharacterDec))
					{
						num4 |= 0xFF;
					}
					continue;
				}
				if (num > _ps.charPos)
				{
					break;
				}
				switch (HandleEntityReference(false, EntityExpandType.All, out num))
				{
				case EntityType.Unexpanded:
					break;
				case EntityType.CharacterDec:
					if (!_v1Compat)
					{
						goto case EntityType.CharacterHex;
					}
					num4 |= 0xFF;
					goto IL_023f;
				case EntityType.CharacterHex:
				case EntityType.CharacterNamed:
					if (!XmlCharType.IsWhiteSpace(_ps.chars[num - 1]))
					{
						num4 |= 0xFF;
					}
					goto IL_023f;
				default:
					{
						num = _ps.charPos;
						goto IL_023f;
					}
					IL_023f:
					chars = _ps.chars;
					continue;
				}
				_nextParsingFunction = _parsingFunction;
				_parsingFunction = ParsingFunction.EntityReference;
				goto IL_03fe;
			}
			case ']':
				if (_ps.charsUsed - num >= 3 || _ps.isEof)
				{
					if (chars[num + 1] == ']' && chars[num + 2] == '>')
					{
						Throw(num, "Xml_CDATAEndInText");
					}
					num4 |= 0x5D;
					num++;
					continue;
				}
				goto IL_0341;
			default:
				if (num != _ps.charsUsed)
				{
					char c2 = chars[num];
					if (XmlCharType.IsHighSurrogate(c2))
					{
						if (num + 1 == _ps.charsUsed)
						{
							goto IL_0341;
						}
						num++;
						if (XmlCharType.IsLowSurrogate(chars[num]))
						{
							num++;
							num4 |= c2;
							continue;
						}
					}
					int num5 = num - _ps.charPos;
					if (ZeroEndingStream(num))
					{
						num = _ps.charPos + num5;
						break;
					}
					ThrowInvalidChar(_ps.chars, _ps.charsUsed, _ps.charPos + num5);
				}
				goto IL_0341;
			case '<':
				break;
				IL_0341:
				if (num > _ps.charPos)
				{
					break;
				}
				if (ReadData() == 0)
				{
					if (_ps.charsUsed - _ps.charPos <= 0)
					{
						if (InEntity)
						{
							if (!HandleEntityEnd(true))
							{
								goto IL_03e1;
							}
							_nextParsingFunction = _parsingFunction;
							_parsingFunction = ParsingFunction.ReportEndEntity;
						}
						goto IL_03fe;
					}
					if (_ps.chars[_ps.charPos] != '\r' && _ps.chars[_ps.charPos] != ']')
					{
						Throw("Xml_UnexpectedEOF1");
					}
				}
				goto IL_03e1;
				IL_03e1:
				num = _ps.charPos;
				chars = _ps.chars;
				continue;
				IL_03fe:
				P_0 = (P_1 = num);
				return true;
			}
			break;
		}
		if (_parsingMode == ParsingMode.Full && num2 > 0)
		{
			ShiftBuffer(num3 + num2, num3, num - num3 - num2);
		}
		P_0 = _ps.charPos;
		P_1 = num - num2;
		_ps.charPos = num;
		P_2 = num4;
		return c == '<';
	}

	private void FinishPartialValue()
	{
		_curNode.CopyTo(_readValueOffset, _stringBuilder);
		int num = 0;
		int num2;
		int num3;
		while (!ParseText(out num2, out num3, ref num))
		{
			_stringBuilder.Append(_ps.chars, num2, num3 - num2);
		}
		_stringBuilder.Append(_ps.chars, num2, num3 - num2);
		_curNode.SetValue(_stringBuilder.ToString());
		_stringBuilder.Length = 0;
	}

	private void FinishOtherValueIterator()
	{
		switch (_parsingFunction)
		{
		case ParsingFunction.InReadValueChunk:
			if (_incReadState == IncrementalReadState.ReadValueChunk_OnPartialValue)
			{
				FinishPartialValue();
				_incReadState = IncrementalReadState.ReadValueChunk_OnCachedValue;
			}
			else if (_readValueOffset > 0)
			{
				_curNode.SetValue(_curNode.StringValue.Substring(_readValueOffset));
				_readValueOffset = 0;
			}
			break;
		case ParsingFunction.InReadContentAsBinary:
		case ParsingFunction.InReadElementContentAsBinary:
			switch (_incReadState)
			{
			case IncrementalReadState.ReadContentAsBinary_OnPartialValue:
				FinishPartialValue();
				_incReadState = IncrementalReadState.ReadContentAsBinary_OnCachedValue;
				break;
			case IncrementalReadState.ReadContentAsBinary_OnCachedValue:
				if (_readValueOffset > 0)
				{
					_curNode.SetValue(_curNode.StringValue.Substring(_readValueOffset));
					_readValueOffset = 0;
				}
				break;
			case IncrementalReadState.ReadContentAsBinary_End:
				_curNode.SetValue(string.Empty);
				break;
			}
			break;
		case ParsingFunction.InReadAttributeValue:
			break;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SkipPartialTextValue()
	{
		int num = 0;
		_parsingFunction = _nextParsingFunction;
		int num2;
		int num3;
		while (!ParseText(out num2, out num3, ref num))
		{
		}
	}

	private void FinishReadValueChunk()
	{
		_readValueOffset = 0;
		if (_incReadState == IncrementalReadState.ReadValueChunk_OnPartialValue)
		{
			SkipPartialTextValue();
			return;
		}
		_parsingFunction = _nextParsingFunction;
		_nextParsingFunction = _nextNextParsingFunction;
	}

	private void FinishReadContentAsBinary()
	{
		_readValueOffset = 0;
		if (_incReadState == IncrementalReadState.ReadContentAsBinary_OnPartialValue)
		{
			SkipPartialTextValue();
		}
		else
		{
			_parsingFunction = _nextParsingFunction;
			_nextParsingFunction = _nextNextParsingFunction;
		}
		if (_incReadState != IncrementalReadState.ReadContentAsBinary_End)
		{
			while (MoveToNextContentNode(true))
			{
			}
		}
	}

	private void FinishReadElementContentAsBinary()
	{
		FinishReadContentAsBinary();
		if (_curNode.type != XmlNodeType.EndElement)
		{
			Throw("Xml_InvalidNodeType", _curNode.type.ToString());
		}
		_outerReader.Read();
	}

	private bool ParseRootLevelWhitespace()
	{
		XmlNodeType whitespaceType = GetWhitespaceType();
		if (whitespaceType == XmlNodeType.None)
		{
			EatWhitespaces(null);
			if (_ps.chars[_ps.charPos] == '<' || _ps.charsUsed - _ps.charPos == 0 || ZeroEndingStream(_ps.charPos))
			{
				return false;
			}
		}
		else
		{
			_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
			EatWhitespaces(_stringBuilder);
			if (_ps.chars[_ps.charPos] == '<' || _ps.charsUsed - _ps.charPos == 0 || ZeroEndingStream(_ps.charPos))
			{
				if (_stringBuilder.Length > 0)
				{
					_curNode.SetValueNode(whitespaceType, _stringBuilder.ToString());
					_stringBuilder.Length = 0;
					return true;
				}
				return false;
			}
		}
		if (XmlCharType.IsCharData(_ps.chars[_ps.charPos]))
		{
			Throw("Xml_InvalidRootData");
		}
		else
		{
			ThrowInvalidChar(_ps.chars, _ps.charsUsed, _ps.charPos);
		}
		return false;
	}

	private void ParseEntityReference()
	{
		_ps.charPos++;
		_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
		_curNode.SetNamedNode(XmlNodeType.EntityReference, ParseEntityName());
	}

	private EntityType HandleEntityReference(bool P_0, EntityExpandType P_1, out int P_2)
	{
		if (_ps.charPos + 1 == _ps.charsUsed && ReadData() == 0)
		{
			Throw("Xml_UnexpectedEOF1");
		}
		if (_ps.chars[_ps.charPos + 1] == '#')
		{
			P_2 = ParseNumericCharRef(P_1 != EntityExpandType.OnlyGeneral, null, out var result);
			return result;
		}
		P_2 = ParseNamedCharRef(P_1 != EntityExpandType.OnlyGeneral, null);
		if (P_2 >= 0)
		{
			return EntityType.CharacterNamed;
		}
		if (P_1 == EntityExpandType.OnlyCharacter || (_entityHandling != EntityHandling.ExpandEntities && (!P_0 || !_validatingReaderCompatFlag)))
		{
			return EntityType.Unexpanded;
		}
		_ps.charPos++;
		int linePos = _ps.LinePos;
		int num;
		try
		{
			num = ParseName();
		}
		catch (XmlException)
		{
			Throw("Xml_ErrorParsingEntityName", _ps.LineNo, linePos);
			return EntityType.Skipped;
		}
		if (_ps.chars[num] != ';')
		{
			ThrowUnexpectedToken(num, ";");
		}
		int linePos2 = _ps.LinePos;
		string text = _nameTable.Add(_ps.chars, _ps.charPos, num - _ps.charPos);
		_ps.charPos = num + 1;
		P_2 = -1;
		EntityType result2 = HandleGeneralEntityReference(text, P_0, false, linePos2);
		_reportedBaseUri = _ps.baseUriStr;
		_reportedEncoding = _ps.encoding;
		return result2;
	}

	private EntityType HandleGeneralEntityReference(string P_0, bool P_1, bool P_2, int P_3)
	{
		IDtdEntityInfo dtdEntityInfo = null;
		if (_dtdInfo == null && _fragmentParserContext != null && _fragmentParserContext.HasDtdInfo && _dtdProcessing == DtdProcessing.Parse)
		{
			ParseDtdFromParserContext();
		}
		if (_dtdInfo == null || (dtdEntityInfo = _dtdInfo.LookupEntity(P_0)) == null)
		{
			if (_disableUndeclaredEntityCheck)
			{
				SchemaEntity schemaEntity = new SchemaEntity(new XmlQualifiedName(P_0), false);
				schemaEntity.Text = string.Empty;
				dtdEntityInfo = schemaEntity;
			}
			else
			{
				Throw("Xml_UndeclaredEntity", P_0, _ps.LineNo, P_3);
			}
		}
		if (dtdEntityInfo.IsUnparsedEntity)
		{
			if (_disableUndeclaredEntityCheck)
			{
				SchemaEntity schemaEntity2 = new SchemaEntity(new XmlQualifiedName(P_0), false);
				schemaEntity2.Text = string.Empty;
				dtdEntityInfo = schemaEntity2;
			}
			else
			{
				Throw("Xml_UnparsedEntityRef", P_0, _ps.LineNo, P_3);
			}
		}
		if (_standalone && dtdEntityInfo.IsDeclaredInExternal)
		{
			Throw("Xml_ExternalEntityInStandAloneDocument", dtdEntityInfo.Name, _ps.LineNo, P_3);
		}
		if (dtdEntityInfo.IsExternal)
		{
			if (P_1)
			{
				Throw("Xml_ExternalEntityInAttValue", P_0, _ps.LineNo, P_3);
				return EntityType.Skipped;
			}
			if (_parsingMode == ParsingMode.SkipContent)
			{
				return EntityType.Skipped;
			}
			if (IsResolverNull)
			{
				if (P_2)
				{
					PushExternalEntity(dtdEntityInfo);
					_curNode.entityId = _ps.entityId;
					return EntityType.FakeExpanded;
				}
				return EntityType.Skipped;
			}
			PushExternalEntity(dtdEntityInfo);
			_curNode.entityId = _ps.entityId;
			return EntityType.Expanded;
		}
		if (_parsingMode == ParsingMode.SkipContent)
		{
			return EntityType.Skipped;
		}
		PushInternalEntity(dtdEntityInfo);
		_curNode.entityId = _ps.entityId;
		if (!P_1 || !_validatingReaderCompatFlag)
		{
			return EntityType.Expanded;
		}
		return EntityType.ExpandedInAttribute;
	}

	private bool HandleEntityEnd(bool P_0)
	{
		if (_parsingStatesStackTop == -1)
		{
			Throw("Xml_InternalError");
		}
		if (_ps.entityResolvedManually)
		{
			_index--;
			if (P_0 && _ps.entityId != _nodes[_index].entityId)
			{
				Throw("Xml_IncompleteEntity");
			}
			_lastEntity = _ps.entity;
			PopEntity();
			return true;
		}
		if (P_0 && _ps.entityId != _nodes[_index].entityId)
		{
			Throw("Xml_IncompleteEntity");
		}
		PopEntity();
		_reportedEncoding = _ps.encoding;
		_reportedBaseUri = _ps.baseUriStr;
		return false;
	}

	private void SetupEndEntityNodeInContent()
	{
		_reportedEncoding = _ps.encoding;
		_reportedBaseUri = _ps.baseUriStr;
		_curNode = _nodes[_index];
		_curNode.SetNamedNode(XmlNodeType.EndEntity, _lastEntity.Name);
		_curNode.lineInfo.Set(_ps.lineNo, _ps.LinePos - 1);
		if (_index == 0 && _parsingFunction == ParsingFunction.ElementContent)
		{
			_parsingFunction = ParsingFunction.DocumentContent;
		}
	}

	private void SetupEndEntityNodeInAttribute()
	{
		_curNode = _nodes[_index + _attrCount + 1];
		_curNode.lineInfo.linePos += _curNode.localName.Length;
		_curNode.type = XmlNodeType.EndEntity;
	}

	private bool ParsePI()
	{
		return ParsePI(null);
	}

	private bool ParsePI(StringBuilder P_0)
	{
		if (_parsingMode == ParsingMode.Full)
		{
			_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
		}
		int num = ParseName();
		string text = _nameTable.Add(_ps.chars, _ps.charPos, num - _ps.charPos);
		if (string.Equals(text, "xml", StringComparison.OrdinalIgnoreCase))
		{
			Throw(text.Equals("xml") ? "Xml_XmlDeclNotFirst" : "Xml_InvalidPIName", text);
		}
		_ps.charPos = num;
		if (P_0 == null)
		{
			if (!_ignorePIs && _parsingMode == ParsingMode.Full)
			{
				_curNode.SetNamedNode(XmlNodeType.ProcessingInstruction, text);
			}
		}
		else
		{
			P_0.Append(text);
		}
		char c = _ps.chars[_ps.charPos];
		if (EatWhitespaces(P_0) == 0)
		{
			if (_ps.charsUsed - _ps.charPos < 2)
			{
				ReadData();
			}
			if (c != '?' || _ps.chars[_ps.charPos + 1] != '>')
			{
				Throw("Xml_BadNameChar", XmlException.BuildCharExceptionArgs(_ps.chars, _ps.charsUsed, _ps.charPos));
			}
		}
		if (ParsePIValue(out var num2, out var num3))
		{
			if (P_0 == null)
			{
				if (_ignorePIs)
				{
					return false;
				}
				if (_parsingMode == ParsingMode.Full)
				{
					_curNode.SetValue(_ps.chars, num2, num3 - num2);
				}
			}
			else
			{
				P_0.Append(_ps.chars, num2, num3 - num2);
			}
		}
		else
		{
			StringBuilder stringBuilder;
			if (P_0 == null)
			{
				if (_ignorePIs || _parsingMode != ParsingMode.Full)
				{
					int num4;
					int num5;
					while (!ParsePIValue(out num4, out num5))
					{
					}
					return false;
				}
				stringBuilder = _stringBuilder;
			}
			else
			{
				stringBuilder = P_0;
			}
			do
			{
				stringBuilder.Append(_ps.chars, num2, num3 - num2);
			}
			while (!ParsePIValue(out num2, out num3));
			stringBuilder.Append(_ps.chars, num2, num3 - num2);
			if (P_0 == null)
			{
				_curNode.SetValue(_stringBuilder.ToString());
				_stringBuilder.Length = 0;
			}
		}
		return true;
	}

	private bool ParsePIValue(out int P_0, out int P_1)
	{
		if (_ps.charsUsed - _ps.charPos < 2 && ReadData() == 0)
		{
			Throw(_ps.charsUsed, "Xml_UnexpectedEOF", "PI");
		}
		int num = _ps.charPos;
		char[] chars = _ps.chars;
		int num2 = 0;
		int num3 = -1;
		while (true)
		{
			char c;
			if (XmlCharType.IsTextChar(c = chars[num]) && c != '?')
			{
				num++;
				continue;
			}
			switch (chars[num])
			{
			case '?':
				if (chars[num + 1] == '>')
				{
					if (num2 > 0)
					{
						ShiftBuffer(num3 + num2, num3, num - num3 - num2);
						P_1 = num - num2;
					}
					else
					{
						P_1 = num;
					}
					P_0 = _ps.charPos;
					_ps.charPos = num + 2;
					return true;
				}
				if (num + 1 != _ps.charsUsed)
				{
					num++;
					continue;
				}
				break;
			case '\n':
				num++;
				OnNewLine(num);
				continue;
			case '\r':
				if (chars[num + 1] == '\n')
				{
					if (!_ps.eolNormalized && _parsingMode == ParsingMode.Full)
					{
						if (num - _ps.charPos > 0)
						{
							if (num2 == 0)
							{
								num2 = 1;
								num3 = num;
							}
							else
							{
								ShiftBuffer(num3 + num2, num3, num - num3 - num2);
								num3 = num - num2;
								num2++;
							}
						}
						else
						{
							_ps.charPos++;
						}
					}
					num += 2;
				}
				else
				{
					if (num + 1 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					if (!_ps.eolNormalized)
					{
						chars[num] = '\n';
					}
					num++;
				}
				OnNewLine(num);
				continue;
			case '\t':
			case '&':
			case '<':
			case ']':
				num++;
				continue;
			default:
			{
				if (num == _ps.charsUsed)
				{
					break;
				}
				char c2 = chars[num];
				if (XmlCharType.IsHighSurrogate(c2))
				{
					if (num + 1 == _ps.charsUsed)
					{
						break;
					}
					num++;
					if (XmlCharType.IsLowSurrogate(chars[num]))
					{
						num++;
						continue;
					}
				}
				ThrowInvalidChar(chars, _ps.charsUsed, num);
				continue;
			}
			}
			break;
		}
		if (num2 > 0)
		{
			ShiftBuffer(num3 + num2, num3, num - num3 - num2);
			P_1 = num - num2;
		}
		else
		{
			P_1 = num;
		}
		P_0 = _ps.charPos;
		_ps.charPos = num;
		return false;
	}

	private bool ParseComment()
	{
		if (_ignoreComments)
		{
			ParsingMode parsingMode = _parsingMode;
			_parsingMode = ParsingMode.SkipNode;
			ParseCDataOrComment(XmlNodeType.Comment);
			_parsingMode = parsingMode;
			return false;
		}
		ParseCDataOrComment(XmlNodeType.Comment);
		return true;
	}

	private void ParseCData()
	{
		ParseCDataOrComment(XmlNodeType.CDATA);
	}

	private void ParseCDataOrComment(XmlNodeType P_0)
	{
		if (_parsingMode == ParsingMode.Full)
		{
			_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
			if (ParseCDataOrComment(P_0, out var num, out var num2))
			{
				_curNode.SetValueNode(P_0, _ps.chars, num, num2 - num);
				return;
			}
			do
			{
				_stringBuilder.Append(_ps.chars, num, num2 - num);
			}
			while (!ParseCDataOrComment(P_0, out num, out num2));
			_stringBuilder.Append(_ps.chars, num, num2 - num);
			_curNode.SetValueNode(P_0, _stringBuilder.ToString());
			_stringBuilder.Length = 0;
		}
		else
		{
			int num3;
			int num4;
			while (!ParseCDataOrComment(P_0, out num3, out num4))
			{
			}
		}
	}

	private bool ParseCDataOrComment(XmlNodeType P_0, out int P_1, out int P_2)
	{
		if (_ps.charsUsed - _ps.charPos < 3 && ReadData() == 0)
		{
			Throw("Xml_UnexpectedEOF", (P_0 == XmlNodeType.Comment) ? "Comment" : "CDATA");
		}
		int num = _ps.charPos;
		char[] chars = _ps.chars;
		int num2 = 0;
		int num3 = -1;
		char c = ((P_0 == XmlNodeType.Comment) ? '-' : ']');
		while (true)
		{
			char c2;
			if (XmlCharType.IsTextChar(c2 = chars[num]) && c2 != c)
			{
				num++;
				continue;
			}
			if (chars[num] == c)
			{
				if (chars[num + 1] == c)
				{
					if (chars[num + 2] == '>')
					{
						if (num2 > 0)
						{
							ShiftBuffer(num3 + num2, num3, num - num3 - num2);
							P_2 = num - num2;
						}
						else
						{
							P_2 = num;
						}
						P_1 = _ps.charPos;
						_ps.charPos = num + 3;
						return true;
					}
					if (num + 2 == _ps.charsUsed)
					{
						break;
					}
					if (P_0 == XmlNodeType.Comment)
					{
						Throw(num, "Xml_InvalidCommentChars");
					}
				}
				else if (num + 1 == _ps.charsUsed)
				{
					break;
				}
				num++;
				continue;
			}
			switch (chars[num])
			{
			case '\n':
				num++;
				OnNewLine(num);
				continue;
			case '\r':
				if (chars[num + 1] == '\n')
				{
					if (!_ps.eolNormalized && _parsingMode == ParsingMode.Full)
					{
						if (num - _ps.charPos > 0)
						{
							if (num2 == 0)
							{
								num2 = 1;
								num3 = num;
							}
							else
							{
								ShiftBuffer(num3 + num2, num3, num - num3 - num2);
								num3 = num - num2;
								num2++;
							}
						}
						else
						{
							_ps.charPos++;
						}
					}
					num += 2;
				}
				else
				{
					if (num + 1 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					if (!_ps.eolNormalized)
					{
						chars[num] = '\n';
					}
					num++;
				}
				OnNewLine(num);
				continue;
			case '\t':
			case '&':
			case '<':
			case ']':
				num++;
				continue;
			default:
			{
				if (num == _ps.charsUsed)
				{
					break;
				}
				char c3 = chars[num];
				if (XmlCharType.IsHighSurrogate(c3))
				{
					if (num + 1 == _ps.charsUsed)
					{
						break;
					}
					num++;
					if (XmlCharType.IsLowSurrogate(chars[num]))
					{
						num++;
						continue;
					}
				}
				ThrowInvalidChar(chars, _ps.charsUsed, num);
				break;
			}
			}
			break;
		}
		if (num2 > 0)
		{
			ShiftBuffer(num3 + num2, num3, num - num3 - num2);
			P_2 = num - num2;
		}
		else
		{
			P_2 = num;
		}
		P_1 = _ps.charPos;
		_ps.charPos = num;
		return false;
	}

	private bool ParseDoctypeDecl()
	{
		if (_dtdProcessing == DtdProcessing.Prohibit)
		{
			ThrowWithoutLineInfo(_v1Compat ? "Xml_DtdIsProhibited" : "Xml_DtdIsProhibitedEx");
		}
		while (_ps.charsUsed - _ps.charPos < 8)
		{
			if (ReadData() == 0)
			{
				Throw("Xml_UnexpectedEOF", "DOCTYPE");
			}
		}
		if (!XmlConvert.StrEqual(_ps.chars, _ps.charPos, 7, "DOCTYPE"))
		{
			ThrowUnexpectedToken((!_rootElementParsed && _dtdInfo == null) ? "DOCTYPE" : "<!--");
		}
		if (!XmlCharType.IsWhiteSpace(_ps.chars[_ps.charPos + 7]))
		{
			ThrowExpectingWhitespace(_ps.charPos + 7);
		}
		if (_dtdInfo != null)
		{
			Throw(_ps.charPos - 2, "Xml_MultipleDTDsProvided");
		}
		if (_rootElementParsed)
		{
			Throw(_ps.charPos - 2, "Xml_DtdAfterRootElement");
		}
		_ps.charPos += 8;
		EatWhitespaces(null);
		if (_dtdProcessing == DtdProcessing.Parse)
		{
			_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
			ParseDtd();
			_nextParsingFunction = _parsingFunction;
			_parsingFunction = ParsingFunction.ResetAttributesRootLevel;
			return true;
		}
		SkipDtd();
		return false;
	}

	private void ParseDtd()
	{
		IDtdParser dtdParser = DtdParser.Create();
		_dtdInfo = dtdParser.ParseInternalDtd(new DtdParserProxy(this), true);
		if ((_validatingReaderCompatFlag || !_v1Compat) && (_dtdInfo.HasDefaultAttributes || _dtdInfo.HasNonCDataAttributes))
		{
			_addDefaultAttributesAndNormalize = true;
		}
		_curNode.SetNamedNode(XmlNodeType.DocumentType, _dtdInfo.Name.ToString(), string.Empty, null);
		_curNode.SetValue(_dtdInfo.InternalDtdSubset);
	}

	private void SkipDtd()
	{
		int num;
		int charPos = ParseQName(out num);
		_ps.charPos = charPos;
		EatWhitespaces(null);
		if (_ps.chars[_ps.charPos] == 'P')
		{
			while (_ps.charsUsed - _ps.charPos < 6)
			{
				if (ReadData() == 0)
				{
					Throw("Xml_UnexpectedEOF1");
				}
			}
			if (!XmlConvert.StrEqual(_ps.chars, _ps.charPos, 6, "PUBLIC"))
			{
				ThrowUnexpectedToken("PUBLIC");
			}
			_ps.charPos += 6;
			if (EatWhitespaces(null) == 0)
			{
				ThrowExpectingWhitespace(_ps.charPos);
			}
			SkipPublicOrSystemIdLiteral();
			if (EatWhitespaces(null) == 0)
			{
				ThrowExpectingWhitespace(_ps.charPos);
			}
			SkipPublicOrSystemIdLiteral();
			EatWhitespaces(null);
		}
		else if (_ps.chars[_ps.charPos] == 'S')
		{
			while (_ps.charsUsed - _ps.charPos < 6)
			{
				if (ReadData() == 0)
				{
					Throw("Xml_UnexpectedEOF1");
				}
			}
			if (!XmlConvert.StrEqual(_ps.chars, _ps.charPos, 6, "SYSTEM"))
			{
				ThrowUnexpectedToken("SYSTEM");
			}
			_ps.charPos += 6;
			if (EatWhitespaces(null) == 0)
			{
				ThrowExpectingWhitespace(_ps.charPos);
			}
			SkipPublicOrSystemIdLiteral();
			EatWhitespaces(null);
		}
		else if (_ps.chars[_ps.charPos] != '[' && _ps.chars[_ps.charPos] != '>')
		{
			Throw("Xml_ExpectExternalOrClose");
		}
		if (_ps.chars[_ps.charPos] == '[')
		{
			_ps.charPos++;
			SkipUntil(']', true);
			EatWhitespaces(null);
			if (_ps.chars[_ps.charPos] != '>')
			{
				ThrowUnexpectedToken(">");
			}
		}
		else if (_ps.chars[_ps.charPos] == '>')
		{
			_curNode.SetValue(string.Empty);
		}
		else
		{
			Throw("Xml_ExpectSubOrClose");
		}
		_ps.charPos++;
	}

	private void SkipPublicOrSystemIdLiteral()
	{
		char c = _ps.chars[_ps.charPos];
		if (c != '"' && c != '\'')
		{
			ThrowUnexpectedToken("\"", "'");
		}
		_ps.charPos++;
		SkipUntil(c, false);
	}

	private void SkipUntil(char P_0, bool P_1)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		char c = '"';
		char[] chars = _ps.chars;
		int num = _ps.charPos;
		while (true)
		{
			char c2;
			if (XmlCharType.IsAttributeValueChar(c2 = chars[num]) && chars[num] != P_0 && c2 != '-' && c2 != '?')
			{
				num++;
				continue;
			}
			if (c2 == P_0 && !flag)
			{
				break;
			}
			_ps.charPos = num;
			switch (c2)
			{
			case '\n':
				num++;
				OnNewLine(num);
				continue;
			case '\r':
				if (chars[num + 1] == '\n')
				{
					num += 2;
				}
				else
				{
					if (num + 1 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					num++;
				}
				OnNewLine(num);
				continue;
			case '<':
				if (chars[num + 1] == '?')
				{
					if (P_1 && !flag && !flag2)
					{
						flag3 = true;
						num += 2;
						continue;
					}
				}
				else if (chars[num + 1] == '!')
				{
					if (num + 3 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					if (chars[num + 2] == '-' && chars[num + 3] == '-' && P_1 && !flag && !flag3)
					{
						flag2 = true;
						num += 4;
						continue;
					}
				}
				else if (num + 1 >= _ps.charsUsed && !_ps.isEof)
				{
					break;
				}
				num++;
				continue;
			case '-':
				if (flag2)
				{
					if (num + 2 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					if (chars[num + 1] == '-' && chars[num + 2] == '>')
					{
						flag2 = false;
						num += 2;
						continue;
					}
				}
				num++;
				continue;
			case '?':
				if (flag3)
				{
					if (num + 1 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					if (chars[num + 1] == '>')
					{
						flag3 = false;
						num++;
						continue;
					}
				}
				num++;
				continue;
			case '\t':
			case '&':
			case '>':
			case ']':
				num++;
				continue;
			case '"':
			case '\'':
				if (flag)
				{
					if (c == c2)
					{
						flag = false;
					}
				}
				else if (P_1 && !flag2 && !flag3)
				{
					flag = true;
					c = c2;
				}
				num++;
				continue;
			default:
			{
				if (num == _ps.charsUsed)
				{
					break;
				}
				char c3 = chars[num];
				if (XmlCharType.IsHighSurrogate(c3))
				{
					if (num + 1 == _ps.charsUsed)
					{
						break;
					}
					num++;
					if (XmlCharType.IsLowSurrogate(chars[num]))
					{
						num++;
						continue;
					}
				}
				ThrowInvalidChar(chars, _ps.charsUsed, num);
				break;
			}
			}
			if (ReadData() == 0)
			{
				if (_ps.charsUsed - _ps.charPos > 0)
				{
					if (_ps.chars[_ps.charPos] != '\r')
					{
						Throw("Xml_UnexpectedEOF1");
					}
				}
				else
				{
					Throw("Xml_UnexpectedEOF1");
				}
			}
			chars = _ps.chars;
			num = _ps.charPos;
		}
		_ps.charPos = num + 1;
	}

	private int EatWhitespaces(StringBuilder P_0)
	{
		int num = _ps.charPos;
		int num2 = 0;
		char[] chars = _ps.chars;
		while (true)
		{
			switch (chars[num])
			{
			case '\n':
				num++;
				OnNewLine(num);
				continue;
			case '\r':
				if (chars[num + 1] == '\n')
				{
					int num4 = num - _ps.charPos;
					if (P_0 != null && !_ps.eolNormalized)
					{
						if (num4 > 0)
						{
							P_0.Append(chars, _ps.charPos, num4);
							num2 += num4;
						}
						_ps.charPos = num + 1;
					}
					num += 2;
				}
				else
				{
					if (num + 1 >= _ps.charsUsed && !_ps.isEof)
					{
						break;
					}
					if (!_ps.eolNormalized)
					{
						chars[num] = '\n';
					}
					num++;
				}
				OnNewLine(num);
				continue;
			case '\t':
			case ' ':
				num++;
				continue;
			default:
				if (num != _ps.charsUsed)
				{
					int num3 = num - _ps.charPos;
					if (num3 > 0)
					{
						P_0?.Append(_ps.chars, _ps.charPos, num3);
						_ps.charPos = num;
						num2 += num3;
					}
					return num2;
				}
				break;
			}
			int num5 = num - _ps.charPos;
			if (num5 > 0)
			{
				P_0?.Append(_ps.chars, _ps.charPos, num5);
				_ps.charPos = num;
				num2 += num5;
			}
			if (ReadData() == 0)
			{
				if (_ps.charsUsed - _ps.charPos == 0)
				{
					break;
				}
				if (_ps.chars[_ps.charPos] != '\r')
				{
					Throw("Xml_UnexpectedEOF1");
				}
			}
			num = _ps.charPos;
			chars = _ps.chars;
		}
		return num2;
	}

	private int ParseCharRefInline(int P_0, out int P_1, out EntityType P_2)
	{
		if (_ps.chars[P_0 + 1] == '#')
		{
			return ParseNumericCharRefInline(P_0, true, null, out P_1, out P_2);
		}
		P_1 = 1;
		P_2 = EntityType.CharacterNamed;
		return ParseNamedCharRefInline(P_0, true, null);
	}

	private int ParseNumericCharRef(bool P_0, StringBuilder P_1, out EntityType P_2)
	{
		int num2;
		int num3;
		while (true)
		{
			int num = (num2 = ParseNumericCharRefInline(_ps.charPos, P_0, P_1, out num3, out P_2));
			if (num != -2)
			{
				break;
			}
			if (ReadData() == 0)
			{
				Throw("Xml_UnexpectedEOF");
			}
		}
		if (P_0)
		{
			_ps.charPos = num2 - num3;
		}
		return num2;
	}

	private int ParseNumericCharRefInline(int P_0, bool P_1, StringBuilder P_2, out int P_3, out EntityType P_4)
	{
		int num = 0;
		string text = null;
		char[] chars = _ps.chars;
		int i = P_0 + 2;
		P_3 = 0;
		int num2 = 0;
		try
		{
			if (chars[i] == 'x')
			{
				i++;
				num2 = i;
				text = "Xml_BadHexEntity";
				while (true)
				{
					int num3 = System.HexConverter.FromChar(chars[i]);
					if (num3 == 255)
					{
						break;
					}
					num = checked(num * 16 + num3);
					i++;
				}
				P_4 = EntityType.CharacterHex;
			}
			else
			{
				if (i >= _ps.charsUsed)
				{
					P_4 = EntityType.Skipped;
					return -2;
				}
				num2 = i;
				text = "Xml_BadDecimalEntity";
				for (; char.IsAsciiDigit(chars[i]); i++)
				{
					num = checked(num * 10 + chars[i] - 48);
				}
				P_4 = EntityType.CharacterDec;
			}
		}
		catch (OverflowException ex)
		{
			_ps.charPos = i;
			P_4 = EntityType.Skipped;
			Throw("Xml_CharEntityOverflow", (string)null, (Exception)ex);
		}
		if (chars[i] != ';' || num2 == i)
		{
			if (i == _ps.charsUsed)
			{
				return -2;
			}
			Throw(i, text);
		}
		if (num <= 65535)
		{
			char c = (char)num;
			if (!XmlCharType.IsCharData(c) && ((_v1Compat && _normalize) || (!_v1Compat && _checkCharacters)))
			{
				Throw((_ps.chars[P_0 + 2] == 'x') ? (P_0 + 3) : (P_0 + 2), "Xml_InvalidCharacter", XmlException.BuildCharExceptionArgs(c, '\0'));
			}
			if (P_1)
			{
				P_2?.Append(_ps.chars, _ps.charPos, i - _ps.charPos + 1);
				chars[i] = c;
			}
			P_3 = 1;
			return i + 1;
		}
		XmlCharType.SplitSurrogateChar(num, out var c2, out var c3);
		if (_normalize && (!XmlCharType.IsHighSurrogate(c3) || !XmlCharType.IsLowSurrogate(c2)))
		{
			Throw((_ps.chars[P_0 + 2] == 'x') ? (P_0 + 3) : (P_0 + 2), "Xml_InvalidCharacter", XmlException.BuildCharExceptionArgs(c3, c2));
		}
		if (P_1)
		{
			P_2?.Append(_ps.chars, _ps.charPos, i - _ps.charPos + 1);
			chars[i - 1] = c3;
			chars[i] = c2;
		}
		P_3 = 2;
		return i + 1;
	}

	private int ParseNamedCharRef(bool P_0, StringBuilder P_1)
	{
		do
		{
			int num;
			switch (num = ParseNamedCharRefInline(_ps.charPos, P_0, P_1))
			{
			case -1:
				return -1;
			case -2:
				continue;
			}
			if (P_0)
			{
				_ps.charPos = num - 1;
			}
			return num;
		}
		while (ReadData() != 0);
		return -1;
	}

	private int ParseNamedCharRefInline(int P_0, bool P_1, StringBuilder P_2)
	{
		int num = P_0 + 1;
		char[] chars = _ps.chars;
		char c = chars[num];
		char c2;
		if ((uint)c <= 103u)
		{
			if (c != 'a')
			{
				if (c != 'g')
				{
					goto IL_0170;
				}
				if (_ps.charsUsed - num >= 3)
				{
					if (chars[num + 1] == 't' && chars[num + 2] == ';')
					{
						num += 3;
						c2 = '>';
						goto IL_0175;
					}
					return -1;
				}
			}
			else
			{
				num++;
				if (chars[num] == 'm')
				{
					if (_ps.charsUsed - num >= 3)
					{
						if (chars[num + 1] == 'p' && chars[num + 2] == ';')
						{
							num += 3;
							c2 = '&';
							goto IL_0175;
						}
						return -1;
					}
				}
				else if (chars[num] == 'p')
				{
					if (_ps.charsUsed - num >= 4)
					{
						if (chars[num + 1] == 'o' && chars[num + 2] == 's' && chars[num + 3] == ';')
						{
							num += 4;
							c2 = '\'';
							goto IL_0175;
						}
						return -1;
					}
				}
				else if (num < _ps.charsUsed)
				{
					return -1;
				}
			}
			goto IL_0172;
		}
		if (c != 'l')
		{
			if (c != 'q')
			{
				goto IL_0170;
			}
			if (_ps.charsUsed - num < 5)
			{
				goto IL_0172;
			}
			if (chars[num + 1] != 'u' || chars[num + 2] != 'o' || chars[num + 3] != 't' || chars[num + 4] != ';')
			{
				return -1;
			}
			num += 5;
			c2 = '"';
		}
		else
		{
			if (_ps.charsUsed - num < 3)
			{
				goto IL_0172;
			}
			if (chars[num + 1] != 't' || chars[num + 2] != ';')
			{
				return -1;
			}
			num += 3;
			c2 = '<';
		}
		goto IL_0175;
		IL_0170:
		return -1;
		IL_0172:
		return -2;
		IL_0175:
		if (P_1)
		{
			P_2?.Append(_ps.chars, _ps.charPos, num - _ps.charPos);
			_ps.chars[num - 1] = c2;
		}
		return num;
	}

	private int ParseName()
	{
		int num;
		return ParseQName(false, 0, out num);
	}

	private int ParseQName(out int P_0)
	{
		return ParseQName(true, 0, out P_0);
	}

	private int ParseQName(bool P_0, int P_1, out int P_2)
	{
		int num = -1;
		int num2 = _ps.charPos + P_1;
		while (true)
		{
			char[] chars = _ps.chars;
			if (XmlCharType.IsStartNCNameSingleChar(chars[num2]))
			{
				num2++;
			}
			else
			{
				if (num2 + 1 >= _ps.charsUsed)
				{
					if (ReadDataInName(ref num2))
					{
						continue;
					}
					Throw(num2, "Xml_UnexpectedEOF", "Name");
				}
				if (chars[num2] != ':' || _supportNamespaces)
				{
					Throw(num2, "Xml_BadStartNameChar", XmlException.BuildCharExceptionArgs(chars, _ps.charsUsed, num2));
				}
			}
			while (true)
			{
				if (XmlCharType.IsNCNameSingleChar(chars[num2]))
				{
					num2++;
					continue;
				}
				if (chars[num2] == ':')
				{
					if (_supportNamespaces)
					{
						break;
					}
					num = num2 - _ps.charPos;
					num2++;
					continue;
				}
				if (num2 == _ps.charsUsed)
				{
					if (ReadDataInName(ref num2))
					{
						chars = _ps.chars;
						continue;
					}
					Throw(num2, "Xml_UnexpectedEOF", "Name");
				}
				P_2 = ((num == -1) ? (-1) : (_ps.charPos + num));
				return num2;
			}
			if (num != -1 || !P_0)
			{
				Throw(num2, "Xml_BadNameChar", XmlException.BuildCharExceptionArgs(':', '\0'));
			}
			num = num2 - _ps.charPos;
			num2++;
		}
	}

	private bool ReadDataInName(ref int P_0)
	{
		int num = P_0 - _ps.charPos;
		bool result = ReadData() != 0;
		P_0 = _ps.charPos + num;
		return result;
	}

	private string ParseEntityName()
	{
		int num;
		try
		{
			num = ParseName();
		}
		catch (XmlException)
		{
			Throw("Xml_ErrorParsingEntityName");
			return null;
		}
		if (_ps.chars[num] != ';')
		{
			Throw("Xml_ErrorParsingEntityName");
		}
		string result = _nameTable.Add(_ps.chars, _ps.charPos, num - _ps.charPos);
		_ps.charPos = num + 1;
		return result;
	}

	private NodeData AddNode(int P_0, int P_1)
	{
		NodeData nodeData = _nodes[P_0];
		if (nodeData != null)
		{
			nodeData.depth = P_1;
			return nodeData;
		}
		return AllocNode(P_0, P_1);
	}

	private NodeData AllocNode(int P_0, int P_1)
	{
		if (P_0 >= _nodes.Length - 1)
		{
			NodeData[] array = new NodeData[_nodes.Length * 2];
			Array.Copy(_nodes, array, _nodes.Length);
			_nodes = array;
		}
		ref NodeData reference = ref _nodes[P_0];
		NodeData nodeData = reference ?? (reference = new NodeData());
		nodeData.depth = P_1;
		return nodeData;
	}

	private NodeData AddAttributeNoChecks(string P_0, int P_1)
	{
		NodeData nodeData = AddNode(_index + _attrCount + 1, P_1);
		nodeData.SetNamedNode(XmlNodeType.Attribute, _nameTable.Add(P_0));
		_attrCount++;
		return nodeData;
	}

	private NodeData AddAttribute(int P_0, int P_1)
	{
		if (P_1 == -1 || !_supportNamespaces)
		{
			string text = _nameTable.Add(_ps.chars, _ps.charPos, P_0 - _ps.charPos);
			return AddAttribute(text, string.Empty, text);
		}
		_attrNeedNamespaceLookup = true;
		int charPos = _ps.charPos;
		int num = P_1 - charPos;
		if (num == _lastPrefix.Length && XmlConvert.StrEqual(_ps.chars, charPos, num, _lastPrefix))
		{
			return AddAttribute(_nameTable.Add(_ps.chars, P_1 + 1, P_0 - P_1 - 1), _lastPrefix, null);
		}
		string text2 = (_lastPrefix = _nameTable.Add(_ps.chars, charPos, num));
		return AddAttribute(_nameTable.Add(_ps.chars, P_1 + 1, P_0 - P_1 - 1), text2, null);
	}

	private NodeData AddAttribute(string P_0, string P_1, string P_2)
	{
		NodeData nodeData = AddNode(_index + _attrCount + 1, _index + 1);
		nodeData.SetNamedNode(XmlNodeType.Attribute, P_0, P_1, P_2);
		int num = 1 << (P_0[0] & 0x1F);
		if ((_attrHashtable & num) == 0)
		{
			_attrHashtable |= num;
		}
		else if (_attrDuplWalkCount < 250)
		{
			_attrDuplWalkCount++;
			for (int i = _index + 1; i < _index + _attrCount + 1; i++)
			{
				NodeData nodeData2 = _nodes[i];
				if (Ref.Equal(nodeData2.localName, nodeData.localName))
				{
					_attrDuplWalkCount = 250;
					break;
				}
			}
		}
		_attrCount++;
		return nodeData;
	}

	private void PopElementContext()
	{
		_namespaceManager.PopScope();
		if (_curNode.xmlContextPushed)
		{
			PopXmlContext();
		}
	}

	private void OnNewLine(int P_0)
	{
		_ps.lineNo++;
		_ps.lineStartPos = P_0 - 1;
	}

	private void OnEof()
	{
		_curNode = _nodes[0];
		_curNode.Clear(XmlNodeType.None);
		_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
		_parsingFunction = ParsingFunction.Eof;
		_readState = ReadState.EndOfFile;
		_reportedEncoding = null;
	}

	private string LookupNamespace(NodeData P_0)
	{
		string text = _namespaceManager.LookupNamespace(P_0.prefix);
		if (text != null)
		{
			return text;
		}
		Throw("Xml_UnknownNs", P_0.prefix, P_0.LineNo, P_0.LinePos);
		return null;
	}

	private void AddNamespace(string P_0, string P_1, NodeData P_2)
	{
		if (P_1 == "http://www.w3.org/2000/xmlns/")
		{
			if (Ref.Equal(P_0, _xmlNs))
			{
				Throw("Xml_XmlnsPrefix", P_2.lineInfo2.lineNo, P_2.lineInfo2.linePos);
			}
			else
			{
				Throw("Xml_NamespaceDeclXmlXmlns", P_0, P_2.lineInfo2.lineNo, P_2.lineInfo2.linePos);
			}
		}
		else if (P_1 == "http://www.w3.org/XML/1998/namespace" && !Ref.Equal(P_0, _xml) && !_v1Compat)
		{
			Throw("Xml_NamespaceDeclXmlXmlns", P_0, P_2.lineInfo2.lineNo, P_2.lineInfo2.linePos);
		}
		if (P_1.Length == 0 && P_0.Length > 0)
		{
			Throw("Xml_BadNamespaceDecl", P_2.lineInfo.lineNo, P_2.lineInfo.linePos);
		}
		try
		{
			_namespaceManager.AddNamespace(P_0, P_1);
		}
		catch (ArgumentException ex)
		{
			ReThrow(ex, P_2.lineInfo.lineNo, P_2.lineInfo.linePos);
		}
	}

	private void ResetAttributes()
	{
		if (_fullAttrCleanup)
		{
			FullAttributeCleanup();
		}
		_curAttrIndex = -1;
		_attrCount = 0;
		_attrHashtable = 0;
		_attrDuplWalkCount = 0;
	}

	private void FullAttributeCleanup()
	{
		for (int i = _index + 1; i < _index + _attrCount + 1; i++)
		{
			NodeData nodeData = _nodes[i];
			nodeData.nextAttrValueChunk = null;
			nodeData.IsDefaultAttribute = false;
		}
		_fullAttrCleanup = false;
	}

	private void PushXmlContext()
	{
		_xmlContext = new XmlContext(_xmlContext);
		_curNode.xmlContextPushed = true;
	}

	private void PopXmlContext()
	{
		_xmlContext = _xmlContext.previousContext;
		_curNode.xmlContextPushed = false;
	}

	private XmlNodeType GetWhitespaceType()
	{
		if (_whitespaceHandling != WhitespaceHandling.None)
		{
			if (_xmlContext.xmlSpace == XmlSpace.Preserve)
			{
				return XmlNodeType.SignificantWhitespace;
			}
			if (_whitespaceHandling == WhitespaceHandling.All)
			{
				return XmlNodeType.Whitespace;
			}
		}
		return XmlNodeType.None;
	}

	private XmlNodeType GetTextNodeType(int P_0)
	{
		if (P_0 > 32)
		{
			return XmlNodeType.Text;
		}
		return GetWhitespaceType();
	}

	private void PushExternalEntityOrSubset(string P_0, string P_1, Uri P_2, string P_3)
	{
		Uri uri;
		if (!string.IsNullOrEmpty(P_0))
		{
			try
			{
				uri = _xmlResolver.ResolveUri(P_2, P_0);
				if (OpenAndPush(uri))
				{
					return;
				}
			}
			catch (Exception)
			{
			}
		}
		uri = _xmlResolver.ResolveUri(P_2, P_1);
		try
		{
			if (OpenAndPush(uri))
			{
				return;
			}
		}
		catch (Exception ex2)
		{
			if (_v1Compat)
			{
				throw;
			}
			string message = ex2.Message;
			Throw(new XmlException((P_3 == null) ? "Xml_ErrorOpeningExternalDtd" : "Xml_ErrorOpeningExternalEntity", new string[2]
			{
				uri.ToString(),
				message
			}, ex2, 0, 0));
		}
		if (P_3 == null)
		{
			ThrowWithoutLineInfo("Xml_CannotResolveExternalSubset", new string[2]
			{
				P_0 ?? string.Empty,
				P_1
			}, null);
		}
		else
		{
			Throw((_dtdProcessing == DtdProcessing.Ignore) ? "Xml_CannotResolveEntityDtdIgnored" : "Xml_CannotResolveEntity", P_3);
		}
	}

	private bool OpenAndPush(Uri P_0)
	{
		if (_xmlResolver.SupportsType(P_0, typeof(TextReader)))
		{
			TextReader textReader = (TextReader)_xmlResolver.GetEntity(P_0, null, typeof(TextReader));
			if (textReader == null)
			{
				return false;
			}
			PushParsingState();
			InitTextReaderInput(P_0.ToString(), P_0, textReader);
		}
		else
		{
			Stream stream = (Stream)_xmlResolver.GetEntity(P_0, null, typeof(Stream));
			if (stream == null)
			{
				return false;
			}
			PushParsingState();
			InitStreamInput(P_0, stream, null);
		}
		return true;
	}

	private bool PushExternalEntity(IDtdEntityInfo P_0)
	{
		if (!IsResolverNull)
		{
			Uri uri = null;
			if (!string.IsNullOrEmpty(P_0.BaseUriString))
			{
				uri = _xmlResolver.ResolveUri(null, P_0.BaseUriString);
			}
			PushExternalEntityOrSubset(P_0.PublicId, P_0.SystemId, uri, P_0.Name);
			RegisterEntity(P_0);
			int charPos = _ps.charPos;
			if (_v1Compat)
			{
				EatWhitespaces(null);
			}
			if (!ParseXmlDeclaration(true))
			{
				_ps.charPos = charPos;
			}
			return true;
		}
		Encoding encoding = _ps.encoding;
		PushParsingState();
		InitStringInput(P_0.SystemId, encoding, string.Empty);
		RegisterEntity(P_0);
		RegisterConsumedCharacters(0L, true);
		return false;
	}

	private void PushInternalEntity(IDtdEntityInfo P_0)
	{
		Encoding encoding = _ps.encoding;
		PushParsingState();
		InitStringInput(P_0.DeclaredUriString ?? string.Empty, encoding, P_0.Text);
		RegisterEntity(P_0);
		_ps.lineNo = P_0.LineNumber;
		_ps.lineStartPos = -P_0.LinePosition - 1;
		_ps.eolNormalized = true;
		RegisterConsumedCharacters(P_0.Text.Length, true);
	}

	private void PopEntity()
	{
		_ps.stream?.Dispose();
		UnregisterEntity();
		PopParsingState();
		_curNode.entityId = _ps.entityId;
	}

	private void RegisterEntity(IDtdEntityInfo P_0)
	{
		if (_currentEntities != null && _currentEntities.ContainsKey(P_0))
		{
			Throw(P_0.IsParameterEntity ? "Xml_RecursiveParEntity" : "Xml_RecursiveGenEntity", P_0.Name, _parsingStatesStack[_parsingStatesStackTop].LineNo, _parsingStatesStack[_parsingStatesStackTop].LinePos);
		}
		_ps.entity = P_0;
		_ps.entityId = _nextEntityId++;
		if (P_0 != null)
		{
			if (_currentEntities == null)
			{
				_currentEntities = new Dictionary<IDtdEntityInfo, IDtdEntityInfo>();
			}
			_currentEntities.Add(P_0, P_0);
		}
	}

	private void UnregisterEntity()
	{
		if (_ps.entity != null)
		{
			_currentEntities.Remove(_ps.entity);
		}
	}

	private void PushParsingState()
	{
		if (_parsingStatesStack == null)
		{
			_parsingStatesStack = new ParsingState[2];
		}
		else if (_parsingStatesStackTop + 1 == _parsingStatesStack.Length)
		{
			ParsingState[] array = new ParsingState[_parsingStatesStack.Length * 2];
			Array.Copy(_parsingStatesStack, array, _parsingStatesStack.Length);
			_parsingStatesStack = array;
		}
		_parsingStatesStackTop++;
		_parsingStatesStack[_parsingStatesStackTop] = _ps;
		_ps.Clear();
	}

	private void PopParsingState()
	{
		_ps.Close(true);
		_ps = _parsingStatesStack[_parsingStatesStackTop--];
	}

	private int IncrementalRead()
	{
		int num = 0;
		int num3;
		while (true)
		{
			int num2 = _incReadLeftEndPos - _incReadLeftStartPos;
			if (num2 > 0)
			{
				try
				{
					num3 = _incReadDecoder.Decode(_ps.chars, _incReadLeftStartPos, num2);
				}
				catch (XmlException ex)
				{
					ReThrow(ex, _incReadLineInfo.lineNo, _incReadLineInfo.linePos);
					return 0;
				}
				if (num3 < num2)
				{
					_incReadLeftStartPos += num3;
					_incReadLineInfo.linePos += num3;
					return num3;
				}
				_incReadLeftStartPos = 0;
				_incReadLeftEndPos = 0;
				_incReadLineInfo.linePos += num3;
				if (_incReadDecoder.IsFull)
				{
					break;
				}
			}
			while (true)
			{
				int charPos;
				int i;
				switch (_incReadState)
				{
				case IncrementalReadState.PI:
					if (ParsePIValue(out charPos, out i))
					{
						_ps.charPos -= 2;
						_incReadState = IncrementalReadState.Text;
					}
					break;
				case IncrementalReadState.Comment:
					if (ParseCDataOrComment(XmlNodeType.Comment, out charPos, out i))
					{
						_ps.charPos -= 3;
						_incReadState = IncrementalReadState.Text;
					}
					break;
				case IncrementalReadState.CDATA:
					if (ParseCDataOrComment(XmlNodeType.CDATA, out charPos, out i))
					{
						_ps.charPos -= 3;
						_incReadState = IncrementalReadState.Text;
					}
					break;
				case IncrementalReadState.EndElement:
					_parsingFunction = ParsingFunction.PopElementContext;
					_nextParsingFunction = ((_index <= 0 && _fragmentType == XmlNodeType.Document) ? ParsingFunction.DocumentContent : ParsingFunction.ElementContent);
					_outerReader.Read();
					_incReadState = IncrementalReadState.End;
					goto case IncrementalReadState.End;
				case IncrementalReadState.End:
					return num;
				case IncrementalReadState.ReadData:
					if (ReadData() == 0)
					{
						ThrowUnclosedElements();
					}
					_incReadState = IncrementalReadState.Text;
					goto default;
				default:
				{
					char[] chars = _ps.chars;
					charPos = _ps.charPos;
					i = charPos;
					while (true)
					{
						_incReadLineInfo.Set(_ps.LineNo, _ps.LinePos);
						if (_incReadState == IncrementalReadState.Attributes)
						{
							char c;
							while (XmlCharType.IsAttributeValueChar(c = chars[i]) && c != '/')
							{
								i++;
							}
						}
						else
						{
							for (; XmlCharType.IsAttributeValueChar(chars[i]); i++)
							{
							}
						}
						if (chars[i] == '&' || chars[i] == '\t')
						{
							i++;
							continue;
						}
						if (i - charPos <= 0)
						{
							char c2 = chars[i];
							if ((uint)c2 <= 34u)
							{
								if (c2 == '\n')
								{
									i++;
									OnNewLine(i);
									continue;
								}
								if (c2 == '\r')
								{
									if (chars[i + 1] == '\n')
									{
										i += 2;
									}
									else
									{
										if (i + 1 >= _ps.charsUsed)
										{
											goto IL_064d;
										}
										i++;
									}
									OnNewLine(i);
									continue;
								}
								if (c2 == '"')
								{
									goto IL_05eb;
								}
							}
							else if ((uint)c2 <= 47u)
							{
								if (c2 == '\'')
								{
									goto IL_05eb;
								}
								if (c2 == '/')
								{
									if (_incReadState == IncrementalReadState.Attributes)
									{
										if (_ps.charsUsed - i < 2)
										{
											goto IL_064d;
										}
										if (chars[i + 1] == '>')
										{
											_incReadState = IncrementalReadState.Text;
											_incReadDepth--;
										}
									}
									i++;
									continue;
								}
							}
							else
							{
								if (c2 == '<')
								{
									if (_incReadState != IncrementalReadState.Text)
									{
										i++;
										continue;
									}
									if (_ps.charsUsed - i < 2)
									{
										goto IL_064d;
									}
									char c3 = chars[i + 1];
									if (c3 != '!')
									{
										int num5;
										switch (c3)
										{
										case '?':
											i += 2;
											_incReadState = IncrementalReadState.PI;
											break;
										case '/':
										{
											int num6 = ParseQName(true, 2, out num5);
											if (!XmlConvert.StrEqual(chars, _ps.charPos + 2, num6 - _ps.charPos - 2, _curNode.GetNameWPrefix(_nameTable)) || (_ps.chars[num6] != '>' && !XmlCharType.IsWhiteSpace(_ps.chars[num6])))
											{
												i = num6;
												charPos = _ps.charPos;
												chars = _ps.chars;
												continue;
											}
											num5 = --_incReadDepth;
											if (num5 > 0)
											{
												i = num6 + 1;
												continue;
											}
											_ps.charPos = num6;
											if (XmlCharType.IsWhiteSpace(_ps.chars[num6]))
											{
												EatWhitespaces(null);
											}
											if (_ps.chars[_ps.charPos] != '>')
											{
												ThrowUnexpectedToken(">");
											}
											goto end_IL_00b7;
										}
										default:
										{
											int num4 = ParseQName(true, 1, out num5);
											if (XmlConvert.StrEqual(_ps.chars, _ps.charPos + 1, num4 - _ps.charPos - 1, _curNode.localName) && (_ps.chars[num4] == '>' || _ps.chars[num4] == '/' || XmlCharType.IsWhiteSpace(_ps.chars[num4])))
											{
												_incReadDepth++;
												_incReadState = IncrementalReadState.Attributes;
												i = num4;
												break;
											}
											i = num4;
											charPos = _ps.charPos;
											chars = _ps.chars;
											continue;
										}
										}
									}
									else
									{
										if (_ps.charsUsed - i < 4)
										{
											goto IL_064d;
										}
										if (chars[i + 2] == '-' && chars[i + 3] == '-')
										{
											i += 4;
											_incReadState = IncrementalReadState.Comment;
										}
										else
										{
											if (_ps.charsUsed - i < 9)
											{
												goto IL_064d;
											}
											if (!XmlConvert.StrEqual(chars, i + 2, 7, "[CDATA["))
											{
												continue;
											}
											i += 9;
											_incReadState = IncrementalReadState.CDATA;
										}
									}
									goto IL_0654;
								}
								if (c2 == '>')
								{
									if (_incReadState == IncrementalReadState.Attributes)
									{
										_incReadState = IncrementalReadState.Text;
									}
									i++;
									continue;
								}
							}
							if (i != _ps.charsUsed)
							{
								i++;
								continue;
							}
							goto IL_064d;
						}
						goto IL_0654;
						IL_0654:
						_ps.charPos = i;
						break;
						IL_064d:
						_incReadState = IncrementalReadState.ReadData;
						goto IL_0654;
						IL_05eb:
						switch (_incReadState)
						{
						case IncrementalReadState.AttributeValue:
							if (chars[i] == _curNode.quoteChar)
							{
								_incReadState = IncrementalReadState.Attributes;
							}
							break;
						case IncrementalReadState.Attributes:
							_curNode.quoteChar = chars[i];
							_incReadState = IncrementalReadState.AttributeValue;
							break;
						}
						i++;
					}
					break;
				}
				}
				int num7 = i - charPos;
				if (num7 > 0)
				{
					int num8;
					try
					{
						num8 = _incReadDecoder.Decode(_ps.chars, charPos, num7);
					}
					catch (XmlException ex2)
					{
						ReThrow(ex2, _incReadLineInfo.lineNo, _incReadLineInfo.linePos);
						return 0;
					}
					num += num8;
					if (_incReadDecoder.IsFull)
					{
						_incReadLeftStartPos = charPos + num8;
						_incReadLeftEndPos = i;
						_incReadLineInfo.linePos += num8;
						return num;
					}
				}
				continue;
				end_IL_00b7:
				break;
			}
			_ps.charPos++;
			_incReadState = IncrementalReadState.EndElement;
		}
		return num3;
	}

	private void FinishIncrementalRead()
	{
		_incReadDecoder = new IncrementalReadDummyDecoder();
		IncrementalRead();
		_incReadDecoder = null;
	}

	private bool ParseFragmentAttribute()
	{
		if (_curNode.type == XmlNodeType.None)
		{
			_curNode.type = XmlNodeType.Attribute;
			_curAttrIndex = 0;
			ParseAttributeValueSlow(_ps.charPos, ' ', _curNode);
		}
		else
		{
			_parsingFunction = ParsingFunction.InReadAttributeValue;
		}
		if (ReadAttributeValue())
		{
			_parsingFunction = ParsingFunction.FragmentAttribute;
			return true;
		}
		OnEof();
		return false;
	}

	private bool ParseAttributeValueChunk()
	{
		char[] chars = _ps.chars;
		int num = _ps.charPos;
		_curNode = AddNode(_index + _attrCount + 1, _index + 2);
		_curNode.SetLineInfo(_ps.LineNo, _ps.LinePos);
		if (_emptyEntityInAttributeResolved)
		{
			_curNode.SetValueNode(XmlNodeType.Text, string.Empty);
			_emptyEntityInAttributeResolved = false;
			return true;
		}
		while (true)
		{
			if (XmlCharType.IsAttributeValueChar(chars[num]))
			{
				num++;
				continue;
			}
			switch (chars[num])
			{
			case '\r':
				num++;
				continue;
			case '\t':
			case '\n':
				if (_normalize)
				{
					chars[num] = ' ';
				}
				num++;
				continue;
			case '"':
			case '\'':
			case '>':
				num++;
				continue;
			case '<':
				Throw(num, "Xml_BadAttributeChar", XmlException.BuildCharExceptionArgs('<', '\0'));
				goto IL_025f;
			case '&':
			{
				if (num - _ps.charPos > 0)
				{
					_stringBuilder.Append(chars, _ps.charPos, num - _ps.charPos);
				}
				_ps.charPos = num;
				EntityType entityType = HandleEntityReference(true, EntityExpandType.OnlyCharacter, out num);
				if ((uint)entityType > 2u)
				{
					if (entityType == EntityType.Unexpanded)
					{
						if (_stringBuilder.Length == 0)
						{
							_curNode.lineInfo.linePos++;
							_ps.charPos++;
							_curNode.SetNamedNode(XmlNodeType.EntityReference, ParseEntityName());
							return true;
						}
						break;
					}
				}
				else
				{
					chars = _ps.chars;
					if (_normalize && XmlCharType.IsWhiteSpace(chars[_ps.charPos]) && num - _ps.charPos == 1)
					{
						chars[_ps.charPos] = ' ';
					}
				}
				chars = _ps.chars;
				continue;
			}
			default:
				{
					if (num != _ps.charsUsed)
					{
						char c = chars[num];
						if (XmlCharType.IsHighSurrogate(c))
						{
							if (num + 1 == _ps.charsUsed)
							{
								goto IL_025f;
							}
							num++;
							if (XmlCharType.IsLowSurrogate(chars[num]))
							{
								num++;
								continue;
							}
						}
						ThrowInvalidChar(chars, _ps.charsUsed, num);
					}
					goto IL_025f;
				}
				IL_025f:
				if (num - _ps.charPos > 0)
				{
					_stringBuilder.Append(chars, _ps.charPos, num - _ps.charPos);
					_ps.charPos = num;
				}
				if (ReadData() == 0)
				{
					if (_stringBuilder.Length > 0)
					{
						break;
					}
					if (HandleEntityEnd(false))
					{
						SetupEndEntityNodeInAttribute();
						return true;
					}
				}
				num = _ps.charPos;
				chars = _ps.chars;
				continue;
			}
			break;
		}
		if (num - _ps.charPos > 0)
		{
			_stringBuilder.Append(chars, _ps.charPos, num - _ps.charPos);
			_ps.charPos = num;
		}
		_curNode.SetValueNode(XmlNodeType.Text, _stringBuilder.ToString());
		_stringBuilder.Length = 0;
		return true;
	}

	private void ParseXmlDeclarationFragment()
	{
		try
		{
			ParseXmlDeclaration(false);
		}
		catch (XmlException ex)
		{
			ReThrow(ex, ex.LineNumber, ex.LinePosition - 6);
		}
	}

	private void ThrowUnexpectedToken(int P_0, string P_1)
	{
		ThrowUnexpectedToken(P_0, P_1, null);
	}

	private void ThrowUnexpectedToken(string P_0)
	{
		ThrowUnexpectedToken(P_0, null);
	}

	private void ThrowUnexpectedToken(int P_0, string P_1, string P_2)
	{
		_ps.charPos = P_0;
		ThrowUnexpectedToken(P_1, P_2);
	}

	private void ThrowUnexpectedToken(string P_0, string P_1)
	{
		string text = ParseUnexpectedToken();
		if (text == null)
		{
			Throw("Xml_UnexpectedEOF1");
		}
		if (P_1 != null)
		{
			Throw("Xml_UnexpectedTokens2", new string[3] { text, P_0, P_1 });
		}
		else
		{
			Throw("Xml_UnexpectedTokenEx", new string[2] { text, P_0 });
		}
	}

	private string ParseUnexpectedToken(int P_0)
	{
		_ps.charPos = P_0;
		return ParseUnexpectedToken();
	}

	private string ParseUnexpectedToken()
	{
		if (_ps.charPos == _ps.charsUsed)
		{
			return null;
		}
		if (XmlCharType.IsNCNameSingleChar(_ps.chars[_ps.charPos]))
		{
			int i;
			for (i = _ps.charPos + 1; XmlCharType.IsNCNameSingleChar(_ps.chars[i]); i++)
			{
			}
			return new string(_ps.chars, _ps.charPos, i - _ps.charPos);
		}
		return new string(_ps.chars, _ps.charPos, 1);
	}

	private void ThrowExpectingWhitespace(int P_0)
	{
		string text = ParseUnexpectedToken(P_0);
		if (text == null)
		{
			Throw(P_0, "Xml_UnexpectedEOF1");
		}
		else
		{
			Throw(P_0, "Xml_ExpectingWhiteSpace", text);
		}
	}

	private int GetIndexOfAttributeWithoutPrefix(string P_0)
	{
		string text = _nameTable.Get(P_0);
		if (text == null)
		{
			return -1;
		}
		for (int i = _index + 1; i < _index + _attrCount + 1; i++)
		{
			if (Ref.Equal(_nodes[i].localName, text) && _nodes[i].prefix.Length == 0)
			{
				return i;
			}
		}
		return -1;
	}

	private int GetIndexOfAttributeWithPrefix(string P_0)
	{
		P_0 = _nameTable.Add(P_0);
		if (P_0 == null)
		{
			return -1;
		}
		for (int i = _index + 1; i < _index + _attrCount + 1; i++)
		{
			if (Ref.Equal(_nodes[i].GetNameWPrefix(_nameTable), P_0))
			{
				return i;
			}
		}
		return -1;
	}

	private bool ZeroEndingStream(int P_0)
	{
		if (_v1Compat && P_0 == _ps.charsUsed - 1 && _ps.chars[P_0] == '\0' && ReadData() == 0 && _ps.isStreamEof)
		{
			_ps.charsUsed--;
			return true;
		}
		return false;
	}

	private void ParseDtdFromParserContext()
	{
		IDtdParser dtdParser = DtdParser.Create();
		_dtdInfo = dtdParser.ParseFreeFloatingDtd(_fragmentParserContext.BaseURI, _fragmentParserContext.DocTypeName, _fragmentParserContext.PublicId, _fragmentParserContext.SystemId, _fragmentParserContext.InternalSubset, new DtdParserProxy(this));
		if ((_validatingReaderCompatFlag || !_v1Compat) && (_dtdInfo.HasDefaultAttributes || _dtdInfo.HasNonCDataAttributes))
		{
			_addDefaultAttributesAndNormalize = true;
		}
	}

	private bool MoveToNextContentNode(bool P_0)
	{
		do
		{
			switch (_curNode.type)
			{
			case XmlNodeType.Attribute:
				return !P_0;
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
				if (!P_0)
				{
					return true;
				}
				break;
			case XmlNodeType.EntityReference:
				_outerReader.ResolveEntity();
				break;
			default:
				return false;
			case XmlNodeType.ProcessingInstruction:
			case XmlNodeType.Comment:
			case XmlNodeType.EndEntity:
				break;
			}
			P_0 = false;
		}
		while (_outerReader.Read());
		return false;
	}

	internal void SetDtdInfo(IDtdInfo P_0)
	{
		_dtdInfo = P_0;
		if (_dtdInfo != null && (_validatingReaderCompatFlag || !_v1Compat) && (_dtdInfo.HasDefaultAttributes || _dtdInfo.HasNonCDataAttributes))
		{
			_addDefaultAttributesAndNormalize = true;
		}
	}

	private bool AddDefaultAttributeDtd(IDtdDefaultAttributeInfo P_0, bool P_1, NodeData[] P_2)
	{
		if (P_0.Prefix.Length > 0)
		{
			_attrNeedNamespaceLookup = true;
		}
		string localName = P_0.LocalName;
		string prefix = P_0.Prefix;
		if (P_2 != null)
		{
			if (Array.BinarySearch(P_2, P_0, DtdDefaultAttributeInfoToNodeDataComparer.Instance) >= 0)
			{
				return false;
			}
		}
		else
		{
			for (int i = _index + 1; i < _index + 1 + _attrCount; i++)
			{
				if ((object)_nodes[i].localName == localName && (object)_nodes[i].prefix == prefix)
				{
					return false;
				}
			}
		}
		NodeData nodeData = AddDefaultAttributeInternal(P_0.LocalName, null, P_0.Prefix, P_0.DefaultValueExpanded, P_0.LineNumber, P_0.LinePosition, P_0.ValueLineNumber, P_0.ValueLinePosition, P_0.IsXmlAttribute);
		if (DtdValidation)
		{
			_onDefaultAttributeUse?.Invoke(P_0, this);
			nodeData.typedValue = P_0.DefaultValueTyped;
		}
		return nodeData != null;
	}

	private NodeData AddDefaultAttributeInternal(string P_0, string P_1, string P_2, string P_3, int P_4, int P_5, int P_6, int P_7, bool P_8)
	{
		NodeData nodeData = AddAttribute(P_0, P_2, (P_2.Length > 0) ? null : P_0);
		if (P_1 != null)
		{
			nodeData.ns = P_1;
		}
		nodeData.SetValue(P_3);
		nodeData.IsDefaultAttribute = true;
		nodeData.lineInfo.Set(P_4, P_5);
		nodeData.lineInfo2.Set(P_6, P_7);
		if (nodeData.prefix.Length == 0)
		{
			if (Ref.Equal(nodeData.localName, _xmlNs))
			{
				OnDefaultNamespaceDecl(nodeData);
				if (!_attrNeedNamespaceLookup && _nodes[_index].prefix.Length == 0)
				{
					_nodes[_index].ns = _xmlContext.defaultNamespace;
				}
			}
		}
		else if (Ref.Equal(nodeData.prefix, _xmlNs))
		{
			OnNamespaceDecl(nodeData);
			if (!_attrNeedNamespaceLookup)
			{
				string localName = nodeData.localName;
				for (int i = _index; i < _index + _attrCount + 1; i++)
				{
					if (_nodes[i].prefix.Equals(localName))
					{
						_nodes[i].ns = _namespaceManager.LookupNamespace(localName);
					}
				}
			}
		}
		else if (P_8)
		{
			OnXmlReservedAttribute(nodeData);
		}
		_fullAttrCleanup = true;
		return nodeData;
	}

	private void RegisterConsumedCharacters(long P_0, bool P_1)
	{
		if (_maxCharactersInDocument > 0)
		{
			long num = _charactersInDocument + P_0;
			if (num < _charactersInDocument)
			{
				ThrowWithoutLineInfo("Xml_LimitExceeded", "MaxCharactersInDocument");
			}
			else
			{
				_charactersInDocument = num;
			}
			if (_charactersInDocument > _maxCharactersInDocument)
			{
				ThrowWithoutLineInfo("Xml_LimitExceeded", "MaxCharactersInDocument");
			}
		}
		if (_maxCharactersFromEntities > 0 && P_1)
		{
			long num2 = _charactersFromEntities + P_0;
			if (num2 < _charactersFromEntities)
			{
				ThrowWithoutLineInfo("Xml_LimitExceeded", "MaxCharactersFromEntities");
			}
			else
			{
				_charactersFromEntities = num2;
			}
			if (_charactersFromEntities > _maxCharactersFromEntities)
			{
				ThrowWithoutLineInfo("Xml_LimitExceeded", "MaxCharactersFromEntities");
			}
		}
	}

	internal static string StripSpaces(string P_0)
	{
		int length = P_0.Length;
		if (length <= 0)
		{
			return string.Empty;
		}
		int num = 0;
		StringBuilder stringBuilder = null;
		while (P_0[num] == ' ')
		{
			num++;
			if (num == length)
			{
				return " ";
			}
		}
		int i;
		for (i = num; i < length; i++)
		{
			if (P_0[i] != ' ')
			{
				continue;
			}
			int j;
			for (j = i + 1; j < length && P_0[j] == ' '; j++)
			{
			}
			if (j == length)
			{
				if (stringBuilder == null)
				{
					return P_0.Substring(num, i - num);
				}
				stringBuilder.Append(P_0, num, i - num);
				return stringBuilder.ToString();
			}
			if (j > i + 1)
			{
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(length);
				}
				stringBuilder.Append(P_0, num, i - num + 1);
				num = j;
				i = j - 1;
			}
		}
		if (stringBuilder == null)
		{
			if (num != 0)
			{
				return P_0.Substring(num, length - num);
			}
			return P_0;
		}
		if (i > num)
		{
			stringBuilder.Append(P_0, num, i - num);
		}
		return stringBuilder.ToString();
	}

	internal static void StripSpaces(char[] P_0, int P_1, ref int P_2)
	{
		if (P_2 <= 0)
		{
			return;
		}
		int num = P_1;
		int num2 = P_1 + P_2;
		while (P_0[num] == ' ')
		{
			num++;
			if (num == num2)
			{
				P_2 = 1;
				return;
			}
		}
		int num3 = num - P_1;
		for (int i = num; i < num2; i++)
		{
			char c;
			if ((c = P_0[i]) == ' ')
			{
				int j;
				for (j = i + 1; j < num2 && P_0[j] == ' '; j++)
				{
				}
				if (j == num2)
				{
					num3 += j - i;
					break;
				}
				if (j > i + 1)
				{
					num3 += j - i - 1;
					i = j - 1;
				}
			}
			P_0[i - num3] = c;
		}
		P_2 -= num3;
	}

	internal static void BlockCopyChars(char[] P_0, int P_1, char[] P_2, int P_3, int P_4)
	{
		Buffer.BlockCopy(P_0, P_1 * 2, P_2, P_3 * 2, P_4 * 2);
	}

	internal static void BlockCopy(byte[] P_0, int P_1, byte[] P_2, int P_3, int P_4)
	{
		Buffer.BlockCopy(P_0, P_1, P_2, P_3, P_4);
	}

	private static void ConvertAbsoluteUnixPathToAbsoluteUri([NotNullIfNotNull("url")][NotNullIfNotNull("url")] ref string P_0, XmlResolver P_1)
	{
		if (P_0 == null || P_0.Length <= 0 || P_0[0] != '/')
		{
			return;
		}
		if (P_1 != null)
		{
			Uri uri = P_1.ResolveUri(null, P_0);
			if (uri.IsFile)
			{
				P_0 = uri.ToString();
			}
		}
		else
		{
			P_0 = new Uri(P_0).ToString();
		}
	}
}
