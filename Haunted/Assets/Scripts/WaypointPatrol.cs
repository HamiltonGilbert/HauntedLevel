using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform[] waypoints;
    public NavMeshAgent navMeshAgent;

    public bool InPlayerSight { get; set; }
    public bool IsHunting { get; set; }

    void Update()
    {
        if (InPlayerSight && IsHunting)
        {
            navMeshAgent.SetDestination(transform.position);
        }
        else
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    public void EndHunt()
    {
        int index = Random.Range(0, 10);
        transform.position = waypoints[index].position;
    }
}
