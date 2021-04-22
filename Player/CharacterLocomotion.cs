using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    Animator animator;
    public Vector2 input;

    private gameAudio aud;


    void Start()
    {
        animator = GetComponent<Animator>();
        aud = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<gameAudio>();
    }

    public void stopMovement ()
    {
        input.x = 0f;
        input.y = 0f;

        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);

        if (aud.runningSource.isPlaying && aud.runningSource.clip != null)
        {
            aud.runningSource.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        if (input.x != 0 || input.y != 0)
        {
            if (!aud.runningSource.isPlaying && aud.runningSource.clip != null)
            {
                aud.Play("running");
            }
            
        }
        else
        {
            if (aud.runningSource.isPlaying && aud.runningSource.clip != null)
            {
                aud.runningSource.Stop();
            }
        }

        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);
    }
}
