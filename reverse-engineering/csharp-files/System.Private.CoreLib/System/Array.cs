using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public abstract class Array : ICloneable, IList, ICollection, IEnumerable
{
	[StructLayout((LayoutKind)0)]
	internal sealed class RawData
	{
		public nint Bounds;

		public uint Count;

		public byte Data;
	}

	private static class EmptyArray<T>
	{
		internal static readonly T[] Value = new T[0];
	}

	private readonly struct SorterObjectArray
	{
		private readonly object[] keys;

		private readonly object[] items;

		private readonly IComparer comparer;

		internal SorterObjectArray(object[] P_0, object[] P_1, IComparer P_2)
		{
			keys = P_0;
			items = P_1;
			comparer = P_2;
		}

		internal void SwapIfGreater(int P_0, int P_1)
		{
			if (P_0 != P_1 && comparer.Compare(keys[P_0], keys[P_1]) > 0)
			{
				object obj = keys[P_0];
				keys[P_0] = keys[P_1];
				keys[P_1] = obj;
				if (items != null)
				{
					object obj2 = items[P_0];
					items[P_0] = items[P_1];
					items[P_1] = obj2;
				}
			}
		}

		private void Swap(int P_0, int P_1)
		{
			object obj = keys[P_0];
			keys[P_0] = keys[P_1];
			keys[P_1] = obj;
			if (items != null)
			{
				object obj2 = items[P_0];
				items[P_0] = items[P_1];
				items[P_1] = obj2;
			}
		}

		internal void Sort(int P_0, int P_1)
		{
			IntrospectiveSort(P_0, P_1);
		}

		private void IntrospectiveSort(int P_0, int P_1)
		{
			if (P_1 < 2)
			{
				return;
			}
			try
			{
				IntroSort(P_0, P_1 + P_0 - 1, 2 * (BitOperations.Log2((uint)P_1) + 1));
			}
			catch (IndexOutOfRangeException)
			{
				ThrowHelper.ThrowArgumentException_BadComparer(comparer);
			}
			catch (Exception ex2)
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_IComparerFailed, ex2);
			}
		}

		private void IntroSort(int P_0, int P_1, int P_2)
		{
			while (P_1 > P_0)
			{
				int num = P_1 - P_0 + 1;
				if (num <= 16)
				{
					switch (num)
					{
					case 2:
						SwapIfGreater(P_0, P_1);
						break;
					case 3:
						SwapIfGreater(P_0, P_1 - 1);
						SwapIfGreater(P_0, P_1);
						SwapIfGreater(P_1 - 1, P_1);
						break;
					default:
						InsertionSort(P_0, P_1);
						break;
					}
					break;
				}
				if (P_2 == 0)
				{
					Heapsort(P_0, P_1);
					break;
				}
				P_2--;
				int num2 = PickPivotAndPartition(P_0, P_1);
				IntroSort(num2 + 1, P_1, P_2);
				P_1 = num2 - 1;
			}
		}

		private int PickPivotAndPartition(int P_0, int P_1)
		{
			int num = P_0 + (P_1 - P_0) / 2;
			SwapIfGreater(P_0, num);
			SwapIfGreater(P_0, P_1);
			SwapIfGreater(num, P_1);
			object obj = keys[num];
			Swap(num, P_1 - 1);
			int num2 = P_0;
			int num3 = P_1 - 1;
			while (num2 < num3)
			{
				while (comparer.Compare(keys[++num2], obj) < 0)
				{
				}
				while (comparer.Compare(obj, keys[--num3]) < 0)
				{
				}
				if (num2 >= num3)
				{
					break;
				}
				Swap(num2, num3);
			}
			if (num2 != P_1 - 1)
			{
				Swap(num2, P_1 - 1);
			}
			return num2;
		}

		private void Heapsort(int P_0, int P_1)
		{
			int num = P_1 - P_0 + 1;
			for (int num2 = num / 2; num2 >= 1; num2--)
			{
				DownHeap(num2, num, P_0);
			}
			for (int num3 = num; num3 > 1; num3--)
			{
				Swap(P_0, P_0 + num3 - 1);
				DownHeap(1, num3 - 1, P_0);
			}
		}

		private void DownHeap(int P_0, int P_1, int P_2)
		{
			object obj = keys[P_2 + P_0 - 1];
			object[] array = items;
			object obj2 = ((array != null) ? array[P_2 + P_0 - 1] : null);
			while (P_0 <= P_1 / 2)
			{
				int num = 2 * P_0;
				if (num < P_1 && comparer.Compare(keys[P_2 + num - 1], keys[P_2 + num]) < 0)
				{
					num++;
				}
				if (comparer.Compare(obj, keys[P_2 + num - 1]) >= 0)
				{
					break;
				}
				keys[P_2 + P_0 - 1] = keys[P_2 + num - 1];
				if (items != null)
				{
					items[P_2 + P_0 - 1] = items[P_2 + num - 1];
				}
				P_0 = num;
			}
			keys[P_2 + P_0 - 1] = obj;
			if (items != null)
			{
				items[P_2 + P_0 - 1] = obj2;
			}
		}

		private void InsertionSort(int P_0, int P_1)
		{
			for (int i = P_0; i < P_1; i++)
			{
				int num = i;
				object obj = keys[i + 1];
				object[] array = items;
				object obj2 = ((array != null) ? array[i + 1] : null);
				while (num >= P_0 && comparer.Compare(obj, keys[num]) < 0)
				{
					keys[num + 1] = keys[num];
					if (items != null)
					{
						items[num + 1] = items[num];
					}
					num--;
				}
				keys[num + 1] = obj;
				if (items != null)
				{
					items[num + 1] = obj2;
				}
			}
		}
	}

	private readonly struct SorterGenericArray
	{
		private readonly Array keys;

		private readonly Array items;

		private readonly IComparer comparer;

		internal SorterGenericArray(Array P_0, Array P_1, IComparer P_2)
		{
			keys = P_0;
			items = P_1;
			comparer = P_2;
		}

		internal void SwapIfGreater(int P_0, int P_1)
		{
			if (P_0 != P_1 && comparer.Compare(keys.GetValue(P_0), keys.GetValue(P_1)) > 0)
			{
				object value = keys.GetValue(P_0);
				keys.SetValue(keys.GetValue(P_1), P_0);
				keys.SetValue(value, P_1);
				if (items != null)
				{
					object value2 = items.GetValue(P_0);
					items.SetValue(items.GetValue(P_1), P_0);
					items.SetValue(value2, P_1);
				}
			}
		}

		private void Swap(int P_0, int P_1)
		{
			object value = keys.GetValue(P_0);
			keys.SetValue(keys.GetValue(P_1), P_0);
			keys.SetValue(value, P_1);
			if (items != null)
			{
				object value2 = items.GetValue(P_0);
				items.SetValue(items.GetValue(P_1), P_0);
				items.SetValue(value2, P_1);
			}
		}

		internal void Sort(int P_0, int P_1)
		{
			IntrospectiveSort(P_0, P_1);
		}

		private void IntrospectiveSort(int P_0, int P_1)
		{
			if (P_1 < 2)
			{
				return;
			}
			try
			{
				IntroSort(P_0, P_1 + P_0 - 1, 2 * (BitOperations.Log2((uint)P_1) + 1));
			}
			catch (IndexOutOfRangeException)
			{
				ThrowHelper.ThrowArgumentException_BadComparer(comparer);
			}
			catch (Exception ex2)
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_IComparerFailed, ex2);
			}
		}

		private void IntroSort(int P_0, int P_1, int P_2)
		{
			while (P_1 > P_0)
			{
				int num = P_1 - P_0 + 1;
				if (num <= 16)
				{
					switch (num)
					{
					case 2:
						SwapIfGreater(P_0, P_1);
						break;
					case 3:
						SwapIfGreater(P_0, P_1 - 1);
						SwapIfGreater(P_0, P_1);
						SwapIfGreater(P_1 - 1, P_1);
						break;
					default:
						InsertionSort(P_0, P_1);
						break;
					}
					break;
				}
				if (P_2 == 0)
				{
					Heapsort(P_0, P_1);
					break;
				}
				P_2--;
				int num2 = PickPivotAndPartition(P_0, P_1);
				IntroSort(num2 + 1, P_1, P_2);
				P_1 = num2 - 1;
			}
		}

		private int PickPivotAndPartition(int P_0, int P_1)
		{
			int num = P_0 + (P_1 - P_0) / 2;
			SwapIfGreater(P_0, num);
			SwapIfGreater(P_0, P_1);
			SwapIfGreater(num, P_1);
			object value = keys.GetValue(num);
			Swap(num, P_1 - 1);
			int num2 = P_0;
			int num3 = P_1 - 1;
			while (num2 < num3)
			{
				while (comparer.Compare(keys.GetValue(++num2), value) < 0)
				{
				}
				while (comparer.Compare(value, keys.GetValue(--num3)) < 0)
				{
				}
				if (num2 >= num3)
				{
					break;
				}
				Swap(num2, num3);
			}
			if (num2 != P_1 - 1)
			{
				Swap(num2, P_1 - 1);
			}
			return num2;
		}

		private void Heapsort(int P_0, int P_1)
		{
			int num = P_1 - P_0 + 1;
			for (int num2 = num / 2; num2 >= 1; num2--)
			{
				DownHeap(num2, num, P_0);
			}
			for (int num3 = num; num3 > 1; num3--)
			{
				Swap(P_0, P_0 + num3 - 1);
				DownHeap(1, num3 - 1, P_0);
			}
		}

		private void DownHeap(int P_0, int P_1, int P_2)
		{
			object value = keys.GetValue(P_2 + P_0 - 1);
			object obj = items?.GetValue(P_2 + P_0 - 1);
			while (P_0 <= P_1 / 2)
			{
				int num = 2 * P_0;
				if (num < P_1 && comparer.Compare(keys.GetValue(P_2 + num - 1), keys.GetValue(P_2 + num)) < 0)
				{
					num++;
				}
				if (comparer.Compare(value, keys.GetValue(P_2 + num - 1)) >= 0)
				{
					break;
				}
				keys.SetValue(keys.GetValue(P_2 + num - 1), P_2 + P_0 - 1);
				items?.SetValue(items.GetValue(P_2 + num - 1), P_2 + P_0 - 1);
				P_0 = num;
			}
			keys.SetValue(value, P_2 + P_0 - 1);
			items?.SetValue(obj, P_2 + P_0 - 1);
		}

		private void InsertionSort(int P_0, int P_1)
		{
			for (int i = P_0; i < P_1; i++)
			{
				int num = i;
				object value = keys.GetValue(i + 1);
				object obj = items?.GetValue(i + 1);
				while (num >= P_0 && comparer.Compare(value, keys.GetValue(num)) < 0)
				{
					keys.SetValue(keys.GetValue(num), num + 1);
					items?.SetValue(items.GetValue(num), num + 1);
					num--;
				}
				keys.SetValue(value, num + 1);
				items?.SetValue(obj, num + 1);
			}
		}
	}

	public int Length
	{
		[Intrinsic]
		get
		{
			return Length;
		}
	}

	internal nuint NativeLength => Unsafe.As<RawData>(this).Count;

	public int Rank
	{
		[Intrinsic]
		get
		{
			return Rank;
		}
	}

	int ICollection.Count => Length;

	public object SyncRoot => this;

	public bool IsReadOnly => false;

	public bool IsFixedSize => true;

	public bool IsSynchronized => false;

	object? IList.this[int P_0]
	{
		get
		{
			return GetValue(P_0);
		}
		set
		{
			SetValue(obj, num);
		}
	}

	public static void Clear(Array P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		ref byte arrayDataReference = ref MemoryMarshal.GetArrayDataReference(P_0);
		nuint num = P_0.NativeLength * (uint)P_0.GetElementSize();
		if (RuntimeHelpers.ObjectHasReferences(P_0))
		{
			SpanHelpers.ClearWithReferences(ref Unsafe.As<byte, nint>(ref arrayDataReference), num / 4u);
		}
		else
		{
			SpanHelpers.ClearWithoutReferences(ref arrayDataReference, num);
		}
	}

	public static void Clear(Array P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		int lowerBound = P_0.GetLowerBound(0);
		int elementSize = P_0.GetElementSize();
		nuint nativeLength = P_0.NativeLength;
		int num = P_1 - lowerBound;
		if (P_1 < lowerBound || num < 0 || P_2 < 0 || (uint)(num + P_2) > nativeLength)
		{
			ThrowHelper.ThrowIndexOutOfRangeException();
		}
		ref byte reference = ref Unsafe.AddByteOffset(ref MemoryMarshal.GetArrayDataReference(P_0), (nuint)(uint)num * (nuint)elementSize);
		nuint num2 = (nuint)(uint)P_2 * (nuint)elementSize;
		if (RuntimeHelpers.ObjectHasReferences(P_0))
		{
			SpanHelpers.ClearWithReferences(ref Unsafe.As<byte, nint>(ref reference), num2 / 4u);
		}
		else
		{
			SpanHelpers.ClearWithoutReferences(ref reference, num2);
		}
	}

	public static void Copy(Array P_0, Array P_1, int P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "sourceArray");
		ArgumentNullException.ThrowIfNull(P_1, "destinationArray");
		Copy(P_0, P_0.GetLowerBound(0), P_1, P_1.GetLowerBound(0), P_2);
	}

	public static void Copy(Array P_0, int P_1, Array P_2, int P_3, int P_4)
	{
		Copy(P_0, P_1, P_2, P_3, P_4, false);
	}

	private static void Copy(Array P_0, int P_1, Array P_2, int P_3, int P_4, bool P_5)
	{
		ArgumentNullException.ThrowIfNull(P_0, "sourceArray");
		ArgumentNullException.ThrowIfNull(P_2, "destinationArray");
		if (P_4 < 0)
		{
			throw new ArgumentOutOfRangeException("length", "ArgumentOutOfRange_NeedNonNegNum");
		}
		if (P_0.Rank != P_2.Rank)
		{
			throw new RankException("Rank_MultiDimNotSupported");
		}
		if (P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("sourceIndex", "Value has to be >= 0.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("destinationIndex", "Value has to be >= 0.");
		}
		if (!FastCopy(P_0, P_1, P_2, P_3, P_4))
		{
			CopySlow(P_0, P_1, P_2, P_3, P_4, P_5);
		}
	}

	private static void CopySlow(Array P_0, int P_1, Array P_2, int P_3, int P_4, bool P_5)
	{
		int num = P_1 - P_0.GetLowerBound(0);
		int num2 = P_3 - P_2.GetLowerBound(0);
		if (num < 0)
		{
			throw new ArgumentOutOfRangeException("sourceIndex", "ArgumentOutOfRange_ArrayLB");
		}
		if (num2 < 0)
		{
			throw new ArgumentOutOfRangeException("destinationIndex", "ArgumentOutOfRange_ArrayLB");
		}
		if (num > P_0.Length - P_4)
		{
			throw new ArgumentException("Arg_LongerThanSrcArray", "sourceArray");
		}
		if (num2 > P_2.Length - P_4)
		{
			throw new ArgumentException("Arg_LongerThanDestArray", "destinationArray");
		}
		Type type = P_0.GetType().GetElementType();
		Type type2 = P_2.GetType().GetElementType();
		Type type3 = type2;
		bool flag = type2.IsValueType && Nullable.GetUnderlyingType(type2) == null;
		bool isEnum = type.IsEnum;
		bool isEnum2 = type2.IsEnum;
		if (isEnum)
		{
			type = Enum.GetUnderlyingType(type);
		}
		if (isEnum2)
		{
			type2 = Enum.GetUnderlyingType(type2);
		}
		if (P_5)
		{
			if (!type2.Equals(type) && (!type2.IsPrimitive || !type.IsPrimitive || !CanChangePrimitive(ref type2, ref type, true)))
			{
				throw new ArrayTypeMismatchException("ArrayTypeMismatch_CantAssignType");
			}
		}
		else if (!CanAssignArrayElement(type, type2))
		{
			throw new ArrayTypeMismatchException("ArrayTypeMismatch_CantAssignType");
		}
		if (P_0 != P_2 || num > num2)
		{
			for (int i = 0; i < P_4; i++)
			{
				object valueImpl = P_0.GetValueImpl(num + i);
				if (flag && (valueImpl == null || (type == typeof(object) && !type3.IsAssignableFrom(valueImpl.GetType()))))
				{
					throw new InvalidCastException("InvalidCast_DownCastArrayElement");
				}
				try
				{
					P_2.SetValueRelaxedImpl(valueImpl, num2 + i);
				}
				catch (ArgumentException)
				{
					throw CreateArrayTypeMismatchException();
				}
			}
			return;
		}
		for (int num3 = P_4 - 1; num3 >= 0; num3--)
		{
			object valueImpl2 = P_0.GetValueImpl(num + num3);
			try
			{
				P_2.SetValueRelaxedImpl(valueImpl2, num2 + num3);
			}
			catch (ArgumentException)
			{
				throw CreateArrayTypeMismatchException();
			}
		}
	}

	private static ArrayTypeMismatchException CreateArrayTypeMismatchException()
	{
		return new ArrayTypeMismatchException();
	}

	private static bool CanAssignArrayElement(Type P_0, Type P_1)
	{
		if (!P_1.IsValueType && !P_1.IsPointer)
		{
			if (!P_0.IsValueType && !P_0.IsPointer)
			{
				if (!P_0.IsInterface && !P_1.IsInterface && !P_0.IsAssignableFrom(P_1))
				{
					return P_1.IsAssignableFrom(P_0);
				}
				return true;
			}
			if (P_0.IsPointer)
			{
				return false;
			}
			return P_1.IsAssignableFrom(P_0);
		}
		if (P_0.IsEquivalentTo(P_1))
		{
			return true;
		}
		if (P_0.IsPointer && P_1.IsPointer)
		{
			return true;
		}
		if (P_0.IsPrimitive && P_1.IsPrimitive)
		{
			return CanChangePrimitive(ref P_0, ref P_1, false);
		}
		if (!P_0.IsValueType && !P_0.IsPointer)
		{
			if (P_1.IsPointer)
			{
				return false;
			}
			return P_0.IsAssignableFrom(P_1);
		}
		return false;
	}

	private unsafe static Array InternalCreate(RuntimeType P_0, int P_1, int* P_2, int* P_3)
	{
		Array result = null;
		InternalCreate(ref result, P_0._impl.Value, P_1, P_2, P_3);
		GC.KeepAlive(P_0);
		return result;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern void InternalCreate(ref Array P_0, nint P_1, int P_2, int* P_3, int* P_4);

	private nint GetFlattenedIndex(int P_0)
	{
		int num = P_0 - GetLowerBound(0);
		int length = GetLength(0);
		if ((uint)num >= (uint)length)
		{
			ThrowHelper.ThrowIndexOutOfRangeException();
		}
		return num;
	}

	internal object InternalGetValue(nint P_0)
	{
		if (GetType().GetElementType().IsPointer)
		{
			throw new NotSupportedException("NotSupported_Type");
		}
		return GetValueImpl((int)P_0);
	}

	internal void InternalSetValue(object P_0, nint P_1)
	{
		if (GetType().GetElementType().IsPointer)
		{
			throw new NotSupportedException("NotSupported_Type");
		}
		SetValueImpl(P_0, (int)P_1);
	}

	[Intrinsic]
	internal int GetElementSize()
	{
		return GetElementSize();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal extern CorElementType GetCorElementTypeOfElementType();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern bool IsValueOfElementType(object P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool CanChangePrimitive(ref Type P_0, ref Type P_1, bool P_2);

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern bool FastCopy(Array P_0, int P_1, Array P_2, int P_3, int P_4);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[Intrinsic]
	public extern int GetLength(int P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[Intrinsic]
	public extern int GetLowerBound(int P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetGenericValue_icall<T>(ref Array P_0, int P_1, out T P_2);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern object GetValueImpl(int P_0);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetGenericValue_icall<T>(ref Array P_0, int P_1, ref T P_2);

	[Intrinsic]
	private void GetGenericValueImpl<T>(int P_0, out T P_1)
	{
		Array array = this;
		GetGenericValue_icall<T>(ref array, P_0, out P_1);
	}

	[Intrinsic]
	private void SetGenericValueImpl<T>(int P_0, ref T P_1)
	{
		Array array = this;
		SetGenericValue_icall(ref array, P_0, ref P_1);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern void SetValueImpl(object P_0, int P_1);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private extern void SetValueRelaxedImpl(object P_0, int P_1);

	internal int InternalArray__ICollection_get_Count()
	{
		return Length;
	}

	internal bool InternalArray__ICollection_get_IsReadOnly()
	{
		return true;
	}

	internal IEnumerator<T> InternalArray__IEnumerable_GetEnumerator<T>()
	{
		if (Length != 0)
		{
			return new SZGenericArrayEnumerator<T>(Unsafe.As<T[]>(this));
		}
		return SZGenericArrayEnumerator<T>.Empty;
	}

	internal void InternalArray__ICollection_Clear()
	{
		ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_ReadOnlyCollection);
	}

	internal void InternalArray__ICollection_Add<T>(T _)
	{
		ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_FixedSizeCollection);
	}

	internal bool InternalArray__ICollection_Remove<T>(T _)
	{
		ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_FixedSizeCollection);
		return false;
	}

	internal bool InternalArray__ICollection_Contains<T>(T item)
	{
		return IndexOf((T[])this, item, 0, Length) >= 0;
	}

	internal void InternalArray__ICollection_CopyTo<T>(T[] array, int arrayIndex)
	{
		Copy(this, GetLowerBound(0), array, arrayIndex, Length);
	}

	internal T InternalArray__IReadOnlyList_get_Item<T>(int index)
	{
		if ((uint)index >= (uint)Length)
		{
			ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
		}
		GetGenericValueImpl<T>(index, out var result);
		return result;
	}

	internal int InternalArray__IReadOnlyCollection_get_Count()
	{
		return Length;
	}

	internal void InternalArray__Insert<T>(int _, T _1)
	{
		ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_FixedSizeCollection);
	}

	internal void InternalArray__RemoveAt(int _)
	{
		ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_FixedSizeCollection);
	}

	internal int InternalArray__IndexOf<T>(T item)
	{
		return IndexOf((T[])this, item, 0, Length);
	}

	internal T InternalArray__get_Item<T>(int index)
	{
		if ((uint)index >= (uint)Length)
		{
			ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
		}
		GetGenericValueImpl<T>(index, out var result);
		return result;
	}

	internal void InternalArray__set_Item<T>(int index, T item)
	{
		if ((uint)index >= (uint)Length)
		{
			ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
		}
		if (this is object[] array)
		{
			array[index] = item;
		}
		else
		{
			SetGenericValueImpl(index, ref item);
		}
	}

	private protected Array()
	{
	}

	public static void Resize<T>([NotNull] ref T[]? P_0, int P_1)
	{
		if (P_1 < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.newSize, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		}
		T[] array = P_0;
		if (array == null)
		{
			P_0 = new T[P_1];
		}
		else if (array.Length != P_1)
		{
			T[] array2 = new T[P_1];
			Buffer.Memmove(ref MemoryMarshal.GetArrayDataReference(array2), ref MemoryMarshal.GetArrayDataReference(array), (uint)Math.Min(P_1, array.Length));
			P_0 = array2;
		}
	}

	[RequiresDynamicCode("The code for an array of the specified type might not be available.")]
	public unsafe static Array CreateInstance(Type P_0, int P_1)
	{
		if ((object)P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.elementType);
		}
		if (P_1 < 0)
		{
			ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
		}
		RuntimeType runtimeType = P_0.UnderlyingSystemType as RuntimeType;
		if (runtimeType == null)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_MustBeType, ExceptionArgument.elementType);
		}
		return InternalCreate(runtimeType, 1, &P_1, null);
	}

	public object? GetValue(int P_0)
	{
		if (Rank != 1)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_Need1DArray);
		}
		return InternalGetValue(GetFlattenedIndex(P_0));
	}

	public void SetValue(object? P_0, int P_1)
	{
		if (Rank != 1)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_Need1DArray);
		}
		InternalSetValue(P_0, GetFlattenedIndex(P_1));
	}

	private static int GetMedian(int P_0, int P_1)
	{
		return P_0 + (P_1 - P_0 >> 1);
	}

	int IList.Add(object P_0)
	{
		ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_FixedSizeCollection);
		return 0;
	}

	bool IList.Contains(object P_0)
	{
		return IndexOf(this, P_0) >= GetLowerBound(0);
	}

	void IList.Clear()
	{
		Clear(this);
	}

	int IList.IndexOf(object P_0)
	{
		return IndexOf(this, P_0);
	}

	void IList.Insert(int P_0, object P_1)
	{
		ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_FixedSizeCollection);
	}

	void IList.Remove(object P_0)
	{
		ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_FixedSizeCollection);
	}

	void IList.RemoveAt(int P_0)
	{
		ThrowHelper.ThrowNotSupportedException(ExceptionResource.NotSupported_FixedSizeCollection);
	}

	[Intrinsic]
	public object Clone()
	{
		return MemberwiseClone();
	}

	public static int BinarySearch(Array P_0, object? P_1, IComparer? P_2)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		return BinarySearch(P_0, P_0.GetLowerBound(0), P_0.Length, P_1, P_2);
	}

	public static int BinarySearch(Array P_0, int P_1, int P_2, object? P_3, IComparer? P_4)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		int lowerBound = P_0.GetLowerBound(0);
		if (P_1 < lowerBound)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (P_2 < 0)
		{
			ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
		}
		if (P_0.Length - (P_1 - lowerBound) < P_2)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		if (P_0.Rank != 1)
		{
			ThrowHelper.ThrowRankException(ExceptionResource.Rank_MultiDimNotSupported);
		}
		if (P_4 == null)
		{
			P_4 = Comparer.Default;
		}
		int num = P_1;
		int num2 = P_1 + P_2 - 1;
		if (P_0 is object[] array)
		{
			while (num <= num2)
			{
				int median = GetMedian(num, num2);
				int num3;
				try
				{
					num3 = P_4.Compare(array[median], P_3);
				}
				catch (Exception ex)
				{
					ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_IComparerFailed, ex);
					return 0;
				}
				if (num3 == 0)
				{
					return median;
				}
				if (num3 < 0)
				{
					num = median + 1;
				}
				else
				{
					num2 = median - 1;
				}
			}
			return ~num;
		}
		if (P_4 == Comparer.Default)
		{
			CorElementType corElementTypeOfElementType = P_0.GetCorElementTypeOfElementType();
			if (corElementTypeOfElementType.IsPrimitiveType())
			{
				if (P_3 == null)
				{
					return ~P_1;
				}
				if (P_0.IsValueOfElementType(P_3))
				{
					int num4 = P_1 - lowerBound;
					int num5 = -1;
					switch (corElementTypeOfElementType)
					{
					case CorElementType.ELEMENT_TYPE_I1:
						num5 = GenericBinarySearch<sbyte>(P_0, num4, P_2, P_3);
						break;
					case CorElementType.ELEMENT_TYPE_BOOLEAN:
					case CorElementType.ELEMENT_TYPE_U1:
						num5 = GenericBinarySearch<byte>(P_0, num4, P_2, P_3);
						break;
					case CorElementType.ELEMENT_TYPE_I2:
						num5 = GenericBinarySearch<short>(P_0, num4, P_2, P_3);
						break;
					case CorElementType.ELEMENT_TYPE_CHAR:
					case CorElementType.ELEMENT_TYPE_U2:
						num5 = GenericBinarySearch<ushort>(P_0, num4, P_2, P_3);
						break;
					case CorElementType.ELEMENT_TYPE_I4:
					case CorElementType.ELEMENT_TYPE_I:
						num5 = GenericBinarySearch<int>(P_0, num4, P_2, P_3);
						break;
					case CorElementType.ELEMENT_TYPE_U4:
					case CorElementType.ELEMENT_TYPE_U:
						num5 = GenericBinarySearch<uint>(P_0, num4, P_2, P_3);
						break;
					case CorElementType.ELEMENT_TYPE_I8:
						num5 = GenericBinarySearch<long>(P_0, num4, P_2, P_3);
						break;
					case CorElementType.ELEMENT_TYPE_U8:
						num5 = GenericBinarySearch<ulong>(P_0, num4, P_2, P_3);
						break;
					case CorElementType.ELEMENT_TYPE_R4:
						num5 = GenericBinarySearch<float>(P_0, num4, P_2, P_3);
						break;
					case CorElementType.ELEMENT_TYPE_R8:
						num5 = GenericBinarySearch<double>(P_0, num4, P_2, P_3);
						break;
					}
					if (num5 < 0)
					{
						return ~(P_1 + ~num5);
					}
					return P_1 + num5;
				}
			}
		}
		while (num <= num2)
		{
			int median2 = GetMedian(num, num2);
			int num6;
			try
			{
				num6 = P_4.Compare(P_0.GetValue(median2), P_3);
			}
			catch (Exception ex2)
			{
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_IComparerFailed, ex2);
				return 0;
			}
			if (num6 == 0)
			{
				return median2;
			}
			if (num6 < 0)
			{
				num = median2 + 1;
			}
			else
			{
				num2 = median2 - 1;
			}
		}
		return ~num;
		static int GenericBinarySearch<T>(Array array2, int num7, int num8, object obj) where T : struct, IComparable<T>
		{
			return UnsafeArrayAsSpan<T>(array2, num7, num8).BinarySearch(Unsafe.As<byte, T>(ref obj.GetRawData()));
		}
	}

	public static int BinarySearch<T>(T[] P_0, T P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		return BinarySearch(P_0, 0, P_0.Length, P_1, null);
	}

	public static int BinarySearch<T>(T[] P_0, T P_1, IComparer<T>? P_2)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		return BinarySearch(P_0, 0, P_0.Length, P_1, P_2);
	}

	public static int BinarySearch<T>(T[] P_0, int P_1, int P_2, T P_3, IComparer<T>? P_4)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		if (P_1 < 0)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (P_2 < 0)
		{
			ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
		}
		if (P_0.Length - P_1 < P_2)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		return ArraySortHelper<T>.Default.BinarySearch(P_0, P_1, P_2, P_3, P_4);
	}

	public void CopyTo(Array P_0, int P_1)
	{
		if (P_0 != null && P_0.Rank != 1)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
		}
		Copy(this, GetLowerBound(0), P_0, P_1, Length);
	}

	public static T[] Empty<T>()
	{
		return EmptyArray<T>.Value;
	}

	public static void Fill<T>(T[] P_0, T P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		if (!typeof(T).IsValueType && P_0.GetType() != typeof(T[]))
		{
			for (int i = 0; i < P_0.Length; i++)
			{
				P_0[i] = P_1;
			}
		}
		else
		{
			new Span<T>(P_0).Fill(P_1);
		}
	}

	public static int IndexOf(Array P_0, object? P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		return IndexOf(P_0, P_1, P_0.GetLowerBound(0), P_0.Length);
	}

	public static int IndexOf(Array P_0, object? P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		if (P_0.Rank != 1)
		{
			ThrowHelper.ThrowRankException(ExceptionResource.Rank_MultiDimNotSupported);
		}
		int lowerBound = P_0.GetLowerBound(0);
		if (P_2 < lowerBound || P_2 > P_0.Length + lowerBound)
		{
			ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_IndexMustBeLessOrEqual();
		}
		if (P_3 < 0 || P_3 > P_0.Length - P_2 + lowerBound)
		{
			ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
		}
		int num = P_2 + P_3;
		if (P_0 is object[] array)
		{
			if (P_1 == null)
			{
				for (int i = P_2; i < num; i++)
				{
					if (array[i] == null)
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = P_2; j < num; j++)
				{
					object obj = array[j];
					if (obj != null && obj.Equals(P_1))
					{
						return j;
					}
				}
			}
			return -1;
		}
		CorElementType corElementTypeOfElementType = P_0.GetCorElementTypeOfElementType();
		if (corElementTypeOfElementType.IsPrimitiveType())
		{
			if (P_1 == null)
			{
				return lowerBound - 1;
			}
			if (P_0.IsValueOfElementType(P_1))
			{
				int num2 = P_2 - lowerBound;
				int num3 = -1;
				switch (corElementTypeOfElementType)
				{
				case CorElementType.ELEMENT_TYPE_BOOLEAN:
				case CorElementType.ELEMENT_TYPE_I1:
				case CorElementType.ELEMENT_TYPE_U1:
					num3 = GenericIndexOf<byte>(P_0, P_1, num2, P_3);
					break;
				case CorElementType.ELEMENT_TYPE_CHAR:
				case CorElementType.ELEMENT_TYPE_I2:
				case CorElementType.ELEMENT_TYPE_U2:
					num3 = GenericIndexOf<char>(P_0, P_1, num2, P_3);
					break;
				case CorElementType.ELEMENT_TYPE_I4:
				case CorElementType.ELEMENT_TYPE_U4:
				case CorElementType.ELEMENT_TYPE_I:
				case CorElementType.ELEMENT_TYPE_U:
					num3 = GenericIndexOf<int>(P_0, P_1, num2, P_3);
					break;
				case CorElementType.ELEMENT_TYPE_I8:
				case CorElementType.ELEMENT_TYPE_U8:
					num3 = GenericIndexOf<long>(P_0, P_1, num2, P_3);
					break;
				case CorElementType.ELEMENT_TYPE_R4:
					num3 = GenericIndexOf<float>(P_0, P_1, num2, P_3);
					break;
				case CorElementType.ELEMENT_TYPE_R8:
					num3 = GenericIndexOf<double>(P_0, P_1, num2, P_3);
					break;
				}
				return ((num3 >= 0) ? P_2 : lowerBound) + num3;
			}
		}
		for (int k = P_2; k < num; k++)
		{
			object value = P_0.GetValue(k);
			if (value == null)
			{
				if (P_1 == null)
				{
					return k;
				}
			}
			else if (value.Equals(P_1))
			{
				return k;
			}
		}
		return lowerBound - 1;
		static int GenericIndexOf<T>(Array array2, object obj2, int num4, int num5) where T : struct, IEquatable<T>
		{
			return UnsafeArrayAsSpan<T>(array2, num4, num5).IndexOf(Unsafe.As<byte, T>(ref obj2.GetRawData()));
		}
	}

	public static int IndexOf<T>(T[] P_0, T P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		return IndexOf(P_0, P_1, 0, P_0.Length);
	}

	public static int IndexOf<T>(T[] P_0, T P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		if ((uint)P_2 > (uint)P_0.Length)
		{
			ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_IndexMustBeLessOrEqual();
		}
		if ((uint)P_3 > (uint)(P_0.Length - P_2))
		{
			ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
		}
		if (RuntimeHelpers.IsBitwiseEquatable<T>())
		{
			if (Unsafe.SizeOf<T>() == 1)
			{
				int num = SpanHelpers.IndexOfValueType(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(Unsafe.As<byte[]>(P_0)), P_2), Unsafe.As<T, byte>(ref P_1), P_3);
				return ((num >= 0) ? P_2 : 0) + num;
			}
			if (Unsafe.SizeOf<T>() == 2)
			{
				int num2 = SpanHelpers.IndexOfValueType(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(Unsafe.As<short[]>(P_0)), P_2), Unsafe.As<T, short>(ref P_1), P_3);
				return ((num2 >= 0) ? P_2 : 0) + num2;
			}
			if (Unsafe.SizeOf<T>() == 4)
			{
				int num3 = (typeof(T).IsValueType ? SpanHelpers.IndexOfValueType(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(Unsafe.As<int[]>(P_0)), P_2), Unsafe.As<T, int>(ref P_1), P_3) : SpanHelpers.IndexOf(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(Unsafe.As<int[]>(P_0)), P_2), Unsafe.As<T, int>(ref P_1), P_3));
				return ((num3 >= 0) ? P_2 : 0) + num3;
			}
			if (Unsafe.SizeOf<T>() == 8)
			{
				int num4 = (typeof(T).IsValueType ? SpanHelpers.IndexOfValueType(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(Unsafe.As<long[]>(P_0)), P_2), Unsafe.As<T, long>(ref P_1), P_3) : SpanHelpers.IndexOf(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(Unsafe.As<long[]>(P_0)), P_2), Unsafe.As<T, long>(ref P_1), P_3));
				return ((num4 >= 0) ? P_2 : 0) + num4;
			}
		}
		return EqualityComparer<T>.Default.IndexOf(P_0, P_1, P_2, P_3);
	}

	public static int LastIndexOf<T>(T[] P_0, T P_1, int P_2)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		return LastIndexOf(P_0, P_1, P_2, (P_0.Length != 0) ? (P_2 + 1) : 0);
	}

	public static int LastIndexOf<T>(T[] P_0, T P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		if (P_0.Length == 0)
		{
			if (P_2 != -1 && P_2 != 0)
			{
				ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_IndexMustBeLess();
			}
			if (P_3 != 0)
			{
				ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
			}
			return -1;
		}
		if ((uint)P_2 >= (uint)P_0.Length)
		{
			ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_IndexMustBeLess();
		}
		if (P_3 < 0 || P_2 - P_3 + 1 < 0)
		{
			ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
		}
		if (RuntimeHelpers.IsBitwiseEquatable<T>())
		{
			if (Unsafe.SizeOf<T>() == 1)
			{
				int num = P_2 - P_3 + 1;
				int num2 = SpanHelpers.LastIndexOfValueType(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(Unsafe.As<byte[]>(P_0)), num), Unsafe.As<T, byte>(ref P_1), P_3);
				return ((num2 >= 0) ? num : 0) + num2;
			}
			if (Unsafe.SizeOf<T>() == 2)
			{
				int num3 = P_2 - P_3 + 1;
				int num4 = SpanHelpers.LastIndexOfValueType(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(Unsafe.As<short[]>(P_0)), num3), Unsafe.As<T, short>(ref P_1), P_3);
				return ((num4 >= 0) ? num3 : 0) + num4;
			}
			if (Unsafe.SizeOf<T>() == 4)
			{
				int num5 = P_2 - P_3 + 1;
				int num6 = SpanHelpers.LastIndexOfValueType(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(Unsafe.As<int[]>(P_0)), num5), Unsafe.As<T, int>(ref P_1), P_3);
				return ((num6 >= 0) ? num5 : 0) + num6;
			}
			if (Unsafe.SizeOf<T>() == 8)
			{
				int num7 = P_2 - P_3 + 1;
				int num8 = SpanHelpers.LastIndexOfValueType(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(Unsafe.As<long[]>(P_0)), num7), Unsafe.As<T, long>(ref P_1), P_3);
				return ((num8 >= 0) ? num7 : 0) + num8;
			}
		}
		return EqualityComparer<T>.Default.LastIndexOf(P_0, P_1, P_2, P_3);
	}

	public static void Reverse(Array P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		int lowerBound = P_0.GetLowerBound(0);
		if (P_1 < lowerBound)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (P_2 < 0)
		{
			ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
		}
		if (P_0.Length - (P_1 - lowerBound) < P_2)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		if (P_0.Rank != 1)
		{
			ThrowHelper.ThrowRankException(ExceptionResource.Rank_MultiDimNotSupported);
		}
		if (P_2 <= 1)
		{
			return;
		}
		int num = P_1 - lowerBound;
		switch (P_0.GetCorElementTypeOfElementType())
		{
		case CorElementType.ELEMENT_TYPE_BOOLEAN:
		case CorElementType.ELEMENT_TYPE_I1:
		case CorElementType.ELEMENT_TYPE_U1:
			UnsafeArrayAsSpan<byte>(P_0, num, P_2).Reverse();
			return;
		case CorElementType.ELEMENT_TYPE_CHAR:
		case CorElementType.ELEMENT_TYPE_I2:
		case CorElementType.ELEMENT_TYPE_U2:
			UnsafeArrayAsSpan<short>(P_0, num, P_2).Reverse();
			return;
		case CorElementType.ELEMENT_TYPE_I4:
		case CorElementType.ELEMENT_TYPE_U4:
		case CorElementType.ELEMENT_TYPE_R4:
		case CorElementType.ELEMENT_TYPE_I:
		case CorElementType.ELEMENT_TYPE_U:
			UnsafeArrayAsSpan<int>(P_0, num, P_2).Reverse();
			return;
		case CorElementType.ELEMENT_TYPE_I8:
		case CorElementType.ELEMENT_TYPE_U8:
		case CorElementType.ELEMENT_TYPE_R8:
			UnsafeArrayAsSpan<long>(P_0, num, P_2).Reverse();
			return;
		case CorElementType.ELEMENT_TYPE_ARRAY:
		case CorElementType.ELEMENT_TYPE_OBJECT:
		case CorElementType.ELEMENT_TYPE_SZARRAY:
			UnsafeArrayAsSpan<object>(P_0, num, P_2).Reverse();
			return;
		}
		int num2 = P_1;
		int num3 = P_1 + P_2 - 1;
		while (num2 < num3)
		{
			object value = P_0.GetValue(num2);
			P_0.SetValue(P_0.GetValue(num3), num2);
			P_0.SetValue(value, num3);
			num2++;
			num3--;
		}
	}

	public static void Reverse<T>(T[] P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		if (P_0.Length > 1)
		{
			SpanHelpers.Reverse(ref MemoryMarshal.GetArrayDataReference(P_0), (nuint)P_0.Length);
		}
	}

	public static void Reverse<T>(T[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		if (P_1 < 0)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (P_2 < 0)
		{
			ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
		}
		if (P_0.Length - P_1 < P_2)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		if (P_2 > 1)
		{
			SpanHelpers.Reverse(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(P_0), P_1), (nuint)P_2);
		}
	}

	public static void Sort(Array P_0, IComparer? P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		Sort(P_0, null, P_0.GetLowerBound(0), P_0.Length, P_1);
	}

	public static void Sort(Array P_0, int P_1, int P_2, IComparer? P_3)
	{
		Sort(P_0, null, P_1, P_2, P_3);
	}

	public static void Sort(Array P_0, Array? P_1, int P_2, int P_3, IComparer? P_4)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keys);
		}
		if (P_0.Rank != 1 || (P_1 != null && P_1.Rank != 1))
		{
			ThrowHelper.ThrowRankException(ExceptionResource.Rank_MultiDimNotSupported);
		}
		int lowerBound = P_0.GetLowerBound(0);
		if (P_1 != null && lowerBound != P_1.GetLowerBound(0))
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_LowerBoundsMustMatch);
		}
		if (P_2 < lowerBound)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (P_3 < 0)
		{
			ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
		}
		if (P_0.Length - (P_2 - lowerBound) < P_3 || (P_1 != null && P_2 - lowerBound > P_1.Length - P_3))
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		if (P_3 <= 1)
		{
			return;
		}
		if (P_4 == null)
		{
			P_4 = Comparer.Default;
		}
		if (P_0 is object[] array)
		{
			object[] array2 = P_1 as object[];
			if (P_1 == null || array2 != null)
			{
				new SorterObjectArray(array, array2, P_4).Sort(P_2, P_3);
				return;
			}
		}
		if (P_4 == Comparer.Default)
		{
			CorElementType corElementTypeOfElementType = P_0.GetCorElementTypeOfElementType();
			if (P_1 == null || P_1.GetCorElementTypeOfElementType() == corElementTypeOfElementType)
			{
				int num = P_2 - lowerBound;
				switch (corElementTypeOfElementType)
				{
				case CorElementType.ELEMENT_TYPE_I1:
					GenericSort<sbyte>(P_0, P_1, num, P_3);
					return;
				case CorElementType.ELEMENT_TYPE_BOOLEAN:
				case CorElementType.ELEMENT_TYPE_U1:
					GenericSort<byte>(P_0, P_1, num, P_3);
					return;
				case CorElementType.ELEMENT_TYPE_I2:
					GenericSort<short>(P_0, P_1, num, P_3);
					return;
				case CorElementType.ELEMENT_TYPE_CHAR:
				case CorElementType.ELEMENT_TYPE_U2:
					GenericSort<ushort>(P_0, P_1, num, P_3);
					return;
				case CorElementType.ELEMENT_TYPE_I4:
				case CorElementType.ELEMENT_TYPE_I:
					GenericSort<int>(P_0, P_1, num, P_3);
					return;
				case CorElementType.ELEMENT_TYPE_U4:
				case CorElementType.ELEMENT_TYPE_U:
					GenericSort<uint>(P_0, P_1, num, P_3);
					return;
				case CorElementType.ELEMENT_TYPE_I8:
					GenericSort<long>(P_0, P_1, num, P_3);
					return;
				case CorElementType.ELEMENT_TYPE_U8:
					GenericSort<ulong>(P_0, P_1, num, P_3);
					return;
				case CorElementType.ELEMENT_TYPE_R4:
					GenericSort<float>(P_0, P_1, num, P_3);
					return;
				case CorElementType.ELEMENT_TYPE_R8:
					GenericSort<double>(P_0, P_1, num, P_3);
					return;
				}
			}
		}
		new SorterGenericArray(P_0, P_1, P_4).Sort(P_2, P_3);
		static void GenericSort<T>(Array array3, Array array4, int num2, int num3) where T : struct
		{
			Span<T> span = UnsafeArrayAsSpan<T>(array3, num2, num3);
			if (array4 != null)
			{
				span.Sort(UnsafeArrayAsSpan<T>(array4, num2, num3));
			}
			else
			{
				span.Sort();
			}
		}
	}

	public static void Sort<T>(T[] P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		if (P_0.Length > 1)
		{
			Span<T> span = new Span<T>(ref MemoryMarshal.GetArrayDataReference(P_0), P_0.Length);
			ArraySortHelper<T>.Default.Sort(span, null);
		}
	}

	public static void Sort<T>(T[] P_0, int P_1, int P_2)
	{
		Sort(P_0, P_1, P_2, null);
	}

	public static void Sort<T>(T[] P_0, IComparer<T>? P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		Sort(P_0, 0, P_0.Length, P_1);
	}

	public static void Sort<TKey, TValue>(TKey[] P_0, TValue[]? P_1, IComparer<TKey>? P_2)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keys);
		}
		Sort(P_0, P_1, 0, P_0.Length, P_2);
	}

	public static void Sort<T>(T[] P_0, int P_1, int P_2, IComparer<T>? P_3)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		if (P_1 < 0)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (P_2 < 0)
		{
			ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
		}
		if (P_0.Length - P_1 < P_2)
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		if (P_2 > 1)
		{
			Span<T> span = new Span<T>(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(P_0), P_1), P_2);
			ArraySortHelper<T>.Default.Sort(span, P_3);
		}
	}

	public static void Sort<TKey, TValue>(TKey[] P_0, TValue[]? P_1, int P_2, int P_3, IComparer<TKey>? P_4)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.keys);
		}
		if (P_2 < 0)
		{
			ThrowHelper.ThrowIndexArgumentOutOfRange_NeedNonNegNumException();
		}
		if (P_3 < 0)
		{
			ThrowHelper.ThrowLengthArgumentOutOfRange_ArgumentOutOfRange_NeedNonNegNum();
		}
		if (P_0.Length - P_2 < P_3 || (P_1 != null && P_2 > P_1.Length - P_3))
		{
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
		}
		if (P_3 > 1)
		{
			if (P_1 == null)
			{
				Sort(P_0, P_2, P_3, P_4);
				return;
			}
			Span<TKey> span = new Span<TKey>(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(P_0), P_2), P_3);
			Span<TValue> span2 = new Span<TValue>(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(P_1), P_2), P_3);
			ArraySortHelper<TKey, TValue>.Default.Sort(span, span2, P_4);
		}
	}

	private static Span<T> UnsafeArrayAsSpan<T>(Array P_0, int P_1, int P_2)
	{
		return new Span<T>(ref Unsafe.As<byte, T>(ref MemoryMarshal.GetArrayDataReference(P_0)), P_0.Length).Slice(P_1, P_2);
	}

	public IEnumerator GetEnumerator()
	{
		return new ArrayEnumerator(this);
	}
}
