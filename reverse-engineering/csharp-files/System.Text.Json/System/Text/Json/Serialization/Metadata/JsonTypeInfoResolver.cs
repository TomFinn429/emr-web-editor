namespace System.Text.Json.Serialization.Metadata;

public static class JsonTypeInfoResolver
{
	private sealed class CombiningJsonTypeInfoResolver : IJsonTypeInfoResolver
	{
		private readonly IJsonTypeInfoResolver[] _resolvers;

		public CombiningJsonTypeInfoResolver(IJsonTypeInfoResolver[] P_0)
		{
			_resolvers = P_0.AsSpan().ToArray();
		}

		public JsonTypeInfo GetTypeInfo(Type P_0, JsonSerializerOptions P_1)
		{
			IJsonTypeInfoResolver[] resolvers = _resolvers;
			foreach (IJsonTypeInfoResolver jsonTypeInfoResolver in resolvers)
			{
				JsonTypeInfo typeInfo = jsonTypeInfoResolver.GetTypeInfo(P_0, P_1);
				if (typeInfo != null)
				{
					return typeInfo;
				}
			}
			return null;
		}
	}

	public static IJsonTypeInfoResolver Combine(params IJsonTypeInfoResolver[] P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("resolvers");
		}
		foreach (IJsonTypeInfoResolver jsonTypeInfoResolver in P_0)
		{
			if (jsonTypeInfoResolver == null)
			{
				throw new ArgumentNullException("resolvers", "CombineOneOfResolversIsNull");
			}
		}
		return new CombiningJsonTypeInfoResolver(P_0);
	}
}
