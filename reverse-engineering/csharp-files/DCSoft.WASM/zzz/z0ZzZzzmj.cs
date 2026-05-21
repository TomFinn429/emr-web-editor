using DCSoft.Writer.Dom;

namespace zzz;

internal sealed class z0ZzZzzmj : z0ZzZzcmj
{
	[z0ZzZzimj("ResetFormValue")]
	protected void z0eek_jiejie20260327142557(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5 && p1.Document.z0qnk())
		{
			p1.Document.Modified = true;
			p1.Document.z0imk().Clear();
			p1.EditorControl.z0eek(p0: false, p1: true);
			p1.Document.OnDocumentContentChanged();
			p1.Document.OnSelectionChanged();
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("ClearBuffer")]
	protected void z0rek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = true;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5 || p1.Document == null)
			{
				return;
			}
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.Document.z0nek<XTextInputFieldElement>().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)z0bpk.Current;
				if (xTextInputFieldElement.FieldSettings != null && xTextInputFieldElement.FieldSettings.z0zek() != null)
				{
					xTextInputFieldElement.FieldSettings.z0zek().z0eek(null);
				}
			}
		}
	}

	protected override z0ZzZzvmj z0qz()
	{
		z0ZzZzvmj obj = new z0ZzZzvmj();
		z0ZzZzcmj.z0rek(obj, "ClearBuffer", z0rek);
		z0ZzZzcmj.z0rek(obj, "ResetFormValue", z0eek_jiejie20260327142557);
		return obj;
	}
}
