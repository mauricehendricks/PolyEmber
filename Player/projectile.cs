using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float velocity = 30f;
    public GameObject p;
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
