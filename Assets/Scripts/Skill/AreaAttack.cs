using UnityEngine;

public class AreaAttack : MonoBehaviour
{
    [SerializeField] public float attackRadius = 6f;
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



// // with range indicator 
// using UnityEngine;
// using UnityEngine.UI;

// public class AreaAttack : MonoBehaviour
// {
//     [SerializeField] public float attackRadius = 50f;
//     [SerializeField] private float areaDamage = 5f;
//     [SerializeField] private ParticleSystem attackParticleSystem;
//     [SerializeField] private GameObject rangeIndicatorPrefab; 
//     [SerializeField] private Canvas canvas;


//     public void PerformAttack()
//     {
//         // Play particle system
//         if (attackParticleSystem != null)
//         {
//             ParticleSystem instance = Instantiate(attackParticleSystem, transform.position, transform.rotation);
//             instance.Play();
//             if (rangeIndicatorPrefab != null)
//             {
//                GameObject rangeIndicator = Instantiate(rangeIndicatorPrefab, canvas.transform);
//                 rangeIndicator.transform.position = transform.position;
//                 Destroy(rangeIndicator, instance.main.duration);
//             }
//             Destroy(instance.gameObject, instance.main.duration);

//         }
//         else
//         {
//             Debug.LogWarning("Particle system not assigned");
//         }


//         Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius);
//         foreach (Collider hitCollider in hitColliders)
//         {
//             if (hitCollider.CompareTag("Boss"))
//             {
//                 hitCollider.GetComponent<HealthController>().TakeDamage(areaDamage);
//             }
//         }

       
//     }

    // public void DisableRangeIndicator()
    // {
    //     if (rangeIndicatorImage != null)
    //     {
    //         rangeIndicatorImage.enabled = false;
    //     }
    // }
// }





