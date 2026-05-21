using System;
using System.Collections.Generic;
using System.Globalization;
using DCSystem_Drawing;

namespace zzz;

public static class z0ZzZzifh
{
	private static Dictionary<string, uint> z0rek;

	public static string z0eek(Color p0)
	{
		switch (p0._value)
		{
		case 0u:
			return "none";
		case 16777215u:
			return "Transparent";
		case 4278190080u:
			return "Black";
		case 4278190208u:
			return "Navy";
		case 4278190219u:
			return "DarkBlue";
		case 4278190285u:
			return "MediumBlue";
		case 4278190335u:
			return "Blue";
		case 4278215680u:
			return "DarkGreen";
		case 4278216396u:
			return "highlight";
		case 4278221015u:
			return "highlight";
		case 4278222848u:
			return "Green";
		case 4278222976u:
			return "Teal";
		case 4278225803u:
			return "DarkCyan";
		case 4278239231u:
			return "DeepSkyBlue";
		case 4278243025u:
			return "DarkTurquoise";
		case 4278254234u:
			return "MediumSpringGreen";
		case 4278255360u:
			return "Lime";
		case 4278255487u:
			return "SpringGreen";
		case 4278255615u:
			return "Cyan";
		case 4279834992u:
			return "MidnightBlue";
		case 4280193279u:
			return "DodgerBlue";
		case 4280332970u:
			return "LightSeaGreen";
		case 4280453922u:
			return "ForestGreen";
		case 4281240407u:
			return "SeaGreen";
		case 4281290575u:
			return "DarkSlateGray";
		case 4281519410u:
			return "LimeGreen";
		case 4282168177u:
			return "MediumSeaGreen";
		case 4282441936u:
			return "Turquoise";
		case 4282477025u:
			return "RoyalBlue";
		case 4282811060u:
			return "SteelBlue";
		case 4282924427u:
			return "DarkSlateBlue";
		case 4282962380u:
			return "MediumTurquoise";
		case 4283105410u:
			return "Indigo";
		case 4283788079u:
			return "DarkOliveGreen";
		case 4284456608u:
			return "CadetBlue";
		case 4284769380u:
			return "windowframe";
		case 4284782061u:
			return "CornflowerBlue";
		case 4284927402u:
			return "MediumAquamarine";
		case 4285098345u:
			return "DimGray";
		case 4285160141u:
			return "SlateBlue";
		case 4285238819u:
			return "OliveDrab";
		case 4285361517u:
			return "graytext";
		case 4285563024u:
			return "SlateGray";
		case 4286023833u:
			return "LightSlateGray";
		case 4286277870u:
			return "MediumSlateBlue";
		case 4286381056u:
			return "LawnGreen";
		case 4286578432u:
			return "Chartreuse";
		case 4286578644u:
			return "Aquamarine";
		case 4286578688u:
			return "Maroon";
		case 4286578816u:
			return "Purple";
		case 4286611456u:
			return "Olive";
		case 4286611584u:
			return "Gray";
		case 4287090411u:
			return "SkyBlue";
		case 4287090426u:
			return "LightSkyBlue";
		case 4287245282u:
			return "BlueViolet";
		case 4287299584u:
			return "DarkRed";
		case 4287299723u:
			return "DarkMagenta";
		case 4287317267u:
			return "SaddleBrown";
		case 4287609995u:
			return "DarkSeaGreen";
		case 4287688336u:
			return "LightGreen";
		case 4287852763u:
			return "MediumPurple";
		case 4287889619u:
			return "DarkViolet";
		case 4288215960u:
			return "PaleGreen";
		case 4288230092u:
			return "DarkOrchid";
		case 4288263377u:
			return "activecaption";
		case 4288335154u:
			return "YellowGreen";
		case 4288696877u:
			return "Sienna";
		case 4289014314u:
			return "Brown";
		case 4289309097u:
			return "DarkGray";
		case 4289440683u:
			return "appworkspace";
		case 4289583334u:
			return "LightBlue";
		case 4289593135u:
			return "GreenYellow";
		case 4289720046u:
			return "PaleTurquoise";
		case 4289774814u:
			return "LightSteelBlue";
		case 4289781990u:
			return "PowderBlue";
		case 4289864226u:
			return "Firebrick";
		case 4290032820u:
			return "activeborder";
		case 4290283019u:
			return "DarkGoldenrod";
		case 4290367978u:
			return "activecaption";
		case 4290401747u:
			return "MediumOrchid";
		case 4290547599u:
			return "RosyBrown";
		case 4290623339u:
			return "DarkKhaki";
		case 4290760155u:
			return "inactivecaption";
		case 4290822336u:
			return "Silver";
		case 4291237253u:
			return "MediumVioletRed";
		case 4291348680u:
			return "scrollbar";
		case 4291648604u:
			return "IndianRed";
		case 4291659071u:
			return "Peru";
		case 4291979550u:
			return "Chocolate";
		case 4291998860u:
			return "Tan";
		case 4292072403u:
			return "LightGrey";
		case 4292338930u:
			return "inactivecaption";
		case 4292394968u:
			return "Thistle";
		case 4292505814u:
			return "Orchid";
		case 4292519200u:
			return "Goldenrod";
		case 4292571283u:
			return "PaleVioletRed";
		case 4292613180u:
			return "Crimson";
		case 4292664540u:
			return "Gainsboro";
		case 4292714717u:
			return "Plum";
		case 4292786311u:
			return "BurlyWood";
		case 4292935679u:
			return "LightCyan";
		case 4293125091u:
			return "buttonface";
		case 4293322490u:
			return "Lavender";
		case 4293498490u:
			return "DarkSalmon";
		case 4293821166u:
			return "Violet";
		case 4293847210u:
			return "PaleGoldenrod";
		case 4293951616u:
			return "LightCoral";
		case 4293977740u:
			return "Khaki";
		case 4293982463u:
			return "AliceBlue";
		case 4293984240u:
			return "Honeydew";
		case 4293984255u:
			return "Azure";
		case 4294222944u:
			return "SandyBrown";
		case 4294244348u:
			return "inactiveborder";
		case 4294303411u:
			return "Wheat";
		case 4294309340u:
			return "Beige";
		case 4294309365u:
			return "WhiteSmoke";
		case 4294311930u:
			return "MintCream";
		case 4294506751u:
			return "GhostWhite";
		case 4294606962u:
			return "Salmon";
		case 4294634455u:
			return "AntiqueWhite";
		case 4294635750u:
			return "Linen";
		case 4294638290u:
			return "LightGoldenrodYellow";
		case 4294833638u:
			return "OldLace";
		case 4294901760u:
			return "Red";
		case 4294902015u:
			return "Magenta";
		case 4294907027u:
			return "DeepPink";
		case 4294919424u:
			return "OrangeRed";
		case 4294927175u:
			return "Tomato";
		case 4294928820u:
			return "HotPink";
		case 4294934352u:
			return "Coral";
		case 4294937600u:
			return "DarkOrange";
		case 4294942842u:
			return "LightSalmon";
		case 4294944000u:
			return "Orange";
		case 4294948545u:
			return "LightPink";
		case 4294951115u:
			return "Pink";
		case 4294956800u:
			return "Gold";
		case 4294957753u:
			return "PeachPuff";
		case 4294958765u:
			return "NavajoWhite";
		case 4294960309u:
			return "Moccasin";
		case 4294960324u:
			return "Bisque";
		case 4294960353u:
			return "MistyRose";
		case 4294962125u:
			return "BlanchedAlmond";
		case 4294963157u:
			return "PapayaWhip";
		case 4294963445u:
			return "LavenderBlush";
		case 4294964718u:
			return "SeaShell";
		case 4294965468u:
			return "Cornsilk";
		case 4294965965u:
			return "LemonChiffon";
		case 4294966000u:
			return "FloralWhite";
		case 4294966010u:
			return "Snow";
		case 4294967040u:
			return "Yellow";
		case 4294967264u:
			return "LightYellow";
		case 4294967265u:
			return "infobackground";
		case 4294967280u:
			return "Ivory";
		case 4294967295u:
			return "White";
		default:
			if (p0.A != 255)
			{
				return "rgba(" + p0.R + "," + p0.G + "," + p0.B + "," + ((double)(int)p0.A / 255.0).ToString("0.0000") + ")";
			}
			return $"#{p0.R:X2}{p0.G:X2}{p0.B:X2}";
		}
	}

	public static Color z0eek(string p0)
	{
		if (z0eek(p0, out var p1))
		{
			return p1;
		}
		throw new ArgumentException("Bad color[" + p0 + "]");
	}

	public static bool z0eek(string p0, out Color p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			p1 = Color.Empty;
			return true;
		}
		p0 = p0.Trim();
		if (p0[0] == '#' && (p0.Length == 7 || p0.Length == 4))
		{
			if (p0.Length == 7)
			{
				p1 = Color.FromArgb(Convert.ToInt32(p0.Substring(1, 2), 16), Convert.ToInt32(p0.Substring(3, 2), 16), Convert.ToInt32(p0.Substring(5, 2), 16));
			}
			else
			{
				string text = char.ToString(p0[1]);
				string text2 = char.ToString(p0[2]);
				string text3 = char.ToString(p0[3]);
				p1 = Color.FromArgb(Convert.ToInt32(text + text, 16), Convert.ToInt32(text2 + text2, 16), Convert.ToInt32(text3 + text3, 16));
			}
			return true;
		}
		if (p0.Length > 10)
		{
			if (p0.StartsWith("rgb(", StringComparison.OrdinalIgnoreCase) && p0[p0.Length - 1] == ')')
			{
				p0 = p0.Substring(4, p0.Length - 5);
				string[] array = p0.Split(',');
				if (array.Length == 3)
				{
					int red = 0;
					int green = 0;
					int blue = 0;
					if (int.TryParse(array[0], out red) && int.TryParse(array[1], out green) && int.TryParse(array[2], out blue))
					{
						p1 = Color.FromArgb(red, green, blue);
						return true;
					}
				}
			}
			else if (p0.StartsWith("rgba(", StringComparison.CurrentCultureIgnoreCase) && p0[p0.Length - 1] == ')')
			{
				p0 = p0.Substring(5, p0.Length - 6);
				string[] array2 = p0.Split(',');
				int red2 = 0;
				int green2 = 0;
				int blue2 = 0;
				float num = 0f;
				if (array2.Length == 4 && int.TryParse(array2[0], out red2) && int.TryParse(array2[1], out green2) && int.TryParse(array2[2], out blue2) && float.TryParse(array2[3], out num))
				{
					p1 = Color.FromArgb((int)(num * 255f), red2, green2, blue2);
					return true;
				}
			}
		}
		uint v = 0u;
		if (z0rek.TryGetValue(p0.ToLower(), out v))
		{
			p1 = new Color(v);
			return true;
		}
		try
		{
			p1 = z0ZzZzufh.z0eek(p0, CultureInfo.CurrentCulture);
		}
		catch (Exception)
		{
			p1 = Color.Empty;
			return false;
		}
		return true;
	}

	static z0ZzZzifh()
	{
		z0rek = new Dictionary<string, uint>
		{
			{ "none", 0u },
			{ "activeborder", 4290032820u },
			{ "activecaption", 4290367978u },
			{ "activecaptiontext", 4278190080u },
			{ "aliceblue", 4293982463u },
			{ "antiquewhite", 4294634455u },
			{ "appworkspace", 4289440683u },
			{ "aqua", 4278255615u },
			{ "aquamarine", 4286578644u },
			{ "azure", 4293984255u },
			{ "background", 4278190080u },
			{ "beige", 4294309340u },
			{ "bisque", 4294960324u },
			{ "black", 4278190080u },
			{ "blanchedalmond", 4294962125u },
			{ "blue", 4278190335u },
			{ "blueviolet", 4287245282u },
			{ "brown", 4289014314u },
			{ "burlywood", 4292786311u },
			{ "buttonface", 4293125091u },
			{ "buttonhighlight", 4294967295u },
			{ "buttonshadow", 4288716960u },
			{ "buttontext", 4278190080u },
			{ "cadetblue", 4284456608u },
			{ "captiontext", 4278190080u },
			{ "chartreuse", 4286578432u },
			{ "chocolate", 4291979550u },
			{ "control", 4293980400u },
			{ "controldark", 4288716960u },
			{ "controldarkdark", 4285098345u },
			{ "controllight", 4293125091u },
			{ "controllightlight", 4294967295u },
			{ "controltext", 4278190080u },
			{ "coral", 4294934352u },
			{ "cornflowerblue", 4284782061u },
			{ "cornsilk", 4294965468u },
			{ "crimson", 4292613180u },
			{ "cyan", 4278255615u },
			{ "darkblue", 4278190219u },
			{ "darkcyan", 4278225803u },
			{ "darkgoldenrod", 4290283019u },
			{ "darkgray", 4289309097u },
			{ "darkgreen", 4278215680u },
			{ "darkkhaki", 4290623339u },
			{ "darkmagenta", 4287299723u },
			{ "darkolivegreen", 4283788079u },
			{ "darkorange", 4294937600u },
			{ "darkorchid", 4288230092u },
			{ "darkred", 4287299584u },
			{ "darksalmon", 4293498490u },
			{ "darkseagreen", 4287609995u },
			{ "darkslateblue", 4282924427u },
			{ "darkslategray", 4281290575u },
			{ "darkturquoise", 4278243025u },
			{ "darkviolet", 4287889619u },
			{ "deeppink", 4294907027u },
			{ "deepskyblue", 4278239231u },
			{ "desktop", 4278190080u },
			{ "dimgray", 4285098345u },
			{ "dodgerblue", 4280193279u },
			{ "firebrick", 4289864226u },
			{ "floralwhite", 4294966000u },
			{ "forestgreen", 4280453922u },
			{ "fuchsia", 4294902015u },
			{ "gainsboro", 4292664540u },
			{ "ghostwhite", 4294506751u },
			{ "gold", 4294956800u },
			{ "goldenrod", 4292519200u },
			{ "gradientactivecaption", 4290367978u },
			{ "gradientinactivecaption", 4292338930u },
			{ "gray", 4286611584u },
			{ "graytext", 4285361517u },
			{ "green", 4278222848u },
			{ "greenyellow", 4289593135u },
			{ "highlight", 4278216396u },
			{ "highlighttext", 4278221015u },
			{ "honeydew", 4293984240u },
			{ "hotpink", 4294928820u },
			{ "hottrack", 4278216396u },
			{ "inactiveborder", 4294244348u },
			{ "inactivecaption", 4290760155u },
			{ "inactivecaptiontext", 4278190080u },
			{ "indianred", 4291648604u },
			{ "indigo", 4283105410u },
			{ "info", 4294967265u },
			{ "infobackground", 4294967265u },
			{ "infotext", 4278190080u },
			{ "ivory", 4294967280u },
			{ "khaki", 4293977740u },
			{ "lavender", 4293322490u },
			{ "lavenderblush", 4294963445u },
			{ "lawngreen", 4286381056u },
			{ "lemonchiffon", 4294965965u },
			{ "lightblue", 4289583334u },
			{ "lightcoral", 4293951616u },
			{ "lightcyan", 4292935679u },
			{ "lightgoldenrodyellow", 4294638290u },
			{ "lightgray", 4292072403u },
			{ "lightgreen", 4287688336u },
			{ "lightgrey", 4292072403u },
			{ "lightpink", 4294948545u },
			{ "lightsalmon", 4294942842u },
			{ "lightseagreen", 4280332970u },
			{ "lightskyblue", 4287090426u },
			{ "lightslategray", 4286023833u },
			{ "lightsteelblue", 4289774814u },
			{ "lightyellow", 4294967264u },
			{ "lime", 4278255360u },
			{ "limegreen", 4281519410u },
			{ "linen", 4294635750u },
			{ "magenta", 4294902015u },
			{ "maroon", 4286578688u },
			{ "mediumaquamarine", 4284927402u },
			{ "mediumblue", 4278190285u },
			{ "mediumorchid", 4290401747u },
			{ "mediumpurple", 4287852763u },
			{ "mediumseagreen", 4282168177u },
			{ "mediumslateblue", 4286277870u },
			{ "mediumspringgreen", 4278254234u },
			{ "mediumturquoise", 4282962380u },
			{ "mediumvioletred", 4291237253u },
			{ "menu", 4293980400u },
			{ "menubar", 4293980400u },
			{ "menuhighlight", 4278221015u },
			{ "menutext", 4278190080u },
			{ "midnightblue", 4279834992u },
			{ "mintcream", 4294311930u },
			{ "mistyrose", 4294960353u },
			{ "moccasin", 4294960309u },
			{ "navajowhite", 4294958765u },
			{ "navy", 4278190208u },
			{ "oldlace", 4294833638u },
			{ "olive", 4286611456u },
			{ "olivedrab", 4285238819u },
			{ "orange", 4294944000u },
			{ "orangered", 4294919424u },
			{ "orchid", 4292505814u },
			{ "palegoldenrod", 4293847210u },
			{ "palegreen", 4288215960u },
			{ "paleturquoise", 4289720046u },
			{ "palevioletred", 4292571283u },
			{ "papayawhip", 4294963157u },
			{ "peachpuff", 4294957753u },
			{ "peru", 4291659071u },
			{ "pink", 4294951115u },
			{ "plum", 4292714717u },
			{ "powderblue", 4289781990u },
			{ "purple", 4286578816u },
			{ "red", 4294901760u },
			{ "rosybrown", 4290547599u },
			{ "royalblue", 4282477025u },
			{ "saddlebrown", 4287317267u },
			{ "salmon", 4294606962u },
			{ "sandybrown", 4294222944u },
			{ "scrollbar", 4291348680u },
			{ "seagreen", 4281240407u },
			{ "seashell", 4294964718u },
			{ "sienna", 4288696877u },
			{ "silver", 4290822336u },
			{ "skyblue", 4287090411u },
			{ "slateblue", 4285160141u },
			{ "slategray", 4285563024u },
			{ "snow", 4294966010u },
			{ "springgreen", 4278255487u },
			{ "steelblue", 4282811060u },
			{ "tan", 4291998860u },
			{ "teal", 4278222976u },
			{ "thistle", 4292394968u },
			{ "threeddarkshadow", 4285098345u },
			{ "tomato", 4294927175u },
			{ "transparent", 16777215u },
			{ "turquoise", 4282441936u },
			{ "violet", 4293821166u },
			{ "wheat", 4294303411u },
			{ "white", 4294967295u },
			{ "whitesmoke", 4294309365u },
			{ "window", 4294967295u },
			{ "windowframe", 4284769380u },
			{ "windowtext", 4278190080u },
			{ "yellow", 4294967040u },
			{ "yellowgreen", 4288335154u }
		};
	}
}
