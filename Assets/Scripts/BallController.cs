using UnityEngine;

public class BallController : MonoBehaviour
{
    public float Speed;
    public Vector2 direction;

    Rigidbody2D rb;
    float startSpeed;
    float startTime;

    void Start()
    {
        startSpeed = Speed;
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;
        ResetBall();
    }

    private void FixedUpdate()
    {
        if (Time.time - startTime > 2)
        {
            rb.simulated = true;
        }
        rb.velocity = direction * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            direction.x *= -1;

            float paddleHeight = collision.bounds.size.y;
            float ballY = ComputeBallY(collision.transform.localPosition.y, paddleHeight);

            direction.y += ballY + Random.Range(-0.05f, 0.05f);
            direction.x += Mathf.Sign(direction.x) * Mathf.Abs(direction.y);
            direction.Normalize();
        }
        else if (collision.CompareTag("Border"))
        {
            direction.y *= -1;
        }

        if (Speed < 7)
        {
            Speed += .1f;
        }
    }

    public void ResetBall()
    {
        rb.simulated = false;
        startTime = Time.time;
        Speed = startSpeed;

        transform.localPosition = Vector2.zero;
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-1, 1);
        direction = new Vector2(x, y);
        direction.Normalize();

        Speed = startSpeed;
    }

    private float ComputeBallY(float paddlePosY, float paddleHeight)
    {
        float ballPosY = transform.localPosition.y;
        float y = ((ballPosY - paddlePosY) / paddleHeight) * 2;
        return Mathf.Clamp(y, -1, 1);
    }
}
