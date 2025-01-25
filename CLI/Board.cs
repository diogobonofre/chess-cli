﻿namespace CLI;

public class Board
{
    public Piece?[,] Grid { get; private set; } = new Piece[8, 8];

    public Piece? GetPieceAt(Coordinate position)
    {
        return Grid[position.X, position.Y];
    }

    public void SetPieceAt(Coordinate position, Piece piece)
    {
        if (GetPieceAt(position) != null)
        {
            Console.WriteLine($"The coordinate ({position.X}, {position.Y}) already has a piece.");
            return;
        }

        Grid[position.X, position.Y] = piece;
    }

    public void RemovePieceAt(Coordinate position)
    {
        if (GetPieceAt(position) != null) Grid[position.X, position.Y] = null;
    }

    public void PlacePlayerPieces(Player player)
    {
        foreach (var piece in player.Pieces)
        {
            SetPieceAt(piece.Position, piece);
        }
    }
}