using UnityEngine;
using UnityEngine.AI;

public class PlayerMovements : MonoBehaviour
{
    public GameObject movementIndicatorPrefab;

    private NavMeshAgent navMeshAgent;

    [SerializeField] private LayerMask layerMask;

    private GameObject currentIndicator; 

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //rotateWithMouse();
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if (currentIndicator != null)
                {
                    Destroy(currentIndicator);
                }
                //currentIndicator = Instantiate(movementIndicatorPrefab, hit.point, Quaternion.identity);
                currentIndicator = Instantiate(movementIndicatorPrefab, hit.point, Quaternion.Euler(90, 0, 0));
                navMeshAgent.destination = hit.point;
            }
        }

        // Check if the hero has reached the destination
        if (currentIndicator != null && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)
        {
            Destroy(currentIndicator);
            currentIndicator = null;
        }
    }
}
//     private void RotateTowards(Vector3 targetPoint)
//     {
//         Vector3 direction = (targetPoint - transform.position).normalized;
//         direction.y = 0; // Keep only the horizontal direction
//         transform.rotation = Quaternion.LookRotation(direction);
//     }

// }


    // public void rotateWithMouse(){
    //     Vector3 mouseScreenPosition = Input.mousePosition;
    //     Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, Camera.main.transform.position.z));

    //     Vector3 direction = mouseWorldPosition - transform.position;
    //     // Ensure the direction is in the X-Z plane
    //     direction.y = 0;

    //     // Calculate the angle between the forward vector and the target direction
    //     float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

    //     // Apply the rotation to the player
    //     transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    // }

//}
// public class PlayerMovements : MonoBehaviour
// {
//     public GameObject movementIndicatorPrefab; 

//     private NavMeshAgent navMeshAgent;

//     [SerializeField] private LayerMask layerMask;

//     private GameObject currentIndicator; 

//     void Awake()
//     {
//         navMeshAgent = GetComponent<NavMeshAgent>();
//     }

//     void Update()
//     {
//         if (Input.GetMouseButtonDown(1))
//         {
//             RaycastHit hit;
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//         //     if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
//         //     {
//         //         // Instantiate the movement indicator prefab at the hit point
//         //         currentIndicator = Instantiate(movementIndicatorPrefab, hit.point, Quaternion.identity);

//         //         // Move the hero to the hit point
//         //         navMeshAgent.destination = hit.point;
//         //     }
//         // }

//                 if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
//         {
//             // Instantiate the movement indicator prefab at the hit point
//             if (currentIndicator != null)
//             {
//                 Destroy(currentIndicator);
//             }
//             currentIndicator = Instantiate(movementIndicatorPrefab, hit.point, Quaternion.identity);
//             Debug.Log("Movement indicator instantiated at: " + hit.point); // Debug log
//             Debug.DrawLine(ray.origin, hit.point, Color.red, 2f);

//             // Move the hero to the hit point
//             navMeshAgent.destination = hit.point;
//         }
//         }




//         // Check if the hero has reached the destination
//         if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
//         {
//             // Destroy the current movement indicator
//             Destroy(currentIndicator);
//         }
//     }
// }




// public class PlayerMovements : MonoBehaviour
// {
//    // [SerializeField] private Transform movePositionTransform;

//     private NavMeshAgent navMeshAgent;
    
//     [SerializeField] private LayerMask layerMask;

//     //public GameObject indicator;

//     void Awake(){
//         navMeshAgent = GetComponent<NavMeshAgent>();
//     }


//     void Update()
//     {
//         // navMeshAgent.destination = movePositionTransform.position;
//         if (Input.GetMouseButtonDown(1)) {
               
            
//                 RaycastHit hit;
                
//                 //  if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, layerMask)) {
//                 //     navMeshAgent.destination = hit.point;
//                 // }

//                 Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                

//             if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
//                 navMeshAgent.destination = hit.point;
//                // Destroy(indicator);

//                 // // Draw a line from the ray origin to the hit point
//                 Debug.DrawLine(ray.origin, hit.point, Color.red, 2f);

//                 // // Print hit point and agent's destination to the console
//                 // Debug.Log("Hit point: " + hit.point);
//                 // Debug.Log("Agent's destination: " + navMeshAgent.destination);
//             }
//             // else
//             // {
//             //     // Draw the ray in the scene view even if it didn't hit anything
//             //     Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 2f);
//             // }
//         }
//             }
//     }




