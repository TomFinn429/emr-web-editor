using zzz;

namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
[z0ZzZzoqh]
[CompilerGenerated]
internal sealed class NullableAttribute : Attribute
{
	public readonly byte[] NullableFlags;

	public NullableAttribute(byte[] A_1)
	{
		NullableFlags = A_1;
	}

	public NullableAttribute(byte A_1)
	{
		NullableFlags = new byte[1] { A_1 };
	}
}
