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

        ResetBall();
    }

    private void FixedUpdate()
    {
        if (Time.time - startTime > 2)
        {

        }
        rb.velocity = direction * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float x = rb.velocity.x;
        float y = rb.velocity.y;
        
        if (collision.CompareTag("Paddle"))
        {
            x *= -1;
        }
        else if (collision.CompareTag("Border"))
        {
            y *= -1;
        }

        direction = new Vector2(x, y);
        if (Speed < 7)
        {
            Speed += .1f;
        }
    }

    private void ResetBall()
    {
        rb.simulated = false;
        startTime = Time.time;
        Speed = startSpeed;

        transform.localPosition = Vector2.zero;
        float x = Random.value < 0.5 ? -1 : 1;
        float y = Random.Range(-1, 1);
        direction = new Vector2(x, y);
        direction.Normalize();
    }
}
