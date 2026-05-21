using System;
using System.Reflection;
using System.Text.Json.Serialization;
using DCSoft.Printing;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

public class DocumentPaintEventArgs : IDisposable
{
	private z0ZzZzjpk z0yek;

	private z0ZzZzvxj z0uek;

	public InterpolationMode GraphicsInterpolationMode
	{
		get
		{
			return z0yek.z0nek_jiejie20260327142557();
		}
		set
		{
			z0yek.z0eek(value);
		}
	}

	public bool HasBoundSelection
	{
		get
		{
			if (Options != null)
			{
				return Options.HasBoundSelection;
			}
			return false;
		}
	}

	public z0ZzZzbdh PageClipRectangle
	{
		get
		{
			return z0uek.z0hrk();
		}
		set
		{
			z0uek.z0uek(value);
		}
	}

	public int PageCount
	{
		get
		{
			return z0uek.z0pek();
		}
		set
		{
			z0uek.z0eek(value);
		}
	}

	public z0ZzZzbdh ViewBounds
	{
		get
		{
			return z0uek.z0gtk;
		}
		set
		{
			z0uek.z0gtk = value;
		}
	}

	public bool GraphicsAutoDisposeImageForPDF
	{
		get
		{
			return z0yek.z0pek();
		}
		set
		{
			z0yek.z0rek(value);
		}
	}

	[JsonIgnore]
	public XTextElement Element
	{
		get
		{
			return z0uek.z0hyk;
		}
		set
		{
			z0uek.z0hyk = value;
		}
	}

	public int PageIndex
	{
		get
		{
			return z0uek.z0oek();
		}
		set
		{
			z0uek.z0rek(value);
		}
	}

	public PageViewMode ViewMode
	{
		get
		{
			return z0uek.z0krk();
		}
		set
		{
			z0uek.z0eek(value);
		}
	}

	[JsonIgnore]
	public z0ZzZzlrj Options
	{
		get
		{
			return z0uek.z0bek();
		}
		set
		{
			z0uek.z0eek(value);
		}
	}

	public float ScaleRate
	{
		get
		{
			return z0uek.z0xek();
		}
		set
		{
			z0uek.z0eek(value);
		}
	}

	[JsonIgnore]
	public XTextDocument Document => z0uek.z0kuk;

	public z0ZzZzbdh ClipRectangle
	{
		get
		{
			return z0uek.z0nek();
		}
		set
		{
			z0uek.z0rek(value);
		}
	}

	[JsonIgnore]
	public z0ZzZzwrj Page
	{
		get
		{
			return z0uek.z0lrk();
		}
		set
		{
			z0uek.z0eek(value);
			if (value != null)
			{
				z0uek.z0rek(value.z0brk());
			}
		}
	}

	public z0ZzZzbdh ClientViewBounds
	{
		get
		{
			return z0uek.z0drk();
		}
		set
		{
			z0uek.z0tek(value);
		}
	}

	public z0ZzZzfdh GraphicsPixelOffsetMode
	{
		get
		{
			return z0yek.z0tek();
		}
		set
		{
			z0yek.z0eek(value);
		}
	}

	public z0ZzZzfsh GraphicsTextRenderingHint
	{
		get
		{
			return z0yek.z0grk();
		}
		set
		{
			z0yek.z0eek(value);
		}
	}

	public SmoothingMode GraphicsSmoothingMode
	{
		get
		{
			return z0yek.z0mek();
		}
		set
		{
			z0yek.z0eek(value);
		}
	}

	public z0ZzZzbdh Bounds
	{
		get
		{
			return z0uek.z0grk();
		}
		set
		{
			z0uek.z0yek(value);
		}
	}

	public void GraphicsFillEllipse(Color c, z0ZzZzbdh rect)
	{
		z0yek.z0eek(c, rect);
	}

	public void GraphicsDrawLine(z0ZzZzudh pen, int x1, int y1, int x2, int y2)
	{
		z0yek.z0eek(pen, x1, y1, x2, y2);
	}

	public float GraphicsGetFontHeight(z0ZzZzimk font)
	{
		return z0yek.z0eek(font);
	}

	public DocumentPaintEventArgs(XTextDocument document, z0ZzZzjpk g, z0ZzZzbdh clipRect, DocumentRenderMode renderMode = DocumentRenderMode.Paint)
	{
		z0uek = new z0ZzZzvxj(document, g, clipRect, (z0ZzZzcxj)renderMode);
		z0yek = g;
	}

	public void GraphicsDrawPolygon(Color c, float lineWidth, z0ZzZzpdh[] ps)
	{
		z0yek.z0eek(c, lineWidth, ps);
	}

	public bool z0eek()
	{
		return z0yek.z0krk();
	}

	public void GraphicsDrawRectangle(z0ZzZzudh pen, z0ZzZzndh rect)
	{
		z0yek.z0eek(pen, rect);
	}

	public void GraphicsDrawLine(z0ZzZznmk pen, float x1, float y1, float x2, float y2)
	{
		z0yek.z0eek(pen, x1, y1, x2, y2);
	}

	public void GraphicsFillRoundRectangle(Color c, z0ZzZzbdh bounds, float radio)
	{
		z0yek.z0eek(c, bounds, radio);
	}

	public void GraphicsDrawPie(z0ZzZzudh p, z0ZzZzndh rect, float startAngle, float sweepAngle)
	{
		z0yek.z0eek(p, rect, startAngle, sweepAngle);
	}

	public z0ZzZzxdh GraphicsMeasureString(string text, z0ZzZzimk font, int width)
	{
		return z0yek.z0eek(text, font, width);
	}

	public z0ZzZzxdh GraphicsMeasureString(string text, z0ZzZzimk font)
	{
		return z0yek.z0eek(text, font);
	}

	public void GraphicsDrawPath(z0ZzZzudh p, z0ZzZznfh path)
	{
		z0yek.z0eek(p, path);
	}

	public DocumentPaintEventArgs(z0ZzZzvxj args)
	{
		if (args == null)
		{
			throw new ArgumentNullException("args");
		}
		z0uek = args;
		z0yek = args.z0gyk;
	}

	public void GraphicsDrawEllipse(z0ZzZzudh pen, z0ZzZzbdh rect)
	{
		z0yek.z0eek(pen, rect);
	}

	public void GraphicsDrawPolygon(Color c, z0ZzZzpdh[] ps)
	{
		z0yek.z0eek(c, ps);
	}

	public void GraphicsDrawPath(Color lineColor, float lineWidth, DashStyle lineStyle, z0ZzZznfh path)
	{
		z0yek.z0eek(lineColor, lineWidth, lineStyle, path);
	}

	public float GraphicsGetFontHeight(z0ZzZzsdh font)
	{
		return z0yek.z0eek(font);
	}

	public void GraphicsDrawString(string s, z0ZzZzsdh font, z0ZzZztfh brush, z0ZzZzbdh layoutRectangle, z0ZzZzlsh format)
	{
		z0yek.DrawString(s, font, brush, layoutRectangle, format);
	}

	public void GraphicsDrawRoundRectangle(z0ZzZznmk p, z0ZzZzbdh bounds, float radio)
	{
		z0yek.z0eek(p, bounds, radio);
	}

	public void GraphicsDrawPolygon(z0ZzZzudh p, z0ZzZzpdh[] ps)
	{
		z0yek.z0rek(p, ps);
	}

	public void GraphicsDrawRectangle(z0ZzZzudh pen, z0ZzZzbdh rect)
	{
		z0yek.z0rek(pen, rect);
	}

	public void GraphicsFillRectangle(z0ZzZztfh brush, float x, float y, float width, float height)
	{
		z0yek.z0eek(brush, x, y, width, height);
	}

	public void GraphicsDrawLine(z0ZzZznmk pen, z0ZzZzpdh pt1, z0ZzZzpdh pt2)
	{
		z0yek.z0eek(pen, pt1, pt2);
	}

	public void GraphicsDrawLine(z0ZzZzudh pen, float x1, float y1, float x2, float y2)
	{
		z0yek.z0eek(pen, x1, y1, x2, y2);
	}

	public void GraphicsDrawPolygon(Color c, float lineWidth, DashStyle lineStyle, z0ZzZzpdh[] ps)
	{
		z0yek.z0eek(c, lineWidth, lineStyle, ps);
	}

	public void GraphicsDrawRectangle(z0ZzZznmk pen, z0ZzZzndh rect)
	{
		z0yek.z0eek(pen, rect);
	}

	public void GraphicsDrawRectangle(z0ZzZznmk pen, z0ZzZzbdh rect)
	{
		z0yek.z0eek(pen, rect);
	}

	public void GraphicsDrawLine(z0ZzZznmk pen, int x1, int y1, int x2, int y2)
	{
		z0yek.z0eek(pen, x1, y1, x2, y2);
	}

	public void GraphicsFillPie(z0ZzZztfh b, float x, float y, float width, float height, float startAngle, float sweepAngle)
	{
		z0yek.z0eek(b, x, y, width, height, startAngle, sweepAngle);
	}

	public void GraphicsDrawImage(z0ZzZzedh img, z0ZzZzbdh rect)
	{
		z0yek.z0eek(img, rect);
	}

	public void GraphicsDrawLine(z0ZzZzudh pen, z0ZzZzpdh pt1, z0ZzZzpdh pt2)
	{
		z0yek.z0eek(pen, pt1, pt2);
	}

	public void GraphicsDrawString(string s, z0ZzZzsdh font, z0ZzZztfh brush, float x, float y, z0ZzZzlsh format)
	{
		z0yek.z0eek(s, font, brush, x, y, format);
	}

	public void GraphicsDrawLine(Color color, float width, float x1, float y1, float x2, float y2)
	{
		z0yek.z0rek(color, width, x1, y1, x2, y2);
	}

	public void GraphicsDrawString(string s, z0ZzZzimk font, Color c, float x, float y)
	{
		z0yek.z0eek(s, font, c, x, y);
	}

	public z0ZzZzxdh GraphicsMeasureString(string text, z0ZzZzsdh font)
	{
		return z0yek.z0eek(text, font);
	}

	public void z0eek(z0ZzZzbdh[] p0)
	{
		z0uek.z0eek(p0);
	}

	public void GraphicsDrawRectangle(z0ZzZznmk pen, float x, float y, float width, float height)
	{
		z0yek.z0rek(pen, x, y, width, height);
	}

	public void GraphicsFillPath(z0ZzZztfh brush, z0ZzZznfh path)
	{
		z0yek.z0eek(brush, path);
	}

	public void GraphicsFillRectangle(z0ZzZzemk brush, z0ZzZzbdh rect)
	{
		z0yek.z0eek(brush, rect);
	}

	public void GraphicsDrawPie(z0ZzZzudh p, float x, float y, float width, float height, float startAngle, float sweepAngle)
	{
		z0yek.z0eek(p, x, y, width, height, startAngle, sweepAngle);
	}

	public void GraphicsDrawImageUnscaled(z0ZzZzedh image, int x, int y)
	{
		z0yek.z0eek(image, x, y);
	}

	public z0ZzZzbdh[] z0rek()
	{
		return z0uek.z0jrk();
	}

	public void GraphicsFillRoundRectangle(Color c, float left, float top, float width, float height, float radio)
	{
		z0yek.z0eek(c, left, top, width, height, radio);
	}

	public void GraphicsDrawRoundRectangle(z0ZzZznmk p, float left, float top, float width, float height, float radio)
	{
		z0yek.z0eek(p, left, top, width, height, radio);
	}

	public void GraphicsFillEllipse(z0ZzZzemk brush, z0ZzZzbdh rect)
	{
		z0yek.z0eek(brush.z0eek(), rect);
	}

	public void GraphicsFillRectangle(z0ZzZzemk brush, z0ZzZzndh rect)
	{
		z0yek.z0eek(brush, rect);
	}

	public object z0tek()
	{
		return z0yek;
	}

	public void Dispose()
	{
		z0uek = null;
		z0yek = null;
	}

	public void GraphicsDrawLines(z0ZzZzudh pen, z0ZzZzpdh[] points)
	{
		z0yek.z0eek(pen, points);
	}

	public void GraphicsDrawPath(z0ZzZznmk p, z0ZzZznfh path)
	{
		z0yek.z0eek(p, path);
	}

	public void GraphicsFillPath(Color c, z0ZzZznfh path)
	{
		z0yek.z0eek(c, path);
	}

	public z0ZzZzxdh GraphicsMeasureString(string text, z0ZzZzsdh font, int width, z0ZzZzlsh format)
	{
		return z0yek.z0eek(text, font, width, format);
	}

	public void GraphicsDrawImage(z0ZzZzedh img, float x, float y)
	{
		z0yek.z0eek(img, x, y);
	}

	public void GraphicsDrawImage(z0ZzZzedh img, float x, float y, float width, float height)
	{
		z0yek.z0eek(img, x, y, width, height);
	}

	public void GraphicsDrawString(string s, z0ZzZzsdh font, z0ZzZztfh brush, float x, float y)
	{
		z0yek.z0eek(s, font, brush, x, y);
	}

	public void GraphicsFillRectangle(z0ZzZztfh brush, z0ZzZzndh rect)
	{
		z0yek.z0eek(brush, rect);
	}

	public void GraphicsDrawLine(Color color, float width, DashStyle lineStyle, float x1, float y1, float x2, float y2)
	{
		z0yek.z0eek(color, width, lineStyle, x1, y1, x2, y2);
	}

	public void GraphicsDrawPath(Color lineColor, z0ZzZznfh path)
	{
		z0yek.z0rek(lineColor, path);
	}

	public void GraphicsDrawRectangle(z0ZzZzudh pen, float x, float y, float width, float height)
	{
		z0yek.z0eek(pen, x, y, width, height, 0f);
	}

	public void GraphicsDrawImage(z0ZzZzedh img, z0ZzZzbdh descRect, z0ZzZzbdh sourceRect, GraphicsUnit unit)
	{
		z0yek.z0eek(img, descRect, sourceRect, unit);
	}

	[Obfuscation(Exclude = true, ApplyToMembers = true)]
	public void GraphicsDrawString(string s, z0ZzZzimk font, Color c, z0ZzZzbdh rect, z0ZzZzlsh format)
	{
		z0yek.z0eek(s, font, c, rect, format);
	}

	public void GraphicsFillRectangle(z0ZzZztfh brush, z0ZzZzbdh rect)
	{
		z0yek.z0rek(brush, rect);
	}

	public void GraphicsDrawPath(Color lineColor, float lineWidth, z0ZzZznfh path)
	{
		z0yek.z0eek(lineColor, lineWidth, path);
	}
}
