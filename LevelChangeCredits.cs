using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class LevelChangeCredits : MonoBehaviour
{
    private gameAudio aud;

    private void Start()
    {
        aud = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<gameAudio>();
    }
    public void NextScene()
    {
        aud.Play("menuNavigation");
        SceneManager.LoadScene("Credits");
    }
}

