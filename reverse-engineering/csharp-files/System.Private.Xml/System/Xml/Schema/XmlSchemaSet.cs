using System.Collections;

namespace System.Xml.Schema;

public class XmlSchemaSet
{
	private readonly XmlNameTable _nameTable;

	private readonly SortedList _schemas;

	private readonly ValidationEventHandler _internalEventHandler;

	private ValidationEventHandler _eventHandler;

	private readonly Hashtable _schemaLocations;

	private readonly Hashtable _chameleonSchemas;

	private readonly Hashtable _targetNamespaces;

	private bool _compileAll;

	private SchemaInfo _cachedCompiledInfo;

	private readonly XmlReaderSettings _readerSettings;

	private XmlSchemaCompilationSettings _compilationSettings;

	public XmlSchemaSet()
		: this(new NameTable())
	{
	}

	public XmlSchemaSet(XmlNameTable P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "nameTable");
		_nameTable = P_0;
		_schemas = new SortedList();
		_schemaLocations = new Hashtable();
		_chameleonSchemas = new Hashtable();
		_targetNamespaces = new Hashtable();
		_internalEventHandler = InternalValidationCallback;
		_eventHandler = _internalEventHandler;
		_readerSettings = new XmlReaderSettings();
		if (_readerSettings.GetXmlResolver() == null)
		{
			_readerSettings.XmlResolver = new XmlUrlResolver();
			_readerSettings.IsXmlResolverSet = false;
		}
		_readerSettings.NameTable = P_0;
		_readerSettings.DtdProcessing = DtdProcessing.Prohibit;
		_compilationSettings = new XmlSchemaCompilationSettings();
		_cachedCompiledInfo = new SchemaInfo();
		_compileAll = true;
	}

	private void InternalValidationCallback(object P_0, ValidationEventArgs P_1)
	{
		if (P_1.Severity == XmlSeverityType.Error)
		{
			throw P_1.Exception;
		}
	}
}
