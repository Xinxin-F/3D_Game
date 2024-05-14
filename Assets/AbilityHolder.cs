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
        if (abilities != null && abilities.Length > 0)
        {
            currentAbility = abilities[0];
        }
    }

    void Update()
    {
        // Switch abilities using numeric keys, checking if the index exists
        if (Input.GetKeyDown(KeyCode.Alpha1) && abilities.Length > 0) currentAbility = abilities[0];
        if (Input.GetKeyDown(KeyCode.Alpha2) && abilities.Length > 1) currentAbility = abilities[1];
        if (Input.GetKeyDown(KeyCode.Alpha3) && abilities.Length > 2) currentAbility = abilities[2];
        if (Input.GetKeyDown(KeyCode.Alpha4) && abilities.Length > 3) currentAbility = abilities[3];

        // Activate the selected ability with left mouse click
        if (Input.GetMouseButtonDown(0) && currentAbility != null && currentAbility.state == AbilityControl.AbilityState.ready)
        {
            ActivateAbility(currentAbility);
        }

        // Update all abilities' states and cooldowns
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
}




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





//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
