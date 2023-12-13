using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 10;
    private float direction;
    private Vector3 initialPosition;
    private bool facingRight = true;

    [SerializeField] private float jumpStrenght = 2;
    [SerializeField] private Transform feetPosition;
    [SerializeField] private float overlapRadius;
    [SerializeField] private LayerMask ground;
    private bool onGround;

    private Rigidbody2D plataform;

    [SerializeField] private float downBoundary;

    [SerializeField] private Animator playerAnimator;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        Move();

        // Reseta a posição do Player caso ele caia do mapa
        if (transform.position.y < downBoundary) {
            ResetPosition();
        }
    }

    private void Move() {
        // Movimentação Horizontal
        direction = Input.GetAxis("Horizontal");
        onGround = Physics2D.OverlapCircle(feetPosition.position, overlapRadius, ground);
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

        // Faz o Player olhar para o lado do movimento
        if ((direction < 0 && facingRight) || (direction > 0 && !facingRight)) {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }

        // Meânica de Pulo
        if (onGround && Input.GetButtonDown("Jump")) {
            rb.velocity = Vector2.up * jumpStrenght;
        }

        // Animações
        playerAnimator.SetFloat("speedX", Mathf.Abs(direction));    //  idle -> run
        playerAnimator.SetFloat("speedY", rb.velocity.y);           //  AnyState -> Jump || Fall
        playerAnimator.SetBool("OnGround", onGround);               //  AnyState -> Jump || Fall
    }

    private void ResetPosition() {
        transform.position = initialPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("MovingPlataform")) {
            transform.parent = collision.transform;
            plataform = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.gravityScale = 10;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("MovingPlataform")) {
            transform.parent = null;
            plataform = null;
            rb.gravityScale = 3.0f;
        }
    }
}
