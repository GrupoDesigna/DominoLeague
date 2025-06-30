using System.Collections.Generic;

[System.Serializable]
public class Player
{
    public string Name;
    public List<DominoTile> Hand = new List<DominoTile>();

    public Player(string name)
    {
        Name = name;
    }

    public void AddTile(DominoTile tile)
    {
        Hand.Add(tile);
    }

    public bool PlayTile(DominoTile tile, DominoBoard board, bool placeLeft)
    {
        if (!Hand.Contains(tile))
            return false;

        bool canPlace = placeLeft ? board.CanPlaceLeft(tile) : board.CanPlaceRight(tile);
        if (!canPlace)
            return false;

        if (placeLeft)
            board.PlaceLeft(tile);
        else
            board.PlaceRight(tile);

        Hand.Remove(tile);
        return true;
    }
}
