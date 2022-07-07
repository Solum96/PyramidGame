using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Canvas gameOverScreen;
    public Canvas UiScreen;
    public GameObject scoreTextObject;
    private TextMeshProUGUI scoreText;
    private PointsHandler pointsHandler;

    public void Start()
    {
        scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
        if (scoreText == null)
        {
            Debug.LogWarning("Score UI is null. Score will not be displayed");
        }

        pointsHandler = FindObjectOfType<PointsHandler>();
    }

    public void EndGame()
    {
        gameOverScreen.gameObject.SetActive(true);
        UiScreen.gameObject.SetActive(false);

        scoreText.text = pointsHandler.points.ToString();
        SetHighScore(pointsHandler.points);

        pointsHandler.enabled = false;
        FindObjectOfType<MeteorSpawner>().enabled = false;
        var meteors = FindObjectsOfType<Meteor>();
    }

    private void SetHighScore(int points)
    {
        var currentHighScore = PlayerPrefs.GetInt("highscore", 0);
        if(points > currentHighScore)
        {
            PlayerPrefs.SetInt("highscore", points);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
