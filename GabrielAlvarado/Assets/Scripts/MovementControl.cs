using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour {
    
    public KeyCode positiveButton = KeyCode.UpArrow;
    public KeyCode negativeButton = KeyCode.DownArrow;
    public float speed = 1f;
    public float jumpForce = 10f;
    
    Rigidbody rb;
    bool canJump;
    Vector3 originalPos;

    int pointCount = 0;

    void Start() {
        rb = GetComponent<Rigidbody>();
        originalPos = transform.position;
    }


    void Update() {

        // Run condition
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            speed = speed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = speed / 2;
        }
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
        if (other.tag == "Hazard") {
            Debug.Log("Hit by " + other.name + ".");
            transform.position = originalPos;
        } else if (other.tag == "Collectible") {
            Debug.Log("Collected " + other.name + ".");
            pointCount++;
            Destroy(other.gameObject);
        }
    }
    
    void OnGUI () {
        GUI.Label(new Rect(10,10, 100, 50), "Points: " + pointCount);
    }

}
