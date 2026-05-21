using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzgyk : IComparer<z0ZzZzkyk>
{
	public int Compare(z0ZzZzkyk x, z0ZzZzkyk y)
	{
		if (x == y)
		{
			return 0;
		}
		if ((x.z0trk() <= 270f && x.z0trk() + x.z0pek() >= 270f) || (x.z0trk() <= 630f && x.z0trk() + x.z0pek() >= 630f))
		{
			return -1;
		}
		if ((x.z0trk() <= 90f && x.z0trk() + x.z0pek() >= 90f) || (x.z0trk() <= 450f && x.z0trk() + x.z0pek() >= 450f))
		{
			return 1;
		}
		if ((y.z0trk() <= 270f && y.z0trk() + y.z0pek() >= 270f) || (y.z0trk() <= 630f && y.z0trk() + y.z0pek() >= 630f))
		{
			return 1;
		}
		if ((y.z0trk() <= 90f && y.z0trk() + y.z0pek() >= 90f) || (y.z0trk() <= 450f && y.z0trk() + y.z0pek() >= 450f))
		{
			return -1;
		}
		float num = ((!(x.z0trk() > 90f) || !(x.z0trk() + x.z0pek() < 270f)) ? ((x.z0nek() + 90f) % 360f) : (270f - x.z0trk()));
		float num2 = ((!(y.z0trk() >= 90f) || !(x.z0trk() + x.z0pek() < 270f)) ? ((y.z0nek() + 90f) % 360f) : (270f - y.z0trk()));
		if (num > num2)
		{
			return 1;
		}
		if (num == num2)
		{
			return 0;
		}
		return -1;
	}
}
