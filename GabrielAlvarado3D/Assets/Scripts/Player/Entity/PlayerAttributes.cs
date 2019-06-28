﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour {
    
    public int itemCount { get; private set; }
    public Activator targetActivator;
    
    public void Initialize() {
        itemCount = SceneControl.persistentPlayerData.itemCount;
        transform.position = SceneControl.persistentPlayerData.pointData.position;
        transform.rotation = SceneControl.persistentPlayerData.pointData.rotation;
        GetComponent<ControlledMovement>().characterController.enabled = true;
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Item")) {
            itemCount++;
        } else if (other.CompareTag("Checkpoint")) {
            Checkpoint checkpoint = other.GetComponent<Checkpoint>();
            SceneControl.persistentPlayerData.SetAllData(itemCount, checkpoint.pointData);
            FindObjectOfType<CheckpointControl>().SetCurrentActive(checkpoint);
        }
    }
}
