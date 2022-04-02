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

    private void Start()
    {
        ResetGhost();
    }

    void Update()
    {
        if (IsHunting)
        {
            if (InPlayerSight)
            {
                navMeshAgent.SetDestination(transform.position);
            }
            else
            {
                navMeshAgent.SetDestination(player.position);
            }
        }
        else
        {
            navMeshAgent.SetDestination(transform.position);
        }
    }

    public void ResetGhost()
    {
        int index = Random.Range(0, 9);
        transform.position = waypoints[index].position;
    }
}
