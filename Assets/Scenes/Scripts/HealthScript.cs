using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private static Slider _RealHealthSlider;
    private static Text _RealHealthText;
    private static PlayerController _RealPlayerController;

    public Slider _healSlider;
    public Text _healthText;
    public PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _RealHealthSlider = _healSlider;
        _RealHealthText = _healthText;
        _RealPlayerController = _playerController;
        _RealHealthText.text = "Vida: " + _RealPlayerController.currentHealth;
        _RealHealthSlider.maxValue = _RealPlayerController.maxHealth;
        _RealHealthSlider.value = _RealPlayerController.currentHealth;
    }

    public static void  UpdateHealthBar()
    {
        _RealHealthText.text = "Vida: " + _RealPlayerController.currentHealth;
        _RealHealthSlider.maxValue = _RealPlayerController.maxHealth;
        _RealHealthSlider.value = _RealPlayerController.currentHealth;
    }
}
