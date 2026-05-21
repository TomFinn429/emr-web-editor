using System;
using zzz;

namespace DCSoft.Writer.Dom;

public class DocumentContentMerger : DocumentContentMergerBase
{
	internal override bool z0lb(XTextObjectElement p0, XTextObjectElement p1, z0mgj p2)
	{
		bool flag = true;
		if (p0 is XTextNewMedicalExpressionElement)
		{
			XTextNewMedicalExpressionElement xTextNewMedicalExpressionElement = (XTextNewMedicalExpressionElement)p0;
			XTextNewMedicalExpressionElement xTextNewMedicalExpressionElement2 = (XTextNewMedicalExpressionElement)p1;
			if (!z0ZzZzafh.z0yek(xTextNewMedicalExpressionElement.Text, xTextNewMedicalExpressionElement2.Text))
			{
				return false;
			}
			if (xTextNewMedicalExpressionElement.ExpressionStyle != xTextNewMedicalExpressionElement2.ExpressionStyle)
			{
				return false;
			}
			flag = true;
		}
		else if (p0 is XTextNewBarcodeElement)
		{
			XTextNewBarcodeElement xTextNewBarcodeElement = (XTextNewBarcodeElement)p0;
			XTextNewBarcodeElement xTextNewBarcodeElement2 = (XTextNewBarcodeElement)p1;
			if (!z0ZzZzafh.z0yek(xTextNewBarcodeElement.Text, xTextNewBarcodeElement2.Text))
			{
				return false;
			}
			if (xTextNewBarcodeElement.BarcodeStyle2 != xTextNewBarcodeElement2.BarcodeStyle2)
			{
				return false;
			}
			flag = true;
		}
		if (flag)
		{
			if (Math.Abs(p0.Width - p1.Width) + Math.Abs(p0.Height - p1.Height) > 6f)
			{
				return false;
			}
		}
		else if (p0 is XTextMediaElement)
		{
			XTextMediaElement obj = (XTextMediaElement)p0;
			if (!z0ZzZzafh.z0yek(p1: ((XTextMediaElement)p1).FileName, p0: obj.FileName))
			{
				return false;
			}
		}
		else if (p0 is XTextNewBarcodeElement)
		{
			XTextNewBarcodeElement obj2 = (XTextNewBarcodeElement)p0;
			XTextNewBarcodeElement xTextNewBarcodeElement3 = (XTextNewBarcodeElement)p1;
			if (obj2.BarcodeStyle2 != xTextNewBarcodeElement3.BarcodeStyle2)
			{
				return false;
			}
		}
		return z0ZzZzafh.z0yek(p0.Text, p1.Text);
	}

	protected override XTextElement z0zn(XTextElement p0, XTextElement p1)
	{
		if (p0 is z0eck)
		{
			return p0;
		}
		if (p0 is XTextCheckBoxElementBase)
		{
			XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)p0;
			XTextCheckBoxElementBase xTextCheckBoxElementBase2 = (XTextCheckBoxElementBase)p1;
			if (z0pek != null && xTextCheckBoxElementBase.Checked != xTextCheckBoxElementBase2.Checked)
			{
				xTextCheckBoxElementBase2.CheckedUserHistories = xTextCheckBoxElementBase.CheckedUserHistories;
				xTextCheckBoxElementBase2.z0eek(z0pek.z0zek(), z0pek.z0yek());
				return xTextCheckBoxElementBase2;
			}
			if (xTextCheckBoxElementBase.z0hrk())
			{
				xTextCheckBoxElementBase2.CheckedUserHistories = xTextCheckBoxElementBase.CheckedUserHistories;
				return xTextCheckBoxElementBase2;
			}
		}
		z0ZzZzrzj z0ZzZzrzj = p0.z0aek();
		z0ZzZzrzj z0ZzZzrzj2 = p1.z0aek();
		if (z0ZzZzrzj.z0nrk >= 0 || z0ZzZzrzj.z0jyk >= 0)
		{
			if (z0ZzZzrzj.z0tyk != z0ZzZzrzj2.z0tyk || z0ZzZzrzj.z0wtk != z0ZzZzrzj2.z0wtk || z0ZzZzrzj.z0gyk != z0ZzZzrzj2.z0gyk || z0ZzZzrzj.z0vtk_jiejie20260327142557 != z0ZzZzrzj2.z0vtk_jiejie20260327142557 || z0ZzZzrzj.z0gtk != z0ZzZzrzj2.z0gtk || z0ZzZzrzj.z0euk != z0ZzZzrzj2.z0euk || z0ZzZzrzj.z0uyk != z0ZzZzrzj2.z0uyk || z0ZzZzrzj.z0bek != z0ZzZzrzj2.z0bek || z0ZzZzrzj.z0ark != z0ZzZzrzj2.z0ark || z0ZzZzrzj.z0ltk != z0ZzZzrzj2.z0ltk || z0ZzZzrzj.z0huk != z0ZzZzrzj2.z0huk || z0ZzZzrzj.z0yyk != z0ZzZzrzj2.z0yyk || z0ZzZzrzj.z0yrk != z0ZzZzrzj2.z0yrk)
			{
				return p1;
			}
			return p0;
		}
		return p1;
	}

	protected override byte[] z0xn(XTextElement p0)
	{
		return z0ZzZzftk.z0eek(p0, 2);
	}
}
