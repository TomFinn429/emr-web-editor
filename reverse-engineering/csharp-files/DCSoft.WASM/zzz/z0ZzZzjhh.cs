using System.IO;
using DCSoft.WASM;

namespace zzz;

public abstract class z0ZzZzjhh : z0ZzZzxuk
{
	protected abstract void z0xa(object p0, z0ZzZzkhh p1);

	public virtual bool z0za(z0ZzZzcah p0)
	{
		return false;
	}

	protected abstract object z0lq(z0ZzZzlhh p0);

	public object z0wq(TextReader p0)
	{
		z0ZzZzihh p1 = WriterControlForWASM.z0vek(p0.ReadToEnd());
		return z0aq(p1);
	}

	protected virtual z0ZzZzkhh z0kq()
	{
		return null;
	}

	public void z0qq(z0ZzZzhqh p0, object p1)
	{
		z0ZzZzkhh z0ZzZzkhh2 = z0kq();
		z0ZzZzkhh2.z0eek(p0);
		z0xa(p1, z0ZzZzkhh2);
	}

	protected virtual z0ZzZzlhh z0jq()
	{
		return null;
	}

	public object z0aq(z0ZzZzcah p0)
	{
		z0ZzZzlhh z0ZzZzlhh2 = z0jq();
		z0ZzZzlhh2.z0eek(p0);
		object result = z0lq(z0ZzZzlhh2);
		z0ZzZzlhh2.z0iek();
		return result;
	}
}
