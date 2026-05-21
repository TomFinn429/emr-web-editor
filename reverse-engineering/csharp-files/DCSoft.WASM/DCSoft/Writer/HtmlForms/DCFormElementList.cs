using System.Collections.Generic;
using System.Diagnostics;
using zzz;

namespace DCSoft.Writer.HtmlForms;

[DebuggerDisplay("Count={ Count }")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
public sealed class DCFormElementList : List<DCFormElement>
{
	public DCFormElementList z0eek(bool p0)
	{
		DCFormElementList dCFormElementList = new DCFormElementList();
		if (p0)
		{
			using List<DCFormElement>.Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				DCFormElement current = enumerator.Current;
				dCFormElementList.Add(current.z0bq(p0: false));
			}
		}
		else
		{
			dCFormElementList.AddRange(this);
		}
		return dCFormElementList;
	}
}
