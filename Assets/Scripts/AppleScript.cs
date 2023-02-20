using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{

    public PlayerStatus myPlayerStatus;
    private int foodValue = 15;

    private void Start()
    {
        myPlayerStatus = FindObjectOfType<PlayerStatus>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.2f); //DrawWireSphere
    }
    
    private void OnCollisionEnter(Collision collision) //if object moves near head
    {
        if(collision.gameObject.GetComponent<Camera>())
        {
            myPlayerStatus.EatFood(foodValue);
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Camera>())
        {
            myPlayerStatus.EatFood(foodValue);
            Destroy(this);
        }
    }
}
