using System.Collections.Generic;
using UnityEngine;

public class DominoBoard : MonoBehaviour
{
    public List<DominoTile> Tiles = new List<DominoTile>();

    public int LeftValue => Tiles.Count > 0 ? Tiles[0].Left : -1;
    public int RightValue => Tiles.Count > 0 ? Tiles[Tiles.Count - 1].Right : -1;

    public bool CanPlaceLeft(DominoTile tile)
    {
        if (Tiles.Count == 0)
            return true;

        return tile.Left == LeftValue || tile.Right == LeftValue;
    }

    public bool CanPlaceRight(DominoTile tile)
    {
        if (Tiles.Count == 0)
            return true;

        return tile.Left == RightValue || tile.Right == RightValue;
    }

    public void PlaceLeft(DominoTile tile)
    {
        if (Tiles.Count == 0)
        {
            Tiles.Add(tile);
            return;
        }

        if (tile.Right == LeftValue)
            Tiles.Insert(0, tile);
        else if (tile.Left == LeftValue)
            Tiles.Insert(0, tile.Flip());
    }

    public void PlaceRight(DominoTile tile)
    {
        if (Tiles.Count == 0)
        {
            Tiles.Add(tile);
            return;
        }

        if (tile.Left == RightValue)
            Tiles.Add(tile);
        else if (tile.Right == RightValue)
            Tiles.Add(tile.Flip());
    }
}
