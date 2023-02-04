using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float startingHealth = 100f;

    private float hitPoints;
    private DeathHandler deathHandler;

    private void Awake()
    {
        hitPoints = startingHealth;
        deathHandler = GetComponentInParent<DeathHandler>();
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log("Taking damage");
        hitPoints -= damageAmount;

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("You died yo");

        if (deathHandler != null)
        {
            deathHandler.HandleDeath();
        }
    }

}
