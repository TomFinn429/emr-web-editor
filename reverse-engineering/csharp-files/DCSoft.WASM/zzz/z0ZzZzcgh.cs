using System;
using System.Collections.Generic;
using System.Diagnostics;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

[DebuggerDisplay("Count={ Count }")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
public class z0ZzZzcgh : List<z0ZzZzvgh>
{
	private bool z0iek = true;

	private int z0oek;

	private XTextDocument z0pek;

	internal z0ZzZzcgh(XTextDocument p0)
	{
		z0pek = p0;
		z0uek();
	}

	public void z0eek(int p0)
	{
		z0oek = p0;
	}

	private void z0eek(XTextElementList p0)
	{
		z0ZzZzvgh z0ZzZzvgh2 = null;
		bool fillCommentToUserTrackList = z0eek().z0bu().FillCommentToUserTrackList;
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			z0ZzZzrzj z0ZzZzrzj2 = current.z0aek();
			if (z0ZzZzrzj2.z0nrk >= 0 || z0ZzZzrzj2.z0jyk >= 0)
			{
				if (z0ZzZzvgh2 == null || z0ZzZzvgh2.z0qrk != z0ZzZzrzj2.z0nrk || z0ZzZzvgh2.z0zek != z0ZzZzrzj2.z0jyk || z0ZzZzvgh2.z0frk != z0ZzZzrzj2.z0vyk)
				{
					z0ZzZzvgh2 = new z0ZzZzvgh();
					z0ZzZzvgh2.z0qrk = z0ZzZzrzj2.z0nrk;
					z0ZzZzvgh2.z0zek = z0ZzZzrzj2.z0jyk;
					z0ZzZzvgh2.z0frk = z0ZzZzrzj2.z0vyk;
					Add(z0ZzZzvgh2);
				}
				z0ZzZzvgh2.z0nek().Add(current);
			}
			else if (current is XTextCheckBoxElementBase && ((XTextCheckBoxElementBase)current).z0hrk())
			{
				foreach (z0ZzZzyhh checkedUserHistory in ((XTextCheckBoxElementBase)current).CheckedUserHistories)
				{
					z0ZzZzvgh z0ZzZzvgh3 = new z0ZzZzvgh();
					z0ZzZzvgh3.z0qrk = checkedUserHistory.z0pek();
					z0ZzZzvgh3.z0eek(checkedUserHistory.z0xek());
					z0ZzZzvgh3.z0tek(checkedUserHistory.z0zek());
					z0ZzZzvgh3.z0rek(checkedUserHistory.z0yek());
					z0ZzZzvgh3.z0pek(checkedUserHistory.z0mek());
					z0ZzZzvgh3.z0eek(checkedUserHistory.z0rek());
					if (checkedUserHistory.z0vek())
					{
						z0ZzZzvgh3.z0eek(UserTrackType.Checked);
					}
					else
					{
						z0ZzZzvgh3.z0eek(UserTrackType.UnChecked);
					}
					z0ZzZzvgh3.z0nek().Add(current);
					Add(z0ZzZzvgh3);
				}
				z0ZzZzvgh2 = null;
			}
			else if (fillCommentToUserTrackList && z0ZzZzrzj2.z0vyk >= 0)
			{
				if (z0ZzZzvgh2 == null || z0ZzZzvgh2.z0frk != z0ZzZzrzj2.z0vyk)
				{
					z0ZzZzvgh2 = new z0ZzZzvgh();
					z0ZzZzvgh2.z0frk = z0ZzZzrzj2.z0vyk;
					Add(z0ZzZzvgh2);
				}
				z0ZzZzvgh2.z0nek().Add(current);
			}
			else
			{
				z0ZzZzvgh2 = null;
			}
		}
	}

	internal z0ZzZzcgh()
	{
	}

	public XTextDocument z0eek()
	{
		return z0pek;
	}

	public void z0eek(XTextContainerElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		z0pek = p0.z0jr();
		z0eek(p0: false, p0);
	}

	private void z0rek(XTextContainerElement p0)
	{
		z0ZzZzvgh z0ZzZzvgh2 = null;
		bool fillCommentToUserTrackList = z0eek().z0bu().FillCommentToUserTrackList;
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0be().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			_ = current.Text;
			z0ZzZzrzj z0ZzZzrzj2 = current.z0aek();
			if (current is XTextCheckBoxElementBase && ((XTextCheckBoxElementBase)current).z0hrk())
			{
				foreach (z0ZzZzyhh checkedUserHistory in ((XTextCheckBoxElementBase)current).CheckedUserHistories)
				{
					z0ZzZzvgh z0ZzZzvgh3 = new z0ZzZzvgh();
					z0ZzZzvgh3.z0qrk = checkedUserHistory.z0pek();
					z0ZzZzvgh3.z0eek(checkedUserHistory.z0xek());
					z0ZzZzvgh3.z0tek(checkedUserHistory.z0zek());
					z0ZzZzvgh3.z0rek(checkedUserHistory.z0yek());
					z0ZzZzvgh3.z0pek(checkedUserHistory.z0mek());
					z0ZzZzvgh3.z0eek(checkedUserHistory.z0rek());
					if (checkedUserHistory.z0vek())
					{
						z0ZzZzvgh3.z0eek(UserTrackType.Checked);
					}
					else
					{
						z0ZzZzvgh3.z0eek(UserTrackType.UnChecked);
					}
					z0ZzZzvgh3.z0nek().Add(current);
					Add(z0ZzZzvgh3);
				}
				z0ZzZzvgh2 = null;
			}
			if (z0ZzZzrzj2.z0nrk >= 0 || z0ZzZzrzj2.z0jyk >= 0)
			{
				if (z0ZzZzvgh2 == null || z0ZzZzvgh2.z0qrk != z0ZzZzrzj2.z0nrk || z0ZzZzvgh2.z0zek != z0ZzZzrzj2.z0jyk || z0ZzZzvgh2.z0frk != z0ZzZzrzj2.z0vyk)
				{
					z0ZzZzvgh2 = new z0ZzZzvgh();
					z0ZzZzvgh2.z0qrk = z0ZzZzrzj2.z0nrk;
					z0ZzZzvgh2.z0zek = z0ZzZzrzj2.z0jyk;
					z0ZzZzvgh2.z0frk = z0ZzZzrzj2.z0vyk;
					Add(z0ZzZzvgh2);
				}
				z0ZzZzvgh2.z0nek().Add(current);
			}
			else if (fillCommentToUserTrackList && z0ZzZzrzj2.z0vyk >= 0)
			{
				if (z0ZzZzvgh2 == null || z0ZzZzvgh2.z0frk != z0ZzZzrzj2.z0vyk)
				{
					z0ZzZzvgh2 = new z0ZzZzvgh();
					z0ZzZzvgh2.z0frk = z0ZzZzrzj2.z0vyk;
					Add(z0ZzZzvgh2);
				}
				z0ZzZzvgh2.z0nek().Add(current);
			}
			else
			{
				z0ZzZzvgh2 = null;
			}
			if (current is XTextContainerElement)
			{
				z0rek((XTextContainerElement)current);
			}
		}
	}

	public bool z0rek()
	{
		return z0iek;
	}

	private void z0eek(bool p0, XTextContainerElement p1)
	{
		if (z0pek == null)
		{
			return;
		}
		if (p0)
		{
			z0oek = z0pek.z0kek();
			Clear();
			z0eek(z0pek.z0xyk().z0frk());
		}
		else
		{
			if (p1 == null)
			{
				throw new ArgumentNullException("rootElement");
			}
			z0rek(p1);
		}
		if (base.Count == 0)
		{
			return;
		}
		List<z0ZzZzvgh> list = new List<z0ZzZzvgh>();
		using (List<z0ZzZzvgh>.Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzvgh current = enumerator.Current;
				if (current.z0pek() == UserTrackType.Checked || current.z0pek() == UserTrackType.UnChecked)
				{
					list.Add(current);
					continue;
				}
				if (current.z0qrk >= 0)
				{
					z0ZzZzvgh z0ZzZzvgh2 = new z0ZzZzvgh();
					z0ZzZzvgh2.z0eek(UserTrackType.Create);
					z0ZzZzvgh2.z0qrk = current.z0qrk;
					((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzvgh2.z0nek()).z0tek((zzz.z0ZzZzkuk<XTextElement>)current.z0nek());
					list.Add(z0ZzZzvgh2);
				}
				if (current.z0zek >= 0)
				{
					z0ZzZzvgh z0ZzZzvgh3 = new z0ZzZzvgh();
					z0ZzZzvgh3.z0eek(UserTrackType.Delete);
					z0ZzZzvgh3.z0zek = current.z0zek;
					((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzvgh3.z0nek()).z0tek((zzz.z0ZzZzkuk<XTextElement>)current.z0nek());
					list.Add(z0ZzZzvgh3);
				}
				if (current.z0frk >= 0)
				{
					z0ZzZzvgh z0ZzZzvgh4 = new z0ZzZzvgh();
					z0ZzZzvgh4.z0eek(UserTrackType.Comment);
					z0ZzZzvgh4.z0frk = current.z0frk;
					((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzvgh4.z0nek()).z0tek((zzz.z0ZzZzkuk<XTextElement>)current.z0nek());
					list.Add(z0ZzZzvgh4);
				}
			}
		}
		Clear();
		AddRange(list);
		using List<z0ZzZzvgh>.Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzvgh current2 = enumerator.Current;
			if (current2.z0pek() == UserTrackType.Checked || current2.z0pek() == UserTrackType.UnChecked)
			{
				continue;
			}
			if (current2.z0pek() == UserTrackType.Create)
			{
				z0ZzZzyhh z0ZzZzyhh2 = z0pek.z0syk().z0tek(current2.z0qrk);
				if (z0ZzZzyhh2 != null)
				{
					current2.z0tek(z0ZzZzyhh2.z0zek());
					current2.z0rek(z0ZzZzyhh2.z0yek());
					current2.z0eek(z0ZzZzyhh2.z0xek());
					current2.z0eek(z0ZzZzyhh2.z0rek());
					current2.z0pek(z0ZzZzyhh2.z0mek());
					current2.z0yek(z0ZzZzyhh2.z0bek());
					current2.z0iek(z0ZzZzyhh2.z0uek());
				}
			}
			else if (current2.z0pek() == UserTrackType.Delete)
			{
				z0ZzZzyhh z0ZzZzyhh3 = z0pek.z0syk().z0tek(current2.z0zek);
				if (z0ZzZzyhh3 != null)
				{
					current2.z0tek(z0ZzZzyhh3.z0zek());
					current2.z0rek(z0ZzZzyhh3.z0yek());
					current2.z0eek(z0ZzZzyhh3.z0xek());
					current2.z0eek(z0ZzZzyhh3.z0rek());
					current2.z0pek(z0ZzZzyhh3.z0mek());
					current2.z0yek(z0ZzZzyhh3.z0bek());
					current2.z0iek(z0ZzZzyhh3.z0uek());
				}
			}
			else if (current2.z0pek() == UserTrackType.Comment)
			{
				DocumentComment documentComment = z0pek.Comments.z0eek(current2.z0frk);
				if (documentComment != null)
				{
					current2.z0uek(documentComment.z0nek());
					int num = documentComment.z0urk();
					if (num >= 0)
					{
						z0ZzZzyhh z0ZzZzyhh4 = z0pek.z0syk().z0tek(num);
						current2.z0tek(z0ZzZzyhh4.z0zek());
						current2.z0rek(z0ZzZzyhh4.z0yek());
						current2.z0eek(z0ZzZzyhh4.z0xek());
						current2.z0eek(z0ZzZzyhh4.z0rek());
						current2.z0pek(z0ZzZzyhh4.z0mek());
						current2.z0yek(z0ZzZzyhh4.z0bek());
						current2.z0iek(z0ZzZzyhh4.z0uek());
					}
					else
					{
						current2.z0tek(documentComment.z0eek());
						current2.z0rek(documentComment.z0krk());
						current2.z0eek(documentComment.z0mrk());
						current2.z0eek(0);
					}
				}
			}
			if (current2.z0eek() == z0ZzZzkfh.z0wrk || current2.z0eek() == z0ZzZzkfh.z0zrk)
			{
				current2.z0eek(z0eek().z0jpk());
			}
		}
	}

	public int z0tek()
	{
		return z0oek;
	}

	public z0ZzZzvgh z0yek()
	{
		if (z0pek == null || base.Count == 0)
		{
			return null;
		}
		if (z0eek().z0oik() == PageContentPartyStyle.Body)
		{
			XTextElement item = z0eek().z0itk();
			using List<z0ZzZzvgh>.Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				z0ZzZzvgh current = enumerator.Current;
				if (current.z0nek().Contains(item))
				{
					return current;
				}
			}
		}
		return null;
	}

	public void z0eek(bool p0)
	{
		z0iek = p0;
	}

	public void z0uek()
	{
		z0eek(p0: true, null);
	}

	public void z0eek(XTextDocument p0)
	{
		z0pek = p0;
	}
}
