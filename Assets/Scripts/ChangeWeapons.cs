using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeapons : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;

    private void Start()
    {
        weapon1.SetActive(true);
        weapon2.SetActive(false);
    }
    void Update()
    {
        PhysicalChange();
    }
    private void PhysicalChange()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon1.SetActive(true);
            weapon2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon1.SetActive(false);
            weapon2.SetActive(true);
        }
    }
}
