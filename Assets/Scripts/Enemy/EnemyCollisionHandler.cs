using UnityEngine;

namespace Enemy
{
    public class EnemyCollisionHandler : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosion;
        [SerializeField] private Transform parentForExplosionInstance;
        
        private void OnParticleCollision(GameObject other)
        {
            var instance = Instantiate(explosion, transform.position, Quaternion.identity);
            instance.transform.parent = parentForExplosionInstance;
            instance.Play();
            Destroy(instance, 3f);
            Destroy(transform.root.gameObject);
        }
    }
}
