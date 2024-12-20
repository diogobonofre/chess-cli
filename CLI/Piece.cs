namespace CLI {
  public abstract class Piece {
    public Coordinate Position { get; set; }
    public Color Color { get; set; }
    public char Sprite { get; set; }
    // Piece constructor need to check if the tile is empty in order to create
    // a piece in that coordinate
    protected Piece(Coordinate position, Color color) {
      Position = position;
      Color = color;
    }
  }
}