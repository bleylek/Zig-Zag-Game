using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public Text scoreText;
    private int previousScore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        previousScore = score;
        UpdateScoreText(); // Initialize the score text
    }

    // Update is called once per frame
    void Update()
    {
        // Update the score text only if the score has changed
        if (score != previousScore)
        {
            UpdateScoreText();
            previousScore = score;
        }
    }

    // Method to update the score text
    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
