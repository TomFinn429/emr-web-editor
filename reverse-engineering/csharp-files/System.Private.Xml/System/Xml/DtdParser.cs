using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Schema;

namespace System.Xml;

internal sealed class DtdParser : IDtdParser
{
	private enum Token
	{
		CDATA,
		ID,
		IDREF,
		IDREFS,
		ENTITY,
		ENTITIES,
		NMTOKEN,
		NMTOKENS,
		NOTATION,
		None,
		PERef,
		AttlistDecl,
		ElementDecl,
		EntityDecl,
		NotationDecl,
		Comment,
		PI,
		CondSectionStart,
		CondSectionEnd,
		Eof,
		REQUIRED,
		IMPLIED,
		FIXED,
		QName,
		Name,
		Nmtoken,
		Quote,
		LeftParen,
		RightParen,
		GreaterThan,
		Or,
		LeftBracket,
		RightBracket,
		PUBLIC,
		SYSTEM,
		Literal,
		DOCTYPE,
		NData,
		Percent,
		Star,
		QMark,
		Plus,
		PCDATA,
		Comma,
		ANY,
		EMPTY,
		IGNORE,
		INCLUDE
	}

	private enum ScanningFunction
	{
		SubsetContent,
		Name,
		QName,
		Nmtoken,
		Doctype1,
		Doctype2,
		Element1,
		Element2,
		Element3,
		Element4,
		Element5,
		Element6,
		Element7,
		Attlist1,
		Attlist2,
		Attlist3,
		Attlist4,
		Attlist5,
		Attlist6,
		Attlist7,
		Entity1,
		Entity2,
		Entity3,
		Notation1,
		CondSection1,
		CondSection2,
		CondSection3,
		Literal,
		SystemId,
		PublicId1,
		PublicId2,
		ClosingTag,
		ParamEntitySpace,
		None
	}

	private enum LiteralType
	{
		AttributeValue,
		EntityReplText,
		SystemOrPublicID
	}

	private sealed class UndeclaredNotation
	{
		internal string name;

		internal int lineNo;

		internal int linePos;

		internal UndeclaredNotation next;

		internal UndeclaredNotation(string P_0, int P_1, int P_2)
		{
			name = P_0;
			lineNo = P_1;
			linePos = P_2;
			next = null;
		}
	}

	private sealed class ParseElementOnlyContent_LocalFrame
	{
		public int startParenEntityId;

		public Token parsingSchema;

		public ParseElementOnlyContent_LocalFrame(int P_0)
		{
			startParenEntityId = P_0;
			parsingSchema = Token.None;
		}
	}

	private IDtdParserAdapter _readerAdapter;

	private IDtdParserAdapterWithValidation _readerAdapterWithValidation;

	private XmlNameTable _nameTable;

	private SchemaInfo _schemaInfo;

	private string _systemId = string.Empty;

	private string _publicId = string.Empty;

	private bool _normalize = true;

	private bool _validate;

	private bool _supportNamespaces = true;

	private bool _v1Compat;

	private char[] _chars;

	private int _charsUsed;

	private int _curPos;

	private ScanningFunction _scanningFunction;

	private ScanningFunction _nextScanningFunction;

	private ScanningFunction _savedScanningFunction;

	private bool _whitespaceSeen;

	private int _tokenStartPos;

	private int _colonPos;

	private StringBuilder _internalSubsetValueSb;

	private int _externalEntitiesDepth;

	private int _currentEntityId;

	private bool _freeFloatingDtd;

	private bool _hasFreeFloatingInternalSubset;

	private StringBuilder _stringBuilder;

	private int _condSectionDepth;

	private LineInfo _literalLineInfo = new LineInfo(0, 0);

	private char _literalQuoteChar = '"';

	private string _documentBaseUri = string.Empty;

	private string _externalDtdBaseUri = string.Empty;

	private Dictionary<string, UndeclaredNotation> _undeclaredNotations;

	private int[] _condSectionEntityIds;

	private bool ParsingInternalSubset => _externalEntitiesDepth == 0;

	private bool IgnoreEntityReferences => _scanningFunction == ScanningFunction.CondSection3;

	private bool SaveInternalSubsetValue
	{
		get
		{
			if (_readerAdapter.EntityStackLength == 0)
			{
				return _internalSubsetValueSb != null;
			}
			return false;
		}
	}

	private bool ParsingTopLevelMarkup
	{
		get
		{
			if (_scanningFunction != ScanningFunction.SubsetContent)
			{
				if (_scanningFunction == ScanningFunction.ParamEntitySpace)
				{
					return _savedScanningFunction == ScanningFunction.SubsetContent;
				}
				return false;
			}
			return true;
		}
	}

	private bool SupportNamespaces => _supportNamespaces;

	private bool Normalize => _normalize;

	private int LineNo => _readerAdapter.LineNo;

	private int LinePos => _curPos - _readerAdapter.LineStartPosition;

	private string BaseUriStr
	{
		get
		{
			Uri baseUri = _readerAdapter.BaseUri;
			if (!(baseUri != null))
			{
				return string.Empty;
			}
			return baseUri.ToString();
		}
	}

	private DtdParser()
	{
	}

	internal static IDtdParser Create()
	{
		return new DtdParser();
	}

	private void Initialize(IDtdParserAdapter P_0)
	{
		_readerAdapter = P_0;
		_readerAdapterWithValidation = P_0 as IDtdParserAdapterWithValidation;
		_nameTable = P_0.NameTable;
		if (P_0 is IDtdParserAdapterWithValidation dtdParserAdapterWithValidation)
		{
			_validate = dtdParserAdapterWithValidation.DtdValidation;
		}
		if (P_0 is IDtdParserAdapterV1 dtdParserAdapterV)
		{
			_v1Compat = dtdParserAdapterV.V1CompatibilityMode;
			_normalize = dtdParserAdapterV.Normalization;
			_supportNamespaces = dtdParserAdapterV.Namespaces;
		}
		_schemaInfo = new SchemaInfo();
		_schemaInfo.SchemaType = SchemaType.DTD;
		_stringBuilder = new StringBuilder();
		Uri baseUri = P_0.BaseUri;
		if (baseUri != null)
		{
			_documentBaseUri = baseUri.ToString();
		}
		_freeFloatingDtd = false;
	}

	private void InitializeFreeFloatingDtd(string P_0, string P_1, string P_2, string P_3, string P_4, IDtdParserAdapter P_5)
	{
		Initialize(P_5);
		ArgumentException.ThrowIfNullOrEmpty(P_1, "docTypeName");
		XmlConvert.VerifyName(P_1);
		int num = P_1.IndexOf(':');
		if (num == -1)
		{
			_schemaInfo.DocTypeName = new XmlQualifiedName(_nameTable.Add(P_1));
		}
		else
		{
			_schemaInfo.DocTypeName = new XmlQualifiedName(_nameTable.Add(P_1.Substring(0, num)), _nameTable.Add(P_1.Substring(num + 1)));
		}
		if (P_3 != null && P_3.Length > 0)
		{
			int num2;
			if ((num2 = XmlCharType.IsOnlyCharData(P_3)) >= 0)
			{
				ThrowInvalidChar(_curPos, P_3, num2);
			}
			_systemId = P_3;
		}
		if (P_2 != null && P_2.Length > 0)
		{
			int num2;
			if ((num2 = XmlCharType.IsPublicId(P_2)) >= 0)
			{
				ThrowInvalidChar(_curPos, P_2, num2);
			}
			_publicId = P_2;
		}
		if (P_4 != null && P_4.Length > 0)
		{
			_readerAdapter.PushInternalDtd(P_0, P_4);
			_hasFreeFloatingInternalSubset = true;
		}
		Uri baseUri = _readerAdapter.BaseUri;
		if (baseUri != null)
		{
			_documentBaseUri = baseUri.ToString();
		}
		_freeFloatingDtd = true;
	}

	IDtdInfo IDtdParser.ParseInternalDtd(IDtdParserAdapter P_0, bool P_1)
	{
		Initialize(P_0);
		Parse(P_1);
		return _schemaInfo;
	}

	IDtdInfo IDtdParser.ParseFreeFloatingDtd(string P_0, string P_1, string P_2, string P_3, string P_4, IDtdParserAdapter P_5)
	{
		InitializeFreeFloatingDtd(P_0, P_1, P_2, P_3, P_4, P_5);
		Parse(false);
		return _schemaInfo;
	}

	private void Parse(bool P_0)
	{
		if (_freeFloatingDtd)
		{
			ParseFreeFloatingDtd();
		}
		else
		{
			ParseInDocumentDtd(P_0);
		}
		_schemaInfo.Finish();
		if (!_validate || _undeclaredNotations == null)
		{
			return;
		}
		foreach (UndeclaredNotation value in _undeclaredNotations.Values)
		{
			for (UndeclaredNotation undeclaredNotation = value; undeclaredNotation != null; undeclaredNotation = undeclaredNotation.next)
			{
				SendValidationEvent(XmlSeverityType.Error, new XmlSchemaException("Sch_UndeclaredNotation", value.name, BaseUriStr, value.lineNo, value.linePos));
			}
		}
	}

	private void ParseInDocumentDtd(bool P_0)
	{
		LoadParsingBuffer();
		_scanningFunction = ScanningFunction.QName;
		_nextScanningFunction = ScanningFunction.Doctype1;
		if (GetToken(false) != Token.QName)
		{
			OnUnexpectedError();
		}
		_schemaInfo.DocTypeName = GetNameQualified(true);
		Token token = GetToken(false);
		if (token == Token.SYSTEM || token == Token.PUBLIC)
		{
			ParseExternalId(token, Token.DOCTYPE, out _publicId, out _systemId);
			token = GetToken(false);
		}
		switch (token)
		{
		case Token.LeftBracket:
			if (P_0)
			{
				SaveParsingBuffer();
				_internalSubsetValueSb = new StringBuilder();
			}
			ParseInternalSubset();
			break;
		default:
			OnUnexpectedError();
			break;
		case Token.GreaterThan:
			break;
		}
		SaveParsingBuffer();
		if (_systemId != null && _systemId.Length > 0)
		{
			ParseExternalSubset();
		}
	}

	private void ParseFreeFloatingDtd()
	{
		if (_hasFreeFloatingInternalSubset)
		{
			LoadParsingBuffer();
			ParseInternalSubset();
			SaveParsingBuffer();
		}
		if (_systemId != null && _systemId.Length > 0)
		{
			ParseExternalSubset();
		}
	}

	private void ParseInternalSubset()
	{
		ParseSubset();
	}

	private void ParseExternalSubset()
	{
		if (_readerAdapter.PushExternalSubset(_systemId, _publicId))
		{
			Uri baseUri = _readerAdapter.BaseUri;
			if (baseUri != null)
			{
				_externalDtdBaseUri = baseUri.ToString();
			}
			_externalEntitiesDepth++;
			LoadParsingBuffer();
			ParseSubset();
		}
	}

	private void ParseSubset()
	{
		while (true)
		{
			Token token = GetToken(false);
			int currentEntityId = _currentEntityId;
			switch (token)
			{
			case Token.AttlistDecl:
				ParseAttlistDecl();
				break;
			case Token.ElementDecl:
				ParseElementDecl();
				break;
			case Token.EntityDecl:
				ParseEntityDecl();
				break;
			case Token.NotationDecl:
				ParseNotationDecl();
				break;
			case Token.Comment:
				ParseComment();
				break;
			case Token.PI:
				ParsePI();
				break;
			case Token.CondSectionStart:
				if (ParsingInternalSubset)
				{
					Throw(_curPos - 3, "Xml_InvalidConditionalSection");
				}
				ParseCondSection();
				currentEntityId = _currentEntityId;
				break;
			case Token.CondSectionEnd:
				if (_condSectionDepth > 0)
				{
					_condSectionDepth--;
					if (_validate && _currentEntityId != _condSectionEntityIds[_condSectionDepth])
					{
						SendValidationEvent(_curPos, XmlSeverityType.Error, "Sch_ParEntityRefNesting", string.Empty);
					}
				}
				else
				{
					Throw(_curPos - 3, "Xml_UnexpectedCDataEnd");
				}
				break;
			case Token.RightBracket:
				if (ParsingInternalSubset)
				{
					if (_condSectionDepth != 0)
					{
						Throw(_curPos, "Xml_UnclosedConditionalSection");
					}
					if (_internalSubsetValueSb != null)
					{
						SaveParsingBuffer(_curPos - 1);
						_schemaInfo.InternalDtdSubset = _internalSubsetValueSb.ToString();
						_internalSubsetValueSb = null;
					}
					if (GetToken(false) != Token.GreaterThan)
					{
						ThrowUnexpectedToken(_curPos, ">");
					}
				}
				else
				{
					Throw(_curPos, "Xml_ExpectDtdMarkup");
				}
				return;
			case Token.Eof:
				if (ParsingInternalSubset && !_freeFloatingDtd)
				{
					Throw(_curPos, "Xml_IncompleteDtdContent");
				}
				if (_condSectionDepth != 0)
				{
					Throw(_curPos, "Xml_UnclosedConditionalSection");
				}
				return;
			}
			if (_currentEntityId != currentEntityId)
			{
				if (_validate)
				{
					SendValidationEvent(_curPos, XmlSeverityType.Error, "Sch_ParEntityRefNesting", string.Empty);
				}
				else if (!_v1Compat)
				{
					Throw(_curPos, "Sch_ParEntityRefNesting");
				}
			}
		}
	}

	private void ParseAttlistDecl()
	{
		if (GetToken(true) == Token.QName)
		{
			XmlQualifiedName nameQualified = GetNameQualified(true);
			if (!_schemaInfo.ElementDecls.TryGetValue(nameQualified, out var schemaElementDecl) && !_schemaInfo.UndeclaredElementDecls.TryGetValue(nameQualified, out schemaElementDecl))
			{
				schemaElementDecl = new SchemaElementDecl(nameQualified, nameQualified.Namespace);
				_schemaInfo.UndeclaredElementDecls.Add(nameQualified, schemaElementDecl);
			}
			SchemaAttDef schemaAttDef = null;
			while (true)
			{
				switch (GetToken(false))
				{
				case Token.QName:
				{
					XmlQualifiedName nameQualified2 = GetNameQualified(true);
					schemaAttDef = new SchemaAttDef(nameQualified2, nameQualified2.Namespace);
					schemaAttDef.IsDeclaredInExternal = !ParsingInternalSubset;
					schemaAttDef.LineNumber = LineNo;
					schemaAttDef.LinePosition = LinePos - (_curPos - _tokenStartPos);
					bool flag = schemaElementDecl.GetAttDef(schemaAttDef.Name) != null;
					ParseAttlistType(schemaAttDef, schemaElementDecl, flag);
					ParseAttlistDefault(schemaAttDef, flag);
					if (schemaAttDef.Prefix.Length > 0 && schemaAttDef.Prefix.Equals("xml"))
					{
						if (schemaAttDef.Name.Name == "space")
						{
							if (_v1Compat)
							{
								string text = schemaAttDef.DefaultValueExpanded.Trim();
								if (text.Equals("preserve") || text.Equals("default"))
								{
									schemaAttDef.Reserved = SchemaAttDef.Reserve.XmlSpace;
								}
							}
							else
							{
								schemaAttDef.Reserved = SchemaAttDef.Reserve.XmlSpace;
								if (schemaAttDef.TokenizedType != XmlTokenizedType.ENUMERATION)
								{
									Throw("Xml_EnumerationRequired", string.Empty, schemaAttDef.LineNumber, schemaAttDef.LinePosition);
								}
								if (_validate)
								{
									schemaAttDef.CheckXmlSpace(_readerAdapterWithValidation.ValidationEventHandling);
								}
							}
						}
						else if (schemaAttDef.Name.Name == "lang")
						{
							schemaAttDef.Reserved = SchemaAttDef.Reserve.XmlLang;
						}
					}
					if (!flag)
					{
						schemaElementDecl.AddAttDef(schemaAttDef);
					}
					continue;
				}
				case Token.GreaterThan:
					if (_v1Compat && schemaAttDef != null && schemaAttDef.Prefix.Length > 0 && schemaAttDef.Prefix.Equals("xml") && schemaAttDef.Name.Name == "space")
					{
						schemaAttDef.Reserved = SchemaAttDef.Reserve.XmlSpace;
						if (schemaAttDef.Datatype.TokenizedType != XmlTokenizedType.ENUMERATION)
						{
							Throw("Xml_EnumerationRequired", string.Empty, schemaAttDef.LineNumber, schemaAttDef.LinePosition);
						}
						if (_validate)
						{
							schemaAttDef.CheckXmlSpace(_readerAdapterWithValidation.ValidationEventHandling);
						}
					}
					return;
				}
				break;
			}
		}
		OnUnexpectedError();
	}

	private void ParseAttlistType(SchemaAttDef P_0, SchemaElementDecl P_1, bool P_2)
	{
		Token token = GetToken(true);
		if (token != Token.CDATA)
		{
			P_1.HasNonCDataAttribute = true;
		}
		if (IsAttributeValueType(token))
		{
			P_0.TokenizedType = (XmlTokenizedType)token;
			P_0.SchemaType = XmlSchemaType.GetBuiltInSimpleType(P_0.Datatype.TypeCode);
			switch (token)
			{
			default:
				return;
			case Token.ID:
				if (_validate && P_1.IsIdDeclared)
				{
					SchemaAttDef attDef = P_1.GetAttDef(P_0.Name);
					if ((attDef == null || attDef.Datatype.TokenizedType != XmlTokenizedType.ID) && !P_2)
					{
						SendValidationEvent(XmlSeverityType.Error, "Sch_IdAttrDeclared", P_1.Name.ToString());
					}
				}
				P_1.IsIdDeclared = true;
				return;
			case Token.NOTATION:
				break;
			}
			if (_validate)
			{
				if (P_1.IsNotationDeclared && !P_2)
				{
					SendValidationEvent(_curPos - 8, XmlSeverityType.Error, "Sch_DupNotationAttribute", P_1.Name.ToString());
				}
				else
				{
					if (P_1.ContentValidator != null && P_1.ContentValidator.ContentType == XmlSchemaContentType.Empty && !P_2)
					{
						SendValidationEvent(_curPos - 8, XmlSeverityType.Error, "Sch_NotationAttributeOnEmptyElement", P_1.Name.ToString());
					}
					P_1.IsNotationDeclared = true;
				}
			}
			if (GetToken(true) == Token.LeftParen && GetToken(false) == Token.Name)
			{
				do
				{
					string nameString = GetNameString();
					if (!_schemaInfo.Notations.ContainsKey(nameString))
					{
						AddUndeclaredNotation(nameString);
					}
					if (_validate && !_v1Compat && P_0.Values != null && P_0.Values.Contains(nameString) && !P_2)
					{
						SendValidationEvent(XmlSeverityType.Error, new XmlSchemaException("Xml_AttlistDuplNotationValue", nameString, BaseUriStr, LineNo, LinePos));
					}
					P_0.AddValue(nameString);
					switch (GetToken(false))
					{
					case Token.Or:
						continue;
					case Token.RightParen:
						return;
					}
					break;
				}
				while (GetToken(false) == Token.Name);
			}
		}
		else if (token == Token.LeftParen)
		{
			P_0.TokenizedType = XmlTokenizedType.ENUMERATION;
			P_0.SchemaType = XmlSchemaType.GetBuiltInSimpleType(P_0.Datatype.TypeCode);
			if (GetToken(false) == Token.Nmtoken)
			{
				P_0.AddValue(GetNameString());
				while (true)
				{
					string nmtokenString;
					switch (GetToken(false))
					{
					case Token.Or:
						if (GetToken(false) == Token.Nmtoken)
						{
							nmtokenString = GetNmtokenString();
							if (_validate && !_v1Compat && P_0.Values != null && P_0.Values.Contains(nmtokenString) && !P_2)
							{
								SendValidationEvent(XmlSeverityType.Error, new XmlSchemaException("Xml_AttlistDuplEnumValue", nmtokenString, BaseUriStr, LineNo, LinePos));
							}
							goto IL_0277;
						}
						break;
					case Token.RightParen:
						return;
					}
					break;
					IL_0277:
					P_0.AddValue(nmtokenString);
				}
			}
		}
		OnUnexpectedError();
	}

	private void ParseAttlistDefault(SchemaAttDef P_0, bool P_1)
	{
		switch (GetToken(true))
		{
		case Token.REQUIRED:
			P_0.Presence = SchemaDeclBase.Use.Required;
			return;
		case Token.IMPLIED:
			P_0.Presence = SchemaDeclBase.Use.Implied;
			return;
		case Token.FIXED:
			P_0.Presence = SchemaDeclBase.Use.Fixed;
			if (GetToken(true) != Token.Literal)
			{
				break;
			}
			goto case Token.Literal;
		case Token.Literal:
			if (_validate && P_0.Datatype.TokenizedType == XmlTokenizedType.ID && !P_1)
			{
				SendValidationEvent(_curPos, XmlSeverityType.Error, "Sch_AttListPresence", string.Empty);
			}
			if (P_0.TokenizedType != XmlTokenizedType.CDATA)
			{
				P_0.DefaultValueExpanded = GetValueWithStrippedSpaces();
			}
			else
			{
				P_0.DefaultValueExpanded = GetValue();
			}
			P_0.ValueLineNumber = _literalLineInfo.lineNo;
			P_0.ValueLinePosition = _literalLineInfo.linePos + 1;
			DtdValidator.SetDefaultTypedValue(P_0, _readerAdapter);
			return;
		}
		OnUnexpectedError();
	}

	private void ParseElementDecl()
	{
		if (GetToken(true) == Token.QName)
		{
			XmlQualifiedName nameQualified = GetNameQualified(true);
			if (_schemaInfo.ElementDecls.TryGetValue(nameQualified, out var schemaElementDecl))
			{
				if (_validate)
				{
					SendValidationEvent(_curPos - nameQualified.Name.Length, XmlSeverityType.Error, "Sch_DupElementDecl", GetNameString());
				}
			}
			else
			{
				if (_schemaInfo.UndeclaredElementDecls.TryGetValue(nameQualified, out schemaElementDecl))
				{
					_schemaInfo.UndeclaredElementDecls.Remove(nameQualified);
				}
				else
				{
					schemaElementDecl = new SchemaElementDecl(nameQualified, nameQualified.Namespace);
				}
				_schemaInfo.ElementDecls.Add(nameQualified, schemaElementDecl);
			}
			schemaElementDecl.IsDeclaredInExternal = !ParsingInternalSubset;
			Token token = GetToken(true);
			if (token != Token.LeftParen)
			{
				if (token != Token.ANY)
				{
					if (token != Token.EMPTY)
					{
						goto IL_017c;
					}
					schemaElementDecl.ContentValidator = ContentValidator.Empty;
				}
				else
				{
					schemaElementDecl.ContentValidator = ContentValidator.Any;
				}
			}
			else
			{
				int currentEntityId = _currentEntityId;
				Token token2 = GetToken(false);
				if (token2 != Token.None)
				{
					if (token2 != Token.PCDATA)
					{
						goto IL_017c;
					}
					ParticleContentValidator particleContentValidator = new ParticleContentValidator(XmlSchemaContentType.Mixed);
					particleContentValidator.Start();
					particleContentValidator.OpenGroup();
					ParseElementMixedContent(particleContentValidator, currentEntityId);
					schemaElementDecl.ContentValidator = particleContentValidator.Finish(true);
				}
				else
				{
					ParticleContentValidator particleContentValidator2 = new ParticleContentValidator(XmlSchemaContentType.ElementOnly);
					particleContentValidator2.Start();
					particleContentValidator2.OpenGroup();
					ParseElementOnlyContent(particleContentValidator2, currentEntityId);
					schemaElementDecl.ContentValidator = particleContentValidator2.Finish(true);
				}
			}
			if (GetToken(false) != Token.GreaterThan)
			{
				ThrowUnexpectedToken(_curPos, ">");
			}
			return;
		}
		goto IL_017c;
		IL_017c:
		OnUnexpectedError();
	}

	private void ParseElementOnlyContent(ParticleContentValidator P_0, int P_1)
	{
		Stack<ParseElementOnlyContent_LocalFrame> stack = new Stack<ParseElementOnlyContent_LocalFrame>();
		ParseElementOnlyContent_LocalFrame parseElementOnlyContent_LocalFrame = new ParseElementOnlyContent_LocalFrame(P_1);
		stack.Push(parseElementOnlyContent_LocalFrame);
		while (true)
		{
			Token token = GetToken(false);
			if (token != Token.QName)
			{
				if (token != Token.LeftParen)
				{
					if (token != Token.GreaterThan)
					{
						goto IL_0148;
					}
					Throw(_curPos, "Xml_InvalidContentModel");
					goto IL_014e;
				}
				P_0.OpenGroup();
				parseElementOnlyContent_LocalFrame = new ParseElementOnlyContent_LocalFrame(_currentEntityId);
				stack.Push(parseElementOnlyContent_LocalFrame);
				continue;
			}
			P_0.AddName(GetNameQualified(true), null);
			ParseHowMany(P_0);
			goto IL_0078;
			IL_0148:
			OnUnexpectedError();
			goto IL_014e;
			IL_00f9:
			P_0.CloseGroup();
			if (_validate && _currentEntityId != parseElementOnlyContent_LocalFrame.startParenEntityId)
			{
				SendValidationEvent(_curPos, XmlSeverityType.Error, "Sch_ParEntityRefNesting", string.Empty);
			}
			ParseHowMany(P_0);
			goto IL_014e;
			IL_00cb:
			if (parseElementOnlyContent_LocalFrame.parsingSchema == Token.Comma)
			{
				Throw(_curPos, "Xml_InvalidContentModel");
			}
			P_0.AddChoice();
			parseElementOnlyContent_LocalFrame.parsingSchema = Token.Or;
			continue;
			IL_014e:
			stack.Pop();
			if (stack.Count > 0)
			{
				parseElementOnlyContent_LocalFrame = stack.Peek();
				goto IL_0078;
			}
			break;
			IL_0135:
			Throw(_curPos, "Xml_InvalidContentModel");
			goto IL_014e;
			IL_0078:
			switch (GetToken(false))
			{
			case Token.Comma:
				break;
			case Token.Or:
				goto IL_00cb;
			case Token.RightParen:
				goto IL_00f9;
			case Token.GreaterThan:
				goto IL_0135;
			default:
				goto IL_0148;
			}
			if (parseElementOnlyContent_LocalFrame.parsingSchema == Token.Or)
			{
				Throw(_curPos, "Xml_InvalidContentModel");
			}
			P_0.AddSequence();
			parseElementOnlyContent_LocalFrame.parsingSchema = Token.Comma;
		}
	}

	private void ParseHowMany(ParticleContentValidator P_0)
	{
		switch (GetToken(false))
		{
		case Token.Star:
			P_0.AddStar();
			break;
		case Token.QMark:
			P_0.AddQMark();
			break;
		case Token.Plus:
			P_0.AddPlus();
			break;
		}
	}

	private void ParseElementMixedContent(ParticleContentValidator P_0, int P_1)
	{
		bool flag = false;
		int num = -1;
		int currentEntityId = _currentEntityId;
		while (true)
		{
			switch (GetToken(false))
			{
			case Token.RightParen:
				P_0.CloseGroup();
				if (_validate && _currentEntityId != P_1)
				{
					SendValidationEvent(_curPos, XmlSeverityType.Error, "Sch_ParEntityRefNesting", string.Empty);
				}
				if (GetToken(false) == Token.Star && flag)
				{
					P_0.AddStar();
				}
				else if (flag)
				{
					ThrowUnexpectedToken(_curPos, "*");
				}
				return;
			case Token.Or:
			{
				if (!flag)
				{
					flag = true;
				}
				else
				{
					P_0.AddChoice();
				}
				if (_validate)
				{
					num = _currentEntityId;
					if (currentEntityId < num)
					{
						SendValidationEvent(_curPos, XmlSeverityType.Error, "Sch_ParEntityRefNesting", string.Empty);
					}
				}
				if (GetToken(false) != Token.QName)
				{
					break;
				}
				XmlQualifiedName nameQualified = GetNameQualified(true);
				if (P_0.Exists(nameQualified) && _validate)
				{
					SendValidationEvent(XmlSeverityType.Error, "Sch_DupElement", nameQualified.ToString());
				}
				P_0.AddName(nameQualified, null);
				if (_validate)
				{
					currentEntityId = _currentEntityId;
					if (currentEntityId < num)
					{
						SendValidationEvent(_curPos, XmlSeverityType.Error, "Sch_ParEntityRefNesting", string.Empty);
					}
				}
				continue;
			}
			}
			OnUnexpectedError();
		}
	}

	private void ParseEntityDecl()
	{
		bool flag = false;
		Token token = GetToken(true);
		if (token == Token.Name)
		{
			goto IL_002a;
		}
		if (token == Token.Percent)
		{
			flag = true;
			if (GetToken(true) == Token.Name)
			{
				goto IL_002a;
			}
		}
		goto IL_01d4;
		IL_002a:
		XmlQualifiedName nameQualified = GetNameQualified(false);
		SchemaEntity schemaEntity = new SchemaEntity(nameQualified, flag);
		schemaEntity.BaseURI = BaseUriStr;
		schemaEntity.DeclaredURI = ((_externalDtdBaseUri.Length == 0) ? _documentBaseUri : _externalDtdBaseUri);
		if (flag)
		{
			if (!_schemaInfo.ParameterEntities.ContainsKey(nameQualified))
			{
				_schemaInfo.ParameterEntities.Add(nameQualified, schemaEntity);
			}
		}
		else if (!_schemaInfo.GeneralEntities.ContainsKey(nameQualified))
		{
			_schemaInfo.GeneralEntities.Add(nameQualified, schemaEntity);
		}
		schemaEntity.DeclaredInExternal = !ParsingInternalSubset;
		schemaEntity.ParsingInProgress = true;
		Token token2 = GetToken(true);
		if ((uint)(token2 - 33) > 1u)
		{
			if (token2 != Token.Literal)
			{
				goto IL_01d4;
			}
			schemaEntity.Text = GetValue();
			schemaEntity.Line = _literalLineInfo.lineNo;
			schemaEntity.Pos = _literalLineInfo.linePos;
		}
		else
		{
			ParseExternalId(token2, Token.EntityDecl, out var pubid, out var url);
			schemaEntity.IsExternal = true;
			schemaEntity.Url = url;
			schemaEntity.Pubid = pubid;
			if (GetToken(false) == Token.NData)
			{
				if (flag)
				{
					ThrowUnexpectedToken(_curPos - 5, ">");
				}
				if (!_whitespaceSeen)
				{
					Throw(_curPos - 5, "Xml_ExpectingWhiteSpace", "NDATA");
				}
				if (GetToken(true) != Token.Name)
				{
					goto IL_01d4;
				}
				schemaEntity.NData = GetNameQualified(false);
				string name = schemaEntity.NData.Name;
				if (!_schemaInfo.Notations.ContainsKey(name))
				{
					AddUndeclaredNotation(name);
				}
			}
		}
		if (GetToken(false) == Token.GreaterThan)
		{
			schemaEntity.ParsingInProgress = false;
			return;
		}
		goto IL_01d4;
		IL_01d4:
		OnUnexpectedError();
	}

	private void ParseNotationDecl()
	{
		if (GetToken(true) != Token.Name)
		{
			OnUnexpectedError();
		}
		XmlQualifiedName nameQualified = GetNameQualified(false);
		SchemaNotation schemaNotation = null;
		if (!_schemaInfo.Notations.ContainsKey(nameQualified.Name))
		{
			_undeclaredNotations?.Remove(nameQualified.Name);
			schemaNotation = new SchemaNotation(nameQualified);
			_schemaInfo.Notations.Add(schemaNotation.Name.Name, schemaNotation);
		}
		else if (_validate)
		{
			SendValidationEvent(_curPos - nameQualified.Name.Length, XmlSeverityType.Error, "Sch_DupNotation", nameQualified.Name);
		}
		Token token = GetToken(true);
		if (token == Token.SYSTEM || token == Token.PUBLIC)
		{
			ParseExternalId(token, Token.NOTATION, out var pubid, out var systemLiteral);
			if (schemaNotation != null)
			{
				schemaNotation.SystemLiteral = systemLiteral;
				schemaNotation.Pubid = pubid;
			}
		}
		else
		{
			OnUnexpectedError();
		}
		if (GetToken(false) != Token.GreaterThan)
		{
			OnUnexpectedError();
		}
	}

	private void AddUndeclaredNotation(string P_0)
	{
		if (_undeclaredNotations == null)
		{
			_undeclaredNotations = new Dictionary<string, UndeclaredNotation>();
		}
		UndeclaredNotation undeclaredNotation = new UndeclaredNotation(P_0, LineNo, LinePos - P_0.Length);
		if (_undeclaredNotations.TryGetValue(P_0, out var undeclaredNotation2))
		{
			undeclaredNotation.next = undeclaredNotation2.next;
			undeclaredNotation2.next = undeclaredNotation;
		}
		else
		{
			_undeclaredNotations.Add(P_0, undeclaredNotation);
		}
	}

	private void ParseComment()
	{
		SaveParsingBuffer();
		try
		{
			if (SaveInternalSubsetValue)
			{
				_readerAdapter.ParseComment(_internalSubsetValueSb);
				_internalSubsetValueSb.Append("-->");
			}
			else
			{
				_readerAdapter.ParseComment(null);
			}
		}
		catch (XmlException ex)
		{
			if (!(ex.ResString == "Xml_UnexpectedEOF") || _currentEntityId == 0)
			{
				throw;
			}
			SendValidationEvent(XmlSeverityType.Error, "Sch_ParEntityRefNesting", null);
		}
		LoadParsingBuffer();
	}

	private void ParsePI()
	{
		SaveParsingBuffer();
		if (SaveInternalSubsetValue)
		{
			_readerAdapter.ParsePI(_internalSubsetValueSb);
			_internalSubsetValueSb.Append("?>");
		}
		else
		{
			_readerAdapter.ParsePI(null);
		}
		LoadParsingBuffer();
	}

	private void ParseCondSection()
	{
		int currentEntityId = _currentEntityId;
		switch (GetToken(false))
		{
		case Token.INCLUDE:
			if (GetToken(false) == Token.LeftBracket)
			{
				if (_validate && currentEntityId != _currentEntityId)
				{
					SendValidationEvent(_curPos, XmlSeverityType.Error, "Sch_ParEntityRefNesting", string.Empty);
				}
				if (_validate)
				{
					if (_condSectionEntityIds == null)
					{
						_condSectionEntityIds = new int[2];
					}
					else if (_condSectionEntityIds.Length == _condSectionDepth)
					{
						int[] array = new int[_condSectionEntityIds.Length * 2];
						Array.Copy(_condSectionEntityIds, array, _condSectionEntityIds.Length);
						_condSectionEntityIds = array;
					}
					_condSectionEntityIds[_condSectionDepth] = currentEntityId;
				}
				_condSectionDepth++;
				break;
			}
			goto default;
		case Token.IGNORE:
			if (GetToken(false) == Token.LeftBracket)
			{
				if (_validate && currentEntityId != _currentEntityId)
				{
					SendValidationEvent(_curPos, XmlSeverityType.Error, "Sch_ParEntityRefNesting", string.Empty);
				}
				if (GetToken(false) == Token.CondSectionEnd)
				{
					if (_validate && currentEntityId != _currentEntityId)
					{
						SendValidationEvent(_curPos, XmlSeverityType.Error, "Sch_ParEntityRefNesting", string.Empty);
					}
					break;
				}
			}
			goto default;
		default:
			OnUnexpectedError();
			break;
		}
	}

	private void ParseExternalId(Token P_0, Token P_1, out string P_2, out string P_3)
	{
		LineInfo lineInfo = new LineInfo(LineNo, LinePos - 6);
		P_2 = null;
		P_3 = null;
		if (GetToken(true) != Token.Literal)
		{
			ThrowUnexpectedToken(_curPos, "\"", "'");
		}
		if (P_0 == Token.SYSTEM)
		{
			P_3 = GetValue();
			if (P_3.Contains('#'))
			{
				Throw(_curPos - P_3.Length - 1, "Xml_FragmentId", new string[2]
				{
					P_3.Substring(P_3.IndexOf('#')),
					P_3
				});
			}
			if (P_1 == Token.DOCTYPE && !_freeFloatingDtd)
			{
				_literalLineInfo.linePos++;
				_readerAdapter.OnSystemId(P_3, lineInfo, _literalLineInfo);
			}
			return;
		}
		P_2 = GetValue();
		int num;
		if ((num = XmlCharType.IsPublicId(P_2)) >= 0)
		{
			ThrowInvalidChar(_curPos - 1 - P_2.Length + num, P_2, num);
		}
		if (P_1 == Token.DOCTYPE && !_freeFloatingDtd)
		{
			_literalLineInfo.linePos++;
			_readerAdapter.OnPublicId(P_2, lineInfo, _literalLineInfo);
			if (GetToken(false) == Token.Literal)
			{
				if (!_whitespaceSeen)
				{
					Throw("Xml_ExpectingWhiteSpace", char.ToString(_literalQuoteChar), _literalLineInfo.lineNo, _literalLineInfo.linePos);
				}
				P_3 = GetValue();
				_literalLineInfo.linePos++;
				_readerAdapter.OnSystemId(P_3, lineInfo, _literalLineInfo);
			}
			else
			{
				ThrowUnexpectedToken(_curPos, "\"", "'");
			}
		}
		else if (GetToken(false) == Token.Literal)
		{
			if (!_whitespaceSeen)
			{
				Throw("Xml_ExpectingWhiteSpace", char.ToString(_literalQuoteChar), _literalLineInfo.lineNo, _literalLineInfo.linePos);
			}
			P_3 = GetValue();
		}
		else if (P_1 != Token.NOTATION)
		{
			ThrowUnexpectedToken(_curPos, "\"", "'");
		}
	}

	private Token GetToken(bool P_0)
	{
		_whitespaceSeen = false;
		while (true)
		{
			switch (_chars[_curPos])
			{
			case '\0':
				if (_curPos != _charsUsed)
				{
					ThrowInvalidChar(_chars, _charsUsed, _curPos);
				}
				break;
			case '\n':
				_whitespaceSeen = true;
				_curPos++;
				_readerAdapter.OnNewLine(_curPos);
				continue;
			case '\r':
				_whitespaceSeen = true;
				if (_chars[_curPos + 1] == '\n')
				{
					if (Normalize)
					{
						SaveParsingBuffer();
						_readerAdapter.CurrentPosition++;
					}
					_curPos += 2;
				}
				else
				{
					if (_curPos + 1 >= _charsUsed && !_readerAdapter.IsEof)
					{
						break;
					}
					_chars[_curPos] = '\n';
					_curPos++;
				}
				_readerAdapter.OnNewLine(_curPos);
				continue;
			case '\t':
			case ' ':
				_whitespaceSeen = true;
				_curPos++;
				continue;
			case '%':
				if (_charsUsed - _curPos < 2)
				{
					break;
				}
				if (!XmlCharType.IsWhiteSpace(_chars[_curPos + 1]))
				{
					if (IgnoreEntityReferences)
					{
						_curPos++;
					}
					else
					{
						HandleEntityReference(true, false, false);
					}
					continue;
				}
				goto default;
			default:
				if (P_0 && !_whitespaceSeen && _scanningFunction != ScanningFunction.ParamEntitySpace)
				{
					Throw(_curPos, "Xml_ExpectingWhiteSpace", ParseUnexpectedToken(_curPos));
				}
				_tokenStartPos = _curPos;
				while (true)
				{
					switch (_scanningFunction)
					{
					case ScanningFunction.Name:
						return ScanNameExpected();
					case ScanningFunction.QName:
						return ScanQNameExpected();
					case ScanningFunction.Nmtoken:
						return ScanNmtokenExpected();
					case ScanningFunction.SubsetContent:
						return ScanSubsetContent();
					case ScanningFunction.Doctype1:
						return ScanDoctype1();
					case ScanningFunction.Doctype2:
						return ScanDoctype2();
					case ScanningFunction.Element1:
						return ScanElement1();
					case ScanningFunction.Element2:
						return ScanElement2();
					case ScanningFunction.Element3:
						return ScanElement3();
					case ScanningFunction.Element4:
						return ScanElement4();
					case ScanningFunction.Element5:
						return ScanElement5();
					case ScanningFunction.Element6:
						return ScanElement6();
					case ScanningFunction.Element7:
						return ScanElement7();
					case ScanningFunction.Attlist1:
						return ScanAttlist1();
					case ScanningFunction.Attlist2:
						return ScanAttlist2();
					case ScanningFunction.Attlist3:
						return ScanAttlist3();
					case ScanningFunction.Attlist4:
						return ScanAttlist4();
					case ScanningFunction.Attlist5:
						return ScanAttlist5();
					case ScanningFunction.Attlist6:
						return ScanAttlist6();
					case ScanningFunction.Attlist7:
						return ScanAttlist7();
					case ScanningFunction.Notation1:
						return ScanNotation1();
					case ScanningFunction.SystemId:
						return ScanSystemId();
					case ScanningFunction.PublicId1:
						return ScanPublicId1();
					case ScanningFunction.PublicId2:
						return ScanPublicId2();
					case ScanningFunction.Entity1:
						return ScanEntity1();
					case ScanningFunction.Entity2:
						return ScanEntity2();
					case ScanningFunction.Entity3:
						return ScanEntity3();
					case ScanningFunction.CondSection1:
						return ScanCondSection1();
					case ScanningFunction.CondSection2:
						return ScanCondSection2();
					case ScanningFunction.CondSection3:
						return ScanCondSection3();
					case ScanningFunction.ClosingTag:
						return ScanClosingTag();
					case ScanningFunction.ParamEntitySpace:
						break;
					default:
						return Token.None;
					}
					_whitespaceSeen = true;
					_scanningFunction = _savedScanningFunction;
				}
			}
			if ((_readerAdapter.IsEof || ReadData() == 0) && !HandleEntityEnd(false))
			{
				if (_scanningFunction == ScanningFunction.SubsetContent)
				{
					break;
				}
				Throw(_curPos, "Xml_IncompleteDtdContent");
			}
		}
		return Token.Eof;
	}

	private Token ScanSubsetContent()
	{
		while (true)
		{
			char c = _chars[_curPos];
			if (c != '<')
			{
				if (c != ']')
				{
					goto IL_04f3;
				}
				if (_charsUsed - _curPos >= 2 || _readerAdapter.IsEof)
				{
					if (_chars[_curPos + 1] != ']')
					{
						_curPos++;
						_scanningFunction = ScanningFunction.ClosingTag;
						return Token.RightBracket;
					}
					if (_charsUsed - _curPos >= 3 || _readerAdapter.IsEof)
					{
						if (_chars[_curPos + 1] == ']' && _chars[_curPos + 2] == '>')
						{
							break;
						}
						goto IL_04f3;
					}
				}
			}
			else
			{
				switch (_chars[_curPos + 1])
				{
				case '!':
					switch (_chars[_curPos + 2])
					{
					case 'E':
						if (_chars[_curPos + 3] == 'L')
						{
							if (_charsUsed - _curPos >= 9)
							{
								if (_chars[_curPos + 4] != 'E' || _chars[_curPos + 5] != 'M' || _chars[_curPos + 6] != 'E' || _chars[_curPos + 7] != 'N' || _chars[_curPos + 8] != 'T')
								{
									Throw(_curPos, "Xml_ExpectDtdMarkup");
								}
								_curPos += 9;
								_scanningFunction = ScanningFunction.QName;
								_nextScanningFunction = ScanningFunction.Element1;
								return Token.ElementDecl;
							}
						}
						else if (_chars[_curPos + 3] == 'N')
						{
							if (_charsUsed - _curPos >= 8)
							{
								if (_chars[_curPos + 4] != 'T' || _chars[_curPos + 5] != 'I' || _chars[_curPos + 6] != 'T' || _chars[_curPos + 7] != 'Y')
								{
									Throw(_curPos, "Xml_ExpectDtdMarkup");
								}
								_curPos += 8;
								_scanningFunction = ScanningFunction.Entity1;
								return Token.EntityDecl;
							}
						}
						else if (_charsUsed - _curPos >= 4)
						{
							Throw(_curPos, "Xml_ExpectDtdMarkup");
							return Token.None;
						}
						break;
					case 'A':
						if (_charsUsed - _curPos >= 9)
						{
							if (_chars[_curPos + 3] != 'T' || _chars[_curPos + 4] != 'T' || _chars[_curPos + 5] != 'L' || _chars[_curPos + 6] != 'I' || _chars[_curPos + 7] != 'S' || _chars[_curPos + 8] != 'T')
							{
								Throw(_curPos, "Xml_ExpectDtdMarkup");
							}
							_curPos += 9;
							_scanningFunction = ScanningFunction.QName;
							_nextScanningFunction = ScanningFunction.Attlist1;
							return Token.AttlistDecl;
						}
						break;
					case 'N':
						if (_charsUsed - _curPos >= 10)
						{
							if (_chars[_curPos + 3] != 'O' || _chars[_curPos + 4] != 'T' || _chars[_curPos + 5] != 'A' || _chars[_curPos + 6] != 'T' || _chars[_curPos + 7] != 'I' || _chars[_curPos + 8] != 'O' || _chars[_curPos + 9] != 'N')
							{
								Throw(_curPos, "Xml_ExpectDtdMarkup");
							}
							_curPos += 10;
							_scanningFunction = ScanningFunction.Name;
							_nextScanningFunction = ScanningFunction.Notation1;
							return Token.NotationDecl;
						}
						break;
					case '[':
						_curPos += 3;
						_scanningFunction = ScanningFunction.CondSection1;
						return Token.CondSectionStart;
					case '-':
						if (_chars[_curPos + 3] == '-')
						{
							_curPos += 4;
							return Token.Comment;
						}
						if (_charsUsed - _curPos >= 4)
						{
							Throw(_curPos, "Xml_ExpectDtdMarkup");
						}
						break;
					default:
						if (_charsUsed - _curPos >= 3)
						{
							Throw(_curPos + 2, "Xml_ExpectDtdMarkup");
						}
						break;
					}
					break;
				case '?':
					_curPos += 2;
					return Token.PI;
				default:
					if (_charsUsed - _curPos >= 2)
					{
						Throw(_curPos, "Xml_ExpectDtdMarkup");
						return Token.None;
					}
					break;
				}
			}
			goto IL_0513;
			IL_0513:
			if (ReadData() == 0)
			{
				Throw(_charsUsed, "Xml_IncompleteDtdContent");
			}
			continue;
			IL_04f3:
			if (_charsUsed - _curPos != 0)
			{
				Throw(_curPos, "Xml_ExpectDtdMarkup");
			}
			goto IL_0513;
		}
		_curPos += 3;
		return Token.CondSectionEnd;
	}

	private Token ScanNameExpected()
	{
		ScanName();
		_scanningFunction = _nextScanningFunction;
		return Token.Name;
	}

	private Token ScanQNameExpected()
	{
		ScanQName();
		_scanningFunction = _nextScanningFunction;
		return Token.QName;
	}

	private Token ScanNmtokenExpected()
	{
		ScanNmtoken();
		_scanningFunction = _nextScanningFunction;
		return Token.Nmtoken;
	}

	private Token ScanDoctype1()
	{
		switch (_chars[_curPos])
		{
		case 'P':
			if (!EatPublicKeyword())
			{
				Throw(_curPos, "Xml_ExpectExternalOrClose");
			}
			_nextScanningFunction = ScanningFunction.Doctype2;
			_scanningFunction = ScanningFunction.PublicId1;
			return Token.PUBLIC;
		case 'S':
			if (!EatSystemKeyword())
			{
				Throw(_curPos, "Xml_ExpectExternalOrClose");
			}
			_nextScanningFunction = ScanningFunction.Doctype2;
			_scanningFunction = ScanningFunction.SystemId;
			return Token.SYSTEM;
		case '[':
			_curPos++;
			_scanningFunction = ScanningFunction.SubsetContent;
			return Token.LeftBracket;
		case '>':
			_curPos++;
			_scanningFunction = ScanningFunction.SubsetContent;
			return Token.GreaterThan;
		default:
			Throw(_curPos, "Xml_ExpectExternalOrClose");
			return Token.None;
		}
	}

	private Token ScanDoctype2()
	{
		switch (_chars[_curPos])
		{
		case '[':
			_curPos++;
			_scanningFunction = ScanningFunction.SubsetContent;
			return Token.LeftBracket;
		case '>':
			_curPos++;
			_scanningFunction = ScanningFunction.SubsetContent;
			return Token.GreaterThan;
		default:
			Throw(_curPos, "Xml_ExpectSubOrClose");
			return Token.None;
		}
	}

	private Token ScanClosingTag()
	{
		if (_chars[_curPos] != '>')
		{
			ThrowUnexpectedToken(_curPos, ">");
		}
		_curPos++;
		_scanningFunction = ScanningFunction.SubsetContent;
		return Token.GreaterThan;
	}

	private Token ScanElement1()
	{
		while (true)
		{
			char c = _chars[_curPos];
			if (c != '(')
			{
				if (c != 'A')
				{
					if (c == 'E')
					{
						if (_charsUsed - _curPos < 5)
						{
							goto IL_011b;
						}
						if (_chars[_curPos + 1] == 'M' && _chars[_curPos + 2] == 'P' && _chars[_curPos + 3] == 'T' && _chars[_curPos + 4] == 'Y')
						{
							_curPos += 5;
							_scanningFunction = ScanningFunction.ClosingTag;
							return Token.EMPTY;
						}
					}
				}
				else
				{
					if (_charsUsed - _curPos < 3)
					{
						goto IL_011b;
					}
					if (_chars[_curPos + 1] == 'N' && _chars[_curPos + 2] == 'Y')
					{
						break;
					}
				}
				Throw(_curPos, "Xml_InvalidContentModel");
				goto IL_011b;
			}
			_scanningFunction = ScanningFunction.Element2;
			_curPos++;
			return Token.LeftParen;
			IL_011b:
			if (ReadData() == 0)
			{
				Throw(_curPos, "Xml_IncompleteDtdContent");
			}
		}
		_curPos += 3;
		_scanningFunction = ScanningFunction.ClosingTag;
		return Token.ANY;
	}

	private Token ScanElement2()
	{
		if (_chars[_curPos] == '#')
		{
			while (_charsUsed - _curPos < 7)
			{
				if (ReadData() == 0)
				{
					Throw(_curPos, "Xml_IncompleteDtdContent");
				}
			}
			if (_chars.AsSpan(_curPos + 1).StartsWith("PCDATA"))
			{
				_curPos += 7;
				_scanningFunction = ScanningFunction.Element6;
				return Token.PCDATA;
			}
			Throw(_curPos + 1, "Xml_ExpectPcData");
		}
		_scanningFunction = ScanningFunction.Element3;
		return Token.None;
	}

	private Token ScanElement3()
	{
		switch (_chars[_curPos])
		{
		case '(':
			_curPos++;
			return Token.LeftParen;
		case '>':
			_curPos++;
			_scanningFunction = ScanningFunction.SubsetContent;
			return Token.GreaterThan;
		default:
			ScanQName();
			_scanningFunction = ScanningFunction.Element4;
			return Token.QName;
		}
	}

	private Token ScanElement4()
	{
		_scanningFunction = ScanningFunction.Element5;
		Token result;
		switch (_chars[_curPos])
		{
		case '*':
			result = Token.Star;
			break;
		case '?':
			result = Token.QMark;
			break;
		case '+':
			result = Token.Plus;
			break;
		default:
			return Token.None;
		}
		if (_whitespaceSeen)
		{
			Throw(_curPos, "Xml_ExpectNoWhitespace");
		}
		_curPos++;
		return result;
	}

	private Token ScanElement5()
	{
		switch (_chars[_curPos])
		{
		case ',':
			_curPos++;
			_scanningFunction = ScanningFunction.Element3;
			return Token.Comma;
		case '|':
			_curPos++;
			_scanningFunction = ScanningFunction.Element3;
			return Token.Or;
		case ')':
			_curPos++;
			_scanningFunction = ScanningFunction.Element4;
			return Token.RightParen;
		case '>':
			_curPos++;
			_scanningFunction = ScanningFunction.SubsetContent;
			return Token.GreaterThan;
		default:
			Throw(_curPos, "Xml_ExpectOp");
			return Token.None;
		}
	}

	private Token ScanElement6()
	{
		switch (_chars[_curPos])
		{
		case ')':
			_curPos++;
			_scanningFunction = ScanningFunction.Element7;
			return Token.RightParen;
		case '|':
			_curPos++;
			_nextScanningFunction = ScanningFunction.Element6;
			_scanningFunction = ScanningFunction.QName;
			return Token.Or;
		default:
			ThrowUnexpectedToken(_curPos, ")", "|");
			return Token.None;
		}
	}

	private Token ScanElement7()
	{
		_scanningFunction = ScanningFunction.ClosingTag;
		if (_chars[_curPos] == '*' && !_whitespaceSeen)
		{
			_curPos++;
			return Token.Star;
		}
		return Token.None;
	}

	private Token ScanAttlist1()
	{
		char c = _chars[_curPos];
		if (c == '>')
		{
			_curPos++;
			_scanningFunction = ScanningFunction.SubsetContent;
			return Token.GreaterThan;
		}
		if (!_whitespaceSeen)
		{
			Throw(_curPos, "Xml_ExpectingWhiteSpace", ParseUnexpectedToken(_curPos));
		}
		ScanQName();
		_scanningFunction = ScanningFunction.Attlist2;
		return Token.QName;
	}

	private Token ScanAttlist2()
	{
		while (true)
		{
			switch (_chars[_curPos])
			{
			case '(':
				_curPos++;
				_scanningFunction = ScanningFunction.Nmtoken;
				_nextScanningFunction = ScanningFunction.Attlist5;
				return Token.LeftParen;
			case 'C':
				if (_charsUsed - _curPos >= 5)
				{
					if (_chars[_curPos + 1] != 'D' || _chars[_curPos + 2] != 'A' || _chars[_curPos + 3] != 'T' || _chars[_curPos + 4] != 'A')
					{
						Throw(_curPos, "Xml_InvalidAttributeType1");
					}
					_curPos += 5;
					_scanningFunction = ScanningFunction.Attlist6;
					return Token.CDATA;
				}
				break;
			case 'E':
				if (_charsUsed - _curPos < 9)
				{
					break;
				}
				_scanningFunction = ScanningFunction.Attlist6;
				if (_chars[_curPos + 1] != 'N' || _chars[_curPos + 2] != 'T' || _chars[_curPos + 3] != 'I' || _chars[_curPos + 4] != 'T')
				{
					Throw(_curPos, "Xml_InvalidAttributeType");
				}
				switch (_chars[_curPos + 5])
				{
				case 'I':
					if (_chars[_curPos + 6] != 'E' || _chars[_curPos + 7] != 'S')
					{
						Throw(_curPos, "Xml_InvalidAttributeType");
					}
					_curPos += 8;
					return Token.ENTITIES;
				case 'Y':
					_curPos += 6;
					return Token.ENTITY;
				}
				Throw(_curPos, "Xml_InvalidAttributeType");
				break;
			case 'I':
				if (_charsUsed - _curPos >= 6)
				{
					_scanningFunction = ScanningFunction.Attlist6;
					if (_chars[_curPos + 1] != 'D')
					{
						Throw(_curPos, "Xml_InvalidAttributeType");
					}
					if (_chars[_curPos + 2] != 'R')
					{
						_curPos += 2;
						return Token.ID;
					}
					if (_chars[_curPos + 3] != 'E' || _chars[_curPos + 4] != 'F')
					{
						Throw(_curPos, "Xml_InvalidAttributeType");
					}
					if (_chars[_curPos + 5] != 'S')
					{
						_curPos += 5;
						return Token.IDREF;
					}
					_curPos += 6;
					return Token.IDREFS;
				}
				break;
			case 'N':
				if (_charsUsed - _curPos < 8 && !_readerAdapter.IsEof)
				{
					break;
				}
				switch (_chars[_curPos + 1])
				{
				case 'O':
					if (_chars[_curPos + 2] != 'T' || _chars[_curPos + 3] != 'A' || _chars[_curPos + 4] != 'T' || _chars[_curPos + 5] != 'I' || _chars[_curPos + 6] != 'O' || _chars[_curPos + 7] != 'N')
					{
						Throw(_curPos, "Xml_InvalidAttributeType");
					}
					_curPos += 8;
					_scanningFunction = ScanningFunction.Attlist3;
					return Token.NOTATION;
				case 'M':
					if (_chars[_curPos + 2] != 'T' || _chars[_curPos + 3] != 'O' || _chars[_curPos + 4] != 'K' || _chars[_curPos + 5] != 'E' || _chars[_curPos + 6] != 'N')
					{
						Throw(_curPos, "Xml_InvalidAttributeType");
					}
					_scanningFunction = ScanningFunction.Attlist6;
					if (_chars[_curPos + 7] == 'S')
					{
						_curPos += 8;
						return Token.NMTOKENS;
					}
					_curPos += 7;
					return Token.NMTOKEN;
				}
				Throw(_curPos, "Xml_InvalidAttributeType");
				break;
			default:
				Throw(_curPos, "Xml_InvalidAttributeType");
				break;
			}
			if (ReadData() == 0)
			{
				Throw(_curPos, "Xml_IncompleteDtdContent");
			}
		}
	}

	private Token ScanAttlist3()
	{
		if (_chars[_curPos] == '(')
		{
			_curPos++;
			_scanningFunction = ScanningFunction.Name;
			_nextScanningFunction = ScanningFunction.Attlist4;
			return Token.LeftParen;
		}
		ThrowUnexpectedToken(_curPos, "(");
		return Token.None;
	}

	private Token ScanAttlist4()
	{
		switch (_chars[_curPos])
		{
		case ')':
			_curPos++;
			_scanningFunction = ScanningFunction.Attlist6;
			return Token.RightParen;
		case '|':
			_curPos++;
			_scanningFunction = ScanningFunction.Name;
			_nextScanningFunction = ScanningFunction.Attlist4;
			return Token.Or;
		default:
			ThrowUnexpectedToken(_curPos, ")", "|");
			return Token.None;
		}
	}

	private Token ScanAttlist5()
	{
		switch (_chars[_curPos])
		{
		case ')':
			_curPos++;
			_scanningFunction = ScanningFunction.Attlist6;
			return Token.RightParen;
		case '|':
			_curPos++;
			_scanningFunction = ScanningFunction.Nmtoken;
			_nextScanningFunction = ScanningFunction.Attlist5;
			return Token.Or;
		default:
			ThrowUnexpectedToken(_curPos, ")", "|");
			return Token.None;
		}
	}

	private Token ScanAttlist6()
	{
		while (true)
		{
			switch (_chars[_curPos])
			{
			case '"':
			case '\'':
				ScanLiteral(LiteralType.AttributeValue);
				_scanningFunction = ScanningFunction.Attlist1;
				return Token.Literal;
			case '#':
				if (_charsUsed - _curPos < 6)
				{
					break;
				}
				switch (_chars[_curPos + 1])
				{
				case 'R':
					if (_charsUsed - _curPos >= 9)
					{
						if (_chars[_curPos + 2] != 'E' || _chars[_curPos + 3] != 'Q' || _chars[_curPos + 4] != 'U' || _chars[_curPos + 5] != 'I' || _chars[_curPos + 6] != 'R' || _chars[_curPos + 7] != 'E' || _chars[_curPos + 8] != 'D')
						{
							Throw(_curPos, "Xml_ExpectAttType");
						}
						_curPos += 9;
						_scanningFunction = ScanningFunction.Attlist1;
						return Token.REQUIRED;
					}
					break;
				case 'I':
					if (_charsUsed - _curPos >= 8)
					{
						if (_chars[_curPos + 2] != 'M' || _chars[_curPos + 3] != 'P' || _chars[_curPos + 4] != 'L' || _chars[_curPos + 5] != 'I' || _chars[_curPos + 6] != 'E' || _chars[_curPos + 7] != 'D')
						{
							Throw(_curPos, "Xml_ExpectAttType");
						}
						_curPos += 8;
						_scanningFunction = ScanningFunction.Attlist1;
						return Token.IMPLIED;
					}
					break;
				case 'F':
					if (_chars[_curPos + 2] != 'I' || _chars[_curPos + 3] != 'X' || _chars[_curPos + 4] != 'E' || _chars[_curPos + 5] != 'D')
					{
						Throw(_curPos, "Xml_ExpectAttType");
					}
					_curPos += 6;
					_scanningFunction = ScanningFunction.Attlist7;
					return Token.FIXED;
				default:
					Throw(_curPos, "Xml_ExpectAttType");
					break;
				}
				break;
			default:
				Throw(_curPos, "Xml_ExpectAttType");
				break;
			}
			if (ReadData() == 0)
			{
				Throw(_curPos, "Xml_IncompleteDtdContent");
			}
		}
	}

	private Token ScanAttlist7()
	{
		char c = _chars[_curPos];
		if (c == '"' || c == '\'')
		{
			ScanLiteral(LiteralType.AttributeValue);
			_scanningFunction = ScanningFunction.Attlist1;
			return Token.Literal;
		}
		ThrowUnexpectedToken(_curPos, "\"", "'");
		return Token.None;
	}

	private Token ScanLiteral(LiteralType P_0)
	{
		char c = _chars[_curPos];
		char c2 = ((P_0 == LiteralType.AttributeValue) ? ' ' : '\n');
		int currentEntityId = _currentEntityId;
		_literalLineInfo.Set(LineNo, LinePos);
		_curPos++;
		_tokenStartPos = _curPos;
		_stringBuilder.Length = 0;
		while (true)
		{
			if (XmlCharType.IsAttributeValueChar(_chars[_curPos]) && _chars[_curPos] != '%')
			{
				_curPos++;
				continue;
			}
			if (_chars[_curPos] == c && _currentEntityId == currentEntityId)
			{
				break;
			}
			int num = _curPos - _tokenStartPos;
			if (num > 0)
			{
				_stringBuilder.Append(_chars, _tokenStartPos, num);
				_tokenStartPos = _curPos;
			}
			switch (_chars[_curPos])
			{
			case '"':
			case '\'':
			case '>':
				_curPos++;
				continue;
			case '\n':
				_curPos++;
				if (Normalize)
				{
					_stringBuilder.Append(c2);
					_tokenStartPos = _curPos;
				}
				_readerAdapter.OnNewLine(_curPos);
				continue;
			case '\r':
				if (_chars[_curPos + 1] == '\n')
				{
					if (Normalize)
					{
						if (P_0 == LiteralType.AttributeValue)
						{
							_stringBuilder.Append(_readerAdapter.IsEntityEolNormalized ? "  " : " ");
						}
						else
						{
							_stringBuilder.Append(_readerAdapter.IsEntityEolNormalized ? "\r\n" : "\n");
						}
						_tokenStartPos = _curPos + 2;
						SaveParsingBuffer();
						_readerAdapter.CurrentPosition++;
					}
					_curPos += 2;
				}
				else
				{
					if (_curPos + 1 == _charsUsed)
					{
						break;
					}
					_curPos++;
					if (Normalize)
					{
						_stringBuilder.Append(c2);
						_tokenStartPos = _curPos;
					}
				}
				_readerAdapter.OnNewLine(_curPos);
				continue;
			case '\t':
				if (P_0 == LiteralType.AttributeValue && Normalize)
				{
					_stringBuilder.Append(' ');
					_tokenStartPos++;
				}
				_curPos++;
				continue;
			case '<':
				if (P_0 == LiteralType.AttributeValue)
				{
					Throw(_curPos, "Xml_BadAttributeChar", XmlException.BuildCharExceptionArgs('<', '\0'));
				}
				_curPos++;
				continue;
			case '%':
				if (P_0 != LiteralType.EntityReplText)
				{
					_curPos++;
					continue;
				}
				HandleEntityReference(true, true, P_0 == LiteralType.AttributeValue);
				_tokenStartPos = _curPos;
				continue;
			case '&':
			{
				if (P_0 == LiteralType.SystemOrPublicID)
				{
					_curPos++;
					continue;
				}
				if (_curPos + 1 == _charsUsed)
				{
					break;
				}
				if (_chars[_curPos + 1] == '#')
				{
					SaveParsingBuffer();
					int num2 = _readerAdapter.ParseNumericCharRef(SaveInternalSubsetValue ? _internalSubsetValueSb : null);
					LoadParsingBuffer();
					_stringBuilder.Append(_chars, _curPos, num2 - _curPos);
					_readerAdapter.CurrentPosition = num2;
					_tokenStartPos = num2;
					_curPos = num2;
					continue;
				}
				SaveParsingBuffer();
				if (P_0 == LiteralType.AttributeValue)
				{
					int num3 = _readerAdapter.ParseNamedCharRef(true, SaveInternalSubsetValue ? _internalSubsetValueSb : null);
					LoadParsingBuffer();
					if (num3 >= 0)
					{
						_stringBuilder.Append(_chars, _curPos, num3 - _curPos);
						_readerAdapter.CurrentPosition = num3;
						_tokenStartPos = num3;
						_curPos = num3;
					}
					else
					{
						HandleEntityReference(false, true, true);
						_tokenStartPos = _curPos;
					}
					continue;
				}
				int num4 = _readerAdapter.ParseNamedCharRef(false, null);
				LoadParsingBuffer();
				if (num4 >= 0)
				{
					_tokenStartPos = _curPos;
					_curPos = num4;
					continue;
				}
				_stringBuilder.Append('&');
				_curPos++;
				_tokenStartPos = _curPos;
				XmlQualifiedName xmlQualifiedName = ScanEntityName();
				VerifyEntityReference(xmlQualifiedName, false, false, false);
				continue;
			}
			default:
			{
				if (_curPos == _charsUsed)
				{
					break;
				}
				char c3 = _chars[_curPos];
				if (XmlCharType.IsHighSurrogate(c3))
				{
					if (_curPos + 1 == _charsUsed)
					{
						break;
					}
					_curPos++;
					if (XmlCharType.IsLowSurrogate(_chars[_curPos]))
					{
						_curPos++;
						continue;
					}
				}
				ThrowInvalidChar(_chars, _charsUsed, _curPos);
				return Token.None;
			}
			}
			if ((_readerAdapter.IsEof || ReadData() == 0) && (P_0 == LiteralType.SystemOrPublicID || !HandleEntityEnd(true)))
			{
				Throw(_curPos, "Xml_UnclosedQuote");
			}
			_tokenStartPos = _curPos;
		}
		if (_stringBuilder.Length > 0)
		{
			_stringBuilder.Append(_chars, _tokenStartPos, _curPos - _tokenStartPos);
		}
		_curPos++;
		_literalQuoteChar = c;
		return Token.Literal;
	}

	private XmlQualifiedName ScanEntityName()
	{
		try
		{
			ScanName();
		}
		catch (XmlException ex)
		{
			Throw("Xml_ErrorParsingEntityName", string.Empty, ex.LineNumber, ex.LinePosition);
		}
		if (_chars[_curPos] != ';')
		{
			ThrowUnexpectedToken(_curPos, ";");
		}
		XmlQualifiedName nameQualified = GetNameQualified(false);
		_curPos++;
		return nameQualified;
	}

	private Token ScanNotation1()
	{
		switch (_chars[_curPos])
		{
		case 'P':
			if (!EatPublicKeyword())
			{
				Throw(_curPos, "Xml_ExpectExternalOrClose");
			}
			_nextScanningFunction = ScanningFunction.ClosingTag;
			_scanningFunction = ScanningFunction.PublicId1;
			return Token.PUBLIC;
		case 'S':
			if (!EatSystemKeyword())
			{
				Throw(_curPos, "Xml_ExpectExternalOrClose");
			}
			_nextScanningFunction = ScanningFunction.ClosingTag;
			_scanningFunction = ScanningFunction.SystemId;
			return Token.SYSTEM;
		default:
			Throw(_curPos, "Xml_ExpectExternalOrPublicId");
			return Token.None;
		}
	}

	private Token ScanSystemId()
	{
		if (_chars[_curPos] != '"' && _chars[_curPos] != '\'')
		{
			ThrowUnexpectedToken(_curPos, "\"", "'");
		}
		ScanLiteral(LiteralType.SystemOrPublicID);
		_scanningFunction = _nextScanningFunction;
		return Token.Literal;
	}

	private Token ScanEntity1()
	{
		if (_chars[_curPos] == '%')
		{
			_curPos++;
			_nextScanningFunction = ScanningFunction.Entity2;
			_scanningFunction = ScanningFunction.Name;
			return Token.Percent;
		}
		ScanName();
		_scanningFunction = ScanningFunction.Entity2;
		return Token.Name;
	}

	private Token ScanEntity2()
	{
		switch (_chars[_curPos])
		{
		case 'P':
			if (!EatPublicKeyword())
			{
				Throw(_curPos, "Xml_ExpectExternalOrClose");
			}
			_nextScanningFunction = ScanningFunction.Entity3;
			_scanningFunction = ScanningFunction.PublicId1;
			return Token.PUBLIC;
		case 'S':
			if (!EatSystemKeyword())
			{
				Throw(_curPos, "Xml_ExpectExternalOrClose");
			}
			_nextScanningFunction = ScanningFunction.Entity3;
			_scanningFunction = ScanningFunction.SystemId;
			return Token.SYSTEM;
		case '"':
		case '\'':
			ScanLiteral(LiteralType.EntityReplText);
			_scanningFunction = ScanningFunction.ClosingTag;
			return Token.Literal;
		default:
			Throw(_curPos, "Xml_ExpectExternalIdOrEntityValue");
			return Token.None;
		}
	}

	private Token ScanEntity3()
	{
		if (_chars[_curPos] == 'N')
		{
			do
			{
				if (_charsUsed - _curPos >= 5)
				{
					if (_chars[_curPos + 1] != 'D' || _chars[_curPos + 2] != 'A' || _chars[_curPos + 3] != 'T' || _chars[_curPos + 4] != 'A')
					{
						break;
					}
					_curPos += 5;
					_scanningFunction = ScanningFunction.Name;
					_nextScanningFunction = ScanningFunction.ClosingTag;
					return Token.NData;
				}
			}
			while (ReadData() != 0);
		}
		_scanningFunction = ScanningFunction.ClosingTag;
		return Token.None;
	}

	private Token ScanPublicId1()
	{
		if (_chars[_curPos] != '"' && _chars[_curPos] != '\'')
		{
			ThrowUnexpectedToken(_curPos, "\"", "'");
		}
		ScanLiteral(LiteralType.SystemOrPublicID);
		_scanningFunction = ScanningFunction.PublicId2;
		return Token.Literal;
	}

	private Token ScanPublicId2()
	{
		if (_chars[_curPos] != '"' && _chars[_curPos] != '\'')
		{
			_scanningFunction = _nextScanningFunction;
			return Token.None;
		}
		ScanLiteral(LiteralType.SystemOrPublicID);
		_scanningFunction = _nextScanningFunction;
		return Token.Literal;
	}

	private Token ScanCondSection1()
	{
		if (_chars[_curPos] != 'I')
		{
			Throw(_curPos, "Xml_ExpectIgnoreOrInclude");
		}
		_curPos++;
		while (true)
		{
			if (_charsUsed - _curPos >= 5)
			{
				char c = _chars[_curPos];
				if (c == 'G')
				{
					if (_chars[_curPos + 1] != 'N' || _chars[_curPos + 2] != 'O' || _chars[_curPos + 3] != 'R' || _chars[_curPos + 4] != 'E' || XmlCharType.IsNameSingleChar(_chars[_curPos + 5]))
					{
						break;
					}
					_nextScanningFunction = ScanningFunction.CondSection3;
					_scanningFunction = ScanningFunction.CondSection2;
					_curPos += 5;
					return Token.IGNORE;
				}
				if (c != 'N')
				{
					break;
				}
				if (_charsUsed - _curPos >= 6)
				{
					if (_chars[_curPos + 1] != 'C' || _chars[_curPos + 2] != 'L' || _chars[_curPos + 3] != 'U' || _chars[_curPos + 4] != 'D' || _chars[_curPos + 5] != 'E' || XmlCharType.IsNameSingleChar(_chars[_curPos + 6]))
					{
						break;
					}
					_nextScanningFunction = ScanningFunction.SubsetContent;
					_scanningFunction = ScanningFunction.CondSection2;
					_curPos += 6;
					return Token.INCLUDE;
				}
			}
			if (ReadData() == 0)
			{
				Throw(_curPos, "Xml_IncompleteDtdContent");
			}
		}
		Throw(_curPos - 1, "Xml_ExpectIgnoreOrInclude");
		return Token.None;
	}

	private Token ScanCondSection2()
	{
		if (_chars[_curPos] != '[')
		{
			ThrowUnexpectedToken(_curPos, "[");
		}
		_curPos++;
		_scanningFunction = _nextScanningFunction;
		return Token.LeftBracket;
	}

	private Token ScanCondSection3()
	{
		int num = 0;
		while (true)
		{
			if (XmlCharType.IsTextChar(_chars[_curPos]) && _chars[_curPos] != ']')
			{
				_curPos++;
				continue;
			}
			switch (_chars[_curPos])
			{
			case '\t':
			case '"':
			case '&':
			case '\'':
				_curPos++;
				continue;
			case '\n':
				_curPos++;
				_readerAdapter.OnNewLine(_curPos);
				continue;
			case '\r':
				if (_chars[_curPos + 1] == '\n')
				{
					_curPos += 2;
				}
				else
				{
					if (_curPos + 1 >= _charsUsed && !_readerAdapter.IsEof)
					{
						break;
					}
					_curPos++;
				}
				_readerAdapter.OnNewLine(_curPos);
				continue;
			case '<':
				if (_charsUsed - _curPos >= 3)
				{
					if (_chars[_curPos + 1] != '!' || _chars[_curPos + 2] != '[')
					{
						_curPos++;
						continue;
					}
					num++;
					_curPos += 3;
					continue;
				}
				break;
			case ']':
				if (_charsUsed - _curPos < 3)
				{
					break;
				}
				if (_chars[_curPos + 1] != ']' || _chars[_curPos + 2] != '>')
				{
					_curPos++;
					continue;
				}
				if (num > 0)
				{
					num--;
					_curPos += 3;
					continue;
				}
				_curPos += 3;
				_scanningFunction = ScanningFunction.SubsetContent;
				return Token.CondSectionEnd;
			default:
			{
				if (_curPos == _charsUsed)
				{
					break;
				}
				char c = _chars[_curPos];
				if (XmlCharType.IsHighSurrogate(c))
				{
					if (_curPos + 1 == _charsUsed)
					{
						break;
					}
					_curPos++;
					if (XmlCharType.IsLowSurrogate(_chars[_curPos]))
					{
						_curPos++;
						continue;
					}
				}
				ThrowInvalidChar(_chars, _charsUsed, _curPos);
				return Token.None;
			}
			}
			if (_readerAdapter.IsEof || ReadData() == 0)
			{
				if (HandleEntityEnd(false))
				{
					continue;
				}
				Throw(_curPos, "Xml_UnclosedConditionalSection");
			}
			_tokenStartPos = _curPos;
		}
	}

	private void ScanName()
	{
		ScanQName(false);
	}

	private void ScanQName()
	{
		ScanQName(SupportNamespaces);
	}

	private void ScanQName(bool P_0)
	{
		_tokenStartPos = _curPos;
		int num = -1;
		while (true)
		{
			if (XmlCharType.IsStartNCNameSingleChar(_chars[_curPos]) || _chars[_curPos] == ':')
			{
				_curPos++;
			}
			else if (_curPos + 1 >= _charsUsed)
			{
				if (ReadDataInName())
				{
					continue;
				}
				Throw(_curPos, "Xml_UnexpectedEOF", "Name");
			}
			else
			{
				Throw(_curPos, "Xml_BadStartNameChar", XmlException.BuildCharExceptionArgs(_chars, _charsUsed, _curPos));
			}
			while (true)
			{
				if (XmlCharType.IsNCNameSingleChar(_chars[_curPos]))
				{
					_curPos++;
					continue;
				}
				if (_chars[_curPos] == ':')
				{
					if (P_0)
					{
						break;
					}
					_curPos++;
					continue;
				}
				if (_curPos == _charsUsed)
				{
					if (ReadDataInName())
					{
						continue;
					}
					if (_tokenStartPos == _curPos)
					{
						Throw(_curPos, "Xml_UnexpectedEOF", "Name");
					}
				}
				_colonPos = ((num == -1) ? (-1) : (_tokenStartPos + num));
				return;
			}
			if (num != -1)
			{
				Throw(_curPos, "Xml_BadNameChar", XmlException.BuildCharExceptionArgs(':', '\0'));
			}
			num = _curPos - _tokenStartPos;
			_curPos++;
		}
	}

	private bool ReadDataInName()
	{
		int num = _curPos - _tokenStartPos;
		_curPos = _tokenStartPos;
		bool result = ReadData() != 0;
		_tokenStartPos = _curPos;
		_curPos += num;
		return result;
	}

	private void ScanNmtoken()
	{
		_tokenStartPos = _curPos;
		int num;
		while (true)
		{
			if (XmlCharType.IsNCNameSingleChar(_chars[_curPos]) || _chars[_curPos] == ':')
			{
				_curPos++;
				continue;
			}
			if (_curPos < _charsUsed)
			{
				if (_curPos - _tokenStartPos == 0)
				{
					Throw(_curPos, "Xml_BadNameChar", XmlException.BuildCharExceptionArgs(_chars, _charsUsed, _curPos));
				}
				return;
			}
			num = _curPos - _tokenStartPos;
			_curPos = _tokenStartPos;
			if (ReadData() == 0)
			{
				if (num > 0)
				{
					break;
				}
				Throw(_curPos, "Xml_UnexpectedEOF", "NmToken");
			}
			_tokenStartPos = _curPos;
			_curPos += num;
		}
		_tokenStartPos = _curPos;
		_curPos += num;
	}

	private bool EatPublicKeyword()
	{
		while (_charsUsed - _curPos < 6)
		{
			if (ReadData() == 0)
			{
				return false;
			}
		}
		if (!_chars.AsSpan(_curPos + 1).StartsWith("UBLIC"))
		{
			return false;
		}
		_curPos += 6;
		return true;
	}

	private bool EatSystemKeyword()
	{
		while (_charsUsed - _curPos < 6)
		{
			if (ReadData() == 0)
			{
				return false;
			}
		}
		if (!_chars.AsSpan(_curPos + 1).StartsWith("YSTEM"))
		{
			return false;
		}
		_curPos += 6;
		return true;
	}

	private XmlQualifiedName GetNameQualified(bool P_0)
	{
		if (_colonPos == -1)
		{
			return new XmlQualifiedName(_nameTable.Add(_chars, _tokenStartPos, _curPos - _tokenStartPos));
		}
		if (P_0)
		{
			return new XmlQualifiedName(_nameTable.Add(_chars, _colonPos + 1, _curPos - _colonPos - 1), _nameTable.Add(_chars, _tokenStartPos, _colonPos - _tokenStartPos));
		}
		Throw(_tokenStartPos, "Xml_ColonInLocalName", GetNameString());
		return null;
	}

	private string GetNameString()
	{
		return new string(_chars, _tokenStartPos, _curPos - _tokenStartPos);
	}

	private string GetNmtokenString()
	{
		return GetNameString();
	}

	private string GetValue()
	{
		if (_stringBuilder.Length == 0)
		{
			return new string(_chars, _tokenStartPos, _curPos - _tokenStartPos - 1);
		}
		return _stringBuilder.ToString();
	}

	private string GetValueWithStrippedSpaces()
	{
		string text = ((_stringBuilder.Length == 0) ? new string(_chars, _tokenStartPos, _curPos - _tokenStartPos - 1) : _stringBuilder.ToString());
		return StripSpaces(text);
	}

	private int ReadData()
	{
		SaveParsingBuffer();
		int result = _readerAdapter.ReadData();
		LoadParsingBuffer();
		return result;
	}

	private void LoadParsingBuffer()
	{
		_chars = _readerAdapter.ParsingBuffer;
		_charsUsed = _readerAdapter.ParsingBufferLength;
		_curPos = _readerAdapter.CurrentPosition;
	}

	private void SaveParsingBuffer()
	{
		SaveParsingBuffer(_curPos);
	}

	private void SaveParsingBuffer(int P_0)
	{
		if (SaveInternalSubsetValue)
		{
			int currentPosition = _readerAdapter.CurrentPosition;
			if (P_0 - currentPosition > 0)
			{
				_internalSubsetValueSb.Append(_chars, currentPosition, P_0 - currentPosition);
			}
		}
		_readerAdapter.CurrentPosition = _curPos;
	}

	private bool HandleEntityReference(bool P_0, bool P_1, bool P_2)
	{
		_curPos++;
		return HandleEntityReference(ScanEntityName(), P_0, P_1, P_2);
	}

	private bool HandleEntityReference(XmlQualifiedName P_0, bool P_1, bool P_2, bool P_3)
	{
		SaveParsingBuffer();
		if (P_1 && ParsingInternalSubset && !ParsingTopLevelMarkup)
		{
			Throw(_curPos - P_0.Name.Length - 1, "Xml_InvalidParEntityRef");
		}
		SchemaEntity schemaEntity = VerifyEntityReference(P_0, P_1, true, P_3);
		if (schemaEntity == null)
		{
			return false;
		}
		if (schemaEntity.ParsingInProgress)
		{
			Throw(_curPos - P_0.Name.Length - 1, P_1 ? "Xml_RecursiveParEntity" : "Xml_RecursiveGenEntity", P_0.Name);
		}
		int currentEntityId;
		if (schemaEntity.IsExternal)
		{
			if (!_readerAdapter.PushEntity(schemaEntity, out currentEntityId))
			{
				return false;
			}
			_externalEntitiesDepth++;
		}
		else
		{
			if (schemaEntity.Text.Length == 0)
			{
				return false;
			}
			if (!_readerAdapter.PushEntity(schemaEntity, out currentEntityId))
			{
				return false;
			}
		}
		_currentEntityId = currentEntityId;
		if (P_1 && !P_2 && _scanningFunction != ScanningFunction.ParamEntitySpace)
		{
			_savedScanningFunction = _scanningFunction;
			_scanningFunction = ScanningFunction.ParamEntitySpace;
		}
		LoadParsingBuffer();
		return true;
	}

	private bool HandleEntityEnd(bool P_0)
	{
		SaveParsingBuffer();
		if (!_readerAdapter.PopEntity(out var dtdEntityInfo, out _currentEntityId))
		{
			return false;
		}
		LoadParsingBuffer();
		if (dtdEntityInfo == null)
		{
			if (_scanningFunction == ScanningFunction.ParamEntitySpace)
			{
				_scanningFunction = _savedScanningFunction;
			}
			return false;
		}
		if (dtdEntityInfo.IsExternal)
		{
			_externalEntitiesDepth--;
		}
		if (!P_0 && _scanningFunction != ScanningFunction.ParamEntitySpace)
		{
			_savedScanningFunction = _scanningFunction;
			_scanningFunction = ScanningFunction.ParamEntitySpace;
		}
		return true;
	}

	private SchemaEntity VerifyEntityReference(XmlQualifiedName P_0, bool P_1, bool P_2, bool P_3)
	{
		SchemaEntity schemaEntity;
		if (P_1)
		{
			_schemaInfo.ParameterEntities.TryGetValue(P_0, out schemaEntity);
		}
		else
		{
			_schemaInfo.GeneralEntities.TryGetValue(P_0, out schemaEntity);
		}
		if (schemaEntity == null)
		{
			if (P_1)
			{
				if (_validate)
				{
					SendValidationEvent(_curPos - P_0.Name.Length - 1, XmlSeverityType.Error, "Xml_UndeclaredParEntity", P_0.Name);
				}
			}
			else if (P_2)
			{
				if (!ParsingInternalSubset)
				{
					if (_validate)
					{
						SendValidationEvent(_curPos - P_0.Name.Length - 1, XmlSeverityType.Error, "Xml_UndeclaredEntity", P_0.Name);
					}
				}
				else
				{
					Throw(_curPos - P_0.Name.Length - 1, "Xml_UndeclaredEntity", P_0.Name);
				}
			}
			return null;
		}
		if (!schemaEntity.NData.IsEmpty)
		{
			Throw(_curPos - P_0.Name.Length - 1, "Xml_UnparsedEntityRef", P_0.Name);
		}
		if (P_3 && schemaEntity.IsExternal)
		{
			Throw(_curPos - P_0.Name.Length - 1, "Xml_ExternalEntityInAttValue", P_0.Name);
		}
		return schemaEntity;
	}

	private void SendValidationEvent(int P_0, XmlSeverityType P_1, string P_2, string P_3)
	{
		SendValidationEvent(P_1, new XmlSchemaException(P_2, P_3, BaseUriStr, LineNo, LinePos + (P_0 - _curPos)));
	}

	private void SendValidationEvent(XmlSeverityType P_0, string P_1, string P_2)
	{
		SendValidationEvent(P_0, new XmlSchemaException(P_1, P_2, BaseUriStr, LineNo, LinePos));
	}

	private void SendValidationEvent(XmlSeverityType P_0, XmlSchemaException P_1)
	{
		_readerAdapterWithValidation.ValidationEventHandling?.SendEvent(P_1, P_0);
	}

	private static bool IsAttributeValueType(Token P_0)
	{
		if (P_0 >= Token.CDATA)
		{
			return P_0 <= Token.NOTATION;
		}
		return false;
	}

	private void OnUnexpectedError()
	{
		Throw(_curPos, "Xml_InternalError");
	}

	private void Throw(int P_0, string P_1)
	{
		Throw(P_0, P_1, string.Empty);
	}

	[DoesNotReturn]
	private void Throw(int P_0, string P_1, string P_2)
	{
		_curPos = P_0;
		Uri baseUri = _readerAdapter.BaseUri;
		_readerAdapter.Throw(new XmlException(P_1, P_2, LineNo, LinePos, baseUri?.ToString()));
	}

	[DoesNotReturn]
	private void Throw(int P_0, string P_1, string[] P_2)
	{
		_curPos = P_0;
		Uri baseUri = _readerAdapter.BaseUri;
		_readerAdapter.Throw(new XmlException(P_1, P_2, LineNo, LinePos, baseUri?.ToString()));
	}

	[DoesNotReturn]
	private void Throw(string P_0, string P_1, int P_2, int P_3)
	{
		Uri baseUri = _readerAdapter.BaseUri;
		_readerAdapter.Throw(new XmlException(P_0, P_1, P_2, P_3, baseUri?.ToString()));
	}

	private void ThrowInvalidChar(int P_0, string P_1, int P_2)
	{
		Throw(P_0, "Xml_InvalidCharacter", XmlException.BuildCharExceptionArgs(P_1, P_2));
	}

	private void ThrowInvalidChar(char[] P_0, int P_1, int P_2)
	{
		Throw(P_2, "Xml_InvalidCharacter", XmlException.BuildCharExceptionArgs(P_0, P_1, P_2));
	}

	private void ThrowUnexpectedToken(int P_0, string P_1)
	{
		ThrowUnexpectedToken(P_0, P_1, null);
	}

	private void ThrowUnexpectedToken(int P_0, string P_1, string P_2)
	{
		string text = ParseUnexpectedToken(P_0);
		if (P_2 != null)
		{
			Throw(_curPos, "Xml_UnexpectedTokens2", new string[3] { text, P_1, P_2 });
		}
		else
		{
			Throw(_curPos, "Xml_UnexpectedTokenEx", new string[2] { text, P_1 });
		}
	}

	private string ParseUnexpectedToken(int P_0)
	{
		if (XmlCharType.IsNCNameSingleChar(_chars[P_0]))
		{
			int i;
			for (i = P_0; XmlCharType.IsNCNameSingleChar(_chars[i]); i++)
			{
			}
			int num = i - P_0;
			return new string(_chars, P_0, (num <= 0) ? 1 : num);
		}
		return new string(_chars, P_0, 1);
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
}
