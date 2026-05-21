using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[DebuggerDisplay("Count={ Count }")]
public class DetectResultForValueBindingModifiedList : List<DetectResultForValueBindingModified>
{
	public override string ToString()
	{
		if (base.Count == 0)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				DetectResultForValueBindingModified current = enumerator.Current;
				stringBuilder.AppendLine("[" + current.CurrentValue + "]=>[" + current.NewValue + "] {" + current.Binding.DataSource + "#" + current.Binding.BindingPath + "}");
			}
		}
		return stringBuilder.ToString();
	}
}
