using System;
using System.ComponentModel;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh]
public class DCContentLockInfo : z0ZzZzcuk
{
	private string z0rek;

	private string z0tek_jiejie20260327142557;

	private DateTime z0yek = z0ZzZzkfh.z0wrk;

	[DefaultValue(null)]
	public string AuthorisedUserIDList
	{
		get
		{
			return z0tek_jiejie20260327142557;
		}
		set
		{
			z0tek_jiejie20260327142557 = value;
		}
	}

	public DateTime CreationTime
	{
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	public bool IsEmpty
	{
		get
		{
			if (string.IsNullOrEmpty(z0tek_jiejie20260327142557) && z0yek != z0ZzZzkfh.z0wrk)
			{
				return string.IsNullOrEmpty(z0rek);
			}
			return false;
		}
	}

	[DefaultValue(null)]
	public string OwnerUserID
	{
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	public bool CheckAuthorize(string userID)
	{
		if (string.IsNullOrEmpty(OwnerUserID) && string.IsNullOrEmpty(AuthorisedUserIDList))
		{
			return true;
		}
		if (userID == OwnerUserID)
		{
			return true;
		}
		if (string.IsNullOrEmpty(userID))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(AuthorisedUserIDList) && new z0ZzZzzuk(AuthorisedUserIDList).z0tek(userID))
		{
			return true;
		}
		return false;
	}

	public bool CheckCurrentUserAuthorize(XTextDocument document)
	{
		if (document == null)
		{
			throw new ArgumentNullException("documnet");
		}
		if (!document.z0bu().EnableContentLock)
		{
			return true;
		}
		if (document.z0muk() != null)
		{
			return CheckAuthorize(document.z0muk().z0zek());
		}
		return CheckAuthorize(null);
	}

	public void DCReadString(string text)
	{
		z0ZzZzmik.z0eek(this, text);
	}

	public string DCWriteString()
	{
		return z0ZzZzmik.z0rek(this, p1: true);
	}

	public DCContentLockInfo z0eek()
	{
		return (DCContentLockInfo)MemberwiseClone();
	}
}
