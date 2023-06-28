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
    [SerializeField] private TextMeshProUGUI _ammoDisplayText;
    private Player _player;
    private Inventory _inventory;

    void Start()
    {
        //_healthBarSlider = Player.GetComponentInChildren<Slider>();
        //_ammoDisplayText = Player.GetComponentInChildren<TextMeshProUGUI>();
        //_healthBarSlider.maxValue = Player.GetComponent<Player>().MaxHealth;
        //_player = Player.GetComponent<Player>();
        //_inventory = Player.GetComponent<Inventory>();
    }

    void Update()
    {
        //_healthBarSlider.value = _player.Health;
       // TODO Ammo currentammo = _inventory.CurrentWeapon.GetComponent<Ammo>();
       // _ammoDisplayText.text = currentammo.CurrentInClipCount.ToString() + " / " + currentammo.CurrentCount.ToString();
    }

    public void DisplayWeapon(int a1, int a2, int a3, int a4)
    {
        _ammoDisplayText.text = $"{a1}/{a2}\n{a3}/{a4}";
    }

    public void DisplayHealth(float heath, float maxHealth)
    {
        _healthBarSlider.value = heath / maxHealth;
    }
}
