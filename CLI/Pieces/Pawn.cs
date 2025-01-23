namespace CLI.Pieces;

internal class Pawn : Piece {
  public Pawn(Coordinate position, Color color) : base(position, color) {
    Sprite = '♟';
  }

  public override List<Coordinate> GetPossibleMoves(GameController controller) {
    var possibleMoves = new List<Coordinate>();

    if (Color == Color.White) {
      if (IsWithinBounds(Position.X + 1, Position.Y)) {
        possibleMoves.Add(new Coordinate(Position.X + 1, Position.Y));
      }
      if (IsWithinBounds(Position.X + 1, Position.Y + 1)
          && controller.Board.GetPieceAt(new Coordinate(Position.X + 1, Position.Y + 1)) != null) {
        possibleMoves.Add(new Coordinate(Position.X + 1, Position.Y + 1));
      }
      if (IsWithinBounds(Position.X + 1, Position.Y - 1)
          && controller.Board.GetPieceAt(new Coordinate(Position.X + 1, Position.Y - 1)) != null) {
        possibleMoves.Add(new Coordinate(Position.X + 1, Position.Y - 1));
      }
    } else {
      if (IsWithinBounds(Position.X - 1, Position.Y)) {
        possibleMoves.Add(new Coordinate(Position.X - 1, Position.Y));
      }
      if (IsWithinBounds(Position.X - 1, Position.Y - 1)
          && controller.Board.GetPieceAt(new Coordinate(Position.X - 1, Position.Y - 1)) != null) {
        possibleMoves.Add(new Coordinate(Position.X - 1, Position.Y - 1));
      }
      if (IsWithinBounds(Position.X - 1, Position.Y + 1)
          && controller.Board.GetPieceAt(new Coordinate(Position.X - 1, Position.Y + 1)) != null) {
        possibleMoves.Add(new Coordinate(Position.X - 1, Position.Y + 1));
      }
    }

    return possibleMoves;
  }
}