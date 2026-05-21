using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.MedicalExpression;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

internal sealed class z0ZzZzhnj : z0ZzZzcmj
{
	[ThreadStatic]
	internal static bool z0ltk;

	[z0ZzZzimj("InsertImage", ReturnValueType = typeof(XTextImageElement), FunctionID = 68)]
	private void z0eek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextImageElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			XTextImageElement xTextImageElement = null;
			if (p1.Parameter is XTextImageElement)
			{
				xTextImageElement = (XTextImageElement)p1.Parameter;
			}
			else if (p1.Parameter is z0ZzZzedh)
			{
				xTextImageElement = new XTextImageElement();
				xTextImageElement.z0frk().Value = (z0ZzZzedh)p1.Parameter;
			}
			else if (p1.Parameter is z0ZzZzpmk)
			{
				xTextImageElement = new XTextImageElement();
				xTextImageElement.z0rek((z0ZzZzpmk)p1.Parameter);
			}
			else if (p1.Parameter is byte[])
			{
				xTextImageElement = new XTextImageElement();
				z0ZzZzpmk z0ZzZzpmk2 = new z0ZzZzpmk();
				z0ZzZzpmk2.ImageData = (byte[])p1.Parameter;
				xTextImageElement.z0rek(z0ZzZzpmk2);
			}
			p1.Document.z0bek("image", xTextImageElement);
			if (xTextImageElement != null)
			{
				xTextImageElement.z0bt(p1.Document);
				bool p2 = xTextImageElement.Height != 0f && xTextImageElement.Width != 0f;
				xTextImageElement.z0eek(p2);
				z0ZzZzafh.z0yek(p1.Document, xTextImageElement, xTextImageElement.z0oek(), null);
				p1.Document.z0srk(xTextImageElement);
				p1.DocumentControler.z0dn(xTextImageElement);
				p1.Result = xTextImageElement;
				p1.RefreshLevel = (z0ZzZzwmj)2;
				xTextImageElement.z0xek();
			}
		}
	}

	[z0ZzZzimj("InsertHorizontalLine", ReturnValueType = typeof(XTextHorizontalLineElement))]
	private void z0rek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextHorizontalLineElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			XTextHorizontalLineElement xTextHorizontalLineElement = null;
			if (p1.Parameter is XTextHorizontalLineElement)
			{
				xTextHorizontalLineElement = (XTextHorizontalLineElement)p1.Parameter;
			}
			if (xTextHorizontalLineElement == null)
			{
				xTextHorizontalLineElement = new XTextHorizontalLineElement();
			}
			xTextHorizontalLineElement.z0bt(p1.Document);
			p1.Document.z0bek("hl", xTextHorizontalLineElement);
			if (p1.ShowUI && !z0ZzZzlfh.z0eek(p1, xTextHorizontalLineElement, (z0ZzZzakh)0))
			{
				xTextHorizontalLineElement.Dispose();
				xTextHorizontalLineElement = null;
			}
			if (xTextHorizontalLineElement != null)
			{
				xTextHorizontalLineElement.z0bt(p1.Document);
				p1.Document.z0srk(xTextHorizontalLineElement);
				p1.DocumentControler.z0dn(xTextHorizontalLineElement);
				p1.Result = xTextHorizontalLineElement;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	[z0ZzZzimj("InsertPageInfo", ReturnValueType = typeof(XTextPageInfoElement))]
	private void z0tek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && ((z0ZzZztcj)p1.DocumentControler).z0an(typeof(XTextPageInfoElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			PageInfoValueType valueType = PageInfoValueType.PageIndex;
			ParagraphListStyle displayFormat = ParagraphListStyle.ListNumberStyle;
			string formatString = null;
			bool autoHeight = true;
			string specifyPageIndexTextList = null;
			XTextPageInfoElement xTextPageInfoElement = null;
			if (p1.Parameter is XTextPageInfoElement)
			{
				xTextPageInfoElement = (XTextPageInfoElement)p1.Parameter;
				valueType = xTextPageInfoElement.ValueType;
				formatString = xTextPageInfoElement.FormatString;
				displayFormat = xTextPageInfoElement.DisplayFormat;
				autoHeight = xTextPageInfoElement.AutoHeight;
				specifyPageIndexTextList = xTextPageInfoElement.SpecifyPageIndexTextList;
			}
			else if (p1.Parameter is PageInfoValueType)
			{
				valueType = (PageInfoValueType)p1.Parameter;
			}
			else if (p1.Parameter is string && p1.Parameter.ToString().Length > 0)
			{
				try
				{
					valueType = (xTextPageInfoElement.ValueType = (PageInfoValueType)Enum.Parse(typeof(PageInfoValueType), (string)p1.Parameter, true));
				}
				catch
				{
				}
			}
			p1.Document.z0bek("page", xTextPageInfoElement);
			if (xTextPageInfoElement == null)
			{
				xTextPageInfoElement = new XTextPageInfoElement();
				xTextPageInfoElement.AutoHeight = true;
			}
			xTextPageInfoElement.z0bt(p1.Document);
			xTextPageInfoElement.ValueType = valueType;
			xTextPageInfoElement.DisplayFormat = displayFormat;
			xTextPageInfoElement.FormatString = formatString;
			xTextPageInfoElement.AutoHeight = autoHeight;
			xTextPageInfoElement.SpecifyPageIndexTextList = specifyPageIndexTextList;
			xTextPageInfoElement.z0yek(z0ZzZzjnj.z0eek(p1.Document));
			z0eek(xTextPageInfoElement, p1.Document);
			p1.DocumentControler.z0dn(xTextPageInfoElement);
			p1.RefreshLevel = (z0ZzZzwmj)2;
			p1.Result = xTextPageInfoElement;
		}
	}

	[z0ZzZzimj("InsertEmptySignImage", ReturnValueType = typeof(XTextSignImageElement), FunctionID = 68)]
	private void z0yek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextSignImageElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			XTextSignImageElement xTextSignImageElement = null;
			xTextSignImageElement = ((!(p1.Parameter is XTextSignImageElement)) ? new XTextSignImageElement() : ((XTextSignImageElement)p1.Parameter));
			p1.Document.z0bek("signImage", xTextSignImageElement);
			if (xTextSignImageElement != null)
			{
				xTextSignImageElement.z0bt(p1.Document);
				xTextSignImageElement.z0rek();
				p1.Document.z0srk(xTextSignImageElement);
				p1.DocumentControler.z0dn(xTextSignImageElement);
				p1.Result = xTextSignImageElement;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	private static XTextElementList z0eek(XTextDocument p0, XTextDocument p1, int p2, bool p3, bool p4)
	{
		XTextElementList xTextElementList = z0rek(p0, p1, p2, p3, p4);
		if (xTextElementList != null)
		{
			((z0ZzZztcj)p0.z0xek()).z0om(xTextElementList);
		}
		return xTextElementList;
	}

	protected override z0ZzZzvmj z0qz()
	{
		z0ZzZzvmj obj = new z0ZzZzvmj();
		z0ZzZzcmj.z0rek(obj, "ConvertContentToContainerElement", z0mek);
		z0ZzZzcmj.z0rek(obj, "ConvertContentToField", z0xrk);
		z0ZzZzcmj.z0rek(obj, "ConvertFieldToContent", z0frk);
		z0ZzZzcmj.z0rek(obj, "ConvertTextContentToElementLabel", z0crk);
		z0ZzZzcmj.z0rek(obj, "DeleteSection", z0hrk);
		z0ZzZzcmj.z0rek(obj, "InsertBarcode", z0vek);
		z0ZzZzcmj.z0rek(obj, "InsertButton", z0bek);
		z0ZzZzcmj.z0rek(obj, "InsertChartElement", z0grk);
		z0ZzZzcmj.z0rek(obj, "InsertCheckBox", z0mrk);
		z0ZzZzcmj.z0rek(obj, "InsertCheckBoxList", z0jrk);
		z0ZzZzcmj.z0rek(obj, "InsertControlHost", z0srk);
		z0ZzZzcmj.z0rek(obj, "InsertCustomShape", z0ork);
		z0ZzZzcmj.z0rek(obj, "InsertDirectoryField", z0irk);
		z0ZzZzcmj.z0rek(obj, "InsertElements", z0xek);
		z0ZzZzcmj.z0rek(obj, "InsertEmptySignImage", z0yek);
		z0ZzZzcmj.z0rek(obj, "InsertEmptySignImageInFrontText", z0trk);
		z0ZzZzcmj.z0rek(obj, "InsertFileContent", z0zrk);
		z0ZzZzcmj.z0rek(obj, "InsertHorizontalLine", z0rek);
		z0ZzZzcmj.z0rek(obj, "InsertHtml", z0pek);
		z0ZzZzcmj.z0rek(obj, "InsertImage", z0eek);
		z0ZzZzcmj.z0rek(obj, "InsertImageExt", z0brk_jiejie20260327142557);
		z0ZzZzcmj.z0rek(obj, "InsertInputField", z0zek);
		z0ZzZzcmj.z0rek(obj, "InsertLabel", z0ark);
		z0ZzZzcmj.z0rek(obj, "InsertLineBreak", z0vrk, Keys.Return | Keys.Shift);
		z0ZzZzcmj.z0rek(obj, "InsertMediaElement", z0nrk);
		z0ZzZzcmj.z0rek(obj, "InsertNewBarcode", z0cek);
		z0ZzZzcmj.z0rek(obj, "InsertNewMedicalExpression", z0uek);
		z0ZzZzcmj.z0rek(obj, "InsertPageBreak", z0wrk);
		z0ZzZzcmj.z0rek(obj, "InsertPageInfo", z0tek);
		z0ZzZzcmj.z0rek(obj, "InsertParagrahFlag", z0urk);
		z0ZzZzcmj.z0rek(obj, "InsertPieElement", z0nek);
		z0ZzZzcmj.z0rek(obj, "InsertRadioBox", z0oek);
		z0ZzZzcmj.z0rek(obj, "InsertRTF", z0rrk);
		z0ZzZzcmj.z0rek(obj, "InsertRuler", z0drk);
		z0ZzZzcmj.z0rek(obj, "InsertSection", z0prk);
		z0ZzZzcmj.z0rek(obj, "InsertString", z0erk);
		z0ZzZzcmj.z0rek(obj, "InsertTDBarcode", z0qrk);
		z0ZzZzcmj.z0rek(obj, "InsertWhiteSpaceForAlignRight", z0yrk);
		z0ZzZzcmj.z0rek(obj, "InsertXML", z0lrk);
		z0ZzZzcmj.z0rek(obj, "InsertXMLWithClearFontNameSize", z0krk);
		z0ZzZzcmj.z0rek(obj, "InsertXMLWithClearFormat", z0iek);
		return obj;
	}

	[z0ZzZzimj("InsertNewMedicalExpression")]
	private void z0uek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.DocumentControler != null)
			{
				p1.Enabled = p1.DocumentControler.z0an(typeof(XTextNewMedicalExpressionElement));
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextNewMedicalExpressionElement xTextNewMedicalExpressionElement = null;
			if (p1.Parameter is XTextNewMedicalExpressionElement)
			{
				xTextNewMedicalExpressionElement = (XTextNewMedicalExpressionElement)p1.Parameter;
			}
			if (xTextNewMedicalExpressionElement == null)
			{
				xTextNewMedicalExpressionElement = new XTextNewMedicalExpressionElement();
				xTextNewMedicalExpressionElement.z0bt(p1.Document);
			}
			p1.Document.z0bek("exp", xTextNewMedicalExpressionElement);
			if (p1.ShowUI)
			{
				xTextNewMedicalExpressionElement.z0bt(p1.Document);
				if (!z0ZzZzlfh.z0eek(p1, xTextNewMedicalExpressionElement, (z0ZzZzakh)0))
				{
					xTextNewMedicalExpressionElement.Dispose();
					xTextNewMedicalExpressionElement = null;
				}
			}
			if (xTextNewMedicalExpressionElement == null)
			{
				return;
			}
			XTextElement xTextElement = p1.Document.z0itk();
			xTextNewMedicalExpressionElement.z0oek(xTextElement.z0pek());
			if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.FourValues)
			{
				if (xTextNewMedicalExpressionElement.z0eek())
				{
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.FourValues1)
			{
				if (!xTextNewMedicalExpressionElement.z0eek())
				{
					xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
					xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
					xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
					xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
					xTextNewMedicalExpressionElement.Values.Value4 = "Value4";
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.FourValues2)
			{
				if (!xTextNewMedicalExpressionElement.z0eek())
				{
					xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
					xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
					xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
					xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
					xTextNewMedicalExpressionElement.Values.Value4 = "Value4";
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.ThreeValues)
			{
				if (!xTextNewMedicalExpressionElement.z0eek())
				{
					xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
					xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
					xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
					xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.Pupil)
			{
				if (!xTextNewMedicalExpressionElement.z0eek())
				{
					xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
					xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
					xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
					xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
					xTextNewMedicalExpressionElement.Values.Value4 = "Value4";
					xTextNewMedicalExpressionElement.Values.Value5 = "Value5";
					xTextNewMedicalExpressionElement.Values.Value6 = "Value6";
					xTextNewMedicalExpressionElement.Values.Value7 = "Value7";
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.LightPositioning)
			{
				if (!xTextNewMedicalExpressionElement.z0eek())
				{
					xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
					xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
					xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
					xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
					xTextNewMedicalExpressionElement.Values.Value4 = "Value4";
					xTextNewMedicalExpressionElement.Values.Value5 = "Value5";
					xTextNewMedicalExpressionElement.Values.Value6 = "Value6";
					xTextNewMedicalExpressionElement.Values.Value7 = "Value7";
					xTextNewMedicalExpressionElement.Values.Value8 = "Value8";
					xTextNewMedicalExpressionElement.Values.Value9 = "Value9";
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.FetalHeart)
			{
				if (!xTextNewMedicalExpressionElement.z0eek())
				{
					xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
					xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
					xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
					xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
					xTextNewMedicalExpressionElement.Values.Value4 = "Value4";
					xTextNewMedicalExpressionElement.Values.Value5 = "Value5";
					xTextNewMedicalExpressionElement.Values.Value6 = "Value6";
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.PermanentTeethBitmap)
			{
				if (xTextNewMedicalExpressionElement.z0eek())
				{
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.DeciduousTeech)
			{
				if (xTextNewMedicalExpressionElement.z0eek())
				{
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.PDTeech)
			{
				if (!xTextNewMedicalExpressionElement.z0eek())
				{
					xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
					xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
					xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
					xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
					xTextNewMedicalExpressionElement.Values.Value4 = "Value4";
					xTextNewMedicalExpressionElement.Values.Value5 = "Value5";
					xTextNewMedicalExpressionElement.Values.Value6 = "Value6";
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.DiseasedTeethBotton)
			{
				if (!xTextNewMedicalExpressionElement.z0eek())
				{
					xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
					xTextNewMedicalExpressionElement.Values.Value1 = "FI";
					xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
					xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.DiseasedTeethTop)
			{
				if (!xTextNewMedicalExpressionElement.z0eek())
				{
					xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
					xTextNewMedicalExpressionElement.Values.Value1 = "1";
					xTextNewMedicalExpressionElement.Values.Value2 = "2";
					xTextNewMedicalExpressionElement.Values.Value3 = "3";
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.Fraction)
			{
				if (!xTextNewMedicalExpressionElement.z0eek())
				{
					xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
					xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
					xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.ThreeValues2)
			{
				if (!xTextNewMedicalExpressionElement.z0eek())
				{
					xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
					xTextNewMedicalExpressionElement.Values.Value1 = "Value1";
					xTextNewMedicalExpressionElement.Values.Value2 = "Value2";
					xTextNewMedicalExpressionElement.Values.Value3 = "Value3";
				}
			}
			else if (xTextNewMedicalExpressionElement.ExpressionStyle == DCMedicalExpressionStyle.ThreeValues2 && !xTextNewMedicalExpressionElement.z0eek())
			{
				xTextNewMedicalExpressionElement.Values = new MedicalExpressionValueList();
				xTextNewMedicalExpressionElement.Values.Value1 = "LR";
			}
			p1.DocumentControler.z0dn(xTextNewMedicalExpressionElement);
			p1.RefreshLevel = (z0ZzZzwmj)2;
			p1.Result = xTextNewMedicalExpressionElement;
		}
	}

	[z0ZzZzimj("InsertXMLWithClearFormat", ReturnValueType = typeof(XTextElementList))]
	private void z0iek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.Document != null && p1.DocumentControler.z0an(typeof(XTextElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			z0eek(p1, 1);
		}
	}

	[z0ZzZzimj("InsertRadioBox", ReturnValueType = typeof(XTextRadioBoxElement))]
	private void z0oek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextRadioBoxElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextRadioBoxElement xTextRadioBoxElement = null;
			if (p1.Parameter is XTextRadioBoxElement)
			{
				xTextRadioBoxElement = (XTextRadioBoxElement)p1.Parameter;
			}
			if (xTextRadioBoxElement == null)
			{
				xTextRadioBoxElement = new XTextRadioBoxElement();
				xTextRadioBoxElement.VisualStyle = CheckBoxVisualStyle.SystemDefault;
			}
			xTextRadioBoxElement.z0bt(p1.Document);
			if (p1.ShowUI && !z0ZzZzlfh.z0eek(p1, xTextRadioBoxElement, (z0ZzZzakh)0))
			{
				xTextRadioBoxElement.Dispose();
				xTextRadioBoxElement = null;
			}
			else if (xTextRadioBoxElement != null)
			{
				if (string.IsNullOrEmpty(xTextRadioBoxElement.ID))
				{
					p1.Document.z0bek("radio", xTextRadioBoxElement);
				}
				z0eek(xTextRadioBoxElement, p1.Document);
				p1.Document.z0srk(xTextRadioBoxElement);
				p1.Document.z0xek().z0dn(xTextRadioBoxElement);
				p1.RefreshLevel = (z0ZzZzwmj)2;
				p1.Result = xTextRadioBoxElement;
			}
		}
	}

	[z0ZzZzimj("InsertHtml", ReturnValueType = typeof(XTextElementList))]
	private void z0pek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.Document != null && p1.DocumentControler.z0an(typeof(XTextElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			XTextDocument xTextDocument = null;
			if (p1.Parameter is string)
			{
				xTextDocument = new XTextDocument();
				z0ZzZzsjh.z0eek(xTextDocument, new StringReader((string)p1.Parameter));
			}
			else if (p1.Parameter is Stream)
			{
				xTextDocument = new XTextDocument();
				xTextDocument.z0bek((Stream)p1.Parameter, z0ZzZzkfh.z0ltk, p2: true);
			}
			else if (p1.Parameter is TextReader)
			{
				xTextDocument = new XTextDocument();
				xTextDocument.z0bek((TextReader)p1.Parameter, z0ZzZzkfh.z0ltk, p2: true);
			}
			if (xTextDocument != null && xTextDocument.z0xyk() != null && xTextDocument.z0xyk().z0be().Count > 0)
			{
				XTextElementList xTextElementList = xTextDocument.z0xyk().z0be();
				p1.Document.z0cek(xTextElementList);
				p1.Document.z0krk(xTextElementList);
				if (xTextElementList.Count > 0)
				{
					p1.DocumentControler.z0om(xTextElementList);
					p1.Result = xTextElementList;
				}
			}
		}
	}

	[z0ZzZzimj("ConvertContentToContainerElement")]
	private void z0mek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document != null && p1.Document.z0cuk().z0qrk() != 0 && !p1.DocumentControler.z0kn())
			{
				XTextElement xTextElement = p1.Document.z0cuk().z0uek();
				XTextElement xTextElement2 = p1.Document.z0cuk().z0iek();
				XTextElement xTextElement3 = z0ZzZzafh.z0iek(xTextElement, xTextElement2);
				if (xTextElement3 is XTextTableRowElement)
				{
					xTextElement3 = xTextElement3.z0ji().z0ji();
				}
				else if (xTextElement3 is XTextTableElement)
				{
					xTextElement3 = xTextElement3.z0ji();
				}
				while (xTextElement != null && xTextElement.z0ji() != xTextElement3)
				{
					xTextElement = xTextElement.z0ji();
				}
				while (xTextElement2 != null && xTextElement2.z0ji() != xTextElement3)
				{
					xTextElement2 = xTextElement2.z0ji();
				}
				if (p1.DocumentControler.z0lm(xTextElement) && p1.DocumentControler.z0lm(xTextElement2))
				{
					p1.Enabled = true;
				}
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextElement xTextElement4 = p1.Document.z0cuk().z0uek();
			XTextElement xTextElement5 = p1.Document.z0cuk().z0iek();
			XTextContainerElement xTextContainerElement = z0ZzZzafh.z0iek(xTextElement4, xTextElement5);
			if (xTextContainerElement is XTextTableElement)
			{
				xTextContainerElement = xTextContainerElement.z0ji();
			}
			else if (xTextContainerElement is XTextTableRowElement)
			{
				xTextContainerElement = xTextContainerElement.z0ji().z0ji();
			}
			while (xTextElement4 != null && xTextElement4.z0ji() != xTextContainerElement)
			{
				xTextElement4 = xTextElement4.z0ji();
			}
			while (xTextElement5 != null && xTextElement5.z0ji() != xTextContainerElement)
			{
				xTextElement5 = xTextElement5.z0ji();
			}
			XTextContainerElement xTextContainerElement2 = null;
			if (p1.Parameter is XTextContainerElement)
			{
				xTextContainerElement2 = (XTextContainerElement)p1.Parameter;
			}
			else if (p1.Parameter is Type)
			{
				xTextContainerElement2 = (XTextContainerElement)Activator.CreateInstance((Type)p1.Parameter);
				xTextContainerElement2.z0bt(p1.Document);
			}
			if (xTextContainerElement2 == null)
			{
				xTextContainerElement2 = new XTextInputFieldElement();
			}
			xTextContainerElement2.z0bt(p1.Document);
			if (!p1.DocumentControler.z0qm(xTextContainerElement, xTextContainerElement2, (z0ZzZzbcj)0))
			{
				if (p1.Document.z0bu().ShowDebugMessage)
				{
					string p2 = string.Format(z0ZzZziok.z0qik(), z0ZzZzafh.z0oek(xTextContainerElement), z0ZzZzafh.z0oek(xTextContainerElement2));
					z0ZzZzfpj.z0rek(p1.EditorControl, p2);
				}
				return;
			}
			ElementType elementType = ElementType.None;
			int num = xTextContainerElement.z0be().IndexOf(xTextElement5);
			for (int i = xTextContainerElement.z0be().IndexOf(xTextElement4); i <= num; i++)
			{
				XTextElement xTextElement6 = xTextContainerElement.z0be()[i];
				elementType |= z0ZzZzafh.z0yek(xTextElement6.GetType());
				if (xTextElement6 is XTextParagraphFlagElement && xTextContainerElement2 is XTextInputFieldElement)
				{
					((XTextInputFieldElement)xTextContainerElement2).AcceptChildElementTypes2 |= ElementType.ParagraphFlag;
				}
			}
			if (xTextContainerElement2 is XTextInputFieldElement)
			{
				((XTextInputFieldElement)xTextContainerElement2).AcceptChildElementTypes2 = elementType;
			}
			if (string.IsNullOrEmpty(xTextContainerElement2.ID))
			{
				p1.Document.z0bek("element", xTextContainerElement2);
			}
			xTextContainerElement2.z0bt(p1.Document);
			if (p1.ShowUI && !z0ZzZzlfh.z0eek(p1, xTextContainerElement2, (z0ZzZzakh)0))
			{
				xTextContainerElement2.Dispose();
				xTextContainerElement2 = null;
			}
			if (xTextContainerElement2 == null)
			{
				return;
			}
			int num2 = xTextContainerElement.z0be().IndexOf(xTextElement4);
			int num3 = xTextContainerElement.z0be().IndexOf(xTextElement5);
			for (int j = num2; j <= num3; j++)
			{
				if (!p1.DocumentControler.z0xp(xTextContainerElement2, xTextContainerElement.z0be()[j].GetType(), (z0ZzZzbcj)0))
				{
					return;
				}
			}
			XTextElement xTextElement7 = p1.Document.z0itk();
			xTextContainerElement2.z0oek(xTextElement7.z0pek());
			xTextContainerElement2.z0bt(p1.Document);
			if (xTextContainerElement2 is XTextInputFieldElementBase)
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextContainerElement2;
				((XTextElement)((XTextFieldElementBase)xTextInputFieldElementBase).z0jrk()).z0oek(xTextElement7.z0pek());
				((XTextElement)((XTextFieldElementBase)xTextInputFieldElementBase).z0tek()).z0oek(xTextElement7.z0pek());
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextContainerElement2.z0be().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						z0bpk.Current.z0oek(xTextElement7.z0pek());
					}
				}
				using z0ZzZzjpk p3 = p1.Document.z0ru();
				z0ZzZzvxj p4 = p1.Document.z0bek(p3, (z0ZzZzcxj)0);
				((XTextFieldElementBase)xTextInputFieldElementBase).z0jrk().z0mr(p4);
				((XTextFieldElementBase)xTextInputFieldElementBase).z0tek().z0mr(p4);
			}
			xTextContainerElement2.z0be().Clear();
			for (int k = num2; k <= num3; k++)
			{
				((zzz.z0ZzZzkuk<XTextElement>)xTextContainerElement2.z0be()).z0pek(xTextContainerElement.z0be()[k]);
			}
			if (xTextContainerElement2 is XTextContentElement)
			{
				((XTextContentElement)xTextContainerElement2).z0gu();
			}
			z0ZzZzezj z0ZzZzezj2 = new z0ZzZzezj();
			z0ZzZzezj2.z0eek(xTextContainerElement);
			z0ZzZzezj2.z0eek(new XTextElementList());
			z0ZzZzezj2.z0yek().Add(xTextContainerElement2);
			z0ZzZzezj2.z0tek(num2);
			z0ZzZzezj2.z0rek(num3 - num2 + 1);
			z0ZzZzezj2.z0mek(p0: true);
			z0ZzZzezj2.z0eek((z0ZzZzbcj)255);
			z0ZzZzezj2.z0eek(p0: false);
			z0ZzZzezj2.z0nek(p0: true);
			z0ZzZzezj2.z0oek_jiejie20260327142557(p0: true);
			z0ZzZzezj2.z0bek(p0: true);
			p1.Document.z0ytk();
			int num4 = p1.Document.z0bek(z0ZzZzezj2);
			p1.Document.z0nuk();
			p1.RefreshLevel = (z0ZzZzwmj)2;
			if (num4 > 0)
			{
				p1.Result = xTextContainerElement2;
			}
		}
	}

	private void z0eek(z0ZzZzomj p0, int p1)
	{
		p0.Result = false;
		XTextDocument xTextDocument = null;
		if (p0.Parameter is string)
		{
			string text = (string)p0.Parameter;
			text = text.Trim();
			int num = text.IndexOf('<');
			if (num == -1)
			{
				return;
			}
			if (num > 0)
			{
				text = text.Substring(num, text.Length - num);
			}
			StringReader stringReader = new StringReader(text);
			xTextDocument = new XTextDocument();
			xTextDocument.z0bek(stringReader, z0ZzZzkfh.z0uek, p2: true);
			stringReader.Close();
		}
		else if (p0.Parameter is Stream)
		{
			xTextDocument = new XTextDocument();
			xTextDocument.z0bek((Stream)p0.Parameter, z0ZzZzkfh.z0uek, p2: true);
		}
		else if (p0.Parameter is TextReader)
		{
			xTextDocument = new XTextDocument();
			xTextDocument.z0bek((TextReader)p0.Parameter, z0ZzZzkfh.z0uek, p2: true);
		}
		p0.Result = z0eek(p0.Document, xTextDocument, p1, p3: true, p0.ShowUI);
	}

	[z0ZzZzimj("InsertPieElement")]
	private void z0nek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextPieElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			XTextPieElement xTextPieElement = p1.Parameter as XTextPieElement;
			if (xTextPieElement == null)
			{
				xTextPieElement = new XTextPieElement();
				xTextPieElement.z0rek();
				xTextPieElement.Width = p1.Document.z0xyk().Width * 0.7f;
				xTextPieElement.Height = xTextPieElement.Width * 0.7f;
			}
			xTextPieElement.z0bt(p1.Document);
			p1.Document.z0srk(xTextPieElement);
			p1.Document.z0ytk();
			p1.Document.z0frk(xTextPieElement);
			p1.Document.z0nuk();
			p1.Result = xTextPieElement;
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("InsertButton", ReturnValueType = typeof(XTextButtonElement))]
	private void z0bek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextButtonElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextButtonElement xTextButtonElement = null;
			if (p1.Parameter is XTextButtonElement)
			{
				xTextButtonElement = (XTextButtonElement)p1.Parameter;
			}
			else if (p1.Parameter is string)
			{
				xTextButtonElement = new XTextButtonElement();
				xTextButtonElement.Text = (string)p1.Parameter;
			}
			if (xTextButtonElement != null && string.IsNullOrEmpty(xTextButtonElement.Text))
			{
				xTextButtonElement.Text = z0ZzZziok.z0yyk();
			}
			xTextButtonElement.z0bt(p1.Document);
			p1.Document.z0bek("button", xTextButtonElement);
			if (p1.ShowUI)
			{
				if (xTextButtonElement == null)
				{
					xTextButtonElement = new XTextButtonElement();
				}
				xTextButtonElement.z0bt(p1.Document);
				if (!z0ZzZzlfh.z0eek(p1, xTextButtonElement, (z0ZzZzakh)0))
				{
					return;
				}
			}
			if (xTextButtonElement == null)
			{
				return;
			}
			z0eek(xTextButtonElement, p1.Document);
			xTextButtonElement.z0bt(p1.Document);
			if (xTextButtonElement.Width == 199f && !string.IsNullOrEmpty(xTextButtonElement.Text))
			{
				using z0ZzZzjpk p2 = p1.Document.z0ru();
				z0ZzZzxdh z0ZzZzxdh2 = xTextButtonElement.z0eek(p2);
				xTextButtonElement.Width = Math.Max(z0ZzZzxdh2.z0rek(), xTextButtonElement.Width);
				xTextButtonElement.Height = Math.Max(z0ZzZzxdh2.z0tek(), xTextButtonElement.Height);
			}
			p1.Document.z0srk(xTextButtonElement);
			if (p1.DocumentControler.z0dn(xTextButtonElement))
			{
				p1.Result = xTextButtonElement;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	[z0ZzZzimj("InsertBarcode", ReturnValueType = typeof(XTextBarcodeFieldElement))]
	private void z0vek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextBarcodeFieldElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			if (p1.ShowUI)
			{
				z0ZzZzfpj.z0rek(p1.EditorControl, "InsertBarcode命令已经不推荐使用了，请使用InsertNewBarcode命令替换掉它。");
			}
			XTextBarcodeFieldElement xTextBarcodeFieldElement = null;
			if (p1.Parameter is XTextBarcodeFieldElement)
			{
				xTextBarcodeFieldElement = (XTextBarcodeFieldElement)p1.Parameter;
			}
			if (xTextBarcodeFieldElement == null)
			{
				xTextBarcodeFieldElement = new XTextBarcodeFieldElement();
			}
			xTextBarcodeFieldElement.z0bt(p1.Document);
			p1.Document.z0bek("barcode", xTextBarcodeFieldElement);
			if ((!p1.ShowUI || z0ZzZzlfh.z0eek(p1, xTextBarcodeFieldElement, (z0ZzZzakh)0)) && xTextBarcodeFieldElement != null)
			{
				xTextBarcodeFieldElement.z0bt(p1.Document);
				p1.DocumentControler.z0dn(xTextBarcodeFieldElement);
				p1.Result = xTextBarcodeFieldElement;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	public static XTextElementList z0rek(XTextDocument p0, XTextDocument p1, int p2, bool p3, bool p4)
	{
		z0ltk = false;
		if (p1 == null)
		{
			return null;
		}
		if (p1.z0xyk() == null)
		{
			return null;
		}
		if (p1.z0xyk().z0be().Count == 0)
		{
			return null;
		}
		if (p1.z0xyk().z0be().Count == 1 && p1.z0xyk().z0be()[0] is XTextParagraphFlagElement)
		{
			return null;
		}
		if (p3 && !p0.z0xek().z0ln(p1, p4))
		{
			z0ltk = true;
			return null;
		}
		p1.z0li();
		XTextElementList xTextElementList = p1.z0xyk().z0be().z0pek();
		switch (p2)
		{
		case 1:
		{
			p1.z0gnk().Styles.Clear();
			p1.z0gnk().Default = p0.z0gnk().Default;
			int num = -1;
			int num2 = -1;
			num = p0.z0gnk().GetStyleIndex(p0.z0onk().z0tek());
			num2 = p0.z0gnk().GetStyleIndex(p0.z0onk().z0uek());
			foreach (XTextElement item in new z0ZzZzkxj(xTextElementList)
			{
				ExcludeParagraphFlag = false,
				ExcludeCharElement = false
			})
			{
				if (item is XTextParagraphFlagElement)
				{
					item.z0oek(num2);
				}
				else
				{
					item.z0oek(num);
				}
			}
			break;
		}
		case 2:
		{
			p1.z0gnk().Default.FontName = p0.z0onk().z0tek().FontName;
			p1.z0gnk().Default.FontSize = p0.z0onk().z0tek().FontSize;
			using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = p1.z0gnk().Styles.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					DocumentContentStyle obj = (DocumentContentStyle)z0bpk.Current;
					obj.FontName = p0.z0onk().z0tek().FontName;
					obj.FontSize = p0.z0onk().z0tek().FontSize;
				}
			}
			break;
		}
		}
		p0.z0cek(xTextElementList);
		p0.z0krk(xTextElementList);
		if (xTextElementList.Count > 0)
		{
			return xTextElementList;
		}
		return null;
	}

	[z0ZzZzimj("InsertNewBarcode", ReturnValueType = typeof(XTextBarcodeFieldElement))]
	private void z0cek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextNewBarcodeElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextNewBarcodeElement xTextNewBarcodeElement = null;
			if (p1.Parameter is XTextNewBarcodeElement)
			{
				xTextNewBarcodeElement = (XTextNewBarcodeElement)p1.Parameter;
			}
			if (xTextNewBarcodeElement == null)
			{
				xTextNewBarcodeElement = new XTextNewBarcodeElement();
			}
			xTextNewBarcodeElement.z0bt(p1.Document);
			p1.Document.z0bek("barcode", xTextNewBarcodeElement);
			if ((!p1.ShowUI || z0ZzZzlfh.z0eek(p1, xTextNewBarcodeElement, (z0ZzZzakh)0)) && xTextNewBarcodeElement != null)
			{
				if (xTextNewBarcodeElement.Width <= 0f)
				{
					xTextNewBarcodeElement.Width = 400f;
				}
				if (xTextNewBarcodeElement.Height <= 0f)
				{
					xTextNewBarcodeElement.Height = 150f;
				}
				xTextNewBarcodeElement.z0bt(p1.Document);
				p1.DocumentControler.z0dn(xTextNewBarcodeElement);
				p1.Result = xTextNewBarcodeElement;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	internal static bool z0eek(XTextElement p0, XTextDocument p1)
	{
		if (p1.z0vtk().BehaviorOptions.AutoClearTextFormatWhenPasteOrInsertContent)
		{
			p0.z0oek(p1.z0gnk().GetStyleIndex(p1.z0onk().z0iek()));
			return true;
		}
		return false;
	}

	[z0ZzZzimj("InsertElements")]
	private void z0xek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.DocumentControler != null)
			{
				p1.Enabled = p1.DocumentControler.z0an(typeof(XTextElement));
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = 0;
			XTextElementList xTextElementList = p1.Parameter as XTextElementList;
			if (xTextElementList == null)
			{
				if (p1.Parameter is XTextElement)
				{
					xTextElementList = new XTextElementList();
					xTextElementList.Add((XTextElement)p1.Parameter);
				}
				if (xTextElementList == null)
				{
					return;
				}
			}
			if (p1.Document.z0vtk().BehaviorOptions.AutoClearTextFormatWhenPasteOrInsertContent)
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					current.z0bt(p1.Document);
					current.z0yek(p1.Document.z0xpk());
				}
			}
			int num = ((z0ZzZztcj)p1.DocumentControler).z0om(xTextElementList);
			p1.RefreshLevel = (z0ZzZzwmj)2;
			p1.Result = num;
		}
	}

	[z0ZzZzimj("InsertInputField", ReturnValueType = typeof(XTextInputFieldElement))]
	private void z0zek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextInputFieldElementBase));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextInputFieldElement xTextInputFieldElement = null;
			if (p1.Parameter is XTextInputFieldElement)
			{
				xTextInputFieldElement = (XTextInputFieldElement)p1.Parameter;
			}
			else if (p1.Parameter is InputFieldSettings)
			{
				xTextInputFieldElement = new XTextInputFieldElement();
				xTextInputFieldElement.FieldSettings = (InputFieldSettings)p1.Parameter;
			}
			else if (p1.Parameter is z0ZzZzevj)
			{
				xTextInputFieldElement = new XTextInputFieldElement();
				xTextInputFieldElement.ValueBinding = (z0ZzZzevj)p1.Parameter;
			}
			else if (p1.Parameter is ValueValidateStyle)
			{
				xTextInputFieldElement = new XTextInputFieldElement();
				xTextInputFieldElement.ValidateStyle = (ValueValidateStyle)p1.Parameter;
			}
			if (xTextInputFieldElement == null)
			{
				xTextInputFieldElement = new XTextInputFieldElement();
			}
			xTextInputFieldElement.z0bt(p1.Document);
			p1.Document.z0bek("field", xTextInputFieldElement);
			if (p1.ShowUI && !z0ZzZzlfh.z0eek(p1, xTextInputFieldElement, (z0ZzZzakh)0))
			{
				xTextInputFieldElement.Dispose();
				xTextInputFieldElement = null;
			}
			if (xTextInputFieldElement == null)
			{
				return;
			}
			if (!z0eek(xTextInputFieldElement, p1.Document))
			{
				if (((XTextElement)xTextInputFieldElement).z0xrk() != null)
				{
					xTextInputFieldElement.z0bt(p1.Document);
					((XTextElement)xTextInputFieldElement).z0drk(p0: true);
				}
				else if (((XTextElement)xTextInputFieldElement).z0pek() == -1)
				{
					xTextInputFieldElement.z0oek(p1.Document.z0gnk().GetStyleIndex(p1.Document.z0onk().z0iek()));
				}
			}
			((XTextElement)((XTextFieldElementBase)xTextInputFieldElement).z0jrk()).z0oek(((XTextElement)xTextInputFieldElement).z0pek());
			((XTextElement)((XTextFieldElementBase)xTextInputFieldElement).z0tek()).z0oek(((XTextElement)xTextInputFieldElement).z0pek());
			xTextInputFieldElement.z0bt(p1.Document);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextInputFieldElement.z0be().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					z0bpk.Current.z0oek(((XTextElement)xTextInputFieldElement).z0pek());
				}
			}
			if (xTextInputFieldElement.ValueBinding != null && xTextInputFieldElement.ValueBinding.z0yek())
			{
				xTextInputFieldElement.z0cek(new z0ZzZzrlh(null, p1: true));
			}
			p1.Document.z0srk(xTextInputFieldElement);
			p1.DocumentControler.z0dn(xTextInputFieldElement);
			p1.RefreshLevel = (z0ZzZzwmj)2;
			p1.Result = xTextInputFieldElement;
		}
	}

	[z0ZzZzimj("InsertXML", ReturnValueType = typeof(XTextElementList))]
	private void z0lrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.Document != null && p1.DocumentControler.z0an(typeof(XTextElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			z0eek(p1, 0);
		}
	}

	[z0ZzZzimj("InsertXMLWithClearFontNameSize", ReturnValueType = typeof(XTextElementList))]
	private void z0krk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.Document != null && p1.DocumentControler.z0an(typeof(XTextElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			z0eek(p1, 2);
		}
	}

	[z0ZzZzimj("InsertCheckBoxList", ReturnValueType = typeof(XTextElementList))]
	private void z0jrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextInputFieldElementBase));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextInputFieldElement xTextInputFieldElement = null;
			if (p1.Parameter is XTextInputFieldElement)
			{
				xTextInputFieldElement = (XTextInputFieldElement)p1.Parameter;
			}
			else
			{
				z0ZzZzanj z0ZzZzanj2 = null;
				z0ZzZzanj2 = p1.Parameter as z0ZzZzanj;
				if (p1.Parameter is z0ZzZzanj)
				{
					z0ZzZzanj2 = (z0ZzZzanj)p1.Parameter;
				}
				if (z0ZzZzanj2 == null)
				{
					z0ZzZzanj2 = new z0ZzZzanj();
				}
				z0ZzZzanj2.z0eek(p1.Document);
				if (p1.Parameter is InputFieldSettings)
				{
					z0ZzZzanj2.z0eek((InputFieldSettings)p1.Parameter);
				}
				else if (p1.Parameter is z0ZzZzevj)
				{
					z0ZzZzanj2.z0eek((z0ZzZzevj)p1.Parameter);
				}
				else if (p1.Parameter is ValueValidateStyle)
				{
					z0ZzZzanj2.z0eek((ValueValidateStyle)p1.Parameter);
				}
				xTextInputFieldElement = (XTextInputFieldElement)z0ZzZzanj2.z0sz(p1.Document);
			}
			z0ZzZzgvj p2 = (z0ZzZzgvj)p1.Host.z0tek().z0eek(typeof(z0ZzZzgvj));
			XTextElementList xTextElementList = new XTextElementList();
			z0ZzZzdvj z0ZzZzdvj2 = z0ZzZzsvj.z0eek(p1.EditorControl, xTextInputFieldElement, p1.Host, xTextInputFieldElement.FieldSettings.z0zek(), p2, null, null, p7: true, null);
			if (z0ZzZzdvj2 != null)
			{
				using zzz.z0ZzZzkuk<ListItem>.z0bpk z0bpk = z0ZzZzdvj2.z0ltk();
				while (z0bpk.MoveNext())
				{
					ListItem current = z0bpk.Current;
					XTextCheckBoxElement xTextCheckBoxElement = new XTextCheckBoxElement();
					if (xTextInputFieldElement.FieldSettings.z0yek())
					{
						xTextCheckBoxElement.z0ii(CheckBoxControlStyle.CheckBox);
					}
					else
					{
						xTextCheckBoxElement.z0ii(CheckBoxControlStyle.RadioBox);
					}
					xTextCheckBoxElement.GroupName = xTextInputFieldElement.Name;
					xTextCheckBoxElement.CheckedValue = current.Value;
					xTextCheckBoxElement.StringTag = current.Tag;
					xTextCheckBoxElement.ID = xTextInputFieldElement.ID;
					if (xTextInputFieldElement.Attributes != null)
					{
						xTextCheckBoxElement.Attributes = xTextInputFieldElement.Attributes.z0eek();
					}
					xTextElementList.Add(xTextCheckBoxElement);
					if (!string.IsNullOrEmpty(current.Text))
					{
						string text = current.Text;
						foreach (char charValue in text)
						{
							XTextCharElement xTextCharElement = new XTextCharElement();
							xTextCharElement.CharValue = charValue;
							xTextElementList.Add(xTextCharElement);
						}
					}
				}
			}
			if (xTextElementList.Count <= 0)
			{
				return;
			}
			int styleIndex = p1.Document.z0gnk().GetStyleIndex(p1.Document.z0onk().z0tek());
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextElementList.z0ltk())
			{
				while (z0bpk2.MoveNext())
				{
					XTextElement current2 = z0bpk2.Current;
					current2.z0oek(styleIndex);
					current2.z0bt(p1.Document);
				}
			}
			((z0ZzZztcj)p1.DocumentControler).z0om(xTextElementList);
			p1.RefreshLevel = (z0ZzZzwmj)2;
			p1.Result = xTextElementList;
		}
	}

	[z0ZzZzimj("DeleteSection", ReturnValueType = typeof(bool), DefaultResultValue = false)]
	private void z0hrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document == null)
			{
				return;
			}
			XTextContainerElement p2 = null;
			int p3 = 0;
			p1.Document.z0ryk().z0tek(out p2, out p3);
			while (p2 != null)
			{
				if (p2 is XTextSectionElement)
				{
					p1.Enabled = true;
					break;
				}
				p2 = p2.z0ji();
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			XTextContainerElement p4 = null;
			int p5 = 0;
			p1.Document.z0ryk().z0tek(out p4, out p5);
			while (p4 != null)
			{
				if (p4 is XTextSectionElement)
				{
					p4.z0le(p0: true);
					p1.Result = true;
					break;
				}
				p4 = p4.z0ji();
			}
		}
	}

	[z0ZzZzimj("InsertChartElement")]
	private void z0grk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextChartElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			XTextChartElement xTextChartElement = p1.Parameter as XTextChartElement;
			if (xTextChartElement == null)
			{
				xTextChartElement = new XTextChartElement();
				xTextChartElement.z0vek();
				xTextChartElement.Width = p1.Document.z0xyk().Width * 0.7f;
				xTextChartElement.Height = xTextChartElement.Width * 0.7f;
			}
			xTextChartElement.z0bt(p1.Document);
			p1.Document.z0srk(xTextChartElement);
			p1.Document.z0ytk();
			p1.Document.z0frk(xTextChartElement);
			p1.Document.z0nuk();
			p1.Result = xTextChartElement;
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("ConvertFieldToContent", ReturnValueType = typeof(bool))]
	private void z0frk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document != null)
			{
				XTextFieldElementBase xTextFieldElementBase = null;
				xTextFieldElementBase = ((p1.Parameter == null || !(p1.Parameter is XTextInputFieldElement)) ? ((XTextFieldElementBase)p1.Document.z0bek(typeof(XTextFieldElementBase), p1: false)) : (p1.Parameter as XTextInputFieldElementBase));
				if (xTextFieldElementBase != null)
				{
					p1.Enabled = true;
				}
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			XTextFieldElementBase xTextFieldElementBase2 = null;
			xTextFieldElementBase2 = ((p1.Parameter == null || !(p1.Parameter is XTextInputFieldElement)) ? ((XTextFieldElementBase)p1.Document.z0bek(typeof(XTextFieldElementBase), p1: false)) : (p1.Parameter as XTextInputFieldElementBase));
			if (xTextFieldElementBase2 == null)
			{
				return;
			}
			XTextContainerElement xTextContainerElement = xTextFieldElementBase2.z0ji();
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextFieldElementBase2.z0be().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					if (!p1.DocumentControler.z0xp(xTextContainerElement, current.GetType(), (z0ZzZzbcj)255))
					{
						return;
					}
				}
			}
			if (!p1.DocumentControler.z0lm(xTextFieldElementBase2))
			{
				return;
			}
			z0ZzZzezj z0ZzZzezj2 = new z0ZzZzezj();
			z0ZzZzezj2.z0eek(xTextContainerElement);
			z0ZzZzezj2.z0tek(xTextContainerElement.z0be().IndexOf(xTextFieldElementBase2));
			z0ZzZzezj2.z0rek(1);
			XTextElementList xTextElementList = new XTextElementList();
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextFieldElementBase2.z0be().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current2 = z0bpk.Current;
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(current2);
				}
			}
			z0ZzZzezj2.z0eek(xTextElementList);
			if (z0ZzZzezj2.z0yek().Count == 0)
			{
				z0ZzZzezj2.z0eek((XTextElementList)null);
			}
			z0ZzZzezj2.z0oek_jiejie20260327142557(p0: true);
			z0ZzZzezj2.z0bek(p0: true);
			z0ZzZzezj2.z0eek((z0ZzZzbcj)255);
			z0ZzZzezj2.z0mek(p0: true);
			z0ZzZzezj2.z0eek(p0: false);
			z0ZzZzezj2.z0nek(p0: true);
			p1.Document.z0ytk();
			int num = p1.Document.z0bek(z0ZzZzezj2);
			p1.Document.z0nuk();
			p1.RefreshLevel = (z0ZzZzwmj)2;
			if (num > 0)
			{
				p1.Result = true;
			}
		}
	}

	[z0ZzZzimj("InsertRuler", ReturnValueType = typeof(XTextRulerElement))]
	private void z0drk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextRulerElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextRulerElement xTextRulerElement = null;
			if (p1.Parameter is XTextRulerElement)
			{
				xTextRulerElement = (XTextRulerElement)p1.Parameter;
			}
			else if (p1.Parameter is string)
			{
				xTextRulerElement = new XTextRulerElement();
				xTextRulerElement.Text = (string)p1.Parameter;
			}
			if (xTextRulerElement == null)
			{
				xTextRulerElement = new XTextRulerElement();
			}
			if (string.IsNullOrEmpty(xTextRulerElement.Text))
			{
				xTextRulerElement.Text = z0ZzZziok.z0sik();
			}
			xTextRulerElement.z0bt(p1.Document);
			p1.Document.z0bek("ruler", xTextRulerElement);
			if ((!p1.ShowUI || z0ZzZzlfh.z0eek(p1, xTextRulerElement, (z0ZzZzakh)0)) && xTextRulerElement != null)
			{
				xTextRulerElement.z0bt(p1.Document);
				p1.Document.z0srk(xTextRulerElement);
				if (p1.DocumentControler.z0dn(xTextRulerElement))
				{
					p1.Result = xTextRulerElement;
					p1.RefreshLevel = (z0ZzZzwmj)2;
				}
			}
		}
	}

	[z0ZzZzimj("InsertControlHost", ReturnValueType = typeof(XTextControlHostElement))]
	private void z0srk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextControlHostElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextControlHostElement xTextControlHostElement = null;
			if (p1.Parameter is XTextControlHostElement)
			{
				xTextControlHostElement = (XTextControlHostElement)p1.Parameter;
			}
			if (xTextControlHostElement == null)
			{
				xTextControlHostElement = new XTextControlHostElement();
				DocumentContentStyle documentContentStyle = (DocumentContentStyle)p1.Document.z0itk().z0xrk().Clone();
				documentContentStyle.PaddingLeft = XTextObjectElement.z0xek;
				documentContentStyle.PaddingTop = XTextObjectElement.z0xek;
				documentContentStyle.PaddingRight = XTextObjectElement.z0xek;
				documentContentStyle.PaddingBottom = XTextObjectElement.z0xek;
				documentContentStyle.BorderWidth = 1f;
				documentContentStyle.BorderLeft = true;
				documentContentStyle.BorderTop = true;
				documentContentStyle.BorderRight = true;
				documentContentStyle.BorderBottom = true;
				documentContentStyle.BorderStyle = DashStyle.Solid;
				xTextControlHostElement.z0oek(p1.Document.z0gnk().GetStyleIndex(documentContentStyle));
			}
			p1.Document.z0bek("host", xTextControlHostElement);
			xTextControlHostElement.z0bt(p1.Document);
			z0ZzZzcdh z0yek_jiejie20260327142557 = z0ZzZzcdh.z0yek_jiejie20260327142557;
			if (p1.Parameter is string)
			{
				xTextControlHostElement.z0ey((z0ZzZzrxj)0);
				xTextControlHostElement.TypeFullName = (string)p1.Parameter;
			}
			else if (p1.Parameter is Type)
			{
				xTextControlHostElement.z0ey((z0ZzZzrxj)0);
				xTextControlHostElement.TypeFullName = z0ZzZzwnj.z0eek((Type)p1.Parameter);
			}
			if (p1.ShowUI && !z0ZzZzlfh.z0eek(p1, xTextControlHostElement, (z0ZzZzakh)0))
			{
				xTextControlHostElement.Dispose();
				xTextControlHostElement = null;
			}
			if (xTextControlHostElement != null)
			{
				XTextElement xTextElement = p1.Document.z0itk();
				if (((XTextElement)xTextControlHostElement).z0pek() < 0)
				{
					xTextControlHostElement.z0oek(xTextElement.z0pek());
				}
				xTextControlHostElement.z0bt(p1.Document);
				if (!z0yek_jiejie20260327142557.z0eek())
				{
					xTextControlHostElement.z0iek(p1.Document.z0xek((float)z0yek_jiejie20260327142557.z0rek()));
					xTextControlHostElement.z0di(p1.Document.z0xek((float)z0yek_jiejie20260327142557.z0tek()));
				}
				if (xTextControlHostElement.z0ork() <= 0f)
				{
					xTextControlHostElement.z0iek(300f);
				}
				if (xTextControlHostElement.z0si() <= 0f)
				{
					xTextControlHostElement.z0di(300f);
				}
				z0ZzZzafh.z0yek(p1.Document, xTextControlHostElement, p2: false, null);
				p1.Document.z0bek("media", xTextControlHostElement);
				p1.DocumentControler.z0dn(xTextControlHostElement);
				p1.RefreshLevel = (z0ZzZzwmj)2;
				p1.Result = xTextControlHostElement;
			}
		}
	}

	[z0ZzZzimj("InsertLabel", ReturnValueType = typeof(XTextLabelElement))]
	private void z0ark(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextLabelElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextLabelElement xTextLabelElement = null;
			if (p1.Parameter is XTextLabelElement)
			{
				xTextLabelElement = (XTextLabelElement)p1.Parameter;
			}
			else if (p1.Parameter is string)
			{
				xTextLabelElement = new XTextLabelElement();
				xTextLabelElement.Text = (string)p1.Parameter;
			}
			if (xTextLabelElement == null)
			{
				xTextLabelElement = new XTextLabelElement();
			}
			if (string.IsNullOrEmpty(xTextLabelElement.Text))
			{
				xTextLabelElement.Text = z0ZzZziok.z0sik();
			}
			xTextLabelElement.z0bt(p1.Document);
			p1.Document.z0bek("label", xTextLabelElement);
			if ((!p1.ShowUI || z0ZzZzlfh.z0eek(p1, xTextLabelElement, (z0ZzZzakh)0)) && xTextLabelElement != null)
			{
				z0eek(xTextLabelElement, p1.Document);
				xTextLabelElement.z0bt(p1.Document);
				p1.Document.z0srk(xTextLabelElement);
				if (p1.DocumentControler.z0dn(xTextLabelElement))
				{
					p1.Result = xTextLabelElement;
					p1.RefreshLevel = (z0ZzZzwmj)2;
				}
			}
		}
	}

	[z0ZzZzimj("InsertTDBarcode", ReturnValueType = typeof(XTextTDBarcodeElement))]
	private void z0qrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextTDBarcodeElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			XTextTDBarcodeElement xTextTDBarcodeElement = null;
			if (p1.Parameter is XTextTDBarcodeElement)
			{
				xTextTDBarcodeElement = (XTextTDBarcodeElement)p1.Parameter;
			}
			if (xTextTDBarcodeElement == null)
			{
				xTextTDBarcodeElement = new XTextTDBarcodeElement();
			}
			xTextTDBarcodeElement.z0bt(p1.Document);
			p1.Document.z0bek("tdbarcode", xTextTDBarcodeElement);
			if ((!p1.ShowUI || z0ZzZzlfh.z0eek(p1, xTextTDBarcodeElement, (z0ZzZzakh)0)) && xTextTDBarcodeElement != null)
			{
				xTextTDBarcodeElement.z0bt(p1.Document);
				p1.Document.z0srk(xTextTDBarcodeElement);
				p1.DocumentControler.z0dn(xTextTDBarcodeElement);
				p1.Result = xTextTDBarcodeElement;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	[z0ZzZzimj("InsertPageBreak", ReturnValueType = typeof(bool), DefaultResultValue = false)]
	private void z0wrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.DocumentControler != null)
			{
				p1.Enabled = p1.DocumentControler.z0an(typeof(XTextPageBreakElement));
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
			xTextParagraphFlagElement.z0bt(p1.Document);
			XTextPageBreakElement xTextPageBreakElement = new XTextPageBreakElement();
			xTextPageBreakElement.z0bt(p1.Document);
			xTextParagraphFlagElement.z0oek(((XTextElement)p1.Document.z0mtk()).z0pek());
			xTextPageBreakElement.z0oek(-1);
			using (z0ZzZzjpk p2 = p1.Document.z0ru())
			{
				z0ZzZzvxj z0ZzZzvxj2 = p1.Document.z0bek(p2, (z0ZzZzcxj)0);
				z0ZzZzvxj2.z0hyk = xTextParagraphFlagElement;
				xTextParagraphFlagElement.z0mr(z0ZzZzvxj2);
				z0ZzZzvxj2.z0hyk = xTextPageBreakElement;
				xTextPageBreakElement.z0mr(z0ZzZzvxj2);
			}
			XTextElementList xTextElementList = new XTextElementList();
			xTextElementList.Add(xTextPageBreakElement);
			p1.Document.z0ytk();
			p1.Document.z0vek(xTextElementList, p1: true);
			p1.Document.z0ryk().z0tek(xTextPageBreakElement.z0jrk() + 1, p1: false);
			XTextElement p3 = p1.Document.z0ryk().SafeGet(xTextPageBreakElement.z0jrk() + 1);
			p1.Document.z0ryk().z0oek(p3);
			p1.Document.z0nuk();
			p1.Document.OnDocumentContentChanged();
			p1.Result = true;
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("InsertString")]
	private void z0erk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextCharElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = 0;
			z0ZzZzgmj z0ZzZzgmj2 = null;
			if (p1.Parameter is z0ZzZzgmj)
			{
				z0ZzZzgmj2 = (z0ZzZzgmj)p1.Parameter;
			}
			else
			{
				z0ZzZzgmj2 = new z0ZzZzgmj();
				if (p1.Parameter != null)
				{
					z0ZzZzgmj2.z0eek(Convert.ToString(p1.Parameter));
				}
			}
			if (p1.ShowUI)
			{
				string text = p1.EditorControl.z0lh().z0xz(p1.EditorControl.z0zok() + "请输入文本", z0ZzZzgmj2.z0eek());
				if (text == null || text.Length == 0)
				{
					return;
				}
				z0ZzZzgmj2.z0eek(text);
			}
			if (!string.IsNullOrEmpty(z0ZzZzgmj2.z0eek()))
			{
				p1.Result = p1.DocumentControler.z0pn(z0ZzZzgmj2.z0eek(), p1: true, InputValueSource.UI, z0ZzZzgmj2.z0rek(), z0ZzZzgmj2.z0tek());
			}
		}
	}

	[z0ZzZzimj("InsertRTF")]
	private void z0rrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			z0ZzZzhmj z0ZzZzhmj2 = null;
			if (p1.Parameter is z0ZzZzhmj)
			{
				z0ZzZzhmj2 = (z0ZzZzhmj)p1.Parameter;
			}
			else
			{
				z0ZzZzhmj2 = new z0ZzZzhmj();
				if (p1.Parameter != null)
				{
					z0ZzZzhmj2.z0eek(Convert.ToString(p1.Parameter));
				}
			}
			if (!string.IsNullOrEmpty(z0ZzZzhmj2.z0eek()))
			{
				p1.Result = p1.DocumentControler.z0sm(z0ZzZzhmj2.z0eek());
			}
		}
	}

	[z0ZzZzimj("InsertEmptySignImageInFrontText", ReturnValueType = typeof(XTextSignImageElement), FunctionID = 68)]
	private void z0trk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextSignImageElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			XTextSignImageElement xTextSignImageElement = null;
			xTextSignImageElement = ((!(p1.Parameter is XTextSignImageElement)) ? new XTextSignImageElement() : ((XTextSignImageElement)p1.Parameter));
			p1.Document.z0bek("signImage", xTextSignImageElement);
			xTextSignImageElement.ZOrderStyle = ElementZOrderStyle.InFrontOfText;
			if (xTextSignImageElement != null)
			{
				xTextSignImageElement.z0bt(p1.Document);
				xTextSignImageElement.z0rek();
				p1.Document.z0srk(xTextSignImageElement);
				p1.DocumentControler.z0dn(xTextSignImageElement);
				p1.Result = xTextSignImageElement;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	[z0ZzZzimj("InsertWhiteSpaceForAlignRight")]
	private void z0yrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextCharElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextElement xTextElement = p1.Parameter as XTextElement;
			if (xTextElement == null)
			{
				xTextElement = p1.Document.z0itk();
			}
			if (xTextElement == null)
			{
				return;
			}
			XTextContentElement xTextContentElement = xTextElement.z0jy();
			if (xTextContentElement == null)
			{
				return;
			}
			z0ZzZzzlh z0ZzZzzlh2 = xTextElement.z0ptk();
			if (z0ZzZzzlh2 != null)
			{
				float num = ((XTextElement)xTextContentElement).z0ork() - z0ZzZzzlh2.z0itk();
				XTextCharElement xTextCharElement = new XTextCharElement();
				xTextCharElement.z0oek(-1);
				xTextCharElement.CharValue = ' ';
				xTextCharElement.z0bt(p1.Document);
				int num2 = 0;
				using (z0ZzZzjpk p2 = p1.Document.z0ru())
				{
					z0ZzZzvxj z0ZzZzvxj2 = p1.Document.z0bek(p2, (z0ZzZzcxj)0);
					z0ZzZzvxj2.z0hyk = xTextCharElement;
					xTextCharElement.z0mr(z0ZzZzvxj2);
					num2 = (int)Math.Floor(num / xTextCharElement.Width);
				}
				if (num2 > 0)
				{
					xTextElement.z0qek().z0uek(xTextElement.z0jrk(), 0);
					p1.Result = p1.DocumentControler.z0pn(new string(' ', num2), p1: true, InputValueSource.UI, p1.Document.z0dik(), null);
				}
			}
		}
	}

	[z0ZzZzimj("InsertParagrahFlag", ReturnValueType = typeof(bool))]
	private void z0urk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextParagraphFlagElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			XTextElementList xTextElementList = p1.DocumentControler.z0pn("\r", p1: true, InputValueSource.UI, null, null);
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				p1.Result = true;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	[z0ZzZzimj("InsertDirectoryField")]
	private void z0irk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextDirectoryFieldElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			XTextDirectoryFieldElement xTextDirectoryFieldElement = p1.Parameter as XTextDirectoryFieldElement;
			if (xTextDirectoryFieldElement == null)
			{
				xTextDirectoryFieldElement = new XTextDirectoryFieldElement();
			}
			p1.Document.z0bek("directory", xTextDirectoryFieldElement);
			xTextDirectoryFieldElement.z0bt(p1.Document);
			xTextDirectoryFieldElement.z0nu(p1.Document.z0xyk());
			xTextDirectoryFieldElement.z0rek(p0: false);
			p1.DocumentControler.z0dn(xTextDirectoryFieldElement);
			xTextDirectoryFieldElement.z0rek();
			p1.RefreshLevel = (z0ZzZzwmj)2;
			p1.Result = xTextDirectoryFieldElement;
		}
	}

	[z0ZzZzimj("InsertCustomShape", ReturnValueType = typeof(XTextCustomShapeElement), FunctionID = 75)]
	private void z0ork(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextCustomShapeElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextCustomShapeElement xTextCustomShapeElement = null;
			if (p1.Parameter is XTextCustomShapeElement)
			{
				xTextCustomShapeElement = (XTextCustomShapeElement)p1.Parameter;
			}
			p1.Document.z0bek("shape", xTextCustomShapeElement);
			if (p1.ShowUI && xTextCustomShapeElement == null)
			{
				xTextCustomShapeElement = new XTextCustomShapeElement();
				xTextCustomShapeElement.Width = 200f;
				xTextCustomShapeElement.Height = 200f;
				xTextCustomShapeElement.z0bt(p1.Document);
				if (p1.Parameter is string)
				{
					xTextCustomShapeElement.ID = (string)p1.Parameter;
				}
			}
			if (xTextCustomShapeElement != null)
			{
				xTextCustomShapeElement.z0bt(p1.Document);
				p1.Document.z0srk(xTextCustomShapeElement);
				p1.DocumentControler.z0dn(xTextCustomShapeElement);
				p1.Result = xTextCustomShapeElement;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	[z0ZzZzimj("InsertSection", ReturnValueType = typeof(XTextSectionElement), FunctionID = 86)]
	private void z0prk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document != null)
			{
				XTextContainerElement p2 = null;
				int p3 = 0;
				p1.Document.z0ryk().z0tek(out p2, out p3);
				if (p2 is XTextDocumentBodyElement)
				{
					p1.Enabled = p1.DocumentControler.z0an(typeof(XTextSectionElement));
				}
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextContainerElement p4 = null;
			int p5 = 0;
			p1.Document.z0ryk().z0tek(out p4, out p5);
			if (!(p4 is XTextDocumentBodyElement))
			{
				return;
			}
			XTextSectionElement xTextSectionElement = p1.Parameter as XTextSectionElement;
			if (xTextSectionElement == null)
			{
				xTextSectionElement = new XTextSectionElement();
				xTextSectionElement.CompressOwnerLineSpacing = true;
			}
			xTextSectionElement.z0nu(p4);
			xTextSectionElement.z0bt(p1.Document);
			if (string.IsNullOrEmpty(xTextSectionElement.ID))
			{
				p1.Document.z0bek("section", xTextSectionElement);
			}
			if (string.IsNullOrEmpty(xTextSectionElement.Name))
			{
				xTextSectionElement.Name = xTextSectionElement.ID;
			}
			if (p1.ShowUI && !z0ZzZzlfh.z0eek(p1, xTextSectionElement, (z0ZzZzakh)0))
			{
				xTextSectionElement.Dispose();
				xTextSectionElement = null;
			}
			if (xTextSectionElement != null)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
				xTextParagraphFlagElement.z0oek(-1);
				xTextSectionElement.z0oek(-1);
				xTextSectionElement.z0gu();
				using (z0ZzZzjpk p6 = p1.Document.z0ru())
				{
					z0ZzZzvxj z0ZzZzvxj2 = p1.Document.z0bek(p6, (z0ZzZzcxj)0);
					z0ZzZzvxj2.z0hyk = xTextParagraphFlagElement;
					xTextParagraphFlagElement.z0mr(z0ZzZzvxj2);
					z0ZzZzvxj2.z0hyk = xTextSectionElement;
					xTextSectionElement.z0mr(z0ZzZzvxj2);
				}
				XTextElementList xTextElementList = new XTextElementList();
				xTextElementList.Add(xTextSectionElement);
				p1.Document.z0srk(xTextSectionElement);
				p1.Document.z0ytk();
				int num = p1.Document.z0vek(xTextElementList, p1: true);
				p1.Document.z0nuk();
				if (num > 0)
				{
					int p7 = xTextSectionElement.z0be()[0].z0jrk();
					p1.Document.z0ryk().z0tek(p7, 0);
					p1.Document.OnDocumentContentChanged();
					p1.Result = xTextSectionElement;
					p1.RefreshLevel = (z0ZzZzwmj)2;
				}
			}
		}
	}

	[z0ZzZzimj("InsertCheckBox", ReturnValueType = typeof(XTextCheckBoxElement))]
	private void z0mrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextCheckBoxElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			XTextCheckBoxElement xTextCheckBoxElement = null;
			if (p1.Parameter is XTextCheckBoxElement)
			{
				xTextCheckBoxElement = (XTextCheckBoxElement)p1.Parameter;
			}
			if (xTextCheckBoxElement == null)
			{
				xTextCheckBoxElement = new XTextCheckBoxElement();
				xTextCheckBoxElement.VisualStyle = CheckBoxVisualStyle.SystemDefault;
			}
			xTextCheckBoxElement.z0bt(p1.Document);
			if (string.IsNullOrEmpty(xTextCheckBoxElement.ID))
			{
				p1.Document.z0bek("checkbox", xTextCheckBoxElement);
			}
			if (p1.ShowUI && !z0ZzZzlfh.z0eek(p1, xTextCheckBoxElement, (z0ZzZzakh)0))
			{
				xTextCheckBoxElement.Dispose();
			}
			else if (xTextCheckBoxElement != null)
			{
				z0eek(xTextCheckBoxElement, p1.Document);
				xTextCheckBoxElement.z0bt(p1.Document);
				p1.Document.z0srk(xTextCheckBoxElement);
				z0ZzZzafh.z0rek(p1.Document, new XTextElementList(xTextCheckBoxElement), p2: true);
				z0ZzZzafh.z0yek(p1.Document, xTextCheckBoxElement, p2: false, null);
				p1.Document.z0xek().z0dn(xTextCheckBoxElement);
				p1.RefreshLevel = (z0ZzZzwmj)2;
				p1.Result = xTextCheckBoxElement;
			}
		}
	}

	[z0ZzZzimj("InsertMediaElement")]
	private void z0nrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextControlHostElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextMediaElement xTextMediaElement = p1.Parameter as XTextMediaElement;
			if (xTextMediaElement == null)
			{
				xTextMediaElement = new XTextMediaElement();
				xTextMediaElement.FileName = p1.Parameter as string;
				DocumentContentStyle documentContentStyle = (DocumentContentStyle)p1.Document.z0itk().z0xrk().Clone();
				documentContentStyle.PaddingLeft = XTextObjectElement.z0xek;
				documentContentStyle.PaddingTop = XTextObjectElement.z0xek;
				documentContentStyle.PaddingRight = XTextObjectElement.z0xek;
				documentContentStyle.PaddingBottom = XTextObjectElement.z0xek;
				documentContentStyle.BorderWidth = 1f;
				documentContentStyle.BorderLeft = true;
				documentContentStyle.BorderTop = true;
				documentContentStyle.BorderRight = true;
				documentContentStyle.BorderBottom = true;
				documentContentStyle.BorderStyle = DashStyle.Solid;
				xTextMediaElement.z0oek(p1.Document.z0gnk().GetStyleIndex(documentContentStyle));
				xTextMediaElement.Width = 1000f;
				XTextContentElement xTextContentElement = p1.Document.z0jrk();
				if (xTextContentElement != null)
				{
					xTextMediaElement.Width = ((XTextElement)xTextContentElement).z0ork() - 10f;
				}
				xTextMediaElement.Height = 1000f;
			}
			XTextElement xTextElement = p1.Document.z0itk();
			if (((XTextElement)xTextMediaElement).z0pek() < 0)
			{
				xTextMediaElement.z0oek(xTextElement.z0pek());
			}
			xTextMediaElement.z0bt(p1.Document);
			if (xTextMediaElement.z0ork() <= 0f)
			{
				xTextMediaElement.z0iek(300f);
			}
			if (xTextMediaElement.z0si() <= 0f)
			{
				xTextMediaElement.z0di(300f);
			}
			z0ZzZzafh.z0yek(p1.Document, xTextMediaElement, p2: false, null);
			p1.DocumentControler.z0dn(xTextMediaElement);
			p1.RefreshLevel = (z0ZzZzwmj)2;
			p1.Result = xTextMediaElement;
		}
	}

	[z0ZzZzimj("InsertImageExt", ReturnValueType = typeof(XTextImageElement), FunctionID = 68)]
	private void z0brk_jiejie20260327142557(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextImageElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextImageElement xTextImageElement = null;
			if (p1.Parameter is XTextImageElement)
			{
				xTextImageElement = (XTextImageElement)p1.Parameter;
			}
			else if (p1.Parameter is string)
			{
				string text = (string)p1.Parameter;
				text = text.Trim();
				if (!string.IsNullOrEmpty(text))
				{
					xTextImageElement = new XTextImageElement();
					xTextImageElement.z0eek(text, p1: false);
				}
			}
			else if (p1.Parameter is z0ZzZzedh)
			{
				xTextImageElement = new XTextImageElement();
				xTextImageElement.z0frk().Value = (z0ZzZzedh)p1.Parameter;
			}
			else if (p1.Parameter is z0ZzZzpmk)
			{
				xTextImageElement = new XTextImageElement();
				xTextImageElement.z0rek((z0ZzZzpmk)p1.Parameter);
			}
			else if (p1.Parameter is byte[])
			{
				xTextImageElement = new XTextImageElement();
				z0ZzZzpmk z0ZzZzpmk2 = new z0ZzZzpmk();
				z0ZzZzpmk2.ImageData = (byte[])p1.Parameter;
				xTextImageElement.z0rek(z0ZzZzpmk2);
			}
			if (xTextImageElement != null && string.IsNullOrEmpty(xTextImageElement.ID))
			{
				p1.Document.z0bek("image", xTextImageElement);
			}
			if (xTextImageElement != null)
			{
				xTextImageElement.z0bt(p1.Document);
				xTextImageElement.z0eek(p0: false);
				z0ZzZzafh.z0yek(p1.Document, xTextImageElement, xTextImageElement.z0oek(), null);
				p1.DocumentControler.z0dn(xTextImageElement);
				p1.Result = xTextImageElement;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	[z0ZzZzimj("InsertLineBreak", ShortcutKey = (Keys.Return | Keys.Shift))]
	private void z0vrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextLineBreakElement));
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Document.z0jvk = true;
			try
			{
				p1.Result = p1.DocumentControler.z0op();
			}
			finally
			{
				p1.Document.z0jvk = false;
			}
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("ConvertTextContentToElementLabel")]
	private void z0crk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document != null && p1.Document.z0cuk().z0qrk() != 0)
			{
				p1.Enabled = p1.DocumentControler.z0up() && p1.DocumentControler.z0in().z0tek();
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5 || p1.DocumentControler == null || p1.Document.z0cuk().z0qrk() == 0 || p1.DocumentControler.z0kn())
			{
				return;
			}
			XTextElement xTextElement = p1.Document.z0cuk().z0uek();
			XTextElement xTextElement2 = p1.Document.z0cuk().z0iek();
			XTextContainerElement xTextContainerElement = z0ZzZzafh.z0iek(xTextElement, xTextElement2);
			if (xTextContainerElement is XTextTableElement)
			{
				xTextContainerElement = xTextContainerElement.z0ji();
			}
			else if (xTextContainerElement is XTextTableRowElement)
			{
				xTextContainerElement = xTextContainerElement.z0ji().z0ji();
			}
			int num = -1;
			for (XTextElement xTextElement3 = xTextElement; xTextElement3 != null; xTextElement3 = xTextElement3.z0ji())
			{
				if (xTextElement3.z0ji() == xTextContainerElement)
				{
					num = xTextContainerElement.z0be().IndexOf(xTextElement3);
					break;
				}
			}
			int num2 = -1;
			for (XTextElement xTextElement3 = xTextElement2; xTextElement3 != null; xTextElement3 = xTextElement3.z0ji())
			{
				if (xTextElement3.z0ji() == xTextContainerElement)
				{
					num2 = xTextContainerElement.z0be().IndexOf(xTextElement3);
					break;
				}
			}
			if (num < 0 || num2 < 0 || num2 < num)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			XTextDocumentContentElement xTextDocumentContentElement = xTextContainerElement.z0qek();
			bool flag = false;
			XTextElement xTextElement4 = null;
			for (int i = num; i <= num2; i++)
			{
				XTextElement xTextElement3 = xTextContainerElement.z0be()[i];
				if (!(xTextElement3 is XTextInputFieldElement) && !xTextDocumentContentElement.z0frk().Contains(xTextElement3))
				{
					continue;
				}
				if (xTextElement3 is XTextCharElement || xTextElement3 is XTextLabelElement)
				{
					if (xTextDocumentContentElement.z0frk().Contains(xTextElement3))
					{
						stringBuilder.Append(xTextElement3.Text);
					}
					continue;
				}
				if (xTextElement3 is XTextInputFieldElement || xTextElement3 is XTextCheckBoxElement || xTextElement3 is XTextRadioBoxElement)
				{
					flag = stringBuilder.Length > 0;
					if (xTextElement4 == null)
					{
						xTextElement4 = xTextElement3;
						continue;
					}
					return;
				}
				return;
			}
			if (xTextElement4 == null && stringBuilder.Length > 0)
			{
				xTextElement4 = new XTextLabelElement();
				xTextElement4.z0bt(p1.Document);
				xTextElement4.z0oek(xTextElement.z0pek());
				xTextElement4.Text = stringBuilder.ToString();
			}
			if (xTextElement4 == null || stringBuilder.Length <= 0)
			{
				return;
			}
			p1.Document.z0ytk();
			if (xTextElement4 is XTextInputFieldElement)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xTextElement4;
				if (flag)
				{
					string text = xTextInputFieldElement.LabelText;
					if (text != null)
					{
						text = text.Trim();
					}
					string text2 = stringBuilder.ToString() + text;
					p1.Document.z0imk().z0eek("LabelText", xTextInputFieldElement.LabelText, text2, xTextInputFieldElement);
					xTextInputFieldElement.LabelText = text2;
				}
				else
				{
					string text3 = xTextInputFieldElement.UnitText;
					if (text3 != null)
					{
						text3 = text3.Trim();
					}
					string text4 = text3 + stringBuilder.ToString();
					p1.Document.z0imk().z0eek("UnitText", xTextInputFieldElement.UnitText, text4, xTextInputFieldElement);
					xTextInputFieldElement.UnitText = text4;
				}
			}
			else if (xTextElement4 is XTextCheckBoxElementBase)
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)xTextElement4;
				string text5 = stringBuilder.ToString() + xTextCheckBoxElementBase.Caption;
				string text6 = xTextCheckBoxElementBase.Caption;
				if (text6 != null)
				{
					text6 = text6.Trim();
				}
				text5 = ((!flag) ? (text6 + stringBuilder.ToString()) : (stringBuilder.ToString() + text6));
				p1.Document.z0imk().z0eek("Caption", xTextCheckBoxElementBase.Caption, text5, xTextCheckBoxElementBase);
				xTextCheckBoxElementBase.Caption = text5;
				p1.Document.z0imk().z0eek("CheckAlignLeft", xTextCheckBoxElementBase.CheckAlignLeft, !flag, xTextCheckBoxElementBase);
				xTextCheckBoxElementBase.CheckAlignLeft = !flag;
			}
			z0ZzZzezj z0ZzZzezj2 = new z0ZzZzezj();
			z0ZzZzezj2.z0eek(xTextContainerElement);
			z0ZzZzezj2.z0tek(num);
			z0ZzZzezj2.z0rek(num2 - num + 1);
			z0ZzZzezj2.z0eek(new XTextElementList());
			z0ZzZzezj2.z0yek().Add(xTextElement4);
			xTextElement4.z0xi(p0: true);
			z0ZzZzezj2.z0nek(p0: true);
			z0ZzZzezj2.z0bek(p0: true);
			z0ZzZzezj2.z0oek_jiejie20260327142557(p0: true);
			int num3 = p1.Document.z0bek(z0ZzZzezj2);
			p1.Document.z0nuk();
			if (num3 > 0)
			{
				p1.RefreshLevel = (z0ZzZzwmj)2;
				p1.Result = xTextElement4;
			}
		}
	}

	[z0ZzZzimj("ConvertContentToField", ReturnValueType = typeof(XTextInputFieldElement))]
	private void z0xrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document != null && p1.Document.z0cuk().z0qrk() != 0 && !p1.DocumentControler.z0kn())
			{
				XTextElement xTextElement = p1.Document.z0cuk().z0uek();
				XTextElement xTextElement2 = p1.Document.z0cuk().z0iek();
				XTextElement xTextElement3 = z0ZzZzafh.z0iek(xTextElement, xTextElement2);
				if (xTextElement3 is XTextTableRowElement)
				{
					xTextElement3 = xTextElement3.z0ji().z0ji();
				}
				else if (xTextElement3 is XTextTableElement)
				{
					xTextElement3 = xTextElement3.z0ji();
				}
				while (xTextElement != null && xTextElement.z0ji() != xTextElement3)
				{
					xTextElement = xTextElement.z0ji();
				}
				while (xTextElement2 != null && xTextElement2.z0ji() != xTextElement3)
				{
					xTextElement2 = xTextElement2.z0ji();
				}
				if (p1.DocumentControler.z0lm(xTextElement) && p1.DocumentControler.z0lm(xTextElement2) && p1.DocumentControler.z0xp(xTextElement3, typeof(XTextInputFieldElement), (z0ZzZzbcj)0))
				{
					p1.Enabled = true;
				}
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			XTextElement xTextElement4 = p1.Document.z0cuk().z0uek();
			XTextElement xTextElement5 = p1.Document.z0cuk().z0iek();
			XTextContainerElement xTextContainerElement = z0ZzZzafh.z0iek(xTextElement4, xTextElement5);
			if (xTextContainerElement is XTextTableElement)
			{
				xTextContainerElement = xTextContainerElement.z0ji();
			}
			else if (xTextContainerElement is XTextTableRowElement)
			{
				xTextContainerElement = xTextContainerElement.z0ji().z0ji();
			}
			if (!p1.DocumentControler.z0xp(xTextContainerElement, typeof(XTextInputFieldElement), (z0ZzZzbcj)0))
			{
				return;
			}
			while (xTextElement4 != null && xTextElement4.z0ji() != xTextContainerElement)
			{
				xTextElement4 = xTextElement4.z0ji();
			}
			while (xTextElement5 != null && xTextElement5.z0ji() != xTextContainerElement)
			{
				xTextElement5 = xTextElement5.z0ji();
			}
			XTextInputFieldElement xTextInputFieldElement = null;
			if (p1.Parameter is XTextInputFieldElement)
			{
				xTextInputFieldElement = (XTextInputFieldElement)p1.Parameter;
			}
			else if (p1.Parameter is InputFieldSettings)
			{
				xTextInputFieldElement = new XTextInputFieldElement();
				xTextInputFieldElement.FieldSettings = (InputFieldSettings)p1.Parameter;
			}
			else if (p1.Parameter is z0ZzZzevj)
			{
				xTextInputFieldElement = new XTextInputFieldElement();
				xTextInputFieldElement.ValueBinding = (z0ZzZzevj)p1.Parameter;
			}
			else if (p1.Parameter is ValueValidateStyle)
			{
				xTextInputFieldElement = new XTextInputFieldElement();
				xTextInputFieldElement.ValidateStyle = (ValueValidateStyle)p1.Parameter;
			}
			if (xTextInputFieldElement == null)
			{
				xTextInputFieldElement = new XTextInputFieldElement();
			}
			xTextInputFieldElement.z0bt(p1.Document);
			ElementType elementType = ElementType.None;
			int num = xTextContainerElement.z0be().IndexOf(xTextElement5);
			for (int i = xTextContainerElement.z0be().IndexOf(xTextElement4); i <= num; i++)
			{
				XTextElement xTextElement6 = xTextContainerElement.z0be()[i];
				elementType |= z0ZzZzafh.z0yek(xTextElement6.GetType());
				if (xTextElement6 is XTextParagraphFlagElement)
				{
					xTextInputFieldElement.AcceptChildElementTypes2 |= ElementType.ParagraphFlag;
				}
			}
			xTextInputFieldElement.AcceptChildElementTypes2 = elementType;
			p1.Document.z0bek("field", xTextInputFieldElement);
			xTextInputFieldElement.z0bt(p1.Document);
			if (p1.ShowUI && !z0ZzZzlfh.z0eek(p1, xTextInputFieldElement, (z0ZzZzakh)0))
			{
				xTextInputFieldElement.Dispose();
				xTextInputFieldElement = null;
			}
			if (xTextInputFieldElement == null)
			{
				return;
			}
			int num2 = xTextContainerElement.z0be().IndexOf(xTextElement4);
			int num3 = xTextContainerElement.z0be().IndexOf(xTextElement5);
			for (int j = num2; j <= num3; j++)
			{
				if (!p1.DocumentControler.z0xp(xTextInputFieldElement, xTextContainerElement.z0be()[j].GetType(), (z0ZzZzbcj)0))
				{
					return;
				}
			}
			XTextElement xTextElement7 = p1.Document.z0itk();
			xTextInputFieldElement.z0oek(xTextElement7.z0pek());
			((XTextElement)((XTextFieldElementBase)xTextInputFieldElement).z0jrk()).z0oek(xTextElement7.z0pek());
			((XTextElement)((XTextFieldElementBase)xTextInputFieldElement).z0tek()).z0oek(xTextElement7.z0pek());
			xTextInputFieldElement.z0bt(p1.Document);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextInputFieldElement.z0be().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					z0bpk.Current.z0oek(xTextElement7.z0pek());
				}
			}
			using (z0ZzZzjpk p2 = p1.Document.z0ru())
			{
				z0ZzZzvxj p3 = p1.Document.z0bek(p2, (z0ZzZzcxj)0);
				((XTextFieldElementBase)xTextInputFieldElement).z0jrk().z0mr(p3);
				((XTextFieldElementBase)xTextInputFieldElement).z0tek().z0mr(p3);
			}
			xTextInputFieldElement.z0be().Clear();
			for (int k = num2; k <= num3; k++)
			{
				((zzz.z0ZzZzkuk<XTextElement>)xTextInputFieldElement.z0be()).z0pek(xTextContainerElement.z0be()[k]);
			}
			z0ZzZzezj z0ZzZzezj2 = new z0ZzZzezj();
			z0ZzZzezj2.z0eek(xTextContainerElement);
			z0ZzZzezj2.z0eek(new XTextElementList());
			z0ZzZzezj2.z0yek().Add(xTextInputFieldElement);
			z0ZzZzezj2.z0tek(num2);
			z0ZzZzezj2.z0rek(num3 - num2 + 1);
			z0ZzZzezj2.z0mek(p0: true);
			z0ZzZzezj2.z0eek((z0ZzZzbcj)255);
			z0ZzZzezj2.z0eek(p0: false);
			z0ZzZzezj2.z0nek(p0: true);
			z0ZzZzezj2.z0oek_jiejie20260327142557(p0: true);
			z0ZzZzezj2.z0bek(p0: true);
			p1.Document.z0ytk();
			int num4 = p1.Document.z0bek(z0ZzZzezj2);
			p1.Document.z0nuk();
			p1.RefreshLevel = (z0ZzZzwmj)2;
			if (num4 > 0)
			{
				p1.Result = xTextInputFieldElement;
			}
		}
	}

	[z0ZzZzimj("InsertFileContent", ReturnValueType = typeof(XTextElementList))]
	private void z0zrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.Document != null && p1.DocumentControler.z0an(typeof(XTextElement));
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = null;
			XTextDocument xTextDocument = null;
			if (p1.Parameter is string)
			{
				_ = (string)p1.Parameter;
			}
			else if (p1.Parameter is XTextDocument)
			{
				xTextDocument = (XTextDocument)p1.Parameter;
			}
			else if (p1.Parameter is Stream)
			{
				Stream p2 = (Stream)p1.Parameter;
				xTextDocument = (XTextDocument)p1.Document.z0lr(p0: false);
				xTextDocument.z0bek(p2, null);
			}
			else if (p1.Parameter is TextReader)
			{
				TextReader p3 = (TextReader)p1.Parameter;
				xTextDocument = (XTextDocument)p1.Document.z0lr(p0: false);
				xTextDocument.z0bek(p3, null);
			}
			else if (p1.Parameter is byte[])
			{
				MemoryStream p4 = new MemoryStream((byte[])p1.Parameter);
				xTextDocument = (XTextDocument)p1.Document.z0lr(p0: false);
				xTextDocument.z0bek(p4, null);
			}
			if (xTextDocument != null && xTextDocument.z0xyk() != null && xTextDocument.z0xyk().z0be().Count > 0)
			{
				XTextElementList xTextElementList = xTextDocument.z0xyk().z0be();
				p1.Document.z0krk(xTextElementList);
				if (xTextElementList.Count > 0)
				{
					p1.Document.z0cek(xTextElementList);
					((z0ZzZztcj)p1.DocumentControler).z0om(xTextElementList);
					p1.Result = xTextElementList;
				}
			}
		}
	}
}
