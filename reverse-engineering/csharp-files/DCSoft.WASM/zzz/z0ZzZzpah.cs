using System;
using System.Collections;
using System.Reflection;

namespace zzz;

[DefaultMember("ItemOf")]
public abstract class z0ZzZzpah : IEnumerable, IDisposable
{
	protected virtual void z0dg()
	{
	}

	private void z0eek()
	{
		z0dg();
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		this.z0eek();
	}

	public virtual z0ZzZzoah z0eek(int p0)
	{
		return z0df(p0);
	}

	public abstract IEnumerator GetEnumerator();

	public abstract z0ZzZzoah z0df(int p0);

	public abstract int z0sf();
}
