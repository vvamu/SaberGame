using Assets.Scripts;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] protected GameObject _aim;

    [SerializeField] protected float _spread;
    [SerializeField] protected float _damage;

    public virtual void Shoot()
    {
        var spreadX = UnityEngine.Random.Range(-_spread, _spread);
        var spreadY = UnityEngine.Random.Range(-_spread, _spread);

        var center = _camera.transform.position;
        var ray = new Ray(center, transform.forward + new Vector3(spreadX, spreadY, 0));
        
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out var hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100);
        }
        Debug.DrawRay(center, transform.forward + new Vector3(spreadX, spreadY, 0));
        var direction = targetPoint - _hole.transform.position + new Vector3(spreadX, spreadY, 0);

        var bullet = Instantiate(_bullet, _hole.position, transform.rotation);
        Debug.Log(_hole.transform.position);

        Destroy(bullet, 1);

        if (hit.transform != null && hit.transform.CompareTag("Character"))
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
