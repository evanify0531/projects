using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText1;
    public Text scoreText2;
    public BallMovement ball;

    void Update()
    {
        string score1 = ball.score1.ToString();
        string score2 = ball.score2.ToString();
        scoreText1.text = score1;
        scoreText2.text = score2;
    }
}
