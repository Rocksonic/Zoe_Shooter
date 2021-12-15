using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject _player;
    public Transform _teleportExit;

    void OnTriggerEnter(Collider other)
    {
        PlayerController _playerController = _player.GetComponent<PlayerController>();
        _playerController.cH.enabled = false;
        _player.transform.position = _teleportExit.position;
        _player.transform.rotation = _teleportExit.rotation;
        _playerController.cH.enabled = true;
    }
}