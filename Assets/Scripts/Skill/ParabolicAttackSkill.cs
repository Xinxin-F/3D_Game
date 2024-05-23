using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//exact same code as GrenadeSkill
[CreateAssetMenu(menuName = "Abilities/Parabolic")]
public class ParabolicAttackSkill : Ability
{
    [SerializeField] private GameObject projectilePrefab;
    public float launchVelocity = 10f;
    ShootProjectiles shootProjectiles;

    public override void Activate(GameObject parent)
    {
        shootProjectiles = parent.GetComponent<ShootProjectiles>();

        if (shootProjectiles != null)
        {
            shootProjectiles.shootParabola(projectilePrefab);
        }
        else
        {
            Debug.LogError("ShootProjectiles component is not assigned.");
        }
    }
}

