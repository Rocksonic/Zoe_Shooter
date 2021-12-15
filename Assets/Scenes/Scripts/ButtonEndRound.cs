using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEndRound : MonoBehaviour
{
    public GameObject _RoundManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            _RoundManager.GetComponent<RoundManager>().resetAll();
        }
    }
}
