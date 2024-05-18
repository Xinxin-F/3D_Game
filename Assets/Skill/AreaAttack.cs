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
        }
    }

    void PerformAttack()
    {

        if (attackParticleSystem != null)
        {
            //Debug.Log("Preparing to play particle system");
            // Instantiate(attackParticleSystem, transform.position, transform.rotation);

            ParticleSystem instance = Instantiate(attackParticleSystem, transform.position, transform.rotation);
            instance.Play();
            Destroy(instance.gameObject, instance.main.duration);

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

    // void StopParticleSystem()
    // {
    //     //attackParticleSystem.Stop();
    //     attackParticleSystem.Clear();
    //     Debug.Log("Stopping particle system");
    // }


    // void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, attackRadius);
    // }
}