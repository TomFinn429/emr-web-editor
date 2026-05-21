using System;
using DCSoft.WASM;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

internal sealed class z0ZzZzdnj : z0ZzZzcmj
{
	protected override z0ZzZzvmj z0qz()
	{
		z0ZzZzvmj obj = new z0ZzZzvmj();
		z0ZzZzcmj.z0rek(obj, "ClearValueValidateResult", z0yek);
		z0ZzZzcmj.z0rek(obj, "DocumentValueValidate", z0eek);
		z0ZzZzcmj.z0rek(obj, "DocumentValueValidateWithCreateDocumentComments", z0tek);
		z0ZzZzcmj.z0rek(obj, "GCCollect", z0rek);
		return obj;
	}

	[z0ZzZzimj("DocumentValueValidate")]
	private void z0eek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.Document.z0pu_jiejie20260327142557().ValueValidateMode != DocumentValueValidateMode.None;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			z0ZzZzylh z0ZzZzylh2 = (z0ZzZzylh)(p1.Result = p1.Document.z0stk());
			if (p1.ShowUI)
			{
				if (z0ZzZzylh2 != null && z0ZzZzylh2.Count > 0)
				{
					if (z0ZzZzylh2[0].z0yek() != null)
					{
						z0ZzZzylh2[0].z0yek().z0sr();
					}
					z0ZzZzfpj.z0tek(p1.EditorControl, z0ZzZziok.z0drk() + Environment.NewLine + z0ZzZzylh2.ToString());
				}
				else
				{
					z0ZzZzfpj.z0rek(p1.EditorControl, z0ZzZziok.z0iuk());
				}
			}
			if (z0ZzZzylh2 == null || z0ZzZzylh2.Count <= 0)
			{
				return;
			}
			XTextElement xTextElement = z0ZzZzylh2[0].z0yek();
			if (xTextElement != null)
			{
				xTextElement.z0sr();
				if (p1.ShowUI)
				{
					p1.EditorControl.z0cok();
				}
			}
		}
	}

	[z0ZzZzimj("GCCollect")]
	private void z0rek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			WriterControlForWASM.z0zrk();
		}
	}

	[z0ZzZzimj("DocumentValueValidateWithCreateDocumentComments")]
	private void z0tek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.Document.z0pu_jiejie20260327142557().ValueValidateMode != DocumentValueValidateMode.None;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			z0ZzZzylh z0ZzZzylh2 = (z0ZzZzylh)(p1.Result = p1.Document.z0ymk());
			if (p1.ShowUI)
			{
				if (z0ZzZzylh2 != null && z0ZzZzylh2.Count > 0)
				{
					if (z0ZzZzylh2[0].z0yek() != null)
					{
						z0ZzZzylh2[0].z0yek().z0sr();
					}
					z0ZzZzfpj.z0tek(p1.EditorControl, z0ZzZziok.z0drk() + Environment.NewLine + z0ZzZzylh2.ToString());
				}
				else
				{
					z0ZzZzfpj.z0rek(p1.EditorControl, z0ZzZziok.z0iuk());
				}
			}
			if (z0ZzZzylh2 == null || z0ZzZzylh2.Count <= 0)
			{
				return;
			}
			XTextElement xTextElement = z0ZzZzylh2[0].z0yek();
			if (xTextElement != null)
			{
				xTextElement.z0sr();
				if (p1.ShowUI)
				{
					p1.EditorControl.z0cok();
				}
			}
		}
	}

	[z0ZzZzimj("ClearValueValidateResult")]
	private void z0yek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.Document.z0pu_jiejie20260327142557().ValueValidateMode != DocumentValueValidateMode.None;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = p1.Document.z0ruk();
		}
	}
}
