using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StickAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float waterSpeed = 10f;

    // private Rigidbody rb;

    // void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    // }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("OnCollisionEnter triggered with Ground");
            GetComponent<Rigidbody>().isKinematic = true; //stationary when hits ground
            Vector3 BossPosition = Vector3.zero;
            RotateTowards(BossPosition);
            InvokeRepeating("ShootAtBoss", 0f, 3f);
            Destroy(gameObject, 15f);
        }
        // else if (collision.gameObject.CompareTag("Boss")||collision.gameObject.CompareTag("Obstacles")){
        //     Destroy(gameObject);
        // }
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Boss") ||other.gameObject.CompareTag("Obstacles")){
            Destroy(gameObject);
        }
    }

    private void RotateTowards(Vector3 targetPoint)
    {
        Vector3 direction = (targetPoint - transform.position).normalized;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void ShootAtBoss()
    {
        Debug.Log("ShootAtBoss called");
        Vector3 BossPosition = Vector3.zero;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Vector3 direction = BossPosition - bulletSpawnPoint.position;
        bullet.GetComponent<Rigidbody>().velocity = direction.normalized * waterSpeed;
    }
}