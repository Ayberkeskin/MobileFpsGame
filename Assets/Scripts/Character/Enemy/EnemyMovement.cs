using UnityEngine;
using UnityEngine.AI;

namespace MobileFpsGame.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] EnemySettings _enemySettings;

        NavMeshAgent _agent;
        Transform _target;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _target = GameObject.FindWithTag("Player").transform;
            _agent.speed = _enemySettings.EnemyMoveSpeed;
        }

        private void FixedUpdate()
        {
            Move();
            LookTheTargert(_target.position);
        }

        private void Move()
        {
            if (_target == null||_agent.enabled==false) { return; }
            _agent.SetDestination(_target.position);
        }

        private void LookTheTargert(Vector3 target)
        {
            Vector3 lookPos = new Vector3(target.x, transform.position.y, target.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookPos - transform.position),
                _enemySettings.EnemyTurnSpeed * Time.deltaTime);
        }

    }
}