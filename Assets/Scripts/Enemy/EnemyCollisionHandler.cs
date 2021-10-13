using UnityEngine;

namespace Enemy
{
    public class EnemyCollisionHandler : MonoBehaviour
    {
        private void OnParticleCollision(GameObject other)
        {
            Destroy(transform.root.gameObject);
        }
    }
}
