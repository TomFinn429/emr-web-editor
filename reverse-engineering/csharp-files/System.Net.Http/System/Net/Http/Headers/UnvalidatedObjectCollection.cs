namespace System.Net.Http.Headers;

internal sealed class UnvalidatedObjectCollection<T> : ObjectCollection<T> where T : class
{
	public override void Validate(T P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "item");
	}
}
