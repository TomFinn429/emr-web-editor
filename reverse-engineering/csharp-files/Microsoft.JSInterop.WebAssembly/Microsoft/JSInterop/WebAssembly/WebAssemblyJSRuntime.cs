using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.JSInterop.Infrastructure;
using WebAssembly.JSInterop;

namespace Microsoft.JSInterop.WebAssembly;

public abstract class WebAssemblyJSRuntime : JSInProcessRuntime, IJSUnmarshalledRuntime
{
	protected WebAssemblyJSRuntime()
	{
		base.JsonSerializerOptions.Converters.Insert(0, new WebAssemblyJSObjectReferenceJsonConverter(this));
	}

	protected override string InvokeJS(string P_0, string? P_1, JSCallResultType P_2, long P_3)
	{
		JSCallInfo jSCallInfo = new JSCallInfo
		{
			FunctionIdentifier = P_0,
			TargetInstanceId = P_3,
			ResultType = P_2,
			MarshalledCallArgsJson = (P_1 ?? "[]"),
			MarshalledCallAsyncHandle = 0L
		};
		string text;
		string result = InternalCalls.InvokeJS<object, object, object, string>(out text, ref jSCallInfo, null, null, null);
		if (text == null)
		{
			return result;
		}
		throw new JSException(text);
	}

	protected override void BeginInvokeJS(long P_0, string P_1, string? P_2, JSCallResultType P_3, long P_4)
	{
		JSCallInfo jSCallInfo = new JSCallInfo
		{
			FunctionIdentifier = P_1,
			TargetInstanceId = P_4,
			ResultType = P_3,
			MarshalledCallArgsJson = (P_2 ?? "[]"),
			MarshalledCallAsyncHandle = P_0
		};
		InternalCalls.InvokeJS<object, object, object, string>(out string _, ref jSCallInfo, null, null, null);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "TODO: This should be in the xml suppressions file, but can't be because https://github.com/mono/linker/issues/2006")]
	protected override void EndInvokeDotNet(DotNetInvocationInfo P_0, in DotNetInvocationResult P_1)
	{
		string text = (P_1.Success ? P_1.ResultJson : P_1.Exception.ToString());
		InvokeUnmarshalled<string, bool, string, object>("Blazor._internal.endInvokeDotNetFromJS", P_0.CallId, P_1.Success, text);
	}

	protected override void SendByteArray(int P_0, byte[] P_1)
	{
		InvokeUnmarshalled<int, byte[], object>("Blazor._internal.receiveByteArray", P_0, P_1);
	}

	[Obsolete("This method is obsolete. Use JSImportAttribute instead.")]
	internal TResult InvokeUnmarshalled<T0, T1, T2, TResult>(string P_0, T0 P_1, T1 P_2, T2 P_3, long P_4)
	{
		JSCallResultType jSCallResultType = Microsoft.JSInterop.JSCallResultTypeHelper.FromGeneric<TResult>();
		JSCallInfo jSCallInfo = new JSCallInfo
		{
			FunctionIdentifier = P_0,
			TargetInstanceId = P_4,
			ResultType = jSCallResultType
		};
		string text2;
		switch (jSCallResultType)
		{
		case JSCallResultType.Default:
		case JSCallResultType.JSVoidResult:
		{
			TResult result = InternalCalls.InvokeJS<T0, T1, T2, TResult>(out text2, ref jSCallInfo, P_1, P_2, P_3);
			if (text2 == null)
			{
				return result;
			}
			throw new JSException(text2);
		}
		case JSCallResultType.JSObjectReference:
		{
			int num = InternalCalls.InvokeJS<T0, T1, T2, int>(out text2, ref jSCallInfo, P_1, P_2, P_3);
			if (text2 == null)
			{
				return (TResult)(object)new WebAssemblyJSObjectReference(this, num);
			}
			throw new JSException(text2);
		}
		case JSCallResultType.JSStreamReference:
		{
			string text = InternalCalls.InvokeJS<T0, T1, T2, string>(out text2, ref jSCallInfo, P_1, P_2, P_3);
			if (text2 == null)
			{
				return (TResult)DeserializeJSStreamReference(text);
			}
			throw new JSException(text2);
		}
		default:
			throw new InvalidOperationException($"Invalid result type '{jSCallResultType}'.");
		}
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "IJSStreamReference is referenced in Microsoft.JSInterop.Infrastructure.JSStreamReferenceJsonConverter")]
	private IJSStreamReference DeserializeJSStreamReference(string P_0)
	{
		return JsonSerializer.Deserialize<IJSStreamReference>(P_0, base.JsonSerializerOptions) ?? throw new NullReferenceException("Unable to parse the serializedStreamReference.");
	}

	[Obsolete("This method is obsolete. Use JSImportAttribute instead.")]
	public TResult InvokeUnmarshalled<TResult>(string P_0)
	{
		return InvokeUnmarshalled<object, object, object, TResult>(P_0, null, null, null, 0L);
	}

	[Obsolete("This method is obsolete. Use JSImportAttribute instead.")]
	public TResult InvokeUnmarshalled<T0, T1, TResult>(string P_0, T0 P_1, T1 P_2)
	{
		return InvokeUnmarshalled<T0, T1, object, TResult>(P_0, P_1, P_2, null, 0L);
	}

	[Obsolete("This method is obsolete. Use JSImportAttribute instead.")]
	public TResult InvokeUnmarshalled<T0, T1, T2, TResult>(string P_0, T0 P_1, T1 P_2, T2 P_3)
	{
		return InvokeUnmarshalled<T0, T1, T2, TResult>(P_0, P_1, P_2, P_3, 0L);
	}
}
