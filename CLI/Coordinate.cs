namespace CLI {
  public class Coordinate {
    private int _x;
    private int _y;

    public int X {
      get => _x;
      set {
        if (value < 0 || value > 7) {
          throw new ArgumentOutOfRangeException(nameof(value), "X must be between 0 and 7.");
        }
        _x = value;
      }
    }

    public int Y {
      get => _y;
      set {
        if (value < 0 || value > 7) {
          throw new ArgumentOutOfRangeException(nameof(value), "Y must be between 0 and 7.");
        }
        _y = value;
      }
    }

    public Coordinate(int x, int y) {
      X = x; // Atribuição utiliza o setter, portanto a validação é automática
      Y = y; // Atribuição utiliza o setter, portanto a validação é automática
    }

    public override string ToString() {
      return $"{(char)('A' + X)}{Y + 1}";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="coordinate"></param>
    /// <returns></returns>
    public static Coordinate FromString(string coordinate) {
      return new Coordinate(coordinate[0] - 'A', coordinate[1] - '1');
    }

    public override bool Equals(object? obj) {
      if (obj is Coordinate other) return X == other.X && Y == other.Y;
      return false;
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);

    public static bool operator ==(Coordinate left, Coordinate right) {
      if (ReferenceEquals(left, right)) return true;
      if (left is null || right is null) return false;
      return left.Equals(right);
    }

    public static bool operator !=(Coordinate left, Coordinate right) {
      return !(left == right);
    }
  }
}
