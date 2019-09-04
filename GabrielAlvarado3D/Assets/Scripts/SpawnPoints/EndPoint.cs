using GameUtilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour {
    SceneControl sceneControl;

    void OnTriggerEnter(Collider other) {
        sceneControl.LoadScene(2);
    }
}
