using UnityEngine;

public class Opossum : MonoBehaviour {
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private Transform[] pointsToMove;
    [SerializeField] private int startingPoint;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    void Start() {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        transform.position = pointsToMove[startingPoint].position;
    }

    void Update() {
        if (startingPoint == 0) {
            sprite.flipX = true;
        } else {
            sprite.flipX = false;
        }
    }

    void FixedUpdate() {
        Move();
    }

    private void Move() {
        transform.position = Vector2.MoveTowards(transform.position, pointsToMove[startingPoint].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == pointsToMove[startingPoint].transform.position) {
            startingPoint += 1;
        }

        if (startingPoint == pointsToMove.Length) {
            startingPoint = 0;
        }
    }
}
