using UnityEngine;

public class OpossumMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private int patrolDestination;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    void Start() {
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        transform.position = patrolPoints[patrolDestination].position;
    }

    void Update() {
        if (patrolDestination == 0) {
            sprite.flipX = true;
        } else {
            sprite.flipX = false;
        }
    }

    void FixedUpdate() {
        Move();
    }

    private void Move() {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolDestination].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == patrolPoints[patrolDestination].transform.position) {
            patrolDestination += 1;
        }

        if (patrolDestination == patrolPoints.Length) {
            patrolDestination = 0;
        }
    }
}
