using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform spawn;
    public GameObject bulletPrefab;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletClone = Instantiate(bulletPrefab, spawn.position, transform.rotation);
            bulletClone.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                 (0, 0, speed));
        }
    }
}
