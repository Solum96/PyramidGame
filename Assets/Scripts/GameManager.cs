using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Canvas gameOverScreen;

    public void EndGame()
    {
        gameOverScreen.gameObject.SetActive(true);
    }
}
