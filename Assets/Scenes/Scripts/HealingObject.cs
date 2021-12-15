using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingObject : MonoBehaviour
{
    public float healing;
    public float timeLife;

    
    void Start()
    {
        Destroy(gameObject, timeLife);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            other.gameObject.GetComponent<PlayerController>().TakeHealing(healing);
            Destroy(gameObject);
        }
    }
}
