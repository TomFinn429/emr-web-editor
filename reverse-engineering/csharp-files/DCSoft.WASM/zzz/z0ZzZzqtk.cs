using System;
using DCSoft.Chart;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzqtk : ICloneable
{
	private StringAlignment z0stk;

	private int z0atk;

	private float z0qtk;

	private double z0wtk = 1.0;

	private int z0etk;

	private int z0rtk;

	private StringAlignment z0ttk = StringAlignment.Center;

	private int z0ytk;

	private int z0utk;

	private z0ZzZznmk z0itk = new z0ZzZznmk();

	private ChartViewStyle z0otk;

	private string z0ptk;

	private int z0mtk = 60;

	private z0ZzZzstk z0ntk = new z0ZzZzstk();

	private bool z0btk = true;

	private z0ZzZzimk z0vtk = new z0ZzZzimk();

	private float z0ctk;

	private z0ZzZzbtk z0xtk;

	private int z0ztk = 20;

	private z0ZzZznmk z0lyk = new z0ZzZznmk();

	private bool z0kyk;

	private int z0jyk = 10;

	private z0ZzZzitk z0hyk = new z0ZzZzitk();

	private z0ZzZznmk z0gyk = new z0ZzZznmk();

	private ColorThemeType z0fyk;

	private z0ZzZzbtk z0dyk;

	private z0ZzZzptk z0syk = new z0ZzZzptk();

	private int z0ayk;

	private z0ZzZzemk z0qyk = new z0ZzZzemk();

	private int z0wyk;

	private AxisCompressStyle z0eyk = AxisCompressStyle.AutoSize;

	private z0ZzZzatk z0ryk = new z0ZzZzatk();

	private int z0tyk = 100;

	private Color z0yyk = Color.Black;

	private int z0uyk = 50;

	private z0ZzZznmk z0iyk = new z0ZzZznmk();

	private float z0oyk = 45f;

	private z0ZzZzstk z0pyk = new z0ZzZzstk();

	public void z0eek(int p0)
	{
		z0ytk = p0;
	}

	public void z0eek(float p0)
	{
		z0oyk = p0;
	}

	public z0ZzZzstk z0eek()
	{
		return z0pyk;
	}

	public int z0rek()
	{
		return z0etk;
	}

	public ChartStyleConsts z0tek()
	{
		if (z0dtk() == ChartViewStyle.Bar || z0dtk() == ChartViewStyle.CascadeBar || z0dtk() == ChartViewStyle.CascadeColumnBar || z0dtk() == ChartViewStyle.ColumnBar || z0dtk() == ChartViewStyle.HorizBar || z0dtk() == ChartViewStyle.HorizCascadeBar || z0dtk() == ChartViewStyle.HorizCascadeColumnBar || z0dtk() == ChartViewStyle.HorizColumnBar || z0dtk() == ChartViewStyle.HorizPercentBar || z0dtk() == ChartViewStyle.HorizPercentColumnBar || z0dtk() == ChartViewStyle.PercentBar || z0dtk() == ChartViewStyle.PercentColumnBar)
		{
			return ChartStyleConsts.Bar;
		}
		if (z0dtk() == ChartViewStyle.Area || z0dtk() == ChartViewStyle.HorizArea || z0dtk() == ChartViewStyle.HorizLine || z0dtk() == ChartViewStyle.Line)
		{
			return ChartStyleConsts.Line;
		}
		if (z0dtk() == ChartViewStyle.Point || z0dtk() == ChartViewStyle.HorizPoint)
		{
			return ChartStyleConsts.Point;
		}
		return ChartStyleConsts.Bar;
	}

	public z0ZzZzbtk z0yek()
	{
		return z0xtk;
	}

	public void z0eek(StringAlignment p0)
	{
		z0ttk = p0;
	}

	public float z0uek()
	{
		return z0qtk;
	}

	public z0ZzZznmk z0iek()
	{
		return z0itk;
	}

	public string z0oek()
	{
		return z0ZzZzlok.z0eek(z0mrk(), Color.Black);
	}

	public void z0eek(z0ZzZzptk p0)
	{
		if (p0 == null)
		{
			z0syk = new z0ZzZzptk();
		}
		else
		{
			z0syk = p0;
		}
	}

	public void z0eek(z0ZzZzemk p0)
	{
		if (p0 == null)
		{
			z0qyk = new z0ZzZzemk();
		}
		else
		{
			z0qyk = p0;
		}
	}

	public int z0pek()
	{
		return z0uyk;
	}

	public void z0eek(z0ZzZznmk p0)
	{
		if (p0 != null)
		{
			z0iyk = p0;
		}
		else
		{
			z0iyk = new z0ZzZznmk();
		}
	}

	public void z0rek(int p0)
	{
		z0jyk = p0;
	}

	public z0ZzZzatk z0mek()
	{
		return z0ryk;
	}

	public void z0eek(string p0)
	{
		z0ptk = p0;
	}

	public StringAlignment z0nek()
	{
		return z0ttk;
	}

	public bool z0bek()
	{
		if (z0dtk() != ChartViewStyle.CascadeColumnBar && z0dtk() != ChartViewStyle.ColumnBar && z0dtk() != ChartViewStyle.HorizCascadeColumnBar && z0dtk() != ChartViewStyle.HorizColumnBar && z0dtk() != ChartViewStyle.HorizPercentColumnBar)
		{
			return z0dtk() == ChartViewStyle.PercentColumnBar;
		}
		return true;
	}

	public int z0vek()
	{
		return z0ytk;
	}

	public float z0cek()
	{
		return z0oyk;
	}

	public bool z0xek()
	{
		return z0btk;
	}

	public int z0zek()
	{
		return z0rtk;
	}

	public z0ZzZzqtk()
	{
		z0lyk.Color = Color.Transparent;
	}

	public int z0lrk()
	{
		return z0utk;
	}

	public int z0krk()
	{
		return z0jyk;
	}

	public void z0eek(z0ZzZzimk p0)
	{
		if (p0 == null)
		{
			z0vtk = new z0ZzZzimk();
		}
		else
		{
			z0vtk = p0;
		}
	}

	public void z0eek(double p0)
	{
		z0wtk = p0;
		if (z0wtk > 1.0)
		{
			z0wtk = 1.0;
		}
		if (z0wtk < 0.0)
		{
			z0wtk = 0.0;
		}
	}

	public z0ZzZzstk z0jrk()
	{
		return z0ntk;
	}

	public void z0tek(int p0)
	{
		z0ztk = p0;
	}

	public bool z0hrk()
	{
		if (z0dtk() != ChartViewStyle.Area)
		{
			return z0dtk() == ChartViewStyle.HorizArea;
		}
		return true;
	}

	public z0ZzZzitk z0grk()
	{
		return z0hyk;
	}

	public int z0frk()
	{
		return z0wyk;
	}

	public int z0drk()
	{
		return z0ayk;
	}

	public void z0yek(int p0)
	{
		z0wyk = p0;
	}

	public string z0srk()
	{
		return z0ptk;
	}

	public void z0eek(z0ZzZzstk p0)
	{
		if (p0 == null)
		{
			z0ntk = new z0ZzZzstk();
		}
		else
		{
			z0ntk = p0;
		}
	}

	public AxisCompressStyle z0ark()
	{
		return z0eyk;
	}

	public z0ZzZznmk z0qrk()
	{
		return z0lyk;
	}

	public void z0uek(int p0)
	{
		z0etk = p0;
	}

	public z0ZzZzemk z0wrk()
	{
		return z0qyk;
	}

	public void z0eek(ChartViewStyle p0)
	{
		z0otk = p0;
	}

	public z0ZzZzptk z0erk()
	{
		return z0syk;
	}

	public bool z0rrk()
	{
		if (z0dtk() != ChartViewStyle.HorizPercentBar && z0dtk() != ChartViewStyle.HorizPercentColumnBar && z0dtk() != ChartViewStyle.PercentBar)
		{
			return z0dtk() == ChartViewStyle.PercentColumnBar;
		}
		return true;
	}

	public void z0rek(StringAlignment p0)
	{
		z0stk = p0;
	}

	public void z0rek(z0ZzZzstk p0)
	{
		if (p0 == null)
		{
			z0pyk = new z0ZzZzstk();
		}
		else
		{
			z0pyk = p0;
		}
	}

	private object z0trk()
	{
		z0ZzZzqtk z0ZzZzqtk2 = (z0ZzZzqtk)MemberwiseClone();
		if (z0dyk != null)
		{
			z0ZzZzqtk2.z0dyk = z0dyk.z0pek();
		}
		if (z0xtk != null)
		{
			z0ZzZzqtk2.z0xtk = z0xtk.z0pek();
		}
		if (z0ntk != null)
		{
			z0ZzZzqtk2.z0ntk = z0ntk.z0lrk();
		}
		if (z0vtk != null)
		{
			z0ZzZzqtk2.z0vtk = z0vtk.Clone();
		}
		if (z0qyk != null)
		{
			z0ZzZzqtk2.z0qyk = z0qyk.z0bek();
		}
		if (z0iyk != null)
		{
			z0ZzZzqtk2.z0iyk = z0iyk.z0rek();
		}
		if (z0gyk != null)
		{
			z0ZzZzqtk2.z0gyk = z0gyk.z0rek();
		}
		if (z0itk != null)
		{
			z0ZzZzqtk2.z0itk = z0itk.z0rek();
		}
		if (z0jyk >= 0)
		{
			z0ZzZzqtk2.z0jyk = z0jyk;
		}
		if (z0hyk != null)
		{
			z0ZzZzqtk2.z0hyk = z0hyk.z0mek();
		}
		if (z0syk != null)
		{
			z0ZzZzqtk2.z0syk = z0syk.z0mek();
		}
		if (z0pyk != null)
		{
			z0ZzZzqtk2.z0pyk = z0pyk.z0lrk();
		}
		if (z0ryk != null)
		{
			z0ZzZzqtk2.z0ryk = z0ryk.z0eek();
		}
		return z0ZzZzqtk2;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0trk
		return this.z0trk();
	}

	public void z0iek(int p0)
	{
		z0mtk = p0;
	}

	public void z0eek(ColorThemeType p0)
	{
		z0fyk = p0;
	}

	internal z0ZzZzbtk z0yrk()
	{
		if (z0htk() == ColorThemeType.Custom)
		{
			if (z0brk() != null)
			{
				return z0brk();
			}
			z0ZzZzbtk obj = new z0ZzZzbtk();
			obj.z0rek(ColorThemeType.Default);
			return obj;
		}
		z0ZzZzbtk obj2 = new z0ZzZzbtk();
		obj2.z0rek(z0htk());
		return obj2;
	}

	public void z0rek(string p0)
	{
		z0eek(z0ZzZzlok.z0eek(p0, Color.Black));
	}

	public void z0rek(z0ZzZznmk p0)
	{
		if (p0 == null)
		{
			z0lyk = new z0ZzZznmk();
		}
		else
		{
			z0lyk = p0;
		}
	}

	public void z0eek(z0ZzZzbtk p0)
	{
		z0xtk = p0;
	}

	public int z0urk()
	{
		return z0atk;
	}

	public int z0irk()
	{
		return z0tyk;
	}

	public void z0oek(int p0)
	{
		z0tyk = p0;
	}

	public double z0ork()
	{
		return z0wtk;
	}

	public void z0eek(z0ZzZzatk p0)
	{
		if (p0 == null || p0.Count == 0)
		{
			z0ryk = new z0ZzZzatk();
		}
		else
		{
			z0ryk = p0;
		}
	}

	public void z0pek(int p0)
	{
		z0utk = p0;
	}

	public bool z0prk()
	{
		if (z0dtk() != ChartViewStyle.CascadeBar && z0dtk() != ChartViewStyle.CascadeColumnBar && z0dtk() != ChartViewStyle.HorizCascadeBar && z0dtk() != ChartViewStyle.HorizCascadeColumnBar && z0dtk() != ChartViewStyle.PercentBar && z0dtk() != ChartViewStyle.PercentColumnBar && z0dtk() != ChartViewStyle.HorizPercentBar)
		{
			return z0dtk() == ChartViewStyle.HorizPercentColumnBar;
		}
		return true;
	}

	public Color z0mrk()
	{
		return z0yyk;
	}

	public StringAlignment z0nrk()
	{
		return z0stk;
	}

	public z0ZzZzbtk z0brk()
	{
		return z0dyk;
	}

	public float z0vrk()
	{
		return z0ctk;
	}

	public void z0eek(z0ZzZzitk p0)
	{
		if (p0 == null)
		{
			z0hyk = new z0ZzZzitk();
		}
		else
		{
			z0hyk = p0;
		}
	}

	public z0ZzZzqtk z0crk()
	{
		return (z0ZzZzqtk)((ICloneable)this).Clone();
	}

	public void z0mek(int p0)
	{
		z0uyk = p0;
	}

	public z0ZzZznmk z0xrk()
	{
		return z0iyk;
	}

	public void z0tek(z0ZzZznmk p0)
	{
		if (p0 != null)
		{
			z0itk = p0;
		}
		else
		{
			z0itk = new z0ZzZznmk();
		}
	}

	public void z0eek(Color p0)
	{
		z0yyk = p0;
	}

	public int z0zrk()
	{
		return z0mtk;
	}

	public void z0rek(float p0)
	{
		z0qtk = p0;
	}

	public z0ZzZznmk z0ltk()
	{
		return z0gyk;
	}

	public void z0eek(bool p0)
	{
		z0btk = p0;
	}

	public int z0ktk()
	{
		return z0ztk;
	}

	public void z0rek(bool p0)
	{
		z0kyk = p0;
	}

	public void z0nek(int p0)
	{
		z0atk = p0;
	}

	public bool z0jtk()
	{
		return z0kyk;
	}

	public ColorThemeType z0htk()
	{
		return z0fyk;
	}

	public void z0tek(float p0)
	{
		z0ctk = p0;
	}

	public void z0rek(z0ZzZzbtk p0)
	{
		z0dyk = p0;
	}

	public z0ZzZzimk z0gtk()
	{
		return z0vtk;
	}

	public void z0eek(AxisCompressStyle p0)
	{
		z0eyk = p0;
	}

	public void z0yek(z0ZzZznmk p0)
	{
		if (p0 != null)
		{
			z0gyk = p0;
		}
		else
		{
			z0gyk = new z0ZzZznmk();
		}
	}

	public bool z0ftk()
	{
		if (z0dtk() == ChartViewStyle.HorizArea || z0dtk() == ChartViewStyle.HorizBar || z0dtk() == ChartViewStyle.HorizCascadeBar || z0dtk() == ChartViewStyle.HorizCascadeColumnBar || z0dtk() == ChartViewStyle.HorizColumnBar || z0dtk() == ChartViewStyle.HorizLine || z0dtk() == ChartViewStyle.HorizPercentBar || z0dtk() == ChartViewStyle.HorizPercentColumnBar || z0dtk() == ChartViewStyle.HorizPoint)
		{
			return false;
		}
		return true;
	}

	public ChartViewStyle z0dtk()
	{
		return z0otk;
	}

	public void z0bek(int p0)
	{
		z0rtk = p0;
	}

	public void z0vek(int p0)
	{
		z0ayk = p0;
	}
}
