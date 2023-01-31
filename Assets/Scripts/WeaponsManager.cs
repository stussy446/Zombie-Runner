using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponsManager : MonoBehaviour
{
    [SerializeField] Weapon[] availableWeapons;

    Weapon equippedWeapon;

    private void Awake()
    {
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
}
