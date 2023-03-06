using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;



public class CrossBow : MonoBehaviour
{
    public Bolt myBolt;
    private float shootForce = 30f;
    private XRSocketInteractor myXRSocketInteractor;
    private AudioSource myAudioSource;
    public bool reloadAble = true;
    public bool loaded = false;
    public bool lineFixed = false;

    void Start()
    {
        myXRSocketInteractor = GetComponentInChildren<XRSocketInteractor>();
        myAudioSource = GetComponent<AudioSource>();
    }


    public void Shoot()
    {
        if(myBolt != null && !reloadAble && loaded)
        { 
            myXRSocketInteractor.socketActive = false;
            myBolt.myRB.AddForce(transform.forward * shootForce, ForceMode.Impulse);
            myBolt.Whistle();
            myBolt = null;
            myAudioSource.Play();

            reloadAble = true;
            loaded = false;
            lineFixed = false;

        }
        else
        {

            myXRSocketInteractor.socketActive = true;
            loaded = false;
        }
    }

    private void Update()
    {

    }

}
