using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Ammo")]
public class LimetedAmmo : WeaponAmmo
{
    public override int CurrentAmount { get => currentAmount; set => currentAmount = value; }
    public override int MaxAmount { get => maxAmount; set => maxAmount = value; }

    [SerializeField] private int currentAmount;
    [SerializeField] private int maxAmount;
}