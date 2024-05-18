using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 7f;
    [SerializeField] private float detonationTime = 3f; 

    private Rigidbody rb;
    [SerializeField] private float grenadeDamage = 5f;
    private bool hasDetonated = false;
    [SerializeField] private GameObject grenadeExplosion;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifetime);
    }

    public void SetDirection(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boss"))
        {
            Detonate();
            // Deal damage or other effects to the enemy
            other.GetComponent<HealthController>().TakeDamage(grenadeDamage);
        }
        else if (!hasDetonated)
        {
            StartCoroutine(DetonationTimer());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasDetonated)
        {
            StartCoroutine(DetonationTimer());
        }
    }

    private IEnumerator DetonationTimer()
    {
        hasDetonated = true;
        yield return new WaitForSeconds(detonationTime);
        Detonate();
    }

    private void Detonate()
    {
        // Implement grenade explosion effects or damage here
        Instantiate(grenadeExplosion, transform.position, transform.rotation);

        Destroy(gameObject);
    }



    
}
