using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartRound : MonoBehaviour
{
    public GameObject _RoundManager;
    public GameObject _RoundCount;
    public GameObject _Timer;
    public GameObject _buttonOf;
    public GameObject _Dificulty;
    private bool lockStart;
    private float _DistanceHide = 60f;
    //private Vector3 ActualPosition;
    
    private void Start()
    {
        //ActualPosition = transform.position;
        lockStart = false;
    }

    void OnEnable() {
        
    }

    private void Update() 
    {
        if (_Timer.GetComponent<Timer>().isFinishTime && lockStart)
        {
            lockStart = false;
            _RoundManager.GetComponent<RoundManager>().NextRound();
            hide();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 6)
        {
            if (lockStart == false)
            {
                _Timer.GetComponent<Timer>().startTimer();
                _buttonOf.SetActive(false);
                _Dificulty.SetActive(false);
            }
            lockStart = true;
        }
    }

    private void hide()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y + _DistanceHide, transform.position.z);
        gameObject.SetActive(false);
        _RoundCount.SetActive(true);
        _buttonOf.SetActive(false);
        _Dificulty.SetActive(false);
    }

    public void show()
    {
        gameObject.SetActive(true);
        _buttonOf.SetActive(true);
        _Dificulty.SetActive(true);
        Debug.Log("hola");
        //transform.position = ActualPosition;
        
    }
}
