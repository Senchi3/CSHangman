using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSwitch : Activator {

    Transform lever;
    bool isInRange = false;

    // Start is called before the first frame update
    void Start() {
        lever = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update() {

    }

    protected override void ShowAction() {
        Vector3 leverAngles = lever.eulerAngles;
        leverAngles.x *= -1;
        lever.eulerAngles = leverAngles;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            isInRange = true;
            other.GetComponent<PlayerAttributes>().targetActivator = this;
        }
    }

    void OnGUI() {
        if (isInRange) {
            GUI.Label(new Rect(10, 250, 120, 30), "Press E to activate");
        }
    }

    void OnTriggerExit(Collider other) {
        PlayerAttributes player = other.GetComponent<PlayerAttributes>();
        if (player && player.targetActivator == this) {
            isInRange = false;
            player.targetActivator = null;
        }
    }
}
