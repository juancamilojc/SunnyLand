using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour {
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    private bool moveRight = true;

    // Update is called once per frame
    void Update() {
        Move();
    }

    private void Move() {
        if (transform.position.x < pointA.position.x) {
            moveRight = true;
        } else if (transform.position.x > pointB.position.x) {
            moveRight = false;
        }

        if (moveRight) {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        } else {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
