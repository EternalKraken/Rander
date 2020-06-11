/////////////////////////////////////
///          Base Script          ///
///       Use: Mouse Handle       ///
///         Attatch: Base         ///
/////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Rander
{
    public class MouseInput : Component
    {
        public static MouseState MouseInfo;
        public static Point Position { get { return MouseInfo.Position; } }
        public static Point PositionDelta { get { return MouseDelta; } }
        public static bool IsVisible { get { return Game.gameWindow.IsMouseVisible; } set { SetVisibility(value); } }
        public static bool CursorLocked { set { Lck = value; } get { return Lck; } }
        static bool Lck = false;
        static Point MousePrev;
        static Point MouseDelta;

        public override void Start()
        {
            SetVisibility(true);
        }

        public override void Update()
        {
            MouseInfo = Mouse.GetState();
            MouseDelta = MousePrev - MouseInfo.Position;

            if (Lck == true)
            {
                SetPosition(Screen.Width / 2, Screen.Height / 2);
            }

            MousePrev = MouseInfo.Position;
        }

        public static void SetPosition(Point position)
        {
            Mouse.SetPosition(position.X, position.Y);
        }

        public static void SetPosition(int X, int Y)
        {
            Mouse.SetPosition(X, Y);
        }

        public static void ChangeCursor(MouseCursor cursor)
        {
            Mouse.SetCursor(cursor);
        }

        public static void SetVisibility(bool visible)
        {
            Game.gameWindow.IsMouseVisible = visible;
        }
    }
}
