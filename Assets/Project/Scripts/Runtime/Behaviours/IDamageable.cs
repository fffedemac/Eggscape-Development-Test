namespace Project
{
    public interface IDamageable
    {
        public void TakeDamageServer(int damage);
        public void TakeDamage(int damage);
        public void Die();
    }
}
