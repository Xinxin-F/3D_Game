using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    public Transform launchPoint;
   // public GameObject grenade;
    public float launchVelocity = 10f;

    public void shootParabola(GameObject grenade){
        Vector3 direction = AttackDirection.GetDirectionFromMouse(Camera.main, gameObject);
        Vector3 spawnPosition = launchPoint.position;
        var _projectiles = Instantiate(grenade, spawnPosition, launchPoint.rotation);
        _projectiles.GetComponent<Rigidbody>().velocity = launchPoint.up*launchVelocity;
    }

    // Update is called once per frame
    // void Update()
    // {
    //      if (Input.GetKeyDown(KeyCode.G))
    //     {
    //         shootParabola();
    //     }

    //     // var _projectiles = Instantiate(grenade, launchPoint.position, launchPoint.rotation);
    //     // _projectiles.GetComponent<Rigidbody>().velocity = launchPoint.up*launchVelocity;
    // }

    // void shootParabola(){
    //     Vector3 direction = AttackDirection.GetDirectionFromMouse(Camera.main, gameObject);
    //     Vector3 spawnPosition = launchPoint.position;
    //     var _projectiles = Instantiate(grenade, spawnPosition, launchPoint.rotation);
    //     _projectiles.GetComponent<Rigidbody>().velocity = launchPoint.up*launchVelocity;
    // }
}
