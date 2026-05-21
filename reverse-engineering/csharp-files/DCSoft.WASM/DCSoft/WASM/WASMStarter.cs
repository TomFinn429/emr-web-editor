using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Extension.Medical;
using DCSoft.Writer.Security;
using DCSystem_Drawing.Printing;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.WASM;

public static class WASMStarter
{
	[CompilerGenerated]
	private static class z0bik
	{
		public static z0ZzZzhah.z0ixk z0eek;

		public static z0ZzZzivj.z0ank z0rek;

		public static Action z0tek;

		public static XTextLabelElement.z0zhj z0yek;

		public static XTextTableCellElement.z0rmk z0uek;

		public static Func<byte[], z0ZzZzcdh> z0iek;

		public static z0ZzZzadh.z0vnk z0oek;

		public static z0ZzZzwgh.z0zpk z0pek;

		public static Func<int, byte[]> z0mek;

		public static z0ZzZzsok.z0nmk z0nek;
	}

	[CompilerGenerated]
	private sealed class z0ryk
	{
		public static z0ZzZzuok.z0tpk z0srk;

		public static Action<z0ZzZzzlh> z0ark;

		public static z0ZzZzuok.z0tpk z0qrk;

		public static z0ZzZzuok.z0tpk z0wrk;

		public static zzz.z0ZzZzgik<z0ZzZzlkh>.z0rpk z0erk;

		public static z0ZzZzuok.z0tpk z0rrk;

		public static zzz.z0ZzZzgik<XTextElementList>.z0rpk z0trk;

		public static zzz.z0ZzZzgik<List<XTextElement>>.z0rpk z0yrk_jiejie20260327142557;

		public static zzz.z0ZzZzgik<XTextElement[]>.z0rpk z0urk;

		public static zzz.z0ZzZzgik<z0ZzZzzlh[]>.z0rpk z0irk;

		public static z0ZzZztyk z0ork;

		public static z0ZzZzuok.z0tpk z0prk;

		public static z0ZzZzbej.z0ypk z0mrk;

		public static z0ZzZzuok.z0tpk z0nrk;

		public static z0ZzZzuok.z0tpk z0brk;

		public static z0ZzZzuok.z0tpk z0vrk;

		public static Action<XTextDocument> z0crk;

		public static z0ZzZzhbj.z0fnk z0xrk;

		public static z0ZzZzuok.z0tpk z0zrk;

		public static readonly z0ryk z0ltk = new z0ryk();

		public static z0ZzZzuok.z0tpk z0ktk;

		public static z0ZzZztyk z0jtk;

		public static z0ZzZzuok.z0tpk z0htk;

		public static z0ZzZzrfh.z0dhj z0gtk;

		public static z0ZzZzuok.z0tpk z0ftk;

		public static z0ZzZzuok.z0tpk z0dtk;

		public static z0ZzZzuok.z0tpk z0stk;

		internal object z0eek()
		{
			return new z0ZzZztcj();
		}

		internal object z0rek()
		{
			return new z0ZzZzvhh();
		}

		internal z0ZzZzzlh[] z0tek()
		{
			return new z0ZzZzzlh[100];
		}

		internal void z0eek(z0ZzZzzlh p0)
		{
			p0.z0frk();
			((zzz.z0ZzZzkuk<XTextElement>)p0).z0vrk();
		}

		internal object z0yek()
		{
			return new z0ZzZzexj();
		}

		internal void z0eek(z0ZzZzrfh p0)
		{
			if (p0 != null)
			{
				if (WASMStarter.z0pek == null)
				{
					WASMStarter.z0pek = new List<z0ZzZzrfh>();
				}
				WASMStarter.z0pek.Add(p0);
				z0ZzZzroj.z0eek(p0.z0cek, p0.z0eek());
			}
		}

		internal List<XTextElement> z0uek()
		{
			return new List<XTextElement>();
		}

		internal object z0iek()
		{
			return new z0ZzZzmij();
		}

		internal z0ZzZzxuk z0oek()
		{
			return new z0ZzZzsgh();
		}

		internal object z0pek()
		{
			return new z0ZzZzzbj();
		}

		internal object z0mek()
		{
			return new z0ZzZzlbj();
		}

		internal object z0nek()
		{
			return new z0ZzZzlbj();
		}

		internal XTextElementList z0bek()
		{
			return new XTextElementList();
		}

		internal object z0vek()
		{
			return new z0ZzZzpvj();
		}

		internal object z0cek()
		{
			return new z0ZzZzibj();
		}

		internal object z0xek_jiejie20260327142557()
		{
			return new z0ZzZztkh();
		}

		internal object z0zek()
		{
			return new z0ZzZznmj();
		}

		internal object z0lrk()
		{
			return new z0ZzZzecj();
		}

		internal Encoding z0krk()
		{
			return z0ZzZzluk.z0tek;
		}

		internal void z0eek(XTextDocument p0)
		{
			if (p0 != null && p0.z0vtk().BehaviorOptions.EnableExpression && p0.z0rik() is z0ZzZztkh z0ZzZztkh && p0.z0cu() != null)
			{
				bool enableExpression = p0.z0vtk().BehaviorOptions.EnableExpression;
				p0.z0vtk().BehaviorOptions.EnableExpression = true;
				try
				{
					z0ZzZztkh.z0tek(new z0ZzZztkh.z0bmk
					{
						z0uek = true
					});
					_ = 0;
				}
				finally
				{
					p0.z0vtk().BehaviorOptions.EnableExpression = enableExpression;
				}
			}
		}

		internal object z0jrk()
		{
			return new z0ZzZzinj();
		}

		internal z0ZzZzxuk z0hrk()
		{
			return new z0ZzZzehh();
		}

		internal object z0grk()
		{
			return new z0ZzZzbhh();
		}

		internal z0ZzZzlkh z0frk()
		{
			return new z0ZzZzlkh();
		}

		internal z0ZzZzbej z0eek(Stream p0, bool p1)
		{
			return new z0ZzZznej(p0, p1);
		}

		internal XTextElement[] z0drk()
		{
			return new XTextElement[100];
		}
	}

	private static char[] z0oek;

	private static List<z0ZzZzrfh> z0pek;

	private static char[] z0mek;

	[JSInvokable]
	public static void AddReplaceCharsForLoad(int oldChar, int newChar)
	{
		if (oldChar != newChar)
		{
			if (z0oek == null)
			{
				z0oek = new char[1] { (char)oldChar };
				z0mek = new char[1] { (char)newChar };
				return;
			}
			char[] array = new char[z0mek.Length + 1];
			Array.Copy(z0oek, array, z0oek.Length);
			array[array.Length - 1] = (char)oldChar;
			z0oek = array;
			array = new char[z0mek.Length + 1];
			Array.Copy(z0mek, array, z0mek.Length);
			array[array.Length - 1] = (char)newChar;
			z0mek = array;
		}
	}

	internal static void z0eek()
	{
		z0ZzZzovj.z0iek.SetBitmape(DCStdImageKey.CheckBoxUnchecked, new z0ZzZzrfh(new byte[1144]
		{
			66, 77, 120, 4, 0, 0, 0, 0, 0, 0,
			54, 0, 0, 0, 40, 0, 0, 0, 17, 0,
			0, 0, 16, 0, 0, 0, 1, 0, 32, 0,
			0, 0, 0, 0, 66, 4, 0, 0, 18, 11,
			0, 0, 18, 11, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 255, 208, 191, 0, 255, 80,
			15, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 80, 15, 0, 255, 185, 159, 0, 255, 255,
			255, 0, 255, 80, 15, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 80, 15, 0, 255, 255, 255, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 104,
			48, 0, 255, 244, 240, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 244,
			240, 0, 255, 104, 48, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 208, 191, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 244, 240, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 244, 240, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 208, 191, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 208, 191, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 208,
			191, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 208, 191, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 208, 191, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 208, 191, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 208, 191, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 208,
			191, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 208, 191, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 186,
			160, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 221, 208, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 208, 191, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 174, 144, 0, 255, 209, 192, 0, 255, 209,
			192, 0, 255, 209, 192, 0, 255, 209, 192, 0,
			255, 209, 192, 0, 255, 209, 192, 0, 255, 209,
			192, 0, 255, 209, 192, 0, 255, 197, 176, 0,
			255, 81, 16, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 208, 191, 0, 255, 80, 15, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 80, 15, 0,
			255, 255, 255, 0, 255, 208, 191, 0, 255, 80,
			15, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 80, 15, 0, 255, 185, 159, 0, 255, 255,
			255, 0, 0, 0
		}));
	}

	internal static void z0rek()
	{
		z0ZzZzovj.z0iek.SetBitmape(DCStdImageKey.RadioBoxUnchecked, new z0ZzZzrfh(new byte[1080]
		{
			66, 77, 56, 4, 0, 0, 0, 0, 0, 0,
			54, 0, 0, 0, 40, 0, 0, 0, 16, 0,
			0, 0, 16, 0, 0, 0, 1, 0, 32, 0,
			0, 0, 0, 0, 2, 4, 0, 0, 18, 11,
			0, 0, 18, 11, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 185, 159, 0, 255, 115, 63, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 115, 63, 0, 255, 185,
			159, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 232, 223, 0,
			255, 104, 47, 0, 255, 69, 0, 0, 255, 138,
			95, 0, 255, 197, 175, 0, 255, 208, 191, 0,
			255, 220, 207, 0, 255, 197, 175, 0, 255, 138,
			95, 0, 255, 69, 0, 0, 255, 104, 47, 0,
			255, 232, 223, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 232, 223, 0,
			255, 79, 15, 0, 255, 103, 47, 0, 255, 220,
			207, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 220, 207, 0,
			255, 103, 47, 0, 255, 79, 15, 0, 255, 232,
			223, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 104, 47, 0, 255, 103, 47, 0, 255, 243,
			239, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 243, 239, 0, 255, 103,
			47, 0, 255, 104, 47, 0, 255, 255, 255, 0,
			255, 185, 159, 0, 255, 69, 0, 0, 255, 220,
			207, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 220, 207, 0, 255, 69, 0, 0,
			255, 185, 159, 0, 255, 115, 63, 0, 255, 138,
			95, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 138, 95, 0, 255, 115, 63, 0, 255, 69,
			0, 0, 255, 197, 175, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 197, 175, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 220, 207, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 208,
			191, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 208, 191, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 208, 191, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 197, 175, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 197, 175, 0,
			255, 69, 0, 0, 255, 115, 63, 0, 255, 138,
			95, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 138, 95, 0, 255, 115, 63, 0, 255, 185,
			159, 0, 255, 69, 0, 0, 255, 220, 207, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 220, 207, 0, 255, 69, 0, 0, 255, 185,
			159, 0, 255, 255, 255, 0, 255, 104, 47, 0,
			255, 103, 47, 0, 255, 243, 239, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 243, 239, 0, 255, 103, 47, 0, 255, 104,
			47, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 232, 223, 0, 255, 79, 15, 0, 255, 103,
			47, 0, 255, 220, 207, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 220, 207, 0, 255, 103, 47, 0, 255, 79,
			15, 0, 255, 232, 223, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 232,
			223, 0, 255, 104, 47, 0, 255, 69, 0, 0,
			255, 138, 95, 0, 255, 197, 175, 0, 255, 208,
			191, 0, 255, 208, 191, 0, 255, 197, 175, 0,
			255, 138, 95, 0, 255, 69, 0, 0, 255, 104,
			47, 0, 255, 232, 223, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 185, 159, 0, 255, 115, 63, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 115, 63, 0, 255, 185,
			159, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 0, 0
		}));
	}

	internal static void z0tek()
	{
		z0yek();
		z0eek();
		z0uek();
		z0rek();
	}

	public static char z0eek(char p0)
	{
		if (p0 > '\u007f' && z0oek != null)
		{
			for (int num = z0oek.Length - 1; num >= 0; num--)
			{
				if (z0oek[num] == p0)
				{
					return z0mek[num];
				}
			}
		}
		return p0;
	}

	internal static void z0yek()
	{
		z0ZzZzovj.z0iek.SetBitmape(DCStdImageKey.CheckBoxChecked, new z0ZzZzrfh(new byte[1144]
		{
			66, 77, 120, 4, 0, 0, 0, 0, 0, 0,
			54, 0, 0, 0, 40, 0, 0, 0, 17, 0,
			0, 0, 16, 0, 0, 0, 1, 0, 32, 0,
			0, 0, 0, 0, 66, 4, 0, 0, 18, 11,
			0, 0, 18, 11, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 255, 255, 255, 0, 255, 185,
			159, 0, 255, 80, 15, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 80, 15, 0, 255, 220,
			207, 0, 255, 243, 239, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 92, 31, 0,
			255, 208, 191, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 81, 16, 0, 255, 116,
			64, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 208,
			191, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 174, 144, 0, 255, 255, 255, 0,
			255, 174, 144, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 208, 191, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 116, 64, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 116, 64, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 208, 191, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 81, 16, 0, 255, 244, 240, 0, 255, 255,
			255, 0, 255, 209, 192, 0, 255, 255, 255, 0,
			255, 244, 240, 0, 255, 81, 16, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 208, 191, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 197,
			176, 0, 255, 255, 255, 0, 255, 209, 192, 0,
			255, 69, 0, 0, 255, 209, 192, 0, 255, 255,
			255, 0, 255, 197, 176, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 208, 191, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 81, 16, 0, 255, 255, 255, 0,
			255, 244, 240, 0, 255, 92, 32, 0, 255, 69,
			0, 0, 255, 81, 16, 0, 255, 244, 240, 0,
			255, 255, 255, 0, 255, 151, 112, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 208,
			191, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 81, 16, 0, 255, 197, 176, 0, 255, 127,
			80, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 127, 80, 0, 255, 255,
			255, 0, 255, 244, 240, 0, 255, 104, 48, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 208, 191, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 174, 144, 0,
			255, 255, 255, 0, 255, 221, 208, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 208, 191, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 81, 16, 0, 255, 221,
			208, 0, 255, 255, 255, 0, 255, 174, 144, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 208, 191, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 104, 48, 0,
			255, 255, 255, 0, 255, 209, 192, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 208, 191, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 127,
			80, 0, 255, 139, 96, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 208,
			191, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 243, 239, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 92, 31, 0, 255, 255, 255, 0, 255, 185,
			159, 0, 255, 80, 15, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 80, 15, 0, 255, 220,
			207, 0, 0, 0
		}));
	}

	[JSInvokable]
	public static void SetBmpSize(int vIndex, int vWidth, int vHeight)
	{
		if (z0pek == null)
		{
			return;
		}
		foreach (z0ZzZzrfh item in z0pek)
		{
			if (item.z0cek == vIndex)
			{
				item.z0eek(vWidth, vHeight);
				z0pek.Remove(item);
				break;
			}
		}
	}

	internal static void z0uek()
	{
		z0ZzZzovj.z0iek.SetBitmape(DCStdImageKey.RadioBoxChecked, new z0ZzZzrfh(new byte[1080]
		{
			66, 77, 56, 4, 0, 0, 0, 0, 0, 0,
			54, 0, 0, 0, 40, 0, 0, 0, 16, 0,
			0, 0, 16, 0, 0, 0, 1, 0, 32, 0,
			0, 0, 0, 0, 2, 4, 0, 0, 18, 11,
			0, 0, 18, 11, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 185, 159, 0, 255, 115, 63, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 115, 63, 0, 255, 185,
			159, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 232, 223, 0,
			255, 104, 47, 0, 255, 69, 0, 0, 255, 138,
			95, 0, 255, 197, 175, 0, 255, 208, 191, 0,
			255, 220, 207, 0, 255, 197, 175, 0, 255, 138,
			95, 0, 255, 69, 0, 0, 255, 104, 47, 0,
			255, 232, 223, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 232, 223, 0,
			255, 79, 15, 0, 255, 103, 47, 0, 255, 220,
			207, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 220, 207, 0,
			255, 103, 47, 0, 255, 79, 15, 0, 255, 232,
			223, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 104, 47, 0, 255, 103, 47, 0, 255, 243,
			239, 0, 255, 255, 255, 0, 255, 162, 127, 0,
			255, 80, 15, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 80, 15, 0, 255, 162, 127, 0,
			255, 255, 255, 0, 255, 243, 239, 0, 255, 103,
			47, 0, 255, 104, 47, 0, 255, 255, 255, 0,
			255, 185, 159, 0, 255, 69, 0, 0, 255, 220,
			207, 0, 255, 255, 255, 0, 255, 103, 47, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 103, 47, 0, 255, 255,
			255, 0, 255, 220, 207, 0, 255, 69, 0, 0,
			255, 185, 159, 0, 255, 115, 63, 0, 255, 138,
			95, 0, 255, 255, 255, 0, 255, 162, 127, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 162, 127, 0, 255, 255, 255, 0,
			255, 138, 95, 0, 255, 115, 63, 0, 255, 69,
			0, 0, 255, 197, 175, 0, 255, 255, 255, 0,
			255, 80, 15, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 80, 15, 0,
			255, 255, 255, 0, 255, 197, 175, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 220, 207, 0,
			255, 255, 255, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 255, 255, 0, 255, 208,
			191, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 208, 191, 0, 255, 255, 255, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 255,
			255, 0, 255, 208, 191, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 197, 175, 0, 255, 255,
			255, 0, 255, 80, 15, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 80,
			15, 0, 255, 255, 255, 0, 255, 197, 175, 0,
			255, 69, 0, 0, 255, 115, 63, 0, 255, 138,
			95, 0, 255, 255, 255, 0, 255, 162, 127, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 162, 127, 0, 255, 255, 255, 0,
			255, 138, 95, 0, 255, 115, 63, 0, 255, 185,
			159, 0, 255, 69, 0, 0, 255, 220, 207, 0,
			255, 243, 239, 0, 255, 103, 47, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 69,
			0, 0, 255, 103, 47, 0, 255, 255, 255, 0,
			255, 220, 207, 0, 255, 69, 0, 0, 255, 185,
			159, 0, 255, 255, 255, 0, 255, 104, 47, 0,
			255, 103, 47, 0, 255, 243, 239, 0, 255, 255,
			255, 0, 255, 162, 127, 0, 255, 80, 15, 0,
			255, 69, 0, 0, 255, 69, 0, 0, 255, 80,
			15, 0, 255, 162, 127, 0, 255, 255, 255, 0,
			255, 243, 239, 0, 255, 103, 47, 0, 255, 104,
			47, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 232, 223, 0, 255, 79, 15, 0, 255, 103,
			47, 0, 255, 220, 207, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 220, 207, 0, 255, 103, 47, 0, 255, 79,
			15, 0, 255, 232, 223, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 232,
			223, 0, 255, 104, 47, 0, 255, 69, 0, 0,
			255, 138, 95, 0, 255, 197, 175, 0, 255, 208,
			191, 0, 255, 208, 191, 0, 255, 197, 175, 0,
			255, 138, 95, 0, 255, 69, 0, 0, 255, 104,
			47, 0, 255, 232, 223, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 255, 255,
			255, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 185, 159, 0, 255, 115, 63, 0, 255, 69,
			0, 0, 255, 69, 0, 0, 255, 69, 0, 0,
			255, 69, 0, 0, 255, 115, 63, 0, 255, 185,
			159, 0, 255, 255, 255, 0, 255, 255, 255, 0,
			255, 255, 255, 0, 255, 255, 255, 0, 0, 0
		}));
	}

	public static void z0iek()
	{
		DateTime now = DateTime.Now;
		z0ZzZzloj.z0rek();
		z0ZzZzpmk.z0zek = z0ZzZzcoj.z0yek;
		z0ZzZzihh.z0bek = z0ZzZzroj.z0rek;
		z0ZzZzihh.z0nnk.z0mek = z0ZzZzroj.z0eek;
		z0ZzZzivj.z0uek = z0ZzZzcoj.z0tek;
		zzz.z0ZzZzgik<XTextElement[]>.z0iek.z0rek(() => new XTextElement[100]);
		zzz.z0ZzZzgik<XTextElementList>.z0iek.z0rek(() => new XTextElementList());
		zzz.z0ZzZzgik<z0ZzZzzlh[]>.z0iek.z0rek(() => new z0ZzZzzlh[100]);
		zzz.z0ZzZzgik<z0ZzZzlkh>.z0iek.z0rek(() => new z0ZzZzlkh());
		zzz.z0ZzZzgik<List<XTextElement>>.z0iek.z0rek(() => new List<XTextElement>());
		zzz.z0ZzZzguk<z0ZzZzzlh>.z0oek = delegate(z0ZzZzzlh z0ZzZzzlh)
		{
			z0ZzZzzlh.z0frk();
			((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzzlh).z0vrk();
		};
		z0ZzZzsok.z0yek = z0ZzZzcoj.z0tek;
		z0ZzZzhah.z0pek = z0ZzZzcoj.z0iek;
		z0ZzZzlcj.z0rek('₁', 16.65f);
		z0ZzZzlcj.z0rek('₂', 16.65f);
		z0ZzZzlcj.z0rek('₃', 16.65f);
		z0ZzZzlcj.z0rek('½', 20.83f);
		z0ZzZzlcj.z0rek('⅓', 41.7f);
		z0ZzZzlcj.z0rek('⅔', 41.7f);
		z0ZzZzlcj.z0rek('¼', 20.83f);
		z0ZzZzlcj.z0rek('⑪', 50f);
		z0ZzZzlcj.z0rek('⑫', 50f);
		z0ZzZzlcj.z0rek('⑬', 50f);
		z0ZzZzlcj.z0rek('⑭', 50f);
		z0ZzZzlcj.z0rek('⑮', 50f);
		z0ZzZzlcj.z0rek('⑯', 50f);
		z0ZzZzlcj.z0rek('⑰', 50f);
		z0ZzZzlcj.z0rek('⑱', 50f);
		z0ZzZzlcj.z0rek('⑲', 50f);
		z0ZzZzlcj.z0rek('⑳', 50f);
		z0ZzZzxoj.z0eek();
		XTextTableCellElement.z0rrk = z0ZzZzcoj.z0tek;
		XTextLabelElement.z0nek = z0ZzZzcoj.z0tek;
		z0ZzZzimk.DefaultFontName = "宋体";
		z0ZzZzadh.z0ltk = z0ZzZzroj.z0yek;
		z0ZzZzrfh.z0oek = delegate(z0ZzZzrfh z0ZzZzrfh)
		{
			if (z0ZzZzrfh != null)
			{
				if (z0pek == null)
				{
					z0pek = new List<z0ZzZzrfh>();
				}
				z0pek.Add(z0ZzZzrfh);
				z0ZzZzroj.z0eek(z0ZzZzrfh.z0cek, z0ZzZzrfh.z0eek());
			}
		};
		z0ZzZzcij.z0eek();
		z0ZzZzegh.z0eek = new z0ZzZzooj();
		z0ZzZzmoj.z0eek();
		z0ZzZzszk.z0yek("DCWriter " + z0ZzZzook.z0tek());
		TTFontFileHelper.z0eek();
		z0ZzZzroj.z0tek();
		z0ZzZzhbj.z0tek = () => z0ZzZzluk.z0tek;
		z0ZzZzwgh.z0oek = z0ZzZzfhh.z0eek;
		z0ZzZzwgh.z0iek = () => new z0ZzZzehh();
		XTextImageElement.z0etk = () => new z0ZzZzsgh();
		z0ZzZzbej.z0rek = (Stream p2, bool p3) => new z0ZzZznej(p2, p3);
		XTextDocument.z0ock = delegate(XTextDocument xTextDocument)
		{
			if (xTextDocument != null && xTextDocument.z0vtk().BehaviorOptions.EnableExpression && xTextDocument.z0rik() is z0ZzZztkh z0ZzZztkh && xTextDocument.z0cu() != null)
			{
				bool enableExpression = xTextDocument.z0vtk().BehaviorOptions.EnableExpression;
				xTextDocument.z0vtk().BehaviorOptions.EnableExpression = true;
				try
				{
					z0ZzZztkh.z0tek(new z0ZzZztkh.z0bmk
					{
						z0uek = true
					});
					_ = 0;
				}
				finally
				{
					xTextDocument.z0vtk().BehaviorOptions.EnableExpression = enableExpression;
				}
			}
		};
		z0ZzZzuok.z0rek<z0ZzZzbmj>(() => new z0ZzZznmj());
		z0ZzZzuok.z0rek<z0ZzZzsbj>(() => new z0ZzZzinj());
		z0ZzZzuok.z0rek<z0ZzZzhvj>(() => new z0ZzZzzbj());
		z0ZzZzuok.z0rek<z0ZzZzxlh>(() => new z0ZzZzmij());
		z0ZzZzuok.z0rek<z0ZzZzznj>(() => new z0ZzZzlbj());
		z0ZzZzuok.z0rek<z0ZzZzyxj>(() => new z0ZzZzibj());
		z0ZzZzuok.z0rek<z0ZzZzmxj>(() => new z0ZzZzexj());
		z0ZzZzuok.z0rek<z0ZzZzpjh>(() => new z0ZzZzpvj());
		z0ZzZzuok.z0rek<z0ZzZzpxj>(() => new z0ZzZztcj());
		z0ZzZzuok.z0rek<z0ZzZzoxj>(() => new z0ZzZzecj());
		z0ZzZzuok.z0rek<z0ZzZzznj>(() => new z0ZzZzlbj());
		z0ZzZzuok.z0rek<z0ZzZzpkh>(() => new z0ZzZztkh());
		z0ZzZzuok.z0rek<z0ZzZzkgh>(() => new z0ZzZzbhh());
		z0ZzZzuok.z0rek<z0ZzZzjgh>(() => new z0ZzZzvhh());
		z0ZzZzick.z0xek = z0ZzZzook.z0uek;
		z0ZzZzdfh.z0rek(new z0ZzZzffh());
		z0ZzZznhh.z0eek().z0eek(new z0ZzZzgjh());
		z0ZzZznhh.z0eek().z0eek(new z0ZzZzhhh());
		z0ZzZznhh.z0eek().z0eek(new z0ZzZzqrk());
		z0ZzZznhh.z0eek().z0eek(new z0ZzZzvkh());
		z0ZzZzlfh.z0eek(typeof(XTextControlHostElement), z0ZzZziok.z0rrk());
		z0ZzZzlfh.z0eek(typeof(XTextButtonElement), string.Empty);
		z0ZzZzlfh.z0eek(typeof(XTextDirectoryFieldElement), string.Empty);
		z0ZzZzlfh.z0eek(typeof(z0ZzZzolh), string.Empty);
		z0ZzZzlfh.z0eek(typeof(XTextChartElement), string.Empty);
		z0ZzZzlfh.z0eek(typeof(XTextPieElement), string.Empty);
		z0ZzZzlfh.z0eek(typeof(XTextNewBarcodeElement), z0ZzZziok.z0jyk());
		z0ZzZzlfh.z0eek(typeof(XTextTDBarcodeElement), z0ZzZziok.z0uek());
		z0ZzZzlfh.z0eek(typeof(XTextBarcodeFieldElement), z0ZzZziok.z0jyk());
		z0ZzZzlfh.z0eek(typeof(XTextMediaElement), z0ZzZziok.z0byk());
		z0ZzZzlfh.z0eek(typeof(XTextNewMedicalExpressionElement));
		z0ZzZzqgh.z0eek(typeof(XTextDocument), typeof(z0ZzZzehh));
		z0ZzZziok.z0aik();
		z0ZzZznhh.z0eek().z0eek(new z0ZzZzwgh());
		z0ZzZznhh.z0eek().z0eek(new z0ZzZzhgh());
		z0ZzZznhh.z0eek().z0eek(new z0ZzZzagh());
		z0ZzZzmvj.z0eek().z0rek(typeof(z0ZzZzivj), new z0ZzZzivj());
		new DocumentOptions();
		_ = DocumentSecurityOptions.DefaultTrackVisibleLevel0;
		_ = z0ZzZzimk.DefaultFontName;
		z0ZzZzppj.z0vek();
		z0ZzZzppj.z0pek();
		_ = z0ZzZzovj.z0iek;
		_ = z0ZzZzcok.z0byk;
		z0ZzZzlfh.z0eek(typeof(XTextMedicalExpressionFieldElement));
		z0ZzZzamk.z0eek(PaperKind.A4);
		int tickCount = Environment.TickCount;
		_ = z0ZzZzkfh.z0irk;
		z0ZzZzlmk.z0eek(ParagraphListStyle.BulletedList);
		_ = (DateTime.Now.Ticks - tickCount) / 1000;
		DocumentEditOptions.z0eek();
		_ = (DateTime.Now.Ticks - tickCount) / 1000;
		_ = DocumentSecurityOptions.DefaultTrackVisibleLevel0;
		z0ZzZzimk.z0rek();
		_ = (DateTime.Now.Ticks - tickCount) / 1000;
		z0ZzZzcok.z0rek();
		_ = (DateTime.Now.Ticks - tickCount) / 1000;
		DocumentContentStyle.z0oek();
		z0ZzZzvlh.z0yek();
		z0ZzZzrpk.z0eek();
		_ = (DateTime.Now.Ticks - tickCount) / 1000;
		new z0ZzZzqck();
		z0ZzZzemj.z0eek().z0eek(new z0ZzZzxmj());
		z0ZzZzemj.z0eek().z0eek(new z0ZzZzlnj());
		z0ZzZzemj.z0eek().z0eek(new z0ZzZzknj());
		z0ZzZzemj.z0eek().z0eek(new z0ZzZzjnj());
		z0ZzZzemj.z0eek().z0eek(new z0ZzZzhnj());
		z0ZzZzemj.z0eek().z0eek(new z0ZzZzgnj());
		z0ZzZzemj.z0eek().z0eek(new z0ZzZzfnj());
		z0ZzZzemj.z0eek().z0eek(new z0ZzZzdnj());
		z0ZzZzemj.z0eek().z0eek(new z0ZzZzzmj());
		z0ZzZzemj.z0eek().z0eek(new z0ZzZzckh());
		z0ZzZzomj p = new z0ZzZzomj(null, null, (z0ZzZzmmj)7, null);
		foreach (z0ZzZzcmj item in z0ZzZzemj.z0eek())
		{
			foreach (z0ZzZzrmj item2 in item.z0rek())
			{
				item2.z0iz(p);
			}
		}
		z0ZzZzlcj.z0uhj.z0eek();
		string text = z0ZzZzroj.z0hrk("document.URL;");
		string text2 = XTextDocument.z0erk(text);
		if (text2 == null || text2.Length == 0)
		{
			z0ZzZzroj.z0eek("未获得服务器地址[" + text + "]");
		}
		z0ZzZzynj.z0yek();
		z0ZzZzqok.z0rek.z0sh("DCWriter5启动耗时" + (DateTime.Now - now).TotalMilliseconds + "毫秒，版本:" + z0ZzZzook.z0eek() + ",当前页面地址[ " + text + " ]。");
	}
}
