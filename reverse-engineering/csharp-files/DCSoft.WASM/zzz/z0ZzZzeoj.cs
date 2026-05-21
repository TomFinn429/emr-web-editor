using System.Collections.Generic;
using System.Windows.Forms;

namespace zzz;

public static class z0ZzZzeoj
{
	private static readonly Dictionary<string, Keys> z0rek;

	public static Keys z0eek(string p0, string p1)
	{
		if (p0 != null && p0.Length > 0 && z0rek.ContainsKey(p0))
		{
			return z0rek[p0];
		}
		if (p1 != null && p1.Length > 0 && z0rek.ContainsKey(p1))
		{
			return z0rek[p1];
		}
		return Keys.None;
	}

	static z0ZzZzeoj()
	{
		z0rek = new Dictionary<string, Keys>();
		z0rek["Escape"] = Keys.Escape;
		z0rek["Digit1"] = Keys.D1;
		z0rek["Digit2"] = Keys.D2;
		z0rek["Digit3"] = Keys.D3;
		z0rek["Digit4"] = Keys.D4;
		z0rek["Digit5"] = Keys.D5;
		z0rek["Digit6"] = Keys.D6;
		z0rek["Digit7"] = Keys.D7;
		z0rek["Digit8"] = Keys.D8;
		z0rek["Digit9"] = Keys.D9;
		z0rek["Digit0"] = Keys.D0;
		z0rek["Minus"] = Keys.Subtract;
		z0rek["Backspace"] = Keys.Back;
		z0rek["Tab"] = Keys.Tab;
		z0rek["KeyQ"] = Keys.Q;
		z0rek["KeyW"] = Keys.W;
		z0rek["KeyE"] = Keys.E;
		z0rek["KeyR"] = Keys.R;
		z0rek["KeyT"] = Keys.T;
		z0rek["KeyY"] = Keys.Y;
		z0rek["KeyU"] = Keys.U;
		z0rek["KeyI"] = Keys.I;
		z0rek["KeyO"] = Keys.O;
		z0rek["KeyP"] = Keys.P;
		z0rek["BracketLeft"] = Keys.OemOpenBrackets;
		z0rek["BracketRight"] = Keys.OemCloseBrackets;
		z0rek["Enter"] = Keys.Return;
		z0rek["ControlLeft"] = Keys.LControlKey;
		z0rek["KeyA"] = Keys.A;
		z0rek["KeyS"] = Keys.S;
		z0rek["KeyD"] = Keys.D;
		z0rek["KeyF"] = Keys.F;
		z0rek["KeyG"] = Keys.G;
		z0rek["KeyH"] = Keys.H;
		z0rek["KeyJ"] = Keys.J;
		z0rek["KeyK"] = Keys.K;
		z0rek["KeyL"] = Keys.L;
		z0rek["Semicolon"] = Keys.OemSemicolon;
		z0rek["Quote"] = Keys.OemQuotes;
		z0rek["ShiftLeft"] = Keys.LShiftKey;
		z0rek["Backslash"] = Keys.OemBackslash;
		z0rek["KeyZ"] = Keys.Z;
		z0rek["KeyX"] = Keys.X;
		z0rek["KeyC"] = Keys.C;
		z0rek["KeyV"] = Keys.V;
		z0rek["KeyB"] = Keys.B;
		z0rek["KeyN"] = Keys.N;
		z0rek["KeyM"] = Keys.M;
		z0rek["Comma"] = Keys.Oemcomma;
		z0rek["Period"] = Keys.OemPeriod;
		z0rek["ShiftRight"] = Keys.RShiftKey;
		z0rek["NumpadMultiply"] = Keys.Multiply;
		z0rek["AltLeft"] = Keys.LMenu;
		z0rek["Space"] = Keys.Space;
		z0rek["CapsLock"] = Keys.Capital;
		z0rek["F1"] = Keys.F1;
		z0rek["F2"] = Keys.F2;
		z0rek["F3"] = Keys.F3;
		z0rek["F4"] = Keys.F4;
		z0rek["F5"] = Keys.F5;
		z0rek["F6"] = Keys.F6;
		z0rek["F7"] = Keys.F7;
		z0rek["F8"] = Keys.F8;
		z0rek["F9"] = Keys.F9;
		z0rek["F10"] = Keys.F10;
		z0rek["Pause"] = Keys.Pause;
		z0rek["ScrollLock"] = Keys.Scroll;
		z0rek["Numpad7"] = Keys.NumPad7;
		z0rek["Numpad8"] = Keys.NumPad8;
		z0rek["Numpad9"] = Keys.NumPad9;
		z0rek["NumpadSubtract"] = Keys.Subtract;
		z0rek["Numpad4"] = Keys.NumPad4;
		z0rek["Numpad5"] = Keys.NumPad5;
		z0rek["Numpad6"] = Keys.NumPad6;
		z0rek["NumpadAdd"] = Keys.Add;
		z0rek["Numpad1"] = Keys.NumPad1;
		z0rek["Numpad2"] = Keys.NumPad2;
		z0rek["Numpad3"] = Keys.NumPad3;
		z0rek["Numpad0"] = Keys.NumPad0;
		z0rek["NumpadDecimal"] = Keys.Decimal;
		z0rek["PrintScreen"] = Keys.Snapshot;
		z0rek["F11"] = Keys.F11;
		z0rek["F12"] = Keys.F12;
		z0rek["F13"] = Keys.F13;
		z0rek["F14"] = Keys.F14;
		z0rek["F15"] = Keys.F15;
		z0rek["F16"] = Keys.F16;
		z0rek["F17"] = Keys.F17;
		z0rek["F18"] = Keys.F18;
		z0rek["F19"] = Keys.F19;
		z0rek["F20"] = Keys.F20;
		z0rek["F21"] = Keys.F21;
		z0rek["F22"] = Keys.F22;
		z0rek["F23"] = Keys.F23;
		z0rek["KanaMode"] = Keys.KanaMode;
		z0rek["Lang2"] = Keys.LaunchApplication2;
		z0rek["Lang1"] = Keys.LaunchApplication1;
		z0rek["F24"] = Keys.F24;
		z0rek["Convert"] = Keys.IMEConvert;
		z0rek["NonConvert"] = Keys.IMENonconvert;
		z0rek["IntlYen"] = Keys.Insert;
		z0rek["MediaTrackPrevious"] = Keys.MediaPreviousTrack;
		z0rek["MediaTrackNext"] = Keys.MediaNextTrack;
		z0rek["NumpadEnter"] = Keys.Return;
		z0rek["ControlRight"] = Keys.RControlKey;
		z0rek["AudioVolumeMute"] = Keys.VolumeMute;
		z0rek["LaunchApp2"] = Keys.Apps;
		z0rek["MediaPlayPause"] = Keys.MediaPlayPause;
		z0rek["MediaStop"] = Keys.MediaStop;
		z0rek["AudioVolumeDown"] = Keys.VolumeDown;
		z0rek["AudioVolumeUp"] = Keys.VolumeUp;
		z0rek["BrowserHome"] = Keys.BrowserHome;
		z0rek["NumpadDivide"] = Keys.Divide;
		z0rek["PrintScreen"] = Keys.Snapshot;
		z0rek["AltRight"] = Keys.Alt;
		z0rek["AltLeft"] = Keys.Alt;
		z0rek["Help"] = Keys.Help;
		z0rek["NumLock"] = Keys.NumLock;
		z0rek["Pause"] = Keys.Pause;
		z0rek["Home"] = Keys.Home;
		z0rek["ArrowUp"] = Keys.Up;
		z0rek["PageUp"] = Keys.Prior;
		z0rek["ArrowLeft"] = Keys.Left;
		z0rek["ArrowRight"] = Keys.Right;
		z0rek["End"] = Keys.End;
		z0rek["ArrowDown"] = Keys.Down;
		z0rek["PageDown"] = Keys.Next;
		z0rek["Insert"] = Keys.Insert;
		z0rek["Delete"] = Keys.Delete;
		z0rek["MetaLeft"] = Keys.LWin;
		z0rek["MetaRight"] = Keys.RWin;
		z0rek["Sleep"] = Keys.Sleep;
		z0rek["BrowserSearch"] = Keys.BrowserSearch;
		z0rek["BrowserFavorites"] = Keys.BrowserFavorites;
		z0rek["BrowserRefresh"] = Keys.BrowserRefresh;
		z0rek["BrowserStop"] = Keys.BrowserStop;
		z0rek["BrowserForward"] = Keys.BrowserForward;
		z0rek["BrowserBack"] = Keys.BrowserBack;
		z0rek["LaunchMail"] = Keys.LaunchMail;
		z0rek["MediaSelect"] = Keys.SelectMedia;
	}
}
