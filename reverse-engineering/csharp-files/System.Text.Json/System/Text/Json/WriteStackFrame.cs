using System.Collections;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json;

[StructLayout((LayoutKind)3)]
internal struct WriteStackFrame
{
	public IEnumerator CollectionEnumerator;

	public IAsyncDisposable AsyncDisposable;

	public bool AsyncEnumeratorIsPendingCompletion;

	public JsonPropertyInfo JsonPropertyInfo;

	public bool IsWritingExtensionDataProperty;

	public JsonTypeInfo JsonTypeInfo;

	public int OriginalDepth;

	public bool ProcessedStartToken;

	public bool ProcessedEndToken;

	public StackFramePropertyState PropertyState;

	public int EnumeratorIndex;

	public string JsonPropertyNameAsString;

	public MetadataPropertyName MetadataPropertyName;

	public PolymorphicSerializationState PolymorphicSerializationState;

	private JsonPropertyInfo PolymorphicJsonTypeInfo;

	public JsonNumberHandling? NumberHandling;

	public bool IsPushedReferenceForCycleDetection;

	public void EndCollectionElement()
	{
		PolymorphicSerializationState = PolymorphicSerializationState.None;
	}

	public void EndDictionaryEntry()
	{
		PropertyState = StackFramePropertyState.None;
		PolymorphicSerializationState = PolymorphicSerializationState.None;
	}

	public void EndProperty()
	{
		JsonPropertyInfo = null;
		JsonPropertyNameAsString = null;
		PropertyState = StackFramePropertyState.None;
		PolymorphicSerializationState = PolymorphicSerializationState.None;
	}

	public JsonTypeInfo GetNestedJsonTypeInfo()
	{
		JsonPropertyInfo jsonPropertyInfo = ((PolymorphicSerializationState == PolymorphicSerializationState.PolymorphicReEntryStarted) ? PolymorphicJsonTypeInfo : JsonPropertyInfo);
		return jsonPropertyInfo.JsonTypeInfo;
	}

	public JsonConverter InitializePolymorphicReEntry(Type P_0, JsonSerializerOptions P_1)
	{
		if (PolymorphicJsonTypeInfo?.PropertyType != P_0)
		{
			JsonTypeInfo typeInfoInternal = P_1.GetTypeInfoInternal(P_0);
			PolymorphicJsonTypeInfo = typeInfoInternal.PropertyInfoForTypeInfo;
		}
		PolymorphicSerializationState = PolymorphicSerializationState.PolymorphicReEntryStarted;
		return PolymorphicJsonTypeInfo.EffectiveConverter;
	}

	public JsonConverter InitializePolymorphicReEntry(JsonTypeInfo P_0)
	{
		PolymorphicJsonTypeInfo = P_0.PropertyInfoForTypeInfo;
		PolymorphicSerializationState = PolymorphicSerializationState.PolymorphicReEntryStarted;
		return PolymorphicJsonTypeInfo.EffectiveConverter;
	}

	public JsonConverter ResumePolymorphicReEntry()
	{
		PolymorphicSerializationState = PolymorphicSerializationState.PolymorphicReEntryStarted;
		return PolymorphicJsonTypeInfo.EffectiveConverter;
	}

	public void ExitPolymorphicConverter(bool P_0)
	{
		PolymorphicSerializationState = ((!P_0) ? PolymorphicSerializationState.PolymorphicReEntrySuspended : PolymorphicSerializationState.None);
	}
}
