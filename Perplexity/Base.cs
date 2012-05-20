using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Perplexity
{
    public class Base : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        protected Component.CameraManager Camera;

        /// <summary>
        /// Get/Set the width of screen.
        /// </summary>
        public int ScreenWidth { get; set; }

        /// <summary>
        /// Get/Set the height of screen.
        /// </summary>
        public int ScreenHeight { get; set; }

        /// <summary>
        /// Get/Set the content directory where the content files will be located.
        /// </summary>
        public string ContentDir { get; set; }

        /// <summary>
        /// Get/Set the color of the screen.
        /// </summary>
        public Color ScreenColor { get; set; }

        public Base()
        {
            //Default Values
            ScreenWidth = 640;
            ScreenHeight = 480;
            ScreenColor = Color.Black;
            ContentDir = "Content";

            graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.ApplyChanges();

            Content.RootDirectory = ContentDir;

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);  
        }
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            Camera.OnUpdate(graphics.GraphicsDevice, gameTime);

            Entity.ActorManager.OnUpdate(gameTime);

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(ScreenColor);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, Camera.Transform);

            Entity.ActorManager.OnDraw(spriteBatch);

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
