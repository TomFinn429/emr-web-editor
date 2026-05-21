using System;
using System.Collections.Generic;
using System.Text;

namespace zzz;

public class z0ZzZzbyk<T> : List<z0ZzZznyk> where T : notnull
{
	protected class z0lhj
	{
		public int z0pek = 1;

		public int z0mek;

		public bool z0nek;

		public const bool z0bek = true;

		public int z0vek;

		public IList<T> z0cek;

		public int z0xek;

		public int z0zek_jiejie20260327142557;

		public bool z0lrk;

		public int z0krk;

		public IList<T> z0jrk;

		public int z0hrk = -1;

		public string z0uek()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < z0mek; i++)
			{
				string text = z0cek[z0krk + i].ToString();
				if (text != null && text.Length > 0)
				{
					stringBuilder.Append(text);
				}
			}
			return stringBuilder.ToString();
		}

		private string z0uek(int p0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < z0mek; i++)
			{
				string text = z0jrk[z0zek_jiejie20260327142557 + i].ToString();
				if (!string.IsNullOrEmpty(text))
				{
					stringBuilder.Append(text);
				}
				if (p0 > 0 && stringBuilder.Length > p0)
				{
					break;
				}
			}
			return stringBuilder.ToString();
		}

		public int z0iek()
		{
			return z0krk + z0mek - 1;
		}

		public bool z0iek(int p0)
		{
			if (p0 >= z0zek_jiejie20260327142557)
			{
				return p0 < z0zek_jiejie20260327142557 + z0mek;
			}
			return false;
		}

		public void z0oek(int p0)
		{
			z0mek = p0;
		}

		public T z0eek()
		{
			return z0jrk[z0zek_jiejie20260327142557 + z0mek - 1];
		}

		public T z0rek()
		{
			return z0cek[z0krk + z0mek - 1];
		}

		public string z0oek()
		{
			return z0uek(0);
		}

		public T z0tek()
		{
			return z0jrk[z0zek_jiejie20260327142557];
		}

		public T z0yek()
		{
			return z0cek[z0krk];
		}
	}

	protected class z0khj : List<z0lhj>
	{
		public int z0rek;

		private int z0tek;

		public z0lhj z0eek(int p0, int p1, int p2, IList<T> p3, IList<T> p4)
		{
			z0rek++;
			int num = p0 + p2;
			int num2 = p1 + p2;
			int num3 = p2 * 8;
			int num4 = p2 / 8;
			for (int num5 = base.Count - 1; num5 >= 0; num5--)
			{
				z0lhj z0lhj = base[num5];
				if (z0lhj.z0mek > p2)
				{
					bool flag = num <= z0lhj.z0zek_jiejie20260327142557 + z0lhj.z0mek;
					bool flag2 = p1 >= z0lhj.z0krk && num2 <= z0lhj.z0krk + z0lhj.z0mek;
					if (flag && flag2)
					{
						return null;
					}
					if (z0lhj.z0mek > num3 && (flag || flag2))
					{
						return null;
					}
				}
				else if (z0lhj.z0mek < num4 && p1 <= z0lhj.z0krk && num2 > z0lhj.z0krk + z0lhj.z0mek)
				{
					RemoveAt(num5);
				}
			}
			z0lhj z0lhj2 = new z0lhj();
			z0lhj2.z0zek_jiejie20260327142557 = p0;
			z0lhj2.z0krk = p1;
			z0lhj2.z0mek = p2;
			z0lhj2.z0jrk = p3;
			z0lhj2.z0cek = p4;
			z0lhj2.z0xek = z0tek++;
			Add(z0lhj2);
			return z0lhj2;
		}
	}

	private readonly List<int> z0krk = new List<int>();

	protected z0khj z0jrk_jiejie20260327142557;

	private bool z0grk;

	private float z0frk = 0f / 0f;

	private bool z0srk;

	private int z0ark;

	private int z0qrk = 40000;

	protected List<T> z0wrk;

	private bool z0erk;

	[ThreadStatic]
	private static byte[] z0rrk;

	protected int z0trk;

	public int LastTickSpan => z0ark;

	public int z0oek()
	{
		return z0trk;
	}

	public virtual void z0wk()
	{
		Clear();
		if (z0jrk_jiejie20260327142557 != null)
		{
			z0jrk_jiejie20260327142557.Clear();
			z0jrk_jiejie20260327142557 = null;
		}
		if (z0wrk != null)
		{
			z0wrk.Clear();
			z0wrk = null;
		}
		z0krk.Clear();
	}

	protected virtual z0ZzZznyk z0eek(IList<T> p0, int p1, IList<T> p2, int p3, int p4)
	{
		z0ZzZznyk z0ZzZznyk2 = new z0ZzZznyk(z0wrk.Count, p4, (z0ZzZzvyk)2);
		Add(z0ZzZznyk2);
		z0wrk.Capacity = z0wrk.Count + p4;
		for (int i = 0; i < p4; i++)
		{
			z0wrk.Add(z0ak(p0[p1 + i], p2[p3 + i]));
		}
		return z0ZzZznyk2;
	}

	protected virtual T z0ak(T p0, T p1)
	{
		return p0;
	}

	protected virtual byte[][] z0dk(IList<T> p0, IList<T> p1, byte[] p2, ref int p3)
	{
		return null;
	}

	public virtual void z0pek()
	{
		Clear();
		z0jrk_jiejie20260327142557 = null;
		z0grk = false;
		z0ark = 0;
		z0trk = 0;
		z0krk.Clear();
		z0frk = 0f / 0f;
		z0wrk = null;
	}

	public void z0oek(bool p0)
	{
		z0srk = p0;
	}

	public virtual int z0qk(T p0)
	{
		return 1;
	}

	protected virtual z0ZzZznyk z0rek(IList<T> p0, int p1, int p2)
	{
		z0ZzZznyk z0ZzZznyk2 = new z0ZzZznyk(z0wrk.Count, p2, (z0ZzZzvyk)1);
		Add(z0ZzZznyk2);
		z0wrk.Capacity = z0wrk.Count + p2;
		for (int i = 0; i < p2; i++)
		{
			z0wrk.Add(p0[p1 + i]);
		}
		return z0ZzZznyk2;
	}

	private bool z0tek(IList<T> p0, IList<T> p1, z0khj p2, int p3)
	{
		z0lhj z0lhj = p2[p3];
		if (z0lhj.z0zek_jiejie20260327142557 > 0 && z0ek(p0[z0lhj.z0zek_jiejie20260327142557 - 1]))
		{
			return false;
		}
		if (z0lhj.z0zek_jiejie20260327142557 + z0lhj.z0mek < p0.Count - 1 && z0ek(p0[z0lhj.z0zek_jiejie20260327142557 + z0lhj.z0mek]))
		{
			return false;
		}
		if (z0lhj.z0krk > 0 && z0ek(p1[z0lhj.z0krk - 1]))
		{
			return false;
		}
		if (z0lhj.z0krk + z0lhj.z0mek < p1.Count - 1 && z0ek(p1[z0lhj.z0krk + z0lhj.z0mek]))
		{
			return false;
		}
		p2.RemoveAt(p3);
		return true;
	}

	public void z0oek(int p0, int p1)
	{
		z0krk.Add(p0);
		z0krk.Add(p1);
	}

	public void z0oek(int p0)
	{
		z0trk = p0;
	}

	public float z0mek()
	{
		if (float.IsNaN(z0frk))
		{
			z0frk = z0uk();
		}
		return z0frk;
	}

	public virtual int GetValueHashCode()
	{
		if (base.Count == 0)
		{
			return 0;
		}
		StringBuilder stringBuilder = new StringBuilder();
		using (List<z0ZzZznyk>.Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZznyk current = enumerator.Current;
				stringBuilder.Append(current.z0oek.ToString());
				stringBuilder.Append(',');
				stringBuilder.Append(current.z0iek.ToString());
				stringBuilder.Append(',');
				stringBuilder.Append(current.z0uek.ToString());
				stringBuilder.Append(',');
			}
		}
		return stringBuilder.ToString().GetHashCode();
	}

	public bool z0nek()
	{
		return z0erk;
	}

	protected virtual z0ZzZznyk z0yek(IList<T> p0, int p1, int p2)
	{
		z0ZzZznyk z0ZzZznyk2 = new z0ZzZznyk(z0zek().Count, p2, (z0ZzZzvyk)0);
		Add(z0ZzZznyk2);
		z0wrk.Capacity += p2;
		for (int i = 0; i < p2; i++)
		{
			z0wrk.Add(p0[p1 + i]);
		}
		return z0ZzZznyk2;
	}

	public virtual void Compare(IList<T> oldList, IList<T> newList)
	{
		z0jrk_jiejie20260327142557 = null;
		z0grk = true;
		Clear();
		if (oldList == newList)
		{
			return;
		}
		int num = oldList?.Count ?? 0;
		int num2 = newList?.Count ?? 0;
		if (num == 0 && num2 == 0)
		{
			return;
		}
		z0wrk = new List<T>();
		if (num == 0 || num2 == 0)
		{
			if (num == 0)
			{
				z0yek(newList, 0, num2).z0yek = 0;
			}
			else
			{
				z0rek(oldList, 0, num).z0pek = 0;
			}
			z0ark = 0;
			return;
		}
		int tickCount = Environment.TickCount;
		z0khj z0khj = new z0khj();
		int[] array = z0ik(oldList, newList);
		if (array != null && array.Length == oldList.Count)
		{
			int num3 = -1;
			for (int i = 0; i < num; i++)
			{
				int num4 = array[i];
				if (num4 < 0 || num4 < num3)
				{
					continue;
				}
				int num5 = i;
				for (; i < num; i++)
				{
					if (array[i] != num4 + i - num5)
					{
						z0khj.z0eek(num5, num4, i - num5, oldList, newList);
						break;
					}
				}
			}
			z0iek(z0khj, oldList, newList);
			z0ark = Math.Abs(Environment.TickCount - tickCount);
			return;
		}
		if (num == num2)
		{
			bool flag = true;
			for (int j = 0; j < num; j++)
			{
				if (!EqualValues(oldList[j], j, newList[j], j))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				z0ZzZznyk obj = z0eek(oldList, 0, newList, 0, num2);
				obj.z0yek = 0;
				obj.z0pek = 0;
				z0ark = Math.Abs(Environment.TickCount - tickCount);
				return;
			}
		}
		if (z0nek())
		{
			z0rek(oldList, 0, num);
			z0yek(newList, 0, num2);
			z0ark = Math.Abs(Environment.TickCount - tickCount);
			return;
		}
		int p = 0;
		List<z0lhj> list = new List<z0lhj>();
		z0lhj z0lhj = null;
		int[] array2 = new int[num];
		for (int k = 0; k < num; k++)
		{
			array2[k] = z0qk(oldList[k]);
		}
		if (z0rrk == null || z0rrk.Length < num2)
		{
			z0rrk = new byte[num2];
			for (int l = 0; l < num2; l++)
			{
				z0rrk[l] = 2;
			}
		}
		byte[][] array3 = z0dk(oldList, newList, z0rrk, ref p);
		for (int m = 0; m < num; m++)
		{
			T oldElement = oldList[m];
			if (m == 15)
			{
				_ = 16;
			}
			if (z0khj.Count > 0)
			{
				if (list.Count > 0)
				{
					list.Clear();
				}
				for (int num6 = z0khj.Count - 1; num6 >= 0; num6--)
				{
					z0lhj z0lhj2 = z0khj[num6];
					if (z0lhj2.z0zek_jiejie20260327142557 < m)
					{
						break;
					}
					if (z0lhj2.z0mek > 1 && m < z0lhj2.z0zek_jiejie20260327142557 + z0lhj2.z0mek)
					{
						list.Add(z0lhj2);
					}
				}
			}
			if (z0lhj != null && !z0lhj.z0iek(m))
			{
				z0lhj = null;
			}
			bool flag2 = list.Count > 0;
			byte[] array4 = null;
			if (array3 != null)
			{
				array4 = array3[m];
				if (array4 == z0rrk)
				{
					array4 = null;
				}
			}
			for (int n = 0; n < num2; n++)
			{
				if (flag2)
				{
					foreach (z0lhj item in list)
					{
						if (m - item.z0zek_jiejie20260327142557 == n - item.z0krk)
						{
							n = item.z0krk + item.z0mek;
							break;
						}
					}
					if (n >= num2)
					{
						break;
					}
				}
				if (array3 == null)
				{
					p++;
					if (!EqualValues(oldElement, m, newList[n], n))
					{
						continue;
					}
					int num7 = Math.Min(num - m, num2 - n);
					int num8 = 1;
					for (int num9 = 1; num9 < num7; num9++)
					{
						p++;
						if (!EqualValues(oldList[m + num9], m + num9, newList[n + num9], n + num9))
						{
							break;
						}
						num8++;
					}
					if (num8 != 1 || array2[m] != 1 || z0lhj == null || !z0lhj.z0iek(m))
					{
						if (num8 > 10)
						{
							z0lhj = z0khj.z0eek(m, n, num8, oldList, newList);
						}
						else if (z0khj.z0eek(m, n, num8, oldList, newList) == null)
						{
							n += num8 - 1;
							continue;
						}
						if (z0qrk > 0 && z0khj.Count > z0qrk)
						{
							break;
						}
						n = n + num8 - 1;
					}
					continue;
				}
				if (array4 == null)
				{
					p++;
					if (!EqualValues(oldElement, m, newList[n], n))
					{
						continue;
					}
				}
				else if (array4[n] == 0)
				{
					continue;
				}
				int num10 = Math.Min(num - m, num2 - n);
				int num11 = 1;
				for (int num12 = 1; num12 < num10; num12++)
				{
					switch (array3[m + num12][n + num12])
					{
					case 1:
						num11++;
						continue;
					case 2:
						p++;
						if (EqualValues(oldList[m + num12], m + num12, newList[n + num12], n + num12))
						{
							num11++;
							continue;
						}
						break;
					}
					break;
				}
				if (num11 != 1 || array2[m] != 1 || z0lhj == null || !z0lhj.z0iek(m))
				{
					if (num11 > 10)
					{
						z0lhj = z0khj.z0eek(m, n, num11, oldList, newList);
					}
					else if (z0khj.z0eek(m, n, num11, oldList, newList) == null)
					{
						n += num11 - 1;
						continue;
					}
					if (z0qrk > 0 && z0khj.Count > z0qrk)
					{
						break;
					}
					n = n + num11 - 1;
				}
			}
			if (z0qrk > 0 && z0khj.Count > z0qrk)
			{
				break;
			}
		}
		_ = 16;
		array3 = null;
		list.Clear();
		if (z0khj.Count == 1)
		{
			z0lhj z0lhj3 = z0khj[0];
			if (z0lhj3.z0zek_jiejie20260327142557 == 0 && z0lhj3.z0krk == 0 && z0lhj3.z0mek == num && num == num2)
			{
				z0khj.Clear();
				z0ZzZznyk obj2 = z0eek(oldList, 0, newList, 0, num2);
				obj2.z0yek = 0;
				obj2.z0pek = 0;
				z0ark = Environment.TickCount - tickCount;
				return;
			}
		}
		if (z0khj.Count > 1)
		{
			foreach (z0lhj item2 in z0khj)
			{
				item2.z0lrk = false;
				item2.z0vek = 0;
				item2.z0nek = true;
				int num13 = item2.z0zek_jiejie20260327142557 + item2.z0mek;
				for (int num14 = item2.z0zek_jiejie20260327142557; num14 < num13; num14++)
				{
					int num15 = array2[num14];
					if (num15 == 1)
					{
						item2.z0vek++;
						continue;
					}
					item2.z0vek += num15;
					item2.z0nek = false;
				}
			}
			while (true)
			{
				z0lhj z0lhj4 = null;
				foreach (z0lhj item3 in z0khj)
				{
					if (!item3.z0lrk && (z0lhj4 == null || z0lhj4.z0mek < item3.z0mek))
					{
						z0lhj4 = item3;
					}
				}
				if (z0lhj4 == null)
				{
					break;
				}
				z0lhj4.z0lrk = true;
				int num16 = z0lhj4.z0krk + z0lhj4.z0mek;
				int num17 = z0lhj4.z0zek_jiejie20260327142557 + z0lhj4.z0mek;
				for (int num18 = z0khj.Count - 1; num18 >= 0; num18--)
				{
					z0lhj z0lhj5 = z0khj[num18];
					if (z0lhj5.z0lrk || z0lhj5.z0mek > z0lhj4.z0mek)
					{
						continue;
					}
					bool flag3 = z0lhj5.z0zek_jiejie20260327142557 >= z0lhj4.z0zek_jiejie20260327142557 && z0lhj5.z0zek_jiejie20260327142557 + z0lhj5.z0mek <= num17;
					bool flag4 = z0lhj5.z0krk >= z0lhj4.z0krk && z0lhj5.z0krk + z0lhj5.z0mek <= num16;
					if (flag3 && flag4)
					{
						z0khj.RemoveAt(num18);
					}
					else if (flag3 || flag4)
					{
						z0khj.RemoveAt(num18);
					}
					else if (z0lhj5.z0zek_jiejie20260327142557 < z0lhj4.z0zek_jiejie20260327142557 && z0lhj5.z0krk < z0lhj4.z0krk)
					{
						if (z0lhj5.z0zek_jiejie20260327142557 + z0lhj5.z0mek > z0lhj4.z0zek_jiejie20260327142557)
						{
							z0lhj5.z0oek(z0lhj4.z0zek_jiejie20260327142557 - z0lhj5.z0zek_jiejie20260327142557);
						}
						if (z0lhj5.z0krk + z0lhj5.z0mek > z0lhj4.z0krk)
						{
							z0lhj5.z0oek(z0lhj4.z0krk - z0lhj5.z0krk);
						}
					}
					else
					{
						if (z0lhj5.z0zek_jiejie20260327142557 + z0lhj5.z0mek < num17 || z0lhj5.z0krk + z0lhj5.z0mek < num16)
						{
							continue;
						}
						if (z0lhj5.z0zek_jiejie20260327142557 < num17)
						{
							int num19 = num17 - z0lhj5.z0zek_jiejie20260327142557;
							if (z0lhj5.z0mek == num19)
							{
								z0khj.RemoveAt(num18);
								continue;
							}
							z0lhj5.z0oek(z0lhj5.z0mek - num19);
							z0lhj5.z0zek_jiejie20260327142557 += num19;
							z0lhj5.z0krk += num19;
						}
						if (z0lhj5.z0krk < num16)
						{
							int num20 = num16 - z0lhj5.z0krk;
							if (num20 == z0lhj5.z0mek)
							{
								z0khj.RemoveAt(num18);
								continue;
							}
							z0lhj5.z0oek(z0lhj5.z0mek - num20);
							z0lhj5.z0zek_jiejie20260327142557 += num20;
							z0lhj5.z0krk += num20;
						}
					}
				}
			}
			for (int num21 = z0khj.Count - 1; num21 >= 0; num21--)
			{
				z0lhj z0lhj6 = z0khj[num21];
				for (int num22 = num21 - 1; num22 >= 0; num22--)
				{
					z0lhj z0lhj7 = z0khj[num22];
					bool flag5 = false;
					int num23 = ((z0lhj6.z0mek < z0lhj7.z0mek) ? z0lhj6.z0mek : z0lhj7.z0mek);
					if (z0lhj6.z0krk < z0lhj7.z0krk + z0lhj7.z0mek && z0lhj6.z0krk + z0lhj6.z0mek >= z0lhj7.z0krk)
					{
						flag5 = true;
						if (num23 > 10)
						{
							int num24 = num23 / 3;
							if (z0lhj6.z0krk < z0lhj7.z0krk)
							{
								int num25 = z0lhj6.z0krk + z0lhj6.z0mek - z0lhj7.z0krk;
								if (num25 < num24)
								{
									z0lhj6.z0oek(z0lhj6.z0mek - num25);
									flag5 = false;
								}
							}
							else
							{
								int num26 = z0lhj7.z0krk + z0lhj7.z0mek - z0lhj6.z0krk;
								if (num26 < num24)
								{
									z0lhj7.z0oek(z0lhj6.z0mek - num26);
									flag5 = false;
								}
							}
						}
					}
					else if (z0lhj6.z0zek_jiejie20260327142557 < z0lhj7.z0zek_jiejie20260327142557 + z0lhj7.z0mek && z0lhj6.z0zek_jiejie20260327142557 + z0lhj6.z0mek >= z0lhj7.z0zek_jiejie20260327142557)
					{
						flag5 = true;
						if (num23 > 10)
						{
							int num27 = num23 / 3;
							if (z0lhj6.z0zek_jiejie20260327142557 < z0lhj7.z0zek_jiejie20260327142557)
							{
								int num28 = z0lhj6.z0zek_jiejie20260327142557 + z0lhj6.z0mek - z0lhj7.z0zek_jiejie20260327142557;
								if (num28 < num27)
								{
									z0lhj6.z0oek(z0lhj6.z0mek - num28);
									flag5 = false;
								}
							}
							else
							{
								int num29 = z0lhj7.z0zek_jiejie20260327142557 + z0lhj7.z0mek - z0lhj6.z0zek_jiejie20260327142557;
								if (num29 < num27)
								{
									z0lhj7.z0oek(z0lhj6.z0mek - num29);
									flag5 = false;
								}
							}
						}
					}
					if (flag5 && (z0lhj7.z0zek_jiejie20260327142557 + z0lhj7.z0mek != z0lhj6.z0zek_jiejie20260327142557 + 1 || z0lhj6.z0mek <= 1 || z0lhj6.z0krk < z0lhj7.z0krk + z0lhj7.z0mek))
					{
						int num30 = 0;
						for (int num31 = 0; num31 < z0lhj6.z0mek; num31++)
						{
							num30 += array2[z0lhj6.z0zek_jiejie20260327142557 + num31];
						}
						int num32 = 0;
						for (int num33 = 0; num33 < z0lhj7.z0mek; num33++)
						{
							num32 += array2[z0lhj7.z0zek_jiejie20260327142557 + num33];
						}
						if (num30 <= num32)
						{
							z0tek(oldList, newList, z0khj, num21);
							break;
						}
						z0tek(oldList, newList, z0khj, num22);
						num21--;
					}
				}
			}
			for (int num34 = z0khj.Count - 1; num34 > 0; num34--)
			{
				if (z0khj[num34].z0krk < z0khj[num34 - 1].z0krk)
				{
					if ((double)z0khj[num34].z0mek / (double)z0khj[num34 - 1].z0mek > 2.0)
					{
						z0khj.RemoveAt(num34 - 1);
					}
					else
					{
						z0khj.RemoveAt(num34);
					}
				}
			}
		}
		if (z0tk())
		{
			z0jrk_jiejie20260327142557 = z0khj;
		}
		if (z0khj.Count > 1)
		{
			int num35 = num + num2;
			foreach (z0lhj item4 in z0khj)
			{
				if ((double)item4.z0mek > (double)num35 * 0.2)
				{
					num35 -= item4.z0mek;
				}
			}
			int num36 = num35 / 50;
			if (num36 == 0)
			{
				if (num35 > 30)
				{
					num36 = 3;
				}
				else if (num35 > 10)
				{
					num36 = 2;
				}
			}
			for (int num37 = z0khj.Count - 1; num37 >= 0; num37--)
			{
				z0lhj z0lhj8 = z0khj[num37];
				if (z0lhj8.z0vek < 4 && z0lhj8.z0zek_jiejie20260327142557 + z0lhj8.z0mek == num && z0lhj8.z0krk + z0lhj8.z0mek == num2)
				{
					if (num37 > 0)
					{
						z0lhj z0lhj9 = z0khj[num37 - 1];
						if (z0lhj9.z0zek_jiejie20260327142557 + z0lhj9.z0mek == z0lhj8.z0zek_jiejie20260327142557 || z0lhj9.z0krk + z0lhj9.z0mek == z0lhj8.z0krk)
						{
							continue;
						}
					}
					if (Math.Abs(z0lhj8.z0zek_jiejie20260327142557 - z0lhj8.z0krk) >= z0lhj8.z0vek * 7)
					{
						if (z0sk(oldList, newList, z0lhj8))
						{
							z0khj.RemoveAt(num37);
						}
						continue;
					}
				}
				if (z0cek() || z0lhj8.z0vek > num36)
				{
					continue;
				}
				bool flag6 = true;
				for (int num38 = 0; num38 < z0lhj8.z0mek; num38++)
				{
					if (array2[z0lhj8.z0zek_jiejie20260327142557 + num38] > 1)
					{
						flag6 = true;
						break;
					}
				}
				if (flag6)
				{
					z0tek(oldList, newList, z0khj, num37);
				}
			}
		}
		bool flag7 = false;
		if (z0khj.Count > 1)
		{
			foreach (z0lhj item5 in z0khj)
			{
				item5.z0lrk = false;
			}
			while (true)
			{
				z0lhj z0lhj10 = null;
				foreach (z0lhj item6 in z0khj)
				{
					if (!item6.z0lrk && (z0lhj10 == null || z0lhj10.z0mek < item6.z0mek))
					{
						z0lhj10 = item6;
					}
				}
				if (z0lhj10 == null)
				{
					break;
				}
				z0lhj10.z0lrk = true;
				for (int num39 = z0khj.Count - 1; num39 >= 0; num39--)
				{
					z0lhj z0lhj11 = z0khj[num39];
					if (z0lhj11 == z0lhj10)
					{
						break;
					}
					if (z0lhj11.z0krk <= z0lhj10.z0krk)
					{
						z0khj.RemoveAt(num39);
					}
				}
			}
		}
		if (z0khj.Count > 1 && flag7)
		{
			for (int num40 = z0khj.Count - 1; num40 > 0; num40--)
			{
				z0lhj z0lhj12 = z0khj[num40];
				z0lhj z0lhj13 = z0khj[num40 - 1];
				for (int num41 = num40 - 2; num41 >= 0; num41--)
				{
					if (z0lhj13.z0krk < z0khj[num41].z0krk)
					{
						z0lhj13 = z0khj[num41];
					}
				}
				if (z0lhj13 != z0khj[num40 - 1] && z0lhj13.z0mek >= z0lhj12.z0mek)
				{
					int num42 = num40;
					while (num42 >= 0 && z0khj[num42] != z0lhj13)
					{
						z0khj.RemoveAt(num42);
						num40--;
						num42--;
					}
				}
			}
		}
		if (z0khj.Count > 1)
		{
			for (int num43 = z0khj.Count - 1; num43 >= 0; num43--)
			{
				z0lhj z0lhj14 = z0khj[num43];
				bool flag8 = false;
				for (int num44 = z0khj.Count - 1; num44 >= 0; num44--)
				{
					z0lhj z0lhj15 = z0khj[num44];
					if (z0lhj15 != z0lhj14 && ((z0lhj15.z0krk >= z0lhj14.z0krk && z0lhj15.z0krk + z0lhj15.z0mek < z0lhj14.z0krk + z0lhj14.z0mek) || (z0lhj15.z0zek_jiejie20260327142557 >= z0lhj14.z0zek_jiejie20260327142557 && z0lhj15.z0zek_jiejie20260327142557 + z0lhj15.z0mek < z0lhj14.z0zek_jiejie20260327142557 + z0lhj14.z0mek)))
					{
						z0khj.RemoveAt(num44);
						flag8 = true;
					}
				}
				if (flag8)
				{
					num43 = z0khj.IndexOf(z0lhj14);
				}
			}
		}
		if (z0khj.Count > 1 && !z0cek())
		{
			int num45 = num + num2;
			foreach (z0lhj item7 in z0khj)
			{
				if ((double)item7.z0mek > (double)num45 * 0.2)
				{
					num45 -= item7.z0mek;
				}
			}
			int num46 = num45 / 50;
			for (int num47 = z0khj.Count - 1; num47 >= 0; num47--)
			{
				z0lhj z0lhj16 = z0khj[num47];
				if (z0lhj16.z0vek < num46)
				{
					bool flag9 = true;
					for (int num48 = 0; num48 < z0lhj16.z0mek; num48++)
					{
						if (array2[z0lhj16.z0zek_jiejie20260327142557 + num48] > 1)
						{
							flag9 = true;
							break;
						}
					}
					if (flag9)
					{
						z0tek(oldList, newList, z0khj, num47);
					}
				}
			}
		}
		if (z0khj.Count > 1)
		{
			for (int num49 = 0; num49 < z0khj.Count; num49++)
			{
				z0lhj z0lhj17 = z0khj[num49];
				z0lhj z0lhj18 = null;
				if (num49 > 0)
				{
					z0lhj18 = z0khj[num49 - 1];
				}
				int num50 = z0lhj17.z0zek_jiejie20260327142557 - 1;
				int num51 = z0lhj17.z0krk - 1;
				while (num50 >= 0 && num51 >= 0 && EqualValues(oldList[num50], num50, newList[num51], num51) && (z0lhj18 == null || (num50 >= z0lhj18.z0zek_jiejie20260327142557 + z0lhj18.z0mek && num51 >= z0lhj18.z0krk + z0lhj18.z0mek)))
				{
					z0lhj17.z0zek_jiejie20260327142557--;
					z0lhj17.z0krk--;
					z0lhj17.z0mek++;
					num50--;
					num51--;
				}
				z0lhj18 = ((num49 >= z0khj.Count - 1) ? null : z0khj[num49 + 1]);
				int num52 = z0lhj17.z0zek_jiejie20260327142557 + z0lhj17.z0mek;
				int num53 = z0lhj17.z0krk + z0lhj17.z0mek;
				while (num52 < num && num53 < num2 && EqualValues(oldList[num52], num52, newList[num53], num53) && (z0lhj18 == null || (num52 < z0lhj18.z0zek_jiejie20260327142557 && num53 < z0lhj18.z0krk)))
				{
					z0lhj17.z0mek++;
					num52++;
					num53++;
				}
			}
		}
		if (z0khj.Count > 0 && z0cek())
		{
			int num54 = (int)Math.Min((double)(num + num2) / 150.0, 3.0);
			if (num54 >= 1)
			{
				for (int num55 = z0khj.Count - 1; num55 >= 0; num55--)
				{
					if (z0khj[num55].z0mek <= num54)
					{
						z0khj.RemoveAt(num55);
					}
				}
			}
		}
		z0iek(z0khj, oldList, newList);
		z0ark = Math.Abs(Environment.TickCount - tickCount);
	}

	public void z0pek(int p0)
	{
		z0qrk = p0;
	}

	public int z0bek()
	{
		return z0qrk;
	}

	protected virtual bool z0yk(IList<T> p0, IList<T> p1)
	{
		int num = (p0.Count + p1.Count) / 2;
		if ((base.Count - 1) * 4 > num && num < 30)
		{
			return true;
		}
		return false;
	}

	public virtual bool EqualValues(T oldElement, int oldIndex, T newElement, int newIndex)
	{
		return object.Equals(oldElement, newElement);
	}

	protected virtual bool z0sk(IList<T> p0, IList<T> p1, z0lhj p2)
	{
		return true;
	}

	public void z0pek(bool p0)
	{
		z0grk = p0;
	}

	protected virtual void z0uek(z0khj p0, IList<T> p1, IList<T> p2)
	{
	}

	public int z0vek()
	{
		int num = 0;
		using List<z0ZzZznyk>.Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZznyk current = enumerator.Current;
			if (current.z0tek() || current.z0eek())
			{
				num++;
			}
		}
		return num;
	}

	protected virtual bool z0tk()
	{
		return false;
	}

	public virtual float z0uk()
	{
		float result = 0f;
		if (z0wrk != null && z0wrk.Count > 0)
		{
			int num = 0;
			using (List<z0ZzZznyk>.Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					z0ZzZznyk current = enumerator.Current;
					if (current.z0rek())
					{
						num += current.z0iek;
					}
				}
			}
			num += z0oek();
			result = (float)num / (float)z0wrk.Count;
		}
		return result;
	}

	protected virtual int[] z0ik(IList<T> p0, IList<T> p1)
	{
		return null;
	}

	public bool z0cek()
	{
		return z0srk;
	}

	public bool z0xek()
	{
		return z0grk;
	}

	protected virtual bool z0ek(T p0)
	{
		return false;
	}

	private void z0iek(z0khj p0, IList<T> p1, IList<T> p2)
	{
		if (p0 == null)
		{
			return;
		}
		int count = p1.Count;
		int count2 = p2.Count;
		if (p0.Count > 0)
		{
			int count3 = p0.Count;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < count3; i++)
			{
				z0lhj z0lhj = p0[i];
				if (i < count3 - 1)
				{
					z0lhj z0lhj2 = p0[i + 1];
					if (z0lhj.z0zek_jiejie20260327142557 + z0lhj.z0mek > z0lhj2.z0zek_jiejie20260327142557)
					{
						z0rk("重复删除旧元素" + z0lhj2.z0zek_jiejie20260327142557);
					}
					if (z0lhj.z0krk + z0lhj.z0mek > z0lhj2.z0krk)
					{
						z0rk("重复添加新元素" + z0lhj2.z0krk);
					}
				}
				num3 += z0lhj.z0mek;
				if (z0lhj.z0zek_jiejie20260327142557 > num)
				{
					z0rek(p1, num, z0lhj.z0zek_jiejie20260327142557 - num);
					num = z0lhj.z0zek_jiejie20260327142557 + z0lhj.z0mek;
				}
				if (z0lhj.z0krk > num2)
				{
					z0yek(p2, num2, z0lhj.z0krk - num2);
					num2 = z0lhj.z0krk + z0lhj.z0mek;
				}
				z0lhj.z0hrk = z0wrk.Count;
				if (z0lhj.z0zek_jiejie20260327142557 + z0lhj.z0mek > p1.Count)
				{
					z0lhj.z0mek = p1.Count - z0lhj.z0zek_jiejie20260327142557;
				}
				if (z0lhj.z0krk + z0lhj.z0mek > p2.Count)
				{
					z0lhj.z0mek = p2.Count - z0lhj.z0krk;
				}
				z0ZzZznyk obj = z0eek(p1, z0lhj.z0zek_jiejie20260327142557, p2, z0lhj.z0krk, z0lhj.z0mek);
				obj.z0pek = z0lhj.z0zek_jiejie20260327142557;
				obj.z0yek = z0lhj.z0krk;
				num = z0lhj.z0zek_jiejie20260327142557 + z0lhj.z0mek;
				num2 = z0lhj.z0krk + z0lhj.z0mek;
			}
			if (num < count)
			{
				z0rek(p1, num, count - num);
			}
			if (num2 < count2)
			{
				z0yek(p2, num2, count2 - num2);
			}
			if (p0.Count > 1 && !z0cek() && z0yk(p1, p2))
			{
				Clear();
				z0wrk.Clear();
				z0rek(p1, 0, count);
				z0yek(p2, 0, count2);
			}
		}
		else
		{
			z0rek(p1, 0, count).z0pek = 0;
			z0yek(p2, 0, count2).z0yek = 0;
		}
	}

	public void z0mek(bool p0)
	{
		z0erk = p0;
	}

	public virtual void z0rk(string p0)
	{
		throw new Exception(p0);
	}

	public List<T> z0zek()
	{
		return z0wrk;
	}
}
