using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startOver : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("WaitaWhile");
    }


    public IEnumerator WaitaWhile()
    {

        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("OpeningStory");
    }
}
