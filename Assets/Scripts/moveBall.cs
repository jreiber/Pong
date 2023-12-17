using TMPro;
using UnityEngine;

public class moveBall : MonoBehaviour
{
    public Vector2 initialForce;
    public Rigidbody2D rb2D;
    public Transform ballPosition;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endGameText;
    public TextMeshProUGUI subtitleText;
    public GameObject titleTextContainer;
    public GameObject endGameTextContainer;


    public AudioClip paddleBounce;
    public AudioClip scoreSound;
    public AudioClip borderBounce;
    public AudioSource audioSource;

    private int player1Score;
    private int player2Score;
    private int endGameScore = 1;
    private bool isActive = false;

    const string playerWinsText = "You Win!";
    const string playerLosesText = "You Lose!";

    private void Start()
    {
        subtitleText.text = $"First to {endGameScore} wins.\nPress E to start.";
    }

    private void Update()
    {
        if (!isActive)
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                initiateGame();
            }
        }
    }

    private void initiateGame()
    {
        isActive= true;

        player1Score = 0;
        player2Score = 0;

        scoreText.gameObject.SetActive(true);
        titleTextContainer.SetActive(false);
        endGameTextContainer.SetActive(false);

        resetBall(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ontriggerenter tag = " + collision.tag);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("old velocity" + rb2D.velocity);
            if(rb2D.velocity.x < 0) { rb2D.velocity = GetNewVelocity(1);}
            else { rb2D.velocity = GetNewVelocity(-1); }
            audioSource.clip = paddleBounce;
            audioSource.Play();
            
            
            Debug.Log("new velocity" + rb2D.velocity);
        }
        if(collision.CompareTag("top border") || collision.CompareTag("bottom border"))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x,rb2D.velocity.y * -1);
            audioSource.clip = borderBounce;
            audioSource.Play();
        }
        if (collision.CompareTag("right border"))
        {
            // stop ball
            rb2D.velocity = new Vector2(0, 0);
            audioSource.clip = scoreSound;
            audioSource.Play();
            player1Score++;
            Debug.Log("Hit right border, player2 score = " + player2Score + "; player 1 score = " + player1Score);
            hitBorder(-1);
        }
        if(collision.CompareTag("left border"))
        {
            rb2D.velocity = new Vector2(0, 0);
            audioSource.clip = scoreSound;
            audioSource.Play();
            player2Score++;
            Debug.Log("Hit left border, player2 score = " + player2Score + "; player 1 score = " + player1Score);
            hitBorder(1);
        }


    }

    private Vector2 GetNewVelocity(int direction = 1)
    {
        Vector2 v;
        var rand = new System.Random();
        int x = rand.Next(4, 8);
        int y = rand.Next(-5, 5);


        v.x = direction * x;
        v.y = y;
        return v;

    }

    private void hitBorder(int direction)
    {
        updateScore();

        if(player1Score >= endGameScore)
        {
            endGameText.text = playerWinsText;
            gameOver();
        }
        else if (player2Score >= endGameScore)
        {
            endGameText.text = playerLosesText;
            gameOver();
        }
        else
        {
            resetBall(direction);
        }
    }

    private void gameOver()
    {
        endGameTextContainer.SetActive(true);
        isActive = false;

    }

    void updateScore()
    {
        scoreText.text = player1Score + "\t" + player2Score;
    }

    void resetBall(int direction)
    {
        ballPosition.position = new Vector3(0, 0, 0);
        rb2D.velocity = GetNewVelocity(direction);

    }
    

}
