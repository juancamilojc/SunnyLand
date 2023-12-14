using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float moveSpeed = 400f;
    private Vector3 initialPosition;
    private float horizontalMove = 0;
    private bool facingRight = true;
    private Rigidbody2D rb;

    private bool jump = false;
    [SerializeField] private float jumpStrenght = 600f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float overlapRadius;
    [SerializeField] private LayerMask whatIsFloor;
    private bool onGround;

    [SerializeField] private Animator playerAnimator;

    //[SerializeField] private float downBoundary = -7;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    void Update() {
        horizontalMove = Input.GetAxis("Horizontal");

        // Faz o Player olhar para o lado do movimento
        if ((horizontalMove < 0 && facingRight) || (horizontalMove > 0 && !facingRight)) {
            transform.Rotate(0f, 180f, 0f);
            facingRight = !facingRight;
        }

        onGround = Physics2D.OverlapCircle(groundCheck.position, overlapRadius, whatIsFloor);

        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }

        // Reseta a posição do Player caso ele caia do mapa
        /* if (transform.position.y < downBoundary) {
            ResetPosition();
        } */
    }

    void FixedUpdate() {
        Move(horizontalMove, onGround, jump);
        jump = false;
    }

    private void Move(float direction, bool ground, bool jump) {
        // Movimentação Horizontal
        rb.velocity = new Vector2(direction * moveSpeed * Time.fixedDeltaTime, rb.velocity.y);

        // Meânica de Pulo
        if (ground && jump) {
            rb.velocity = jumpStrenght * Time.fixedDeltaTime * Vector2.up;
        }

        // Animações
        playerAnimator.SetFloat("speedX", Mathf.Abs(direction));    //  idle -> run
        playerAnimator.SetFloat("speedY", rb.velocity.y);           //  AnyState -> Jump || Fall
        playerAnimator.SetBool("OnGround", ground);
    }

    private void ResetPosition() {
        transform.position = initialPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Void")) {
            ResetPosition();
        }
    }
}
