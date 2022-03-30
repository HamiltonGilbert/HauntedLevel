using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSight : MonoBehaviour
{
    public Transform ghost;
    [SerializeField] WaypointPatrol waypointPatrol;
    //[SerializeField] ObserverNonFatal observerNonFatal;
    //bool GhostInSight { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == ghost)
        {
            waypointPatrol.InPlayerSight = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform == ghost)
        {
            waypointPatrol.InPlayerSight = false;
        }
    }
}
