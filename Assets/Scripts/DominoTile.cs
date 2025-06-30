using UnityEngine;

[System.Serializable]
public class DominoTile
{
    public int Left;
    public int Right;

    public DominoTile(int left, int right)
    {
        Left = left;
        Right = right;
    }
}
