using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Attributes attributes;

    [Header("Attributes")]
    public float _Strength;
    public float _Dexterity;
    public float _Speed;

    public string _playerPrimaryAttribute;
    public float _damage;
    public float _hitPoint;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    private void Start()
    {

    }
}
