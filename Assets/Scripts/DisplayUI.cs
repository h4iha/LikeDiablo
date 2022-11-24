using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Enum_UI
{
    Mana = 0,
    Life = 1,
    Exp = 2,
}
public class DisplayUI : MonoBehaviour
{
    [SerializeField] Enum_UI enumUI;
    PlayerDetail detail;
    // Start is called before the first frame update
    void Start()
    {
        detail = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerDetail>();
        if (enumUI == Enum_UI.Life)
        {
            GetComponent<Image>().fillAmount = detail.current_Life / (float)detail.final_Life;
            if (detail.current_Life == detail.final_Life)
                GetComponentInChildren<Text>().text = "";
            else
                GetComponentInChildren<Text>().text = detail.current_Life.ToString() + " / " + detail.final_Life.ToString();
        }
        if (enumUI == Enum_UI.Mana)
        {
            GetComponent<Image>().fillAmount = detail.current_Mana / (float)detail.final_Mana;
            if (detail.current_Mana == detail.final_Mana)
                GetComponentInChildren<Text>().text = "";
            else
                GetComponentInChildren<Text>().text = detail.current_Mana.ToString() + " / " + detail.final_Mana.ToString();
        }
        if (enumUI == Enum_UI.Exp)
        {
            GetComponent<Image>().fillAmount = detail.current_Exp / (float)detail.required_Exp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enumUI == Enum_UI.Life)
        {
            GetComponent<Image>().fillAmount = detail.current_Life / (float)detail.final_Life;
            if (detail.current_Life == detail.final_Life)
                GetComponentInChildren<Text>().text = "";
            else
                GetComponentInChildren<Text>().text = detail.current_Life.ToString() + " / " + detail.final_Life.ToString();
        }
        if (enumUI == Enum_UI.Mana)
        {
            GetComponent<Image>().fillAmount = detail.current_Mana / (float)detail.final_Mana;
            if (detail.current_Mana == detail.final_Mana)
                GetComponentInChildren<Text>().text = "";
            else
                GetComponentInChildren<Text>().text = detail.current_Mana.ToString() + " / " + detail.final_Mana.ToString();
        }
        if (enumUI == Enum_UI.Exp)
        {
            GetComponent<Image>().fillAmount = detail.current_Exp / (float)detail.required_Exp;
        }
    }
}
