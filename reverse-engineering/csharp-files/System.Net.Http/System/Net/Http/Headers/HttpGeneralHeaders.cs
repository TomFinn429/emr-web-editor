namespace System.Net.Http.Headers;

internal sealed class HttpGeneralHeaders
{
	private readonly HttpHeaders _parent;

	private bool _transferEncodingChunkedSet;

	private bool _connectionCloseSet;

	public bool? ConnectionClose
	{
		get
		{
			return GetConnectionClose(_parent, this);
		}
		set
		{
			if (flag == true)
			{
				_connectionCloseSet = true;
				if (!_parent.ContainsParsedValue(KnownHeaders.Connection.Descriptor, "close"))
				{
					_parent.AddParsedValue(KnownHeaders.Connection.Descriptor, "close");
				}
			}
			else
			{
				_connectionCloseSet = flag.HasValue;
				_parent.RemoveParsedValue(KnownHeaders.Connection.Descriptor, "close");
			}
		}
	}

	public bool? TransferEncodingChunked
	{
		get
		{
			return GetTransferEncodingChunked(_parent, this);
		}
		set
		{
			if (flag == true)
			{
				_transferEncodingChunkedSet = true;
				if (!_parent.ContainsParsedValue(KnownHeaders.TransferEncoding.Descriptor, HeaderUtilities.TransferEncodingChunked))
				{
					_parent.AddParsedValue(KnownHeaders.TransferEncoding.Descriptor, HeaderUtilities.TransferEncodingChunked);
				}
			}
			else
			{
				_transferEncodingChunkedSet = flag.HasValue;
				_parent.RemoveParsedValue(KnownHeaders.TransferEncoding.Descriptor, HeaderUtilities.TransferEncodingChunked);
			}
		}
	}

	internal static bool? GetConnectionClose(HttpHeaders P_0, HttpGeneralHeaders P_1)
	{
		if (P_0.ContainsParsedValue(KnownHeaders.Connection.Descriptor, "close"))
		{
			return true;
		}
		if (P_1 != null && P_1._connectionCloseSet)
		{
			return false;
		}
		return null;
	}

	internal static bool? GetTransferEncodingChunked(HttpHeaders P_0, HttpGeneralHeaders P_1)
	{
		if (P_0.ContainsParsedValue(KnownHeaders.TransferEncoding.Descriptor, HeaderUtilities.TransferEncodingChunked))
		{
			return true;
		}
		if (P_1 != null && P_1._transferEncodingChunkedSet)
		{
			return false;
		}
		return null;
	}

	internal HttpGeneralHeaders(HttpHeaders P_0)
	{
		_parent = P_0;
	}

	internal void AddSpecialsFrom(HttpGeneralHeaders P_0)
	{
		if (!TransferEncodingChunked.HasValue)
		{
			TransferEncodingChunked = P_0.TransferEncodingChunked;
		}
		if (!ConnectionClose.HasValue)
		{
			ConnectionClose = P_0.ConnectionClose;
		}
	}
}
