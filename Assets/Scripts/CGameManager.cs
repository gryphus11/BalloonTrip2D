using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CGameManager : MonoBehaviour
{
    public static bool IsGameStop = false;
    public Animator _backGroundAnimator;
    public Text _balloonCountText;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameStop)
            _backGroundAnimator.speed = 0.0f;
    }

    public void ScoreUp()
    {
        int balloonCount = int.Parse(_balloonCountText.text);

        ++balloonCount;

        _balloonCountText.text = balloonCount.ToString();

        HighScoreSave();
    }

    private void HighScoreSave()
    {
        string highScoreText = PlayerPrefs.GetString("HIGH_SCORE", "0");
        string currentScoreText = _balloonCountText.text;

        int highScore = int.Parse(highScoreText);
        int currentScore = int.Parse(currentScoreText);

        if (highScore < currentScore)
        {
            PlayerPrefs.SetString("HIGH_SCORE", currentScore.ToString());
            PlayerPrefs.Save();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
