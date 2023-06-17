using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movePower;

    public float jumpPower;

    public int maxHealth;

    public int curHealth;

    public HealthBar hb;

    private Rigidbody2D rb;

    public Animator anim;

    bool isJumping = false;

    private bool alive = true;

    private float hurtCooldown = 0f;

    public bool reset = false;

    public CamerController cam;

    public SceneChanger sc;

    public SFX sfx;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        reset = true;
        curHealth = maxHealth;
        hb.setMaxHealth (maxHealth);
    }

    private void Update()
    {
        if (alive)
        {
            //Hurt();
            Die();
            Attack();
            Jump();
            Run();
        }
        if (hurtCooldown > 0f)
        {
            hurtCooldown -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (alive)
        {
            anim.SetBool("isJump", false);
            if (other.CompareTag("Obstacle") && hurtCooldown <= 0f)
            {
                Hurt();
                ScoreManager.score -= 5;
                curHealth -= 10;
                hb.setHealth (curHealth);
                sfx.sounds[1].Play();
                hurtCooldown = 0.5f;

                // destroy the obstacle
                Destroy(other.gameObject);
            }
            if (other.CompareTag("Collect"))
            {
                ScoreManager.score += 10;
                sfx.sounds[0].Play();
                hurtCooldown = 0.5f;

                // destroy the obstacle
                Destroy(other.gameObject);
            }
        }
    }

    void Run()
    {
        Vector3 moveVelocity;
        anim.SetBool("isRun", false);
        if (cam.isMoving)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1) * 0.5f;
            if (!anim.GetBool("isJump")) anim.SetBool("isRun", true);
        }

        // transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Jump()
    {
        if (
            Input.GetKeyDown(KeyCode.Space) &&
            !anim.GetBool("isJump") &&
            cam.isMoving
        )
        {
            isJumping = true;
            anim.SetBool("isJump", true);
        }
        if (!isJumping)
        {
            return;
        }

        rb.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0f, jumpPower);
        rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.name == "Object")
        // {
        //     sfx.sounds[0].Play();
        //     ScoreManager.score += 10;
        // }
        // if (collision.gameObject.name == "Obstacle")
        // {
        //     Hurt();
        //     sfx.sounds[1].Play();
        //     ScoreManager.score -= 5;
        // }
    }

    void Attack()
    {
        // if (Input.GetKeyDown(KeyCode.Alpha1))
        //     {
        //         anim.SetTrigger("attack");
        //     }
    }

    void Hurt()
    {
        anim.SetTrigger("hurt");
        //rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
    }

    void Die()
    {
        if (curHealth <= 10)
        {
            anim.SetTrigger("die");
            alive = false;
            sc.MoveToScene(2);
        }
    }

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            anim.SetTrigger("idle");
            alive = true;
        }
    }
}
