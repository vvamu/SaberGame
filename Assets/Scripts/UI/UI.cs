using Assets.Scripts;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private Slider _shieldBarSlider;
    [SerializeField] private Slider _grenadeReloadSlider;
    [SerializeField] private TextMeshProUGUI _ammoDisplayText;
    [SerializeField] private Image _currentWeaponImage;
    [SerializeField] private Sprite[] _weaponImages;

    public void DisplayGrenade(float current, float max)
    {
        _grenadeReloadSlider.value = current / max;
    }

    public void DisplayCurrentWeapon(int id)
    {
        _currentWeaponImage.sprite = _weaponImages[id];
    }

    public void DisplayWeapon(int a1, int a2, int a3, int a4)
    {
        _ammoDisplayText.text = $"{a1}/{a2}\n{a3}/{a4}";
    }

    public void DisplayShield(float shield, float maxShield)
    {
        _shieldBarSlider.value = shield / maxShield;
    }

    public void DisplayHealth(float heath, float maxHealth)
    {
        _healthBarSlider.value = heath / maxHealth;
    }
}
