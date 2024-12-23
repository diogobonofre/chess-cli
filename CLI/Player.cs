namespace CLI {
  public class Player {
    public Color Color { get; set; }
    public string Name { get; set; }
    public List<Piece> Pieces { get; set; } = [];
    public List<Piece> CapturedPieces { get; set; } = [];

    public Player(Color color, string name) {
      Color = color;
      Name = name;
    }
  }
}
