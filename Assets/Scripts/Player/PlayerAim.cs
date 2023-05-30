using Assets.Scripts.Weapon;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerAim : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Camera _camera;
        void Update()
        {
            var center = _camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
            _inventory.CurrentWeapon.Aim.SetShootPositionAndDirection(center.origin, center.direction);

            if (Input.GetMouseButtonDown(0))
                _inventory.CurrentWeapon.MainFire.Press();

            if (Input.GetMouseButtonUp(0))
                _inventory.CurrentWeapon.MainFire.Release();

            if (Input.GetKeyDown(KeyCode.R))
                _inventory.CurrentWeapon.Magazine.Reload();
        }
    }
}