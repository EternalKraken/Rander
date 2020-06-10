using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rander._2D
{
    public class Component2D : Component
    {
        new public Object2D Parent;

        Alignment Al;
        public Vector2 Pivot;
        public Alignment Align { get { return Al; } set { SetAlign(value); } }

        public virtual void SetAlign(Alignment al)
        {
            Al = al;
            switch (al)
            {
                case Alignment.TopLeft:
                    Pivot = new Vector2(0, 0);
                    break;
                case Alignment.TopCenter:
                    Pivot = new Vector2(Parent.Size.X / 2, 0);
                    break;
                case Alignment.TopRight:
                    Pivot = new Vector2(Parent.Size.X, 0);
                    break;
                case Alignment.MiddleLeft:
                    Pivot = new Vector2(0, Parent.Size.Y / 2);
                    break;
                case Alignment.Center:
                    Pivot = new Vector2(Parent.Size.X / 2, Parent.Size.Y / 2);
                    break;
                case Alignment.MiddleRight:
                    Pivot = new Vector2(Parent.Size.X, Parent.Size.Y / 2);
                    break;
                case Alignment.BottomLeft:
                    Pivot = new Vector2(0, Parent.Size.Y);
                    break;
                case Alignment.BottomCenter:
                    Pivot = new Vector2(Parent.Size.X / 2, Parent.Size.Y);
                    break;
                case Alignment.BottomRight:
                    Pivot = new Vector2(Parent.Size.X, Parent.Size.Y);
                    break;
                default:
                    Pivot = new Vector2(0, 0);
                    break;
            }
        }
    }
}
