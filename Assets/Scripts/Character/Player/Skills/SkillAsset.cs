using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAsset : MonoBehaviour
{
    public static SkillAsset Instance;
    private void Awake()
    {
        Instance = this;
    }
    public GameObject skillUIPrefab;
    public Sprite weaponSprite;
    public Sprite potionSprite;
    public GameObject potionGo;
    public GameObject weaponGo;
}
