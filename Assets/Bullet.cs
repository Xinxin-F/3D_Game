using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 100f;

    [SerializeField] private float lifetime = 7f; //die after 3 seconds

    private Rigidbody rb;
    [SerializeField] private float BulletDamage = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifetime); 
    }

    // private void FixedUpdate()
    // {
    //     rb.AddForce(rb.transform.forward * speed); //fly straight away
    // }

    public void SetDirection(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Boss")){
            other.GetComponent<HealthController>().TakeDamage(BulletDamage);
            Destroy(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }


}

