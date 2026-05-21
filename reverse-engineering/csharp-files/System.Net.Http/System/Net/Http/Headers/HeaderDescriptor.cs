namespace System.Net.Http.Headers;

internal readonly struct HeaderDescriptor : IEquatable<HeaderDescriptor>
{
	private readonly object _descriptor;

	public string Name
	{
		get
		{
			if (!(_descriptor is KnownHeader knownHeader))
			{
				return _descriptor as string;
			}
			return knownHeader.Name;
		}
	}

	public HttpHeaderParser Parser => (_descriptor as KnownHeader)?.Parser;

	public HttpHeaderType HeaderType
	{
		get
		{
			if (!(_descriptor is KnownHeader knownHeader))
			{
				return HttpHeaderType.Custom;
			}
			return knownHeader.HeaderType;
		}
	}

	public HeaderDescriptor(KnownHeader P_0)
	{
		_descriptor = P_0;
	}

	internal HeaderDescriptor(string P_0, bool P_1 = false)
	{
		_descriptor = P_0;
	}

	public bool Equals(HeaderDescriptor P_0)
	{
		if (_descriptor is string text)
		{
			return string.Equals(text, P_0._descriptor as string, StringComparison.OrdinalIgnoreCase);
		}
		return _descriptor == P_0._descriptor;
	}

	public override int GetHashCode()
	{
		if (!(_descriptor is KnownHeader knownHeader))
		{
			return StringComparer.OrdinalIgnoreCase.GetHashCode(_descriptor);
		}
		return knownHeader.GetHashCode();
	}

	public override bool Equals(object P_0)
	{
		throw new InvalidOperationException();
	}

	public static bool TryGet(string P_0, out HeaderDescriptor P_1)
	{
		KnownHeader knownHeader = KnownHeaders.TryGetKnownHeader(P_0);
		if (knownHeader != null)
		{
			P_1 = new HeaderDescriptor(knownHeader);
			return true;
		}
		if (!HttpRuleParser.IsToken(P_0))
		{
			P_1 = default(HeaderDescriptor);
			return false;
		}
		P_1 = new HeaderDescriptor(P_0);
		return true;
	}

	public HeaderDescriptor AsCustomHeader()
	{
		return new HeaderDescriptor(Name, true);
	}
}
