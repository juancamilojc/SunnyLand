using UnityEngine;

public class HealthSystem : MonoBehaviour {
    [SerializeField] private int _maxHealth = 5;
    [SerializeField] private int _currentHealth = 3;
    [SerializeField] private HealthUI healthUI;

    void Start() {
        healthUI.UpdateHearts(CurrentHealth);
    }

    public int MaxHealth { 
        get { return _maxHealth; }
        set { _maxHealth = Mathf.Max(1, value); }
    }
    
    public int CurrentHealth {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, _maxHealth); }
    }

    public void Heal(int heal) {
        CurrentHealth += heal;
        healthUI.UpdateHearts(CurrentHealth);
    }

    public void TakeDamage(int damage) {
        CurrentHealth -= damage;
        healthUI.UpdateHearts(CurrentHealth);
        CheckDead(CurrentHealth);
    }

    private void CheckDead(int hp) {
        if (hp <= 0) {
            Debug.Log("No céu tem pão? E morreu!");
        }
    }
}
