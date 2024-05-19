using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillSelectionManager : MonoBehaviour {
    public List<Ability> allSkills;
    public List<Ability> selectedSkills = new List<Ability>();
    public int maxSkills = 4;

    public void SelectSkill(Ability skill) {
        if (selectedSkills.Contains(skill)) {
            selectedSkills.Remove(skill);
        } else {
            if (selectedSkills.Count < maxSkills) {
                selectedSkills.Add(skill);
            }
        }
    }

    public void ConfirmSelection() {
        PlayerPrefs.SetInt("SelectedSkillsCount", selectedSkills.Count);
        for (int i = 0; i < selectedSkills.Count; i++) {
            PlayerPrefs.SetString("SelectedSkill" + i, selectedSkills[i].name);
        }
        SceneManager.LoadScene("GameScene");
    }
}
