using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/InifiniteAmmo")]
public class InifiniteAmmo : WeaponAmmo
{
    public override int CurrentAmount { get => int.MaxValue; set { } }
    public override int MaxAmount { get => int.MaxValue; set { } }
}