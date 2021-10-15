using Interfaces;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour, IDamageReceiver
    {
        [SerializeField] private int hitPoints = 3;
        
        public void TakeDamage(int damage) => hitPoints -= damage;

        public bool TryDie()
        {
            if (hitPoints <= 0) Destroy(transform.root.gameObject);
            return hitPoints <= 0;
        }
    }
}