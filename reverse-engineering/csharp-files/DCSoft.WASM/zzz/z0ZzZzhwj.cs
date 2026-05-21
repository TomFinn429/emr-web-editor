using System.Text;

namespace zzz;

internal class z0ZzZzhwj : z0ZzZzlgj
{
	private readonly string z0rek;

	private void z0eek(z0ZzZzpgj p0, int p1)
	{
		z0eek(p0);
	}

	void z0ZzZzlgj.z0nfk(z0ZzZzpgj p0, int p1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		this.z0eek(p0, p1);
	}

	internal z0ZzZzhwj(string p0)
	{
		z0rek = p0;
	}

	internal void z0eek(z0ZzZzpgj p0)
	{
		p0.z0eek((byte)47);
		string text = z0rek;
		foreach (char c in text)
		{
			if ((byte)c != c)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(z0rek);
				foreach (byte p1 in bytes)
				{
					z0eek(p0, (char)p1);
				}
				return;
			}
		}
		text = z0rek;
		foreach (char p2 in text)
		{
			z0eek(p0, p2);
		}
	}

	private static void z0eek(z0ZzZzpgj p0, char p1)
	{
		if (char.IsLetterOrDigit(p1) && p1 != '#' && p1 > '!' && p1 < '~')
		{
			p0.z0eek((byte)p1);
		}
		else
		{
			p0.z0eek($"#{(byte)p1:X2}");
		}
	}

	internal string z0eek()
	{
		return z0rek;
	}
}
