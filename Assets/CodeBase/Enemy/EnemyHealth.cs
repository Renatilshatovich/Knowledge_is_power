using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyHealth : MonoBehaviour
    {
        public EnemyAnimator Animator;

        public float Current;
        public float Max;

        public event Action HealthChanged;

        public void TakeDamage(float damage)
        {
            Current -= damage;
            
            Animator.PlayHit();
            
            HealthChanged?.Invoke();
        }
    }
}