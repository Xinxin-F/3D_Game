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