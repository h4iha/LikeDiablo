using UnityEngine;
[CreateAssetMenu(fileName = "Class", menuName = "Prefabs/ScriptableObject/Character/Class")]
public class Scriptable_Monster : ScriptableObject
{
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
    public string branchName1;
    public string branchName2;
    public string branchName3;
}
