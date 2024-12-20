namespace CLI.Pieces {
  internal class Bishop : Piece {
    public Bishop(Coordinate position, Color color) : base(position, color) {
      Sprite = color == Color.White ? '♝' : '♗';
    }
  }
}