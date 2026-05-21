using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace System;

public readonly struct SequencePosition : IEquatable<SequencePosition>
{
	private readonly object _object;

	private readonly int _integer;

	public SequencePosition(object? P_0, int P_1)
	{
		_object = P_0;
		_integer = P_1;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public object? GetObject()
	{
		return _object;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public int GetInteger()
	{
		return _integer;
	}

	public bool Equals(SequencePosition P_0)
	{
		if (_integer == P_0._integer)
		{
			return object.Equals(_object, P_0._object);
		}
		return false;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (P_0 is SequencePosition sequencePosition)
		{
			return Equals(sequencePosition);
		}
		return false;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int GetHashCode()
	{
		return HashCode.Combine(_object?.GetHashCode() ?? 0, _integer);
	}
}
