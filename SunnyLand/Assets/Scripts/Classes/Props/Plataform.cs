using UnityEngine;

public class Plataform : MonoBehaviour {
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private bool horizontal = true;
    private bool moveToB = true;

    // Update is called once per frame
    void Update() {
        Move();
    }

    private void Move() {
        if (horizontal) {
            if (transform.position.x < pointA.position.x) {
                moveToB = true;
            } else if (transform.position.x > pointB.position.x) {
                moveToB = false;
            }

            if (moveToB) {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            } else {
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            }
        } else {
            if (transform.position.y > pointA.position.y) {
                moveToB = true;
            } else if (transform.position.y < pointB.position.y) {
                moveToB = false;
            }

            if (moveToB) {
                transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            } else {
                transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
            }
        }
    }

    // Se o Player pisar numa plataforma movel, ela se torna 'Pai' dele, movendo ele junto.
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.transform.SetParent(transform);
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
            Debug.Log("Pisou na Plataforma!");
        }
    }

    // Se o Player parar de pisar em uma plataforma movel, ela deixa de ser 'Pai' dele.
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.transform.SetParent(null);
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
            Debug.Log("Saiu da Plataforma!");
        }
    }
}