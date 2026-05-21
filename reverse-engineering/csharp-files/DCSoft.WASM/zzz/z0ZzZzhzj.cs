using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzhzj
{
	private int z0tek;

	private bool z0yek;

	private readonly z0ZzZzqeh z0uek;

	private int z0iek;

	private readonly int z0oek;

	private readonly int z0pek;

	public void z0eek(int p0)
	{
		z0iek = p0;
	}

	public z0ZzZzhzj(DocumentEventArgs p0)
	{
		z0uek = p0.Button;
		z0pek = p0.X;
		z0oek = p0.Y;
		z0iek = p0.X;
		z0tek = p0.Y;
	}

	public void z0rek(int p0)
	{
		z0tek = p0;
	}

	public void z0eek(bool p0)
	{
		z0yek = p0;
	}

	public bool z0eek()
	{
		return z0yek;
	}
}
