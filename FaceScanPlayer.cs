using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceScanPlayer : MonoBehaviour
{
    public Transform player;
    public GameObject Scanner;
    public bool isActive = false;

    void OnTriggerStay(Collider myCollider)
    {
        if (myCollider.gameObject.name == "Robot_Soldier_Black")
        {
            Scanner.gameObject.GetComponent<Animator>().enabled = false;
            //transform.LookAt(player);
            isActive = true;
        }

    }

    void OnTriggerExit(Collider myCollider)
    {
        if (myCollider.gameObject.name == "Robot_Soldier_Black")
        {
            Scanner.gameObject.GetComponent<Animator>().enabled = true;
            isActive = false;
            

        }

    }
}