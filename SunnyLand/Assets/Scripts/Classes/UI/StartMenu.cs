using System.Collections;
using UnityEngine;

public class StartMenu : MonoBehaviour {
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private Animator startMenuAnim;
    
    void Start() {
        levelLoader = FindAnyObjectByType<LevelLoader>();
        startMenuAnim = GetComponent<Animator>();

        StartCoroutine(StartMenuWait());
    }

    void Update() {
        if (Input.GetButtonDown("Start")) {
            StartCoroutine(StartGame());
        }
    }

    private IEnumerator StartMenuWait() {
        yield return new WaitForSeconds(1.25f);
        startMenuAnim.SetTrigger("Wait");
    }

    private IEnumerator StartGame() {
        startMenuAnim.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        levelLoader.LoadNextLevel();
    }
}
