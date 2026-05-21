using System.Xml.Schema;

namespace System.Xml;

internal interface IValidationEventHandling
{
	void SendEvent(Exception P_0, XmlSeverityType P_1);
}
