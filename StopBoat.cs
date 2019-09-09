using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBoat : MonoBehaviour
{
    public BoatController bc;

    private void OnTriggerEnter(Collider collider)
    {
        bc.speed = 0.0f;
    }

    private void OnTriggerStay(Collider collider)
    {
        bc.speed = 0.0f;
    }
}
