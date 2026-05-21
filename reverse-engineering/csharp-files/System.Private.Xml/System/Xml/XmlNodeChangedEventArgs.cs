namespace System.Xml;

public class XmlNodeChangedEventArgs : EventArgs
{
	private readonly XmlNodeChangedAction _action;

	private readonly XmlNode _node;

	private readonly XmlNode _oldParent;

	private readonly XmlNode _newParent;

	private readonly string _oldValue;

	private readonly string _newValue;

	public XmlNodeChangedAction Action => _action;

	public XmlNodeChangedEventArgs(XmlNode? P_0, XmlNode? P_1, XmlNode? P_2, string? P_3, string? P_4, XmlNodeChangedAction P_5)
	{
		_node = P_0;
		_oldParent = P_1;
		_newParent = P_2;
		_action = P_5;
		_oldValue = P_3;
		_newValue = P_4;
	}
}
