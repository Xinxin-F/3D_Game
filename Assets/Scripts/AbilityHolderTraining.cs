// using UnityEngine;
// using UnityEngine.UI;

// public class AbilityHolderTraining : AbilityHolder
// {
//     public Dropdown abilityDropdown;

//     // override void Start()
//     // {
//     //     LoadAllSkills();
//     //     if (abilities != null && abilities.Length > 0)
//     //     {
//     //         currentAbility = abilities[0];
//     //         PopulateDropdown();
//     //     }
//     // }

//     protected override void Start()
//     {
//         base.Start();

//             PopulateDropdown();
        
//     }


//     private void PopulateDropdown()
//     {
//         List<string> options = new List<string>();
//         foreach (var ability in abilities)
//         {
//             options.Add(ability.ability.name);
//         }
//         abilityDropdown.AddOptions(options);
//         abilityDropdown.onValueChanged.AddListener(delegate {
//             DropdownValueChanged(abilityDropdown);
//         });
//     }

//     private void DropdownValueChanged(Dropdown dropdown)
//     {
//         currentAbility = abilities[dropdown.value];
//     }

//     private void LoadAllSkills()
//     {
//         // Load all abilities from the Resources/Abilities folder
//         Ability[] loadedAbilities = Resources.LoadAll<Ability>("Abilities");
//         abilities = new AbilityControl[loadedAbilities.Length];
//         for (int i = 0; i < loadedAbilities.Length; i++)
//         {
//             abilities[i] = new AbilityControl { ability = loadedAbilities[i] };
//         }
//     }
// }