namespace System;

internal interface ITypeName : IEquatable<ITypeName>
{
	string DisplayName { get; }
}
