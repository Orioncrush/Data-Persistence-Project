using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;

    public int highScore;
    public string bestPlayer;

    string savePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Application.persistentDataPath + "/highscore.json";
            LoadHighScore();
            SaveHighScore();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void SetHighScore(int score, string name)
    {
        highScore = score;
        bestPlayer = name;

        SaveHighScore();
        LoadHighScore();
    }

    private void LoadHighScore()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            highScore = data.highScore;
            bestPlayer = data.playerName;
        }
    }

    private void SaveHighScore()
    {
        HighScoreData data = new HighScoreData();
        data.highScore = highScore;
        data.playerName = bestPlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(savePath, json);
    }

    public void ResetHighScores()
    {
        SetHighScore(0, "Bill Gates");
    }

    [System.Serializable]
    public class HighScoreData
    {
        public int highScore;
        public string playerName;
    }
}
