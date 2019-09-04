using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Activable {

    public List<Vector3> movePoints;
    public int targetPoint;
    public int direction = 1;
    public int speed = 2;
    public bool loops = false;
    public Vector3 lastMovement { get; set; }

    // Update is called once per frame
    void Update() {
        if (currentlyActive && movePoints.Count > 1) {
            Vector3 lastPosition = transform.position;
            transform.position = Vector3.MoveTowards(transform.position, movePoints[targetPoint], speed * Time.deltaTime);
            lastMovement = transform.position - lastPosition;
            if (transform.position == movePoints[targetPoint]) {
                if ((targetPoint == movePoints.Count - 1) || targetPoint == 0 && direction < 0) {
                    direction *= -1;
                }
                targetPoint += direction;
            }
        }
    }

    void OnDrawGizmos() {
        if(movePoints.Count > 1) {
            foreach (Vector3 point in movePoints) {
                Gizmos.DrawCube(point, Vector3.one * 0.5f);
            }
        }
    }
}
