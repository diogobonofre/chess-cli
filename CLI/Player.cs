namespace CLI {
  internal class Player {
    public Color Color { get; set; }
    public string Name { get; set; }
    public List<Piece> Pieces { get; set; }

    public Player(Color color, string name, List<Piece> pieces) {
      Color = color;
      Name = name;
      Pieces = pieces;
    }
  }
}
