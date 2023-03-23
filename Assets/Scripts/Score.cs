using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public TextMeshProUGUI scoreTMP;
    public TextMeshProUGUI highScoreTMP;

    public GameObject GoldBadge;
    public GameObject SilverBadge;
    public GameObject BronzeBadge;
    private const string HIGH_SCORE = "High Score";
    [HideInInspector] public int score;

    void Start()
    {
        ResetScore();
    }
    void DisplayScore()
    {
        scoreText.text = $"{score}";
    }
    void ResetScore()
    {
        score = 0;
        DisplayScore();
    }
    public void ScoreCount()
    {
        score++;
        DisplayScore();
    }
    public void ScoreSubtract()
    {
        score--;
        DisplayScore();
    }
    public void BadgeGain()
    {
        GoldBadge.SetActive(true);
        SilverBadge.SetActive(false);
        BronzeBadge.SetActive(false);

        if (score < GetHighScore() * 0.6) BronzeBadge.SetActive(true);
        else if (score < GetHighScore()) SilverBadge.SetActive(true);
        else GoldBadge.SetActive(true);
    }
    public void FinalScore()
    {
        BadgeGain();
        scoreTMP.text = $"Your Score: {score}";
        if (score > GetHighScore())
        {
            SetHighScore(score);
        }
        highScoreTMP.text = $"High Score: {GetHighScore()}";
    }
    void FirstTime()
    {
        if (!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
        }
    }
    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
}
