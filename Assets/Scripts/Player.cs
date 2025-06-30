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
}
