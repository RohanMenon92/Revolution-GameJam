using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
/// <summary>
/// Controls collision with enemies and pickups and sends on the message to Player Controller
/// </summary>
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
            this.GetComponentInParent<PlayerController>().OnObstacleHit(transform);
        }

        if(collision.transform.tag == "SmokeTrigger")
        {
            this.GetComponentInParent<PlayerController>().OnSmokeTriggerHit(transform);
        }

        if(collision.transform.tag == "PickUp")
        {
            collision.transform.GetComponent<PickUpScript>().OnPickUp();
            this.GetComponentInParent<PlayerController>().OnPickUpHit(transform);
        }

    }
}
