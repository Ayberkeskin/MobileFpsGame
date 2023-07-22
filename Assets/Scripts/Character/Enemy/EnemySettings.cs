using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileFpsGame.Enemy
{
    [CreateAssetMenu(menuName = "Enemy Settings")]
    public class EnemySettings : ScriptableObject
    {
        [Header("Enemy Move Settings")]
        [SerializeField] float _enemyMoveSpeed;
        [SerializeField] float _enemyTurnSpeed;

        [Header("Enemy Health Settings")]
        [SerializeField] float _enemyHealth;
        [SerializeField] bool _enemyIsDeath;

        [Header("Enemy Attack Settings")]
        [SerializeField] float _enemyDamage;
        [SerializeField] float _enemyAttackRange;
        [SerializeField] float _enemyAttackRate;

        public float EnemyMoveSpeed { get => _enemyMoveSpeed; set => _enemyMoveSpeed = value; }
        public float EnemyTurnSpeed { get => _enemyTurnSpeed; set => _enemyTurnSpeed = value; }

        public float EnemyHealth { get => _enemyHealth; set => _enemyHealth = value; }
        public bool EnemyIsDeath { get => _enemyIsDeath; set => _enemyIsDeath = value; }

        public float EnemyDamage { get => _enemyDamage; set => _enemyDamage = value; }
        public float EnemyAttackRange { get => _enemyAttackRange; set => _enemyAttackRange = value; }
        public float EnemyAttackRate { get => _enemyAttackRate; set => _enemyAttackRate = value; }
    }
}