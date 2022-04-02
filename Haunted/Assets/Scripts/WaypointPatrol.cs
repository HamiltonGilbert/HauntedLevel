using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform[] waypoints;
    [SerializeField] new Renderer renderer;
    public NavMeshAgent navMeshAgent;

    public bool InPlayerSight { get; set; }
    public bool isHunting;

    private void Start()
    {
        ResetGhost();
    }

    void Update()
    {
        if (isHunting)
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
        isHunting = false;
        int index = Random.Range(0, 9);
        transform.position = waypoints[index].position;
        renderer.enabled = false;
    }

    public void StartHunt()
    {
        renderer.enabled = true;
        isHunting = true;
    }
}
