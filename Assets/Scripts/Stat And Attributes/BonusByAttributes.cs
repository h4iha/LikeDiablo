using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusByAttributes : MonoBehaviour
{
    public static BonusByAttributes instance;
    public void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
}
