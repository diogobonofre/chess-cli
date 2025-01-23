namespace CLI;

internal static class Program
{
    public static void Main()
    {
        var whitePlayer = new Player(Color.White, "Diogo");
        var blackPlayer = new Player(Color.Black, "Pamela");

        var controller = new GameController(whitePlayer, blackPlayer);

        controller.SetupGame();

        UserInterface.ShowMoves(controller, whitePlayer);
        UserInterface.ShowMoves(controller, blackPlayer);
    }
}