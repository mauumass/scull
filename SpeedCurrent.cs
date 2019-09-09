using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCurrent : MonoBehaviour {

    public BoatController bc;
    private bool sameDirection = false;
    public bool left = false;
    public bool right = false;
    public float angle;

    private void OnTriggerEnter(Collider collider)
    {
        float dot = Vector3.Dot(transform.forward, bc.boat.transform.forward);
        sameDirection = dot >= 0;
        if (sameDirection)
        {
            bc.speedCap = 0.75f;
            if (bc.speed + 0.25f < 0.8f)
            {
                bc.speed += 0.25f;
            }
        } else
        {
            if (bc.speed - 0.15f > 0.05f)
            {
                bc.speed -= 0.15f;
            }
            bc.speedCap = 0.3f;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (right || left)
        {
            if (right)
            {
                if (bc.boat.transform.rotation.eulerAngles.y > 180 + angle && bc.boat.transform.rotation.eulerAngles.y <= 360.0f || bc.boat.transform.rotation.eulerAngles.y < angle)
                {
                    bc.boat.transform.Rotate(0, 1 * 45.0f * Time.deltaTime, 0);
                }
                else
                 {
                    bc.boat.transform.Rotate(0, -1 * 45.0f * Time.deltaTime, 0);
                }
            }
            else
            {
                if (bc.boat.transform.rotation.eulerAngles.y < angle - 180 || bc.boat.transform.rotation.eulerAngles.y > 350.0f)
                {
                    bc.boat.transform.Rotate(0, -1 * 45.0f * Time.deltaTime, 0);
                }
                else
                {
                    bc.boat.transform.Rotate(0, 1 * 45.0f * Time.deltaTime, 0);
                }
            }
        }
        else
        {
            if (sameDirection)
            {
                if (transform.rotation.eulerAngles.y > bc.boat.transform.rotation.eulerAngles.y)
                {
                    bc.boat.transform.Rotate(0, 1 * 45.0f * Time.deltaTime, 0);
                }
                else if (transform.rotation.eulerAngles.y < bc.boat.transform.rotation.eulerAngles.y)
                {
                    bc.boat.transform.Rotate(0, -1 * 45.0f * Time.deltaTime, 0);
                }
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        bc.speedCap = 0.5f;
    }
}
