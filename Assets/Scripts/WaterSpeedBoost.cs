using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpeedBoost : MonoBehaviour
{
    public float multiplier = 4.0f; 

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("TortoisePlayer"))
        {
            Tortoise playerController = other.GetComponent<Tortoise>();
            if (playerController != null)
            {
                playerController.SpeedBoost(multiplier);
            }
        }
    }
void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TortoisePlayer"))
        {
            Tortoise playerController = other.GetComponent<Tortoise>();
            if (playerController != null)
            {
                playerController.ResetSpeed();
            }
        }
    }
}