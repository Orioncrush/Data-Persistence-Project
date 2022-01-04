using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public Text enteredText;

    public void SetName(string nameText)
    {
        DataManager.Instance.playerName = nameText;
    }

    public void StartGame()
    {
        SetName(enteredText.text);
        SceneManager.LoadScene(1);
    }

    public void ResetHighScore()
    {
        DataManager.Instance.ResetHighScores();
    }
}
