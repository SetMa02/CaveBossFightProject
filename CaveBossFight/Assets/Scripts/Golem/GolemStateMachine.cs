using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(GolemAttacks), typeof(GolemMovement))]
[RequireComponent( typeof(GolemAnimations))]
public class GolemStateMachine : MonoBehaviour
{
    private GolemAttacks _attacks;
    private GolemMovement _movement;
    private GolemAnimations _animations;
    private int _attackCount;

    private void Start()
    {
        _attacks = GetComponent<GolemAttacks>();
        _movement  = GetComponent<GolemMovement>();
        _animations = GetComponent<GolemAnimations>();
    }

    private void Update()
    {
        
    }
}
