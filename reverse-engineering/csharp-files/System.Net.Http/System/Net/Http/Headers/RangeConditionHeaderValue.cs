using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http.Headers;

public class RangeConditionHeaderValue : ICloneable
{
	private readonly DateTimeOffset? _date;

	private readonly EntityTagHeaderValue _entityTag;

	public RangeConditionHeaderValue(DateTimeOffset P_0)
	{
		_date = P_0;
	}

	public RangeConditionHeaderValue(EntityTagHeaderValue P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "entityTag");
		_entityTag = P_0;
	}

	private RangeConditionHeaderValue(RangeConditionHeaderValue P_0)
	{
		_entityTag = P_0._entityTag;
		_date = P_0._date;
	}

	public override string ToString()
	{
		if (_entityTag == null)
		{
			return _date.GetValueOrDefault().ToString("r");
		}
		return _entityTag.ToString();
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is RangeConditionHeaderValue rangeConditionHeaderValue))
		{
			return false;
		}
		if (_entityTag == null)
		{
			if (rangeConditionHeaderValue._date.HasValue)
			{
				return _date.Value == rangeConditionHeaderValue._date.Value;
			}
			return false;
		}
		return _entityTag.Equals(rangeConditionHeaderValue._entityTag);
	}

	public override int GetHashCode()
	{
		if (_entityTag == null)
		{
			return _date.Value.GetHashCode();
		}
		return _entityTag.GetHashCode();
	}

	internal static int GetRangeConditionLength(string P_0, int P_1, out object P_2)
	{
		P_2 = null;
		if (string.IsNullOrEmpty(P_0) || P_1 + 1 >= P_0.Length)
		{
			return 0;
		}
		int num = P_1;
		DateTimeOffset minValue = DateTimeOffset.MinValue;
		EntityTagHeaderValue entityTagHeaderValue = null;
		char c = P_0[num];
		char c2 = P_0[num + 1];
		if (c == '"' || ((c == 'w' || c == 'W') && c2 == '/'))
		{
			int entityTagLength = EntityTagHeaderValue.GetEntityTagLength(P_0, num, out entityTagHeaderValue);
			if (entityTagLength == 0)
			{
				return 0;
			}
			num += entityTagLength;
			if (num != P_0.Length)
			{
				return 0;
			}
		}
		else
		{
			if (!HttpDateParser.TryParse(P_0.AsSpan(num), out minValue))
			{
				return 0;
			}
			num = P_0.Length;
		}
		if (entityTagHeaderValue == null)
		{
			P_2 = new RangeConditionHeaderValue(minValue);
		}
		else
		{
			P_2 = new RangeConditionHeaderValue(entityTagHeaderValue);
		}
		return num - P_1;
	}

	object ICloneable.Clone()
	{
		return new RangeConditionHeaderValue(this);
	}
}
