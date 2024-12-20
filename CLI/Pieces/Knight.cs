namespace CLI.Pieces {
  internal class Knight : Piece {
    public Knight(Coordinate position, Color color) : base(position, color) {
      Sprite = color == Color.White ? '♞' : '♘';
    }
  }
}
