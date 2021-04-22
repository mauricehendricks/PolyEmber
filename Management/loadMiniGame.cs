using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadMiniGame : MonoBehaviour
{
    public GameObject safe;
    public GameObject safeMinigameUI;

    private string levelToLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (this.tag == "ATM Safe")
        {
            safeMinigameUI.SetActive(true);
            levelToLoad = "AmongUsMiniGame";
        }
    }

    public void activateMiniGame ()
    {
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Additive);
    } 
}
