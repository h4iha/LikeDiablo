using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeAttributes
{
    Life,
    Mana,
    Strength,
    Dexterity,
    Vitality,
    Energy,
    Damage,
    AttackSpeed,
    AttackRating,
    DefenseRating,
}
public class Detail : MonoBehaviour
{
    public int currentMovementSpeed = 200;
    public const int MAX_MOVEMENT_SPEED = 500;
    public int currentLife = 100;
    public int currentMana = 50;
    public int currentDamage = 10;
    public int currentAttackRange = 150;
    public int currentAttackRating = 100;
    public int currentDefenseRating = 30;
    public int currentHeal = 10;
    public int currentRegenation;
    public class Player : Detail
    {
        public int currentMana;
        public int currentRegenation;
    }
    public class Monster : Detail
    {
        public int expGain;

    }

}
