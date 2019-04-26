using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour {
    public float speed = 1;

    void Start() {
        
    }
    
    void Update() {
        transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
    }
}
