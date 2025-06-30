using System.Collections.Generic;
using UnityEngine;

public class DominoBoard : MonoBehaviour
{
    public List<DominoTile> Tiles = new List<DominoTile>();

    public void AddTile(DominoTile tile)
    {
        Tiles.Add(tile);
    }
}
