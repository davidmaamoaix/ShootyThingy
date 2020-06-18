using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour {

    private enum HeadTilt {
        Middle,
        Left,
        Right
    }

    [SerializeField]
    private Animator animator;

    private HeadTilt tiltState = HeadTilt.Middle;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (this.tiltState == HeadTilt.Left) {
                this.tiltState = HeadTilt.Middle;
                animator.SetInteger("TiltState", 0);
            } else {
                this.tiltState = HeadTilt.Left;
                animator.SetInteger("TiltState", 1);
            }
        } else if (Input.GetKeyDown(KeyCode.E)) {
            if (this.tiltState == HeadTilt.Right) {
                this.tiltState = HeadTilt.Middle;
                animator.SetInteger("TiltState", 0);
            } else {
                this.tiltState = HeadTilt.Right;
                animator.SetInteger("TiltState", 2);
            }
        }
    }
}
