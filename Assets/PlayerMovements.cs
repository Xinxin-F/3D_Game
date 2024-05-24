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
        RotateWithMouse();
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

    private void RotateWithMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, layerMask))
        {
            Vector3 direction = (hitInfo.point - transform.position).normalized;
            direction.y = 0;
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
            }
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




