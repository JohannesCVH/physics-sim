using SFML.Graphics;
using SFML.System;

namespace PhysicsSim;

public abstract class Entity
{
    public Vector2f Position { get; set; }
	public float ScaleFactor { get; set; }
	
	public Vector2f Velocity { get; set; } = new Vector2f(0.0f, 0.0f);

	public Entity(Vector2f pos)
	{
		Position = pos;
	}
	
	public abstract bool IsInside(Vector2f pos);
	public abstract VertexArray Generate(Vector2i pos);
	public abstract void CheckCollisions();
	public virtual void Update()
	{
		Position += Velocity;
		CheckCollisions();
	}
}