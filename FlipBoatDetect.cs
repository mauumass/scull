using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipBoatDetect : MonoBehaviour {

    public GameObject panel;
    public GameObject canvas;
    public BoatController boatController;
	
	// Update is called once per frame
	void Update () {
        
        if (transform.rotation.eulerAngles.z > 75.0f && transform.rotation.eulerAngles.z < 285.0f)
        {
            canvas.SetActive(true);
            panel.SetActive(true);
            boatController.canMove = false;
        }
	}
}
