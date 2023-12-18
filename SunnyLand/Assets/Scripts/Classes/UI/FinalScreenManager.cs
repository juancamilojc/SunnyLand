using UnityEngine;

public class FinalScreenManager : MonoBehaviour {
    [SerializeField] private GameObject gameOverScreen;

    private void OnEnable() {
        FinalPoint.OnFinalGame += EnableGameOverScreen;
    }

    private void EnableGameOverScreen() {
        gameOverScreen.SetActive(true);
    }
}
