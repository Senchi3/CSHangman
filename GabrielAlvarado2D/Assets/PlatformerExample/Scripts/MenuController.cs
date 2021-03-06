﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    const int testLength = 20;
    Vector2 boxSize = new Vector2(200, 100);
    
    public void MoveToLevel (int index) {
        SceneManager.LoadScene(index);
    }

    public void EndGame() {
        Application.Quit();
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.up * -testLength, Vector3.up * testLength);
        Gizmos.DrawLine(Vector3.right * -testLength, Vector3.right * testLength);
    }
}