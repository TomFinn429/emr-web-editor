using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.Text.Json.Serialization.Metadata;

public class JsonPolymorphismOptions
{
	private sealed class DerivedTypeList : ConfigurationList<JsonDerivedType>
	{
		private readonly JsonPolymorphismOptions _parent;

		protected override bool IsImmutable => _parent.DeclaringTypeInfo?.IsConfigured ?? false;

		public DerivedTypeList(JsonPolymorphismOptions P_0)
			: base((IList<JsonDerivedType>)null)
		{
			_parent = P_0;
		}

		protected override void VerifyMutable()
		{
			_parent.DeclaringTypeInfo?.VerifyMutable();
		}
	}

	private DerivedTypeList _derivedTypes;

	private bool _ignoreUnrecognizedTypeDiscriminators;

	private JsonUnknownDerivedTypeHandling _unknownDerivedTypeHandling;

	private string _typeDiscriminatorPropertyName;

	[CompilerGenerated]
	private JsonTypeInfo _003CDeclaringTypeInfo_003Ek__BackingField;

	public IList<JsonDerivedType> DerivedTypes => _derivedTypes ?? (_derivedTypes = new DerivedTypeList(this));

	public bool IgnoreUnrecognizedTypeDiscriminators
	{
		get
		{
			return _ignoreUnrecognizedTypeDiscriminators;
		}
		set
		{
			VerifyMutable();
			_ignoreUnrecognizedTypeDiscriminators = ignoreUnrecognizedTypeDiscriminators;
		}
	}

	public JsonUnknownDerivedTypeHandling UnknownDerivedTypeHandling
	{
		get
		{
			return _unknownDerivedTypeHandling;
		}
		set
		{
			VerifyMutable();
			_unknownDerivedTypeHandling = unknownDerivedTypeHandling;
		}
	}

	public string TypeDiscriminatorPropertyName
	{
		get
		{
			return _typeDiscriminatorPropertyName ?? "$type";
		}
		[param: AllowNull]
		set
		{
			VerifyMutable();
			_typeDiscriminatorPropertyName = typeDiscriminatorPropertyName;
		}
	}

	internal JsonTypeInfo? DeclaringTypeInfo
	{
		[CompilerGenerated]
		get
		{
			return _003CDeclaringTypeInfo_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CDeclaringTypeInfo_003Ek__BackingField = jsonTypeInfo;
		}
	}

	private void VerifyMutable()
	{
		DeclaringTypeInfo?.VerifyMutable();
	}

	internal static JsonPolymorphismOptions CreateFromAttributeDeclarations(Type P_0)
	{
		JsonPolymorphismOptions jsonPolymorphismOptions = null;
		JsonPolymorphicAttribute customAttribute = P_0.GetCustomAttribute<JsonPolymorphicAttribute>(false);
		if (customAttribute != null)
		{
			jsonPolymorphismOptions = new JsonPolymorphismOptions
			{
				IgnoreUnrecognizedTypeDiscriminators = customAttribute.IgnoreUnrecognizedTypeDiscriminators,
				UnknownDerivedTypeHandling = customAttribute.UnknownDerivedTypeHandling,
				TypeDiscriminatorPropertyName = customAttribute.TypeDiscriminatorPropertyName
			};
		}
		foreach (JsonDerivedTypeAttribute customAttribute2 in P_0.GetCustomAttributes<JsonDerivedTypeAttribute>(false))
		{
			(jsonPolymorphismOptions ?? (jsonPolymorphismOptions = new JsonPolymorphismOptions())).DerivedTypes.Add(new JsonDerivedType(customAttribute2.DerivedType, customAttribute2.TypeDiscriminator));
		}
		return jsonPolymorphismOptions;
	}
}
