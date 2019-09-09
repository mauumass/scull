using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour {

    public float speed = 0.0f;
    public float rotationSpeed = 45.0f;
    public float moveAxis = 1.0f;
    public GameObject boat;
    public bool canMove = true;
    public float speedCap = 0.5f;

    public AudioSource audio;
	
	// Update is called once per frame
	void Update () {
        if (canMove)
        {
            float turnAxis = 0.0f;
            bool drift = false;

            if(speed > speedCap)
            {
                speed -= 0.005f;
            }

            if (Input.GetKey("s"))
            {
                turnAxis = 0.0f;
                if (speed > 0.0f) {
                    speed -= 0.005f;
                    speed = Math.Max(0.0f, speed);
                }
                if(audio.isPlaying)
                {
                    audio.Stop();
                }
            }
            else
            {
                if (Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w"))
                {
                    if (Input.GetKey("w"))
                    {
                        if (speed < speedCap) { speed += 0.005f; }
                    }
                    if (Input.GetKey("a"))
                    {
                        if (Input.GetKey("left")) {
                            rotationSpeed = 90.0f;
                        }
                        else { rotationSpeed = 60.0f; }

                        turnAxis = -1.0f;
                        if (speed < speedCap) { speed += 0.0025f; }
                        drift = true;
                    }
                    else if (Input.GetKey("d"))
                    {
                        if (Input.GetKey("right")) { rotationSpeed = 90.0f; }
                        else { rotationSpeed = 60.0f; }

                        turnAxis = 1.0f;
                        if (speed < speedCap) { speed += 0.0025f; }
                        drift = true;
                    }
                    if (!audio.isPlaying)
                    {
                        audio.Play();
                    }
                }
                else
                {
                    if (speed > 0.0f) { speed -= 0.0025f; }
                    if (speed < 0.0f) { speed = 0.0f; }
                }

                if (Input.GetKey("left") && !drift)
                {
                    turnAxis = -1.0f;
                    rotationSpeed = 30.0f;
                }
                else if (Input.GetKey("right") && !drift)
                {
                    turnAxis = 1.0f;
                    rotationSpeed = 30.0f;
                }
            }

            boat.transform.Translate(-Vector3.forward * moveAxis * speed); // Invert forward due to boat forward position
            boat.transform.Rotate(0, turnAxis * rotationSpeed * Time.deltaTime, 0);
        }
    }
}
