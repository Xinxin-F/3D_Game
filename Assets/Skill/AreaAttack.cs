// using UnityEngine;

// [CreateAssetMenu(menuName = "Abilities/Area Attack")]
// public class AreaAttack : Ability
// {
//     public float attackRadius = 50f;
//     public float areaDamage = 5f;
//     public ParticleSystem attackParticleSystem;

//     public override void Activate(GameObject parent)
//     {
//         if (attackParticleSystem != null)
//         {
//             ParticleSystem instance = Instantiate(attackParticleSystem, parent.transform.position, parent.transform.rotation);
//             instance.Play();
//             Destroy(instance.gameObject, instance.main.duration);
//         }
//         else
//         {
//             Debug.LogWarning("Particle system not assigned");
//         }

//         Collider[] hitColliders = Physics.OverlapSphere(parent.transform.position, attackRadius);
//         foreach (Collider hitCollider in hitColliders)
//         {
//             if (hitCollider.CompareTag("Boss"))
//             {
//                 hitCollider.GetComponent<HealthController>().TakeDamage(areaDamage);
//             }
//         }
//     }
// }






 ///// code solely for attack, no integration
using UnityEngine;

public class AreaAttack : MonoBehaviour
{
    [SerializeField] public float attackRadius = 50f;
    [SerializeField] private float areaDamage = 5f;
    [SerializeField] private ParticleSystem attackParticleSystem;

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.A))
    //     {
    //         PerformAttack();
    //     }
    // }

    public void PerformAttack()
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
}


