using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement: MonoBehaviour {

    [SerializeField]
    private Animator animator;

    void Start() {
        
    }

    void Update() {
        
    }

    public void setMovementState(MovementController.MovementState state) {
        this.animator.SetInteger("HandState", (int) state);
    }
}
