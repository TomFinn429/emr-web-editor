using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzupk
{
	public z0ZzZzbdh z0tek = z0ZzZzbdh.z0xek;

	public object z0yek;

	public string z0uek;

	public bool z0iek = true;

	public Color z0oek = Color.Transparent;

	public z0ZzZzsdh z0pek;

	public Color z0mek = Color.Black;

	public Color z0nek = Color.White;

	internal void z0eek()
	{
		z0pek = null;
		z0yek = null;
	}

	public string z0rek()
	{
		if (z0yek == null)
		{
			return null;
		}
		if (z0yek is string)
		{
			return (string)z0yek;
		}
		if (z0yek is z0ZzZzwok)
		{
			return ((z0ZzZzwok)z0yek).z0tek();
		}
		return z0yek.ToString();
	}
}
