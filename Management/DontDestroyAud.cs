using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAud : MonoBehaviour
{
    public static DontDestroyAud aud;
    // Start is called before the first frame update
    void Start()
    {
        if (aud == null)
        {
            aud = this;
        }
        else
        {
            if (aud != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
