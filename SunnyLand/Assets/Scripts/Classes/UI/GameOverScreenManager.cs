using UnityEngine;

public class GameOverScreenManager : MonoBehaviour {
    [SerializeField] private GameOverScreen gameOverScreen;

    void Awake() {
        gameOverScreen = GetComponentInChildren<GameOverScreen>();
    }

    private void OnEnable() {
        PlayerHP.OnPlayerDead += EnableGameOverScreen;
    }

    private void EnableGameOverScreen() {
        gameOverScreen.gameObject.SetActive(true);
    }
}
