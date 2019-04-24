using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour {

    private Rigidbody rb;
    private bool canJump;

    public KeyCode positiveButton = KeyCode.UpArrow;
    public KeyCode negativeButton = KeyCode.DownArrow;

    public float speed = 1f;
    public float jumpForce = 10f;


    void Start() {
        rb = GetComponent<Rigidbody>();
    }


    void Update() {

        // Movement condition
        Vector3 horizontal = Vector3.right * GetAxis(KeyCode.RightArrow, KeyCode.LeftArrow);
        Vector3 vertical = Vector3.forward * GetAxis(KeyCode.UpArrow, KeyCode.DownArrow);
        
        transform.Translate((horizontal + vertical).normalized * speed * Time.deltaTime);

        // Jump condition
        if (Input.GetKeyDown(KeyCode.Space) && canJump) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }

    }
    
    int GetAxis (KeyCode positive, KeyCode negative) {

        int up = 0, down = 0;

        if (Input.GetKey (positive)) {
            up = 1;
        }

        if (Input.GetKey(negative)) {
            down = 1;
        }

        return up - down;
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
