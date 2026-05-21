namespace DCSoft.Writer.Data;

public class LinkListProvider
{
	private bool z0eek = true;

	private string z0rek;

	public bool Enabled
	{
		get
		{
			return z0eek;
		}
		set
		{
			z0eek = value;
		}
	}

	public string Name
	{
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	public virtual void GetListItems(GetLinkListItemsEventArgs args)
	{
	}
}
