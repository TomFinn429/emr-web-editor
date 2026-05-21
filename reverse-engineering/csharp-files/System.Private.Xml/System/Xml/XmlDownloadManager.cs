using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace System.Xml;

internal sealed class XmlDownloadManager
{
	internal static Stream GetStream(Uri P_0, ICredentials P_1, IWebProxy P_2)
	{
		if (P_0.Scheme == "file")
		{
			return new FileStream(P_0.LocalPath, FileMode.Open, FileAccess.Read, FileShare.Read, 1);
		}
		return GetNonFileStreamAsync(P_0, P_1, P_2).GetAwaiter().GetResult();
	}

	internal static Task<Stream> GetStreamAsync(Uri P_0, ICredentials P_1, IWebProxy P_2)
	{
		if (P_0.Scheme == "file")
		{
			Uri fileUri = P_0;
			return Task.Run((Func<Stream>)(() => new FileStream(fileUri.LocalPath, FileMode.Open, FileAccess.Read, FileShare.Read, 1, true)));
		}
		return GetNonFileStreamAsync(P_0, P_1, P_2);
	}

	private static async Task<Stream> GetNonFileStreamAsync(Uri P_0, ICredentials P_1, IWebProxy P_2)
	{
		HttpClientHandler httpClientHandler = new HttpClientHandler();
		using HttpClient client = new HttpClient(httpClientHandler);
		if (P_1 != null)
		{
			httpClientHandler.Credentials = P_1;
		}
		if (P_2 != null)
		{
			httpClientHandler.Proxy = P_2;
		}
		using Stream stream = await client.GetStreamAsync(P_0).ConfigureAwait(false);
		MemoryStream memoryStream = new MemoryStream();
		stream.CopyTo(memoryStream);
		memoryStream.Position = 0L;
		return memoryStream;
	}
}
