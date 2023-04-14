using Assets.Scripts;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;


//TODO
public class InventoryWeapon : MonoBehaviour
{

    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _description;
    private Image _image;

    public void Start()
    {
        var image = GameObject.Find("WeaponImage").GetComponent<Image>();
    }
    public void ChangeWeaponIcon(Weapon weapon)
    {
         _image.sprite = weapon.inventoryWeapon._icon;
    }


}
