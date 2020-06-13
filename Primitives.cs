using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace AnimationInterpolation
{
    class Primitives
    {
        public static Texture2D point;
        public static Texture2D circle;

        public static void Load(ContentManager content,GraphicsDevice device)
        {
            point = new Texture2D(device, 1, 1);
            point.SetData<Color>(new Color[] { Color.White });

            circle = content.Load<Texture2D>(@"./Graphics/circle");
            Color[] colors = new Color[circle.Width * circle.Height];
            circle.GetData(colors);
            circle.SetData(colors.Select(c => { if (c.A > 0) return new Color(255, 255, 255); return c;}).ToArray());

        }

        public static void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end,Color color,int weight = 1)
        {
            Vector2 edge = end - start;

            float angle = (float)Math.Atan2(edge.Y, edge.X);


            sb.Draw(point,
                new Rectangle(
                    (int)start.X,
                    (int)start.Y,
                    (int)edge.Length(),
                    weight),
                null,
                color,
                angle,    
                new Vector2(0, 0),
                SpriteEffects.None,
                0);
        }


        public static void DrawEllipse(SpriteBatch sb, Vector2 position, Color color, int width = 50,int height = 50,bool centerMode = false)
        {
            if (!centerMode)
            {
                
                sb.Draw(circle,
                    new Rectangle(
                        (int)position.X - width / 2,
                        (int)position.Y - height / 2,
                        width,
                        height),
                    null,
                    color,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0);
                return;
            }
            sb.Draw(circle,
                    new Rectangle(
                        (int)position.X,
                        (int)position.Y,
                        width,
                        height),
                    null,
                    color,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0);

        }
    }


    
}
