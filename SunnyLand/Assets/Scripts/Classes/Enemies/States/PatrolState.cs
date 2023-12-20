using UnityEngine;

public class PatrolState : EnemyBaseState {
    public PatrolState(Enemy enemy, string animationName) : base (enemy, animationName) {
        
    }

    public override void Enter() {
        base.Enter();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        if (enemy.CheckForPlayer()) {
            enemy.SwitchState(enemy.playerDetectedState);
        }

        if (enemy.CheckForObstacles()) {
            Rotate();
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();

        if (enemy.direction == 1)
            enemy.rb.velocity = new Vector2(enemy.stats.moveSpeed, enemy.rb.velocity.y);
        else
            enemy.rb.velocity = new Vector2(-enemy.stats.moveSpeed, enemy.rb.velocity.y);
    }

    private void Rotate() {
        enemy.transform.Rotate(0, 180, 0);
        enemy.direction = -enemy.direction;
    }
}
