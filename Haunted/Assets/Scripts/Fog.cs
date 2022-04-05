using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    public float moveSpeed;
    public int timeUntilDeath;

    bool m_IsPlayerInRange;
    float count = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        if (m_IsPlayerInRange)
        {
            count += Time.deltaTime;
            if (count >= timeUntilDeath)
                gameEnding.CaughtPlayer();
        }
        else
        {
            count = 0;
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
}
