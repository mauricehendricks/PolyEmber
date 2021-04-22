using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameAudio : MonoBehaviour
{
    // Script to handle all game audio, except looping track

    //Here is where you can add more Audioclips if you want 
    [Header("Audio Clips for Game Sound FX")]
    public AudioClip itemPickup;
    public AudioClip menuNavigation;
    public AudioClip charge;
    public AudioClip running;
    public AudioClip flashLight;
    public AudioClip button;
    public AudioClip wrong;
    public AudioClip correct;

    [Range(0, 1)]
    public float VolumeLevel = 1;

    //And here is where you should create the respective AudioSource
    [HideInInspector] public AudioSource itemPickupSource;
    [HideInInspector] public AudioSource menuNavigationSource;
    [HideInInspector] public AudioSource chargeSource;
    [HideInInspector] public AudioSource runningSource;
    [HideInInspector] public AudioSource flashLightSource;
    [HideInInspector] public AudioSource buttonSource;
    [HideInInspector] public AudioSource wrongSource;
    [HideInInspector] public AudioSource correctSource;


    //The whole [HideInInspector] thing just makes it so that way you can't see these public variables in editor

    void Start()
    {
        SetUpAudio();
    }

    //Here is where you can add more audio sources and the like
    void SetUpAudio()
    {
        //First you have to make a new GameObject with a name
        GameObject itemPickupGameObject = new GameObject("itemPickupAudioSource");
        GameObject menuNavigationGameObject = new GameObject("menuNavigationAudioSource");
        GameObject chargeGameObject = new GameObject("chargeAudioSource");
        GameObject runningGameObject = new GameObject("runningAudioSource");
        GameObject flashLightGameObject = new GameObject("flashLightAudioSource");
        GameObject buttonGameObject = new GameObject("buttonAudioSource");
        GameObject wrongGameObject = new GameObject("wrongAudioSource");
        GameObject correctGameObject = new GameObject("correctAudioSource");


        //Next you have to Assign the parent so it's all organized
        AssignParent(itemPickupGameObject);
        AssignParent(menuNavigationGameObject);
        AssignParent(chargeGameObject);
        AssignParent(runningGameObject);
        AssignParent(flashLightGameObject);
        AssignParent(buttonGameObject);
        AssignParent(wrongGameObject);
        AssignParent(correctGameObject);


        //Then you have to add the actual audiosource to each gameobject
        itemPickupSource = itemPickupGameObject.AddComponent<AudioSource>();
        menuNavigationSource = menuNavigationGameObject.AddComponent<AudioSource>();
        chargeSource = chargeGameObject.AddComponent<AudioSource>();
        runningSource = runningGameObject.AddComponent<AudioSource>();
        flashLightSource = flashLightGameObject.AddComponent<AudioSource>();
        buttonSource = buttonGameObject.AddComponent<AudioSource>();
        wrongSource = wrongGameObject.AddComponent<AudioSource>();
        correctSource = correctGameObject.AddComponent<AudioSource>();

        //And finally you assign the clip to the audio source
        itemPickupSource.clip = itemPickup;
        menuNavigationSource.clip = menuNavigation;
        chargeSource.clip = charge;
        runningSource.clip = running;
        flashLightSource.clip = flashLight;
        buttonSource.clip = button;
        wrongSource.clip = wrong;
        correctSource.clip = correct;

        //And here is just where we assign the global volume level, you can make these individualized if you want
        itemPickupSource.volume = VolumeLevel;
        menuNavigationSource.volume = VolumeLevel;
        chargeSource.volume = VolumeLevel;
        runningSource.volume = 0.15f;
        flashLightSource.volume = .8f;
        buttonSource.volume = VolumeLevel;
        wrongSource.volume = VolumeLevel;
        correctSource.volume = .35f;

    }

    public void Play(string clipname)
    {

        if (clipname == "itemPickup")
        {
            itemPickupSource.clip = itemPickup;
            itemPickupSource.Play();
        }
        if (clipname == "menuNavigation")
        {
            menuNavigationSource.clip = menuNavigation;
            menuNavigationSource.Play();
        }
        if (clipname == "charge")
        {
            chargeSource.clip = charge;
            chargeSource.Play();
        }
        if (clipname == "running")
        {
            runningSource.clip = running;
            runningSource.Play();
        }
        if (clipname == "flashLight")
        {
            flashLightSource.clip = flashLight;
            flashLightSource.Play();
        }
        if (clipname == "button")
        {
            buttonSource.clip = button;
            buttonSource.Play();
        }
        if (clipname == "wrong")
        {
            wrongSource.clip = wrong;
            wrongSource.Play();
        }
        if (clipname == "correct")
        {
            correctSource.clip = correct;
            correctSource.Play();
        }
    }

    //Just a helper function that assigns whatever object as a child of this gameObject
    void AssignParent(GameObject obj)
    {
        obj.transform.parent = transform;
    }
}
