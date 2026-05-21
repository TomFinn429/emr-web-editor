using DCSoft.Writer.HtmlForms;

namespace zzz;

internal class z0ZzZzijh
{
	private DCFormElementList z0tek = new DCFormElementList();

	public void z0eek(DCFormElementList p0)
	{
		z0tek = p0;
	}

	public z0ZzZzijh z0eek()
	{
		z0ZzZzijh z0ZzZzijh2 = new z0ZzZzijh();
		if (z0tek != null)
		{
			z0ZzZzijh2.z0tek = new DCFormElementList();
			foreach (DCFormElement item in z0tek)
			{
				z0ZzZzijh2.z0tek.Add(item.z0bq(p0: true));
			}
		}
		return z0ZzZzijh2;
	}

	public DCFormElementList z0rek()
	{
		if (z0tek == null)
		{
			z0tek = new DCFormElementList();
		}
		return z0tek;
	}
}
