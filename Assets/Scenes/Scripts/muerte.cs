using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class muerte : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(WaitForSceneLoad());
    }

  private IEnumerator WaitForSceneLoad() {
     yield return new WaitForSeconds(8);
     SceneManager.LoadScene ("SelectorPlayer");
     
 }
 void OnTriggerEnter(Collider other) {
     // Do your things, then:
     StartCoroutine(WaitForSceneLoad());
     // And done
 }
}
