using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalBullet : MonoBehaviour
{
    [SerializeField] private BulletType bulletType;
    

    private void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Boss")){
            other.GetComponent<BossElement>().OnHit(bulletType);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision) 
    {
        Destroy(gameObject);
    }
}

    // void OnCollisionEnter(Collision collision)
    // {
    //     // Check if the collided object is the boss
        
    //     BossElement boss = collision.gameObject.GetComponent<BossElement>();
    //     if (boss != null)
    //     {
    //         boss.OnHit(bulletType);
    //         Destroy(gameObject);
    //     }
