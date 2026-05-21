using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class IListConverter<TCollection> : JsonCollectionConverter<TCollection, object> where TCollection : IList
{
	protected override void Add(in object P_0, ref ReadStack P_1)
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

	protected override bool OnWriteResume(Utf8JsonWriter P_0, TCollection P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		IList list = P_1;
		int i = P_3.Current.EnumeratorIndex;
		JsonConverter<object> elementConverter = JsonCollectionConverter<TCollection, object>.GetElementConverter(ref P_3);
		if (elementConverter.CanUseDirectReadOrWrite && !P_3.Current.NumberHandling.HasValue)
		{
			for (; i < list.Count; i++)
			{
				elementConverter.Write(P_0, list[i], P_2);
			}
		}
		else
		{
			for (; i < list.Count; i++)
			{
				if (!elementConverter.TryWrite(P_0, list[i], P_2, ref P_3))
				{
					P_3.Current.EnumeratorIndex = i;
					return false;
				}
				P_3.Current.EndCollectionElement();
				if (JsonConverter.ShouldFlush(P_0, ref P_3))
				{
					i = (P_3.Current.EnumeratorIndex = i + 1);
					return false;
				}
			}
		}
		return true;
	}

	internal override void ConfigureJsonTypeInfo(JsonTypeInfo P_0, JsonSerializerOptions P_1)
	{
		if (P_0.CreateObject == null && TypeToConvert.IsAssignableFrom(typeof(List<object>)))
		{
			P_0.CreateObject = () => new List<object>();
		}
	}
}
