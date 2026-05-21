using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

public class DocumentContentStyle : z0ZzZzcok
{
	private new static readonly z0ZzZzcik z0bek = z0ZzZzcik.z0eek(34, "GridLineOffsetY", typeof(float), typeof(DocumentContentStyle), 0f);

	private static readonly z0ZzZzcik z0vek = z0ZzZzcik.z0eek(33, "GridLineColor", typeof(Color), typeof(DocumentContentStyle), Color.Black);

	[NonSerialized]
	private Hashtable z0cek;

	[NonSerialized]
	internal z0ZzZzrzj z0xek;

	[NonSerialized]
	[z0ZzZzuqh]
	public float z0zek = -1f;

	private static readonly z0ZzZzcik z0lrk = z0ZzZzcik.z0eek(77, "TitleLevel", typeof(int), typeof(DocumentContentStyle), -1);

	private static readonly z0ZzZzcik z0krk = z0ZzZzcik.z0eek(26, "Cursor", typeof(string), typeof(DocumentContentStyle), null);

	private static readonly z0ZzZzcik z0jrk = z0ZzZzcik.z0eek(40, "LayoutDirection", typeof(ContentLayoutDirectionStyle), typeof(DocumentContentStyle), ContentLayoutDirectionStyle.Default);

	[NonSerialized]
	private float z0hrk = 100f;

	[NonSerialized]
	[z0ZzZzuqh]
	public bool z0grk;

	private static readonly z0ZzZzcik z0frk = z0ZzZzcik.z0eek(73, "SpecifyGridLineStep", typeof(float), typeof(DocumentContentStyle), 0f);

	private static readonly z0ZzZzcik z0drk = z0ZzZzcik.z0eek(27, "DeleterIndex", typeof(int), typeof(DocumentContentStyle), -1);

	private static readonly z0ZzZzcik z0srk = z0ZzZzcik.z0eek(35, "GridLineStyle", typeof(DashStyle), typeof(DocumentContentStyle), DashStyle.Solid);

	private static readonly z0ZzZzcik z0ark = z0ZzZzcik.z0eek(63, "PrintBackColor", typeof(Color), typeof(DocumentContentStyle), Color.Empty);

	private static readonly z0ZzZzcik z0qrk = z0ZzZzcik.z0eek(25, "CreatorIndex", typeof(int), typeof(DocumentContentStyle), -1);

	[NonSerialized]
	private float z0wrk;

	private float z0erk;

	private static readonly z0ZzZzcik z0rrk = z0ZzZzcik.z0eek(64, "PrintColor", typeof(Color), typeof(DocumentContentStyle), Color.Transparent);

	private static readonly z0ZzZzcik z0trk = z0ZzZzcik.z0eek(36, "GridLineType", typeof(ContentGridLineType), typeof(DocumentContentStyle), ContentGridLineType.None);

	[NonSerialized]
	[z0ZzZzuqh]
	public float z0yrk = -1f;

	private static readonly z0ZzZzcik z0urk = z0ZzZzcik.z0eek(24, "CommentIndex", typeof(int), typeof(DocumentContentStyle), -1);

	private static readonly string z0irk = "____";

	private static readonly z0ZzZzcik z0ork = z0ZzZzcik.z0eek(65, "ProtectType", typeof(ContentProtectType), typeof(DocumentContentStyle), ContentProtectType.None);

	[z0ZzZzyqh]
	[DefaultValue(0f)]
	public float SpecifyGridLineStep
	{
		get
		{
			return (float)z0eek(z0frk);
		}
		set
		{
			z0eek(z0frk, value);
		}
	}

	[DefaultValue(-1)]
	public int TitleLevel
	{
		get
		{
			return (int)z0eek(z0lrk);
		}
		set
		{
			z0eek(z0lrk, value);
		}
	}

	[DefaultValue(ContentGridLineType.None)]
	[z0ZzZzyqh]
	public ContentGridLineType GridLineType
	{
		get
		{
			return (ContentGridLineType)z0eek(z0trk);
		}
		set
		{
			z0eek(z0trk, value);
		}
	}

	[z0ZzZzuqh]
	public Hashtable Tags
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

	[DefaultValue(-1)]
	public int CommentIndex
	{
		get
		{
			return (int)z0eek(z0urk);
		}
		set
		{
			z0eek(z0urk, value);
		}
	}

	[z0ZzZzyqh("PrintColor")]
	[DefaultValue(null)]
	public string PrintColorString
	{
		get
		{
			return z0ZzZzlok.z0eek(PrintColor, Color.Transparent);
		}
		set
		{
			PrintColor = z0ZzZzlok.z0eek(value, Color.Transparent);
		}
	}

	[DefaultValue(-1)]
	public int CreatorIndex
	{
		get
		{
			return (int)z0eek(z0qrk);
		}
		set
		{
			z0eek(z0qrk, value);
		}
	}

	[DefaultValue(null)]
	public string Cursor
	{
		get
		{
			return (string)z0eek(z0krk);
		}
		set
		{
			z0eek(z0krk, value);
		}
	}

	[z0ZzZzuqh]
	public Color PrintColor
	{
		get
		{
			return (Color)z0eek(z0rrk);
		}
		set
		{
			z0eek(z0rrk, value);
		}
	}

	public float TabWidth => z0hrk;

	[DefaultValue(-1)]
	public int DeleterIndex
	{
		get
		{
			return (int)z0eek(z0drk);
		}
		set
		{
			z0eek(z0drk, value);
		}
	}

	public bool HasTitleLevel
	{
		get
		{
			if (base.z0bek.ContainsKey(z0lrk))
			{
				return (int)z0eek(z0lrk) >= 0;
			}
			return false;
		}
	}

	[z0ZzZzyqh("GridLineColor")]
	[DefaultValue(null)]
	public string GridLineColorString
	{
		get
		{
			return z0ZzZzlok.z0eek(GridLineColor, Color.Black);
		}
		set
		{
			GridLineColor = z0ZzZzlok.z0eek(value, Color.Black);
		}
	}

	[DefaultValue(null)]
	[z0ZzZzyqh("PrintBackColor")]
	public string PrintBackColorString
	{
		get
		{
			return z0ZzZzlok.z0eek(PrintBackColor, Color.Empty);
		}
		set
		{
			PrintBackColor = z0ZzZzlok.z0eek(value, Color.Empty);
		}
	}

	[z0ZzZzuqh]
	public Color PrintBackColor
	{
		get
		{
			return (Color)z0eek(z0ark);
		}
		set
		{
			z0eek(z0ark, value);
		}
	}

	[DefaultValue(0f)]
	[z0ZzZzyqh]
	public float GridLineOffsetY
	{
		get
		{
			return (float)z0eek(z0bek);
		}
		set
		{
			z0eek(z0bek, value);
		}
	}

	[z0ZzZzuqh]
	public Color GridLineColor
	{
		get
		{
			return (Color)z0eek(z0vek);
		}
		set
		{
			z0eek(z0vek, value);
		}
	}

	[DefaultValue(ContentLayoutDirectionStyle.Default)]
	public ContentLayoutDirectionStyle LayoutDirection
	{
		get
		{
			return (ContentLayoutDirectionStyle)z0eek(z0jrk);
		}
		set
		{
			z0eek(z0jrk, value);
		}
	}

	[DefaultValue(DashStyle.Solid)]
	[z0ZzZzyqh]
	public DashStyle GridLineStyle
	{
		get
		{
			return (DashStyle)z0eek(z0srk);
		}
		set
		{
			z0eek(z0srk, value);
		}
	}

	[DefaultValue(ContentProtectType.None)]
	public ContentProtectType ProtectType
	{
		get
		{
			return (ContentProtectType)z0eek(z0ork);
		}
		set
		{
			z0eek(z0ork, value);
		}
	}

	public z0ZzZzrzj z0eek_jiejie20260327142557()
	{
		if (z0xek == null)
		{
			z0eek_jiejie20260327142557(new z0ZzZzrzj(this));
		}
		return z0xek;
	}

	public override z0ZzZzcok Clone()
	{
		DocumentContentStyle documentContentStyle = new DocumentContentStyle();
		foreach (KeyValuePair<z0ZzZzcik, object> item in base.z0bek)
		{
			((z0ZzZzvik)documentContentStyle).z0bek.Add(item.Key, item.Value);
		}
		((z0ZzZzvik)documentContentStyle).z0mek = true;
		return documentContentStyle;
	}

	protected override bool z0cn()
	{
		return XTextElementList.z0qrk;
	}

	internal new void z0rek()
	{
		base.z0bek.Remove(z0qrk);
	}

	internal new void z0tek()
	{
		base.z0bek.Remove(z0drk);
	}

	public new Color z0yek()
	{
		Color printColor = PrintColor;
		if (printColor.A == 0)
		{
			return base.Color;
		}
		return printColor;
	}

	internal new DocumentContentStyle z0uek()
	{
		DocumentContentStyle obj = (DocumentContentStyle)Clone();
		obj.BorderLeft = false;
		obj.BorderTop = false;
		obj.BorderRight = false;
		obj.BorderBottom = false;
		return obj;
	}

	public new float z0iek()
	{
		return z0erk;
	}

	public new static void z0oek()
	{
	}

	internal bool z0pek()
	{
		if (!base.z0bek.Remove(z0qrk))
		{
			return base.z0bek.Remove(z0drk);
		}
		return true;
	}

	internal void z0eek_jiejie20260327142557(z0ZzZzrzj p0)
	{
		if (z0xek != p0)
		{
			_ = z0xek;
		}
		z0xek = p0;
	}

	public new float z0mek()
	{
		return z0wrk;
	}

	protected override void z0vn(z0ZzZzcik p0)
	{
		z0eek_jiejie20260327142557((z0ZzZzrzj)null);
	}

	public override void Dispose()
	{
		base.Dispose();
		z0eek_jiejie20260327142557((z0ZzZzrzj)null);
	}

	internal Dictionary<z0ZzZzcik, object> z0nek()
	{
		return base.z0bek;
	}

	public void z0eek_jiejie20260327142557(z0ZzZzjpk p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("g");
		}
		z0ZzZzimk z0ZzZzimk = null;
		z0ZzZzimk = z0eek_jiejie20260327142557().z0pek;
		z0ZzZzxdh z0ZzZzxdh = z0ZzZzlcj.z0rek(p0, z0irk, z0ZzZzimk, 1000, z0ZzZzlsh.z0uek());
		z0erk = p0.z0eek(z0ZzZzimk);
		if (z0xek != null)
		{
			z0xek.z0rek(z0erk);
		}
		z0hrk = (int)Math.Ceiling(z0ZzZzxdh.z0rek());
		z0wrk = z0erk + 4f;
		float num = z0erk + 4f;
		_ = z0wrk;
	}

	public bool z0eek_jiejie20260327142557(string p0)
	{
		foreach (z0ZzZzcik key in z0yek().Keys)
		{
			if (string.Compare(key.z0yek(), p0, true) == 0)
			{
				z0yek().Remove(key);
				base.z0mek = true;
				return true;
			}
		}
		z0ZzZzcik[] array = z0ZzZzcik.z0eek(GetType(), p1: false);
		for (int i = 0; i < array.Length; i++)
		{
			if (string.Compare(array[i].z0yek(), p0, true) == 0)
			{
				return false;
			}
		}
		throw new ArgumentOutOfRangeException(p0);
	}
}
