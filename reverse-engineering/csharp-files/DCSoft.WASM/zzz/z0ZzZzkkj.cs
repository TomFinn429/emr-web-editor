using System;
using DCSystem_Drawing;

namespace zzz;

internal abstract class z0ZzZzkkj
{
	private readonly double z0rek_jiejie20260327142557;

	private z0ZzZzjej z0yek;

	private readonly double z0uek;

	private readonly Color z0iek;

	private readonly Color z0pek;

	protected z0ZzZzkkj(z0ZzZzsxk p0)
	{
		z0iek = p0.z0tek();
		z0pek = p0.z0rek();
		z0rek_jiejie20260327142557 = 0.699999988079071;
		z0uek = 6.0;
		z0yek = new z0ZzZzjej();
	}

	protected void z0eek(float p0)
	{
		double num = Math.PI * (double)p0 / 180.0;
		double num2 = Math.Cos(num);
		double num3 = Math.Sin(num);
		z0yek = z0ZzZzjej.z0rek(z0yek, new z0ZzZzjej(num2, 0.0 - num3, num3, num2, 0.0, 0.0));
	}

	internal z0ZzZzrwj z0eek(z0ZzZziwj p0, z0ZzZzugj p1)
	{
		double num = z0isk();
		double num2 = z0rsk() / 2.0;
		z0ZzZzlej z0ZzZzlej2 = new z0ZzZzlej(z0ZzZzjej.z0rek(new z0ZzZzjej(1.0, 0.0, 0.0, -1.0, 0.0, p0.z0rek()), z0yek), new z0ZzZziwj(0.0 - num2, 0.0 - num2, num + num2, num + num2), num, num, p1);
		using z0ZzZzsgj z0ZzZzsgj2 = new z0ZzZzsgj(z0ZzZzlej2.z0rek());
		z0msk(z0ZzZzsgj2);
		z0ZzZzlej2.z0eek(z0ZzZzsgj2.z0oek());
		return z0ZzZzlej2;
	}

	internal static z0ZzZzkkj z0eek(z0ZzZzsxk p0)
	{
		return p0.z0eek_jiejie20260327142557() switch
		{
			(z0ZzZzcfh)5 => new z0ZzZzrzk(p0), 
			(z0ZzZzcfh)6 => new z0ZzZzczk(p0), 
			(z0ZzZzcfh)2 => new z0ZzZzgkj(p0), 
			(z0ZzZzcfh)52 => new z0ZzZzvzk(p0), 
			(z0ZzZzcfh)41 => new z0ZzZzhkj(p0), 
			(z0ZzZzcfh)31 => new z0ZzZzzzk(p0), 
			(z0ZzZzcfh)50 => new z0ZzZzzjj(p0), 
			(z0ZzZzcfh)27 => new z0ZzZzqkj(p0), 
			(z0ZzZzcfh)29 => new z0ZzZzmkj(p0), 
			(z0ZzZzcfh)23 => new z0ZzZzllj(p0), 
			(z0ZzZzcfh)21 => new z0ZzZzwkj(p0), 
			(z0ZzZzcfh)25 => new z0ZzZzihj(p0), 
			(z0ZzZzcfh)3 => new z0ZzZzrhj(p0), 
			(z0ZzZzcfh)30 => new z0ZzZzklj(p0), 
			(z0ZzZzcfh)26 => new z0ZzZzekj(p0), 
			(z0ZzZzcfh)28 => new z0ZzZznkj(p0), 
			(z0ZzZzcfh)40 => new z0ZzZzslj(p0), 
			(z0ZzZzcfh)4 => new z0ZzZzulj(p0), 
			(z0ZzZzcfh)22 => new z0ZzZzxzk(p0), 
			(z0ZzZzcfh)20 => new z0ZzZzakj(p0), 
			(z0ZzZzcfh)24 => new z0ZzZzuhj(p0), 
			(z0ZzZzcfh)54 => new z0ZzZzkhj(p0), 
			(z0ZzZzcfh)7 => new z0ZzZzalj(p0), 
			(z0ZzZzcfh)34 => new z0ZzZzhlj(p0), 
			(z0ZzZzcfh)35 => new z0ZzZzflj(p0), 
			(z0ZzZzcfh)32 => new z0ZzZzjlj(p0), 
			(z0ZzZzcfh)33 => new z0ZzZzglj(p0), 
			(z0ZzZzcfh)53 => new z0ZzZzvkj(p0), 
			(z0ZzZzcfh)38 => new z0ZzZznhj(p0), 
			(z0ZzZzcfh)51 => new z0ZzZzcjj(p0), 
			(z0ZzZzcfh)8 => new z0ZzZzxkj(p0), 
			(z0ZzZzcfh)9 => new z0ZzZzzkj(p0), 
			(z0ZzZzcfh)10 => new z0ZzZzljj(p0), 
			(z0ZzZzcfh)11 => new z0ZzZzkjj(p0), 
			(z0ZzZzcfh)12 => new z0ZzZzjjj(p0), 
			(z0ZzZzcfh)13 => new z0ZzZzhjj(p0), 
			(z0ZzZzcfh)14 => new z0ZzZzgjj(p0), 
			(z0ZzZzcfh)15 => new z0ZzZzfjj(p0), 
			(z0ZzZzcfh)16 => new z0ZzZzdjj(p0), 
			(z0ZzZzcfh)17 => new z0ZzZzsjj(p0), 
			(z0ZzZzcfh)18 => new z0ZzZzajj(p0), 
			(z0ZzZzcfh)19 => new z0ZzZzqjj(p0), 
			(z0ZzZzcfh)45 => new z0ZzZzrlj(p0), 
			(z0ZzZzcfh)46 => new z0ZzZzelj(p0), 
			(z0ZzZzcfh)43 => new z0ZzZzejj(p0), 
			(z0ZzZzcfh)44 => new z0ZzZzwlj(p0), 
			(z0ZzZzcfh)49 => new z0ZzZzjhj(p0), 
			(z0ZzZzcfh)39 => new z0ZzZzthj(p0), 
			(z0ZzZzcfh)48 => new z0ZzZzahj(p0), 
			(z0ZzZzcfh)37 => new z0ZzZzskj(p0), 
			(z0ZzZzcfh)36 => new z0ZzZzxjj(p0), 
			(z0ZzZzcfh)42 => new z0ZzZzyhj(p0), 
			(z0ZzZzcfh)47 => new z0ZzZzvjj(p0), 
			_ => null, 
		};
	}

	protected virtual void z0msk(z0ZzZzsgj p0)
	{
		p0.z0tek(z0ZzZznlj.z0eek(z0pek));
		z0ZzZzbqj obj = new z0ZzZzbqj();
		obj.z0rek((float)(int)z0pek.A / 255f);
		p0.z0rek(obj);
		p0.z0oek(new z0ZzZziwj(new z0ZzZzywj(0.0, 0.0), new z0ZzZzywj(z0isk(), z0isk())));
		p0.z0tek(z0ZzZznlj.z0eek(z0iek));
		p0.z0rek(new z0ZzZzpwj((float)(int)z0iek.R / 255f, (float)(int)z0iek.G / 255f, (float)(int)z0iek.B / 255f));
		z0ZzZzbqj obj2 = new z0ZzZzbqj();
		obj2.z0rek((double)(int)z0iek.A / 255.0);
		obj2.z0eek((double)(int)z0iek.A / 255.0);
		p0.z0rek(obj2);
		p0.z0yek(z0rsk());
		p0.z0rek(z0sak());
	}

	protected virtual double z0rsk()
	{
		return z0rek_jiejie20260327142557;
	}

	protected virtual z0ZzZzxqj z0sak()
	{
		return (z0ZzZzxqj)2;
	}

	protected void z0eek(z0ZzZzjej p0)
	{
		z0yek = z0ZzZzjej.z0rek(z0yek, p0);
	}

	protected virtual double z0isk()
	{
		return z0uek;
	}
}
