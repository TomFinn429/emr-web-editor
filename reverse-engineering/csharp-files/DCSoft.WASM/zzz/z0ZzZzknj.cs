using System;
using System.IO;
using DCSoft.Printing;
using DCSoft.WASM;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

internal sealed class z0ZzZzknj : z0ZzZzcmj
{
	[z0ZzZzimj("DocumentDefaultFont", FunctionID = 21)]
	private void z0eek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document != null && p1.EditorControl != null && !p1.EditorControl.z0ork() && !p1.EditorControl.z0oik())
			{
				p1.Enabled = true;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			z0ZzZzimk z0ZzZzimk2 = new z0ZzZzimk();
			if (p1.Parameter is z0ZzZzimk)
			{
				z0ZzZzimk2 = (z0ZzZzimk)p1.Parameter;
			}
			else if (p1.Parameter is z0ZzZzsdh)
			{
				z0ZzZzimk2 = new z0ZzZzimk((z0ZzZzsdh)p1.Parameter);
			}
			else if (p1.Parameter is string)
			{
				z0ZzZzimk2.z0eek((string)p1.Parameter);
			}
			else
			{
				z0ZzZzimk2 = p1.Document.z0dik().Font;
			}
			Color color = p1.Document.z0dik().Color;
			if (p1.Document.z0ytk())
			{
				z0ZzZzflh p2 = new z0ZzZzflh(p1.EditorControl, p1.Document.z0dik().Font, p1.Document.z0dik().Color, z0ZzZzimk2, color);
				p1.Document.z0bek(p2);
				p1.Document.z0nuk();
			}
			p1.EditorControl.z0eek(z0ZzZzimk2, color, p2: true);
		}
	}

	[z0ZzZzimj("FilePageSettings", ReturnValueType = typeof(XPageSettings))]
	private void z0rek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document != null)
			{
				p1.Enabled = !p1.DocumentControler.z0kn();
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XPageSettings xPageSettings = null;
			if (p1.Parameter is XPageSettings)
			{
				xPageSettings = (XPageSettings)p1.Parameter;
			}
			else if (p1.Parameter is string)
			{
				if (string.IsNullOrEmpty((string)p1.Parameter))
				{
					xPageSettings = p1.Document.PageSettings.z0wtk();
				}
				else
				{
					xPageSettings = new XPageSettings();
					new z0ZzZzsyk((string)p1.Parameter).z0eek(xPageSettings, p1: false);
				}
			}
			_ = p1.ShowUI;
			if (xPageSettings != null)
			{
				if (p1.Document.z0ytk())
				{
					p1.Document.z0imk().z0eek("PageSettings", p1.Document.PageSettings, xPageSettings, p1.Document);
					p1.Document.z0nuk();
				}
				p1.Document.PageSettings = xPageSettings;
				((XTextElement)p1.Document).z0rrk();
				if (p1.EditorControl != null)
				{
					p1.EditorControl.z0iyk();
					p1.EditorControl.z0ypk().z0hz();
				}
				p1.Result = xPageSettings;
			}
		}
	}

	[z0ZzZzimj("FileNew", ReturnValueType = typeof(bool))]
	private void z0tek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			p1.EditorControl.z0htk();
			p1.EditorControl.z0eek(new WriterEventArgs(p1.EditorControl, p1.Document, null));
			p1.Document.z0cek((string)null);
			p1.Document.z0bek(DocumentContentSourceTypes.NewFile);
			p1.Result = true;
			if (((WriterControlForWASM)p1.EditorControl.z0lh()).z0drk())
			{
				GC.Collect();
			}
		}
	}

	protected override z0ZzZzvmj z0qz()
	{
		z0ZzZzvmj obj = new z0ZzZzvmj();
		z0ZzZzcmj.z0rek(obj, "DocumentDefaultFont", z0eek);
		z0ZzZzcmj.z0rek(obj, "FileNew", z0tek);
		z0ZzZzcmj.z0rek(obj, "FilePageSettings", z0rek);
		z0ZzZzcmj.z0rek(obj, "GetSelectionContentText", z0yek);
		z0ZzZzcmj.z0rek(obj, "PageBorderBackgroundFormat", z0uek);
		return obj;
	}

	[z0ZzZzimj("GetSelectionContentText", ReturnValueType = typeof(string))]
	private void z0yek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			StringWriter stringWriter = new StringWriter();
			string text = Convert.ToString(p1.Parameter);
			if (string.IsNullOrEmpty(text))
			{
				text = z0ZzZznhh.z0eek().z0rek().z0js();
			}
			if (p1.Document.z0cuk().z0qrk() != 0)
			{
				XTextDocument xTextDocument = p1.Document.z0cuk().z0prk();
				if (xTextDocument != null)
				{
					xTextDocument.z0vek(stringWriter, text);
					xTextDocument.Dispose();
				}
			}
			string result = stringWriter.ToString();
			p1.Result = result;
		}
	}

	[z0ZzZzimj("PageBorderBackgroundFormat", FunctionID = 35)]
	private void z0uek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null && !p1.EditorControl.z0ork();
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			if (p1.EditorControl != null && !p1.EditorControl.z0ork())
			{
				z0ZzZzvpk z0ZzZzvpk2 = p1.Parameter as z0ZzZzvpk;
				if (z0ZzZzvpk2 == null)
				{
					z0ZzZzvpk2 = p1.Document.PageSettings.PageBorderBackground;
				}
				if (z0ZzZzvpk2 == null)
				{
					z0ZzZzvpk2 = new z0ZzZzvpk();
					z0ZzZzvpk2.BackgroundColor = Color.Transparent;
					z0ZzZzvpk2.BorderColor = Color.Black;
					z0ZzZzvpk2.BorderWidth = 0f;
					z0ZzZzvpk2.BorderLeft = true;
					z0ZzZzvpk2.BorderTop = true;
					z0ZzZzvpk2.BorderRight = true;
					z0ZzZzvpk2.BorderBottom = true;
				}
				p1.Document.z0ytk();
				p1.Document.z0imk().z0eek("PageBorderBackground", p1.Document.PageSettings.PageBorderBackground, z0ZzZzvpk2, p1.Document.PageSettings);
				p1.Document.z0imk().z0eek((z0ZzZzbzj)5);
				p1.Document.PageSettings.PageBorderBackground = z0ZzZzvpk2;
				p1.Document.z0nuk();
				p1.EditorControl.z0ypk().z0hz();
				p1.Document.Modified = true;
				p1.Document.OnDocumentContentChanged();
				p1.Result = true;
			}
		}
	}
}
