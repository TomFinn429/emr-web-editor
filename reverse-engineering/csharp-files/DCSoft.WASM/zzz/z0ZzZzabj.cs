using System;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzabj
{
	private XTextElement z0eek;

	private int z0rek;

	private bool z0tek;

	private z0ZzZzdbj z0yek;

	private XTextElement z0uek;

	private FormViewMode z0iek;

	private XTextElement z0oek;

	private PageContentPartyStyle z0pek = PageContentPartyStyle.Body;

	private int z0mek;

	private XTextElement z0nek;

	private PageViewMode z0bek;

	public void Restore()
	{
		z0yek.z0eek(z0iek);
		z0yek.z0qrk(z0tek);
		z0yek.z0eek(z0bek);
		z0yek.z0eek(z0pek);
		int num = -1;
		int num2 = -1;
		XTextDocument xTextDocument = z0yek.z0ruk();
		if (z0uek != null)
		{
			num = xTextDocument.z0ryk().IndexOf(z0uek);
		}
		if (num < 0)
		{
			num = xTextDocument.z0ryk().IndexOf(z0oek);
			if (num >= 0)
			{
				num++;
			}
		}
		if (num < 0)
		{
			num = z0rek;
		}
		if (z0eek != null)
		{
			num2 = xTextDocument.z0ryk().IndexOf(z0eek);
		}
		if (num2 < 0)
		{
			num2 = xTextDocument.z0ryk().IndexOf(z0nek);
			if (num2 >= 0)
			{
				num2++;
			}
		}
		int num3 = 0;
		num3 = ((num2 < 0) ? z0mek : (num2 - num));
		xTextDocument.z0ryk().z0tek(num, num3);
		z0yek.z0puk_jiejie20260327142557();
	}

	public z0ZzZzabj(z0ZzZzdbj p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("ctl");
		}
		z0yek = p0;
		z0iek = p0.z0ook();
		z0tek = p0.z0ryk();
		z0bek = p0.z0qtk();
		XTextDocument xTextDocument = p0.z0ruk();
		z0pek = xTextDocument.z0oik();
		z0rek = xTextDocument.z0cuk().z0nek();
		z0mek = xTextDocument.z0cuk().z0qrk();
		if (z0rek >= 0)
		{
			z0oek = xTextDocument.z0ryk().SafeGet(z0rek - 1);
			z0uek = xTextDocument.z0ryk().SafeGet(z0rek);
		}
		int num = z0rek + z0mek;
		if (num >= 0)
		{
			z0nek = xTextDocument.z0ryk().SafeGet(num - 1);
			z0eek = xTextDocument.z0ryk().SafeGet(num);
		}
	}
}
