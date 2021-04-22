using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceScanFacePlayer : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Pipe").GetComponent<FaceScanPlayer>().isActive == true)
        {

            //code
            transform.LookAt(player);

        }
    }
}
