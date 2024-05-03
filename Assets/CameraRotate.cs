using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float speed = 20;

    void Update()
    {
        if (Input.GetKey("q")) {
            //Debug.Log("Q was pressed");
            transform.Rotate(0, speed*Time.deltaTime, 0);
        }
        else if (Input.GetKey("e")){
            //Debug.Log("E was pressed");
            transform.Rotate(0, -speed*Time.deltaTime, 0);
        }


    }
}
