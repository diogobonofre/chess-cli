namespace CLI.Pieces {
  internal class Pawn : Piece {
    public Pawn(Coordinate position, Color color) : base(position, color) {
      Sprite = '♟';
    }

    public override List<Coordinate> GetPossibleMoves(Board board) {
      throw new NotImplementedException();
    }
  }
}
