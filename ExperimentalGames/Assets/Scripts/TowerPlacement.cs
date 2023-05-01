using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacement : MonoBehaviour
{
    public List<GameObject> towerPrefabs;
    public GameObject towerListUI;

    private bool isPlacingTower;
    private GameObject currentTower;
    private Vector3 currentTilePosition;

    void OnMouseDown()
    {
        towerListUI.GetComponent<TowerListUI>().ShowTowerList(transform.position);
        Debug.Log("Showing Tower List");
    }

    private void Update()
    {
        if (isPlacingTower)
        {
            currentTower.transform.position = currentTilePosition;

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                PlaceTower();
            }
        }
    }

    private void PlaceTower()
    {
        var selectedTower = towerListUI.GetComponent<TowerListUI>().GetSelectedTower();

        if (selectedTower != null)
        {
            // Instantiate the selected tower prefab and place it at the current tile position
            var tower = Instantiate(selectedTower, currentTilePosition, Quaternion.identity);
            tower.transform.SetParent(transform);

            // Clean up the current tower placement state
            isPlacingTower = false;
            currentTower = null;
            currentTilePosition = Vector3.zero;
        }
    }

    public void StartTowerPlacement(Vector3 tilePosition)
    {
        if (!isPlacingTower)
        {
            // Instantiate a new tower placement object
            currentTower = new GameObject("CurrentTower");
            currentTower.transform.SetParent(transform);

            // Set the current tower position to the center of the clicked tile
            currentTilePosition = tilePosition + new Vector3(0.5f, 0.5f, 0f);

            // Set the current tower to the first tower in the tower prefabs list
            var towerPrefab = towerPrefabs[0];
            var towerRenderer = towerPrefab.GetComponent<SpriteRenderer>();
            var towerSize = towerRenderer.bounds.size;
            currentTower.transform.position = currentTilePosition - new Vector3(0f, towerSize.y / 2f, 0f);
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