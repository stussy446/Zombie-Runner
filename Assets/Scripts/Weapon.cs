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

    [SerializeField] float bulletRange;
    [SerializeField] LayerMask shootableLayer;
    [SerializeField] bool debugMode;
    [SerializeField] float damage;
    [SerializeField] ParticleSystem muzzleFlashParticles;

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
        isShooting = true;
    }

    private void EndShot()
    {
        isShooting = false;
    }

    private void PerformShot()
    {
        Vector3 direction = cam.transform.forward;

        if (debugMode)
        {
            Debug.DrawRay(cam.transform.position, direction * bulletRange, Color.red, 20f, false);
        }

        PlayMuzzleFlash();

        if (Physics.Raycast(cam.transform.position, direction, out hit, bulletRange, shootableLayer))
        {
            Debug.Log(hit.collider.gameObject.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlashParticles.Play();

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