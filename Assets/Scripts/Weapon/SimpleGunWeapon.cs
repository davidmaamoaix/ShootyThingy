using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGunWeapon: MonoBehaviour {

    private WeaponAnimation weaponAnimation;
    private MovementController playerMovement;
    private GameObject cameraHolder;
    private Camera cam;

    // Weapon properties.
    private int maxCoolDown;
    private bool automaticFire;
    private int maxRecoil;
    private int recoilMag;

    private int recoil;
    private int coolDown;
    private int framesSinceLastFired;

    protected SimpleGunWeapon(
            int maxCoolDown, bool automaticFire, int recoil, int recoilMag
            ) {
        this.maxCoolDown = maxCoolDown;
        this.automaticFire = automaticFire;
        this.maxRecoil = recoil;
        this.recoilMag = recoilMag;
    }

    void Start() {
        this.weaponAnimation = this.GetComponent<WeaponAnimation>();
        this.cam = GameUtils.findComponentOnObject<Camera>("PlayerCamera");

        this.cameraHolder = GameObject.Find("RecoilDisplay");
        
        GameObject player = GameObject.Find("Player");
        this.playerMovement = player.GetComponent<MovementController>();
    }

    void Update() {
        if (Input.GetMouseButton(1)) {
            this.weaponAnimation.trySetAim(true);
            this.playerMovement.maxSpeed = Constants.DEFAULT_MAX_SPEED * 0.5F;

            if (this.cam.fieldOfView > Constants.ZOOM_FOV) {
                this.cam.fieldOfView -= 2.5F;
            }
        } else {
            this.weaponAnimation.trySetAim(false);
            this.playerMovement.maxSpeed = Constants.DEFAULT_MAX_SPEED;

            if (this.cam.fieldOfView < Constants.DEFAULT_FOV) {
                this.cam.fieldOfView += 2.5F;
            }
        }

        if (!this.automaticFire && Input.GetMouseButtonDown(0)) {
            if (this.coolDown <= 0) {
                this.fire();
                this.coolDown = this.maxCoolDown;
            }
        }

        float slerpSize = 0.5F;
        if (this.framesSinceLastFired > 10) {
            this.recoil = Mathf.Max(this.recoil - 10, 0);
            slerpSize = 0.25F;
        }

        Vector3 rot = new Vector3(-this.recoil / 10F, 0, 0);
        Quaternion from = this.cameraHolder.transform.localRotation;
        Quaternion to = Quaternion.Euler(rot);
        Quaternion change = Quaternion.Slerp(from, to, slerpSize); ;
        this.cameraHolder.transform.localRotation = change;

        ++this.framesSinceLastFired;
    }

    void FixedUpdate() {
        if (this.automaticFire && Input.GetMouseButton(0)) {
            if (this.coolDown <= 0) {
                this.fire();
                this.coolDown = this.maxCoolDown;
            }
        }

        --this.coolDown;
    }

    private void fire() {
        Vector3 p = this.cam.ViewportToWorldPoint(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(p, this.cam.transform.forward, out hit)) {
            this.weaponAnimation.onFire(hit.point);
        } else {
            this.weaponAnimation.onFire(p + this.cam.transform.forward * 100);
        }

        this.recoil = Mathf.Min(this.recoil + this.recoilMag, this.maxRecoil);

        this.framesSinceLastFired = 0;
    }

    private void offsetCamera(int amount) {

    }
}
