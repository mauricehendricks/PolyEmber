using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommTowerUI : MonoBehaviour
{
    public GameObject CardUI;
    public GameObject freeLookCam;

    private CharacterLocomotion locomotion;
    private TopDownCharacterMover movement;
    // Start is called before the first frame update
    void Start()
    {
        locomotion = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterLocomotion>();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<TopDownCharacterMover>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Robot_Soldier_Black")
        {
            
        }
        else
        {
            CardUI.SetActive(false);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CardUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            freeLookCam.SetActive(false);
            locomotion.stopMovement();
            locomotion.enabled = false;
            movement.enabled = false;
            StartCoroutine(UIScrolling());
        }
    }

    IEnumerator UIScrolling()
    {
        //print(Time.time);
        yield return new WaitForSeconds(20);
        CardUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        freeLookCam.SetActive(true);
        locomotion.enabled = true;
        movement.enabled = true;

    }
}
