using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAmmo : ScriptableObject
{
    public abstract int CurrentAmount { get; set; }
    public abstract int MaxAmount { get; set; }
}
