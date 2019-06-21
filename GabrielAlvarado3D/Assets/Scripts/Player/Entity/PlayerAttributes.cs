﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour {
    
    public int itemCount { get; private set; }
    
    public void Initialize() {
        itemCount = SceneControl.persistentPlayerData.itemCount;
        transform.position = SceneControl.persistentPlayerData.position;
        transform.rotation = SceneControl.persistentPlayerData.rotation;
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Item")) {
            itemCount++;
        } else if (other.CompareTag("Checkpoint")) {
            SceneControl.persistentPlayerData.SetData(itemCount, other.transform.position + Vector3.up, other.transform.rotation);
        }
    }
}
