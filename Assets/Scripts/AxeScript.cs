using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    public Rigidbody myBlade;
    public AudioSource axeSound;
    public AudioClip cuttingwood;


    void Start()
    {
        myBlade = FindObjectOfType<Rigidbody>();
        axeSound = GetComponent<AudioSource>();

    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with" + collision.gameObject.name);
        if (collision.gameObject.name == "Axe")
        {
            Destroy(collision.gameObject);
        }
    }
    */
    private void OnTriggerEnter(Collider other)
    {

            Debug.Log("Collision with" + other.gameObject.name);
            if (other.gameObject.GetComponent<TreeScript>())
            {
                other.gameObject.GetComponent<TreeScript>().BeingCut();
                axeSound.Play(0);
             }

    }
}
