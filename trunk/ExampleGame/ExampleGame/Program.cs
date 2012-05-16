using System;

namespace ExampleGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Primary game = new Primary())
            {
                game.Run();
            }
        }
    }
#endif
}

