using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrosshairController : MonoBehaviour
{
    public GameObject crosshair;
    static GameObject realCrosshair;


    void Awake()
    {
        realCrosshair = crosshair;
    }

    public static void ActivateCrosshair()
    {
        realCrosshair.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public static void DeactivateCrosshair()
    {
        realCrosshair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }
}
