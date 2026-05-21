using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal class SmallObjectWithParameterizedConstructorConverter<T, TArg0, TArg1, TArg2, TArg3> : ObjectWithParameterizedConstructorConverter<T>
{
	protected override object CreateObject(ref ReadStackFrame P_0)
	{
		JsonTypeInfo.ParameterizedConstructorDelegate<T, TArg0, TArg1, TArg2, TArg3> parameterizedConstructorDelegate = (JsonTypeInfo.ParameterizedConstructorDelegate<T, TArg0, TArg1, TArg2, TArg3>)P_0.JsonTypeInfo.CreateObjectWithArgs;
		Arguments<TArg0, TArg1, TArg2, TArg3> arguments = (Arguments<TArg0, TArg1, TArg2, TArg3>)P_0.CtorArgumentState.Arguments;
		return parameterizedConstructorDelegate(arguments.Arg0, arguments.Arg1, arguments.Arg2, arguments.Arg3);
	}

	protected override bool ReadAndCacheConstructorArgument(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, JsonParameterInfo P_2)
	{
		Arguments<TArg0, TArg1, TArg2, TArg3> arguments = (Arguments<TArg0, TArg1, TArg2, TArg3>)P_0.Current.CtorArgumentState.Arguments;
		return P_2.ClrInfo.Position switch
		{
			0 => TryRead<TArg0>(ref P_0, ref P_1, P_2, out arguments.Arg0), 
			1 => TryRead<TArg1>(ref P_0, ref P_1, P_2, out arguments.Arg1), 
			2 => TryRead<TArg2>(ref P_0, ref P_1, P_2, out arguments.Arg2), 
			3 => TryRead<TArg3>(ref P_0, ref P_1, P_2, out arguments.Arg3), 
			_ => throw new InvalidOperationException(), 
		};
	}

	private static bool TryRead<TArg>(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, JsonParameterInfo P_2, out TArg P_3)
	{
		JsonParameterInfo<TArg> jsonParameterInfo = (JsonParameterInfo<TArg>)P_2;
		JsonConverter<TArg> jsonConverter = (JsonConverter<TArg>)P_2.ConverterBase;
		TArg val;
		bool flag = jsonConverter.TryRead(ref P_1, jsonParameterInfo.PropertyType, jsonParameterInfo.Options, ref P_0, out val);
		P_3 = ((val == null && P_2.IgnoreNullTokensOnRead) ? ((TArg)jsonParameterInfo.DefaultValue) : val);
		if (flag)
		{
			P_0.Current.MarkRequiredPropertyAsRead(P_2.MatchingProperty);
		}
		return flag;
	}

	protected override void InitializeConstructorArgumentCaches(ref ReadStack P_0, JsonSerializerOptions P_1)
	{
		JsonTypeInfo jsonTypeInfo = P_0.Current.JsonTypeInfo;
		JsonTypeInfo jsonTypeInfo2 = jsonTypeInfo;
		if (jsonTypeInfo2.CreateObjectWithArgs == null)
		{
			object obj = (jsonTypeInfo2.CreateObjectWithArgs = P_1.MemberAccessorStrategy.CreateParameterizedConstructor<T, TArg0, TArg1, TArg2, TArg3>(base.ConstructorInfo));
		}
		Arguments<TArg0, TArg1, TArg2, TArg3> arguments = new Arguments<TArg0, TArg1, TArg2, TArg3>();
		List<KeyValuePair<string, JsonParameterInfo>> list = jsonTypeInfo.ParameterCache.List;
		for (int i = 0; i < jsonTypeInfo.ParameterCount; i++)
		{
			JsonParameterInfo value = list[i].Value;
			if (value.ShouldDeserialize)
			{
				switch (value.ClrInfo.Position)
				{
				case 0:
					arguments.Arg0 = ((JsonParameterInfo<TArg0>)value).TypedDefaultValue;
					break;
				case 1:
					arguments.Arg1 = ((JsonParameterInfo<TArg1>)value).TypedDefaultValue;
					break;
				case 2:
					arguments.Arg2 = ((JsonParameterInfo<TArg2>)value).TypedDefaultValue;
					break;
				case 3:
					arguments.Arg3 = ((JsonParameterInfo<TArg3>)value).TypedDefaultValue;
					break;
				default:
					throw new InvalidOperationException();
				}
			}
		}
		P_0.Current.CtorArgumentState.Arguments = arguments;
	}
}
