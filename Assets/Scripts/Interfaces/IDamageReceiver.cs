namespace Interfaces
{
    public interface IDamageReceiver
    {
        public void TakeDamage(int damage);
        public bool TryDie();
    }
}