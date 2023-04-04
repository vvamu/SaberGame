using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotDelayTimer : MonoBehaviour
{
    public bool IsReadyToShoot;

    private float _currentDelayTime;

    [SerializeField] private float _delayBeforeNextShot;

    void Update()
    {
        if (_currentDelayTime < _delayBeforeNextShot)
        {
            _currentDelayTime += Time.deltaTime;
            IsReadyToShoot = false;
        }
        else
        {
            IsReadyToShoot = true;
        }
    }
    public void StartTimer()
    {
        _currentDelayTime = 0;
    }
}
