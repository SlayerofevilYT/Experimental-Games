using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementPath : MonoBehaviour
{
    public GameObject towerListUI;
    public GameObject towerListPanel;
    public Tower[] placeableTowers;

    public GameObject selectedSpot;

    public bool isTowerHere = false;

    public UISFXManager SFXManager;

    private void OnMouseDown()
    {
        if (isTowerHere == false && PlayerStats.pathTowerTest == true)
        {
            SFXManager.PlayClickSound();
            towerListUI.GetComponent<TowerListPath>().ShowTowerList(transform.position);
            towerListUI.GetComponent<TowerListPath>().ChooseTowerSpot(this);
        }
    }

    public void PickingTowers(int towerInt)
    {
        switch (towerInt)
        {
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
        if (PlayerStats.Money >= placeableTowers[0].towerCost)
        {
            Tower tower = Instantiate(placeableTowers[0], transform.position, Quaternion.identity);
            tower.transform.SetParent(transform);
            PlayerStats.Money -= placeableTowers[0].towerCost;
            towerListPanel.SetActive(false);
            isTowerHere = true;
        }
        else
        {
            Debug.Log("Not enough money to place tower!");
        }
    }

    public void placeSecondTower()
    {
        if (PlayerStats.Money >= placeableTowers[1].towerCost)
        {
            Tower tower = Instantiate(placeableTowers[1], transform.position, Quaternion.identity);
            tower.transform.SetParent(transform);
            PlayerStats.Money -= placeableTowers[1].towerCost;
            towerListPanel.SetActive(false);
            isTowerHere = true;
        }
        else
        {
            Debug.Log("Not enough money to place tower!");
        }
    }

    public void placeThirdTower()
    {
        if (PlayerStats.Money >= placeableTowers[2].towerCost)
        {
            Tower tower = Instantiate(placeableTowers[2], transform.position, Quaternion.identity);
            tower.transform.SetParent(transform);
            PlayerStats.Money -= placeableTowers[2].towerCost;
            towerListPanel.SetActive(false);
            isTowerHere = true;
        }
        else
        {
            Debug.Log("Not enough money to place tower!");
        }
    }

    public void placeFourthTower()
    {
        if (PlayerStats.Money >= placeableTowers[3].towerCost)
        {
            Tower tower = Instantiate(placeableTowers[3], transform.position, Quaternion.identity);
            tower.transform.SetParent(transform);
            PlayerStats.Money -= placeableTowers[3].towerCost;
            towerListPanel.SetActive(false);
            isTowerHere = true;
        }
        else
        {
            Debug.Log("Not enough money to place tower!");
        }
    }

    public void placeFifthTower()
    {
        if (PlayerStats.Money >= placeableTowers[4].towerCost)
        {
            Tower tower = Instantiate(placeableTowers[4], transform.position, Quaternion.identity);
            tower.transform.SetParent(transform);
            PlayerStats.Money -= placeableTowers[4].towerCost;
            towerListPanel.SetActive(false);
            isTowerHere = true;
        }
        else
        {
            Debug.Log("Not enough money to place tower!");
        }
    }
}
