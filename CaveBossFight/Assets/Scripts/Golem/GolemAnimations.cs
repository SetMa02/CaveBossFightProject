using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof(Animator))]
public class GolemAnimations : MonoBehaviour
{
    private MeshCollider _collider;
    private MeshFilter _filter;
    private Animator _animator;
    private string _throwAttack; 

    private void Start()
    {
        _throwAttack = "ThrowAttack";
       _animator = GetComponent<Animator>();
        _collider = GetComponentInChildren<MeshCollider>();
        _filter = GetComponentInChildren<MeshFilter>();
        
    }

    public void PlayAttackAnimation()
    {
        _animator.SetTrigger(_throwAttack);
    }

    private void LateUpdate()
    {
        UpdateMeshCollider();
    }

    private void UpdateMeshCollider()
    {
        _collider.sharedMesh = null; 
        _collider.sharedMesh =_filter.mesh; 
    }
}
