namespace System;

internal static class TypeIdentifiers
{
	private sealed class NoEscape : TypeNames.ATypeName, ITypeIdentifier, ITypeName, IEquatable<ITypeName>
	{
		private readonly string simpleName;

		public override string DisplayName => simpleName;

		internal NoEscape(string P_0)
		{
			simpleName = P_0;
		}
	}

	internal static ITypeIdentifier WithoutEscape(string P_0)
	{
		return new NoEscape(P_0);
	}
}
