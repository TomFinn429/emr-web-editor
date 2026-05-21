using System.Collections;

namespace System.Xml.Schema;

internal sealed class Positions
{
	private readonly ArrayList _positions = new ArrayList();

	public Position this[int P_0] => (Position)_positions[P_0];

	public int Count => _positions.Count;

	public int Add(int P_0, object P_1)
	{
		return _positions.Add(new Position(P_0, P_1));
	}
}
