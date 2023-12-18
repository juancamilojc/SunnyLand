using System.Collections;
using UnityEngine;

public class NextLevel : MonoBehaviour {
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private Animator portalAnim;

    void Start() {
        levelLoader = FindObjectOfType<LevelLoader>();
        portalAnim = GetComponentInParent<Animator>();

        if (levelLoader == null || portalAnim == null) {
            Debug.Log("Erro ao carregar o Level Loader ou o Portal.");
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            StartCoroutine(NextLevelLoader());
            Debug.Log("Entrou no portal!");
        }
    }

    private IEnumerator NextLevelLoader() {
        yield return new WaitForSeconds(0.1f);
        levelLoader.LoadNextLevel();
    }    
}
