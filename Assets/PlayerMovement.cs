using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;            //constant forward speed
    public float jumpForce = 10f;           //jump force
    public Transform groundCheckPoint;      //a point to check is player is on ground
    public float checkRadius = 0.2f;        // radius of the overlap circle for ground check
    public LayerMask groundLayer;           //layer of ground object

    private Rigidbody2D rb;                 //makes rigidbody2d now rb
    private bool isGrounded;                //is player on ground

    public AudioClip jump;
    public AudioClip backgroundMusic;
    public int dubJump = 2;


    public AudioSource sfxPlayer;
    public AudioSource musicPlayer;
    public CoinManager cm;
    Animator anim;

    public float timer = 0f;
    public float delayAmount = 1f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //get the rb component attached to player
        sfxPlayer = GetComponent<AudioSource>();
        anim= GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delayAmount)
        {
            cm.coinCount += 5;
            timer = 0f;
        }
        anim.SetBool("GroundChecker", isGrounded);



        //constant forward
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        //check if player is on ground
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundLayer);

        //jumping logic
        if (dubJump >= 1 && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            sfxPlayer.PlayOneShot(jump);
            dubJump -= 1;
            anim.SetTrigger("Jump");
            
        }

        if (isGrounded == true)
        {
            dubJump = 2;
        }
    }


    private void Jump()
    {
        //add an up force for jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnDrawGizmosSelected()
    {
        //draw a circle to visualise ground check point in editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, checkRadius);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            cm.coinCount += 10;
            Destroy(other.gameObject);

            PlayerPrefs.SetInt("Highscore", cm.coinCount);
            PlayerPrefs.GetInt("HighScore");
            if (cm.coinCount > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", cm.coinCount);
            }
            if (other.gameObject.CompareTag("Spike"))
            {
                SceneManager.LoadScene(3);
            }

        }
    }

}