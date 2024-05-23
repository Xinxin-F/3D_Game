using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Heal Ability")]
public class HealAbility : Ability
{
    public float healAmount;

    public override void Activate(GameObject parent) {
        HealthController health = parent.GetComponent<HealthController>();
        if (health != null) {
            health.Heal(healAmount);
        }
    }
}
