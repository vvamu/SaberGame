﻿using Assets.Scripts.Weapon;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerAim : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Transform _bulletHole;
        [SerializeField] private Camera _camera;
        void Update()
        {
            Aim();

            if (Input.GetMouseButtonDown(0))
                _inventory.CurrentWeapon.MainFire.Press();

            if (Input.GetMouseButtonUp(0))
                _inventory.CurrentWeapon.MainFire.Release();

            if (Input.GetKeyDown(KeyCode.R))
                _inventory.CurrentWeapon.Magazine.Reload();
        }

        private void Aim()
        {
            var center = _camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));

            Vector3 targetPoint;
            if (Physics.Raycast(center, out RaycastHit hit)) targetPoint = hit.point;
            else targetPoint = center.GetPoint(100);

            Vector3 direction = targetPoint - _bulletHole.transform.position;

            _inventory.CurrentWeapon.Aim.SetShootPositionAndDirection(_bulletHole.transform.position, direction.normalized);
        }
    }
}