using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Shoot Ability")]
public class ShootStraight : Ability
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public override void Activate(GameObject parent)
    {
    Vector3 direction = AttackDirection.GetDirectionFromMouse(Camera.main, parent);
        if (direction != Vector3.zero)
        {
            // Use the parent's position as the spawn point
            Transform parentTransform = parent.transform;

            GameObject bullet = Instantiate(bulletPrefab, parentTransform.position, parentTransform.rotation);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }
        }

    // public override void Activate(GameObject parent)
    // {
    //     Vector3 direction = AttackDirection.GetDirectionFromMouse(Camera.main, parent);
    //     //Transform bulletSpawnPoint = parent.transform;

    //     GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform. rotation);
    //    // Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    //     // if (rb != null)
    //     // {
    //     //     rb.velocity = direction * bulletSpeed;
    //     // }
    // }
}

}


//// cannot shoot at target location
// public class ShootStraight : Ability
// {
//     // public Transform bulletSpawnPoint;
//     public GameObject bulletPrefab;

//     public override void Activate(GameObject parent)
//     {
//         Transform bulletSpawnPoint = parent.transform;
//         Vector3 shootDirection = GetShootDirection(parent, bulletSpawnPoint);
//         Shoot(bulletSpawnPoint, shootDirection);
//     }

//     private Vector3 GetShootDirection(GameObject shooter, Transform bulletSpawnPoint)
//     {
//         if (shooter.CompareTag("Player"))
//         {
//             // Player shooting towards mouse click
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//             RaycastHit hit;
            
//             if (Physics.Raycast(ray, out hit, Mathf.Infinity))
//             {
//                 Vector3 targetPoint = hit.point;
//                 Vector3 direction = (targetPoint - bulletSpawnPoint.position).normalized;
//                 Debug.DrawLine(ray.origin, hit.point, Color.red, 2f);

//                 return direction;
//                 // RotateTowards(hit.point);
//             }
//             return bulletSpawnPoint.forward; // Default to forward direction if no hit
//         }
//         // else if (shooter.CompareTag("Boss"))
//         // {
//         //     // Boss shooting towards the player
//         //     GameObject player = GameObject.FindGameObjectWithTag("Player");
//         //     if (player != null)
//         //     {
//         //         Vector3 targetPoint = player.transform.position;
//         //         Vector3 direction = (targetPoint - bulletSpawnPoint.position).normalized;
//         //         return direction;
//         //     }
//         //     return bulletSpawnPoint.forward; // Default to forward direction if no player found
//         // }
        
//         return bulletSpawnPoint.forward; // Default to forward direction if shooter tag is not recognized
//     }

//     private void Shoot(Transform bulletSpawnPoint, Vector3 direction)
//     {
//         GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.LookRotation(direction));
//         Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
//         if (bulletRb != null)
//         {
//             bulletRb.velocity = direction * 10f; // Set bullet speed, adjust as needed
//         }
//     }
// }






//// just shoot straight
    // public override void Activate(GameObject parent)
    // {
    //     Transform bulletSpawnPoint = parent.transform;
    //     // Shoot();
    //     Shoot(bulletSpawnPoint);
        
    // }

    // private void Shoot(Transform bulletSpawnPoint)
    // {
    //     Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    // }






// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ShootStraight : MonoBehaviour
// {
//     public Transform bulletSpawnPoint;
//     public GameObject bulletPrefab;
//     //private float ShootTimer;


//     // Update is called once per frame
//     void Update()
//     {
//         if(Input.GetMouseButtonDown(1)){
//              Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform. rotation);
//         }
//         // checkShoot();
//     }

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
//}
