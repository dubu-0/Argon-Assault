using UnityEngine;

namespace Enemy
{
    public class EnemyCollisionHandler : MonoBehaviour
    {
        [Header("Explosion VFX")]
        [SerializeField] private ParticleSystem explosion;
        [SerializeField] private Transform parentForExplosionInstance;

        [Header("Score")] 
        [SerializeField] private int scoreAdd;
        [SerializeField] private ScoreUpdater scoreUpdater;
        
        private void OnParticleCollision(GameObject other)
        {
            var instance = Instantiate(explosion, transform.position, Quaternion.identity);
            instance.transform.parent = parentForExplosionInstance;
            instance.Play();
            Destroy(instance, 3f);
            
            scoreUpdater.AddScore(scoreAdd);
            
            Destroy(transform.root.gameObject);
        }
    }
}
