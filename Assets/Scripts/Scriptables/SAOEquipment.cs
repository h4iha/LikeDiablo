using UnityEngine;
[CreateAssetMenu(fileName = "SAOEquipment", menuName = "Prefabs/SAO/SAOEquipment")]
public class SAOEquipment : ScriptableObject
{
    public string nameEquipment;
    public string typeEquipment; // Weapons // Shields // Body Equipment: Helms Armor Circles Gloves Belts Boots // Amulets Rings Jewels
    public string sizeWeapon;
    public int qualityLevel;
    public int levelRequirement;
}
