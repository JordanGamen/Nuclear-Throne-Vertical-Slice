﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
[SerializeField]
public class Weapon : ScriptableObject
{
    [SerializeField] private string weaponName = "";
    public string Name { get { return weaponName; } }

    [SerializeField] private Sprite sprite;
    public Sprite SpriteOfWeapon { get { return sprite; } }

    [SerializeField] private Sprite uiSprite;
    public Sprite UiSprite { get { return uiSprite; } }

    public enum type { SINGLE, AUTO}
    public type weaponType;

    [SerializeField] private Bullet bullet;
    public Bullet WeaponBullet { get { return bullet; } set { bullet = value; } }

    [SerializeField] private int damage;
    public int Damage { get { return damage; } }

    [SerializeField] private float reloadTime = 0.5f;
    public float ReloadTime { get { return reloadTime; } }

    [SerializeField] private float shootCoords = 0;
    public float ShootCoords { get { return shootCoords; } }

    [SerializeField] private int ammoWaste = 1;
    public int AmmoWaste { get { return ammoWaste; } }

    [SerializeField] private int shootBullets = 1;
    public int ShootBullets { get { return shootBullets; } }

    [SerializeField] private int spreadAngle = 0;
    public int SpreadAngle { get { return spreadAngle; } }

    [SerializeField] private int fixedAngle = 0;
    public int FixedAngle { get { return fixedAngle; } }

    [SerializeField] private bool melee = false;
    public bool Melee { get { return melee; } }
}
