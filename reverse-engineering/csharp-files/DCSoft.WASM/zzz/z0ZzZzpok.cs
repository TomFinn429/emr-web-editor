using System.Collections.Generic;
using System.Reflection;

namespace zzz;

public class z0ZzZzpok : IComparer<Assembly>
{
	public int Compare(Assembly x, Assembly y)
	{
		return string.Compare(x.FullName, y.FullName, true);
	}
}
