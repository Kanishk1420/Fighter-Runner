using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CollisionHandler : MonoBehaviour
{
    public ParticleSystem TouchParticle; // Assign your explosion particle effect in the Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Play the explosion particle effect if it's assigned
            if (TouchParticle != null)
            {
                TouchParticle.Play(); // Play the explosion particle effect
            }

            Destroy(other.gameObject); // Destroy the enemy

            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                StartCoroutine(DeactivateAfterDelay());
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }

    IEnumerator DeactivateAfterDelay()
    {
        yield return new WaitForSeconds(TouchParticle.main.duration);
        gameObject.SetActive(false);
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }
}