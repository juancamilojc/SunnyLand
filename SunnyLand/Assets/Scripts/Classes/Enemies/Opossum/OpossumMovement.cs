using UnityEngine;

public class OpossumMovement : MonoBehaviour, IEnemyMovement {
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private int patrolDestination;
    
    // Variáveis para o Chase
    /* [SerializeField] private Transform player;
    [SerializeField] private float chasingDistance = 2f;
    private bool isChasing = false; */
    private bool isMovementEnable = true;

    void Update() {
        // Tratamento se ativar o Chase
        /* if (!isMovementEnable) {
            return;
        } else if (Vector2.Distance(transform.position, player.position) < chasingDistance) {
            Chase();
        } else {
            Patrol();
        } */

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

    // Não deu tempo de refinar a perseguição :'(
    /* public void Chase() {
        if (transform.position.x > player.transform.position.x) {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        } else if (transform.position.x < player.transform.position.x) {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position += moveSpeed * Time.deltaTime * Vector3.right;
        }
    } */

    public void DisableMovement() {
        isMovementEnable = false;
    }
}
