using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] Weapon[] availableWeapons;

    ShootInput shootInput;
    Weapon equippedWeapon;

    private void Awake()
    {
        shootInput = new ShootInput();
        if (availableWeapons.Length < 2)
        {
            equippedWeapon = availableWeapons[0];
        }
        else
        {
            equippedWeapon = availableWeapons[0];
            //TODO add ability to choose starting weapon

        }

    }

    private void OnEnable()
    {
        shootInput.Enable();

        shootInput.Shoot.Fire.performed += OnShoot;
    }

    private void OnDisable()
    {
        shootInput.Shoot.Fire.performed -= OnShoot;
        shootInput.Disable();
    }

    private void OnShoot(InputAction.CallbackContext obj)
    {
        equippedWeapon.Fire();
    }
}
