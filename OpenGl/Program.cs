
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenGl
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello world");
            using (Game game = new Game(1000, 1000))
            {
                game.Run();
            }
        }

    
    }
}