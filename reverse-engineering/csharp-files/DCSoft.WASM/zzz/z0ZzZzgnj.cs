using System.Collections.Generic;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;

namespace zzz;

internal sealed class z0ZzZzgnj : z0ZzZzcmj
{
	[z0ZzZzimj("ClearUserTrace", FunctionID = 131)]
	private void z0eek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null && p1.EditorControl.z0uek() && !p1.EditorControl.z0ork() && p1.Document != null && p1.Document.z0cuk().z0qrk() != 0;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			if (p1.Document.z0cuk().z0qrk() == 0)
			{
				return;
			}
			Dictionary<XTextElement, int> dictionary = new Dictionary<XTextElement, int>();
			XTextElementList xTextElementList = new XTextElementList();
			foreach (XTextElement item in p1.Document.z0cuk())
			{
				if (item is XTextCharElement)
				{
					XTextCharElement xTextCharElement = (XTextCharElement)item;
					if (xTextCharElement.z0oek())
					{
						XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xTextCharElement.z0ji();
						if (!xTextElementList.Contains(xTextInputFieldElement))
						{
							xTextElementList.Add(xTextInputFieldElement);
						}
						continue;
					}
				}
				if (item is XTextFieldBorderElement)
				{
					XTextInputFieldElement xTextInputFieldElement2 = (XTextInputFieldElement)(item as XTextFieldBorderElement).z0ji();
					if (!xTextElementList.Contains(xTextInputFieldElement2))
					{
						xTextElementList.Add(xTextInputFieldElement2);
					}
					continue;
				}
				DocumentContentStyle z0jrk = item.z0aek().z0jrk;
				if (z0jrk.CreatorIndex >= 0 || z0jrk.DeleterIndex >= 0)
				{
					z0jrk = (DocumentContentStyle)z0jrk.Clone();
					z0jrk.z0eek(p0: false);
					z0jrk.CreatorIndex = -1;
					z0jrk.DeleterIndex = -1;
					dictionary[item] = p1.Document.z0gnk().GetStyleIndex(z0jrk);
				}
			}
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					DocumentContentStyle z0jrk2 = current.z0aek().z0jrk;
					if (z0jrk2.CreatorIndex >= 0 || z0jrk2.DeleterIndex >= 0)
					{
						z0jrk2 = (DocumentContentStyle)z0jrk2.Clone();
						z0jrk2.z0eek(p0: false);
						z0jrk2.CreatorIndex = -1;
						z0jrk2.DeleterIndex = -1;
						dictionary[current] = p1.Document.z0gnk().GetStyleIndex(z0jrk2);
					}
				}
			}
			if (p1.Document.z0cuk().z0irk() != null)
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.Document.z0cuk().z0irk().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
					DocumentContentStyle z0jrk3 = xTextTableCellElement.z0aek().z0jrk;
					if (z0jrk3.CreatorIndex >= 0 || z0jrk3.DeleterIndex >= 0)
					{
						z0jrk3 = (DocumentContentStyle)z0jrk3.Clone();
						z0jrk3.z0eek(p0: false);
						z0jrk3.CreatorIndex = -1;
						z0jrk3.DeleterIndex = -1;
						dictionary[xTextTableCellElement] = p1.Document.z0gnk().GetStyleIndex(z0jrk3);
					}
				}
			}
			if (dictionary.Count > 0)
			{
				p1.Result = true;
				p1.Document.z0rek(dictionary, p1: true, p2: true, p1.Name);
			}
		}
	}

	[z0ZzZzimj("SignBySignImageElement")]
	private void z0rek_jiejie20260327142557(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null && p1.EditorControl.z0bek();
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.EditorControl.z0eek(p1.Parameter as DCSignInputInfo);
		}
	}

	[z0ZzZzimj("RejectUserTrace", ReturnValueType = typeof(bool))]
	private void z0tek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null && p1.EditorControl.z0uek() && !p1.EditorControl.z0ork();
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			if (p1.EditorControl.z0mok())
			{
				p1.RefreshLevel = (z0ZzZzwmj)2;
				p1.Result = true;
			}
			else
			{
				p1.Result = false;
			}
		}
	}

	[z0ZzZzimj("CommitUserTrace", ReturnValueType = typeof(bool))]
	private void z0yek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null && p1.EditorControl.z0uek() && !p1.EditorControl.z0ork();
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			if (p1.Document.z0eu())
			{
				p1.Document.Modified = true;
				p1.EditorControl.z0iyk();
				p1.RefreshLevel = (z0ZzZzwmj)2;
				p1.Document.OnDocumentContentChanged();
				p1.Result = true;
			}
			else
			{
				p1.Result = false;
			}
		}
	}

	[z0ZzZzimj("SetUserInfo")]
	private void z0uek(object p0, z0ZzZzomj p1)
	{
		z0nek(p0, p1);
	}

	[z0ZzZzimj("GetUserTrackInfosXMLString", ReturnValueType = typeof(string))]
	private void z0iek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			z0ZzZzcgh obj = new z0ZzZzcgh(p1.Document);
			z0ZzZzfah z0ZzZzfah2 = new z0ZzZzfah();
			z0ZzZzsah z0ZzZzsah2 = z0ZzZzfah2.z0rek("UserTrackInfoList");
			foreach (z0ZzZzvgh item in obj)
			{
				z0ZzZzsah z0ZzZzsah3 = z0ZzZzfah2.z0rek("UserTrackInfo");
				z0ZzZzsah3.z0eek("CommentText", item.z0uek());
				z0ZzZzsah3.z0eek("ViewIndexForNavigating", item.z0nek().z0krk().z0jrk()
					.ToString());
				z0ZzZzsah3.z0eek("InfoType", item.z0pek().ToString());
				z0ZzZzsah3.z0eek("PermissionLevel", item.z0yek().ToString());
				z0ZzZzsah3.z0eek("SaveTime", item.z0eek().ToString());
				z0ZzZzsah3.z0eek("StdTitle", item.z0oek());
				z0ZzZzsah3.z0eek("Text", item.z0iek());
				z0ZzZzsah3.z0eek("UserID", item.z0rek());
				z0ZzZzsah3.z0eek("UserName", item.z0mek());
				z0ZzZzsah2.z0if(z0ZzZzsah3);
			}
			z0ZzZzfah2.z0if(z0ZzZzsah2);
			p1.Result = ((z0ZzZzoah)z0ZzZzfah2).z0uek();
		}
	}

	[z0ZzZzimj("BackgroundMode", FunctionID = 124)]
	private void z0oek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null)
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = true;
			p1.Checked = p1.EditorControl.z0hik();
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			bool p2 = !p1.EditorControl.z0hik();
			p2 = z0ZzZzafh.z0yek(p1.Parameter, p2);
			p1.EditorControl.z0srk(p2);
			p1.EditorControl.z0cuk().BehaviorOptions.EnableLogUndo = !p2;
			p1.EditorControl.z0ypk()?.z0ouk();
			p1.Result = p1.EditorControl.z0hik();
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("AdministratorViewMode", FunctionID = 123)]
	private void z0pek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null)
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = true;
			p1.Checked = p1.EditorControl.z0uek();
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			bool p2 = !p1.EditorControl.z0uek();
			p2 = z0ZzZzafh.z0yek(p1.Parameter, p2);
			p1.EditorControl.z0bek(p2);
			p1.z0rek().z0hz();
			p1.Result = p1.EditorControl.z0uek();
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("AttachCurrentUserTrackToBodyContent", ReturnValueType = typeof(bool))]
	private void z0mek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			int creatorIndex = p1.Document.z0syk().z0yek();
			bool flag = false;
			foreach (XTextElement item in new z0ZzZzkxj(p1.Document.z0xyk())
			{
				ExcludeCharElement = false,
				ExcludeParagraphFlag = false
			})
			{
				if (item.z0aek().z0nrk == -1 && item.z0aek().z0jyk == -1)
				{
					item.z0xrk().CreatorIndex = creatorIndex;
					flag = true;
				}
			}
			if (flag)
			{
				if (p1.Document.z0imk() != null)
				{
					p1.Document.z0imk().Clear();
				}
				p1.Document.Modified = true;
				p1.Document.OnDocumentContentChanged();
				p1.EditorControl.z0iyk();
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
			p1.Result = flag;
		}
	}

	protected override z0ZzZzvmj z0qz()
	{
		z0ZzZzvmj obj = new z0ZzZzvmj();
		z0ZzZzcmj.z0rek(obj, "AdministratorViewMode", z0pek);
		z0ZzZzcmj.z0rek(obj, "AttachCurrentUserTrackToBodyContent", z0mek);
		z0ZzZzcmj.z0rek(obj, "BackgroundMode", z0oek);
		z0ZzZzcmj.z0rek(obj, "ClearAllUserTrace", z0bek);
		z0ZzZzcmj.z0rek(obj, "ClearUserTrace", z0eek);
		z0ZzZzcmj.z0rek(obj, "CommitUserTrace", z0yek);
		z0ZzZzcmj.z0rek(obj, "GetUserTrackInfosXMLString", z0iek);
		z0ZzZzcmj.z0rek(obj, "RejectUserTrace", z0tek);
		z0ZzZzcmj.z0rek(obj, "SetAutoLogin", z0nek);
		z0ZzZzcmj.z0rek(obj, "SetUserInfo", z0uek);
		z0ZzZzcmj.z0rek(obj, "SignBySignImageElement", z0rek_jiejie20260327142557);
		return obj;
	}

	[z0ZzZzimj("SetAutoLogin")]
	private void z0nek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			z0ZzZznbj z0ZzZznbj2 = null;
			if (p1.Parameter is UserLoginInfo)
			{
				UserLoginInfo userLoginInfo = (UserLoginInfo)p1.Parameter;
				z0ZzZznbj2 = new z0ZzZznbj();
				z0ZzZznbj2.z0yek(userLoginInfo.ClientName);
				z0ZzZznbj2.z0tek(userLoginInfo.Name);
				z0ZzZznbj2.z0rek(userLoginInfo.ID);
				z0ZzZznbj2.z0eek(userLoginInfo.PermissionLevel);
			}
			if (p1.Parameter is z0ZzZznbj)
			{
				z0ZzZznbj2 = (z0ZzZznbj)p1.Parameter;
			}
			p1.Host.z0tek().z0rek(typeof(z0ZzZznbj), z0ZzZznbj2);
			if (p1.EditorControl != null)
			{
				p1.EditorControl.z0tek(p0: true);
				p1.EditorControl.z0cuk().SecurityOptions.EnablePermission = true;
				p1.EditorControl.z0cuk().SecurityOptions.EnableLogicDelete = true;
			}
		}
	}

	[z0ZzZzimj("ClearAllUserTrace", ReturnValueType = typeof(bool), FunctionID = 131)]
	private void z0bek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null && p1.EditorControl.z0uek() && !p1.EditorControl.z0ork();
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			bool flag = false;
			using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = p1.Document.z0gnk().Styles.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					DocumentContentStyle documentContentStyle = (DocumentContentStyle)z0bpk.Current;
					if (documentContentStyle.CreatorIndex >= 0 || documentContentStyle.DeleterIndex >= 0)
					{
						documentContentStyle.z0rek();
						documentContentStyle.z0tek();
						flag = true;
					}
				}
			}
			if (p1.Document.z0syk().Count > 0)
			{
				p1.Document.z0syk().Clear();
				p1.Document.z0prk();
			}
			if (flag)
			{
				if (p1.Document.z0imk() != null)
				{
					p1.Document.z0imk().Clear();
				}
				p1.EditorControl.z0iyk();
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
			p1.Result = flag;
		}
	}
}
