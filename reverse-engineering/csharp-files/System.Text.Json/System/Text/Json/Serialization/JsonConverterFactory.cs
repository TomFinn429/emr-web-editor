using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization;

public abstract class JsonConverterFactory : JsonConverter
{
	internal sealed override ConverterStrategy ConverterStrategy => ConverterStrategy.None;

	internal sealed override Type? KeyType => null;

	internal sealed override Type? ElementType => null;

	internal sealed override Type TypeToConvert => null;

	public abstract JsonConverter? CreateConverter(Type P_0, JsonSerializerOptions P_1);

	internal override JsonParameterInfo CreateJsonParameterInfo()
	{
		throw new InvalidOperationException();
	}

	internal JsonConverter GetConverterInternal(Type P_0, JsonSerializerOptions P_1)
	{
		JsonConverter jsonConverter = CreateConverter(P_0, P_1);
		if (jsonConverter != null)
		{
			if (jsonConverter is JsonConverterFactory)
			{
				ThrowHelper.ThrowInvalidOperationException_SerializerConverterFactoryReturnsJsonConverterFactorty(GetType());
			}
		}
		else
		{
			ThrowHelper.ThrowInvalidOperationException_SerializerConverterFactoryReturnsNull(GetType());
		}
		return jsonConverter;
	}

	internal sealed override object ReadCoreAsObject(ref Utf8JsonReader P_0, JsonSerializerOptions P_1, scoped ref ReadStack P_2)
	{
		throw new InvalidOperationException();
	}

	internal sealed override bool OnTryReadAsObject(ref Utf8JsonReader P_0, JsonSerializerOptions P_1, scoped ref ReadStack P_2, out object P_3)
	{
		throw new InvalidOperationException();
	}

	internal sealed override bool TryReadAsObject(ref Utf8JsonReader P_0, JsonSerializerOptions P_1, scoped ref ReadStack P_2, out object P_3)
	{
		throw new InvalidOperationException();
	}

	internal sealed override bool TryWriteAsObject(Utf8JsonWriter P_0, object P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		throw new InvalidOperationException();
	}

	internal sealed override bool WriteCoreAsObject(Utf8JsonWriter P_0, object P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		throw new InvalidOperationException();
	}

	internal sealed override void WriteAsPropertyNameCoreAsObject(Utf8JsonWriter P_0, object P_1, JsonSerializerOptions P_2, bool P_3)
	{
		throw new InvalidOperationException();
	}

	internal sealed override JsonConverter<TTarget> CreateCastingConverter<TTarget>()
	{
		ThrowHelper.ThrowInvalidOperationException_ConverterCanConvertMultipleTypes(typeof(TTarget), this);
		return null;
	}
}
