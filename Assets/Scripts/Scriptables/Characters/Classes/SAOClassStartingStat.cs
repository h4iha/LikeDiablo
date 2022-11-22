using System;
using UnityEngine;
[CreateAssetMenu(fileName = "SAOClassStartingStat", menuName = "Prefabs/SAO/Character/SAOClassStartingStat")]
public class SAOClassStartingStat : ScriptableObject
{
    [Header("Stat")]
    [Space]
    public int life; // The amount of hits your character can endure. If it depletes, your character dies.
    public int mana; // The energy source your character drains upon in order to use Skills.
    [Space]
    [Header(" Point Stat")]
    public int strength; // Strength determines melee physical damage (very minor) and acts as a requirement for most gear.
    public int dexteriry; // Dexterity determines ranged physical damage, Attack Rating and as a requirement for some weapons.
    public int vitality; // Vitality determines life and stamina.
    public int energy; // Energy determines mana.
    [Space]
    [Header("Add Point Stat")]
    public float lifeByPoint; // Life increases each Vitality Point
    public float manaByPoint; // Mana increases each Energy Point
    public float lifeByLevel; // Life increases by level
    public float manaByLevel; // Mana increases by level
}
