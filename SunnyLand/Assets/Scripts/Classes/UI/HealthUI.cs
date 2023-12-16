using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {
    private Image[] hearts;

    void Awake() {
        InitializeHearts();
    }

    private void InitializeHearts() {
        int maxHealth = transform.childCount;
        hearts = new Image[maxHealth];

        for (int i = 0; i < maxHealth; i++) {
            hearts[i] = transform.GetChild(i).GetComponent<Image>();
        }
    }

    public void UpdateHearts(int currentHealth) {
        for (int i = 0; i < hearts.Length; i++) {
            if (i < currentHealth) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
}
