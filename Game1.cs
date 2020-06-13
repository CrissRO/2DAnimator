using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimationInterpolation
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Rig rig1, rig2, rig3;
        int frames = 20;
        double f = 1;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            rig1 = new Rig(new Vector2(100, 100));
            rig2 = new Rig(new Vector2(300, 100));
            rig3 = new Rig(new Vector2(100, 300));

            rig1.AddJoint(new Joint(new Vector2(0, 0)));
            rig1.AddJoint(new Joint(new Vector2(0,100)));
            rig1.AddBone(0, 1);

            rig2.AddJoint(new Joint(new Vector2(0, 0)));
            rig2.AddJoint(new Joint(new Vector2(-100, -100)));
            rig2.AddBone(0, 1);


            rig3.AddJoint(new Joint(new Vector2(0, 0)));
            rig3.AddJoint(new Joint(new Vector2(0, 100)));
            rig3.AddBone(0, 1);

        }

        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Primitives.Load(Content,GraphicsDevice);
        }

        
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            f += 15 * gameTime.ElapsedGameTime.TotalSeconds;
            f %= frames;

            rig3.AnimateJointLinear(1, rig1, rig2, frames,(int)f);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();

            rig1.Draw(spriteBatch);
            rig2.Draw(spriteBatch);
            rig3.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
