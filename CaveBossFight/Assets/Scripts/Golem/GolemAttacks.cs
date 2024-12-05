using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(GolemObjectPool))]
public class GolemAttacks : MonoBehaviour
{
    [SerializeField] private Transform _throwPoint;
    private GolemObjectPool _pool;
    private void Start()
    {
        _pool = GetComponent<GolemObjectPool>();
    }

    public void RockThrow()
    {
        _pool.GetFromPool(_throwPoint.position);
    }
}
