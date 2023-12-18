using System;
using UnityEngine;

public class FinalPoint : MonoBehaviour {
    public static event Action OnFinalGame;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            OnFinalGame?.Invoke();
            Debug.Log("Final do Sunny Land, Obrigado por jogar! :)");
        }
    }
}
