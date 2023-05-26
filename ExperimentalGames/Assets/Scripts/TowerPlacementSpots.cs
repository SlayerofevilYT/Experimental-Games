using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementSpots : MonoBehaviour
{

    public int towerCost = 10;

    public TowerList towerListPanel;
    public Tower[] placeableTowers;

    private void OnMouseDown()
    {
        towerListPanel.ShowTowerList(transform.position);
    }

    public void PickingTowers(int towerInt)
    {
        switch(towerInt){
            case 0:
                placeFirstTower();
                break;
            case 1:
                placeSecondTower();
                break;
            case 2:
                placeThirdTower();
                break;
            case 3:
                placeFourthTower();
                break;
            case 4:
                placeFifthTower();
                break;
        }
    }

    public void placeFirstTower()
    {
        if (PlayerStats.Money >= towerCost)
        {
            Tower tower = Instantiate(placeableTowers[0], transform.position, Quaternion.identity);
            tower.transform.SetParent(transform);
            PlayerStats.Money -= towerCost;
        }
        else
        {
            Debug.Log("Not enough money to place tower!");
        }
    }

    public void placeSecondTower()
    {
        if (PlayerStats.Money >= towerCost)
        {
            Tower tower = Instantiate(placeableTowers[1], transform.position, Quaternion.identity);
            tower.transform.SetParent(transform);
            PlayerStats.Money -= towerCost;
        }
        else
        {
            Debug.Log("Not enough money to place tower!");
        }
    }

    public void placeThirdTower()
    {
        if (PlayerStats.Money >= towerCost)
        {
            Tower tower = Instantiate(placeableTowers[2], transform.position, Quaternion.identity);
            tower.transform.SetParent(transform);
            PlayerStats.Money -= towerCost;
        }
        else
        {
            Debug.Log("Not enough money to place tower!");
        }
    }

    public void placeFourthTower()
    {
        if (PlayerStats.Money >= towerCost)
        {
            Tower tower = Instantiate(placeableTowers[3], transform.position, Quaternion.identity);
            tower.transform.SetParent(transform);
            PlayerStats.Money -= towerCost;
        }
        else
        {
            Debug.Log("Not enough money to place tower!");
        }
    }

    public void placeFifthTower()
    {
        if (PlayerStats.Money >= towerCost)
        {
            Tower tower = Instantiate(placeableTowers[4], transform.position, Quaternion.identity);
            tower.transform.SetParent(transform);
            PlayerStats.Money -= towerCost;
        }
        else
        {
            Debug.Log("Not enough money to place tower!");
        }
    }
}
