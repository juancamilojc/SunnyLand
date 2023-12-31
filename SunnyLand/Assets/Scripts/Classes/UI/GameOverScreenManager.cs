using UnityEngine;

public class GameOverScreenManager : MonoBehaviour {
    [SerializeField] private GameObject gameOverScreen;

    private void OnEnable() {
        PlayerHP.OnPlayerDead += EnableGameOverScreen;
    }

    private void EnableGameOverScreen() {
        gameOverScreen.SetActive(true);
    }
}
