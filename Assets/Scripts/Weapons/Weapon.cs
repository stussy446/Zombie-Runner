using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    ShootInput weaponInputs;
    Camera cam;
    RaycastHit hit;

    bool isShooting;
    bool isZooming;
    WeaponZoom weaponZoom;
    WeaponSwitcher weaponSwitcher;

    [Header("Weapon Configurations")]
    [SerializeField] float bulletRange;
    [SerializeField] LayerMask shootableLayer;
    [SerializeField] float damage;
    [SerializeField] ParticleSystem muzzleFlashParticles;
    [SerializeField] GameObject hitImpactParticles;

    [Header("Ammo Slot")]
    [SerializeField] Ammo ammoSlot;

    [Header("Debug setting")]
    [Tooltip("shows trajectory of shot if enabled")][SerializeField] bool debugMode;

    protected virtual bool IsShooting
    {
        get { return isShooting; }
        set { isShooting = value; }
    }

    private void Awake()
    {
        weaponInputs = new ShootInput();
        cam = Camera.main;
        weaponZoom = GetComponent<WeaponZoom>();
        weaponSwitcher = GetComponentInParent<WeaponSwitcher>();
    }

    private void OnEnable()
    {
        weaponInputs.Enable();

        weaponInputs.Shoot.Fire.started += ctx => Startshot();
        weaponInputs.Shoot.Fire.canceled += ctx => EndShot();

        weaponInputs.Shoot.Zoom.started += ctx => StartZoom();
        weaponInputs.Shoot.Zoom.canceled += ctx => EndZoom();

        weaponInputs.Shoot.SwitchWeapons.performed += ctx => SwitchWeapons();
    }

    private void StartZoom()
    {
        isZooming = true;
    }

    private void EndZoom()
    {
        isZooming = false;
        if (weaponZoom != null)
        {
            weaponZoom.UnZoom();
        }
    }

    private void Update()
    {
        if (isShooting && !ammoSlot.OutOfAmmo())
        {
            PerformShot();
        }

        if (isZooming && weaponZoom != null)
        {
            weaponZoom.Zoom();
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

    protected virtual void PerformShot()
    {
      
        Vector3 direction = cam.transform.forward;

        if (debugMode)
        {
            Debug.DrawRay(cam.transform.position, direction * bulletRange, Color.red, 20f, false);
        }

        PlayMuzzleFlash();

        if (Physics.Raycast(cam.transform.position, direction, out hit, bulletRange, shootableLayer))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            CreateHitImpact(hit);
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

        ammoSlot.ReduceAmmo();
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitImpactParticles, hit.point, Quaternion.LookRotation(hit.normal));

        ParticleSystem[] effects = impact.GetComponentsInChildren<ParticleSystem>();
        foreach (var effect in effects)
        {
            effect.Play();
        }
        
        Destroy(impact, 0.1f);
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlashParticles.Play();
    }

    private void OnDisable()
    {
        weaponInputs.Disable();
    }

    private void SwitchWeapons()
    {
        weaponSwitcher.SetActiveWeapon();
    }
}
