using System.Text;

namespace zzz;

internal class z0ZzZzrdj
{
	private readonly byte[] z0oek;

	private readonly z0ZzZzedj z0pek;

	private readonly z0ZzZzxfj z0mek;

	private readonly string z0nek;

	private readonly z0ZzZzadj z0bek;

	private readonly z0ZzZzudj z0vek;

	internal z0ZzZzudj z0eek()
	{
		return z0vek;
	}

	public override string ToString()
	{
		return z0nek;
	}

	internal z0ZzZzxfj z0rek()
	{
		return z0mek;
	}

	internal string z0tek()
	{
		return z0nek;
	}

	internal z0ZzZzadj z0yek()
	{
		return z0bek;
	}

	internal byte[] z0uek()
	{
		return z0oek;
	}

	internal z0ZzZzedj z0iek()
	{
		return z0pek;
	}

	internal z0ZzZzrdj(z0ZzZzjgj p0, int p1)
	{
		z0vek = (z0ZzZzudj)p0.z0rek();
		z0mek = (z0ZzZzxfj)p0.z0rek();
		z0bek = (z0ZzZzadj)p0.z0rek();
		z0pek = (z0ZzZzedj)p0.z0rek();
		int num = p0.z0rek();
		int num2 = p0.z0rek();
		long num3 = p1 + num2;
		if (num3 + num <= p0.z0mek())
		{
			long p2 = p0.z0uek();
			p0.z0eek(num3);
			z0oek = p0.z0yek(num);
			z0nek = z0ZzZzzfj.z0uek(z0oek, (z0vek == (z0ZzZzudj)3) ? Encoding.BigEndianUnicode : Encoding.UTF8);
			p0.z0eek(p2);
		}
	}
}
