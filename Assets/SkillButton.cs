using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {
    public Ability skill;
    public SkillSelectionManager selectionManager;
    public Button button;
    //public Image icon;
    //public Text skillName;
    //public Text description;
    private bool isSelected = false;

    void Start() {
        button.onClick.AddListener(OnButtonClick);
        //icon.sprite = skill.icon;
        //skillName.text = skill.name;
        //description.text = skill.description;
    }

    void OnButtonClick() {
        isSelected = !isSelected;
        selectionManager.SelectSkill(skill);
        UpdateButtonUI();
    }

    void UpdateButtonUI() {
        // Optionally, update the button's visual state to show selection
        // ColorBlock colors = button.colors;
        // colors.normalColor = isSelected ? Color.green : Color.white;
        // button.colors = colors;

        ColorBlock colors = button.colors;
        colors.normalColor = isSelected ? Color.green : Color.white;
        colors.selectedColor = isSelected ? Color.green : Color.white;
        button.colors = colors;
    
    }
}
