using Assets.Scripts.Weapon.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapon.Trigger
{
    public abstract class TriggerPull : MonoBehaviour, ITrigger
    {
        public abstract void Press();
        public abstract void Release();
    }
}