namespace CLI.Pieces {
  internal class Knight : Piece {
    public Knight(Coordinate position, Color color) : base(position, color) {
      Sprite = '♞';
    }

    public override List<Coordinate> GetPossibleMoves(Board board) {
      throw new NotImplementedException();
    }
  }
}
