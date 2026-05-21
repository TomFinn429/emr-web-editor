using System;
using DCSoft.Drawing;

namespace zzz;

public class z0ZzZzgmk
{
	public static z0ZzZzpdh[] z0eek(z0ZzZzbdh p0, RectangleSlantSplitStyle p1)
	{
		return p1 switch
		{
			RectangleSlantSplitStyle.None => null, 
			RectangleSlantSplitStyle.TopLeftOneLine => new z0ZzZzpdh[2]
			{
				new z0ZzZzpdh(p0.z0oek(), p0.z0pek()),
				new z0ZzZzpdh(p0.z0mek(), p0.z0nek())
			}, 
			RectangleSlantSplitStyle.TopLeftTwoLines => new z0ZzZzpdh[4]
			{
				new z0ZzZzpdh(p0.z0oek(), p0.z0pek()),
				new z0ZzZzpdh(p0.z0mek(), p0.z0pek() + p0.z0iek() * 0.6f),
				new z0ZzZzpdh(p0.z0oek(), p0.z0pek()),
				new z0ZzZzpdh(p0.z0oek() + p0.z0uek() * 0.7f, p0.z0nek())
			}, 
			RectangleSlantSplitStyle.TopRightOneLine => new z0ZzZzpdh[2]
			{
				new z0ZzZzpdh(p0.z0mek(), p0.z0pek()),
				new z0ZzZzpdh(p0.z0oek(), p0.z0nek())
			}, 
			RectangleSlantSplitStyle.TopRightTwoLines => new z0ZzZzpdh[4]
			{
				new z0ZzZzpdh(p0.z0mek(), p0.z0pek()),
				new z0ZzZzpdh(p0.z0oek(), p0.z0pek() + p0.z0iek() * 0.6f),
				new z0ZzZzpdh(p0.z0mek(), p0.z0pek()),
				new z0ZzZzpdh(p0.z0oek() + p0.z0uek() * 0.3f, p0.z0nek())
			}, 
			RectangleSlantSplitStyle.BottomLeftOneLine => new z0ZzZzpdh[2]
			{
				new z0ZzZzpdh(p0.z0oek(), p0.z0nek()),
				new z0ZzZzpdh(p0.z0mek(), p0.z0pek())
			}, 
			RectangleSlantSplitStyle.BottomLeftTwoLines => new z0ZzZzpdh[4]
			{
				new z0ZzZzpdh(p0.z0oek(), p0.z0nek()),
				new z0ZzZzpdh(p0.z0mek(), p0.z0pek() + p0.z0iek() * 0.4f),
				new z0ZzZzpdh(p0.z0oek(), p0.z0nek()),
				new z0ZzZzpdh(p0.z0oek() + p0.z0uek() * 0.7f, p0.z0pek())
			}, 
			RectangleSlantSplitStyle.BottomRightOneLine => new z0ZzZzpdh[2]
			{
				new z0ZzZzpdh(p0.z0mek(), p0.z0nek()),
				new z0ZzZzpdh(p0.z0oek(), p0.z0pek())
			}, 
			RectangleSlantSplitStyle.BottomRigthTwoLines => new z0ZzZzpdh[4]
			{
				new z0ZzZzpdh(p0.z0mek(), p0.z0nek()),
				new z0ZzZzpdh(p0.z0oek() + p0.z0uek() * 0.4f, p0.z0pek()),
				new z0ZzZzpdh(p0.z0mek(), p0.z0nek()),
				new z0ZzZzpdh(p0.z0oek(), p0.z0pek() + p0.z0iek() * 0.6f)
			}, 
			_ => null, 
		};
	}

	public static void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1, z0ZzZzudh p2, RectangleSlantSplitStyle p3)
	{
		if (p1.z0bek())
		{
			return;
		}
		if (p2 == null)
		{
			throw new ArgumentNullException("p");
		}
		z0ZzZzpdh[] array = z0eek(p1, p3);
		if (array != null)
		{
			for (int i = 0; i < array.Length; i += 2)
			{
				p0.z0eek(p2, array[i], array[i + 1]);
			}
		}
	}
}
