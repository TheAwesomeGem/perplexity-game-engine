using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Entity
{
    public static class SpriteManager
    {
        #region Enum

        #endregion


        #region Field
        
        //Public
        public static List<Sprite> sprites = new List<Sprite>();
       
        #endregion


        #region Property

        #endregion


        #region Method

        public static void Remove(Sprite sprite)
        {
            sprites.Remove(sprite);
        }

        #endregion


        #region Event

        #endregion
    }
}
