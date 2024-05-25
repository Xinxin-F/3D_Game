using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[CreateAssetMenu(menuName = "Abilities/Area Attack")]
public class AreaAttackSkill : Ability
{
    [SerializeField] private GameObject areaAttackObject;
    [SerializeField] private GameObject rangeIndicatorPrefab; 

    public override void Activate(GameObject parent)
    {
        if (areaAttackObject != null)
        {
            AreaAttack areaAttack = areaAttackObject.GetComponent<AreaAttack>();
            if (areaAttack != null)
            {
                areaAttack.PerformAttack();
                ShowRangeIndicator();
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

    private void ShowRangeIndicator()
    {   
        Vector3 BossPosition = new Vector3(0.0f, 0.5f, 0.0f);
        GameObject rangeIndicator = Instantiate(rangeIndicatorPrefab, BossPosition, Quaternion.Euler(90f, 0f, 0f));
        Destroy(rangeIndicator, 5f);
    }
}


