using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 15;
    public Vector2 limits = new Vector2(5, 3.5f);

    void Update() {
        // Get current horizontal movement
        float horDirection = Input.GetAxisRaw("Horizontal");
        Vector3 horMove = horDirection * Vector3.right;

        // Get current vertical movement
        float verDirection = Input.GetAxisRaw("Vertical");
        Vector3 verMove = verDirection * Vector3.up;

        Vector3 temp = transform.position;
        transform.Translate((horMove + verMove).normalized * moveSpeed * Time.deltaTime);

        temp.x = Mathf.Clamp(transform.position.x, -limits.x, limits.x);
        temp.y = Mathf.Clamp(transform.position.y, -limits.y, limits.y);
        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Wow! It works!");
    }

    void OnDrawGizmos () {
        Gizmos.DrawSphere(transform.position, 0.15f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, limits * 2);
    }
}