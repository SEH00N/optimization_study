using UnityEngine;
using UnityEngine.UI;

public class MyGoodScore : MonoBehaviour
{
    public Text scoreText;
    private string scoreStr;

    private int score;
    public int Score {
        get => score;
        set {
            score = value;
            scoreStr = $"Score : {score}";

            if(scoreText != null)
                scoreText.text = scoreStr;
        }
    }

    private void Start()
    {
        Score = 100;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
            Score += 100;
        else if(Input.GetKeyDown(KeyCode.DownArrow))
            Score -= 100;
    }
}
