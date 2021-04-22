using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class float_noRotation : MonoBehaviour
{
   // public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public Transform objectToFollow;
    public float heightchange = 0;
    public float LRchange = 0;
    float x,z;
    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
      //  Debug.Log(posOffset);
       // Debug.Log(objectToFollow.position); 
       
        x = posOffset.x - objectToFollow.position.x;
        z = posOffset.z - objectToFollow.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        //   transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = objectToFollow.position;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        
        transform.position = new Vector3(tempPos.x+x+LRchange, tempPos.y-posOffset.y+heightchange, tempPos.z+z);
    }
}
