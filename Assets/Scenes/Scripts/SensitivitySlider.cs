using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider _sensitivitySlider;
    public Text _sensitivityText;
    public PlayerController _playerController;

    void Awake()
    {
        _sensitivitySlider.maxValue = 150;
        _sensitivitySlider.minValue = 0.01f;
        _sensitivitySlider.value = _playerController.Sensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        _playerController.Sensitivity = _sensitivitySlider.value;
        _sensitivityText.text = "Sensitivity: " + _sensitivitySlider.value;
    }
}
