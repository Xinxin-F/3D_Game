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
        if (Input.GetMouseButtonDown(0))
        {
            selectedAbility?.Activate(gameObject);
        }
    }

    void SelectAbility(int index)
    {
        selectedAbility = abilities[index];
    }
}
