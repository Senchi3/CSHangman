using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    const int testLength = 20;
    Vector2 boxSize = new Vector2(200, 100);
    
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.up * -testLength, Vector3.up * testLength);
        Gizmos.DrawLine(Vector3.right * -testLength, Vector3.right * testLength);
    }
}
