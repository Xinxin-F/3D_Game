// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovements : MonoBehaviour
{
   // [SerializeField] private Transform movePositionTransform;

    private NavMeshAgent navMeshAgent;
    
    [SerializeField] private LayerMask layerMask;

    //public GameObject indicator;

    void Awake(){
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        // navMeshAgent.destination = movePositionTransform.position;
        if (Input.GetMouseButtonDown(0)) {
               
            
                RaycastHit hit;
                
                //  if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, layerMask)) {
                //     navMeshAgent.destination = hit.point;
                // }

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
                navMeshAgent.destination = hit.point;
               // Destroy(indicator);

                // // Draw a line from the ray origin to the hit point
                // Debug.DrawLine(ray.origin, hit.point, Color.red, 2f);

                // // Print hit point and agent's destination to the console
                // Debug.Log("Hit point: " + hit.point);
                // Debug.Log("Agent's destination: " + navMeshAgent.destination);
            }
            // else
            // {
            //     // Draw the ray in the scene view even if it didn't hit anything
            //     Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 2f);
            // }
        }
            }
    }




