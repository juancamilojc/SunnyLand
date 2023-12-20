using UnityEngine;

public class DogMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform ledgeDetector;
    [SerializeField] private LayerMask groundLayer, obstacleLayer;
    [SerializeField] private float raycastDistance = 1.5f, obstacleDistance = 0.2f;
    private bool facingRight = false;

    private void Start() {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void Update() {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetector.position, Vector2.down, raycastDistance, groundLayer);
        Debug.DrawRay(ledgeDetector.position, Vector2.down * raycastDistance, Color.green);

        RaycastHit2D hitObstacle = Physics2D.Raycast(ledgeDetector.position, Vector2.left, obstacleDistance, obstacleLayer);
        Debug.DrawRay(ledgeDetector.position, Vector2.left * obstacleDistance, Color.magenta);

        if (hit.collider == null || hitObstacle.collider) {
            Rotate();
        }
    }

    private void FixedUpdate() {
        if (facingRight) {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

    private void Rotate() {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
