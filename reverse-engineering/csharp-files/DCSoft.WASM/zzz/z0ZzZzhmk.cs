namespace zzz;

public class z0ZzZzhmk
{
	private float z0tek;

	private float z0yek;

	private float z0uek;

	private float z0iek;

	public void z0eek(z0ZzZzbdh p0)
	{
		if (z0iek == 0f && z0yek == 0f)
		{
			z0uek = p0.z0oek();
			z0tek = p0.z0pek();
			z0iek = p0.z0uek();
			z0yek = p0.z0iek();
			return;
		}
		float num = ((z0uek <= p0.z0oek()) ? z0uek : p0.z0oek());
		float num2 = ((z0uek + z0iek >= p0.z0mek()) ? (z0uek + z0iek) : p0.z0mek());
		z0uek = num;
		z0iek = num2 - num;
		num = ((z0tek <= p0.z0pek()) ? z0tek : p0.z0pek());
		num2 = ((z0tek + z0yek >= p0.z0nek()) ? (z0tek + z0yek) : p0.z0nek());
		z0tek = num;
		z0yek = num2 - num;
	}

	public z0ZzZzbdh z0eek()
	{
		return new z0ZzZzbdh(z0uek, z0tek, z0iek, z0yek);
	}

	public bool z0rek()
	{
		if (z0iek == 0f)
		{
			return z0yek == 0f;
		}
		return false;
	}

	public void z0eek(float p0, float p1, float p2, float p3)
	{
		if (z0iek == 0f && z0yek == 0f)
		{
			z0uek = p0;
			z0tek = p1;
			z0iek = p2;
			z0yek = p3;
			return;
		}
		float num = ((z0uek < p0) ? z0uek : p0);
		float num2 = ((z0uek + z0iek > p0 + p2) ? (z0uek + z0iek) : (p0 + p2));
		z0uek = num;
		z0iek = num2 - num;
		num = ((z0tek < p1) ? z0tek : p1);
		num2 = ((z0tek + z0yek > p1 + p3) ? (z0tek + z0yek) : (p1 + p3));
		z0tek = num;
		z0yek = num2 - num;
	}
}
