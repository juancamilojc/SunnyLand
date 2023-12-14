using UnityEngine;

public class Collector : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Gem")) {
            collision.GetComponent<Gem>().Collect();
        } else if (collision.CompareTag("Cherry")) {
            collision.GetComponent<Cherry>().Collect();
        }
    }
}
