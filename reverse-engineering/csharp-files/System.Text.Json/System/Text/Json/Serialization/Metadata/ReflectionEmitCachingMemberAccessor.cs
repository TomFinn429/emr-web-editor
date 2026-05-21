using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading;

namespace System.Text.Json.Serialization.Metadata;

[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
internal sealed class ReflectionEmitCachingMemberAccessor : MemberAccessor
{
	private sealed class Cache<TKey>
	{
		private sealed class CacheEntry
		{
			public readonly object Value;

			public long LastUsedTicks;

			public CacheEntry(object P_0)
			{
				Value = P_0;
			}
		}

		private int _evictLock;

		private long _lastEvictedTicks;

		private readonly long _evictionIntervalTicks;

		private readonly long _slidingExpirationTicks;

		private readonly ConcurrentDictionary<TKey, CacheEntry> _cache = new ConcurrentDictionary<TKey, CacheEntry>();

		public Cache(TimeSpan P_0, TimeSpan P_1)
		{
			_slidingExpirationTicks = P_0.Ticks;
			_evictionIntervalTicks = P_1.Ticks;
			_lastEvictedTicks = DateTime.UtcNow.Ticks;
		}

		public TValue GetOrAdd<TValue>(TKey P_0, Func<TKey, TValue> P_1) where TValue : class
		{
			CacheEntry orAdd = _cache.GetOrAdd(P_0, (TKey val, Func<TKey, TValue> func) => new CacheEntry(func(val)), P_1);
			long ticks = DateTime.UtcNow.Ticks;
			Volatile.Write(ref orAdd.LastUsedTicks, ticks);
			if (ticks - Volatile.Read(ref _lastEvictedTicks) >= _evictionIntervalTicks && Interlocked.CompareExchange(ref _evictLock, 1, 0) == 0)
			{
				if (ticks - _lastEvictedTicks >= _evictionIntervalTicks)
				{
					EvictStaleCacheEntries(ticks);
					Volatile.Write(ref _lastEvictedTicks, ticks);
				}
				Volatile.Write(ref _evictLock, 0);
			}
			return (TValue)orAdd.Value;
		}

		private void EvictStaleCacheEntries(long P_0)
		{
			foreach (KeyValuePair<TKey, CacheEntry> item in _cache)
			{
				if (P_0 - Volatile.Read(ref item.Value.LastUsedTicks) >= _slidingExpirationTicks)
				{
					_cache.TryRemove(item.Key, out var _);
				}
			}
		}
	}

	private static readonly ReflectionEmitMemberAccessor s_sourceAccessor = new ReflectionEmitMemberAccessor();

	private static readonly Cache<(string id, Type declaringType, MemberInfo member)> s_cache = new Cache<(string, Type, MemberInfo)>(TimeSpan.FromMilliseconds(1000.0), TimeSpan.FromMilliseconds(200.0));

	public override Action<TCollection, object> CreateAddMethodDelegate<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TCollection>()
	{
		return s_cache.GetOrAdd(("CreateAddMethodDelegate", typeof(TCollection), null), [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2091:UnrecognizedReflectionPattern", Justification = "Parent method annotation does not flow to lambda method, cf. https://github.com/dotnet/roslyn/issues/46646")] ((string id, Type declaringType, MemberInfo member) P_0) => s_sourceAccessor.CreateAddMethodDelegate<TCollection>());
	}

	public override Func<object> CreateConstructor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type P_0)
	{
		return s_cache.GetOrAdd(("CreateConstructor", P_0, null), [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2077:UnrecognizedReflectionPattern", Justification = "Cannot apply DynamicallyAccessedMembersAttribute to tuple properties.")] ((string id, Type declaringType, MemberInfo member) tuple) => s_sourceAccessor.CreateConstructor(tuple.declaringType));
	}

	public override Func<object, TProperty> CreateFieldGetter<TProperty>(FieldInfo P_0)
	{
		return s_cache.GetOrAdd(("CreateFieldGetter", typeof(TProperty), P_0), ((string id, Type declaringType, MemberInfo member) tuple) => s_sourceAccessor.CreateFieldGetter<TProperty>((FieldInfo)tuple.member));
	}

	public override Action<object, TProperty> CreateFieldSetter<TProperty>(FieldInfo P_0)
	{
		return s_cache.GetOrAdd(("CreateFieldSetter", typeof(TProperty), P_0), ((string id, Type declaringType, MemberInfo member) tuple) => s_sourceAccessor.CreateFieldSetter<TProperty>((FieldInfo)tuple.member));
	}

	[RequiresUnreferencedCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	public override Func<IEnumerable<KeyValuePair<TKey, TValue>>, TCollection> CreateImmutableDictionaryCreateRangeDelegate<TCollection, TKey, TValue>()
	{
		return s_cache.GetOrAdd(("CreateImmutableDictionaryCreateRangeDelegate", typeof((TCollection, TKey, TValue)), null), [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Parent method annotation does not flow to lambda method, cf. https://github.com/dotnet/roslyn/issues/46646")] ((string id, Type declaringType, MemberInfo member) P_0) => s_sourceAccessor.CreateImmutableDictionaryCreateRangeDelegate<TCollection, TKey, TValue>());
	}

	[RequiresUnreferencedCode("System.Collections.Immutable converters use Reflection to find and create Immutable Collection types, which requires unreferenced code.")]
	public override Func<IEnumerable<TElement>, TCollection> CreateImmutableEnumerableCreateRangeDelegate<TCollection, TElement>()
	{
		return s_cache.GetOrAdd(("CreateImmutableEnumerableCreateRangeDelegate", typeof((TCollection, TElement)), null), [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Parent method annotation does not flow to lambda method, cf. https://github.com/dotnet/roslyn/issues/46646")] ((string id, Type declaringType, MemberInfo member) P_0) => s_sourceAccessor.CreateImmutableEnumerableCreateRangeDelegate<TCollection, TElement>());
	}

	public override Func<object[], T> CreateParameterizedConstructor<T>(ConstructorInfo P_0)
	{
		return s_cache.GetOrAdd(("CreateParameterizedConstructor", typeof(T), P_0), ((string id, Type declaringType, MemberInfo member) tuple) => s_sourceAccessor.CreateParameterizedConstructor<T>((ConstructorInfo)tuple.member));
	}

	public override JsonTypeInfo.ParameterizedConstructorDelegate<T, TArg0, TArg1, TArg2, TArg3> CreateParameterizedConstructor<T, TArg0, TArg1, TArg2, TArg3>(ConstructorInfo P_0)
	{
		return s_cache.GetOrAdd(("CreateParameterizedConstructor", typeof(T), P_0), ((string id, Type declaringType, MemberInfo member) tuple) => s_sourceAccessor.CreateParameterizedConstructor<T, TArg0, TArg1, TArg2, TArg3>((ConstructorInfo)tuple.member));
	}

	public override Func<object, TProperty> CreatePropertyGetter<TProperty>(PropertyInfo P_0)
	{
		return s_cache.GetOrAdd(("CreatePropertyGetter", typeof(TProperty), P_0), ((string id, Type declaringType, MemberInfo member) tuple) => s_sourceAccessor.CreatePropertyGetter<TProperty>((PropertyInfo)tuple.member));
	}

	public override Action<object, TProperty> CreatePropertySetter<TProperty>(PropertyInfo P_0)
	{
		return s_cache.GetOrAdd(("CreatePropertySetter", typeof(TProperty), P_0), ((string id, Type declaringType, MemberInfo member) tuple) => s_sourceAccessor.CreatePropertySetter<TProperty>((PropertyInfo)tuple.member));
	}
}
