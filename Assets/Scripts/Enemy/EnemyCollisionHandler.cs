using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyCollisionHandler : MonoBehaviour
    {
        [Header("Explosion VFX")]
        [SerializeField] private ParticleSystem explosionAfterDeath;
        [SerializeField] private ParticleSystem explosionOnHit;
        [SerializeField] private Transform parentForExplosionInstance;

        [Header("Score")] 
        [SerializeField] private int scoreAdd;
        [SerializeField] private ScoreUpdater scoreUpdater;

        private Enemy _enemy;
        private readonly List<ParticleCollisionEvent> _particleCollisionEvents = new List<ParticleCollisionEvent>();
        
        private void Start()
        {
            var rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;

            _enemy = GetComponent<Enemy>();
        }

        private void OnParticleCollision(GameObject other)
        {
            var playerShootingComponent = other.GetComponentInParent<PlayerShooting>();
            if (playerShootingComponent == null) return;

            _enemy.TakeDamage(playerShootingComponent.GetDamage());
            
            ExplodeAtCollisionPosition(other.GetComponent<ParticleSystem>());
            
            if (!_enemy.TryDie()) return;
            
            scoreUpdater.AddScore(scoreAdd);
            Explode(explosionAfterDeath, transform.position);
        }

        private void Explode(ParticleSystem explosionType, Vector3 where)
        {
            var instance = Instantiate(explosionType, where, Quaternion.identity);
            instance.transform.parent = parentForExplosionInstance;
            instance.Play();
            Destroy(instance.gameObject, 3);
        }

        private void ExplodeAtCollisionPosition(ParticleSystem playerLaser)
        {
            var eventCount = playerLaser.GetCollisionEvents(gameObject, _particleCollisionEvents);

            for (var i = 0; i < eventCount; i++)
            {
                Explode(explosionOnHit, _particleCollisionEvents[i].intersection);
            }
        }
    }
}
