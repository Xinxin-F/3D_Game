using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour{

    public Ability ability;
    float cooldownTime;
    float activeTime;

    enum AbilityState{
        ready, 
        active, 
        cooldown
    }

    AbilityState state = AbilityState.ready;

    public KeyCode key;

    void Update()
    {
        switch (state){
            case AbilityState.ready:
                if(Input.GetKeyDown(key)){
                    ability.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                }
            break;

            case AbilityState.active: 
                if(activeTime > 0){
                    activeTime -= Time.deltaTime;
                }
                else{
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;
                }
            break;
            case AbilityState.cooldown:
                if(activeTime > 0){
                    cooldownTime -= Time.deltaTime;
                }
                else{
                    state = AbilityState.ready;
                }
            break;
        }

        
    }
}







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
