using System.Collections;
using System.Collections.Generic;
using TileGeneration;
using UnityEngine;
using UnityEngine.UI;

public enum TileState
{
    _IsVacant,
    _IsOccupied
}

public class Tile : MonoBehaviour
{
   public int _Index;
    public int _TileId;
    [HideInInspector]
    public bool isOccupied;
    public TileState _TileState;
    [HideInInspector]
   public Tile rightNeighbour, leftNeighbour, bottomNeighbour, topNeighbour;
    public GeneralVariables generalVariables;

    private void OnEnable()
    {
        //GetComponent<Image>().sprite = images[tileId];
        GetComponent<SpriteRenderer>().sprite = generalVariables.allTiles[_TileId];

        Invoke(nameof(FindNeighbours), 0.5f);
    }

    public void Clicked()
    {
        if (_TileState==TileState._IsVacant)
        {
            if (_TileId == generalVariables.tileThatCanSpawn)
            {
                //spwan table
                //check availbility
                if (rightNeighbour != null && rightNeighbour._TileState == TileState._IsVacant && rightNeighbour._TileId== generalVariables.tileThatCanSpawn)
                {
                    _TileState = TileState._IsOccupied;
                    rightNeighbour._TileState = TileState._IsOccupied;
                    GameObject newTable = TileFactory.CreateTile(1, transform, generalVariables);
                    newTable.transform.localPosition = new Vector3(0 + GetComponent<SpriteRenderer>().bounds.size.x/2, 0, 0);
                }
                else if (leftNeighbour != null && leftNeighbour._TileState == TileState._IsVacant && leftNeighbour._TileId == generalVariables.tileThatCanSpawn)
                {
                    _TileState = TileState._IsOccupied;
                    leftNeighbour._TileState = TileState._IsOccupied;
                    GameObject newTable = TileFactory.CreateTile(1, transform, generalVariables);
                    newTable.transform.localPosition = new Vector3(0 - GetComponent<SpriteRenderer>().bounds.size.x/2, 0, 0);
                }
                else if (bottomNeighbour != null && bottomNeighbour._TileState == TileState._IsVacant && bottomNeighbour._TileId == generalVariables.tileThatCanSpawn)
                {
                    _TileState = TileState._IsOccupied;
                    bottomNeighbour._TileState = TileState._IsOccupied;
                    GameObject newTable = TileFactory.CreateTile(2, transform, generalVariables);
                    newTable.transform.localPosition = new Vector3(0 , 0 - GetComponent<SpriteRenderer>().bounds.size.y / 2, 0);
                }
                else if (topNeighbour != null && topNeighbour._TileState == TileState._IsVacant && topNeighbour._TileId == generalVariables.tileThatCanSpawn)
                {
                    _TileState = TileState._IsOccupied;
                    topNeighbour._TileState = TileState._IsOccupied;
                    GameObject newTable = TileFactory.CreateTile(2, transform, generalVariables);
                    newTable.transform.localPosition = new Vector3(0 , 0+ GetComponent<SpriteRenderer>().bounds.size.y / 2, 0);

                }
            }
        }
    }

    private void OnMouseDown()
    {
        Clicked();
    }

    


    void FindNeighbours()
    {
        //find right neighbour
        if ((_Index+1) % generalVariables.cols != 0) {
            rightNeighbour = transform.parent.GetChild(_Index+1).GetComponent<Tile>();
        }
        //find left neighbour
        if ((_Index+1) % generalVariables.cols!= 1)
        {
            leftNeighbour = transform.parent.GetChild(_Index - 1).GetComponent<Tile>();
        }

        //find bottom neighbour
        if ((_Index+1) <= generalVariables.cols*(generalVariables.rows-1))
        {
            bottomNeighbour = transform.parent.GetChild(_Index + generalVariables.cols).GetComponent<Tile>();
        }
        //find top neighbour
        if (((_Index + 1)) > generalVariables.cols)
        {
            topNeighbour = transform.parent.GetChild(_Index-generalVariables.cols).GetComponent<Tile>();
        }

        
    }
}
