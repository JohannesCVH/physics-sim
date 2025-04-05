using OpenTK.Mathematics;
using PhysicsSim.Models3D;

using static PhysicsSim.Globals;

namespace PhysicsSim;

public class EntityCircle : EntityPhysical
{
    public EntityCircle(Vector2 pos, float radius) : 
        base(pos, radius * 2)
    {
        GenCircle(pos, 16, radius);
        Mesh.CreateMesh();
    }

    public void GenCircle(Vector2 pos, int triCount, float radius)
    {
        //there are 2*pi radians in a full circle. so 2*pi = 6.2831855 (radians) = 360 degrees.
        float angleIncr = (float)(2.0f * Math.PI / triCount); //in radians
        float currentAngle = 0.0f; //also in radians

        Vertex[] vertices = new Vertex[(triCount * 3) + 1];

        vertices[0] = new Vertex(new Vector3(pos.X, pos.Y, 0.0f));

        for (int i = 0; i <= triCount; i++)
        {
            float x = WINDOW_ASPECT * pos.X + (float)(radius * MathHelper.Cos(currentAngle));
            float y = pos.Y + (float)(radius * MathHelper.Sin(currentAngle));

            vertices[i] = new Vertex(new Vector3(x, y, 0.0f));
            currentAngle += angleIncr;
        }

        Mesh.Vertices = vertices;
    }
}
