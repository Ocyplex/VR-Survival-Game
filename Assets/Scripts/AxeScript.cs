using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    public Rigidbody myBlade;
    void Start()
    {
        myBlade = FindObjectOfType<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with" + collision.gameObject.name);
        if (collision.gameObject.name == "Axe")
        {
            GameObject.Destroy(this);
        }
    }
}
