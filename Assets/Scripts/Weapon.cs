using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    internal void Fire()
    {
        Debug.Log($"{this.gameObject.name} fired");
    }

}
