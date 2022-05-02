using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Base
{
    private int id;
    private string dialogueName;
    private string dialogueText;
    private string audioName;
    private AudioClip audioClip;
    private float dialogueLength;

    public Dialogue_Base(int id, string dialogueName, string dialogueText, string audioName)
    {
        this.id = id;
        this.dialogueName = dialogueName;
        this.dialogueText = dialogueText;
        this.dialogueLength = dialogueText.Length;
        this.audioName = audioName;
        this.audioClip = Resources.Load<AudioClip>("Assets/Sound/Dialogue/" + audioName);
    }

    public int getDialogueId()
    {
        return this.id;
    }

    public string getDialogueName()
    {
        return this.dialogueName;
    }

    public string getDialogueText()
    {
        return this.dialogueText;
    }

    public string getAudioName()
    {
        return this.audioName;
    }

    public AudioClip GetAudioClip()
    {
        return this.audioClip;
    }

    public float GetDialogueLength()
    {
        return this.dialogueLength;
    }

}
