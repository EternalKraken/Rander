/////////////////////////////////////
///          Base Script          ///
///          Use: Random          ///
///         Attatch: Base         ///
/////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rander
{
    public class Rand : Component
    {

        static Random Random;

        public override void Start()
        {
            Random = new Random(DateTime.Now.Millisecond + DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year);
        }

        public static int RandomInt(int Min, int Max)
        {
            return Random.Next(Min, Max);
        }

        public static float RandomFloat(float Min, float Max)
        {
            return (float)(Random.NextDouble() * (Max - Min) + Min);
        }

        public static double RandomDouble(double Min, double Max)
        {
            return Random.NextDouble() * (Max - Min) + Min;
        }
    }
}
