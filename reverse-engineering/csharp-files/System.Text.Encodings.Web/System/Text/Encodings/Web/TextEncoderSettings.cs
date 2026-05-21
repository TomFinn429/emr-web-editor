using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Unicode;

namespace System.Text.Encodings.Web;

public class TextEncoderSettings
{
	private AllowedBmpCodePointsBitmap _allowedCodePointsBitmap;

	public TextEncoderSettings(params UnicodeRange[] P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.allowedRanges);
		}
		AllowRanges(P_0);
	}

	public virtual void AllowRange(UnicodeRange P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.range);
		}
		int firstCodePoint = P_0.FirstCodePoint;
		int length = P_0.Length;
		for (int i = 0; i < length; i++)
		{
			int num = firstCodePoint + i;
			_allowedCodePointsBitmap.AllowChar((char)num);
		}
	}

	public virtual void AllowRanges(params UnicodeRange[] P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.ranges);
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			AllowRange(P_0[i]);
		}
	}

	public virtual IEnumerable<int> GetAllowedCodePoints()
	{
		for (int i = 0; i <= 65535; i++)
		{
			if (_allowedCodePointsBitmap.IsCharAllowed((char)i))
			{
				yield return i;
			}
		}
	}

	internal ref readonly AllowedBmpCodePointsBitmap GetAllowedCodePointsBitmap()
	{
		if (GetType() == typeof(TextEncoderSettings))
		{
			return ref _allowedCodePointsBitmap;
		}
		StrongBox<AllowedBmpCodePointsBitmap> strongBox = new StrongBox<AllowedBmpCodePointsBitmap>();
		foreach (int allowedCodePoint in GetAllowedCodePoints())
		{
			if ((uint)allowedCodePoint <= 65535u)
			{
				strongBox.Value.AllowChar((char)allowedCodePoint);
			}
		}
		return ref strongBox.Value;
	}
}
