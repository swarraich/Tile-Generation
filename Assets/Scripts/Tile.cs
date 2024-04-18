using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tile : MonoBehaviour
{
   public int index;
    public int tileId;
    [HideInInspector]
    public bool isOccupied;
    [HideInInspector]
   public Tile rightNeighbour, leftNeighbour, bottomNeighbour, topNeighbour;
    public GeneralVariables generalVariables;

    private void OnEnable()
    {
        //GetComponent<Image>().sprite = images[tileId];
        GetComponent<SpriteRenderer>().sprite = generalVariables.allTiles[tileId];

        Invoke(nameof(FindNeighbours), 0.5f);
    }

    public void Clicked()
    {
        if (!isOccupied)
        {
            if (tileId == generalVariables.tileThatCanSpawn)
            {
                //spwan table
                //check availbility
                if (rightNeighbour != null && !rightNeighbour.isOccupied && rightNeighbour.tileId== generalVariables.tileThatCanSpawn)
                {
                    isOccupied = true;
                    rightNeighbour.isOccupied = true;
                    GameObject newTable = Instantiate(generalVariables.horizontalTable, transform);
                    newTable.transform.localPosition = new Vector3(0 + GetComponent<SpriteRenderer>().bounds.size.x/2, 0, 0);
                }
                else if (leftNeighbour != null && !leftNeighbour.isOccupied && leftNeighbour.tileId == generalVariables.tileThatCanSpawn)
                {
                    isOccupied = true;
                    leftNeighbour.isOccupied = true;
                    GameObject newTable = Instantiate(generalVariables.horizontalTable, transform);
                    newTable.transform.localPosition = new Vector3(0 - GetComponent<SpriteRenderer>().bounds.size.x/2, 0, 0);
                }
                else if (bottomNeighbour != null && !bottomNeighbour.isOccupied && bottomNeighbour.tileId == generalVariables.tileThatCanSpawn)
                {
                    isOccupied = true;
                    bottomNeighbour.isOccupied = true;
                    GameObject newTable = Instantiate(generalVariables.verticleTable, transform);
                    newTable.transform.localPosition = new Vector3(0 , 0 - GetComponent<SpriteRenderer>().bounds.size.y / 2, 0);
                }
                else if (topNeighbour != null && !topNeighbour.isOccupied && topNeighbour.tileId == generalVariables.tileThatCanSpawn)
                {
                    isOccupied = true;
                    topNeighbour.isOccupied = true;
                    GameObject newTable = Instantiate(generalVariables.verticleTable, transform);
                    newTable.transform.localPosition = new Vector3(0 , 0+ GetComponent<SpriteRenderer>().bounds.size.y / 2, 0);

                }
            }
        }
    }

    private void OnMouseDown()
    {
        //c print("My name is: " + transform.name);
        Clicked();
    }

    


    void FindNeighbours()
    {
        //find right neighbour
        if (index % generalVariables.cols != 0) {
            rightNeighbour = transform.parent.GetChild(index).GetComponent<Tile>();
        }
        //find left neighbour
        if (index % generalVariables.cols!= 1)
        {
            leftNeighbour = transform.parent.GetChild(index - 2).GetComponent<Tile>();
        }

        //find bottom neighbour
        if (index <= generalVariables.cols*(generalVariables.rows-1))
        {
            bottomNeighbour = transform.parent.GetChild(index + 15).GetComponent<Tile>();
        }
        //find top neighbour
        if (index > generalVariables.cols)
        {
            topNeighbour = transform.parent.GetChild(index-17).GetComponent<Tile>();
        }

        
    }
}
