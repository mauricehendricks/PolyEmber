using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameMoveBlue : MonoBehaviour
{
    public GameObject green;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

    }
    void OnTriggerEnter(Collider myCollider)
    {
        if (myCollider.gameObject.name == "BlueBase")
        {
            green.SetActive(true);
            Destroy(gameObject);
        }
    }

}