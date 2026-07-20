using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int _currentHealth;
    private bool _isDead;

    private void Awake()
    {
        // Тут ініціалізувати _currentHealth значенням maxHealth
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (_isDead) return;

        _currentHealth -= damage;


        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;
        Debug.Log("Player has died.");
    }
}