using System.Runtime.CompilerServices;

internal static class Interop
{
	internal static class Runtime
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ReleaseCSOwnedObject(nint P_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern void BindJSFunction(in string P_0, in string P_1, void* P_2, out nint P_3, out int P_4, out object P_5);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern void InvokeJSFunction(nint P_0, void* P_1);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern void BindCSFunction(in string P_0, int P_1, void* P_2, out int P_3, out object P_4);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern void MarshalPromise(void* P_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern nint RegisterGCRoot(nint P_0, int P_1, nint P_2);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void DeregisterGCRoot(nint P_0);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void InvokeJSWithArgsRef(nint P_0, in string P_1, in object[] P_2, out int P_3, out object P_4);
	}
}
