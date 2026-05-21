namespace DCSoft;

internal delegate TResult DCFunc<T1, T2, TResult>(T1 arg1, T2 arg2);
internal delegate TResult DCFunc<TResult>();
internal delegate TResult DCFunc<T, TResult>(T arg);
