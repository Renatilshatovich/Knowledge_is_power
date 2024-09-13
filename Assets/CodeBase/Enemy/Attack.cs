using System.Linq;
using CodeBase.Logic;
using UnityEngine;
namespace CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class Attack : MonoBehaviour
    {
        public EnemyAnimator Animator;

        public float AttackCooldown = 3f;
        public float Cleavage= .5f;
        public float EffectiveDistance = .5f;
        public float Damage = 10f;
        
        private Transform _heroTransform;
        
        private float _attackCooldown;
        private bool _isAttacking;
        private int _layerMask;
        private bool _attackIsActive;
        private Collider[] _hits = new Collider[1];

        public void Construct(Transform heroTransform) => 
            _heroTransform = heroTransform;

        private void Awake()
        {
            _layerMask = 1 << LayerMask.NameToLayer("Player");
        }

        private void Update()
        {
            UpdateCooldown();

            if(CanAttack())
                StartAttack();
        }

        private void OnAttack()
        {
            if (Hit(out Collider hit))
            {
                PhysicsDebug.DrawDebug(StartPoint(), Cleavage, 2.0f);
                hit.transform.GetComponent<IHealth>().TakeDamage(Damage);
            }
        }

        private void OnAttackEnded()
        {
            _attackCooldown = AttackCooldown;
            _isAttacking = false;
        }

        public void EnableAttack() => 
            _attackIsActive = true;

        public void DisableAttack() => 
            _attackIsActive = false;

        private bool Hit(out Collider hit)
        {
            var hitAmount = Physics.OverlapSphereNonAlloc(StartPoint(), Cleavage, _hits, _layerMask);

            hit = _hits.FirstOrDefault();
      
            return hitAmount > 0;
        }

        private Vector3 StartPoint()
        {
            return new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) +
                   transform.forward * EffectiveDistance;
        }

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
                _attackCooldown -= Time.deltaTime;
        }

        private bool CooldownIsUp() => 
            _attackCooldown <= 0;

        private void StartAttack()
        {
            transform.LookAt(_heroTransform);
            Animator.PlayAttack();

            _isAttacking = true;
        }

        private bool CanAttack() => 
            _attackIsActive && !_isAttacking && CooldownIsUp();
    }
}
