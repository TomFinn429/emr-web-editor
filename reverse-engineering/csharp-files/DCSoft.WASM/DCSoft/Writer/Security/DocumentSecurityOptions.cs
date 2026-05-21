using System;
using System.ComponentModel;
using System.Text;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Security;

public class DocumentSecurityOptions : ICloneable
{
	private bool z0rek = true;

	private bool z0tek = true;

	private bool z0yek;

	private bool z0uek = true;

	private bool z0iek;

	private string z0oek;

	private DCCAMode z0pek = DCCAMode.Software;

	private bool z0mek = true;

	private static readonly z0ZzZzigh z0nek;

	private z0ZzZzigh z0bek;

	private z0ZzZzigh z0vek;

	private bool z0cek;

	private bool z0xek = true;

	private int z0zek;

	private bool z0lrk;

	private bool z0krk = true;

	private z0ZzZzigh z0jrk;

	private static readonly z0ZzZzigh z0hrk;

	private z0ZzZzigh z0grk;

	private static readonly z0ZzZzigh z0frk;

	private bool z0drk;

	private static readonly z0ZzZzigh z0srk;

	private string z0ark;

	private string z0qrk;

	[DefaultValue(true)]
	public bool AutoEnablePermissionWhenUserLogin
	{
		get
		{
			return z0krk;
		}
		set
		{
			z0krk = value;
		}
	}

	[DefaultValue(null)]
	public string CreatorTipFormatString
	{
		get
		{
			return z0ark;
		}
		set
		{
			z0ark = value;
		}
	}

	[DefaultValue(false)]
	public bool EnablePermission
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

	[DefaultValue(null)]
	public string CAServerIP
	{
		get
		{
			return z0qrk;
		}
		set
		{
			z0qrk = value;
		}
	}

	[DefaultValue(false)]
	public bool ShowPermissionMark
	{
		get
		{
			return z0cek;
		}
		set
		{
			z0cek = value;
		}
	}

	public z0ZzZzigh TrackVisibleLevel3
	{
		get
		{
			return z0grk;
		}
		set
		{
			z0grk = value;
		}
	}

	public static z0ZzZzigh DefaultTrackVisibleLevel0 => z0hrk;

	[DefaultValue(true)]
	public bool ShowFlagForOnlySoftwareSign
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	[DefaultValue(0)]
	public int CAServerPort
	{
		get
		{
			return z0zek;
		}
		set
		{
			z0zek = value;
		}
	}

	[DefaultValue(DCCAMode.Software)]
	public DCCAMode CAMode
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	public static z0ZzZzigh DefaultTrackVisibleLevel3 => z0nek;

	[DefaultValue(true)]
	public bool ShowNewContentMarkForFirstHistory
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

	public z0ZzZzigh TrackVisibleLevel0
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	public z0ZzZzigh TrackVisibleLevel2
	{
		get
		{
			return z0jrk;
		}
		set
		{
			z0jrk = value;
		}
	}

	public z0ZzZzigh TrackVisibleLevel1
	{
		get
		{
			return z0vek;
		}
		set
		{
			z0vek = value;
		}
	}

	public static z0ZzZzigh DefaultTrackVisibleLevel2 => z0srk;

	[DefaultValue(false)]
	public bool ShowLogicDeletedContent
	{
		get
		{
			return z0drk;
		}
		set
		{
			z0drk = value;
		}
	}

	[DefaultValue(false)]
	public bool EnableLogicDelete
	{
		get
		{
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	[DefaultValue(false)]
	public bool RealDeleteOwnerContent
	{
		get
		{
			return z0lrk;
		}
		set
		{
			z0lrk = value;
		}
	}

	[DefaultValue(true)]
	public bool PowerfulSignDocument
	{
		get
		{
			return z0xek;
		}
		set
		{
			z0xek = value;
		}
	}

	public static z0ZzZzigh DefaultTrackVisibleLevel1 => z0frk;

	[DefaultValue(true)]
	public bool ShowPermissionTip
	{
		get
		{
			return z0mek;
		}
		set
		{
			z0mek = value;
		}
	}

	[DefaultValue(true)]
	public bool CanModifyDeleteSameLevelContent
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	[DefaultValue(null)]
	public string DeleterTipFormatString
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	static DocumentSecurityOptions()
	{
		z0hrk = new z0ZzZzigh();
		z0hrk.DeleteLineColor = Color.Coral;
		z0hrk.DeleteLineNum = 1;
		z0hrk.UnderLineColor = Color.LightBlue;
		z0frk = new z0ZzZzigh();
		z0frk.UnderLineColor = Color.Blue;
		z0frk.UnderLineColorNum = 1;
		z0frk.DeleteLineColor = Color.Red;
		z0frk.DeleteLineNum = 1;
		z0srk = new z0ZzZzigh();
		z0srk.UnderLineColor = Color.Blue;
		z0srk.UnderLineColorNum = 2;
		z0srk.DeleteLineColor = Color.Red;
		z0srk.DeleteLineNum = 2;
		z0srk.BackgroundColor = Color.LightYellow;
		z0nek = new z0ZzZzigh();
		z0nek.UnderLineColor = Color.Blue;
		z0nek.UnderLineColorNum = 2;
		z0nek.DeleteLineColor = Color.Red;
		z0nek.DeleteLineNum = 2;
		z0nek.BackgroundColor = Color.Yellow;
	}

	public DocumentSecurityOptions()
	{
		z0bek = DefaultTrackVisibleLevel0.z0eek();
		z0vek = DefaultTrackVisibleLevel1.z0eek();
		z0jrk = DefaultTrackVisibleLevel2.z0eek();
		z0grk = DefaultTrackVisibleLevel2.z0eek();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (EnablePermission)
		{
			stringBuilder.Append("Enable ");
		}
		if (EnableLogicDelete)
		{
			stringBuilder.Append("LogicDelete ");
		}
		if (ShowLogicDeletedContent)
		{
			stringBuilder.Append("ShowLogicDeleted ");
		}
		if (ShowPermissionMark)
		{
			stringBuilder.Append("ShowMark ");
		}
		if (ShowPermissionTip)
		{
			stringBuilder.Append("ShowTip ");
		}
		if (RealDeleteOwnerContent)
		{
			stringBuilder.Append("RealDeleteOwnerContent ");
		}
		return stringBuilder.ToString();
	}

	private object z0eek()
	{
		DocumentSecurityOptions documentSecurityOptions = (DocumentSecurityOptions)MemberwiseClone();
		if (z0bek != null)
		{
			documentSecurityOptions.z0bek = z0bek.z0eek();
		}
		if (z0vek != null)
		{
			documentSecurityOptions.z0vek = z0vek.z0eek();
		}
		if (z0jrk != null)
		{
			documentSecurityOptions.z0jrk = z0jrk.z0eek();
		}
		if (z0grk != null)
		{
			documentSecurityOptions.z0grk = z0grk.z0eek();
		}
		return documentSecurityOptions;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}

	public DocumentSecurityOptions Clone()
	{
		return (DocumentSecurityOptions)((ICloneable)this).Clone();
	}

	public z0ZzZzigh GetTrackVisibleConfig(int level)
	{
		bool flag = z0ZzZzxcj.z0eek(133);
		if (level <= 0)
		{
			if (flag)
			{
				return TrackVisibleLevel0;
			}
			return DefaultTrackVisibleLevel0;
		}
		if (level == 1)
		{
			if (flag)
			{
				return TrackVisibleLevel1;
			}
			return DefaultTrackVisibleLevel1;
		}
		if (level == 2)
		{
			if (flag)
			{
				return TrackVisibleLevel2;
			}
			return DefaultTrackVisibleLevel2;
		}
		if (level >= 3)
		{
			if (flag)
			{
				return TrackVisibleLevel3;
			}
			return DefaultTrackVisibleLevel3;
		}
		return null;
	}
}
