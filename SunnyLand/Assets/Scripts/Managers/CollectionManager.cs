using UnityEngine;
using TMPro;

public class CollectionManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI gemUI;
    private int numGemsCollected = 0;
    [SerializeField] private TextMeshProUGUI cherryUI;
    private int numCherrysCollected = 0;

    private void OnEnable() {
        Gem.OnGemCollected += GemCollected;
        Cherry.OnCherryCollected += CherryCollected;
    }

    private void OnDisable() {
        Gem.OnGemCollected -= GemCollected;
        Cherry.OnCherryCollected -= CherryCollected;
    }

    private void GemCollected() {
        numGemsCollected++;
        gemUI.text = numGemsCollected.ToString();
    
    }

    private void CherryCollected() {
        numCherrysCollected++;
        cherryUI.text = numCherrysCollected.ToString();
    }
}
