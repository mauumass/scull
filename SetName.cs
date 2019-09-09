using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetName : MonoBehaviour {

    public UnityEngine.UI.InputField ipfield;
    public UnityEngine.UI.Text text;
    bool allowEnter;

    void Update()
    {
        if (allowEnter && (ipfield.text.Length > 0) && (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)))
        {
            print(true);
            PlayerPrefs.SetString("name", ipfield.text);
            ipfield.text = "";
            text.text = "Your name:\n" + PlayerPrefs.GetString("name");
            allowEnter = false;
        }
        else
            allowEnter = ipfield.isFocused || ipfield.isFocused;
    }
}
