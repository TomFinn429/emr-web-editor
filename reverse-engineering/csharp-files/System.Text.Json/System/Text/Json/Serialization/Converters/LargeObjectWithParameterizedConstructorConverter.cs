using System.Buffers;
using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal class LargeObjectWithParameterizedConstructorConverter<T> : ObjectWithParameterizedConstructorConverter<T>
{
	protected sealed override bool ReadAndCacheConstructorArgument(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, JsonParameterInfo P_2)
	{
		object obj;
		bool flag = P_2.ConverterBase.TryReadAsObject(ref P_1, P_2.Options, ref P_0, out obj);
		if (flag && (obj != null || !P_2.IgnoreNullTokensOnRead))
		{
			((object[])P_0.Current.CtorArgumentState.Arguments)[P_2.ClrInfo.Position] = obj;
			P_0.Current.MarkRequiredPropertyAsRead(P_2.MatchingProperty);
		}
		return flag;
	}

	protected sealed override object CreateObject(ref ReadStackFrame P_0)
	{
		object[] array = (object[])P_0.CtorArgumentState.Arguments;
		P_0.CtorArgumentState.Arguments = null;
		Func<object[], T> func = (Func<object[], T>)P_0.JsonTypeInfo.CreateObjectWithArgs;
		if (func == null)
		{
			ThrowHelper.ThrowNotSupportedException_ConstructorMaxOf64Parameters(TypeToConvert);
		}
		object result = func(array);
		ArrayPool<object>.Shared.Return(array, true);
		return result;
	}

	protected sealed override void InitializeConstructorArgumentCaches(ref ReadStack P_0, JsonSerializerOptions P_1)
	{
		JsonTypeInfo jsonTypeInfo = P_0.Current.JsonTypeInfo;
		List<KeyValuePair<string, JsonParameterInfo>> list = jsonTypeInfo.ParameterCache.List;
		object[] array = ArrayPool<object>.Shared.Rent(list.Count);
		for (int i = 0; i < jsonTypeInfo.ParameterCount; i++)
		{
			JsonParameterInfo value = list[i].Value;
			array[value.ClrInfo.Position] = value.DefaultValue;
		}
		P_0.Current.CtorArgumentState.Arguments = array;
	}
}
