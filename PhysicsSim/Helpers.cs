using SFML.System;
using static PhysicsSim.Globals;

namespace PhysicsSim;

public static class Helpers
{   
    public static Vector2f ToWorldSpace(this Vector2i vec)
    {
        float x = (((float)vec.X / WINDOW_WIDTH_HALF) - 1 + ((float)1 / WINDOW_WIDTH)) * WORLD_SIZE;
        float y = (-(((float)vec.Y / WINDOW_HEIGHT_HALF) - 1 + ((float)1 / WINDOW_HEIGHT))) * WORLD_SIZE;
        // Console.WriteLine($"To World Space: {x}|{y}");
        return new Vector2f(x, y);
    }
    
    public static Vector2f Normalize(this Vector2f vec)
    {
        float x = vec.X / WORLD_SIZE;
        float y = vec.Y / WORLD_SIZE;
        // Console.WriteLine($"Normalize: {x}|{y}");
        return new Vector2f(x, y);
    }
    
    public static Vector2i ToScreenSpace(this Vector2f vec)
    {
        int x = (int)(vec.X + 1) * WINDOW_WIDTH;
        int y = (int)(vec.Y + 1) * WINDOW_HEIGHT;
        // Console.WriteLine($"To Screen Space: {x}|{y}");
        return new Vector2i(x, y);
    }
}