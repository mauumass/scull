using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySongScript : MonoBehaviour {

    public Toggle tog;

	// Use this for initialization
	void Start () {
        int dejavu = PlayerPrefs.GetInt("song");
        if (dejavu == 1)
        {
            tog.isOn = true;
        }
        else
        {
            tog.isOn = false;
        }

        tog.onValueChanged.AddListener((value) =>
        {
            MyListener(value);
        });
    }

    public void MyListener(bool value)
    {
        if (value)
        {
            PlayerPrefs.SetInt("song", 1);
        }
        else
        {
            PlayerPrefs.SetInt("song", 0);
        }

    }
}
