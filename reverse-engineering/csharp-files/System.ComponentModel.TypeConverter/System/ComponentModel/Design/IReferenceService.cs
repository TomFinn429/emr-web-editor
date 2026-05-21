namespace System.ComponentModel.Design;

public interface IReferenceService
{
	object? GetReference(string P_0);

	string? GetName(object P_0);

	object[] GetReferences(Type P_0);
}
