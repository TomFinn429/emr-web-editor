using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;

namespace zzz;

internal sealed class z0ZzZzxmj : z0ZzZzcmj
{
	[z0ZzZzimj("ShowBackgroundCellID")]
	private void z0eek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null)
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = true;
			p1.Checked = p1.EditorControl.z0cuk().ViewOptions.ShowBackgroundCellID;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			bool flag = z0ZzZzafh.z0yek(p1.Parameter, !p1.EditorControl.z0cuk().ViewOptions.ShowBackgroundCellID);
			if (flag != p1.EditorControl.z0cuk().ViewOptions.ShowBackgroundCellID)
			{
				p1.EditorControl.z0cuk().ViewOptions.ShowBackgroundCellID = flag;
				p1.z0eek().z0hz();
				p1.RefreshLevel = (z0ZzZzwmj)1;
			}
		}
	}

	[z0ZzZzimj("MoveHome", ShortcutKey = Keys.Home)]
	private void z0rek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: true);
			p1.Document.z0ryk().z0bek();
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	[z0ZzZzimj("DocumentGridLine", ReturnValueType = typeof(bool), DefaultResultValue = false, FunctionID = 33)]
	private void z0tek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
			if (p1.EditorControl != null)
			{
				p1.Checked = p1.EditorControl.z0cuk().ViewOptions.ShowGridLine;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			if (p1.ShowUI)
			{
				z0ZzZzfpj.z0tek(p1.EditorControl, z0ZzZziok.z0juk());
			}
			p1.Result = false;
			z0ZzZzkjh z0ZzZzkjh2 = null;
			if (p1.Parameter is z0ZzZzkjh)
			{
				z0ZzZzkjh2 = (z0ZzZzkjh)p1.Parameter;
			}
			else
			{
				z0ZzZzkjh2 = new z0ZzZzkjh();
				DocumentViewOptions viewOptions = p1.EditorControl.z0cuk().ViewOptions;
				z0ZzZzkjh2.ShowGridLine = z0ZzZzafh.z0yek(p1.Parameter, viewOptions.ShowGridLine);
				z0ZzZzkjh2.GridLineColor = viewOptions.GridLineColor;
				z0ZzZzkjh2.PrintGridLine = viewOptions.PrintGridLine;
				z0ZzZzkjh2.LineStyle = viewOptions.GridLineStyle;
			}
			DocumentViewOptions viewOptions2 = p1.EditorControl.z0cuk().ViewOptions;
			viewOptions2.ShowGridLine = z0ZzZzkjh2.ShowGridLine;
			viewOptions2.GridLineColor = z0ZzZzkjh2.GridLineColor;
			viewOptions2.PrintGridLine = z0ZzZzkjh2.PrintGridLine;
			viewOptions2.GridLineStyle = z0ZzZzkjh2.LineStyle;
			p1.Result = true;
			p1.RefreshLevel = (z0ZzZzwmj)2;
			p1.z0eek().z0hz();
		}
	}

	[z0ZzZzimj("MoveRight", ShortcutKey = Keys.Right)]
	private void z0yek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: true);
			p1.Document.z0ryk().z0tek();
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	[z0ZzZzimj("ShiftMoveEnd", ShortcutKey = (Keys.End | Keys.Shift))]
	private void z0uek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: false);
			p1.Document.z0ryk().z0nek();
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	[z0ZzZzimj("ShowFormButton")]
	private void z0iek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
			if (p1.Enabled)
			{
				p1.Checked = p1.EditorControl.z0cuk().ViewOptions.ShowFormButton;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			bool flag = z0ZzZzafh.z0yek(p1.Parameter, !p1.EditorControl.z0cuk().ViewOptions.ShowFormButton);
			if (p1.EditorControl.z0cuk().ViewOptions.ShowFormButton != flag)
			{
				p1.EditorControl.z0cuk().ViewOptions.ShowFormButton = flag;
				p1.EditorControl.z0iyk();
				p1.RefreshLevel = (z0ZzZzwmj)1;
				p1.Result = flag;
			}
		}
	}

	[z0ZzZzimj("DebugMode", ReturnValueType = typeof(bool))]
	private void z0oek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null)
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = true;
			p1.Checked = p1.EditorControl.z0cuk().BehaviorOptions.DebugMode;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			DocumentBehaviorOptions behaviorOptions = p1.EditorControl.z0cuk().BehaviorOptions;
			bool flag = (behaviorOptions.DebugMode = z0ZzZzafh.z0yek(p1.Parameter, !behaviorOptions.DebugMode));
			p1.RefreshLevel = (z0ZzZzwmj)1;
			p1.Result = flag;
		}
	}

	[z0ZzZzimj("RefreshDocument")]
	private void z0pek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5 && p1.EditorControl != null)
		{
			p1.EditorControl.z0qok();
			p1.EditorControl.z0iyk();
		}
	}

	[z0ZzZzimj("MoveUp", ShortcutKey = Keys.Up)]
	private void z0mek_jiejie20260327142557(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: true);
			p1.Document.z0ryk().z0iek();
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	[z0ZzZzimj("MoveDown", ShortcutKey = Keys.Down)]
	private void z0nek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: true);
			p1.Document.z0ryk().z0wrk();
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	[z0ZzZzimj("JumpPrintModeBySelection", ReturnValueType = typeof(bool), FunctionID = 42)]
	private void z0bek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null)
			{
				p1.Enabled = false;
			}
			else
			{
				p1.Enabled = p1.EditorControl.z0kok().z0qrk() != 0;
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			if (p1.EditorControl.z0kok().z0qrk() != 0 && p1.EditorControl != null)
			{
				p1.EditorControl.z0xek(p0: true);
				XTextElement xTextElement = null;
				XTextElement xTextElement2 = null;
				xTextElement = p1.EditorControl.z0kok().z0grk().z0krk();
				xTextElement2 = p1.EditorControl.z0kok().z0grk().LastElement;
				JumpPrintInfo jumpPrintInfo = p1.Document.z0vek(xTextElement, xTextElement2);
				if (jumpPrintInfo != null)
				{
					p1.EditorControl.z0eek(jumpPrintInfo);
					p1.z0eek().z0hz();
				}
				else
				{
					p1.EditorControl.z0qok();
				}
				p1.RefreshLevel = (z0ZzZzwmj)2;
				p1.Result = true;
			}
		}
	}

	[z0ZzZzimj("ShiftMoveRight", ShortcutKey = (Keys.Right | Keys.Shift))]
	private void z0vek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: false);
			p1.Document.z0ryk().z0tek();
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	[z0ZzZzimj("MoveEnd", ShortcutKey = Keys.End)]
	private void z0cek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: true);
			p1.Document.z0ryk().z0nek();
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	[z0ZzZzimj("ComplexViewMode", FunctionID = 119)]
	private void z0xek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.Document == null || p1.EditorControl.z0ryk())
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = true;
			DocumentSecurityOptions documentSecurityOptions = p1.Document.z0hi();
			p1.Checked = documentSecurityOptions.ShowLogicDeletedContent && documentSecurityOptions.ShowPermissionMark && documentSecurityOptions.ShowPermissionTip;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			DocumentSecurityOptions documentSecurityOptions2 = p1.Document.z0hi();
			documentSecurityOptions2.ShowLogicDeletedContent = true;
			documentSecurityOptions2.ShowPermissionMark = true;
			documentSecurityOptions2.ShowPermissionTip = true;
			if (p1.EditorControl != null)
			{
				DocumentSecurityOptions securityOptions = p1.EditorControl.z0cuk().SecurityOptions;
				securityOptions.ShowLogicDeletedContent = true;
				securityOptions.ShowPermissionMark = true;
				securityOptions.ShowPermissionTip = true;
			}
			p1.EditorControl.z0iyk();
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("DocumentGridLineNew", ReturnValueType = typeof(bool), DefaultResultValue = false, FunctionID = 33)]
	private void z0zek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null;
			if (p1.Document != null)
			{
				p1.Checked = p1.Document.z0xyk().GridLine != null && p1.Document.z0xyk().GridLine.z0uek();
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			z0ZzZzzej z0ZzZzzej2 = null;
			z0ZzZzzej2 = ((p1.Parameter is z0ZzZzzej) ? ((z0ZzZzzej)p1.Parameter) : ((p1.Document.PageSettings.DocumentGridLine != null) ? p1.Document.PageSettings.DocumentGridLine.z0pek() : new z0ZzZzzej()));
			if (p1.Document.z0ytk())
			{
				p1.Document.z0imk().z0eek("DocumentGridLine", p1.Document.PageSettings.DocumentGridLine, z0ZzZzzej2, p1.Document.PageSettings);
				p1.Document.z0imk().z0eek((z0ZzZzbzj)2);
				p1.Document.z0nuk();
			}
			p1.Document.PageSettings.DocumentGridLine = z0ZzZzzej2;
			p1.EditorControl.z0eek(p0: false, p1: true);
			p1.Result = true;
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("DisplayWhole")]
	private void z0lrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl != null && !p1.EditorControl.z0ork())
			{
				p1.Enabled = true;
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			int num = 0;
			XTextElementList xTextElementList = p1.EditorControl.z0ruk().z0ve();
			if (xTextElementList == null || xTextElementList.Count <= 0)
			{
				return;
			}
			p1.Document.z0ytk();
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					if (p1.DocumentControler.z0pm(current, (z0ZzZzbcj)255) && !current.Visible && p1.Document.z0uik())
					{
						current.Visible = true;
						num++;
						p1.Document.z0imk().z0eek("Visible", false, true, current);
					}
				}
			}
			p1.Document.z0nuk();
			p1.Document.Modified = true;
			p1.Result = num;
			p1.RefreshLevel = (z0ZzZzwmj)2;
			p1.EditorControl.z0iyk();
			p1.Document.OnSelectionChanged();
			p1.Document.OnDocumentContentChanged();
		}
	}

	[z0ZzZzimj("ShiftMovePageUp", ShortcutKey = (Keys.Prior | Keys.Shift))]
	private void z0krk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: false);
			p1.Document.z0ryk().z0tek(0f - p1.Document.PageSettings.z0mrk());
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	[z0ZzZzimj("OffsetJumpPrintMode", ReturnValueType = typeof(bool))]
	private void z0jrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null)
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = p1.EditorControl.z0qtk() == PageViewMode.Page;
			p1.Checked = p1.EditorControl.z0rek() == WriterControlExtViewMode.OffsetJumpPrint;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5 || p1.EditorControl == null)
			{
				return;
			}
			bool flag = p1.EditorControl.z0rek() == WriterControlExtViewMode.OffsetJumpPrint;
			bool flag2 = z0ZzZzafh.z0yek(p1.Parameter, !flag);
			if (flag != flag2)
			{
				if (flag2)
				{
					bool num = p1.EditorControl.z0rek() == WriterControlExtViewMode.BoundsSelection;
					p1.EditorControl.z0eek(WriterControlExtViewMode.OffsetJumpPrint);
					if (num)
					{
						p1.EditorControl.z0fpk();
					}
				}
				else
				{
					p1.EditorControl.z0qok();
					p1.EditorControl.z0eek(WriterControlExtViewMode.Normal);
				}
			}
			p1.Result = p1.EditorControl.z0rek() == WriterControlExtViewMode.OffsetJumpPrint;
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("NormalViewMode", FunctionID = 117)]
	private void z0hrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null || p1.EditorControl.z0ryk())
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = true;
			p1.Checked = ((z0ZzZzqrj)p1.z0eek()).z0hrk();
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.EditorControl.z0qok();
			p1.EditorControl.z0xek(p0: false);
			p1.z0eek().z0eek(PageViewMode.CompressPage);
			p1.EditorControl.z0iyk();
			p1.z0eek().z0hz();
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("PageViewMode", FunctionID = 116)]
	private void z0grk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null || p1.EditorControl.z0ryk())
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = true;
			p1.Checked = !((z0ZzZzqrj)p1.z0eek()).z0hrk();
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.EditorControl.z0qok();
			p1.EditorControl.z0xek(p0: false);
			p1.z0eek().z0eek(PageViewMode.Page);
			p1.EditorControl.z0qrk(p0: false);
			p1.EditorControl.z0iyk();
			p1.z0eek().z0hz();
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("BoundsSelectionViewMode", ReturnValueType = typeof(bool), FunctionID = 45)]
	private void z0frk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null)
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = true;
			p1.Checked = p1.EditorControl.z0rek() == WriterControlExtViewMode.BoundsSelection;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5 || p1.EditorControl == null)
			{
				return;
			}
			p1.EditorControl.z0qok();
			bool flag = p1.EditorControl.z0rek() == WriterControlExtViewMode.BoundsSelection;
			bool flag2 = z0ZzZzafh.z0yek(p1.Parameter, !flag);
			if (flag != flag2)
			{
				if (flag2)
				{
					p1.EditorControl.z0eek(WriterControlExtViewMode.BoundsSelection);
				}
				else
				{
					p1.EditorControl.z0eek(WriterControlExtViewMode.Normal);
					p1.EditorControl.z0fpk();
				}
			}
			p1.Result = p1.EditorControl.z0rek() == WriterControlExtViewMode.BoundsSelection;
		}
	}

	[z0ZzZzimj("SelectLine")]
	private void z0drk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			if (!p1.Document.z0itk().z0ptk().z0btk())
			{
				p1.EditorControl.z0eek("MoveHome", p1: false, null);
				p1.EditorControl.z0eek("ShiftMoveEnd", p1: false, null);
			}
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	[z0ZzZzimj("RuleVisible")]
	private void z0srk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
			if (p1.EditorControl != null)
			{
				p1.Checked = p1.EditorControl.z0zrk_jiejie20260327142557();
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			bool flag = z0ZzZzafh.z0yek(p1.Parameter, !p1.EditorControl.z0zrk_jiejie20260327142557());
			if (p1.EditorControl.z0zrk_jiejie20260327142557() != flag)
			{
				p1.EditorControl.z0rrk(flag);
			}
		}
	}

	[z0ZzZzimj("MovePageDown", ShortcutKey = Keys.Next)]
	private void z0ark(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: true);
			p1.Document.z0ryk().z0tek(p1.Document.PageSettings.z0mrk());
			p1.Document.z0yyk().z0vik();
		}
	}

	[z0ZzZzimj("ClearJumpPrintMode", ReturnValueType = typeof(bool))]
	private void z0qrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5 && p1.EditorControl != null)
		{
			p1.EditorControl.z0xek(p0: false);
			p1.EditorControl.z0qpk().PageIndex = -1;
			p1.EditorControl.z0qpk().z0eek(0f);
			p1.EditorControl.z0qpk().z0rek(0f);
			p1.EditorControl.z0qpk().Position = 0f;
			p1.EditorControl.z0qpk().EndPageIndex = -1;
			p1.EditorControl.z0qpk().EndPosition = 0f;
			p1.z0eek().z0hz();
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("ShiftMoveLeft", ShortcutKey = (Keys.Left | Keys.Shift))]
	private void z0wrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: false);
			p1.Document.z0ryk().z0tek(p0: false);
			p1.Document.z0ryk().z0grk();
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	[z0ZzZzimj("MoveToPage", ReturnValueType = typeof(bool))]
	private void z0erk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null && p1.Document != null;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			XTextDocument document = p1.Document;
			z0ZzZzwrj z0ZzZzwrj2 = null;
			if (p1.Parameter is z0ZzZzwrj)
			{
				z0ZzZzwrj2 = (z0ZzZzwrj)p1.Parameter;
				if (!document.z0suk().Contains(z0ZzZzwrj2))
				{
					z0ZzZzwrj2 = null;
				}
			}
			else if (p1.Parameter is int || p1.Parameter is short || p1.Parameter is long || p1.Parameter is float || p1.Parameter is double || p1.Parameter is byte)
			{
				int num = (int)p1.Parameter;
				z0ZzZzwrj2 = document.z0suk().z0rek(num - 1);
			}
			else if (p1.Parameter is string)
			{
				int num2 = 0;
				if (int.TryParse((string)p1.Parameter, out num2))
				{
					z0ZzZzwrj2 = document.z0suk().z0rek(num2 - 1);
				}
			}
			if (z0ZzZzwrj2 == null)
			{
				return;
			}
			using zzz.z0ZzZzkuk<z0ZzZzzlh>.z0bpk z0bpk = document.z0xyk().z0rrk().z0ltk();
			while (z0bpk.MoveNext())
			{
				z0ZzZzzlh current = z0bpk.Current;
				if (current.z0dtk() == z0ZzZzwrj2)
				{
					XTextElement xTextElement = current[0];
					if (xTextElement is XTextTableElement || xTextElement is XTextSectionElement)
					{
						xTextElement = xTextElement.z0hy();
					}
					int num3 = document.z0xyk().z0frk().IndexOf(xTextElement);
					if (xTextElement is XTextParagraphListItemElement)
					{
						num3++;
					}
					num3 = document.z0xyk().z0frk().z0tek(num3, (z0ZzZzfxj)1, p2: true);
					document.z0xyk().z0frk().z0tek(num3, p1: false);
					p1.EditorControl.z0eek(ScrollToViewStyle.Top);
					p1.Result = true;
					break;
				}
			}
		}
	}

	[z0ZzZzimj("DesignMode", ReturnValueType = typeof(bool))]
	private void z0rrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null)
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = true;
			p1.Checked = p1.EditorControl.z0cuk().BehaviorOptions.DesignMode;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			DocumentBehaviorOptions behaviorOptions = p1.EditorControl.z0cuk().BehaviorOptions;
			bool p2 = !behaviorOptions.DesignMode;
			p2 = (behaviorOptions.DesignMode = z0ZzZzafh.z0yek(p1.Parameter, p2));
			behaviorOptions.DesignMode = p2;
			p1.Result = behaviorOptions.DebugMode;
			p1.EditorControl.z0iyk();
			p1.z0eek().z0hz();
			string p3 = p1.z0eek().z0yek(p1.EditorControl.z0ruk().z0suk(), p1: false);
			p1.EditorControl.z0ij(p3);
			p1.RefreshLevel = (z0ZzZzwmj)1;
		}
	}

	[z0ZzZzimj("ShiftMoveUp", ShortcutKey = (Keys.Up | Keys.Shift))]
	private void z0trk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: false);
			p1.Document.z0ryk().z0iek();
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	[z0ZzZzimj("MoveToPosition", ReturnValueType = typeof(bool))]
	private void z0yrk(object p0, z0ZzZzomj p1)
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
			p1.Result = false;
			if (p1.Parameter != null)
			{
				int num = z0ZzZzafh.z0yek(p1.Parameter, -1);
				if (num >= 0 && num < p1.Document.z0ryk().Count)
				{
					p1.Document.z0ryk().z0uek(p0: true);
					p1.Result = p1.Document.z0ryk().z0tek(num, p1: false);
					p1.EditorControl.z0syk();
				}
			}
		}
	}

	[z0ZzZzimj("ShiftMovePageDown", ShortcutKey = (Keys.Next | Keys.Shift))]
	private void z0urk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: false);
			p1.Document.z0ryk().z0tek(p1.Document.PageSettings.z0mrk());
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	[z0ZzZzimj("JumpPrintModeBySubDocument", FunctionID = 42)]
	private void z0irk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document == null)
			{
				return;
			}
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.Document.z0xyk().z0be().z0ltk();
			while (z0bpk.MoveNext())
			{
				if (z0bpk.Current is XTextSubDocumentElement)
				{
					p1.Enabled = true;
					break;
				}
			}
			return;
		}
		if (p1.Mode != (z0ZzZzmmj)5 || p1.Document == null)
		{
			return;
		}
		XTextSubDocumentElement xTextSubDocumentElement = null;
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.Document.z0xyk().z0be().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			if (!(current is XTextSubDocumentElement))
			{
				continue;
			}
			XTextSubDocumentElement xTextSubDocumentElement2 = (XTextSubDocumentElement)current;
			if (!xTextSubDocumentElement2.Printed)
			{
				if (xTextSubDocumentElement != null)
				{
					float position = xTextSubDocumentElement.PrintPositionInPage + xTextSubDocumentElement.Height;
					new JumpPrintInfo().Position = position;
					p1.EditorControl.z0rek(xTextSubDocumentElement2, p1: false, p2: true);
				}
				break;
			}
			xTextSubDocumentElement = xTextSubDocumentElement2;
		}
	}

	[z0ZzZzimj("MoveTo")]
	private void z0ork(object p0, z0ZzZzomj p1)
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
			MoveTarget moveTarget = MoveTarget.None;
			if (p1.Parameter is MoveTarget)
			{
				moveTarget = (MoveTarget)p1.Parameter;
			}
			else if (p1.Parameter is string)
			{
				try
				{
					moveTarget = (MoveTarget)Enum.Parse(typeof(MoveTarget), (string)p1.Parameter, true);
				}
				catch
				{
				}
			}
			if (moveTarget != MoveTarget.None)
			{
				p1.Document.z0ryk().z0uek(p0: true);
				p1.Document.z0ryk().z0tek(moveTarget);
			}
		}
	}

	[z0ZzZzimj("MoveLeft", ShortcutKey = Keys.Left)]
	private void z0prk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: true);
			p1.Document.z0ryk().z0grk();
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	protected override z0ZzZzvmj z0qz()
	{
		z0ZzZzvmj obj = new z0ZzZzvmj();
		z0ZzZzcmj.z0rek(obj, "BoundsSelectionViewMode", z0frk);
		z0ZzZzcmj.z0rek(obj, "CleanViewMode", z0vrk);
		z0ZzZzcmj.z0rek(obj, "ClearJumpPrintMode", z0qrk);
		z0ZzZzcmj.z0rek(obj, "ComplexViewMode", z0xek);
		z0ZzZzcmj.z0rek(obj, "DebugMode", z0oek);
		z0ZzZzcmj.z0rek(obj, "DesignMode", z0rrk);
		z0ZzZzcmj.z0rek(obj, "DisplayWhole", z0lrk);
		z0ZzZzcmj.z0rek(obj, "DocumentGridLine", z0tek);
		z0ZzZzcmj.z0rek(obj, "DocumentGridLineNew", z0zek);
		z0ZzZzcmj.z0rek(obj, "DocumentGridLineVisible", z0ltk);
		z0ZzZzcmj.z0rek(obj, "FormViewMode", z0brk);
		z0ZzZzcmj.z0rek(obj, "JumpPrintMode", z0xrk);
		z0ZzZzcmj.z0rek(obj, "JumpPrintModeBySelection", z0bek);
		z0ZzZzcmj.z0rek(obj, "JumpPrintModeBySubDocument", z0irk);
		z0ZzZzcmj.z0rek(obj, "MoveDown", z0nek, Keys.Down);
		z0ZzZzcmj.z0rek(obj, "MoveEnd", z0cek, Keys.End);
		z0ZzZzcmj.z0rek(obj, "MoveHome", z0rek, Keys.Home);
		z0ZzZzcmj.z0rek(obj, "MoveLeft", z0prk, Keys.Left);
		z0ZzZzcmj.z0rek(obj, "MovePageDown", z0ark, Keys.Next);
		z0ZzZzcmj.z0rek(obj, "MovePageUp", z0nrk, Keys.Prior);
		z0ZzZzcmj.z0rek(obj, "MoveRight", z0yek, Keys.Right);
		z0ZzZzcmj.z0rek(obj, "MoveTo", z0ork);
		z0ZzZzcmj.z0rek(obj, "MoveToPage", z0erk);
		z0ZzZzcmj.z0rek(obj, "MoveToPosition", z0yrk);
		z0ZzZzcmj.z0rek(obj, "MoveUp", z0mek_jiejie20260327142557, Keys.Up);
		z0ZzZzcmj.z0rek(obj, "OffsetJumpPrintMode", z0jrk);
		z0ZzZzcmj.z0rek(obj, "ReadViewMode", z0ktk);
		z0ZzZzcmj.z0rek(obj, "RefreshDocument", z0pek);
		z0ZzZzcmj.z0rek(obj, "RuleVisible", z0srk);
		z0ZzZzcmj.z0rek(obj, "SelectAll", z0mrk, Keys.A | Keys.Control);
		z0ZzZzcmj.z0rek(obj, "SelectLine", z0drk);
		z0ZzZzcmj.z0rek(obj, "ShiftMoveDown", z0zrk, Keys.Down | Keys.Shift);
		z0ZzZzcmj.z0rek(obj, "ShiftMoveEnd", z0uek, Keys.End | Keys.Shift);
		z0ZzZzcmj.z0rek(obj, "ShiftMoveHome", z0crk, Keys.Home | Keys.Shift);
		z0ZzZzcmj.z0rek(obj, "ShiftMoveLeft", z0wrk, Keys.Left | Keys.Shift);
		z0ZzZzcmj.z0rek(obj, "ShiftMovePageDown", z0urk, Keys.Next | Keys.Shift);
		z0ZzZzcmj.z0rek(obj, "ShiftMovePageUp", z0krk, Keys.Prior | Keys.Shift);
		z0ZzZzcmj.z0rek(obj, "ShiftMoveRight", z0vek, Keys.Right | Keys.Shift);
		z0ZzZzcmj.z0rek(obj, "ShiftMoveUp", z0trk, Keys.Up | Keys.Shift);
		z0ZzZzcmj.z0rek(obj, "ShowBackgroundCellID", z0eek);
		z0ZzZzcmj.z0rek(obj, "ShowFormButton", z0iek);
		z0ZzZzcmj.z0rek(obj, "NormalViewMode", z0hrk);
		z0ZzZzcmj.z0rek(obj, "PageViewMode", z0grk);
		return obj;
	}

	[z0ZzZzimj("SelectAll", ShortcutKey = (Keys.A | Keys.Control))]
	private void z0mrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0urk();
			p1.z0eek().z0hz();
			p1.EditorControl.z0vik();
		}
	}

	[z0ZzZzimj("MovePageUp", ShortcutKey = Keys.Prior)]
	private void z0nrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: true);
			p1.Document.z0ryk().z0tek(0f - p1.Document.PageSettings.z0qrk());
			p1.Document.z0yyk().z0vik();
		}
	}

	[z0ZzZzimj("FormViewMode", ReturnValueType = typeof(FormViewMode), FunctionID = 120)]
	private void z0brk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null || p1.EditorControl.z0ryk())
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = true;
			p1.Checked = p1.EditorControl.z0ook() == FormViewMode.Normal || p1.EditorControl.z0ook() == FormViewMode.Strict;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			FormViewMode formViewMode = p1.EditorControl.z0ook();
			if (p1.Parameter is FormViewMode)
			{
				formViewMode = (FormViewMode)p1.Parameter;
			}
			else if (p1.Parameter is bool)
			{
				formViewMode = (((bool)p1.Parameter) ? FormViewMode.Strict : FormViewMode.Disable);
			}
			else if (!(p1.Parameter is string))
			{
				formViewMode = ((formViewMode == FormViewMode.Disable) ? FormViewMode.Strict : FormViewMode.Disable);
			}
			else
			{
				string text = (string)p1.Parameter;
				if (string.Compare(text, "Strict", true) == 0)
				{
					formViewMode = FormViewMode.Strict;
				}
				else if (string.Compare(text, "Normal", true) == 0)
				{
					formViewMode = FormViewMode.Normal;
				}
				else if (string.Compare(text, "Disable", true) == 0)
				{
					formViewMode = FormViewMode.Disable;
				}
				else if (string.Compare(text, "true", true) == 0)
				{
					formViewMode = FormViewMode.Strict;
				}
				else if (string.Compare(text, "false", true) == 0)
				{
					formViewMode = FormViewMode.Disable;
				}
			}
			p1.EditorControl.z0eek(formViewMode);
			p1.EditorControl.z0qrk(p0: false);
			if (p1.Document != null)
			{
				p1.Document.z0ryk().z0hrk();
			}
			p1.z0eek().z0hz();
			p1.RefreshLevel = (z0ZzZzwmj)2;
			p1.Result = formViewMode;
		}
	}

	[z0ZzZzimj("CleanViewMode", FunctionID = 118)]
	private void z0vrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.Document == null)
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = true;
			DocumentSecurityOptions documentSecurityOptions = p1.Document.z0hi();
			p1.Checked = !documentSecurityOptions.ShowLogicDeletedContent && !documentSecurityOptions.ShowPermissionMark && !documentSecurityOptions.ShowPermissionTip;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			DocumentSecurityOptions documentSecurityOptions2 = p1.Document.z0hi();
			documentSecurityOptions2.ShowLogicDeletedContent = false;
			documentSecurityOptions2.ShowPermissionMark = false;
			documentSecurityOptions2.ShowPermissionTip = false;
			if (p1.EditorControl != null)
			{
				DocumentSecurityOptions securityOptions = p1.EditorControl.z0cuk().SecurityOptions;
				securityOptions.ShowLogicDeletedContent = false;
				securityOptions.ShowPermissionMark = false;
				securityOptions.ShowPermissionTip = false;
			}
			p1.EditorControl.z0iyk();
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("ShiftMoveHome", ShortcutKey = (Keys.Home | Keys.Shift))]
	private void z0crk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: false);
			p1.Document.z0ryk().z0bek();
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	[z0ZzZzimj("JumpPrintMode", ReturnValueType = typeof(bool), FunctionID = 42)]
	private void z0xrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null)
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = p1.EditorControl.z0qtk() == PageViewMode.Page;
			p1.Checked = p1.EditorControl.z0rek() == WriterControlExtViewMode.JumpPrint;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5 || p1.EditorControl == null)
			{
				return;
			}
			bool flag = p1.EditorControl.z0rek() == WriterControlExtViewMode.JumpPrint;
			bool flag2 = z0ZzZzafh.z0yek(p1.Parameter, !flag);
			if (flag != flag2)
			{
				p1.EditorControl.z0qok();
				if (flag2)
				{
					bool num = p1.EditorControl.z0rek() == WriterControlExtViewMode.BoundsSelection;
					p1.EditorControl.z0eek(WriterControlExtViewMode.JumpPrint);
					p1.EditorControl.z0qok();
					if (num)
					{
						p1.EditorControl.z0fpk();
					}
				}
				else
				{
					p1.EditorControl.z0eek(WriterControlExtViewMode.Normal);
				}
				p1.z0eek().z0hz();
			}
			p1.Result = p1.EditorControl.z0rek() == WriterControlExtViewMode.JumpPrint;
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("ShiftMoveDown", ShortcutKey = (Keys.Down | Keys.Shift))]
	private void z0zrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0ryk().z0uek(p0: false);
			p1.Document.z0ryk().z0wrk();
			p1.EditorControl.z0vik();
			p1.EditorControl.z0syk();
		}
	}

	[z0ZzZzimj("DocumentGridLineVisible", ReturnValueType = typeof(bool), DefaultResultValue = false, FunctionID = 33)]
	private void z0ltk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
			if (p1.EditorControl != null)
			{
				p1.Checked = p1.EditorControl.z0cuk().ViewOptions.ShowGridLine;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			if (p1.ShowUI)
			{
				z0ZzZzfpj.z0tek(p1.EditorControl, z0ZzZziok.z0juk());
			}
			p1.Result = false;
			DocumentViewOptions viewOptions = p1.EditorControl.z0cuk().ViewOptions;
			viewOptions.ShowGridLine = z0ZzZzafh.z0yek(p1.Parameter, !viewOptions.ShowGridLine);
			p1.Result = viewOptions.ShowGridLine;
			p1.RefreshLevel = (z0ZzZzwmj)1;
			p1.z0eek().z0hz();
		}
	}

	[z0ZzZzimj("ReadViewMode")]
	private void z0ktk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
			if (p1.Enabled)
			{
				p1.Checked = p1.EditorControl.z0ryk();
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.EditorControl.z0qok();
			bool flag = z0ZzZzafh.z0yek(p1.Parameter, !p1.EditorControl.z0ryk());
			if (flag == p1.EditorControl.z0ryk())
			{
				return;
			}
			p1.RefreshLevel = (z0ZzZzwmj)2;
			if (flag)
			{
				Dictionary<string, object> session = p1.Session;
				session["readonly"] = p1.EditorControl.z0sok();
				session["viewmode"] = p1.EditorControl.z0qtk();
				session["formview"] = p1.EditorControl.z0ook();
				session["comment"] = p1.EditorControl.z0oyk();
				p1.EditorControl.z0qrk(p0: true);
				p1.EditorControl.z0oek(p0: true);
				p1.EditorControl.z0eek(PageViewMode.Page);
				p1.EditorControl.z0eek(FormViewMode.Disable);
				p1.EditorControl.z0eek(FunctionControlVisibility.Hide);
				p1.EditorControl.z0eek(p0: false, p1: true);
				return;
			}
			Dictionary<string, object> session2 = p1.Session;
			p1.EditorControl.z0qrk(p0: false);
			if (session2.ContainsKey("readonly"))
			{
				p1.EditorControl.z0oek((bool)session2["readonly"]);
			}
			if (session2.ContainsKey("viewmode"))
			{
				p1.EditorControl.z0eek((PageViewMode)session2["viewmode"]);
			}
			if (session2.ContainsKey("formview"))
			{
				p1.EditorControl.z0eek((FormViewMode)session2["formview"]);
			}
			if (session2.ContainsKey("comment"))
			{
				p1.EditorControl.z0eek((FunctionControlVisibility)session2["comment"]);
			}
			p1.EditorControl.z0eek(p0: false, p1: true);
		}
	}
}
