using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions;

[DefaultMember("Item")]
public class GroupCollection
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Reset()
	{
		throw new NotSupportedException("Linked away");
	}
}
