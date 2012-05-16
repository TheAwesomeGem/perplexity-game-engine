using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Perplexity
{
    public abstract class Base : Game
    {
        #region Enum

        #endregion


        #region Field

        //General
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        #endregion


        #region Property

        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        public Color ScreenColor { get; set; }

        #endregion


        public Base()
        {
            //TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 100);

            ScreenWidth = 640;
            ScreenHeight = 480;
            ScreenColor = Color.Black;

            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }


        #region Method

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.ApplyChanges();

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void UnloadContent()
        {
            
        }

        #endregion


        #region Event

        protected override void Update(GameTime gameTime)
        {
            Entity.ActorManager.OnUpdate(gameTime);

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(ScreenColor);


            spriteBatch.Begin();

            Entity.ActorManager.OnDraw(spriteBatch);

            spriteBatch.End();


            base.Draw(gameTime);
        }

        #endregion
    }
}
