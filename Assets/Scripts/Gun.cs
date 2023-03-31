using Assets.Scripts;
using System;
using System.Collections;
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
    [SerializeField] private float _bulletLifeTime;

    private float _currentTimeToShot;

    [SerializeField] private Ammo _ammo;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioClip _shot;
    [SerializeField] private AudioClip _reload;
    [SerializeField] private AudioSource _audioSource;

    public float Damage => _damage;

    private void Start()
    {
        _currentTimeToShot = _delayBeforeNextShot;
        _ammo._currentInClipCount = _ammo._clipCapacity;
    }
    private void Update()
    {
        Aiming();
        Shoot();
    }
    private void Aiming()
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
    private void Shoot()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (!CanShoot()) return;

        _audioSource.clip = _shot;
        _audioSource.Play();

        var ray = new Ray(_hole.position, _hole.forward);
        Vector3 targetPoint;
        RaycastHit hit;

        _muzzleFlash.Play();

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
            GameObject hitEffectClone = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal)); 
            Destroy(hitEffectClone, 1);

            Enemy target = hit.transform.GetComponent<Enemy>();
            if(target != null)
            {
                target.TakeDamage(Convert.ToInt32(_damage));
            }
        }
        else
        {
            targetPoint = ray.GetPoint(100);
        }
        var spreadX = UnityEngine.Random.Range(-_spread, _spread);
        var spreadY = UnityEngine.Random.Range(-_spread, _spread);

        var direction = targetPoint - _hole.position + new Vector3(spreadX, spreadY, 0);

        var bullet = Instantiate(_bullet, _hole.position, Quaternion.AngleAxis(90, Vector3.right));
        Destroy(bullet, _bulletLifeTime);

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
        _audioSource.clip = _reload;
        _audioSource.Play();

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
       return _currentTimeToShot >= _delayBeforeNextShot
            && _ammo._currentInClipCount > 0;
    }
}
