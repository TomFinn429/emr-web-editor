using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop.Infrastructure;

namespace Microsoft.JSInterop;

public abstract class JSRuntime : IJSRuntime, IDisposable
{
	private long _nextObjectReferenceId;

	private long _nextPendingTaskId = 1L;

	private readonly ConcurrentDictionary<long, object> _pendingTasks = new ConcurrentDictionary<long, object>();

	private readonly ConcurrentDictionary<long, IDotNetObjectReference> _trackedRefsById = new ConcurrentDictionary<long, IDotNetObjectReference>();

	private readonly ConcurrentDictionary<long, CancellationTokenRegistration> _cancellationRegistrations = new ConcurrentDictionary<long, CancellationTokenRegistration>();

	internal readonly ArrayBuilder<byte[]> ByteArraysToBeRevived = new ArrayBuilder<byte[]>();

	protected internal JsonSerializerOptions JsonSerializerOptions { get; }

	protected TimeSpan? DefaultAsyncTimeout { get; }

	protected JSRuntime()
	{
		JsonSerializerOptions = new JsonSerializerOptions
		{
			MaxDepth = 32,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			PropertyNameCaseInsensitive = true,
			Converters = 
			{
				(JsonConverter)new DotNetObjectReferenceJsonConverterFactory(this),
				(JsonConverter)new JSObjectReferenceJsonConverter(this),
				(JsonConverter)new JSStreamReferenceJsonConverter(this),
				(JsonConverter)new DotNetStreamReferenceJsonConverter(this),
				(JsonConverter)new ByteArrayJsonConverter(this)
			}
		};
	}

	public ValueTask<TValue> InvokeAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)] TValue>(string P_0, object?[]? P_1)
	{
		return InvokeAsync<TValue>(0L, P_0, P_1);
	}

	internal async ValueTask<TValue> InvokeAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)] TValue>(long P_0, string P_1, object?[]? P_2)
	{
		if (DefaultAsyncTimeout.HasValue)
		{
			using (CancellationTokenSource cts = new CancellationTokenSource(DefaultAsyncTimeout.Value))
			{
				return await InvokeAsync<TValue>(P_0, P_1, cts.Token, P_2);
			}
		}
		return await InvokeAsync<TValue>(P_0, P_1, CancellationToken.None, P_2);
	}

	[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "We expect application code is configured to ensure JS interop arguments are linker friendly.")]
	internal ValueTask<TValue> InvokeAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicProperties)] TValue>(long P_0, string P_1, CancellationToken P_2, object?[]? P_3)
	{
		long taskId = Interlocked.Increment(ref _nextPendingTaskId);
		TaskCompletionSource<TValue> tcs = new TaskCompletionSource<TValue>();
		if (P_2.CanBeCanceled)
		{
			_cancellationRegistrations[taskId] = P_2.Register(delegate
			{
				tcs.TrySetCanceled(P_2);
				CleanupTasksAndRegistrations(taskId);
			});
		}
		_pendingTasks[taskId] = tcs;
		try
		{
			if (P_2.IsCancellationRequested)
			{
				tcs.TrySetCanceled(P_2);
				CleanupTasksAndRegistrations(taskId);
				return new ValueTask<TValue>(tcs.Task);
			}
			string text = ((P_3 != null && P_3.Length != 0) ? JsonSerializer.Serialize(P_3, JsonSerializerOptions) : null);
			JSCallResultType jSCallResultType = JSCallResultTypeHelper.FromGeneric<TValue>();
			BeginInvokeJS(taskId, P_1, text, jSCallResultType, P_0);
			return new ValueTask<TValue>(tcs.Task);
		}
		catch
		{
			CleanupTasksAndRegistrations(taskId);
			throw;
		}
	}

	private void CleanupTasksAndRegistrations(long P_0)
	{
		_pendingTasks.TryRemove(P_0, out var _);
		if (_cancellationRegistrations.TryRemove(P_0, out var cancellationTokenRegistration))
		{
			cancellationTokenRegistration.Dispose();
		}
	}

	protected abstract void BeginInvokeJS(long P_0, string P_1, string? P_2, JSCallResultType P_3, long P_4);

	protected internal abstract void EndInvokeDotNet(DotNetInvocationInfo P_0, in DotNetInvocationResult P_1);

	protected internal virtual void SendByteArray(int P_0, byte[] P_1)
	{
		throw new NotSupportedException("JSRuntime subclasses are responsible for implementing byte array transfer to JS.");
	}

	protected internal virtual void ReceiveByteArray(int P_0, byte[] P_1)
	{
		if (P_0 == 0)
		{
			ByteArraysToBeRevived.Clear();
		}
		if (P_0 != ByteArraysToBeRevived.Count)
		{
			throw new ArgumentOutOfRangeException($"Element id '{P_0}' cannot be added to the byte arrays to be revived with length '{ByteArraysToBeRevived.Count}'.", (Exception?)null);
		}
		ByteArraysToBeRevived.Append(in P_1);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2072:RequiresUnreferencedCode", Justification = "We enforce trimmer attributes for JSON deserialized types on InvokeAsync.")]
	[UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "We enforce trimmer attributes for JSON deserialized types on InvokeAsync.")]
	internal bool EndInvokeJS(long P_0, bool P_1, ref Utf8JsonReader P_2)
	{
		if (!_pendingTasks.TryRemove(P_0, out var obj))
		{
			return false;
		}
		CleanupTasksAndRegistrations(P_0);
		try
		{
			if (P_1)
			{
				Type taskCompletionSourceResultType = TaskGenericsUtil.GetTaskCompletionSourceResultType(obj);
				object obj2 = JsonSerializer.Deserialize(ref P_2, taskCompletionSourceResultType, JsonSerializerOptions);
				ByteArraysToBeRevived.Clear();
				TaskGenericsUtil.SetTaskCompletionSourceResult(obj, obj2);
			}
			else
			{
				string text = P_2.GetString() ?? string.Empty;
				TaskGenericsUtil.SetTaskCompletionSourceException(obj, new JSException(text));
			}
			return true;
		}
		catch (Exception ex)
		{
			string text2 = "An exception occurred executing JS interop: " + ex.Message + ". See InnerException for more details.";
			TaskGenericsUtil.SetTaskCompletionSourceException(obj, new JSException(text2, ex));
			return false;
		}
	}

	protected internal virtual Task TransmitStreamAsync(long P_0, DotNetStreamReference P_1)
	{
		if (!P_1.LeaveOpen)
		{
			P_1.Stream.Dispose();
		}
		throw new NotSupportedException("The current JS runtime does not support sending streams from .NET to JS.");
	}

	internal long BeginTransmittingStream(DotNetStreamReference P_0)
	{
		long num = Interlocked.Increment(ref _nextObjectReferenceId);
		TransmitStreamAsync(num, P_0);
		return num;
	}

	internal long TrackObjectReference<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TValue>(DotNetObjectReference<TValue> P_0) where TValue : class
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dotNetObjectReference");
		}
		P_0.ThrowIfDisposed();
		JSRuntime jSRuntime = P_0.JSRuntime;
		if (jSRuntime == null)
		{
			long num = Interlocked.Increment(ref _nextObjectReferenceId);
			P_0.JSRuntime = this;
			P_0.ObjectId = num;
			_trackedRefsById[num] = P_0;
		}
		else if (this != jSRuntime)
		{
			throw new InvalidOperationException(P_0.GetType().Name + " is already being tracked by a different instance of JSRuntime. A common cause is caching an instance of DotNetObjectReference globally. Consider creating instances of DotNetObjectReference at the JSInterop callsite.");
		}
		return P_0.ObjectId;
	}

	internal IDotNetObjectReference GetObjectReference(long P_0)
	{
		if (!_trackedRefsById.TryGetValue(P_0, out var result))
		{
			throw new ArgumentException($"There is no tracked object with id '{P_0}'. Perhaps the DotNetObjectReference instance was already disposed.", "dotNetObjectId");
		}
		return result;
	}

	internal void ReleaseObjectReference(long P_0)
	{
		_trackedRefsById.TryRemove(P_0, out var _);
	}

	public void Dispose()
	{
		ByteArraysToBeRevived.Dispose();
	}
}
