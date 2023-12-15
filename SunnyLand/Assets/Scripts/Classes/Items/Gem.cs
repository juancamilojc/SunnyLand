using UnityEngine;
using System;

public class Gem : MonoBehaviour, ICollectible {
    public static event Action OnGemCollected;
    private readonly float amplitude = 0.25f;
    private readonly float speed = 2.5f;
    private Vector2 startPos;

    void Awake() {
        startPos = transform.position;
    }

    void Update() {
        float newY = startPos.y + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = new Vector2(startPos.x, newY);
    }

    public void Collect() {
        Debug.Log("Gema Coletada!");
        OnGemCollected?.Invoke();
        Destroy(gameObject);
    }
}
