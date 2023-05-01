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

    void OnMouseDown()
    {
        towerListUI.GetComponent<TowerListUI>().ShowTowerList(transform.position);
    }

    private void Update()
    {
        if (isPlacingTower)
        {
            currentTower.transform.position = currentTilePosition;

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                PlaceTower();
            }
        }
    }

    private void PlaceTower()
    {
        Tower selectedTower = towerListUI.GetComponent<TowerListUI>().GetSelectedTower();

        if (selectedTower != null)
        {
            // Instantiate the selected tower prefab and place it at the current tile position
            Tower tower = Instantiate(selectedTower, currentTilePosition, Quaternion.identity);
            tower.transform.SetParent(transform);
            Debug.Log("Placing"+selectedTower);

            // Clean up the current tower placement state
            isPlacingTower = false;
            currentTower = null;
            currentTilePosition = Vector3.zero;
        }
    }

    public void StartTowerPlacement()
    {
        if (!isPlacingTower)
        {
            // Instantiate a new tower placement object
            currentTower = new GameObject("CurrentTower");
            currentTower.transform.SetParent(transform);

            // Set the current tower to the first tower in the tower prefabs list
            var towerPrefab = towerPrefabs[0];
            var towerRenderer = towerPrefab.GetComponent<SpriteRenderer>();
            var towerSize = towerRenderer.bounds.size;
            currentTower.transform.position = transform.position;
            var towerSprite = towerRenderer.sprite;
            currentTower.AddComponent<SpriteRenderer>().sprite = towerSprite;

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
            // Destroy the current tower placement object
            Destroy(currentTower);

            // Hide the tower list UI
            towerListUI.SetActive(false);

            // Clean up the current tower placement state
            isPlacingTower = false;
            currentTower = null;
            currentTilePosition = Vector3.zero;
        }
    }
}