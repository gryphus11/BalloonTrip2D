using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CGameOverManager : MonoBehaviour
{
    public Text _bestScoreText;
    // Use this for initialization
    void Start()
    {
        _bestScoreText.text = PlayerPrefs.GetString("HIGH_SCORE", "0");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnReStartButtonClick()
    {
        CGameManager.IsGameStop = false;
        SceneManager.LoadScene("Game");
    }
}
