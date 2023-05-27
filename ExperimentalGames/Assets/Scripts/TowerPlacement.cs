using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacement : MonoBehaviour
{
    public List<GameObject> towerPrefabs;
    public GameObject towerListUI;

    private bool isPlacingTower;
    public bool startPlacement;
    private GameObject currentTower;
    public Vector3 currentTilePosition;

    public int towerCost = 50;

    public TowerPlacement placementSpot;

    void OnMouseDown()
    {
        towerListUI.GetComponent<TowerListUI>().ShowTowerList(transform.position);
        towerListUI.GetComponent<TowerListUI>().ChooseTowerSpot(this);
    }

    private void Update()
    {
        if (isPlacingTower)
        {
            currentTilePosition = this.transform.position;

            PlaceTower();
        }
    }

    private void PlaceTower()
    {
        Tower selectedTower = towerListUI.GetComponent<TowerListUI>().GetSelectedTower(transform.position);

        if (selectedTower != null)
        {
            if (PlayerStats.Money >= towerCost)
            {
                // Instantiate the selected tower prefab and place it at the current tile position
                Tower tower = Instantiate(selectedTower, currentTilePosition, Quaternion.identity);
                tower.transform.SetParent(transform);
                Debug.Log("Placing" + selectedTower);

                // Clean up the current tower placement state
                isPlacingTower = false;
                // Destroy the current tower placement object
                Destroy(currentTower);
                PlayerStats.Money -= towerCost;
            } else
            {
                Debug.Log("Not enough money to place tower!");
            }
        }
    }

    public void StartTowerPlacement()
    {
        if (!isPlacingTower)
        {
            // Instantiate a new tower placement object
            currentTower = new GameObject("CurrentTower");
            currentTower.transform.SetParent(transform);

            // Show the tower list UI
            towerListUI.SetActive(true);

            // Set the isPlacingTower flag to true
            isPlacingTower = true;
        }
    }

    public void EndTowerPlacement()
    {
        if (isPlacingTower)
        {
            // Hide the tower list UI
            towerListUI.SetActive(false);

            // Clean up the current tower placement state
            isPlacingTower = false;
            currentTower = null;
            currentTilePosition = Vector3.zero;
        }
    }
}