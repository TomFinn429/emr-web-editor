using DCSoft.Writer.Data;

namespace zzz;

public class z0ZzZzuvj : LinkListProvider
{
	private z0ZzZzfah z0eek;

	public z0ZzZzuvj(string p0, z0ZzZzfah p1)
	{
		base.Name = p0;
		z0eek = p1;
	}

	public override void GetListItems(GetLinkListItemsEventArgs args)
	{
		z0ZzZzsah z0ZzZzsah2 = null;
		if (args.CurrentBinding.IsRoot)
		{
			z0ZzZzsah2 = z0eek.z0uek();
			args.CurrentBinding.DataBoundItem = z0ZzZzsah2;
		}
		else
		{
			foreach (z0ZzZzoah item in ((z0ZzZzoah)(args.ParentBinding.DataBoundItem as z0ZzZzsah)).z0tek())
			{
				if (item is z0ZzZzsah)
				{
					z0ZzZzsah z0ZzZzsah3 = (z0ZzZzsah)item;
					string text = null;
					text = ((!z0ZzZzsah3.z0rek("Value")) ? z0ZzZzsah3.z0eek("Text") : z0ZzZzsah3.z0eek("Value"));
					if (text == args.ParentValue)
					{
						z0ZzZzsah2 = z0ZzZzsah3;
						break;
					}
				}
			}
		}
		args.CurrentBinding.DataBoundItem = z0ZzZzsah2;
		if (z0ZzZzsah2 == null)
		{
			return;
		}
		foreach (z0ZzZzoah item2 in ((z0ZzZzoah)z0ZzZzsah2).z0tek())
		{
			if (item2 is z0ZzZzsah)
			{
				z0ZzZzsah z0ZzZzsah4 = (z0ZzZzsah)item2;
				ListItem listItem = new ListItem();
				listItem.Text = z0ZzZzsah4.z0eek("Text");
				if (z0ZzZzsah4.z0rek("Value"))
				{
					listItem.Value = z0ZzZzsah4.z0eek("Value");
				}
				else
				{
					listItem.Value = listItem.Text;
				}
				args.Items.Add(listItem);
			}
		}
		args.Handled = true;
	}

	public void LoadXMLString(string xml)
	{
		z0eek = new z0ZzZzfah();
		z0eek.z0eek(xml);
	}

	public z0ZzZzuvj()
	{
	}
}
