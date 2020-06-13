using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimationInterpolation
{
    class Bone
    {
        public Vector2 start { get; set; }
        public Vector2 end { get; set; }

        public Bone(Vector2 start,Vector2 end)
        {
            this.start = start;
            this.end = end;
        }

        public void Draw(SpriteBatch sp)
        {
            Primitives.DrawLine(sp, start, end, Color.Red, 5);
        }
    }
}
