using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofSocket : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.1f); //DrawWireSphere
    }
}
