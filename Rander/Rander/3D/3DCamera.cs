using Microsoft.Xna.Framework;

namespace Rander._3D
{
    public class Camera3D
    {
        public Matrix LocalMatrix;
        public Matrix Projection;

        Vector3 Up = Vector3.UnitZ;
        Vector3 CamPos = Vector3.Zero;
        Vector3 CamRot = Vector3.Zero;
        public Vector3 CameraPosition { get { return CamPos; } set { CamPos = value; LocalMatrix = Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(CamRot.X), MathHelper.ToRadians(CamRot.Y), MathHelper.ToRadians(CamRot.Z)) * Matrix.CreateTranslation(CamPos); } }
        public Vector3 CameraRotation { get { return CamRot; } set { CamRot = value; LocalMatrix = Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(CamRot.X), MathHelper.ToRadians(CamRot.Y), MathHelper.ToRadians(CamRot.Z)) * Matrix.CreateTranslation(CamPos); } }

        public float FOV = MathHelper.PiOver4 * 1.5f;
        public float nearClipPlane = 1;
        public float farClipPlane = 200;

        float aspectRatio;

        public Camera3D(Vector3 Position, Vector3 Rotation)
        {
            aspectRatio = Game.graphics.PreferredBackBufferWidth / (float)Game.graphics.PreferredBackBufferHeight;
            Projection = Matrix.CreatePerspectiveFieldOfView(FOV, aspectRatio, nearClipPlane, farClipPlane);

            CameraRotation = Rotation;
            CameraPosition = Position;
        }

        public void LookAt(Vector3 Position)
        {
            LocalMatrix = Matrix.CreateLookAt(CamPos, Position, Up) * Matrix.CreateTranslation(CamPos);
        }
    }
}
