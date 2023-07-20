using UnityEngine;
using UnityEngine.UI;

public class GoodScore : MonoBehaviour
{
    public Text scoreText;
    public Text scoreDisplayText;
    public int score;

    public int oldScore;
    private string scoreStr;

    private void Start()
    {
        score = 99999;

        scoreText.text = "Score : ";
    }

    private void Update()
    {

        if (score != oldScore)
        {
            if (scoreText != null)
            {
                scoreStr = score.ToString();
                scoreDisplayText.text = scoreStr;

                oldScore = score;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            score = Random.Range(1000, 10000);
        }
    }
}
