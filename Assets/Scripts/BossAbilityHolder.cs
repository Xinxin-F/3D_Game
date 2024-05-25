using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilityHolder : MonoBehaviour
{
    [System.Serializable]
    public class AbilityControl
    {
        public Ability ability;
        public float cooldownTime;
        public float activeTime;

        public enum AbilityState
        {
            ready,
            active,
            cooldown
        }

        public AbilityState state = AbilityState.ready;
    }

    public AbilityControl[] abilities;
    private AbilityControl healAbility;
    //private AbilityControl shootAbility;

    private HealthController bossHealthController;
    //public GameObject player;
    [SerializeField]private float healHealthThreshold = 80f;
   // public Transform shootPoint; // Point from where the boss will shoot projectiles

    void Start()
    {
        bossHealthController = GetComponent<HealthController>();
        foreach (var ability in abilities)
        {
            if (ability.ability is HealAbility)
            {
                healAbility = ability;
            }
            // else if (ability.ability is ShootAbility)
            // {
            //     shootAbility = ability;
            // }
        }
    }

    void Update()
    {
        HandleBossAbilities();
        UpdateAbilities();
    }

    private void HandleBossAbilities()
    {
        if (bossHealthController.getCurrentHealth() < healHealthThreshold && healAbility != null && healAbility.state == AbilityControl.AbilityState.ready)
        {
            ActivateAbility(healAbility);
        }

        // if (shootAbility != null && shootAbility.state == AbilityControl.AbilityState.ready)
        // {
        //     ActivateAbility(shootAbility);
        // }
    }

    private void ActivateAbility(AbilityControl abilityControl)
    {
        abilityControl.ability.Activate(gameObject);
        abilityControl.activeTime = abilityControl.ability.activeTime;
        abilityControl.state = AbilityControl.AbilityState.active;
    }

    private void UpdateAbilities()
    {
        foreach (var ability in abilities)
        {
            switch (ability.state)
            {
                case AbilityControl.AbilityState.active:
                    if (ability.activeTime > 0)
                    {
                        ability.activeTime -= Time.deltaTime;
                    }
                    else
                    {
                        ability.state = AbilityControl.AbilityState.cooldown;
                        ability.cooldownTime = ability.ability.cooldownTime;
                    }
                    break;

                case AbilityControl.AbilityState.cooldown:
                    if (ability.cooldownTime > 0)
                    {
                        ability.cooldownTime -= Time.deltaTime;
                    }
                    else
                    {
                        ability.state = AbilityControl.AbilityState.ready;
                    }
                    break;
            }
        }
    }
}
