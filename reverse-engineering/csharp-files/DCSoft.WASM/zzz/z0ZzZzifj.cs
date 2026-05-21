namespace zzz;

internal class z0ZzZzifj : z0ZzZztfj
{
	private new readonly short[] z0eek;

	private new readonly ushort z0rek;

	private new readonly short z0tek;

	internal z0ZzZzifj(z0ZzZzudj p0, z0ZzZzxfj p1, z0ZzZzjgj p2)
		: base(p0, p1, p2)
	{
		z0rek = (ushort)p2.z0rek();
		z0tek = p2.z0yek();
		z0eek = p2.z0uek(z0tek);
	}

	internal override int z0qdk(int p0)
	{
		int num = p0;
		if (z0eek() && z0rek >= 61440)
		{
			num += 61440;
		}
		int num2 = num - z0rek;
		if (num2 < 0 || num2 >= z0tek)
		{
			return 0;
		}
		return (ushort)z0eek[num2];
	}

	protected override z0ZzZzhfj z0sdk()
	{
		return (z0ZzZzhfj)6;
	}

	internal override void z0wdk(z0ZzZzjgj p0)
	{
		base.z0wdk(p0);
		p0.z0eek((short)z0rek);
		p0.z0eek(z0tek);
		p0.z0eek(z0eek);
	}

	internal override int z0adk()
	{
		return 10 + z0eek.Length * 2;
	}
}
