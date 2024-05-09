using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject grenade;
    public float launchVelocity = 10f;


    // Update is called once per frame
    void Update()
    {
        var _projectiles = Instantiate(grenade, launchPoint.position, launchPoint.rotation);
        _projectiles.GetComponent<Rigidbody>().velocity = launchPoint.up*launchVelocity;
    }
}
