using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject gameOverPanel;
    public Canvas gameOverCanvas;
    public GameObject goalPanel;
    public Canvas goalCanvas;
    public AudioSource audio1;
    public AudioSource audio2;

    // Use this for initialization
    void Start () {
        gameOverPanel.SetActive(false);
        gameOverCanvas.gameObject.SetActive(false);
        goalPanel.SetActive(false);
        goalPanel.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("song") == 1)
        {
            audio2.Play();
        }
        else
        {
            audio1.Play();
        }
    }
}
