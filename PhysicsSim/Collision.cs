namespace PhysicsSim;

public enum Bounds
{
    Left = 0,
    Right = 1,
    Top = 2,
    Bottom = 3
}

public static class Collision
{
    public static bool CheckCollisionCircle(this EntityCircle entity, EntityCircle circle, out float collisionDepth)
    {
        var dist = (float)Math.Sqrt(Math.Pow(entity.Position.X - circle.Position.X, 2) + Math.Pow(entity.Position.Y - circle.Position.Y, 2));
        var radii = entity.Radius + circle.Radius;
        collisionDepth = radii - dist;
        if (dist < radii) return true;
        
        return false;
    }
}