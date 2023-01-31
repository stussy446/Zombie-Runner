using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    ShootInput weaponInputs;
    Camera cam;
    RaycastHit hit;
    bool isShooting;
    bool readyToShoot;

    [SerializeField] float bulletRange;
    [SerializeField] LayerMask shootableLayer;
    [SerializeField] bool debugMode;
    
    private void Awake()
    {
        weaponInputs = new ShootInput();
        cam = Camera.main;
    }

    private void OnEnable()
    {
        weaponInputs.Enable();
        weaponInputs.Shoot.Fire.started += ctx => Startshot();
        weaponInputs.Shoot.Fire.canceled += ctx => EndShot();

    }

    private void Update()
    {
        if (isShooting)
        {
            PerformShot();
        }
    }

    private void Startshot()
    {
        Debug.Log("Shot");
        isShooting = true;
    }

    private void EndShot()
    {
        Debug.Log("Shot ended");
        isShooting = false;
    }

    private void PerformShot()
    {
        readyToShoot = false;
        Vector3 direction = cam.transform.forward;

        if (debugMode)
        {
            Debug.DrawRay(cam.transform.position, direction * bulletRange, Color.red, 20f, false);
        }


        if (Physics.Raycast(cam.transform.position, direction, out hit, bulletRange, shootableLayer))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }

    private void ResetShot()
    {

    }

    private void Reload()
    {

    }

    private void ReloadFinish()
    {

    }

    private void OnDisable()
    {
        weaponInputs.Disable();
    }

}
