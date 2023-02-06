using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 10;

    public int AmmoCount
    {
        get { return ammoAmount; }
    }

    public int ReduceAmmo(int reduction=1)
    {
        ammoAmount -= reduction;
        if (OutOfAmmo())
        {
            ammoAmount = 0;
            Debug.Log("out of ammo");
        }

        return ammoAmount;
    }

    public bool OutOfAmmo()
    {
        return ammoAmount <= 0;
    }
}
