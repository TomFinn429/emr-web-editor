namespace System.Text.Json.Serialization.Metadata;

public readonly struct JsonDerivedType
{
	public Type DerivedType { get; }

	public object? TypeDiscriminator { get; }

	internal JsonDerivedType(Type P_0, object P_1)
	{
		DerivedType = P_0;
		TypeDiscriminator = P_1;
	}

	internal void Deconstruct(out Type P_0, out object P_1)
	{
		P_0 = DerivedType;
		P_1 = TypeDiscriminator;
	}
}
