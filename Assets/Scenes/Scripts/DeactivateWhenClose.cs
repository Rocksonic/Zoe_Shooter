using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateWhenClose : MonoBehaviour
{
    public GameObject _objectToActivate;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _objectToActivate.SetActive(true);
            CrosshairController.DeactivateCrosshair();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CrosshairController.DeactivateCrosshair();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CrosshairController.ActivateCrosshair();
            _objectToActivate.SetActive(false);
        }
    }
}
