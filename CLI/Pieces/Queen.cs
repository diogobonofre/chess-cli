namespace CLI.Pieces;

public class Queen : Piece
{
    public Queen(Coordinate position, Color color) : base(position, color)
    {
        Sprite = '♛';
    }

    public override List<Coordinate> GetPossibleMoves(GameController controller)
    {
        var possibleMoves = new List<Coordinate>();
        var rook = new Rook(Position, Color);
        var bishop = new Bishop(Position, Color);

        possibleMoves.AddRange(rook.GetPossibleMoves(controller));
        possibleMoves.AddRange(bishop.GetPossibleMoves(controller));

        return possibleMoves;
    }
}