using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fxckingParticle : MonoBehaviour
{
    [SerializeField] private GameObject _muzzle;
    private double timer;
    private double needTime = 0.2f;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButton(1)){
            timer += Time.deltaTime;
            if(timer>= needTime){
                var effect = Instantiate(_muzzle);
                Destroy(effect, 0.3f);
            }
        }
        else {
            timer = 0;
        }if(Input.GetMouseButtonDown(1)){
                var effect = Instantiate(_muzzle);
                Destroy(effect, 0.3f);
            
        }
        
    }
}
