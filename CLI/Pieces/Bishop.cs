namespace CLI.Pieces;

public class Bishop : Piece
{
    public Bishop(Coordinate position, Color color) : base(position, color)
    {
        Sprite = '♝';
    }

    public override List<Coordinate> GetPossibleMoves(GameController controller)
    {
        var possibleMoves = new List<Coordinate>();

        var topRight = false;
        var topLeft = false;
        var bottomRight = false;
        var bottomLeft = false;

        for (var i = 1; i < 8; i++)
        {
            if (!topRight && IsWithinBounds(Position.X + i, Position.Y + i))
            {
                if (controller.Board.GetPieceAt(new Coordinate(Position.X + i, Position.Y + i)) != null)
                    topRight = true;
                possibleMoves.Add(new Coordinate(Position.X + i, Position.Y + i));
            }

            if (!topLeft && IsWithinBounds(Position.X + i, Position.Y - i))
            {
                if (controller.Board.GetPieceAt(new Coordinate(Position.X + i, Position.Y - i)) != null) topLeft = true;
                possibleMoves.Add(new Coordinate(Position.X + i, Position.Y - i));
            }

            if (!bottomRight && IsWithinBounds(Position.X - i, Position.Y + i))
            {
                if (controller.Board.GetPieceAt(new Coordinate(Position.X - i, Position.Y + i)) != null)
                    bottomRight = true;
                possibleMoves.Add(new Coordinate(Position.X - i, Position.Y + i));
            }

            if (!bottomLeft && IsWithinBounds(Position.X - i, Position.Y - i))
            {
                if (controller.Board.GetPieceAt(new Coordinate(Position.X - i, Position.Y - i)) != null)
                    bottomLeft = true;
                possibleMoves.Add(new Coordinate(Position.X - i, Position.Y - i));
            }
        }

        return possibleMoves;
    }
}