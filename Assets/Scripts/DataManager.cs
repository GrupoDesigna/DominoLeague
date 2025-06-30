using System.IO;
using UnityEngine;

[System.Serializable]
public class PlayerProgress
{
    public int Coins;
    public int Level;

    public PlayerProgress(int coins = 0, int level = 1)
    {
        Coins = coins;
        Level = level;
    }
}

public static class DataManager
{
    private static string FilePath => Path.Combine(Application.persistentDataPath, "player_progress.json");

    public static void SaveProgress(PlayerProgress progress)
    {
        string json = JsonUtility.ToJson(progress);
        File.WriteAllText(FilePath, json);
    }

    public static PlayerProgress LoadProgress()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            return JsonUtility.FromJson<PlayerProgress>(json);
        }
        return new PlayerProgress();
    }
}
