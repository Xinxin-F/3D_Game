using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float FullHealth; 
    [SerializeField] private float currentHealth; 

    void Start(){
        currentHealth = FullHealth;
    }

    public float RemainingHealthPercentage{
        get{
            return currentHealth/FullHealth;
        }
    }
    
    public UnityEvent OnHealthChanged;

    public void TakeDamage(float damage){
        currentHealth -= damage;
        //OnHealthChanged.Invoke();

        if(currentHealth <= 0f){
            Destroy(gameObject);
           // LevelManager.manager.GameOver();
        }
    }
}
