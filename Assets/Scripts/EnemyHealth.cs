using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    private void Update()
    {
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
    }
    private void Die()
    {
        Destroy(gameObject);
    }

}
