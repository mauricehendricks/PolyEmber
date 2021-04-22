using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInRange : MonoBehaviour
{
    private GameObject parent;
    private Outline outline;
    private void Start()
    {
        parent = this.transform.parent.gameObject;
        outline = parent.GetComponent<Outline>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            outline.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            outline.enabled = false;
        }
    }
}
