using System;
using zzz;

namespace DCSoft.Writer.Dom;

public class DetectResultForValueBindingModified
{
	private z0ZzZzevj z0eek;

	private string z0rek;

	private string z0tek;

	private XTextElement z0yek;

	public string NewValue => z0tek;

	public string CurrentValue => z0rek;

	public XTextElement Element => z0yek;

	public z0ZzZzevj Binding => z0eek;

	public DetectResultForValueBindingModified(z0ZzZzevj binding, XTextElement element, string currentValue, string newValue)
	{
		if (binding == null)
		{
			throw new ArgumentNullException("binding");
		}
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		z0eek = binding;
		z0yek = element;
		z0rek = currentValue;
		z0tek = newValue;
	}
}
