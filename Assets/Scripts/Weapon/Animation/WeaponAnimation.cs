using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation: MonoBehaviour {

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Animator triggerAnimator;
    [SerializeField]
    private ParticleSystem flashParticle;
    [SerializeField]
    private ParticleSystem smokeTrail;

    private bool aimingState;

    void Start() {
        
    }

    void Update() {
        
    }

    public void trySetAim(bool newState) {
        if (newState != this.aimingState) {
            this.aimingState = newState;
            animator.SetBool("Aiming", newState);
        }
    }

    public void onFire(Vector3 hit) {
        this.triggerAnimator.SetTrigger("Trigger");
        this.flashParticle.Play();

        Vector3 origin = this.smokeTrail.transform.position;
        Vector3 dir = hit - origin;
        float distance = dir.magnitude;
        dir /= distance;

        this.smokeTrail.transform.LookAt(hit);

        var shape = this.smokeTrail.shape;
        shape.length = distance;

        this.smokeTrail.Play();
    }
}
