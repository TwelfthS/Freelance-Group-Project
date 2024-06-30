using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public GameObject player;
    public bool seesPlayer = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<PlayerMovement>() != null) {
            player = collider.gameObject;
            seesPlayer = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<PlayerMovement>() != null) {
            seesPlayer = false;
        }

    }
}
