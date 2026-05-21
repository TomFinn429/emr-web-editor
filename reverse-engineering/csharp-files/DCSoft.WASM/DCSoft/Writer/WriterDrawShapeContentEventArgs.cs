using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer;

public class WriterDrawShapeContentEventArgs : WriterEventArgs
{
	private readonly z0ZzZzvxj z0yek;

	private readonly XTextCustomShapeElement z0uek;

	public bool GraphicsAutoDisposeImageForPDF
	{
		get
		{
			return z0eek().z0pek();
		}
		set
		{
			z0eek().z0rek(value);
		}
	}

	public InterpolationMode GraphicsInterpolationMode
	{
		get
		{
			return z0eek().z0nek_jiejie20260327142557();
		}
		set
		{
			z0eek().z0eek(value);
		}
	}

	[JsonIgnore]
	public XTextCustomShapeElement ShapeElement => z0uek;

	public z0ZzZzrzj Sytle => z0yek.z0luk;

	public int PageIndex => z0yek.z0oek();

	public z0ZzZzfsh GraphicsTextRenderingHint
	{
		get
		{
			return z0eek().z0grk();
		}
		set
		{
			z0eek().z0eek(value);
		}
	}

	public SmoothingMode GraphicsSmoothingMode
	{
		get
		{
			return z0eek().z0mek();
		}
		set
		{
			z0eek().z0eek(value);
		}
	}

	public z0ZzZzbdh ClipRectangle => z0yek.z0nek();

	public z0ZzZzbdh ViewBounds => z0yek.z0gtk;

	public z0ZzZzfdh GraphicsPixelOffsetMode
	{
		get
		{
			return z0eek().z0tek();
		}
		set
		{
			z0eek().z0eek(value);
		}
	}

	public void GraphicsDrawRectangle(z0ZzZzudh pen, z0ZzZzndh rect)
	{
		z0eek().z0eek(pen, rect);
	}

	public void GraphicsDrawLine(z0ZzZzudh pen, z0ZzZzpdh pt1, z0ZzZzpdh pt2)
	{
		z0eek().z0eek(pen, pt1, pt2);
	}

	public void GraphicsDrawRoundRectangle(z0ZzZznmk p, z0ZzZzbdh bounds, float radio)
	{
		z0eek().z0eek(p, bounds, radio);
	}

	public void GraphicsDrawImage(z0ZzZzedh img, z0ZzZzbdh descRect, z0ZzZzbdh sourceRect, GraphicsUnit unit)
	{
		z0eek().z0eek(img, descRect, sourceRect, unit);
	}

	public float GraphicsGetFontHeight(z0ZzZzimk font)
	{
		return z0eek().z0eek(font);
	}

	public void GraphicsDrawRectangle(z0ZzZznmk pen, float x, float y, float width, float height)
	{
		z0eek().z0rek(pen, x, y, width, height);
	}

	public void GraphicsDrawString(string s, z0ZzZzsdh font, z0ZzZztfh brush, z0ZzZzbdh layoutRectangle, z0ZzZzlsh format)
	{
		z0eek().DrawString(s, font, brush, layoutRectangle, format);
	}

	public void GraphicsDrawString(string s, z0ZzZzsdh font, z0ZzZztfh brush, float x, float y, z0ZzZzlsh format)
	{
		z0eek().z0eek(s, font, brush, x, y, format);
	}

	public void GraphicsFillRectangle(z0ZzZztfh brush, float x, float y, float width, float height)
	{
		z0eek().z0eek(brush, x, y, width, height);
	}

	public void GraphicsDrawPolygon(Color c, float lineWidth, DashStyle lineStyle, z0ZzZzpdh[] ps)
	{
		z0eek().z0eek(c, lineWidth, lineStyle, ps);
	}

	public void GraphicsDrawPolygon(Color c, float lineWidth, z0ZzZzpdh[] ps)
	{
		z0eek().z0eek(c, lineWidth, ps);
	}

	public void GraphicsDrawPath(Color lineColor, float lineWidth, DashStyle lineStyle, z0ZzZznfh path)
	{
		z0eek().z0eek(lineColor, lineWidth, lineStyle, path);
	}

	public void GraphicsDrawRectangle(z0ZzZzudh pen, float x, float y, float width, float height)
	{
		z0eek().z0eek(pen, x, y, width, height, 0f);
	}

	public bool GraphicsIsPDFMode()
	{
		return z0eek().z0krk();
	}

	public z0ZzZzxdh GraphicsMeasureString(string text, z0ZzZzsdh font, int width, z0ZzZzlsh format)
	{
		return z0eek().z0eek(text, font, width, format);
	}

	public z0ZzZzxdh GraphicsMeasureString(string text, z0ZzZzimk font, int width)
	{
		return z0eek().z0eek(text, font, width);
	}

	public void GraphicsDrawRectangle(z0ZzZznmk pen, z0ZzZzndh rect)
	{
		z0eek().z0eek(pen, rect);
	}

	public void GraphicsFillPath(z0ZzZztfh brush, z0ZzZznfh path)
	{
		z0eek().z0eek(brush, path);
	}

	public void GraphicsFillRectangle(z0ZzZztfh brush, z0ZzZzbdh rect)
	{
		z0eek().z0rek(brush, rect);
	}

	public void GraphicsDrawImage(z0ZzZzedh img, float x, float y, float width, float height)
	{
		z0eek().z0eek(img, x, y, width, height);
	}

	public void GraphicsDrawEllipse(Color c, z0ZzZzbdh rect)
	{
		z0eek().z0tek(c, rect);
	}

	public void GraphicsFillPath(Color c, z0ZzZznfh path)
	{
		z0eek().z0eek(c, path);
	}

	public void GraphicsDrawPolygon(Color c, z0ZzZzpdh[] ps)
	{
		z0eek().z0eek(c, ps);
	}

	public void GraphicsDrawString(string s, z0ZzZzsdh font, z0ZzZztfh brush, float x, float y)
	{
		z0eek().z0eek(s, font, brush, x, y);
	}

	public void GraphicsDrawPolygon(z0ZzZzudh p, z0ZzZzpdh[] ps)
	{
		z0eek().z0rek(p, ps);
	}

	public void GraphicsFillRectangle(z0ZzZzemk brush, z0ZzZzndh rect)
	{
		z0eek().z0eek(brush, rect);
	}

	public void GraphicsFillRoundRectangle(Color c, float left, float top, float width, float height, float radio)
	{
		z0eek().z0eek(c, left, top, width, height, radio);
	}

	public void GraphicsDrawLines(z0ZzZzudh pen, z0ZzZzpdh[] points)
	{
		z0eek().z0eek(pen, points);
	}

	public void GraphicsDrawImage(z0ZzZzedh img, z0ZzZzbdh rect)
	{
		z0eek().z0eek(img, rect);
	}

	private z0ZzZzjpk z0eek()
	{
		return z0yek.z0gyk;
	}

	public void GraphicsDrawLine(z0ZzZznmk pen, float x1, float y1, float x2, float y2)
	{
		z0eek().z0eek(pen, x1, y1, x2, y2);
	}

	public z0ZzZzxdh GraphicsMeasureString(string text, z0ZzZzsdh font)
	{
		return z0eek().z0eek(text, font);
	}

	public void GraphicsDrawString(string s, z0ZzZzimk font, Color c, float x, float y)
	{
		z0eek().z0eek(s, font, c, x, y);
	}

	public void GraphicsDrawPath(Color lineColor, float lineWidth, z0ZzZznfh path)
	{
		z0eek().z0eek(lineColor, lineWidth, path);
	}

	public void GraphicsDrawRoundRectangle(z0ZzZznmk p, float left, float top, float width, float height, float radio)
	{
		z0eek().z0eek(p, left, top, width, height, radio);
	}

	public void GraphicsDrawImage(z0ZzZzedh img, float x, float y)
	{
		z0eek().z0eek(img, x, y);
	}

	public void GraphicsDrawEllipse(Color c, float lineWidth, DashStyle lineStyle, z0ZzZzbdh rect)
	{
		z0eek().z0eek(c, lineWidth, lineStyle, rect);
	}

	public void GraphicsDrawRectangle(z0ZzZzudh pen, z0ZzZzbdh rect)
	{
		z0eek().z0rek(pen, rect);
	}

	public void GraphicsDrawLine(z0ZzZznmk pen, z0ZzZzpdh pt1, z0ZzZzpdh pt2)
	{
		z0eek().z0eek(pen, pt1, pt2);
	}

	public void GraphicsDrawLine(z0ZzZznmk pen, int x1, int y1, int x2, int y2)
	{
		z0eek().z0eek(pen, x1, y1, x2, y2);
	}

	public void GraphicsDrawImageUnscaled(z0ZzZzedh image, int x, int y)
	{
		z0eek().z0eek(image, x, y);
	}

	public void GraphicsDrawPath(z0ZzZznmk p, z0ZzZznfh path)
	{
		z0eek().z0eek(p, path);
	}

	private z0ZzZzjpk z0rek()
	{
		return z0yek.z0gyk;
	}

	public void GraphicsDrawEllipse(z0ZzZzudh pen, z0ZzZzbdh rect)
	{
		z0eek().z0eek(pen, rect);
	}

	public void GraphicsFillEllipse(Color c, z0ZzZzbdh rect)
	{
		z0eek().z0eek(c, rect);
	}

	public void GraphicsDrawPath(z0ZzZzudh p, z0ZzZznfh path)
	{
		z0eek().z0eek(p, path);
	}

	public void GraphicsDrawPath(Color lineColor, z0ZzZznfh path)
	{
		z0eek().z0rek(lineColor, path);
	}

	public void GraphicsDrawLine(z0ZzZzudh pen, float x1, float y1, float x2, float y2)
	{
		z0eek().z0eek(pen, x1, y1, x2, y2);
	}

	public void GraphicsFillRectangle(z0ZzZztfh brush, z0ZzZzndh rect)
	{
		z0eek().z0eek(brush, rect);
	}

	public void GraphicsDrawPie(z0ZzZzudh p, float x, float y, float width, float height, float startAngle, float sweepAngle)
	{
		z0eek().z0eek(p, x, y, width, height, startAngle, sweepAngle);
	}

	public void GraphicsDrawLine(Color color, float width, DashStyle lineStyle, float x1, float y1, float x2, float y2)
	{
		z0eek().z0eek(color, width, lineStyle, x1, y1, x2, y2);
	}

	public void GraphicsDrawRectangle(z0ZzZznmk pen, z0ZzZzbdh rect)
	{
		z0eek().z0eek(pen, rect);
	}

	public float GraphicsGetFontHeight(z0ZzZzsdh font)
	{
		return z0eek().z0eek(font);
	}

	public void GraphicsDrawLine(z0ZzZzudh pen, int x1, int y1, int x2, int y2)
	{
		z0eek().z0eek(pen, x1, y1, x2, y2);
	}

	public void GraphicsDrawLine(Color color, float width, float x1, float y1, float x2, float y2)
	{
		z0eek().z0rek(color, width, x1, y1, x2, y2);
	}

	public WriterDrawShapeContentEventArgs(z0ZzZzdbj ctl, XTextDocument document, XTextCustomShapeElement shapeElement, z0ZzZzvxj args)
		: base(ctl, document, shapeElement)
	{
		z0uek = ShapeElement;
		z0yek = args;
	}

	public void GraphicsDrawPie(z0ZzZzudh p, z0ZzZzndh rect, float startAngle, float sweepAngle)
	{
		z0eek().z0eek(p, rect, startAngle, sweepAngle);
	}

	public void GraphicsFillRectangle(z0ZzZzemk brush, z0ZzZzbdh rect)
	{
		z0eek().z0eek(brush, rect);
	}

	public z0ZzZzxdh GraphicsMeasureString(string text, z0ZzZzimk font)
	{
		return z0eek().z0eek(text, font);
	}

	public void GraphicsFillPie(z0ZzZztfh b, float x, float y, float width, float height, float startAngle, float sweepAngle)
	{
		z0eek().z0eek(b, x, y, width, height, startAngle, sweepAngle);
	}

	private z0ZzZzbdh z0tek()
	{
		return z0yek.z0gtk;
	}

	public void GraphicsDrawEllipse(Color c, float lineWidth, z0ZzZzbdh rect)
	{
		z0eek().z0eek(c, lineWidth, DashStyle.Solid, rect);
	}
}
