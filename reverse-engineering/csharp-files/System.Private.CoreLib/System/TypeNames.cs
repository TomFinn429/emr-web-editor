namespace System;

internal static class TypeNames
{
	internal abstract class ATypeName : ITypeName, IEquatable<ITypeName>
	{
		public abstract string DisplayName { get; }

		public bool Equals(ITypeName P_0)
		{
			if (P_0 != null)
			{
				return DisplayName == P_0.DisplayName;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return DisplayName.GetHashCode();
		}

		public override bool Equals(object P_0)
		{
			return Equals(P_0 as ITypeName);
		}
	}
}
