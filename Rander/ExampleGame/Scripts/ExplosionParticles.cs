using Microsoft.Xna.Framework;
using Rander;
using Rander._2D;

namespace ExampleGame.Scripts
{
    class ExplosionParticles : Component2D
    {
        float InitRotation = Rand.RandomFloat(0, 90);
        float RotateSpeed = Rand.RandomFloat(-5, 5);
        Vector2 Direction = new Vector2(Rand.RandomFloat(-3, 3), Rand.RandomFloat(-3, 3));
        float KillTimer;

        int ID;

        public ExplosionParticles(int ParticleID)
        {
            ID = ParticleID;
        }

        public override void Start()
        {
            Parent.Position = MouseInput.Position.ToVector2();
            Parent.Rotation = InitRotation;
            KillTimer = Time.TimeSinceStart + 0.2f;
        }

        public override void Update()
        {
            Parent.Position += Direction * Time.FrameTime * 10;
            Parent.Rotation += RotateSpeed * Time.FrameTime * 2;
            if (Time.TimeSinceStart > KillTimer)
            {
                Parent.Color.A -= 5;
                KillTimer = Time.TimeSinceStart + 0.01f;
            }

            if (Parent.Color.A <= 0)
            {
                if (ID == int.MaxValue - 1) {
                    Rander.Game.FindObject2D("Cursor").GetComponent<CursorReplacement>().i = 0;
                }

                Parent.Destroy();
            }
        }
    }
}
