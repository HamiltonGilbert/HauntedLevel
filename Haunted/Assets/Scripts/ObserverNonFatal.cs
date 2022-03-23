using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverNonFatal : MonoBehaviour
{
    public Transform player;
    public GameObject ghost;
    public float ghostHuntTime;

    GameObject ghostInstance = null;
    bool ghostHunting = false;

    bool m_IsPlayerInRange = false;

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
                    ghostInstance = Instantiate(ghost, transform.position, transform.rotation);
                    ghostHunting = true;
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
        // start timer until ghost destroys itself
    }

    private void GhostHuntEnd()
    {
        Destroy(ghostInstance);
        ghostHunting = false;
    }
}
