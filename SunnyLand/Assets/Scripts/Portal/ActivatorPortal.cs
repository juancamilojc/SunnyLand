using UnityEngine;

public class ActivatorPortal : MonoBehaviour {
    [SerializeField] private Animator portalAnim;
    [SerializeField] private Transform portal;
    [SerializeField] private Transform player;
    [SerializeField] private float distanceOfActivate = 5f;
    private float playerDistance;

    void Start() {
        portalAnim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>().transform;
        portal = GetComponentInChildren<NextLevel>().transform;

        if (portalAnim == null || portal == null || player == null) {
            Debug.Log("Erro ao obter objetos para o funcionamento correto do Portal!");
            return;
        }
    }

    void Update() {
        playerDistance = Vector2.Distance(transform.position, player.position);
        portalAnim.SetFloat("PlayerDistance", playerDistance);

        if (Vector2.Distance(transform.position, player.position) < distanceOfActivate) {
            portalAnim.SetBool("PortalEnable", true);
        } else if (Vector2.Distance(transform.position, player.position) > distanceOfActivate){
            portalAnim.SetBool("PortalEnable", false);
        }

    }
}
