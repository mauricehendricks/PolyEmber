using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpConstantVelocity : MonoBehaviour
{

    public float velocity = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;

        newPos.z += velocity * Time.deltaTime;

        transform.position = newPos;
    }
}
