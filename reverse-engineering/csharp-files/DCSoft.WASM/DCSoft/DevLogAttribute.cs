using System;

namespace DCSoft;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public sealed class DevLogAttribute : Attribute
{
	private string _Description;

	private string _JiraID;

	private DateTime _Time = DateTime.MinValue;

	private string _Author;

	public DateTime Time => _Time;

	public string Description => _Description;

	public string JiraID => _JiraID;

	public string Author => _Author;

	public DevLogAttribute(string strTime, string strAuthor, string strJiraID, string strDescription)
	{
		_Time = DateTime.Parse(strTime);
		_Author = strAuthor;
		_JiraID = strJiraID;
		_Description = strDescription;
	}
}
