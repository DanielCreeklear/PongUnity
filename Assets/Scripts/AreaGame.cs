using UnityEngine;

public class AreaGame : MonoBehaviour
{
    GameObject leftPaddle;
    GameObject rightPaddle;
    GameObject ball;

    private void Start()
    {
        leftPaddle = transform.Find("Player1").gameObject;
        rightPaddle = transform.Find("Player2").gameObject;
        ball = transform.Find("Ball").gameObject;

        ResetArea();
    }

    public void ResetArea()
    {
        ball.GetComponent<BallController>().ResetBall();
        leftPaddle.transform.localPosition = new Vector3(leftPaddle.transform.localPosition.x, 0, 0);
        rightPaddle.transform.localPosition = new Vector3(rightPaddle.transform.localPosition.x, 0, 0);
    }

    private void LateUpdate()
    {
        if (ball.transform.localPosition.x < -1.3f)
        {
            GameManager.Instance.AddScore(0, 1);
            if (!GameManager.Instance.IsGameOver())
                ResetArea();
        }
        else if (ball.transform.localPosition.x > 1.3f)
        {
            GameManager.Instance.AddScore(1, 0);
            if (!GameManager.Instance.IsGameOver())
                ResetArea();
        }
    }
}
