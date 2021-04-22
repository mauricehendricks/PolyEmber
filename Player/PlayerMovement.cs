using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

  
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        { transform.Translate(speed * Time.deltaTime, 0, 0);
          //  transform.Rotate(0, 90 , 0);
        }
        if (Input.GetKey(KeyCode.A))
        { transform.Translate(0, 0, speed * Time.deltaTime);
          //  transform.Rotate(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.S))
        { transform.Translate(-(speed * Time.deltaTime), 0, 0);
         //   transform.Rotate(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.D))
        { transform.Translate(0, 0, -(speed * Time.deltaTime));
          //  transform.Rotate(0, -180, 0);
        }

    }
}
