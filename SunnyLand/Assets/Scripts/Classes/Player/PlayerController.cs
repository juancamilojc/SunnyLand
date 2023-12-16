using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpStrenght = 5.75f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float overlapRadius = 0.15f;
    private bool onGround;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool jump = false;
    private Vector3 initialPosition;
    private float horizontalMove;

    private Animator playerAnimator;
    private PlayerHP playerHP;

    void Awake() {
        initialPosition = transform.position;
        playerAnimator = GetComponent<Animator>();
        playerHP = GetComponent<PlayerHP>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        onGround = Physics2D.OverlapCircle(groundCheck.position, overlapRadius, whatIsGround);

        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }

    void FixedUpdate() {
        Move(horizontalMove, onGround, jump);
        jump = false;
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
        transform.Rotate(0f, 180f, 0f);
    }

    // Valores para definir a Animação (idle, run, jump & fall)
    private void HandlerAnimation(float speedX, float speedY, bool grounded) {
        playerAnimator.SetFloat("speedX", Mathf.Abs(speedX));
        playerAnimator.SetFloat("speedY", speedY);
        playerAnimator.SetBool("OnGround", grounded);
    }

    private void ResetPosition() {
        transform.position = initialPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Void")) {
            playerHP.TakeDamage(1);
            ResetPosition();
        }
    }
}
