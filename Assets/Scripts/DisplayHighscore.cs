using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayHighscore : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = $"Highscore: {score}";
    }
}
