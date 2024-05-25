using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Heal Ability")]
public class HealAbility : Ability
{
    public float healAmount;
    [SerializeField] private ParticleSystem healParticleSystem;

    public override void Activate(GameObject parent) {
        HealthController health = parent.GetComponent<HealthController>();
        if (health != null) {
            health.Heal(healAmount);
            PlayParticle(parent);
        }
    }

    private void PlayParticle(GameObject parent)
    {
        if (healParticleSystem != null)
        {
            ParticleSystem instance = Instantiate(healParticleSystem, parent.transform.position, Quaternion.identity);
            instance.Play();
            Destroy(instance.gameObject, 3f); // Destroy after 3 seconds
        }
        else
        {
            Debug.LogWarning("Particle system not assigned");
        }
    }
}