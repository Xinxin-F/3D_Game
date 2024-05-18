using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    float countdown;
    [SerializeField] private GameObject ExplosionEffect;
    bool hasExploded = false;
    [SerializeField] private float grenadeDamage = 5f;
    [SerializeField] private float radius = 2f;
    
    void Start(){
        countdown = delay;
    }

    void Update(){
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded){
            Exploded();
            hasExploded = true;
        }
    }

    void Exploded(){

        //show visual effect
        //  Instantiate(ExplosionEffect, transform.position, transform.rotation);

        GameObject explosionInstance = Instantiate(ExplosionEffect, transform.position, transform.rotation);
        ParticleSystem ps = explosionInstance.GetComponent<ParticleSystem>();

            if (ps != null)
            {
                ps.Play();
                //Debug.Log("Playing particle system");
                Destroy(explosionInstance, ps.main.duration);
            }
            else
            {
                Debug.LogWarning("Particle system component not found on the prefab");
            }
        
        //get nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders){
            if (nearbyObject.gameObject.CompareTag("Boss"))
            {
                nearbyObject.GetComponent<HealthController>().TakeDamage(grenadeDamage);
            }
        }
        //damage

        Destroy(gameObject);


        
    }





}



    // [SerializeField] private float speed = 10f;
    // [SerializeField] private float lifetime = 7f;
    // [SerializeField] private float detonationTime = 3f; 

    // private Rigidbody rb;
    // [SerializeField] private float grenadeDamage = 5f;
    // private bool hasDetonated = false;
    // [SerializeField] private GameObject grenadeExplosion;

    // private void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    //     Destroy(gameObject, lifetime);
    // }

    // public void SetDirection(Vector3 direction)
    // {
    //     rb.velocity = direction * speed;
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     // if (other.gameObject.CompareTag("Boss"))
    //     // {
    //     //     //Detonate();
    //     //     // Deal damage or other effects to the enemy
    //     //     other.GetComponent<HealthController>().TakeDamage(grenadeDamage);
    //     // }
    //     // else if (!hasDetonated)
    //     // {
    //     //     StartCoroutine(DetonationTimer());
    //     // }
    //     StartCoroutine(DetonationTimer());

    // }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (!hasDetonated)
    //     {
    //         StartCoroutine(DetonationTimer());
    //     }
    // }

    // private IEnumerator DetonationTimer()
    // {
    //     hasDetonated = true;
    //     yield return new WaitForSeconds(detonationTime);
    //     Detonate();
    // }

    // private void Detonate()
    // {
    //     // Implement grenade explosion effects or damage here
    //     Instantiate(grenadeExplosion, transform.position, transform.rotation);
    //     Destroy(gameObject);
        
    // }





    

