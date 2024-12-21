namespace CLI.Pieces {
  internal class Rook : Piece {
    public Rook(Coordinate position, Color color) : base(position, color) {
      Sprite = '♜';
    }
  }
}
