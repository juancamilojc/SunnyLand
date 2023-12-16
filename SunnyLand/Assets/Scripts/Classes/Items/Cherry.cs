using UnityEngine;
using System;

public class Cherry : MonoBehaviour, ICollectible {
    public static event Action OnCherryCollected;
    private Animator cherryAnimator;

    void Start() {
        cherryAnimator = GetComponent<Animator>();
    }

    public void Collect() {
        OnCherryCollected?.Invoke();
        GetComponent<CircleCollider2D>().enabled = false;
        cherryAnimator.SetBool("Collected", true);
        Destroy(gameObject, 0.5f);
        Debug.Log("Cereja Coletada!");
    }
}
