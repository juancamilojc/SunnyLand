using UnityEngine;
using TMPro;

public class CollectionManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI gemUI;
    [SerializeField] private TextMeshProUGUI cherryUI;

    [Header("Healing")]
    [SerializeField] private int amountToCure = 3;
    [SerializeField] private int amountHeal = 1;
    [SerializeField] private HealthSystem playerHP;

    private int numCherrysCollected = 0;
    private int numGemsCollected = 0;

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
