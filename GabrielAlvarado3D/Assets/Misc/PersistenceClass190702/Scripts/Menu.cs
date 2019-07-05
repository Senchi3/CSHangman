using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public InputField inputKey;
    public InputField inputValue;
    public Text textResult;

    public void Save() {
        string key = inputKey.text;
        string value = inputValue.text;

        Debug.Log(key + " - " + value);

        PlayerPrefs.SetString(key, value);
    }

    public void Load() {
        string value = PlayerPrefs.GetString("name", "no name");
        textResult.text = value;
    }

    public void CreateFile() {
        string path = "D:/myFile.txt";

        Dictionary<string, string> valuePairs = new Dictionary<string, string>();
        valuePairs.Add("name", "Juan");
        valuePairs.Add("age", "7");
        valuePairs.Add("mom", "Juana");

        string[] lines = new string[valuePairs.Count + 1];
        int i = 0;
        foreach (KeyValuePair<string, string> item in valuePairs) {
            lines[i] = item.Key + " -> " + item.Value;
            i++;
        }

        File.WriteAllLines(path, lines);
    }
}
