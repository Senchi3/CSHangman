using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovingPlatform : MovingPlatform {
    
    // Start is called before the first frame update
    void Start() {
        SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        if (currentlyActive && movePoints.Count > 1) {
            Vector3 lastPosition = transform.position;
            transform.position = Vector3.MoveTowards(transform.position, movePoints[targetPoint], speed * Time.deltaTime);
            lastMovement = transform.position - lastPosition;
            if (transform.position == movePoints[targetPoint]) {
                if ((targetPoint == movePoints.Count - 1) || targetPoint == 0 && direction < 0) {
                    if (loops) {
                        targetPoint = -1;
                    } else {
                        direction *= -1;
                    }
                }
                targetPoint += direction;
            }
        }
    }
}
