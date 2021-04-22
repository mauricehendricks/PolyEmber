using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enemycount : MonoBehaviour
{   public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("shootenemy");
        int num = npcs.Length;
        if( num == 0)
            { //button.SetActive(true);

            SceneManager.LoadScene("Win");
        }
    }
}
