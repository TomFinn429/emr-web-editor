using System.Text;

namespace zzz;

internal sealed class z0ZzZzeij
{
	private int z0nek;

	private int z0bek;

	private z0ZzZzbuj z0vek;

	private int z0cek;

	private int z0xek;

	private int z0lrk;

	private int z0krk;

	private z0ZzZzhij z0jrk;

	private z0ZzZzgij z0hrk;

	private int z0grk;

	public void z0eek(int p0)
	{
		z0lrk = p0;
	}

	public z0ZzZzhij z0eek()
	{
		return z0jrk;
	}

	public z0ZzZzeij()
	{
		z0hrk = null;
		z0jrk = null;
		z0lrk = -1;
		z0xek = -1;
		z0bek = -1;
		z0grk = -1;
		z0nek = -1;
		z0krk = -1;
		z0cek = -1;
		z0vek = null;
	}

	public static bool z0rek(int p0)
	{
		if (p0 >= 0)
		{
			return p0 < 8;
		}
		return false;
	}

	public void z0tek(int p0)
	{
		z0grk = p0;
	}

	public int z0rek()
	{
		return z0lrk;
	}

	public z0ZzZzbuj z0tek()
	{
		return z0vek;
	}

	public void z0yek(int p0)
	{
		z0krk = p0;
	}

	public void z0eek(z0ZzZzgij p0)
	{
		z0hrk = p0;
	}

	public int z0yek()
	{
		return z0grk;
	}

	public void z0uek(int p0)
	{
		z0cek = p0;
	}

	public void z0eek(z0ZzZzbuj p0)
	{
		z0vek = p0;
	}

	public int z0uek()
	{
		return z0cek;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(200);
		stringBuilder.Append("<<\n");
		stringBuilder.Append(" mode: ");
		stringBuilder.Append(z0hrk);
		stringBuilder.Append("\n ecLevel: ");
		stringBuilder.Append(z0jrk);
		stringBuilder.Append("\n version: ");
		stringBuilder.Append(z0lrk);
		stringBuilder.Append("\n matrixWidth: ");
		stringBuilder.Append(z0xek);
		stringBuilder.Append("\n maskPattern: ");
		stringBuilder.Append(z0bek);
		stringBuilder.Append("\n numTotalBytes: ");
		stringBuilder.Append(z0grk);
		stringBuilder.Append("\n numDataBytes: ");
		stringBuilder.Append(z0nek);
		stringBuilder.Append("\n numECBytes: ");
		stringBuilder.Append(z0krk);
		stringBuilder.Append("\n numRSBlocks: ");
		stringBuilder.Append(z0cek);
		if (z0vek == null)
		{
			stringBuilder.Append("\n matrix: null\n");
		}
		else
		{
			stringBuilder.Append("\n matrix:\n");
			stringBuilder.Append(z0vek.ToString());
		}
		stringBuilder.Append(">>\n");
		return stringBuilder.ToString();
	}

	public void z0eek(z0ZzZzhij p0)
	{
		z0jrk = p0;
	}

	public bool z0iek()
	{
		if (z0hrk != null && z0jrk != null && z0lrk != -1 && z0xek != -1 && z0bek != -1 && z0grk != -1 && z0nek != -1 && z0krk != -1 && z0cek != -1 && z0rek(z0bek) && z0grk == z0nek + z0krk && z0vek != null && z0xek == z0vek.z0tek())
		{
			return z0vek.z0tek() == z0vek.z0rek();
		}
		return false;
	}

	public void z0iek(int p0)
	{
		z0bek = p0;
	}

	public int z0oek()
	{
		return z0nek;
	}

	public void z0oek(int p0)
	{
		z0nek = p0;
	}

	public void z0pek(int p0)
	{
		z0xek = p0;
	}

	public int z0pek()
	{
		return z0xek;
	}

	public int z0mek()
	{
		return z0bek;
	}
}
