using Assets.Scripts;
using UnityEngine;

public class Shield : Character
{
    
    private ParticleSystem ParticleSystem{get;set;}
    private void Start()
    {
        Health = 200;
    }
    private void OnDestroy() 
    {
        ParticleSystem.Play();
    }
}