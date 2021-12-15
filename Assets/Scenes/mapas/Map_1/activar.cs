using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activar : MonoBehaviour
{
    public  GameObject gunnerObj;
 public  GameObject soldadoObj;
 public  GameObject bomberoObj;
 public  GameObject ninjaObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gunner ()
      {
        gunnerObj.SetActive(true);
        soldadoObj.SetActive(false);
        bomberoObj.SetActive(false);
        ninjaObj.SetActive(false);
    }
        public void soldado ()
      {
        gunnerObj.SetActive(false);
        soldadoObj.SetActive(true);
        bomberoObj.SetActive(false);
        ninjaObj.SetActive(false);
    }
            public void bombero ()
      {
        gunnerObj.SetActive(false);
        soldadoObj.SetActive(false);
        bomberoObj.SetActive(true);
        ninjaObj.SetActive(false);
    }
            public void ninja ()
      {
        gunnerObj.SetActive(false);
        soldadoObj.SetActive(false);
        bomberoObj.SetActive(false);
        ninjaObj.SetActive(true);
    }
}
