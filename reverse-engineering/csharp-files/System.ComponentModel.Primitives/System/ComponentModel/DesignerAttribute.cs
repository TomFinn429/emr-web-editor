using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
public sealed class DesignerAttribute : Attribute
{
	private string _typeId;

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
	public string DesignerBaseTypeName { get; }

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
	public string DesignerTypeName { get; }

	public override object TypeId
	{
		get
		{
			if (_typeId == null)
			{
				string text = DesignerBaseTypeName ?? string.Empty;
				int num = text.IndexOf(',');
				if (num != -1)
				{
					text = text.Substring(0, num);
				}
				_typeId = GetType().FullName + text;
			}
			return _typeId;
		}
	}

	public DesignerAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "designerTypeName");
		DesignerTypeName = P_0;
		DesignerBaseTypeName = "System.ComponentModel.Design.IDesigner, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
	}

	public DesignerAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] string P_0, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] string P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "designerTypeName");
		DesignerTypeName = P_0;
		DesignerBaseTypeName = P_1;
	}

	public override bool Equals(object? P_0)
	{
		if (P_0 == this)
		{
			return true;
		}
		if (P_0 is DesignerAttribute designerAttribute && designerAttribute.DesignerBaseTypeName == DesignerBaseTypeName)
		{
			return designerAttribute.DesignerTypeName == DesignerTypeName;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(DesignerBaseTypeName, DesignerTypeName);
	}
}
