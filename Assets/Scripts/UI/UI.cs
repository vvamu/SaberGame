using Assets.Scripts;
using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private Slider _shieldBarSlider;
    [SerializeField] private Slider _grenadeReloadSlider;
    [SerializeField] private TextMeshProUGUI _ammoDisplayText;
    [SerializeField] private Image _currentWeaponImage;
    [SerializeField] private GameObject _hitMarkerIcon;
    [SerializeField] private Sprite[] _weaponImages;
    [SerializeField] private AudioSource _hitMarkerSound;

    private void OnEnable()
    {
        EventBus.onHit += HitSound;
        EventBus.onGrenadeReload += DisplayGrenade;
        EventBus.onHealthChange += DisplayHealth;
        EventBus.onShieldChange += DisplayShield;
        EventBus.onWeaponChange += DisplayCurrentWeapon;
    }
    private void OnDestroy()
    {
        EventBus.onHit -= HitSound;
        EventBus.onGrenadeReload -= DisplayGrenade;
        EventBus.onHealthChange -= DisplayHealth;
        EventBus.onShieldChange -= DisplayShield;
        EventBus.onWeaponChange -= DisplayCurrentWeapon;
    }
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

    public void HitSound()
    {
        StartCoroutine(ShowHitmarket());
    }

    IEnumerator ShowHitmarket()
    {
        _hitMarkerIcon.SetActive(true);
        _hitMarkerSound.Play();
        yield return new WaitForSeconds(.2f);
        _hitMarkerIcon.SetActive(false);
        yield return null;
    }
}
