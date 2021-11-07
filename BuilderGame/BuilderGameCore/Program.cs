using System;

namespace BuilderGameCore
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new BuilderGame())
                game.Run();
        }
    }
}
