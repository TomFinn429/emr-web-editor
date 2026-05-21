using System.Runtime.CompilerServices;
using System.Text;

namespace System.Net.Http.Headers;

internal sealed class KnownHeader
{
	[CompilerGenerated]
	private readonly string[] _003CKnownValues_003Ek__BackingField;

	[CompilerGenerated]
	private readonly byte[] _003CAsciiBytesWithColonSpace_003Ek__BackingField;

	public string Name { get; }

	public HttpHeaderParser Parser { get; }

	public HttpHeaderType HeaderType { get; }

	public HeaderDescriptor Descriptor => new HeaderDescriptor(this);

	public KnownHeader(string P_0, int? P_1 = null, int? P_2 = null)
		: this(P_0, HttpHeaderType.Custom, null, null, P_1, P_2)
	{
	}

	public KnownHeader(string P_0, HttpHeaderType P_1, HttpHeaderParser P_2, string[] P_3 = null, int? P_4 = null, int? P_5 = null)
	{
		Name = P_0;
		HeaderType = P_1;
		Parser = P_2;
		_003CKnownValues_003Ek__BackingField = P_3;
		byte[] array = new byte[P_0.Length + 2];
		int bytes = Encoding.ASCII.GetBytes(P_0, array);
		array[array.Length - 2] = 58;
		array[array.Length - 1] = 32;
		_003CAsciiBytesWithColonSpace_003Ek__BackingField = array;
	}
}
