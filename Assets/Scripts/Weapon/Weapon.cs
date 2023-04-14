using Assets.Scripts;
using System;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform _hole;
    [SerializeField] protected Ammo _ammo;
    [SerializeField] protected ShotDelayTimer _delayTimer;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Camera _camera;

    [SerializeField] protected float _spread;
    [SerializeField] protected float _damage;

    public virtual void Shoot()
    {
        var spreadX = UnityEngine.Random.Range(-_spread, _spread);
        var spreadY = UnityEngine.Random.Range(-_spread, _spread);

        //var direction =  + new Vector3(spreadX, spreadY, 0);

        //var ray = new Ray(_hole.position, direction);
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
        Debug.DrawRay(center, direction, Color.red);

        if (hit.transform.CompareTag("Enemy"))
        {
            hit.transform.GetComponent<Enemy>().TakeDamage(Convert.ToInt32(_damage));
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
