namespace CLI.Pieces;

public class King : Piece
{
    public King(Coordinate position, Color color) : base(position, color)
    {
        Sprite = '♚';
    }

    // TODO: Refactor to reuse existing Bishop and Rook movement logic
    public override List<Coordinate> GetPossibleMoves(GameController controller)
    {
        var possibleMoves = new List<Coordinate>();

        if (IsWithinBounds(Position.X + 1, Position.Y))
        {
            possibleMoves.Add(new Coordinate(Position.X + 1, Position.Y));
        }

        if (IsWithinBounds(Position.X - 1, Position.Y))
        {
            possibleMoves.Add(new Coordinate(Position.X - 1, Position.Y));
        }

        if (IsWithinBounds(Position.X, Position.Y + 1))
        {
            possibleMoves.Add(new Coordinate(Position.X, Position.Y + 1));
        }

        if (IsWithinBounds(Position.X, Position.Y - 1))
        {
            possibleMoves.Add(new Coordinate(Position.X, Position.Y - 1));
        }

        if (IsWithinBounds(Position.X + 1, Position.Y + 1))
        {
            possibleMoves.Add(new Coordinate(Position.X + 1, Position.Y + 1));
        }

        if (IsWithinBounds(Position.X + 1, Position.Y - 1))
        {
            possibleMoves.Add(new Coordinate(Position.X + 1, Position.Y - 1));
        }

        if (IsWithinBounds(Position.X - 1, Position.Y + 1))
        {
            possibleMoves.Add(new Coordinate(Position.X - 1, Position.Y + 1));
        }

        if (IsWithinBounds(Position.X - 1, Position.Y - 1))
        {
            possibleMoves.Add(new Coordinate(Position.X - 1, Position.Y - 1));
        }

        return possibleMoves;
    }
}