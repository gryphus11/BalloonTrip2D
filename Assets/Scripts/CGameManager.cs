using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CGameManager : MonoBehaviour
{
    public static Transform playerTransform = null;
    public static bool isGameStop = false;
    public Animator backGroundAnimator = null;
    public Text balloonCountText = null;

    // Use this for initialization
    void Start()
    {
        GameObject playerObject = GameObject.Find("BalloonMan");
        playerTransform = playerObject == null ? null : playerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStop)
            backGroundAnimator.speed = 0.0f;
    }

    public void ScoreUp()
    {
        int balloonCount = int.Parse(balloonCountText.text);

        ++balloonCount;

        balloonCountText.text = balloonCount.ToString();

        HighScoreSave();
    }

    private void HighScoreSave()
    {
        string highScoreText = PlayerPrefs.GetString("HIGH_SCORE", "0");
        string currentScoreText = balloonCountText.text;

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

    private void OnDestroy()
    {
        playerTransform = null;
    }
}
