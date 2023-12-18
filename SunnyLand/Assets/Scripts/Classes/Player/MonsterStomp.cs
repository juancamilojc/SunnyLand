using System.Collections;
using UnityEngine;

public class MonsterStomp : MonoBehaviour {
    private GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("WeakPoint")) {
            enemy = collision.gameObject;
            IEnemyMovement enemyMovement = enemy.GetComponent<IEnemyMovement>();
            enemyMovement?.DisableMovement();

            StartCoroutine(KillEnemy());
        }
    }

    private IEnumerator KillEnemy() {
        enemy.transform.GetChild(0).gameObject.SetActive(false);
        enemy.GetComponent<BoxCollider2D>().enabled = false;
        enemy.GetComponent<Rigidbody2D>().isKinematic = true;

        enemy.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(enemy);
        Debug.Log("Inimigo Derrotado!");
    }
}
