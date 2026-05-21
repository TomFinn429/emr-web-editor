using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using zzz;

namespace DCSoft.Common;

public class ValueValidateStyle : ICloneable, z0ZzZzcuk
{
	[NonSerialized]
	private string strMessage;

	private string _RegExpression;

	private int _MaxLength;

	private string _Range;

	private int _MinLength;

	private int _MaxDecimalDigits;

	private ValueValidateLevel _Level;

	private string _IncludeKeywords;

	private double _MinValue;

	private int _ContentVersion = -1;

	private DateTime _DateTimeMaxValue = NullDateTime;

	private string _CustomMessage;

	private DateTime _DateTimeMinValue = NullDateTime;

	public static readonly DateTime NullDateTime = new DateTime(1980, 1, 1, 0, 0, 0);

	private double _MaxValue;

	private string _ValueName;

	private ValueTypeStyle _ValueType;

	private string _ExcludeKeywords;

	private int _EleStates;

	[DefaultValue(typeof(DateTime), "1980-1-1")]
	public DateTime DateTimeMinValue
	{
		get
		{
			return _DateTimeMinValue;
		}
		set
		{
			_DateTimeMinValue = value;
		}
	}

	[DefaultValue(ValueTypeStyle.Text)]
	public ValueTypeStyle ValueType
	{
		get
		{
			return _ValueType;
		}
		set
		{
			_ValueType = value;
		}
	}

	[DefaultValue(false)]
	public bool CheckDecimalDigits
	{
		get
		{
			return (_EleStates & 0x10) != 0;
		}
		set
		{
			_EleStates = (value ? (_EleStates | 0x10) : (_EleStates & -17));
		}
	}

	[DefaultValue(0.0)]
	public double MaxValue
	{
		get
		{
			return _MaxValue;
		}
		set
		{
			_MaxValue = value;
		}
	}

	[DefaultValue(typeof(DateTime), "1980-1-1")]
	public DateTime DateTimeMaxValue
	{
		get
		{
			return _DateTimeMaxValue;
		}
		set
		{
			_DateTimeMaxValue = value;
		}
	}

	[DefaultValue(0.0)]
	public double MinValue
	{
		get
		{
			return _MinValue;
		}
		set
		{
			_MinValue = value;
		}
	}

	[DefaultValue(null)]
	public string Range
	{
		get
		{
			return _Range;
		}
		set
		{
			_Range = value;
		}
	}

	[DefaultValue(null)]
	public string RegExpression
	{
		get
		{
			return _RegExpression;
		}
		set
		{
			_RegExpression = value;
		}
	}

	[DefaultValue(null)]
	public string ExcludeKeywords
	{
		get
		{
			return _ExcludeKeywords;
		}
		set
		{
			_ExcludeKeywords = value;
		}
	}

	[DefaultValue(null)]
	public string CustomMessage
	{
		get
		{
			return _CustomMessage;
		}
		set
		{
			_CustomMessage = value;
		}
	}

	[DefaultValue(null)]
	public string ValueName
	{
		get
		{
			return _ValueName;
		}
		set
		{
			_ValueName = value;
		}
	}

	[DefaultValue(0)]
	public int MaxDecimalDigits
	{
		get
		{
			return _MaxDecimalDigits;
		}
		set
		{
			_MaxDecimalDigits = value;
		}
	}

	[z0ZzZzuqh]
	public int ContentVersion
	{
		get
		{
			return _ContentVersion;
		}
		set
		{
			_ContentVersion = value;
		}
	}

	[DefaultValue(false)]
	public bool CheckMaxValue
	{
		get
		{
			return (_EleStates & 4) != 0;
		}
		set
		{
			_EleStates = (value ? (_EleStates | 4) : (_EleStates & -5));
		}
	}

	[DefaultValue(null)]
	public string IncludeKeywords
	{
		get
		{
			return _IncludeKeywords;
		}
		set
		{
			_IncludeKeywords = value;
		}
	}

	[DefaultValue(ValueValidateLevel.Error)]
	public ValueValidateLevel Level
	{
		get
		{
			return _Level;
		}
		set
		{
			_Level = value;
		}
	}

	[DefaultValue(false)]
	public bool BinaryLength
	{
		get
		{
			return (_EleStates & 2) != 0;
		}
		set
		{
			_EleStates = (value ? (_EleStates | 2) : (_EleStates & -3));
		}
	}

	[DefaultValue(0)]
	public int MinLength
	{
		get
		{
			return _MinLength;
		}
		set
		{
			_MinLength = value;
		}
	}

	[DefaultValue(0)]
	public int MaxLength
	{
		get
		{
			return _MaxLength;
		}
		set
		{
			_MaxLength = value;
		}
	}

	[JsonIgnore]
	[z0ZzZzuqh]
	public string Message
	{
		get
		{
			return strMessage;
		}
		set
		{
			strMessage = value;
		}
	}

	[DefaultValue(false)]
	[JsonIgnore]
	public bool RequiredInvalidateFlag
	{
		get
		{
			return (_EleStates & 0x20) != 0;
		}
		set
		{
			_EleStates = (value ? (_EleStates | 0x20) : (_EleStates & -33));
		}
	}

	public bool IsEmpty
	{
		get
		{
			if (Required)
			{
				return false;
			}
			if (_ValueType == ValueTypeStyle.Text)
			{
				if (CheckMaxValue || CheckMinValue)
				{
					return false;
				}
				if (ValueType == ValueTypeStyle.RegExpress && !string.IsNullOrEmpty(RegExpression))
				{
					return false;
				}
				if (_Range != null && _Range.Trim().Length > 0)
				{
					return false;
				}
				if (_ValueName != null && _ValueName.Trim().Length > 0)
				{
					return false;
				}
				if (_CustomMessage != null && _CustomMessage.Trim().Length > 0)
				{
					return false;
				}
				if (_ExcludeKeywords != null && _ExcludeKeywords.Trim().Length > 0)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	[DefaultValue(false)]
	public bool Required
	{
		get
		{
			return (_EleStates & 1) != 0;
		}
		set
		{
			_EleStates = (value ? (_EleStates | 1) : (_EleStates & -2));
		}
	}

	[DefaultValue(false)]
	public bool CheckMinValue
	{
		get
		{
			return (_EleStates & 8) != 0;
		}
		set
		{
			_EleStates = (value ? (_EleStates | 8) : (_EleStates & -9));
		}
	}

	public void DCReadString(string text)
	{
		z0ZzZzmik.z0eek(this, text);
	}

	public string DCWriteString()
	{
		z0ZzZzayk z0ZzZzayk = new z0ZzZzayk();
		if (_Level != ValueValidateLevel.Error)
		{
			z0ZzZzayk.z0eek("Level", _Level.ToString());
		}
		if (_ValueName != null && _ValueName.Length > 0)
		{
			z0ZzZzayk.z0eek("ValueName", _ValueName);
		}
		if (Required)
		{
			z0ZzZzayk.z0eek("Required", "True");
		}
		if (_ValueType != ValueTypeStyle.Text)
		{
			z0ZzZzayk.z0eek("ValueType", _ValueType.ToString());
		}
		if (BinaryLength)
		{
			z0ZzZzayk.z0eek("BinaryLength", BinaryLength.ToString());
		}
		if (_MaxLength != 0)
		{
			z0ZzZzayk.z0eek("MaxLength", _MaxLength.ToString());
		}
		if (_MinLength != 0)
		{
			z0ZzZzayk.z0eek("MinLength", _MinLength.ToString());
		}
		if (CheckMaxValue)
		{
			z0ZzZzayk.z0eek("CheckMaxValue", "True");
		}
		if (CheckMinValue)
		{
			z0ZzZzayk.z0eek("CheckMinValue", "True");
		}
		if (!z0ZzZzbok.z0eek(_MaxValue) && CheckMaxValue)
		{
			z0ZzZzayk.z0eek("MaxValue", _MaxValue.ToString());
		}
		if (!z0ZzZzbok.z0eek(_MinValue) && CheckMinValue)
		{
			z0ZzZzayk.z0eek("MinValue", _MinValue.ToString());
		}
		if (CheckDecimalDigits)
		{
			z0ZzZzayk.z0eek("CheckDecimalDigits", "True");
		}
		if (_MaxDecimalDigits != 0)
		{
			z0ZzZzayk.z0eek("MaxDecimalDigits", _MaxDecimalDigits.ToString());
		}
		if (_DateTimeMaxValue != NullDateTime)
		{
			z0ZzZzayk.z0eek("DateTimeMaxValue", z0ZzZzuyk.z0rek(_DateTimeMaxValue));
		}
		if (_DateTimeMinValue != NullDateTime)
		{
			z0ZzZzayk.z0eek("DateTimeMinValue", z0ZzZzuyk.z0rek(_DateTimeMinValue));
		}
		if (_Range != null && _Range.Length > 0)
		{
			z0ZzZzayk.z0eek("Range", _Range);
		}
		if (_RegExpression != null && _RegExpression.Length > 0)
		{
			z0ZzZzayk.z0eek("RegExpression", _RegExpression);
		}
		if (_IncludeKeywords != null && _IncludeKeywords.Length > 0)
		{
			z0ZzZzayk.z0eek("IncludeKeywords", _IncludeKeywords);
		}
		if (_ExcludeKeywords != null && _ExcludeKeywords.Length > 0)
		{
			z0ZzZzayk.z0eek("ExcludeKeywords", _ExcludeKeywords);
		}
		if (_CustomMessage != null && _CustomMessage.Length > 0)
		{
			z0ZzZzayk.z0eek("CustomMessage", _CustomMessage);
		}
		return z0ZzZzayk.ToString();
	}

	object ICloneable.Clone()
	{
		return (ValueValidateStyle)MemberwiseClone();
	}

	public ValueValidateStyle Clone()
	{
		return (ValueValidateStyle)((ICloneable)this).Clone();
	}

	public bool IsDateOrTimeType()
	{
		if (_ValueType != ValueTypeStyle.Date && _ValueType != ValueTypeStyle.Time)
		{
			return _ValueType == ValueTypeStyle.DateTime;
		}
		return true;
	}
}
