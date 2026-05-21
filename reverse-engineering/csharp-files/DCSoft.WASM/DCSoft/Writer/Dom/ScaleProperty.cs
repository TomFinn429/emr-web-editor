using System.ComponentModel;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("ScaleProperty")]
public class ScaleProperty
{
	private float _ScaleRate;

	private float _Value;

	[z0ZzZztqh]
	[DefaultValue(0f)]
	public float ScaleRate
	{
		get
		{
			return _ScaleRate;
		}
		set
		{
			_ScaleRate = value;
		}
	}

	[DefaultValue(0)]
	[z0ZzZztqh]
	public float Value
	{
		get
		{
			return _Value;
		}
		set
		{
			_Value = value;
		}
	}
}
