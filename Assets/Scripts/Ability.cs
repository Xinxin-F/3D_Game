using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject{
    public new string name;
    public float cooldownTime;
    public float activeTime;

    public virtual void Activate(GameObject parent){

    }

}




// namespace Server{
//     public abstract class CharacterAbility : ScriptableObjects
//     {

//         public abstract void Use(ServerCharacter owner, ServerCharacter target);
//     }
// }


