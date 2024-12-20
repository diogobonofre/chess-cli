namespace CLI.Pieces {
  internal class Queen : Piece {
    public Queen(Coordinate position, Color color) : base(position, color) {
      Sprite = color == Color.White ? '♛' : '♕';
    }
  }
}
