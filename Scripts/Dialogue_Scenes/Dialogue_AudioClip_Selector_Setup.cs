using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_AudioClip_Selector_Setup : MonoBehaviour
{
    [SerializeField] private Dropdown dropdown;
    private List<string> ListOfOptions;

    public void Awake()
    {
        ListOfOptions = new List<string>();
        foreach(string file in System.IO.Directory.GetFiles("Assets/Sound/Dialogue/"))
        {
            if (!file.Contains(".meta"))
            {
                ListOfOptions.Add(file);
            }
        }

        dropdown.AddOptions(ListOfOptions);
    }

}
