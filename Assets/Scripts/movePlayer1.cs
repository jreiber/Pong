using UnityEngine;

public class movePlayer1 : MonoBehaviour
{
    public Transform playerPosition;
    public Rigidbody2D rb2D;
    
    private static float moveSensitivity = 3f;
    private Vector2 paddleMove = new Vector2(0f, moveSensitivity);
    
    // Update is called once per frame
    void FixedUpdate()
    {
       if(Input.GetKey(KeyCode.UpArrow))
        {
            rb2D.MovePosition(rb2D.position + paddleMove * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb2D.MovePosition(rb2D.position - paddleMove * Time.deltaTime);
        }
    }
}
