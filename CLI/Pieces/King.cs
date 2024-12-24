namespace CLI.Pieces {
  internal class King : Piece {
    public King(Coordinate position, Color color) : base(position, color) {
      Sprite = '♚';
    }

    public override List<Coordinate> GetPossibleMoves(Board board) {
      throw new NotImplementedException();
    }
  }
}
