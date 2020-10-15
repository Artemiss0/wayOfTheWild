using UnityEngine;

public class IsDamagable : MonoBehaviour
{
    public int MaxHealth = 100;
    private int _currentHealth;

    void Start()
    {
        _currentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        // To-Do: play hit animation

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);

        //To-Do: Die animation / destruct animation
    }
}
