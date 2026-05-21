using System.Text;
using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer.Data;

public class GetLinkListItemsEventArgs
{
	private XTextElementList z0eek;

	private z0ZzZzfvj z0rek_jiejie20260327142557;

	private XTextElement z0tek;

	private string z0yek;

	private z0ZzZzfvj z0uek;

	private z0ZzZzdvj z0iek = new z0ZzZzdvj();

	private bool z0oek;

	private bool z0pek;

	private XTextElement z0mek;

	public z0ZzZzfvj ParentBinding
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	[JsonIgnore]
	public XTextElement CurrentElement
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	public int CurrentLevelBase0
	{
		get
		{
			if (EffectElements != null)
			{
				return EffectElements.IndexOf(CurrentElement);
			}
			return -1;
		}
	}

	public string ParentValueList
	{
		get
		{
			if (z0eek != null)
			{
				int num = z0eek.IndexOf(CurrentElement);
				if (num > 1)
				{
					StringBuilder stringBuilder = new StringBuilder();
					for (int i = 0; i < num; i++)
					{
						XTextInputFieldElement xTextInputFieldElement = z0eek[i] as XTextInputFieldElement;
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(',');
						}
						if (xTextInputFieldElement != null)
						{
							stringBuilder.Append(xTextInputFieldElement.InnerValue);
						}
					}
					return stringBuilder.ToString();
				}
			}
			return null;
		}
	}

	public string ParentTextList
	{
		get
		{
			if (z0eek != null)
			{
				int num = z0eek.IndexOf(CurrentElement);
				if (num > 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					for (int i = 0; i < num; i++)
					{
						XTextElement xTextElement = z0eek[i];
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(',');
						}
						stringBuilder.Append(xTextElement.Text);
					}
					return stringBuilder.ToString();
				}
			}
			return null;
		}
	}

	public string ProviderName
	{
		get
		{
			if (z0rek_jiejie20260327142557 != null)
			{
				return z0rek_jiejie20260327142557.ProviderName;
			}
			return null;
		}
	}

	public string ParentValue
	{
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	public bool Cancel
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	[JsonIgnore]
	public XTextElement ParentElement
	{
		get
		{
			return z0mek;
		}
		set
		{
			z0mek = value;
		}
	}

	public z0ZzZzdvj Items
	{
		get
		{
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	public bool Handled
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	public z0ZzZzfvj CurrentBinding
	{
		get
		{
			return z0rek_jiejie20260327142557;
		}
		set
		{
			z0rek_jiejie20260327142557 = value;
		}
	}

	[JsonIgnore]
	public XTextElementList EffectElements
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
}
