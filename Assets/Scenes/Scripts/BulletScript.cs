using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject Player;
    public float damageBullet;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        target = Player.transform;
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.layer == 6)
        {  
            
            Player.GetComponent<PlayerController>().TakeDamage(damageBullet);
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 7)
        {
            
            Destroy(gameObject);
        }
        Destroy(gameObject, 10f);
    }
}
