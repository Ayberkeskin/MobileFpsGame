using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent _agent;
    Transform _target;

    [Header("Move Settings")]
    [SerializeField] float _moveSpeed;
    [SerializeField] float _turnSpeed;

    [Header("Attack Settings")]
    [SerializeField] float _damage;
    [SerializeField] float _attackRange;
    [SerializeField] float _attackRate;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_target == null) { return;  }
        
    }
}
