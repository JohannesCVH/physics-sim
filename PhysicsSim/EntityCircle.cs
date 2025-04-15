using SFML.Graphics;
using SFML.System;

using static PhysicsSim.Globals;

namespace PhysicsSim;

public class EntityCircle : Entity
{
    public float Radius { get; set; }
    public int TriCount { get; set; } = 32;
    
    public EntityCircle(Vector2f pos, float radius) :
        base(pos)
    {
        Radius = radius;
    }

    public override VertexArray Generate(Vector2i pos)
    {
        var va = new VertexArray(PrimitiveType.TriangleFan);
        
        //there are 2*pi radians in a full circle. so 2*pi = 6.2831855 (radians) = 360 degrees.
        float angleIncr = (float)(2.0f * Math.PI / TriCount); //in radians
        float currentAngle = 0.0f; //also in radians

        for (int i = 0; i < TriCount; i++)
        {
            float x = WINDOW_ASPECT * Position.X + (float)(Radius * MathF.Cos(currentAngle));
            float y = -Position.Y + (float)(Radius * MathF.Sin(currentAngle));

            va.Append(new Vertex(new Vector2f(x, y), Color.White));
            currentAngle += angleIncr;
        }
        
        return va;
    }

    public override bool IsInside(Vector2f pos)
    {
        var dist = Math.Sqrt(Math.Pow(Position.X - pos.X, 2) + Math.Pow(Position.Y - pos.Y, 2));
        // Console.WriteLine($"Distance: {dist}");
        if (dist < Radius) return true;

        return false;
    }

    public override void CheckCollisions()
    {
        //Check window collisions
        if ((Position.X - Radius) < -WORLD_SIZE)
        {
            Position = new Vector2f(-WORLD_SIZE + Radius, Position.Y);
            Velocity = new Vector2f(-Velocity.X, Velocity.Y);
        }
        if ((Position.X + Radius) > WORLD_SIZE)
        {
            Position = new Vector2f(WORLD_SIZE - Radius, Position.Y);
            Velocity = new Vector2f(-Velocity.X, Velocity.Y);
        }
        if ((Position.Y - Radius) < -WORLD_SIZE)
        {
            Position = new Vector2f(Position.X, -WORLD_SIZE + Radius);
            Velocity = new Vector2f(Velocity.X, -Velocity.Y);
        }
        if ((Position.Y + Radius) > WORLD_SIZE)
        {
            Position = new Vector2f(Position.X, WORLD_SIZE - Radius);
            Velocity = new Vector2f(Velocity.X, -Velocity.Y);
        }
        
        //Check other entity collisions
        for (int i = 0; i < ENTITIES.Count; i++)
        {
            if (GetHashCode() == ENTITIES[i].GetHashCode()) continue;
            if (ENTITIES[i].GetType() == typeof(EntityCircle))
            {
                var collision = this.CheckCollisionCircle((EntityCircle)ENTITIES[i], out float collisionDepth);
                if (!collision) continue;
                
                Vector2f dir = (Position - ENTITIES[i].Position).Normalize();
                // Console.WriteLine($"Direction: {dir}");
                Position += dir * collisionDepth;
                ENTITIES[i].Position += -dir * collisionDepth;
            }
        }
    }
}