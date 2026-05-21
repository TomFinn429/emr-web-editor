using zzz;

namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
[z0ZzZzoqh]
[CompilerGenerated]
internal sealed class NullableAttribute_2 : Attribute
{
	public readonly byte[] NullableFlags;

	public NullableAttribute_2(byte[] A_1)
	{
		((System.Runtime.CompilerServices.NullableAttribute)this).NullableFlags = A_1;
	}

	public NullableAttribute_2(byte A_1)
	{
		((System.Runtime.CompilerServices.NullableAttribute)this).NullableFlags = new byte[1] { A_1 };
	}
}
