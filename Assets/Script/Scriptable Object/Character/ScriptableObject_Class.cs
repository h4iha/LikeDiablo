using UnityEngine;
[CreateAssetMenu(fileName = "Class", menuName = "Prefabs/ScriptableObject/Character/Class")]

public class ScriptableObject_Class : ScriptableObject
{
    public TypeCharacter mainWeapon;
    [Header("Starting Attributes")]
    public int lifeStarting;
    public int manaStarting;
    public int strengthStarting;
    public int dexteriyStarting;
    public int vitalityStarting;
    public int energyStarting;
    [Header("Level Up")]
    public float lifeLevelUp;
    public float manaLevelUp;
    [Header("Attributes Point Effect")]
    public float lifePerVitality;
    public float manaPerEnergy;
    [Header("Skill Trees")]
    public ScriptableObjectSkillBranch branch_1;
    public ScriptableObjectSkillBranch branch_2;
    public ScriptableObjectSkillBranch branch_3;
}
