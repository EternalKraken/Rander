using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Rander._3D
{
    public class MeshRenderer3DComponent : Component3D
    {
        public VertexPositionTexture[] Vertexes;
        public BasicEffect ObjectRender;

        public MeshRenderer3DComponent(VertexPositionTexture[] vertexes)
        {
            ObjectRender = new BasicEffect(Game.graphics.GraphicsDevice);
            Vertexes = vertexes;
        }

        public MeshRenderer3DComponent(VertexPositionTexture[] vertexes, Color color)
        {
            ObjectRender = new BasicEffect(Game.graphics.GraphicsDevice);
            Vertexes = vertexes;
            ObjectRender.DiffuseColor = color.ToVector3();
        }

        public override void Draw()
        {
            // Updates the object's matrix
            ObjectRender.World = Matrix.CreateScale(Parent.Size) * Matrix.CreateFromYawPitchRoll(Parent.Rotation.X, Parent.Rotation.Y, Parent.Rotation.Z) * Matrix.CreateTranslation(Parent.Position);

            // Sets the object for rendering
            ObjectRender.View = Game.Cam3D.LocalMatrix;
            ObjectRender.Projection = Game.Cam3D.Projection;

            foreach (EffectPass pass in ObjectRender.CurrentTechnique.Passes)
            {
                pass.Apply();
                Game.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Vertexes, 0, Vertexes.Length / 3);
            }
        }
    }

    public class Primitives
    {
        public static VertexPositionTexture[] Plane = new VertexPositionTexture[] {
            new VertexPositionTexture(new Vector3(-1, -1, 0), new Vector2(-1, -1)),
            new VertexPositionTexture(new Vector3(-1, 1, 0), new Vector2(-1, 1)),
            new VertexPositionTexture(new Vector3(1, -1, 0), new Vector2(1, -1)),
            new VertexPositionTexture(new Vector3(-1, 1, 0), new Vector2(-1, 1)),
            new VertexPositionTexture(new Vector3(1, 1, 0), new Vector2(1, 1)),
            new VertexPositionTexture(new Vector3(1, -1, 0), new Vector2(1, -1))
        };
    }
}
