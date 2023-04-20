using Assets.Scripts;
using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] public InventoryWeapon inventoryWeapon;

    [SerializeField] protected Transform _hole;
    [SerializeField] protected Ammo _ammo;
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected ShotDelayTimer _delayTimer;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Camera _camera;

    [SerializeField] protected float _spread;
    [SerializeField] protected float _damage;

    public virtual void Shoot()
    {
        var spreadX = UnityEngine.Random.Range(-_spread, _spread);
        var spreadY = UnityEngine.Random.Range(-_spread, _spread);

        var center = _camera.ScreenToWorldPoint(new Vector3(_camera.scaledPixelWidth/2, _camera.scaledPixelHeight/2,0),Camera.MonoOrStereoscopicEye.Mono);
        var ray = new Ray(center, _camera.transform.forward + new Vector3(spreadX, spreadY, 0));

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out var hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100);
        }
        var direction = targetPoint - center + new Vector3(spreadX, spreadY, 0);

        var bullet = Instantiate(_bullet, _camera.transform.position, _camera.transform.rotation);

        bullet.transform.Translate(0, 0, 2);
        Destroy(bullet, 1);

        if (hit.transform != null && hit.transform.GetComponent<Character>() == true)
        {
            hit.transform.GetComponent<Character>().TakeDamage(_damage);
        }

        _ammo.CurrentInClipCount--;

        _delayTimer.StartTimer();
    }
    public virtual void Aim()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _animator.SetBool("Aiming", true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            _animator.SetBool("Aiming", false);
        }
    }
    public virtual void Reload()
    {
        var lessAmmo = Mathf.Min(_ammo.ClipCapacity, _ammo.CurrentCount);
        _ammo.CurrentInClipCount = lessAmmo;
        _ammo.CurrentCount -= lessAmmo;
    }
}
