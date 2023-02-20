using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{

    public LvlCreator myLevelCreator;
    private bool wasCut = false;

    private void Start()
    {
        myLevelCreator = FindObjectOfType<LvlCreator>();
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with" + collision.gameObject.name);
        if(collision.gameObject.name == "Axe")
        {
            GameObject.Destroy(this);
        }
    }
    */
    public void BeingCut()
    {
        if(!wasCut)
        { 
            Instantiate(myLevelCreator.apple, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),Quaternion.identity);
            FallTree();
        }
    }

    private void FallTree()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
