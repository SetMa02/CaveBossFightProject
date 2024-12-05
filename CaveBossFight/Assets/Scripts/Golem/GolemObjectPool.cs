using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemObjectPool : MonoBehaviour
{
    [SerializeField] private int _poolSize = 50;
    [SerializeField] private Transform _poolStorge;
    [SerializeField] private GolemProjectile _projectile;
    private List<GolemProjectile> _pool;
    
    private void Start()
    {
        PoolInit();
    }
    
    public void GetFromPool(Vector3 position)
    {
        var projectile = _pool[0];
        _pool.RemoveAt(0);
        projectile.SetParentTransform(_poolStorge.transform, _pool);
        projectile.transform.position = position;
        _projectile.gameObject.SetActive(true);
    }

    private void PoolInit()
    {
        _pool = new List<GolemProjectile>();
        for (int i = 0; i < _poolSize; i++)
        {
            var projectile = Instantiate(_projectile, _poolStorge);
            _pool.Add(projectile);
            _projectile.gameObject.SetActive(false);
        }   
    }
    
}
