using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Text.Json.Serialization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface, AllowMultiple = false)]
public class JsonConverterAttribute : JsonAttribute
{
	[CompilerGenerated]
	private Type _003CConverterType_003Ek__BackingField;

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
	public Type? ConverterType
	{
		[CompilerGenerated]
		get
		{
			return _003CConverterType_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CConverterType_003Ek__BackingField = type;
		}
	}

	public JsonConverterAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] Type P_0)
	{
		ConverterType = P_0;
	}

	public virtual JsonConverter? CreateConverter(Type P_0)
	{
		return null;
	}
}
