using Rander._2D;
using Rander;
using System;
using Microsoft.Xna.Framework;

namespace ExampleGame.Scripts
{
    class CursorReplacement : Component2D
    {
        float PulseMagnitude = 3;
        float PulseSpeed = 3;
        float BaseSize = 10;

        public int i;

        float Timer = 0;

        public override void Start()
        {
            MouseInput.IsVisible = false;
        }

        public override void Update()
        {
            Parent.Position = MouseInput.Position.ToVector2();
            Parent.Rotation += 15 * Time.FrameTime;
            Parent.Size = new Vector2((float)Math.Sin(Time.TimeSinceStart * PulseSpeed) * PulseMagnitude + BaseSize + PulseMagnitude, (float)Math.Sin(Time.TimeSinceStart * PulseSpeed) * PulseMagnitude + BaseSize + PulseMagnitude);

            if (Time.TimeSinceStart > Timer) {
                new Object2D("P" + i, Parent.Position, new Vector2(10, 10), Rand.RandomFloat(0, 90), Color.Blue, 0.95f, new Component2D[] { new Image2DComponent(DefaultValues.PixelTexture, Alignment.Center), new ExplosionParticles(i) });
                i++;
                Timer += 0.01f;
            }
        }
    }
}
