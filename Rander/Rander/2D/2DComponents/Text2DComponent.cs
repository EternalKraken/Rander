using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rander._2D
{
    public class Text2DComponent : Component2D
    {
        public string Txt = "";
        public float FontSize = 1;
        SpriteFont Font = DefaultValues.DefaultFont;

        Alignment Al;
        new public Vector2 Pivot;
        new public Alignment Align { get { return Al; } set { SetAlign(value); } }

        public Text2DComponent(string text)
        {
            Txt = text;
        }

        public Text2DComponent(string text, SpriteFont font)
        {
            Txt = text;
            Font = font;
        }

        public Text2DComponent(string text, float fontSize)
        {
            Txt = text;
            FontSize = fontSize;
        }

        public Text2DComponent(string text, float fontSize, SpriteFont font)
        {
            Txt = text;
            FontSize = fontSize;
            Font = font;
        }

        public Text2DComponent(string text, float fontSize, Alignment alignment)
        {
            Txt = text;
            SetAlign(alignment);
            FontSize = fontSize;
        }

        public Text2DComponent(string text, float fontSize, SpriteFont font, Alignment alignment)
        {
            Txt = text;
            SetAlign(alignment);
            FontSize = fontSize;
            Font = font;
        }

        public override void SetAlign(Alignment al)
        {
            Al = al;
            switch (al)
            {
                case Alignment.TopLeft:
                    Pivot = new Vector2(0, 0);
                    break;
                case Alignment.TopCenter:
                    Pivot = new Vector2(Font.MeasureString(Txt).X / 2, 0);
                    break;
                case Alignment.TopRight:
                    Pivot = new Vector2(Font.MeasureString(Txt).X, 0);
                    break;
                case Alignment.MiddleLeft:
                    Pivot = new Vector2(0, Font.MeasureString(Txt).Y / 2);
                    break;
                case Alignment.Center:
                    Pivot = new Vector2(Font.MeasureString(Txt).X / 2, Font.MeasureString(Txt).Y / 2);
                    break;
                case Alignment.MiddleRight:
                    Pivot = new Vector2(Font.MeasureString(Txt).X, Font.MeasureString(Txt).Y / 2);
                    break;
                case Alignment.BottomLeft:
                    Pivot = new Vector2(0, Font.MeasureString(Txt).Y);
                    break;
                case Alignment.BottomCenter:
                    Pivot = new Vector2(Font.MeasureString(Txt).X / 2, Font.MeasureString(Txt).Y);
                    break;
                case Alignment.BottomRight:
                    Pivot = new Vector2(Font.MeasureString(Txt).X, Font.MeasureString(Txt).Y);
                    break;
                default:
                    Pivot = new Vector2(0, 0);
                    break;
            }
        }

        public override void Draw()
        {
            MyGame.Drawing.DrawString(Font, Txt, Parent.Position, Parent.Color, Parent.Rotation, Pivot, FontSize, SpriteEffects.None, 0);
        }
    }
}

public enum Alignment
{
    TopLeft = 0,
    TopCenter = 1,
    TopRight = 2,
    MiddleLeft = 3,
    Center = 4,
    MiddleRight = 5,
    BottomLeft = 6,
    BottomCenter = 7,
    BottomRight = 8
}
