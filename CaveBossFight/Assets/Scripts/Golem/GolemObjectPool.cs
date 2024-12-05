using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GolemProjectile))]
public class GolemObjectPool : MonoBehaviour
{
    private GolemProjectile _projectile;

    private void Start()
    {
        _projectile = GetComponent<GolemProjectile>();
    }
}
