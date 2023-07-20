using UnityEngine;
using UnityEngine.UI;

public class BadScore : MonoBehaviour
{
    public Text scoreText;
    public int score;

    private string scoreStr;

    private void Start()
    {
        score = 99999;
    }

    private void Update()
    {
        if(scoreText != null)
        {
            scoreStr = "Score : " + score.ToString(); 
            scoreText.text = scoreStr;
        }
    }
}
