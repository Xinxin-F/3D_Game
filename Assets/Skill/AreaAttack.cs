using UnityEngine;

public class AreaAttack : MonoBehaviour
{
    [SerializeField] public float attackRadius = 50f;
    [SerializeField] private float areaDamage = 5f;
    [SerializeField] private ParticleSystem attackParticleSystem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PerformAttack();
            //particleSystem.Play();
        }
    }

    void PerformAttack()
    {
        // attackParticleSystem.Play();
        // Invoke("StopParticleSystem", 5f);

        if (attackParticleSystem != null)
        {
            Debug.Log("Playing particle system");
            attackParticleSystem.Play();
            Invoke("StopParticleSystem", 5f);
        }
        else
        {
            Debug.LogWarning("Particle system not assigned");
        }


        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Boss"))
            {
                hitCollider.GetComponent<HealthController>().TakeDamage(areaDamage);
            }
        }
    }

    void StopParticleSystem()
    {
        attackParticleSystem.Stop();
        Debug.Log("Stopping particle system");
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}