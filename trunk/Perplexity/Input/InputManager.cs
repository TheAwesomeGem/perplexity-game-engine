using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Perplexity
{
    public static class InputManager
    {
        #region Enum

        #endregion


        #region Field

        //Private        
        private static KeyboardState newState;
        private static KeyboardState oldState;

        #endregion


        #region Property

        #endregion


        #region Method

        public static bool KeyDown(Keys key)
        {
            return newState.IsKeyDown(key) && oldState.IsKeyUp(key);
        }

        public static bool KeyUp(Keys key)
        {
            return newState.IsKeyUp(key) && oldState.IsKeyDown(key);
        }

        public static bool KeyHolding(Keys key)
        {
            return newState.IsKeyDown(key);
        }

        #endregion


        #region Event

        public static void Start()
        {
            newState = Keyboard.GetState();
        }

        public static void End()
        {
            oldState = newState;
        }

        #endregion
    }
}
