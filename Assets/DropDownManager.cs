// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;

// public class DropDownManager : MonoBehaviour
// {
//     public TMP_Dropdown skillDropdown;
//     public AbilityHolder abilityHolder;

//     private void Start()
//     {
//         PopulateDropdown();
//         if (abilityHolder.abilities != null && abilityHolder.abilities.Length > 0)
//         {
//             abilityHolder.SetCurrentAbility(0);
//         }

//         skillDropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(skillDropdown); });
//     }

//     private void PopulateDropdown()
//     {
//         skillDropdown.ClearOptions();
//         List<string> options = new List<string>();
//         foreach (var ability in abilityHolder.abilities)
//         {
//             options.Add(ability.ability.name);
//         }
//         skillDropdown.AddOptions(options);
//     }

//     private void DropdownValueChanged(TMP_Dropdown change)
//     {
//         int index = change.value;
//         abilityHolder.SetCurrentAbility(index); // Use the extension method to set the current ability
//     }

//     private void Update()
//     {
//         HandleAbilityActivation();
//     }

//     private float pressTime = 0f;
//     private float longPressThreshold = 0.5f;

//     private void HandleAbilityActivation()
//     {
//         if (Input.GetMouseButtonDown(0))
//         {
//             pressTime = Time.time;
//         }

//         if (Input.GetMouseButtonUp(0) && abilityHolder.currentAbility != null && abilityHolder.currentAbility.state == AbilityHolder.AbilityControl.AbilityState.ready)
//         {
//             float pressDuration = Time.time - pressTime;
//             bool isLongPress = pressDuration >= longPressThreshold;

//             if (abilityHolder.currentAbility.ability is ElementalReactionSkill)
//             {
//                 ((ElementalReactionSkill)abilityHolder.currentAbility.ability).Activate(gameObject, isLongPress);
//             }
//             else
//             {
//                 ActivateAbility(abilityHolder.currentAbility);
//             }
//         }
//     }

//     private void ActivateAbility(AbilityHolder.AbilityControl abilityControl)
//     {
//         abilityControl.ability.Activate(gameObject);
//         abilityControl.activeTime = abilityControl.ability.activeTime;
//         abilityControl.state = AbilityHolder.AbilityControl.AbilityState.active;
//     }
// }
