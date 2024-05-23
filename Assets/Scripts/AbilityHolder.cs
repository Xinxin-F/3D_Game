using System.Collections;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
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

    public AbilityControl[] abilities;  // Array to hold any number of abilities
    private AbilityControl currentAbility;  // Currently selected ability

    void Start()
    {
        LoadSelectedSkills();
        if (abilities != null && abilities.Length > 0)
        {
            currentAbility = abilities[0];
        }
    }

    void Update()
    {
        SwitchAbilities();
        //ActivateSelectedAbility();
        HandleAbilityActivation();
        UpdateAbilities();
    }

    private void SwitchAbilities()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && abilities.Length > 0)
            currentAbility = abilities[0];
        if (Input.GetKeyDown(KeyCode.Alpha2) && abilities.Length > 1)
            currentAbility = abilities[1];
        if (Input.GetKeyDown(KeyCode.Alpha3) && abilities.Length > 2)
            currentAbility = abilities[2];
        if (Input.GetKeyDown(KeyCode.Alpha4) && abilities.Length > 3)
            currentAbility = abilities[3];
    }

    private float pressTime = 0f;
    private float longPressThreshold = 0.5f;

    private void HandleAbilityActivation()
    {
        if (Input.GetMouseButtonDown(0))                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        {
            pressTime = Time.time;
        }
        
        if (Input.GetMouseButtonUp(0) && currentAbility != null && currentAbility.state == AbilityControl.AbilityState.ready)
        {
            float pressDuration = Time.time - pressTime;
            bool isLongPress = pressDuration >= longPressThreshold;

            //short press for fire, long press for ice
            if (currentAbility.ability is ElementalReactionSkill)
            {
                ((ElementalReactionSkill)currentAbility.ability).Activate(gameObject, isLongPress);
            }
            else
            {
                ActivateAbility(currentAbility);
            }
        }
    }

    // private void ActivateSelectedAbility()
    // {
    //     if (Input.GetMouseButtonDown(0) && currentAbility != null && currentAbility.state == AbilityControl.AbilityState.ready)
    //     {
    //         ActivateAbility(currentAbility);
    //     }
    // }

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

    // Method to activate an ability
    private void ActivateAbility(AbilityControl abilityControl)
    {
        abilityControl.ability.Activate(gameObject);
        abilityControl.activeTime = abilityControl.ability.activeTime;
        abilityControl.state = AbilityControl.AbilityState.active;
    }

    private void LoadSelectedSkills() {
        int selectedSkillsCount = PlayerPrefs.GetInt("SelectedSkillsCount", 0);
        abilities = new AbilityControl[selectedSkillsCount];
        for (int i = 0; i < selectedSkillsCount; i++) {
            string skillName = PlayerPrefs.GetString("SelectedSkill" + i);
            Ability ability = Resources.Load<Ability>("Abilities/" + skillName);
            if (ability != null) {
                abilities[i] = new AbilityControl { ability = ability };

                Debug.Log("Loaded skill: " + ability.name);
            }
        }
    }


    public void SetCurrentAbility(int index)
    {
        if (index >= 0 && index < abilities.Length)
        {
            currentAbility = abilities[index];
        }
    }


}






    // void Update()
    // {
    //     Debug.Log("Current Ability: " + currentAbility?.ability.name);

    //     // Switch abilities using numeric keys, checking if the index exists
    //     if (Input.GetKeyDown(KeyCode.Alpha1) && abilities.Length > 0) currentAbility = abilities[0];
    //     if (Input.GetKeyDown(KeyCode.Alpha2) && abilities.Length > 1) currentAbility = abilities[1];
    //     if (Input.GetKeyDown(KeyCode.Alpha3) && abilities.Length > 2) currentAbility = abilities[2];
    //     if (Input.GetKeyDown(KeyCode.Alpha4) && abilities.Length > 3) currentAbility = abilities[3];

    //     // Activate the selected ability with left mouse click
    //     if (Input.GetMouseButtonDown(0) && currentAbility != null && currentAbility.state == AbilityControl.AbilityState.ready)
    //     {
    //         ActivateAbility(currentAbility);
    //     }

    //     // Update all abilities' states and cooldowns
    //     foreach (var ability in abilities)
    //     {
    //         switch (ability.state)
    //         {
    //             case AbilityControl.AbilityState.active:
    //                 if (ability.activeTime > 0)
    //                 {
    //                     ability.activeTime -= Time.deltaTime;
    //                 }
    //                 else
    //                 {
    //                     ability.state = AbilityControl.AbilityState.cooldown;
    //                     ability.cooldownTime = ability.ability.cooldownTime;
    //                 }
    //                 break;
                
    //             case AbilityControl.AbilityState.cooldown:
    //                 if (ability.cooldownTime > 0)
    //                 {
    //                     ability.cooldownTime -= Time.deltaTime;
    //                 }
    //                 else
    //                 {
    //                     ability.state = AbilityControl.AbilityState.ready;
    //                 }
    //                 break;
    //         }
    //     }
    // }






// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AbilityHolder : MonoBehaviour{

//     public Ability ability;
//     float cooldownTime;
//     float activeTime;

//     enum AbilityState{
//         ready, 
//         active, 
//         cooldown
//     }

//     AbilityState state = AbilityState.ready;

//     public KeyCode key;

//     void Update()
//     {
//         switch (state){
//             case AbilityState.ready:
//                 if(Input.GetKeyDown(key)){
//                     ability.Activate(gameObject);
//                     state = AbilityState.active;
//                     activeTime = ability.activeTime;
//                 }
//             break;

//             case AbilityState.active: 
//                 if(activeTime > 0){
//                     activeTime -= Time.deltaTime;
//                 }
//                 else{
//                     state = AbilityState.cooldown;
//                     cooldownTime = ability.cooldownTime;
//                 }
//             break;
//             case AbilityState.cooldown:
//                 if(activeTime > 0){
//                     cooldownTime -= Time.deltaTime;
//                 }
//                 else{
//                     state = AbilityState.ready;
//                 }
//             break;
//         }

        
//     }
// }







// public class SkillManager : MonoBehaviour
// {
//     public static SkillManager Instance {get; private set;}
//     public List<CharacterAbility> Abilities;

//     public ServerCharacter CharacterPrefab;
//     public ServerPlayer PlayerPrefab;

//     void Awake(){
//         Instance = this;
//         DontDestroyOnLoad(this.gameObject);
//     }

//     public void UseAbility(ServerCharacter clickedCharacter, byte abilityIndex){
//         if(abilityIndex >= _abilities.Count){
//             return;
//         }
//         var ability = _abilities[abilityIndex];
//         ability.Use(this, clickedCharacter);
//     }


