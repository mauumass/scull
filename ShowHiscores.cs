using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHiscores : MonoBehaviour {

    public Text hiscores;
    public string level;

	// Use this for initialization
	void Start () {
        string scores = System.IO.File.ReadAllText(level + "scores.txt");
        if (level.Equals("level2"))
        {
            hiscores.text = "Intermediate: \n" + scores;
        }
        else
        {
            hiscores.text = "Beginner: \n" + scores;
        }
    }
}
