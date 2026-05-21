using System;

namespace DCSoft;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public sealed class DevAPIAttribute : Attribute
{
	private string _Description;

	private DateTime _CreationTime = DateTime.MinValue;

	private string _Name;

	public string Description => _Description;

	public DateTime CreationTime => _CreationTime;

	public string Name => _Name;

	public DevAPIAttribute(string strCreationTime, string strName)
	{
		_CreationTime = DateTime.Parse(strCreationTime);
		_Name = strName;
	}

	public DevAPIAttribute(string strCreationTime, string strName, string strDescription)
	{
		_CreationTime = DateTime.Parse(strCreationTime);
		_Name = strName;
		_Description = strDescription;
	}
}
