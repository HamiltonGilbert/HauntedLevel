using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverNonFatal : MonoBehaviour
{
    public Transform player;
    public WaypointPatrol wayPointPatrol;
    public float ghostHuntTime;
    public bool ghostHunting;

    bool m_IsPlayerInRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);

            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player && !ghostHunting)
                {
                    ghostHunting = true;
                    wayPointPatrol.IsHunting = true;
                    Invoke(nameof(GhostHuntEnd), ghostHuntTime);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    private void GhostHuntEnd()
    {
        wayPointPatrol.ResetGhost();
        wayPointPatrol.IsHunting = false;
        ghostHunting = false;
    }
}
