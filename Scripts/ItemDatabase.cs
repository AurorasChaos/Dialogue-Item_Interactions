using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item_Base> items = new List<Item_Base>();
    private string itemStoragePath = "Assets/GameData/Dialogue/Item_Database.csv";

    public void Awake()
    {
        BuildDatabase();
    }

    public Item_Base GetItem(int id)
    {
        return items.Find(item => item.getItemId() == id);
    }

    public Item_Base GetItem(string itemName)
    {
        return items.Find(item => item.getItemName() == itemName);
    }

    public int GetCurrentItemDatabaseLength()
    {
        return items.Count;
    }

    public void AddNewItem(int id, string itemName, string itemDescription, List<int> itemsToCombineWith, int itemToMakeFromCombination, bool SaveDataToFile)
    {
        items.Add(
            new Item_Base(id, itemName, itemDescription, itemsToCombineWith, itemToMakeFromCombination)
            );
        if (SaveDataToFile)
        {
            WriteValuesToGameData();
        }
    }

    public void ReadAndBringInValuesFromGameData()
    {
        using (var reader = new StreamReader(itemStoragePath))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                //Parse info from csv into a list
                List<int> Value3 = new List<int>();
                var values3 = values[3].Split(';');
                foreach (string value in values3)
                {
                    Value3.Add(Int32.Parse(value));
                }

                AddNewItem(Int32.Parse(values[0]), values[1], values[2], Value3, Int32.Parse(values[4]), false);
            }
        }
    }

    public void WriteValuesToGameData()
    {
        var csv = new System.Text.StringBuilder();
        foreach (Item_Base _item in items)
        {
            //Parse values to go into csv
            string ValuesToCombineWith = "";
            foreach(char item_id in _item.getItemsNeededForCombination().ToString())
            {
                ValuesToCombineWith += ";" + item_id;
            }
            string LineToWrite = _item.getItemId() + "," + _item.getItemDescription() + "," + "" + "," + "";
            csv.AppendLine(LineToWrite);
        }
        File.WriteAllText(itemStoragePath, csv.ToString());
        Debug.Log("Added new data to the file");
    }


    void BuildDatabase()
    {
        ReadAndBringInValuesFromGameData();
    }

}
