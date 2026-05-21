internal static class InteropErrorExtensions
{
	public static Interop.ErrorInfo Info(this Interop.Error P_0)
	{
		return new Interop.ErrorInfo(P_0);
	}
}
