using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Text.Json.Serialization.Metadata;

internal sealed class DefaultValueHolder
{
	public object DefaultValue { get; }

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2067:UnrecognizedReflectionPattern", Justification = "GetUninitializedObject is only called on a struct. You can always create an instance of a struct.")]
	private DefaultValueHolder(Type P_0)
	{
		if (P_0.IsValueType && Nullable.GetUnderlyingType(P_0) == null)
		{
			DefaultValue = RuntimeHelpers.GetUninitializedObject(P_0);
		}
	}

	public static DefaultValueHolder CreateHolder(Type P_0)
	{
		return new DefaultValueHolder(P_0);
	}
}
