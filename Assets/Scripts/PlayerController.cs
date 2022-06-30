using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum Command
    {
        UP,
        DOWN,
        NONE
    };
    Rigidbody2D rb;
    public float Speed=2;
    private KeyCode upCode;
    private KeyCode downCode;
    private float paddleHeight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        paddleHeight = GetComponent<Collider2D>().bounds.size.y;
        upCode = GetUpKey();
        downCode = GetDownKey();
    }

    private void FixedUpdate()
    {
        switch (GetCommand())
        {
            case Command.UP:
                rb.velocity = Vector2.up;
                break;
            
            case Command.DOWN:
                rb.velocity = Vector2.down;
                break;

            default:
                rb.velocity = Vector2.zero;
                break;
        }
        
    }

    private void LateUpdate()
    {
        float topBound = 1 - (paddleHeight / 2) - 0.05f;
        float bottomBound = -topBound;

        var curPos = transform.localPosition;
        float y = Mathf.Clamp(curPos.y, bottomBound, topBound);
        transform.localPosition = new Vector2(curPos.x, y);
    }

    private Command GetCommand()
    {
        if (Input.GetKey(upCode))
        {
            return Command.UP;
        }
        else if (Input.GetKey(downCode))
        {
            return Command.DOWN;
        }
        else
        {
            return Command.NONE;
        }
    }

    private KeyCode GetUpKey()
    {
        if (transform.localPosition.x < 0)
        {
            return KeyCode.W;
        }
        else
        {
            return KeyCode.UpArrow;
        }
    }

    private KeyCode GetDownKey()
    {
        if (transform.localPosition.x < 0)
        {
            return KeyCode.S;
        }
        else
        {
            return KeyCode.DownArrow;
        }
    }
}
