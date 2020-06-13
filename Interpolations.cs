using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimationInterpolation
{
    class Interpolations
    {
        public static float Linear(double x0, double x1, int n, int f)
        {
            if (f < 0 || f > n)
                return 0;
            return (float)(x0 + f * ((x1 - x0) / n));
        }
    }
}
