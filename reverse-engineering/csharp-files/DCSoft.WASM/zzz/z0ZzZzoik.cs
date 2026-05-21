using System;
using System.Collections;

namespace zzz;

public class z0ZzZzoik : IEnumerable, IDisposable
{
	private class z0dxk : IEnumerator
	{
		private class z0ock
		{
			public readonly IEnumerator z0eek;

			public readonly object z0rek;

			public z0ock(object p0, IEnumerator p1, bool p2)
			{
				z0rek = p0;
				if (p2)
				{
					ArrayList arrayList = new ArrayList();
					while (p1.MoveNext())
					{
						arrayList.Add(p1.Current);
					}
					z0eek = arrayList.GetEnumerator();
				}
				else
				{
					z0eek = p1;
				}
			}
		}

		private IEnumerator z0uek;

		private readonly zzz.z0ZzZzsuk<z0ock> z0iek = new zzz.z0ZzZzsuk<z0ock>();

		private bool z0oek;

		private bool z0pek = true;

		private z0ZzZzoik z0mek;

		public object Current
		{
			get
			{
				if (z0pek)
				{
					return null;
				}
				if (z0iek.z0uek() > 0)
				{
					return z0iek.z0rek().z0eek.Current;
				}
				return null;
			}
		}

		public bool MoveNext()
		{
			z0mek.z0uek = this;
			while (z0eek())
			{
				object current = Current;
				if (z0mek.z0wp(current))
				{
					z0mek.z0pek++;
					return true;
				}
			}
			return false;
		}

		private bool z0eek()
		{
			if (z0iek.z0uek() > 0)
			{
				IEnumerator enumerator = z0iek.z0rek().z0eek;
				if (z0pek)
				{
					z0pek = false;
					return enumerator.MoveNext();
				}
				if (enumerator != null && enumerator.Current != null)
				{
					z0ock z0ock = null;
					if (z0oek)
					{
						z0oek = false;
					}
					else
					{
						IEnumerable childNodes = z0mek.GetChildNodes(enumerator.Current);
						if (childNodes != null)
						{
							z0ock = new z0ock(enumerator.Current, childNodes.GetEnumerator(), z0mek.z0rek());
						}
					}
					if (z0ock != null)
					{
						z0iek.z0eek(z0ock);
					}
				}
				while (z0iek.z0uek() > 0)
				{
					IEnumerator enumerator2 = z0iek.z0rek().z0eek;
					if (z0uek == enumerator2)
					{
						z0uek = null;
						return true;
					}
					if (enumerator2.MoveNext())
					{
						return true;
					}
					z0iek.z0tek();
				}
			}
			return false;
		}

		public void Reset()
		{
			z0mek.z0pek = 0;
			z0iek.z0yek();
			if (z0mek.z0mek != null)
			{
				z0iek.z0eek(new z0ock(z0mek.z0tek, z0mek.z0mek.GetEnumerator(), z0mek.z0rek()));
				z0pek = true;
			}
			else if (z0mek.z0oek != null)
			{
				ArrayList arrayList = new ArrayList();
				object parent = z0mek.z0oek;
				while (parent != null)
				{
					arrayList.Insert(0, parent);
					parent = z0mek.GetParent(parent);
					if (parent != null && arrayList.Contains(parent))
					{
						break;
					}
				}
				z0eek(arrayList);
			}
			else if (z0mek.z0iek != null && z0mek.z0iek.Count > 0)
			{
				z0eek(z0mek.z0iek);
			}
		}

		public void z0rek()
		{
			z0oek = true;
		}

		public object z0tek()
		{
			if (z0iek.z0uek() > 0)
			{
				return z0iek.z0rek().z0rek;
			}
			return null;
		}

		public z0dxk(z0ZzZzoik p0)
		{
			if (p0 == null)
			{
				throw new ArgumentNullException("parent");
			}
			z0mek = p0;
			Reset();
		}

		public void z0yek()
		{
			z0mek = null;
			if (z0iek != null)
			{
				z0iek.z0yek();
			}
		}

		private void z0eek(IList p0)
		{
			z0mek.z0pek = 0;
			z0pek = false;
			z0iek.z0yek();
			z0iek.z0eek(new z0ock(null, new object[1] { p0[0] }.GetEnumerator(), z0mek.z0rek()));
			z0iek.z0rek().z0eek.MoveNext();
			for (int i = 0; i < p0.Count - 1; i++)
			{
				object obj = p0[i];
				IEnumerable childNodes = z0mek.GetChildNodes(obj);
				if (childNodes == null)
				{
					throw new Exception("TreeNodeEnumerable:this._Parent._GetChildNodeHandler(p)==null");
				}
				object obj2 = p0[i + 1];
				IEnumerator enumerator = childNodes.GetEnumerator();
				z0iek.z0eek(new z0ock(obj, enumerator, z0mek.z0rek()));
				bool flag = false;
				int num = 1000000;
				while (enumerator.MoveNext())
				{
					if (enumerator.Current == obj2)
					{
						z0uek = enumerator;
						flag = true;
						break;
					}
					if (num-- < 0)
					{
						throw new Exception("TreeNodeEnumerable:可能死循环");
					}
				}
				if (!flag)
				{
					throw new Exception("TreeNodeEnumerable:" + childNodes.GetType().FullName + "，没找到指定子节点");
				}
			}
		}
	}

	protected object z0tek;

	private bool z0yek;

	private z0dxk z0uek;

	private IList z0iek;

	private object z0oek;

	private int z0pek;

	protected IEnumerable z0mek;

	public object CurrentParent
	{
		get
		{
			if (z0uek != null)
			{
				return z0uek.z0tek();
			}
			return null;
		}
	}

	public int LastPosition => z0pek;

	public virtual bool z0wp(object p0)
	{
		return true;
	}

	public virtual object GetParent(object childNode)
	{
		return null;
	}

	public IEnumerator GetEnumerator()
	{
		z0dxk result = (z0uek = new z0dxk(this));
		z0pek = 0;
		return result;
	}

	public virtual IEnumerable GetChildNodes(object instance)
	{
		return null;
	}

	protected z0ZzZzoik(IList p0, bool p1 = false)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootNode");
		}
		if (p1)
		{
			z0iek = p0;
		}
		else
		{
			z0mek = p0;
		}
	}

	public void CancelChild()
	{
		if (z0uek != null)
		{
			z0uek.z0rek();
		}
	}

	protected z0ZzZzoik(object p0, bool p1 = false)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootNode");
		}
		if (p1)
		{
			z0oek = p0;
			return;
		}
		z0mek = new object[1] { p0 };
	}

	protected z0ZzZzoik()
	{
	}

	public virtual void z0eek()
	{
		z0mek = null;
		z0tek = null;
		z0oek = null;
		if (z0uek != null)
		{
			z0uek.z0yek();
			z0uek = null;
		}
		z0iek = null;
	}

	public void Dispose()
	{
		z0eek();
	}

	public bool z0rek()
	{
		return z0yek;
	}

	public void z0eek(bool p0)
	{
		z0yek = p0;
	}
}
