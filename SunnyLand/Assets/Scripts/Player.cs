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
    [SerializeField] private LayerMask ground;
    private bool onGround;

    [SerializeField] private Animator playerAnimator;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update() {
        Move();

        if (transform.position.y < -7) {
            ResetPosition();
        }
    }

    private void Move() {
        // Movimentação Horizontal
        direction = Input.GetAxis("Horizontal");
        onGround = Physics2D.OverlapCircle(feetPosition.position, 0.3f, ground);
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
}
