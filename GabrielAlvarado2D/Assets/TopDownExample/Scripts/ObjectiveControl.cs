using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveControl : MonoBehaviour {

    public GameObject targetWall;
    public int remainingEnemies = 0;
    public int nextScene;

    // Start is called before the first frame update
    void Start() {
        nextScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
        remainingEnemies = GameObject.FindGameObjectsWithTag("Hazard").Length;
    }

    // Update is called once per frame
    void Update() {
        if (remainingEnemies <= 0 && targetWall) {
            Destroy(targetWall);
        }
    }

    public void EndGame() {
        Application.Quit();
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 120, 50), "Remaining enemies: " + remainingEnemies);
    }
}
