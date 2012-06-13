using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Perplexity.Component
{
    public class Timer
    {
        private static List<Timer> Timers = new List<Timer>();
        private float interval, remaining;

        public event NotifyHandler Fire;

        public void Start(float interval)
        {
            Timers.Remove(this);
            Timers.Add(this);
            this.interval = interval;
            this.remaining = interval;
        }
        public void Stop()
        {
            Timers.Remove(this);
        }

        public static void Update(GameTime gameTime)
        {
            for (int i = Timers.Count - 1; i >= 0; i--)
            {
                Timer timer = Timers[i];

                timer.remaining -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (timer.remaining <= 0)
                {
                    if (timer.Fire != null)
                        timer.Fire();

                    timer.remaining = timer.interval;
                }
            }
        }
    }
}
