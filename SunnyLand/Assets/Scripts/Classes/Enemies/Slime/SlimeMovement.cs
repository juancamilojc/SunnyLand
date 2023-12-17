using UnityEngine;

public class SlimeMovement : MonoBehaviour, IEnemyMovement {
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private int patrolDestination;
    
    private bool isMovementEnable = true;

    void Update() {
        if (!isMovementEnable) {
            return;
        } else {
            Patrol();
        }
    }

    public void Patrol() {
        if (patrolDestination == 0) {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f) {
                transform.localScale = new Vector3(1, 1, 1);
                patrolDestination = 1;
            }
        } else if (patrolDestination == 1) {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f) {
                transform.localScale = new Vector3(-1, 1, 1);
                patrolDestination = 0;
            }
        }
    }

    public void DisableMovement() {
        isMovementEnable = false;
    }
}
