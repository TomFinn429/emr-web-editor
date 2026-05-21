using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace System.Text.Json.Serialization.Converters;

internal sealed class IAsyncEnumerableOfTConverter<TAsyncEnumerable, TElement> : JsonCollectionConverter<TAsyncEnumerable, TElement> where TAsyncEnumerable : IAsyncEnumerable<TElement>
{
	private sealed class BufferedAsyncEnumerable : IAsyncEnumerable<TElement>
	{
		[CompilerGenerated]
		private sealed class _003CGetAsyncEnumerator_003Ed__1 : IAsyncEnumerator<TElement>, IAsyncDisposable, IValueTaskSource<bool>, IValueTaskSource, IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncIteratorMethodBuilder _003C_003Et__builder;

			public ManualResetValueTaskSourceCore<bool> _003C_003Ev__promiseOfValueOrEnd;

			private TElement _003C_003E2__current;

			private bool _003C_003Ew__disposeMode;

			public BufferedAsyncEnumerable _003C_003E4__this;

			private List<TElement>.Enumerator _003C_003E7__wrap1;

			TElement IAsyncEnumerator<TElement>.Current => _003C_003E2__current;

			public _003CGetAsyncEnumerator_003Ed__1(int P_0)
			{
				_003C_003Et__builder = AsyncIteratorMethodBuilder.Create();
				_003C_003E1__state = P_0;
			}

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				BufferedAsyncEnumerable bufferedAsyncEnumerable = _003C_003E4__this;
				try
				{
					if (num == -4)
					{
						goto IL_0040;
					}
					_ = -3;
					if (!_003C_003Ew__disposeMode)
					{
						num = (_003C_003E1__state = -1);
						_003C_003E7__wrap1 = bufferedAsyncEnumerable._buffer.GetEnumerator();
						goto IL_0040;
					}
					goto end_IL_000e;
					IL_0040:
					try
					{
						if (num != -4)
						{
							goto IL_007a;
						}
						num = (_003C_003E1__state = -1);
						if (!_003C_003Ew__disposeMode)
						{
							goto IL_007a;
						}
						goto end_IL_0040;
						IL_007a:
						if (_003C_003E7__wrap1.MoveNext())
						{
							TElement current = _003C_003E7__wrap1.Current;
							_003C_003E2__current = current;
							num = (_003C_003E1__state = -4);
							goto IL_0111;
						}
						end_IL_0040:;
					}
					finally
					{
						if (num == -1)
						{
							((IDisposable)_003C_003E7__wrap1/*cast due to .constrained prefix*/).Dispose();
						}
					}
					if (!_003C_003Ew__disposeMode)
					{
						_003C_003E7__wrap1 = default(List<TElement>.Enumerator);
					}
					end_IL_000e:;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003C_003E2__current = default(TElement);
					_003C_003Et__builder.Complete();
					_003C_003Ev__promiseOfValueOrEnd.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003C_003E2__current = default(TElement);
				_003C_003Et__builder.Complete();
				_003C_003Ev__promiseOfValueOrEnd.SetResult(false);
				return;
				IL_0111:
				_003C_003Ev__promiseOfValueOrEnd.SetResult(true);
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			private void SetStateMachine(IAsyncStateMachine P_0)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine P_0)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(P_0);
			}

			ValueTask<bool> IAsyncEnumerator<TElement>.MoveNextAsync()
			{
				if (_003C_003E1__state == -2)
				{
					return default(ValueTask<bool>);
				}
				_003C_003Ev__promiseOfValueOrEnd.Reset();
				_003CGetAsyncEnumerator_003Ed__1 _003CGetAsyncEnumerator_003Ed__ = this;
				_003C_003Et__builder.MoveNext(ref _003CGetAsyncEnumerator_003Ed__);
				short version = _003C_003Ev__promiseOfValueOrEnd.Version;
				if (_003C_003Ev__promiseOfValueOrEnd.GetStatus(version) == ValueTaskSourceStatus.Succeeded)
				{
					return new ValueTask<bool>(_003C_003Ev__promiseOfValueOrEnd.GetResult(version));
				}
				return new ValueTask<bool>(this, version);
			}

			bool IValueTaskSource<bool>.GetResult(short P_0)
			{
				return _003C_003Ev__promiseOfValueOrEnd.GetResult(P_0);
			}

			ValueTaskSourceStatus IValueTaskSource<bool>.GetStatus(short P_0)
			{
				return _003C_003Ev__promiseOfValueOrEnd.GetStatus(P_0);
			}

			void IValueTaskSource<bool>.OnCompleted(Action<object> P_0, object P_1, short P_2, ValueTaskSourceOnCompletedFlags P_3)
			{
				_003C_003Ev__promiseOfValueOrEnd.OnCompleted(P_0, P_1, P_2, P_3);
			}

			void IValueTaskSource.GetResult(short P_0)
			{
				_003C_003Ev__promiseOfValueOrEnd.GetResult(P_0);
			}

			ValueTaskSourceStatus IValueTaskSource.GetStatus(short P_0)
			{
				return _003C_003Ev__promiseOfValueOrEnd.GetStatus(P_0);
			}

			void IValueTaskSource.OnCompleted(Action<object> P_0, object P_1, short P_2, ValueTaskSourceOnCompletedFlags P_3)
			{
				_003C_003Ev__promiseOfValueOrEnd.OnCompleted(P_0, P_1, P_2, P_3);
			}
		}

		public readonly List<TElement> _buffer = new List<TElement>();

		[AsyncIteratorStateMachine(typeof(IAsyncEnumerableOfTConverter<, >.BufferedAsyncEnumerable._003CGetAsyncEnumerator_003Ed__1))]
		public IAsyncEnumerator<TElement> GetAsyncEnumerator(CancellationToken P_0)
		{
			return new _003CGetAsyncEnumerator_003Ed__1(-3)
			{
				_003C_003E4__this = this
			};
		}
	}

	internal override bool SupportsCreateObjectDelegate => false;

	internal override bool OnTryRead(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2, scoped ref ReadStack P_3, out TAsyncEnumerable P_4)
	{
		if (!P_1.IsAssignableFrom(typeof(IAsyncEnumerable<TElement>)))
		{
			ThrowHelper.ThrowNotSupportedException_CannotPopulateCollection(TypeToConvert, ref P_0, ref P_3);
		}
		return base.OnTryRead(ref P_0, P_1, P_2, ref P_3, out P_4);
	}

	protected override void Add(in TElement P_0, ref ReadStack P_1)
	{
		((BufferedAsyncEnumerable)P_1.Current.ReturnValue)._buffer.Add(P_0);
	}

	protected override void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1, JsonSerializerOptions P_2)
	{
		P_1.Current.ReturnValue = new BufferedAsyncEnumerable();
	}

	internal override bool OnTryWrite(Utf8JsonWriter P_0, TAsyncEnumerable P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		if (!P_3.SupportAsync)
		{
			ThrowHelper.ThrowNotSupportedException_TypeRequiresAsyncSerialization(TypeToConvert);
		}
		return base.OnTryWrite(P_0, P_1, P_2, ref P_3);
	}

	protected override bool OnWriteResume(Utf8JsonWriter P_0, TAsyncEnumerable P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		IAsyncEnumerator<TElement> asyncEnumerator;
		ValueTask<bool> valueTask;
		if (P_3.Current.AsyncDisposable == null)
		{
			asyncEnumerator = P_1.GetAsyncEnumerator(P_3.CancellationToken);
			P_3.Current.AsyncDisposable = asyncEnumerator;
			valueTask = asyncEnumerator.MoveNextAsync();
			if (!valueTask.IsCompleted)
			{
				P_3.SuppressFlush = true;
				goto IL_0106;
			}
		}
		else
		{
			asyncEnumerator = (IAsyncEnumerator<TElement>)P_3.Current.AsyncDisposable;
			if (P_3.Current.AsyncEnumeratorIsPendingCompletion)
			{
				valueTask = new ValueTask<bool>((Task<bool>)P_3.PendingTask);
				P_3.Current.AsyncEnumeratorIsPendingCompletion = false;
				P_3.PendingTask = null;
			}
			else
			{
				valueTask = new ValueTask<bool>(true);
			}
		}
		JsonConverter<TElement> elementConverter = JsonCollectionConverter<TAsyncEnumerable, TElement>.GetElementConverter(ref P_3);
		do
		{
			if (!valueTask.Result)
			{
				P_3.Current.AsyncDisposable = null;
				P_3.AddCompletedAsyncDisposable(asyncEnumerator);
				return true;
			}
			if (JsonConverter.ShouldFlush(P_0, ref P_3))
			{
				return false;
			}
			if (!elementConverter.TryWrite(P_0, asyncEnumerator.Current, P_2, ref P_3))
			{
				return false;
			}
			P_3.Current.EndCollectionElement();
			valueTask = asyncEnumerator.MoveNextAsync();
		}
		while (valueTask.IsCompleted);
		goto IL_0106;
		IL_0106:
		P_3.PendingTask = valueTask.AsTask();
		P_3.Current.AsyncEnumeratorIsPendingCompletion = true;
		return false;
	}
}
