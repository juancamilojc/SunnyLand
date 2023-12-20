using UnityEngine;

public class Enemy : MonoBehaviour {
    #region Variáveis
    public EnemyBaseState currentState;

    public PatrolState patrolState;
    public PlayerDetectedState playerDetectedState;
    public ChargeState chargeState;

    public Rigidbody2D rb;
    public Transform ledgeDetector;
    public LayerMask groundLayer, obstacleLayer, playerLayer;

    public int direction = -1;
    public float stateTime;

    public StatsSO stats;

    public GameObject alert;
    #endregion

    #region Unity Callbacks
    private void Awake() {
        patrolState = new PatrolState(this, "patrol");
        playerDetectedState = new PlayerDetectedState(this, "playerDetected");
        chargeState = new ChargeState(this, "charge");

        currentState = patrolState;
        currentState.Enter();
    }

    private void Start() {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    private void Update() {
        currentState.LogicUpdate();
    }

    private void FixedUpdate() {
        currentState.PhysicsUpdate();
    }
    #endregion

    #region Checks
    public bool CheckForObstacles() {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetector.position, Vector2.down, stats.cliffCheckDistance, groundLayer);
        RaycastHit2D hitObstacle = Physics2D.Raycast(ledgeDetector.position, direction == 1 ? Vector2.right : Vector2.left, stats.obstacleDistance, obstacleLayer);
        
        return hit.collider == null || hitObstacle.collider;
    }

    public bool CheckForPlayer() {
        RaycastHit2D hitPlayer = Physics2D.Raycast(ledgeDetector.position, direction == 1 ? Vector2.right : Vector2.left, stats.playerDetectDistance, playerLayer);

        return hitPlayer.collider;
    }
    #endregion

    #region Outras Funções
    public void SwitchState(EnemyBaseState newState) {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
        stateTime = Time.time;
    }

    //* Apenas para os raios serem vizíveis na Unity
    private void OnDrawGizmos() {
        // Raio de detecção do Player
        Gizmos.DrawRay(ledgeDetector.position, (direction == 1 ? Vector2.right : Vector2.left) * 5);
        
        // Raio de detecção do Chão
        Gizmos.color = Color.green;
        Gizmos.DrawRay(ledgeDetector.position, Vector2.down * 2);

        // Raio de detecção de Obstáculos
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(ledgeDetector.position, (direction == 1 ? Vector2.right : Vector2.left) * .2f);

    }
    #endregion
}
