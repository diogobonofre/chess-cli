namespace CLI;

public class Player(Color color, string name)
{
    public Color Color { get; set; } = color;
    public string Name { get; set; } = name;
    public List<Piece> Pieces { get; set; } = [];
    public List<Piece> CapturedPieces { get; set; } = [];

    public string GetPiecesString()
    {
        return Pieces.Count == 0
            ? $"{Color.ToString()} player has no pieces on the board"
            : string.Join(", ", Pieces.Select(p => p.Sprite));
    }

    public string GetCapturedPiecesString()
    {
        return CapturedPieces.Count == 0
            ? $"{Color.ToString()} player has no captures"
            : string.Join(", ", CapturedPieces.Select(p => p.Sprite));
    }
}