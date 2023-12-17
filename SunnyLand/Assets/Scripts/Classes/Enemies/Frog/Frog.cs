using UnityEditor.Tilemaps;
using UnityEngine;

public class Frog : MonoBehaviour {
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float moveSpeed = 1.0f;
    private bool moveToB = true;
    private Rigidbody2D rb;

    private Animator frogAnimator;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        frogAnimator = GetComponent<Animator>();
    }

    void Update() {
        Move();
    }

    private void Move() {
        if (transform.position.x < pointA.position.x) {
            moveToB = true;
        } else if (transform.position.x > pointB.position.x) {
            moveToB = false;
        }

        float horizontalMovement = moveToB ? 1f : -1f;

        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);

        if (Mathf.Abs(rb.velocity.x) > 0) {
            frogAnimator.SetBool("Moving", true);
        } else {
            frogAnimator.SetBool("Moving", false);
        }

        if (moveToB && horizontalMovement > 0) {
            Flip();
        } else if (!moveToB && horizontalMovement < 0) {
            Flip();
        }
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
