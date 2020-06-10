using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rander._2D
{
    public class Image2DComponent : Component2D
    {
        public Texture2D Texture;

        Alignment SetAl;

        public Image2DComponent(Texture2D texture)
        {
            Texture = texture;
        }

        public Image2DComponent(Texture2D texture, Alignment alignment)
        {
            Texture = texture;
            SetAl = alignment;
        }

        public override void Start()
        {
            Align = SetAl;
        }

        public override void Draw()
        {
            MyGame.Drawing.Draw(Texture, new Rectangle((int)Parent.Position.X, (int)Parent.Position.Y, (int)Parent.Size.X, (int)Parent.Size.Y), new Rectangle((int)Parent.Position.X, (int)Parent.Position.Y, (int)Parent.Size.X, (int)Parent.Size.Y), Parent.Color, Parent.Rotation, Pivot, SpriteEffects.None, 0);
        }
    }
}
