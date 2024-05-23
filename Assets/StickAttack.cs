using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickAttack : MonoBehaviour
{

    //[SerializeField] private GameObject assistant;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("OnCollisionEnter triggered with Ground");
            Vector3 BossPosition = Vector3.zero;
            RotateTowards(BossPosition);
            ShootAtBoss(BossPosition);
        }
    }

     private void RotateTowards(Vector3 targetPoint)
    {
        Vector3 direction = (targetPoint - transform.position).normalized;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float waterSpeed = 10f;

    private void ShootAtBoss(Vector3 targetPosition)
    {
        Debug.Log("ShootAtBoss called");
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Vector3 direction = targetPosition - bulletSpawnPoint.position;
        bullet.GetComponent<Rigidbody>().velocity = direction.normalized * waterSpeed;
    }
}
