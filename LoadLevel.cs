using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {
    public void TaskOnClick(string level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }
}
