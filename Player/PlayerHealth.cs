using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float energy = 30f;
    public GameObject player;
    public GameObject resetPoint;
    public Text lowIndicator;

    private CharacterLocomotion locomotion; 

    public Image EnergyImage;
    public Sprite[] EnergyIcons;

    private IEnumerator degradeEnergy;

    private void Start()
    {
        degradeEnergy = decreaseEnergy();
        locomotion = GetComponent<CharacterLocomotion>();
        StartCoroutine(degradeEnergy);
    }

    public void increaseHealth(float amount)
    {
        energy += amount;
    }
    public void descreaseHealth (float damage)
    {
        energy -= damage;
    }

    private void Update()
    {
        // Energy Low Indicator
        if (energy <= 40)
        {
            lowIndicator.enabled = true;

        } else if (energy > 40)
        {
            lowIndicator.enabled = false;
        }

        // Energy UI
        if (energy >= 140)
        {
            energy = 140;
            EnergyImage.sprite = EnergyIcons[0];
        }
        else if (energy >= 120 && energy < 140)
        {
            EnergyImage.sprite = EnergyIcons[1];
        }
        else if (energy >= 100 && energy < 120)
        {
            EnergyImage.sprite = EnergyIcons[2];
        }
        else if (energy >= 80 && energy < 100)
        {
            EnergyImage.sprite = EnergyIcons[3];
        }
        else if (energy >= 60 && energy < 80)
        {
            EnergyImage.sprite = EnergyIcons[4];
        }
        else if (energy >= 40 && energy < 60)
        {
            EnergyImage.sprite = EnergyIcons[5];
        }
        else if (energy > 0 && energy < 40)
        {
            EnergyImage.sprite = EnergyIcons[6];
        }
        else if (energy <= 0)
        {
            EnergyImage.sprite = EnergyIcons[7];
            resetGame();
        }
    }

    public void resetGame()
    {
        locomotion.stopMovement();
        locomotion.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Dead");
    }

    IEnumerator decreaseEnergy()
    {
        while(true)
        {
            yield return new WaitForSeconds(30f);
            energy -= 20f;
        }
    }
}
