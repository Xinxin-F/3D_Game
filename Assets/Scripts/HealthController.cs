using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float FullHealth; 
    [SerializeField] private float currentHealth; 
    [SerializeField] private float healAmount; 

    void Start(){
        // currentHealth = FullHealth;
         currentHealth = 50;
    }

    public float RemainingHealthPercentage{
        get{
            return currentHealth/FullHealth;
        }
    }
    
    public UnityEvent OnHealthChanged;

    public void TakeDamage(float damage){
        currentHealth -= damage;
        OnHealthChanged.Invoke();

        if(currentHealth <= 0f){
            Destroy(gameObject);
           // LevelManager.manager.GameOver();
        }
    }

    public void Heal(float amount) {
        currentHealth += amount;
        if (currentHealth > FullHealth) {
            currentHealth = FullHealth;
        }
        OnHealthChanged.Invoke();
    }

    // public void heal(){
    //     if(currentHealth <= FullHealth){
    //         float tempHealth = currentHealth + healAmount;
    //         if(tempHealth >= FullHealth){
    //             currentHealth = FullHealth;
    //         }
    //         else{
    //             currentHealth += healAmount;
    //         }
    //     }
    //     else{
    //         currentHealth = FullHealth;
    //     }
    // }
}

