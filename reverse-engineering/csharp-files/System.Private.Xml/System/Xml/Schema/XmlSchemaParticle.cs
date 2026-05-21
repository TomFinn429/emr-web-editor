using System.Xml.Serialization;

namespace System.Xml.Schema;

public abstract class XmlSchemaParticle : XmlSchemaAnnotated
{
	[Flags]
	private enum Occurs
	{
		None = 0,
		Min = 1,
		Max = 2
	}

	private sealed class EmptyParticle : XmlSchemaParticle
	{
	}

	private decimal _minOccurs = 1m;

	private decimal _maxOccurs = 1m;

	private Occurs _flags;

	internal static readonly XmlSchemaParticle Empty = new EmptyParticle();

	[XmlIgnore]
	public decimal MinOccurs
	{
		set
		{
			if (num < 0m || num != decimal.Truncate(num))
			{
				throw new XmlSchemaException("Sch_MinOccursInvalidXsd", string.Empty);
			}
			_minOccurs = num;
			_flags |= Occurs.Min;
		}
	}

	[XmlIgnore]
	public decimal MaxOccurs
	{
		set
		{
			if (num < 0m || num != decimal.Truncate(num))
			{
				throw new XmlSchemaException("Sch_MaxOccursInvalidXsd", string.Empty);
			}
			_maxOccurs = num;
			if (_maxOccurs == 0m && (_flags & Occurs.Min) == 0)
			{
				_minOccurs = default(decimal);
			}
			_flags |= Occurs.Max;
		}
	}
}
