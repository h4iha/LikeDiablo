using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] GridLayoutGroup gridGame;
    [SerializeField] GameObject cellPrefab;

    void Start()
    {
        calculateSpacingAndCellSizeGridLG(4);
        createBoard(4);
    }

    void calculateSpacingAndCellSizeGridLG(int numOfRows)
    {
        // Size cell = 20 Space, Space 1024/ (20 * Space
        float spacing = 1024 / (float)(21 * numOfRows + 1);
        gridGame.cellSize = new Vector2(20 * spacing, 20 * spacing);
        gridGame.spacing = new Vector2(spacing, spacing);
    }


    void createBoard(int numOfRows)
    {
        for (int i = 0; i < gridGame.transform.childCount; i++)
            Destroy(gridGame.transform.GetChild(i).gameObject);
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numOfRows; j++)
            {
                GameObject newCellGO = Instantiate(cellPrefab, transform);
                newCellGO.name = (i * numOfRows + j).ToString();
            }
        }
    }

    public void newGame()
    {
        calculateSpacingAndCellSizeGridLG(6);
        createBoard(6);
        //random number apear
    }
}
