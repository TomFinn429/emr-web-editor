using System.Text;

namespace zzz;

internal class z0ZzZzjwj : z0ZzZzfsj
{
	private new readonly string z0rek;

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		return new z0ZzZzraj(new z0ZzZzeaj(p0)
		{
			{
				"Type",
				new z0ZzZzhwj("Metadata")
			},
			{
				"Subtype",
				new z0ZzZzhwj("XML")
			}
		}, Encoding.UTF8.GetBytes(z0rek));
	}

	internal z0ZzZzjwj(string p0)
	{
		z0rek = p0;
	}
}
