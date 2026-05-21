using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class IListOfTConverter<TCollection, TElement> : IEnumerableDefaultConverter<TCollection, TElement> where TCollection : IList<TElement>
{
	protected override void Add(in TElement P_0, ref ReadStack P_1)
	{
		TCollection val = (TCollection)P_1.Current.ReturnValue;
		val.Add(P_0);
		if (base.IsValueType)
		{
			P_1.Current.ReturnValue = val;
		}
	}

	protected override void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1, JsonSerializerOptions P_2)
	{
		base.CreateCollection(ref P_0, ref P_1, P_2);
		if (((TCollection)P_1.Current.ReturnValue).IsReadOnly)
		{
			P_1.Current.ReturnValue = null;
			ThrowHelper.ThrowNotSupportedException_CannotPopulateCollection(TypeToConvert, ref P_0, ref P_1);
		}
	}

	internal override void ConfigureJsonTypeInfo(JsonTypeInfo P_0, JsonSerializerOptions P_1)
	{
		if (P_0.CreateObject == null && TypeToConvert.IsAssignableFrom(typeof(List<TElement>)))
		{
			P_0.CreateObject = () => new List<TElement>();
		}
	}
}
