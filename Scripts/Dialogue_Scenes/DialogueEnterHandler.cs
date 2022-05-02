using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueEnterHandler : MonoBehaviour
{
    [SerializeField] private DialogueDatabase dialogueDatabase;
    [SerializeField] private Text dialogueName;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Text audioClip;
    [SerializeField] private Text statusText;
    public void OnClickEnterButton()
    {
        //Check if entry fields are valid
        if (dialogueName.text != "" && dialogueText.text != "" && audioClip.text != "")
        {
            //Get the id to save the dialogue under.
            int id = dialogueDatabase.GetCurrentDialogueDatabaseLength();
            //Save the new dialogue into the database
            dialogueDatabase.AddNewDialogue(id, dialogueName.text, dialogueText.text, audioClip.text, true);
            //Give feedback upon success
            statusText.text = "Saved new dialogue with id: " + id;
        } else
        {
            statusText.text = "Ensure all fields are selected";
        }

    }
}
