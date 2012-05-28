using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Perplexity.Entity;

namespace Perplexity.Component
{
    public class AnimationFrame 
    {
        //private float timer;
        //private float interval;
        private int frameWidth, frameHeight;
        private Rectangle source;
        public Point currentFrame;

        public Rectangle Source { get { return source; } }

        public AnimationFrame(Point currentFrame, int frameWidth, int frameHeight /*, float interval = 200f */ )
        {
            this.currentFrame = currentFrame;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            //this.interval = interval;

            source = new Rectangle(frameWidth * currentFrame.X, frameHeight * currentFrame.Y,
                                   frameWidth, frameHeight);
        }

        public void Update(GameTime gameTime)
        {
            source = new Rectangle(frameWidth * currentFrame.X, frameHeight * currentFrame.Y, 
                                   frameWidth, frameHeight);
        }
    }
}
