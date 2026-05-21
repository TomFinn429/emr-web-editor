using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization.Converters;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization;

public abstract class JsonConverter
{
	[CompilerGenerated]
	private bool _003CCanUseDirectReadOrWrite_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CCanBePolymorphic_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CRequiresReadAhead_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsValueType_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsInternalConverter_003Ek__BackingField;

	internal bool IsInternalConverterForNumberType;

	[CompilerGenerated]
	private ConstructorInfo _003CConstructorInfo_003Ek__BackingField;

	internal abstract ConverterStrategy ConverterStrategy { get; }

	internal virtual bool SupportsCreateObjectDelegate => false;

	internal bool CanUseDirectReadOrWrite
	{
		[CompilerGenerated]
		get
		{
			return _003CCanUseDirectReadOrWrite_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CCanUseDirectReadOrWrite_003Ek__BackingField = flag;
		}
	}

	internal virtual bool CanHaveMetadata => false;

	internal bool CanBePolymorphic
	{
		[CompilerGenerated]
		get
		{
			return _003CCanBePolymorphic_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CCanBePolymorphic_003Ek__BackingField = flag;
		}
	}

	internal bool RequiresReadAhead
	{
		[CompilerGenerated]
		get
		{
			return _003CRequiresReadAhead_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CRequiresReadAhead_003Ek__BackingField = flag;
		}
	}

	internal abstract Type? ElementType { get; }

	internal abstract Type? KeyType { get; }

	internal bool IsValueType
	{
		[CompilerGenerated]
		get
		{
			return _003CIsValueType_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CIsValueType_003Ek__BackingField = flag;
		}
	}

	internal bool IsInternalConverter
	{
		[CompilerGenerated]
		get
		{
			return _003CIsInternalConverter_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CIsInternalConverter_003Ek__BackingField = flag;
		}
	}

	internal abstract Type TypeToConvert { get; }

	internal virtual bool ConstructorIsParameterized { get; }

	internal ConstructorInfo? ConstructorInfo
	{
		[CompilerGenerated]
		get
		{
			return _003CConstructorInfo_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CConstructorInfo_003Ek__BackingField = constructorInfo;
		}
	}

	internal JsonConverter()
	{
	}

	public abstract bool CanConvert(Type P_0);

	internal virtual void ReadElementAndSetProperty(object P_0, string P_1, ref Utf8JsonReader P_2, JsonSerializerOptions P_3, scoped ref ReadStack P_4)
	{
		throw new InvalidOperationException();
	}

	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	internal virtual JsonTypeInfo CreateReflectionJsonTypeInfo(JsonSerializerOptions P_0)
	{
		throw new InvalidOperationException();
	}

	internal abstract JsonParameterInfo CreateJsonParameterInfo();

	internal abstract JsonConverter<TTarget> CreateCastingConverter<TTarget>();

	internal abstract object ReadCoreAsObject(ref Utf8JsonReader P_0, JsonSerializerOptions P_1, scoped ref ReadStack P_2);

	internal static bool ShouldFlush(Utf8JsonWriter P_0, ref WriteStack P_1)
	{
		if (P_1.FlushThreshold > 0)
		{
			return P_0.BytesPending > P_1.FlushThreshold;
		}
		return false;
	}

	internal abstract bool OnTryReadAsObject(ref Utf8JsonReader P_0, JsonSerializerOptions P_1, scoped ref ReadStack P_2, out object P_3);

	internal abstract bool TryReadAsObject(ref Utf8JsonReader P_0, JsonSerializerOptions P_1, scoped ref ReadStack P_2, out object P_3);

	internal abstract bool TryWriteAsObject(Utf8JsonWriter P_0, object P_1, JsonSerializerOptions P_2, ref WriteStack P_3);

	internal abstract bool WriteCoreAsObject(Utf8JsonWriter P_0, object P_1, JsonSerializerOptions P_2, ref WriteStack P_3);

	internal abstract void WriteAsPropertyNameCoreAsObject(Utf8JsonWriter P_0, object P_1, JsonSerializerOptions P_2, bool P_3);

	internal virtual void ConfigureJsonTypeInfo(JsonTypeInfo P_0, JsonSerializerOptions P_1)
	{
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	internal virtual void ConfigureJsonTypeInfoUsingReflection(JsonTypeInfo P_0, JsonSerializerOptions P_1)
	{
	}

	internal JsonConverter ResolvePolymorphicConverter(JsonTypeInfo P_0, JsonSerializerOptions P_1, ref ReadStack P_2)
	{
		JsonConverter jsonConverter = null;
		switch (P_2.Current.PolymorphicSerializationState)
		{
		case PolymorphicSerializationState.None:
		{
			PolymorphicTypeResolver polymorphicTypeResolver = P_0.PolymorphicTypeResolver;
			if (polymorphicTypeResolver.TryGetDerivedJsonTypeInfo(P_2.PolymorphicTypeDiscriminator, out var jsonTypeInfo))
			{
				jsonConverter = P_2.InitializePolymorphicReEntry(jsonTypeInfo);
				if (!jsonConverter.CanHaveMetadata)
				{
					ThrowHelper.ThrowNotSupportedException_DerivedConverterDoesNotSupportMetadata(jsonTypeInfo.Type);
				}
			}
			else
			{
				P_2.Current.PolymorphicSerializationState = PolymorphicSerializationState.PolymorphicReEntryNotFound;
			}
			P_2.PolymorphicTypeDiscriminator = null;
			break;
		}
		case PolymorphicSerializationState.PolymorphicReEntrySuspended:
			jsonConverter = P_2.ResumePolymorphicReEntry();
			break;
		}
		return jsonConverter;
	}

	internal JsonConverter ResolvePolymorphicConverter(object P_0, JsonTypeInfo P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		JsonConverter jsonConverter = null;
		switch (P_3.Current.PolymorphicSerializationState)
		{
		case PolymorphicSerializationState.None:
		{
			if (P_3.IsPolymorphicRootValue && P_3.CurrentDepth == 0)
			{
				P_3.Current.PolymorphicSerializationState = PolymorphicSerializationState.PolymorphicReEntryNotFound;
				break;
			}
			Type type = P_0.GetType();
			PolymorphicTypeResolver polymorphicTypeResolver = P_1.PolymorphicTypeResolver;
			if (polymorphicTypeResolver != null)
			{
				if (polymorphicTypeResolver.TryGetDerivedJsonTypeInfo(type, out var jsonTypeInfo, out var obj))
				{
					jsonConverter = P_3.Current.InitializePolymorphicReEntry(jsonTypeInfo);
					if (obj != null)
					{
						if (!jsonConverter.CanHaveMetadata)
						{
							ThrowHelper.ThrowNotSupportedException_DerivedConverterDoesNotSupportMetadata(jsonTypeInfo.Type);
						}
						P_3.PolymorphicTypeDiscriminator = obj;
					}
				}
				else
				{
					P_3.Current.PolymorphicSerializationState = PolymorphicSerializationState.PolymorphicReEntryNotFound;
				}
			}
			else if (type != TypeToConvert)
			{
				jsonConverter = P_3.Current.InitializePolymorphicReEntry(type, P_2);
			}
			else
			{
				P_3.Current.PolymorphicSerializationState = PolymorphicSerializationState.PolymorphicReEntryNotFound;
			}
			break;
		}
		case PolymorphicSerializationState.PolymorphicReEntrySuspended:
			jsonConverter = P_3.Current.ResumePolymorphicReEntry();
			break;
		}
		return jsonConverter;
	}

	internal bool TryHandleSerializedObjectReference(Utf8JsonWriter P_0, object P_1, JsonSerializerOptions P_2, JsonConverter P_3, ref WriteStack P_4)
	{
		switch (P_2.ReferenceHandlingStrategy)
		{
		case ReferenceHandlingStrategy.IgnoreCycles:
		{
			ReferenceResolver referenceResolver = P_4.ReferenceResolver;
			if (referenceResolver.ContainsReferenceForCycleDetection(P_1))
			{
				P_0.WriteNullValue();
				return true;
			}
			referenceResolver.PushReferenceForCycleDetection(P_1);
			P_4.Current.IsPushedReferenceForCycleDetection = P_4.CurrentDepth > 0;
			break;
		}
		case ReferenceHandlingStrategy.Preserve:
			if ((P_3?.CanHaveMetadata ?? CanHaveMetadata) && JsonSerializer.TryGetReferenceForValue(P_1, ref P_4, P_0))
			{
				return true;
			}
			break;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static bool SingleValueReadWithReadAhead(bool P_0, ref Utf8JsonReader P_1, scoped ref ReadStack P_2)
	{
		if (!P_0 || !P_2.ReadAhead)
		{
			return P_1.Read();
		}
		return DoSingleValueReadWithReadAhead(ref P_1, ref P_2);
	}

	internal static bool DoSingleValueReadWithReadAhead(ref Utf8JsonReader P_0, scoped ref ReadStack P_1)
	{
		Utf8JsonReader utf8JsonReader = P_0;
		if (!P_0.Read())
		{
			return false;
		}
		JsonTokenType tokenType = P_0.TokenType;
		if (tokenType == JsonTokenType.StartObject || tokenType == JsonTokenType.StartArray)
		{
			bool flag = P_0.TrySkip();
			P_0 = utf8JsonReader;
			if (!flag)
			{
				return false;
			}
			P_0.ReadWithVerify();
		}
		return true;
	}
}
public abstract class JsonConverter<T> : JsonConverter
{
	internal override ConverterStrategy ConverterStrategy => ConverterStrategy.Value;

	internal virtual JsonConverter? SourceConverterForCastingConverter => null;

	internal override Type? KeyType => null;

	internal override Type? ElementType => null;

	public virtual bool HandleNull
	{
		get
		{
			HandleNullOnRead = default(T) != null;
			HandleNullOnWrite = false;
			return false;
		}
	}

	internal bool HandleNullOnRead
	{
		[CompilerGenerated]
		get
		{
			return _003CHandleNullOnRead_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CHandleNullOnRead_003Ek__BackingField = flag;
		}
	}

	internal bool HandleNullOnWrite
	{
		[CompilerGenerated]
		get
		{
			return _003CHandleNullOnWrite_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CHandleNullOnWrite_003Ek__BackingField = flag;
		}
	}

	internal sealed override Type TypeToConvert { get; } = typeof(T);

	internal sealed override object ReadCoreAsObject(ref Utf8JsonReader P_0, JsonSerializerOptions P_1, scoped ref ReadStack P_2)
	{
		return ReadCore(ref P_0, P_1, ref P_2);
	}

	internal T ReadCore(ref Utf8JsonReader P_0, JsonSerializerOptions P_1, scoped ref ReadStack P_2)
	{
		try
		{
			if (!P_2.IsContinuation)
			{
				if (!JsonConverter.SingleValueReadWithReadAhead(base.RequiresReadAhead, ref P_0, ref P_2))
				{
					if (P_2.SupportContinuation)
					{
						P_2.BytesConsumed += P_0.BytesConsumed;
						if (P_2.Current.ReturnValue == null)
						{
							return default(T);
						}
						return (T)P_2.Current.ReturnValue;
					}
					P_2.BytesConsumed += P_0.BytesConsumed;
					return default(T);
				}
			}
			else if (!JsonConverter.SingleValueReadWithReadAhead(true, ref P_0, ref P_2))
			{
				P_2.BytesConsumed += P_0.BytesConsumed;
				return default(T);
			}
			if (TryRead(ref P_0, P_2.Current.JsonTypeInfo.Type, P_1, ref P_2, out var val) && !P_0.Read() && !P_0.IsFinalBlock)
			{
				P_2.Current.ReturnValue = val;
			}
			P_2.BytesConsumed += P_0.BytesConsumed;
			return val;
		}
		catch (JsonReaderException ex)
		{
			ThrowHelper.ReThrowWithPath(ref P_2, ex);
			return default(T);
		}
		catch (FormatException ex2) when (ex2.Source == "System.Text.Json.Rethrowable")
		{
			ThrowHelper.ReThrowWithPath(ref P_2, in P_0, ex2);
			return default(T);
		}
		catch (InvalidOperationException ex3) when (ex3.Source == "System.Text.Json.Rethrowable")
		{
			ThrowHelper.ReThrowWithPath(ref P_2, in P_0, ex3);
			return default(T);
		}
		catch (JsonException ex4) when (ex4.Path == null)
		{
			ThrowHelper.AddJsonExceptionInformation(ref P_2, in P_0, ex4);
			throw;
		}
		catch (NotSupportedException ex5)
		{
			if (ex5.Message.Contains(" Path: "))
			{
				throw;
			}
			ThrowHelper.ThrowNotSupportedException(ref P_2, in P_0, ex5);
			return default(T);
		}
	}

	internal sealed override bool WriteCoreAsObject(Utf8JsonWriter P_0, object P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		if (typeof(T).IsValueType)
		{
			if (default(T) != null && P_1 == null)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(TypeToConvert);
			}
			if (P_2.ReferenceHandlingStrategy == ReferenceHandlingStrategy.IgnoreCycles && P_1 != null)
			{
				P_3.ReferenceResolver.PushReferenceForCycleDetection(P_1);
			}
		}
		return WriteCore(P_0, (T)P_1, P_2, ref P_3);
	}

	internal bool WriteCore(Utf8JsonWriter P_0, in T P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		try
		{
			return TryWrite(P_0, in P_1, P_2, ref P_3);
		}
		catch (InvalidOperationException ex) when (ex.Source == "System.Text.Json.Rethrowable")
		{
			ThrowHelper.ReThrowWithPath(ref P_3, ex);
			throw;
		}
		catch (JsonException ex2) when (ex2.Path == null)
		{
			ThrowHelper.AddJsonExceptionInformation(ref P_3, ex2);
			throw;
		}
		catch (NotSupportedException ex3)
		{
			if (ex3.Message.Contains(" Path: "))
			{
				throw;
			}
			ThrowHelper.ThrowNotSupportedException(ref P_3, ex3);
			return false;
		}
	}

	protected internal JsonConverter()
		: this(true)
	{
	}

	internal JsonConverter(bool P_0)
	{
		base.IsValueType = typeof(T).IsValueType;
		base.IsInternalConverter = GetType().Assembly == typeof(JsonConverter).Assembly;
		if (P_0)
		{
			Initialize();
		}
	}

	private protected void Initialize()
	{
		if (HandleNull)
		{
			HandleNullOnRead = true;
			HandleNullOnWrite = true;
		}
		base.CanUseDirectReadOrWrite = ConverterStrategy == ConverterStrategy.Value && base.IsInternalConverter;
		base.RequiresReadAhead = ConverterStrategy == ConverterStrategy.Value;
	}

	public override bool CanConvert(Type P_0)
	{
		return P_0 == typeof(T);
	}

	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	internal sealed override JsonTypeInfo CreateReflectionJsonTypeInfo(JsonSerializerOptions P_0)
	{
		return new ReflectionJsonTypeInfo<T>(this, P_0);
	}

	internal sealed override JsonParameterInfo CreateJsonParameterInfo()
	{
		return new JsonParameterInfo<T>();
	}

	internal sealed override JsonConverter<TTarget> CreateCastingConverter<TTarget>()
	{
		if (this is JsonConverter<TTarget> result)
		{
			return result;
		}
		JsonSerializerOptions.CheckConverterNullabilityIsSameAsPropertyType(this, typeof(TTarget));
		return SourceConverterForCastingConverter?.CreateCastingConverter<TTarget>() ?? new CastingConverter<TTarget, T>(this);
	}

	internal sealed override bool TryWriteAsObject(Utf8JsonWriter P_0, object P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		return TryWrite(P_0, (T)P_1, P_2, ref P_3);
	}

	internal virtual bool OnTryWrite(Utf8JsonWriter P_0, T P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		Write(P_0, P_1, P_2);
		return true;
	}

	internal virtual bool OnTryRead(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2, scoped ref ReadStack P_3, out T P_4)
	{
		P_4 = Read(ref P_0, P_1, P_2);
		return true;
	}

	public abstract T? Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2);

	internal bool TryRead(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2, scoped ref ReadStack P_3, out T P_4)
	{
		if (P_0.TokenType == JsonTokenType.Null && !HandleNullOnRead && !P_3.IsContinuation)
		{
			if (default(T) != null)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(TypeToConvert);
			}
			P_4 = default(T);
			return true;
		}
		if (ConverterStrategy == ConverterStrategy.Value)
		{
			if (base.IsInternalConverter)
			{
				if (P_3.Current.NumberHandling.HasValue && IsInternalConverterForNumberType)
				{
					P_4 = ReadNumberWithCustomHandling(ref P_0, P_3.Current.NumberHandling.Value, P_2);
				}
				else
				{
					P_4 = Read(ref P_0, P_1, P_2);
				}
			}
			else
			{
				JsonTokenType tokenType = P_0.TokenType;
				int currentDepth = P_0.CurrentDepth;
				long bytesConsumed = P_0.BytesConsumed;
				if (P_3.Current.NumberHandling.HasValue && IsInternalConverterForNumberType)
				{
					P_4 = ReadNumberWithCustomHandling(ref P_0, P_3.Current.NumberHandling.Value, P_2);
				}
				else
				{
					P_4 = Read(ref P_0, P_1, P_2);
				}
				VerifyRead(tokenType, currentDepth, bytesConsumed, true, ref P_0);
			}
			return true;
		}
		bool isContinuation = P_3.IsContinuation;
		bool flag;
		if (!typeof(T).IsValueType && base.CanBePolymorphic)
		{
			flag = OnTryRead(ref P_0, P_1, P_2, ref P_3, out P_4);
			return true;
		}
		P_3.Push();
		flag = OnTryRead(ref P_0, P_1, P_2, ref P_3, out P_4);
		P_3.Pop(flag);
		return flag;
	}

	internal sealed override bool OnTryReadAsObject(ref Utf8JsonReader P_0, JsonSerializerOptions P_1, scoped ref ReadStack P_2, out object P_3)
	{
		T val;
		bool result = OnTryRead(ref P_0, TypeToConvert, P_1, ref P_2, out val);
		P_3 = val;
		return result;
	}

	internal sealed override bool TryReadAsObject(ref Utf8JsonReader P_0, JsonSerializerOptions P_1, scoped ref ReadStack P_2, out object P_3)
	{
		T val;
		bool result = TryRead(ref P_0, TypeToConvert, P_1, ref P_2, out val);
		P_3 = val;
		return result;
	}

	private static bool IsNull(T P_0)
	{
		return P_0 == null;
	}

	internal bool TryWrite(Utf8JsonWriter P_0, in T P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		if (P_0.CurrentDepth >= P_2.EffectiveMaxDepth)
		{
			ThrowHelper.ThrowJsonException_SerializerCycleDetected(P_2.EffectiveMaxDepth);
		}
		if (default(T) == null && !HandleNullOnWrite && IsNull(P_1))
		{
			P_0.WriteNullValue();
			return true;
		}
		if (ConverterStrategy == ConverterStrategy.Value)
		{
			int currentDepth = P_0.CurrentDepth;
			if (P_3.Current.NumberHandling.HasValue && IsInternalConverterForNumberType)
			{
				WriteNumberWithCustomHandling(P_0, P_1, P_3.Current.NumberHandling.Value);
			}
			else
			{
				Write(P_0, P_1, P_2);
			}
			VerifyWrite(currentDepth, P_0);
			return true;
		}
		bool isContinuation = P_3.IsContinuation;
		bool flag;
		if (!typeof(T).IsValueType && P_1 != null && P_3.Current.PolymorphicSerializationState != PolymorphicSerializationState.PolymorphicReEntryStarted)
		{
			JsonTypeInfo jsonTypeInfo = P_3.PeekNestedJsonTypeInfo();
			JsonConverter jsonConverter = ((base.CanBePolymorphic || jsonTypeInfo.PolymorphicTypeResolver != null) ? ResolvePolymorphicConverter(P_1, jsonTypeInfo, P_2, ref P_3) : null);
			if (!isContinuation && P_2.ReferenceHandlingStrategy != ReferenceHandlingStrategy.None && TryHandleSerializedObjectReference(P_0, P_1, P_2, jsonConverter, ref P_3))
			{
				return true;
			}
			if (jsonConverter != null)
			{
				flag = jsonConverter.TryWriteAsObject(P_0, P_1, P_2, ref P_3);
				P_3.Current.ExitPolymorphicConverter(flag);
				if (flag && P_3.Current.IsPushedReferenceForCycleDetection)
				{
					P_3.ReferenceResolver.PopReferenceForCycleDetection();
					P_3.Current.IsPushedReferenceForCycleDetection = false;
				}
				return flag;
			}
		}
		P_3.Push();
		flag = OnTryWrite(P_0, P_1, P_2, ref P_3);
		P_3.Pop(flag);
		if (flag && P_3.Current.IsPushedReferenceForCycleDetection)
		{
			P_3.ReferenceResolver.PopReferenceForCycleDetection();
			P_3.Current.IsPushedReferenceForCycleDetection = false;
		}
		return flag;
	}

	internal bool TryWriteDataExtensionProperty(Utf8JsonWriter P_0, T P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		if (!base.IsInternalConverter)
		{
			return TryWrite(P_0, in P_1, P_2, ref P_3);
		}
		JsonDictionaryConverter<T> jsonDictionaryConverter = (this as JsonDictionaryConverter<T>) ?? ((this as JsonMetadataServicesConverter<T>)?.Converter as JsonDictionaryConverter<T>);
		if (jsonDictionaryConverter == null)
		{
			return TryWrite(P_0, in P_1, P_2, ref P_3);
		}
		if (P_0.CurrentDepth >= P_2.EffectiveMaxDepth)
		{
			ThrowHelper.ThrowJsonException_SerializerCycleDetected(P_2.EffectiveMaxDepth);
		}
		bool isContinuation = P_3.IsContinuation;
		P_3.Push();
		if (!isContinuation)
		{
			P_3.Current.OriginalDepth = P_0.CurrentDepth;
		}
		P_3.Current.IsWritingExtensionDataProperty = true;
		P_3.Current.JsonPropertyInfo = P_3.Current.JsonTypeInfo.ElementTypeInfo.PropertyInfoForTypeInfo;
		bool flag = jsonDictionaryConverter.OnWriteResume(P_0, P_1, P_2, ref P_3);
		if (flag)
		{
			VerifyWrite(P_3.Current.OriginalDepth, P_0);
		}
		P_3.Pop(flag);
		return flag;
	}

	internal void VerifyRead(JsonTokenType P_0, int P_1, long P_2, bool P_3, ref Utf8JsonReader P_4)
	{
		switch (P_0)
		{
		case JsonTokenType.StartArray:
			if (P_4.TokenType != JsonTokenType.EndArray)
			{
				ThrowHelper.ThrowJsonException_SerializationConverterRead(this);
			}
			else if (P_1 != P_4.CurrentDepth)
			{
				ThrowHelper.ThrowJsonException_SerializationConverterRead(this);
			}
			return;
		case JsonTokenType.StartObject:
			if (P_4.TokenType != JsonTokenType.EndObject)
			{
				ThrowHelper.ThrowJsonException_SerializationConverterRead(this);
			}
			else if (P_1 != P_4.CurrentDepth)
			{
				ThrowHelper.ThrowJsonException_SerializationConverterRead(this);
			}
			return;
		}
		if (P_3)
		{
			if (P_4.BytesConsumed != P_2)
			{
				ThrowHelper.ThrowJsonException_SerializationConverterRead(this);
			}
		}
		else if (!base.CanBePolymorphic && (!HandleNullOnRead || P_0 != JsonTokenType.Null))
		{
			ThrowHelper.ThrowJsonException_SerializationConverterRead(this);
		}
	}

	internal void VerifyWrite(int P_0, Utf8JsonWriter P_1)
	{
		if (P_0 != P_1.CurrentDepth)
		{
			ThrowHelper.ThrowJsonException_SerializationConverterWrite(this);
		}
	}

	public abstract void Write(Utf8JsonWriter P_0, T P_1, JsonSerializerOptions P_2);

	public virtual T ReadAsPropertyName(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		if (!base.IsInternalConverter && P_2.SerializerContext == null && DefaultJsonTypeInfoResolver.TryGetDefaultSimpleConverter(TypeToConvert, out var jsonConverter))
		{
			return ((JsonConverter<T>)jsonConverter).ReadAsPropertyNameCore(ref P_0, TypeToConvert, P_2);
		}
		ThrowHelper.ThrowNotSupportedException_DictionaryKeyTypeNotSupported(TypeToConvert, this);
		return default(T);
	}

	internal virtual T ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		long bytesConsumed = P_0.BytesConsumed;
		T result = ReadAsPropertyName(ref P_0, P_1, P_2);
		if (P_0.BytesConsumed != bytesConsumed)
		{
			ThrowHelper.ThrowJsonException_SerializationConverterRead(this);
		}
		return result;
	}

	public virtual void WriteAsPropertyName(Utf8JsonWriter P_0, T P_1, JsonSerializerOptions P_2)
	{
		if (!base.IsInternalConverter && P_2.SerializerContext == null && DefaultJsonTypeInfoResolver.TryGetDefaultSimpleConverter(TypeToConvert, out var jsonConverter))
		{
			((JsonConverter<T>)jsonConverter).WriteAsPropertyNameCore(P_0, P_1, P_2, false);
		}
		else
		{
			ThrowHelper.ThrowNotSupportedException_DictionaryKeyTypeNotSupported(TypeToConvert, this);
		}
	}

	internal virtual void WriteAsPropertyNameCore(Utf8JsonWriter P_0, T P_1, JsonSerializerOptions P_2, bool P_3)
	{
		if (P_3)
		{
			P_0.WritePropertyName((string)(object)P_1);
			return;
		}
		int currentDepth = P_0.CurrentDepth;
		WriteAsPropertyName(P_0, P_1, P_2);
		if (currentDepth != P_0.CurrentDepth || P_0.TokenType != JsonTokenType.PropertyName)
		{
			ThrowHelper.ThrowJsonException_SerializationConverterWrite(this);
		}
	}

	internal sealed override void WriteAsPropertyNameCoreAsObject(Utf8JsonWriter P_0, object P_1, JsonSerializerOptions P_2, bool P_3)
	{
		WriteAsPropertyNameCore(P_0, (T)P_1, P_2, P_3);
	}

	internal virtual T ReadNumberWithCustomHandling(ref Utf8JsonReader P_0, JsonNumberHandling P_1, JsonSerializerOptions P_2)
	{
		throw new InvalidOperationException();
	}

	internal virtual void WriteNumberWithCustomHandling(Utf8JsonWriter P_0, T P_1, JsonNumberHandling P_2)
	{
		throw new InvalidOperationException();
	}
}
