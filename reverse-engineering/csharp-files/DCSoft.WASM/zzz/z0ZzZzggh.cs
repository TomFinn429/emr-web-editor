using System;
using System.Collections.Generic;
using DCSystem_Drawing;

namespace zzz;

public abstract class z0ZzZzggh : IDisposable
{
	private class z0mnk
	{
		public object z0eek;

		public int z0rek;

		public string z0tek;
	}

	private Stack<z0mnk> z0eek;

	public virtual bool IsForSignContent => false;

	public abstract void WritePropertyValue(string name, string v);

	public abstract void WritePropertyValue(string name, Enum v, Enum defaultValue);

	public virtual bool IsEmptyInstance(object instance)
	{
		return false;
	}

	public virtual void WritePropertyValues(object instance)
	{
		if (instance == null)
		{
			throw new ArgumentNullException("instance");
		}
		GetProvider(instance.GetType()).z0sj(this, instance);
	}

	public abstract void WritePropertyValue(string name, long v, long defaultValue = 0L);

	public abstract void WritePropertyValue(string name, z0ZzZzimk v);

	public virtual object GetParentInstance()
	{
		if (z0eek != null && z0eek.Count > 1)
		{
			z0mnk z0mnk = z0eek.Pop();
			z0mnk z0mnk2 = z0eek.Peek();
			z0eek.Push(z0mnk);
			return z0mnk2.z0eek;
		}
		return null;
	}

	public abstract void WritePropertyValue(string name, byte[] v);

	public abstract void WritePropertyValue(string name, int v, int defaultValue = 0);

	public abstract void WritePropertyValue(string name, double v, double defaultValue = 0.0);

	public abstract void WritePropertyValue(string name, float v, float defaultValue = 0f);

	public abstract void WritePropertyValue(string name, DateTime v, DateTime defaultValue);

	public abstract void WritePropertyValue(string name, char v, char defaultValue = '\0');

	public abstract void WritePropertyValue(string name, Color v, Color defaultValue);

	public virtual z0ZzZzfgh GetProvider(Type t)
	{
		return z0ZzZzdgh.z0eek().z0eek(t);
	}

	public virtual void Close()
	{
	}

	public virtual void WriteStartInstance(string name, object instance)
	{
		if (instance == null)
		{
			throw new ArgumentNullException("instance");
		}
		z0mnk z0mnk = new z0mnk();
		z0mnk.z0eek = instance;
		z0mnk.z0tek = name;
		z0eek.Push(z0mnk);
	}

	public virtual void WriteEndInstance()
	{
		z0eek.Pop();
	}

	public virtual object GetCurrentInstance()
	{
		if (z0eek != null && z0eek.Count > 0)
		{
			return z0eek.Peek().z0eek;
		}
		return null;
	}

	public abstract void WritePropertyValue(string name, DateTime v);

	public abstract void WritePropertyValue(string name, byte v, byte defaultValue = 0);

	public abstract void WritePropertyValue(string name, bool v, bool defaultValue = false);

	public abstract void WritePropertyValue(string name, z0ZzZzpmk v);

	public virtual void WriteEndDocument()
	{
		z0eek = null;
	}

	public abstract void WritePropertyValue(string name, decimal v, decimal defaultValue);

	public virtual void Dispose()
	{
		Close();
	}

	public virtual void WriteStartDocument()
	{
		z0eek = new Stack<z0mnk>();
	}

	public abstract void WritePropertyValueInstance(string name, object instance);
}
