using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StaticScripts : MonoBehaviour
{
    [Header("Type Animation")]
    public static string idle = "Idle";
    public static string attack = "Attack";
    public static string walking = "Walking";
    public static string death = "Death";
    [Space]
    [Header("Type Damage")]
    public static string physicDamage = "Physic";
    public static string magicDamage = "Magic";
    // Damage Element
    public static string lightDamage = "Light";
    public static string coldDamage = "Cold";
    public static string fireDamage = "Fire";
    public static string poisonDamage = "Poison";
    [Space]
    [Header("Type Reduce Damage")]
    //Reduce
    public static string reduceDamage = "Physic";
    //Registance
    public static string lightRegistance = "Light";
    public static string coldRegistance = "Cold";
    public static string fireRegistance = "Fire";
    public static string poisonRegistance = "Poison";
    [Space]
    [Header("Chance")]
    public static int minChanceToHit = 5;
    public static int maxChanceToHit = 95;
    public static int maxChanceToBlock = 75;
    [Space]
    [Header("Registances")]
    public static int maxFinalElementFireResistance = 95;
    public static int maxElementFireResistance = 75;
    public static int maxPhysicalResistance = 50;
    public static int maxMagicResistance = 75;
}
