using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public Text enteredText;

    public void SetName()
    {
        DataManager.Instance.playerName = enteredText.text;
    }

    public void StartGame()
    {
        SetName();
        SceneManager.LoadScene(1);
    }
}
