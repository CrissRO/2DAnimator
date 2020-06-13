using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimationInterpolation
{
    class Joint
    {
        public Vector2 position { get; set; }

        public Joint(Vector2 position)
        {
            this.position = position;
        }

        public void Draw(SpriteBatch sb)
        {
            Primitives.DrawEllipse(sb, position, Color.Green);
        }

    }
}
