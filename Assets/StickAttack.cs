using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickAttack : MonoBehaviour
{

    //[SerializeField] private GameObject assistant;

     private void OnCollisionEnter(Collision collision)
    {

        // GameObject instance = Instantiate(stickAttackParticle, transform.position, transform.rotation);
        // ParticleSystem ps = instance.GetComponent<ParticleSystem>();
        // ps.Play();
         Debug.Log("OnCollisionEnter triggered with " + collision.gameObject.tag);
        if(collision.gameObject.CompareTag("Ground")){
            GameObject target = GameObject.FindWithTag("Boss");
            if (target == null)
            {
                Debug.LogError("Boss not found!");
                return;
            }
            ShootAtBoss(target.transform.position);
        }
        //Destroy(gameObject, 10f);
        // if (collision.gameObject.CompareTag("Ground"))
        // {
        //     if (stickAttackParticle != null)
        //     {
        //         stickAttackParticle.Play();
        //     //}
        // }
    }

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float waterSpeed = 5f;

    private void ShootAtBoss(Vector3 targetPosition){
        Debug.Log("ShootAtBoss called");
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Vector3 direction = new Vector3(targetPosition.x, bulletSpawnPoint.position.y, targetPosition.z);
        bullet.GetComponent<Rigidbody>().velocity = direction * waterSpeed;
    }
}
