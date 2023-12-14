using UnityEngine;
using System;

public class Cherry : MonoBehaviour, ICollectible {
    public static event Action OnCherryCollected;

    public void Collect() {
        Debug.Log("Cereja Coletada!");
        OnCherryCollected?.Invoke();
        Destroy(gameObject);
    }
}
