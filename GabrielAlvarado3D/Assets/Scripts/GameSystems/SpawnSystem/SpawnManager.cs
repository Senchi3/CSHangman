﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager instance;

    public List<SpawnableEntity> spawnableEntities;

    // Start is called before the first frame update
    void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update() {

    }

    public SpawnableEntity Search(string id) {
        return spawnableEntities.Find(entity => entity.id == id);
    }
}
