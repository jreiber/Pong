using UnityEngine;

public class computerPlayer : MonoBehaviour
{
    public Transform ballPosition;
    public Rigidbody2D ballRB2D;
    public Transform paddlePosition;
    public Rigidbody2D paddleRB2D;
    private static float moveSensitivity = 2f;
    private Vector2 paddleMove = new Vector2(0f, moveSensitivity);

    // Update is called once per frame
    void FixedUpdate()
    {
        // check if ball is moving toward right paddle
        if(ballRB2D.velocity.x > 0)
        {
            if(paddlePosition.position.y < ballPosition.position.y)
            {
                paddleRB2D.MovePosition(paddleRB2D.position + paddleMove * Time.deltaTime);
            }
            else if(paddlePosition.position.y > ballPosition.position.y)
            {
                paddleRB2D.MovePosition(paddleRB2D.position - paddleMove * Time.deltaTime);
            }
            // begin moving toward that location at a set speed

        }


    }
}
