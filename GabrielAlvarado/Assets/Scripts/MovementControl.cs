using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour {

    private Rigidbody rb;
    private bool canJump;

    public float speed = 1f;
    public float jumpForce = 10f;


    void Start() {
        rb = GetComponent<Rigidbody>();
        canJump = true;
    }
    

    void Update() {

        // Movement condition
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h, 0, v) * speed * Time.deltaTime;

        // Jump condition
        if (Input.GetKeyDown(KeyCode.Space) && canJump) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }

    }

    
    // Collisions

    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            canJump = true;
        }
    }


    // Triggers

    void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger enter!");
        other.GetComponent<ChangeMaterial>().ChangeMaterialToNew();
    }

    void OnTriggerExit(Collider other) {
        Debug.Log("Trigger exit!");
        other.GetComponent<ChangeMaterial>().ChangeMaterialToOld();
    }
}
