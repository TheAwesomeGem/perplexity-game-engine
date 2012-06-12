using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Perplexity.Entity;
using Perplexity.Component;

namespace Perplexity
{
    public class Engine : Game
    {
        private GraphicsDeviceManager graphics;
        private GraphicsDevice device;
        private SpriteBatch spriteBatch;

        protected string ContentDir;
        protected Color ScreenColor;
        protected string ScreenTitle;
        protected Camera Camera;

        public static int ScreenWidth;
        public static int ScreenHeight;

        public Engine()
        {
            ContentDir = "Content";
            ScreenWidth = 640;
            ScreenHeight = 480;
            ScreenColor = Color.CornflowerBlue;
            ScreenTitle = "MyGame";

            graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            Content.RootDirectory = ContentDir;

            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.ApplyChanges();

            Window.Title = ScreenTitle;

            Camera = new Camera();
            
            base.Initialize();
        }
        protected override void LoadContent()
        {
            device = graphics.GraphicsDevice;
            spriteBatch = new SpriteBatch(device);
        }

        protected override void Update(GameTime gameTime)
        {
            Camera.Update(gameTime);
            SceneManager.Update(gameTime);

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            device.Clear(ScreenColor);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, Camera.View);
            SceneManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
