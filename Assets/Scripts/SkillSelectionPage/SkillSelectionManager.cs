using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SkillSelectionManager : MonoBehaviour
{
    public List<Ability> allSkills;
    public List<Ability> selectedSkills = new List<Ability>();
    public int maxSkills = 4;
    public TMP_Text selectionLimitText; 

    public void SelectSkill(Ability skill)
    {
        if (selectedSkills.Contains(skill))
        {
            selectedSkills.Remove(skill);
        }
        else
        {   
            if (selectedSkills.Count < maxSkills)
            {   
                selectedSkills.Add(skill);
            }
        }
        //UpdateSelectionLimitText(); 
    }

    public void ConfirmSelection()
    {
        PlayerPrefs.SetInt("SelectedSkillsCount", selectedSkills.Count);
        for (int i = 0; i < selectedSkills.Count; i++)
        {
            PlayerPrefs.SetString("SelectedSkill" + i, selectedSkills[i].name);
        }
        SceneManager.LoadScene("GameScene");  
    }


    private void UpdateSelectionLimitText()
    {
        if (selectedSkills.Count > maxSkills)
        {
            selectionLimitText.gameObject.SetActive(true);
        }
        else
        {
            selectionLimitText.gameObject.SetActive(false); 
        }
    }
}



// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class SkillSelectionManager : MonoBehaviour
// {
//     public List<Ability> allSkills;
//     public List<Ability> selectedSkills = new List<Ability>();
//     public int maxSkills = 4;
//     public Text selectionLimitText; // Reference to the text component to display the selection limit message

//     public void SelectSkill(Ability skill)
//     {
//         if (selectedSkills.Contains(skill))
//         {
//             selectedSkills.Remove(skill);
//         }
//         else
//         {
//             if (selectedSkills.Count < maxSkills)
//             {
//                 selectedSkills.Add(skill);
//             }
//         }

//         UpdateSelectionLimitText(); // Update the UI text to display the selection limit message
//     }

//     public void ConfirmSelection()
//     {
//         if (selectedSkills.Count == maxSkills) // Check if exactly four skills are selected
//         {
//             PlayerPrefs.SetInt("SelectedSkillsCount", selectedSkills.Count);
//             for (int i = 0; i < selectedSkills.Count; i++)
//             {
//                 PlayerPrefs.SetString("SelectedSkill" + i, selectedSkills[i].name);
//             }
//             SceneManager.LoadScene("GameScene");
//         }
//         else
//         {
//             selectionLimitText.gameObject.SetActive(true); // Enable the text component to display the message
//             selectionLimitText.text = "Please select exactly 4 skills.";
//         }
//     }

//     private void UpdateSelectionLimitText()
//     {
//         if (selectedSkills.Count > maxSkills)
//         {
//             selectionLimitText.gameObject.SetActive(true); // Enable the text component to display the message
//             selectionLimitText.text = "More than 4 skills selected. Please select only 4.";
//         }
//         else
//         {
//             selectionLimitText.gameObject.SetActive(false); // Disable the text component
//         }
//     }
// }




// // using System.Collections.Generic;
// // using UnityEngine;
// // using UnityEngine.SceneManagement;

// // public class SkillSelectionManager : MonoBehaviour {
// //     public List<Ability> allSkills;
// //     public List<Ability> selectedSkills = new List<Ability>();
// //     public int maxSkills = 4;

// //     public void SelectSkill(Ability skill) {
// //         if (selectedSkills.Contains(skill)) {
// //             selectedSkills.Remove(skill);
// //         } else {
// //             if (selectedSkills.Count < maxSkills) {
// //                 selectedSkills.Add(skill);
// //             }
// //         }
// //     }

// //     public void ConfirmSelection() {
// //         PlayerPrefs.SetInt("SelectedSkillsCount", selectedSkills.Count);
// //         for (int i = 0; i < selectedSkills.Count; i++) {
// //             PlayerPrefs.SetString("SelectedSkill" + i, selectedSkills[i].name);
// //         }
// //         SceneManager.LoadScene("GameScene");
// //     }
// // }
