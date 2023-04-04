using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyRiffle : EnergyWeapon
{
    private bool CanShoot => _delayTimer.IsReadyToShoot && _ammo.CurrentInClipCount > 0;
    void Update()
    {
        Aim();
        if (Input.GetMouseButton(0) && CanShoot)
        {
            Shoot();
        }
        if (_ammo.CurrentInClipCount <= 0)
        {
            Reload();
        }
    }
    public override void Charge(float value)
    {
        if(_ammo.CurrentCount + value <= _ammo.MaxCapacity)
        {
            _ammo.CurrentCount += value;
        }
    }
}
