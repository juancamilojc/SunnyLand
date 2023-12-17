using System;
using UnityEngine;

public class PlayerHP : MonoBehaviour, IHealthSystem {
    [SerializeField] private int _maxHealth = 5;
    [SerializeField] private int _currentHealth = 3;
    private HealthUI healthUI;
    private PlayerController player;
    private Animator anim;

    public static event Action OnPlayerDead;
    public static event Action OnPlayerDamage;

    public int MaxHealth { 
        get { return _maxHealth; }
        set { _maxHealth = Mathf.Max(1, value); }
    }
    
    public int CurrentHealth {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, _maxHealth); }
    }

    void Awake() {
        anim = GetComponentInParent<Animator>();
        healthUI = FindObjectOfType<HealthUI>();
        player = GetComponentInParent<PlayerController>();
    }

    void Start() {
        if (healthUI != null && player != null) {
            healthUI.UpdateHearts(_currentHealth);
        } else {
            Debug.Log("Erro ao encontrar a UI de HP e o Player!");
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
        Debug.Log("Tomou Dano!");
    }

    private void CheckDead(int hp) {
        if (hp <= 0) {
            OnPlayerDead?.Invoke();
            Debug.Log("No céu tem pão? E morreu!");
            GetComponent<CapsuleCollider2D>().enabled = false;
            anim.enabled = false;
            //this.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Damage1")) {
            player.kbCounter = player.kbTotalTime;

            if (collision.transform.position.x  >= transform.position.x) {
                player.knockFromRight = true;
            } else if (collision.transform.position.x < transform.position.x) {
                player.knockFromRight = false;
            }
            //TakeDamage(1);
            OnPlayerDamage?.Invoke();
        } else if (collision.CompareTag("Void")) {
            TakeDamage(1);
            player.ResetPosition();
        }
    }
}
