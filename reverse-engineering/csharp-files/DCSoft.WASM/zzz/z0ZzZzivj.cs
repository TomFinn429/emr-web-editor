using System;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;

namespace zzz;

public class z0ZzZzivj
{
	public delegate string z0ank(z0ZzZzyhh deleterInfo, z0ZzZzyhh creatorInfo);

	private string z0tek;

	public static bool z0yek = true;

	public static z0ank z0uek = null;

	public virtual bool z0eek(XTextDocument p0, int p1, int p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		DocumentSecurityOptions documentSecurityOptions = p0.z0hi();
		z0eek(null);
		if (documentSecurityOptions.EnablePermission)
		{
			if (p1 >= 0 && !(p0.z0syk().z0iek() == p0.z0syk().z0rek(p1)))
			{
				int num = p0.z0syk().z0eek(p1);
				int num2 = p0.z0syk().z0oek();
				if (num2 == num && !documentSecurityOptions.CanModifyDeleteSameLevelContent)
				{
					if (z0yek)
					{
						if (z0uek != null)
						{
							z0eek(z0uek(p0.z0syk().z0eek(), p0.z0syk().z0tek(p1)));
						}
						if (string.IsNullOrEmpty(z0eek()))
						{
							z0eek(z0ZzZziok.z0mok());
						}
					}
					return false;
				}
				if (num2 < num)
				{
					if (z0yek)
					{
						if (z0uek != null)
						{
							z0eek(z0uek(p0.z0syk().z0eek(), p0.z0syk().z0tek(p1)));
						}
						if (string.IsNullOrEmpty(z0eek()))
						{
							z0eek(string.Format(z0ZzZziok.z0mik(), num2, num));
						}
					}
					return false;
				}
			}
			if (p2 >= 0)
			{
				if (documentSecurityOptions.EnableLogicDelete)
				{
					z0eek(z0ZzZziok.z0eyk());
					return false;
				}
				int num3 = p0.z0syk().z0eek(p2);
				int num4 = p0.z0syk().z0oek();
				if (num4 == num3 && !documentSecurityOptions.CanModifyDeleteSameLevelContent && p0.z0syk().z0iek() != p0.z0syk().z0rek(p1))
				{
					if (z0yek)
					{
						if (z0uek != null)
						{
							z0eek(z0uek(p0.z0syk().z0eek(), p0.z0syk().z0tek(p2)));
						}
						if (string.IsNullOrEmpty(z0eek()))
						{
							z0eek(z0ZzZziok.z0mok());
						}
					}
					return false;
				}
				if (num4 < num3)
				{
					if (z0yek)
					{
						if (z0uek != null)
						{
							z0eek(z0uek(p0.z0syk().z0eek(), p0.z0syk().z0tek(p2)));
						}
						if (string.IsNullOrEmpty(z0eek()))
						{
							z0eek(string.Format(z0ZzZziok.z0mik(), num4, num3));
						}
					}
					return false;
				}
			}
		}
		return true;
	}

	public string z0eek()
	{
		return z0tek;
	}

	public virtual bool z0rek(XTextDocument p0, int p1, int p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		if (p0.z0hi().EnablePermission)
		{
			if (p2 >= 0)
			{
				return false;
			}
			if (p1 >= 0)
			{
				if (p0.z0syk().z0iek() == p0.z0syk().z0rek(p1))
				{
					return true;
				}
				int num = p0.z0syk().z0eek(p1);
				int num2 = p0.z0syk().z0oek();
				if (num2 == num && !p0.z0hi().CanModifyDeleteSameLevelContent)
				{
					if (z0yek)
					{
						if (z0uek != null)
						{
							z0eek(z0uek(p0.z0syk().z0eek(), p0.z0syk().z0tek(p1)));
						}
						if (string.IsNullOrEmpty(z0eek()))
						{
							z0eek(z0ZzZziok.z0mok());
						}
					}
					return false;
				}
				if (num2 < num)
				{
					if (z0yek)
					{
						if (z0uek != null)
						{
							z0eek(z0uek(p0.z0syk().z0eek(), p0.z0syk().z0tek(p1)));
						}
						if (string.IsNullOrEmpty(z0eek()))
						{
							z0eek(string.Format(z0ZzZziok.z0mik(), num2, num));
						}
					}
					return false;
				}
			}
		}
		return true;
	}

	public void z0eek(string p0)
	{
		z0tek = p0;
	}
}
