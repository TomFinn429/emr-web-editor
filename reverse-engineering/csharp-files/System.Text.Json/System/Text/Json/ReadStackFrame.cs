using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json;

[StructLayout((LayoutKind)3)]
internal struct ReadStackFrame
{
	public JsonPropertyInfo JsonPropertyInfo;

	public StackFramePropertyState PropertyState;

	public bool UseExtensionProperty;

	public byte[] JsonPropertyName;

	public string JsonPropertyNameAsString;

	public object DictionaryKey;

	public object ReturnValue;

	public JsonTypeInfo JsonTypeInfo;

	public StackFrameObjectState ObjectState;

	public bool CanContainMetadata;

	public MetadataPropertyName LatestMetadataPropertyName;

	public MetadataPropertyName MetadataPropertyNames;

	public PolymorphicSerializationState PolymorphicSerializationState;

	public JsonTypeInfo PolymorphicJsonTypeInfo;

	public int PropertyIndex;

	public List<PropertyRef> PropertyRefCache;

	public int CtorArgumentStateIndex;

	public ArgumentState CtorArgumentState;

	public JsonNumberHandling? NumberHandling;

	public BitArray RequiredPropertiesSet;

	public JsonTypeInfo BaseJsonTypeInfo
	{
		get
		{
			if (PolymorphicSerializationState != PolymorphicSerializationState.PolymorphicReEntryStarted)
			{
				return JsonTypeInfo;
			}
			return PolymorphicJsonTypeInfo;
		}
	}

	public void EndConstructorParameter()
	{
		CtorArgumentState.JsonParameterInfo = null;
		JsonPropertyName = null;
		PropertyState = StackFramePropertyState.None;
	}

	public void EndProperty()
	{
		JsonPropertyInfo = null;
		JsonPropertyName = null;
		JsonPropertyNameAsString = null;
		PropertyState = StackFramePropertyState.None;
	}

	public void EndElement()
	{
		JsonPropertyNameAsString = null;
		PropertyState = StackFramePropertyState.None;
	}

	public bool IsProcessingDictionary()
	{
		return (JsonTypeInfo.PropertyInfoForTypeInfo.ConverterStrategy & ConverterStrategy.Dictionary) != 0;
	}

	public bool IsProcessingEnumerable()
	{
		return (JsonTypeInfo.PropertyInfoForTypeInfo.ConverterStrategy & ConverterStrategy.Enumerable) != 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void MarkRequiredPropertyAsRead(JsonPropertyInfo P_0)
	{
		if (P_0.IsRequired)
		{
			RequiredPropertiesSet[P_0.RequiredPropertyIndex] = true;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal void InitializeRequiredPropertiesValidationState(JsonTypeInfo P_0)
	{
		if (P_0.NumberOfRequiredProperties > 0)
		{
			RequiredPropertiesSet = new BitArray(P_0.NumberOfRequiredProperties);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal void ValidateAllRequiredPropertiesAreRead(JsonTypeInfo P_0)
	{
		if (P_0.NumberOfRequiredProperties > 0 && !RequiredPropertiesSet.AllBitsEqual(true))
		{
			ThrowHelper.ThrowJsonException_JsonRequiredPropertyMissing(P_0, RequiredPropertiesSet);
		}
	}
}
