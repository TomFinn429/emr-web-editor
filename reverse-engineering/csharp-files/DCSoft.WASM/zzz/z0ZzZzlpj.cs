using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace zzz;

internal static class z0ZzZzlpj
{
	[CompilerGenerated]
	private sealed class z0yuk<T> where T : notnull
	{
		public T z0rek;

		public Action<T> z0tek;

		internal void z0eek()
		{
			z0tek(z0rek);
		}
	}

	private static readonly Queue<Action> z0rek = new Queue<Action>();

	private static bool z0tek;

	public static void z0eek<T>(T p0, Action<T> p1)
	{
		if (z0tek)
		{
			z0rek.Enqueue(delegate
			{
				p1(p0);
			});
			return;
		}
		z0tek = true;
		p1(p0);
		Action action;
		while (z0rek.TryDequeue(out action))
		{
			action();
		}
		z0tek = false;
	}
}
