using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootStraight : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    //private float ShootTimer;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
             Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform. rotation);
        }
        // checkShoot();
    }

    // // check whether range attack is triggered
    // private void checkShoot(){
    //     if(Input.GetMouseButtonDown(0) && ShootTimer <= 0f){
    //         shoot();
    //         rangedAttackTimer = RangedAttackCool; //reset timer every time shoot
    //     }
    //     else{
    //         rangedAttackTimer -= Time.deltaTime;
    //     }
    // }

    // public void shoot(){
    //      Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    // }
}
