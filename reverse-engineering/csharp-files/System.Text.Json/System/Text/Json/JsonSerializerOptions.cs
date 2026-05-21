using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json.Nodes;
using System.Text.Json.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading;

namespace System.Text.Json;

public sealed class JsonSerializerOptions
{
	internal sealed class CachingContext
	{
		private readonly ConcurrentDictionary<Type, JsonTypeInfo> _jsonTypeInfoCache = new ConcurrentDictionary<Type, JsonTypeInfo>();

		private readonly Func<Type, JsonTypeInfo> _jsonTypeInfoFactory;

		public JsonSerializerOptions Options { get; }

		public int HashCode { get; }

		public CachingContext(JsonSerializerOptions P_0, int P_1)
		{
			Options = P_0;
			HashCode = P_1;
			_jsonTypeInfoFactory = Options.GetTypeInfoNoCaching;
		}

		public JsonTypeInfo GetOrAddJsonTypeInfo(Type P_0)
		{
			return _jsonTypeInfoCache.GetOrAdd(P_0, _jsonTypeInfoFactory);
		}

		public bool TryGetJsonTypeInfo(Type P_0, [NotNullWhen(true)] out JsonTypeInfo P_1)
		{
			return _jsonTypeInfoCache.TryGetValue(P_0, out P_1);
		}
	}

	internal static class TrackedCachingContexts
	{
		private static readonly WeakReference<CachingContext>[] s_trackedContexts = new WeakReference<CachingContext>[64];

		private static readonly EqualityComparer s_optionsComparer = new EqualityComparer();

		public static CachingContext GetOrCreate(JsonSerializerOptions P_0)
		{
			int hashCode = s_optionsComparer.GetHashCode(P_0);
			if (TryGetContext(P_0, hashCode, out var num, out var result))
			{
				return result;
			}
			if (num < 0)
			{
				return new CachingContext(P_0, hashCode);
			}
			lock (s_trackedContexts)
			{
				if (TryGetContext(P_0, hashCode, out num, out result))
				{
					return result;
				}
				CachingContext cachingContext = new CachingContext(P_0, hashCode);
				if (num >= 0)
				{
					ref WeakReference<CachingContext> reference = ref s_trackedContexts[num];
					if (reference == null)
					{
						reference = new WeakReference<CachingContext>(cachingContext);
					}
					else
					{
						reference.SetTarget(cachingContext);
					}
				}
				return cachingContext;
			}
		}

		private static bool TryGetContext(JsonSerializerOptions P_0, int P_1, out int P_2, [NotNullWhen(true)] out CachingContext P_3)
		{
			WeakReference<CachingContext>[] array = s_trackedContexts;
			P_2 = -1;
			for (int i = 0; i < array.Length; i++)
			{
				WeakReference<CachingContext> weakReference = array[i];
				if (weakReference == null || !weakReference.TryGetTarget(out var cachingContext))
				{
					if (P_2 < 0)
					{
						P_2 = i;
					}
				}
				else if (P_1 == cachingContext.HashCode && s_optionsComparer.Equals(P_0, cachingContext.Options))
				{
					P_3 = cachingContext;
					return true;
				}
			}
			P_3 = null;
			return false;
		}
	}

	private sealed class EqualityComparer : IEqualityComparer<JsonSerializerOptions>
	{
		public bool Equals(JsonSerializerOptions P_0, JsonSerializerOptions P_1)
		{
			if (P_0._dictionaryKeyPolicy == P_1._dictionaryKeyPolicy && P_0._jsonPropertyNamingPolicy == P_1._jsonPropertyNamingPolicy && P_0._readCommentHandling == P_1._readCommentHandling && P_0._referenceHandler == P_1._referenceHandler && P_0._encoder == P_1._encoder && P_0._defaultIgnoreCondition == P_1._defaultIgnoreCondition && P_0._numberHandling == P_1._numberHandling && P_0._unknownTypeHandling == P_1._unknownTypeHandling && P_0._defaultBufferSize == P_1._defaultBufferSize && P_0._maxDepth == P_1._maxDepth && P_0._allowTrailingCommas == P_1._allowTrailingCommas && P_0._ignoreNullValues == P_1._ignoreNullValues && P_0._ignoreReadOnlyProperties == P_1._ignoreReadOnlyProperties && P_0._ignoreReadonlyFields == P_1._ignoreReadonlyFields && P_0._includeFields == P_1._includeFields && P_0._propertyNameCaseInsensitive == P_1._propertyNameCaseInsensitive && P_0._writeIndented == P_1._writeIndented && P_0._typeInfoResolver == P_1._typeInfoResolver)
			{
				return CompareLists<JsonConverter>(P_0._converters, P_1._converters);
			}
			return false;
			static bool CompareLists<TValue>(ConfigurationList<TValue> configurationList, ConfigurationList<TValue> configurationList2) where TValue : class
			{
				int count;
				if ((count = configurationList.Count) != configurationList2.Count)
				{
					return false;
				}
				for (int i = 0; i < count; i++)
				{
					if (configurationList[i] != configurationList2[i])
					{
						return false;
					}
				}
				return true;
			}
		}

		public int GetHashCode(JsonSerializerOptions P_0)
		{
			HashCode hashCode = default(HashCode);
			AddHashCode<JsonNamingPolicy>(ref hashCode, P_0._dictionaryKeyPolicy);
			AddHashCode<JsonNamingPolicy>(ref hashCode, P_0._jsonPropertyNamingPolicy);
			AddHashCode<JsonCommentHandling>(ref hashCode, P_0._readCommentHandling);
			AddHashCode<ReferenceHandler>(ref hashCode, P_0._referenceHandler);
			AddHashCode<JavaScriptEncoder>(ref hashCode, P_0._encoder);
			AddHashCode<JsonIgnoreCondition>(ref hashCode, P_0._defaultIgnoreCondition);
			AddHashCode<JsonNumberHandling>(ref hashCode, P_0._numberHandling);
			AddHashCode<JsonUnknownTypeHandling>(ref hashCode, P_0._unknownTypeHandling);
			AddHashCode<int>(ref hashCode, P_0._defaultBufferSize);
			AddHashCode<int>(ref hashCode, P_0._maxDepth);
			AddHashCode<bool>(ref hashCode, P_0._allowTrailingCommas);
			AddHashCode<bool>(ref hashCode, P_0._ignoreNullValues);
			AddHashCode<bool>(ref hashCode, P_0._ignoreReadOnlyProperties);
			AddHashCode<bool>(ref hashCode, P_0._ignoreReadonlyFields);
			AddHashCode<bool>(ref hashCode, P_0._includeFields);
			AddHashCode<bool>(ref hashCode, P_0._propertyNameCaseInsensitive);
			AddHashCode<bool>(ref hashCode, P_0._writeIndented);
			AddHashCode<IJsonTypeInfoResolver>(ref hashCode, P_0._typeInfoResolver);
			AddListHashCode<JsonConverter>(ref hashCode, P_0._converters);
			return hashCode.ToHashCode();
			static void AddHashCode<TValue>(ref HashCode reference, TValue val)
			{
				if (typeof(TValue).IsValueType)
				{
					reference.Add(val);
				}
				else
				{
					reference.Add(RuntimeHelpers.GetHashCode(val));
				}
			}
			static void AddListHashCode<TValue>(ref HashCode reference, ConfigurationList<TValue> configurationList)
			{
				int count = configurationList.Count;
				for (int i = 0; i < count; i++)
				{
					AddHashCode<TValue>(ref reference, configurationList[i]);
				}
			}
		}
	}

	internal static class TrackedOptionsInstances
	{
		public static ConditionalWeakTable<JsonSerializerOptions, object> All { get; } = new ConditionalWeakTable<JsonSerializerOptions, object>();
	}

	private sealed class ConverterList : ConfigurationList<JsonConverter>
	{
		private readonly JsonSerializerOptions _options;

		protected override bool IsImmutable => _options.IsImmutable;

		public ConverterList(JsonSerializerOptions P_0, IList<JsonConverter> P_1 = null)
			: base(P_1)
		{
			_options = P_0;
		}

		protected override void VerifyMutable()
		{
			_options.VerifyMutable();
		}
	}

	private CachingContext _cachingContext;

	private volatile JsonTypeInfo _lastTypeInfo;

	private JsonTypeInfo _objectTypeInfo;

	private static JsonSerializerOptions s_defaultOptions;

	private IJsonTypeInfoResolver _typeInfoResolver;

	private MemberAccessor _memberAccessorStrategy;

	private JsonNamingPolicy _dictionaryKeyPolicy;

	private JsonNamingPolicy _jsonPropertyNamingPolicy;

	private JsonCommentHandling _readCommentHandling;

	private ReferenceHandler _referenceHandler;

	private JavaScriptEncoder _encoder;

	private ConfigurationList<JsonConverter> _converters;

	private JsonIgnoreCondition _defaultIgnoreCondition;

	private JsonNumberHandling _numberHandling;

	private JsonUnknownTypeHandling _unknownTypeHandling;

	private int _defaultBufferSize = 16384;

	private int _maxDepth;

	private bool _allowTrailingCommas;

	private bool _ignoreNullValues;

	private bool _ignoreReadOnlyProperties;

	private bool _ignoreReadonlyFields;

	private bool _includeFields;

	private bool _propertyNameCaseInsensitive;

	private bool _writeIndented;

	private volatile bool _isImmutable;

	[CompilerGenerated]
	private int _003CEffectiveMaxDepth_003Ek__BackingField;

	internal ReferenceHandlingStrategy ReferenceHandlingStrategy;

	private volatile bool _isInitializedForReflectionSerializer;

	private IJsonTypeInfoResolver _effectiveJsonTypeInfoResolver;

	internal JsonTypeInfo ObjectTypeInfo => _objectTypeInfo ?? (_objectTypeInfo = GetTypeInfoInternal(JsonTypeInfo.ObjectType));

	public IList<JsonConverter> Converters => _converters;

	public static JsonSerializerOptions Default
	{
		[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
		[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
		get
		{
			JsonSerializerOptions orCreateDefaultOptionsInstance = s_defaultOptions;
			if (orCreateDefaultOptionsInstance == null)
			{
				orCreateDefaultOptionsInstance = GetOrCreateDefaultOptionsInstance();
			}
			return orCreateDefaultOptionsInstance;
		}
	}

	public IJsonTypeInfoResolver? TypeInfoResolver
	{
		get
		{
			return _typeInfoResolver;
		}
		set
		{
			VerifyMutable();
			_typeInfoResolver = typeInfoResolver;
		}
	}

	public bool AllowTrailingCommas => _allowTrailingCommas;

	public int DefaultBufferSize => _defaultBufferSize;

	public JavaScriptEncoder? Encoder => _encoder;

	public JsonNamingPolicy? DictionaryKeyPolicy => _dictionaryKeyPolicy;

	[Obsolete("JsonSerializerOptions.IgnoreNullValues is obsolete. To ignore null values when serializing, set DefaultIgnoreCondition to JsonIgnoreCondition.WhenWritingNull.", DiagnosticId = "SYSLIB0020", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IgnoreNullValues => _ignoreNullValues;

	public JsonIgnoreCondition DefaultIgnoreCondition => _defaultIgnoreCondition;

	public JsonNumberHandling NumberHandling => _numberHandling;

	public bool IgnoreReadOnlyProperties => _ignoreReadOnlyProperties;

	public bool IgnoreReadOnlyFields => _ignoreReadonlyFields;

	public bool IncludeFields => _includeFields;

	public int MaxDepth
	{
		get
		{
			return _maxDepth;
		}
		set
		{
			VerifyMutable();
			if (num < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException_MaxDepthMustBePositive("value");
			}
			_maxDepth = num;
			EffectiveMaxDepth = ((num == 0) ? 64 : num);
		}
	}

	internal int EffectiveMaxDepth
	{
		[CompilerGenerated]
		get
		{
			return _003CEffectiveMaxDepth_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CEffectiveMaxDepth_003Ek__BackingField = num;
		}
	} = 64;

	public JsonNamingPolicy? PropertyNamingPolicy
	{
		get
		{
			return _jsonPropertyNamingPolicy;
		}
		set
		{
			VerifyMutable();
			_jsonPropertyNamingPolicy = jsonPropertyNamingPolicy;
		}
	}

	public bool PropertyNameCaseInsensitive
	{
		get
		{
			return _propertyNameCaseInsensitive;
		}
		set
		{
			VerifyMutable();
			_propertyNameCaseInsensitive = propertyNameCaseInsensitive;
		}
	}

	public JsonCommentHandling ReadCommentHandling => _readCommentHandling;

	public JsonUnknownTypeHandling UnknownTypeHandling => _unknownTypeHandling;

	public bool WriteIndented
	{
		get
		{
			return _writeIndented;
		}
		set
		{
			VerifyMutable();
			_writeIndented = writeIndented;
		}
	}

	public ReferenceHandler? ReferenceHandler => _referenceHandler;

	internal JsonSerializerContext? SerializerContext
	{
		get
		{
			_ = _typeInfoResolver;
			return null;
		}
	}

	[UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "Dynamic path is guarded by the runtime feature switch.")]
	internal MemberAccessor MemberAccessorStrategy => _memberAccessorStrategy ?? (_memberAccessorStrategy = (RuntimeFeature.IsDynamicCodeSupported ? ((MemberAccessor)new ReflectionEmitCachingMemberAccessor()) : ((MemberAccessor)new ReflectionMemberAccessor())));

	internal bool IsImmutable
	{
		get
		{
			return _isImmutable;
		}
		set
		{
			_isImmutable = true;
		}
	}

	internal bool IsInitializedForReflectionSerializer => _isInitializedForReflectionSerializer;

	internal JsonTypeInfo GetTypeInfoInternal(Type P_0, bool P_1 = true, bool P_2 = false)
	{
		JsonTypeInfo jsonTypeInfo = null;
		if (IsImmutable)
		{
			jsonTypeInfo = GetCachingContext()?.GetOrAddJsonTypeInfo(P_0);
			if (P_1)
			{
				jsonTypeInfo?.EnsureConfigured();
			}
		}
		else if (P_2)
		{
			jsonTypeInfo = GetTypeInfoNoCaching(P_0);
		}
		if (jsonTypeInfo == null)
		{
			ThrowHelper.ThrowNotSupportedException_NoMetadataForType(P_0, TypeInfoResolver);
		}
		return jsonTypeInfo;
	}

	internal bool TryGetTypeInfoCached(Type P_0, [NotNullWhen(true)] out JsonTypeInfo P_1)
	{
		if (_cachingContext == null)
		{
			P_1 = null;
			return false;
		}
		return _cachingContext.TryGetJsonTypeInfo(P_0, out P_1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal JsonTypeInfo GetTypeInfoForRootType(Type P_0)
	{
		JsonTypeInfo jsonTypeInfo = _lastTypeInfo;
		if (jsonTypeInfo?.Type != P_0)
		{
			jsonTypeInfo = (_lastTypeInfo = GetTypeInfoInternal(P_0));
		}
		return jsonTypeInfo;
	}

	private CachingContext GetCachingContext()
	{
		return _cachingContext ?? (_cachingContext = TrackedCachingContexts.GetOrCreate(this));
	}

	internal JsonConverter GetConverterInternal(Type P_0)
	{
		JsonTypeInfo typeInfoInternal = GetTypeInfoInternal(P_0, false, true);
		return typeInfoInternal.Converter;
	}

	internal JsonConverter GetConverterFromList(Type P_0)
	{
		foreach (JsonConverter converter in _converters)
		{
			if (converter.CanConvert(P_0))
			{
				return converter;
			}
		}
		return null;
	}

	[return: NotNullIfNotNull("converter")]
	internal JsonConverter ExpandConverterFactory(JsonConverter P_0, Type P_1)
	{
		if (P_0 is JsonConverterFactory jsonConverterFactory)
		{
			P_0 = jsonConverterFactory.GetConverterInternal(P_1, this);
		}
		return P_0;
	}

	internal static void CheckConverterNullabilityIsSameAsPropertyType(JsonConverter P_0, Type P_1)
	{
		if (P_1.IsValueType && P_0.IsValueType && (P_1.IsNullableOfT() ^ P_0.TypeToConvert.IsNullableOfT()))
		{
			ThrowHelper.ThrowInvalidOperationException_ConverterCanConvertMultipleTypes(P_1, P_0);
		}
	}

	public JsonSerializerOptions()
	{
		_converters = new ConverterList(this);
		TrackOptionsInstance(this);
	}

	private static void TrackOptionsInstance(JsonSerializerOptions P_0)
	{
		TrackedOptionsInstances.All.Add(P_0, null);
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	internal void InitializeForReflectionSerializer()
	{
		DefaultJsonTypeInfoResolver defaultJsonTypeInfoResolver = DefaultJsonTypeInfoResolver.RootDefaultInstance();
		IJsonTypeInfoResolver typeInfoResolver = _typeInfoResolver;
		if (typeInfoResolver != null)
		{
			JsonSerializerContext jsonSerializerContext = null;
			if (jsonSerializerContext != null && AppContextSwitchHelper.IsSourceGenReflectionFallbackEnabled)
			{
				_effectiveJsonTypeInfoResolver = JsonTypeInfoResolver.Combine(jsonSerializerContext, defaultJsonTypeInfoResolver);
			}
		}
		else
		{
			_typeInfoResolver = defaultJsonTypeInfoResolver;
		}
		IsImmutable = true;
		_isInitializedForReflectionSerializer = true;
	}

	internal void InitializeForMetadataGeneration()
	{
		if (_typeInfoResolver == null)
		{
			ThrowHelper.ThrowInvalidOperationException_JsonTypeInfoUsedButTypeInfoResolverNotSet();
		}
		IsImmutable = true;
	}

	private JsonTypeInfo GetTypeInfoNoCaching(Type P_0)
	{
		JsonTypeInfo jsonTypeInfo = (_effectiveJsonTypeInfoResolver ?? _typeInfoResolver)?.GetTypeInfo(P_0, this);
		if (jsonTypeInfo != null)
		{
			if (jsonTypeInfo.Type != P_0)
			{
				ThrowHelper.ThrowInvalidOperationException_ResolverTypeNotCompatible(P_0, jsonTypeInfo.Type);
			}
			if (jsonTypeInfo.Options != this)
			{
				ThrowHelper.ThrowInvalidOperationException_ResolverTypeInfoOptionsNotCompatible();
			}
		}
		return jsonTypeInfo;
	}

	internal JsonDocumentOptions GetDocumentOptions()
	{
		return new JsonDocumentOptions
		{
			AllowTrailingCommas = AllowTrailingCommas,
			CommentHandling = ReadCommentHandling,
			MaxDepth = MaxDepth
		};
	}

	internal JsonNodeOptions GetNodeOptions()
	{
		return new JsonNodeOptions
		{
			PropertyNameCaseInsensitive = PropertyNameCaseInsensitive
		};
	}

	internal JsonReaderOptions GetReaderOptions()
	{
		return new JsonReaderOptions
		{
			AllowTrailingCommas = AllowTrailingCommas,
			CommentHandling = ReadCommentHandling,
			MaxDepth = EffectiveMaxDepth
		};
	}

	internal JsonWriterOptions GetWriterOptions()
	{
		return new JsonWriterOptions
		{
			Encoder = Encoder,
			Indented = WriteIndented,
			MaxDepth = EffectiveMaxDepth,
			SkipValidation = true
		};
	}

	internal void VerifyMutable()
	{
		if (_isImmutable)
		{
			_ = _typeInfoResolver;
			ThrowHelper.ThrowInvalidOperationException_SerializerOptionsImmutable(null);
		}
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	private static JsonSerializerOptions GetOrCreateDefaultOptionsInstance()
	{
		JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
		{
			TypeInfoResolver = DefaultJsonTypeInfoResolver.RootDefaultInstance(),
			IsImmutable = true
		};
		return Interlocked.CompareExchange(ref s_defaultOptions, jsonSerializerOptions, null) ?? jsonSerializerOptions;
	}
}
