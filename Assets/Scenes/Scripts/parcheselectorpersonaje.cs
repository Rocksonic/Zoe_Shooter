using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parcheselectorpersonaje : MonoBehaviour
{
    public GameObject soldados;
    public GameObject ninja;
    public GameObject bombero;
    public GameObject gunner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Nija()
     {
        ninja.SetActive (true);
        soldados.SetActive (false);
        bombero.SetActive (false);
        gunner.SetActive (false);
    }
    public void soldados2()
     {
         ninja.SetActive (false);
        soldados.SetActive (true);
        bombero.SetActive (false);
        gunner.SetActive (false);
    }
    public void bomberos()
     {
         ninja.SetActive (false);
        soldados.SetActive (false);
        bombero.SetActive (true);
        gunner.SetActive (false);
    }
    public void gunners()
     {
         ninja.SetActive (false);
        soldados.SetActive (false);
        bombero.SetActive (false);
        gunner.SetActive (true);
    }
}
