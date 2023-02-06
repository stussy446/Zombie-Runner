using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] float shotDelay;

    bool shotFired;
    
    protected override void PerformShot()
    {
        if (!shotFired)
        {
            base.PerformShot();
            StartCoroutine(DelayNextShot());
        }
    }

    private IEnumerator DelayNextShot()
    {
        shotFired = true;
        yield return new WaitForSeconds(shotDelay);
        shotFired = false;
    }
}
