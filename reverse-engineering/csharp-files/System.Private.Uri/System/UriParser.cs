using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System;

public abstract class UriParser
{
	private sealed class BuiltInUriParser : UriParser
	{
		internal BuiltInUriParser(string P_0, int P_1, System.UriSyntaxFlags P_2)
			: base(P_2 | System.UriSyntaxFlags.SimpleUserSyntax | System.UriSyntaxFlags.BuiltInSyntax)
		{
			_scheme = P_0;
			_port = P_1;
		}
	}

	internal static readonly UriParser HttpUri = new BuiltInUriParser("http", 80, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.MustHaveAuthority | System.UriSyntaxFlags.MayHaveUserInfo | System.UriSyntaxFlags.MayHavePort | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveQuery | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.AllowUncHost | System.UriSyntaxFlags.PathIsRooted | System.UriSyntaxFlags.ConvertPathSlashes | System.UriSyntaxFlags.CompressPath | System.UriSyntaxFlags.CanonicalizeAsFilePath | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);

	internal static readonly UriParser HttpsUri = new BuiltInUriParser("https", 443, HttpUri._flags);

	internal static readonly UriParser WsUri = new BuiltInUriParser("ws", 80, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.MustHaveAuthority | System.UriSyntaxFlags.MayHaveUserInfo | System.UriSyntaxFlags.MayHavePort | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveQuery | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.AllowUncHost | System.UriSyntaxFlags.PathIsRooted | System.UriSyntaxFlags.ConvertPathSlashes | System.UriSyntaxFlags.CompressPath | System.UriSyntaxFlags.CanonicalizeAsFilePath | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);

	internal static readonly UriParser WssUri = new BuiltInUriParser("wss", 443, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.MustHaveAuthority | System.UriSyntaxFlags.MayHaveUserInfo | System.UriSyntaxFlags.MayHavePort | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveQuery | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.AllowUncHost | System.UriSyntaxFlags.PathIsRooted | System.UriSyntaxFlags.ConvertPathSlashes | System.UriSyntaxFlags.CompressPath | System.UriSyntaxFlags.CanonicalizeAsFilePath | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);

	internal static readonly UriParser FtpUri = new BuiltInUriParser("ftp", 21, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.MustHaveAuthority | System.UriSyntaxFlags.MayHaveUserInfo | System.UriSyntaxFlags.MayHavePort | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.AllowUncHost | System.UriSyntaxFlags.PathIsRooted | System.UriSyntaxFlags.ConvertPathSlashes | System.UriSyntaxFlags.CompressPath | System.UriSyntaxFlags.CanonicalizeAsFilePath | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);

	internal static readonly UriParser FileUri = new BuiltInUriParser("file", -1, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.MustHaveAuthority | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveQuery | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.AllowEmptyHost | System.UriSyntaxFlags.AllowUncHost | System.UriSyntaxFlags.FileLikeUri | System.UriSyntaxFlags.AllowDOSPath | System.UriSyntaxFlags.PathIsRooted | System.UriSyntaxFlags.ConvertPathSlashes | System.UriSyntaxFlags.CompressPath | System.UriSyntaxFlags.CanonicalizeAsFilePath | System.UriSyntaxFlags.UnEscapeDotsAndSlashes | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);

	internal static readonly UriParser UnixFileUri = new BuiltInUriParser("file", -1, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.MustHaveAuthority | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveQuery | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.AllowEmptyHost | System.UriSyntaxFlags.AllowUncHost | System.UriSyntaxFlags.FileLikeUri | System.UriSyntaxFlags.AllowDOSPath | System.UriSyntaxFlags.PathIsRooted | System.UriSyntaxFlags.CompressPath | System.UriSyntaxFlags.CanonicalizeAsFilePath | System.UriSyntaxFlags.UnEscapeDotsAndSlashes | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);

	internal static readonly UriParser GopherUri = new BuiltInUriParser("gopher", 70, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.MustHaveAuthority | System.UriSyntaxFlags.MayHaveUserInfo | System.UriSyntaxFlags.MayHavePort | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.AllowUncHost | System.UriSyntaxFlags.PathIsRooted | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);

	internal static readonly UriParser NntpUri = new BuiltInUriParser("nntp", 119, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.MustHaveAuthority | System.UriSyntaxFlags.MayHaveUserInfo | System.UriSyntaxFlags.MayHavePort | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.AllowUncHost | System.UriSyntaxFlags.PathIsRooted | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);

	internal static readonly UriParser NewsUri = new BuiltInUriParser("news", -1, System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.AllowIriParsing);

	internal static readonly UriParser MailToUri = new BuiltInUriParser("mailto", 25, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.MayHaveUserInfo | System.UriSyntaxFlags.MayHavePort | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveQuery | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.AllowEmptyHost | System.UriSyntaxFlags.AllowUncHost | System.UriSyntaxFlags.MailToLikeUri | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);

	internal static readonly UriParser UuidUri = new BuiltInUriParser("uuid", -1, NewsUri._flags);

	internal static readonly UriParser TelnetUri = new BuiltInUriParser("telnet", 23, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.MustHaveAuthority | System.UriSyntaxFlags.MayHaveUserInfo | System.UriSyntaxFlags.MayHavePort | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.AllowUncHost | System.UriSyntaxFlags.PathIsRooted | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);

	internal static readonly UriParser LdapUri = new BuiltInUriParser("ldap", 389, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.MustHaveAuthority | System.UriSyntaxFlags.MayHaveUserInfo | System.UriSyntaxFlags.MayHavePort | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveQuery | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.AllowEmptyHost | System.UriSyntaxFlags.AllowUncHost | System.UriSyntaxFlags.PathIsRooted | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);

	internal static readonly UriParser NetTcpUri = new BuiltInUriParser("net.tcp", 808, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.MustHaveAuthority | System.UriSyntaxFlags.MayHavePort | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveQuery | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.PathIsRooted | System.UriSyntaxFlags.ConvertPathSlashes | System.UriSyntaxFlags.CompressPath | System.UriSyntaxFlags.CanonicalizeAsFilePath | System.UriSyntaxFlags.UnEscapeDotsAndSlashes | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);

	internal static readonly UriParser NetPipeUri = new BuiltInUriParser("net.pipe", -1, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.MustHaveAuthority | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveQuery | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.PathIsRooted | System.UriSyntaxFlags.ConvertPathSlashes | System.UriSyntaxFlags.CompressPath | System.UriSyntaxFlags.CanonicalizeAsFilePath | System.UriSyntaxFlags.UnEscapeDotsAndSlashes | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);

	internal static readonly UriParser VsMacrosUri = new BuiltInUriParser("vsmacros", -1, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.MustHaveAuthority | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.AllowEmptyHost | System.UriSyntaxFlags.AllowUncHost | System.UriSyntaxFlags.FileLikeUri | System.UriSyntaxFlags.AllowDOSPath | System.UriSyntaxFlags.ConvertPathSlashes | System.UriSyntaxFlags.CompressPath | System.UriSyntaxFlags.CanonicalizeAsFilePath | System.UriSyntaxFlags.UnEscapeDotsAndSlashes | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);

	private static readonly Hashtable s_table = new Hashtable(16)
	{
		{ HttpUri.SchemeName, HttpUri },
		{ HttpsUri.SchemeName, HttpsUri },
		{ WsUri.SchemeName, WsUri },
		{ WssUri.SchemeName, WssUri },
		{ FtpUri.SchemeName, FtpUri },
		{ FileUri.SchemeName, FileUri },
		{ GopherUri.SchemeName, GopherUri },
		{ NntpUri.SchemeName, NntpUri },
		{ NewsUri.SchemeName, NewsUri },
		{ MailToUri.SchemeName, MailToUri },
		{ UuidUri.SchemeName, UuidUri },
		{ TelnetUri.SchemeName, TelnetUri },
		{ LdapUri.SchemeName, LdapUri },
		{ NetTcpUri.SchemeName, NetTcpUri },
		{ NetPipeUri.SchemeName, NetPipeUri },
		{ VsMacrosUri.SchemeName, VsMacrosUri }
	};

	private static Hashtable s_tempTable = new Hashtable(25);

	private System.UriSyntaxFlags _flags;

	private int _port;

	private string _scheme;

	internal string SchemeName => _scheme;

	internal int DefaultPort => _port;

	internal System.UriSyntaxFlags Flags => _flags;

	internal bool IsSimple => InFact(System.UriSyntaxFlags.SimpleUserSyntax);

	protected virtual UriParser OnNewUri()
	{
		return this;
	}

	protected virtual void InitializeAndValidate(Uri P_0, out UriFormatException? P_1)
	{
		if (P_0._syntax == null)
		{
			throw new InvalidOperationException("net_uri_NotAbsolute");
		}
		if (P_0._syntax != this)
		{
			throw new InvalidOperationException(System.SR.Format("net_uri_UserDrivenParsing", P_0._syntax.GetType()));
		}
		ulong num = Interlocked.Or(ref Unsafe.As<Uri.Flags, ulong>(ref P_0._flags), 4611686018427387904uL);
		if ((num & 0x4000000000000000L) != 0L)
		{
			throw new InvalidOperationException("net_uri_InitializeCalledAlreadyOrTooLate");
		}
		P_1 = P_0.ParseMinimal();
	}

	protected virtual string? Resolve(Uri P_0, Uri? P_1, out UriFormatException? P_2)
	{
		if (P_0.UserDrivenParsing)
		{
			throw new InvalidOperationException(System.SR.Format("net_uri_UserDrivenParsing", GetType()));
		}
		if (!P_0.IsAbsoluteUri)
		{
			throw new InvalidOperationException("net_uri_NotAbsolute");
		}
		string result = null;
		bool flag = false;
		P_2 = null;
		Uri uri = Uri.ResolveHelper(P_0, P_1, ref result, ref flag);
		if (uri != null)
		{
			return uri.OriginalString;
		}
		return result;
	}

	protected virtual string GetComponents(Uri P_0, UriComponents P_1, UriFormat P_2)
	{
		if ((P_1 & UriComponents.SerializationInfoString) != 0 && P_1 != UriComponents.SerializationInfoString)
		{
			throw new ArgumentOutOfRangeException("components", P_1, "net_uri_NotJustSerialization");
		}
		if ((P_2 & (UriFormat)(-4)) != 0)
		{
			throw new ArgumentOutOfRangeException("format");
		}
		if (P_0.UserDrivenParsing)
		{
			throw new InvalidOperationException(System.SR.Format("net_uri_UserDrivenParsing", GetType()));
		}
		if (!P_0.IsAbsoluteUri)
		{
			throw new InvalidOperationException("net_uri_NotAbsolute");
		}
		if (P_0.DisablePathAndQueryCanonicalization && (P_1 & UriComponents.PathAndQuery) != 0)
		{
			throw new InvalidOperationException("net_uri_GetComponentsCalledWhenCanonicalizationDisabled");
		}
		return P_0.GetComponentsHelper(P_1, P_2);
	}

	internal bool NotAny(System.UriSyntaxFlags P_0)
	{
		return IsFullMatch(P_0, System.UriSyntaxFlags.None);
	}

	internal bool InFact(System.UriSyntaxFlags P_0)
	{
		return !IsFullMatch(P_0, System.UriSyntaxFlags.None);
	}

	internal bool IsAllSet(System.UriSyntaxFlags P_0)
	{
		return IsFullMatch(P_0, P_0);
	}

	private bool IsFullMatch(System.UriSyntaxFlags P_0, System.UriSyntaxFlags P_1)
	{
		return (_flags & P_0) == P_1;
	}

	internal UriParser(System.UriSyntaxFlags P_0)
	{
		_flags = P_0;
		_scheme = string.Empty;
	}

	internal static UriParser FindOrFetchAsUnknownV1Syntax(string P_0)
	{
		UriParser uriParser = (UriParser)s_table[P_0];
		if (uriParser != null)
		{
			return uriParser;
		}
		uriParser = (UriParser)s_tempTable[P_0];
		if (uriParser != null)
		{
			return uriParser;
		}
		lock (s_table)
		{
			if (s_tempTable.Count >= 512)
			{
				s_tempTable = new Hashtable(25);
			}
			uriParser = new BuiltInUriParser(P_0, -1, System.UriSyntaxFlags.AllowAnInternetHost | System.UriSyntaxFlags.OptionalAuthority | System.UriSyntaxFlags.MayHaveUserInfo | System.UriSyntaxFlags.MayHavePort | System.UriSyntaxFlags.MayHavePath | System.UriSyntaxFlags.MayHaveQuery | System.UriSyntaxFlags.MayHaveFragment | System.UriSyntaxFlags.AllowEmptyHost | System.UriSyntaxFlags.AllowUncHost | System.UriSyntaxFlags.V1_UnknownUri | System.UriSyntaxFlags.AllowDOSPath | System.UriSyntaxFlags.PathIsRooted | System.UriSyntaxFlags.ConvertPathSlashes | System.UriSyntaxFlags.CompressPath | System.UriSyntaxFlags.AllowIdn | System.UriSyntaxFlags.AllowIriParsing);
			s_tempTable[P_0] = uriParser;
			return uriParser;
		}
	}

	internal UriParser InternalOnNewUri()
	{
		UriParser uriParser = OnNewUri();
		if (this != uriParser)
		{
			uriParser._scheme = _scheme;
			uriParser._port = _port;
			uriParser._flags = _flags;
		}
		return uriParser;
	}

	internal void InternalValidate(Uri P_0, out UriFormatException P_1)
	{
		InitializeAndValidate(P_0, out P_1);
		Interlocked.Or(ref Unsafe.As<Uri.Flags, ulong>(ref P_0._flags), 4611686018427387904uL);
	}

	internal string InternalResolve(Uri P_0, Uri P_1, out UriFormatException P_2)
	{
		return Resolve(P_0, P_1, out P_2);
	}

	internal string InternalGetComponents(Uri P_0, UriComponents P_1, UriFormat P_2)
	{
		return GetComponents(P_0, P_1, P_2);
	}
}
