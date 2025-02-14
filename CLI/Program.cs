using CLI.Pieces;

namespace CLI;

internal static class Program
{
	public static void Main()
	{
		var whitePlayer = new Player(Color.White, "Diogo");
		var blackPlayer = new Player(Color.Black, "Pamela");

		var controller = new GameController(whitePlayer, blackPlayer);

		var whiteKing = new King(new Coordinate(4, 4), Color.White);
		controller.Board.SetPieceAt(whiteKing.Position, whiteKing);
		whitePlayer.Pieces.Add(whiteKing);

		var blackKing = new King(new Coordinate(4, 5), Color.Black);
		controller.Board.SetPieceAt(blackKing.Position, blackKing);
		blackPlayer.Pieces.Add(blackKing);

		Console.WriteLine(whitePlayer.GetPiecesString());
		Console.WriteLine(whitePlayer.GetCapturedPiecesString());

		Console.WriteLine(blackPlayer.GetPiecesString());
		Console.WriteLine(blackPlayer.GetCapturedPiecesString());

		UserInterface.ShowMoves(controller, whitePlayer);
		UserInterface.ShowMoves(controller, blackPlayer);
	}
}
