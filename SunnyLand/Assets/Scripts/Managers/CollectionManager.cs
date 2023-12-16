using UnityEngine;
using TMPro;

public class CollectionManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI gemUI;
    [SerializeField] private TextMeshProUGUI cherryUI;

    [Header("Healing")]
    [SerializeField] private int amountToCure = 3;
    [SerializeField] private int amountHeal = 1;
    
    private int numCherrysCollected = 0;
    private int numGemsCollected = 0;
    private PlayerHP playerHP;

    void Awake() {
        playerHP = GameObject.FindWithTag("Player").GetComponent<PlayerHP>();

        if (playerHP == null) {
            Debug.Log("Erro ao carregar o HP do Player!");
        }
    }

    private void OnEnable() {
        Cherry.OnCherryCollected += CherryCollected;
        Gem.OnGemCollected += GemCollected;
    }

    private void OnDisable() {
        Cherry.OnCherryCollected -= CherryCollected;
        Gem.OnGemCollected -= GemCollected;
    }

    private void CherryCollected() {
        numCherrysCollected++;

        if (numCherrysCollected >= amountToCure && playerHP.CurrentHealth < playerHP.MaxHealth) {
            numCherrysCollected -= amountToCure;
            playerHP.Heal(amountHeal);
        }

        cherryUI.text = numCherrysCollected.ToString();
    }

    private void GemCollected() {
        numGemsCollected++;
        gemUI.text = numGemsCollected.ToString();
    
    }
}
