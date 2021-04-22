using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationTrigger : MonoBehaviour {

    [SerializeField] private GameObject displayed;
    bool hasActivated = false;

    private Inventory inventory;
    void Start()
    {
        displayed.SetActive(false);
        inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (this.name == "LabTrigger")
            {
                displayed.SetActive(true);
            }
        }

        if (collision.CompareTag("Player") && !hasActivated)
        {
            if (this.name == "Trigger 3")
            {
                inventory.craftingTutorial = true;
            }

            displayed.SetActive(true);
            hasActivated = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            displayed.SetActive(false);
        }
    }
}
