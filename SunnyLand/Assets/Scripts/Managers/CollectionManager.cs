using UnityEngine;
using TMPro;

public class CollectionManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI cherryUI;
    [SerializeField] private TextMeshProUGUI gemUI;
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
        cherryUI.text = numCherrysCollected.ToString();
    }

    private void GemCollected() {
        numGemsCollected++;
        gemUI.text = numGemsCollected.ToString();
    
    }
}
