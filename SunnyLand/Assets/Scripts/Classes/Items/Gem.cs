using UnityEngine;
using System;

public class Gem : MonoBehaviour, ICollectible {
    public static event Action OnGemCollected;

    public void Collect() {
        Debug.Log("Gema Coletada!");
        OnGemCollected?.Invoke();
        Destroy(gameObject);
    }
}
