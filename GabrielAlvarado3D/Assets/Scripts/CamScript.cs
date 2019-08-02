using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

    public MovScript movingTarget;
    public Vector3 distanceFromTarget;
    public float yPosition;
    Vector3 distancePoint { get { return movingTarget.position + movingTarget.EqualizeWithLocal (distanceFromTarget); } }
    Vector3 cameraPoint { get { return movingTarget.transform.position + movingTarget.transform.forward + (Vector3.up * yPosition); } }

    // Start is called before the first frame update
    void Start () {
        
    }

    // Update is called once per frame
    void LateUpdate () {
        if (movingTarget) {
            if (movingTarget.activeControl) {
                transform.position = distancePoint;
            }
            transform.LookAt (cameraPoint);
        }
    }

    void OnDrawGizmos () {
        if (movingTarget) {
            Gizmos.DrawWireSphere (distancePoint, 0.25f);
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine (distancePoint, cameraPoint);
            Gizmos.DrawWireSphere(cameraPoint, 0.25f);
        }
    }
}
