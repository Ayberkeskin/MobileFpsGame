using UnityEngine;

namespace MobileFpsGame.Player
{
    [CreateAssetMenu(menuName = "Player Settings")]
    public class PlayerSettings : ScriptableObject
    {
        [Header("Player Move Settings")]
        [SerializeField] private float _runSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _maxViewAngle;
        [SerializeField] private float _gravityModifer;

        [Header("Player Health Settings")]
        [SerializeField] private float _maxHealth;
        [SerializeField] private bool _isDeath;

        public float RunSpeed { get => _runSpeed; set => _runSpeed = value; }
        public float RotateSpeed { get => _rotateSpeed; set => _rotateSpeed = value; }
        public float MaxViewAngle { get => _maxViewAngle; set => _maxViewAngle = value; }
        public float GravityModifer { get => _gravityModifer; set => _gravityModifer = value; }



        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public bool IsDeath { get => _isDeath; set => _isDeath = value; }
    }
}