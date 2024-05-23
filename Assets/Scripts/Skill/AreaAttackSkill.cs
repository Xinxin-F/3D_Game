using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Area Attack")]
public class AreaAttackSkill : Ability
{
    [SerializeField] private GameObject areaAttackObject;

    public override void Activate(GameObject parent)
    {
        //GameObject areaAttackObject = GameObject.Find(areaAttackObjectName);
        if (areaAttackObject != null)
        {
            AreaAttack areaAttack = areaAttackObject.GetComponent<AreaAttack>();
            if (areaAttack != null)
            {
                areaAttack.PerformAttack();
            }
            else
            {
                Debug.LogError("AreaAttack component not found on " + areaAttackObject);
            }
        }
        else
        {
            Debug.LogError("GameObject with name " + areaAttackObject + " not found");
        }
    }
}
