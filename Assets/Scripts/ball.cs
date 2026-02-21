using UnityEngine;

public class Ball : MonoBehaviour
{
    //how long the ball lasts before going away
    public float lifetime = 15f;
    //speed boost that is applied when two balls collide with eachother
    public float ballBoostOnCollision = 0.5f;
    //speed multiplier when the ball hits the wall (not another ball)
    public float wallDragOnCollision = 0.9f;

    //counts down from lifetime to zero each frame
    private float lifetimeTimer;
    //referencing the rigidbody 
    private Rigidbody2D rb;
    //referencing the spriterenderer
    private SpriteRenderer sr;
    //keeps the balls chosen color so we can change it without losing any hue
    private Color ballColour;

    void Start()
    {
        //steal the physics and visual aspects of the ball
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        //give the ball a random color
        ballColour = new Color(
            Random.Range(0.4f, 1f),
            Random.Range(0.4f, 1f),
            Random.Range(0.4f, 1f)
        );
        sr.color = ballColour;

        //start the timer
        lifetimeTimer = lifetime;

        //move the ball sideways so that it doesnt fall straight down
        float randomX = Random.Range(-2f, 2f);
        rb.linearVelocity = new Vector2(randomX, 0f);
    }

    void Update()
    {
        //tick the timer down every frame
        lifetimeTimer -= Time.deltaTime;

        //as the ball gets closer to fading away, also fade the balls transparancy
        float alpha = Mathf.Clamp01(lifetimeTimer / lifetime);
        sr.color = new Color(ballColour.r, ballColour.g, ballColour.b, alpha);

        //when the timer hits zero, remove the ball!
        if (lifetimeTimer <= 0f)
        {
            Destroy(gameObject);
        }
        //spin the ball
        float spinSpeed = rb.linearVelocity.magnitude * 90f;
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if ball hits another ball
        if (collision.gameObject.CompareTag("ball"))
        {
            //get the other balls physics components so we are able to push it around
            Rigidbody2D otherRb = collision.gameObject.GetComponent<Rigidbody2D>();

            //figure out which direction to push the ball
            Vector2 pushDirection = (rb.position - otherRb.position).normalized;

            //push ball + speed it up
            rb.linearVelocity += pushDirection * ballBoostOnCollision;

            //push the other ball the opposite direction
            otherRb.linearVelocity += -pushDirection * ballBoostOnCollision;
        }

        //if ball hits another wall, slow it down
        if (collision.gameObject.CompareTag("walls"))
        {
            rb.linearVelocity *= wallDragOnCollision;
        }
    }
}