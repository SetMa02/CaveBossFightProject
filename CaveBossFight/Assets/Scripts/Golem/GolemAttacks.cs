using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(GolemObjectPool))]
public class GolemAttacks : MonoBehaviour
{
    private GolemObjectPool _pool;
    private void Start()
    {
        _pool = GetComponent<GolemObjectPool>();
    }

    public void RockThrow()
    {
        
    }
}
