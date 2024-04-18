using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tile : MonoBehaviour
{
   public int index;
    public int tileId;
    public bool isOccupied;
    public Sprite[] images;
   public Tile rightNeighbour, leftNeighbour, bottomNeighbour, topNeighbour;
    public GameObject horizontalTable,verticleTable;
    private void OnEnable()
    {
        //GetComponent<Image>().sprite = images[tileId];
        GetComponent<SpriteRenderer>().sprite = images[tileId];

        Invoke(nameof(FindNeighbours), 0.5f);
    }

    public void Clicked()
    {
        if (!isOccupied)
        {
            if (tileId == 3)
            {
                //spwan table
                //check availbility
                if (rightNeighbour != null && !rightNeighbour.isOccupied && rightNeighbour.tileId==3)
                {
                    isOccupied = true;
                    rightNeighbour.isOccupied = true;
                    GameObject newTable = Instantiate(horizontalTable, transform);
                    newTable.transform.localPosition = new Vector3(0 + GetComponent<SpriteRenderer>().bounds.size.x/2, 0, 0);
                }
                else if (leftNeighbour != null && !leftNeighbour.isOccupied && leftNeighbour.tileId == 3)
                {
                    isOccupied = true;
                    leftNeighbour.isOccupied = true;
                    GameObject newTable = Instantiate(horizontalTable, transform);
                    newTable.transform.localPosition = new Vector3(0 - GetComponent<SpriteRenderer>().bounds.size.x/2, 0, 0);
                }
                else if (bottomNeighbour != null && !bottomNeighbour.isOccupied && bottomNeighbour.tileId == 3)
                {
                    isOccupied = true;
                    bottomNeighbour.isOccupied = true;
                    GameObject newTable = Instantiate(verticleTable, transform);
                    newTable.transform.localPosition = new Vector3(0 , 0 - GetComponent<SpriteRenderer>().bounds.size.y / 2, 0);
                }
                else if (topNeighbour != null && !topNeighbour.isOccupied && topNeighbour.tileId == 3)
                {
                    isOccupied = true;
                    topNeighbour.isOccupied = true;
                    GameObject newTable = Instantiate(verticleTable, transform);
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
        if (index % 16 != 0) {
            rightNeighbour = transform.parent.GetChild(index).GetComponent<Tile>();
        }
        //find left neighbour
        if (index % 16 != 1)
        {
            leftNeighbour = transform.parent.GetChild(index - 2).GetComponent<Tile>();
        }

        //find bottom neighbour
        if (index <= 240)
        {
            bottomNeighbour = transform.parent.GetChild(index + 15).GetComponent<Tile>();
        }
        //find top neighbour
        if (index > 16)
        {
            topNeighbour = transform.parent.GetChild(index-17).GetComponent<Tile>();
        }

        
    }
}
