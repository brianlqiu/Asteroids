using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{

    public static bool updateScore;
    public static int score;
    private TextMesh scoreText;
    // Start is called before the first frame update
    void Start()
    {
        updateScore = false;
        score = 0;
        scoreText = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (updateScore)
        {
            scoreText.text = String.Format("Score: {0}", score);
            updateScore = false;
        }
    }
}
