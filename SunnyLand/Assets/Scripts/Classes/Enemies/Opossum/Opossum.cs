using UnityEngine;

public class Opossum : MonoBehaviour {
    [SerializeField] private int damage = 1;
    private PlayerHP player;

    void Start() {
        player = FindAnyObjectByType<PlayerHP>();

        if (player == null) {
            Debug.Log("Erro ao encontrar o Player!");
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            player.TakeDamage(damage);
        }
    }
}