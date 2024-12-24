
namespace CLI.Pieces {
  internal class Queen : Piece {
    public Queen(Coordinate position, Color color) : base(position, color) {
      Sprite = '♛';
    }

    public override List<Coordinate> GetPossibleMoves(Board board) {
      throw new NotImplementedException();
    }
  }
}
