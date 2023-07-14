using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventBus
{
    public static Action onHit;
    public static Action<float, float> onGrenadeReload;
    public static Action<float, float> onHealthChange;
    public static Action<float, float> onShieldChange;
    public static Action<int> onWeaponChange;
}
