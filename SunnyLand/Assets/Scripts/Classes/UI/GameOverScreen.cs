using System.Collections;
using UnityEngine;

public class GameOverScreen : MonoBehaviour {
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private Animator gameOverScreenAnim;

    void Awake() {
        levelLoader = FindObjectOfType<LevelLoader>();
        gameOverScreenAnim = GetComponent<Animator>();
    }

    public void OnRestartButtonClicked() {
        StartCoroutine(Restart());
    }

    public void OnExitButtonClicked() {
        Debug.Log("Saindo!");
        Application.Quit();
    }

    private IEnumerator Restart() {
        gameOverScreenAnim.SetTrigger("Restart");
        yield return new WaitForSeconds(0.2f);
        levelLoader.ReloadLevel();
    }
}
