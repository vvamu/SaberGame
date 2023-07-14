using Assets.Scripts;
using Assets.Scripts.Weapon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    #region Properties
    public BaseWeapon CurrentWeapon { get => _currentWeapon ?? Weapons.FirstOrDefault(); set => _currentWeapon = value; }
    private int _currentWeaponIndex;//=> Array.IndexOf(Weapons, CurrentWeapon);

    #endregion

    #region Fields

    public BaseWeapon _currentWeapon;

    [SerializeField] private BaseWeapon[] Weapons;
    [SerializeField] private static int maxVolume = 5;
    [SerializeField] private float switchSpeed = 5f;
    [SerializeField] private WeaponAmmo[] weaponAmmos;


    #endregion

    #region Methods
    public BaseWeapon ChangeCurrentWeapon(int index)
    {
       if (index > maxVolume || index < 0) throw new ArgumentOutOfRangeException();

       CurrentWeapon.gameObject.SetActive(false);
       CurrentWeapon = Weapons[index];
       CurrentWeapon.gameObject.SetActive(true);

        onChangeCurrentWeapon.Invoke(index);

       return CurrentWeapon;
    }


    #region Optional - AddToInventory
    //public void AddToInventory(Weapon weapon)
    //{
    //    if (InventoryIsFull) return;
    //    //Weapons[IndexOfFirstEmptyElement()] = weapon;

    //}

    private bool InventoryIsFull =>
    Weapons.Select(x => x == null).Any();

    private int IndexOfFirstEmptyElement()
    {
        return Weapons.Select((weapon, index) => (weapon, index)).FirstOrDefault(null).index;
    }


    #endregion


    #endregion


    #region MonoBehavior

    private void Awake()
    {
        for (int i = 0; i < weaponAmmos.Length; i++)
        {
            weaponAmmos[i] = Instantiate(weaponAmmos[i]);
        }
        onChangeCurrentWeapon.Invoke(0);
    }

    public void ChangeWeapon()
    {
        float mouseWheelInput = Input.GetAxis("Mouse ScrollWheel");
        

        if (mouseWheelInput != 0f)
        {
            //int nextObjectIndex = (_currentWeaponIndex - (int)Mathf.Sign(mouseWheelInput)) % Weapons.Length;

            int nextObjectIndex = _currentWeaponIndex - (int)Mathf.Sign(mouseWheelInput);

            if (nextObjectIndex < 0)
            {
                nextObjectIndex = Weapons.Length - 1;
            }
            else if (nextObjectIndex >= Weapons.Length)
            {
                nextObjectIndex = 0;
            }

            StartCoroutine(SwitchObjectSmoothly(nextObjectIndex));
        }





        //if (Input.GetKeyDown(KeyCode.Alpha1)) 
        //{
        //    Debug.Log(CurrentWeapon.ToString());
        //    ChangeCurrentWeapon(0);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2)) 
        //{
        //    Debug.Log(CurrentWeapon.ToString());
        //    ChangeCurrentWeapon(1);
        //}
    }

    IEnumerator SwitchObjectSmoothly(int nextObjectIndex)
    {
        float elapsedTime = 0f;

        ChangeCurrentWeapon(nextObjectIndex);
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * switchSpeed;
            yield return null;
        }

        _currentWeaponIndex = nextObjectIndex;
    }

    public void Update()
    {
        ChangeWeapon();
    }

    #endregion

}

