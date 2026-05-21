using System;
using System.Collections;

namespace zzz;

internal sealed class z0ZzZzlah : IEnumerator
{
	internal bool z0iek;

	internal z0ZzZzoah z0oek;

	internal z0ZzZzoah z0pek;

	private object z0eek()
	{
		return z0uek();
	}

	object IEnumerator.get_Current()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}

	private void z0rek()
	{
		z0iek = true;
		z0oek = z0pek.z0iek();
	}

	void IEnumerator.Reset()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0rek
		this.z0rek();
	}

	private bool z0tek()
	{
		return z0yek();
	}

	bool IEnumerator.MoveNext()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0tek
		return this.z0tek();
	}

	internal bool z0yek()
	{
		if (z0iek)
		{
			z0oek = z0pek.z0iek();
			z0iek = false;
		}
		else if (z0oek != null)
		{
			z0oek = z0oek.z0qf();
		}
		return z0oek != null;
	}

	internal z0ZzZzoah z0uek()
	{
		if (z0iek || z0oek == null)
		{
			throw new InvalidOperationException();
		}
		return z0oek;
	}

	internal z0ZzZzlah(z0ZzZzoah p0)
	{
		z0pek = p0;
		z0oek = p0.z0iek();
		z0iek = true;
	}
}
