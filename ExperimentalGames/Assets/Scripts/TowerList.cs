using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerList : MonoBehaviour
{
    public GameObject towerListPanel;
    public Button closeButton;
    public Button[] towerButtons;

    public TowerPlacementSpots placementSpot;

    void Start()
    {
        towerListPanel.SetActive(false);

        for (int i = 0; i < towerButtons.Length; i++)
        {
            int index = i;
            towerButtons[index].onClick.AddListener(() => { OnTowerButtonClicked(index); });
        }

        // Add a click listener to the close button
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    public void ShowTowerList(Vector3 pos)
    {
        towerListPanel.SetActive(true);
        towerListPanel.transform.position = pos;
    }

    private void OnTowerButtonClicked(int index)
    {
        placementSpot.PickingTowers(index);
    }

    private void OnCloseButtonClicked()
    {
        // Hide the tower list panel
        towerListPanel.SetActive(false);
    }
}
