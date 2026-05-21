using System.IO;
using System.Threading.Tasks;

namespace System.Xml;

public abstract class XmlResolver
{
	public abstract object? GetEntity(Uri P_0, string? P_1, Type? P_2);

	public virtual Task<object> GetEntityAsync(Uri P_0, string? P_1, Type? P_2)
	{
		throw new NotImplementedException();
	}

	public virtual Uri ResolveUri(Uri? P_0, string? P_1)
	{
		if (P_0 == null || (!P_0.IsAbsoluteUri && P_0.OriginalString.Length == 0))
		{
			Uri uri = new Uri(P_1, UriKind.RelativeOrAbsolute);
			if (!uri.IsAbsoluteUri && uri.OriginalString.Length > 0)
			{
				uri = new Uri(Path.GetFullPath(P_1));
			}
			return uri;
		}
		if (P_1 == null || P_1.Length == 0)
		{
			return P_0;
		}
		if (!P_0.IsAbsoluteUri)
		{
			throw new NotSupportedException("Xml_RelativeUriNotSupported");
		}
		return new Uri(P_0, P_1);
	}

	public virtual bool SupportsType(Uri P_0, Type? P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "absoluteUri");
		if (P_1 == null || P_1 == typeof(Stream))
		{
			return true;
		}
		return false;
	}
}
