namespace DCSoft.Writer.Controls;

public class CustomCommandEventArgs
{
	private string z0eek;

	private string z0rek;

	public string CommandName => z0eek;

	public string Text => z0rek;

	public CustomCommandEventArgs(string txt, string cmd)
	{
		z0rek = txt;
		z0eek = cmd;
	}
}
