using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Entity
{
    public class Actor : Animation
    {
        #region Enum

        #endregion


        #region Field
        
        //Private

        //Public
        public readonly Point Size;
       
        #endregion


        #region Property

        public Vector2 Position 
        {
            get { return base.position; }
            set { base.position = value; }
        }

        #endregion


        public Actor(Texture2D texture, Vector2 position, bool frameEnabled, float rotation = 0f)
            : base(texture, position, frameEnabled, rotation)
        {
            Size = new Point(texture.Width, texture.Height);

            ActorManager.actors.Add(this);
        }


        #region Method

        public void SetFrameIndex(Point frame)
        {
            base.SetFrame(frame);
        }

        public bool ColidingWith(Actor actor)
        {
            return base.rectangle.Intersects(actor.rectangle);
        }

        #endregion


        #region Event

        #endregion
    }
}
