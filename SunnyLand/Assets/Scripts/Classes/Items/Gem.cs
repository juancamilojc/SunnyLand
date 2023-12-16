using UnityEngine;
using System;

public class Gem : MonoBehaviour, ICollectible {
    public static event Action OnGemCollected;
    private Animator gemAnimator;
    private readonly float amplitude = 0.25f;
    private readonly float speed = 2.5f;
    private Vector2 startPos;

    void Awake() {
        startPos = transform.position;
    }

    void Start() {
        gemAnimator = GetComponent<Animator>();
    }

    void Update() {
        float newY = startPos.y + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = new Vector2(startPos.x, newY);
    }

    public void Collect() {
        OnGemCollected?.Invoke();
        GetComponent<CircleCollider2D>().enabled = false;
        gemAnimator.SetBool("Collected", true);
        Destroy(gameObject, 0.5f);
        Debug.Log("Gema Coletada!");
    }
}
