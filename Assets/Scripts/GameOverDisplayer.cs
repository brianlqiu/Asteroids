using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplayer : MonoBehaviour
{
    public static bool gameOver;
    private TextMesh gameOverText;
    void Start()
    {
        gameOver = false;
        gameOverText = GetComponent<TextMesh>();
    }

    void Update()
    {
        if (gameOver)
        {
            gameOverText.color = Color.white;
        }
    }
}
