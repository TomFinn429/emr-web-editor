using System;

namespace zzz;

internal static class z0ZzZzqij
{
	private static int z0eek(z0ZzZzbuj p0, bool p1)
	{
		int num = 0;
		int num2 = 0;
		int num3 = -1;
		int num4 = (p1 ? p0.z0rek() : p0.z0tek());
		int num5 = (p1 ? p0.z0tek() : p0.z0rek());
		sbyte[][] array = p0.z0eek();
		for (int i = 0; i < num4; i++)
		{
			for (int j = 0; j < num5; j++)
			{
				int num6 = (p1 ? array[i][j] : array[j][i]);
				if (num6 == num3)
				{
					num2++;
					if (num2 == 5)
					{
						num += 3;
					}
					else if (num2 > 5)
					{
						num++;
					}
				}
				else
				{
					num2 = 1;
					num3 = num6;
				}
			}
			num2 = 0;
		}
		return num;
	}

	public static bool z0eek(int p0, int p1, int p2)
	{
		if (!z0ZzZzeij.z0rek(p0))
		{
			throw new ArgumentException("Invalid mask pattern");
		}
		int num2;
		switch (p0)
		{
		case 0:
			num2 = (p2 + p1) & 1;
			break;
		case 1:
			num2 = p2 & 1;
			break;
		case 2:
			num2 = p1 % 3;
			break;
		case 3:
			num2 = (p2 + p1) % 3;
			break;
		case 4:
			num2 = (z0ZzZztij.z0eek(p2, 1) + p1 / 3) & 1;
			break;
		case 5:
		{
			int num = p2 * p1;
			num2 = (num & 1) + num % 3;
			break;
		}
		case 6:
		{
			int num = p2 * p1;
			num2 = ((num & 1) + num % 3) & 1;
			break;
		}
		case 7:
		{
			int num = p2 * p1;
			num2 = (num % 3 + ((p2 + p1) & 1)) & 1;
			break;
		}
		default:
			throw new ArgumentException("Invalid mask pattern: " + p0);
		}
		return num2 == 0;
	}

	public static int z0eek(z0ZzZzbuj p0)
	{
		return z0eek(p0, p1: true) + z0eek(p0, p1: false);
	}

	public static int z0rek(z0ZzZzbuj p0)
	{
		int num = 0;
		sbyte[][] array = p0.z0eek();
		int num2 = p0.z0tek();
		int num3 = p0.z0rek();
		for (int i = 0; i < num3; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				if (j + 6 < num2 && array[i][j] == 1 && array[i][j + 1] == 0 && array[i][j + 2] == 1 && array[i][j + 3] == 1 && array[i][j + 4] == 1 && array[i][j + 5] == 0 && array[i][j + 6] == 1 && ((j + 10 < num2 && array[i][j + 7] == 0 && array[i][j + 8] == 0 && array[i][j + 9] == 0 && array[i][j + 10] == 0) || (j - 4 >= 0 && array[i][j - 1] == 0 && array[i][j - 2] == 0 && array[i][j - 3] == 0 && array[i][j - 4] == 0)))
				{
					num += 40;
				}
				if (i + 6 < num3 && array[i][j] == 1 && array[i + 1][j] == 0 && array[i + 2][j] == 1 && array[i + 3][j] == 1 && array[i + 4][j] == 1 && array[i + 5][j] == 0 && array[i + 6][j] == 1 && ((i + 10 < num3 && array[i + 7][j] == 0 && array[i + 8][j] == 0 && array[i + 9][j] == 0 && array[i + 10][j] == 0) || (i - 4 >= 0 && array[i - 1][j] == 0 && array[i - 2][j] == 0 && array[i - 3][j] == 0 && array[i - 4][j] == 0)))
				{
					num += 40;
				}
			}
		}
		return num;
	}

	public static int z0tek(z0ZzZzbuj p0)
	{
		int num = 0;
		sbyte[][] array = p0.z0eek();
		int num2 = p0.z0tek();
		int num3 = p0.z0rek();
		for (int i = 0; i < num3 - 1; i++)
		{
			for (int j = 0; j < num2 - 1; j++)
			{
				int num4 = array[i][j];
				if (num4 == array[i][j + 1] && num4 == array[i + 1][j] && num4 == array[i + 1][j + 1])
				{
					num += 3;
				}
			}
		}
		return num;
	}

	public static int z0yek(z0ZzZzbuj p0)
	{
		int num = 0;
		sbyte[][] array = p0.z0eek();
		int num2 = p0.z0tek();
		int num3 = p0.z0rek();
		for (int i = 0; i < num3; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				if (array[i][j] == 1)
				{
					num++;
				}
			}
		}
		int num4 = p0.z0rek() * p0.z0tek();
		return Math.Abs((int)((double)num / (double)num4 * 100.0 - 50.0)) / 5 * 10;
	}
}
