using System.Linq;

namespace AncientCave.Main;

public static class Program
{
    private static void Main(string[] args)
    {
        var debugMode = args.Contains("--debug");

        var game = Game1.Instance;

        // Assuming that Game1 class has a DebugMode property.
        // If not, you will need to add it to the Game1 class.
        // Or any other way to enable debug functionality.
        //game.DebugMode = debugMode;

        game.Run();
    }
}