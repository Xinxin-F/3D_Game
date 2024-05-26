using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrainingAbilityController : MonoBehaviour
{
    public Ability[] abilities; 
    public TMP_Dropdown dropdown;

    private Ability selectedAbility;

    void Start()
    {
        dropdown.ClearOptions();

        foreach (var ability in abilities)
        {
            dropdown.options.Add(new TMPro.TMP_Dropdown.OptionData(ability.name));
        }

        dropdown.onValueChanged.AddListener(SelectAbility);
    }

    void Update()
    {
        HandleAbilityActivation();
        // if (Input.GetMouseButtonDown(0))
        // {
        //     selectedAbility?.Activate(gameObject);
        // }
        
    }

    void SelectAbility(int index)
    {
        selectedAbility = abilities[index];
    }


    private float pressTime = 0f;
    private float longPressThreshold = 0.5f;

    private void HandleAbilityActivation()
    {
        if (Input.GetMouseButtonDown(0))                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        {
            pressTime = Time.time;
        }
        
        if (Input.GetMouseButtonUp(0) && selectedAbility != null)
        {
            float pressDuration = Time.time - pressTime;
            bool isLongPress = pressDuration >= longPressThreshold;

            //short press for fire, long press for ice
            if (selectedAbility is ElementalReactionSkill)
            {
                ((ElementalReactionSkill)selectedAbility).Activate(gameObject, isLongPress);
            }
            else
            {
                selectedAbility?.Activate(gameObject);
            }
        }
    }
}
