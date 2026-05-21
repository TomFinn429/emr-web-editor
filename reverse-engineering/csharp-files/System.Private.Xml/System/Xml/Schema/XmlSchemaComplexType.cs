using System.ComponentModel;
using System.Xml.Serialization;

namespace System.Xml.Schema;

public class XmlSchemaComplexType : XmlSchemaType
{
	private static readonly XmlSchemaComplexType s_anyTypeLax = CreateAnyType(XmlSchemaContentProcessing.Lax);

	private static readonly XmlSchemaComplexType s_anyTypeSkip = CreateAnyType(XmlSchemaContentProcessing.Skip);

	private static readonly XmlSchemaComplexType s_untypedAnyType = CreateUntypedAnyType();

	private XmlSchemaDerivationMethod _block = XmlSchemaDerivationMethod.None;

	private XmlSchemaParticle _contentTypeParticle = XmlSchemaParticle.Empty;

	private XmlSchemaAnyAttribute _attributeWildcard;

	private byte _pvFlags;

	[XmlIgnore]
	internal static XmlSchemaComplexType AnyType => s_anyTypeLax;

	internal static ContentValidator AnyTypeContentValidator => s_anyTypeLax.ElementDecl.ContentValidator;

	[XmlAttribute("mixed")]
	[DefaultValue(false)]
	public override bool IsMixed
	{
		set
		{
			if (flag)
			{
				_pvFlags |= 2;
			}
			else
			{
				_pvFlags = (byte)(_pvFlags & -3);
			}
		}
	}

	[XmlIgnore]
	public XmlSchemaParticle ContentTypeParticle => _contentTypeParticle;

	private static XmlSchemaComplexType CreateUntypedAnyType()
	{
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		xmlSchemaComplexType.SetQualifiedName(new XmlQualifiedName("untypedAny", "http://www.w3.org/2003/11/xpath-datatypes"));
		xmlSchemaComplexType.IsMixed = true;
		xmlSchemaComplexType.SetContentTypeParticle(s_anyTypeLax.ContentTypeParticle);
		xmlSchemaComplexType.SetContentType(XmlSchemaContentType.Mixed);
		xmlSchemaComplexType.ElementDecl = SchemaElementDecl.CreateAnyTypeElementDecl();
		xmlSchemaComplexType.ElementDecl.SchemaType = xmlSchemaComplexType;
		xmlSchemaComplexType.ElementDecl.ContentValidator = AnyTypeContentValidator;
		return xmlSchemaComplexType;
	}

	private static XmlSchemaComplexType CreateAnyType(XmlSchemaContentProcessing P_0)
	{
		XmlSchemaComplexType xmlSchemaComplexType = new XmlSchemaComplexType();
		xmlSchemaComplexType.SetQualifiedName(DatatypeImplementation.QnAnyType);
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny();
		xmlSchemaAny.MinOccurs = 0m;
		xmlSchemaAny.MaxOccurs = decimal.MaxValue;
		xmlSchemaAny.ProcessContents = P_0;
		xmlSchemaAny.BuildNamespaceList(null);
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType.SetContentTypeParticle(xmlSchemaSequence);
		xmlSchemaComplexType.SetContentType(XmlSchemaContentType.Mixed);
		xmlSchemaComplexType.ElementDecl = SchemaElementDecl.CreateAnyTypeElementDecl();
		xmlSchemaComplexType.ElementDecl.SchemaType = xmlSchemaComplexType;
		ParticleContentValidator particleContentValidator = new ParticleContentValidator(XmlSchemaContentType.Mixed);
		particleContentValidator.Start();
		particleContentValidator.OpenGroup();
		particleContentValidator.AddNamespaceList(xmlSchemaAny.NamespaceList, xmlSchemaAny);
		particleContentValidator.AddStar();
		particleContentValidator.CloseGroup();
		ContentValidator contentValidator = particleContentValidator.Finish(true);
		xmlSchemaComplexType.ElementDecl.ContentValidator = contentValidator;
		XmlSchemaAnyAttribute xmlSchemaAnyAttribute = new XmlSchemaAnyAttribute();
		xmlSchemaAnyAttribute.ProcessContents = P_0;
		xmlSchemaAnyAttribute.BuildNamespaceList(null);
		xmlSchemaComplexType.SetAttributeWildcard(xmlSchemaAnyAttribute);
		xmlSchemaComplexType.ElementDecl.AnyAttribute = xmlSchemaAnyAttribute;
		return xmlSchemaComplexType;
	}

	internal void SetContentTypeParticle(XmlSchemaParticle P_0)
	{
		_contentTypeParticle = P_0;
	}

	internal void SetAttributeWildcard(XmlSchemaAnyAttribute P_0)
	{
		_attributeWildcard = P_0;
	}
}
