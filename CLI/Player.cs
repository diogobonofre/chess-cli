namespace CLI;

public class Player(Color color, string name)
{
    public Color Color { get; set; } = color;
    public string Name { get; set; } = name;
    public List<Piece> Pieces { get; set; } = [];
    public List<Piece> CapturedPieces { get; set; } = [];
}