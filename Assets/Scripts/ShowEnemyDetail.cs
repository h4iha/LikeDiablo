using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class ShowEnemyDetail : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerController>();
        SetActiveAllChilds(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null)
        {
            if (playerController.target != null)
            {
                SetActiveAllChilds(true);
                //name
                transform.GetChild(3).gameObject.GetComponent<Text>().text = playerController.target.name;
                //life current
                transform.GetChild(2).gameObject.GetComponent<Image>().fillAmount = playerController.target.gameObject.GetComponent<EnemyDetails>().current_Life / (float) playerController.target.gameObject.GetComponent<EnemyDetails>().final_Life;
            }
        }
        else SetActiveAllChilds(false);
    }
    //private void ShowEnemyDetailS()
    //{
    //    //if (target != null)
    //    //{
    //    //    enemyDetail.SetActive(true);
    //    //}
    //    //else enemyDetail.SetActive(false);
    //}
    private void SetActiveAllChilds(bool _bool)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(_bool);
        }
    }
}
