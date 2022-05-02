using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueDatabase : MonoBehaviour
{
    public List<Dialogue_Base> dialogues = new List<Dialogue_Base>();
    private string dialogueStoragePath = "Assets/GameData/Dialogue/Dialogue_Database.csv";
    public void Awake()
    {
        BuildDatabase();
    }

    public Dialogue_Base GetDialogue(int id)
    {
        return dialogues.Find(dialogues => dialogues.getDialogueId() == id);
    }

    public Dialogue_Base GetDialogue(string dialogueName)
    {
        return dialogues.Find(dialogues => dialogues.getDialogueName() == dialogueName);
    }

    public int GetCurrentDialogueDatabaseLength()
    {
        return dialogues.Count;
    }


    public void AddNewDialogue(int id, string dialogueName, string dialogueText, string audioName, bool SaveDataToFile)
    {
        dialogues.Add(
            new Dialogue_Base(id, dialogueName, dialogueText, audioName)
            );
        if (SaveDataToFile)
        {
            WriteValuesToGameData();
        }
    }

    public void ReadAndBringInValuesFromGameData()
    {
        using (var reader = new StreamReader(dialogueStoragePath))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                AddNewDialogue(Int32.Parse(values[0]), values[1], values[2], values[3], false);
            }
        }
    }

    public void WriteValuesToGameData()
    {
        var csv = new System.Text.StringBuilder();
        foreach(Dialogue_Base dialogue in dialogues)
        {
            string LineToWrite = dialogue.getDialogueId() + "," + dialogue.getDialogueName() + "," + dialogue.getDialogueText() + "," + dialogue.getAudioName();
            csv.AppendLine(LineToWrite);
        }
        File.WriteAllText(dialogueStoragePath, csv.ToString());
        Debug.Log("Added new data to the file");
    }

    private void BuildDatabase()
    {
        ReadAndBringInValuesFromGameData();
    }

}
