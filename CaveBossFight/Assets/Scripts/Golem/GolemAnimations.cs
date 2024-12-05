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
    private bool _canPlayAnimation = true;

    private void Start()
    {
        _throwAttack = "ThrowAttack";
        _animator = GetComponent<Animator>();
        _collider = GetComponentInChildren<MeshCollider>();
        _filter = GetComponentInChildren<MeshFilter>();
    }

    public void PlayThrowAttackAnimation()
    {
        if (_canPlayAnimation) 
        {
            _canPlayAnimation = false; 
            _animator.SetTrigger(_throwAttack);
        }
    }

    private void LateUpdate()
    {
        UpdateMeshCollider();
        
        if (IsAnimationFinished(_throwAttack))
        {
            _canPlayAnimation = true; 
        }
    }

    private void UpdateMeshCollider()
    {
   
    }

    private bool IsAnimationFinished(string animationName)
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1f;
    }
}
