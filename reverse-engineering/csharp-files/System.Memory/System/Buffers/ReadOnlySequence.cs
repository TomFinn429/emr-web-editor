using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Buffers;

public readonly struct ReadOnlySequence<T>
{
	public struct Enumerator
	{
		private readonly ReadOnlySequence<T> _sequence;

		private SequencePosition _next;

		private ReadOnlyMemory<T> _currentMemory;

		public ReadOnlyMemory<T> Current => _currentMemory;

		public Enumerator(in ReadOnlySequence<T> P_0)
		{
			_currentMemory = default(ReadOnlyMemory<T>);
			_next = P_0.Start;
			_sequence = P_0;
		}

		public bool MoveNext()
		{
			if (_next.GetObject() == null)
			{
				return false;
			}
			return _sequence.TryGet(ref _next, out _currentMemory);
		}
	}

	private enum SequenceType
	{
		MultiSegment,
		Array,
		MemoryManager,
		String,
		Empty
	}

	private readonly object _startObject;

	private readonly object _endObject;

	private readonly int _startInteger;

	private readonly int _endInteger;

	public static readonly ReadOnlySequence<T> Empty = new ReadOnlySequence<T>(Array.Empty<T>());

	public long Length => GetLength();

	public bool IsEmpty => Length == 0;

	public bool IsSingleSegment
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return _startObject == _endObject;
		}
	}

	public ReadOnlyMemory<T> First => GetFirstBuffer();

	public SequencePosition Start
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			return new SequencePosition(_startObject, GetIndex(_startInteger));
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private ReadOnlySequence(object P_0, int P_1, object P_2, int P_3)
	{
		_startObject = P_0;
		_endObject = P_2;
		_startInteger = P_1;
		_endInteger = P_3;
	}

	public ReadOnlySequence(T[] P_0)
	{
		if (P_0 == null)
		{
			System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.array);
		}
		_startObject = P_0;
		_endObject = P_0;
		_startInteger = 0;
		_endInteger = ReadOnlySequence.ArrayToSequenceEnd(P_0.Length);
	}

	public ReadOnlySequence<T> Slice(long P_0, long P_1)
	{
		if (P_0 < 0 || P_1 < 0)
		{
			System.ThrowHelper.ThrowStartOrEndArgumentValidationException(P_0);
		}
		int index = GetIndex(_startInteger);
		int index2 = GetIndex(_endInteger);
		object startObject = _startObject;
		object endObject = _endObject;
		SequencePosition sequencePosition;
		SequencePosition sequencePosition2;
		if (startObject != endObject)
		{
			ReadOnlySequenceSegment<T> readOnlySequenceSegment = (ReadOnlySequenceSegment<T>)startObject;
			int num = readOnlySequenceSegment.Memory.Length - index;
			if (num > P_0)
			{
				index += (int)P_0;
				sequencePosition = new SequencePosition(startObject, index);
				sequencePosition2 = GetEndPosition(readOnlySequenceSegment, startObject, index, endObject, index2, P_1);
			}
			else
			{
				if (num < 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
				}
				sequencePosition = SeekMultiSegment(readOnlySequenceSegment.Next, endObject, index2, P_0 - num, System.ExceptionArgument.start);
				int integer = sequencePosition.GetInteger();
				object obj = sequencePosition.GetObject();
				if (obj != endObject)
				{
					sequencePosition2 = GetEndPosition((ReadOnlySequenceSegment<T>)obj, obj, integer, endObject, index2, P_1);
				}
				else
				{
					if (index2 - integer < P_1)
					{
						System.ThrowHelper.ThrowStartOrEndArgumentValidationException(0L);
					}
					sequencePosition2 = new SequencePosition(obj, integer + (int)P_1);
				}
			}
		}
		else
		{
			if (index2 - index < P_0)
			{
				System.ThrowHelper.ThrowStartOrEndArgumentValidationException(-1L);
			}
			index += (int)P_0;
			sequencePosition = new SequencePosition(startObject, index);
			if (index2 - index < P_1)
			{
				System.ThrowHelper.ThrowStartOrEndArgumentValidationException(0L);
			}
			sequencePosition2 = new SequencePosition(startObject, index + (int)P_1);
		}
		return SliceImpl(in sequencePosition, in sequencePosition2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public ReadOnlySequence<T> Slice(SequencePosition P_0, SequencePosition P_1)
	{
		BoundsCheck((uint)P_0.GetInteger(), P_0.GetObject(), (uint)P_1.GetInteger(), P_1.GetObject());
		return SliceImpl(in P_0, in P_1);
	}

	public ReadOnlySequence<T> Slice(long P_0)
	{
		if (P_0 < 0)
		{
			System.ThrowHelper.ThrowStartOrEndArgumentValidationException(P_0);
		}
		if (P_0 == 0L)
		{
			return this;
		}
		return SliceImpl(Seek(P_0, System.ExceptionArgument.start));
	}

	public override string ToString()
	{
		if (typeof(T) == typeof(char))
		{
			ReadOnlySequence<T> readOnlySequence = this;
			ReadOnlySequence<char> readOnlySequence2 = Unsafe.As<ReadOnlySequence<T>, ReadOnlySequence<char>>(ref readOnlySequence);
			if (readOnlySequence2.TryGetString(out var text, out var num, out var num2))
			{
				return text.Substring(num, num2);
			}
			if (Length < 2147483647)
			{
				return string.Create((int)Length, readOnlySequence2, delegate(Span<char> P_0, ReadOnlySequence<char> P_1)
				{
					P_1.CopyTo(P_0);
				});
			}
		}
		return $"System.Buffers.ReadOnlySequence<{typeof(T).Name}>[{Length}]";
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(in this);
	}

	public bool TryGet(ref SequencePosition P_0, out ReadOnlyMemory<T> P_1, bool P_2 = true)
	{
		SequencePosition sequencePosition;
		bool result = TryGetBuffer(in P_0, out P_1, out sequencePosition);
		if (P_2)
		{
			P_0 = sequencePosition;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal bool TryGetBuffer(in SequencePosition P_0, out ReadOnlyMemory<T> P_1, out SequencePosition P_2)
	{
		object obj = P_0.GetObject();
		P_2 = default(SequencePosition);
		if (obj == null)
		{
			P_1 = default(ReadOnlyMemory<T>);
			return false;
		}
		SequenceType sequenceType = GetSequenceType();
		object endObject = _endObject;
		int integer = P_0.GetInteger();
		int index = GetIndex(_endInteger);
		if (sequenceType == SequenceType.MultiSegment)
		{
			ReadOnlySequenceSegment<T> readOnlySequenceSegment = (ReadOnlySequenceSegment<T>)obj;
			if (readOnlySequenceSegment != endObject)
			{
				ReadOnlySequenceSegment<T> next = readOnlySequenceSegment.Next;
				if (next == null)
				{
					System.ThrowHelper.ThrowInvalidOperationException_EndPositionNotReached();
				}
				P_2 = new SequencePosition(next, 0);
				P_1 = readOnlySequenceSegment.Memory.Slice(integer);
			}
			else
			{
				P_1 = readOnlySequenceSegment.Memory.Slice(integer, index - integer);
			}
		}
		else
		{
			if (obj != endObject)
			{
				System.ThrowHelper.ThrowInvalidOperationException_EndPositionNotReached();
			}
			if (sequenceType == SequenceType.Array)
			{
				P_1 = new ReadOnlyMemory<T>((T[])obj, integer, index - integer);
			}
			else if (typeof(T) == typeof(char) && sequenceType == SequenceType.String)
			{
				P_1 = (ReadOnlyMemory<T>)(object)((string)obj).AsMemory(integer, index - integer);
			}
			else
			{
				P_1 = ((MemoryManager<T>)obj).Memory.Slice(integer, index - integer);
			}
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private ReadOnlyMemory<T> GetFirstBuffer()
	{
		object startObject = _startObject;
		if (startObject == null)
		{
			return default(ReadOnlyMemory<T>);
		}
		int startInteger = _startInteger;
		int endInteger = _endInteger;
		bool flag = startObject != _endObject;
		if ((startInteger | endInteger) >= 0)
		{
			ReadOnlyMemory<T> memory = ((ReadOnlySequenceSegment<T>)startObject).Memory;
			if (flag)
			{
				return memory.Slice(startInteger);
			}
			return memory.Slice(startInteger, endInteger - startInteger);
		}
		return GetFirstBufferSlow(startObject, flag);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private ReadOnlyMemory<T> GetFirstBufferSlow(object P_0, bool P_1)
	{
		if (P_1)
		{
			System.ThrowHelper.ThrowInvalidOperationException_EndPositionNotReached();
		}
		int startInteger = _startInteger;
		int endInteger = _endInteger;
		if (startInteger >= 0)
		{
			return new ReadOnlyMemory<T>((T[])P_0, startInteger, (endInteger & 0x7FFFFFFF) - startInteger);
		}
		if (typeof(T) == typeof(char) && endInteger < 0)
		{
			return (ReadOnlyMemory<T>)(object)((string)P_0).AsMemory(startInteger & 0x7FFFFFFF, endInteger - startInteger);
		}
		startInteger &= 0x7FFFFFFF;
		return ((MemoryManager<T>)P_0).Memory.Slice(startInteger, endInteger - startInteger);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal SequencePosition Seek(long P_0, System.ExceptionArgument P_1 = System.ExceptionArgument.offset)
	{
		object startObject = _startObject;
		object endObject = _endObject;
		int index = GetIndex(_startInteger);
		int index2 = GetIndex(_endInteger);
		if (startObject != endObject)
		{
			ReadOnlySequenceSegment<T> readOnlySequenceSegment = (ReadOnlySequenceSegment<T>)startObject;
			int num = readOnlySequenceSegment.Memory.Length - index;
			if (num <= P_0 && P_0 != 0L)
			{
				if (num < 0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
				}
				return SeekMultiSegment(readOnlySequenceSegment.Next, endObject, index2, P_0 - num, P_1);
			}
		}
		else if (index2 - index < P_0)
		{
			System.ThrowHelper.ThrowArgumentOutOfRangeException(P_1);
		}
		return new SequencePosition(startObject, index + (int)P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static SequencePosition SeekMultiSegment(ReadOnlySequenceSegment<T> P_0, object P_1, int P_2, long P_3, System.ExceptionArgument P_4)
	{
		while (true)
		{
			if (P_0 != null && P_0 != P_1)
			{
				int length = P_0.Memory.Length;
				if (length > P_3)
				{
					break;
				}
				P_3 -= length;
				P_0 = P_0.Next;
				continue;
			}
			if (P_0 == null || P_2 < P_3)
			{
				System.ThrowHelper.ThrowArgumentOutOfRangeException(P_4);
			}
			break;
		}
		return new SequencePosition(P_0, (int)P_3);
	}

	private void BoundsCheck(uint P_0, object P_1, uint P_2, object P_3)
	{
		object startObject = _startObject;
		object endObject = _endObject;
		uint index = (uint)GetIndex(_startInteger);
		uint index2 = (uint)GetIndex(_endInteger);
		if (startObject == endObject)
		{
			if (P_1 != P_3 || P_1 != startObject || P_0 > P_2 || P_0 < index || P_2 > index2)
			{
				System.ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
			}
			return;
		}
		ulong num = P_0;
		ulong num2 = P_2;
		if (P_1 != null)
		{
			num += (ulong)((ReadOnlySequenceSegment<T>)P_1).RunningIndex;
		}
		if (P_3 != null)
		{
			num2 += (ulong)((ReadOnlySequenceSegment<T>)P_3).RunningIndex;
		}
		if (num > num2)
		{
			System.ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
		}
		if (num < (ulong)(((ReadOnlySequenceSegment<T>)startObject).RunningIndex + index) || num2 > (ulong)(((ReadOnlySequenceSegment<T>)endObject).RunningIndex + index2))
		{
			System.ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
		}
	}

	private static SequencePosition GetEndPosition(ReadOnlySequenceSegment<T> P_0, object P_1, int P_2, object P_3, int P_4, long P_5)
	{
		int num = P_0.Memory.Length - P_2;
		if (num > P_5)
		{
			return new SequencePosition(P_1, P_2 + (int)P_5);
		}
		if (num < 0)
		{
			System.ThrowHelper.ThrowArgumentOutOfRangeException_PositionOutOfRange();
		}
		return SeekMultiSegment(P_0.Next, P_3, P_4, P_5 - num, System.ExceptionArgument.length);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private SequenceType GetSequenceType()
	{
		return (SequenceType)(-(2 * (_startInteger >> 31) + (_endInteger >> 31)));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int GetIndex(int P_0)
	{
		return P_0 & 0x7FFFFFFF;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private ReadOnlySequence<T> SliceImpl(in SequencePosition P_0, in SequencePosition P_1)
	{
		return new ReadOnlySequence<T>(P_0.GetObject(), P_0.GetInteger() | (_startInteger & -2147483648), P_1.GetObject(), P_1.GetInteger() | (_endInteger & -2147483648));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private ReadOnlySequence<T> SliceImpl(in SequencePosition P_0)
	{
		return new ReadOnlySequence<T>(P_0.GetObject(), P_0.GetInteger() | (_startInteger & -2147483648), _endObject, _endInteger);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private long GetLength()
	{
		object startObject = _startObject;
		object endObject = _endObject;
		int index = GetIndex(_startInteger);
		int index2 = GetIndex(_endInteger);
		if (startObject != endObject)
		{
			ReadOnlySequenceSegment<T> readOnlySequenceSegment = (ReadOnlySequenceSegment<T>)startObject;
			ReadOnlySequenceSegment<T> readOnlySequenceSegment2 = (ReadOnlySequenceSegment<T>)endObject;
			return readOnlySequenceSegment2.RunningIndex + index2 - (readOnlySequenceSegment.RunningIndex + index);
		}
		return index2 - index;
	}

	internal bool TryGetString([NotNullWhen(true)] out string P_0, out int P_1, out int P_2)
	{
		if (typeof(T) != typeof(char) || GetSequenceType() != SequenceType.String)
		{
			P_1 = 0;
			P_2 = 0;
			P_0 = null;
			return false;
		}
		P_1 = GetIndex(_startInteger);
		P_2 = GetIndex(_endInteger) - P_1;
		P_0 = (string)_startObject;
		return true;
	}
}
internal static class ReadOnlySequence
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ArrayToSequenceEnd(int P_0)
	{
		return P_0 | -2147483648;
	}
}
