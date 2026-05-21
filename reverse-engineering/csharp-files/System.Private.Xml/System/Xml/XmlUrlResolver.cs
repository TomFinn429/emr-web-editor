using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace System.Xml;

public class XmlUrlResolver : XmlResolver
{
	private ICredentials _credentials;

	private IWebProxy _proxy;

	public override object? GetEntity(Uri P_0, string? P_1, Type? P_2)
	{
		if ((object)P_2 == null || P_2 == typeof(Stream) || P_2 == typeof(object))
		{
			return XmlDownloadManager.GetStream(P_0, _credentials, _proxy);
		}
		throw new XmlException("Xml_UnsupportedClass", string.Empty);
	}

	public override Uri ResolveUri(Uri? P_0, string? P_1)
	{
		return base.ResolveUri(P_0, P_1);
	}

	public override async Task<object> GetEntityAsync(Uri P_0, string? P_1, Type? P_2)
	{
		if (P_2 == null || P_2 == typeof(Stream) || P_2 == typeof(object))
		{
			return await XmlDownloadManager.GetStreamAsync(P_0, _credentials, _proxy).ConfigureAwait(false);
		}
		throw new XmlException("Xml_UnsupportedClass", string.Empty);
	}
}
