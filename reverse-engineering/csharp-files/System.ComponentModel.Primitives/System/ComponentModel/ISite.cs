namespace System.ComponentModel;

public interface ISite : IServiceProvider
{
	string? Name { get; }
}
