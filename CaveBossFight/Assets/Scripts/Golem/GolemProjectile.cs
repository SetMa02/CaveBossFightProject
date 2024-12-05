using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GolemProjectile : MonoBehaviour
{
    [SerializeField]private float _acceleration = 2f;
    [SerializeField]private float _maxSpeed = 10f;
    [SerializeField]private float _homingDuration = 2f;
    
    private Transform _target;           
    private float _currentSpeed = 0f;   
    private Vector3 _direction;        
    private bool _isHoming = true;     

    void Start()
    {
       SetUpTarget();
    }

    void Update()
    {
       ProjectileFlight();
    }

    private void SetUpTarget()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        
        if (_target != null)
        {
            _direction = (_target.position - transform.position).normalized;
        }
        else
        {
            Debug.LogWarning("Target not assigned for the projectile.");
        }
        
        Invoke(nameof(DisableHoming), _homingDuration);
    }

    private void ProjectileFlight()
    {
        _currentSpeed = Mathf.Min(_currentSpeed + _acceleration * Time.deltaTime, _maxSpeed);
        
        if (_isHoming && _target != null)
        {
            _direction = (_target.position - transform.position).normalized;
        }
        
        transform.position += _direction * _currentSpeed * Time.deltaTime;
        
        if (_direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _direction);
        }
    }

    private void DisableHoming()
    {
        _isHoming = false;
    }
}

