namespace zzz;

internal class z0ZzZznfj : z0ZzZzjfj
{
	private new readonly z0ZzZzmfj[] z0rek;

	internal z0ZzZznfj(z0ZzZzudj p0, z0ZzZzxfj p1, z0ZzZzjgj p2)
		: base(p0, p1)
	{
		long num = p2.z0uek() - 2;
		p2.z0nek();
		int num2 = p2.z0nek();
		z0rek = new z0ZzZzmfj[num2];
		for (int i = 0; i < num2; i++)
		{
			int p3 = p2.z0bek();
			int num3 = p2.z0nek();
			int num4 = p2.z0nek();
			long p4 = p2.z0uek();
			z0ZzZzofj[] array;
			if (num3 == 0)
			{
				array = null;
			}
			else
			{
				p2.z0eek(num + num3);
				int num5 = p2.z0nek();
				array = new z0ZzZzofj[num5];
				for (int j = 0; j < num5; j++)
				{
					array[j] = new z0ZzZzofj(p2.z0bek(), p2.z0tek());
				}
			}
			z0ZzZzpfj[] array2;
			if (num4 == 0)
			{
				array2 = null;
			}
			else
			{
				p2.z0eek(num + num4);
				int num6 = p2.z0nek();
				array2 = new z0ZzZzpfj[num6];
				for (int k = 0; k < num6; k++)
				{
					array2[k] = new z0ZzZzpfj(p2.z0bek(), p2.z0yek());
				}
			}
			p2.z0eek(p4);
			z0rek[i] = new z0ZzZzmfj(p3, array, array2);
		}
		p2.z0eek(num + z0adk());
	}

	internal override void z0wdk(z0ZzZzjgj p0)
	{
		base.z0wdk(p0);
		p0.z0oek(z0adk());
		p0.z0oek(z0rek.Length);
		int num = 10 + z0rek.Length * 11;
		z0ZzZzmfj[] array = z0rek;
		foreach (z0ZzZzmfj z0ZzZzmfj2 in array)
		{
			num += z0ZzZzmfj2.z0eek(p0, num);
		}
		array = z0rek;
		foreach (z0ZzZzmfj z0ZzZzmfj3 in array)
		{
			z0ZzZzofj[] array2 = z0ZzZzmfj3.z0rek();
			if (array2 != null)
			{
				p0.z0oek(array2.Length);
				z0ZzZzofj[] array3 = array2;
				for (int j = 0; j < array3.Length; j++)
				{
					array3[j].z0eek(p0);
				}
			}
			z0ZzZzpfj[] array4 = z0ZzZzmfj3.z0eek();
			if (array4 != null)
			{
				p0.z0oek(array4.Length);
				z0ZzZzpfj[] array5 = array4;
				for (int j = 0; j < array5.Length; j++)
				{
					array5[j].z0eek(p0);
				}
			}
		}
	}

	protected override z0ZzZzhfj z0sdk()
	{
		return (z0ZzZzhfj)14;
	}

	internal override int z0adk()
	{
		int num = 10 + z0rek.Length * 11;
		z0ZzZzmfj[] array = z0rek;
		foreach (z0ZzZzmfj obj in array)
		{
			z0ZzZzofj[] array2 = obj.z0rek();
			if (array2 != null)
			{
				num += array2.Length * 4 + 4;
			}
			z0ZzZzpfj[] array3 = obj.z0eek();
			if (array3 != null)
			{
				num += array3.Length * 5 + 4;
			}
		}
		return num;
	}
}
