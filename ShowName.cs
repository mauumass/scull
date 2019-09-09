using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowName : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
        text.text = "Your name:\n" + PlayerPrefs.GetString("name");
	}
}
