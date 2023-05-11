using UnityEngine;
using System.IO;

[System.Serializable]
public class ScoreData
{
    public int score;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveScore(int score)
    {
        ScoreData data = new ScoreData();
        data.score = score;

        string json = JsonUtility.ToJson(data);

        string path = Application.persistentDataPath + "/score.json";
        File.WriteAllText(path, json);
    }

    public int LoadScore()
    {
        string path = Application.persistentDataPath + "/score.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);

            return data.score;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return 0;
        }
    }
}
