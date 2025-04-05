using OpenTK.Mathematics;

namespace PhysicsSim;

public static class MathLib
{
    public static Matrix3 CreateTransformationMatrix(Vector2 pos, float scale, float rotZ)
    {
        var transform = Matrix3.Identity;
        // transform = transform * Matrix3.CreateRotationZ(MathHelper.DegreesToRadians(rotZ));
        // transform = transform * Matrix3.CreateScale(scale);

        // Matrix4 transMat = Matrix4.CreateTranslation(new Vector3(pos));

        Matrix3 translationMatrix = new Matrix3();
        translationMatrix.Row0.X = 1.0f;
		translationMatrix.Row0.Y = 0.0f;
		translationMatrix.Row0.Z = pos.X;
				
		translationMatrix.Row1.X = 0.0f;
		translationMatrix.Row1.Y = 1.0f;
		translationMatrix.Row1.Z = pos.Y;
				
		translationMatrix.Row2.X = 0.0f;
		translationMatrix.Row2.Y = 0.0f;
		translationMatrix.Row2.Z = 1.0f;

        // translationMatrix.Row0.X = 1.0f;
		// translationMatrix.Row1.X = 0.0f;
		// translationMatrix.Row2.X = pos.X;
				
		// translationMatrix.Row0.Y = 0.0f;
		// translationMatrix.Row1.Y = 1.0f;
		// translationMatrix.Row2.Y = pos.Y;
				
		// translationMatrix.Row0.Z = 0.0f;
		// translationMatrix.Row1.Z = 0.0f;
		// translationMatrix.Row2.Z = 1.0f;

        transform = transform * translationMatrix;
        
        return transform;
    }
}