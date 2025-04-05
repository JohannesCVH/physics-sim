using OpenTK.Mathematics;

namespace PhysicsSim;

public class Entity
{
    public Vector2 Position { get; set; }

	public Entity(Vector2 pos)
	{
		Position = pos;
	}
}