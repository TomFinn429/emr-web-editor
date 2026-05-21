using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;

namespace System;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class Uri : ISerializable
{
	[Flags]
	internal enum Flags : ulong
	{
		Zero = 0uL,
		SchemeNotCanonical = 1uL,
		UserNotCanonical = 2uL,
		HostNotCanonical = 4uL,
		PortNotCanonical = 8uL,
		PathNotCanonical = 0x10uL,
		QueryNotCanonical = 0x20uL,
		FragmentNotCanonical = 0x40uL,
		CannotDisplayCanonical = 0x7FuL,
		E_UserNotCanonical = 0x80uL,
		E_HostNotCanonical = 0x100uL,
		E_PortNotCanonical = 0x200uL,
		E_PathNotCanonical = 0x400uL,
		E_QueryNotCanonical = 0x800uL,
		E_FragmentNotCanonical = 0x1000uL,
		E_CannotDisplayCanonical = 0x1F80uL,
		ShouldBeCompressed = 0x2000uL,
		FirstSlashAbsent = 0x4000uL,
		BackslashInPath = 0x8000uL,
		IndexMask = 0xFFFFuL,
		HostTypeMask = 0x70000uL,
		HostNotParsed = 0uL,
		IPv6HostType = 0x10000uL,
		IPv4HostType = 0x20000uL,
		DnsHostType = 0x30000uL,
		UncHostType = 0x40000uL,
		BasicHostType = 0x50000uL,
		UnusedHostType = 0x60000uL,
		UnknownHostType = 0x70000uL,
		UserEscaped = 0x80000uL,
		AuthorityFound = 0x100000uL,
		HasUserInfo = 0x200000uL,
		LoopbackHost = 0x400000uL,
		NotDefaultPort = 0x800000uL,
		UserDrivenParsing = 0x1000000uL,
		CanonicalDnsHost = 0x2000000uL,
		ErrorOrParsingRecursion = 0x4000000uL,
		DosPath = 0x8000000uL,
		UncPath = 0x10000000uL,
		ImplicitFile = 0x20000000uL,
		MinimalUriInfoSet = 0x40000000uL,
		AllUriInfoSet = 0x80000000uL,
		IdnHost = 0x100000000uL,
		HasUnicode = 0x200000000uL,
		HostUnicodeNormalized = 0x400000000uL,
		RestUnicodeNormalized = 0x800000000uL,
		UnicodeHost = 0x1000000000uL,
		IntranetUri = 0x2000000000uL,
		UserIriCanonical = 0x8000000000uL,
		PathIriCanonical = 0x10000000000uL,
		QueryIriCanonical = 0x20000000000uL,
		FragmentIriCanonical = 0x40000000000uL,
		IriCanonical = 0x78000000000uL,
		UnixPath = 0x100000000000uL,
		DisablePathAndQueryCanonicalization = 0x200000000000uL,
		CustomParser_ParseMinimalAlreadyCalled = 0x4000000000000000uL,
		Debug_LeftConstructor = 9223372036854775808uL
	}

	private sealed class UriInfo
	{
		public Offset Offset;

		public string String;

		public string Host;

		public string IdnHost;

		public string ScopeId;

		private MoreInfo _moreInfo;

		public MoreInfo MoreInfo
		{
			get
			{
				if (_moreInfo == null)
				{
					Interlocked.CompareExchange(ref _moreInfo, new MoreInfo(), null);
				}
				return _moreInfo;
			}
		}
	}

	[StructLayout((LayoutKind)0, Pack = 1)]
	private struct Offset
	{
		public ushort Scheme;

		public ushort User;

		public ushort Host;

		public ushort PortValue;

		public ushort Path;

		public ushort Query;

		public ushort Fragment;

		public ushort End;
	}

	private sealed class MoreInfo
	{
		public string AbsoluteUri;

		public string RemoteUrl;
	}

	[Flags]
	private enum Check
	{
		None = 0,
		EscapedCanonical = 1,
		DisplayCanonical = 2,
		DotSlashAttn = 4,
		DotSlashEscaped = 0x80,
		BackslashInPath = 0x10,
		ReservedFound = 0x20,
		NotIriCanonical = 0x40,
		FoundNonAscii = 8
	}

	public static readonly string UriSchemeFile = UriParser.FileUri.SchemeName;

	public static readonly string UriSchemeFtp = UriParser.FtpUri.SchemeName;

	public static readonly string UriSchemeSftp = "sftp";

	public static readonly string UriSchemeFtps = "ftps";

	public static readonly string UriSchemeGopher = UriParser.GopherUri.SchemeName;

	public static readonly string UriSchemeHttp = UriParser.HttpUri.SchemeName;

	public static readonly string UriSchemeHttps = UriParser.HttpsUri.SchemeName;

	public static readonly string UriSchemeWs = UriParser.WsUri.SchemeName;

	public static readonly string UriSchemeWss = UriParser.WssUri.SchemeName;

	public static readonly string UriSchemeMailto = UriParser.MailToUri.SchemeName;

	public static readonly string UriSchemeNews = UriParser.NewsUri.SchemeName;

	public static readonly string UriSchemeNntp = UriParser.NntpUri.SchemeName;

	public static readonly string UriSchemeSsh = "ssh";

	public static readonly string UriSchemeTelnet = UriParser.TelnetUri.SchemeName;

	public static readonly string UriSchemeNetTcp = UriParser.NetTcpUri.SchemeName;

	public static readonly string UriSchemeNetPipe = UriParser.NetPipeUri.SchemeName;

	public static readonly string SchemeDelimiter = "://";

	private string _string;

	private string _originalUnicodeString;

	internal UriParser _syntax;

	internal Flags _flags;

	private UriInfo _info;

	private bool IsImplicitFile => (_flags & Flags.ImplicitFile) != 0;

	private bool IsUncOrDosPath => (_flags & (Flags.DosPath | Flags.UncPath)) != 0;

	private bool IsDosPath => (_flags & Flags.DosPath) != 0;

	private bool IsUncPath => (_flags & Flags.UncPath) != 0;

	private bool IsUnixPath => (_flags & Flags.UnixPath) != 0;

	private Flags HostType => _flags & Flags.HostTypeMask;

	private UriParser Syntax => _syntax;

	private bool IsNotAbsoluteUri => _syntax == null;

	private bool IriParsing => IriParsingStatic(_syntax);

	internal bool DisablePathAndQueryCanonicalization => (_flags & Flags.DisablePathAndQueryCanonicalization) != 0;

	internal bool UserDrivenParsing => (_flags & Flags.UserDrivenParsing) != 0;

	private int SecuredPathIndex
	{
		get
		{
			if (IsDosPath)
			{
				char c = _string[_info.Offset.Path];
				if (c != '/' && c != '\\')
				{
					return 2;
				}
				return 3;
			}
			return 0;
		}
	}

	public string AbsoluteUri
	{
		get
		{
			if (_syntax == null)
			{
				throw new InvalidOperationException("net_uri_NotAbsolute");
			}
			MoreInfo moreInfo = EnsureUriInfo().MoreInfo;
			MoreInfo moreInfo2 = moreInfo;
			return moreInfo2.AbsoluteUri ?? (moreInfo2.AbsoluteUri = GetParts(UriComponents.AbsoluteUri, UriFormat.UriEscaped));
		}
	}

	public string LocalPath
	{
		get
		{
			if (IsNotAbsoluteUri)
			{
				throw new InvalidOperationException("net_uri_NotAbsolute");
			}
			return GetLocalPath();
		}
	}

	public bool IsFile
	{
		get
		{
			if (IsNotAbsoluteUri)
			{
				throw new InvalidOperationException("net_uri_NotAbsolute");
			}
			return (object)_syntax.SchemeName == UriSchemeFile;
		}
	}

	public bool IsUnc
	{
		get
		{
			if (IsNotAbsoluteUri)
			{
				throw new InvalidOperationException("net_uri_NotAbsolute");
			}
			return IsUncPath;
		}
	}

	public string Host
	{
		get
		{
			if (IsNotAbsoluteUri)
			{
				throw new InvalidOperationException("net_uri_NotAbsolute");
			}
			return GetParts(UriComponents.Host, UriFormat.UriEscaped);
		}
	}

	public int Port
	{
		get
		{
			if (IsNotAbsoluteUri)
			{
				throw new InvalidOperationException("net_uri_NotAbsolute");
			}
			if (_syntax.IsSimple)
			{
				EnsureUriInfo();
			}
			else
			{
				EnsureHostString(false);
			}
			if (InFact(Flags.NotDefaultPort))
			{
				return _info.Offset.PortValue;
			}
			return _syntax.DefaultPort;
		}
	}

	public string Scheme
	{
		get
		{
			if (IsNotAbsoluteUri)
			{
				throw new InvalidOperationException("net_uri_NotAbsolute");
			}
			return _syntax.SchemeName;
		}
	}

	public string OriginalString => _originalUnicodeString ?? _string;

	public string DnsSafeHost
	{
		get
		{
			if (IsNotAbsoluteUri)
			{
				throw new InvalidOperationException("net_uri_NotAbsolute");
			}
			EnsureHostString(false);
			Flags hostType = HostType;
			if (hostType == Flags.IPv6HostType || (hostType == Flags.BasicHostType && InFact(Flags.HostNotCanonical | Flags.E_HostNotCanonical)))
			{
				return IdnHost;
			}
			return _info.Host;
		}
	}

	public string IdnHost
	{
		get
		{
			if (IsNotAbsoluteUri)
			{
				throw new InvalidOperationException("net_uri_NotAbsolute");
			}
			if (_info?.IdnHost == null)
			{
				EnsureHostString(false);
				string text = _info.Host;
				switch (HostType)
				{
				case Flags.DnsHostType:
					text = System.DomainNameHelper.IdnEquivalent(text);
					break;
				case Flags.IPv6HostType:
					text = ((_info.ScopeId != null) ? string.Concat(text.AsSpan(1, text.Length - 2), _info.ScopeId) : text.Substring(1, text.Length - 2));
					break;
				case Flags.BasicHostType:
					if (InFact(Flags.HostNotCanonical | Flags.E_HostNotCanonical))
					{
						Span<char> span = stackalloc char[512];
						System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(span);
						System.UriHelper.UnescapeString(text, 0, text.Length, ref valueStringBuilder, '\uffff', '\uffff', '\uffff', System.UnescapeMode.Unescape | System.UnescapeMode.UnescapeAll, _syntax, false);
						text = valueStringBuilder.ToString();
					}
					break;
				}
				_info.IdnHost = text;
			}
			return _info.IdnHost;
		}
	}

	public bool IsAbsoluteUri => _syntax != null;

	public bool UserEscaped => InFact(Flags.UserEscaped);

	private void InterlockedSetFlags(Flags P_0)
	{
		if (_syntax.IsSimple)
		{
			Interlocked.Or(ref Unsafe.As<Flags, ulong>(ref _flags), (ulong)P_0);
			return;
		}
		lock (_info)
		{
			_flags |= P_0;
		}
	}

	internal static bool IriParsingStatic(UriParser P_0)
	{
		return P_0?.InFact(System.UriSyntaxFlags.AllowIriParsing) ?? true;
	}

	private bool NotAny(Flags P_0)
	{
		return (_flags & P_0) == 0;
	}

	private bool InFact(Flags P_0)
	{
		return (_flags & P_0) != 0;
	}

	private static bool StaticNotAny(Flags P_0, Flags P_1)
	{
		return (P_0 & P_1) == 0;
	}

	private static bool StaticInFact(Flags P_0, Flags P_1)
	{
		return (P_0 & P_1) != 0;
	}

	private UriInfo EnsureUriInfo()
	{
		Flags flags = _flags;
		if ((flags & Flags.MinimalUriInfoSet) == Flags.Zero)
		{
			CreateUriInfo(flags);
		}
		return _info;
	}

	private void EnsureParseRemaining()
	{
		if ((_flags & Flags.AllUriInfoSet) == Flags.Zero)
		{
			ParseRemaining();
		}
	}

	private void EnsureHostString(bool P_0)
	{
		UriInfo uriInfo = EnsureUriInfo();
		if (uriInfo.Host == null && (!P_0 || !InFact(Flags.CanonicalDnsHost)))
		{
			CreateHostString();
		}
	}

	public Uri([StringSyntax("Uri")] string uriString)
	{
		ArgumentNullException.ThrowIfNull(uriString, "uriString");
		CreateThis(uriString, false, UriKind.Absolute, default(UriCreationOptions));
	}

	[Obsolete("This constructor has been deprecated; the dontEscape parameter is always false. Use Uri(string) instead.")]
	public Uri([StringSyntax("Uri")] string uriString, bool dontEscape)
	{
		ArgumentNullException.ThrowIfNull(uriString, "uriString");
		CreateThis(uriString, dontEscape, UriKind.Absolute, default(UriCreationOptions));
	}

	[Obsolete("This constructor has been deprecated; the dontEscape parameter is always false. Use Uri(Uri, string) instead.")]
	public Uri(Uri baseUri, string? relativeUri, bool dontEscape)
	{
		ArgumentNullException.ThrowIfNull(baseUri, "baseUri");
		if (!baseUri.IsAbsoluteUri)
		{
			throw new ArgumentOutOfRangeException("baseUri");
		}
		CreateUri(baseUri, relativeUri, dontEscape);
	}

	public Uri([StringSyntax("Uri", new object[] { "uriKind" })] string uriString, UriKind uriKind)
	{
		ArgumentNullException.ThrowIfNull(uriString, "uriString");
		CreateThis(uriString, false, uriKind, default(UriCreationOptions));
	}

	public Uri([StringSyntax("Uri")] string uriString, in UriCreationOptions creationOptions)
	{
		ArgumentNullException.ThrowIfNull(uriString, "uriString");
		CreateThis(uriString, false, UriKind.Absolute, in creationOptions);
	}

	public Uri(Uri baseUri, string? relativeUri)
	{
		ArgumentNullException.ThrowIfNull(baseUri, "baseUri");
		if (!baseUri.IsAbsoluteUri)
		{
			throw new ArgumentOutOfRangeException("baseUri");
		}
		CreateUri(baseUri, relativeUri, false);
	}

	void ISerializable.GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		GetObjectData(P_0, P_1);
	}

	protected void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		if (IsAbsoluteUri)
		{
			P_0.AddValue("AbsoluteUri", GetParts(UriComponents.SerializationInfoString, UriFormat.UriEscaped));
			return;
		}
		P_0.AddValue("AbsoluteUri", string.Empty);
		P_0.AddValue("RelativeUri", GetParts(UriComponents.SerializationInfoString, UriFormat.UriEscaped));
	}

	private void CreateUri(Uri P_0, string P_1, bool P_2)
	{
		CreateThis(P_1, P_2, UriKind.RelativeOrAbsolute, default(UriCreationOptions));
		if (P_0.Syntax.IsSimple)
		{
			Uri uri = ResolveHelper(P_0, this, ref P_1, ref P_2);
			if (uri != null)
			{
				if ((object)this != uri)
				{
					CreateThisFromUri(uri);
				}
				return;
			}
		}
		else
		{
			P_2 = false;
			P_1 = P_0.Syntax.InternalResolve(P_0, this, out var ex);
			if (ex != null)
			{
				throw ex;
			}
		}
		_flags = Flags.Zero;
		_info = null;
		_syntax = null;
		_originalUnicodeString = null;
		CreateThis(P_1, P_2, UriKind.Absolute, default(UriCreationOptions));
	}

	public Uri(Uri baseUri, Uri relativeUri)
	{
		ArgumentNullException.ThrowIfNull(baseUri, "baseUri");
		if (!baseUri.IsAbsoluteUri)
		{
			throw new ArgumentOutOfRangeException("baseUri");
		}
		CreateThisFromUri(relativeUri);
		string text = null;
		bool flag;
		if (baseUri.Syntax.IsSimple)
		{
			flag = InFact(Flags.UserEscaped);
			Uri uri = ResolveHelper(baseUri, this, ref text, ref flag);
			if (uri != null)
			{
				if ((object)this != uri)
				{
					CreateThisFromUri(uri);
				}
				return;
			}
		}
		else
		{
			flag = false;
			text = baseUri.Syntax.InternalResolve(baseUri, this, out var ex);
			if (ex != null)
			{
				throw ex;
			}
		}
		_flags = Flags.Zero;
		_info = null;
		_syntax = null;
		_originalUnicodeString = null;
		CreateThis(text, flag, UriKind.Absolute, default(UriCreationOptions));
	}

	private static void GetCombinedString(Uri P_0, string P_1, bool P_2, ref string P_3)
	{
		for (int i = 0; i < P_1.Length && P_1[i] != '/' && P_1[i] != '\\' && P_1[i] != '?' && P_1[i] != '#'; i++)
		{
			if (P_1[i] == ':')
			{
				if (i < 2)
				{
					break;
				}
				UriParser uriParser = null;
				if (CheckSchemeSyntax(P_1.AsSpan(0, i), ref uriParser) != System.ParsingError.None)
				{
					break;
				}
				if (P_0.Syntax == uriParser)
				{
					P_1 = ((i + 1 >= P_1.Length) ? string.Empty : P_1.Substring(i + 1));
					break;
				}
				P_3 = P_1;
				return;
			}
		}
		if (P_1.Length == 0)
		{
			P_3 = P_0.OriginalString;
		}
		else
		{
			P_3 = CombineUri(P_0, P_1, P_2 ? UriFormat.UriEscaped : UriFormat.SafeUnescaped);
		}
	}

	private static UriFormatException GetException(System.ParsingError P_0)
	{
		return P_0 switch
		{
			System.ParsingError.None => null, 
			System.ParsingError.BadFormat => new UriFormatException("net_uri_BadFormat"), 
			System.ParsingError.BadScheme => new UriFormatException("net_uri_BadScheme"), 
			System.ParsingError.BadAuthority => new UriFormatException("net_uri_BadAuthority"), 
			System.ParsingError.EmptyUriString => new UriFormatException("net_uri_EmptyUri"), 
			System.ParsingError.SchemeLimit => new UriFormatException("net_uri_SchemeLimit"), 
			System.ParsingError.SizeLimit => new UriFormatException("net_uri_SizeLimit"), 
			System.ParsingError.MustRootedPath => new UriFormatException("net_uri_MustRootedPath"), 
			System.ParsingError.BadHostName => new UriFormatException("net_uri_BadHostName"), 
			System.ParsingError.NonEmptyHost => new UriFormatException("net_uri_BadFormat"), 
			System.ParsingError.BadPort => new UriFormatException("net_uri_BadPort"), 
			System.ParsingError.BadAuthorityTerminator => new UriFormatException("net_uri_BadAuthorityTerminator"), 
			System.ParsingError.CannotCreateRelative => new UriFormatException("net_uri_CannotCreateRelative"), 
			_ => new UriFormatException("net_uri_BadFormat"), 
		};
	}

	private static bool StaticIsFile(UriParser P_0)
	{
		return P_0.InFact(System.UriSyntaxFlags.FileLikeUri);
	}

	private string GetLocalPath()
	{
		EnsureParseRemaining();
		if (IsUncOrDosPath)
		{
			EnsureHostString(false);
			int num;
			if (NotAny(Flags.HostNotCanonical | Flags.PathNotCanonical | Flags.ShouldBeCompressed))
			{
				num = (IsUncPath ? (_info.Offset.Host - 2) : _info.Offset.Path);
				string text = ((IsImplicitFile && _info.Offset.Host == ((!IsDosPath) ? 2 : 0) && _info.Offset.Query == _info.Offset.End) ? _string : ((IsDosPath && (_string[num] == '/' || _string[num] == '\\')) ? _string.Substring(num + 1, _info.Offset.Query - num - 1) : _string.Substring(num, _info.Offset.Query - num)));
				if (IsDosPath && text[1] == '|')
				{
					text = text.Remove(1, 1);
					text = text.Insert(1, ":");
				}
				return text.Replace('/', '\\');
			}
			int num2 = 0;
			num = _info.Offset.Path;
			string host = _info.Host;
			char[] array = new char[host.Length + 3 + _info.Offset.Fragment - _info.Offset.Path];
			if (IsUncPath)
			{
				array[0] = '\\';
				array[1] = '\\';
				num2 = 2;
				System.UriHelper.UnescapeString(host, 0, host.Length, array, ref num2, '\uffff', '\uffff', '\uffff', System.UnescapeMode.CopyOnly, _syntax, false);
			}
			else if (_string[num] == '/' || _string[num] == '\\')
			{
				num++;
			}
			ushort num3 = (ushort)num2;
			System.UnescapeMode unescapeMode = ((InFact(Flags.PathNotCanonical) && !IsImplicitFile) ? (System.UnescapeMode.Unescape | System.UnescapeMode.UnescapeAll) : System.UnescapeMode.CopyOnly);
			System.UriHelper.UnescapeString(_string, num, _info.Offset.Query, array, ref num2, '\uffff', '\uffff', '\uffff', unescapeMode, _syntax, true);
			if (array[1] == '|')
			{
				array[1] = ':';
			}
			if (InFact(Flags.ShouldBeCompressed))
			{
				Compress(array, IsDosPath ? (num3 + 2) : num3, ref num2, _syntax);
			}
			for (ushort num4 = 0; num4 < (ushort)num2; num4++)
			{
				if (array[num4] == '/')
				{
					array[num4] = '\\';
				}
			}
			return new string(array, 0, num2);
		}
		return GetUnescapedParts(UriComponents.Path | UriComponents.KeepDelimiter, UriFormat.Unescaped);
	}

	public static int FromHex(char P_0)
	{
		int num = System.HexConverter.FromChar(P_0);
		if (num == 255)
		{
			throw new ArgumentException(null, "digit");
		}
		return num;
	}

	public override int GetHashCode()
	{
		if (IsNotAbsoluteUri)
		{
			return OriginalString.GetHashCode();
		}
		MoreInfo moreInfo = EnsureUriInfo().MoreInfo;
		MoreInfo moreInfo2 = moreInfo;
		string text = moreInfo2.RemoteUrl ?? (moreInfo2.RemoteUrl = GetParts(UriComponents.HttpRequestUrl, UriFormat.SafeUnescaped));
		if (IsUncOrDosPath)
		{
			return StringComparer.OrdinalIgnoreCase.GetHashCode(text);
		}
		return text.GetHashCode();
	}

	public override string ToString()
	{
		if (_syntax == null)
		{
			return _string;
		}
		EnsureUriInfo();
		if (_info.String == null)
		{
			if (_syntax.IsSimple)
			{
				_info.String = GetComponentsHelper(UriComponents.AbsoluteUri, (UriFormat)32767);
			}
			else
			{
				_info.String = GetParts(UriComponents.AbsoluteUri, UriFormat.SafeUnescaped);
			}
		}
		return _info.String;
	}

	public static bool operator ==(Uri? P_0, Uri? P_1)
	{
		if ((object)P_0 == P_1)
		{
			return true;
		}
		if ((object)P_0 == null || (object)P_1 == null)
		{
			return false;
		}
		return P_0.Equals(P_1);
	}

	public static bool operator !=(Uri? P_0, Uri? P_1)
	{
		if ((object)P_0 == P_1)
		{
			return false;
		}
		if ((object)P_0 == null || (object)P_1 == null)
		{
			return true;
		}
		return !P_0.Equals(P_1);
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (this == P_0)
		{
			return true;
		}
		Uri uri = P_0 as Uri;
		if ((object)uri == null)
		{
			if (DisablePathAndQueryCanonicalization)
			{
				return false;
			}
			if (!(P_0 is string text))
			{
				return false;
			}
			if ((object)text == OriginalString)
			{
				return true;
			}
			if (!TryCreate(text, UriKind.RelativeOrAbsolute, out uri))
			{
				return false;
			}
		}
		if (DisablePathAndQueryCanonicalization != uri.DisablePathAndQueryCanonicalization)
		{
			return false;
		}
		if ((object)OriginalString == uri.OriginalString)
		{
			return true;
		}
		if (IsAbsoluteUri != uri.IsAbsoluteUri)
		{
			return false;
		}
		if (IsNotAbsoluteUri)
		{
			return OriginalString.Equals(uri.OriginalString);
		}
		if ((NotAny(Flags.AllUriInfoSet) || uri.NotAny(Flags.AllUriInfoSet)) && string.Equals(_string, uri._string, IsUncOrDosPath ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
		{
			return true;
		}
		EnsureUriInfo();
		uri.EnsureUriInfo();
		if (!UserDrivenParsing && !uri.UserDrivenParsing && Syntax.IsSimple && uri.Syntax.IsSimple)
		{
			if (InFact(Flags.CanonicalDnsHost) && uri.InFact(Flags.CanonicalDnsHost))
			{
				int num = _info.Offset.Host;
				int num2 = _info.Offset.Path;
				int num3 = uri._info.Offset.Host;
				int path = uri._info.Offset.Path;
				string text2 = uri._string;
				if (num2 - num > path - num3)
				{
					num2 = num + path - num3;
				}
				while (num < num2)
				{
					if (_string[num] != text2[num3])
					{
						return false;
					}
					if (text2[num3] == ':')
					{
						break;
					}
					num++;
					num3++;
				}
				if (num < _info.Offset.Path && _string[num] != ':')
				{
					return false;
				}
				if (num3 < path && text2[num3] != ':')
				{
					return false;
				}
			}
			else
			{
				EnsureHostString(false);
				uri.EnsureHostString(false);
				if (!_info.Host.Equals(uri._info.Host))
				{
					return false;
				}
			}
			if (Port != uri.Port)
			{
				return false;
			}
		}
		MoreInfo moreInfo = _info.MoreInfo;
		MoreInfo moreInfo2 = uri._info.MoreInfo;
		MoreInfo moreInfo3 = moreInfo;
		string text3 = moreInfo3.RemoteUrl ?? (moreInfo3.RemoteUrl = GetParts(UriComponents.HttpRequestUrl, UriFormat.SafeUnescaped));
		moreInfo3 = moreInfo2;
		string text4 = moreInfo3.RemoteUrl ?? (moreInfo3.RemoteUrl = uri.GetParts(UriComponents.HttpRequestUrl, UriFormat.SafeUnescaped));
		return string.Equals(text3, text4, IsUncOrDosPath ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
	}

	private unsafe static System.ParsingError ParseScheme(string P_0, ref Flags P_1, ref UriParser P_2)
	{
		int length = P_0.Length;
		if (length == 0)
		{
			return System.ParsingError.EmptyUriString;
		}
		if (length >= 65520)
		{
			return System.ParsingError.SizeLimit;
		}
		fixed (char* ptr = P_0)
		{
			System.ParsingError parsingError = System.ParsingError.None;
			int num = ParseSchemeCheckImplicitFile(ptr, length, ref parsingError, ref P_1, ref P_2);
			if (parsingError != System.ParsingError.None)
			{
				return parsingError;
			}
			P_1 |= (Flags)num;
		}
		return System.ParsingError.None;
	}

	internal UriFormatException ParseMinimal()
	{
		System.ParsingError parsingError = PrivateParseMinimal();
		if (parsingError == System.ParsingError.None)
		{
			return null;
		}
		_flags |= Flags.ErrorOrParsingRecursion;
		return GetException(parsingError);
	}

	private unsafe System.ParsingError PrivateParseMinimal()
	{
		int num = (int)(_flags & Flags.IndexMask);
		int num2 = _string.Length;
		string text = null;
		_flags &= ~(Flags.IndexMask | Flags.UserDrivenParsing);
		fixed (char* ptr = (((_flags & Flags.HostUnicodeNormalized) == Flags.Zero) ? OriginalString : _string))
		{
			if (num2 > num && System.UriHelper.IsLWS(ptr[num2 - 1]))
			{
				num2--;
				while (num2 != num && System.UriHelper.IsLWS(ptr[--num2]))
				{
				}
				num2++;
			}
			_ = 0;
			if (InFact(Flags.UnixPath))
			{
				_flags |= Flags.BasicHostType;
				_flags |= (Flags)num;
				return System.ParsingError.None;
			}
			if (_syntax.IsAllSet(System.UriSyntaxFlags.AllowEmptyHost | System.UriSyntaxFlags.AllowDOSPath) && NotAny(Flags.ImplicitFile) && num + 1 < num2)
			{
				int i;
				for (i = num; i < num2; i++)
				{
					char c;
					if ((c = ptr[i]) != '\\' && c != '/')
					{
						break;
					}
				}
				if (_syntax.InFact(System.UriSyntaxFlags.FileLikeUri) || i - num <= 3)
				{
					if (i - num >= 2)
					{
						_flags |= Flags.AuthorityFound;
					}
					char c;
					if (i + 1 < num2 && ((c = ptr[i + 1]) == ':' || c == '|') && char.IsAsciiLetter(ptr[i]))
					{
						if (i + 2 >= num2 || ((c = ptr[i + 2]) != '\\' && c != '/'))
						{
							if (_syntax.InFact(System.UriSyntaxFlags.FileLikeUri))
							{
								return System.ParsingError.MustRootedPath;
							}
						}
						else
						{
							_flags |= Flags.DosPath;
							if (_syntax.InFact(System.UriSyntaxFlags.MustHaveAuthority))
							{
								_flags |= Flags.AuthorityFound;
							}
							num = ((i == num || i - num == 2) ? i : (i - 1));
						}
					}
					else if (_syntax.InFact(System.UriSyntaxFlags.FileLikeUri) && i - num >= 2 && i - num != 3 && i < num2 && ptr[i] != '?' && ptr[i] != '#')
					{
						_flags |= Flags.UncPath;
						num = i;
					}
					else
					{
						_ = 0;
						if (_syntax.InFact(System.UriSyntaxFlags.FileLikeUri) && ptr[i - 1] == '/' && i - num == 3)
						{
							_syntax = UriParser.UnixFileUri;
							_flags |= Flags.AuthorityFound | Flags.UnixPath;
							num += 2;
						}
					}
				}
			}
			if ((_flags & (Flags.DosPath | Flags.UncPath | Flags.UnixPath)) == Flags.Zero)
			{
				if (num + 2 <= num2)
				{
					char c2 = ptr[num];
					char c3 = ptr[num + 1];
					if (_syntax.InFact(System.UriSyntaxFlags.MustHaveAuthority))
					{
						if ((c2 != '/' && c2 != '\\') || (c3 != '/' && c3 != '\\'))
						{
							return System.ParsingError.BadAuthority;
						}
						_flags |= Flags.AuthorityFound;
						num += 2;
					}
					else if (_syntax.InFact(System.UriSyntaxFlags.OptionalAuthority) && (InFact(Flags.AuthorityFound) || (c2 == '/' && c3 == '/')))
					{
						_flags |= Flags.AuthorityFound;
						num += 2;
					}
					else if (_syntax.NotAny(System.UriSyntaxFlags.MailToLikeUri))
					{
						if ((_flags & (Flags.HasUnicode | Flags.HostUnicodeNormalized)) == Flags.HasUnicode)
						{
							_string = _string.Substring(0, num);
						}
						_flags |= (Flags)((ulong)num | 0x70000uL);
						return System.ParsingError.None;
					}
				}
				else
				{
					if (_syntax.InFact(System.UriSyntaxFlags.MustHaveAuthority))
					{
						return System.ParsingError.BadAuthority;
					}
					if (_syntax.NotAny(System.UriSyntaxFlags.MailToLikeUri))
					{
						if ((_flags & (Flags.HasUnicode | Flags.HostUnicodeNormalized)) == Flags.HasUnicode)
						{
							_string = _string.Substring(0, num);
						}
						_flags |= (Flags)((ulong)num | 0x70000uL);
						return System.ParsingError.None;
					}
				}
			}
			if (InFact(Flags.DosPath))
			{
				_flags |= (Flags)(((_flags & Flags.AuthorityFound) != Flags.Zero) ? 327680 : 458752);
				_flags |= (Flags)num;
				return System.ParsingError.None;
			}
			System.ParsingError parsingError = System.ParsingError.None;
			num = CheckAuthorityHelper(ptr, num, num2, ref parsingError, ref _flags, _syntax, ref text);
			if (parsingError != System.ParsingError.None)
			{
				return parsingError;
			}
			if (num < num2)
			{
				char c4 = ptr[num];
				if (c4 == '\\' && NotAny(Flags.ImplicitFile) && _syntax.NotAny(System.UriSyntaxFlags.AllowDOSPath))
				{
					return System.ParsingError.BadAuthorityTerminator;
				}
				_ = 0;
				if (c4 == '/' && NotAny(Flags.ImplicitFile) && InFact(Flags.UncPath) && _syntax == UriParser.FileUri)
				{
					_syntax = UriParser.UnixFileUri;
				}
			}
			_flags |= (Flags)num;
		}
		if (IriParsing && text != null)
		{
			_string = text;
		}
		return System.ParsingError.None;
	}

	private unsafe void CreateUriInfo(Flags P_0)
	{
		UriInfo uriInfo = new UriInfo();
		uriInfo.Offset.End = (ushort)_string.Length;
		if (!UserDrivenParsing)
		{
			bool flag = false;
			int i;
			if ((P_0 & Flags.ImplicitFile) != Flags.Zero)
			{
				i = 0;
				while (System.UriHelper.IsLWS(_string[i]))
				{
					i++;
					uriInfo.Offset.Scheme++;
				}
				if (StaticInFact(P_0, Flags.UncPath))
				{
					i += 2;
					for (int num = (int)(P_0 & Flags.IndexMask); i < num && (_string[i] == '/' || _string[i] == '\\'); i++)
					{
					}
				}
			}
			else
			{
				i = _syntax.SchemeName.Length;
				while (_string[i++] != ':')
				{
					uriInfo.Offset.Scheme++;
				}
				if ((P_0 & Flags.AuthorityFound) != Flags.Zero)
				{
					if (_string[i] == '\\' || _string[i + 1] == '\\')
					{
						flag = true;
					}
					i += 2;
					if ((P_0 & (Flags.DosPath | Flags.UncPath)) != Flags.Zero)
					{
						for (int num2 = (int)(P_0 & Flags.IndexMask); i < num2 && (_string[i] == '/' || _string[i] == '\\'); i++)
						{
							flag = true;
						}
					}
				}
			}
			if (_syntax.DefaultPort != -1)
			{
				uriInfo.Offset.PortValue = (ushort)_syntax.DefaultPort;
			}
			if ((P_0 & Flags.HostTypeMask) == Flags.HostTypeMask || StaticInFact(P_0, Flags.DosPath))
			{
				uriInfo.Offset.User = (ushort)(P_0 & Flags.IndexMask);
				uriInfo.Offset.Host = uriInfo.Offset.User;
				uriInfo.Offset.Path = uriInfo.Offset.User;
				P_0 = (Flags)((ulong)P_0 & 0xFFFFFFFFFFFF0000uL);
				if (flag)
				{
					P_0 |= Flags.SchemeNotCanonical;
				}
			}
			else
			{
				uriInfo.Offset.User = (ushort)i;
				if (HostType == Flags.BasicHostType)
				{
					uriInfo.Offset.Host = (ushort)i;
					uriInfo.Offset.Path = (ushort)(P_0 & Flags.IndexMask);
					P_0 = (Flags)((ulong)P_0 & 0xFFFFFFFFFFFF0000uL);
				}
				else
				{
					if ((P_0 & Flags.HasUserInfo) != Flags.Zero)
					{
						for (; _string[i] != '@'; i++)
						{
						}
						i++;
						uriInfo.Offset.Host = (ushort)i;
					}
					else
					{
						uriInfo.Offset.Host = (ushort)i;
					}
					i = (int)(P_0 & Flags.IndexMask);
					P_0 = (Flags)((ulong)P_0 & 0xFFFFFFFFFFFF0000uL);
					if (flag)
					{
						P_0 |= Flags.SchemeNotCanonical;
					}
					uriInfo.Offset.Path = (ushort)i;
					bool flag2 = false;
					if ((P_0 & Flags.HasUnicode) != Flags.Zero)
					{
						uriInfo.Offset.End = (ushort)_originalUnicodeString.Length;
					}
					if (i < uriInfo.Offset.End)
					{
						fixed (char* originalString = OriginalString)
						{
							if (originalString[i] == ':')
							{
								int num3 = 0;
								if (++i < uriInfo.Offset.End)
								{
									num3 = originalString[i] - 48;
									if ((uint)num3 <= 9u)
									{
										flag2 = true;
										if (num3 == 0)
										{
											P_0 |= Flags.PortNotCanonical | Flags.E_PortNotCanonical;
										}
										for (i++; i < uriInfo.Offset.End; i++)
										{
											int num4 = originalString[i] - 48;
											if ((uint)num4 > 9u)
											{
												break;
											}
											num3 = num3 * 10 + num4;
										}
									}
								}
								if (flag2 && _syntax.DefaultPort != num3)
								{
									uriInfo.Offset.PortValue = (ushort)num3;
									P_0 |= Flags.NotDefaultPort;
								}
								else
								{
									P_0 |= Flags.PortNotCanonical | Flags.E_PortNotCanonical;
								}
								uriInfo.Offset.Path = (ushort)i;
							}
						}
					}
				}
			}
		}
		P_0 |= Flags.MinimalUriInfoSet;
		Interlocked.CompareExchange(ref _info, uriInfo, null);
		Flags flags = _flags;
		while ((flags & Flags.MinimalUriInfoSet) == Flags.Zero)
		{
			Flags flags2 = (Flags)(((ulong)flags & 0xFFFFFFFFFFFF0000uL) | (ulong)P_0);
			ulong num5 = Interlocked.CompareExchange(ref Unsafe.As<Flags, ulong>(ref _flags), (ulong)flags2, (ulong)flags);
			if (num5 == (ulong)flags)
			{
				break;
			}
			flags = (Flags)num5;
		}
	}

	private unsafe void CreateHostString()
	{
		if (!_syntax.IsSimple)
		{
			lock (_info)
			{
				if (NotAny(Flags.ErrorOrParsingRecursion))
				{
					_flags |= Flags.ErrorOrParsingRecursion;
					GetHostViaCustomSyntax();
					_flags &= ~Flags.ErrorOrParsingRecursion;
					return;
				}
			}
		}
		Flags flags = _flags;
		string text = CreateHostStringHelper(_string, _info.Offset.Host, _info.Offset.Path, ref flags, ref _info.ScopeId);
		if (text.Length != 0)
		{
			if (HostType == Flags.BasicHostType)
			{
				int num = 0;
				Check check;
				fixed (char* ptr = text)
				{
					check = CheckCanonical(ptr, ref num, text.Length, '\uffff');
				}
				if ((check & Check.DisplayCanonical) == 0 && (NotAny(Flags.ImplicitFile) || (check & Check.ReservedFound) != Check.None))
				{
					flags |= Flags.HostNotCanonical;
				}
				if (InFact(Flags.ImplicitFile) && (check & (Check.EscapedCanonical | Check.ReservedFound)) != Check.None)
				{
					check &= ~Check.EscapedCanonical;
				}
				if ((check & (Check.EscapedCanonical | Check.BackslashInPath)) != Check.EscapedCanonical)
				{
					flags |= Flags.E_HostNotCanonical;
					if (NotAny(Flags.UserEscaped))
					{
						text = System.UriHelper.EscapeString(text, !IsImplicitFile, System.UriHelper.UnreservedReservedTable, '?', '#');
					}
				}
			}
			else if (NotAny(Flags.CanonicalDnsHost))
			{
				if (_info.ScopeId != null)
				{
					flags |= Flags.HostNotCanonical | Flags.E_HostNotCanonical;
				}
				else
				{
					for (int i = 0; i < text.Length; i++)
					{
						if (_info.Offset.Host + i >= _info.Offset.End || text[i] != _string[_info.Offset.Host + i])
						{
							flags |= Flags.HostNotCanonical | Flags.E_HostNotCanonical;
							break;
						}
					}
				}
			}
		}
		_info.Host = text;
		InterlockedSetFlags(flags);
	}

	private static string CreateHostStringHelper(string P_0, int P_1, int P_2, ref Flags P_3, ref string P_4)
	{
		bool flag = false;
		string text;
		switch (P_3 & Flags.HostTypeMask)
		{
		case Flags.DnsHostType:
			text = System.DomainNameHelper.ParseCanonicalName(P_0, P_1, P_2, ref flag);
			break;
		case Flags.IPv6HostType:
			text = System.IPv6AddressHelper.ParseCanonicalName(P_0, P_1, ref flag, ref P_4);
			break;
		case Flags.IPv4HostType:
			text = System.IPv4AddressHelper.ParseCanonicalName(P_0, P_1, P_2, ref flag);
			break;
		case Flags.UncHostType:
			text = System.UncNameHelper.ParseCanonicalName(P_0, P_1, P_2, ref flag);
			break;
		case Flags.BasicHostType:
			text = ((!StaticInFact(P_3, Flags.DosPath)) ? P_0.Substring(P_1, P_2 - P_1) : string.Empty);
			if (text.Length == 0)
			{
				flag = true;
			}
			break;
		case Flags.HostTypeMask:
			text = string.Empty;
			break;
		default:
			throw GetException(System.ParsingError.BadHostName);
		}
		if (flag)
		{
			P_3 |= Flags.LoopbackHost;
		}
		return text;
	}

	private unsafe void GetHostViaCustomSyntax()
	{
		if (_info.Host != null)
		{
			return;
		}
		string text = _syntax.InternalGetComponents(this, UriComponents.Host, UriFormat.UriEscaped);
		if (_info.Host == null)
		{
			if (text.Length >= 65520)
			{
				throw GetException(System.ParsingError.SizeLimit);
			}
			System.ParsingError parsingError = System.ParsingError.None;
			Flags flags = (Flags)((ulong)_flags & 0xFFFFFFFFFFF8FFFFuL);
			fixed (char* ptr = text)
			{
				string text2 = null;
				if (CheckAuthorityHelper(ptr, 0, text.Length, ref parsingError, ref flags, _syntax, ref text2) != text.Length)
				{
					flags = (Flags)((ulong)flags & 0xFFFFFFFFFFF8FFFFuL);
					flags |= Flags.HostTypeMask;
				}
			}
			if (parsingError != System.ParsingError.None || (flags & Flags.HostTypeMask) == Flags.HostTypeMask)
			{
				_flags = (Flags)(((ulong)_flags & 0xFFFFFFFFFFF8FFFFuL) | 0x50000);
			}
			else
			{
				text = CreateHostStringHelper(text, 0, text.Length, ref flags, ref _info.ScopeId);
				for (int i = 0; i < text.Length; i++)
				{
					if (_info.Offset.Host + i >= _info.Offset.End || text[i] != _string[_info.Offset.Host + i])
					{
						_flags |= Flags.HostNotCanonical | Flags.E_HostNotCanonical;
						break;
					}
				}
				_flags = (Flags)(((ulong)_flags & 0xFFFFFFFFFFF8FFFFuL) | (ulong)(flags & Flags.HostTypeMask));
			}
		}
		string text3 = _syntax.InternalGetComponents(this, UriComponents.StrongPort, UriFormat.UriEscaped);
		int num = 0;
		if (string.IsNullOrEmpty(text3))
		{
			_flags &= ~Flags.NotDefaultPort;
			_flags |= Flags.PortNotCanonical | Flags.E_PortNotCanonical;
			_info.Offset.PortValue = 0;
		}
		else
		{
			for (int j = 0; j < text3.Length; j++)
			{
				int num2 = text3[j] - 48;
				if (num2 < 0 || num2 > 9 || (num = num * 10 + num2) > 65535)
				{
					throw new UriFormatException(System.SR.Format("net_uri_PortOutOfRange", _syntax.GetType(), text3));
				}
			}
			if (num != _info.Offset.PortValue)
			{
				if (num == _syntax.DefaultPort)
				{
					_flags &= ~Flags.NotDefaultPort;
				}
				else
				{
					_flags |= Flags.NotDefaultPort;
				}
				_flags |= Flags.PortNotCanonical | Flags.E_PortNotCanonical;
				_info.Offset.PortValue = (ushort)num;
			}
		}
		_info.Host = text;
	}

	internal string GetParts(UriComponents P_0, UriFormat P_1)
	{
		return InternalGetComponents(P_0, P_1);
	}

	private string GetEscapedParts(UriComponents P_0)
	{
		ushort num = (ushort)(((ushort)_flags & 0x3F80) >> 6);
		if (InFact(Flags.SchemeNotCanonical))
		{
			num |= 1;
		}
		if ((P_0 & UriComponents.Path) != 0)
		{
			if (InFact(Flags.ShouldBeCompressed | Flags.FirstSlashAbsent | Flags.BackslashInPath))
			{
				num |= 0x10;
			}
			else if (IsDosPath && _string[_info.Offset.Path + SecuredPathIndex - 1] == '|')
			{
				num |= 0x10;
			}
		}
		if (((ushort)P_0 & num) == 0)
		{
			string uriPartsFromUserString = GetUriPartsFromUserString(P_0);
			if (uriPartsFromUserString != null)
			{
				return uriPartsFromUserString;
			}
		}
		return ReCreateParts(P_0, num, UriFormat.UriEscaped);
	}

	private string GetUnescapedParts(UriComponents P_0, UriFormat P_1)
	{
		ushort num = (ushort)((ushort)_flags & 0x7F);
		if ((P_0 & UriComponents.Path) != 0)
		{
			if ((_flags & (Flags.ShouldBeCompressed | Flags.FirstSlashAbsent | Flags.BackslashInPath)) != Flags.Zero)
			{
				num |= 0x10;
			}
			else if (IsDosPath && _string[_info.Offset.Path + SecuredPathIndex - 1] == '|')
			{
				num |= 0x10;
			}
		}
		if (((ushort)P_0 & num) == 0)
		{
			string uriPartsFromUserString = GetUriPartsFromUserString(P_0);
			if (uriPartsFromUserString != null)
			{
				return uriPartsFromUserString;
			}
		}
		return ReCreateParts(P_0, num, P_1);
	}

	private string ReCreateParts(UriComponents P_0, ushort P_1, UriFormat P_2)
	{
		EnsureHostString(false);
		string text = _string;
		System.Text.ValueStringBuilder valueStringBuilder;
		if (text.Length <= 512)
		{
			Span<char> span = stackalloc char[512];
			valueStringBuilder = new System.Text.ValueStringBuilder(span);
		}
		else
		{
			valueStringBuilder = new System.Text.ValueStringBuilder(text.Length);
		}
		System.Text.ValueStringBuilder valueStringBuilder2 = valueStringBuilder;
		if ((P_0 & UriComponents.Scheme) != 0)
		{
			valueStringBuilder2.Append(_syntax.SchemeName);
			if (P_0 != UriComponents.Scheme)
			{
				valueStringBuilder2.Append(':');
				if (InFact(Flags.AuthorityFound))
				{
					valueStringBuilder2.Append('/');
					valueStringBuilder2.Append('/');
				}
			}
		}
		ReadOnlySpan<char> readOnlySpan2;
		if ((P_0 & UriComponents.UserInfo) != 0 && InFact(Flags.HasUserInfo))
		{
			ReadOnlySpan<char> readOnlySpan = text.AsSpan(_info.Offset.User, _info.Offset.Host - _info.Offset.User);
			if ((P_1 & 2) != 0)
			{
				switch (P_2)
				{
				case UriFormat.UriEscaped:
					if (NotAny(Flags.UserEscaped))
					{
						System.UriHelper.EscapeString(readOnlySpan, ref valueStringBuilder2, true, '?', '#');
					}
					else
					{
						valueStringBuilder2.Append(readOnlySpan);
					}
					break;
				case UriFormat.SafeUnescaped:
					readOnlySpan2 = readOnlySpan;
					System.UriHelper.UnescapeString(readOnlySpan2.Slice(0, readOnlySpan2.Length - 1), ref valueStringBuilder2, '@', '/', '\\', InFact(Flags.UserEscaped) ? System.UnescapeMode.Unescape : System.UnescapeMode.EscapeUnescape, _syntax, false);
					valueStringBuilder2.Append('@');
					break;
				case UriFormat.Unescaped:
					System.UriHelper.UnescapeString(readOnlySpan, ref valueStringBuilder2, '\uffff', '\uffff', '\uffff', System.UnescapeMode.Unescape | System.UnescapeMode.UnescapeAll, _syntax, false);
					break;
				default:
					valueStringBuilder2.Append(readOnlySpan);
					break;
				}
			}
			else
			{
				valueStringBuilder2.Append(readOnlySpan);
			}
			if (P_0 == UriComponents.UserInfo)
			{
				valueStringBuilder2.Length--;
			}
		}
		if ((P_0 & UriComponents.Host) != 0)
		{
			string text2 = _info.Host;
			if (text2.Length != 0)
			{
				System.UnescapeMode unescapeMode = ((P_2 != UriFormat.UriEscaped && HostType == Flags.BasicHostType && (P_1 & 4) != 0) ? ((P_2 == UriFormat.Unescaped) ? (System.UnescapeMode.Unescape | System.UnescapeMode.UnescapeAll) : (InFact(Flags.UserEscaped) ? System.UnescapeMode.Unescape : System.UnescapeMode.EscapeUnescape)) : System.UnescapeMode.CopyOnly);
				Span<char> span = stackalloc char[512];
				System.Text.ValueStringBuilder valueStringBuilder3 = new System.Text.ValueStringBuilder(span);
				if ((P_0 & UriComponents.NormalizedHost) != 0)
				{
					text2 = System.UriHelper.StripBidiControlCharacters(text2, text2);
					if (!System.DomainNameHelper.TryGetUnicodeEquivalent(text2, ref valueStringBuilder3))
					{
						valueStringBuilder3.Length = 0;
					}
				}
				System.UriHelper.UnescapeString((valueStringBuilder3.Length == 0) ? ((ReadOnlySpan<char>)text2) : valueStringBuilder3.AsSpan(), ref valueStringBuilder2, '/', '?', '#', unescapeMode, _syntax, false);
				valueStringBuilder3.Dispose();
				if ((P_0 & UriComponents.SerializationInfoString) != 0 && HostType == Flags.IPv6HostType && _info.ScopeId != null)
				{
					valueStringBuilder2.Length--;
					valueStringBuilder2.Append(_info.ScopeId);
					valueStringBuilder2.Append(']');
				}
			}
		}
		if ((P_0 & UriComponents.Port) != 0 && (InFact(Flags.NotDefaultPort) || ((P_0 & UriComponents.StrongPort) != 0 && _syntax.DefaultPort != -1)))
		{
			valueStringBuilder2.Append(':');
			ref ushort portValue = ref _info.Offset.PortValue;
			Span<char> span2 = valueStringBuilder2.AppendSpan(5);
			readOnlySpan2 = default(ReadOnlySpan<char>);
			int num;
			bool flag = portValue.TryFormat(span2, out num, readOnlySpan2);
			valueStringBuilder2.Length -= 5 - num;
		}
		if ((P_0 & UriComponents.Path) != 0)
		{
			GetCanonicalPath(ref valueStringBuilder2, P_2);
			if (P_0 == UriComponents.Path)
			{
				int num2 = ((InFact(Flags.AuthorityFound) && valueStringBuilder2.Length != 0 && valueStringBuilder2[0] == '/') ? 1 : 0);
				readOnlySpan2 = valueStringBuilder2.AsSpan(num2);
				string result = readOnlySpan2.ToString();
				valueStringBuilder2.Dispose();
				return result;
			}
		}
		if ((P_0 & UriComponents.Query) != 0 && _info.Offset.Query < _info.Offset.Fragment)
		{
			int num3 = _info.Offset.Query + 1;
			if (P_0 != UriComponents.Query)
			{
				valueStringBuilder2.Append('?');
			}
			System.UnescapeMode unescapeMode2 = System.UnescapeMode.CopyOnly;
			if ((P_1 & 0x20) != 0)
			{
				if (P_2 == UriFormat.UriEscaped)
				{
					if (NotAny(Flags.UserEscaped))
					{
						System.UriHelper.EscapeString(text.AsSpan(num3, _info.Offset.Fragment - num3), ref valueStringBuilder2, true, '#');
						goto IL_04bf;
					}
				}
				else
				{
					unescapeMode2 = P_2 switch
					{
						(UriFormat)32767 => (System.UnescapeMode)((InFact(Flags.UserEscaped) ? 2 : 3) | 4), 
						UriFormat.Unescaped => System.UnescapeMode.Unescape | System.UnescapeMode.UnescapeAll, 
						_ => InFact(Flags.UserEscaped) ? System.UnescapeMode.Unescape : System.UnescapeMode.EscapeUnescape, 
					};
				}
			}
			System.UriHelper.UnescapeString(text, num3, _info.Offset.Fragment, ref valueStringBuilder2, '#', '\uffff', '\uffff', unescapeMode2, _syntax, true);
		}
		goto IL_04bf;
		IL_04bf:
		if ((P_0 & UriComponents.Fragment) != 0 && _info.Offset.Fragment < _info.Offset.End)
		{
			int num4 = _info.Offset.Fragment + 1;
			if (P_0 != UriComponents.Fragment)
			{
				valueStringBuilder2.Append('#');
			}
			System.UnescapeMode unescapeMode3 = System.UnescapeMode.CopyOnly;
			if ((P_1 & 0x40) != 0)
			{
				if (P_2 == UriFormat.UriEscaped)
				{
					if (NotAny(Flags.UserEscaped))
					{
						System.UriHelper.EscapeString(text.AsSpan(num4, _info.Offset.End - num4), ref valueStringBuilder2, true);
						goto IL_05c2;
					}
				}
				else
				{
					unescapeMode3 = P_2 switch
					{
						(UriFormat)32767 => (System.UnescapeMode)((InFact(Flags.UserEscaped) ? 2 : 3) | 4), 
						UriFormat.Unescaped => System.UnescapeMode.Unescape | System.UnescapeMode.UnescapeAll, 
						_ => InFact(Flags.UserEscaped) ? System.UnescapeMode.Unescape : System.UnescapeMode.EscapeUnescape, 
					};
				}
			}
			System.UriHelper.UnescapeString(text, num4, _info.Offset.End, ref valueStringBuilder2, '#', '\uffff', '\uffff', unescapeMode3, _syntax, false);
		}
		goto IL_05c2;
		IL_05c2:
		return valueStringBuilder2.ToString();
	}

	private string GetUriPartsFromUserString(UriComponents P_0)
	{
		switch (P_0 & ~UriComponents.KeepDelimiter)
		{
		case UriComponents.SchemeAndServer:
			if (!InFact(Flags.HasUserInfo))
			{
				return _string.Substring(_info.Offset.Scheme, _info.Offset.Path - _info.Offset.Scheme);
			}
			return string.Concat(_string.AsSpan(_info.Offset.Scheme, _info.Offset.User - _info.Offset.Scheme), _string.AsSpan(_info.Offset.Host, _info.Offset.Path - _info.Offset.Host));
		case UriComponents.HostAndPort:
			if (InFact(Flags.HasUserInfo))
			{
				if (InFact(Flags.NotDefaultPort) || _syntax.DefaultPort == -1)
				{
					return _string.Substring(_info.Offset.Host, _info.Offset.Path - _info.Offset.Host);
				}
				return string.Concat(_string.AsSpan(_info.Offset.Host, _info.Offset.Path - _info.Offset.Host), ":", _info.Offset.PortValue.ToString(CultureInfo.InvariantCulture));
			}
			goto case UriComponents.StrongAuthority;
		case UriComponents.AbsoluteUri:
			if (_info.Offset.Scheme == 0 && _info.Offset.End == _string.Length)
			{
				return _string;
			}
			return _string.Substring(_info.Offset.Scheme, _info.Offset.End - _info.Offset.Scheme);
		case UriComponents.HttpRequestUrl:
			if (InFact(Flags.HasUserInfo))
			{
				return string.Concat(_string.AsSpan(_info.Offset.Scheme, _info.Offset.User - _info.Offset.Scheme), _string.AsSpan(_info.Offset.Host, _info.Offset.Fragment - _info.Offset.Host));
			}
			if (_info.Offset.Scheme == 0 && _info.Offset.Fragment == _string.Length)
			{
				return _string;
			}
			return _string.Substring(_info.Offset.Scheme, _info.Offset.Fragment - _info.Offset.Scheme);
		case UriComponents.SchemeAndServer | UriComponents.UserInfo:
			return _string.Substring(_info.Offset.Scheme, _info.Offset.Path - _info.Offset.Scheme);
		case UriComponents.HttpRequestUrl | UriComponents.UserInfo:
			if (_info.Offset.Scheme == 0 && _info.Offset.Fragment == _string.Length)
			{
				return _string;
			}
			return _string.Substring(_info.Offset.Scheme, _info.Offset.Fragment - _info.Offset.Scheme);
		case UriComponents.Scheme:
			if (P_0 != UriComponents.Scheme)
			{
				return _string.Substring(_info.Offset.Scheme, _info.Offset.User - _info.Offset.Scheme);
			}
			return _syntax.SchemeName;
		case UriComponents.Host:
		{
			int num2 = _info.Offset.Path;
			if (InFact(Flags.PortNotCanonical | Flags.NotDefaultPort))
			{
				while (_string[--num2] != ':')
				{
				}
			}
			if (num2 - _info.Offset.Host != 0)
			{
				return _string.Substring(_info.Offset.Host, num2 - _info.Offset.Host);
			}
			return string.Empty;
		}
		case UriComponents.Path:
		{
			int num = ((P_0 != UriComponents.Path || !InFact(Flags.AuthorityFound) || _info.Offset.End <= _info.Offset.Path || _string[_info.Offset.Path] != '/') ? _info.Offset.Path : (_info.Offset.Path + 1));
			if (num >= _info.Offset.Query)
			{
				return string.Empty;
			}
			return _string.Substring(num, _info.Offset.Query - num);
		}
		case UriComponents.Query:
		{
			int num = ((P_0 != UriComponents.Query) ? _info.Offset.Query : (_info.Offset.Query + 1));
			if (num >= _info.Offset.Fragment)
			{
				return string.Empty;
			}
			return _string.Substring(num, _info.Offset.Fragment - num);
		}
		case UriComponents.Fragment:
		{
			int num = ((P_0 != UriComponents.Fragment) ? _info.Offset.Fragment : (_info.Offset.Fragment + 1));
			if (num >= _info.Offset.End)
			{
				return string.Empty;
			}
			return _string.Substring(num, _info.Offset.End - num);
		}
		case UriComponents.UserInfo | UriComponents.Host | UriComponents.Port:
			if (_info.Offset.Path - _info.Offset.User != 0)
			{
				return _string.Substring(_info.Offset.User, _info.Offset.Path - _info.Offset.User);
			}
			return string.Empty;
		case UriComponents.StrongAuthority:
			if (!InFact(Flags.NotDefaultPort) && _syntax.DefaultPort != -1)
			{
				return string.Concat(_string.AsSpan(_info.Offset.User, _info.Offset.Path - _info.Offset.User), ":", _info.Offset.PortValue.ToString(CultureInfo.InvariantCulture));
			}
			goto case UriComponents.UserInfo | UriComponents.Host | UriComponents.Port;
		case UriComponents.PathAndQuery:
			return _string.Substring(_info.Offset.Path, _info.Offset.Fragment - _info.Offset.Path);
		case UriComponents.HttpRequestUrl | UriComponents.Fragment:
			if (InFact(Flags.HasUserInfo))
			{
				return string.Concat(_string.AsSpan(_info.Offset.Scheme, _info.Offset.User - _info.Offset.Scheme), _string.AsSpan(_info.Offset.Host, _info.Offset.End - _info.Offset.Host));
			}
			if (_info.Offset.Scheme == 0 && _info.Offset.End == _string.Length)
			{
				return _string;
			}
			return _string.Substring(_info.Offset.Scheme, _info.Offset.End - _info.Offset.Scheme);
		case UriComponents.PathAndQuery | UriComponents.Fragment:
			return _string.Substring(_info.Offset.Path, _info.Offset.End - _info.Offset.Path);
		case UriComponents.UserInfo:
		{
			if (NotAny(Flags.HasUserInfo))
			{
				return string.Empty;
			}
			int num = ((P_0 != UriComponents.UserInfo) ? _info.Offset.Host : (_info.Offset.Host - 1));
			if (_info.Offset.User >= num)
			{
				return string.Empty;
			}
			return _string.Substring(_info.Offset.User, num - _info.Offset.User);
		}
		default:
			return null;
		}
	}

	private static void GetLengthWithoutTrailingSpaces(string P_0, ref int P_1, int P_2)
	{
		int num = P_1;
		while (num > P_2 && System.UriHelper.IsLWS(P_0[num - 1]))
		{
			num--;
		}
		P_1 = num;
	}

	private unsafe void ParseRemaining()
	{
		EnsureUriInfo();
		Flags flags = Flags.Zero;
		if (!UserDrivenParsing)
		{
			bool flag = (_flags & (Flags.HasUnicode | Flags.RestUnicodeNormalized)) == Flags.HasUnicode;
			int scheme = _info.Offset.Scheme;
			int length = _string.Length;
			Check check = Check.None;
			System.UriSyntaxFlags flags2 = _syntax.Flags;
			fixed (char* ptr = _string)
			{
				GetLengthWithoutTrailingSpaces(_string, ref length, scheme);
				if (IsImplicitFile)
				{
					flags |= Flags.SchemeNotCanonical;
				}
				else
				{
					string schemeName = _syntax.SchemeName;
					int i;
					for (i = 0; i < schemeName.Length; i++)
					{
						if (schemeName[i] != ptr[scheme + i])
						{
							flags |= Flags.SchemeNotCanonical;
						}
					}
					if ((_flags & Flags.AuthorityFound) != Flags.Zero && (scheme + i + 3 >= length || ptr[scheme + i + 1] != '/' || ptr[scheme + i + 2] != '/'))
					{
						flags |= Flags.SchemeNotCanonical;
					}
				}
				if ((_flags & Flags.HasUserInfo) != Flags.Zero)
				{
					scheme = _info.Offset.User;
					check = CheckCanonical(ptr, ref scheme, _info.Offset.Host, '@');
					if ((check & Check.DisplayCanonical) == 0)
					{
						flags |= Flags.UserNotCanonical;
					}
					if ((check & (Check.EscapedCanonical | Check.BackslashInPath)) != Check.EscapedCanonical)
					{
						flags |= Flags.E_UserNotCanonical;
					}
					if (IriParsing && (check & (Check.EscapedCanonical | Check.DisplayCanonical | Check.BackslashInPath | Check.NotIriCanonical | Check.FoundNonAscii)) == (Check.DisplayCanonical | Check.FoundNonAscii))
					{
						flags |= Flags.UserIriCanonical;
					}
				}
			}
			scheme = _info.Offset.Path;
			int num = _info.Offset.Path;
			if (flag)
			{
				if (IsFile && !IsUncPath)
				{
					if (IsImplicitFile)
					{
						_string = string.Empty;
					}
					else
					{
						_string = _syntax.SchemeName + SchemeDelimiter;
					}
				}
				_info.Offset.Path = (ushort)_string.Length;
				scheme = _info.Offset.Path;
			}
			if (DisablePathAndQueryCanonicalization)
			{
				if (flag)
				{
					_string += _originalUnicodeString.Substring(num);
				}
				string text = _string;
				if (IsImplicitFile || (flags2 & System.UriSyntaxFlags.MayHaveQuery) == 0)
				{
					scheme = text.Length;
				}
				else
				{
					scheme = text.IndexOf('?');
					if (scheme == -1)
					{
						scheme = text.Length;
					}
				}
				_info.Offset.Query = (ushort)scheme;
				_info.Offset.Fragment = (ushort)text.Length;
				_info.Offset.End = (ushort)text.Length;
			}
			else
			{
				if (flag)
				{
					int num2 = num;
					if (IsImplicitFile || (flags2 & (System.UriSyntaxFlags.MayHaveQuery | System.UriSyntaxFlags.MayHaveFragment)) == 0)
					{
						num = _originalUnicodeString.Length;
					}
					else
					{
						ReadOnlySpan<char> readOnlySpan = _originalUnicodeString.AsSpan(num);
						int num3 = ((!_syntax.InFact(System.UriSyntaxFlags.MayHaveQuery)) ? readOnlySpan.IndexOf('#') : ((!_syntax.InFact(System.UriSyntaxFlags.MayHaveFragment)) ? readOnlySpan.IndexOf('?') : readOnlySpan.IndexOfAny('?', '#')));
						num = ((num3 == -1) ? _originalUnicodeString.Length : (num3 + num));
					}
					_string += EscapeUnescapeIri(_originalUnicodeString, num2, num, UriComponents.Path);
					if (_string.Length > 65535)
					{
						UriFormatException exception = GetException(System.ParsingError.SizeLimit);
						throw exception;
					}
					length = _string.Length;
					if (_string == _originalUnicodeString)
					{
						GetLengthWithoutTrailingSpaces(_string, ref length, scheme);
					}
				}
				fixed (char* ptr2 = _string)
				{
					check = ((!IsImplicitFile && (flags2 & (System.UriSyntaxFlags.MayHaveQuery | System.UriSyntaxFlags.MayHaveFragment)) != System.UriSyntaxFlags.None) ? CheckCanonical(ptr2, ref scheme, length, ((flags2 & System.UriSyntaxFlags.MayHaveQuery) != System.UriSyntaxFlags.None) ? '?' : (_syntax.InFact(System.UriSyntaxFlags.MayHaveFragment) ? '#' : '\ufffe')) : CheckCanonical(ptr2, ref scheme, length, '\uffff'));
					if ((_flags & Flags.AuthorityFound) != Flags.Zero && (flags2 & System.UriSyntaxFlags.PathIsRooted) != System.UriSyntaxFlags.None && (_info.Offset.Path == length || (ptr2[(int)_info.Offset.Path] != '/' && ptr2[(int)_info.Offset.Path] != '\\')))
					{
						flags |= Flags.FirstSlashAbsent;
					}
				}
				bool flag2 = false;
				if (IsDosPath || ((_flags & Flags.AuthorityFound) != Flags.Zero && ((flags2 & (System.UriSyntaxFlags.ConvertPathSlashes | System.UriSyntaxFlags.CompressPath)) != System.UriSyntaxFlags.None || _syntax.InFact(System.UriSyntaxFlags.UnEscapeDotsAndSlashes))))
				{
					if ((check & Check.DotSlashEscaped) != Check.None && _syntax.InFact(System.UriSyntaxFlags.UnEscapeDotsAndSlashes))
					{
						flags |= Flags.PathNotCanonical | Flags.E_PathNotCanonical;
						flag2 = true;
					}
					if ((flags2 & System.UriSyntaxFlags.ConvertPathSlashes) != System.UriSyntaxFlags.None && (check & Check.BackslashInPath) != Check.None)
					{
						flags |= Flags.PathNotCanonical | Flags.E_PathNotCanonical;
						flag2 = true;
					}
					if ((flags2 & System.UriSyntaxFlags.CompressPath) != System.UriSyntaxFlags.None && ((flags & Flags.E_PathNotCanonical) != Flags.Zero || (check & Check.DotSlashAttn) != Check.None))
					{
						flags |= Flags.ShouldBeCompressed;
					}
					if ((check & Check.BackslashInPath) != Check.None)
					{
						flags |= Flags.BackslashInPath;
					}
				}
				else if ((check & Check.BackslashInPath) != Check.None)
				{
					flags |= Flags.E_PathNotCanonical;
					flag2 = true;
				}
				if ((check & Check.DisplayCanonical) == 0 && ((_flags & Flags.ImplicitFile) == Flags.Zero || (_flags & Flags.UserEscaped) != Flags.Zero || (check & Check.ReservedFound) != Check.None))
				{
					flags |= Flags.PathNotCanonical;
					flag2 = true;
				}
				if ((_flags & Flags.ImplicitFile) != Flags.Zero && (check & (Check.EscapedCanonical | Check.ReservedFound)) != Check.None)
				{
					check &= ~Check.EscapedCanonical;
				}
				if ((check & Check.EscapedCanonical) == 0)
				{
					flags |= Flags.E_PathNotCanonical;
				}
				if (IriParsing && !flag2 && (check & (Check.EscapedCanonical | Check.DisplayCanonical | Check.NotIriCanonical | Check.FoundNonAscii)) == (Check.DisplayCanonical | Check.FoundNonAscii))
				{
					flags |= Flags.PathIriCanonical;
				}
				if (flag)
				{
					int num4 = num;
					if (num < _originalUnicodeString.Length && _originalUnicodeString[num] == '?')
					{
						if ((flags2 & System.UriSyntaxFlags.MayHaveFragment) != System.UriSyntaxFlags.None)
						{
							num++;
							int num5 = _originalUnicodeString.AsSpan(num).IndexOf('#');
							num = ((num5 == -1) ? _originalUnicodeString.Length : (num5 + num));
						}
						else
						{
							num = _originalUnicodeString.Length;
						}
						_string += EscapeUnescapeIri(_originalUnicodeString, num4, num, UriComponents.Query);
						if (_string.Length > 65535)
						{
							UriFormatException exception2 = GetException(System.ParsingError.SizeLimit);
							throw exception2;
						}
						length = _string.Length;
						if (_string == _originalUnicodeString)
						{
							GetLengthWithoutTrailingSpaces(_string, ref length, scheme);
						}
					}
				}
				_info.Offset.Query = (ushort)scheme;
				fixed (char* ptr3 = _string)
				{
					if (scheme < length && ptr3[scheme] == '?')
					{
						scheme++;
						check = CheckCanonical(ptr3, ref scheme, length, ((flags2 & System.UriSyntaxFlags.MayHaveFragment) != System.UriSyntaxFlags.None) ? '#' : '\ufffe');
						if ((check & Check.DisplayCanonical) == 0)
						{
							flags |= Flags.QueryNotCanonical;
						}
						if ((check & (Check.EscapedCanonical | Check.BackslashInPath)) != Check.EscapedCanonical)
						{
							flags |= Flags.E_QueryNotCanonical;
						}
						if (IriParsing && (check & (Check.EscapedCanonical | Check.DisplayCanonical | Check.BackslashInPath | Check.NotIriCanonical | Check.FoundNonAscii)) == (Check.DisplayCanonical | Check.FoundNonAscii))
						{
							flags |= Flags.QueryIriCanonical;
						}
					}
				}
				if (flag)
				{
					int num6 = num;
					if (num < _originalUnicodeString.Length && _originalUnicodeString[num] == '#')
					{
						num = _originalUnicodeString.Length;
						_string += EscapeUnescapeIri(_originalUnicodeString, num6, num, UriComponents.Fragment);
						if (_string.Length > 65535)
						{
							UriFormatException exception3 = GetException(System.ParsingError.SizeLimit);
							throw exception3;
						}
						length = _string.Length;
						GetLengthWithoutTrailingSpaces(_string, ref length, scheme);
					}
				}
				_info.Offset.Fragment = (ushort)scheme;
				fixed (char* ptr4 = _string)
				{
					if (scheme < length && ptr4[scheme] == '#')
					{
						scheme++;
						check = CheckCanonical(ptr4, ref scheme, length, '\ufffe');
						if ((check & Check.DisplayCanonical) == 0)
						{
							flags |= Flags.FragmentNotCanonical;
						}
						if ((check & (Check.EscapedCanonical | Check.BackslashInPath)) != Check.EscapedCanonical)
						{
							flags |= Flags.E_FragmentNotCanonical;
						}
						if (IriParsing && (check & (Check.EscapedCanonical | Check.DisplayCanonical | Check.BackslashInPath | Check.NotIriCanonical | Check.FoundNonAscii)) == (Check.DisplayCanonical | Check.FoundNonAscii))
						{
							flags |= Flags.FragmentIriCanonical;
						}
					}
				}
				_info.Offset.End = (ushort)scheme;
			}
		}
		flags |= Flags.AllUriInfoSet | Flags.RestUnicodeNormalized;
		InterlockedSetFlags(flags);
	}

	private unsafe static int ParseSchemeCheckImplicitFile(char* P_0, int P_1, ref System.ParsingError P_2, ref Flags P_3, ref UriParser P_4)
	{
		int i;
		for (i = 0; i < P_1 && System.UriHelper.IsLWS(P_0[i]); i++)
		{
		}
		_ = 0;
		if (i < P_1 && P_0[i] == '/' && (i + 1 == P_1 || (P_0[i + 1] != '/' && P_0[i + 1] != '\\')))
		{
			P_3 |= Flags.AuthorityFound | Flags.ImplicitFile | Flags.UnixPath;
			P_4 = UriParser.UnixFileUri;
			return i;
		}
		int j;
		for (j = i; j < P_1 && P_0[j] != ':'; j++)
		{
		}
		_ = 4;
		if (j != P_1 && j >= i + 2 && CheckKnownSchemes((long*)(P_0 + i), j - i, ref P_4))
		{
			return j + 1;
		}
		if (i + 2 >= P_1 || j == i)
		{
			P_2 = System.ParsingError.BadFormat;
			return 0;
		}
		char c;
		if ((c = P_0[i + 1]) == ':' || c == '|')
		{
			if (char.IsAsciiLetter(P_0[i]))
			{
				if ((c = P_0[i + 2]) == '\\' || c == '/')
				{
					P_3 |= Flags.AuthorityFound | Flags.DosPath | Flags.ImplicitFile;
					P_4 = UriParser.FileUri;
					return i;
				}
				P_2 = System.ParsingError.MustRootedPath;
				return 0;
			}
			if (c == ':')
			{
				P_2 = System.ParsingError.BadScheme;
			}
			else
			{
				P_2 = System.ParsingError.BadFormat;
			}
			return 0;
		}
		if ((c = P_0[i]) == '/' || c == '\\')
		{
			if ((c = P_0[i + 1]) == '\\' || c == '/')
			{
				P_3 |= Flags.AuthorityFound | Flags.UncPath | Flags.ImplicitFile;
				P_4 = UriParser.FileUri;
				for (i += 2; i < P_1; i++)
				{
					if ((c = P_0[i]) != '/' && c != '\\')
					{
						break;
					}
				}
				return i;
			}
			P_2 = System.ParsingError.BadFormat;
			return 0;
		}
		if (j == P_1)
		{
			P_2 = System.ParsingError.BadFormat;
			return 0;
		}
		P_2 = CheckSchemeSyntax(new ReadOnlySpan<char>(P_0 + i, j - i), ref P_4);
		if (P_2 != System.ParsingError.None)
		{
			return 0;
		}
		return j + 1;
	}

	private unsafe static bool CheckKnownSchemes(long* P_0, int P_1, ref UriParser P_2)
	{
		if (P_1 == 2)
		{
			if (((int)(*P_0) | 0x200020) == 7536759)
			{
				P_2 = UriParser.WsUri;
				return true;
			}
			return false;
		}
		switch (*P_0 | 0x20002000200020L)
		{
		case 31525695615402088L:
			switch (P_1)
			{
			case 4:
				P_2 = UriParser.HttpUri;
				return true;
			case 5:
				if ((((ushort*)P_0)[4] | 0x20) == 115)
				{
					P_2 = UriParser.HttpsUri;
					return true;
				}
				break;
			}
			break;
		case 16326042577993847L:
			if (P_1 == 3)
			{
				P_2 = UriParser.WssUri;
				return true;
			}
			break;
		case 28429436511125606L:
			if (P_1 == 4)
			{
				P_2 = UriParser.FileUri;
				return true;
			}
			break;
		case 16326029693157478L:
			if (P_1 == 3)
			{
				P_2 = UriParser.FtpUri;
				return true;
			}
			break;
		case 32370133429452910L:
			if (P_1 == 4)
			{
				P_2 = UriParser.NewsUri;
				return true;
			}
			break;
		case 31525695615008878L:
			if (P_1 == 4)
			{
				P_2 = UriParser.NntpUri;
				return true;
			}
			break;
		case 28147948650299509L:
			if (P_1 == 4)
			{
				P_2 = UriParser.UuidUri;
				return true;
			}
			break;
		case 29273878621519975L:
			if (P_1 == 6 && (((int*)P_0)[2] | 0x200020) == 7471205)
			{
				P_2 = UriParser.GopherUri;
				return true;
			}
			break;
		case 30399748462674029L:
			if (P_1 == 6 && (((int*)P_0)[2] | 0x200020) == 7274612)
			{
				P_2 = UriParser.MailToUri;
				return true;
			}
			break;
		case 30962711301259380L:
			if (P_1 == 6 && (((int*)P_0)[2] | 0x200020) == 7602277)
			{
				P_2 = UriParser.TelnetUri;
				return true;
			}
			break;
		case 12948347151515758L:
			if (P_1 == 8 && (P_0[1] | 0x20002000200020L) == 28429453690994800L)
			{
				P_2 = UriParser.NetPipeUri;
				return true;
			}
			if (P_1 == 7 && (P_0[1] | 0x20002000200020L) == 16326029692043380L)
			{
				P_2 = UriParser.NetTcpUri;
				return true;
			}
			break;
		case 31525614009974892L:
			if (P_1 == 4)
			{
				P_2 = UriParser.LdapUri;
				return true;
			}
			break;
		}
		return false;
	}

	private unsafe static System.ParsingError CheckSchemeSyntax(ReadOnlySpan<char> P_0, ref UriParser P_1)
	{
		if (P_0.Length == 0)
		{
			return System.ParsingError.BadScheme;
		}
		char c = P_0[0];
		if (char.IsAsciiLetterUpper(c))
		{
			c = (char)(c | 0x20);
		}
		else if (!char.IsAsciiLetterLower(c))
		{
			return System.ParsingError.BadScheme;
		}
		switch (P_0.Length)
		{
		case 2:
			if (30579 == (((uint)c << 8) | ToLowerCaseAscii(P_0[1])))
			{
				P_1 = UriParser.WsUri;
				return System.ParsingError.None;
			}
			break;
		case 3:
			switch ((int)(((uint)c << 16) | ((uint)ToLowerCaseAscii(P_0[1]) << 8) | ToLowerCaseAscii(P_0[2])))
			{
			case 6714480:
				P_1 = UriParser.FtpUri;
				return System.ParsingError.None;
			case 7828339:
				P_1 = UriParser.WssUri;
				return System.ParsingError.None;
			}
			break;
		case 4:
			switch ((int)(((uint)c << 24) | ((uint)ToLowerCaseAscii(P_0[1]) << 16) | ((uint)ToLowerCaseAscii(P_0[2]) << 8) | ToLowerCaseAscii(P_0[3])))
			{
			case 1752462448:
				P_1 = UriParser.HttpUri;
				return System.ParsingError.None;
			case 1718185061:
				P_1 = UriParser.FileUri;
				return System.ParsingError.None;
			}
			break;
		case 5:
			if (1752462448 == (((uint)c << 24) | ((uint)ToLowerCaseAscii(P_0[1]) << 16) | ((uint)ToLowerCaseAscii(P_0[2]) << 8) | ToLowerCaseAscii(P_0[3])) && ToLowerCaseAscii(P_0[4]) == 's')
			{
				P_1 = UriParser.HttpsUri;
				return System.ParsingError.None;
			}
			break;
		case 6:
			if (1835100524 == (((uint)c << 24) | ((uint)ToLowerCaseAscii(P_0[1]) << 16) | ((uint)ToLowerCaseAscii(P_0[2]) << 8) | ToLowerCaseAscii(P_0[3])) && ToLowerCaseAscii(P_0[4]) == 't' && ToLowerCaseAscii(P_0[5]) == 'o')
			{
				P_1 = UriParser.MailToUri;
				return System.ParsingError.None;
			}
			break;
		}
		for (int i = 1; i < P_0.Length; i++)
		{
			char c2 = P_0[i];
			if (!char.IsAsciiLetterOrDigit(c2) && c2 != '+' && c2 != '-' && c2 != '.')
			{
				return System.ParsingError.BadScheme;
			}
		}
		if (P_0.Length > 1024)
		{
			return System.ParsingError.SchemeLimit;
		}
		string text;
		fixed (char* ptr = P_0)
		{
			text = string.Create(P_0.Length, ((nint)ptr, P_0.Length), delegate(Span<char> span, (nint ip, int length) tuple)
			{
				int num = new ReadOnlySpan<char>((void*)tuple.ip, tuple.length).ToLowerInvariant(span);
			});
		}
		P_1 = UriParser.FindOrFetchAsUnknownV1Syntax(text);
		return System.ParsingError.None;
		static char ToLowerCaseAscii(char c3)
		{
			if (!char.IsAsciiLetterUpper(c3))
			{
				return c3;
			}
			return (char)(c3 | 0x20);
		}
	}

	private unsafe int CheckAuthorityHelper(char* P_0, int P_1, int P_2, ref System.ParsingError P_3, ref Flags P_4, UriParser P_5, ref string P_6)
	{
		int i = P_2;
		int num = P_1;
		int j = P_1;
		P_6 = null;
		bool flag = false;
		bool flag2 = IriParsingStatic(P_5);
		bool flag3 = (P_4 & Flags.HasUnicode) != 0;
		bool flag4 = flag3 && (P_4 & Flags.HostUnicodeNormalized) == 0;
		System.UriSyntaxFlags flags = P_5.Flags;
		if (flag4)
		{
			P_6 = _originalUnicodeString.Substring(0, num);
		}
		char c;
		if (P_1 == P_2 || (c = P_0[P_1]) == '/' || (c == '\\' && StaticIsFile(P_5)) || c == '#' || c == '?')
		{
			if (P_5.InFact(System.UriSyntaxFlags.AllowEmptyHost))
			{
				P_4 &= ~Flags.UncPath;
				if (StaticInFact(P_4, Flags.ImplicitFile))
				{
					P_3 = System.ParsingError.BadHostName;
				}
				else
				{
					P_4 |= Flags.BasicHostType;
				}
			}
			else
			{
				P_3 = System.ParsingError.BadHostName;
			}
			if (flag4)
			{
				P_4 |= Flags.HostUnicodeNormalized;
			}
			return P_1;
		}
		string text = null;
		if ((flags & System.UriSyntaxFlags.MayHaveUserInfo) != System.UriSyntaxFlags.None)
		{
			for (; j < i; j++)
			{
				if (j == i - 1 || P_0[j] == '?' || P_0[j] == '#' || P_0[j] == '\\' || P_0[j] == '/')
				{
					j = P_1;
					break;
				}
				if (P_0[j] != '@')
				{
					continue;
				}
				P_4 |= Flags.HasUserInfo;
				if (flag2)
				{
					if (flag4)
					{
						text = System.IriHelper.EscapeUnescapeIri(P_0, num, j + 1, UriComponents.UserInfo);
						P_6 += text;
						if (P_6.Length > 65535)
						{
							P_3 = System.ParsingError.SizeLimit;
							return P_1;
						}
					}
					else
					{
						text = new string(P_0, num, j - num + 1);
					}
				}
				j++;
				c = P_0[j];
				break;
			}
		}
		bool flag5 = (flags & System.UriSyntaxFlags.SimpleUserSyntax) == 0;
		if (c == '[' && P_5.InFact(System.UriSyntaxFlags.AllowIPv6Host) && System.IPv6AddressHelper.IsValid(P_0, j + 1, ref i))
		{
			P_4 |= Flags.IPv6HostType;
			if (flag4)
			{
				P_6 += new string(P_0, j, i - j);
				P_4 |= Flags.HostUnicodeNormalized;
				flag = true;
			}
		}
		else if (char.IsAsciiDigit(c) && P_5.InFact(System.UriSyntaxFlags.AllowIPv4Host) && System.IPv4AddressHelper.IsValid(P_0, j, ref i, false, StaticNotAny(P_4, Flags.ImplicitFile), P_5.InFact(System.UriSyntaxFlags.V1_UnknownUri)))
		{
			P_4 |= Flags.IPv4HostType;
			if (flag4)
			{
				P_6 += new string(P_0, j, i - j);
				P_4 |= Flags.HostUnicodeNormalized;
				flag = true;
			}
		}
		else if ((flags & System.UriSyntaxFlags.AllowDnsHost) != System.UriSyntaxFlags.None && !flag2 && System.DomainNameHelper.IsValid(P_0, j, ref i, ref flag5, StaticNotAny(P_4, Flags.ImplicitFile)))
		{
			P_4 |= Flags.DnsHostType;
			if (!flag5)
			{
				P_4 |= Flags.CanonicalDnsHost;
			}
		}
		else if ((flags & System.UriSyntaxFlags.AllowDnsHost) != System.UriSyntaxFlags.None && (flag4 || P_5.InFact(System.UriSyntaxFlags.AllowIdn)) && System.DomainNameHelper.IsValidByIri(P_0, j, ref i, ref flag5, StaticNotAny(P_4, Flags.ImplicitFile)))
		{
			CheckAuthorityHelperHandleDnsIri(P_0, j, i, flag3, ref P_4, ref flag, ref P_6, ref P_3);
		}
		else if ((flags & System.UriSyntaxFlags.AllowUncHost) != System.UriSyntaxFlags.None && System.UncNameHelper.IsValid(P_0, j, ref i, StaticNotAny(P_4, Flags.ImplicitFile)) && i - j <= 256)
		{
			P_4 |= Flags.UncHostType;
			if (flag4)
			{
				P_6 += new string(P_0, j, i - j);
				P_4 |= Flags.HostUnicodeNormalized;
				flag = true;
			}
		}
		if (i < P_2 && P_0[i] == '\\' && (P_4 & Flags.HostTypeMask) != Flags.Zero && !StaticIsFile(P_5))
		{
			if (P_5.InFact(System.UriSyntaxFlags.V1_UnknownUri))
			{
				P_3 = System.ParsingError.BadHostName;
				P_4 |= Flags.HostTypeMask;
				return i;
			}
			P_4 &= ~Flags.HostTypeMask;
		}
		else if (i < P_2 && P_0[i] == ':')
		{
			if (P_5.InFact(System.UriSyntaxFlags.MayHavePort))
			{
				int num2 = 0;
				int num3 = i;
				for (P_1 = i + 1; P_1 < P_2; P_1++)
				{
					int num4 = P_0[P_1] - 48;
					switch (num4)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
						if ((num2 = num2 * 10 + num4) <= 65535)
						{
							continue;
						}
						break;
					default:
						if (P_5.InFact(System.UriSyntaxFlags.AllowAnyOtherHost) && P_5.NotAny(System.UriSyntaxFlags.V1_UnknownUri))
						{
							P_4 &= ~Flags.HostTypeMask;
							break;
						}
						P_3 = System.ParsingError.BadPort;
						return P_1;
					case -13:
					case -1:
					case 15:
						break;
					}
					break;
				}
				if (num2 > 65535)
				{
					if (!P_5.InFact(System.UriSyntaxFlags.AllowAnyOtherHost))
					{
						P_3 = System.ParsingError.BadPort;
						return P_1;
					}
					P_4 &= ~Flags.HostTypeMask;
				}
				if (flag3 && flag)
				{
					P_6 += new string(P_0, num3, P_1 - num3);
				}
			}
			else
			{
				P_4 &= ~Flags.HostTypeMask;
			}
		}
		if ((P_4 & Flags.HostTypeMask) == Flags.Zero)
		{
			P_4 &= ~Flags.HasUserInfo;
			if (P_5.InFact(System.UriSyntaxFlags.AllowAnyOtherHost))
			{
				P_4 |= Flags.BasicHostType;
				for (i = P_1; i < P_2 && P_0[i] != '/' && P_0[i] != '?' && P_0[i] != '#'; i++)
				{
				}
				if (flag4)
				{
					string text2 = new string(P_0, num, i - num);
					try
					{
						P_6 += text2.Normalize(NormalizationForm.FormC);
					}
					catch (ArgumentException)
					{
						P_3 = System.ParsingError.BadHostName;
					}
					P_4 |= Flags.HostUnicodeNormalized;
				}
			}
			else if (P_5.InFact(System.UriSyntaxFlags.V1_UnknownUri))
			{
				bool flag6 = false;
				int num5 = P_1;
				for (i = P_1; i < P_2 && (!flag6 || (P_0[i] != '/' && P_0[i] != '?' && P_0[i] != '#')); i++)
				{
					if (i < P_1 + 2 && P_0[i] == '.')
					{
						flag6 = true;
						continue;
					}
					P_3 = System.ParsingError.BadHostName;
					P_4 |= Flags.HostTypeMask;
					return P_1;
				}
				P_4 |= Flags.BasicHostType;
				if (flag4)
				{
					string text3 = new string(P_0, num5, i - num5);
					try
					{
						P_6 += text3.Normalize(NormalizationForm.FormC);
					}
					catch (ArgumentException)
					{
						P_3 = System.ParsingError.BadFormat;
						return P_1;
					}
					P_4 |= Flags.HostUnicodeNormalized;
				}
			}
			else if (P_5.InFact(System.UriSyntaxFlags.MustHaveAuthority) || P_5.InFact(System.UriSyntaxFlags.MailToLikeUri))
			{
				P_3 = System.ParsingError.BadHostName;
				P_4 |= Flags.HostTypeMask;
				return P_1;
			}
		}
		return i;
	}

	private unsafe static void CheckAuthorityHelperHandleDnsIri(char* P_0, int P_1, int P_2, bool P_3, ref Flags P_4, ref bool P_5, ref string P_6, ref System.ParsingError P_7)
	{
		P_4 |= Flags.DnsHostType;
		if (P_3)
		{
			string text = System.UriHelper.StripBidiControlCharacters(new ReadOnlySpan<char>(P_0 + P_1, P_2 - P_1));
			try
			{
				P_6 += text.Normalize(NormalizationForm.FormC);
			}
			catch (ArgumentException)
			{
				P_7 = System.ParsingError.BadHostName;
			}
			P_5 = true;
		}
		P_4 |= Flags.HostUnicodeNormalized;
	}

	private unsafe Check CheckCanonical(char* P_0, ref int P_1, int P_2, char P_3)
	{
		Check check = Check.None;
		bool flag = false;
		bool flag2 = false;
		bool iriParsing = IriParsing;
		int i;
		for (i = P_1; i < P_2; i++)
		{
			char c = P_0[i];
			if (c <= '\u001f' || (c >= '\u007f' && c <= '\u009f'))
			{
				flag = true;
				flag2 = true;
				check |= Check.ReservedFound;
				continue;
			}
			if (c > '~')
			{
				if (iriParsing)
				{
					bool flag3 = false;
					check |= Check.FoundNonAscii;
					if (char.IsHighSurrogate(c))
					{
						if (i + 1 < P_2)
						{
							flag3 = System.IriHelper.CheckIriUnicodeRange(c, P_0[i + 1], out var _, true);
						}
					}
					else
					{
						flag3 = System.IriHelper.CheckIriUnicodeRange(c, true);
					}
					if (!flag3)
					{
						check |= Check.NotIriCanonical;
					}
				}
				if (!flag)
				{
					flag = true;
				}
				continue;
			}
			if (c == P_3 || (P_3 == '?' && c == '#' && _syntax != null && _syntax.InFact(System.UriSyntaxFlags.MayHaveFragment)))
			{
				break;
			}
			if (c == '?')
			{
				if (IsImplicitFile || (_syntax != null && !_syntax.InFact(System.UriSyntaxFlags.MayHaveQuery) && P_3 != '\ufffe'))
				{
					check |= Check.ReservedFound;
					flag2 = true;
					flag = true;
				}
				continue;
			}
			if (c == '#')
			{
				flag = true;
				if (IsImplicitFile || (_syntax != null && !_syntax.InFact(System.UriSyntaxFlags.MayHaveFragment)))
				{
					check |= Check.ReservedFound;
					flag2 = true;
				}
				continue;
			}
			if (c == '/' || c == '\\')
			{
				if ((check & Check.BackslashInPath) == 0 && c == '\\')
				{
					check |= Check.BackslashInPath;
				}
				if ((check & Check.DotSlashAttn) == 0 && i + 1 != P_2 && (P_0[i + 1] == '/' || P_0[i + 1] == '\\'))
				{
					check |= Check.DotSlashAttn;
				}
				continue;
			}
			if (c == '.')
			{
				if (((check & Check.DotSlashAttn) == 0 && i + 1 == P_2) || P_0[i + 1] == '.' || P_0[i + 1] == '/' || P_0[i + 1] == '\\' || P_0[i + 1] == '?' || P_0[i + 1] == '#')
				{
					check |= Check.DotSlashAttn;
				}
				continue;
			}
			if ((c > '"' || c == '!') && (c < '[' || c > '^'))
			{
				switch (c)
				{
				case '<':
				case '>':
				case '`':
					break;
				case '{':
				case '|':
				case '}':
					flag = true;
					continue;
				default:
					if (c != '%')
					{
						continue;
					}
					if (!flag2)
					{
						flag2 = true;
					}
					if (i + 2 < P_2 && (c = System.UriHelper.DecodeHexChars(P_0[i + 1], P_0[i + 2])) != '\uffff')
					{
						if (c == '.' || c == '/' || c == '\\')
						{
							check |= Check.DotSlashEscaped;
						}
						i += 2;
					}
					else if (!flag)
					{
						flag = true;
					}
					continue;
				}
			}
			if (!flag)
			{
				flag = true;
			}
			if ((_flags & Flags.HasUnicode) != Flags.Zero)
			{
				check |= Check.NotIriCanonical;
			}
		}
		if (flag2)
		{
			if (!flag)
			{
				check |= Check.EscapedCanonical;
			}
		}
		else
		{
			check |= Check.DisplayCanonical;
			if (!flag)
			{
				check |= Check.EscapedCanonical;
			}
		}
		P_1 = i;
		return check;
	}

	private unsafe void GetCanonicalPath(ref System.Text.ValueStringBuilder P_0, UriFormat P_1)
	{
		if (InFact(Flags.FirstSlashAbsent))
		{
			P_0.Append('/');
		}
		if (_info.Offset.Path == _info.Offset.Query)
		{
			return;
		}
		int length = P_0.Length;
		int securedPathIndex = SecuredPathIndex;
		if (P_1 == UriFormat.UriEscaped)
		{
			if (InFact(Flags.ShouldBeCompressed))
			{
				P_0.Append(_string.AsSpan(_info.Offset.Path, _info.Offset.Query - _info.Offset.Path));
				if (_syntax.InFact(System.UriSyntaxFlags.UnEscapeDotsAndSlashes) && InFact(Flags.PathNotCanonical) && !IsImplicitFile)
				{
					fixed (char* ptr = P_0)
					{
						int length2 = P_0.Length;
						UnescapeOnly(ptr, length, ref length2, '.', '/', _syntax.InFact(System.UriSyntaxFlags.ConvertPathSlashes) ? '\\' : '\uffff');
						P_0.Length = length2;
					}
				}
			}
			else if (InFact(Flags.E_PathNotCanonical) && NotAny(Flags.UserEscaped))
			{
				ReadOnlySpan<char> readOnlySpan = _string;
				if (securedPathIndex != 0 && readOnlySpan[securedPathIndex + _info.Offset.Path - 1] == '|')
				{
					char[] array = readOnlySpan.ToArray();
					array[securedPathIndex + _info.Offset.Path - 1] = ':';
					readOnlySpan = array;
				}
				System.UriHelper.EscapeString(readOnlySpan.Slice(_info.Offset.Path, _info.Offset.Query - _info.Offset.Path), ref P_0, !IsImplicitFile, '?', '#');
			}
			else
			{
				P_0.Append(_string.AsSpan(_info.Offset.Path, _info.Offset.Query - _info.Offset.Path));
			}
			_ = 0;
			if (InFact(Flags.BackslashInPath) && _syntax.NotAny(System.UriSyntaxFlags.ConvertPathSlashes) && _syntax.InFact(System.UriSyntaxFlags.FileLikeUri) && !IsImplicitFile)
			{
				Span<char> span = stackalloc char[512];
				System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(span);
				valueStringBuilder.Append(P_0.AsSpan(length, P_0.Length - length));
				P_0.Length = length;
				ReadOnlySpan<char> readOnlySpan2 = MemoryMarshal.CreateReadOnlySpan(ref valueStringBuilder.GetPinnableReference(), valueStringBuilder.Length);
				System.UriHelper.EscapeString(readOnlySpan2, ref P_0, true, '\\');
				length = P_0.Length;
				valueStringBuilder.Dispose();
			}
		}
		else
		{
			P_0.Append(_string.AsSpan(_info.Offset.Path, _info.Offset.Query - _info.Offset.Path));
			if (InFact(Flags.ShouldBeCompressed) && _syntax.InFact(System.UriSyntaxFlags.UnEscapeDotsAndSlashes) && InFact(Flags.PathNotCanonical) && !IsImplicitFile)
			{
				fixed (char* ptr2 = P_0)
				{
					int length3 = P_0.Length;
					UnescapeOnly(ptr2, length, ref length3, '.', '/', _syntax.InFact(System.UriSyntaxFlags.ConvertPathSlashes) ? '\\' : '\uffff');
					P_0.Length = length3;
				}
			}
		}
		int num = length + securedPathIndex;
		if (securedPathIndex != 0 && P_0[num - 1] == '|')
		{
			P_0[num - 1] = ':';
		}
		if (InFact(Flags.ShouldBeCompressed) && P_0.Length - num > 0)
		{
			P_0.Length = num + Compress(P_0.RawChars.Slice(num, P_0.Length - num), _syntax);
			if (P_0[length] == '\\')
			{
				P_0[length] = '/';
			}
			if (P_1 == UriFormat.UriEscaped && NotAny(Flags.UserEscaped) && InFact(Flags.E_PathNotCanonical))
			{
				Span<char> span = stackalloc char[512];
				System.Text.ValueStringBuilder valueStringBuilder2 = new System.Text.ValueStringBuilder(span);
				valueStringBuilder2.Append(P_0.AsSpan(length, P_0.Length - length));
				P_0.Length = length;
				ReadOnlySpan<char> readOnlySpan3 = MemoryMarshal.CreateReadOnlySpan(ref valueStringBuilder2.GetPinnableReference(), valueStringBuilder2.Length);
				System.UriHelper.EscapeString(readOnlySpan3, ref P_0, !IsImplicitFile, '?', '#');
				length = P_0.Length;
				valueStringBuilder2.Dispose();
			}
		}
		if (P_1 == UriFormat.UriEscaped || !InFact(Flags.PathNotCanonical))
		{
			return;
		}
		System.UnescapeMode unescapeMode;
		switch (P_1)
		{
		case (UriFormat)32767:
			unescapeMode = (System.UnescapeMode)((InFact(Flags.UserEscaped) ? 2 : 3) | 4);
			if (IsImplicitFile)
			{
				unescapeMode &= ~System.UnescapeMode.Unescape;
			}
			break;
		case UriFormat.Unescaped:
			unescapeMode = ((!IsImplicitFile) ? (System.UnescapeMode.Unescape | System.UnescapeMode.UnescapeAll) : System.UnescapeMode.CopyOnly);
			break;
		default:
			unescapeMode = (InFact(Flags.UserEscaped) ? System.UnescapeMode.Unescape : System.UnescapeMode.EscapeUnescape);
			if (IsImplicitFile)
			{
				unescapeMode &= ~System.UnescapeMode.Unescape;
			}
			break;
		}
		if (unescapeMode != System.UnescapeMode.CopyOnly)
		{
			Span<char> span = stackalloc char[512];
			System.Text.ValueStringBuilder valueStringBuilder3 = new System.Text.ValueStringBuilder(span);
			valueStringBuilder3.Append(P_0.AsSpan(length, P_0.Length - length));
			P_0.Length = length;
			fixed (char* ptr3 = valueStringBuilder3)
			{
				System.UriHelper.UnescapeString(ptr3, 0, valueStringBuilder3.Length, ref P_0, '?', '#', '\uffff', unescapeMode, _syntax, false);
			}
			valueStringBuilder3.Dispose();
		}
	}

	private unsafe static void UnescapeOnly(char* P_0, int P_1, ref int P_2, char P_3, char P_4, char P_5)
	{
		if (P_2 - P_1 < 3)
		{
			return;
		}
		char* ptr = P_0 + P_2 - 2;
		P_0 += P_1;
		char* ptr2 = null;
		while (P_0 < ptr)
		{
			if (*(P_0++) != '%')
			{
				continue;
			}
			char c = System.UriHelper.DecodeHexChars(*(P_0++), *(P_0++));
			if (c != P_3 && c != P_4 && c != P_5)
			{
				continue;
			}
			ptr2 = P_0 - 2;
			*(ptr2 - 1) = c;
			while (P_0 < ptr)
			{
				if ((*(ptr2++) = *(P_0++)) == '%')
				{
					c = System.UriHelper.DecodeHexChars(*(ptr2++) = *(P_0++), *(ptr2++) = *(P_0++));
					if (c == P_3 || c == P_4 || c == P_5)
					{
						ptr2 -= 2;
						*(ptr2 - 1) = c;
					}
				}
			}
			break;
		}
		ptr += 2;
		if (ptr2 == null)
		{
			return;
		}
		if (P_0 == ptr)
		{
			P_2 -= (int)(P_0 - ptr2);
			return;
		}
		*(ptr2++) = *(P_0++);
		if (P_0 == ptr)
		{
			P_2 -= (int)(P_0 - ptr2);
			return;
		}
		*(ptr2++) = *(P_0++);
		P_2 -= (int)(P_0 - ptr2);
	}

	private static void Compress(char[] P_0, int P_1, ref int P_2, UriParser P_3)
	{
		P_2 = P_1 + Compress(P_0.AsSpan(P_1, P_2 - P_1), P_3);
	}

	private static int Compress(Span<char> P_0, UriParser P_1)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		for (int num5 = P_0.Length - 1; num5 >= 0; num5--)
		{
			char c = P_0[num5];
			if (c == '\\' && P_1.InFact(System.UriSyntaxFlags.ConvertPathSlashes))
			{
				c = (P_0[num5] = '/');
			}
			if (c == '/')
			{
				num++;
			}
			else
			{
				if (num > 1)
				{
					num2 = num5 + 1;
				}
				num = 0;
			}
			if (c == '.')
			{
				num3++;
				continue;
			}
			if (num3 != 0)
			{
				if ((!P_1.NotAny(System.UriSyntaxFlags.CanonicalizeAsFilePath) || (num3 <= 2 && c == '/')) && c == '/' && (num2 == num5 + num3 + 1 || (num2 == 0 && num5 + num3 + 1 == P_0.Length)) && num3 <= 2)
				{
					num2 = num5 + 1 + num3 + ((num2 != 0) ? 1 : 0);
					P_0.Slice(num2).CopyTo(P_0.Slice(num5 + 1));
					P_0 = P_0.Slice(0, P_0.Length - (num2 - num5 - 1));
					num2 = num5;
					if (num3 == 2)
					{
						num4++;
					}
					num3 = 0;
					continue;
				}
				num3 = 0;
			}
			if (c == '/')
			{
				if (num4 != 0)
				{
					num4--;
					P_0.Slice(num2 + 1).CopyTo(P_0.Slice(num5 + 1));
					P_0 = P_0.Slice(0, P_0.Length - (num2 - num5));
				}
				num2 = num5;
			}
		}
		if (P_0.Length != 0 && P_1.InFact(System.UriSyntaxFlags.CanonicalizeAsFilePath) && num <= 1)
		{
			if (num4 != 0 && P_0[0] != '/')
			{
				num2++;
				P_0.Slice(num2).CopyTo(P_0);
				return P_0.Length - num2;
			}
			if (num3 != 0 && (num2 == num3 || (num2 == 0 && num3 == P_0.Length)))
			{
				num3 += ((num2 != 0) ? 1 : 0);
				P_0.Slice(num3).CopyTo(P_0);
				return P_0.Length - num3;
			}
		}
		return P_0.Length;
	}

	private static string CombineUri(Uri P_0, string P_1, UriFormat P_2)
	{
		char c = P_1[0];
		if (P_0.IsDosPath && (c == '/' || c == '\\') && (P_1.Length == 1 || (P_1[1] != '/' && P_1[1] != '\\')))
		{
			int num = P_0.OriginalString.IndexOf(':');
			if (P_0.IsImplicitFile)
			{
				return string.Concat(P_0.OriginalString.AsSpan(0, num + 1), P_1);
			}
			num = P_0.OriginalString.IndexOf(':', num + 1);
			return string.Concat(P_0.OriginalString.AsSpan(0, num + 1), P_1);
		}
		if (StaticIsFile(P_0.Syntax) && (c == '\\' || c == '/'))
		{
			if (P_1.Length >= 2 && (P_1[1] == '\\' || P_1[1] == '/'))
			{
				if (!P_0.IsImplicitFile)
				{
					return "file:" + P_1;
				}
				return P_1;
			}
			if (P_0.IsUnc)
			{
				ReadOnlySpan<char> readOnlySpan = P_0.GetParts(UriComponents.Path | UriComponents.KeepDelimiter, UriFormat.Unescaped);
				int num2 = readOnlySpan.Slice(1).IndexOf('/');
				if (num2 >= 0)
				{
					readOnlySpan = readOnlySpan.Slice(0, num2 + 1);
				}
				if (P_0.IsImplicitFile)
				{
					return string.Concat("\\\\", P_0.GetParts(UriComponents.Host, UriFormat.Unescaped), readOnlySpan, P_1);
				}
				return string.Concat("file://", P_0.GetParts(UriComponents.Host, P_2), readOnlySpan, P_1);
			}
			return "file://" + P_1;
		}
		bool flag = P_0.Syntax.InFact(System.UriSyntaxFlags.ConvertPathSlashes);
		string text;
		if (c == '/' || (c == '\\' && flag))
		{
			if (P_1.Length >= 2 && P_1[1] == '/')
			{
				return P_0.Scheme + ":" + P_1;
			}
			text = ((P_0.HostType != Flags.IPv6HostType) ? P_0.GetParts(UriComponents.SchemeAndServer | UriComponents.UserInfo, P_2) : $"{P_0.GetParts(UriComponents.Scheme | UriComponents.UserInfo, P_2)}[{P_0.DnsSafeHost}]{P_0.GetParts(UriComponents.Port | UriComponents.KeepDelimiter, P_2)}");
			if (!flag || c != '\\')
			{
				return text + P_1;
			}
			return string.Concat(text, "/", P_1.AsSpan(1));
		}
		text = P_0.GetParts(UriComponents.Path | UriComponents.KeepDelimiter, P_0.IsImplicitFile ? UriFormat.Unescaped : P_2);
		int num3 = text.Length;
		char[] array = new char[num3 + P_1.Length];
		if (num3 > 0)
		{
			text.CopyTo(0, array, 0, num3);
			while (num3 > 0)
			{
				if (array[--num3] == '/')
				{
					num3++;
					break;
				}
			}
		}
		P_1.CopyTo(0, array, num3, P_1.Length);
		c = (P_0.Syntax.InFact(System.UriSyntaxFlags.MayHaveQuery) ? '?' : '\uffff');
		char c2 = ((!P_0.IsImplicitFile && P_0.Syntax.InFact(System.UriSyntaxFlags.MayHaveFragment)) ? '#' : '\uffff');
		ReadOnlySpan<char> readOnlySpan2 = string.Empty;
		if (c != '\uffff' || c2 != '\uffff')
		{
			int i;
			for (i = 0; i < P_1.Length && array[num3 + i] != c && array[num3 + i] != c2; i++)
			{
			}
			if (i == 0)
			{
				readOnlySpan2 = P_1;
			}
			else if (i < P_1.Length)
			{
				readOnlySpan2 = P_1.AsSpan(i);
			}
			num3 += i;
		}
		else
		{
			num3 += P_1.Length;
		}
		if (P_0.HostType == Flags.IPv6HostType)
		{
			text = ((!P_0.IsImplicitFile) ? (P_0.GetParts(UriComponents.Scheme | UriComponents.UserInfo, P_2) + "[" + P_0.DnsSafeHost + "]" + P_0.GetParts(UriComponents.Port | UriComponents.KeepDelimiter, P_2)) : ("\\\\[" + P_0.DnsSafeHost + "]"));
		}
		else if (P_0.IsImplicitFile)
		{
			if (P_0.IsDosPath)
			{
				Compress(array, 3, ref num3, P_0.Syntax);
				return string.Concat(array.AsSpan(1, num3 - 1), readOnlySpan2);
			}
			_ = 0;
			text = ((!P_0.IsUnixPath) ? ("\\\\" + P_0.GetParts(UriComponents.Host, UriFormat.Unescaped)) : P_0.GetParts(UriComponents.Host, UriFormat.Unescaped));
		}
		else
		{
			text = P_0.GetParts(UriComponents.SchemeAndServer | UriComponents.UserInfo, P_2);
		}
		Compress(array, P_0.SecuredPathIndex, ref num3, P_0.Syntax);
		return string.Concat(text, array.AsSpan(0, num3), readOnlySpan2);
	}

	private void CreateThis(string P_0, bool P_1, UriKind P_2, in UriCreationOptions P_3 = default(UriCreationOptions))
	{
		if (P_2 < UriKind.RelativeOrAbsolute || P_2 > UriKind.Relative)
		{
			throw new ArgumentException(System.SR.Format("net_uri_InvalidUriKind", P_2));
		}
		_string = P_0 ?? string.Empty;
		if (P_1)
		{
			_flags |= Flags.UserEscaped;
		}
		if (P_3.DangerousDisablePathAndQueryCanonicalization)
		{
			_flags |= Flags.DisablePathAndQueryCanonicalization;
		}
		System.ParsingError parsingError = ParseScheme(_string, ref _flags, ref _syntax);
		InitializeUri(parsingError, P_2, out var ex);
		if (ex != null)
		{
			throw ex;
		}
	}

	private void InitializeUri(System.ParsingError P_0, UriKind P_1, out UriFormatException P_2)
	{
		if (P_0 == System.ParsingError.None)
		{
			if (IsImplicitFile)
			{
				if (NotAny(Flags.DosPath) && P_1 != UriKind.Absolute)
				{
					if (P_1 != UriKind.Relative && (_string.Length < 2 || (_string[0] == '\\' && _string[1] == '\\')))
					{
						_ = 0;
						if (!InFact(Flags.UnixPath))
						{
							goto IL_0086;
						}
					}
					_syntax = null;
					_flags &= Flags.UserEscaped;
					P_2 = null;
					return;
				}
				goto IL_0086;
			}
		}
		else if (P_0 > System.ParsingError.EmptyUriString)
		{
			_string = null;
			P_2 = GetException(P_0);
			return;
		}
		goto IL_00ca;
		IL_00ca:
		bool flag = false;
		if (IriParsing && CheckForUnicodeOrEscapedUnreserved(_string))
		{
			_flags |= Flags.HasUnicode;
			flag = true;
			_originalUnicodeString = _string;
		}
		if (_syntax != null)
		{
			if (_syntax.IsSimple)
			{
				if ((P_0 = PrivateParseMinimal()) != System.ParsingError.None)
				{
					if (P_1 != UriKind.Absolute && P_0 <= System.ParsingError.EmptyUriString)
					{
						_syntax = null;
						P_2 = null;
						_flags &= Flags.UserEscaped;
						return;
					}
					P_2 = GetException(P_0);
				}
				else if (P_1 == UriKind.Relative)
				{
					P_2 = GetException(System.ParsingError.CannotCreateRelative);
				}
				else
				{
					P_2 = null;
				}
				if (flag)
				{
					try
					{
						EnsureParseRemaining();
						return;
					}
					catch (UriFormatException ex)
					{
						P_2 = ex;
						return;
					}
				}
				return;
			}
			_syntax = _syntax.InternalOnNewUri();
			_flags |= Flags.UserDrivenParsing;
			_syntax.InternalValidate(this, out P_2);
			if (P_2 != null)
			{
				if (P_1 != UriKind.Absolute && P_0 != System.ParsingError.None && P_0 <= System.ParsingError.EmptyUriString)
				{
					_syntax = null;
					P_2 = null;
					_flags &= Flags.UserEscaped;
				}
				return;
			}
			if (P_0 != System.ParsingError.None || InFact(Flags.ErrorOrParsingRecursion))
			{
				_flags = Flags.UserDrivenParsing | (_flags & Flags.UserEscaped);
			}
			else if (P_1 == UriKind.Relative)
			{
				P_2 = GetException(System.ParsingError.CannotCreateRelative);
			}
			if (flag)
			{
				try
				{
					EnsureParseRemaining();
					return;
				}
				catch (UriFormatException ex2)
				{
					P_2 = ex2;
					return;
				}
			}
		}
		else if (P_0 != System.ParsingError.None && P_1 != UriKind.Absolute && P_0 <= System.ParsingError.EmptyUriString)
		{
			P_2 = null;
			_flags &= Flags.UserEscaped | Flags.HasUnicode;
			if (flag)
			{
				_string = EscapeUnescapeIri(_originalUnicodeString, 0, _originalUnicodeString.Length, (UriComponents)0);
				_ = _string.Length;
				_ = 65535;
			}
		}
		else
		{
			_string = null;
			P_2 = GetException(P_0);
		}
		return;
		IL_0086:
		if (P_1 == UriKind.Relative && InFact(Flags.DosPath))
		{
			_syntax = null;
			_flags &= Flags.UserEscaped;
			P_2 = null;
			return;
		}
		goto IL_00ca;
	}

	private static bool CheckForUnicodeOrEscapedUnreserved(string P_0)
	{
		for (int i = 0; i < P_0.Length; i++)
		{
			char c = P_0[i];
			if (c == '%')
			{
				if ((uint)(i + 2) < (uint)P_0.Length)
				{
					char c2 = System.UriHelper.DecodeHexChars(P_0[i + 1], P_0[i + 2]);
					if (c2 >= System.UriHelper.UnreservedTable.Length || System.UriHelper.UnreservedTable[c2])
					{
						return true;
					}
					i += 2;
				}
			}
			else if (c > '\u007f')
			{
				return true;
			}
		}
		return false;
	}

	public static bool TryCreate([NotNullWhen(true)][StringSyntax("Uri", new object[] { "uriKind" })] string? P_0, UriKind P_1, [NotNullWhen(true)] out Uri? P_2)
	{
		if (P_0 == null)
		{
			P_2 = null;
			return false;
		}
		UriFormatException ex = null;
		P_2 = CreateHelper(P_0, false, P_1, ref ex, default(UriCreationOptions));
		if (ex == null)
		{
			return P_2 != null;
		}
		return false;
	}

	public string GetComponents(UriComponents P_0, UriFormat P_1)
	{
		if (DisablePathAndQueryCanonicalization && (P_0 & UriComponents.PathAndQuery) != 0)
		{
			throw new InvalidOperationException("net_uri_GetComponentsCalledWhenCanonicalizationDisabled");
		}
		return InternalGetComponents(P_0, P_1);
	}

	private string InternalGetComponents(UriComponents P_0, UriFormat P_1)
	{
		if ((P_0 & UriComponents.SerializationInfoString) != 0 && P_0 != UriComponents.SerializationInfoString)
		{
			throw new ArgumentOutOfRangeException("components", P_0, "net_uri_NotJustSerialization");
		}
		if ((P_1 & (UriFormat)(-4)) != 0)
		{
			throw new ArgumentOutOfRangeException("format");
		}
		if (IsNotAbsoluteUri)
		{
			if (P_0 == UriComponents.SerializationInfoString)
			{
				return GetRelativeSerializationString(P_1);
			}
			throw new InvalidOperationException("net_uri_NotAbsolute");
		}
		if (Syntax.IsSimple)
		{
			return GetComponentsHelper(P_0, P_1);
		}
		return Syntax.InternalGetComponents(this, P_0, P_1);
	}

	public static string UnescapeDataString(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "stringToUnescape");
		if (P_0.Length == 0)
		{
			return string.Empty;
		}
		int num = P_0.IndexOf('%');
		if (num == -1)
		{
			return P_0;
		}
		Span<char> span = stackalloc char[512];
		System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(span);
		valueStringBuilder.EnsureCapacity(P_0.Length);
		valueStringBuilder.Append(P_0.AsSpan(0, num));
		System.UriHelper.UnescapeString(P_0, num, P_0.Length, ref valueStringBuilder, '\uffff', '\uffff', '\uffff', System.UnescapeMode.Unescape | System.UnescapeMode.UnescapeAll, null, false);
		return valueStringBuilder.ToString();
	}

	internal unsafe string EscapeUnescapeIri(string P_0, int P_1, int P_2, UriComponents P_3)
	{
		fixed (char* ptr = P_0)
		{
			return System.IriHelper.EscapeUnescapeIri(ptr, P_1, P_2, P_3);
		}
	}

	private Uri(Flags P_0, UriParser P_1, string P_2)
	{
		_flags = P_0;
		_syntax = P_1;
		_string = P_2;
	}

	internal static Uri CreateHelper(string P_0, bool P_1, UriKind P_2, ref UriFormatException P_3, in UriCreationOptions P_4 = default(UriCreationOptions))
	{
		if (P_2 < UriKind.RelativeOrAbsolute || P_2 > UriKind.Relative)
		{
			throw new ArgumentException(System.SR.Format("net_uri_InvalidUriKind", P_2));
		}
		UriParser uriParser = null;
		Flags flags = Flags.Zero;
		System.ParsingError parsingError = ParseScheme(P_0, ref flags, ref uriParser);
		if (P_1)
		{
			flags |= Flags.UserEscaped;
		}
		if (P_4.DangerousDisablePathAndQueryCanonicalization)
		{
			flags |= Flags.DisablePathAndQueryCanonicalization;
		}
		if (parsingError != System.ParsingError.None)
		{
			if (P_2 != UriKind.Absolute && parsingError <= System.ParsingError.EmptyUriString)
			{
				return new Uri(flags & Flags.UserEscaped, null, P_0);
			}
			return null;
		}
		Uri uri = new Uri(flags, uriParser, P_0);
		try
		{
			uri.InitializeUri(parsingError, P_2, out P_3);
			if (P_3 == null)
			{
				return uri;
			}
			return null;
		}
		catch (UriFormatException ex)
		{
			P_3 = ex;
			return null;
		}
	}

	internal static Uri ResolveHelper(Uri P_0, Uri P_1, ref string P_2, ref bool P_3)
	{
		string text;
		if ((object)P_1 != null)
		{
			if (P_1.IsAbsoluteUri)
			{
				return P_1;
			}
			text = P_1.OriginalString;
			P_3 = P_1.UserEscaped;
		}
		else
		{
			text = string.Empty;
		}
		if (text.Length > 0 && (System.UriHelper.IsLWS(text[0]) || System.UriHelper.IsLWS(text[text.Length - 1])))
		{
			text = text.Trim(System.UriHelper.s_WSchars);
		}
		if (text.Length == 0)
		{
			P_2 = P_0.GetParts(UriComponents.AbsoluteUri, P_0.UserEscaped ? UriFormat.UriEscaped : UriFormat.SafeUnescaped);
			return null;
		}
		if (text[0] == '#' && !P_0.IsImplicitFile && P_0.Syntax.InFact(System.UriSyntaxFlags.MayHaveFragment))
		{
			P_2 = P_0.GetParts(UriComponents.HttpRequestUrl | UriComponents.UserInfo, UriFormat.UriEscaped) + text;
			return null;
		}
		if (text[0] == '?' && !P_0.IsImplicitFile && P_0.Syntax.InFact(System.UriSyntaxFlags.MayHaveQuery))
		{
			P_2 = P_0.GetParts(UriComponents.SchemeAndServer | UriComponents.UserInfo | UriComponents.Path, UriFormat.UriEscaped) + text;
			return null;
		}
		if (text.Length >= 3 && (text[1] == ':' || text[1] == '|') && char.IsAsciiLetter(text[0]) && (text[2] == '\\' || text[2] == '/'))
		{
			if (P_0.IsImplicitFile)
			{
				P_2 = text;
				return null;
			}
			if (P_0.Syntax.InFact(System.UriSyntaxFlags.AllowDOSPath))
			{
				string text2 = ((!P_0.InFact(Flags.AuthorityFound)) ? (P_0.Syntax.InFact(System.UriSyntaxFlags.PathIsRooted) ? ":/" : ":") : (P_0.Syntax.InFact(System.UriSyntaxFlags.PathIsRooted) ? ":///" : "://"));
				P_2 = P_0.Scheme + text2 + text;
				return null;
			}
		}
		GetCombinedString(P_0, text, P_3, ref P_2);
		if ((object)P_2 == P_0._string)
		{
			return P_0;
		}
		return null;
	}

	private string GetRelativeSerializationString(UriFormat P_0)
	{
		switch (P_0)
		{
		case UriFormat.UriEscaped:
			return System.UriHelper.EscapeString(_string, true, System.UriHelper.UnreservedReservedTable);
		case UriFormat.Unescaped:
			return UnescapeDataString(_string);
		case UriFormat.SafeUnescaped:
		{
			if (_string.Length == 0)
			{
				return string.Empty;
			}
			Span<char> span = stackalloc char[512];
			System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(span);
			System.UriHelper.UnescapeString(_string, ref valueStringBuilder, '\uffff', '\uffff', '\uffff', System.UnescapeMode.EscapeUnescape, null, false);
			return valueStringBuilder.ToString();
		}
		default:
			throw new ArgumentOutOfRangeException("format");
		}
	}

	internal string GetComponentsHelper(UriComponents P_0, UriFormat P_1)
	{
		if (P_0 == UriComponents.Scheme)
		{
			return _syntax.SchemeName;
		}
		if ((P_0 & UriComponents.SerializationInfoString) != 0)
		{
			P_0 |= UriComponents.AbsoluteUri;
		}
		EnsureParseRemaining();
		if ((P_0 & UriComponents.NormalizedHost) != 0)
		{
			P_0 |= UriComponents.Host;
		}
		if ((P_0 & UriComponents.Host) != 0)
		{
			EnsureHostString(true);
		}
		if (P_0 == UriComponents.Port || P_0 == UriComponents.StrongPort)
		{
			if ((_flags & Flags.NotDefaultPort) != Flags.Zero || (P_0 == UriComponents.StrongPort && _syntax.DefaultPort != -1))
			{
				return _info.Offset.PortValue.ToString(CultureInfo.InvariantCulture);
			}
			return string.Empty;
		}
		if ((P_0 & UriComponents.StrongPort) != 0)
		{
			P_0 |= UriComponents.Port;
		}
		if (P_0 == UriComponents.Host && (P_1 == UriFormat.UriEscaped || (_flags & (Flags.HostNotCanonical | Flags.E_HostNotCanonical)) == Flags.Zero))
		{
			EnsureHostString(false);
			return _info.Host;
		}
		switch (P_1)
		{
		case UriFormat.UriEscaped:
			return GetEscapedParts(P_0);
		case UriFormat.Unescaped:
		case UriFormat.SafeUnescaped:
		case (UriFormat)32767:
			return GetUnescapedParts(P_0, P_1);
		default:
			throw new ArgumentOutOfRangeException("uriFormat");
		}
	}

	private void CreateThisFromUri(Uri P_0)
	{
		_info = null;
		_flags = P_0._flags;
		if (InFact(Flags.MinimalUriInfoSet))
		{
			_flags &= ~(Flags.IndexMask | Flags.MinimalUriInfoSet | Flags.AllUriInfoSet);
			int num = P_0._info.Offset.Path;
			if (InFact(Flags.NotDefaultPort))
			{
				while (P_0._string[num] != ':' && num > P_0._info.Offset.Host)
				{
					num--;
				}
				if (P_0._string[num] != ':')
				{
					num = P_0._info.Offset.Path;
				}
			}
			_flags |= (Flags)num;
		}
		_syntax = P_0._syntax;
		_string = P_0._string;
		_originalUnicodeString = P_0._originalUnicodeString;
	}
}
