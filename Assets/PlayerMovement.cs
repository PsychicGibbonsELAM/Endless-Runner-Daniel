using UnityEngine;

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


    public AudioSource sfxPlayer;
    public AudioSource musicPlayer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //get the rb component attached to player
        sfxPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {

        //constant forward
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        //check if player is on ground
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, checkRadius, groundLayer);

        //jumping logic
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            sfxPlayer.PlayOneShot(jump);
            Jump();
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


}