using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    public float speed = 15;
    public Vector3 direction = Vector3.right;
    public float lifespan = 1.5f;

    void Start() {
        Destroy(gameObject, lifespan);
    }

    void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Hazard")) {
            Destroy(other.gameObject);
        }

        if (!other.CompareTag("CamArea")) {
            Destroy(gameObject);
        }
    }
}
