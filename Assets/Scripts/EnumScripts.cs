
using System.Runtime.Serialization;

#region Character
public enum Enum_CharacterType
{
    [EnumMember(Value = "Player")] Player = 0, [EnumMember(Value = "Enemy")] Enemy = 1,
}
//
#region Type
public enum Enum_Classes
{
    [EnumMember(Value = "Amazon")] Amazon = 1,
    [EnumMember(Value = "Barbarian")] Barbarian = 2,
    [EnumMember(Value = "Necromancer")] Necromancer = 3,
    [EnumMember(Value = "Paladin")] Paladin = 4,
    [EnumMember(Value = "Sorceress")] Sorceress = 5,
}
#endregion
//
#region Name AnimState
public enum Enum_NameAnimationState
{
    [EnumMember(Value = "Idle")] Idle = 0,
    [EnumMember(Value = "Attack")] Attack = 1,
    [EnumMember(Value = "Walking")] Walking = 2,
    [EnumMember(Value = "Death")] Death = 3,
}
#endregion
//
#region Dmage Source
public enum Enum_DamageSource
{ 
    [EnumMember(Value = "Physic")] Physic, // Damage done with melee or ranged Weapons. Defense protects against physical damage. It is the most common type of damage.
    [EnumMember(Value = "Magic")] Magic, // Magic Damage can be inflicted by the use of certain spells. Some Enemies are immune to Magic Damage. Players don't have a resistance to mitigate Magic Damage.
    [EnumMember(Value = "Cold")] Cold, // Damage from cold spells, aura's or cold enchanted weapons. Cold damage can slow down Enemies or even freeze them in place. Cold Resistance protects against it.
    [EnumMember(Value = "Fire")] Fire, // Damage from fire spells, aura's or fire enchanted weapons. Fire Resistance protects against it.
    [EnumMember(Value = "Lightning")] Lightning, // Damage from lightning spells, aura's or Lightning enchanted Weapons. Lightning damage is random, as it almost never does the same amount of damage, instead it deals damage from a determined range. For example 1-40. It means that it can deal you 1 lightning damage, 40 lightning damage or anything in between. Lightning Resistance protects against Lightning damage.
    [EnumMember(Value = "Poison")] Poison, // Damage from Poison spells, aura's or Poisoned Weapons. Poison Damage does full damage over a certain amount of time, usually labeled as damage per second. Poison Resistance protects from poison damage.

}
#endregion
//
#region Primary Attributes
public enum Enum_PointStat
{
    [EnumMember(Value = "Strength")] Strength,
    [EnumMember(Value = "Dexterity")] Dexterity,
    [EnumMember(Value = "Vitality")] Vitality,
    [EnumMember(Value = "Energy")] Energy,
}
#endregion
//
#region Max Min Value
public enum Enum_MinChance
{
    MinChanceToHit = 5,
    MinChanceToBlock = 0,
}
public enum Enum_MaxChance
{
    MaxChanceToHit = 95,
    MaxChanceToBlock = 75,
}
#endregion
//
#endregion

#region Weapon
//
#region Weapon Types
public enum Enum_WeaponType
{
    Axe = 0, // Rìu
    Bow = 1, // Cung
    Club = 2, // Dùi cui
    CrossBow = 3, // Nỏ
    Dagger = 4, // Dao
    Hammer = 5, // Búa
    Javelin = 6, // Lao
    Katar = 7, // Vuốt
    Mace = 8, // Chùy
    Orb = 9, // Viên Ngọc Phép
    Polearm = 10, // Kích
    Scepter = 11, // Quyền Trượng
    Spear = 12, // Giáo
    Stave = 13, // Chùy
    Sword = 14, // Kiếm
    Throwing = 15, // Vũ khí phóng được
    Wand = 16, // Gậy phép
}
#endregion
#endregion

#region Quest
public enum Enum_NameQuest
{

}
#endregion

public enum Enum_MinMax
{
    Min = 0,
    Max = 1,
}

public enum Enum_TypeSkills
{

}
public enum Enum_Skill
{
    skillLeft = 0,
    skillRight = 1,
}