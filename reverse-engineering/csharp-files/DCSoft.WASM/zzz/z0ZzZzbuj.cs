using System.Text;

namespace zzz;

internal sealed class z0ZzZzbuj
{
	private sbyte[][] z0yek;

	private int z0uek;

	private int z0iek;

	public sbyte[][] z0eek()
	{
		return z0yek;
	}

	public void z0eek(int p0, int p1, int p2)
	{
		z0yek[p1][p0] = (sbyte)p2;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(2 * z0iek * z0uek + 2);
		for (int i = 0; i < z0uek; i++)
		{
			for (int j = 0; j < z0iek; j++)
			{
				switch (z0yek[i][j])
				{
				case 0:
					stringBuilder.Append(" 0");
					break;
				case 1:
					stringBuilder.Append(" 1");
					break;
				default:
					stringBuilder.Append("  ");
					break;
				}
			}
			stringBuilder.Append('\n');
		}
		return stringBuilder.ToString();
	}

	public void z0eek(sbyte p0)
	{
		for (int i = 0; i < z0uek; i++)
		{
			for (int j = 0; j < z0iek; j++)
			{
				z0yek[i][j] = p0;
			}
		}
	}

	public sbyte z0eek(int p0, int p1)
	{
		return z0yek[p1][p0];
	}

	public int z0rek()
	{
		return z0uek;
	}

	public int z0tek()
	{
		return z0iek;
	}

	public z0ZzZzbuj(int p0, int p1)
	{
		z0yek = new sbyte[p1][];
		for (int i = 0; i < p1; i++)
		{
			z0yek[i] = new sbyte[p0];
		}
		z0iek = p0;
		z0uek = p1;
	}
}
