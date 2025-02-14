namespace CLI.Pieces;

public class King : Piece
{
    public King(Coordinate position, Color color) : base(position, color)
    {
        Sprite = '♚';
    }

    public override List<Coordinate> GetPossibleMoves(GameController controller)
    {
        var possibleMoves = new List<Coordinate>();
        var directions = new (int dx, int dy)[]
        {
            (1, 0), (0, -1), (-1, 0), (0, 1), // cardinal directions
            (1, 1), (1, -1), (-1, -1), (-1, 1) // diagonal directions
        };

        foreach (var (dx, dy) in directions)
        {
            var newX = Position.X + dx;
            var newY = Position.Y + dy;

            if (IsWithinBounds(newX, newY)) possibleMoves.Add(new Coordinate(newX, newY));
        }

        return possibleMoves;
    }
}