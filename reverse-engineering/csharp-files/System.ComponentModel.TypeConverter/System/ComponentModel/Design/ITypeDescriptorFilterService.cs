using System.Collections;

namespace System.ComponentModel.Design;

public interface ITypeDescriptorFilterService
{
	bool FilterAttributes(IComponent P_0, IDictionary P_1);

	bool FilterEvents(IComponent P_0, IDictionary P_1);

	bool FilterProperties(IComponent P_0, IDictionary P_1);
}
