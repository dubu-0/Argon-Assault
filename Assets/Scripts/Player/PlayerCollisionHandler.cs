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
        [SerializeField] private GameSession gameSession;
        [SerializeField] private float sceneReloadDelay = 1f;
        [SerializeField] private PlayableDirector director;
        [SerializeField] private ParticleSystem explosion;
        
        private void OnTriggerEnter(Collider other)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            director.enabled = false;
            explosion.Play();
            gameSession.Invoke(nameof(gameSession.RestartCurrentScene), sceneReloadDelay);
        }
    }
}
