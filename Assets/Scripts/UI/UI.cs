using Assets.Scripts;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject Player;
    private Slider _healthBarSlider;
    private TextMeshProUGUI _ammoDisplayText;
    private Player _player;
    private Inventory _inventory;

    void Start()
    {
        _healthBarSlider = Player.GetComponentInChildren<Slider>();
        _ammoDisplayText = Player.GetComponentInChildren<TextMeshProUGUI>();
        _healthBarSlider.maxValue = Player.GetComponent<Player>().MaxHealth;
        _player = Player.GetComponent<Player>();
        _inventory = Player.GetComponent<Inventory>();
    }

    void Update()
    {
        _healthBarSlider.value = _player.Health;
        Ammo currentammo = _inventory.CurrentWeapon.GetComponent<Ammo>();
        _ammoDisplayText.text = currentammo.CurrentInClipCount.ToString() + " / " + currentammo.CurrentCount.ToString();
    }
}
