using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Playables;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(MeshRenderer))]
    public class PlayerCollisionHandler : MonoBehaviour
    {
        [Header("Game session")]
        [SerializeField] private GameSession gameSession;
        [SerializeField] private float sceneReloadDelay = 1f;
        
        [Header("Timeline")]
        [SerializeField] private PlayableDirector director;
        
        
        [SerializeField] private ParticleSystem explosion;
        [SerializeField] private Transform parentForExplosionInstance;

        private void OnTriggerEnter(Collider other)
        {
            var instance = Instantiate(explosion, transform.position, Quaternion.identity);
            instance.transform.parent = parentForExplosionInstance;
            instance.Play();
            Destroy(instance, 3f);
            
            director.Stop();
            gameSession.Invoke(nameof(gameSession.RestartCurrentScene), sceneReloadDelay);
            
            Destroy(gameObject);
        }
    }
}
