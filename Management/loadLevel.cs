using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour
{
    public string levelToLoad;
    private gameAudio aud;

    private void Start()
    {
        aud = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<gameAudio>();
    }
    public void LoadLevel(string name)
    {
        aud.Play("menuNavigation");
        SceneManager.LoadScene(name);
    }
}
