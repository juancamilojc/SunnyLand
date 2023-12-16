using UnityEngine;

public class PlayerHP : MonoBehaviour, IHealthSystem {
    [SerializeField] private int _maxHealth = 5;
    [SerializeField] private int _currentHealth = 3;
    private HealthUI healthUI;

    public int MaxHealth { 
        get { return _maxHealth; }
        set { _maxHealth = Mathf.Max(1, value); }
    }
    
    public int CurrentHealth {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, _maxHealth); }
    }

    void Awake() {
        healthUI = FindObjectOfType<HealthUI>();
    }

    void Start() {
        if (healthUI != null) {
            healthUI.UpdateHearts(_currentHealth);
        } else {
            Debug.Log("Erro ao encontrar a UI de HP do Player!");
            return;
        }
    }

    public void Heal(int heal) {
        _currentHealth += heal;
        healthUI.UpdateHearts(_currentHealth);
    }

    public void TakeDamage(int damage) {
        _currentHealth -= damage;
        healthUI.UpdateHearts(_currentHealth);
        CheckDead(_currentHealth);
    }

    private void CheckDead(int hp) {
        if (hp <= 0) {
            Debug.Log("No céu tem pão? E morreu!");
        }
    }
}
