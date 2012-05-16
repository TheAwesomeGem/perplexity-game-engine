using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Perplexity
{
    public abstract class Animation : Entity.Sprite
    {
        #region Enum

        #endregion


        #region Field

        //Protected
        protected bool frameEnabled;
        protected Point frameSize;
        protected Point currentFrame;
       

        #endregion


        #region Property

        #endregion


        public Animation(Texture2D texture, Vector2 position, bool frameEnabled, float rotation = 0f)
            : base(texture, position, rotation)
        {
            this.frameEnabled = frameEnabled;    
        }   
            

        #region Method

        public void SetFrame(Point frame)
        {
            if(frameEnabled)
                currentFrame = frame;
        }

        #endregion


        #region Event

        public override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);

            if (frameEnabled)
                base.sourceRectangle = new Rectangle(frameSize.X * currentFrame.X, frameSize.Y * currentFrame.Y, frameSize.X, frameSize.Y);
            else
                base.sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        #endregion
    }
}
