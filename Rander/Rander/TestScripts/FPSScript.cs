using Rander._2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rander.TestScripts
{
    class FPSScript : Component2D
    {

        float TimeToPass;
        int FramesPassed = 0;

        public override void Draw()
        {
            if ((float)Game.Gametime.TotalGameTime.TotalSeconds > TimeToPass)
            {
                Parent.GetComponent<Text2DComponent>().Txt = "FPS: " + FramesPassed;
                TimeToPass += 1;
                FramesPassed = 0;
            } else
            {
                FramesPassed += 1;
            }
        }
    }
}
