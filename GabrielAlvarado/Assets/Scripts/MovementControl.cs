using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour {

    public float speed = 1;
    
    void Start() {
        
    }

    void Update() {

        if (Input.GetKey(KeyCode.LeftArrow)) {
            Vector3 tempVector = Vector3.zero;
            tempVector.x = speed;
            transform.position -= tempVector * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            Vector3 tempVector = Vector3.zero;
            tempVector.z = speed;
            transform.position -= tempVector * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            Vector3 tempVector = Vector3.zero;
            tempVector.x = speed;
            transform.position += tempVector * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 tempVector = Vector3.zero;
            tempVector.z = speed;
            transform.position += tempVector * Time.deltaTime;
        }
    }
}
