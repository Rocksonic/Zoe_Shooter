using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBobbingV3 : MonoBehaviour
{

    public Transform _startingPosition;
    public Transform _finalPosition;
    public Transform _defaultPosition;
    public Transform _reloadPosition;
    public float speed;
    public bool _go = false;
    public bool _comeBack = false;
    public static bool _reloading = false;
    public bool WeaponCanReload;

    // Update is called once per frame
    void Update()
    {
        if (_reloading && WeaponCanReload)
        {
            transform.position = Vector3.MoveTowards(transform.position, _reloadPosition.position, speed * Time.deltaTime);
        }

        else if (_go)
        {
            if (!_comeBack)
            {
                transform.position = Vector3.MoveTowards(transform.position, _finalPosition.position, speed * Time.deltaTime);
                if (transform.position == _finalPosition.position)
                {
                    _comeBack = !_comeBack;
                }
            }

            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _startingPosition.position, speed * Time.deltaTime);
                if (transform.position == _startingPosition.position)
                {
                    _comeBack = !_comeBack;
                }
            }
        }
        
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _defaultPosition.position, speed * Time.deltaTime * 2);
        }
    }
}
