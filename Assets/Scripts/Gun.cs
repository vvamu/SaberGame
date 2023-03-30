using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _hole;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _spread;
    [SerializeField] private float _bulletForce;
    [SerializeField] private float _delayBeforeNextShot;
    [SerializeField] private float _damage;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject _hitEffect;

    private float _currentTimeToShot;

    [SerializeField] private Ammo _ammo;

    private void Start()
    {
        _currentTimeToShot = _delayBeforeNextShot;
        _ammo._currentInClipCount = _ammo._clipCapacity;
    }
    private void Update()
    {
        Shoot();
    }
    private void Shoot()
    {
        if (!CanShoot()) return;

        var ray = new Ray(_hole.position, _hole.forward);
        Vector3 targetPoint;
        RaycastHit hit;

        _muzzleFlash.Play();

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
            GameObject hitEffectClone = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal)); 
            Destroy(hitEffectClone, 1);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(_damage);
            }
        }
        else
        {
            targetPoint = ray.GetPoint(100);
        }
        var spreadX = Random.Range(-_spread, _spread);
        var spreadY = Random.Range(-_spread, _spread);

        var direction = targetPoint - _hole.position + new Vector3(spreadX, spreadY, 0);

        var bullet = Instantiate(_bullet, _hole.position, Quaternion.AngleAxis(90, Vector3.right));

        bullet.GetComponent<Rigidbody>().AddForce(direction.normalized * _bulletForce, ForceMode.Impulse);

        _ammo._currentInClipCount--;
        _currentTimeToShot = 0;

        if (_ammo._currentInClipCount <= 0)
        {
            Reload();
        }

        StartCoroutine(TimerIncreacing());
        
    }
    private void Reload()
    {
        var lessAmmo = _ammo._clipCapacity >= _ammo._currentCount ? _ammo._currentCount : _ammo._clipCapacity;
        _ammo._currentInClipCount = lessAmmo;
        _ammo._currentCount -= lessAmmo;
    }
    private IEnumerator TimerIncreacing()
    {
        while (_currentTimeToShot < _delayBeforeNextShot)
        {
            _currentTimeToShot += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    private bool CanShoot()
    {
       return Input.GetMouseButtonDown(0)
            && _currentTimeToShot >= _delayBeforeNextShot
            && _ammo._currentInClipCount > 0;
    }
}
