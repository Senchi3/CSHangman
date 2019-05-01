using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour {
    public float speed = 1;
    public bool isBounce = false;

    void Start() {
        
    }
    
    void Update() {
        if (isBounce) {
            isBounce = isBounce;
        } else {
            transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
        }
    }
}
