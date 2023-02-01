using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 10f;

    Transform target;

    private void Start()
    {
        target = FindObjectOfType<FirstPersonController>().transform;
    }

    public void AttackHitEvent()
    {
        if (target != null )
        {
            Debug.Log($"bang bang, hit you {target.name}");
        }
    }
}
