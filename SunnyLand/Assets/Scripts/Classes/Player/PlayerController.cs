using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpStrenght = 5.75f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float overlapRadius = 0.15f;

    [SerializeField] private PlayerHP playerHP;

    [SerializeField] private float kbForce = 6f;
    public float kbCounter;
    public float kbTotalTime = 0.3f;
    public bool knockFromRight;

    private bool onGround;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool jump = false;
    private Vector3 initialPosition;
    private float horizontalMove;
    private SpriteRenderer sprite;
    private Animator playerAnimator;
    private bool blockInput = false;

    void Awake() {
        initialPosition = transform.position;
        playerAnimator = GetComponent<Animator>();
        playerHP = GetComponentInChildren<PlayerHP>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (!blockInput) {
            horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
            onGround = Physics2D.OverlapCircle(groundCheck.position, overlapRadius, whatIsGround);

            if (Input.GetButtonDown("Jump")) {
                jump = true;
            }
        } else {
            horizontalMove = 0f;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 10;
            jump = false;

            HandlerAnimation(0, 0, false);
            Debug.Log("Input Blockeado!");
        }
    }

    void FixedUpdate() {
        if (!blockInput) {
            Move(horizontalMove, onGround, jump);
            jump = false;
        }
    }

    private void Move(float move, bool grounded, bool jump) {
        rb.velocity = new Vector2(move * 100f * Time.fixedDeltaTime, rb.velocity.y);

        if ((move < 0 && facingRight) || (move > 0 && !facingRight)) {
            Flip();
        }

        if (grounded && jump) {
            rb.AddForce(new Vector2(0f, jumpStrenght * 100f));
        }

        HandlerAnimation(move, rb.velocity.y, grounded);
    }

    // Faz o Player olhar para o lado do movimento
    private void Flip() {
        facingRight = !facingRight;
        
        if (facingRight) {
            sprite.flipX = false;
        } else {
            sprite.flipX = true;
        }
    }

    // Valores para definir a Animação (idle, run, jump & fall)
    private void HandlerAnimation(float speedX, float speedY, bool grounded) {
        playerAnimator.SetFloat("speedX", Mathf.Abs(speedX));
        playerAnimator.SetFloat("speedY", speedY);
        playerAnimator.SetBool("OnGround", grounded);
    }

    public void ResetPosition() {
        transform.position = initialPosition;
        rb.velocity = Vector2.zero;
    }

    private void OnEnable() {
        PlayerHP.OnPlayerDead += PlayerDead;
        PlayerHP.OnPlayerDamage += PlayerDamage;
    }

    private void OnDisable() {
        PlayerHP.OnPlayerDead -= PlayerDead;
        PlayerHP.OnPlayerDamage -= PlayerDamage;
    }

    private void PlayerDead() {
        StartCoroutine(Dead());
    }

    private void PlayerDamage() {
        StartCoroutine(KnockBack());
    }

    private IEnumerator KnockBack() {
        playerAnimator.SetTrigger("TakeDamage");
        blockInput = true;
        kbCounter = kbTotalTime;

        while (kbCounter > 0) {
            if (knockFromRight) {
                rb.velocity = new Vector2(-kbForce, kbForce);
            } else if (!knockFromRight) {
                rb.velocity = new Vector2(kbForce, kbForce);
            }

            kbCounter -= Time.deltaTime;
            yield return null;
        }

        rb.velocity = Vector2.zero;
        blockInput = false;
    }

    private IEnumerator Dead() {
        blockInput = true;
        yield return new WaitForSeconds(0.1f);
        ResetPosition();
    }
}
