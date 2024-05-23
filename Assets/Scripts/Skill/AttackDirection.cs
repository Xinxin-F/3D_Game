using UnityEngine;

public class AttackDirection : MonoBehaviour
{
    public static Vector3 GetDirectionFromMouse(Camera camera, GameObject parent)
    {
        Ray camRay = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layerMask = LayerMask.GetMask("Ground");

        if (Physics.Raycast(camRay, out hit, Mathf.Infinity, layerMask))
        {
            Vector3 direction = (hit.point - parent.transform.position).normalized;
            return direction;
        }

        return Vector3.zero;
    }
}
