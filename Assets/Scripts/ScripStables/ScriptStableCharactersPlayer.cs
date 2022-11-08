using UnityEngine;
[CreateAssetMenu(fileName = "ScriptStableCharactersPlayer", menuName = "Prefabs/ScriptStableObjects/ScriptStableCharactersPlayer")]
public class ScriptStableCharactersPlayer : MonoBehaviour
{
    [Header("Details")]
    public string nameCharacter;
    [Space]
    [Header("Attributes")]
    public int baseStrength;
    public int baseDexterity;
    public int baseVitality;
    public int baseEnergy;
    [Header("Stat")]
    public int baseLife;

}
