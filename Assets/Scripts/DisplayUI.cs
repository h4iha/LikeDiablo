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
    PlayerDetails playerDetails;
    // Start is called before the first frame update
    void Start()
    {
        playerDetails = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerDetails>();
        if (enumUI == Enum_UI.Life)
        {
            GetComponent<Image>().fillAmount = playerDetails.current_Life / (float)playerDetails.final_Life;
            if (playerDetails.current_Life == playerDetails.final_Life)
                GetComponentInChildren<Text>().text = "";
            else
                GetComponentInChildren<Text>().text = playerDetails.current_Life.ToString() + " / " + playerDetails.final_Life.ToString();
        }
        if (enumUI == Enum_UI.Mana)
        {
            GetComponent<Image>().fillAmount = playerDetails.current_Mana / (float)playerDetails.final_Mana;
            if (playerDetails.current_Mana == playerDetails.final_Mana)
                GetComponentInChildren<Text>().text = "";
            else
                GetComponentInChildren<Text>().text = playerDetails.current_Mana.ToString() + " / " + playerDetails.final_Mana.ToString();
        }
        if (enumUI == Enum_UI.Exp)
        {
            GetComponent<Image>().fillAmount = playerDetails.current_Exp / (float)playerDetails.required_Exp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enumUI == Enum_UI.Life)
        {
            GetComponent<Image>().fillAmount = playerDetails.current_Life / (float)playerDetails.final_Life;
            if (playerDetails.current_Life == playerDetails.final_Life)
                GetComponentInChildren<Text>().text = "";
            else
                GetComponentInChildren<Text>().text = playerDetails.current_Life.ToString() + " / " + playerDetails.final_Life.ToString();
        }
        if (enumUI == Enum_UI.Mana)
        {
            GetComponent<Image>().fillAmount = playerDetails.current_Mana / (float)playerDetails.final_Mana;
            if (playerDetails.current_Mana == playerDetails.final_Mana)
                GetComponentInChildren<Text>().text = "";
            else
                GetComponentInChildren<Text>().text = playerDetails.current_Mana.ToString() + " / " + playerDetails.final_Mana.ToString();
        }
        if (enumUI == Enum_UI.Exp)
        {
            GetComponent<Image>().fillAmount = playerDetails.current_Exp / (float)playerDetails.required_Exp;
        }
    }
}
